Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

''' <summary>
''' Flat style button for windows forms.
''' </summary>
<Description("Flat style button for windows forms.")>
<DefaultEvent("Click")>
<DefaultProperty("MyText")>
Public Class FlatButton

	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		MyText = Name
	End Sub

	Private Enum State
		Normal
		Hover
		Active
	End Enum

	Private _state As State = State.Normal

	Private _icon As Image = Nothing
	''' <summary>
	''' Icon to be drawn on control.
	''' </summary>
	<Description("Icon to be drawn on control.")>
	Public Property Icon() As Image
		Get
			Return _icon
		End Get
		Set(value As Image)
			_icon = value
			Invalidate()
		End Set
	End Property

	Private d_text As Boolean = True
	''' <summary>
	''' Indicates whether text will be drawn or not.
	''' </summary>
	<Description("Indicates whether text will be drawn or not.")>
	<DefaultValue(GetType(Boolean), "True")>
	Public Property DrawText() As Boolean
		Get
			Return d_text
		End Get
		Set(value As Boolean)
			d_text = value
			Invalidate()
		End Set
	End Property

	Private font_szi As Single = 1
	''' <summary>
	''' Increment in font size if mouse is hovered or pressed.
	''' </summary>
	<Description("Increment in font size if mouse is hovered or pressed.")>
	<DefaultValue(GetType(Single), "1")>
	Public Property FontSizeIncrement() As Single
		Get
			Return font_szi
		End Get
		Set(value As Single)
			font_szi = value
			Invalidate()
		End Set
	End Property

	Private ico_szi As Single = 2
	''' <summary>
	''' Increment in icon size if mouse is hovered or pressed.
	''' </summary>
	<Description("Increment in icon size if mouse is hovered or pressed.")>
	<DefaultValue(GetType(Single), "2")>
	Public Property IconSizeIncrement() As Single
		Get
			Return ico_szi
		End Get
		Set(value As Single)
			ico_szi = value
			Invalidate()
		End Set
	End Property

	Private ico_sz As Single = 30
	''' <summary>
	''' Width and height of icon.
	''' </summary>
	<Description("Width and height of icon.")>
	<DefaultValue(GetType(Single), "30")>
	Public Property IconSize() As Single
		Get
			Return ico_sz
		End Get
		Set(value As Single)
			ico_sz = value
			Invalidate()
		End Set
	End Property

	''' <summary>
	''' Text to display on control.
	''' </summary>
	<Description("Text to display on control.")>
	Public Property MyText As String
		Get
			Return Text
		End Get
		Set(value As String)
			Text = value
			Invalidate()
		End Set
	End Property

	Private _normal As Color = Color.Gray
	''' <summary>
	''' Control color when cursor is outside the control bounds.
	''' </summary>
	<Description("Control color when cursor is outside the control bounds.")>
	<DefaultValue(GetType(Color), "Gray")>
	Public Property NormalColor() As Color
		Get
			Return _normal
		End Get
		Set(value As Color)
			_normal = value
			Invalidate()
		End Set
	End Property

	Private _hover As Color = Color.LightGray
	''' <summary>
	''' Control color when mouse is in hovered state.
	''' </summary>
	<Description("Control color when mouse is in hovered state.")>
	<DefaultValue(GetType(Color), "LightGray")>
	Public Property HoverColor() As Color
		Get
			Return _hover
		End Get
		Set(value As Color)
			_hover = value
			Invalidate()
		End Set
	End Property

	Private _active As Color = Color.FromArgb(100, 100, 100)
	''' <summary>
	''' Control color when mouse is in pressed state.
	''' </summary>
	<Description("Control color when mouse is in pressed state.")>
	<DefaultValue(GetType(Color), "100, 100, 100")>
	Public Property ActiveColor() As Color
		Get
			Return _active
		End Get
		Set(value As Color)
			_active = value
			Invalidate()
		End Set
	End Property

	Private t_normal As Color = Color.Black
	''' <summary>
	''' Text color when cursor is outside the control bounds.
	''' </summary>
	<Description("Text color when cursor is outside the control bounds.")>
	<DefaultValue(GetType(Color), "Black")>
	Public Property NormalTextColor() As Color
		Get
			Return t_normal
		End Get
		Set(value As Color)
			t_normal = value
			Invalidate()
		End Set
	End Property

	Private t_hover As Color = Color.Black
	''' <summary>
	''' Text color when mouse is in hovered state.
	''' </summary>
	<Description("Text color when mouse is in hovered state.")>
	<DefaultValue(GetType(Color), "Black")>
	Public Property HoverTextColor() As Color
		Get
			Return t_hover
		End Get
		Set(value As Color)
			t_hover = value
			Invalidate()
		End Set
	End Property

	Private t_active As Color = Color.White
	''' <summary>
	''' Text color when mouse is in pressed state.
	''' </summary>
	<Description("Text color when mouse is in pressed state.")>
	<DefaultValue(GetType(Color), "White")>
	Public Property ActiveTextColor() As Color
		Get
			Return t_active
		End Get
		Set(value As Color)
			t_active = value
			Invalidate()
		End Set
	End Property

	Public Sub ResetState()
		_state = State.Normal
		Invalidate()
	End Sub

	Private Sub FlatButton_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		_state = State.Active
		Invalidate()
	End Sub

	Private Sub FlatButton_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
		_state = State.Hover
		Invalidate()
	End Sub

	Private Sub FlatButton_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		_state = State.Normal
		Invalidate()
	End Sub

	Private Sub FlatButton_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
		_state = State.Hover
		Invalidate()
	End Sub

	Private Sub FlatButton_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias

		g.Clear(BackColor)

		Dim _fill As Color = Color.Transparent
		Dim _text As Color = Color.Transparent

		Select Case _state
			Case State.Active
				_fill = ActiveColor
				_text = ActiveTextColor
			Case State.Hover
				_fill = HoverColor
				_text = HoverTextColor
			Case State.Normal
				_fill = NormalColor
				_text = NormalTextColor
		End Select
		Dim rect As Rectangle = ClientRectangle
		rect.Inflate(1, 1)
		g.FillRectangle(New SolidBrush(_fill), rect)

		Dim i_rect As Rectangle = New Rectangle(0, 0, Height, Height)
		Dim t_rect As Rectangle = rect
		Dim cent As New PointF(i_rect.Width / 2, i_rect.Height / 2)
		Dim ico_r As New RectangleF(cent, SizeF.Empty)
		Dim sz As Single = ico_sz + ico_szi
		If _state = State.Normal Then sz -= ico_szi
		ico_r.Inflate(sz / 2, sz / 2)
		If Not IsNothing(_icon) Then
			t_rect.X += (ico_r.Width + (ico_r.X * 2))
			t_rect.Width -= (ico_r.Width + (ico_r.X * 2))
			Dim ico As New Bitmap(_icon, ico_r.Width, ico_r.Height)
			g.DrawImage(_icon, ico_r)
		End If

		If d_text Then
			'g.FillRectangle(Brushes.White, t_rect)
			Dim sf As New StringFormat With {
				.Alignment = StringAlignment.Center
			}
			If Not IsNothing(_icon) Then sf.Alignment = StringAlignment.Near
			sf.LineAlignment = StringAlignment.Center
			'sf.Trimming = StringTrimming.EllipsisWord
			Dim f_size As Single = Font.Size + font_szi
			If _state = State.Normal Then f_size -= font_szi
			Dim fnt As New Font(Font.FontFamily, f_size, Font.Style)
			g.DrawString(MyText, fnt, New SolidBrush(_text), t_rect, sf)
			fnt.Dispose()
			sf.Dispose()
		End If
	End Sub

	Private Sub FlatButton_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyData = Keys.Enter Then
			InvokeOnClick(Me, New EventArgs())
		End If
	End Sub

	Private Sub FlatButton_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
		ResetState()
	End Sub
End Class
