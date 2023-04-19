Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports DrawIt.Helpers

<DefaultEvent("ValueChanged")>
<DefaultProperty("Value")>
Public Class PointSelector

#Region "New"
	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
	End Sub
#End Region

#Region "Declerations"

	Private IsMouseDown As Boolean = False
	Private rectSlider As RectangleF
	Private rectSliderBar As RectangleF
	Private sngSliderPos As PointF

#End Region

#Region "Events"

	<Description("Occurs when value is changed.")>
	Public Event ValueChanged(sender As Object, e As EventArgs)

#End Region

#Region "Properties"
	Private _pt As Point = New Point(0, 0)
	<Description("Selected point.")>
	<DefaultValue(GetType(Point), "0,0")>
	Public Property Value() As Point
		Get
			Return _pt
		End Get
		Set(value As Point)
			If _pt <> value Then
				If value.X < _min.X Then value.X = _min.X
				If value.Y < _min.Y Then value.Y = _min.Y
				If value.X > _max.X Then value.X = _max.X
				If value.Y > _max.X Then value.Y = _max.Y
				_pt = value
				SetThumb()
				Invalidate()
				RaiseEvent ValueChanged(Me, New EventArgs)
			End If
		End Set
	End Property

	Private _max As Point = New Point(100, 100)
	<Description("Selected point.")>
	<DefaultValue(GetType(Point), "100,100")>
	Public Property Maximum() As Point
		Get
			Return _max
		End Get
		Set(value As Point)
			_max = value
			SetThumb()
			Invalidate()
		End Set
	End Property

	Private _min As Point = New Point(0, 0)
	<Description("Selected point.")>
	<DefaultValue(GetType(Point), "0,0")>
	Public Property Minimum() As Point
		Get
			Return _min
		End Get
		Set(value As Point)
			_min = value
			SetThumb()
			Invalidate()
		End Set
	End Property

	Private _increment As Single = 1
	<Description("Increment or decrement using arrow keys")>
	<DefaultValue(GetType(Single), "1")>
	Public Property Increment() As Single
		Get
			Return _increment
		End Get
		Set(Value As Single)
			_increment = Value
		End Set
	End Property

	Private thumb_clr As Color = Color.White
	<Description("Thumb Color")>
	<DefaultValue(GetType(Color), "White")>
	Public Property ThumbColor() As Color
		Get
			Return thumb_clr
		End Get
		Set(value As Color)
			thumb_clr = value
			Invalidate()
		End Set
	End Property

	Private back_clr As Color = Color.White
	<Description("Back Rectangle Color")>
	<DefaultValue(GetType(Color), "White")>
	Public Property BackRectColor() As Color
		Get
			Return back_clr
		End Get
		Set(value As Color)
			back_clr = value
			Invalidate()
		End Set
	End Property

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

#End Region

#Region "Re-Size"

	Private Sub gSizer_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
		Resizeit()
	End Sub

	Private Sub Resizeit()
		rectSliderBar = New RectangleF(5, 5, Width - 11, Height - 31)
		SetThumb()
	End Sub

#End Region

#Region "Slider Position"
	Private Sub UpdateSlider(xPos As Point)
		Dim rect As RectangleF = rectSlider
		sngSliderPos = xPos
		If sngSliderPos.X < rectSliderBar.X Then sngSliderPos.X = rectSliderBar.X
		If sngSliderPos.X > rectSliderBar.Right Then sngSliderPos.X = rectSliderBar.Right
		If sngSliderPos.Y < rectSliderBar.Y Then sngSliderPos.Y = rectSliderBar.Y
		If sngSliderPos.Y > rectSliderBar.Bottom Then sngSliderPos.Y = rectSliderBar.Bottom
		rectSlider = New RectangleF(sngSliderPos, SizeF.Empty)
		rectSlider.Inflate(4, 4)
	End Sub

	Private Sub SetSliderValue(pt As Point)
		Dim perc As Point = Point.Ceiling(MathUtils.ToPercentage(rectSliderBar.Location, New Point(rectSliderBar.Right, rectSliderBar.Bottom), pt))
		Dim _val As Point = Point.Ceiling(MathUtils.FromPercentage(Minimum, Maximum, perc))
		Value = _val
		UpdateSlider(pt)
	End Sub

	Private Sub SetThumb()
		Dim perc As Point = Point.Ceiling(MathUtils.ToPercentage(Minimum, Maximum, Value))
		Dim pos As Point = Point.Ceiling(MathUtils.FromPercentage(rectSliderBar.Location, New Point(rectSliderBar.Right, rectSliderBar.Bottom), perc))
		UpdateSlider(pos)
	End Sub

