Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Text.Json.Serialization
Imports DrawIt.Helpers
Imports DrawIt.Models

<Serializable>
Public Class Shape : Implements IDisposable

#Region "Constructor"
	Public Sub BindEvents()
		AddHandler FBrush.PropertyChanged, AddressOf BrushChanged
		AddHandler DPen.PropertyChanged, AddressOf PenChanged
		AddHandler DPen.PBrush.PropertyChanged, AddressOf PenChanged
		AddHandler MShape.PropertyChanged, AddressOf ShapeChanged
	End Sub

	Private Sub ShapeChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdatePath()
		UpdateImage()
		UpdateBrush()
		UpdatePenBrush()
	End Sub

	Private Sub PenChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdateSelectionPen()
		UpdatePenBrush()
	End Sub

	Private Sub BrushChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdateImage()
		UpdateBrush()
	End Sub

	Sub New()
		ReloadCachedObjects()
		Zoom = 1
	End Sub

	Sub New(_loc As PointF, _shp As ShapeStyle, _br As BrushType, Optional _zm As Single = 1)
		FBrush.BType = _br
		MShape.SType = _shp
		_baseX = _loc.X / _zm
		_baseY = _loc.Y / _zm
		_baseWidth = 10
		_baseHeight = 10
		_zoom = _zm
		BindEvents()
		ReloadCachedObjects()
	End Sub
#End Region

#Region "Globals"
	Private AnchorSize As New SizeF(7, 7)
#End Region

#Region "Properties"

#Region "Base Rect"

	Private _baseX As Single = 0
	Public Property BaseX() As Single
		Get
			Return _baseX
		End Get
		Set(ByVal value As Single)
			_baseX = value
			FinalizeCoordsChange()
		End Set
	End Property

	Private _baseY As Single = 0
	Public Property BaseY() As Single
		Get
			Return _baseY
		End Get
		Set(ByVal value As Single)
			_baseY = value
			FinalizeCoordsChange()
		End Set
	End Property

	Private _baseWidth As Single = 10
	Public Property BaseWidth() As Single
		Get
			Return _baseWidth
		End Get
		Set(ByVal value As Single)
			_baseWidth = value
			FinalizeCoordsChange()
		End Set
	End Property

	Private _baseHeight As Single = 10
	Public Property BaseHeight() As Single
		Get
			Return _baseHeight
		End Get
		Set(ByVal value As Single)
			_baseHeight = value
			FinalizeCoordsChange()
		End Set
	End Property

	Public Sub FinalizeCoordsChange()
		UpdatePath()
		'resize image only if shape is being resized.
		If Not Moving Then UpdateImage()
		If Not FBrush.BType = BrushType.Solid AndAlso Not FBrush.BType = BrushType.Hatch Then
			UpdateBrush()
		End If
		If DPen.PBrush.BType = BrushType.LinearGradient Then
			UpdatePenBrush()
		End If
	End Sub

	Public Function GetRect() As RectangleF
		If Zoom <= 0 Then Zoom = 1
		Return New RectangleF(
				_baseX * Zoom,
				_baseY * Zoom,
				_baseWidth * Zoom,
				_baseHeight * Zoom)
	End Function

	Public Sub SetAllRect(rect As RectangleF)
		_baseX = rect.X / Zoom
		_baseY = rect.Y / Zoom
		_baseWidth = rect.Width / Zoom
		_baseHeight = rect.Height / Zoom
		FinalizeCoordsChange()
	End Sub

