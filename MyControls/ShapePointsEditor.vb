Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<DefaultEvent("PointsChanged")>
<DefaultProperty("Points")>
Public Class ShapePointsEditor

    Public Enum DrawType
        Lines
        Polygon
        Curves
		ClosedCurve
		Beziers
	End Enum

    Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Private m_down As Boolean = False
    Private rect As RectangleF
    Private _lst As New List(Of MyPoint)

    Public Event PointsChanged(sender As Object, e As EventArgs)

    Private _dt As DrawType = DrawType.Lines
    <DefaultValue(GetType(DrawType), "Lines")>
    Public Property ShapeType() As DrawType
        Get
            Return _dt
        End Get
        Set(ByVal value As DrawType)
            _dt = value
            Invalidate()
        End Set
    End Property

    Private _ten As Single = 0.5
    <DefaultValue(GetType(Single), "0.5")>
    Public Property Tension() As Single
        Get
            Return _ten
        End Get
        Set(ByVal value As Single)
            _ten = value
            Invalidate()
        End Set
    End Property

    Public Property Points() As PointF()
        Get
            Dim _p As New List(Of PointF)
            For Each pt As MyPoint In _lst
                _p.Add(pt.Point)
            Next
            Return _p.ToArray
        End Get
        Set(ByVal value As PointF())
            For Each pt As PointF In value
                _lst.Add(New MyPoint(pt))
            Next
            Invalidate()
        End Set
    End Property

    Private Function GetMin() As Integer
        Select Case ShapeType
            Case DrawType.Lines
                Return 2
            Case DrawType.Polygon
                Return 3
            Case DrawType.Curves
                Return 3
            Case DrawType.ClosedCurve
                Return 3
        End Select
        Return -1
    End Function

    Private Function SelectedItem() As Integer
        Dim ind As Integer = -1
        For Each bl As MyPoint In _lst
            If bl.Selected Then ind = _lst.IndexOf(bl)
        Next
        Return ind
    End Function

    Private Sub DeselectAll()
        For Each bl As MyPoint In _lst
            bl.Selected = False
        Next
    End Sub

    Private Function PointInCursor(pt As Point) As Integer
        Dim ind As Integer = -1
        For Each bl As MyPoint In _lst
            If PointRegion(bl).IsVisible(pt) Then
                ind = _lst.IndexOf(bl)
            End If
        Next
        Return ind
    End Function

    Private Function PointRegion(_item As MyPoint) As GraphicsPath
        Dim gp As New GraphicsPath
        Dim pos As PointF = FromPercentage(rect, _item.Point)
        Dim rt As New RectangleF(pos, SizeF.Empty)
        rt.Inflate(3, 3)
        gp.AddEllipse(rt)
        Return gp
    End Function

    Private Sub SetRect()
        rect = New RectangleF(25, 25, Width - 51, Height - 51)
    End Sub

    Private Sub ShapePointsEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        DeselectAll()
        Dim curr As Integer = PointInCursor(e.Location)
        If curr > -1 Then
            If e.Button = MouseButtons.Left Then
                _lst(curr).Selected = True
            ElseIf e.Button = MouseButtons.Right Then
                If _lst.Count > GetMin() Then
                    _lst.RemoveAt(curr)
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            End If
        Else
            If rect.Contains(e.Location) AndAlso e.Button = MouseButtons.Left Then
                Dim bl As New MyPoint
                bl.Point = ToPercentage(rect, e.Location)
                bl.Selected = True
                _lst.Add(bl)
                RaiseEvent PointsChanged(Me, New EventArgs)
            End If
        End If
        m_down = True
        Invalidate()
    End Sub

    Private Sub ShapePointsEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If m_down Then
            Dim sel As Integer = SelectedItem()
            If sel = -1 Then Return
            Dim bl As MyPoint = _lst(sel)
            Dim pos = ToPercentage(rect, e.Location)
            bl.Point = pos
            RaiseEvent PointsChanged(Me, New EventArgs)
        End If
        Invalidate()
    End Sub

    Private Sub ShapePointsEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        m_down = False
    End Sub

    Private Sub DrawPoint(g As Graphics, bl As MyPoint)
        g.FillPath(New SolidBrush(Color.FromArgb(180, Color.Black)), PointRegion(bl))
        g.DrawPath(Pens.Black, PointRegion(bl))
        If bl.Selected Then
            Dim b_rect As RectangleF = PointRegion(bl).GetBounds
            Dim s_rect As New RectangleF(b_rect.X, b_rect.Bottom, b_rect.Width, 3)
            g.FillEllipse(Brushes.Red, s_rect)
        End If
    End Sub

    Private Sub ShapePointsEditor_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim pn As New Pen(Color.Gray)
        pn.DashStyle = DashStyle.Dash
        g.DrawRectangle(pn, Rectangle.Ceiling(rect))

        If Points.Count >= GetMin() Then
            Dim p_pos As New List(Of PointF)
            For Each pt As PointF In Points
                p_pos.Add(FromPercentage(rect, pt))
            Next
			Select Case ShapeType
				Case DrawType.Lines
					g.DrawLines(Pens.Black, p_pos.ToArray)
				Case DrawType.Polygon
					g.DrawPolygon(Pens.Black, p_pos.ToArray)
				Case DrawType.Curves
					g.DrawCurve(Pens.Black, p_pos.ToArray, Tension)
				Case DrawType.ClosedCurve
					g.DrawClosedCurve(Pens.Black, p_pos.ToArray, Tension, FillMode.Winding)
				Case DrawType.Beziers
					If p_pos.Count > 1 Then g.DrawLines(Pens.Black, p_pos.ToArray)
					If (p_pos.Count - 1) Mod 3 = 0 Then
						g.DrawBeziers(Pens.Black, p_pos.ToArray)
					End If
			End Select
		End If

        For Each pt As MyPoint In _lst
            DrawPoint(g, pt)
        Next

        Dim curr = SelectedItem()
        If curr > -1 Then
            Dim str As String = curr.ToString & ". " & _lst(curr).Point.ToString
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            Dim rtext As New Rectangle(rect.X, rect.Bottom, rect.Width, 25)
            g.DrawString(str, Font, Brushes.Black, rtext, sf)
        End If

        Dim r_brd As Rectangle = ClientRectangle
        r_brd.Width -= 1 : r_brd.Height -= 1
        g.DrawRectangle(Pens.Black, r_brd)

        pn.Dispose()
    End Sub

    Private Sub ShapePointsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRect()
    End Sub

    Private Sub ShapePointsEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SetRect()
        Invalidate()
    End Sub

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Left, Keys.Right, Keys.Up, Keys.Down
                Return True
            Case Else
                Return MyBase.IsInputKey(keyData)
        End Select
    End Function

    Private Sub ShapePointsEditor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyData
            Case Keys.Control Or Keys.C
                _lst.Clear()
                RaiseEvent PointsChanged(Me, New EventArgs)
            Case Keys.Control Or Keys.X
                For Each pt As MyPoint In _lst
                    Dim ptt As PointF = pt.Point
                    ptt.X = 100 - ptt.X
                    pt.Point = ptt
                Next
                RaiseEvent PointsChanged(Me, New EventArgs)
            Case Keys.Control Or Keys.Y
                For Each pt As MyPoint In _lst
                    Dim ptt As PointF = pt.Point
                    ptt.Y = 100 - ptt.Y
                    pt.Point = ptt
                Next
                RaiseEvent PointsChanged(Me, New EventArgs)
            Case Keys.Left
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.X -= 1
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Right
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.X += 1
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Up
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.Y -= 1
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Down
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.Y += 1
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Control Or Keys.Left
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.X = CInt(ptt.X - 1)
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Control Or Keys.Right
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.X = CInt(ptt.X + 1)
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Control Or Keys.Up
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.Y = CInt(ptt.Y - 1)
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
            Case Keys.Control Or Keys.Down
                Dim curr As Integer = SelectedItem()
                If curr > -1 Then
                    Dim ptt As PointF = _lst(curr).Point
                    ptt.Y = CInt(ptt.Y + 1)
                    _lst(curr).Point = ptt
                    RaiseEvent PointsChanged(Me, New EventArgs)
                End If
        End Select
        Invalidate()
    End Sub

End Class

Public Class MyPoint

    Sub New()

    End Sub

    Sub New(x As Single, y As Single, Optional sel As Boolean = False)
        _pt = New PointF(x, y)
        _sel = sel
    End Sub

    Sub New(pt As PointF, Optional sel As Boolean = False)
        _pt = pt
        _sel = sel
    End Sub


    Private _pt As PointF
    Public Property Point() As PointF
        Get
            Return _pt
        End Get
        Set(ByVal value As PointF)
            If value.X < 0 Then value.X = 0
            If value.Y < 0 Then value.Y = 0
            If value.X > 100 Then value.X = 100
            If value.Y > 100 Then value.Y = 100
            _pt = value
        End Set
    End Property

    Private _sel As Boolean
    Public Property Selected() As Boolean
        Get
            Return _sel
        End Get
        Set(ByVal value As Boolean)
            _sel = value
        End Set
    End Property

End Class