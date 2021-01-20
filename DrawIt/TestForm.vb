Imports System.Drawing.Drawing2D

Public Class TestForm

    Private Sub TestForm_Paint(sender As Object, e As PaintEventArgs)
        e.Graphics.TranslateTransform(100, 100)
        Dim myPath = New GraphicsPath()
        Dim srcRect = New RectangleF(0, 0, 100, 100)
        myPath.AddRectangle(srcRect)

        'Draw the source path (rectangle)to the screen.
        e.Graphics.DrawPath(Pens.Black, myPath)

        'Create a destination for the warped rectangle.
        Dim point1 = New PointF(20, 0)
        Dim point2 = New PointF(80, 0)
        Dim point3 = New PointF(0, 100)
        Dim point4 = New PointF(100, 100)
        Dim destPoints = {point1, point2, point3, point4}


        'Warp the source path (rectangle).
        myPath.Warp(destPoints, srcRect, Nothing, WarpMode.Perspective, 0.5)

        'Draw the warped path (rectangle) to the screen.
        e.Graphics.DrawPath(New Pen(Color.Red), myPath)

    End Sub

    Private Sub PointSelector1_ValueChanged(sender As Object, e As EventArgs) Handles PointSelector1.ValueChanged
        Text = PointSelector1.Value.ToString
    End Sub
End Class