#End Region

	Private _zoom As Single = 1.0F
	<JsonIgnore>
	Public Property Zoom() As Single
		Get
			Return _zoom
		End Get
		Set(ByVal value As Single)
			_zoom = value
			FinalizeCoordsChange()
			Dim rc = GetRect()
			RotationPoint = New PointF(rc.X + rc.Width / 2, rc.Y + rc.Height / 2)
		End Set
	End Property

	Private _ang As Single = 0.0
	Public Property Angle() As Single
		Get
			Return _ang
		End Get
		Set(value As Single)
			_ang = value
		End Set
	End Property

	Private _rpt As New PointF
	Public Property RotationPoint() As PointF
		Get
			Return _rpt
		End Get
		Set(value As PointF)
			_rpt = value
		End Set
	End Property

	Private _sel As Boolean = False
	Public Property Selected() As Boolean
		Get
			Return _sel
		End Get
		Set(value As Boolean)
			_sel = value
		End Set
	End Property

	Private _mov As Boolean = False
	Public Property Moving() As Boolean
		Get
			Return _mov
		End Get
		Set(value As Boolean)
			_mov = value
		End Set
	End Property

	Private _pri As Boolean = True
	Public Property Primary() As Boolean
		Get
			Return _pri
		End Get
		Set(value As Boolean)
			_pri = value
		End Set
	End Property

	Private shear_x As Single = 0
	Public Property ShearX() As Single
		Get
			Return shear_x
		End Get
		Set(value As Single)
			shear_x = value
			UpdatePath()
			UpdateBrush()
			UpdateSelectionPen()
			UpdatePenBrush()
		End Set
	End Property

	Private shear_y As Single = 0
	Public Property ShearY() As Single
		Get
			Return shear_y
		End Get
		Set(value As Single)
			shear_y = value
			UpdatePath()
			UpdateBrush()
			UpdateSelectionPen()
			UpdatePenBrush()
		End Set
	End Property

	Private _flipX As Boolean = False
	Public Property FlipX() As Boolean
		Get
			Return _flipX
		End Get
		Set(ByVal value As Boolean)
			If _flipX = value Then Return
			_flipX = value
			Dim cent_pt = FBrush.PCenterPoint
			cent_pt.X = 100 - cent_pt.X
			FBrush.PCenterPoint = cent_pt
		End Set
	End Property

	Private _flipY As Boolean = False
	Public Property FlipY() As Boolean
		Get
			Return _flipY
		End Get
		Set(ByVal value As Boolean)
			If _flipY = value Then Return
			_flipY = value
			Dim cent_pt = FBrush.PCenterPoint
			cent_pt.Y = 100 - cent_pt.Y
			FBrush.PCenterPoint = cent_pt
		End Set
	End Property

	Private _brush As New MyBrush()
	Public Property FBrush() As MyBrush
		Get
			Return _brush
		End Get
		Set(value As MyBrush)
			_brush = value
		End Set
	End Property

	Private _pen As New MyPen()
	Public Property DPen() As MyPen
		Get
			Return _pen
		End Get
		Set(value As MyPen)
			_pen = value
		End Set
	End Property

	Private _shape As New MyShape()
	Public Property MShape() As MyShape
		Get
			Return _shape
		End Get
		Set(value As MyShape)
			_shape = value
		End Set
	End Property

	Private _glow As New MyGlow()
	Public Property Glow() As MyGlow
		Get
			Return _glow
		End Get
		Set(value As MyGlow)
			_glow = value
		End Set
	End Property

	Private _shadow As New MyShadow()
	Public Property Shadow() As MyShadow
		Get
			Return _shadow
		End Get
		Set(value As MyShadow)
			_shadow = value
		End Set
	End Property
#End Region

