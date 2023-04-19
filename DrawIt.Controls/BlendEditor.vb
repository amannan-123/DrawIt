Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports DrawIt.Helpers

<DefaultEvent("BlendChanged")>
Public Class BlendEditor

	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetRect()
	End Sub

	Private m_down As Boolean = False
	Private _rect As New RectangleF
	Private _start As New BlendItem(0, 0, True)
	Private _end As New BlendItem(1, 1)
	Private _lst As New List(Of BlendItem)

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

	Private _clr1 As Color = Color.White
	Public Property Color1() As Color
		Get
			Return _clr1
		End Get
		Set(value As Color)
			_clr1 = value
			BL_Pos.Color1 = Color1
			BL_Fac.Colors = New Color() {_clr1, _clr2}
			Invalidate()
		End Set
	End Property

	Private _clr2 As Color = Color.Black
	Public Property Color2() As Color
		Get
			Return _clr2
		End Get
		Set(value As Color)
			_clr2 = value
			BL_Pos.Color2 = Color2
			BL_Fac.Colors = New Color() {_clr1, _clr2}
			Invalidate()
		End Set
	End Property

	Private _Factors As Single() = New Single() {0, 1}
	Public Property Factors() As Single()
		Get
			Return _Factors
		End Get
		Set(value As Single())
			_Factors = value
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
		Dim _f As New List(Of Single)
		Dim _p As New List(Of Single)

		_f.Add(_start.BFactor)
		_p.Add(0)

		For Each bl As BlendItem In _lst
			_f.Add(bl.BFactor)
			_p.Add(bl.BPosition)
		Next

		_f.Add(_end.BFactor)
		_p.Add(1)

		Factors = _f.ToArray
		Positions = _p.ToArray

		BL_Pos.Factors = Factors
		BL_Pos.Positions = Positions
	End Sub

	Public Function Loadblenditems(_fac As Single(), _pts As Single()) As Boolean
		If _fac.Count <> _pts.Count Then Return False
		If _fac.Count < 2 Then Return False
		If _pts.First <> 0 Then Return False
		If _pts.Last <> 1 Then Return False

		_start = New BlendItem(0, _fac.First, True)
		_end = New BlendItem(1, _fac.Last)

		_lst.Clear()
		If _fac.Count > 2 Then
			For ind As Integer = 1 To _fac.Count - 2
				_lst.Add(New BlendItem(_pts(ind), _fac(ind)))
			Next
		End If

		CreateBlend()
		Invalidate()
		UpdateControls()
		Return True
	End Function

	Private Function SelectedItem() As Integer
		Dim ind As Integer = -1
		For Each bl As BlendItem In _lst
			If bl.Selected Then ind = _lst.IndexOf(bl)
		Next
		Return ind
	End Function

	Private Sub DeselectAll()
		_start.Selected = False
		_end.Selected = False
		For Each bl As BlendItem In _lst
			bl.Selected = False
		Next
	End Sub

	Private Function BlendInCursor(pt As Point) As Integer
		Dim ind As Integer = -1
		For Each bl As BlendItem In _lst
			If BlendRegion(bl).IsVisible(pt) Then
				ind = _lst.IndexOf(bl)
			End If
		Next
		Return ind
	End Function

	Private Function BlendRegion(_item As BlendItem) As GraphicsPath
		Dim gp As New GraphicsPath
		Dim pos As Single = MathUtils.FromPercentage(_rect.X, _rect.Right, _item.BPosition * 100)
		Dim rect As New Rectangle(pos - 3, _rect.Bottom - 10, 6, 8)
		Dim p1 As New Point(rect.X + (rect.Width / 2), rect.Y - 3)
		Dim p2 As Point = rect.Location
		Dim p3 As New Point(rect.X, rect.Bottom)
		Dim p4 As New Point(rect.Right, rect.Bottom)
		Dim p5 As New Point(rect.Right, rect.Y)
		gp.AddPolygon(New Point() {p1, p2, p3, p4, p5})
		Return gp
	End Function

	Private Function Sortblenditems(x As BlendItem, y As BlendItem) As Integer
		Dim pos As Integer = x.BPosition.CompareTo(y.BPosition)
		If pos <> 0 Then
			Return pos
		Else
			Return 0
		End If
	End Function

	Private Sub UpdateControls()
		If _start.Selected Then
			BL_Fac.Value = _start.BFactor * 100
			BL_Pos.Value = _start.BPosition * 100
			BL_Pos.Enabled = False
		ElseIf _end.Selected Then
			BL_Fac.Value = _end.BFactor * 100
			BL_Pos.Value = _end.BPosition * 100
			BL_Pos.Enabled = False
		Else
			Dim curr = SelectedItem()
			If curr < 0 Then Return
			BL_Fac.Value = _lst(curr).BFactor * 100
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
					Dim bl As New BlendItem With {
						.BPosition = MathUtils.ToPercentage(_rect.X, _rect.Right, e.X) / 100,
						.BFactor = BL_Fac.Value / 100,
						.Selected = True
					}
					_lst.Add(bl)
				End If
			End If
		End If
		m_down = True
		If CB_Sort.Checked Then _lst.Sort(AddressOf Sortblenditems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub ColorBlendEditor_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If m_down Then
			Dim sel As Integer = SelectedItem()
			If sel = -1 Then Return
			Dim bl As BlendItem = _lst(sel)
			Dim pos = MathUtils.ToPercentage(_rect.X, _rect.Right, e.X) / 100
			If pos > 1 Or pos < 0 Then Return
			bl.BPosition = pos
		End If
		If CB_Sort.Checked Then _lst.Sort(AddressOf Sortblenditems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub ColorBlendEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		m_down = False
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub Drawblenditem(g As Graphics, bl As BlendItem)
		g.FillPath(New SolidBrush(Color.White), BlendRegion(bl))
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

		If Factors.Count > 1 AndAlso Positions.Count = Factors.Count Then
			Dim lgb As New LinearGradientBrush(r1, _clr1, _clr2, 0)
			Dim cb As New Blend With {
				.Factors = Factors,
				.Positions = Positions
			}
			lgb.Blend = cb

			g.FillRectangle(lgb, r1)
			g.DrawRectangle(New Pen(BordersColor), r1)
		End If

		Drawblenditem(g, _start)

		For Each bl As BlendItem In _lst
			Drawblenditem(g, bl)
		Next

		Drawblenditem(g, _end)

		Dim r_brd As Rectangle = ClientRectangle
		r_brd.Width -= 1 : r_brd.Height -= 1
		g.DrawRectangle(New Pen(BordersColor), r_brd)

	End Sub

	Private Sub ColorBlendEditor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetRect()
		CreateBlend()
		Invalidate()
	End Sub

	Private Sub ColorBlendEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Loadblenditems(Factors, Positions)
		SetRect()
		CreateBlend()
	End Sub

	Private Sub BL_Pos_ValueChanged(sender As Object, e As EventArgs) Handles BL_Pos.ValueChanged
		Dim sel As Integer = SelectedItem()
		If sel = -1 Then Return
		Dim bl As BlendItem = _lst(sel)
		bl.BPosition = BL_Pos.Value / 100
		If CB_Sort.Checked Then _lst.Sort(AddressOf Sortblenditems)
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
		If CB_Sort.Checked Then _lst.Sort(AddressOf Sortblenditems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub B_Reverse_Click(sender As Object, e As EventArgs) Handles B_Reverse.Click
		DeselectAll()
		Dim _temp As Single = _end.BFactor
		_end.BFactor = _start.BFactor
		_start.BFactor = _temp
		For Each it As BlendItem In _lst
			it.BPosition = 1 - it.BPosition
		Next
		_start.Selected = True
		If CB_Sort.Checked Then _lst.Sort(AddressOf Sortblenditems)
		CreateBlend()
		Invalidate()
		UpdateControls()
	End Sub

	Private Sub BL_Fac_ValueChanged(sender As Object, e As EventArgs) Handles BL_Fac.ValueChanged
		If _start.Selected Then
			_start.BFactor = BL_Fac.Value / 100
		ElseIf _end.Selected Then
			_end.BFactor = BL_Fac.Value / 100
		Else
			Dim sel As Integer = SelectedItem()
			If sel = -1 Then Return
			Dim bl As BlendItem = _lst(sel)
			bl.BFactor = BL_Fac.Value / 100
		End If
		CreateBlend()
		Invalidate()
	End Sub
End Class

Public Class BlendItem

	Sub New()
		BFactor = 0.5
		BPosition = 0.5
		Selected = False
	End Sub

	Sub New(_pos As Single, _fac As Single, Optional _sel As Boolean = False)
		BFactor = _fac
		BPosition = _pos
		Selected = _sel
	End Sub

	Private _fac As Single
	Public Property BFactor() As Single
		Get
			Return _fac
		End Get
		Set(value As Single)
			_fac = value
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
