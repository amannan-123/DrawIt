#Region "Imports"
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports System.Xml
Imports DrawIt.Models
Imports JSONHelpers
#End Region

Public Class Canvas

#Region "New"
	Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		SetStyle(ControlStyles.ResizeRedraw, True)
		SetStyle(ControlStyles.UserMouse, True)
		SetStyle(ControlStyles.UserPaint, True)
	End Sub

	Sub New(frm As MainForm)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SetStyle(ControlStyles.AllPaintingInWmPaint, True)
		SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		SetStyle(ControlStyles.ResizeRedraw, True)
		SetStyle(ControlStyles.UserMouse, True)
		SetStyle(ControlStyles.UserPaint, True)
	End Sub
#End Region

#Region "Structs & Enums"
	Private Structure HoverInfo

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

	End Structure

	Private Structure DrawModeInfo

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

	End Structure

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
	Private shps As New List(Of Shape)
	Private op As MOperations = MOperations.None
	Private focus_clr As Color = Color.Silver
	'selection
	Private cloned As Boolean = False
	Private cloning As Boolean = False
	Private up_fix As Boolean = True
	Private md_pt As Point
	Private m_cnt As PointF
	Private m_ang As Single
	Private ReadOnly old_sl As New List(Of Integer)
	Private ReadOnly mv_rect As New List(Of RectangleF)
	Private ReadOnly res_rect As New List(Of RectangleF)
	Private res_bounds As RectangleF
	Private s_rect As New RectangleF
	Private h_info As New HoverInfo(-1, 0)
	Private _negX As Boolean = False
	Private _negY As Boolean = False
	Private m_down As Boolean = False
	Private m_pt As Point
	'drawing
	Private d_info As New DrawModeInfo(False)
	Private curr_loc As Point = Point.Empty
#End Region

