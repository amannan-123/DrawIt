Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Public Class Canvas

#Region "New"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserMouse, True)
        SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Sub New(frm As MainForm)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserMouse, True)
        SetStyle(ControlStyles.UserPaint, True)
        _frm = frm
    End Sub
#End Region

#Region "Enum"
    Enum SelectOrder
        AboveFirst
        BelowFirst
    End Enum
#End Region

#Region "Properties"
    Private _frm As MainForm
    Public Property MainForm() As MainForm
        Get
            Return _frm
        End Get
        Set(ByVal value As MainForm)
            _frm = value
        End Set
    End Property

    Private _ord As SelectOrder = SelectOrder.AboveFirst
    <DefaultValue(GetType(SelectOrder), "AboveFirst")>
    Public Property SelectionOrder() As SelectOrder
        Get
            Return _ord
        End Get
        Set(ByVal value As SelectOrder)
            _ord = value
            Invalidate()
        End Set
    End Property

    Private hg_pth As Color = Color.Blue
    <DefaultValue(GetType(Color), "Blue")>
    Public Property PathHighlightColor() As Color
        Get
            Return hg_pth
        End Get
        Set(ByVal value As Color)
            hg_pth = value
        End Set
    End Property

    Private hg_brd As Color = Color.Lime
    <DefaultValue(GetType(Color), "Lime")>
    Public Property BorderHighlightColor() As Color
        Get
            Return hg_brd
        End Get
        Set(ByVal value As Color)
            hg_brd = value
        End Set
    End Property

    Private clr_sz As Color = Color.Black
    <DefaultValue(GetType(Color), "Black")>
    Public Property SizeTextColor() As Color
        Get
            Return clr_sz
        End Get
        Set(ByVal value As Color)
            clr_sz = value
        End Set
    End Property

    Private clr_sel As Color = Color.Gray
    <DefaultValue(GetType(Color), "Gray")>
    Public Property SelectionRectangleColor() As Color
        Get
            Return clr_sel
        End Get
        Set(ByVal value As Color)
            clr_sel = value
        End Set
    End Property

    Private _highlight As Boolean = True
    <DefaultValue(GetType(Boolean), "True")>
    Public Property HighlightShapes() As Boolean
        Get
            Return _highlight
        End Get
        Set(ByVal value As Boolean)
            _highlight = value
        End Set
    End Property
#End Region

#Region "Globals"
    Dim img As Bitmap
    Dim shps As New List(Of Shape)
    Dim cloned As Boolean = False
    Dim cloning As Boolean = False
    Dim up_fix As Boolean = True
    Dim old_sl As New List(Of Integer)
    Dim ht_shp As Integer
    Dim htype As Integer = 0
    Dim op As MOperations = MOperations.None
    Dim m_pt As Point
    Dim m_cnt As PointF
    Dim m_rect As New List(Of RectangleF)
    Dim m_ang As Single
    Dim s_rect As New Rectangle
#End Region

#Region "Functions"
    Public Function ShapeInCursor(_loc As Point) As Integer
        Dim ind As Integer = -1
        If shps.Count = 0 Then
            Return ind
        Else
            Select Case _ord
                Case SelectOrder.AboveFirst
                    For Each shp As Shape In shps
                        If Not IsNothing(shp.SelectionPath) AndAlso Not IsNothing(shp.BorderPath) Then
                            If shp.SelectionPath.IsVisible(_loc) Or
                                shp.BorderPath.IsVisible(_loc) Then
                                ind = shps.IndexOf(shp)
                            End If
                        End If
                    Next
                Case SelectOrder.BelowFirst
                    For Each shp As Shape In shps
                        If Not IsNothing(shp.SelectionPath) AndAlso Not IsNothing(shp.BorderPath) Then
                            If shp.SelectionPath.IsVisible(_loc) Or
                                shp.BorderPath.IsVisible(_loc) Then
                                Return shps.IndexOf(shp)
                            End If
                        End If
                    Next
            End Select
        End If
        Return ind
    End Function

    Public Function MainSelected() As Shape
        Dim shp As Shape = Nothing
        If (SelectedIndices().Count > 0) Then
            If _ord = SelectOrder.AboveFirst Then
                shp = shps(SelectedIndices().Last)
            Else
                shp = shps(SelectedIndices().First)
            End If
        End If
        Return shp
    End Function

    Public Function SelectedIndices() As List(Of Integer)
        Dim inds As New List(Of Integer)
        For i As Integer = 0 To shps.Count - 1
            Dim shp As Shape = shps(i)
            If shp.Selected Then inds.Add(shps.IndexOf(shp))
        Next
        Return inds
    End Function

    Public Sub SetPrimary()
        For Each ss As Shape In shps
            ss.Primary = False
        Next
        If SelectedIndices.Count > 0 Then
            If _ord = SelectOrder.AboveFirst Then
                shps(SelectedIndices().Last).Primary = True
            Else
                shps(SelectedIndices().First).Primary = True
            End If
        End If
    End Sub

    Public Sub SetMoving()
        For Each ss As Shape In shps
            ss.Moving = False
        Next
    End Sub

    Public Sub DeselectAll()
        For Each shp As Shape In shps
            shp.Selected = False
        Next
    End Sub

    Public Sub CloneSelected()
        Dim lst_sl As New List(Of Shape)
        For Each i As Integer In SelectedIndices()
            lst_sl.Add(shps(i).Clone)
        Next
        DeselectAll()
        For Each sh As Shape In lst_sl
            shps.Add(sh)
        Next
    End Sub

    Public Sub DeleteSelected()
        For i As Integer = SelectedIndices.Count - 1 To 0 Step -1
            shps.RemoveAt(SelectedIndices()(i))
        Next
    End Sub