#End Region

#Region "Mouse Events"
	Private Sub PointSelector_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		If rectSlider.Contains(e.Location) Or rectSliderBar.Contains(e.Location) Then
			If IsMouseDown = False Then
				IsMouseDown = True
				SetSliderValue(e.Location)
				Invalidate()
			End If
		End If
	End Sub

	Private Sub PointSelector_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If IsMouseDown Then
			SetSliderValue(e.Location)
			Invalidate()
		End If
	End Sub

	Private Sub PointSelector_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		IsMouseDown = False
	End Sub
#End Region

#Region "Keyboard Events"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
		'Because a Usercontrol ignores the arrows in the KeyDown Event
		'and changes focus no matter what in the KeyUp Event
		'This is needed to fix the KeyDown problem
		Select Case keyData
			Case Keys.Left, Keys.Right, Keys.Up, Keys.Down
				Return True
			Case Else
				Return MyBase.IsInputKey(keyData)
		End Select
	End Function

	Private Sub MyTrackBar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		Select Case e.KeyData
			Case Keys.Left
				Dim sng = Value.X
				sng -= Increment
				Value = New Point(sng, Value.Y)
				Invalidate()
			Case Keys.Down
				Dim sng = Value.Y
				sng += Increment
				Value = New Point(Value.X, sng)
				Invalidate()
			Case Keys.Right
				Dim sng = Value.X
				sng += Increment
				Value = New Point(sng, Value.Y)
				Invalidate()
			Case Keys.Up
				Dim sng = Value.Y
				sng -= Increment
				Value = New Point(Value.X, sng)
				Invalidate()
		End Select
	End Sub
#End Region

#Region "Paint"
	Private Sub DrawRectF(g As Graphics, pn As Pen, rect As RectangleF)
		Dim pth As New GraphicsPath()
		pth.AddRectangle(rect)
		g.DrawPath(pn, pth)
		pth.Dispose()
	End Sub

	Private Sub PointSelector_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias
		g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

		Dim pn As New Pen(BordersColor, 2)

		g.FillRectangle(New SolidBrush(BackRectColor), rectSliderBar)
		DrawRectF(g, pn, rectSliderBar)

		Dim pt1 = New PointF(rectSliderBar.X + (rectSliderBar.Width / 2),
						   rectSliderBar.Top)
		Dim pt2 = New PointF(rectSliderBar.X + (rectSliderBar.Width / 2),
						   rectSliderBar.Bottom)
		Dim pt3 = New PointF(rectSliderBar.Left,
						   rectSliderBar.Y + (rectSliderBar.Height / 2))
		Dim pt4 = New PointF(rectSliderBar.Right,
						   rectSliderBar.Y + (rectSliderBar.Height / 2))
		Dim pt5 = New PointF(rectSliderBar.X + (rectSliderBar.Width / 2),
						   rectSliderBar.Y + (rectSliderBar.Height / 2))
		Dim pt6 = New PointF(rectSlider.X + (rectSlider.Width / 2),
						   rectSlider.Y + (rectSlider.Height / 2))

		g.DrawLine(pn, pt1, pt2)
		g.DrawLine(pn, pt3, pt4)
		g.DrawLine(pn, pt5, pt6)

		g.FillRectangle(New SolidBrush(ThumbColor), rectSlider)
		DrawRectF(g, pn, rectSlider)

		Dim rectVal As New Rectangle(0, rectSliderBar.Bottom + 5, Width, 20)
		Dim sf As New StringFormat With {
			.Alignment = StringAlignment.Center,
			.LineAlignment = StringAlignment.Center
		}
		Dim str As String = Value.ToString
		Dim tbr As New SolidBrush(ForeColor)
		g.DrawString(str, Font, tbr, rectVal, sf)

		If Focused Then
			Dim pnf As New Pen(Color.Gray, 1) With {
				.DashStyle = DashStyle.Dash
			}
			Dim rect As Rectangle = ClientRectangle
			rect.Width -= 1 : rect.Height -= 1
			g.DrawRectangle(pnf, rect)
		End If

	End Sub

	Private Sub PointSelector_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter, MyBase.Leave
		Invalidate()
	End Sub
#End Region

End Class
