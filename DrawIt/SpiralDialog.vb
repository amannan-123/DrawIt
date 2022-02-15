Public Class SpiralDialog

	Private shp As Shape = Nothing
	Private canvas As Canvas = Nothing

	Sub New()
		InitializeComponent()
	End Sub

	Sub New(_shp As Shape, _canvas As Canvas)
		InitializeComponent()

		shp = _shp
		canvas = _canvas

		T_Spiral.Value = shp.MShape.Spirals
	End Sub

	Private Sub T_Spiral_ValueChanged(sender As Object, e As EventArgs) Handles T_Spiral.ValueChanged
		If IsNothing(shp) Then Return
		shp.MShape.Spirals = T_Spiral.Value
		If Not IsNothing(canvas) Then canvas.Invalidate()
	End Sub
End Class
