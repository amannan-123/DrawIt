Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<DefaultEvent("Click")>
<DefaultProperty("MyText")>
Public Class MyButton

	Sub New()
		InitializeComponent()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		Text = Name
		Reset()
	End Sub

	Private pt As Point
	Private md As Boolean = False
	Private inf As Integer = Math.Min(Width, Height)

	<DefaultValue("Text")>
	<Description("The text associated with the control.")>
	<Category("Appearance")>
	Public Property MyText As String
		Get
			Return Text
		End Get
		Set(value As String)
			Text = value
			Invalidate()
		End Set
	End Property

	Private clr As Color = Color.FromArgb(60, 255, 255, 255)
	<Category("Appearance")>
	<DefaultValue(GetType(Color), "60, 255, 255, 255")>
	<Description("Gets or sets the effect color the control.")>
	Public Property EffectColor As Color
		Get
			Return clr
		End Get
		Set(value As Color)
			clr = value
			Invalidate()
		End Set
	End Property

	Private _brd As Color = Color.Black
	<Category("Appearance")>
	<Description("Gets or sets the border color the control.")>
	<DefaultValue(GetType(Color), "Black")>
	Public Property BorderColor() As Color
		Get
			Return _brd
		End Get
		Set(value As Color)
			_brd = value
			Invalidate()
		End Set
	End Property


	Private inc As Integer = 3
	<Category("Appearance")>
	<Description("Gets or sets the effect's increment value.")>
	<DefaultValue(3)>
	Public Property Increment As Integer
		Get
			Return inc
		End Get
		Set(value As Integer)
			inc = value
			Invalidate()
		End Set
	End Property

	Private brd As Boolean = False
	<Category("Appearance")>
	<DefaultValue(GetType(Boolean), "False")>
	<Description("Indicates whether border should be drawn or not.")>
	Public Property DrawBorder As Boolean
		Get
			Return brd
		End Get
		Set(value As Boolean)
			brd = value
			Invalidate()
		End Set
	End Property

	Private foc As Boolean = True
	<Category("Appearance")>
	<DefaultValue(GetType(Boolean), "True")>
	<Description("Indicates whether focus rectangle should be drawn or not.")>
	Public Property DrawFocus As Boolean
		Get
			Return foc
		End Get
		Set(value As Boolean)
			foc = value
			Invalidate()
		End Set
	End Property

	Private eff As Boolean = True
	<Category("Appearance")>
	<DefaultValue(GetType(Boolean), "True")>
	<Description("Indicates whether effect should be drawn or not.")>
	Public Property DrawEffect As Boolean
		Get
			Return eff
		End Get
		Set(value As Boolean)
			eff = value
			Reset()
		End Set
	End Property

	Private Sub Reset()
		inf = Math.Min(Width, Height)
		Dim point As Point = New Point(-Math.Max(Width, Height), -Math.Max(Width, Height))
		pt = point
		Invalidate()
	End Sub

	Private Sub MyButton_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.AntiAlias
		If DrawEffect Then
			Dim rectangle As Rectangle = New Rectangle(pt.X, pt.Y, 0, 0)
			Dim rect As Rectangle = rectangle
			rect.Inflate(inf, inf)
			rect.Inflate(Math.Min(Width, Height), Math.Min(Width, Height))
			Dim gp As GraphicsPath = New GraphicsPath()
			gp.AddEllipse(rect)
			Dim lgb As PathGradientBrush = New PathGradientBrush(gp)
			Dim bl As ColorBlend = New ColorBlend With {
				.Colors = New Color() {Color.Transparent, Color.Transparent, EffectColor},
				.Positions = New Single() {0F, 0.2F, 1.0F}
			}
			lgb.InterpolationColors = bl
			g.FillEllipse(lgb, rect)
			Dim bord As Rectangle = New Rectangle(0, 0, Width - 1, Height - 1)
			Dim gpb As GraphicsPath = New GraphicsPath()
			gpb.AddEllipse(rect)
			Dim lgbb As PathGradientBrush = New PathGradientBrush(gpb)
			Dim blb As ColorBlend = New ColorBlend With {
				.Colors = New Color() {Color.Transparent, Color.Transparent, Color.FromArgb(255, EffectColor)},
				.Positions = New Single() {0F, 0.2F, 1.0F}
			}
			lgbb.InterpolationColors = blb
			Dim pn As Pen = New Pen(lgbb)
			g.DrawRectangle(pn, bord)
		End If

		Dim sld As SolidBrush = New SolidBrush(ForeColor)
		Dim sf As StringFormat = New StringFormat(StringFormatFlags.NoWrap) With {
			.Alignment = StringAlignment.Center,
			.LineAlignment = StringAlignment.Center
		}
		Dim layoutRectangle As RectangleF = ClientRectangle
		g.DrawString(MyText, Font, sld, layoutRectangle, sf)

		Dim b_rect As Rectangle = ClientRectangle
		b_rect.Width -= 1 : b_rect.Height -= 1

		If DrawBorder Then g.DrawRectangle(New Pen(BorderColor), b_rect)

		If Focused AndAlso DrawFocus Then
			Dim pn As New Pen(Color.Gray) With {
				.DashPattern = New Single() {3, 2}
			}
			If DrawEffect Then
				If Not md Then g.DrawRectangle(pn, b_rect)
			Else
				g.DrawRectangle(pn, b_rect)
			End If
		End If

	End Sub

	Private Sub MyButton_Load(sender As Object, e As EventArgs) Handles Me.Load
		Reset()
	End Sub

	Private Sub MyButton_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
		tInf.Start()
	End Sub

	Private Sub MyButton_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
		md = True
		Invalidate()
	End Sub

	Private Sub MyButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
		md = False
		Reset()
	End Sub

	Private Sub MyButton_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
		Dim location As Point = e.Location
		pt = location
		Invalidate()
	End Sub

	Private Sub MyButton_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
		tInf.Stop()
		Reset()
	End Sub

	Private Sub MyButton_Resize(sender As Object, e As EventArgs) Handles Me.Resize
		Reset()
	End Sub

	Private Sub tInf_Tick(sender As Object, e As EventArgs) Handles tInf.Tick
		If inf < Math.Max(Width, Height) * 2 Then
			inf += Increment
		End If
		Invalidate()
	End Sub

	Private Sub MyButton_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter, MyBase.Leave
		Invalidate()
	End Sub

	Private Sub MyButton_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyData = Keys.Enter Then
			InvokeOnClick(Me, New EventArgs())
		End If
	End Sub

End Class