#End Region

#Region "Mouse Events"
    Private Sub Canvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ht_shp = -1
        m_pt = e.Location

        Dim curr As Integer = ShapeInCursor(e.Location)
        Dim shp As Shape = Nothing

        If MainForm.rDraw.Checked Then
            DeselectAll()
            Dim sty As MyShape.ShapeStyle = [Enum].Parse(GetType(MyShape.ShapeStyle), MainForm.cb_Shape.SelectedItem)
            Dim bty As MyBrush.BrushType = [Enum].Parse(GetType(MyBrush.BrushType), MainForm.cb_Brush.SelectedItem)
            shp = New Shape(m_pt, sty, bty)
            shp.Selected = True
            shps.Add(shp)
            op = MOperations.Draw
        ElseIf MainForm.rSelect.Checked Then
            If curr > -1 Then
                If shps(curr).Selected = False Then
                    If My.Computer.Keyboard.CtrlKeyDown = False Then
                        DeselectAll()
                    Else
                        up_fix = False
                    End If
                    shps(curr).Selected = True
                End If
            Else
                If My.Computer.Keyboard.CtrlKeyDown = False Then DeselectAll()
                op = MOperations.Selection
                s_rect.Location = e.Location
                Return
            End If
        End If

        shp = MainSelected()

        If Not IsNothing(shp) AndAlso MainForm.rDraw.Checked = False Then
            m_ang = shp.Angle
            m_rect.Clear()
            m_cnt = New PointF(shp.BaseRect.X + (shp.BaseRect.Width / 2),
                             shp.BaseRect.Y + (shp.BaseRect.Height / 2))
            shp.CenterPoint = m_cnt

            Dim m_path As New Region(Rectangle.Empty)

            For Each ind As Integer In SelectedIndices()
                Dim ss As Shape = shps(ind)
                m_path.Union(ss.TotalPath)
                m_path.Union(ss.BorderPath)
                m_rect.Add(ss.BaseRect)
            Next

            If shp.FBrush.BType = MyBrush.BrushType.PathGradient AndAlso shp.Centering.IsVisible(e.Location) Then
                If e.Button = MouseButtons.Left Then
                    op = MOperations.Centering
                ElseIf e.Button = MouseButtons.Right Then
                    shp.FBrush.PCenterPoint = New PointF(50, 50)
                End If
            ElseIf shp.TopLeft.IsVisible(e.Location) Then
                op = MOperations.TopLeft
            ElseIf shp.Top.IsVisible(e.Location) Then
                op = MOperations.Top
            ElseIf shp.TopRight.IsVisible(e.Location) Then
                op = MOperations.TopRight
            ElseIf shp.Left.IsVisible(e.Location) Then
                op = MOperations.Left
            ElseIf shp.Right.IsVisible(e.Location) Then
                op = MOperations.Right
            ElseIf shp.BottomLeft.IsVisible(e.Location) Then
                op = MOperations.BottomLeft
            ElseIf shp.Bottom.IsVisible(e.Location) Then
                op = MOperations.Bottom
            ElseIf shp.BottomRight.IsVisible(e.Location) Then
                op = MOperations.BottomRight
            ElseIf shp.Rotate.IsVisible(e.Location) Then
                op = MOperations.Rotate
            ElseIf m_path.IsVisible(e.Location) Then
                op = MOperations.Move
                Cursor = Cursors.SizeAll
                For Each i As Integer In SelectedIndices()
                    shps(i).Moving = True
                Next
            End If
            m_path.Dispose()
        End If
        SetPrimary()
        MainForm.UpdateControls()
        Invalidate()
    End Sub

    Private Sub Canvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If op = MOperations.Selection Then
            s_rect = New Rectangle(Math.Min(e.X, m_pt.X),
                                   Math.Min(e.Y, m_pt.Y),
                                   Math.Abs(e.X - m_pt.X),
                                   Math.Abs(e.Y - m_pt.Y))
            If My.Computer.Keyboard.CtrlKeyDown = False Then DeselectAll()
            For Each ss As Shape In shps
                If ss.Selected = False AndAlso Not IsNothing(ss.BorderPath) AndAlso
                   Not IsNothing(ss.SelectionPath(False)) Then
                    Dim b_rg As New Region(ss.BorderPath)
                    If ss.SelectionPath(False).IsVisible(s_rect) Or b_rg.IsVisible(s_rect) Then
                        ss.Selected = True
                    End If
                End If
            Next
            SetPrimary()
        End If

        Dim shp As Shape = MainSelected()

        'highlight shape
        If HighlightShapes AndAlso op = MOperations.None AndAlso MainForm.rSelect.Checked AndAlso shps.Count > 0 Then
            Dim curr As Integer = ShapeInCursor(e.Location)
            If curr > -1 Then
                If shps(curr).Selected = False AndAlso
                    Not IsNothing(shps(curr).BorderPath) AndAlso
                    Not IsNothing(shps(curr).SelectionPath) Then
                    ht_shp = curr
                    If shps(curr).BorderPath.IsVisible(e.Location) Then
                        htype = 1
                    ElseIf shps(curr).SelectionPath.IsVisible(e.Location) Then
                        htype = 0
                    End If
                Else
                    ht_shp = -1
                End If
            Else
                ht_shp = -1
            End If
            Invalidate()
        End If

        'set cursors
        If MainForm.rDraw.Checked Then
            Cursor = Cursors.Cross
        Else
            If Not IsNothing(shp) AndAlso op = MOperations.None Then
                If shp.FBrush.BType = MyBrush.BrushType.PathGradient AndAlso shp.Centering.IsVisible(e.Location) Then
                    Cursor = Cursors.Hand
                ElseIf shp.TopLeft.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.TopLeft, shp.Angle)
                ElseIf shp.Top.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.Top, shp.Angle)
                ElseIf shp.TopRight.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.TopRight, shp.Angle)
                ElseIf shp.Left.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.Left, shp.Angle)
                ElseIf shp.Right.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.Right, shp.Angle)
                ElseIf shp.BottomLeft.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.BottomLeft, shp.Angle)
                ElseIf shp.Bottom.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.Bottom, shp.Angle)
                ElseIf shp.BottomRight.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.BottomRight, shp.Angle)
                ElseIf shp.Rotate.IsVisible(e.Location) Then
                    Cursor = AnchorToCursor(MOperations.Rotate, shp.Angle)
                Else
                    Cursor = Cursors.Arrow
                End If
            End If
        End If

        'create and initialize variables
        Dim tDest As PointF = e.Location
        Dim tPt As PointF
        Dim tRc As RectangleF
        If Not IsNothing(shp) Then
            If shp.Angle Then tDest = RotatePoint(tDest, m_pt, -shp.Angle)
            tPt = New PointF((tDest.X - m_pt.X), (tDest.Y - m_pt.Y))
            If m_rect.Count > 0 Then
                If _ord = SelectOrder.AboveFirst Then
                    tRc = m_rect.Last
                Else
                    tRc = m_rect.First
                End If
            End If
        End If

        Select Case op
            Case MOperations.Centering
                Dim npt As PointF = RotatePoint(e.Location, shp.CenterPoint, -shp.Angle)
                shp.FBrush.PCenterPoint = ToPercentage(shp.BaseRect, npt)
            Case MOperations.Draw
                shp.BaseRect = New RectangleF(Math.Min(e.X, m_pt.X),
                                   Math.Min(e.Y, m_pt.Y),
                                   Math.Abs(e.X - m_pt.X),
                                   Math.Abs(e.Y - m_pt.Y))
            Case MOperations.TopLeft
                tRc.X += tPt.X
                tRc.Width -= tPt.X
                tRc.Y += tPt.Y
                tRc.Height -= tPt.Y
            Case MOperations.Top
                tRc.Y += tPt.Y
                tRc.Height -= tPt.Y
            Case MOperations.TopRight
                tRc.Width += tPt.X
                tRc.Y += tPt.Y
                tRc.Height -= tPt.Y
            Case MOperations.Left
                tRc.X += tPt.X
                tRc.Width -= tPt.X
            Case MOperations.Right
                tRc.Width += tPt.X
            Case MOperations.BottomLeft
                tRc.X += tPt.X
                tRc.Width -= tPt.X
                tRc.Height += tPt.Y
            Case MOperations.Bottom
                tRc.Height += tPt.Y
            Case MOperations.BottomRight
                tRc.Width += tPt.X
                tRc.Height += tPt.Y
            Case MOperations.Rotate
                Dim snAngle As Single = GetAngleBetweenTwoPointsWithFixedPoint(m_pt, e.Location, m_cnt)
                snAngle = -snAngle * 180.0# / Math.PI
                Dim qt As Boolean = False
                If e.Button = MouseButtons.Left Then qt = True
                shp.Angle = EditRotateAngle(m_ang, snAngle, qt)
            Case MOperations.Move
                If My.Computer.Keyboard.CtrlKeyDown AndAlso cloned = False Then
                    old_sl.Clear()
                    For Each i As Integer In SelectedIndices()
                        old_sl.Add(i)
                    Next
                    CloneSelected()
                    cloned = True
                    cloning = True
                End If
                If cloning Then
                    If My.Computer.Keyboard.CtrlKeyDown = False Then
                        Dim _lst = SelectedIndices()
                        For i As Integer = 0 To old_sl.Count - 1
                            Dim ss As Shape = shps(_lst(i))
                            shps(old_sl(i)).BaseRect = ss.BaseRect
                            shps(old_sl(i)).Selected = False
                        Next
                        DeleteSelected()
                        For i As Integer = 0 To old_sl.Count - 1
                            shps(old_sl(i)).Selected = True
                        Next
                        cloned = False
                    End If
                End If
                Dim iXMove, iYMove As Single
                iXMove = (e.Location.X - m_pt.X)
                iYMove = (e.Location.Y - m_pt.Y)
                For i As Integer = 0 To m_rect.Count - 1
                    Dim dRc As RectangleF = m_rect(i)
                    dRc.Offset(iXMove, iYMove)
                    Dim ss As Shape = shps(SelectedIndices()(i))
                    ss.BaseRect = dRc
                    ss.CenterPoint = New PointF(ss.BaseRect.X + (ss.BaseRect.Width / 2), ss.BaseRect.Y + (ss.BaseRect.Height / 2))
                Next
        End Select

        'finalize resize operation
        If op >= MOperations.TopLeft AndAlso op <= MOperations.BottomRight Then
            If tRc.Width < 1 Then Return
            If tRc.Height < 1 Then Return
            shp.BaseRect = tRc
        End If

        If op <> MOperations.None Then
            Invalidate()
            MainForm.UpdateBoundControls()
        End If
    End Sub

    Private Sub Canvas_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If My.Computer.Keyboard.CtrlKeyDown AndAlso e.Location = m_pt AndAlso up_fix Then
            Dim curr As Integer = ShapeInCursor(e.Location)
            If curr > -1 Then
                Dim ss = shps(curr)
                ss.Selected = Not ss.Selected
            End If
        End If

        Dim shp As Shape = MainSelected()

        'if rotated shape is resized then adjust its coordinates
        If Not IsNothing(shp) AndAlso shp.Angle <> 0.0 Then
            If op >= MOperations.TopLeft AndAlso op <= MOperations.BottomRight Then
                Dim _rgRect = New Region(shp.BaseRect)
                Dim oMtx = New Matrix
                oMtx.RotateAt(shp.Angle, shp.CenterPoint)
                _rgRect.Transform(oMtx)
                Dim rfNewBounds As RectangleF = _rgRect.GetBounds(CreateGraphics)
                Dim ptNewScreenCenterOrigin As New PointF(rfNewBounds.X + (rfNewBounds.Width / 2), rfNewBounds.Y + (rfNewBounds.Height / 2))
                Dim rcNewRenderRect As New RectangleF((ptNewScreenCenterOrigin.X - (shp.BaseRect.Width / 2)),
                                                          (ptNewScreenCenterOrigin.Y - (shp.BaseRect.Height / 2)),
                                                          shp.BaseRect.Width,
                                                          shp.BaseRect.Height)
                shp.BaseRect = rcNewRenderRect
                shp.CenterPoint = New PointF(shp.BaseRect.X + (shp.BaseRect.Width / 2),
                     shp.BaseRect.Y + (shp.BaseRect.Height / 2))

            End If
        End If
        up_fix = True
        SetMoving()
        SetPrimary()
        cloned = False
        cloning = False
        MainForm.rSelect.Checked = True
        Cursor = Cursors.Default
        op = MOperations.None
        s_rect = Rectangle.Empty
        Invalidate()

    End Sub
