#Region "Imports"
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports DrawIt.Helpers
Imports DrawIt.Models
#End Region

Public Class Canvas : Implements ICanvasInteractionContext
	Private Const ShapesClipboardFormat As String = "DrawIt.Shapes.v1"
	Private ReadOnly _interactionController As New CanvasInteractionController(
		New CanvasSelectMouseHandler(),
		New CanvasDrawMouseHandler())

#Region "New"
	Sub New()
		InitializeComponent()
		InitializeCanvasStyles()
	End Sub

	Sub New(frm As MainForm)
		InitializeComponent()
		InitializeCanvasStyles()
	End Sub

	Private Sub InitializeCanvasStyles()
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		SetStyle(ControlStyles.ResizeRedraw, True)
		SetStyle(ControlStyles.UserMouse, True)
		SetStyle(ControlStyles.UserPaint, True)
	End Sub
#End Region

#Region "Structs & Enums"
	Public Class HoverInfo

		Public Sub New(ind As Integer, type As Integer)
			shp_index = ind
			h_type = type
		End Sub

		Private shp_index As Integer
		Public Property ShapeIndex() As Integer
			Get
				Return shp_index
			End Get
			Set(ByVal value As Integer)
				shp_index = value
			End Set
		End Property

		Private h_type As Integer
		Public Property HoverType() As Integer
			Get
				Return h_type
			End Get
			Set(ByVal value As Integer)
				h_type = value
			End Set
		End Property

	End Class

	Public Class DrawModeInfo

		Public Sub New(mode As Boolean)
			d_mode = mode
			_pts = New List(Of PointF)
		End Sub

		Private d_mode As Boolean
		Public Property DrawMode() As Boolean
			Get
				Return d_mode
			End Get
			Set(ByVal value As Boolean)
				d_mode = value
			End Set
		End Property

		Private _pts As List(Of PointF)
		Public Property Points() As List(Of PointF)
			Get
				Return _pts
			End Get
			Set(ByVal value As List(Of PointF))
				_pts = value
			End Set
		End Property

		Private d_shape As DShape
		Public Property ShapeType As DShape
			Get
				Return d_shape
			End Get
			Set(ByVal value As DShape)
				d_shape = value
			End Set
		End Property

	End Class

	Enum SelectOrder
		AboveFirst
		BelowFirst
	End Enum

	Enum DShape
		Lines = 4
		Polygon = 5
		Curves = 6
		ClosedCurve = 7
	End Enum
#End Region

#Region "Globals"
	Private AnchorSize As New SizeF(7, 7)
	Private ReadOnly _state As New CanvasStateManager()
#End Region

#Region "Properties"

	Private _zoom As Single = 1.0F
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
	Public Property Zoom() As Single
		Get
			Return _zoom
		End Get
		Set(ByVal value As Single)
			If value <> _zoom Then
				value = ZoomPanMath.ClampZoom(value)
				_zoom = value
				MainForm.UpdateSettings()
				Invalidate()
			End If
		End Set
	End Property

	Private _panOffset As PointF = PointF.Empty
	<Browsable(False)>
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
	Public Property PanOffset() As PointF
		Get
			Return _panOffset
		End Get
		Set(ByVal value As PointF)
			_panOffset = value
			Invalidate()
		End Set
	End Property

	Private _absSize As New Size(500, 500)
	<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
	Public Property AbsSize() As Size
		Get
			Return _absSize
		End Get
		Set(ByVal value As Size)
			_absSize = value
			If Not IsNothing(MainCanvasControl) Then MainCanvasControl.SetSize()
		End Set
	End Property

	Public ReadOnly Property MainCanvasControl() As CanvasControl
		Get
			If IsNothing(Parent) Then Return Nothing
			Return DirectCast(Parent.Parent, CanvasControl)
		End Get
	End Property

	Private _ord As SelectOrder = SelectOrder.AboveFirst
	<DefaultValue(GetType(SelectOrder), "AboveFirst")>
	Public Property SelectionOrder() As SelectOrder
		Get
			Return _ord
		End Get
		Set(value As SelectOrder)
			_ord = value
			SetPrimary()
			Invalidate()
		End Set
	End Property

	Private hg_pth As Color = Color.Blue
	<DefaultValue(GetType(Color), "Blue")>
	Public Property PathHighlightColor() As Color
		Get
			Return hg_pth
		End Get
		Set(value As Color)
			hg_pth = value
		End Set
	End Property

	Private hg_brd As Color = Color.Lime
	<DefaultValue(GetType(Color), "Lime")>
	Public Property BorderHighlightColor() As Color
		Get
			Return hg_brd
		End Get
		Set(value As Color)
			hg_brd = value
		End Set
	End Property

	Private clr_sz As Color = Color.Black
	<DefaultValue(GetType(Color), "Black")>
	Public Property SizeTextColor() As Color
		Get
			Return clr_sz
		End Get
		Set(value As Color)
			clr_sz = value
		End Set
	End Property

	Private clr_sel As Color = Color.RoyalBlue
	<DefaultValue(GetType(Color), "RoyalBlue")>
	Public Property SelectionRectangleColor() As Color
		Get
			Return clr_sel
		End Get
		Set(value As Color)
			clr_sel = value
		End Set
	End Property

	Private _highlight As Boolean = True
	<DefaultValue(GetType(Boolean), "True")>
	Public Property HighlightShapes() As Boolean
		Get
			Return _highlight
		End Get
		Set(value As Boolean)
			_highlight = value
		End Set
	End Property
#End Region

#Region "File Operations"
	Public Function SaveProject(_loc As String) As Exception
		Try
			DrawItJson.SerializeToFile(_loc, New ProjectData(_state.Shapes, AbsSize, BackColor, BackgroundImage))
		Catch ex As Exception
			Return ex
		End Try
		Return Nothing
	End Function

	Public Function LoadProject(_loc As String) As Exception
		Try
			Dim des_data = DrawItJson.DeserializeFromFile(Of ProjectData)(_loc)
			If IsNothing(des_data) Then
				Return New Exception("Project file could not be parsed.")
			End If
			_state.Shapes.Clear()
			If Not IsNothing(des_data.Shapes) Then _state.Shapes.AddRange(des_data.Shapes)
			BackColor = des_data.BackgroundColor
			BackgroundImage = des_data.BackgroundImage
			AbsSize = des_data.Size
			_state.Shapes.ForEach(Sub(x)
							 x.BindEvents()
							 x.ReloadCachedObjects()
						 End Sub)
			Invalidate()
		Catch ex As Exception
			Return ex
		End Try
		Return Nothing
	End Function

	Public Function SaveImage(_loc As String) As Exception
		Try
			If File.Exists(_loc) Then File.Delete(_loc)
			Dim img As Bitmap = CreateImage()
			If Not IsNothing(img) Then
				img.Save(_loc)
			Else
				Return New Exception("Cannot create image.")
			End If
			Return Nothing
		Catch ex As Exception
			Return ex
		End Try
	End Function
