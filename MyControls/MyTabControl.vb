Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms

Public Class MyTabControl
    Inherits TabControl

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Private _back As Color = Color.FromArgb(45, 47, 49)
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(GetType(Color), "45, 47, 49")>
    Public Overrides Property BackColor() As Color
        Get
            Return _back
        End Get
        Set(ByVal value As Color)
            _back = value
            Invalidate()
        End Set
    End Property

    Private _fore As Color = Color.White
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(GetType(Color), "White")>
    Public Overrides Property ForeColor() As Color
        Get
            Return _fore
        End Get
        Set(ByVal value As Color)
            _fore = value
            Invalidate()
        End Set
    End Property

    Private _sback As Color = Color.FromArgb(35, 168, 109)
    <DefaultValue(GetType(Color), "35, 168, 109")>
    Public Property SelectedTabColor() As Color
        Get
            Return _sback
        End Get
        Set(ByVal value As Color)
            _sback = value
            Invalidate()
        End Set
    End Property

    Private _nback As Color = Color.FromArgb(45, 47, 49)
    <DefaultValue(GetType(Color), "45, 47, 49")>
    Public Property NormalTabColor() As Color
        Get
            Return _nback
        End Get
        Set(ByVal value As Color)
            _nback = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Dim B = New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)

        G.SmoothingMode = SmoothingMode.HighQuality
        G.PixelOffsetMode = PixelOffsetMode.HighQuality
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        For i As Integer = 0 To TabCount - 1
            Dim BaseRect = GetTabRect(i)
            Select Case Alignment
                Case TabAlignment.Top
                    BaseRect.X += 2
                    BaseRect.Y += 2
                Case TabAlignment.Bottom
                    BaseRect.X += 2
                    BaseRect.Y -= 2
                Case TabAlignment.Left
                    BaseRect.X += 2
                    BaseRect.Y += 2
                    sf.FormatFlags = StringFormatFlags.DirectionVertical
                Case TabAlignment.Right
                    BaseRect.X -= 2
                    BaseRect.Y += 2
                    sf.FormatFlags = StringFormatFlags.DirectionVertical
            End Select

            Dim _clr As Color = NormalTabColor
            If i = SelectedIndex Then _clr = SelectedTabColor
            G.FillRectangle(New SolidBrush(_clr), BaseRect)
            G.DrawString(TabPages(i).Text, Font, New SolidBrush(ForeColor), BaseRect, sf)
        Next

        G.Dispose()
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
        MyBase.OnPaint(e)

    End Sub

End Class
