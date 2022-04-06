#Region "Imports"
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
#End Region

<ToolboxBitmap(GetType(TrackBar))>
<DefaultProperty("Value")>
<DefaultEvent("ValueChanged")>
Public Class MyTrackBar

#Region "Enum"

	Enum BlendType
		ColorBlend
		Blend
	End Enum

#End Region

#Region "Declerations"

	Private IsMouseDown As Boolean = False
	Private rectSlider As Rectangle
	Private rectSliderBar As Rectangle
	Private sngSliderPos As Single

#End Region

#Region "New"

	Public Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
	End Sub

#End Region

#Region "Events"

	<Category("TrackBar")>
	<Description("Occurs when value is changed.")>
	Public Event ValueChanged(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

	Private _type As BlendType = BlendType.ColorBlend
	<Category("TrackBar")>
	<Description("Blend type of fill brush.")>
	<DefaultValue(GetType(BlendType), "ColorBlend")>
	Public Property Type() As BlendType
		Get
			Return _type
		End Get
		Set(value As BlendType)
			_type = value
			Invalidate()
		End Set
	End Property

	Private _clr1 As Color = Color.White
	<Category("TrackBar")>
	<Description("First color of brush.")>
	<DefaultValue(GetType(Color), "White")>
	Public Property Color1() As Color
		Get
			Return _clr1
		End Get
		Set(value As Color)
			_clr1 = value
			Invalidate()
		End Set
	End Property

	Private _clr2 As Color = Color.Black
	<Category("TrackBar")>
	<Description("Last color of brush.")>
	<DefaultValue(GetType(Color), "Black")>
	Public Property Color2() As Color
		Get
			Return _clr2
		End Get
		Set(value As Color)
			_clr2 = value
			Invalidate()
		End Set
	End Property

	Private _sng As Boolean = True
	<Category("TrackBar")>
	<Description("Allow floating point numbers as value.")>
	<DefaultValue(GetType(Boolean), "True")>
	Public Property AllowDecimal() As Boolean
		Get
			Return _sng
		End Get
		Set(value As Boolean)
			_sng = value
			Invalidate()
		End Set
	End Property

	Private _value As Single = 0
	<Category("TrackBar")>
	<Description("Value")>
	<DefaultValue(GetType(Single), "0")>
	Public Property Value() As Single
		Get
			Return _value
		End Get
		Set(val As Single)
			If AllowDecimal = False Then val = CInt(val)
			If _value <> val Then
				If val < _minimum Then val = _minimum
				If val > _maximum Then val = _maximum
				_value = val
				SetSliderFromValues()
				Invalidate()
				RaiseEvent ValueChanged(Me, New EventArgs)
			End If
		End Set
	End Property

	Private _minimum As Single = 0
	<Category("TrackBar")>
	<Description("Minimum Value")>
	<DefaultValue(GetType(Single), "0")>
	Public Property Minimum() As Single
		Get
			Return _minimum
		End Get
		Set(Value As Single)
			If Value >= _maximum Then Value = _maximum - 1
			_minimum = Value
			SetSliderFromValues()
			Invalidate()
		End Set
	End Property

	Private _maximum As Single = 100
	<Category("TrackBar")>
	<Description("Maximum Value")>
	<DefaultValue(GetType(Single), "100")>
	Public Property Maximum() As Single
		Get
			Return _maximum
		End Get
		Set(Value As Single)
			If Value <= _minimum Then Value = _minimum + 1
			_maximum = Value
			SetSliderFromValues()
			Invalidate()
		End Set
	End Property

	Private _increment As Single = 1
	<Category("TrackBar")>
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

	Private _colors As Color() = New Color() {Color.White, Color.Black}
	<Category("TrackBar")>
	<Description("Colors of linear gradient brush.")>
	Public Property Colors() As Color()
		Get
			Return _colors
		End Get
		Set(value As Color())
			_colors = value
			Invalidate()
		End Set
	End Property

	Private _positions As Single() = New Single() {0, 1}
	<Category("TrackBar")>
	<Description("Positions of linear gradient brush.")>
	Public Property Positions() As Single()
		Get
			Return _positions
		End Get
		Set(value As Single())
			_positions = value
			Invalidate()
		End Set
	End Property

	Private _factors As Single() = New Single() {0, 1}
	<Category("TrackBar")>
	<Description("Factors of linear gradient brush.")>
	Public Property Factors() As Single()
		Get
			Return _factors
		End Get
		Set(value As Single())
			_factors = value
			Invalidate()
		End Set
	End Property

	Private thumb_clr As Color = Color.FromArgb(180, Color.White)
	<Category("TrackBar")>
	<Description("Thumb Color")>
	<DefaultValue(GetType(Color), "180,255,255,255")>
	Public Property ThumbColor() As Color
		Get
			Return thumb_clr
		End Get
		Set(value As Color)
			thumb_clr = value
			Invalidate()
		End Set
	End Property

	Private thumb_brd As Color = Color.RoyalBlue
	<Category("TrackBar")>
	<Description("Thumb Border Color")>
	<DefaultValue(GetType(Color), "RoyalBlue")>
	Public Property ThumbBorderColor() As Color
		Get
			Return thumb_brd
		End Get
		Set(value As Color)
			thumb_brd = value
			Invalidate()
		End Set
	End Property

	Private bar_brd As Color = Color.Blue
	<Category("TrackBar")>
	<Description("Bar Border Color")>
	<DefaultValue(GetType(Color), "Blue")>
	Public Property BarBorderColor() As Color
		Get
			Return bar_brd
		End Get
		Set(value As Color)
			bar_brd = value
			Invalidate()
		End Set
	End Property

#End Region

#Region "Re-Size"

	Private Sub gSizer_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
		Resizeit()
		Invalidate()
	End Sub

	Private Sub Resizeit()
		rectSliderBar = New Rectangle(5, 5, Width - 51, Height - 11)
		SetSliderFromValues()
	End Sub

#End Region

#Region "Slider Position"
	Private Sub UpdateSlider(xPos As Single)
		sngSliderPos = xPos
		If sngSliderPos < rectSliderBar.X Then sngSliderPos = rectSliderBar.X
		If sngSliderPos > rectSliderBar.Right Then sngSliderPos = rectSliderBar.Right
		rectSlider = New Rectangle(sngSliderPos - 4, 2, 8, Height - 5)
	End Sub

	Private Sub SetSliderValue(pt As Point)
		Dim perc As Single = ToPercentage(rectSliderBar.X, rectSliderBar.Right, pt.X)
		Dim _val As Single = FromPercentage(Minimum, Maximum, perc)
		If AllowDecimal = False Then _val = CInt(_val)
		Value = _val
		UpdateSlider(pt.X)
	End Sub

	Private Sub SetSliderFromValues()
		Dim perc As Single = ToPercentage(Minimum, Maximum, Value)
		Dim pos As Single = FromPercentage(rectSliderBar.X, rectSliderBar.Right, perc)
		UpdateSlider(pos)
	End Sub

#End Region

#Region "Mouse Events"

	Private Sub MyTrackBar_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
		If rectSlider.Contains(e.Location) Or rectSliderBar.Contains(e.Location) Then
			If IsMouseDown = False Then
				IsMouseDown = True
				SetSliderValue(e.Location)
				Invalidate()
			End If
		End If
	End Sub

	Private Sub MyTrackBar_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
		If IsMouseDown Then
			SetSliderValue(e.Location)
			Invalidate()
		End If
	End Sub

	Private Sub MyTrackBar_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
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
			Case Keys.Left, Keys.Down
				Value -= Increment
				Invalidate()
			Case Keys.Right, Keys.Up
				Value += Increment
				Invalidate()
			Case Keys.Control Or Keys.Left, Keys.Control Or Keys.Down
				Value = CInt(Value) - CInt(Increment)
				Invalidate()
			Case Keys.Control Or Keys.Right, Keys.Control Or Keys.Up
				Value = CInt(Value) + CInt(Increment)
				Invalidate()
		End Select
	End Sub

#End Region

#Region "Paint"

	Private Sub MyTrackBar_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim bmp As New Bitmap(Width, Height)
		Dim g As Graphics = Graphics.FromImage(bmp)
		g.SmoothingMode = SmoothingMode.AntiAlias
		g.RenderingOrigin = rectSliderBar.Location

		'Dim rectValueBar As Rectangle = New Rectangle(rectSliderBar.X, rectSliderBar.Y, CInt(sngSliderPos - rectSliderBar.X), rectSliderBar.Height)

		Dim br = New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
		g.FillRectangle(br, rectSliderBar)

		Dim brSlider As New LinearGradientBrush(rectSliderBar, Color1, Color2, 0)

		If Type = BlendType.ColorBlend AndAlso Colors.Length > 1 AndAlso Positions.Length = Colors.Length Then
			Dim cb As New ColorBlend With {
				.Colors = Colors,
				.Positions = Positions
			}
			brSlider.InterpolationColors = cb
			g.FillRectangle(brSlider, rectSliderBar)
		End If

		If Type = BlendType.Blend AndAlso Factors.Length > 1 AndAlso Positions.Length = Factors.Length Then
			Dim cb As New Blend With {
				.Factors = Factors,
				.Positions = Positions
			}
			brSlider.Blend = cb
			g.FillRectangle(brSlider, rectSliderBar)
		End If

		g.DrawRectangle(New Pen(BarBorderColor), rectSliderBar)

		g.FillRectangle(New SolidBrush(ThumbColor), rectSlider)
		g.DrawRectangle(New Pen(ThumbBorderColor), rectSlider)

		Dim sf As New StringFormat With {
			.Alignment = StringAlignment.Center,
			.LineAlignment = StringAlignment.Center
		}
		Dim str As String = CSng(Math.Round(Value, 2)).ToString
		Dim tbr As New SolidBrush(ForeColor)
		Dim t_size = TextRenderer.MeasureText(str, Font)
		Dim rectVal As New Rectangle(rectSliderBar.Right + 5, Height / 2 - t_size.Height / 2, t_size.Width, t_size.Height)

		TextRenderer.DrawText(e.Graphics, str, Font, rectVal, ForeColor, TextFormatFlags.SingleLine)

		If Focused Then
			Dim pn As New Pen(Color.Gray, 1) With {
				.DashStyle = DashStyle.Dash
			}
			Dim rect As Rectangle = ClientRectangle
			rect.Width -= 1 : rect.Height -= 1
			g.DrawRectangle(pn, rect)
		End If

		If Enabled Then
			e.Graphics.DrawImageUnscaled(bmp, 0, 0)
		Else
			ControlPaint.DrawImageDisabled(e.Graphics, bmp, 0, 0, BackColor)
		End If

	End Sub

	Private Sub MyTrackBar_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter, MyBase.Leave
		Invalidate()
	End Sub

#End Region

End Class