#End Region

#Region "Functions"

	Public Function GetViewportCenterOffset() As PointF
		Return ZoomPanMath.GetViewportCenterOffset(ClientSize, AbsSize, Zoom)
	End Function

	Public Function ToWorldPoint(pt As Point) As PointF Implements ICanvasInteractionContext.ToWorldPoint
		Dim centerOffset = GetViewportCenterOffset()
		Return ZoomPanMath.ToWorldPoint(pt, PanOffset, centerOffset, Zoom)
	End Function

	Public Function GetArtboardRect() As RectangleF
		Return New RectangleF(0, 0, AbsSize.Width, AbsSize.Height)
	End Function

	Public Function GetArtboardScreenRect() As RectangleF
		Dim rc = GetArtboardRect()
		Return ToScreenRect(rc)
	End Function

	Private Function ToScreenRect(worldRect As RectangleF) As RectangleF
		Dim centerOffset = GetViewportCenterOffset()
		Return ZoomPanMath.ToScreenRect(worldRect, PanOffset, centerOffset, Zoom)
	End Function

	Public Function GetWorldToScreenMatrix() As Matrix Implements ICanvasInteractionContext.GetWorldToScreenMatrix
		Dim centerOffset = GetViewportCenterOffset()
		Return ZoomPanMath.CreateWorldToScreenMatrix(PanOffset, centerOffset, Zoom)
	End Function

	Private Function IsRegionHit(region As Region, screenPt As PointF) As Boolean
		Using transformed = region.Clone()
			Using wm As Matrix = GetWorldToScreenMatrix()
				transformed.Transform(wm)
			End Using
			Return transformed.IsVisible(screenPt)
		End Using
	End Function

	Public Function IsPathHit(path As GraphicsPath, screenPt As PointF) As Boolean Implements ICanvasInteractionContext.IsPathHit
		Using transformed = DirectCast(path.Clone(), GraphicsPath)
			Using wm As Matrix = GetWorldToScreenMatrix()
				transformed.Transform(wm)
			End Using
			Return transformed.IsVisible(screenPt)
		End Using
	End Function

	Public Function ViewportContentBounds() As RectangleF
		Dim bounds As RectangleF = GetArtboardRect()
		For Each shp In _state.Shapes
			Using p = shp.TotalPath
				If Not IsNothing(p) Then bounds = RectangleF.Union(bounds, p.GetBounds())
			End Using
		Next
		Return bounds
	End Function

	Private Function AnnotationScaleCompensation() As Single
		Return ZoomPanMath.AnnotationScaleCompensation(Zoom)
	End Function

	Private Function AnnotationPenWidth() As Single
		Return AnnotationScaleCompensation()
	End Function

	Private Sub GetAnchorMetrics(ByRef anc As SizeF, ByRef minHandleDistance As Single)
		Dim scale = AnnotationScaleCompensation()
		anc = New SizeF(AnchorSize.Width * scale, AnchorSize.Height * scale)
		minHandleDistance = 20 * scale
	End Sub

	Private Sub SyncSelectedAnnotationScale()
		Dim scale = AnnotationScaleCompensation()
		For Each ind In SelectedIndices()
			If ind >= 0 AndAlso ind < _state.Shapes.Count Then
				_state.Shapes(ind).AnchorScale = scale
			End If
		Next
	End Sub

	Public Function IsPanInputActive() As Boolean Implements ICanvasInteractionContext.IsPanInputActive
		Dim canvasControl = MainCanvasControl
		Return Not IsNothing(canvasControl) AndAlso (canvasControl.Panning OrElse canvasControl.IsPanningNow)
	End Function

	Public Function MultipleSelectionBounds() As RectangleF Implements ICanvasInteractionContext.MultipleSelectionBounds
		Dim rg As New Region(RectangleF.Empty)
		SelectedIndices.ForEach(Sub(shp)
									Dim pth = _state.Shapes(shp).TotalPath
									If Not IsNothing(pth) Then rg.Union(pth)
								End Sub)
		Return rg.GetBounds(CreateGraphics)
	End Function

	Public Sub ClearDrawingData() Implements ICanvasInteractionContext.ClearDrawingData
		_state.DrawInfo.DrawMode = False
		_state.DrawInfo.Points.Clear()
		_state.CurrentLocation = PointF.Empty
	End Sub

	Public Function DModeMin() As Integer Implements ICanvasInteractionContext.DModeMin
		Select Case _state.DrawInfo.ShapeType
			Case DShape.Polygon, DShape.Curves, DShape.ClosedCurve
				Return 3
			Case DShape.Lines
				Return 2
			Case Else
				Return -1
		End Select
	End Function

	Private Function DPPath(ind As Integer) As GraphicsPath
		If ind < 0 Then Return Nothing
		Dim rt As New RectangleF(_state.DrawInfo.Points(ind), SizeF.Empty)
		rt.Inflate(5, 5)
		Dim pth As New GraphicsPath()
		pth.AddEllipse(rt)
		Return pth
	End Function

	Public Function DPInCursor(screenPt As PointF) As Integer Implements ICanvasInteractionContext.DPInCursor
		For i As Integer = _state.DrawInfo.Points.Count - 1 To 0 Step -1
			Using pth = DPPath(i)
				If IsPathHit(pth, screenPt) Then Return i
			End Using
		Next
		Return -1
	End Function

	Public Function ShapeInCursor(screenPt As PointF) As Integer Implements ICanvasInteractionContext.ShapeInCursor
		Dim ind As Integer = -1
		If _state.Shapes.Count = 0 Then Return ind
		For Each shp As Shape In _state.Shapes
			Dim shp_rg = shp.Region()
			If Not IsNothing(shp_rg) Then
				Using shp_rg
					If IsRegionHit(shp_rg, screenPt) Then
						If _ord = SelectOrder.AboveFirst Then
							ind = _state.Shapes.IndexOf(shp)
						Else
							Return _state.Shapes.IndexOf(shp)
						End If
					End If
				End Using
			End If
		Next
		Return ind
	End Function

	Public Function MainSelected() As Shape Implements ICanvasInteractionContext.MainSelected
		Dim inds = SelectedIndices()
		Dim shp As Shape = Nothing
		If inds.Count > 0 Then
			Dim primaryIndex = inds.Find(Function(i) _state.Shapes(i).Primary)
			If primaryIndex > -1 Then
				shp = _state.Shapes(primaryIndex)
			ElseIf _ord = SelectOrder.AboveFirst Then
				shp = _state.Shapes(inds.Last)
			Else
				shp = _state.Shapes(inds.First)
			End If
		End If
		Return shp
	End Function

	Public Function SelectedIndices() As List(Of Integer) Implements ICanvasInteractionContext.SelectedIndices
		Dim inds As New List(Of Integer)
		For i As Integer = 0 To _state.Shapes.Count - 1
			If _state.Shapes(i).Selected Then inds.Add(i)
		Next
		Return inds
	End Function

	Public Sub SetPrimary() Implements ICanvasInteractionContext.SetPrimary
		_state.Shapes.ForEach(Sub(x) x.Primary = False)
		Dim inds = SelectedIndices()

		If inds.Count > 0 Then
			If _ord = SelectOrder.AboveFirst Then
				_state.Shapes(inds.Last).Primary = True
			Else
				_state.Shapes(inds.First).Primary = True
			End If
		End If
	End Sub

	Public Sub SetPrimaryByIndex(index As Integer) Implements ICanvasInteractionContext.SetPrimaryByIndex
		If index < 0 OrElse index >= _state.Shapes.Count Then Return
		If Not _state.Shapes(index).Selected Then Return
		_state.Shapes.ForEach(Sub(x) x.Primary = False)
		_state.Shapes(index).Primary = True
	End Sub

	Public Sub CaptureMoveSnapshot(indices As List(Of Integer)) Implements ICanvasInteractionContext.CaptureMoveSnapshot
		_state.MoveSnapshot.Clear()
		For Each i In indices
			If i < 0 OrElse i >= _state.Shapes.Count Then Continue For
			_state.MoveSnapshot.Add(New KeyValuePair(Of Shape, RectangleF)(_state.Shapes(i), _state.Shapes(i).GetRect()))
		Next
	End Sub

	Public Sub EnsurePrimarySelected() Implements ICanvasInteractionContext.EnsurePrimarySelected
		Dim inds = SelectedIndices()
		If inds.Count = 0 Then
			_state.Shapes.ForEach(Sub(x) x.Primary = False)
			Return
		End If

		For Each i In inds
			If _state.Shapes(i).Primary Then Return
		Next

		SetPrimary()
	End Sub

	Public Sub DeselectAll() Implements ICanvasInteractionContext.DeselectAll
		_state.Shapes.ForEach(Sub(x) x.Selected = False)
	End Sub

	Public Sub CloneSelected() Implements ICanvasInteractionContext.CloneSelected
		Dim lst_sl As New List(Of Shape)
		For Each i As Integer In SelectedIndices()
			lst_sl.Add(_state.Shapes(i).Clone)
		Next
		DeselectAll()
		For Each sh As Shape In lst_sl
			sh.ReloadCachedObjects()
			_state.Shapes.Add(sh)
		Next
		Invalidate()
	End Sub

	Public Sub DeleteSelected() Implements ICanvasInteractionContext.DeleteSelected
		Dim inds = SelectedIndices()
		For i = inds.Count - 1 To 0 Step -1
			Dim ind = inds(i)
			Dim shp = _state.Shapes(ind)
			shp.Dispose()
			_state.Shapes.RemoveAt(ind)
		Next
		SetPrimary()
		MainForm.UpdateControls()
		Invalidate()
	End Sub

	Public Sub ToBack()
		Dim inds = SelectedIndices()
		If inds.Count = 0 Then Return

		Dim selected As New List(Of Shape)
		For Each i As Integer In inds
			selected.Add(_state.Shapes(i))
		Next

		For i = inds.Count - 1 To 0 Step -1
			_state.Shapes.RemoveAt(inds(i))
		Next

		_state.Shapes.InsertRange(0, selected)
		SetPrimary()
		MainForm.UpdateControls()
		Invalidate()
	End Sub

	Public Sub ToFront()
		Dim inds = SelectedIndices()
		If inds.Count = 0 Then Return

		Dim selected As New List(Of Shape)
		For Each i As Integer In inds
			selected.Add(_state.Shapes(i))
		Next

		For i = inds.Count - 1 To 0 Step -1
			_state.Shapes.RemoveAt(inds(i))
		Next

		_state.Shapes.AddRange(selected)
		SetPrimary()
		MainForm.UpdateControls()
		Invalidate()
	End Sub

	Public Sub FinalizeResize(shp As Shape) Implements ICanvasInteractionContext.FinalizeResize
		Dim fRect = AbsRect(shp.GetRect)
		shp.SetAllRect(fRect)
		If shp.Angle <> 0.0 Then
			Dim _rgRect = New Region(shp.GetRect)
			Dim oMtx = New Matrix
			oMtx.RotateAt(shp.Angle, shp.RotationPoint)
			_rgRect.Transform(oMtx)
			Dim rfNewBounds As RectangleF = _rgRect.GetBounds(CreateGraphics)
			Dim ptNewScreenCenterOrigin As New PointF(rfNewBounds.X + (rfNewBounds.Width / 2), rfNewBounds.Y + (rfNewBounds.Height / 2))
			Dim rcNewRenderRect As New RectangleF(ptNewScreenCenterOrigin.X - (shp.GetRect.Width / 2),
														  ptNewScreenCenterOrigin.Y - (shp.GetRect.Height / 2),
														  shp.GetRect.Width,
														  shp.GetRect.Height)
			shp.SetAllRect(rcNewRenderRect)
			shp.RotationPoint = New PointF(shp.GetRect.X + (shp.GetRect.Width / 2),
					 shp.GetRect.Y + (shp.GetRect.Height / 2))
		End If
	End Sub

	Public Sub ClearData()
		For Each shp As Shape In _state.Shapes
			shp.Dispose()
		Next
	End Sub

	Private Sub SetShapesClipboardData(shapes As List(Of Shape))
		Clipboard.SetData(ShapesClipboardFormat, DrawItJson.Serialize(shapes))
	End Sub

	Private Function GetShapesClipboardData() As List(Of Shape)
		Dim json As String = Nothing
		If Not Clipboard.TryGetData(ShapesClipboardFormat, json) Then Return Nothing
		If String.IsNullOrWhiteSpace(json) Then Return Nothing
		Return DrawItJson.Deserialize(Of List(Of Shape))(json)
	End Function
