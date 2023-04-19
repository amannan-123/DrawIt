Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.Design

#Region "ColorSelector"
<DefaultEvent("ColorChanged")>
<DefaultProperty("SelectedColor")>
Public Class ColorSelector

	Private m_EditorService As IWindowsFormsEditorService = Nothing
	Private m_button As ColorEditorButton = Nothing

	Sub New()
		InitializeComponent()
		PutColors()
	End Sub

	Sub New(_button As ColorEditorButton)
		InitializeComponent()
		PutColors()
		m_button = _button
		Button2.Visible = True
	End Sub

	Sub New(_clr As Color, editor_service As IWindowsFormsEditorService)
		InitializeComponent()
		PutColors()
		m_EditorService = editor_service
		SelectedColor = _clr
		Button2.Visible = True
	End Sub

	Public Property SelectedColor() As Color
		Get
			Return MyPanel1.BackColor
		End Get
		Set(value As Color)
			If SelectedColor <> value Then
				MyPanel1.BackColor = value
				MyPanel1.Refresh()
				RaiseEvent ColorChanged(Me, New EventArgs)
				UpdateTrackers()
				UpdateControls()
				UpdateColors()
			End If
		End Set
	End Property

	Public Event ColorChanged(sender As Object, e As EventArgs)

	Private Sub PutColors()
		cb_Colors.Items.Clear()
		For Each str As String In [Enum].GetNames(GetType(KnownColor))
			Dim clr As Color = Color.FromName(str)
			If clr.IsSystemColor = False Then
				cb_Colors.Items.Add(str)
			End If
		Next
		cb_Colors.Items.RemoveAt(0)
		cb_Colors.SelectedIndex = 0
	End Sub

	Private Sub ColorDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim pos As Single() = New Single() {0, 0.5, 1}
		t_sat1.Positions = pos
		t_sat2.Positions = pos
		t_lum.Positions = pos
		t_bri.Positions = pos
		Dim pos2 As Single() = New Single() {0 / 6, 1 / 6, 2 / 6, 3 / 6, 4 / 6, 5 / 6, 6 / 6}
		t_hue1.Positions = pos2
		t_hue2.Positions = pos2
	End Sub

	Private Function IsPreDefined(_clr As Color) As String
		For Each str As String In [Enum].GetNames(GetType(KnownColor))
			Dim clr As Color = Color.FromName(str)
			If clr.R = _clr.R AndAlso clr.G = _clr.G AndAlso clr.B = _clr.B Then
				If cb_Colors.Items.Contains(str) Then
					Return str
				End If
			End If
		Next
		Return ""
	End Function

	Private Function GetHex(num As Integer) As String
		Dim str As String = Hex(num)
		While str.Length < 2
			str = "0" & str
		End While
		Return str
	End Function

	Sub UpdateName()
		Dim str = IsPreDefined(MyPanel1.BackColor)
		Dim str2 = GetHex(t_alpha.Value) & GetHex(t_red.Value) & GetHex(t_green.Value) & GetHex(t_blue.Value)
		If Not str = "" Then str &= " - "
		TextBox1.Text = "Name: " & str & str2
		t_Hex.Text = str2
	End Sub

	Sub UpdateControls()
		UpdateName()
		RemoveHandler cb_Colors.SelectedIndexChanged, AddressOf cb_Colors_SelectedIndexChanged

		Dim str = IsPreDefined(MyPanel1.BackColor)
		If Not str = "" Then cb_Colors.SelectedItem = str

		AddHandler cb_Colors.SelectedIndexChanged, AddressOf cb_Colors_SelectedIndexChanged
	End Sub

	Sub UpdateTrackers(Optional _rgb As Boolean = True, Optional _hsl As Boolean = True, Optional _hsb As Boolean = True)
		RemoveHandler t_alpha.ValueChanged, AddressOf t_red_ValueChanged
		RemoveHandler t_red.ValueChanged, AddressOf t_red_ValueChanged
		RemoveHandler t_blue.ValueChanged, AddressOf t_red_ValueChanged
		RemoveHandler t_green.ValueChanged, AddressOf t_red_ValueChanged

		RemoveHandler t_hue1.ValueChanged, AddressOf t_hue1_ValueChanged
		RemoveHandler t_sat1.ValueChanged, AddressOf t_hue1_ValueChanged
		RemoveHandler t_lum.ValueChanged, AddressOf t_hue1_ValueChanged

		RemoveHandler t_hue2.ValueChanged, AddressOf t_hue2_ValueChanged
		RemoveHandler t_sat2.ValueChanged, AddressOf t_hue2_ValueChanged
		RemoveHandler t_bri.ValueChanged, AddressOf t_hue2_ValueChanged

		Dim clr As Color = MyPanel1.BackColor
		t_alpha.Value = clr.A

		Dim rgb As New ColorConversions.RGB(clr.R, clr.G, clr.B)
		Dim hsl As ColorConversions.HSL = ColorConversions.RGBToHSL(rgb)
		Dim hsb As ColorConversions.HSV = ColorConversions.RGBToHSV(rgb)
		If _rgb Then
			t_red.Value = rgb.R
			t_green.Value = rgb.G
			t_blue.Value = rgb.B
		End If
		If _hsl Then
			If hsl.H = 360 Then hsl.H = 0
			t_hue1.Value = hsl.H
			t_sat1.Value = hsl.S * 100
			t_lum.Value = hsl.L * 100
		End If
		If _hsb Then
			If hsb.H = 360 Then hsb.H = 0
			t_hue2.Value = hsb.H
			t_sat2.Value = hsb.S * 100
			t_bri.Value = hsb.V * 100
		End If

		AddHandler t_alpha.ValueChanged, AddressOf t_red_ValueChanged
		AddHandler t_red.ValueChanged, AddressOf t_red_ValueChanged
		AddHandler t_blue.ValueChanged, AddressOf t_red_ValueChanged
		AddHandler t_green.ValueChanged, AddressOf t_red_ValueChanged

		AddHandler t_hue1.ValueChanged, AddressOf t_hue1_ValueChanged
		AddHandler t_sat1.ValueChanged, AddressOf t_hue1_ValueChanged
		AddHandler t_lum.ValueChanged, AddressOf t_hue1_ValueChanged

		AddHandler t_hue2.ValueChanged, AddressOf t_hue2_ValueChanged
		AddHandler t_sat2.ValueChanged, AddressOf t_hue2_ValueChanged
		AddHandler t_bri.ValueChanged, AddressOf t_hue2_ValueChanged

	End Sub

	Sub UpdateColors()
		t_alpha.Colors = New Color() {
			Color.FromArgb(0, t_red.Value, t_green.Value, t_blue.Value),
			Color.FromArgb(255, t_red.Value, t_green.Value, t_blue.Value)}

		t_red.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, 0, t_green.Value, t_blue.Value),
			Color.FromArgb(t_alpha.Value, 255, t_green.Value, t_blue.Value)}
		t_green.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, t_red.Value, 0, t_blue.Value),
			Color.FromArgb(t_alpha.Value, t_red.Value, 255, t_blue.Value)}
		t_blue.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, t_red.Value, t_green.Value, 0),
			Color.FromArgb(t_alpha.Value, t_red.Value, t_green.Value, 255)}


		t_hue1.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(0, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(60, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(120, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(180, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(240, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(300, t_sat1.Value / 100, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(360, t_sat1.Value / 100, t_lum.Value / 100))}
		t_sat1.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, 0, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, 0.5, t_lum.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, 1, t_lum.Value / 100))}
		t_lum.Colors = New Color() {
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, t_sat1.Value / 100, 0)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, t_sat1.Value / 100, 0.5)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, t_sat1.Value / 100, 1))}

		t_hue2.Colors = New Color() {
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(0, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(60, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(120, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(180, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(240, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(300, t_sat2.Value / 100, t_bri.Value / 100)),
			Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(360, t_sat2.Value / 100, t_bri.Value / 100))}
		t_sat2.Colors = New Color() {
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, 0, t_bri.Value / 100)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, 0.5, t_bri.Value / 100)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, 1, t_bri.Value / 100))}
		t_bri.Colors = New Color() {
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, t_sat2.Value / 100, 0)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, t_sat2.Value / 100, 0.5)),
		   Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, t_sat2.Value / 100, 1))}

	End Sub

	Private Sub cb_Colors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Colors.SelectedIndexChanged
		Dim clr As Color = Color.FromName(cb_Colors.SelectedItem)
		MyPanel1.BackColor = Color.FromArgb(t_alpha.Value, clr)
		RaiseEvent ColorChanged(Me, New EventArgs)
		UpdateTrackers()
		UpdateColors()
		UpdateName()
	End Sub

	Private Sub cb_Colors_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cb_Colors.DrawItem
		If e.Index < 0 Then Return
		' If the item is the edit box item, then draw the rectangle white
		' If the item is the selected item, then draw the rectangle blue
		' Otherwise, draw the rectangle filled in beige
		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
		End If

		' Cast the sender object  to ComboBox type.
		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)
		Dim myBrush As New SolidBrush(Color.FromName(itemString))

		'Draw a Color Swatch
		e.Graphics.FillRectangle(myBrush, e.Bounds.X + 3, e.Bounds.Y + 3, 20, e.Bounds.Height - 6)
		e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 3, e.Bounds.Y + 3, 20, e.Bounds.Height - 6)

		' Draw the text in the item.
		e.Graphics.DrawString(itemString, sender.Font,
			Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 1)

		' Draw the focus rectangle around the selected item.
		e.DrawFocusRectangle()
		myBrush.Dispose()
	End Sub

	Private Sub r_rgb_CheckedChanged(sender As Object, e As EventArgs) Handles r_rgb.CheckedChanged, r_hsl.CheckedChanged, r_hsb.CheckedChanged
		p_rgb.Visible = r_rgb.Checked
		p_hsl.Visible = r_hsl.Checked
		p_hsb.Visible = r_hsb.Checked
		UpdateTrackers()
		UpdateColors()
		UpdateControls()
	End Sub

	Private Sub t_red_ValueChanged(sender As Object, e As EventArgs) Handles t_red.ValueChanged, t_blue.ValueChanged, t_green.ValueChanged, t_alpha.ValueChanged
		Dim clr As Color = Color.FromArgb(t_alpha.Value, t_red.Value, t_green.Value, t_blue.Value)
		MyPanel1.BackColor = clr
		RaiseEvent ColorChanged(Me, New EventArgs)
		UpdateTrackers(False)
		UpdateColors()
		UpdateControls()
	End Sub

	Private Sub t_hue1_ValueChanged(sender As Object, e As EventArgs) Handles t_hue1.ValueChanged, t_sat1.ValueChanged, t_lum.ValueChanged
		Dim clr As Color = Color.FromArgb(t_alpha.Value, ColorConversions.FromHSL(t_hue1.Value, t_sat1.Value / 100, t_lum.Value / 100))
		MyPanel1.BackColor = clr
		RaiseEvent ColorChanged(Me, New EventArgs)
		UpdateTrackers(, False)
		UpdateColors()
		UpdateControls()
	End Sub

	Private Sub t_hue2_ValueChanged(sender As Object, e As EventArgs) Handles t_hue2.ValueChanged, t_sat2.ValueChanged, t_bri.ValueChanged
		Dim clr As Color = Color.FromArgb(t_alpha.Value, ColorConversions.FromHSV(t_hue2.Value, t_sat2.Value / 100, t_bri.Value / 100))
		MyPanel1.BackColor = clr
		RaiseEvent ColorChanged(Me, New EventArgs)
		UpdateTrackers(,, False)
		UpdateColors()
		UpdateControls()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Try
			Dim p1 = "", p2 = "", p3 = "", p4 = ""
			If t_Hex.Text.Length = 6 Then
				p1 = "FF"
				p2 = t_Hex.Text.Substring(0, 2)
				p3 = t_Hex.Text.Substring(2, 2)
				p4 = t_Hex.Text.Substring(4, 2)
			ElseIf t_Hex.Text.Length = 8 Then
				p1 = t_Hex.Text.Substring(0, 2)
				p2 = t_Hex.Text.Substring(2, 2)
				p3 = t_Hex.Text.Substring(4, 2)
				p4 = t_Hex.Text.Substring(6, 2)
			End If
			t_alpha.Value = Integer.Parse(p1, Globalization.NumberStyles.AllowHexSpecifier)
			t_red.Value = Integer.Parse(p2, Globalization.NumberStyles.AllowHexSpecifier)
			t_green.Value = Integer.Parse(p3, Globalization.NumberStyles.AllowHexSpecifier)
			t_blue.Value = Integer.Parse(p4, Globalization.NumberStyles.AllowHexSpecifier)
		Catch ex As Exception

		End Try
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		If Not IsNothing(m_EditorService) Then m_EditorService.CloseDropDown()
		If Not IsNothing(m_button) Then m_button.CloseEditor()
	End Sub

	Private Sub MyPanel1_Paint(sender As Object, e As PaintEventArgs) Handles MyPanel1.Paint
		Dim g As Graphics = e.Graphics
		Dim br = New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
		g.FillRectangle(br, sender.ClientRectangle)
		g.FillRectangle(New SolidBrush(sender.BackColor), sender.ClientRectangle)
		br.Dispose()
	End Sub

End Class
#End Region 'ColorSelector Control Class
