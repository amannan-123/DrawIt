Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable>
Public Class Shape

#Region "Constructor"
    Sub New()

    End Sub

    Sub New(_loc As Point, _shp As MyShape.ShapeStyle, _br As MyBrush.BrushType)
        FBrush.BType = _br
        MShape.SType = _shp
        _rect.Location = _loc
        _rect.Size = New SizeF(10, 10)
    End Sub

#End Region

#Region "Globals"

    Private AnchorSize As New SizeF(7, 7)

#End Region

#Region "Properties"

    Private _rect As RectangleF = RectangleF.Empty
    Public Property BaseRect() As RectangleF
        Get
            Return _rect
        End Get
        Set(ByVal value As RectangleF)
            _rect = value
        End Set
    End Property

    Private _ang As Single = 0.0
    Public Property Angle() As Single
        Get
            Return _ang
        End Get
        Set(ByVal value As Single)
            _ang = value
        End Set
    End Property

    Private _cpt As New PointF
    Public Property CenterPoint() As PointF
        Get
            Return _cpt
        End Get
        Set(ByVal value As PointF)
            _cpt = value
        End Set
    End Property

    Private _sel As Boolean = True
    Public Property Selected() As Boolean
        Get
            Return _sel
        End Get
        Set(ByVal value As Boolean)
            _sel = value
        End Set
    End Property

    Private _mov As Boolean = True
    Public Property Moving() As Boolean
        Get
            Return _mov
        End Get
        Set(ByVal value As Boolean)
            _mov = value
        End Set
    End Property

    Private _pri As Boolean = True
    Public Property Primary() As Boolean
        Get
            Return _pri
        End Get
        Set(ByVal value As Boolean)
            _pri = value
        End Set
    End Property

    Private shear_x As Single = 0
    Public Property ShearX() As Single
        Get
            Return shear_x
        End Get
        Set(ByVal value As Single)
            shear_x = value
        End Set
    End Property

    Private shear_y As Single = 0
    Public Property ShearY() As Single
        Get
            Return shear_y
        End Get
        Set(ByVal value As Single)
            shear_y = value
        End Set
    End Property

    Private _brush As MyBrush = New MyBrush()
    Public Property FBrush() As MyBrush
        Get
            Return _brush
        End Get
        Set(ByVal value As MyBrush)
            _brush = value
        End Set
    End Property

    Private _pen As MyPen = New MyPen()
    Public Property DPen() As MyPen
        Get
            Return _pen
        End Get
        Set(ByVal value As MyPen)
            _pen = value
        End Set
    End Property

    Private _shape As MyShape = New MyShape()
    Public Property MShape() As MyShape
        Get
            Return _shape
        End Get
        Set(ByVal value As MyShape)
            _shape = value
        End Set
    End Property

    Private _glow As MyGlow = New MyGlow()
    Public Property Glow() As MyGlow
        Get
            Return _glow
        End Get
        Set(ByVal value As MyGlow)
            _glow = value
        End Set
    End Property

    Private _shadow As MyShadow = New MyShadow()
    Public Property Shadow() As MyShadow
        Get
            Return _shadow
        End Get
        Set(ByVal value As MyShadow)
            _shadow = value
        End Set
    End Property
#End Region

#Region "Private Subs"

    Private Sub AdjustRotation(ByRef gp As GraphicsPath)
        Dim mm As New Matrix
        mm.RotateAt(Angle, _cpt)
        gp.Transform(mm)
    End Sub

#End Region

