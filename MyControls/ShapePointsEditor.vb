Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<DefaultEvent("PointsChanged")>
<DefaultProperty("Points")>
Public Class ShapePointsEditor

#Region "Enum"
	Public Enum DrawType
		Lines
		Polygon
		Curves
		ClosedCurve
	End Enum
#End Region

#Region "New"
	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
	End Sub
#End Region

#Region "Globals"
	Private m_down As Boolean = False
	Private rect As RectangleF
	Private _lst As New List(Of MyPoint)
	Private hgt As Integer = -1
#End Region

#Region "Event"
	Public Event PointsChanged(sender As Object, e As EventArgs)
#End Region

#Region "Properties"
	Private _dt As DrawType = DrawType.Lines
	<DefaultValue(GetType(DrawType), "Lines")>
	Public Property ShapeType() As DrawType
		Get
			Return _dt
		End Get
		Set(value As DrawType)
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
		Set(value As Single)
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
		Set(value As PointF())
			For Each pt As PointF In value
				_lst.Add(New MyPoint(pt))
			Next
			Invalidate()
		End Set
	End Property
#End Region

#Region "Helper Functions"
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

	Private Function PathInCursor(ept As Point) As Integer
		If _lst.Count < GetMin() Then Return -1
		Dim pn As New Pen(Color.Black, 3)
		If ShapeType = DrawType.Polygon Then
			For p1 As Integer = 0 To _lst.Count - 1
				Dim pth = LineFromIndex(p1)
				pth.Widen(pn)
				If pth.IsVisible(ept) Then Return p1
			Next
		ElseIf ShapeType = DrawType.Lines Then
			For p1 As Integer = 0 To _lst.Count - 2
				Dim pth = LineFromIndex(p1)
				pth.Widen(pn)
				If pth.IsVisible(ept) Then Return p1
			Next
		ElseIf ShapeType = DrawType.ClosedCurve Then
			For p1 As Integer = 0 To _lst.Count - 1
				Dim pth = CurveFromIndex(p1)
				pth.Widen(pn)
				If pth.IsVisible(ept) Then Return p1
			Next
		ElseIf ShapeType = DrawType.Curves Then
			For p1 As Integer = 0 To _lst.Count - 2
				Dim pth = CurveFromIndex(p1)
				pth.Widen(pn)
				If pth.IsVisible(ept) Then Return p1
			Next
		End If
		Return -1
	End Function

	Private Function LineFromIndex(p1 As Integer) As GraphicsPath
		Dim p2 = (p1 + 1) Mod _lst.Count
		Dim gp As New GraphicsPath
		Dim pt1 = FromPercentage(rect, _lst(p1).Point)
		Dim pt2 = FromPercentage(rect, _lst(p2).Point)
		gp.AddLine(pt1, pt2)
		Return gp
	End Function

	Private Function CurveFromIndex(p1 As Integer) As GraphicsPath
		Dim p_pos As New List(Of PointF)
		For Each pt As PointF In Points
			p_pos.Add(FromPercentage(rect, pt))
		Next
		Dim pth_chk As New GraphicsPath
		If ShapeType = DrawType.ClosedCurve Then
			pth_chk.AddClosedCurve(p_pos.ToArray, Tension)
		ElseIf ShapeType = DrawType.Curves Then
			pth_chk.AddCurve(p_pos.ToArray, Tension)
		End If
		Dim pts_chk = pth_chk.PathPoints
		Dim pt1 = p1 * 3
		Dim pt2 = pt1 + 1 Mod pts_chk.Count
		Dim pt3 = pt2 + 1 Mod pts_chk.Count
		Dim pt4 = pt3 + 1 Mod pts_chk.Count
		Dim gp As New GraphicsPath
		gp.AddBezier(pts_chk(pt1), pts_chk(pt2), pts_chk(pt3), pts_chk(pt4))
		Return gp
	End Function

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
#End Region

#Region "Mouse Events"
	Private Sub ShapePointsEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		DeselectAll()
		Dim curr As Integer = PointInCursor(e.Location)
		Dim curl As Integer = PathInCursor(e.Location)
		If curr > -1 Then
			If e.Button = MouseButtons.Left Then
				_lst(curr).Selected = True
			ElseIf e.Button = MouseButtons.Right Then
				If _lst.Count > GetMin() Then
					_lst.RemoveAt(curr)
					RaiseEvent PointsChanged(Me, New EventArgs)
				End If
			End If
		ElseIf curl > -1 Then
			If rect.Contains(e.Location) AndAlso e.Button = MouseButtons.Left Then
				Dim bl As New MyPoint
				bl.Point = ToPercentage(rect, e.Location)
				bl.Selected = True
				_lst.Insert(curl + 1, bl)
				RaiseEvent PointsChanged(Me, New EventArgs)
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
			hgt = -1
			Cursor = Cursors.Hand
			Dim sel As Integer = SelectedItem()
			If sel = -1 Then Return
			Dim bl As MyPoint = _lst(sel)
			Dim pos = ToPercentage(rect, e.Location)
			bl.Point = pos
			RaiseEvent PointsChanged(Me, New EventArgs)
		Else
			Dim curr = PointInCursor(e.Location)
			If curr > -1 Then
				Cursor = Cursors.Hand
				hgt = -1
			Else
				Cursor = Cursors.Arrow
				hgt = PathInCursor(e.Location)
			End If
		End If
		Invalidate()
	End Sub

	Private Sub ShapePointsEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		m_down = False
	End Sub
#End Region

#Region "Drawing"
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
			Dim pth As New GraphicsPath
			Select Case ShapeType
				Case DrawType.Lines
					pth.AddLines(p_pos.ToArray)
				Case DrawType.Polygon
					pth.AddPolygon(p_pos.ToArray)
				Case DrawType.Curves
					pth.AddCurve(p_pos.ToArray, Tension)
				Case DrawType.ClosedCurve
					pth.AddClosedCurve(p_pos.ToArray, Tension)
			End Select
			pth.FillMode = FillMode.Winding
			g.DrawPath(Pens.Black, pth)
		End If

		If hgt > -1 Then
			If ShapeType = DrawType.Lines Or ShapeType = DrawType.Polygon Then
				g.DrawPath(Pens.Red, LineFromIndex(hgt))
			Else
				g.DrawPath(Pens.Red, CurveFromIndex(hgt))
			End If
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
#End Region

#Region "Load & Resize"
	Private Sub ShapePointsEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetRect()
	End Sub

	Private Sub ShapePointsEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetRect()
		Invalidate()
	End Sub
#End Region

#Region "Keyboard Events"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
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
#End Region

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
		Set(value As PointF)
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
		Set(value As Boolean)
			_sel = value
		End Set
	End Property

End Class