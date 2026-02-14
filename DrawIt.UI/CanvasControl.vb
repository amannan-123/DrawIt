Imports System.ComponentModel
Imports DrawIt.Helpers

Public Class CanvasControl
	Private Const WheelZoomStep As Double = 1.1R

	Private m_down As Boolean = False
	Private m_pt As Point
	Private _syncScroll As Boolean = False

	<Browsable(False)>
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
	Public ReadOnly Property IsPanningNow() As Boolean
		Get
			Return m_down
		End Get
	End Property

	Public Sub ResetZoom()
		baseCanvas.Zoom = 1.0F
		SetPanOffset(PointF.Empty)
	End Sub

	Private _pan As Boolean = False
	<Browsable(False)>
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
	Public Property Panning() As Boolean
		Get
			Return _pan
		End Get
		Set(ByVal value As Boolean)
			_pan = value
		End Set
	End Property

	Private Sub SetPanMode(active As Boolean)
		Panning = active
		Dim cur = If(active, Cursors.Hand, Cursors.Arrow)
		Cursor = cur
		baseCanvas.Cursor = cur
	End Sub

	Private Sub StopPanDrag()
		If m_down Then
			m_down = False
			UpdateScrollbars()
		End If
	End Sub


	Private Sub GetPanLimits(ByRef minX As Single, ByRef maxX As Single,
						 ByRef minY As Single, ByRef maxY As Single)
		Dim bounds = baseCanvas.ViewportContentBounds()
		Dim zoom = baseCanvas.Zoom
		Dim centerOffset = baseCanvas.GetViewportCenterOffset()
		Dim margin As Single = Math.Max(Math.Max(Width, Height) * 2.0F, 2000.0F)
		ZoomPanMath.GetSymmetricPanLimits(bounds, zoom, centerOffset, baseCanvas.ClientSize, margin, minX, maxX, minY, maxY)
	End Sub

	Private Function ClampPan(target As PointF) As PointF
		Dim minX, maxX, minY, maxY As Single
		GetPanLimits(minX, maxX, minY, maxY)
		Dim x = Math.Max(minX, Math.Min(maxX, target.X))
		Dim y = Math.Max(minY, Math.Min(maxY, target.Y))
		Return New PointF(x, y)
	End Function

	Private Sub SetPanOffset(target As PointF, Optional syncBars As Boolean = True)
		Dim clamped = ClampPan(target)
		If Math.Abs(clamped.X - baseCanvas.PanOffset.X) < 0.001F AndAlso
		   Math.Abs(clamped.Y - baseCanvas.PanOffset.Y) < 0.001F Then
			Return
		End If
		baseCanvas.PanOffset = clamped
		If syncBars Then UpdateScrollbars()
	End Sub

	Private Sub ZoomAroundClientPoint(targetZoom As Single, anchorClient As Point)
		Dim oldZoom As Double = baseCanvas.Zoom
		If oldZoom <= 0 Then oldZoom = 1

		Dim clampedTargetZoom As Double = ZoomPanMath.ClampZoom(targetZoom)
		If Math.Abs(clampedTargetZoom - oldZoom) < 0.0000001R Then Return

		Dim centerBefore = baseCanvas.GetViewportCenterOffset()

		baseCanvas.Zoom = CSng(clampedTargetZoom)

		Dim centerAfter = baseCanvas.GetViewportCenterOffset()
		Dim newPan = ZoomPanMath.ComputePanForZoomAnchor(anchorClient, baseCanvas.PanOffset, centerBefore, oldZoom, centerAfter, clampedTargetZoom)
		SetPanOffset(newPan)
	End Sub

	Public Sub SetSize()
		basePnl.SuspendLayout()
		Dim viewRect As New Rectangle(0, 0, Math.Max(0, ClientSize.Width - VScrollBar.Width), Math.Max(0, ClientSize.Height - HScrollBar.Height))
		basePnl.Bounds = viewRect
		basePnl.ResumeLayout()
		SetPanOffset(baseCanvas.PanOffset)
		UpdateScrollbars()
	End Sub

	Private Sub UpdateScrollbars()
		If _syncScroll Then Return
		_syncScroll = True
		Try
			Dim viewW = Math.Max(1, baseCanvas.ClientSize.Width)
			Dim viewH = Math.Max(1, baseCanvas.ClientSize.Height)
			Dim minX, maxX, minY, maxY As Single
			GetPanLimits(minX, maxX, minY, maxY)

			HScrollBar.Minimum = CInt(Math.Floor(minX))
			HScrollBar.Maximum = CInt(Math.Ceiling(maxX))
			HScrollBar.LargeChange = Math.Max(1, viewW)
			HScrollBar.SmallChange = Math.Max(5, CInt(viewW / 20.0F))

			VScrollBar.Minimum = CInt(Math.Floor(minY))
			VScrollBar.Maximum = CInt(Math.Ceiling(maxY))
			VScrollBar.LargeChange = Math.Max(1, viewH)
			VScrollBar.SmallChange = Math.Max(5, CInt(viewH / 20.0F))

			Dim pan = baseCanvas.PanOffset
			HScrollBar.Value = Math.Max(HScrollBar.Minimum, Math.Min(HScrollBar.Maximum, CInt(pan.X)))
			VScrollBar.Value = Math.Max(VScrollBar.Minimum, Math.Min(VScrollBar.Maximum, CInt(pan.Y)))
		Finally
			_syncScroll = False
		End Try
	End Sub

	Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
		If Not My.Computer.Keyboard.CtrlKeyDown Then Return

		Dim anchor = baseCanvas.PointToClient(Control.MousePosition)
		If e.Delta = 0 Then Return

		Dim steps As Double = e.Delta / 120.0R
		Dim factor As Double = Math.Pow(WheelZoomStep, steps)
		Dim targetZoom As Single = CSng(baseCanvas.Zoom * factor)
		ZoomAroundClientPoint(targetZoom, anchor)
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

	Private Sub VScrollBar_Scroll(sender As Object, e As EventArgs) Handles VScrollBar.Scroll
		If _syncScroll Then Return
		SetPanOffset(New PointF(baseCanvas.PanOffset.X, VScrollBar.Value))
	End Sub

	Private Sub HScrollBar_Scroll(sender As Object, e As EventArgs) Handles HScrollBar.Scroll
		If _syncScroll Then Return
		SetPanOffset(New PointF(HScrollBar.Value, baseCanvas.PanOffset.Y))
	End Sub

	Private Sub CanvasPan_MouseDown(sender As Object, e As MouseEventArgs) Handles basePnl.MouseDown, baseCanvas.MouseDown
		If Panning AndAlso e.Button = MouseButtons.Left Then
			m_down = True
			m_pt = PointToClient(Control.MousePosition)
		End If
	End Sub

	Private Sub CanvasPan_MouseMove(sender As Object, e As MouseEventArgs) Handles basePnl.MouseMove, baseCanvas.MouseMove
		If m_down Then
			If Not Panning Then
				StopPanDrag()
				Return
			End If
			Dim nowPt = PointToClient(Control.MousePosition)
			Dim dx = nowPt.X - m_pt.X
			Dim dy = nowPt.Y - m_pt.Y
			SetPanOffset(New PointF(baseCanvas.PanOffset.X - dx, baseCanvas.PanOffset.Y - dy), False)
			m_pt = nowPt
		End If
	End Sub

	Private Sub CanvasPan_MouseUp(sender As Object, e As MouseEventArgs) Handles basePnl.MouseUp, baseCanvas.MouseUp
		StopPanDrag()
	End Sub

	Private Sub CanvasControl_KeyDown(sender As Object, e As KeyEventArgs) Handles basePnl.KeyDown, baseCanvas.KeyDown
		If e.KeyCode = Keys.Space Then
			SetPanMode(True)
		End If
	End Sub

	Private Sub CanvasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles basePnl.KeyUp, baseCanvas.KeyUp
		If e.KeyCode = Keys.Space Then
			SetPanMode(False)
			StopPanDrag()
		End If
	End Sub

	Private Sub CanvasControl_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave, basePnl.Leave, baseCanvas.Leave
		SetPanMode(False)
		StopPanDrag()
	End Sub

	Private Sub basePnl_Click(sender As Object, e As EventArgs) Handles basePnl.Click
		basePnl.Focus()
	End Sub

End Class