#Region "Drawing Related Functions"
    Public Function BorderPath() As GraphicsPath
        Dim gp As GraphicsPath = TotalPath()
        If Not IsNothing(gp) Then
            gp.Widen(SelectionPen)
            Return gp
        End If
        Return Nothing
    End Function

    Public Function SelectionPen(Optional ByVal rotated As Boolean = True,
                                 Optional ByVal sheared As Boolean = True) As Pen
        Dim pn As New Pen(Color.Black)
        pn.Width = DPen.PWidth
        pn.StartCap = DPen.PStartCap
        pn.EndCap = DPen.PEndCap
        pn.DashCap = DPen.PDashCap
        pn.DashStyle = DPen.PDashstyle
        pn.LineJoin = DPen.PLineJoin
        pn.ScaleTransform(DPen.ScaleX, DPen.ScaleY)
        Dim mm As New Matrix
        mm.Translate(_rect.X, _rect.Y)
        mm.Shear(ShearX, ShearY)
        If sheared Then pn.MultiplyTransform(mm)
        Dim mm2 As New Matrix
        mm2.RotateAt(Angle, CenterPoint)
        If rotated Then pn.MultiplyTransform(mm2)
        Return pn
    End Function

    Public Function PenBrush() As Brush
        Select Case DPen.PBrush.BType
            Case MyBrush.BrushType.Solid
                Return New SolidBrush(DPen.PBrush.SolidColor)
            Case MyBrush.BrushType.LinearGradient
                Dim pth As GraphicsPath = TotalPath(False)
                If IsNothing(pth) Then Return Nothing
                pth.Widen(SelectionPen)
                Dim r2 As RectangleF = pth.GetBounds
                r2.Inflate(1, 1)
                If r2.Width < 1 Or r2.Height < 1 Then Return Nothing
                Dim lgb As New LinearGradientBrush(r2, DPen.PBrush.LColor1,
                                                    DPen.PBrush.LColor2,
                                                    DPen.PBrush.LinearAngle)
                lgb.GammaCorrection = DPen.PBrush.LGamma
                If DPen.PBrush.LTriangular Then
                    lgb.SetBlendTriangularShape(DPen.PBrush.LTriFocus, DPen.PBrush.LTriScale)
                End If
                If DPen.PBrush.LBell Then
                    lgb.SetSigmaBellShape(DPen.PBrush.LBellFocus, DPen.PBrush.LBellScale)
                End If
                If DPen.PBrush.LInterpolate Then
                    Dim ip As New ColorBlend
                    ip.Colors = DPen.PBrush.LInterColors
                    ip.Positions = DPen.PBrush.LInterPositions
                    lgb.InterpolationColors = ip
                End If
                If DPen.PBrush.LBlend Then
                    Dim bl As New Blend
                    bl.Factors = DPen.PBrush.LBlendFactors
                    bl.Positions = DPen.PBrush.LBlendPositions
                    lgb.Blend = bl
                End If
                Return lgb
            Case MyBrush.BrushType.PathGradient
                Return Nothing
            Case MyBrush.BrushType.Hatch
                Return New HatchBrush(DPen.PBrush.HStyle, DPen.PBrush.HFore, DPen.PBrush.HBack)
            Case MyBrush.BrushType.Texture
                Return Nothing
        End Select
        Return Nothing
    End Function

    Public Function CreatePen() As Pen
        Dim pn As Pen = SelectionPen(False)
        If IsNothing(pn) Then Return Nothing
        If IsNothing(PenBrush) Then Return Nothing
        pn.Brush = PenBrush()
        Return pn
    End Function

    Public Function CreateBrush() As Brush
        Dim rt As New RectangleF(0, 0, _rect.Width, _rect.Height)
        Select Case FBrush.BType
            Case MyBrush.BrushType.Solid
                Return New SolidBrush(FBrush.SolidColor)
            Case MyBrush.BrushType.LinearGradient
                Dim r2 As RectangleF = TotalPath(False).GetBounds
                r2.Inflate(1, 1)
                If r2.Width < 1 Or r2.Height < 1 Then Return Nothing
                Dim lgb As New LinearGradientBrush(r2, FBrush.LColor1,
                                                    FBrush.LColor2,
                                                    FBrush.LinearAngle)
                lgb.GammaCorrection = FBrush.LGamma
                If FBrush.LTriangular Then
                    lgb.SetBlendTriangularShape(FBrush.LTriFocus, FBrush.LTriScale)
                End If
                If FBrush.LBell Then
                    lgb.SetSigmaBellShape(FBrush.LBellFocus, FBrush.LBellScale)
                End If
                If FBrush.LInterpolate Then
                    Dim ip As New ColorBlend
                    ip.Colors = FBrush.LInterColors
                    ip.Positions = FBrush.LInterPositions
                    lgb.InterpolationColors = ip
                End If
                If FBrush.LBlend Then
                    Dim bl As New Blend
                    bl.Factors = FBrush.LBlendFactors
                    bl.Positions = FBrush.LBlendPositions
                    lgb.Blend = bl
                End If
                Return lgb
            Case MyBrush.BrushType.PathGradient
                Try
                    Dim ptb As New PathGradientBrush(TotalPath(False))
                    ptb.CenterColor = FBrush.PCenter
                    ptb.SurroundColors = FBrush.PSurround
                    ptb.FocusScales = New PointF(FBrush.PFocusX, FBrush.PFocusY)
                    ptb.CenterPoint = FromPercentage(_rect, FBrush.PCenterPoint)
                    If FBrush.PTriangular Then
                        ptb.SetBlendTriangularShape(FBrush.PTriFocus, FBrush.PTriScale)
                    End If
                    If FBrush.PBell Then
                        ptb.SetSigmaBellShape(FBrush.PBellFocus, FBrush.PBellScale)
                    End If
                    If FBrush.PInterpolate Then
                        Dim ip As New ColorBlend
                        ip.Colors = FBrush.PInterColors
                        ip.Positions = FBrush.PInterPositions
                        ptb.InterpolationColors = ip
                    End If
                    If FBrush.PBlend Then
                        Dim bl As New Blend
                        bl.Factors = FBrush.PBlendFactors
                        bl.Positions = FBrush.PBlendPositions
                        ptb.Blend = bl
                    End If
                    Return ptb
                Catch ex As Exception
                    Return Nothing
                End Try
            Case MyBrush.BrushType.Hatch
                Return New HatchBrush(FBrush.HStyle, FBrush.HFore, FBrush.HBack)
            Case MyBrush.BrushType.Texture
                If IsNothing(FBrush.TImage) Then Return Nothing
                If rt.Width < 1 Or rt.Height < 1 Then Return Nothing
                Try
                    Dim img As Image = FBrush.TImage.Clone
                    img.RotateFlip(FBrush.TRotateFlip)
                    Dim bmp As New Bitmap(img, rt.Width, rt.Height)
                    'Dim bmp As New Bitmap(CInt(rt.Width), CInt(rt.Height))
                    'Dim g As Graphics = Graphics.FromImage(bmp)
                    'g.CompositingMode = CompositingMode.SourceCopy
                    'g.CompositingQuality = CompositingQuality.HighQuality
                    'g.InterpolationMode = InterpolationMode.HighQualityBicubic
                    'g.SmoothingMode = SmoothingMode.HighQuality
                    'g.PixelOffsetMode = PixelOffsetMode.HighQuality
                    'Dim img As Image = FBrush.TImage.GetThumbnailImage(rt.Width, rt.Height, Nothing, IntPtr.Zero)
                    'img.RotateFlip(FBrush.TRotateFlip)
                    'g.DrawImage(img, rt)
                    img.Dispose()
                    If FBrush.TTransparency Then
                        bmp.MakeTransparent(FBrush.TColor)
                    End If
                    Dim txb As New TextureBrush(bmp)
                    Dim mm As New Matrix
                    mm.Translate(_rect.X, _rect.Y)
                    mm.Shear(ShearX, ShearY)
                    txb.Transform = mm
                    Return txb
                Catch ex As Exception
                    Return Nothing
                End Try
        End Select
        Return Nothing
    End Function

    Public Function SelectionPath(Optional ByVal _anc As Boolean = True) As Region
        Dim gp As GraphicsPath = TotalPath()
        If IsNothing(gp) Then Return Nothing
        'If MShape.IsClosed = False Then
        '    gp.Widen(SelectionPen)
        'End If
        If Not IsNothing(gp) Then
            Dim rg As New Region(gp)
            If Primary AndAlso _anc Then
                Dim _anchors As New List(Of GraphicsPath)
                _anchors.Add(TopLeft())
                _anchors.Add(Top())
                _anchors.Add(TopRight())
                _anchors.Add(Left())
                _anchors.Add(Right())
                _anchors.Add(BottomLeft())
                _anchors.Add(Bottom())
                _anchors.Add(BottomRight())
                _anchors.Add(Rotate())
                If FBrush.BType = MyBrush.BrushType.PathGradient Then _anchors.Add(Centering())
                For Each anc As GraphicsPath In _anchors
                    rg.Union(anc)
                Next
            End If
            Return rg
        End If
        Return Nothing
    End Function

    Public Function TotalPath(Optional ByVal rotated As Boolean = True,
                              Optional ByVal sheared As Boolean = True,
                              Optional ByVal translated As Boolean = True) As GraphicsPath
        Dim gp As New GraphicsPath()

        Try
            Dim rt As New RectangleF(0, 0, _rect.Width, _rect.Height)
            Select Case MShape.SType
                Case MyShape.ShapeStyle.Rectangle
                    gp.AddRectangle(rt)
                Case MyShape.ShapeStyle.RoundedRectangle
                    gp = GetRoundedRectPath(rt, MShape.ULSize, MShape.ULType,
                                        MShape.URSize, MShape.URType,
                                        MShape.BLSize, MShape.BLType,
                                        MShape.BRSize, MShape.BRType)
                Case MyShape.ShapeStyle.Ellipse
                    gp.AddEllipse(rt)
                Case MyShape.ShapeStyle.Triangle
                    Dim _lst As New List(Of PointF)
                    _lst.Add(FromPercentage(rt, New PointF(50, 0)))
                    _lst.Add(FromPercentage(rt, New PointF(0, 100)))
                    _lst.Add(FromPercentage(rt, New PointF(100, 100)))
                    gp.AddPolygon(_lst.ToArray)
                Case MyShape.ShapeStyle.Lines
                    If MShape.PolygonPoints.Length < 2 Then Return Nothing
                    Dim _lst As New List(Of PointF)
                    For Each pt As PointF In MShape.PolygonPoints
                        _lst.Add(FromPercentage(rt, pt))
                    Next
                    gp.AddLines(_lst.ToArray)
                Case MyShape.ShapeStyle.Polygon
                    If MShape.PolygonPoints.Length < 3 Then Return Nothing
                    Dim _lst As New List(Of PointF)
                    For Each pt As PointF In MShape.PolygonPoints
                        _lst.Add(FromPercentage(rt, pt))
                    Next
                    gp.AddPolygon(_lst.ToArray)
                Case MyShape.ShapeStyle.Curves
                    If MShape.CurvePoints.Length < 2 Then Return Nothing
                    Dim _lst As New List(Of PointF)
                    For Each pt As PointF In MShape.CurvePoints
                        _lst.Add(FromPercentage(rt, pt))
                    Next
                    gp.AddCurve(_lst.ToArray, MShape.Tension)
                Case MyShape.ShapeStyle.ClosedCurve
                    If MShape.CurvePoints.Length < 3 Then Return Nothing
                    Dim _lst As New List(Of PointF)
                    For Each pt As PointF In MShape.CurvePoints
                        _lst.Add(FromPercentage(rt, pt))
                    Next
                    gp.AddClosedCurve(_lst.ToArray, MShape.Tension)
                Case MyShape.ShapeStyle.Spiral
                    gp = SpiralPath(BaseRect, MShape.Spirals)
                Case MyShape.ShapeStyle.Arc
                    gp.AddArc(rt, MShape.StartAngle, MShape.SweepAngle)
                Case MyShape.ShapeStyle.Pie
                    gp.AddPie(New Rectangle(0, 0, rt.Width, rt.Height), MShape.StartAngle, MShape.SweepAngle)
                Case MyShape.ShapeStyle.Text
                    Dim stxt = MShape.Text.Trim()
                    If stxt.Length = 0 Then Return Nothing
                    Dim sf As New StringFormat(StringFormatFlags.NoClip)
                    sf.Trimming = StringTrimming.EllipsisCharacter
                    Select Case MShape.TextAlignment
                        Case ContentAlignment.TopLeft
                            sf.Alignment = StringAlignment.Near
                            sf.LineAlignment = StringAlignment.Near
                        Case ContentAlignment.TopCenter
                            sf.Alignment = StringAlignment.Center
                            sf.LineAlignment = StringAlignment.Near
                        Case ContentAlignment.TopRight
                            sf.Alignment = StringAlignment.Far
                            sf.LineAlignment = StringAlignment.Near
                        Case ContentAlignment.MiddleLeft
                            sf.Alignment = StringAlignment.Near
                            sf.LineAlignment = StringAlignment.Center
                        Case ContentAlignment.MiddleCenter
                            sf.Alignment = StringAlignment.Center
                            sf.LineAlignment = StringAlignment.Center
                        Case ContentAlignment.MiddleRight
                            sf.Alignment = StringAlignment.Far
                            sf.LineAlignment = StringAlignment.Center
                        Case ContentAlignment.BottomLeft
                            sf.Alignment = StringAlignment.Near
                            sf.LineAlignment = StringAlignment.Far
                        Case ContentAlignment.BottomCenter
                            sf.Alignment = StringAlignment.Center
                            sf.LineAlignment = StringAlignment.Far
                        Case ContentAlignment.BottomRight
                            sf.Alignment = StringAlignment.Far
                            sf.LineAlignment = StringAlignment.Far
                    End Select
                    Dim fl As New FontFamily(MShape.FontName)
                    gp.AddString(MShape.Text, fl, MShape.FontStyle,
                             MShape.FontSize * 1.34, rt, sf)
            End Select
            If MShape.IsClosed Then gp.CloseFigure()

            'flip
            'Dim flipXMatrix = New Matrix(-1, 0, 0, 1, BaseRect.Width, 0)
            'Dim flipYMatrix = New Matrix(1, 0, 0, -1, 0, BaseRect.Height)
            'Dim transformMatrix = New Matrix()
            'transformMatrix.Multiply(flipXMatrix)
            'transformMatrix.Multiply(flipYMatrix)
            'gp.Transform(transformMatrix)

            'warp
            'Dim points = New PointF() {
            '    New PointF(rt.X + (rt.Width / 4), rt.Y),
            '    New PointF(rt.Right - (rt.Width / 4), rt.Y),
            '    New PointF(rt.X, rt.Bottom),
            '    New PointF(rt.Right, rt.Bottom)}
            'gp.Warp(points, rt)

            Dim mm As New Matrix
            If translated Then mm.Translate(_rect.X, _rect.Y)
            If sheared Then mm.Shear(ShearX, ShearY)
            gp.Transform(mm)
            If rotated Then AdjustRotation(gp)
        Catch ex As Exception
            Return Nothing
        End Try
        Return gp
    End Function

    Public Function TopLeft(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X += (AnchorSize.Width / 2)
            rect.Y += (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Top(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.Y += (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function TopRight(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.Right, _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X -= (AnchorSize.Width / 2)
            rect.Y += (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Left(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Y + (_rect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X += (AnchorSize.Width / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Right(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.Right, _rect.Y + (_rect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X -= (AnchorSize.Width / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function BottomLeft(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X += (AnchorSize.Width / 2)
            rect.Y -= (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Bottom(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.Y -= (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function BottomRight(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.Right, _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
        If _rect.Width > 20 AndAlso _rect.Height > 20 Then
            rect.X -= (AnchorSize.Width / 2)
            rect.Y -= (AnchorSize.Height / 2)
        End If
        Dim gp As New GraphicsPath()
        gp.AddRectangle(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Rotate(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Y - 30, AnchorSize.Width, AnchorSize.Height)
        rect.Inflate(1, 1)
        Dim gp As New GraphicsPath()
        gp.AddEllipse(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

    Public Function Centering(Optional ByVal rotated As Boolean = True) As GraphicsPath
        Dim rect As New RectangleF(FromPercentage(BaseRect, FBrush.PCenterPoint), New SizeF(0, 0))
        rect.Inflate(3, 3)
        Dim pt As PointF = rect.Location
        Dim gp As New GraphicsPath()
        gp.AddEllipse(rect)
        If rotated Then AdjustRotation(gp)
        Return gp
    End Function

#End Region

#Region "Clone"
    Public Function Clone() As Shape
        Dim _new As New Shape
        For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(Shape))
            pd.SetValue(_new, pd.GetValue(Me))
        Next
        _new.MShape = MShape.Clone
        _new.FBrush = FBrush.Clone
        _new.DPen = DPen.Clone
        _new.Glow = Glow.Clone
        _new.Shadow = Shadow.Clone
        Return _new
    End Function
#End Region

End Class
