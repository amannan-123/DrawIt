Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Text.Json.Serialization
Imports DrawIt.Helpers
Imports DrawIt.Models

<Serializable>
Public Class Shape : Implements IDisposable

#Region "Constructor"
	Private _eventsBound As Boolean = False

	Public Sub BindEvents()
		If _eventsBound Then UnbindEvents()
		AddHandler FBrush.PropertyChanged, AddressOf BrushChanged
		AddHandler DPen.PropertyChanged, AddressOf PenChanged
		AddHandler DPen.PBrush.PropertyChanged, AddressOf PenChanged
		AddHandler MShape.PropertyChanged, AddressOf ShapeChanged
		_eventsBound = True
	End Sub

	Private Sub UnbindEvents()
		If Not _eventsBound Then Return
		RemoveHandler FBrush.PropertyChanged, AddressOf BrushChanged
		RemoveHandler DPen.PropertyChanged, AddressOf PenChanged
		RemoveHandler DPen.PBrush.PropertyChanged, AddressOf PenChanged
		RemoveHandler MShape.PropertyChanged, AddressOf ShapeChanged
		_eventsBound = False
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
	End Sub

	Sub New(_loc As PointF, _shp As ShapeStyle, _br As BrushType)
		FBrush = MyBrushFactory.Create(_br)
		MShape = MyShapeFactory.Create(_shp)
		_baseX = _loc.X
		_baseY = _loc.Y
		_baseWidth = 10
		_baseHeight = 10
		BindEvents()
		ReloadCachedObjects()
	End Sub
#End Region

#Region "Globals"
	Private AnchorSize As New SizeF(7, 7)
	Private _anchorScale As Single = 1.0F
	<JsonIgnore>
	Public Property AnchorScale As Single
		Get
			Return _anchorScale
		End Get
		Set(value As Single)
			_anchorScale = Math.Max(0.0001F, value)
		End Set
	End Property

	Private Function EffectiveAnchorSize() As SizeF
		Return New SizeF(AnchorSize.Width * AnchorScale, AnchorSize.Height * AnchorScale)
	End Function
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
		UpdateBrush()
		UpdatePenBrush()
	End Sub

	Public Function GetRect() As RectangleF
		Return New RectangleF(_baseX, _baseY, _baseWidth, _baseHeight)
	End Function

	Public Sub SetAllRect(rect As RectangleF)
		_baseX = rect.X
		_baseY = rect.Y
		_baseWidth = rect.Width
		_baseHeight = rect.Height
		FinalizeCoordsChange()
	End Sub

