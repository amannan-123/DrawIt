﻿Imports DrawIt.Controls
Imports DrawIt.Models

Public Class PointsEditor

	Private shp As Shape = Nothing
	Private canvas As Canvas = Nothing
	Private old_p As PointF()
	Private old_t As Single

	Sub New()
		InitializeComponent()
	End Sub

	Sub New(_shp As Shape, _canvas As Canvas)
		InitializeComponent()
		shp = _shp
		canvas = _canvas
		old_t = shp.MShape.Tension
		Select Case shp.MShape.SType
			Case ShapeStyle.Polygon
				old_p = shp.MShape.PolygonPoints
				PEditor.ShapeType = ShapePointsEditor.DrawType.Polygon
				TB_Tension.Enabled = False
			Case ShapeStyle.Lines
				old_p = shp.MShape.PolygonPoints
				PEditor.ShapeType = ShapePointsEditor.DrawType.Lines
				TB_Tension.Enabled = False
			Case ShapeStyle.Curves
				old_p = shp.MShape.CurvePoints
				PEditor.ShapeType = ShapePointsEditor.DrawType.Curves
			Case ShapeStyle.ClosedCurve
				old_p = shp.MShape.CurvePoints
				PEditor.ShapeType = ShapePointsEditor.DrawType.ClosedCurve
		End Select
		PEditor.Points = old_p
		PEditor.Tension = old_t
		TB_Tension.Value = old_t
	End Sub

	Public Sub RestoreOld()
		If IsNothing(shp) Then Return
		Select Case shp.MShape.SType
			Case ShapeStyle.Polygon, ShapeStyle.Lines
				shp.MShape.PolygonPoints = old_p
			Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
				shp.MShape.Tension = old_t
				shp.MShape.CurvePoints = old_p
		End Select
	End Sub

	Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
		DialogResult = System.Windows.Forms.DialogResult.OK
		Close()
	End Sub

	Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
		DialogResult = System.Windows.Forms.DialogResult.Cancel
		Close()
	End Sub

	Private Sub cbPreview_CheckedChanged(sender As Object, e As EventArgs) Handles cbPreview.CheckedChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			Select Case shp.MShape.SType
				Case ShapeStyle.Polygon, ShapeStyle.Lines
					shp.MShape.PolygonPoints = PEditor.Points
				Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
					shp.MShape.Tension = TB_Tension.Value
					shp.MShape.CurvePoints = PEditor.Points
			End Select
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub

	Private Sub PEditor_PointsChanged(sender As Object, e As EventArgs) Handles PEditor.PointsChanged
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			Select Case shp.MShape.SType
				Case ShapeStyle.Polygon, ShapeStyle.Lines
					shp.MShape.PolygonPoints = PEditor.Points
				Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
					shp.MShape.CurvePoints = PEditor.Points
			End Select
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub

	Private Sub TB_Tension_ValueChanged(sender As Object, e As EventArgs) Handles TB_Tension.ValueChanged
		PEditor.Tension = TB_Tension.Value
		If IsNothing(shp) Then Return
		If cbPreview.Checked Then
			Select Case shp.MShape.SType
				Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
					shp.MShape.Tension = TB_Tension.Value
			End Select
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