#End Region

#Region "Paint Event"
    Private Sub DrawSize(g As Graphics, shp As Shape, Optional ByVal _horz As Boolean = True, Optional ByVal _vert As Boolean = True)
        Select Case shp.Angle
            Case 0, 90, 180, 270, 360
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            Case Else
                g.TextRenderingHint = TextRenderingHint.AntiAlias
        End Select
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        Dim fnt As New Font("Arial", 10)
        If _horz Then
            Dim t_horz As String = Math.Round(shp.BaseRect.Width, 2)
            Dim s_horz As SizeF = g.MeasureString(t_horz, fnt)
            Dim r_horz As New RectangleF(New PointF(shp.BaseRect.Right - s_horz.Width, shp.BaseRect.Bottom + 2), s_horz)
            g.DrawString(t_horz, fnt, New SolidBrush(clr_sz), r_horz, sf)
            If shp.BaseRect.Width > r_horz.Width Then
                Dim p1 As New Point(shp.BaseRect.X, r_horz.Y + (r_horz.Height / 2))
                Dim p2 As New Point(r_horz.Left - 1, p1.Y)
                g.DrawLine(New Pen(clr_sz), p1, p2)
            End If
        End If
        If _vert Then
            sf.FormatFlags = StringFormatFlags.DirectionVertical
            Dim t_vert As String = Math.Round(shp.BaseRect.Height, 2)
            Dim s_vert As SizeF = g.MeasureString(t_vert, fnt)
            Dim r_vert As New RectangleF(New PointF(shp.BaseRect.Right + 2, shp.BaseRect.Top), New SizeF(s_vert.Height, s_vert.Width))
            g.DrawString(t_vert, fnt, New SolidBrush(clr_sz), r_vert, sf)
            If shp.BaseRect.Height > r_vert.Height Then
                Dim p1 As New Point(r_vert.X + (r_vert.Width / 2), r_vert.Bottom + 1)
                Dim p2 As New Point(p1.X, shp.BaseRect.Bottom)
                g.DrawLine(New Pen(clr_sz), p1, p2)
            End If
        End If
        sf.Dispose()
        fnt.Dispose()
    End Sub

    Private Sub DrawAnchorEllipse(g As Graphics, rect As RectangleF)
        rect.Inflate(1, 1)
        g.FillEllipse(New SolidBrush(Color.FromArgb(180, Color.Lime)), rect)
        g.DrawEllipse(Pens.Black, rect)
    End Sub

    Private Sub SetImageSize()
        img = New Bitmap(Width, Height)
    End Sub

    Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim bk As New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
        g.FillRectangle(bk, ClientRectangle)
        bk.Dispose()

        'Draw background of canvas
        g.FillRectangle(New SolidBrush(BackColor), ClientRectangle)

        If Not DesignMode Then
            'Draw all shapes on image
            SetImageSize()
            Dim ig As Graphics = Graphics.FromImage(img)
            ig.SmoothingMode = SmoothingMode.AntiAlias
            For Each shp As Shape In shps
                ig.RenderingOrigin = New Point(shp.BaseRect.Location.X,
                                              shp.BaseRect.Location.Y)
                Dim mm As New Matrix
                mm.RotateAt(shp.Angle, shp.CenterPoint)
                ig.Transform = mm

                Dim br As New SolidBrush(Color.White)
                Dim pn As New Pen(Color.Black, 1)

                'Draw Shape
                If Not IsNothing(shp.TotalPath(False)) Then
                    Dim pth As GraphicsPath = shp.TotalPath(False)
                    If Not IsNothing(shp.CreateBrush) Then
                        ig.RenderingOrigin = Point.Ceiling(shp.TotalPath(False).GetBounds.Location)
                        Dim fbr As Brush = shp.CreateBrush
                        ig.FillPath(fbr, pth)
                        fbr.Dispose()
                    End If
                    If Not IsNothing(shp.CreatePen) Then
                        Dim ppth As GraphicsPath = shp.TotalPath(False)
                        If Not IsNothing(shp.SelectionPen) Then ppth.Widen(shp.SelectionPen)
                        ig.RenderingOrigin = Point.Ceiling(ppth.GetBounds.Location)
                        Dim dpn As Pen = shp.CreatePen
                        ig.DrawPath(dpn, pth)
                        dpn.Dispose()
                    End If
                    pth.Dispose()
                End If

                If shp.Selected Then
                    If shp.Primary Then
                        Dim pth_brd As New GraphicsPath
                        pth_brd.AddRectangle(shp.BaseRect)
                        Dim pn_brd As New Pen(Brushes.Black)
                        pn_brd.DashPattern = New Single() {2, 2, 2}
                        If op = MOperations.Draw Or op = MOperations.Selection Or op = MOperations.None Or (op >= MOperations.TopLeft And op <= MOperations.BottomRight) Then
                            ig.DrawPath(pn_brd, pth_brd)
                        End If

                        Select Case op
                            Case MOperations.None, MOperations.Draw, MOperations.Selection

                                Dim _anchors As New List(Of GraphicsPath)
                                _anchors.Add(shp.TopLeft(False))
                                _anchors.Add(shp.Top(False))
                                _anchors.Add(shp.TopRight(False))
                                _anchors.Add(shp.Left(False))
                                _anchors.Add(shp.Right(False))
                                _anchors.Add(shp.BottomLeft(False))
                                _anchors.Add(shp.Bottom(False))
                                _anchors.Add(shp.BottomRight(False))
                                _anchors.Add(shp.Rotate(False))
                                If shp.FBrush.BType = MyBrush.BrushType.PathGradient Then _anchors.Add(shp.Centering(False))
                                _anchors.Reverse()

                                'Draw all anchors
                                For Each gp As GraphicsPath In _anchors
                                    ig.FillPath(br, gp)
                                    ig.DrawPath(pn, gp)
                                Next
                                _anchors.Clear()
                                'Draw Rotation Anchor Line
                                Dim pt1 As New PointF(shp.Top(False).GetBounds().X + (shp.Top(False).GetBounds().Width / 2),
                                         shp.Top(False).GetBounds().Top)
                                Dim pt2 As New PointF(shp.Rotate(False).GetBounds().X + (shp.Rotate(False).GetBounds().Width / 2),
                                         shp.Rotate(False).GetBounds().Bottom)
                                ig.DrawLine(pn, pt1, pt2)

                            Case MOperations.TopLeft
                                DrawSize(ig, shp)
                                DrawAnchorEllipse(ig, shp.TopLeft(False).GetBounds)

                            Case MOperations.TopRight
                                DrawSize(ig, shp)
                                DrawAnchorEllipse(ig, shp.TopRight(False).GetBounds)

                            Case MOperations.BottomLeft
                                DrawSize(ig, shp)
                                DrawAnchorEllipse(ig, shp.BottomLeft(False).GetBounds)

                            Case MOperations.BottomRight
                                DrawSize(ig, shp)
                                DrawAnchorEllipse(ig, shp.BottomRight(False).GetBounds)

                            Case MOperations.Top
                                DrawSize(ig, shp, False)
                                DrawAnchorEllipse(ig, shp.Top(False).GetBounds)

                            Case MOperations.Bottom
                                DrawSize(ig, shp, False)
                                DrawAnchorEllipse(ig, shp.Bottom(False).GetBounds)

                            Case MOperations.Left
                                DrawSize(ig, shp,, False)
                                DrawAnchorEllipse(ig, shp.Left(False).GetBounds)

                            Case MOperations.Right
                                DrawSize(ig, shp,, False)
                                DrawAnchorEllipse(ig, shp.Right(False).GetBounds)

                            Case MOperations.Rotate
                                DrawAnchorEllipse(ig, shp.Rotate(False).GetBounds)
                                Dim dist As Single = shp.CenterPoint.Y - shp.BaseRect.Top
                                Dim rectt As New RectangleF(shp.CenterPoint, SizeF.Empty)
                                rectt.Inflate(dist, dist)
                                Dim pnt As New Pen(Color.FromArgb(120, Color.Black), 5)
                                pnt.DashStyle = DashStyle.DashDot
                                pnt.DashCap = DashCap.Round
                                ig.ResetTransform()
                                ig.DrawEllipse(pnt, rectt)
                                pnt.Dispose()
                                If shp.BaseRect.Width >= 50 AndAlso shp.BaseRect.Width >= 50 Then
                                    Dim sf As New StringFormat()
                                    sf.Alignment = StringAlignment.Center
                                    sf.LineAlignment = StringAlignment.Center
                                    Dim fnt As New Font("Consolas", 15)
                                    ig.DrawString(shp.Angle.ToString, fnt, Brushes.Black, shp.BaseRect, sf)
                                    sf.Dispose()
                                    fnt.Dispose()
                                End If
                        End Select
                    Else
                        If shp.Moving = False Then
                            Dim rtt As Rectangle = Rectangle.Ceiling(shp.BaseRect)
                            Dim hbr As New HatchBrush(HatchStyle.DarkVertical, Color.White, Color.Black)
                            Select Case shp.Angle
                                Case 0, 90, 180, 270, 360
                                    hbr = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.White, Color.Black)
                            End Select
                            Dim pns = New Pen(hbr, 5)
                            ig.DrawRectangle(pns, rtt)
                            hbr.Dispose()
                            pns.Dispose()
                        End If
                    End If
                End If
                mm.Dispose()
                br.Dispose()
                pn.Dispose()
            Next

            'Draw image containing shapes
            g.DrawImageUnscaled(img, 0, 0, Width, Height)

            'Draw Highlighted Shape
            If ht_shp > -1 And shps.Count >= ht_shp + 1 Then
                Dim pn As New Pen(hg_pth)
                If htype = 1 Then pn.Color = hg_brd
                g.DrawPath(pn, shps(ht_shp).TotalPath())
                pn.Dispose()
            End If

            'Draw selection rectangle
            If s_rect.Width > 0 AndAlso s_rect.Height > 0 Then
                Dim pn As New Pen(clr_sel)
                pn.DashPattern = New Single() {3, 3}
                g.DrawRectangle(pn, s_rect)
                pn.Dispose()
            End If

        End If

        'Draw border rectangle
        Dim rt As Rectangle = ClientRectangle
        rt.Width -= 1 : rt.Height -= 1
        g.DrawRectangle(Pens.Black, rt)

        'Force Garbage Collector
        If Not DesignMode Then GC.Collect()

    End Sub

    Private Sub Canvas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SetImageSize()
    End Sub

