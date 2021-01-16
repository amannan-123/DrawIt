Imports System.Windows.Forms

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

        T_Start.Value = shp.MShape.StartAngle
        T_Sweep.Value = shp.MShape.SweepAngle
    End Sub

    Private Sub T_Start_ValueChanged(sender As Object, e As EventArgs) Handles T_Start.ValueChanged
        If IsNothing(shp) Then Return
        shp.MShape.StartAngle = T_Start.Value
        If Not IsNothing(canvas) Then canvas.Invalidate()
    End Sub

    Private Sub T_Sweep_ValueChanged(sender As Object, e As EventArgs) Handles T_Sweep.ValueChanged
        If IsNothing(shp) Then Return
        shp.MShape.SweepAngle = T_Sweep.Value
        If Not IsNothing(canvas) Then canvas.Invalidate()
    End Sub
End Class
