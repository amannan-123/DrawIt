Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<DefaultEvent("ColorChanged")>
<DefaultProperty("SelectedColor")>
Public Class ColorEditorButton

    Private TSDropDown As New ToolStripDropDown
    Private _selector As New ColorSelector
    Private IsOpen As Boolean = False
    Private rect1, rect2, rect3 As RectangleF

    Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        _selector = New ColorSelector(Me)
        _selector.Width -= 1
        _selector.Button1.BorderColor = Color.White
        _selector.Button2.BorderColor = Color.White
        _selector.Button1.ForeColor = Color.White
        _selector.Button2.ForeColor = Color.White
        _selector.Button1.BackColor = Color.Black
        _selector.Button2.BackColor = Color.Black
        Dim _host As New ToolStripControlHost(_selector)
        _host.Margin = Padding.Empty
        _host.Padding = Padding.Empty
        _host.AutoSize = False
        _host.Size = New Size(_selector.Width, _selector.Height)
        TSDropDown.Items.Add(_host)
        TSDropDown.Size = _selector.Size
        TSDropDown.BackColor = Color.Black
        TSDropDown.ForeColor = Color.White
        AddHandler TSDropDown.KeyDown, AddressOf TSDropDown_KeyDown
        AddHandler TSDropDown.Closing, AddressOf TSDropDown_Closing
        AddHandler _selector.ColorChanged, AddressOf _selector_ColorChanged
        _selector.SelectedColor = BackColor
        SetRects()
    End Sub

    Private Sub TSDropDown_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            CloseEditor()
        End If
    End Sub

    Private Sub TSDropDown_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs)
        If e.CloseReason = ToolStripDropDownCloseReason.AppClicked Then
            e.Cancel = True
        Else
            IsOpen = False
        End If
        Invalidate()
    End Sub

    Private _text As String = "ChooseColor"
    Public Property MyText() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    <Editor(GetType(ColorTypeEditor), GetType(UITypeEditor))>
    Public Property SelectedColor() As Color
        Get
            Return _selector.SelectedColor
        End Get
        Set(ByVal value As Color)
            If SelectedColor <> value Then
                _selector.SelectedColor = value
            End If
        End Set
    End Property

    Public Event ColorChanged(sender As Object, e As EventArgs)

    Public Sub CloseEditor()
        IsOpen = False
        TSDropDown.Close()
        Invalidate()
    End Sub

    Private Sub _selector_ColorChanged(sender As Object, e As EventArgs)
        RaiseEvent ColorChanged(Me, New EventArgs)
        Invalidate()
    End Sub

    Private Sub SetRects()
        rect1 = New RectangleF(2, 2, Height - 5, Height - 5)
        rect2 = New RectangleF(Width - rect1.Height, rect1.Y, rect1.Height - 3, rect1.Height)
        rect3 = New RectangleF(rect1.Right + 2, rect1.Y, rect2.X - rect1.Right - 4, rect1.Height)
    End Sub

    Private Sub ColorEditorButton_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SetRects()
    End Sub

    Private Sub ColorEditorButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not DesignMode AndAlso Not IsNothing(ParentForm) Then
            AddHandler ParentForm.Move, AddressOf ParentForm_Resize
            AddHandler ParentForm.Resize, AddressOf ParentForm_Resize
            AddHandler ParentForm.FormClosed, AddressOf ParentForm_Close
        End If
    End Sub

    Private Sub ParentForm_Close(sender As Object, e As FormClosedEventArgs)
        CloseEditor()
    End Sub

    Private Sub ParentForm_Resize(sender As Object, e As EventArgs)
        CloseEditor()
    End Sub

    Private Sub ColorEditorButton_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If IsOpen Then
            TSDropDown.Close()
            IsOpen = False
        Else
            Dim VertPos = Height
            Dim HorzPos = CShort((Me.Width - Me._selector.Width) / 2)
            TSDropDown.Show(Me, New Point(HorzPos, VertPos))
            IsOpen = True
        End If
        Invalidate()
    End Sub

    Private Sub ColorEditorButton_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim br = New HatchBrush(HatchStyle.LargeCheckerBoard, Color.White, Color.Silver)
        g.FillRectangle(br, rect1)
        g.FillRectangle(New SolidBrush(SelectedColor), rect1)
        g.DrawRectangle(Pens.Black, Rectangle.Ceiling(rect1))

        Dim lgb2 As New LinearGradientBrush(rect2, Color.Black, Color.FromArgb(42, 79, 109), 0)
        lgb2.SetBlendTriangularShape(0.5, 1)
        g.FillRectangle(lgb2, rect2)
        g.DrawRectangle(Pens.Black, Rectangle.Ceiling(rect2))

        Dim vv As Integer = (rect2.Width / 2) - 2
        rect2.Inflate(-(vv - 1), -vv)
        Dim p1, p2, p3 As PointF
        If Not IsOpen Then
            p1 = New PointF(rect2.X, rect2.Y)
            p2 = New PointF(rect2.X + (rect2.Width / 2), rect2.Bottom)
            p3 = New PointF(rect2.Right, rect2.Y)
        Else
            p1 = New PointF(rect2.X, rect2.Bottom)
            p2 = New PointF(rect2.X + (rect2.Width / 2), rect2.Y)
            p3 = New PointF(rect2.Right, rect2.Bottom)
        End If
        g.DrawLines(Pens.White, New PointF() {p1, p2, p3})
        rect2.Inflate(vv - 1, vv)

        Dim cc1 As Color = Color.Black
        If IsOpen Then cc1 = Color.FromArgb(30, 30, 30)
        Dim lgb3 As New LinearGradientBrush(rect3, cc1, Color.FromArgb(42, 79, 109), 0)
        lgb3.SetBlendTriangularShape(0.5, 1)
        g.FillRectangle(lgb3, rect3)
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        g.DrawString(MyText, Font, New SolidBrush(Color.White), rect3, sf)
        g.DrawRectangle(Pens.Black, Rectangle.Ceiling(rect3))

        Dim brd_rect As Rectangle = ClientRectangle
        brd_rect.Width -= 1 : brd_rect.Height -= 1
        g.DrawRectangle(Pens.Black, brd_rect)

        If Focused Then
            Dim pn As New Pen(Color.Gray, 1)
            pn.DashStyle = DashStyle.Dash
            g.DrawRectangle(pn, brd_rect)
        End If

    End Sub

    Private Sub ColorEditorButton_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter, MyBase.Leave
        Invalidate()
    End Sub

    Private Sub ColorEditorButton_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            InvokeOnClick(Me, New EventArgs())
        End If
    End Sub

End Class