#Region "Drawing Related Functions"

	Public Sub ReloadCachedObjects()
		UpdatePath()
		UpdateImage()
		UpdateBrush()
		UpdateSelectionPen()
		UpdatePenBrush()
	End Sub

	''' <summary>
	''' Returns a region containing path and border.
	''' </summary>
	Public Function Region() As Region
		Dim rg As New Region(Rectangle.Empty)
		Dim brd_pth = BorderPath()
		If Not IsNothing(brd_pth) Then rg.Union(brd_pth)
		Dim sel_pth = TotalPath()
		If Not IsNothing(sel_pth) Then rg.Union(sel_pth)
		Return rg
	End Function

	''' <summary>
	''' Returns <see cref="TotalPath(Boolean, Boolean, Boolean)"/> widen with <see cref="SelectionPen(Boolean, Boolean)"/>.
	''' </summary>
	Public Function BorderPath() As GraphicsPath
		Dim gp As GraphicsPath = TotalPath()
		If Not IsNothing(gp) AndAlso Not IsNothing(SelectionPen) Then
			gp.Widen(SelectionPen)
			Return gp
		End If
		Return Nothing
	End Function

	''' <summary>
	''' Returns <see cref="Pen"/> for drawing border.
	''' </summary>
	''' <returns></returns>
	Public Function CreatePen() As Pen
		Dim pn As Pen = SelectionPen(False)
		If IsNothing(pn) Then Return Nothing
		If pn.Width = 0 Then Return Nothing
		If IsNothing(PenBrush) Then Return Nothing
		pn.Brush = PenBrush()
		Return pn
	End Function

	<NonSerialized>
	Private _pn As Pen = Nothing
	''' <summary>
	''' Returns <see cref="Pen"/> based on <see cref="DPen"/> of current instance.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property SelectionPen(Optional rotated As Boolean = True) As Pen
		Get
			If IsNothing(_pn) Then Return Nothing
			Dim pn = _pn.Clone

			Dim mm As New Matrix
			mm.Translate(GetRect.X, GetRect.Y)
			mm.Shear(ShearX, ShearY)
			pn.MultiplyTransform(mm)

			If rotated Then
				mm.Reset()
				mm.RotateAt(Angle, RotationPoint)
				pn.MultiplyTransform(mm)
			End If
			Return pn
		End Get
	End Property

	''' <summary>
	''' Updates <see cref="SelectionPen(Boolean)"/>.
	''' </summary>
	Public Sub UpdateSelectionPen()
		Dim pn As New Pen(Color.Black) With {
			.Width = DPen.PWidth,
			.StartCap = DPen.PStartCap,
			.EndCap = DPen.PEndCap,
			.DashCap = DPen.PDashCap,
			.DashStyle = DPen.PDashstyle,
			.LineJoin = DPen.PLineJoin
		}
		pn.ScaleTransform(DPen.ScaleX, DPen.ScaleY)
		_pn = pn
	End Sub

	<NonSerialized>
	Private _pb As Brush = Nothing
	''' <summary>
	''' Returns <see cref="Brush"/> for drawing border.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property PenBrush() As Brush
		Get
			Return _pb
		End Get
	End Property

	''' <summary>
	''' Updates <see cref="PenBrush"/>.
	''' </summary>
	Public Sub UpdatePenBrush()
		Select Case DPen.PBrush.BType
			Case BrushType.Solid
				_pb = New SolidBrush(DPen.PBrush.SolidColor)
			Case BrushType.LinearGradient
				Dim pth As GraphicsPath = TotalPath(False)
				If IsNothing(pth) Then
					_pb = Nothing
					Return
				End If
				pth.Widen(SelectionPen)
				Dim r2 As RectangleF = pth.GetBounds
				r2.Inflate(1, 1)
				Dim lgb As New LinearGradientBrush(r2, DPen.PBrush.LColor1,
													DPen.PBrush.LColor2,
													DPen.PBrush.LinearAngle) With {
					.GammaCorrection = DPen.PBrush.LGamma
													}
				If DPen.PBrush.LTriangular Then
					lgb.SetBlendTriangularShape(DPen.PBrush.LTriFocus, DPen.PBrush.LTriScale)
				End If
				If DPen.PBrush.LBell Then
					lgb.SetSigmaBellShape(DPen.PBrush.LBellFocus, DPen.PBrush.LBellScale)
				End If
				If DPen.PBrush.LInterpolate Then
					Dim ip As New ColorBlend
					If DPen.PBrush.LInterColors.Length = DPen.PBrush.LInterPositions.Length Then
						ip.Colors = DPen.PBrush.LInterColors
						ip.Positions = DPen.PBrush.LInterPositions
						lgb.InterpolationColors = ip
					Else
						_pb = Nothing
					End If
				End If
				_pb = lgb
			Case BrushType.PathGradient
				_pb = Nothing
			Case BrushType.Hatch
				_pb = New HatchBrush(DPen.PBrush.HStyle, DPen.PBrush.HFore, DPen.PBrush.HBack)
			Case BrushType.Texture
				_pb = Nothing
		End Select
	End Sub

	<NonSerialized>
	Private _cb As Brush = Nothing
	''' <summary>
	''' Returns <see cref="Brush"/>  based on <see cref="FBrush"/> of current instance.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property FillBrush() As Brush
		Get
			Return _cb
		End Get
	End Property

	<NonSerialized>
	Private _img As Image = Nothing
	''' <summary>
	''' Returns <see cref="Image"/> from <see cref="FBrush"/> resized according to GraphicsPath of current instance.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property FittedImage() As Image
		Get
			Return _img
		End Get
	End Property

	Public Sub UpdateImage()
		If IsNothing(FBrush.TImage) Or Not FBrush.BType = BrushType.Texture Then
			_img = Nothing
			Return
		End If
		Dim rt As New RectangleF(0, 0, Math.Abs(GetRect.Width), Math.Abs(GetRect.Height))
		If rt.Width < 1 Or rt.Height < 1 Then
			_img = Nothing
			Return
		End If
		Dim img As Image = FBrush.TImage
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
		'img.Dispose()
		If FBrush.TTransparency Then bmp.MakeTransparent(FBrush.TColor)
		_img = bmp
	End Sub

	''' <summary>
	''' Updates <see cref="FillBrush"/>.
	''' </summary>
	Public Sub UpdateBrush()
		'Static cnt As Integer = 0
		'cnt += 1
		'Debug.WriteLine(cnt & "UpdateBrush")

		Select Case FBrush.BType
			Case BrushType.Solid
				_cb = New SolidBrush(FBrush.SolidColor)
			Case BrushType.LinearGradient
				If IsNothing(TotalPath(False)) Then
					_cb = Nothing
					Return
				End If
				Dim r2 As RectangleF = TotalPath(False).GetBounds
				r2.Inflate(1, 1)
				If r2.Width < 1 Or r2.Height < 1 Then
					_cb = Nothing
					Return
				End If
				Dim lgb As New LinearGradientBrush(r2, FBrush.LColor1,
														FBrush.LColor2,
														FBrush.LinearAngle) With
														{.GammaCorrection = FBrush.LGamma}
				If FBrush.LTriangular Then
					lgb.SetBlendTriangularShape(FBrush.LTriFocus, FBrush.LTriScale)
				ElseIf FBrush.LBell Then
					lgb.SetSigmaBellShape(FBrush.LBellFocus, FBrush.LBellScale)
				End If
				If FBrush.LInterpolate Then
					Dim ip As New ColorBlend With {
						.Colors = FBrush.LInterColors,
						.Positions = FBrush.LInterPositions
					}
					If ip.Colors.Length = ip.Positions.Length Then lgb.InterpolationColors = ip
				ElseIf FBrush.LBlend Then
					Dim bl As New Blend With {
						.Factors = FBrush.LBlendFactors,
						.Positions = FBrush.LBlendPositions
					}
					If bl.Factors.Length = bl.Positions.Length Then lgb.Blend = bl
				End If
				_cb = lgb
			Case BrushType.PathGradient
				Dim t_path = TotalPath(False)
				If IsNothing(t_path) Or AbsRect(GetRect).Width = 0 Or AbsRect(GetRect).Height = 0 Then
					_cb = Nothing
					Return
				End If
				Dim ptb As New PathGradientBrush(TotalPath(False)) With {
						.CenterColor = FBrush.PCenter,
						.FocusScales = New PointF(FBrush.PFocusX, FBrush.PFocusY),
						.CenterPoint = MathUtils.FromPercentage(AbsRect(GetRect), FBrush.PCenterPoint)
					}
				If FBrush.PSurround.Length <= t_path.PointCount Then
					ptb.SurroundColors = FBrush.PSurround
				End If
				If FBrush.PTriangular Then
					ptb.SetBlendTriangularShape(FBrush.PTriFocus, FBrush.PTriScale)
				ElseIf FBrush.PBell Then
					ptb.SetSigmaBellShape(FBrush.PBellFocus, FBrush.PBellScale)
				End If
				If FBrush.PInterpolate Then
					Dim ip As New ColorBlend With {
						.Colors = FBrush.PInterColors,
						.Positions = FBrush.PInterPositions
					}
					If ip.Colors.Length = ip.Positions.Length Then ptb.InterpolationColors = ip
				ElseIf FBrush.PBlend Then
					Dim bl As New Blend With {
						.Factors = FBrush.PBlendFactors,
						.Positions = FBrush.PBlendPositions
					}
					If bl.Factors.Length = bl.Positions.Length Then ptb.Blend = bl
				End If
				_cb = ptb
			Case BrushType.Hatch
				_cb = New HatchBrush(FBrush.HStyle, FBrush.HFore, FBrush.HBack)
			Case BrushType.Texture
				If IsNothing(FittedImage) Then
					_cb = Nothing
					Return
				End If
				Dim txb As New TextureBrush(FittedImage)
				Dim mm As New Matrix
				mm.Translate(GetRect.X, GetRect.Y)
				mm.Shear(ShearX, ShearY)
				txb.Transform = mm
				_cb = txb
		End Select
	End Sub

	''' <summary>
	''' Returns a region containing anchors only.
	''' </summary>
	''' <returns></returns>
	Public Function AnchorsPath() As Region
		Dim rg As New Region(RectangleF.Empty)
		Dim _anchors As New List(Of GraphicsPath) From {
			TopLeft(),
			Top(),
			TopRight(),
			Left(),
			Right(),
			BottomLeft(),
			Bottom(),
			BottomRight(),
			Rotate()
		}
		If FBrush.BType = BrushType.PathGradient Then _anchors.Add(Centering())
		For Each anc As GraphicsPath In _anchors
			rg.Union(anc)
		Next
		Return rg
	End Function

	<NonSerialized>
	Private _pth As GraphicsPath = Nothing
	''' <summary>
	''' Returns <see cref="GraphicsPath"/> based on <see cref="MShape"/> of current instance.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property TotalPath(Optional rotated As Boolean = True) As GraphicsPath
		Get
			If IsNothing(_pth) Then Return Nothing
			Dim gp As GraphicsPath = _pth.Clone
			Dim mm As New Matrix
			mm.Translate(GetRect.X, GetRect.Y)
			mm.Shear(ShearX, ShearY)
			gp.Transform(mm)
			If rotated Then AdjustRotation(gp)
			Return gp
		End Get
	End Property

	''' <summary>
	''' Updates <see cref="TotalPath(Boolean)"/>.
	''' </summary>
	Public Sub UpdatePath()

		If GetRect.Width = 0 Or GetRect.Height = 0 Then
			_pth = Nothing
			Return
		End If

		Dim gp As New GraphicsPath()

		Dim rt As New RectangleF(0, 0, Math.Abs(GetRect.Width), Math.Abs(GetRect.Height))
		Select Case MShape.SType
			Case ShapeStyle.Rectangle
				gp.AddRectangle(rt)
			Case ShapeStyle.RoundedRectangle
				gp = GetRoundedRectPath(rt, MShape.Corners)
			Case ShapeStyle.Ellipse
				gp.AddEllipse(rt)
			Case ShapeStyle.Triangle
				Dim _lst As New List(Of PointF) From {
					MathUtils.FromPercentage(rt, New PointF(50, 0)),
					MathUtils.FromPercentage(rt, New PointF(0, 100)),
					MathUtils.FromPercentage(rt, New PointF(100, 100))
				}
				gp.AddPolygon(_lst.ToArray)
			Case ShapeStyle.Lines
				If MShape.PolygonPoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.PolygonPoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddLines(_lst.ToArray)
			Case ShapeStyle.Polygon
				If MShape.PolygonPoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.PolygonPoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddPolygon(_lst.ToArray)
			Case ShapeStyle.Curves
				If MShape.CurvePoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.CurvePoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddCurve(_lst.ToArray, MShape.Tension)
			Case ShapeStyle.ClosedCurve
				If MShape.CurvePoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.CurvePoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddClosedCurve(_lst.ToArray, MShape.Tension)
			'Case ShapeStyle.Spiral
			'	gp = SpiralPath(GetRect, MShape.Spirals)
			Case ShapeStyle.Arc
				gp.AddArc(rt, MShape.StartAngle, MShape.SweepAngle)
			Case ShapeStyle.Pie
				gp.AddPie(0, 0, rt.Width, rt.Height, MShape.StartAngle, MShape.SweepAngle)
			Case ShapeStyle.Text
				Dim stxt = MShape.Text.Trim()
				If stxt.Length = 0 Then
					_pth = Nothing
					Return
				End If
				'sf.FormatFlags = StringFormatFlags.NoWrap
				Dim sf As New StringFormat With {
					.Trimming = StringTrimming.EllipsisCharacter
				}
				Select Case MShape.TextAlignment
					Case ContentAlignment.TopLeft
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Near
					Case ContentAlignment.TopCenter
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Center
					Case ContentAlignment.TopRight
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Far
					Case ContentAlignment.MiddleLeft
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Near
					Case ContentAlignment.MiddleCenter
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Center
					Case ContentAlignment.MiddleRight
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Far
					Case ContentAlignment.BottomLeft
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Near
					Case ContentAlignment.BottomCenter
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Center
					Case ContentAlignment.BottomRight
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Far
				End Select
				Dim fl As New FontFamily(MShape.FontName)
				gp.AddString(MShape.Text, fl, MShape.FontStyle,
						 MShape.FontSize * 1.34 * Zoom, rt, sf)
		End Select

		'flip
		Dim flipXMatrix = New Matrix(-1, 0,
									 0, 1,
									 GetRect.Width, 0)
		Dim flipYMatrix = New Matrix(1, 0,
									 0, -1,
									 0, GetRect.Height)
		Dim transformMatrix = New Matrix()
		If FlipX Then transformMatrix.Multiply(flipXMatrix)
		If FlipY Then transformMatrix.Multiply(flipYMatrix)
		If GetRect.Width < 0 Then transformMatrix.Translate(GetRect.Width, 0)
		If GetRect.Height < 0 Then transformMatrix.Translate(0, GetRect.Height)
		gp.Transform(transformMatrix)
		'Debug.WriteLine(gp.GetBounds)

		'warp
		'rt = gp.GetBounds
		'Dim points = New PointF() {
		'	New PointF(rt.X + (rt.Width / 4), rt.Y),
		'	New PointF(rt.Right - (rt.Width / 4), rt.Y),
		'	New PointF(rt.X, rt.Bottom),
		'	New PointF(rt.Right, rt.Bottom)}
		'gp.Warp(points, rt)
		gp.FillMode = FillMode.Winding
		_pth = gp
	End Sub

	''' <summary>
	''' Apply rotation on <see cref="GraphicsPath"/>.
	''' </summary>
	''' <param name="gp"><see cref="GraphicsPath"/> on which rotation should be applied.</param>
	Private Sub AdjustRotation(ByRef gp As GraphicsPath)
		Dim mm As New Matrix
		mm.RotateAt(Angle, RotationPoint)
		gp.Transform(mm)
	End Sub

	Public Function TopLeft(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X - AnchorSize.Width, GetRect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Top(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (AnchorSize.Width / 2), GetRect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function TopRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.Right, GetRect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Left(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X - AnchorSize.Width, GetRect.Y + (GetRect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Right(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.Right, GetRect.Y + (GetRect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomLeft(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X - AnchorSize.Width, GetRect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Bottom(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (AnchorSize.Width / 2), GetRect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.Right, GetRect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Rotate(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (AnchorSize.Width / 2), GetRect.Y - 30, AnchorSize.Width, AnchorSize.Height)
		rect.Inflate(1, 1)
		Dim gp As New GraphicsPath()
		gp.AddEllipse(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Centering(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(MathUtils.FromPercentage(GetRect, FBrush.PCenterPoint), New SizeF(0, 0))
		rect.Inflate(3, 3)
		Dim pt As PointF = rect.Location
		Dim gp As New GraphicsPath()
		gp.AddEllipse(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

#End Region

#Region "Clone"
	''' <summary>
	''' Creates an exact copy of this <see cref="Shape"/> object.
	''' </summary>
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
		_new.BindEvents()
		Return _new
	End Function
#End Region

#Region "IDisposable"
	Public Sub Dispose() Implements IDisposable.Dispose
		If Not IsNothing(_pn) Then _pn.Dispose()
		If Not IsNothing(_pb) Then _pb.Dispose()
		If Not IsNothing(_cb) Then _cb.Dispose()
		If Not IsNothing(_img) Then _img.Dispose()
		If Not IsNothing(_pth) Then _pth.Dispose()
	End Sub
#End Region

End Class
