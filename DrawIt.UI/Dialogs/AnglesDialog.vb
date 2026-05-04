Imports DrawIt.Models

Public Class AnglesDialog

	Private shp As Shape = Nothing
	Private canvas As Canvas = Nothing

	Sub New()
		InitializeComponent()
	End Sub

	Sub New(_shp As Shape, _canvas As Canvas)
		InitializeComponent()

		shp = _shp
		canvas = _canvas

		Dim arcData = TryCast(shp.MShape, MyArc)
		If Not IsNothing(arcData) Then
			T_Start.Value = arcData.StartAngle
			T_Sweep.Value = arcData.SweepAngle
		Else
			Dim pieData = TryCast(shp.MShape, MyPie)
			If Not IsNothing(pieData) Then
				T_Start.Value = pieData.StartAngle
				T_Sweep.Value = pieData.SweepAngle
			End If
		End If
	End Sub

	Private Sub T_Start_ValueChanged(sender As Object, e As EventArgs) Handles T_Start.ValueChanged
		If IsNothing(shp) Then Return
		Dim arcData = TryCast(shp.MShape, MyArc)
		If Not IsNothing(arcData) Then
			arcData.StartAngle = T_Start.Value
		Else
			Dim pieData = TryCast(shp.MShape, MyPie)
			If Not IsNothing(pieData) Then pieData.StartAngle = T_Start.Value
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub

	Private Sub T_Sweep_ValueChanged(sender As Object, e As EventArgs) Handles T_Sweep.ValueChanged
		If IsNothing(shp) Then Return
		Dim arcData = TryCast(shp.MShape, MyArc)
		If Not IsNothing(arcData) Then
			arcData.SweepAngle = T_Sweep.Value
		Else
			Dim pieData = TryCast(shp.MShape, MyPie)
			If Not IsNothing(pieData) Then pieData.SweepAngle = T_Sweep.Value
		End If
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