#End Region

#Region "Anchors"

	Public Enum AnchorType
		None
		TopLeft
		Top
		TopRight
		Left
		Right
		BottomLeft
		Bottom
		BottomRight
		Rotate
		BrushCenter
	End Enum

	Public Function GetAnchorsRegion() As Region Implements ICanvasInteractionContext.GetAnchorsRegion
		SyncSelectedAnnotationScale()
		Dim s_inds = SelectedIndices()
		Dim reg_anc As New Region(RectangleF.Empty)
		If s_inds.Count = 1 Then
			reg_anc.Union(MainSelected.AnchorsPath)
		Else
			Dim boundsAll = MultipleSelectionBounds()
			reg_anc.Union(AnchorBR(boundsAll))
			reg_anc.Union(AnchorB(boundsAll))
			reg_anc.Union(AnchorBL(boundsAll))
			reg_anc.Union(AnchorR(boundsAll))
			reg_anc.Union(AnchorL(boundsAll))
			reg_anc.Union(AnchorTR(boundsAll))
			reg_anc.Union(AnchorT(boundsAll))
			reg_anc.Union(AnchorTL(boundsAll))
		End If
		Using wm As Matrix = GetWorldToScreenMatrix()
			reg_anc.Transform(wm)
		End Using
		Return reg_anc
	End Function

	Private Function IsAnchorPathHit(path As GraphicsPath, pt As PointF) As Boolean
		Return IsPathHit(path, pt)
	End Function

	Public Function GetAnchorType(pt As PointF) As AnchorType Implements ICanvasInteractionContext.GetAnchorType
		SyncSelectedAnnotationScale()
		Dim selc = SelectedIndices()
		If selc.Count = 1 Then
			Dim shp = MainSelected()
			If shp.FBrush.BType = BrushType.PathGradient Then
				Using gp = shp.Centering()
					If IsAnchorPathHit(gp, pt) Then Return AnchorType.BrushCenter
				End Using
			End If
			Using gp = shp.TopLeft()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.TopLeft
			End Using
			Using gp = shp.Top()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Top
			End Using
			Using gp = shp.TopRight()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.TopRight
			End Using
			Using gp = shp.Left()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Left
			End Using
			Using gp = shp.Right()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Right
			End Using
			Using gp = shp.BottomLeft()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.BottomLeft
			End Using
			Using gp = shp.Bottom()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Bottom
			End Using
			Using gp = shp.BottomRight()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.BottomRight
			End Using
			Using gp = shp.Rotate()
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Rotate
			End Using
		Else
			Dim boundsAll = MultipleSelectionBounds()
			Using gp = AnchorTL(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.TopLeft
			End Using
			Using gp = AnchorT(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Top
			End Using
			Using gp = AnchorTR(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.TopRight
			End Using
			Using gp = AnchorL(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Left
			End Using
			Using gp = AnchorR(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Right
			End Using
			Using gp = AnchorBL(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.BottomLeft
			End Using
			Using gp = AnchorB(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.Bottom
			End Using
			Using gp = AnchorBR(boundsAll)
				If IsAnchorPathHit(gp, pt) Then Return AnchorType.BottomRight
			End Using
			End If
		Return AnchorType.None
	End Function

	Public Function AnchorTL(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.X - anc.Width, r.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X += anc.Width / 2
			rect.Y += anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorT(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.X + (r.Width / 2) - (anc.Width / 2), r.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.Y += anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorTR(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.Right, r.Y - anc.Height, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X -= anc.Width / 2
			rect.Y += anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorL(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.X - anc.Width, r.Y + (r.Height / 2) - (anc.Height / 2), anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X += anc.Width / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorR(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.Right, r.Y + (r.Height / 2) - (anc.Height / 2), anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X -= anc.Width / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorBL(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.X - anc.Width, r.Bottom, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X += anc.Width / 2
			rect.Y -= anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorB(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.X + (r.Width / 2) - (anc.Width / 2), r.Bottom, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.Y -= anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorBR(r As RectangleF) As GraphicsPath
		Dim anc As SizeF
		Dim minHandleDistance As Single
		GetAnchorMetrics(anc, minHandleDistance)
		Dim rect As New RectangleF(r.Right, r.Bottom, anc.Width, anc.Height)
		If Math.Abs(r.Width) > minHandleDistance AndAlso Math.Abs(r.Height) > minHandleDistance Then
			rect.X -= anc.Width / 2
			rect.Y -= anc.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

#End Region

#Region "Interaction Controller"
	Private ReadOnly Property InteractionState As CanvasStateManager Implements ICanvasInteractionContext.State
		Get
			Return _state
		End Get
	End Property

	Private Property InteractionCanvasCursor As Cursor Implements ICanvasInteractionContext.CanvasCursor
		Get
			Return Cursor
		End Get
		Set(value As Cursor)
			Cursor = value
		End Set
	End Property

	Private ReadOnly Property InteractionHighlightShapesEnabled As Boolean Implements ICanvasInteractionContext.HighlightShapesEnabled
		Get
			Return HighlightShapes
		End Get
	End Property

	Private Sub InvalidateCanvas() Implements ICanvasInteractionContext.InvalidateCanvas
		Invalidate()
	End Sub

	Private Sub UpdateControls() Implements ICanvasInteractionContext.UpdateControls
		MainForm.UpdateControls()
	End Sub

	Private Sub UpdateBoundControls() Implements ICanvasInteractionContext.UpdateBoundControls
		MainForm.UpdateBoundControls()
	End Sub

	Private Sub SwitchToSelectMode() Implements ICanvasInteractionContext.SwitchToSelectMode
		MainForm.rSelect.Checked = True
	End Sub

	Private Sub Canvas_MouseDown_Dispatch(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		_interactionController.HandleMouseDown(Me, e)
	End Sub

	Private Sub Canvas_MouseMove_Dispatch(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		_interactionController.HandleMouseMove(Me, e)
	End Sub

	Private Sub Canvas_MouseUp_Dispatch(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		_interactionController.HandleMouseUp(Me, e)
	End Sub

	Private Sub Canvas_MouseLeave_Dispatch(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		_interactionController.HandleMouseLeave(Me)
	End Sub
#End Region

#Region "Paint Event"

	Private Sub DrawSize(g As Graphics, shp As Shape, Optional _horz As Boolean = True, Optional _vert As Boolean = True)
		g.PixelOffsetMode = PixelOffsetMode.Default
		Dim annScale = AnnotationScaleCompensation()
		Select Case shp.Angle
			Case 0, 90, 180, 270, 360
				g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
			Case Else
				g.TextRenderingHint = TextRenderingHint.AntiAlias
		End Select
		Dim rt As RectangleF = AbsRect(shp.GetRect)
		Dim sf As New StringFormat With {
			.Alignment = StringAlignment.Center,
			.LineAlignment = StringAlignment.Center
		}
		Dim fnt As New Font("Arial", 10 * annScale)
		If _horz Then
			Dim t_horz As String = Math.Round(Math.Abs(shp.BaseWidth), 2)
			Dim s_horz As SizeF = g.MeasureString(t_horz, fnt)
			Dim r_horz As New RectangleF(New PointF(rt.Right - s_horz.Width, rt.Bottom + (2 * annScale)), s_horz)
			g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.White)), r_horz)
			g.DrawString(t_horz, fnt, New SolidBrush(clr_sz), r_horz, sf)
			If rt.Width > r_horz.Width Then
				Dim p1 As New PointF(rt.X, r_horz.Y + (r_horz.Height / 2))
				Dim p2 As New PointF(r_horz.Left - (1 * annScale), p1.Y)
				Using pn As New Pen(clr_sz, AnnotationPenWidth())
					g.DrawLine(pn, p1, p2)
				End Using
			End If
		End If
		If _vert Then
			sf.FormatFlags = StringFormatFlags.DirectionVertical
			Dim t_vert As String = Math.Round(Math.Abs(shp.BaseHeight), 2)
			Dim s_vert As SizeF = g.MeasureString(t_vert, fnt)
			Dim r_vert As New RectangleF(New PointF(rt.Right + (2 * annScale), rt.Top), New SizeF(s_vert.Height, s_vert.Width))
			g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.White)), r_vert)
			g.DrawString(t_vert, fnt, New SolidBrush(clr_sz), r_vert, sf)
			If rt.Height > r_vert.Height Then
				Dim p1 As New PointF(r_vert.X + (r_vert.Width / 2), r_vert.Bottom + (1 * annScale))
				Dim p2 As New PointF(p1.X, rt.Bottom)
				Using pn As New Pen(clr_sz, AnnotationPenWidth())
					g.DrawLine(pn, p1, p2)
				End Using
			End If
		End If
		sf.Dispose()
		fnt.Dispose()
		g.PixelOffsetMode = PixelOffsetMode.HighQuality
	End Sub

	Private Sub DrawAnchorEllipse(g As Graphics, rect As RectangleF)
		rect.Inflate(AnnotationScaleCompensation(), AnnotationScaleCompensation())
		g.FillEllipse(New SolidBrush(Color.FromArgb(180, Color.Lime)), rect)
		Using pn As New Pen(Color.Black, AnnotationPenWidth())
			g.DrawEllipse(pn, rect)
		End Using
	End Sub

	Private Sub CreateGlow(g As Graphics, shp As Shape)
		Dim pth As GraphicsPath = shp.TotalPath(False)
		If IsNothing(pth) Then Return
		pth = pth.Clone

		If shp.Glow.GStyle = GlowStyle.OnBorder Then
			If Not IsNothing(shp.SelectionPen) Then pth.Widen(shp.SelectionPen)
		End If

		If shp.Glow.GClip = GlowClip.Outside Then
			Dim rg As New Region(ClientRectangle)
			rg.Exclude(pth)
			g.Clip = rg
			rg.Dispose()
		ElseIf shp.Glow.GClip = GlowClip.Inside Then
			Dim rg As New Region(pth)
			g.Clip = rg
			rg.Dispose()
		End If

		For i As Integer = 1 To shp.Glow.Radius Step 2
			Dim aGlow As Integer = shp.Glow.Strength - (shp.Glow.Strength / shp.Glow.Radius * i)
			Using pen As New Pen(Color.FromArgb(aGlow, shp.Glow.GlowColor), i) With
				{.LineJoin = LineJoin.Round, .StartCap = ToLineCap(shp.DPen.PStartCap), .EndCap = ToLineCap(shp.DPen.PEndCap)}
				g.DrawPath(pen, pth)
			End Using
		Next i

		pth.Dispose()

		If shp.Glow.GClip <> GlowClip.None Then g.ResetClip()

	End Sub

	Private Sub CreateShadow(g As Graphics, shp As Shape)
		Dim temp_s = shp.Clone
		Dim temp_r As New RectangleF(shp.GetRect.X + shp.Shadow.Offset.X, shp.GetRect.Y + shp.Shadow.Offset.Y,
									 shp.GetRect.Width, shp.GetRect.Height)
		temp_s.SetAllRect(temp_r)
		Dim pth As GraphicsPath = temp_s.TotalPath(False)
		If IsNothing(pth) Then Return

		If shp.Shadow.RegionClipping Then
			Dim rg As New Region(ClientRectangle)
			rg.Exclude(shp.TotalPath(False))
			g.Clip = rg
			rg.Dispose()
		End If

		For i As Integer = 1 To shp.Shadow.Radius
			Dim aGlow As Integer = shp.Shadow.Strength - (shp.Shadow.Strength / shp.Shadow.Radius * i)
			Using pen As New Pen(Color.FromArgb(aGlow, shp.Shadow.ShadowColor), i) With
				{.LineJoin = LineJoin.Round, .StartCap = ToLineCap(shp.DPen.PStartCap), .EndCap = ToLineCap(shp.DPen.PEndCap)}
				g.DrawPath(pen, pth)
			End Using
		Next i

		If shp.Shadow.Fill Then g.FillPath(New SolidBrush(shp.Shadow.ShadowColor), pth)

		pth.Dispose()
		temp_s.Dispose()

		If shp.Shadow.RegionClipping Then g.ResetClip()

	End Sub

	Private Sub DrawPathPoint(g As Graphics, pth As GraphicsPath)
		For i As Integer = 0 To pth.PointCount - 1
			Dim _point = pth.PathData.Points(i)
			Dim _type = pth.PathData.Types(i)
			Dim clr As Color = Color.FromArgb(150, Color.Red)
			Select Case _type
				Case 1, 129
					clr = Color.FromArgb(150, Color.Red)
				Case 3, 131
					clr = Color.FromArgb(150, Color.Blue)
			End Select

			Dim ptrect = New RectangleF(_point, SizeF.Empty)
			ptrect.Inflate(10, 10)
			Dim ptpath = New GraphicsPath()
			ptpath.AddEllipse(ptrect)
			Dim brsh As New SolidBrush(clr)
			g.FillPath(brsh, ptpath)

			ptrect.Inflate(50, 50)

			Using sf As New StringFormat()
				sf.Alignment = StringAlignment.Center
				sf.LineAlignment = StringAlignment.Center
				Dim fnt As New Font("Segoe UI", 10, FontStyle.Bold)
				g.DrawString(_type.ToString, fnt, Brushes.Black, ptrect, sf)
				fnt.Dispose()
			End Using

			ptpath.Dispose()
			brsh.Dispose()

		Next
	End Sub

	Private Sub DrawShape(g As Graphics, shp As Shape)
		g.PixelOffsetMode = PixelOffsetMode.HighSpeed
		g.RenderingOrigin = Point.Ceiling(shp.GetRect.Location)

		Dim originalTransform As Matrix = g.Transform.Clone()
		Try
			Using mm As New Matrix
				mm.RotateAt(shp.Angle, shp.RotationPoint)
				Using finalTransform = originalTransform.Clone()
					finalTransform.Multiply(mm, MatrixOrder.Prepend)
					g.Transform = finalTransform
				End Using
			End Using

			If shp.Shadow.Enabled Then CreateShadow(g, shp)
			If shp.Glow.Enabled AndAlso shp.Glow.BeforeFill Then CreateGlow(g, shp)

			'Fill and Draw Shape
			Dim pth As GraphicsPath = shp.TotalPath(False)
			Dim fbr As Brush = shp.FillBrush
			Dim dpn As Pen = shp.CreatePen()

			If IsNothing(pth) Then Return

			'DrawPathPoint(ig, pth)
			If Not IsNothing(fbr) Then
				g.RenderingOrigin = Point.Ceiling(pth.GetBounds.Location)
				g.FillPath(fbr, pth)
			End If
			If Not IsNothing(dpn) Then
				Using ppth As GraphicsPath = pth.Clone
					If Not IsNothing(shp.SelectionPen) Then ppth.Widen(shp.SelectionPen)
					g.RenderingOrigin = Point.Ceiling(ppth.GetBounds.Location)
				End Using
				g.DrawPath(dpn, pth)
				dpn.Dispose()
			End If
			pth.Dispose()

			If shp.Glow.Enabled AndAlso Not shp.Glow.BeforeFill Then CreateGlow(g, shp)
		Finally
			g.Transform = originalTransform
			originalTransform.Dispose()
		End Try
	End Sub

	Private Sub DrawShapeAnchors(g As Graphics, shp As Shape)
		shp.AnchorScale = AnnotationScaleCompensation()
		Dim originalTransform As Matrix = g.Transform.Clone()
		Try
			Using mm As New Matrix
				mm.RotateAt(shp.Angle, shp.RotationPoint)
				Using finalTransform = originalTransform.Clone()
					finalTransform.Multiply(mm, MatrixOrder.Prepend)
					g.Transform = finalTransform
				End Using
			End Using

			If _state.CurrentOperation = MOperations.Draw Or _state.CurrentOperation = MOperations.Selection Or _state.CurrentOperation = MOperations.None Or (_state.CurrentOperation >= MOperations.TopLeft And _state.CurrentOperation <= MOperations.BottomRight) Then
				Using pth_brd As New GraphicsPath
					pth_brd.AddRectangle(AbsRect(shp.GetRect))
					Dim pn_brd As New Pen(Brushes.Black, AnnotationPenWidth()) With {
						.DashPattern = New Single() {2, 2, 3}
					}
					g.DrawPath(pn_brd, pth_brd)
					pn_brd.Dispose()
				End Using
			End If

			g.PixelOffsetMode = PixelOffsetMode.HighQuality

			Select Case _state.CurrentOperation
				Case MOperations.None, MOperations.Draw, MOperations.Selection
					Dim br As New SolidBrush(Color.White)
					Dim pn As New Pen(Color.Black, AnnotationPenWidth())

					'Create anchors list
					Dim _anchors As New List(Of GraphicsPath)
					If shp.FBrush.BType = BrushType.PathGradient Then _anchors.Add(shp.Centering(False))
					_anchors.AddRange({
					shp.Rotate(False),
					shp.BottomRight(False),
					shp.Bottom(False),
					shp.BottomLeft(False),
					shp.Right(False),
					shp.Left(False),
					shp.TopRight(False),
					shp.Top(False),
					shp.TopLeft(False)
					})

					'Draw all anchors
					_anchors.ForEach(Sub(gp)
									 g.FillPath(br, gp)
									 g.DrawPath(pn, gp)
								 End Sub)

					br.Dispose()

					'Draw Rotation Anchor Line
					Dim pt1 As New PointF(shp.Top(False).GetBounds().X + (shp.Top(False).GetBounds().Width / 2),
					 shp.Top(False).GetBounds().Top)
					Dim pt2 As New PointF(shp.Rotate(False).GetBounds().X + (shp.Rotate(False).GetBounds().Width / 2),
					 shp.Rotate(False).GetBounds().Bottom)
					g.DrawLine(pn, pt1, pt2)

					pn.Dispose()

				Case MOperations.TopLeft
					DrawSize(g, shp)
					DrawAnchorEllipse(g, shp.TopLeft(False).GetBounds)

				Case MOperations.TopRight
					DrawSize(g, shp)
					DrawAnchorEllipse(g, shp.TopRight(False).GetBounds)

				Case MOperations.BottomLeft
					DrawSize(g, shp)
					DrawAnchorEllipse(g, shp.BottomLeft(False).GetBounds)

				Case MOperations.BottomRight
					DrawSize(g, shp)
					DrawAnchorEllipse(g, shp.BottomRight(False).GetBounds)

				Case MOperations.Top
					DrawSize(g, shp, False)
					DrawAnchorEllipse(g, shp.Top(False).GetBounds)

				Case MOperations.Bottom
					DrawSize(g, shp, False)
					DrawAnchorEllipse(g, shp.Bottom(False).GetBounds)

				Case MOperations.Left
					DrawSize(g, shp,, False)
					DrawAnchorEllipse(g, shp.Left(False).GetBounds)

				Case MOperations.Right
					DrawSize(g, shp,, False)
					DrawAnchorEllipse(g, shp.Right(False).GetBounds)

				Case MOperations.Rotate
					DrawAnchorEllipse(g, shp.Rotate(False).GetBounds)
					Dim dist As Single = shp.GetRect.Height / 2
					Dim rectt As New RectangleF(shp.RotationPoint, SizeF.Empty)
					rectt.Inflate(dist, dist)

					'Draw angle helper in canvas space (zoom/pan only, no shape rotation).
					g.Transform = originalTransform
					Using pnt As New Pen(Color.FromArgb(120, Color.Black), 5 * AnnotationScaleCompensation())
						pnt.DashStyle = DashStyle.DashDot
						pnt.DashCap = DashCap.Round
						g.DrawEllipse(pnt, rectt)
					End Using
					Dim minAnnotDisplay = 25 * AnnotationScaleCompensation()
					If shp.GetRect.Width >= minAnnotDisplay AndAlso shp.GetRect.Height >= minAnnotDisplay Then
						Using sf As New StringFormat()
							sf.Alignment = StringAlignment.Center
							sf.LineAlignment = StringAlignment.Center
							Dim fnt As New Font("Consolas", 13 * AnnotationScaleCompensation())
							g.DrawString(shp.Angle.ToString, fnt, Brushes.Black, shp.GetRect, sf)
							fnt.Dispose()
						End Using
					End If
			End Select

			g.PixelOffsetMode = PixelOffsetMode.HighSpeed

		Finally
			g.Transform = originalTransform
			originalTransform.Dispose()
		End Try
	End Sub

	Private Sub DrawMultipleSelectionAnchors(g As Graphics)
		Dim boundsAll = MultipleSelectionBounds()

		If _state.CurrentOperation = MOperations.Draw Or _state.CurrentOperation = MOperations.Selection Or _state.CurrentOperation = MOperations.None Or (_state.CurrentOperation >= MOperations.TopLeft And _state.CurrentOperation <= MOperations.BottomRight) Then
			Using pth_brd As New GraphicsPath
				pth_brd.AddRectangle(boundsAll)
				Dim pn_brd As New Pen(Brushes.Black, AnnotationPenWidth()) With {
					.DashPattern = New Single() {2, 2, 3}
				}
				g.DrawPath(pn_brd, pth_brd)
				pn_brd.Dispose()
			End Using
		End If

		g.PixelOffsetMode = PixelOffsetMode.HighQuality

		Select Case _state.CurrentOperation
			Case MOperations.None, MOperations.Draw, MOperations.Selection
				Dim bounds_br As New SolidBrush(Color.White)
				Dim bounds_pn As New Pen(Color.Black, AnnotationPenWidth())

				'Create anchors list
				Dim _anchors As New List(Of GraphicsPath)
				_anchors.AddRange({
					AnchorBR(boundsAll),
					AnchorB(boundsAll),
					AnchorBL(boundsAll),
					AnchorR(boundsAll),
					AnchorL(boundsAll),
					AnchorTR(boundsAll),
					AnchorT(boundsAll),
					AnchorTL(boundsAll)
				})

				'Draw all anchors
				_anchors.ForEach(Sub(gp)
									 g.FillPath(bounds_br, gp)
									 g.DrawPath(bounds_pn, gp)
								 End Sub)

				bounds_br.Dispose()
				bounds_pn.Dispose()
		End Select

		g.PixelOffsetMode = PixelOffsetMode.HighSpeed
	End Sub

	Private Sub DrawPrimarySelectionMarker(g As Graphics, shp As Shape)
		Dim scale = AnnotationScaleCompensation()
		Dim rect = AbsRect(shp.GetRect)
		Dim margin = 6.0F * scale
		Dim badgeSize = 16.0F * scale
		Dim badgeRect As New RectangleF(rect.X + margin, rect.Y + margin, badgeSize, badgeSize)

		Using fill As New SolidBrush(Color.FromArgb(210, Color.Gold))
			g.FillEllipse(fill, badgeRect)
		End Using
		Using border As New Pen(Color.Black, AnnotationPenWidth())
			g.DrawEllipse(border, badgeRect)
		End Using
		Using sf As New StringFormat()
			sf.Alignment = StringAlignment.Center
			sf.LineAlignment = StringAlignment.Center
			Using fnt As New Font("Consolas", 8.0F * scale, FontStyle.Bold)
				g.DrawString("P", fnt, Brushes.Black, badgeRect, sf)
			End Using
		End Using
	End Sub

	Private Function CreateImage() As Bitmap
		Dim img As Bitmap

		If Not IsNothing(BackgroundImage) Then
			img = New Bitmap(BackgroundImage, AbsSize.Width, AbsSize.Height)
		Else
			img = New Bitmap(AbsSize.Width, AbsSize.Height)
		End If

		Using ig As Graphics = Graphics.FromImage(img)

			ig.SmoothingMode = SmoothingMode.HighQuality
			ig.TextRenderingHint = TextRenderingHint.AntiAlias

			'Painting background color
			ig.Clear(BackColor)

			Dim temp_shp As New List(Of Shape)
			'Draw all shapes on image
			_state.Shapes.ForEach(Sub(shp) temp_shp.Add(shp.Clone))
			temp_shp.ForEach(Sub(shp)
									 shp.ReloadCachedObjects()
								 DrawShape(ig, shp)
							 End Sub)

		End Using

		Return img
	End Function

	Private Sub DrawHighlightedShape(g As Graphics)
		If _state.Hover.ShapeIndex > -1 And _state.Hover.ShapeIndex < _state.Shapes.Count Then
			Using pn As New Pen(hg_pth)
				If _state.Hover.HoverType = 1 Then pn.Color = hg_brd
				g.DrawPath(pn, _state.Shapes(_state.Hover.ShapeIndex).TotalPath())
			End Using
		End If
	End Sub

	Private Sub DrawSelectorRectangle(g As Graphics)
		If _state.SelectionRect.Width > 0 AndAlso _state.SelectionRect.Height > 0 Then
			Dim screenRect = ToScreenRect(_state.SelectionRect)
			Using pth As New GraphicsPath()
				pth.AddRectangle(screenRect)
				Using pn As New Pen(clr_sel)
					Using sld As New SolidBrush(Color.FromArgb(50, clr_sel))
						g.FillPath(sld, pth)
						g.DrawPath(pn, pth)
					End Using
				End Using
			End Using
		End If
	End Sub

	Private Sub RenderDrawingModeData(g As Graphics)
		If _state.DrawInfo.DrawMode Then
			For i As Integer = 0 To _state.DrawInfo.Points.Count - 1
				g.FillPath(New SolidBrush(Color.FromArgb(180, Color.Black)),
						   DPPath(i))
			Next

			Dim d_lim As Integer = DModeMin()
			If Not _state.CurrentLocation = PointF.Empty Then d_lim -= 1

			If _state.DrawInfo.Points.Count >= d_lim Then
				Dim d_pts As New List(Of PointF)
				_state.DrawInfo.Points.ForEach(Sub(pt)
										  d_pts.Add(pt)
									  End Sub)
				If Not _state.CurrentLocation = PointF.Empty Then d_pts.Add(_state.CurrentLocation)
				Using d_pen As New Pen(Color.Black)
					If _state.DrawInfo.Points.Count < DModeMin() Then d_pen.DashPattern = New Single() {8, 4}
					Select Case _state.DrawInfo.ShapeType
						Case DShape.Lines
							g.DrawLines(d_pen, d_pts.ToArray)
						Case DShape.Polygon
							g.DrawPolygon(d_pen, d_pts.ToArray)
						Case DShape.Curves
							g.DrawCurve(d_pen, d_pts.ToArray)
						Case DShape.ClosedCurve
							g.DrawClosedCurve(d_pen, d_pts.ToArray)
					End Select
				End Using
			End If
		End If
	End Sub

	Private Sub Canvas_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		Dim g As Graphics = e.Graphics
		g.SmoothingMode = SmoothingMode.HighQuality
		g.TextRenderingHint = TextRenderingHint.AntiAlias

		g.Clear(SystemColors.ControlDarkDark)
		Dim artboardScreenRect = Rectangle.Round(GetArtboardScreenRect())
		artboardScreenRect.Inflate(20, 20)
		Using borderPen As New Pen(Color.RoyalBlue, 1.0F)
			g.DrawRectangle(borderPen, artboardScreenRect)
		End Using

		Dim centerOffset = GetViewportCenterOffset()
		g.Transform = ZoomPanMath.CreateWorldToScreenMatrix(PanOffset, centerOffset, Zoom)

		Dim artboard = GetArtboardRect()
		Using artBrush As New SolidBrush(BackColor)
			g.FillRectangle(artBrush, artboard)
		End Using
		If Not IsNothing(BackgroundImage) Then
			g.DrawImage(BackgroundImage, artboard)
		End If

		Dim selc = SelectedIndices()
		Dim prm As Shape = MainSelected()

		'Draw all shapes on image
		_state.Shapes.ForEach(Sub(shp)
						 DrawShape(g, shp)
					 End Sub)

		If selc.Count = 1 AndAlso Not IsNothing(prm) Then DrawShapeAnchors(g, prm)
		If selc.Count > 1 Then
			DrawMultipleSelectionAnchors(g)
			If Not IsNothing(prm) Then DrawPrimarySelectionMarker(g, prm)
		End If

		RenderDrawingModeData(g)

		DrawHighlightedShape(g)
		g.ResetTransform()
		DrawSelectorRectangle(g)

		'Paint anchors region
		'Dim rgg = GetAnchorsRegion()
		'If Not IsNothing(rgg) Then
		'    Dim brshh As New SolidBrush(Color.FromArgb(100, 255, 0, 0))
		'    g.FillRegion(brshh, rgg)
		'End If

		'Draw border
		'Dim rt As Rectangle = ClientRectangle
		'rt.Width -= 1 : rt.Height -= 1
		'g.DrawRectangle(Pens.Black, rt)

		'Force Garbage Collection
		'If Not IsDesignMode() Then GC.Collect()

	End Sub

#End Region

#Region "KeyBoard Event"
	Protected Overrides Function IsInputKey(keyData As Keys) As Boolean
		Select Case keyData
			Case Keys.Left, Keys.Right, Keys.Up, Keys.Down,
				 Keys.Shift Or Keys.Left, Keys.Shift Or Keys.Right,
				 Keys.Shift Or Keys.Up, Keys.Shift Or Keys.Down,
				 Keys.Tab, Keys.Shift Or Keys.Tab
				Return True
			Case Else
				Return MyBase.IsInputKey(keyData)
		End Select
	End Function

	Private Sub Canvas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		Select Case e.KeyData
			Case Keys.Delete
				DeleteSelected()
			Case Keys.Tab
				Dim shp As Shape = MainSelected()
				If Not IsNothing(shp) Then
					Dim ind As Integer = _state.Shapes.IndexOf(shp)
					If ind < _state.Shapes.Count - 1 Then
						DeselectAll()
						_state.Shapes(ind + 1).Selected = True
						SetPrimary()
					End If
				End If
			Case Keys.Shift Or Keys.Tab
				Dim shp As Shape = MainSelected()
				If Not IsNothing(shp) Then
					Dim ind As Integer = _state.Shapes.IndexOf(shp)
					If ind > 0 Then
						DeselectAll()
						_state.Shapes(ind - 1).Selected = True
						SetPrimary()
					End If
				End If
			Case Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseX -= 1
				Next
			Case Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseX += 1
				Next
			Case Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseY -= 1
				Next
			Case Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseY += 1
				Next
			Case Keys.Control Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					If shp.BaseWidth > 1 Then
						shp.BaseWidth -= 1
					End If
				Next
			Case Keys.Control Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseWidth += 1
				Next
			Case Keys.Control Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					If shp.BaseHeight > 1 Then
						shp.BaseHeight -= 1
					End If
				Next
			Case Keys.Control Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseHeight += 1
				Next
			Case Keys.Shift Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseX -= 1
					shp.BaseWidth += 1
				Next
			Case Keys.Shift Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					If shp.BaseWidth > 1 Then
						shp.BaseX += 1
						shp.BaseWidth -= 1
					End If
				Next
			Case Keys.Shift Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					shp.BaseY -= 1
					shp.BaseHeight += 1
				Next
			Case Keys.Shift Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					If shp.BaseHeight > 1 Then
						shp.BaseY += 1
						shp.BaseHeight -= 1
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					Dim rect As RectangleF = shp.GetRect
					If rect.Width > 2 Then
						rect.Inflate(-1, 0)
						shp.SetAllRect(rect)
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					Dim rect As RectangleF = shp.GetRect
					rect.Inflate(1, 0)
					shp.SetAllRect(rect)
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					Dim rect As RectangleF = shp.GetRect
					If rect.Width > 2 Then
						rect.Inflate(0, -1)
						shp.SetAllRect(rect)
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = _state.Shapes(i)
					Dim rect As RectangleF = shp.GetRect
					rect.Inflate(0, 1)
					shp.SetAllRect(rect)
				Next
			Case Keys.Control Or Keys.A
				For Each shp As Shape In _state.Shapes
					shp.Selected = True
				Next
				SetPrimary()
			Case Keys.Control Or Keys.C
				Dim _lst As New List(Of Shape)
				For Each i As Integer In SelectedIndices()
					_lst.Add(_state.Shapes(i).Clone)
				Next
				SetShapesClipboardData(_lst)
			Case Keys.Control Or Keys.X
				Dim _lst As New List(Of Shape)
				For Each i As Integer In SelectedIndices()
					_lst.Add(_state.Shapes(i).Clone)
				Next
				DeleteSelected()
				SetShapesClipboardData(_lst)
			Case Keys.Control Or Keys.V
				DeselectAll()
				Dim _lst = GetShapesClipboardData()
				If IsNothing(_lst) Then Return
				For Each shp As Shape In _lst
					shp.BindEvents()
					shp.ReloadCachedObjects()
					_state.Shapes.Add(shp)
				Next
				SetPrimary()
		End Select
		MainForm.UpdateControls()
		Invalidate()
	End Sub

	Private Sub Canvas_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		Select Case e.KeyData
			Case Keys.Control Or Keys.Left, Keys.Control Or Keys.Right,
				 Keys.Control Or Keys.Up, Keys.Control Or Keys.Down,
				 Keys.Shift Or Keys.Left, Keys.Shift Or Keys.Right,
				 Keys.Shift Or Keys.Up, Keys.Shift Or Keys.Down,
				 Keys.Shift Or Keys.Control Or Keys.Left,
				 Keys.Shift Or Keys.Control Or Keys.Right,
				 Keys.Shift Or Keys.Control Or Keys.Up,
				 Keys.Shift Or Keys.Control Or Keys.Down,
				 Keys.Left, Keys.Right, Keys.Up, Keys.Down
				SelectedIndices.ForEach(Sub(i) FinalizeResize(_state.Shapes(i)))
				MainForm.UpdateControls()
				Invalidate()
		End Select
	End Sub

#End Region

#Region "Focus"
	Private Sub Canvas_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
		_state.FocusColor = Color.Silver
		Invalidate()
	End Sub

	Private Sub Canvas_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
		_state.FocusColor = Color.LightGray
		Invalidate()
	End Sub

#End Region

End Class

#Region "Project Data Class"

<Serializable>
Public Class ProjectData

	Public Sub New()

	End Sub

	Public Sub New(shp As List(Of Shape), sz As Size, clr As Color, img As Image)
		_shps = shp
		_size = sz
		_bclr = clr
		_bimg = img
	End Sub

	Private _shps As List(Of Shape) = New List(Of Shape)
	Public Property Shapes() As List(Of Shape)
		Get
			Return _shps
		End Get
		Set(ByVal value As List(Of Shape))
			_shps = value
		End Set
	End Property

	Private _size As Size = Size.Empty
	Public Property Size() As Size
		Get
			Return _size
		End Get
		Set(ByVal value As Size)
			_size = value
		End Set
	End Property

	Private _bclr As Color = Color.Transparent
	Public Property BackgroundColor() As Color
		Get
			Return _bclr
		End Get
		Set(ByVal value As Color)
			_bclr = value
		End Set
	End Property

	Private _bimg As Image = Nothing
	Public Property BackgroundImage() As Image
		Get
			Return _bimg
		End Get
		Set(ByVal value As Image)
			_bimg = value
		End Set
	End Property

End Class

#End Region

