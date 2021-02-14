Public Class CanvasControl

	Private Sub SetSize()
		If baseCanvas.Docked Then
			baseCanvas.Dock = DockStyle.Fill
		Else
			If baseCanvas.Dock = DockStyle.Fill Then baseCanvas.Dock = DockStyle.None
			Dim center As New Point(Width / 2, Height / 2)
			Dim rect As Rectangle
			rect.Location = baseCanvas.Location
			rect.Size = baseCanvas.Size
			If rect.Width < Width Then
				rect.X = center.X - (rect.Width / 2)
			Else
				rect.X = 0
			End If
			If rect.Height < Height Then
				rect.Y = center.Y - (rect.Height / 2)
			Else
				rect.Y = 0
			End If
			baseCanvas.Bounds = rect
		End If
	End Sub

	Private Sub CanvasControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetSize()
	End Sub

	Private Sub baseCanvas_Resize(sender As Object, e As EventArgs) Handles baseCanvas.Resize
		SetSize()
	End Sub

	Private Sub CanvasControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetSize()
	End Sub

	Protected Overrides Function ScrollToControl(activeControl As Control) As Point
		Return DisplayRectangle.Location
	End Function
End Class
