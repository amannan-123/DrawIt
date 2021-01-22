Imports System.Drawing
Imports System.Windows.Forms

Public Class ColorListDialog

    Private _lst As New List(Of Color)
    Public Property Colors() As Color()
        Get
            Return _lst.ToArray
        End Get
        Set(ByVal value As Color())
            _lst.Clear()
            For Each clr As Color In value
                _lst.Add(clr)
            Next
            UpdateItems()
        End Set
    End Property

    Private Sub UpdateItems(Optional ByVal ind As Integer = 0)
        lstColors.Items.Clear()
        For Each clr As Color In _lst
            lstColors.Items.Add(clr.Name)
        Next
        If lstColors.Items.Count > ind Then
            lstColors.SelectedIndex = ind
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub bAdd_Click(sender As Object, e As EventArgs) Handles b_Add.Click
        _lst.Add(CE_Button.SelectedColor)
        UpdateItems(_lst.Count - 1)
    End Sub

    Private Sub bRemove_Click(sender As Object, e As EventArgs) Handles b_Remove.Click
        Dim ind As Integer = lstColors.SelectedIndex
        If ind > -1 AndAlso _lst.Count > 1 Then
            _lst.RemoveAt(ind)
            UpdateItems(ind)
        End If
    End Sub

    Private Sub bUp_Click(sender As Object, e As EventArgs) Handles b_Up.Click
        Dim ind As Integer = lstColors.SelectedIndex
        If ind > 0 Then
            Dim clr As Color = _lst(ind)
            _lst.RemoveAt(ind)
            _lst.Insert(ind - 1, clr)
            UpdateItems(ind - 1)
        End If
    End Sub

    Private Sub bDown_Click(sender As Object, e As EventArgs) Handles b_Down.Click
        Dim ind As Integer = lstColors.SelectedIndex
        If ind > -1 And ind < _lst.Count - 1 Then
            Dim clr As Color = _lst(ind)
            _lst.RemoveAt(ind)
            _lst.Insert(ind + 1, clr)
            UpdateItems(ind + 1)
        End If
    End Sub

    Private Sub CE_Button_ColorChanged(sender As Object, e As EventArgs) Handles CE_Button.ColorChanged
        Dim ind As Integer = lstColors.SelectedIndex
        If ind > -1 Then
            _lst(ind) = CE_Button.SelectedColor
            UpdateItems(ind)
        End If
    End Sub

    Private Sub lstColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstColors.SelectedIndexChanged
        Dim ind As Integer = lstColors.SelectedIndex
        If ind > -1 Then
            CE_Button.SelectedColor = _lst(ind)
        End If
    End Sub

    Private Sub lstColors_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstColors.DrawItem
        If e.Index < 0 Then Return
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
        Else
            e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
        End If

        ' Cast the sender object  to ComboBox type.
        Dim itemString As String = _lst(e.Index).Name
        Dim myBrush As New SolidBrush(_lst(e.Index))

        'Draw a Color Swatch
        Dim rect As New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 20, e.Bounds.Height - 5)
        e.Graphics.FillRectangle(myBrush, rect)
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Draw the text in the item.
        Dim rt As New Rectangle(rect.Right, rect.Y, e.Bounds.Width - rect.Width, rect.Height)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(itemString, sender.Font, New SolidBrush(sender.ForeColor), rt, sf)

        ' Draw the focus rectangle around the selected item.
        e.DrawFocusRectangle()
        myBrush.Dispose()
    End Sub

End Class
