Imports System.Windows.Forms
Imports System.Drawing
Imports DrawIt.Helpers
Imports DrawIt.Models

Public Class CanvasDrawMouseHandler
    Implements ICanvasMouseHandler

    Public Function OnMouseDown(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseDown
        If MainForm.Operation <> MainForm.Operations.Draw Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        Dim screenPt = e.Location
        Dim worldPt = context.ToWorldPoint(screenPt)
        state.MouseDownPoint = worldPt

        context.DeselectAll()
        Dim sty As ShapeStyle = [Enum].Parse(GetType(ShapeStyle), MainForm.cb_Shape.SelectedItem)
        Dim bty As BrushType = [Enum].Parse(GetType(BrushType), MainForm.cb_Brush.SelectedItem)

        Select Case sty
            Case ShapeStyle.Lines, ShapeStyle.Polygon, ShapeStyle.Curves, ShapeStyle.ClosedCurve
                state.DrawInfo.ShapeType = sty
                If e.Button = MouseButtons.Right Then
                    state.DrawInfo.DrawMode = True
                    If My.Computer.Keyboard.AltKeyDown Then
                        If state.DrawInfo.Points.Count > 0 Then
                            Dim ind = context.DPInCursor(screenPt)
                            If ind > -1 Then state.DrawInfo.Points.RemoveAt(ind)
                        End If
                    Else
                        Dim n_pt As PointF = worldPt
                        If My.Computer.Keyboard.CtrlKeyDown Then
                            If state.DrawInfo.Points.Count > 0 Then n_pt.X = state.DrawInfo.Points.Last().X
                        ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                            If state.DrawInfo.Points.Count > 0 Then n_pt.Y = state.DrawInfo.Points.Last().Y
                        End If
                        state.DrawInfo.Points.Add(n_pt)
                        state.CurrentLocation = n_pt
                    End If
                ElseIf e.Button = MouseButtons.Left Then
                    If state.DrawInfo.Points.Count >= context.DModeMin() Then
                        Dim minPt As PointF
                        Dim maxPt As PointF
                        minPt.X = state.DrawInfo.Points.Min(Function(pt As PointF) pt.X)
                        minPt.Y = state.DrawInfo.Points.Min(Function(pt As PointF) pt.Y)
                        maxPt.X = state.DrawInfo.Points.Max(Function(pt As PointF) pt.X)
                        maxPt.Y = state.DrawInfo.Points.Max(Function(pt As PointF) pt.Y)
                        If minPt.X = maxPt.X Then maxPt.X += 1
                        If minPt.Y = maxPt.Y Then maxPt.Y += 1

                        Dim newShape As New Shape(minPt, sty, bty)
                        Dim rectf As New RectangleF(minPt, New SizeF(maxPt.X - minPt.X, maxPt.Y - minPt.Y))
                        newShape.SetAllRect(rectf)

                        Dim percPts = New List(Of PointF)
                        state.DrawInfo.Points.ForEach(Sub(x) percPts.Add(MathUtils.ToPercentage(rectf, x)))
                        If state.DrawInfo.ShapeType = 4 OrElse state.DrawInfo.ShapeType = 5 Then
                            Dim linesData = TryCast(newShape.MShape, MyLines)
                            If Not IsNothing(linesData) Then
                                linesData.PolygonPoints = percPts.ToArray()
                            Else
                                Dim polygonData = TryCast(newShape.MShape, MyPolygon)
                                If Not IsNothing(polygonData) Then polygonData.PolygonPoints = percPts.ToArray()
                            End If
                        Else
                            Dim curvesData = TryCast(newShape.MShape, MyCurves)
                            If Not IsNothing(curvesData) Then
                                curvesData.CurvePoints = percPts.ToArray()
                            Else
                                Dim closedCurveData = TryCast(newShape.MShape, MyClosedCurve)
                                If Not IsNothing(closedCurveData) Then closedCurveData.CurvePoints = percPts.ToArray()
                            End If
                        End If

                        newShape.Selected = True
                        state.Shapes.Add(newShape)
                        context.ClearDrawingData()
                        context.UpdateControls()
                    ElseIf Not state.DrawInfo.DrawMode Then
                        Dim shp_n = New Shape(worldPt, sty, bty) With {
                            .Selected = True
                        }
                        state.Shapes.Add(shp_n)
                        state.CurrentOperation = MOperations.Draw
                        context.UpdateControls()
                    End If
                End If
                context.InvalidateCanvas()
            Case Else
                Dim shp_n = New Shape(worldPt, sty, bty) With {.Selected = True}
                state.Shapes.Add(shp_n)
                state.CurrentOperation = MOperations.Draw
                context.UpdateControls()
        End Select

        Return CanvasMouseHandlerResult.CaptureResult
    End Function

    Public Function OnMouseMove(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseMove
        If MainForm.Operation <> MainForm.Operations.Draw Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        Dim worldPt = context.ToWorldPoint(e.Location)
        context.CanvasCursor = Cursors.Cross

        If state.CurrentOperation = MOperations.Draw Then
            Dim shp_d = context.MainSelected()
            If IsNothing(shp_d) Then Return CanvasMouseHandlerResult.HandledResult

            Dim rtd As New RectangleF(Math.Min(worldPt.X, state.MouseDownPoint.X),
                                      Math.Min(worldPt.Y, state.MouseDownPoint.Y),
                                      Math.Abs(worldPt.X - state.MouseDownPoint.X),
                                      Math.Abs(worldPt.Y - state.MouseDownPoint.Y))
            shp_d.FlipX = worldPt.X - state.MouseDownPoint.X < 0
            shp_d.FlipY = worldPt.Y - state.MouseDownPoint.Y < 0

            If My.Computer.Keyboard.ShiftKeyDown Then
                Dim mxx As Integer = Math.Max(rtd.Width, rtd.Height)
                rtd.Width = mxx
                rtd.Height = mxx
                If worldPt.Y <= state.MouseDownPoint.Y Then rtd.Y = state.MouseDownPoint.Y - rtd.Height
                If worldPt.X <= state.MouseDownPoint.X Then rtd.X = state.MouseDownPoint.X - rtd.Width
            End If

            If My.Computer.Keyboard.CtrlKeyDown Then
                If worldPt.X > state.MouseDownPoint.X Then rtd.X -= rtd.Width
                If worldPt.Y > state.MouseDownPoint.Y Then rtd.Y -= rtd.Height
                rtd.Width *= 2
                rtd.Height *= 2
            End If

            shp_d.SetAllRect(rtd)
            context.InvalidateCanvas()
            context.UpdateBoundControls()
        End If

        If state.DrawInfo.DrawMode AndAlso state.DrawInfo.Points.Count > 0 Then
            Dim n_pt As PointF = worldPt
            If My.Computer.Keyboard.CtrlKeyDown Then
                n_pt.X = state.DrawInfo.Points.Last().X
            ElseIf My.Computer.Keyboard.ShiftKeyDown Then
                n_pt.Y = state.DrawInfo.Points.Last().Y
            End If
            state.CurrentLocation = n_pt
            context.InvalidateCanvas()
        End If

        Return CanvasMouseHandlerResult.HandledResult
    End Function

    Public Function OnMouseUp(context As ICanvasInteractionContext, e As MouseEventArgs) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseUp
        If MainForm.Operation <> MainForm.Operations.Draw Then Return CanvasMouseHandlerResult.Ignore
        If context.IsPanInputActive() Then Return CanvasMouseHandlerResult.Ignore

        Dim state = context.State
        If Not state.DrawInfo.DrawMode Then context.SwitchToSelectMode()
        state.CurrentOperation = MOperations.None
        Return CanvasMouseHandlerResult.ReleaseResult
    End Function

    Public Function OnMouseLeave(context As ICanvasInteractionContext) As CanvasMouseHandlerResult Implements ICanvasMouseHandler.OnMouseLeave
        Dim state = context.State
        If MainForm.Operation = MainForm.Operations.Draw Then
            state.CurrentLocation = PointF.Empty
        Else
            state.Hover.ShapeIndex = -1
        End If
        context.InvalidateCanvas()
        Return CanvasMouseHandlerResult.HandledResult
    End Function
End Class
