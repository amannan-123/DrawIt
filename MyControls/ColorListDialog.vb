Public Class ColorListDialog

	Public Sub LoadColors(_clr As Color())
		lstColors.Items.Clear()
		For Each clr As Color In _clr
			lstColors.Items.Add(clr)
		Next
	End Sub

	Public Function GetColors() As Color()
		Return lstColors.Items.ToArray
	End Function

	Private Sub UpdateItems(ind As Integer)
		If lstColors.Items.Count > ind Then
			lstColors.SelectedIndex = ind
		Else
			lstColors.SelectedIndex = lstColors.Items.Count - 1
		End If
	End Sub

	Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
		DialogResult = DialogResult.OK
		Close()
	End Sub

	Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub bAdd_Click(sender As Object, e As EventArgs) Handles b_Add.Click
		lstColors.Items.Add(CE_Button.SelectedColor)
		UpdateItems(lstColors.Items.Count - 1)
	End Sub

	Private Sub bRemove_Click(sender As Object, e As EventArgs) Handles b_Remove.Click
		Dim ind As Integer = lstColors.SelectedIndex
		If ind > -1 Then
			lstColors.Items.RemoveAt(ind)
			UpdateItems(ind)
		End If
	End Sub

	Private Sub bUp_Click(sender As Object, e As EventArgs) Handles b_Up.Click
		Dim ind As Integer = lstColors.SelectedIndex
		If ind > 0 Then
			Dim clr As Color = lstColors.Items(ind)
			lstColors.Items.RemoveAt(ind)
			lstColors.Items.Insert(ind - 1, clr)
			UpdateItems(ind - 1)
		End If
	End Sub

	Private Sub bDown_Click(sender As Object, e As EventArgs) Handles b_Down.Click
		Dim ind As Integer = lstColors.SelectedIndex
		If ind > -1 And ind < lstColors.Items.Count - 1 Then
			Dim clr As Color = lstColors.Items(ind)
			lstColors.Items.RemoveAt(ind)
			lstColors.Items.Insert(ind + 1, clr)
			UpdateItems(ind + 1)
		End If
	End Sub

	Private Sub CE_Button_ColorChanged(sender As Object, e As EventArgs) Handles CE_Button.ColorChanged
		Dim ind As Integer = lstColors.SelectedIndex
		If ind > -1 Then
			lstColors.Items(ind) = CE_Button.SelectedColor
			UpdateItems(ind)
		End If
	End Sub

	Private Sub lstColors_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lstColors.SelectedIndexChanged
		Dim ind As Integer = lstColors.SelectedIndex
		If ind > -1 Then
			CE_Button.SelectedColor = lstColors.Items(ind)
		End If
	End Sub

End Class
