#Region "Imports"
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports DrawIt.Helpers

#End Region

<DefaultEvent("Scroll")>
<DefaultProperty("Value")>
Public Class MyHScrollBar

#Region "Declerations"
	Private DrawFull As Boolean = False
	Private b_size As Integer = 15
	Private IsMouseDown As Boolean = False
	Private m_pt As Point
	Private m_p As Single
	Private sngSliderPos As Single
	Private rectUp As Rectangle
	Private m_up As Boolean = False
	Private rectDown As Rectangle
	Private m_down As Boolean = False
	Private b_up As Boolean = False
	Private b_down As Boolean = False
	Private rectScroll As Rectangle
	Private rectSlider As Rectangle
	Private rectThumb As Rectangle
	Private m_thumb As Boolean = False
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

	<Category("ScrollBar")>
	<Description("Occurs when the user moves the scroll box.")>
	Public Shadows Event Scroll(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

	Private _clrB As Color = Color.DarkGray
	<Category("ScrollBar")>
	<Description("Color of up and down buttons.")>
	<DefaultValue(GetType(Color), "DarkGray")>
	Public Property ButtonColor() As Color
		Get
			Return _clrB
		End Get
		Set(value As Color)
			_clrB = value
			Invalidate()
		End Set
	End Property

	Private _clrT As Color = Color.DarkGray
	<Category("ScrollBar")>
	<Description("Color of thumb.")>
	<DefaultValue(GetType(Color), "DarkGray")>
	Public Property ThumbColor() As Color
		Get
			Return _clrT
		End Get
		Set(value As Color)
			_clrT = value
			Invalidate()
		End Set
	End Property

	Private d_min As Boolean = False
	<Category("ScrollBar")>
	<Description("The value indicating scrollbar to be minimized when cursor is outside the control region.")>
	<DefaultValue(GetType(Boolean), "False")>
	Public Property DrawMinimzed() As Boolean
		Get
			Return d_min
		End Get
		Set(value As Boolean)
			d_min = value
			Invalidate()
		End Set
	End Property

	Private _arr As Boolean = False
	<Category("ScrollBar")>
	<Description("Gets or sets whether arrow keys can be used to scroll.")>
	<DefaultValue(GetType(Boolean), "False")>
	Public Property ArrowKeys() As Boolean
		Get
			Return _arr
		End Get
		Set(value As Boolean)
			_arr = value
		End Set
	End Property

	Private _value As Integer = 0
	<Category("ScrollBar")>
	<Description("The value that the scroll box position represents.")>
	<DefaultValue(GetType(Integer), "0")>
	Public Property Value() As Integer
		Get
			Return _value
		End Get
		Set(_val As Integer)
			If _value <> _val Then
				If _val < _minimum Then _val = _minimum
				If _val > _maximum Then _val = _maximum
				_value = _val
				SetSliderFromValues()
				Invalidate()
				RaiseEvent Scroll(Me, New EventArgs)
			End If
		End Set
	End Property

	Private _minimum As Integer = 0
	<Category("ScrollBar")>
	<Description("The lower limit value of the scrollable range.")>
	<DefaultValue(GetType(Integer), "0")>
	Public Property Minimum() As Integer
		Get
			Return _minimum
		End Get
		Set(_val As Integer)
			If _val >= _maximum Then _val = _maximum - 1
			_minimum = _val
			If Value < Minimum Then Value = Minimum
			SetSliderFromValues()
			Invalidate()
		End Set
	End Property

	Private _maximum As Integer = 100
	<Category("ScrollBar")>
	<Description("The upper limit value of the scrollable range.")>
	<DefaultValue(GetType(Integer), "100")>
	Public Property Maximum() As Integer
		Get
			Return _maximum
		End Get
		Set(_val As Integer)
			If _val <= _minimum Then _val = _minimum + 1
			_maximum = _val
			If Value > Maximum Then Value = Maximum
			SetSliderFromValues()
			Invalidate()
		End Set
	End Property

	Private _inc_s As Integer = 1
	<Category("ScrollBar")>
	<Description("The amount by which the scroll box position changes when the user clicks a scroll arrow or presses an arrow key.")>
	<DefaultValue(GetType(Integer), "1")>
	Public Property SmallChange() As Integer
		Get
			Return _inc_s
		End Get
		Set(value As Integer)
			If value < 0 Then value = 0
			_inc_s = value
		End Set
	End Property

	Private _inc_l As Integer = 10
	<Category("ScrollBar")>
	<Description("The amount by which the scroll box position changes when the user clicks in the scroll bar or presses the PAGE UP or PAGE DOWN keys.")>
	<DefaultValue(GetType(Integer), "10")>
	Public Property LargeChange() As Integer
		Get
			Return _inc_l
		End Get
		Set(value As Integer)
			If value < 0 Then value = 0
			_inc_l = value
		End Set
	End Property

#End Region

#Region "Re-Size"
	Private Sub MyVScrollBar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		Dim min = b_size * 2 + 15
		If Width < min Then Width = min
		Resizeit()
	End Sub

	Private Sub Resizeit()
		rectUp = New Rectangle(0, 0, b_size, Height - 1)
		rectDown = New Rectangle(Width - (b_size + 1), 0, b_size, Height - 1)
		rectScroll = New Rectangle(rectUp.Right, 0, Width - (b_size * 2), Height - 1)
		SetSliderFromValues()
	End Sub
#End Region

#Region "Slider Position"
	Public Sub BindWheelEvent(ctrl As Control)
		TabStop = False
		AddHandler ctrl.MouseWheel, AddressOf MyVScrollBar_MouseWheel
	End Sub

	Public Sub UnBindBindWheelEvent(ctrl As Control)
		TabStop = True
		RemoveHandler ctrl.MouseWheel, AddressOf MyVScrollBar_MouseWheel
	End Sub

	Private Sub UpdateSlider(xPos As Single)
		sngSliderPos = xPos
		Dim t_size As Integer = Math.Max(rectScroll.Width - (Maximum - Minimum), 15)
		rectSlider = rectScroll
		rectSlider.Width -= t_size
		If sngSliderPos < rectSlider.X Then sngSliderPos = rectSlider.X
		If sngSliderPos > rectSlider.Right Then sngSliderPos = rectSlider.Right
		rectThumb = New Rectangle(sngSliderPos, 0, t_size, Height - 1)
	End Sub

	Private Sub SetSliderValue(_y As Single)
		Dim perc As Single = MathUtils.ToPercentage(rectSlider.X, rectSlider.Right, _y)
		Dim _val As Single = MathUtils.FromPercentage(Minimum, Maximum, perc)
		Value = _val
		UpdateSlider(_y)
	End Sub

	Private Sub SetSliderFromValues()
		Dim perc As Single = MathUtils.ToPercentage(Minimum, Maximum, Value)
		Dim pos As Single = MathUtils.FromPercentage(rectSlider.X, rectSlider.Right, perc)
		UpdateSlider(pos)
	End Sub
#End Region

#Region "Mouse Events"
	Private Sub MyVScrollBar_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		m_pt = e.Location
		m_p = sngSliderPos
		If rectDown.Contains(e.Location) Then
			Value += SmallChange
			m_down = True
			Timer1.Start()
		ElseIf rectThumb.Contains(e.Location) Then
			If rectSlider.Width > 0 Then IsMouseDown = True
			m_thumb = True
		ElseIf rectUp.Contains(e.Location) Then
			Value -= SmallChange
			m_up = True
			Timer1.Start()
		ElseIf rectScroll.Contains(e.Location) Then
			If e.X > sngSliderPos Then
				Value += LargeChange
				b_down = True
				Timer1.Start()
			Else
				Value -= LargeChange
				b_up = True
				Timer1.Start()
			End If
		End If
		Invalidate()
	End Sub

	Private Sub MyVScrollBar_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If IsMouseDown Then
			Dim pt As Single = m_p + (e.X - m_pt.X)
			SetSliderValue(pt)
			Invalidate()
		End If
	End Sub

	Private Sub MyVScrollBar_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		IsMouseDown = False
		m_up = False
		m_down = False
		b_up = False
		b_down = False
		m_thumb = False
		Timer1.Stop()
		Timer1.Interval = 500
		Invalidate()
	End Sub

	Private Sub MyVScrollBar_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
		If d_min Then DrawFull = True
		Invalidate()
	End Sub

	Private Sub MyVScrollBar_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		If d_min Then DrawFull = False
		Invalidate()
	End Sub

	Private Sub MyVScrollBar_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
		Dim chg = SmallChange
		If My.Computer.Keyboard.ShiftKeyDown Then chg = LargeChange

		If e.Delta > 0 Then
			Value += chg
		Else
			Value -= chg
		End If
	End Sub
#End Region

#Region "Keyboard Events"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
		'Because a Usercontrol ignores the arrows in the KeyDown Event
		'and changes focus no matter what in the KeyUp Event
		'This is needed to fix the KeyDown problem
		If Not _arr Then Return MyBase.IsInputKey(keyData)
		Select Case keyData
			Case Keys.Left, Keys.Right
				Return True
			Case Else
				Return MyBase.IsInputKey(keyData)
		End Select
	End Function

	Private Sub MyTrackBar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		Select Case e.KeyData
			Case Keys.Right
				Value += SmallChange
			Case Keys.Left
				Value -= SmallChange
			Case Keys.PageDown
				Value += LargeChange
			Case Keys.PageUp
				Value -= LargeChange
		End Select
	End Sub
#End Region

#Region "Paint"
	Private Sub MyVScrollBar_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim bmp As New Bitmap(Width, Height)
		Dim g As Graphics = Graphics.FromImage(bmp)
		g.SmoothingMode = SmoothingMode.AntiAlias

		If DesignMode Or Not d_min Or (d_min And DrawFull) Then

			Dim p_brd As New Pen(Color.Black)
			Dim b_up = New SolidBrush(If(m_up, ControlPaint.Dark(ButtonColor, 0.1), ButtonColor))
			Dim b_down = New SolidBrush(If(m_down, ControlPaint.Dark(ButtonColor, 0.1), ButtonColor))
			Dim b_thumb = New SolidBrush(If(m_thumb, ControlPaint.Dark(ThumbColor, 0.1), ThumbColor))

			'Up button
			g.FillRectangle(b_up, rectUp)
			Dim r1 As New RectangleF(0, 0, 6, 6)
			r1.Location = New PointF(rectUp.X + (rectUp.Width / 2) - (r1.Width / 2),
									 rectUp.Y + (rectUp.Height / 2) - (r1.Height / 2))
			g.FillPolygon(Brushes.Black, New PointF() {
					New PointF(r1.Left, r1.Top + (r1.Height / 2)),
					New PointF(r1.Right, r1.Top),
					New PointF(r1.Right, r1.Bottom)
					})
			g.DrawRectangle(p_brd, rectUp)

			'Down Button
			g.FillRectangle(b_down, rectDown)
			Dim r2 As New RectangleF(0, 0, 6, 6)
			r2.Location = New PointF(rectDown.X + (rectDown.Width / 2) - (r2.Width / 2),
									 rectDown.Y + (rectDown.Height / 2) - (r2.Height / 2))
			g.FillPolygon(Brushes.Black, New PointF() {
					New PointF(r2.Right, r2.Top + (r2.Height / 2)),
					New PointF(r2.Left, r2.Top),
					New PointF(r2.Left, r2.Bottom)
					})
			g.DrawRectangle(p_brd, rectDown)

			'Bar
			g.FillRectangle(New SolidBrush(BackColor), rectScroll)
			g.DrawRectangle(p_brd, rectScroll)

			'Thumb
			g.FillRectangle(b_thumb, rectThumb)
			Dim r3 As New Rectangle(0, 0, 6, 6)
			r3.Location = New Point(rectThumb.X + rectThumb.Width / 2 - r3.Width / 2,
								rectThumb.Y + rectThumb.Height / 2 - r3.Height / 2)
			g.DrawLine(p_brd, New PointF(r3.X, r3.Y), New PointF(r3.X, r3.Bottom))
			g.DrawLine(p_brd, New PointF(r3.X + (r3.Width / 2), r3.Y), New PointF(r3.X + (r3.Width / 2), r3.Bottom))
			g.DrawLine(p_brd, New PointF(r3.Right, r3.Y), New PointF(r3.Right, r3.Bottom))
			g.DrawRectangle(p_brd, rectThumb)

			p_brd.Dispose()
			b_up.Dispose()
			b_down.Dispose()
			b_thumb.Dispose()

		Else

			Dim r_min = rectThumb
			r_min.Width = 5
			r_min.X = Width - (r_min.Width)
			g.FillRectangle(New SolidBrush(Color.DarkGray), r_min)

		End If

		If Enabled Then
			e.Graphics.DrawImageUnscaled(bmp, 0, 0)
		Else
			ControlPaint.DrawImageDisabled(e.Graphics, bmp, 0, 0, BackColor)
		End If

		bmp.Dispose()

	End Sub
#End Region

#Region "Timer"
	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Timer1.Interval = 50
		If m_down Then
			Value += SmallChange
		ElseIf m_up Then
			Value -= SmallChange
		ElseIf b_down Then
			If Not rectThumb.Contains(m_pt) Then
				Value += LargeChange
			Else
				Timer1.Stop()
				Timer1.Interval = 500
			End If
		ElseIf b_up Then
			If Not rectThumb.Contains(m_pt) Then
				Value -= LargeChange
			Else
				Timer1.Stop()
				Timer1.Interval = 500
			End If
		End If
	End Sub
#End Region

End Class