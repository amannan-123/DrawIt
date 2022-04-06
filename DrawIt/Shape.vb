Imports System.ComponentModel
Imports System.Drawing.Drawing2D

<Serializable>
Public Class Shape

#Region "Constructor"
	Public Sub BindEvents()
		AddHandler FBrush.PropertyChanged, AddressOf BrushChanged
		AddHandler DPen.PropertyChanged, AddressOf PenChanged
		AddHandler DPen.PBrush.PropertyChanged, AddressOf PenChanged
		AddHandler MShape.PropertyChanged, AddressOf ShapeChanged
	End Sub

	Private Sub ShapeChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdatePath()
		UpdateBrush()
		UpdatePenBrush()
	End Sub

	Private Sub PenChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdateSelectionPen()
		UpdatePenBrush()
	End Sub

	Private Sub BrushChanged(sender As Object, e As PropertyChangedEventArgs)
		UpdateBrush()
	End Sub

	Sub New()
		ReloadCachedObjects()
	End Sub

	Sub New(_loc As PointF, _shp As MyShape.ShapeStyle, _br As MyBrush.BrushType)
		FBrush.BType = _br
		MShape.SType = _shp
		_rect.Location = _loc
		_rect.Size = New SizeF(10, 10)
		BindEvents()
		ReloadCachedObjects()
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
		Set(value As RectangleF)
			_rect = value

			UpdatePath()
			If Not FBrush.BType = MyBrush.BrushType.Solid AndAlso Not FBrush.BType = MyBrush.BrushType.Hatch Then
				UpdateBrush()
			End If
			If Not DPen.PBrush.BType = MyBrush.BrushType.Solid AndAlso Not DPen.PBrush.BType = MyBrush.BrushType.Hatch Then
				UpdatePenBrush()
			End If
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

	Private _cpt As New PointF
	Public Property CenterPoint() As PointF
		Get
			Return _cpt
		End Get
		Set(value As PointF)
			_cpt = value
		End Set
	End Property

	Private _sel As Boolean = True
	Public Property Selected() As Boolean
		Get
			Return _sel
		End Get
		Set(value As Boolean)
			_sel = value
		End Set
	End Property

	Private _mov As Boolean = True
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
		End Set
	End Property

	Private shear_y As Single = 0
	Public Property ShearY() As Single
		Get
			Return shear_y
		End Get
		Set(value As Single)
			shear_y = value
		End Set
	End Property

	Private _flipX As Boolean = False
	Public Property FlipX() As Boolean
		Get
			Return _flipX
		End Get
		Set(ByVal value As Boolean)
			_flipX = value
		End Set
	End Property

	Private _flipY As Boolean = False
	Public Property FlipY() As Boolean
		Get
			Return _flipY
		End Get
		Set(ByVal value As Boolean)
			_flipY = value
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

#Region "Private Subs"
	''' <summary>
	''' Apply rotation on <see cref="GraphicsPath"/>.
	''' </summary>
	''' <param name="gp"><see cref="GraphicsPath"/> on which rotation should be applied.</param>
	Private Sub AdjustRotation(ByRef gp As GraphicsPath)
		Dim mm As New Matrix
		mm.RotateAt(Angle, _cpt)
		gp.Transform(mm)
	End Sub
#End Region

