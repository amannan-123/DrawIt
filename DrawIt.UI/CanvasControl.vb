Imports System.ComponentModel

Public Class CanvasControl

    Private m_down As Boolean = False
    Private m_pt As Point

    Public Sub ResetZoom()
        baseCanvas.Zoom = 1
        basePnl.Invalidate()
    End Sub

    Private _pan As Boolean = False
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Panning() As Boolean
        Get
            Return _pan
        End Get
        Set(ByVal value As Boolean)
            If value <> _pan Then
                _pan = value
            End If
        End Set
    End Property

    Public Sub ApplyScrollChange(hscr As Integer, vscr As Integer)
        If hscr Then HScrollBar.Value -= hscr
        If vscr Then VScrollBar.Value -= vscr
    End Sub

    Public Sub SetSize()
        basePnl.SuspendLayout()

        basePnl.Width = Math.Max(Width - 20, baseCanvas.Width * 2)
        basePnl.Height = Math.Max(Height - 20, baseCanvas.Height * 2)
        Dim centX = basePnl.Width / 2
        Dim centY = basePnl.Height / 2
        baseCanvas.Location = New Point(centX - (baseCanvas.Width / 2),
                                        centY - (baseCanvas.Height / 2))
        HScrollBar.Maximum = basePnl.Width - Width
        VScrollBar.Maximum = basePnl.Height - Height

        HScrollBar.Value = FromPercentage(HScrollBar.Minimum, HScrollBar.Maximum, 50)
        VScrollBar.Value = FromPercentage(VScrollBar.Minimum, VScrollBar.Maximum, 50)

        basePnl.ResumeLayout()
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        If Not My.Computer.Keyboard.CtrlKeyDown Then Return
        If e.Delta < 0 Then
            baseCanvas.Zoom -= 0.5
        Else
            baseCanvas.Zoom += 0.5
        End If
        If baseCanvas.Zoom = 10 Then Return

        basePnl.SuspendLayout()

        basePnl.Width = Math.Max(Width - 20, baseCanvas.Width * 2)
        basePnl.Height = Math.Max(Height - 20, baseCanvas.Height * 2)
        Dim centX = basePnl.Width / 2
        Dim centY = basePnl.Height / 2
        baseCanvas.Location = New Point(centX - (baseCanvas.Width / 2),
                                centY - (baseCanvas.Height / 2))
        HScrollBar.Maximum = basePnl.Width - Width
        VScrollBar.Maximum = basePnl.Height - Height

        Dim mouseLoc = baseCanvas.PointToClient(MousePosition)

        Dim pX = ToPercentage(0, baseCanvas.Width, mouseLoc.X)
        Dim pY = ToPercentage(0, baseCanvas.Height, mouseLoc.Y)

        HScrollBar.Value = FromPercentage(0, HScrollBar.Maximum, pX)
        VScrollBar.Value = FromPercentage(0, VScrollBar.Maximum, pY)

        basePnl.ResumeLayout()
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

    Private Sub basePnl_LocationChanged(sender As Object, e As EventArgs) Handles basePnl.LocationChanged
        HScrollBar.Value = -basePnl.Left
        VScrollBar.Value = -basePnl.Top
    End Sub

#Region "Panning"
    Private Sub CanvasPan_MouseDown(sender As Object, e As MouseEventArgs) Handles basePnl.MouseDown, baseCanvas.MouseDown
        If Panning Then
            m_down = True
            m_pt = e.Location
        End If
    End Sub

    Private Sub CanvasPan_MouseMove(sender As Object, e As MouseEventArgs) Handles basePnl.MouseMove, baseCanvas.MouseMove
        If Panning Then
            If m_down Then
                ApplyScrollChange(e.X - m_pt.X, e.Y - m_pt.Y)
            End If
        End If
    End Sub

    Private Sub CanvasPan_MouseUp(sender As Object, e As MouseEventArgs) Handles basePnl.MouseUp, baseCanvas.MouseUp
        If Panning Then
            m_down = False
            basePnl.Invalidate()
        End If
    End Sub

    Private Sub CanvasControl_KeyDown(sender As Object, e As KeyEventArgs) Handles basePnl.KeyDown, baseCanvas.KeyDown
        Select Case e.KeyData
            Case Keys.Space
                Panning = True
                Cursor = Cursors.NoMove2D
                baseCanvas.Cursor = Cursors.NoMove2D
        End Select
    End Sub

    Private Sub CanvasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles basePnl.KeyUp, baseCanvas.KeyUp
        Select Case e.KeyData
            Case Keys.Space
                Panning = False
                Cursor = Cursors.Arrow
                baseCanvas.Cursor = Cursors.Arrow
                basePnl.Invalidate()
        End Select
    End Sub

    Private Sub basePnl_Click(sender As Object, e As EventArgs) Handles basePnl.Click
        basePnl.Focus()
    End Sub

#End Region

End Class