#End Region

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
			Dim pathBrush = TryCast(FBrush, MyPathGradientBrush)
			If IsNothing(pathBrush) Then Return
			Dim cent_pt = pathBrush.CenterPoint
			cent_pt.X = 100 - cent_pt.X
			pathBrush.CenterPoint = cent_pt
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
			Dim pathBrush = TryCast(FBrush, MyPathGradientBrush)
			If IsNothing(pathBrush) Then Return
			Dim cent_pt = pathBrush.CenterPoint
			cent_pt.Y = 100 - cent_pt.Y
			pathBrush.CenterPoint = cent_pt
		End Set
	End Property

	Private _brush As MyBrush = New MySolidBrush()
	Public Property FBrush() As MyBrush
		Get
			Return _brush
		End Get
		Set(value As MyBrush)
			If IsNothing(value) Then value = New MySolidBrush()
			If ReferenceEquals(_brush, value) Then Return

			If _eventsBound AndAlso Not IsNothing(_brush) Then
				RemoveHandler _brush.PropertyChanged, AddressOf BrushChanged
			End If

			_brush = value

			If _eventsBound Then
				AddHandler _brush.PropertyChanged, AddressOf BrushChanged
			End If

			UpdateImage()
			UpdateBrush()
		End Set
	End Property

	Private _pen As New MyPen()
	Public Property DPen() As MyPen
		Get
			Return _pen
		End Get
		Set(value As MyPen)
			If IsNothing(value) Then value = New MyPen()
			If ReferenceEquals(_pen, value) Then Return

			If _eventsBound AndAlso Not IsNothing(_pen) Then
				RemoveHandler _pen.PropertyChanged, AddressOf PenChanged
				If Not IsNothing(_pen.PBrush) Then RemoveHandler _pen.PBrush.PropertyChanged, AddressOf PenChanged
			End If

			_pen = value

			If _eventsBound Then
				AddHandler _pen.PropertyChanged, AddressOf PenChanged
				If Not IsNothing(_pen.PBrush) Then AddHandler _pen.PBrush.PropertyChanged, AddressOf PenChanged
			End If

			UpdateSelectionPen()
			UpdatePenBrush()
		End Set
	End Property

	Private _shape As MyShape = MyShapeFactory.Create(ShapeStyle.Rectangle)
	Public Property MShape() As MyShape
		Get
			Return _shape
		End Get
		Set(value As MyShape)
			If IsNothing(value) Then value = MyShapeFactory.Create(ShapeStyle.Rectangle)
			If ReferenceEquals(_shape, value) Then Return

			If _eventsBound AndAlso Not IsNothing(_shape) Then
				RemoveHandler _shape.PropertyChanged, AddressOf ShapeChanged
			End If

			_shape = value

			If _eventsBound Then
				AddHandler _shape.PropertyChanged, AddressOf ShapeChanged
			End If

			'Replacing the whole shape model must refresh cached geometry/brushes immediately.
			UpdatePath()
			UpdateImage()
			UpdateBrush()
			UpdateSelectionPen()
			UpdatePenBrush()
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
			.StartCap = ToLineCap(DPen.PStartCap),
			.EndCap = ToLineCap(DPen.PEndCap),
			.DashCap = ToDashCap(DPen.PDashCap),
			.DashStyle = ToDashStyle(DPen.PDashstyle),
			.LineJoin = ToLineJoin(DPen.PLineJoin)
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
				Dim solid = TryCast(DPen.PBrush, MySolidBrush)
				If IsNothing(solid) Then
					_pb = Nothing
					Return
				End If
				_pb = New SolidBrush(solid.Color)
			Case BrushType.LinearGradient
				Dim linear = TryCast(DPen.PBrush, MyLinearGradientBrush)
				If IsNothing(linear) Then
					_pb = Nothing
					Return
				End If
				Dim pth As GraphicsPath = TotalPath(False)
				If IsNothing(pth) Then
					_pb = Nothing
					Return
				End If
				pth.Widen(SelectionPen)
				Dim r2 As RectangleF = pth.GetBounds
				r2.Inflate(1, 1)
				Dim lgb As New LinearGradientBrush(r2, linear.Color1,
													linear.Color2,
													linear.Angle) With {
					.GammaCorrection = linear.Gamma
													}
				If linear.Triangular Then
					lgb.SetBlendTriangularShape(linear.TriFocus, linear.TriScale)
				End If
				If linear.Bell Then
					lgb.SetSigmaBellShape(linear.BellFocus, linear.BellScale)
				End If
				If linear.Interpolate Then
					Dim ip As New ColorBlend
					If linear.InterColors.Length = linear.InterPositions.Length Then
						ip.Colors = linear.InterColors
						ip.Positions = linear.InterPositions
						lgb.InterpolationColors = ip
					Else
						_pb = Nothing
					End If
				End If
				_pb = lgb
			Case BrushType.PathGradient
				_pb = Nothing
			Case BrushType.Hatch
				Dim hatch = TryCast(DPen.PBrush, MyHatchBrush)
				If IsNothing(hatch) Then
					_pb = Nothing
					Return
				End If
				_pb = New HatchBrush(ToHatchStyle(hatch.Style), hatch.Fore, hatch.Back)
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
		Dim texture = TryCast(FBrush, MyTextureBrush)
		If IsNothing(texture) Then
			_img = Nothing
			Return
		End If
		Dim rt As New RectangleF(0, 0, Math.Abs(GetRect.Width), Math.Abs(GetRect.Height))
		If rt.Width < 1 Or rt.Height < 1 Then
			_img = Nothing
			Return
		End If
		Dim img As Image = BytesToImage(texture.ImageBytes)
		If IsNothing(img) Then
			_img = Nothing
			Return
		End If
		img.RotateFlip(ToRotateFlipType(texture.RotateFlip))
		Dim bmp As New Bitmap(img, rt.Width, rt.Height)
		img.Dispose()
		'Dim bmp As New Bitmap(CInt(rt.Width), CInt(rt.Height))
		'Dim g As Graphics = Graphics.FromImage(bmp)
		'g.CompositingMode = CompositingMode.SourceCopy
		'g.CompositingQuality = CompositingQuality.HighQuality
		'g.InterpolationMode = InterpolationMode.HighQualityBicubic
		'g.SmoothingMode = SmoothingMode.HighQuality
		'g.PixelOffsetMode = PixelOffsetMode.HighQuality
		'g.DrawImage(img, rt)
		'img.Dispose()
		If texture.Transparency Then bmp.MakeTransparent(texture.TransparentColor)
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
				Dim solid = TryCast(FBrush, MySolidBrush)
				If IsNothing(solid) Then
					_cb = Nothing
					Return
				End If
				_cb = New SolidBrush(solid.Color)
			Case BrushType.LinearGradient
				Dim linear = TryCast(FBrush, MyLinearGradientBrush)
				If IsNothing(linear) Then
					_cb = Nothing
					Return
				End If
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
				Dim lgb As New LinearGradientBrush(r2, linear.Color1,
														linear.Color2,
														linear.Angle) With
														{.GammaCorrection = linear.Gamma}
				If linear.Triangular Then
					lgb.SetBlendTriangularShape(linear.TriFocus, linear.TriScale)
				ElseIf linear.Bell Then
					lgb.SetSigmaBellShape(linear.BellFocus, linear.BellScale)
				End If
				If linear.Interpolate Then
					Dim ip As New ColorBlend With {
						.Colors = linear.InterColors,
						.Positions = linear.InterPositions
					}
					If ip.Colors.Length = ip.Positions.Length Then lgb.InterpolationColors = ip
				ElseIf linear.Blend Then
					Dim bl As New Blend With {
						.Factors = linear.BlendFactors,
						.Positions = linear.BlendPositions
					}
					If bl.Factors.Length = bl.Positions.Length Then lgb.Blend = bl
				End If
				_cb = lgb
			Case BrushType.PathGradient
				Dim pathBrush = TryCast(FBrush, MyPathGradientBrush)
				If IsNothing(pathBrush) Then
					_cb = Nothing
					Return
				End If
				Dim t_path = TotalPath(False)
				If IsNothing(t_path) Or AbsRect(GetRect).Width = 0 Or AbsRect(GetRect).Height = 0 Then
					_cb = Nothing
					Return
				End If
				Dim ptb As New PathGradientBrush(TotalPath(False)) With {
						.CenterColor = pathBrush.Center,
						.FocusScales = New PointF(pathBrush.FocusX, pathBrush.FocusY),
						.CenterPoint = MathUtils.FromPercentage(AbsRect(GetRect), pathBrush.CenterPoint)
					}
				If pathBrush.Surround.Length <= t_path.PointCount Then
					ptb.SurroundColors = pathBrush.Surround
				End If
				If pathBrush.Triangular Then
					ptb.SetBlendTriangularShape(pathBrush.TriFocus, pathBrush.TriScale)
				ElseIf pathBrush.Bell Then
					ptb.SetSigmaBellShape(pathBrush.BellFocus, pathBrush.BellScale)
				End If
				If pathBrush.Interpolate Then
					Dim ip As New ColorBlend With {
						.Colors = pathBrush.InterColors,
						.Positions = pathBrush.InterPositions
					}
					If ip.Colors.Length = ip.Positions.Length Then ptb.InterpolationColors = ip
				ElseIf pathBrush.Blend Then
					Dim bl As New Blend With {
						.Factors = pathBrush.BlendFactors,
						.Positions = pathBrush.BlendPositions
					}
					If bl.Factors.Length = bl.Positions.Length Then ptb.Blend = bl
				End If
				_cb = ptb
			Case BrushType.Hatch
				Dim hatch = TryCast(FBrush, MyHatchBrush)
				If IsNothing(hatch) Then
					_cb = Nothing
					Return
				End If
				_cb = New HatchBrush(ToHatchStyle(hatch.Style), hatch.Fore, hatch.Back)
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
				Dim data = TryCast(MShape, MyRoundedRectangle)
				If IsNothing(data) Then
					_pth = Nothing
					Return
				End If
				gp = GetRoundedRectPath(rt, data.Corners)
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
				Dim data = TryCast(MShape, MyLines)
				If IsNothing(data) OrElse data.PolygonPoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In data.PolygonPoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddLines(_lst.ToArray)
			Case ShapeStyle.Polygon
				Dim data = TryCast(MShape, MyPolygon)
				If IsNothing(data) OrElse data.PolygonPoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In data.PolygonPoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddPolygon(_lst.ToArray)
			Case ShapeStyle.Curves
				Dim data = TryCast(MShape, MyCurves)
				If IsNothing(data) OrElse data.CurvePoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In data.CurvePoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddCurve(_lst.ToArray, data.Tension)
			Case ShapeStyle.ClosedCurve
				Dim data = TryCast(MShape, MyClosedCurve)
				If IsNothing(data) OrElse data.CurvePoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In data.CurvePoints
					_lst.Add(MathUtils.FromPercentage(rt, pt))
				Next
				gp.AddClosedCurve(_lst.ToArray, data.Tension)
			'Case ShapeStyle.Spiral
			'	gp = SpiralPath(GetRect, MShape.Spirals)
			Case ShapeStyle.Arc
				Dim data = TryCast(MShape, MyArc)
				If IsNothing(data) Then
					_pth = Nothing
					Return
				End If
				gp.AddArc(rt, data.StartAngle, data.SweepAngle)
			Case ShapeStyle.Pie
				Dim data = TryCast(MShape, MyPie)
				If IsNothing(data) Then
					_pth = Nothing
					Return
				End If
				gp.AddPie(0, 0, rt.Width, rt.Height, data.StartAngle, data.SweepAngle)
			Case ShapeStyle.Text
				Dim data = TryCast(MShape, MyText)
				If IsNothing(data) Then
					_pth = Nothing
					Return
				End If
				Dim stxt = data.Text.Trim()
				If stxt.Length = 0 Then
					_pth = Nothing
					Return
				End If
				'sf.FormatFlags = StringFormatFlags.NoWrap
				Dim sf As New StringFormat With {
					.Trimming = StringTrimming.EllipsisCharacter
				}
				Select Case data.TextAlignment
					Case MyTextAlignment.TopLeft
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Near
					Case MyTextAlignment.TopCenter
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Center
					Case MyTextAlignment.TopRight
						sf.LineAlignment = StringAlignment.Near
						sf.Alignment = StringAlignment.Far
					Case MyTextAlignment.MiddleLeft
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Near
					Case MyTextAlignment.MiddleCenter
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Center
					Case MyTextAlignment.MiddleRight
						sf.LineAlignment = StringAlignment.Center
						sf.Alignment = StringAlignment.Far
					Case MyTextAlignment.BottomLeft
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Near
					Case MyTextAlignment.BottomCenter
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Center
					Case MyTextAlignment.BottomRight
						sf.LineAlignment = StringAlignment.Far
						sf.Alignment = StringAlignment.Far
				End Select
				Dim fl As New FontFamily(data.FontName)
				gp.AddString(data.Text, fl, ToFontStyle(data.FontStyle),
						 data.FontSize * 1.34, rt, sf)
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
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X - anc.Width, GetRect.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (anc.Width / 2)
			rect.Y += (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Top(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (anc.Width / 2), GetRect.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.Y += (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function TopRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.Right, GetRect.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (anc.Width / 2)
			rect.Y += (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Left(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X - anc.Width, GetRect.Y + (GetRect.Height / 2) - (anc.Height / 2), anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (anc.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Right(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.Right, GetRect.Y + (GetRect.Height / 2) - (anc.Height / 2), anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (anc.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomLeft(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X - anc.Width, GetRect.Bottom, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X += (anc.Width / 2)
			rect.Y -= (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Bottom(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (anc.Width / 2), GetRect.Bottom, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.Y -= (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.Right, GetRect.Bottom, anc.Width, anc.Height)
		If Math.Abs(GetRect.Width) > 20 AndAlso Math.Abs(GetRect.Height) > 20 Then
			rect.X -= (anc.Width / 2)
			rect.Y -= (anc.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Rotate(Optional rotated As Boolean = True) As GraphicsPath
		Dim anc = EffectiveAnchorSize()
		Dim rect As New RectangleF(GetRect.X + (GetRect.Width / 2) - (anc.Width / 2), GetRect.Y - (30 * AnchorScale), anc.Width, anc.Height)
		rect.Inflate(1 * AnchorScale, 1 * AnchorScale)
		Dim gp As New GraphicsPath()
		gp.AddEllipse(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Centering(Optional rotated As Boolean = True) As GraphicsPath
		Dim pathBrush = TryCast(FBrush, MyPathGradientBrush)
		Dim centerPoint As PointF = If(IsNothing(pathBrush), New PointF(50, 50), pathBrush.CenterPoint)
		Dim rect As New RectangleF(MathUtils.FromPercentage(GetRect, centerPoint), New SizeF(0, 0))
		rect.Inflate(3 * AnchorScale, 3 * AnchorScale)
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
