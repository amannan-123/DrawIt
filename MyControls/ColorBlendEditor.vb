Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<DefaultEvent("BlendChanged")>
Public Class ColorBlendEditor

	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetRect()
	End Sub

	Private m_down As Boolean = False
	Private _rect As New RectangleF
	Private _start As New ColorBlendItem(Color.White, 0, True)
	Private _end As New ColorBlendItem(Color.Black, 1)
	Private _lst As New List(Of ColorBlendItem)

	Private _brd As Color = Color.Black
	<Description("Borders Color")>
	<DefaultValue(GetType(Color), "Black")>
	Public Property BordersColor() As Color
		Get
			Return _brd
		End Get
		Set(value As Color)
			_brd = value
			Invalidate()
		End Set
	End Property


	Private _colors As Color() = New Color() {Color.White, Color.Black}
	Public Property Colors() As Color()
		Get
			Return _colors
		End Get
		Set(value As Color())
			_colors = value
			RaiseEvent BlendChanged(Me, New EventArgs)
			Invalidate()
		End Set
	End Property

	Private _positions As Single() = New Single() {0, 1}
	Public Property Positions() As Single()
		Get
			Return _positions
		End Get
		Set(value As Single())
			_positions = value
			RaiseEvent BlendChanged(Me, New EventArgs)
			Invalidate()
		End Set
	End Property

	Public Event BlendChanged(sender As Object, e As EventArgs)

	Public Sub CreateBlend()
		Dim _c As New List(Of Color)
		Dim _p As New List(Of Single)

		_c.Add(_start.BColor)
		_p.Add(0)

		For Each bl As ColorBlendItem In _lst
			_c.Add(bl.BColor)
			_p.Add(bl.BPosition)
		Next

		_c.Add(_end.BColor)
		_p.Add(1)

		Colors = _c.ToArray
		Positions = _p.ToArray
		BL_Pos.Colors = Colors
		BL_Pos.Positions = Positions
	End Sub

	Public Function LoadColorBlendItems(_clr As Color(), _pts As Single()) As Boolean
		If _clr.Count <> _pts.Count Then Return False
		If _clr.Count < 2 Then Return False
		If _pts.First <> 0 Then Return False
		If _pts.Last <> 1 Then Return False

		_start = New ColorBlendItem(_clr(0), 0, True)
		_end = New ColorBlendItem(_clr.Last, 1)

		_lst.Clear()
		If _clr.Count > 2 Then
			For ind As Integer = 1 To _clr.Count - 2
				_lst.Add(New ColorBlendItem(_clr(ind), _pts(ind)))
			Next
		End If

		CreateBlend()
		Invalidate()
		UpdateControls()
		Return True
	End Function

	Private Function SelectedItem() As Integer
		Dim ind As Integer = -1
		For Each bl As ColorBlendItem In _lst
			If bl.Selected Then ind = _lst.IndexOf(bl)
		Next
		Return ind
	End Function

	Private Sub DeselectAll()
		_start.Selected = False
		_end.Selected = False
		For Each bl As ColorBlendItem In _lst
			bl.Selected = False
		Next
	End Sub

	Private Function BlendInCursor(pt As Point) As Integer
		Dim ind As Integer = -1
		For Each bl As ColorBlendItem In _lst
			If BlendRegion(bl).IsVisible(pt) Then
				ind = _lst.IndexOf(bl)
			End If
		Next
		Return ind
	End Function

	Private Function BlendRegion(_item As ColorBlendItem) As GraphicsPath
		Dim gp As New GraphicsPath
		Dim pos As Single = FromPercentage(_rect.X, _rect.Right, _item.BPosition * 100)
		Dim rect As New Rectangle(pos - 3, _rect.Bottom - 10, 6, 8)
		Dim p1 As New Point(rect.X + (rect.Width / 2), rect.Y - 3)
		Dim p2 As Point = rect.Location
		Dim p3 As New Point(rect.X, rect.Bottom)
		Dim p4 As New Point(rect.Right, rect.Bottom)
		Dim p5 As New Point(rect.Right, rect.Y)
		gp.AddPolygon(New Point() {p1, p2, p3, p4, p5})
		Return gp
	End Function

	Private Function SortColorBlendItems(x As ColorBlendItem, y As ColorBlendItem) As Integer
		Dim pos As Integer = x.BPosition.CompareTo(y.BPosition)
		If pos <> 0 Then
			Return pos
		Else
			Return 0
		End If
	End Function

	Private Sub UpdateControls()
		If _start.Selected Then
			CE_Button.SelectedColor = _start.BColor
			BL_Pos.Value = _start.BPosition * 100
			BL_Pos.Enabled = False
		ElseIf _end.Selected Then
			CE_Button.SelectedColor = _end.BColor
			BL_Pos.Value = _end.BPosition * 100
			BL_Pos.Enabled = False
		Else
			Dim curr = SelectedItem()
			If curr < 0 Then Return
			CE_Button.SelectedColor = _lst(curr).BColor
			BL_Pos.Value = _lst(curr).BPosition * 100
			BL_Pos.Enabled = True
		End If
	End Sub

	Private Sub SetRect()
		_rect = New RectangleF(5, 5, Width - 11, 75)
	End Sub

	Private Sub ColorBlendEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		DeselectAll()
		Dim curr As Integer = BlendInCursor(e.Location)
		If curr > -1 Then
			If e.Button = MouseButtons.Left Then
				_lst(curr).Selected = True
			ElseIf e.Button = MouseButtons.Right Then
				_lst.RemoveAt(curr)
			End If
		Else
			If BlendRegion(_start).IsVisible(e.Location) Then
				_start.Selected = True
			ElseIf BlendRegion(_end).IsVisible(e.Location) Then
				_end.Selected = True
			Else
				If _rect.Contains(e.Location) AndAlso e.Button = MouseButtons.Left Then
					Dim bl As New ColorBlendItem With {
						.BPosition = ToPercentage(_rect.X, _rect.Right, e.X) / 100,
						.BColor = CE_Button.SelectedColor,
						.Selected = True
					}
					_lst.Add(bl)
				End If
			End If
		End If
		m_down = True
		If CB_Sort.Checked Then _lst.Sort(AddressOf SortColorBlendItems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub ColorBlendEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If m_down Then
			Dim sel As Integer = SelectedItem()
			If sel = -1 Then Return
			Dim bl As ColorBlendItem = _lst(sel)
			Dim pos = ToPercentage(_rect.X, _rect.Right, e.X) / 100
			If pos > 1 Or pos < 0 Then Return
			bl.BPosition = pos
		End If
		If CB_Sort.Checked Then _lst.Sort(AddressOf SortColorBlendItems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub ColorBlendEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		m_down = False
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub DrawColorBlendItem(g As Graphics, bl As ColorBlendItem)
		g.FillPath(New SolidBrush(bl.BColor), BlendRegion(bl))
		g.DrawPath(New Pen(BordersColor), BlendRegion(bl))
		If bl.Selected Then
			Dim b_rect As RectangleF = BlendRegion(bl).GetBounds
			Dim s_rect As New RectangleF(b_rect.X, b_rect.Bottom, b_rect.Width, 5)
			g.FillEllipse(Brushes.Red, s_rect)
		End If
	End Sub

	Private Sub ColorBlendEditor_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias

		Dim r1 As New Rectangle(_rect.X, _rect.Y, _rect.Width, 65)

		Dim br = New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
		g.FillRectangle(br, r1)

		If Colors.Count > 1 AndAlso Positions.Count = Colors.Count Then
			Dim lgb As New LinearGradientBrush(r1, Color.Transparent, Color.Transparent, 0)
			Dim cb As New ColorBlend With {
				.Colors = Colors,
				.Positions = Positions
			}
			lgb.InterpolationColors = cb

			g.FillRectangle(lgb, r1)
			g.DrawRectangle(New Pen(BordersColor), r1)
		End If

		DrawColorBlendItem(g, _start)

		For Each bl As ColorBlendItem In _lst
			DrawColorBlendItem(g, bl)
		Next

		DrawColorBlendItem(g, _end)

		Dim r_brd As Rectangle = ClientRectangle
		r_brd.Width -= 1 : r_brd.Height -= 1
		g.DrawRectangle(New Pen(BordersColor), r_brd)

	End Sub

	Private Sub ColorBlendEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetRect()
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub CE_Button_ColorChanged(sender As Object, e As EventArgs) Handles CE_Button.ColorChanged
		If _start.Selected Then
			_start.BColor = CE_Button.SelectedColor
		ElseIf _end.Selected Then
			_end.BColor = CE_Button.SelectedColor
		Else
			Dim sel As Integer = SelectedItem()
			If sel = -1 Then Return
			Dim bl As ColorBlendItem = _lst(sel)
			bl.BColor = CE_Button.SelectedColor
		End If
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub ColorBlendEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		LoadColorBlendItems(Colors, Positions)
		SetRect()
		CreateBlend()
	End Sub

	Private Sub BL_Pos_ValueChanged(sender As Object, e As EventArgs) Handles BL_Pos.ValueChanged
		Dim sel As Integer = SelectedItem()
		If sel = -1 Then Return
		Dim bl As ColorBlendItem = _lst(sel)
		bl.BPosition = BL_Pos.Value / 100
		If CB_Sort.Checked Then _lst.Sort(AddressOf SortColorBlendItems)
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub B_Balance_Click(sender As Object, e As EventArgs) Handles B_Balance.Click
		Dim _total As Integer = _lst.Count
		If _total < 1 Then Return
		_total += 1
		For i As Integer = 0 To _lst.Count - 1
			_lst(i).BPosition = (i + 1) / _total
		Next
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub B_Clear_Click(sender As Object, e As EventArgs) Handles B_Clear.Click
		_lst.Clear()
		CreateBlend()
		Invalidate()
		_start.Selected = True
		UpdateControls()
	End Sub

	Private Sub CB_Sort_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Sort.CheckedChanged
		If CB_Sort.Checked Then _lst.Sort(AddressOf SortColorBlendItems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub B_Reverse_Click(sender As Object, e As EventArgs) Handles B_Reverse.Click
		DeselectAll()
		Dim _temp As Color = _end.BColor
		_end.BColor = _start.BColor
		_start.BColor = _temp
		For Each it As ColorBlendItem In _lst
			it.BPosition = 1 - it.BPosition
		Next
		_start.Selected = True
		If CB_Sort.Checked Then _lst.Sort(AddressOf SortColorBlendItems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

End Class

Public Class ColorBlendItem

	Sub New()
		BColor = Color.White
		BPosition = 0.5
		Selected = False
	End Sub

	Sub New(_clr As Color, _pos As Single, Optional _sel As Boolean = False)
		BColor = _clr
		BPosition = _pos
		Selected = _sel
	End Sub

	Private _color As Color
	Public Property BColor() As Color
		Get
			Return _color
		End Get
		Set(value As Color)
			_color = value
		End Set
	End Property

	Private _pos As Single
	Public Property BPosition() As Single
		Get
			Return _pos
		End Get
		Set(value As Single)
			_pos = value
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
