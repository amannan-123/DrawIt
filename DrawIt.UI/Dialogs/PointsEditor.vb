Imports DrawIt.Controls
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
		Dim curvesData = TryCast(shp.MShape, MyCurves)
		If IsNothing(curvesData) Then
			Dim closedCurveData = TryCast(shp.MShape, MyClosedCurve)
			old_t = If(IsNothing(closedCurveData), 0.5F, closedCurveData.Tension)
		Else
			old_t = curvesData.Tension
		End If
		Select Case shp.MShape.SType
			Case ShapeStyle.Polygon
				Dim polyData = TryCast(shp.MShape, MyPolygon)
				old_p = If(IsNothing(polyData), Array.Empty(Of PointF)(), polyData.PolygonPoints)
				PEditor.ShapeType = ShapePointsEditor.DrawType.Polygon
				TB_Tension.Enabled = False
			Case ShapeStyle.Lines
				Dim polyData = TryCast(shp.MShape, MyLines)
				old_p = If(IsNothing(polyData), Array.Empty(Of PointF)(), polyData.PolygonPoints)
				PEditor.ShapeType = ShapePointsEditor.DrawType.Lines
				TB_Tension.Enabled = False
			Case ShapeStyle.Curves
				Dim curveData = TryCast(shp.MShape, MyCurves)
				old_p = If(IsNothing(curveData), Array.Empty(Of PointF)(), curveData.CurvePoints)
				PEditor.ShapeType = ShapePointsEditor.DrawType.Curves
			Case ShapeStyle.ClosedCurve
				Dim curveData = TryCast(shp.MShape, MyClosedCurve)
				old_p = If(IsNothing(curveData), Array.Empty(Of PointF)(), curveData.CurvePoints)
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
				Dim linesData = TryCast(shp.MShape, MyLines)
				If Not IsNothing(linesData) Then
					linesData.PolygonPoints = old_p
				Else
					Dim polygonData = TryCast(shp.MShape, MyPolygon)
					If Not IsNothing(polygonData) Then polygonData.PolygonPoints = old_p
				End If
			Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
				Dim curvesData = TryCast(shp.MShape, MyCurves)
				If Not IsNothing(curvesData) Then
					curvesData.Tension = old_t
					curvesData.CurvePoints = old_p
				Else
					Dim closedCurveData = TryCast(shp.MShape, MyClosedCurve)
					If Not IsNothing(closedCurveData) Then
						closedCurveData.Tension = old_t
						closedCurveData.CurvePoints = old_p
					End If
				End If
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
					Dim linesData = TryCast(shp.MShape, MyLines)
					If Not IsNothing(linesData) Then
						linesData.PolygonPoints = PEditor.Points
					Else
						Dim polygonData = TryCast(shp.MShape, MyPolygon)
						If Not IsNothing(polygonData) Then polygonData.PolygonPoints = PEditor.Points
					End If
				Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
					Dim curvesData = TryCast(shp.MShape, MyCurves)
					If Not IsNothing(curvesData) Then
						curvesData.Tension = TB_Tension.Value
						curvesData.CurvePoints = PEditor.Points
					Else
						Dim closedCurveData = TryCast(shp.MShape, MyClosedCurve)
						If Not IsNothing(closedCurveData) Then
							closedCurveData.Tension = TB_Tension.Value
							closedCurveData.CurvePoints = PEditor.Points
						End If
					End If
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
					Dim linesData = TryCast(shp.MShape, MyLines)
					If Not IsNothing(linesData) Then
						linesData.PolygonPoints = PEditor.Points
					Else
						Dim polygonData = TryCast(shp.MShape, MyPolygon)
						If Not IsNothing(polygonData) Then polygonData.PolygonPoints = PEditor.Points
					End If
				Case ShapeStyle.Curves, ShapeStyle.ClosedCurve
					Dim curvesData = TryCast(shp.MShape, MyCurves)
					If Not IsNothing(curvesData) Then
						curvesData.CurvePoints = PEditor.Points
					Else
						Dim closedCurveData = TryCast(shp.MShape, MyClosedCurve)
						If Not IsNothing(closedCurveData) Then closedCurveData.CurvePoints = PEditor.Points
					End If
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
					Dim curvesData = TryCast(shp.MShape, MyCurves)
					If Not IsNothing(curvesData) Then
						curvesData.Tension = TB_Tension.Value
					Else
						Dim closedCurveData = TryCast(shp.MShape, MyClosedCurve)
						If Not IsNothing(closedCurveData) Then closedCurveData.Tension = TB_Tension.Value
					End If
			End Select
		Else
			RestoreOld()
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
