Public Class CornersDialog

	Private shp As Shape = Nothing
	Private canvas As Canvas = Nothing
	Private old_v As Single()

	Sub New()
		InitializeComponent()
	End Sub

	Sub New(_shp As Shape, _canvas As Canvas)
		InitializeComponent()
		shp = _shp
		canvas = _canvas
		old_v = shp.MShape.Corners.ToArray
		CEditor.Corners = old_v.Clone
	End Sub

	Public Sub RestoreOld()
		If IsNothing(shp) Then Return
		shp.MShape.Corners = RRCorners.FromArray(old_v)
	End Sub

	Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Close()
	End Sub

	Private Sub cbPreview_CheckedChanged(sender As Object, e As EventArgs) Handles cbPreview.CheckedChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			shp.MShape.Corners = RRCorners.FromArray(CEditor.Corners)
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub

	Private Sub CEditor_CornersChanged(sender As Object, e As EventArgs) Handles CEditor.CornersChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			shp.MShape.Corners = RRCorners.FromArray(CEditor.Corners)
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
