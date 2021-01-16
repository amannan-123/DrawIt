Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class MyPanel

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        Dim br = New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
        g.FillRectangle(br, ClientRectangle)
        g.FillRectangle(New SolidBrush(BackColor), ClientRectangle)
    End Sub

End Class
