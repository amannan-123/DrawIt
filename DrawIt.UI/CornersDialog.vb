Imports DrawIt.Models

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
		Dim cornersData = TryCast(shp.MShape, MyRoundedRectangle)
		old_v = If(IsNothing(cornersData), New Single() {25.0F, 75.0F, 25.0F, 75.0F, 25.0F, 75.0F, 25.0F, 75.0F}, cornersData.Corners.ToArray)
		CEditor.Corners = old_v.Clone
	End Sub

	Public Sub RestoreOld()
		If IsNothing(shp) Then Return
		Dim cornersData = TryCast(shp.MShape, MyRoundedRectangle)
		If Not IsNothing(cornersData) Then cornersData.Corners = MyCorners.FromArray(old_v)
	End Sub

	Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
		DialogResult = System.Windows.Forms.DialogResult.OK
		Close()
	End Sub

	Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
		RestoreOld()
		If Not IsNothing(canvas) Then canvas.Invalidate()
		DialogResult = System.Windows.Forms.DialogResult.Cancel
		Close()
	End Sub

	Private Sub cbPreview_CheckedChanged(sender As Object, e As EventArgs) Handles cbPreview.CheckedChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			Dim cornersData = TryCast(shp.MShape, MyRoundedRectangle)
			If Not IsNothing(cornersData) Then cornersData.Corners = MyCorners.FromArray(CEditor.Corners)
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub

	Private Sub CEditor_CornersChanged(sender As Object, e As EventArgs) Handles CEditor.CornersChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			Dim cornersData = TryCast(shp.MShape, MyRoundedRectangle)
			If Not IsNothing(cornersData) Then cornersData.Corners = MyCorners.FromArray(CEditor.Corners)
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