#Region "Properties"

	Private _zoom As Single = 1.0F
	Public Property Zoom() As Single
		Get
			Return _zoom
		End Get
		Set(ByVal value As Single)
			If value <> _zoom Then
				value = Math.Max(0.2, value)
				value = Math.Min(10, value)
				_zoom = value
				shps.ForEach(Sub(x)
								 x.Zoom = _zoom
							 End Sub)
				FixSize()
				MainForm.UpdateSettings()
			End If
		End Set
	End Property

	Private _absSize As New Size(500, 500)
	Public Property AbsSize() As Size
		Get
			Return _absSize
		End Get
		Set(ByVal value As Size)
			_absSize = value
			FixSize()
			If Not IsNothing(MainCanvasControl) Then MainCanvasControl.SetSize()
		End Set
	End Property

	Public Sub FixSize()
		SuspendLayout()
		Width = _absSize.Width * Zoom
		Height = _absSize.Height * Zoom
		ResumeLayout()
	End Sub

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
			Dim stream As FileStream = File.Create(_loc)
			stream.Close()
			Dim options = New JsonSerializerOptions With
							{
								.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
								.IgnoreReadOnlyProperties = True,
								.WriteIndented = True
							}
			options.Converters.Add(New JsonStringEnumConverter())
			options.Converters.Add(New JSONColorConverter())
			options.Converters.Add(New JSONImageConverter())
			Dim jsonString = JsonSerializer.Serialize(New ProjectData(shps, AbsSize, BackColor, BackgroundImage), options)
			File.WriteAllText(_loc, jsonString)
		Catch ex As Exception
			Return ex
		End Try
		Return Nothing
	End Function

	Public Function LoadProject(_loc As String) As Exception
		Try
			Dim jsonString = File.ReadAllText(_loc)
			Dim options = New JsonSerializerOptions With
						  {
							.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
							.IgnoreReadOnlyProperties = True,
							.WriteIndented = True
						  }
			options.Converters.Add(New JsonStringEnumConverter())
			options.Converters.Add(New JSONColorConverter())
			options.Converters.Add(New JSONImageConverter())
			Dim des_data = JsonSerializer.Deserialize(Of ProjectData)(jsonString, options)
			shps = des_data.Shapes
			BackColor = des_data.BackgroundColor
			BackgroundImage = des_data.BackgroundImage
			AbsSize = des_data.Size
			shps.ForEach(Sub(x)
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
	Private Function MultipleSelectionBounds() As RectangleF
		Dim rg As New Region(RectangleF.Empty)
		SelectedIndices.ForEach(Sub(shp)
									Dim pth = shps(shp).TotalPath
									If Not IsNothing(pth) Then rg.Union(pth)
								End Sub)
		Return rg.GetBounds(CreateGraphics)
	End Function

	Public Sub ClearDrawingData()
		d_info.DrawMode = False
		d_info.Points.Clear()
		curr_loc = Point.Empty
	End Sub

	Private Function DModeMin() As Integer
		Select Case d_info.ShapeType
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
		Dim rt As New RectangleF(d_info.Points(ind), SizeF.Empty)
		rt.Inflate(5, 5)
		Dim pth As New GraphicsPath()
		pth.AddEllipse(rt)
		Return pth
	End Function

	Private Function DPInCursor(ept As Point) As Integer
		For i As Integer = d_info.Points.Count - 1 To 0 Step -1
			If DPPath(i).IsVisible(ept) Then
				Return i
			End If
		Next
		Return -1
	End Function

	Public Function ShapeInCursor(_loc As Point) As Integer
		Dim ind As Integer = -1
		If shps.Count = 0 Then Return ind
		For Each shp As Shape In shps
			Dim shp_rg = shp.Region()
			If Not IsNothing(shp_rg) AndAlso shp_rg.IsVisible(_loc) Then
				If _ord = SelectOrder.AboveFirst Then
					ind = shps.IndexOf(shp)
				Else
					Return shps.IndexOf(shp)
				End If
			End If
		Next
		Return ind
	End Function

	Public Function MainSelected() As Shape
		Dim inds = SelectedIndices()
		Dim shp As Shape = Nothing
		If inds.Count > 0 Then
			If _ord = SelectOrder.AboveFirst Then
				shp = shps(inds.Last)
			Else
				shp = shps(inds.First)
			End If
		End If
		Return shp
	End Function

	Public Function SelectedIndices() As List(Of Integer)
		Dim inds As New List(Of Integer)
		For i As Integer = 0 To shps.Count - 1
			If shps(i).Selected Then inds.Add(i)
		Next
		Return inds
	End Function

	Public Sub SetPrimary()
		shps.ForEach(Sub(x) x.Primary = False)
		Dim inds = SelectedIndices()

		If inds.Count > 0 Then
			If _ord = SelectOrder.AboveFirst Then
				shps(inds.Last).Primary = True
			Else
				shps(inds.First).Primary = True
			End If
		End If
	End Sub

	Public Sub DeselectAll()
		shps.ForEach(Sub(x) x.Selected = False)
	End Sub

	Public Sub CloneSelected()
		Dim lst_sl As New List(Of Shape)
		For Each i As Integer In SelectedIndices()
			lst_sl.Add(shps(i).Clone)
		Next
		DeselectAll()
		For Each sh As Shape In lst_sl
			sh.ReloadCachedObjects()
			shps.Add(sh)
		Next
		Invalidate()
	End Sub

	Public Sub DeleteSelected()
		For i As Integer = SelectedIndices.Count - 1 To 0 Step -1
			shps.RemoveAt(SelectedIndices()(i))
		Next
		Invalidate()
	End Sub

	Public Sub ToBack()
		Dim lst_sl As New List(Of Shape)
		For Each i As Integer In SelectedIndices()
			Dim new_shp As Shape = shps(i).Clone
			new_shp.ReloadCachedObjects()
			lst_sl.Add(new_shp)
		Next
		DeleteSelected()
		If lst_sl.Count > 0 Then shps.InsertRange(0, lst_sl)
		Invalidate()
	End Sub

	Public Sub ToFront()
		Dim lst_sl As New List(Of Shape)
		For Each i As Integer In SelectedIndices()
			Dim new_shp As Shape = shps(i).Clone
			new_shp.ReloadCachedObjects()
			lst_sl.Add(new_shp)
		Next
		DeleteSelected()
		If lst_sl.Count > 0 Then shps.AddRange(lst_sl)
		Invalidate()
	End Sub

	Public Sub FinalizeResize(shp As Shape)
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

	Public Function GetAnchorsRegion() As Region
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
		Return reg_anc
	End Function

	Public Function GetAnchorType(pt As Point) As AnchorType
		Dim selc = SelectedIndices()
		If selc.Count = 1 Then
			Dim shp = MainSelected()
			If shp.FBrush.BType = BrushType.PathGradient AndAlso shp.Centering.IsVisible(pt) Then
				Return AnchorType.BrushCenter
			ElseIf shp.TopLeft.IsVisible(pt) Then
				Return AnchorType.TopLeft
			ElseIf shp.Top.IsVisible(pt) Then
				Return AnchorType.Top
			ElseIf shp.TopRight.IsVisible(pt) Then
				Return AnchorType.TopRight
			ElseIf shp.Left.IsVisible(pt) Then
				Return AnchorType.Left
			ElseIf shp.Right.IsVisible(pt) Then
				Return AnchorType.Right
			ElseIf shp.BottomLeft.IsVisible(pt) Then
				Return AnchorType.BottomLeft
			ElseIf shp.Bottom.IsVisible(pt) Then
				Return AnchorType.Bottom
			ElseIf shp.BottomRight.IsVisible(pt) Then
				Return AnchorType.BottomRight
			ElseIf shp.Rotate.IsVisible(pt) Then
				Return AnchorType.Rotate
			End If
		Else
			Dim boundsAll = MultipleSelectionBounds()
			If AnchorTL(boundsAll).IsVisible(pt) Then
				Return AnchorType.TopLeft
			ElseIf AnchorT(boundsAll).IsVisible(pt) Then
				Return AnchorType.Top
			ElseIf AnchorTR(boundsAll).IsVisible(pt) Then
				Return AnchorType.TopRight
			ElseIf AnchorL(boundsAll).IsVisible(pt) Then
				Return AnchorType.Left
			ElseIf AnchorR(boundsAll).IsVisible(pt) Then
				Return AnchorType.Right
			ElseIf AnchorBL(boundsAll).IsVisible(pt) Then
				Return AnchorType.BottomLeft
			ElseIf AnchorB(boundsAll).IsVisible(pt) Then
				Return AnchorType.Bottom
			ElseIf AnchorBR(boundsAll).IsVisible(pt) Then
				Return AnchorType.BottomRight
			End If
		End If
		Return AnchorType.None
	End Function

	Public Function AnchorTL(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.X - AnchorSize.Width, r.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X += AnchorSize.Width / 2
			rect.Y += AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorT(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.X + (r.Width / 2) - (AnchorSize.Width / 2), r.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.Y += AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorTR(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.Right, r.Y - AnchorSize.Height, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X -= AnchorSize.Width / 2
			rect.Y += AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorL(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.X - AnchorSize.Width, r.Y + (r.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X += AnchorSize.Width / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorR(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.Right, r.Y + (r.Height / 2) - (AnchorSize.Height / 2), AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X -= AnchorSize.Width / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorBL(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.X - AnchorSize.Width, r.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X += AnchorSize.Width / 2
			rect.Y -= AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorB(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.X + (r.Width / 2) - (AnchorSize.Width / 2), r.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.Y -= AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

	Public Function AnchorBR(r As RectangleF) As GraphicsPath
		Dim rect As New RectangleF(r.Right, r.Bottom, AnchorSize.Width, AnchorSize.Height)
		If Math.Abs(r.Width) > 20 AndAlso Math.Abs(r.Height) > 20 Then
			rect.X -= AnchorSize.Width / 2
			rect.Y -= AnchorSize.Height / 2
		End If
		Dim gp As New GraphicsPath()
		gp.AddRectangle(rect)
		Return gp
	End Function

#End Region

#Region "Mouse Events"

#Region "Draw"
	Private Sub CanvasDraw_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Draw Then
			md_pt = e.Location

			DeselectAll()
			Dim sty As ShapeStyle = [Enum].Parse(GetType(ShapeStyle), MainForm.cb_Shape.SelectedItem)
			Dim bty As BrushType = [Enum].Parse(GetType(BrushType), MainForm.cb_Brush.SelectedItem)
			Select Case sty
				Case ShapeStyle.Lines,
					 ShapeStyle.Polygon,
					 ShapeStyle.Curves,
					 ShapeStyle.ClosedCurve
					d_info.ShapeType = sty
					If e.Button = MouseButtons.Right Then
						d_info.DrawMode = True
						If My.Computer.Keyboard.AltKeyDown Then
							If d_info.Points.Count > 0 Then
								Dim ind = DPInCursor(e.Location)
								If ind > -1 Then d_info.Points.RemoveAt(ind)
							End If
						Else
							Dim n_pt As Point = e.Location
							If My.Computer.Keyboard.CtrlKeyDown Then
								If d_info.Points.Count > 0 Then n_pt.X = d_info.Points.Last().X
							ElseIf My.Computer.Keyboard.ShiftKeyDown Then
								If d_info.Points.Count > 0 Then n_pt.Y = d_info.Points.Last().Y
							End If
							d_info.Points.Add(n_pt)
							curr_loc = n_pt
						End If
					ElseIf e.Button = MouseButtons.Left Then
						If d_info.Points.Count >= DModeMin() Then
							Dim _min As PointF
							Dim _max As PointF
							_min.X = d_info.Points.Min(Function(pt As PointF) pt.X)
							_min.Y = d_info.Points.Min(Function(pt As PointF) pt.Y)
							_max.X = d_info.Points.Max(Function(pt As PointF) pt.X)
							_max.Y = d_info.Points.Max(Function(pt As PointF) pt.Y)
							If _min.X = _max.X Then _max.X += 1
							If _min.Y = _max.Y Then _max.Y += 1
							Dim sshp As New Shape(_min, sty, bty, Zoom)
							Dim rectf As New RectangleF(_min, New SizeF(_max.X - _min.X, _max.Y - _min.Y))
							sshp.SetAllRect(rectf)
							Dim l_perc = New List(Of PointF)
							d_info.Points.ForEach(Sub(x) l_perc.Add(ToPercentage(rectf, x)))
							If d_info.ShapeType = 4 Or d_info.ShapeType = 5 Then
								sshp.MShape.PolygonPoints = l_perc.ToArray()
							Else
								sshp.MShape.CurvePoints = l_perc.ToArray()
							End If
							sshp.Selected = True
							shps.Add(sshp)
							ClearDrawingData()
							MainForm.UpdateControls()
						Else
							If Not d_info.DrawMode Then
								Dim shp_n = New Shape(e.Location, sty, bty, Zoom) With {
									.Selected = True
								}
								shps.Add(shp_n)
								op = MOperations.Draw
								MainForm.UpdateControls()
							End If
						End If
					End If
					Invalidate()
				Case Else
					Dim shp_n = New Shape(md_pt, sty, bty, Zoom) With {
						.Selected = True
					}
					shps.Add(shp_n)
					op = MOperations.Draw
					MainForm.UpdateControls()
			End Select
		End If
	End Sub

	Private Sub CanvasDraw_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Draw Then
			Cursor = Cursors.Cross
			If op = MOperations.Draw Then
				Dim shp_d As Shape = MainSelected()
				Dim rtd As New RectangleF(Math.Min(e.X, md_pt.X),
								   Math.Min(e.Y, md_pt.Y),
								   Math.Abs(e.X - md_pt.X),
								   Math.Abs(e.Y - md_pt.Y))
				shp_d.FlipX = e.X - md_pt.X < 0
				shp_d.FlipY = e.Y - md_pt.Y < 0
				If My.Computer.Keyboard.ShiftKeyDown Then 'make width and height equal
					Dim mxx As Integer = Math.Max(rtd.Width, rtd.Height)
					rtd.Width = mxx
					rtd.Height = mxx
					If e.Y <= md_pt.Y Then rtd.Y = md_pt.Y - rtd.Height
					If e.X <= md_pt.X Then rtd.X = md_pt.X - rtd.Width
				End If
				If My.Computer.Keyboard.CtrlKeyDown Then 'use mouse down point as center
					If e.X > md_pt.X Then rtd.X -= rtd.Width
					If e.Y > md_pt.Y Then rtd.Y -= rtd.Height
					rtd.Width *= 2
					rtd.Height *= 2
				End If
				shp_d.SetAllRect(rtd)
				Invalidate()
				MainForm.UpdateBoundControls()
			End If
			If d_info.DrawMode And d_info.Points.Count > 0 Then
				Dim n_pt As Point = e.Location
				If My.Computer.Keyboard.CtrlKeyDown Then
					n_pt.X = d_info.Points.Last().X
				ElseIf My.Computer.Keyboard.ShiftKeyDown Then
					n_pt.Y = d_info.Points.Last().Y
				End If
				curr_loc = n_pt
				Invalidate()
			End If
		End If
	End Sub

	Private Sub CanvasDraw_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Draw Then
			If Not d_info.DrawMode Then MainForm.rSelect.Checked = True
			op = MOperations.None
		End If
	End Sub

	Private Sub CanvasDraw_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
		If MainForm.Operation = MainForm.Operations.Draw Then
			curr_loc = Point.Empty
			Invalidate()
		Else
			h_info.ShapeIndex = -1
			Invalidate()
		End If
	End Sub

#End Region

#Region "Select & Resize"

	Private Sub CanvasSelect_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Select Then

			md_pt = e.Location
			h_info.ShapeIndex = -1

			'don't change selection if cursor is on anchors
			If Not GetAnchorsRegion.IsVisible(e.Location) Then
				Dim curr As Integer = ShapeInCursor(e.Location)
				If curr > -1 Then
					If Not shps(curr).Selected Then
						If My.Computer.Keyboard.CtrlKeyDown Then
							up_fix = False
						Else
							DeselectAll()
						End If
						shps(curr).Selected = True
					End If
				Else
					If Not My.Computer.Keyboard.CtrlKeyDown Then DeselectAll()
					op = MOperations.Selection
					s_rect.Location = e.Location
					Return
				End If
			End If

			Dim shp = MainSelected()

			Dim selc = SelectedIndices()

			'set operations
			If selc.Count Then

				shp.RotationPoint = FromPercentage(shp.GetRect, New PointF(50, 50))
				m_cnt = shp.RotationPoint
				m_ang = shp.Angle

				_negX = shp.FlipX
				_negY = shp.FlipY

				Dim anct As AnchorType = GetAnchorType(e.Location)

				If selc.Count = 1 Then
					res_rect.Add(shp.GetRect)
					mv_rect.Add(shp.GetRect)
				Else
					Dim boundsAll = MultipleSelectionBounds()
					For Each ind As Integer In selc
						Dim ss As Shape = shps(ind)
						mv_rect.Add(ss.GetRect)
						res_rect.Add(ToPercentage(boundsAll, ss.GetRect))
					Next
					res_bounds = boundsAll
				End If

				If anct = AnchorType.BrushCenter Then
					If e.Button = MouseButtons.Left Then
						op = MOperations.Centering
					ElseIf e.Button = MouseButtons.Right Then
						shp.FBrush.PCenterPoint = New PointF(50, 50)
					End If
				ElseIf anct = AnchorType.TopLeft Then
					op = MOperations.TopLeft
				ElseIf anct = AnchorType.Top Then
					op = MOperations.Top
				ElseIf anct = AnchorType.TopRight Then
					op = MOperations.TopRight
				ElseIf anct = AnchorType.Left Then
					op = MOperations.Left
				ElseIf anct = AnchorType.Right Then
					op = MOperations.Right
				ElseIf anct = AnchorType.BottomLeft Then
					op = MOperations.BottomLeft
				ElseIf anct = AnchorType.Bottom Then
					op = MOperations.Bottom
				ElseIf anct = AnchorType.BottomRight Then
					op = MOperations.BottomRight
				ElseIf anct = AnchorType.Rotate Then
					op = MOperations.Rotate
				Else

					Dim m_path As New Region(Rectangle.Empty)

					For Each ind As Integer In selc
						Dim ss As Shape = shps(ind)
						m_path.Union(ss.Region())
					Next

					If m_path.IsVisible(e.Location) Then
						op = MOperations.Move
						Cursor = Cursors.SizeAll
						selc.ForEach(Sub(i) shps(i).Moving = True)
					End If

					m_path.Dispose()

				End If

			End If

			SetPrimary()
			MainForm.UpdateControls()
			Invalidate()
		End If
	End Sub

	Private Sub CanvasSelect_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Select Then

			If op = MOperations.Selection Then
				s_rect = New Rectangle(Math.Min(e.X, md_pt.X),
									   Math.Min(e.Y, md_pt.Y),
									   Math.Abs(e.X - md_pt.X),
									   Math.Abs(e.Y - md_pt.Y))
				If Not My.Computer.Keyboard.CtrlKeyDown Then DeselectAll()
				For Each ss As Shape In shps
					Dim ss_rg = ss.Region
					If Not ss.Selected AndAlso Not IsNothing(ss_rg) Then
						If ss_rg.IsVisible(s_rect) Then
							ss.Selected = True
						End If
					End If
				Next
				SetPrimary()
			End If

			Dim selc = SelectedIndices()

			'highlight shape
			If HighlightShapes AndAlso op = MOperations.None AndAlso
			   shps.Count > selc.Count Then
				Dim curr As Integer = ShapeInCursor(e.Location)
				If curr > -1 AndAlso Not GetAnchorsRegion.IsVisible(e.Location, CreateGraphics) Then
					If shps(curr).Selected = False Then
						If Not IsNothing(shps(curr).BorderPath) AndAlso
						Not IsNothing(shps(curr).TotalPath) Then
							h_info.ShapeIndex = curr
							If shps(curr).BorderPath.IsVisible(e.Location) Then
								h_info.HoverType = 1
							ElseIf shps(curr).TotalPath.IsVisible(e.Location) Then
								h_info.HoverType = 0
							End If
						End If
					Else
						h_info.ShapeIndex = -1
					End If
				Else
					h_info.ShapeIndex = -1
				End If
				Invalidate()
			End If

			Dim shp As Shape = MainSelected()
			Dim boundsAll = MultipleSelectionBounds()

			'set cursors
			If op = MOperations.None Then
				Dim anct As AnchorType = GetAnchorType(e.Location)

				Dim cur_ang = 0
				If selc.Count = 1 Then cur_ang = shp.Angle

				If anct = AnchorType.BrushCenter Then
					Cursor = Cursors.Hand
				ElseIf anct = AnchorType.TopLeft Then
					Cursor = AnchorToCursor(MOperations.TopLeft, cur_ang)
				ElseIf anct = AnchorType.Top Then
					Cursor = AnchorToCursor(MOperations.Top, cur_ang)
				ElseIf anct = AnchorType.TopRight Then
					Cursor = AnchorToCursor(MOperations.TopRight, cur_ang)
				ElseIf anct = AnchorType.Left Then
					Cursor = AnchorToCursor(MOperations.Left, cur_ang)
				ElseIf anct = AnchorType.Right Then
					Cursor = AnchorToCursor(MOperations.Right, cur_ang)
				ElseIf anct = AnchorType.BottomLeft Then
					Cursor = AnchorToCursor(MOperations.BottomLeft, cur_ang)
				ElseIf anct = AnchorType.Bottom Then
					Cursor = AnchorToCursor(MOperations.Bottom, cur_ang)
				ElseIf anct = AnchorType.BottomRight Then
					Cursor = AnchorToCursor(MOperations.BottomRight, cur_ang)
				ElseIf anct = AnchorType.Rotate Then
					Cursor = AnchorToCursor(MOperations.Rotate, cur_ang)
				Else
					Cursor = Cursors.Arrow
				End If
			End If

			'create and initialize variables
			Dim tDest As PointF = e.Location
			Dim tPt As PointF
			Dim tRc, oRc As RectangleF

			If selc.Count Then
				If res_rect.Count = 1 Then
					If shp.Angle Then tDest = RotatePoint(tDest, md_pt, -shp.Angle)
					tRc = res_rect.First
				Else
					tRc = res_bounds
				End If
				tPt = New PointF(tDest.X - md_pt.X, tDest.Y - md_pt.Y)
				oRc = tRc
			End If

			'operations
			Select Case op
				Case MOperations.Centering
					Dim npt As PointF = RotatePoint(e.Location, shp.RotationPoint, -shp.Angle)
					shp.FBrush.PCenterPoint = ToPercentage(shp.GetRect, npt)
				Case MOperations.TopLeft
					tRc.X += tPt.X
					tRc.Width -= tPt.X
					tRc.Y += tPt.Y
					tRc.Height -= tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Height -= tPt.Y
						tRc.Width -= tPt.X
					End If
				Case MOperations.Top
					tRc.Y += tPt.Y
					tRc.Height -= tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Height -= tPt.Y
					End If
				Case MOperations.TopRight
					tRc.Width += tPt.X
					tRc.Y += tPt.Y
					tRc.Height -= tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Height -= tPt.Y
						tRc.X -= tPt.X
						tRc.Width += tPt.X
					End If
				Case MOperations.Left
					tRc.X += tPt.X
					tRc.Width -= tPt.X
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Width -= tPt.X
					End If
				Case MOperations.Right
					tRc.Width += tPt.X
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.X -= tPt.X
						tRc.Width += tPt.X
					End If
				Case MOperations.BottomLeft
					tRc.X += tPt.X
					tRc.Width -= tPt.X
					tRc.Height += tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Width -= tPt.X
						tRc.Y -= tPt.Y
						tRc.Height += tPt.Y
					End If
				Case MOperations.Bottom
					tRc.Height += tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.Y -= tPt.Y
						tRc.Height += tPt.Y
					End If
				Case MOperations.BottomRight
					tRc.Width += tPt.X
					tRc.Height += tPt.Y
					If My.Computer.Keyboard.CtrlKeyDown Then
						tRc.X -= tPt.X
						tRc.Width += tPt.X
						tRc.Y -= tPt.Y
						tRc.Height += tPt.Y
					End If
				Case MOperations.Rotate
					Dim snAngle As Single = GetAngleBetweenTwoPointsWithFixedPoint(md_pt, e.Location, m_cnt)
					snAngle = -snAngle * 180 / Math.PI
					Dim qt As Boolean = False
					If e.Button = MouseButtons.Left Then qt = True
					shp.Angle = EditRotateAngle(m_ang, snAngle, qt)
				Case MOperations.Move
					If My.Computer.Keyboard.CtrlKeyDown AndAlso cloned = False Then
						old_sl.Clear()
						selc.ForEach(Sub(i) old_sl.Add(i))
						CloneSelected()
						cloned = True
						cloning = True
					End If
					If cloning Then
						If Not My.Computer.Keyboard.CtrlKeyDown Then
							Dim _lst = selc
							For i As Integer = 0 To old_sl.Count - 1
								Dim ss As Shape = shps(_lst(i))
								shps(old_sl(i)).SetAllRect(ss.GetRect)
								shps(old_sl(i)).Selected = False
								shps(old_sl(i)).Moving = False
							Next
							DeleteSelected()
							For i As Integer = 0 To old_sl.Count - 1
								shps(old_sl(i)).Selected = True
								shps(old_sl(i)).Moving = True
							Next
							cloned = False
						End If
					End If
					selc = SelectedIndices()
					Dim iXMove, iYMove As Single
					iXMove = e.Location.X - md_pt.X
					iYMove = e.Location.Y - md_pt.Y
					For i As Integer = 0 To mv_rect.Count - 1
						Dim dRc As RectangleF = mv_rect(i)
						If My.Computer.Keyboard.ShiftKeyDown Then
							Dim dX = Math.Abs(iXMove)
							Dim dY = Math.Abs(iYMove)
							If dX > dY Then
								'Only horizontal
								dRc.Offset(iXMove, 0)
							ElseIf dY > dX Then
								'Only vertical
								dRc.Offset(0, iYMove)
							Else
								'Diagonal (to be fixed)
								Dim iinc = Math.Max(iXMove, iYMove)
								dRc.Offset(iinc, iinc)
							End If
						Else
							dRc.Offset(iXMove, iYMove)
						End If
						Dim ss As Shape = shps(selc(i))
						ss.SetAllRect(dRc)
						ss.RotationPoint = FromPercentage(ss.GetRect, New PointF(50, 50))
					Next
			End Select

			'finalize resize operation
			If op >= MOperations.TopLeft AndAlso op <= MOperations.BottomRight Then
				If My.Computer.Keyboard.ShiftKeyDown Then
					'maintain aspect ratio
					Dim rtd As RectangleF = tRc
					Dim asp As Single = oRc.Width / oRc.Height
					Select Case op
						Case MOperations.TopLeft, MOperations.TopRight,
						 MOperations.BottomLeft, MOperations.BottomRight
							If oRc.Width > oRc.Height Then
								rtd.Height = Math.Abs(rtd.Width) / asp
							ElseIf oRc.Width < oRc.Height Then
								rtd.Width = Math.Abs(rtd.Height) * asp
							Else
								Dim mxx As Integer = Math.Max(rtd.Width, rtd.Height)
								rtd.Width = mxx
								rtd.Height = mxx
							End If
						Case MOperations.Top, MOperations.Bottom
							rtd.Width = Math.Abs(rtd.Height) * asp
						Case MOperations.Left, MOperations.Right
							rtd.Height = Math.Abs(rtd.Width) / asp
					End Select
					If op = MOperations.TopLeft Or op = MOperations.TopRight Then
						rtd.Y = oRc.Bottom - rtd.Height
					End If
					If op = MOperations.TopLeft Or op = MOperations.BottomLeft Then
						rtd.X = oRc.Right - rtd.Width
					End If
					tRc = rtd
				End If

				If tRc.Width = 0 Then Return
				If tRc.Height = 0 Then Return

				If _negX Then oRc.Width *= -1
				If _negY Then oRc.Height *= -1

				If tRc.Width * oRc.Width < 0 Then
					shp.FlipX = True
				Else
					shp.FlipX = False
				End If

				If tRc.Height * oRc.Height < 0 Then
					shp.FlipY = True
				Else
					shp.FlipY = False
				End If

				If selc.Count = 1 Then
					shp.SetAllRect(tRc)
				Else
					For ind As Integer = 0 To selc.Count - 1
						Dim ss As Shape = shps(selc(ind))
						ss.SetAllRect(FromPercentage(tRc, res_rect(ind)))
						ss.RotationPoint = FromPercentage(ss.GetRect, New PointF(50, 50))
					Next
				End If
			End If

			If op <> MOperations.None Then
				Invalidate()
				MainForm.UpdateBoundControls()
			End If

		End If
	End Sub

	Private Sub CanvasSelect_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
		If MainCanvasControl.Panning Then Return
		If MainForm.Operation = MainForm.Operations.Select Then

			If My.Computer.Keyboard.CtrlKeyDown AndAlso e.Location = md_pt AndAlso up_fix Then
				Dim curr As Integer = ShapeInCursor(e.Location)
				If curr > -1 Then
					Dim ss = shps(curr)
					ss.Selected = Not ss.Selected
				End If
			End If

			'if rotated shape is resized then adjust its coordinates
			If op >= MOperations.TopLeft AndAlso op <= MOperations.BottomRight Then
				Dim shp As Shape = MainSelected()
				If Not IsNothing(shp) Then FinalizeResize(shp)
			End If

			mv_rect.Clear()
			res_rect.Clear()
			up_fix = True
			shps.ForEach(Sub(x) x.Moving = False)
			SetPrimary()
			cloned = False
			cloning = False
			If op <> MOperations.None Then
				MainForm.UpdateControls()
				op = MOperations.None
			Else
				MainForm.UpdateBoundControls()
			End If
			s_rect = Rectangle.Empty
			Invalidate()
		End If
	End Sub

#End Region

#End Region

#Region "Paint Event"

	Private Sub DrawSize(g As Graphics, shp As Shape, Optional _horz As Boolean = True, Optional _vert As Boolean = True)
		g.PixelOffsetMode = PixelOffsetMode.Default
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
		Dim fnt As New Font("Arial", 10)
		If _horz Then
			Dim t_horz As String = Math.Round(Math.Abs(shp.BaseWidth), 2)
			Dim s_horz As SizeF = g.MeasureString(t_horz, fnt)
			Dim r_horz As New RectangleF(New PointF(rt.Right - s_horz.Width, rt.Bottom + 2), s_horz)
			g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.White)), r_horz)
			g.DrawString(t_horz, fnt, New SolidBrush(clr_sz), r_horz, sf)
			If rt.Width > r_horz.Width Then
				Dim p1 As New Point(rt.X, r_horz.Y + (r_horz.Height / 2))
				Dim p2 As New Point(r_horz.Left - 1, p1.Y)
				g.DrawLine(New Pen(clr_sz), p1, p2)
			End If
		End If
		If _vert Then
			sf.FormatFlags = StringFormatFlags.DirectionVertical
			Dim t_vert As String = Math.Round(Math.Abs(shp.BaseHeight), 2)
			Dim s_vert As SizeF = g.MeasureString(t_vert, fnt)
			Dim r_vert As New RectangleF(New PointF(rt.Right + 2, rt.Top), New SizeF(s_vert.Height, s_vert.Width))
			g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.White)), r_vert)
			g.DrawString(t_vert, fnt, New SolidBrush(clr_sz), r_vert, sf)
			If rt.Height > r_vert.Height Then
				Dim p1 As New Point(r_vert.X + (r_vert.Width / 2), r_vert.Bottom + 1)
				Dim p2 As New Point(p1.X, rt.Bottom)
				g.DrawLine(New Pen(clr_sz), p1, p2)
			End If
		End If
		sf.Dispose()
		fnt.Dispose()
		g.PixelOffsetMode = PixelOffsetMode.HighQuality
	End Sub

	Private Sub DrawAnchorEllipse(g As Graphics, rect As RectangleF)
		rect.Inflate(1, 1)
		g.FillEllipse(New SolidBrush(Color.FromArgb(180, Color.Lime)), rect)
		g.DrawEllipse(Pens.Black, rect)
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
		ElseIf shp.Glow.GClip = GlowClip.Inside Then
			Dim rg As New Region(pth)
			g.Clip = rg
		End If
		For i As Integer = 1 To shp.Glow.Radius Step 2
			Dim aGlow As Integer = shp.Glow.Strength - (shp.Glow.Strength / shp.Glow.Radius * i)
			Using pen As New Pen(Color.FromArgb(aGlow, shp.Glow.GlowColor), i) With
				{.LineJoin = LineJoin.Round, .StartCap = shp.DPen.PStartCap, .EndCap = shp.DPen.PEndCap}
				g.DrawPath(pen, pth)
			End Using
		Next i

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
		End If

		For i As Integer = 1 To shp.Shadow.Blur
			Dim aGlow As Integer = shp.Shadow.Radius - (shp.Shadow.Radius / shp.Shadow.Blur * i)
			Using pen As New Pen(Color.FromArgb(aGlow, shp.Shadow.ShadowColor), i) With
				{.LineJoin = LineJoin.Round, .StartCap = shp.DPen.PStartCap, .EndCap = shp.DPen.PEndCap}
				g.DrawPath(pen, pth)
			End Using
		Next i

		If shp.Shadow.Fill Then g.FillPath(New SolidBrush(shp.Shadow.ShadowColor), pth)

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

		Next
	End Sub

	Private Sub DrawShape(g As Graphics, shp As Shape)
		g.PixelOffsetMode = PixelOffsetMode.HighSpeed
		g.RenderingOrigin = Point.Ceiling(shp.GetRect.Location)

		Using mm As New Matrix
			mm.RotateAt(shp.Angle, shp.RotationPoint)
			g.Transform = mm
		End Using

		If shp.Shadow.Enabled Then CreateShadow(g, shp)
		If shp.Glow.Enabled AndAlso shp.Glow.BeforeFill Then CreateGlow(g, shp)

		'Fill and Draw Shape
		Dim pth As GraphicsPath = shp.TotalPath(False)
		Dim fbr As Brush = shp.FillBrush
		Dim dpn As Pen = shp.CreatePen

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

		g.ResetTransform()
	End Sub

	Private Sub DrawShapeAnchors(g As Graphics, shp As Shape)
		Using mm As New Matrix
			mm.RotateAt(shp.Angle, shp.RotationPoint)
			g.Transform = mm
		End Using

		If op = MOperations.Draw Or op = MOperations.Selection Or op = MOperations.None Or (op >= MOperations.TopLeft And op <= MOperations.BottomRight) Then
			Using pth_brd As New GraphicsPath
				pth_brd.AddRectangle(AbsRect(shp.GetRect))
				Dim pn_brd As New Pen(Brushes.Black) With {
					.DashPattern = New Single() {2, 2, 3}
				}
				g.DrawPath(pn_brd, pth_brd)
			End Using
		End If

		g.PixelOffsetMode = PixelOffsetMode.HighQuality

		Select Case op
			Case MOperations.None, MOperations.Draw, MOperations.Selection
				Dim br As New SolidBrush(Color.White)
				Dim pn As New Pen(Color.Black, 1)

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

				'Draw Rotation Anchor Line
				Dim pt1 As New PointF(shp.Top(False).GetBounds().X + (shp.Top(False).GetBounds().Width / 2),
					 shp.Top(False).GetBounds().Top)
				Dim pt2 As New PointF(shp.Rotate(False).GetBounds().X + (shp.Rotate(False).GetBounds().Width / 2),
					 shp.Rotate(False).GetBounds().Bottom)
				g.DrawLine(pn, pt1, pt2)

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
				Using pnt As New Pen(Color.FromArgb(120, Color.Black), 5)
					pnt.DashStyle = DashStyle.DashDot
					pnt.DashCap = DashCap.Round
					g.ResetTransform()
					g.DrawEllipse(pnt, rectt)
				End Using
				If shp.GetRect.Width >= 25 AndAlso shp.GetRect.Height >= 25 Then
					Using sf As New StringFormat()
						sf.Alignment = StringAlignment.Center
						sf.LineAlignment = StringAlignment.Center
						Dim fnt As New Font("Consolas", 13)
						g.DrawString(shp.Angle.ToString, fnt, Brushes.Black, shp.GetRect, sf)
						fnt.Dispose()
					End Using
				End If
		End Select

		g.PixelOffsetMode = PixelOffsetMode.HighSpeed

		g.ResetTransform()
	End Sub

	Private Sub DrawMultipleSelectionAnchors(g As Graphics)
		Dim boundsAll = MultipleSelectionBounds()

		If op = MOperations.Draw Or op = MOperations.Selection Or op = MOperations.None Or (op >= MOperations.TopLeft And op <= MOperations.BottomRight) Then
			Using pth_brd As New GraphicsPath
				pth_brd.AddRectangle(boundsAll)
				Dim pn_brd As New Pen(Brushes.Black) With {
					.DashPattern = New Single() {2, 2, 3}
				}
				g.DrawPath(pn_brd, pth_brd)
			End Using
		End If

		g.PixelOffsetMode = PixelOffsetMode.HighQuality

		Select Case op
			Case MOperations.None, MOperations.Draw, MOperations.Selection
				Dim bounds_br As New SolidBrush(Color.White)
				Dim bounds_pn As New Pen(Color.Black, 1)

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
		End Select

		g.PixelOffsetMode = PixelOffsetMode.HighSpeed
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
			shps.ForEach(Sub(shp) temp_shp.Add(shp.Clone))
			temp_shp.ForEach(Sub(shp)
								 shp.Zoom = 1
								 shp.ReloadCachedObjects()
								 DrawShape(ig, shp)
							 End Sub)

		End Using

		Return img
	End Function

	Private Sub DrawHighlightedShape(g As Graphics)
		If h_info.ShapeIndex > -1 And h_info.ShapeIndex < shps.Count Then
			Using pn As New Pen(hg_pth)
				If h_info.HoverType = 1 Then pn.Color = hg_brd
				g.DrawPath(pn, shps(h_info.ShapeIndex).TotalPath())
			End Using
		End If
	End Sub

	Private Sub DrawSelectorRectangle(g As Graphics)
		If s_rect.Width > 0 AndAlso s_rect.Height > 0 Then
			Using pth As New GraphicsPath()
				pth.AddRectangle(s_rect)
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
		If d_info.DrawMode Then
			For i As Integer = 0 To d_info.Points.Count - 1
				g.FillPath(New SolidBrush(Color.FromArgb(180, Color.Black)),
						   DPPath(i))
			Next

			Dim d_lim As Integer = DModeMin()
			If Not curr_loc = Point.Empty Then d_lim -= 1

			If d_info.Points.Count >= d_lim Then
				Dim d_pts As New List(Of PointF)
				d_info.Points.ForEach(Sub(pt)
										  d_pts.Add(pt)
									  End Sub)
				If Not curr_loc = Point.Empty Then d_pts.Add(curr_loc)
				Using d_pen As New Pen(Color.Black)
					If d_info.Points.Count < DModeMin() Then d_pen.DashPattern = New Single() {8, 4}
					Select Case d_info.ShapeType
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

		If Not IsNothing(BackgroundImage) Then
			g.DrawImage(BackgroundImage, 0, 0, Width, Height)
		End If

		'Draw background color
		g.FillRectangle(New SolidBrush(BackColor), ClientRectangle)

		Dim selc = SelectedIndices()
		Dim prm As Shape = Nothing

		'Draw all shapes on image
		shps.ForEach(Sub(shp)
						 DrawShape(g, shp)
						 If shp.Selected AndAlso selc.Count = 1 Then prm = shp
					 End Sub)

		If Not IsNothing(prm) Then DrawShapeAnchors(g, prm)

		If selc.Count > 1 Then DrawMultipleSelectionAnchors(g)

		RenderDrawingModeData(g)

		DrawHighlightedShape(g)

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
					Dim ind As Integer = shps.IndexOf(shp)
					If ind < shps.Count - 1 Then
						DeselectAll()
						shps(ind + 1).Selected = True
						SetPrimary()
					End If
				End If
			Case Keys.Shift Or Keys.Tab
				Dim shp As Shape = MainSelected()
				If Not IsNothing(shp) Then
					Dim ind As Integer = shps.IndexOf(shp)
					If ind > 0 Then
						DeselectAll()
						shps(ind - 1).Selected = True
						SetPrimary()
					End If
				End If
			Case Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseX -= 1
				Next
			Case Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseX += 1
				Next
			Case Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseY -= 1
				Next
			Case Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseY += 1
				Next
			Case Keys.Control Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					If shp.BaseWidth > 1 Then
						shp.BaseWidth -= 1
					End If
				Next
			Case Keys.Control Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseWidth += 1
				Next
			Case Keys.Control Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					If shp.BaseHeight > 1 Then
						shp.BaseHeight -= 1
					End If
				Next
			Case Keys.Control Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseHeight += 1
				Next
			Case Keys.Shift Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseX -= 1
					shp.BaseWidth += 1
				Next
			Case Keys.Shift Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					If shp.BaseWidth > 1 Then
						shp.BaseX += 1
						shp.BaseWidth -= 1
					End If
				Next
			Case Keys.Shift Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					shp.BaseY -= 1
					shp.BaseHeight += 1
				Next
			Case Keys.Shift Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					If shp.BaseHeight > 1 Then
						shp.BaseY += 1
						shp.BaseHeight -= 1
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Left
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					Dim rect As RectangleF = shp.GetRect
					If rect.Width > 2 Then
						rect.Inflate(-1, 0)
						shp.SetAllRect(rect)
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Right
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					Dim rect As RectangleF = shp.GetRect
					rect.Inflate(1, 0)
					shp.SetAllRect(rect)
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Up
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					Dim rect As RectangleF = shp.GetRect
					If rect.Width > 2 Then
						rect.Inflate(0, -1)
						shp.SetAllRect(rect)
					End If
				Next
			Case Keys.Shift Or Keys.Control Or Keys.Down
				For Each i As Integer In SelectedIndices()
					Dim shp As Shape = shps(i)
					Dim rect As RectangleF = shp.GetRect
					rect.Inflate(0, 1)
					shp.SetAllRect(rect)
				Next
			Case Keys.Control Or Keys.A
				For Each shp As Shape In shps
					shp.Selected = True
				Next
				SetPrimary()
			Case Keys.Control Or Keys.C
				Dim _lst As New List(Of Shape)
				For Each i As Integer In SelectedIndices()
					_lst.Add(shps(i).Clone)
				Next
				My.Computer.Clipboard.SetData("DrawIt-Shapes", _lst)
			Case Keys.Control Or Keys.X
				Dim _lst As New List(Of Shape)
				For Each i As Integer In SelectedIndices()
					_lst.Add(shps(i).Clone)
				Next
				DeleteSelected()
				My.Computer.Clipboard.SetData("DrawIt-Shapes", _lst)
			Case Keys.Control Or Keys.V
				DeselectAll()
				Dim _lst As New List(Of Shape)
				_lst = My.Computer.Clipboard.GetData("DrawIt-Shapes")
				If IsNothing(_lst) Then Return
				For Each shp As Shape In _lst
					shp.BindEvents()
					shp.ReloadCachedObjects()
					shps.Add(shp)
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
				SelectedIndices.ForEach(Sub(i) FinalizeResize(shps(i)))
				MainForm.UpdateControls()
				Invalidate()
		End Select
	End Sub

#End Region

#Region "Focus"
	Private Sub Canvas_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
		focus_clr = Color.Silver
		Invalidate()
	End Sub

	Private Sub Canvas_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
		focus_clr = Color.LightGray
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