#Region "Drawing Related Functions"

	Public Sub ReloadCachedObjects()
		UpdatePath()
		UpdateBrush()
		UpdateSelectionPen()
		UpdatePenBrush()
	End Sub

	''' <summary>
	''' Returns a region containing path and border.
	''' </summary>
	Public Function Region() As Region
		Dim rg As New Region(Rectangle.Empty)
		If Not IsNothing(BorderPath) Then rg.Union(BorderPath)
		If Not IsNothing(SelectionPath) Then rg.Union(SelectionPath)
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
	Public ReadOnly Property SelectionPen(Optional rotated As Boolean = True,
								 Optional sheared As Boolean = True) As Pen
		Get
			If IsNothing(_pn) Then Return Nothing
			Dim pn = _pn.Clone
			If sheared Then
				Dim mm As New Matrix
				mm.Translate(_rect.X, _rect.Y)
				mm.Shear(ShearX, ShearY)
				pn.MultiplyTransform(mm)
			End If
			If rotated Then
				Dim mm As New Matrix
				mm.RotateAt(Angle, CenterPoint)
				pn.MultiplyTransform(mm)
			End If
			Return pn
		End Get
	End Property

	''' <summary>
	''' Updates <see cref="SelectionPen"/>.
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
			Case MyBrush.BrushType.Solid
				_pb = New SolidBrush(DPen.PBrush.SolidColor)
			Case MyBrush.BrushType.LinearGradient
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
			Case MyBrush.BrushType.PathGradient
				_pb = Nothing
			Case MyBrush.BrushType.Hatch
				_pb = New HatchBrush(DPen.PBrush.HStyle, DPen.PBrush.HFore, DPen.PBrush.HBack)
			Case MyBrush.BrushType.Texture
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

	''' <summary>
	''' Updates <see cref="FillBrush"/>.
	''' </summary>
	Public Sub UpdateBrush()
		'Static cnt As Integer = 0
		'cnt += 1
		'Debug.WriteLine(cnt & "UpdateBrush")

		Select Case FBrush.BType
			Case MyBrush.BrushType.Solid
				_cb = New SolidBrush(FBrush.SolidColor)
			Case MyBrush.BrushType.LinearGradient
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
														FBrush.LinearAngle) With {
					.GammaCorrection = FBrush.LGamma
														}
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
			Case MyBrush.BrushType.PathGradient
				Dim ptb As New PathGradientBrush(TotalPath(False)) With {
						.CenterColor = FBrush.PCenter,
						.SurroundColors = FBrush.PSurround,
						.FocusScales = New PointF(FBrush.PFocusX, FBrush.PFocusY),
						.CenterPoint = FromPercentage(AbsRect(_rect), FBrush.PCenterPoint)
					}
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
			Case MyBrush.BrushType.Hatch
				_cb = New HatchBrush(FBrush.HStyle, FBrush.HFore, FBrush.HBack)
			Case MyBrush.BrushType.Texture
				If IsNothing(FBrush.TImage) Then
					_cb = Nothing
					Return
				End If
				Dim rt As New RectangleF(0, 0, Math.Abs(_rect.Width), Math.Abs(_rect.Height))
				If rt.Width = 0 Or rt.Height = 0 Then
					_cb = Nothing
					Return
				End If
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
				If FBrush.TTransparency Then bmp.MakeTransparent(FBrush.TColor)
				Dim txb As New TextureBrush(bmp)
				Dim mm As New Matrix
				mm.Translate(_rect.X, _rect.Y)
				mm.Shear(ShearX, ShearY)
				txb.Transform = mm
				_cb = txb
		End Select
	End Sub

	''' <summary>
	''' Returns <see cref="TotalPath(Boolean, Boolean, Boolean)"/> as <see cref="Drawing.Region"/>.
	''' </summary>
	''' <param name="_anc">Include anchors</param>
	''' <returns></returns>
	Public Function SelectionPath(Optional _anc As Boolean = True) As Region
		Dim gp As GraphicsPath = TotalPath()
		If IsNothing(gp) Then Return Nothing
		If Not IsNothing(gp) Then
			Dim rg As New Region(gp)
			If Primary AndAlso _anc Then
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
				If FBrush.BType = MyBrush.BrushType.PathGradient Then _anchors.Add(Centering())
				For Each anc As GraphicsPath In _anchors
					rg.Union(anc)
				Next
			End If
			Return rg
		End If
		Return Nothing
	End Function

	<NonSerialized>
	Private _pth As GraphicsPath = Nothing
	''' <summary>
	''' Returns <see cref="GraphicsPath"/> based on <see cref="MShape"/> of current instance.
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property TotalPath(Optional rotated As Boolean = True,
							  Optional sheared As Boolean = True,
							  Optional translated As Boolean = True) As GraphicsPath
		Get
			If IsNothing(_pth) Then Return Nothing
			Dim gp As GraphicsPath = _pth.Clone
			Dim mm As New Matrix
			If translated Then mm.Translate(_rect.X, _rect.Y)
			If sheared Then mm.Shear(ShearX, ShearY)
			gp.Transform(mm)
			If rotated Then AdjustRotation(gp)
			Return gp
		End Get
	End Property

	''' <summary>
	''' Updates <see cref="TotalPath(Boolean, Boolean, Boolean)"/>.
	''' </summary>
	Public Sub UpdatePath()

		If _rect.Width = 0 Or _rect.Height = 0 Then
			_pth = Nothing
			Return
		End If

		Dim gp As New GraphicsPath()

		Dim rt As New RectangleF(0, 0, Math.Abs(_rect.Width), Math.Abs(_rect.Height))
		Select Case MShape.SType
			Case MyShape.ShapeStyle.Rectangle
				gp.AddRectangle(rt)
			Case MyShape.ShapeStyle.RoundedRectangle
				gp = GetRoundedRectPath(rt, MShape.Corners,
										MShape.ULType, MShape.URType,
										MShape.BLType, MShape.BRType)
			Case MyShape.ShapeStyle.Ellipse
				gp.AddEllipse(rt)
			Case MyShape.ShapeStyle.Triangle
				Dim _lst As New List(Of PointF) From {
					FromPercentage(rt, New PointF(50, 0)),
					FromPercentage(rt, New PointF(0, 100)),
					FromPercentage(rt, New PointF(100, 100))
				}
				gp.AddPolygon(_lst.ToArray)
			Case MyShape.ShapeStyle.Lines
				If MShape.PolygonPoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.PolygonPoints
					_lst.Add(FromPercentage(rt, pt))
				Next
				gp.AddLines(_lst.ToArray)
			Case MyShape.ShapeStyle.Polygon
				If MShape.PolygonPoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.PolygonPoints
					_lst.Add(FromPercentage(rt, pt))
				Next
				gp.AddPolygon(_lst.ToArray)
			Case MyShape.ShapeStyle.Curves
				If MShape.CurvePoints.Length < 2 Then
					_pth = Nothing
					Return
				End If
				Dim _lst As New List(Of PointF)
				For Each pt As PointF In MShape.CurvePoints
					_lst.Add(FromPercentage(rt, pt))
				Next
				gp.AddCurve(_lst.ToArray, MShape.Tension)
			Case MyShape.ShapeStyle.ClosedCurve
				If MShape.CurvePoints.Length < 3 Then
					_pth = Nothing
					Return
				End If
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
				gp.AddPie(0, 0, rt.Width, rt.Height, MShape.StartAngle, MShape.SweepAngle)
			Case MyShape.ShapeStyle.Text
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
						 MShape.FontSize * 1.34, rt, sf)
		End Select

		'flip
		Dim flipXMatrix = New Matrix(-1, 0,
									 0, 1,
									 BaseRect.Width, 0)
		Dim flipYMatrix = New Matrix(1, 0,
									 0, -1,
									 0, BaseRect.Height)
		Dim transformMatrix = New Matrix()
		If FlipX Then transformMatrix.Multiply(flipXMatrix)
		If FlipY Then transformMatrix.Multiply(flipYMatrix)
		If _rect.Width < 0 Then transformMatrix.Translate(_rect.Width, 0)
		If _rect.Height < 0 Then transformMatrix.Translate(0, _rect.Height)
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

		_pth = gp
	End Sub

	Public Function TopLeft(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Top(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function TopRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.Right, _rect.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
			rect.Y += (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Left(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Y + (_rect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Right(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.Right, _rect.Y + (_rect.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomLeft(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X - AnchorSize.Width, _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X += (AnchorSize.Width / 2)
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Bottom(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function BottomRight(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.Right, _rect.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(_rect.Width) > 20 AndAlso Math.Abs(_rect.Height) > 20 Then
			rect.X -= (AnchorSize.Width / 2)
			rect.Y -= (AnchorSize.Height / 2)
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Rotate(Optional rotated As Boolean = True) As GraphicsPath
		Dim rect As New RectangleF(_rect.X + (_rect.Width / 2) - (AnchorSize.Width / 2), _rect.Y - 30, AnchorSize.Width, AnchorSize.Height)
		rect.Inflate(1, 1)
		Dim gp As New GraphicsPath()
		gp.AddEllipse(rect)
		If rotated Then AdjustRotation(gp)
		Return gp
	End Function

	Public Function Centering(Optional rotated As Boolean = True) As GraphicsPath
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

End Class
