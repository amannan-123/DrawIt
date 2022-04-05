Imports System.Drawing.Drawing2D

Public Class TextEditor

	Sub New()
		InitializeComponent()
		InsertItems()
	End Sub

	Sub New(shp As Shape)
		InitializeComponent()
		InsertItems()
		Dim fnt As New Font(shp.MShape.FontName, shp.MShape.FontSize, shp.MShape.FontStyle)
		TBox.Font = fnt
		TBox.Text = shp.MShape.Text
		If fnt.Bold Then bBold.Checked = True
		If fnt.Italic Then bItalic.Checked = True
		If fnt.Underline Then bUnder.Checked = True
		If fnt.Strikeout Then bStrike.Checked = True
		TB_Size.Value = shp.MShape.FontSize
		cb_Font.SelectedItem = shp.MShape.FontName
		cb_Align.SelectedItem = shp.MShape.TextAlignment.ToString
	End Sub

	Private Sub InsertItems()
		Using installed_fonts As New Drawing.Text.InstalledFontCollection()
			For Each font_family As FontFamily In installed_fonts.Families
				cb_Font.Items.Add(font_family.Name)
			Next
		End Using
		cb_Font.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(ContentAlignment))
			cb_Align.Items.Add(str)
		Next
		cb_Align.SelectedItem = "MiddleCenter"
	End Sub

	Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub bOK_Click(sender As Object, e As EventArgs) Handles bOK.Click
		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub TB_Size_ValueChanged(sender As Object, e As EventArgs) Handles TB_Size.ValueChanged
		TBox.Font = New Font(TBox.Font.FontFamily, TB_Size.Value, TBox.Font.Style)
	End Sub

	Private Sub cb_Font_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Font.SelectedIndexChanged
		TBox.Font = New Font(New FontFamily(cb_Font.SelectedItem.ToString), TBox.Font.Size, TBox.Font.Style)
	End Sub

	Private Sub bStrike_CheckedChanged(sender As Object, e As EventArgs) Handles bStrike.CheckedChanged, bUnder.CheckedChanged, bItalic.CheckedChanged, bBold.CheckedChanged
		Dim fs As FontStyle = FontStyle.Regular
		If bBold.Checked Then fs = fs Or FontStyle.Bold
		If bItalic.Checked Then fs = fs Or FontStyle.Italic
		If bUnder.Checked Then fs = fs Or FontStyle.Underline
		If bStrike.Checked Then fs = fs Or FontStyle.Strikeout
		TBox.Font = New Font(TBox.Font.FontFamily, TBox.Font.Size, fs)
	End Sub

	Private Sub cb_Font_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cb_Font.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)

		Dim rect As Rectangle = e.Bounds
		Dim _x As Integer = 20
		Dim sf As New StringFormat With {
			.Trimming = StringTrimming.EllipsisCharacter,
			.Alignment = StringAlignment.Near,
			.LineAlignment = StringAlignment.Center
		}

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			_x = 1
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			rect.Inflate(0, -1)
			rect.Width -= 2
			_x = 1
			sf.Alignment = StringAlignment.Center
			Dim lgb As New LinearGradientBrush(rect, Color.AliceBlue, Color.LightSteelBlue,
				   LinearGradientMode.Vertical)
			lgb.SetBlendTriangularShape(0.5, 1)
			e.Graphics.FillRectangle(lgb, rect)
			e.Graphics.DrawRectangle(Pens.Blue, rect)
			lgb.Dispose()
		Else
			e.Graphics.FillRectangle(New SolidBrush(BackColor), rect)
			Dim rect2 = New Rectangle(e.Bounds.X, e.Bounds.Y, 20, e.Bounds.Height)
			e.Graphics.FillRectangle(New LinearGradientBrush(rect2, Color.AliceBlue, Color.LightSteelBlue,
					LinearGradientMode.Horizontal), rect2)
		End If

		Dim rt As Rectangle = New Rectangle(_x, e.Bounds.Y, e.Bounds.Width - _x, e.Bounds.Height - 1)

		Dim fnt As New Font(New FontFamily(itemString), TheBox.Font.Size, TheBox.Font.Style)
		e.Graphics.DrawString(itemString, fnt, New SolidBrush(TheBox.ForeColor), rt, sf)

		fnt.Dispose()

	End Sub

End Class