#End Region

#Region "KeyBoard Event"
    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Left, Keys.Right, Keys.Up, Keys.Down,
                 Keys.Shift Or Keys.Left, Keys.Shift Or Keys.Right,
                 Keys.Shift Or Keys.Up, Keys.Shift Or Keys.Down,
                 Keys.Tab, Keys.Shift Or Keys.Tab
                Return True
            Case Else
                Return MyBase.IsInputKey(keyData)
        End Select
    End Function

    Private Sub Canvas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Delete
                DeleteSelected()
            Case Keys.Tab
                Dim shp As Shape = MainSelected()
                If Not IsNothing(shp) Then
                    Dim ind As Integer = shps.IndexOf(shp)
                    If ind < shps.Count - 1 Then
                        DeselectAll()
                        shps(ind + 1).Selected = True
                        SetPrimary()
                    End If
                End If
            Case Keys.Shift Or Keys.Tab
                Dim shp As Shape = MainSelected()
                If Not IsNothing(shp) Then
                    Dim ind As Integer = shps.IndexOf(shp)
                    If ind > 0 Then
                        DeselectAll()
                        shps(ind - 1).Selected = True
                        SetPrimary()
                    End If
                End If
            Case Keys.Left
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.X -= 1
                    shp.BaseRect = rect
                Next
            Case Keys.Right
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.X += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Up
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Y -= 1
                    shp.BaseRect = rect
                Next
            Case Keys.Down
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Y += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Control Or Keys.Left
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Width > 1 Then
                        rect.Width -= 1
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Control Or Keys.Right
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Width += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Control Or Keys.Up
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Height > 1 Then
                        rect.Height -= 1
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Control Or Keys.Down
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Height += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Shift Or Keys.Left
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.X -= 1
                    rect.Width += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Shift Or Keys.Right
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Width > 1 Then
                        rect.X += 1
                        rect.Width -= 1
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Shift Or Keys.Up
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Y -= 1
                    rect.Height += 1
                    shp.BaseRect = rect
                Next
            Case Keys.Shift Or Keys.Down
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Height > 1 Then
                        rect.Y += 1
                        rect.Height -= 1
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Shift Or Keys.Control Or Keys.Left
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Width > 1 Then
                        rect.Inflate(-1, 0)
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Shift Or Keys.Control Or Keys.Right
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Inflate(1, 0)
                    shp.BaseRect = rect
                Next
            Case Keys.Shift Or Keys.Control Or Keys.Up
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    If rect.Height > 1 Then
                        rect.Inflate(0, -1)
                        shp.BaseRect = rect
                    End If
                Next
            Case Keys.Shift Or Keys.Control Or Keys.Down
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    Dim rect As RectangleF = shp.BaseRect
                    rect.Inflate(0, 1)
                    shp.BaseRect = rect
                Next
            Case Keys.Control Or Keys.A
                For Each shp As Shape In shps
                    shp.Selected = True
                Next
                SetPrimary()
            Case Keys.Control Or Keys.C
                Dim _lst As New List(Of Shape)
                For Each i As Integer In SelectedIndices()
                    _lst.Add(shps(i))
                Next
                My.Computer.Clipboard.SetData("DrawIt-Shapes", _lst)
            Case Keys.Control Or Keys.X
                Dim _lst As New List(Of Shape)
                For Each i As Integer In SelectedIndices()
                    _lst.Add(shps(i))
                Next
                DeleteSelected()
                My.Computer.Clipboard.SetData("DrawIt-Shapes", _lst)
            Case Keys.Control Or Keys.V
                DeselectAll()
                Dim _lst As List(Of Shape) = My.Computer.Clipboard.GetData("DrawIt-Shapes")
                If IsNothing(_lst) Then Return
                For Each shp As Shape In _lst
                    shps.Add(shp)
                Next
                SetPrimary()
        End Select
        MainForm.UpdateControls()
        Invalidate()
    End Sub

    Private Sub Canvas_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyData
            Case Keys.Control Or Keys.Left, Keys.Control Or Keys.Right,
                 Keys.Control Or Keys.Up, Keys.Control Or Keys.Down,
                 Keys.Shift Or Keys.Left, Keys.Shift Or Keys.Right,
                 Keys.Shift Or Keys.Up, Keys.Shift Or Keys.Down
                For Each i As Integer In SelectedIndices()
                    Dim shp As Shape = shps(i)
                    If shp.Angle <> 0.0 Then
                        Dim _rgRect = New Region(shp.BaseRect)
                        Dim oMtx = New Matrix
                        oMtx.RotateAt(shp.Angle, shp.CenterPoint)
                        _rgRect.Transform(oMtx)
                        Dim rfNewBounds As RectangleF = _rgRect.GetBounds(CreateGraphics)
                        Dim ptNewScreenCenterOrigin As New PointF(rfNewBounds.X + (rfNewBounds.Width / 2), rfNewBounds.Y + (rfNewBounds.Height / 2))
                        Dim rcNewRenderRect As New RectangleF((ptNewScreenCenterOrigin.X - (shp.BaseRect.Width / 2)),
                                                                      (ptNewScreenCenterOrigin.Y - (shp.BaseRect.Height / 2)),
                                                                      shp.BaseRect.Width,
                                                                      shp.BaseRect.Height)
                        shp.BaseRect = rcNewRenderRect
                        shp.CenterPoint = New PointF(shp.BaseRect.X + (shp.BaseRect.Width / 2),
                                 shp.BaseRect.Y + (shp.BaseRect.Height / 2))
                    End If
                Next
                MainForm.UpdateControls()
                Invalidate()
        End Select
    End Sub
#End Region

End Class
