Public Class CanvasControl

	Private mouseLoc As Point = Point.Empty

	Public Sub ResetZoom()
		baseCanvas.Zoom = 1
		SetSize(False)
		basePnl.Invalidate()
	End Sub

	Public Sub ApplyScrollChange(hscr As Integer, vscr As Integer)
		If hscr Then HScrollBar.Value -= hscr
		If vscr Then VScrollBar.Value -= vscr
	End Sub

	Public Sub SetSize(Optional scVals As Boolean = True)
		basePnl.Width = Math.Max(Width - 20, baseCanvas.Width * 2)
		basePnl.Height = Math.Max(Height - 20, baseCanvas.Height * 2)
		Dim centX = basePnl.Width / 2
		Dim centY = basePnl.Height / 2
		baseCanvas.Location = New Point(centX - (baseCanvas.Width / 2),
								centY - (baseCanvas.Height / 2))
		HScrollBar.Maximum = basePnl.Width - Width
		VScrollBar.Maximum = basePnl.Height - Height
		If scVals Then
			If mouseLoc = Point.Empty Then mouseLoc = New Point(centX, centY)
			Dim pX = ToPercentage(0, basePnl.Width, mouseLoc.X)
			Dim pY = ToPercentage(0, basePnl.Height, mouseLoc.Y)
			HScrollBar.Value = FromPercentage(HScrollBar.Minimum, HScrollBar.Maximum, pX)
			VScrollBar.Value = FromPercentage(VScrollBar.Minimum, VScrollBar.Maximum, pY)
		Else
			HScrollBar.Value = FromPercentage(HScrollBar.Minimum, HScrollBar.Maximum, 50)
			VScrollBar.Value = FromPercentage(VScrollBar.Minimum, VScrollBar.Maximum, 50)
		End If
	End Sub

	Private Sub basePnl_MouseWheel(sender As Object, e As MouseEventArgs) Handles basePnl.MouseWheel
		If Not My.Computer.Keyboard.CtrlKeyDown Then Return
		mouseLoc = e.Location
		If e.Delta < 0 Then
			baseCanvas.Zoom -= 0.5
		Else
			baseCanvas.Zoom += 0.5
		End If
		SetSize()
	End Sub

	Private Sub CanvasControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		SetSize()
	End Sub

	Private Sub CanvasControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		SetSize()
	End Sub

	Protected Overrides Function ScrollToControl(activeControl As Control) As Point
		Return DisplayRectangle.Location
	End Function

	Private Sub basePnl_Paint(sender As Object, e As PaintEventArgs) Handles basePnl.Paint
		Dim g As Graphics = e.Graphics
		Dim rect = New Rectangle(baseCanvas.Location, baseCanvas.Size)
		rect.Inflate(10, 10)
		g.DrawRectangle(Pens.RoyalBlue, rect)
	End Sub

	Private Sub VScrollBar_Scroll(sender As Object, e As EventArgs) Handles VScrollBar.Scroll
		basePnl.Top = -VScrollBar.Value
	End Sub

	Private Sub HScrollBar_Scroll(sender As Object, e As EventArgs) Handles HScrollBar.Scroll
		basePnl.Left = -HScrollBar.Value
	End Sub

	Private Sub basePnl_MouseMove(sender As Object, e As MouseEventArgs) Handles basePnl.MouseMove
		mouseLoc = e.Location
	End Sub

	Private Sub basePnl_LocationChanged(sender As Object, e As EventArgs) Handles basePnl.LocationChanged
		HScrollBar.Value = -basePnl.Left
		VScrollBar.Value = -basePnl.Top
	End Sub

	Private Sub basePnl_MouseLeave(sender As Object, e As EventArgs) Handles basePnl.MouseLeave
		mouseLoc = Point.Empty
	End Sub
End Class
