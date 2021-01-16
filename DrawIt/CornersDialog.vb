Imports System.Windows.Forms

Public Class CornersDialog

    Private shp As Shape = Nothing
    Private canvas As Canvas = Nothing

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(_shp As Shape, _canvas As Canvas)
        InitializeComponent()
        For Each str As String In [Enum].GetNames(GetType(MyShape.CornerType))
            C_BL.Items.Add(str)
            C_BR.Items.Add(str)
            C_TL.Items.Add(str)
            C_TR.Items.Add(str)
        Next
        C_BL.SelectedIndex = 0
        C_BR.SelectedIndex = 0
        C_TL.SelectedIndex = 0
        C_TR.SelectedIndex = 0

        shp = _shp
        canvas = _canvas

        Dim _max = Math.Min(shp.BaseRect.Width, shp.BaseRect.Height)
        T_TL.Maximum = _max
        T_TR.Maximum = _max
        T_BL.Maximum = _max
        T_BR.Maximum = _max

        T_TL.Value = shp.MShape.ULSize
        T_TR.Value = shp.MShape.URSize
        T_BL.Value = shp.MShape.BLSize
        T_BR.Value = shp.MShape.BRSize
        C_TL.SelectedItem = shp.MShape.ULType.ToString
        C_TR.SelectedItem = shp.MShape.URType.ToString
        C_BL.SelectedItem = shp.MShape.BLType.ToString
        C_BR.SelectedItem = shp.MShape.BRType.ToString

        AddHandler T_TL.ValueChanged, AddressOf T_TL_ValueChanged
        AddHandler T_TR.ValueChanged, AddressOf T_TL_ValueChanged
        AddHandler T_BL.ValueChanged, AddressOf T_TL_ValueChanged
        AddHandler T_BR.ValueChanged, AddressOf T_TL_ValueChanged
        AddHandler C_TL.SelectedIndexChanged, AddressOf C_TL_SelectedIndexChanged
        AddHandler C_TR.SelectedIndexChanged, AddressOf C_TL_SelectedIndexChanged
        AddHandler C_BL.SelectedIndexChanged, AddressOf C_TL_SelectedIndexChanged
        AddHandler C_BR.SelectedIndexChanged, AddressOf C_TL_SelectedIndexChanged
    End Sub

    Private Sub T_TL_ValueChanged(sender As Object, e As EventArgs)
        If IsNothing(shp) Then Return
        shp.MShape.ULSize = T_TL.Value
        shp.MShape.URSize = T_TR.Value
        shp.MShape.BLSize = T_BL.Value
        shp.MShape.BRSize = T_BR.Value
        If Not IsNothing(canvas) Then canvas.Invalidate()
    End Sub

    Private Sub C_TL_SelectedIndexChanged(sender As Object, e As EventArgs)
        If IsNothing(shp) Then Return
        shp.MShape.ULType = [Enum].Parse(GetType(MyShape.CornerType), C_TL.SelectedItem)
        shp.MShape.URType = [Enum].Parse(GetType(MyShape.CornerType), C_TR.SelectedItem)
        shp.MShape.BLType = [Enum].Parse(GetType(MyShape.CornerType), C_BL.SelectedItem)
        shp.MShape.BRType = [Enum].Parse(GetType(MyShape.CornerType), C_BR.SelectedItem)
        If Not IsNothing(canvas) Then canvas.Invalidate()
    End Sub

End Class
