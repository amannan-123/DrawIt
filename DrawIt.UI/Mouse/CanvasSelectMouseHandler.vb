Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DrawIt.Helpers
Imports DrawIt.Models

Public Class CanvasSelectMouseHandler
    Implements ICanvasMouseHandler

    Private Function AnchorTypeToOperation(anchorType As Canvas.AnchorType) As MOperations
        Select Case anchorType
            Case Canvas.AnchorType.TopLeft : Return MOperations.TopLeft
            Case Canvas.AnchorType.Top : Return MOperations.Top
            Case Canvas.AnchorType.TopRight : Return MOperations.TopRight
            Case Canvas.AnchorType.Left : Return MOperations.Left
            Case Canvas.AnchorType.Right : Return MOperations.Right
            Case Canvas.AnchorType.BottomLeft : Return MOperations.BottomLeft
            Case Canvas.AnchorType.Bottom : Return MOperations.Bottom
            Case Canvas.AnchorType.BottomRight : Return MOperations.BottomRight
            Case Canvas.AnchorType.Rotate : Return MOperations.Rotate
            Case Else : Return MOperations.None
        End Select
    End Function

    Private Function TryHandleSelectionHit(context As ICanvasInteractionContext, screenPt As PointF, worldPt As PointF, button As MouseButtons, ByRef selectionChanged As Boolean) As Boolean
        If context.GetAnchorsRegion().IsVisible(screenPt) Then Return False
        Dim state = context.State
        Dim selectedCount = context.SelectedIndices().Count

        Dim curr As Integer = context.ShapeInCursor(screenPt)
        If curr > -1 Then
            If Not state.Shapes(curr).Selected Then
                If My.Computer.Keyboard.CtrlKeyDown Then
                    state.MouseUpFix = False
                Else
                    selectionChanged = selectionChanged OrElse selectedCount > 0
                    context.DeselectAll()
                End If
                state.Shapes(curr).Selected = True
                selectionChanged = True
            ElseIf selectedCount > 1 AndAlso button = MouseButtons.Left Then
                context.SetPrimaryByIndex(curr)
            End If
            Return False
        End If

        If Not My.Computer.Keyboard.CtrlKeyDown Then
            selectionChanged = selectionChanged OrElse selectedCount > 0
            context.DeselectAll()
        End If
        If selectionChanged Then context.SetPrimary()
        state.CurrentOperation = MOperations.Selection
        state.SelectionRect = New RectangleF(worldPt, SizeF.Empty)
        context.UpdateControls()
        context.InvalidateCanvas()
        Return True
    End Function

    Private Sub InitializeSelectionOperation(context As ICanvasInteractionContext, screenPt As PointF, button As MouseButtons, selc As List(Of Integer), shp As Shape)
        If IsNothing(shp) OrElse selc.Count = 0 Then Return
        Dim state = context.State

        state.CurrentOperation = MOperations.None
        shp.RotationPoint = MathUtils.FromPercentage(shp.GetRect, New PointF(50, 50))
        state.RotationCenter = shp.RotationPoint
        state.RotationAngle = shp.Angle
        state.NegateX = shp.FlipX
        state.NegateY = shp.FlipY

        If selc.Count = 1 Then
            state.ResizeRects.Add(shp.GetRect)
        Else
            Dim boundsAll = context.MultipleSelectionBounds()
            For Each ind As Integer In selc
                Dim ss As Shape = state.Shapes(ind)
                state.ResizeRects.Add(MathUtils.ToPercentage(boundsAll, ss.GetRect))
            Next
            state.ResizeBounds = boundsAll
        End If
        context.CaptureMoveSnapshot(selc)

        Dim anchorType = context.GetAnchorType(screenPt)
        If anchorType = Canvas.AnchorType.BrushCenter Then
            If button = MouseButtons.Left Then
                state.CurrentOperation = MOperations.Centering
            ElseIf button = MouseButtons.Right Then
                Dim pathBrush = TryCast(shp.FBrush, MyPathGradientBrush)
                If Not IsNothing(pathBrush) Then pathBrush.CenterPoint = New PointF(50, 50)
            End If
            Return
        End If

        Dim anchorOperation = AnchorTypeToOperation(anchorType)
        If anchorOperation <> MOperations.None Then
            state.CurrentOperation = anchorOperation
            Return
        End If

        Using selectedRegion As New Region(Rectangle.Empty)
            For Each ind As Integer In selc
                Using shapeRegion = state.Shapes(ind).Region()
                    If Not IsNothing(shapeRegion) Then selectedRegion.Union(shapeRegion)
                End Using
            Next
            Using wm As Matrix = context.GetWorldToScreenMatrix()
                selectedRegion.Transform(wm)
            End Using
            If selectedRegion.IsVisible(screenPt) Then
                state.CurrentOperation = MOperations.Move
                context.CanvasCursor = Cursors.SizeAll
                selc.ForEach(Sub(i) state.Shapes(i).Moving = True)
            End If
        End Using
    End Sub

    Private Sub UpdateSelectionRectangle(context As ICanvasInteractionContext, worldPt As PointF)
        Dim state = context.State
        state.SelectionRect = New RectangleF(Math.Min(worldPt.X, state.MouseDownPoint.X),
                                             Math.Min(worldPt.Y, state.MouseDownPoint.Y),
                                             Math.Abs(worldPt.X - state.MouseDownPoint.X),
                                             Math.Abs(worldPt.Y - state.MouseDownPoint.Y))
        If Not My.Computer.Keyboard.CtrlKeyDown Then context.DeselectAll()
        For Each ss As Shape In state.Shapes
            Using ss_rg = ss.Region()
                If Not ss.Selected AndAlso Not IsNothing(ss_rg) Then
                    If ss_rg.IsVisible(state.SelectionRect) Then
                        ss.Selected = True
                    End If
                End If
            End Using
        Next
        context.SetPrimary()
    End Sub

    Private Sub UpdateSelectionHover(context As ICanvasInteractionContext, screenPt As PointF, selc As List(Of Integer))
        Dim state = context.State
        Dim settingsHover = context.HighlightShapesEnabled
        If Not settingsHover OrElse state.CurrentOperation <> MOperations.None OrElse state.Shapes.Count <= selc.Count Then Return

        Dim curr As Integer = context.ShapeInCursor(screenPt)
        If curr > -1 AndAlso Not context.GetAnchorsRegion().IsVisible(screenPt) Then
            If state.Shapes(curr).Selected = False Then
                If Not IsNothing(state.Shapes(curr).BorderPath) AndAlso Not IsNothing(state.Shapes(curr).TotalPath) Then
                    state.Hover.ShapeIndex = curr
                    If context.IsPathHit(state.Shapes(curr).BorderPath, screenPt) Then
                        state.Hover.HoverType = 1
                    ElseIf context.IsPathHit(state.Shapes(curr).TotalPath, screenPt) Then
                        state.Hover.HoverType = 0
                    End If
                    context.InvalidateCanvas()
                    Return
                End If
            End If
        End If

        If state.Hover.ShapeIndex <> -1 Then
            state.Hover.ShapeIndex = -1
            context.InvalidateCanvas()
        End If
    End Sub

    Private Sub UpdateSelectionCursor(context As ICanvasInteractionContext, screenPt As PointF, selc As List(Of Integer), shp As Shape)
        Dim state = context.State
        If state.CurrentOperation <> MOperations.None Then Return

        Dim anchorType = context.GetAnchorType(screenPt)
        Dim currentAngle = 0
        If selc.Count = 1 AndAlso Not IsNothing(shp) Then currentAngle = shp.Angle

        If anchorType = Canvas.AnchorType.BrushCenter Then
            context.CanvasCursor = Cursors.Hand
            Return
        End If

        Dim anchorOperation = AnchorTypeToOperation(anchorType)
        If anchorOperation <> MOperations.None Then
            context.CanvasCursor = AnchorToCursor(anchorOperation, currentAngle)
        Else
            context.CanvasCursor = Cursors.Arrow
        End If
    End Sub

    Public Function OnMouseDown(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseDown
        If MainForm.Operation <> MainForm.Operations.Select Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        Dim screenPt = e.Location
        Dim worldPt = context.ToWorldPoint(screenPt)
        Dim selectionChanged As Boolean = False
        state.MouseDownPoint = worldPt
        state.Hover.ShapeIndex = -1

        If TryHandleSelectionHit(context, screenPt, worldPt, e.Button, selectionChanged) Then Return CanvasMouseHandlerResult.CaptureResult

        Dim shp = context.MainSelected()
        Dim selc = context.SelectedIndices()
        InitializeSelectionOperation(context, screenPt, e.Button, selc, shp)

        If selectionChanged Then context.SetPrimary()
        context.UpdateControls()
        context.InvalidateCanvas()
        Return CanvasMouseHandlerResult.CaptureResult
    End Function

    Public Function OnMouseMove(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseMove
        If MainForm.Operation <> MainForm.Operations.Select Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        Dim screenPt = e.Location
        Dim worldPt = context.ToWorldPoint(screenPt)

        If state.CurrentOperation = MOperations.Selection Then
            UpdateSelectionRectangle(context, worldPt)
        End If

        Dim selc = context.SelectedIndices()
        UpdateSelectionHover(context, screenPt, selc)

        Dim shp = context.MainSelected()
        UpdateSelectionCursor(context, screenPt, selc, shp)

        Dim tDest As PointF = worldPt
        Dim tPt As PointF
        Dim tRc, oRc As RectangleF

        If selc.Count > 0 Then
            If state.ResizeRects.Count = 1 Then
                If shp.Angle <> 0 Then tDest = RotatePoint(tDest, state.MouseDownPoint, -shp.Angle)
                tRc = state.ResizeRects.First
            Else
                tRc = state.ResizeBounds
            End If
            tPt = New PointF(tDest.X - state.MouseDownPoint.X, tDest.Y - state.MouseDownPoint.Y)
            oRc = tRc
        End If

        Select Case state.CurrentOperation
            Case MOperations.Centering
                Dim npt As PointF = RotatePoint(worldPt, shp.RotationPoint, -shp.Angle)
                Dim pathBrush = TryCast(shp.FBrush, MyPathGradientBrush)
                If Not IsNothing(pathBrush) Then pathBrush.CenterPoint = MathUtils.ToPercentage(shp.GetRect, npt)
            Case MOperations.TopLeft
                tRc.X += tPt.X : tRc.Width -= tPt.X : tRc.Y += tPt.Y : tRc.Height -= tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then
                    tRc.Height -= tPt.Y : tRc.Width -= tPt.X
                End If
            Case MOperations.Top
                tRc.Y += tPt.Y : tRc.Height -= tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then tRc.Height -= tPt.Y
            Case MOperations.TopRight
                tRc.Width += tPt.X : tRc.Y += tPt.Y : tRc.Height -= tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then
                    tRc.Height -= tPt.Y : tRc.X -= tPt.X : tRc.Width += tPt.X
                End If
            Case MOperations.Left
                tRc.X += tPt.X : tRc.Width -= tPt.X
                If My.Computer.Keyboard.CtrlKeyDown Then tRc.Width -= tPt.X
            Case MOperations.Right
                tRc.Width += tPt.X
                If My.Computer.Keyboard.CtrlKeyDown Then tRc.X -= tPt.X : tRc.Width += tPt.X
            Case MOperations.BottomLeft
                tRc.X += tPt.X : tRc.Width -= tPt.X : tRc.Height += tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then
                    tRc.Width -= tPt.X : tRc.Y -= tPt.Y : tRc.Height += tPt.Y
                End If
            Case MOperations.Bottom
                tRc.Height += tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then tRc.Y -= tPt.Y : tRc.Height += tPt.Y
            Case MOperations.BottomRight
                tRc.Width += tPt.X : tRc.Height += tPt.Y
                If My.Computer.Keyboard.CtrlKeyDown Then
                    tRc.X -= tPt.X : tRc.Width += tPt.X : tRc.Y -= tPt.Y : tRc.Height += tPt.Y
                End If
            Case MOperations.Rotate
                Dim snAngle As Single = GetAngleBetweenTwoPointsWithFixedPoint(state.MouseDownPoint, worldPt, state.RotationCenter)
                snAngle = -snAngle * 180 / Math.PI
                shp.Angle = EditRotateAngle(state.RotationAngle, snAngle, e.Button = MouseButtons.Left)
            Case MOperations.Move
                If My.Computer.Keyboard.CtrlKeyDown AndAlso Not state.IsCloned Then
                    state.OldSelectionIndices.Clear()
                    selc.ForEach(Sub(i) state.OldSelectionIndices.Add(i))
                    context.CloneSelected()
                    selc = context.SelectedIndices()
                    context.CaptureMoveSnapshot(selc)
                    state.IsCloned = True
                    state.IsCloning = True
                End If
                If state.IsCloning AndAlso Not My.Computer.Keyboard.CtrlKeyDown Then
                    Dim currentSel = selc
                    For i As Integer = 0 To state.OldSelectionIndices.Count - 1
                        If i >= currentSel.Count Then Exit For
                        If state.OldSelectionIndices(i) < 0 OrElse state.OldSelectionIndices(i) >= state.Shapes.Count Then Continue For
                        If currentSel(i) < 0 OrElse currentSel(i) >= state.Shapes.Count Then Continue For
                        Dim ss As Shape = state.Shapes(currentSel(i))
                        state.Shapes(state.OldSelectionIndices(i)).SetAllRect(ss.GetRect)
                        state.Shapes(state.OldSelectionIndices(i)).Selected = False
                        state.Shapes(state.OldSelectionIndices(i)).Moving = False
                    Next
                    context.DeleteSelected()
                    For i As Integer = 0 To state.OldSelectionIndices.Count - 1
                        If state.OldSelectionIndices(i) < 0 OrElse state.OldSelectionIndices(i) >= state.Shapes.Count Then Continue For
                        state.Shapes(state.OldSelectionIndices(i)).Selected = True
                        state.Shapes(state.OldSelectionIndices(i)).Moving = True
                    Next
                    context.CaptureMoveSnapshot(context.SelectedIndices())
                    state.IsCloned = False
                    state.IsCloning = False
                End If

                Dim iXMove As Single = worldPt.X - state.MouseDownPoint.X
                Dim iYMove As Single = worldPt.Y - state.MouseDownPoint.Y
                For Each snap In state.MoveSnapshot
                    Dim ss = snap.Key
                    If IsNothing(ss) OrElse Not ss.Selected Then Continue For
                    Dim dRc As RectangleF = snap.Value
                    If My.Computer.Keyboard.ShiftKeyDown Then
                        Dim dX = Math.Abs(iXMove)
                        Dim dY = Math.Abs(iYMove)
                        If dX > dY Then
                            dRc.Offset(iXMove, 0)
                        ElseIf dY > dX Then
                            dRc.Offset(0, iYMove)
                        Else
                            Dim iinc = Math.Max(iXMove, iYMove)
                            dRc.Offset(iinc, iinc)
                        End If
                    Else
                        dRc.Offset(iXMove, iYMove)
                    End If
                    ss.SetAllRect(dRc)
                    ss.RotationPoint = MathUtils.FromPercentage(ss.GetRect, New PointF(50, 50))
                Next
        End Select

        If state.CurrentOperation >= MOperations.TopLeft AndAlso state.CurrentOperation <= MOperations.BottomRight Then
            If My.Computer.Keyboard.ShiftKeyDown Then
                Dim rtd As RectangleF = tRc
                Dim asp As Single = oRc.Width / oRc.Height
                Select Case state.CurrentOperation
                    Case MOperations.TopLeft, MOperations.TopRight, MOperations.BottomLeft, MOperations.BottomRight
                        If oRc.Width > oRc.Height Then
                            rtd.Height = Math.Abs(rtd.Width) / asp
                        ElseIf oRc.Width < oRc.Height Then
                            rtd.Width = Math.Abs(rtd.Height) * asp
                        Else
                            Dim mxx As Integer = Math.Max(rtd.Width, rtd.Height)
                            rtd.Width = mxx : rtd.Height = mxx
                        End If
                    Case MOperations.Top, MOperations.Bottom
                        rtd.Width = Math.Abs(rtd.Height) * asp
                    Case MOperations.Left, MOperations.Right
                        rtd.Height = Math.Abs(rtd.Width) / asp
                End Select
                If state.CurrentOperation = MOperations.TopLeft OrElse state.CurrentOperation = MOperations.TopRight Then
                    rtd.Y = oRc.Bottom - rtd.Height
                End If
                If state.CurrentOperation = MOperations.TopLeft OrElse state.CurrentOperation = MOperations.BottomLeft Then
                    rtd.X = oRc.Right - rtd.Width
                End If
                tRc = rtd
            End If

            If tRc.Width = 0 OrElse tRc.Height = 0 Then Return CanvasMouseHandlerResult.HandledResult
            If state.NegateX Then oRc.Width *= -1
            If state.NegateY Then oRc.Height *= -1

            shp.FlipX = (tRc.Width * oRc.Width < 0)
            shp.FlipY = (tRc.Height * oRc.Height < 0)

            If selc.Count = 1 Then
                shp.SetAllRect(tRc)
            Else
                For ind As Integer = 0 To selc.Count - 1
                    Dim ss As Shape = state.Shapes(selc(ind))
                    ss.SetAllRect(MathUtils.FromPercentage(tRc, state.ResizeRects(ind)))
                    ss.RotationPoint = MathUtils.FromPercentage(ss.GetRect, New PointF(50, 50))
                Next
            End If
        End If

        If state.CurrentOperation <> MOperations.None Then
            context.InvalidateCanvas()
            context.UpdateBoundControls()
        End If

        Return CanvasMouseHandlerResult.HandledResult
    End Function

    Public Function OnMouseUp(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseUp
        If MainForm.Operation <> MainForm.Operations.Select Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        Dim screenPt = e.Location
        Dim worldPt = context.ToWorldPoint(screenPt)

        Dim isSameClick As Boolean = Math.Abs(worldPt.X - state.MouseDownPoint.X) < 0.001F AndAlso Math.Abs(worldPt.Y - state.MouseDownPoint.Y) < 0.001F
        If My.Computer.Keyboard.CtrlKeyDown AndAlso isSameClick AndAlso state.MouseUpFix Then
            Dim curr As Integer = context.ShapeInCursor(screenPt)
            If curr > -1 Then
                state.Shapes(curr).Selected = Not state.Shapes(curr).Selected
            End If
        End If

        If state.CurrentOperation >= MOperations.TopLeft AndAlso state.CurrentOperation <= MOperations.BottomRight Then
            Dim shp = context.MainSelected()
            If Not IsNothing(shp) Then context.FinalizeResize(shp)
        End If

        state.ResizeRects.Clear()
        state.MoveSnapshot.Clear()
        state.MouseUpFix = True
        state.Shapes.ForEach(Sub(x) x.Moving = False)
        context.EnsurePrimarySelected()
        state.IsCloned = False
        state.IsCloning = False

        If state.CurrentOperation <> MOperations.None Then
            context.UpdateControls()
            state.CurrentOperation = MOperations.None
        Else
            context.UpdateBoundControls()
        End If

        state.SelectionRect = Rectangle.Empty
        context.InvalidateCanvas()
        Return CanvasMouseHandlerResult.ReleaseResult
    End Function

    Public Function OnMouseLeave(context As ICanvasInteractionContext) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseLeave
        Return CanvasMouseHandlerResult.Ignore
    End Function
End Class
