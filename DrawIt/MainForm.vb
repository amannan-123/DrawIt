#Region "Imports"
Imports System.Drawing.Drawing2D
Imports System.IO
Imports MyControls
#End Region

Public Class MainForm

#Region "Properties"
	Enum Operations
		Draw
		[Select]
	End Enum

	Private Property MainShape() As Shape = Nothing

	Private Property MainCanvas() As Canvas = Nothing

	Public ReadOnly Property Operation() As Operations
		Get
			If rDraw.Checked Then
				Return Operations.Draw
			Else
				Return Operations.Select
			End If
		End Get
	End Property

#End Region

#Region "TabPageRelated"
	Private Function CurrentCanvas() As Canvas
		If tCanvas.TabPages.Count > 0 Then
			Dim ctrl = DirectCast(tCanvas.SelectedTab.Controls()(0), CanvasControl)
			Return ctrl.baseCanvas
		End If
		Return Nothing
	End Function

	Private Function CurrentCanvasControl() As CanvasControl
		If tCanvas.TabPages.Count > 0 Then
			Return DirectCast(tCanvas.SelectedTab.Controls()(0), CanvasControl)
		End If
		Return Nothing
	End Function

	Private Sub tCanvas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tCanvas.SelectedIndexChanged
		UpdateControls()
		UpdateSettings()
	End Sub
#End Region

#Region "UpdateControls"
	Public Sub UpdateControls()
		Dim cnv = CurrentCanvas()
		MainCanvas = cnv
		MainShape = Nothing
		If Not IsNothing(cnv) Then
			Dim shp As Shape = MainCanvas.MainSelected
			MainShape = shp
			If Not IsNothing(shp) Then
				'shape and brush
				cb_Shape.SelectedItem = shp.MShape.SType.ToString
				cb_Brush.SelectedItem = shp.FBrush.BType.ToString
				'solid brush
				CE_Solid.SelectedColor = shp.FBrush.SolidColor
				'texture brush
				PB_Texture.Image = shp.FBrush.TImage
				CB_Trans.Checked = shp.FBrush.TTransparency
				CE_Trans.SelectedColor = shp.FBrush.TColor
				cb_RotateFlip.SelectedItem = shp.FBrush.TRotateFlip.ToString
				'hatch brush
				CE_H1.SelectedColor = shp.FBrush.HFore
				CE_H2.SelectedColor = shp.FBrush.HBack
				cb_HatchStyle.SelectedItem = shp.FBrush.HStyle.ToString
				'linear gradient brush
				CE_L1.SelectedColor = shp.FBrush.LColor1
				CE_L2.SelectedColor = shp.FBrush.LColor2
				CB_Gamma.Checked = shp.FBrush.LGamma
				TB_LAngle.Value = shp.FBrush.LinearAngle
				CB_LTri.Checked = shp.FBrush.LTriangular
				LTriFocus.Value = shp.FBrush.LTriFocus
				LTriScale.Value = shp.FBrush.LTriScale
				CB_LBell.Checked = shp.FBrush.LBell
				LBellFocus.Value = shp.FBrush.LBellFocus
				LBellScale.Value = shp.FBrush.LBellScale
				CB_LColorBlend.Checked = shp.FBrush.LInterpolate
				L_CBEditor.LoadColorBlendItems(shp.FBrush.LInterColors, shp.FBrush.LInterPositions)
				CB_LBlend.Checked = shp.FBrush.LBlend
				L_BEditor.Loadblenditems(shp.FBrush.LBlendFactors, shp.FBrush.LBlendPositions)
				L_BEditor.Color1 = shp.FBrush.LColor1
				L_BEditor.Color2 = shp.FBrush.LColor2
				'path gradient brush
				CE_P1.SelectedColor = shp.FBrush.PCenter
				PFocusX.Value = shp.FBrush.PFocusX
				PFocusY.Value = shp.FBrush.PFocusY
				CB_PTri.Checked = shp.FBrush.PTriangular
				PTriFocus.Value = shp.FBrush.PTriFocus
				PTriScale.Value = shp.FBrush.PTriScale
				CB_PBell.Checked = shp.FBrush.PBell
				PBellFocus.Value = shp.FBrush.PBellFocus
				PBellScale.Value = shp.FBrush.PBellScale
				CB_PColorBlend.Checked = shp.FBrush.PInterpolate
				P_CBEditor.LoadColorBlendItems(shp.FBrush.PInterColors, shp.FBrush.PInterPositions)
				CB_PBlend.Checked = shp.FBrush.PBlend
				P_BEditor.Loadblenditems(shp.FBrush.PBlendFactors, shp.FBrush.PBlendPositions)
				P_BEditor.Color1 = shp.FBrush.PSurround(0)
				P_BEditor.Color2 = shp.FBrush.PCenter
				'Pen
				Select Case shp.DPen.PBrush.BType
					Case MyBrush.BrushType.Solid
						rbpSolid.Checked = True
					Case MyBrush.BrushType.LinearGradient
						rbpLinear.Checked = True
					Case MyBrush.BrushType.Hatch
						rbpHatch.Checked = True
				End Select
				PWidth.Value = shp.DPen.PWidth
				CE_PSolid.SelectedColor = shp.DPen.PBrush.SolidColor
				LP_CBEditor.LoadColorBlendItems(shp.DPen.PBrush.LInterColors, shp.DPen.PBrush.LInterPositions)
				CE_PFore.SelectedColor = shp.DPen.PBrush.HFore
				CE_PBack.SelectedColor = shp.DPen.PBrush.HBack
				cb_PHatchStyle.SelectedItem = shp.DPen.PBrush.HStyle.ToString
				CB_PGamma.Checked = shp.DPen.PBrush.LGamma
				TB_PAngle.Value = shp.DPen.PBrush.LinearAngle
				CB_DStyle.SelectedItem = shp.DPen.PDashstyle.ToString
				CB_DCap.SelectedItem = shp.DPen.PDashCap.ToString
				CB_SCap.SelectedItem = shp.DPen.PStartCap.ToString
				CB_ECap.SelectedItem = shp.DPen.PEndCap.ToString
				CB_LJoin.SelectedItem = shp.DPen.PLineJoin.ToString
				TB_PSX.Value = shp.DPen.ScaleX
				TB_PSY.Value = shp.DPen.ScaleY
				'glow
				CE_Glow.SelectedColor = shp.Glow.GlowColor
				TB_Glow.Value = shp.Glow.Glow
				TB_Feather.Value = shp.Glow.Feather
				cb_GStyle.SelectedItem = shp.Glow.GStyle.ToString
				cb_gfill.Checked = shp.Glow.BeforeFill
				cb_EGlow.Checked = shp.Glow.Enabled
				cb_GClip.SelectedItem = shp.Glow.GClip.ToString
				'shadow
				CE_Shadow.SelectedColor = shp.Shadow.ShadowColor
				TB_SBlur.Value = shp.Shadow.Blur
				TB_SFeather.Value = shp.Shadow.Feather
				cb_clip.Checked = shp.Shadow.RegionClipping
				cb_fill.Checked = shp.Shadow.Fill
				PS_Shadow.Value = shp.Shadow.Offset
				cb_EShadow.Checked = shp.Shadow.Enabled
				'shear
				TBShrX.Value = shp.ShearX
				TBShrY.Value = shp.ShearY
			Else
				PB_Texture.Image = Nothing
			End If
		Else
			PB_Texture.Image = Nothing
		End If
		UpdateBoundControls()
	End Sub

	Public Sub UpdateBoundControls()
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			ud_X.Value = shp.BaseRect.X
			ud_Y.Value = shp.BaseRect.Y
			ud_W.Value = shp.BaseRect.Width
			ud_H.Value = shp.BaseRect.Height
			ud_A.Value = shp.Angle
		Else
			ud_X.Value = 0
			ud_Y.Value = 0
			ud_W.Value = 0
			ud_H.Value = 0
			ud_A.Value = 0
		End If
	End Sub

	Private Sub UpdateSettings()
		Dim cn = MainCanvas()
		If Not IsNothing(cn) Then
			If cn.Text = "" Then cn.Text = tCanvas.SelectedTab.Text
			pSettings.Text = cn.Text & " Settings"
			set_BC.SelectedColor = cn.BackColor
			set_PB.Image = cn.BackgroundImage
			set_cname.Text = cn.Text
			set_r1.Checked = cn.Docked
			set_r2.Checked = Not cn.Docked
			If Not cn.Docked Then
				set_W.Value = cn.Width
				set_H.Value = cn.Height
			End If
			set_ord.SelectedItem = cn.SelectionOrder.ToString
			set_hgt.Checked = cn.HighlightShapes
			set_pclr.SelectedColor = cn.PathHighlightColor
			set_bclr.SelectedColor = cn.BorderHighlightColor
		End If
	End Sub
#End Region

#Region "Load"
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		CanvasControl1.baseCanvas.MainForm = Me
		MainCanvas = CanvasControl1.baseCanvas
		UpdateSettings()

		For Each str As String In [Enum].GetNames(GetType(MyShape.ShapeStyle))
			cb_Shape.Items.Add(str)
		Next
		cb_Shape.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(MyBrush.BrushType))
			cb_Brush.Items.Add(str)
		Next
		cb_Brush.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(HatchStyle))
			cb_HatchStyle.Items.Add(str)
			cb_PHatchStyle.Items.Add(str)
		Next
		cb_HatchStyle.SelectedIndex = 0
		cb_PHatchStyle.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(RotateFlipType))
			cb_RotateFlip.Items.Add(str)
		Next
		cb_RotateFlip.SelectedIndex = 1
		For Each str As String In [Enum].GetNames(GetType(DashStyle))
			CB_DStyle.Items.Add(str)
		Next
		CB_DStyle.Items.Remove("Custom")
		CB_DStyle.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(DashCap))
			CB_DCap.Items.Add(str)
		Next
		CB_DCap.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(LineCap))
			CB_SCap.Items.Add(str)
			CB_ECap.Items.Add(str)
		Next
		CB_SCap.Items.Remove("NoAnchor")
		CB_ECap.Items.Remove("NoAnchor")
		CB_SCap.Items.Remove("AnchorMask")
		CB_ECap.Items.Remove("AnchorMask")
		CB_SCap.Items.Remove("Custom")
		CB_ECap.Items.Remove("Custom")
		CB_SCap.SelectedIndex = 0
		CB_ECap.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(LineJoin))
			CB_LJoin.Items.Add(str)
		Next
		CB_LJoin.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(MyGlow.GlowStyle))
			cb_GStyle.Items.Add(str)
		Next
		cb_GStyle.SelectedIndex = 0
		For Each str As String In [Enum].GetNames(GetType(MyGlow.Clip))
			cb_GClip.Items.Add(str)
		Next
		cb_GClip.SelectedIndex = 0

		Dim args = My.Application.CommandLineArgs
		If args.Count > 0 Then
			OpenFiles(args.ToArray)
			If tCanvas.TabPages.Count > 1 Then
				tCanvas.TabPages.RemoveAt(0)
			End If
		End If

	End Sub
#End Region

#Region "ComboBox Drawing"
	Private Sub cb_Shape_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cb_Shape.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)
		Dim col_t As Color = Color.White

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
			col_t = Color.Black
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			Dim br As New LinearGradientBrush(TheBox.ClientRectangle, Color.SteelBlue, Color.Black, 0)
			e.Graphics.FillRectangle(br, e.Bounds)
		End If

		Dim rect As New Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, 20, e.Bounds.Height - 3)
		Dim shp As New Shape With {
			.BaseRect = rect
		}
		shp.MShape.SType = [Enum].Parse(GetType(MyShape.ShapeStyle), itemString)
		shp.DPen.PBrush.SolidColor = Color.Black
		shp.FBrush.SolidColor = Color.Black
		shp.MShape.Text = "AZ"
		shp.MShape.FontSize = 9
		shp.MShape.Spirals = 3

		shp.UpdatePath()

		Select Case shp.MShape.SType
			Case MyShape.ShapeStyle.Text
				shp.UpdateBrush()
				e.Graphics.FillPath(shp.FillBrush, shp.TotalPath)
			Case Else
				shp.UpdateSelectionPen()
				shp.UpdatePenBrush()
				e.Graphics.DrawPath(shp.CreatePen, shp.TotalPath)
		End Select

		e.Graphics.DrawString(itemString, sender.Font, New SolidBrush(col_t), e.Bounds.X + 25, e.Bounds.Y + 1)
		e.DrawFocusRectangle()
	End Sub

	Private Sub cb_Brush_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cb_Brush.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)
		Dim col_t As Color = Color.White

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
			col_t = Color.Black
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			Dim br As New LinearGradientBrush(TheBox.ClientRectangle, Color.SteelBlue, Color.Black, 0)
			e.Graphics.FillRectangle(br, e.Bounds)
		End If

		Dim rect As New Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, 20, e.Bounds.Height - 3)
		Dim shp As New Shape With {
			.BaseRect = rect
		}
		shp.FBrush.BType = [Enum].Parse(GetType(MyBrush.BrushType), itemString)
		shp.DPen.PBrush.SolidColor = Color.Black
		shp.FBrush.SolidColor = Color.White
		shp.FBrush.HStyle = HatchStyle.DiagonalCross

		Select Case shp.FBrush.BType
			Case MyBrush.BrushType.Texture
				e.Graphics.FillRectangle(Brushes.White, rect)
				Dim r1 As New Rectangle(rect.X, rect.Y + 4, rect.Width / 2, rect.Height - 4)
				Dim s1 As New Shape With {
					.BaseRect = r1
				}
				s1.MShape.SType = MyShape.ShapeStyle.Triangle
				s1.UpdatePath()
				e.Graphics.FillPath(Brushes.Brown, s1.TotalPath)
				Dim r2 As Rectangle = r1
				r2.X += 7 : r2.Y += 3 : r2.Width -= 1 : r2.Height -= 3
				s1.BaseRect = r2
				s1.UpdatePath()
				e.Graphics.FillPath(Brushes.Brown, s1.TotalPath)
				Dim r3 As New Rectangle(rect.Right - 7, rect.Y + 2, 5, 5)
				s1.BaseRect = r3
				s1.MShape.SType = MyShape.ShapeStyle.Ellipse
				s1.UpdatePath()
				e.Graphics.FillPath(Brushes.DarkOrange, s1.TotalPath)
				e.Graphics.DrawPath(shp.CreatePen, shp.TotalPath)
			Case Else
				e.Graphics.RenderingOrigin = rect.Location
				shp.UpdateBrush()
				e.Graphics.FillPath(shp.FillBrush, shp.TotalPath)
				shp.UpdateSelectionPen()
				shp.UpdatePenBrush()
				e.Graphics.DrawPath(shp.CreatePen, shp.TotalPath)
		End Select

		e.Graphics.DrawString(itemString, sender.Font, New SolidBrush(col_t), e.Bounds.X + 25, e.Bounds.Y + 1)
		e.DrawFocusRectangle()
	End Sub

	Private Sub cb_HatchStyle_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cb_HatchStyle.DrawItem, cb_PHatchStyle.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)
		Dim col_t As Color = Color.White

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
			col_t = Color.Black
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			Dim br As New LinearGradientBrush(TheBox.ClientRectangle, Color.SteelBlue, Color.Black, 0)
			e.Graphics.FillRectangle(br, e.Bounds)
		End If

		Dim rect As New Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, 20, e.Bounds.Height - 3)

		e.Graphics.RenderingOrigin = rect.Location

		Dim hb As New HatchBrush([Enum].Parse(GetType(HatchStyle), itemString), Color.Black, Color.White)

		e.Graphics.FillRectangle(hb, rect)
		e.Graphics.DrawRectangle(Pens.Black, rect)

		e.Graphics.DrawString(itemString, sender.Font, New SolidBrush(col_t), e.Bounds.X + 25, e.Bounds.Y + 1)
		e.DrawFocusRectangle()
	End Sub

	Private Sub CB_DCap_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CB_DCap.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
		End If

		Dim rect As Rectangle = e.Bounds
		rect.Height -= 1 : rect.Width -= 1
		Dim pty As Single = rect.Y + (rect.Height / 2)
		Dim p1 As New PointF(3, pty)
		Dim p2 As New PointF(rect.Width - 3, pty)
		Dim pn As New Pen(Color.Black, 10) With {
			.DashStyle = DashStyle.DashDot,
			.DashCap = [Enum].Parse(GetType(DashCap), itemString)
		}
		e.Graphics.DrawLine(pn, p1, p2)
		pn.Dispose()

		e.DrawFocusRectangle()
	End Sub

	Private Sub CB_DStyle_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CB_DStyle.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
		End If

		Dim rect As Rectangle = e.Bounds
		rect.Height -= 1 : rect.Width -= 1
		Dim pty As Single = rect.Y + (rect.Height / 2)
		Dim p1 As New PointF(3, pty)
		Dim p2 As New PointF(rect.Width - 3, pty)
		Dim pn As New Pen(Color.Black, 10) With {
			.DashStyle = [Enum].Parse(GetType(DashStyle), itemString),
			.DashCap = DashCap.Flat
		}
		e.Graphics.DrawLine(pn, p1, p2)
		pn.Dispose()

		e.DrawFocusRectangle()
	End Sub

	Private Sub CB_SCap_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CB_SCap.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
		End If

		Dim rect As Rectangle = e.Bounds
		rect.Height -= 1 : rect.Width -= 1
		Dim pty As Single = rect.Y + (rect.Height / 2)
		Dim p1 As New PointF(12, pty)
		Dim p2 As New PointF(rect.Width - 6, pty)
		Dim pn As New Pen(Color.Black, 8) With {
			.StartCap = [Enum].Parse(GetType(LineCap), itemString)
		}
		e.Graphics.DrawLine(pn, p1, p2)
		pn.Dispose()

		e.DrawFocusRectangle()
	End Sub

	Private Sub CB_ECap_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CB_ECap.DrawItem
		If e.Index < 0 Then Return

		e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

		Dim TheBox As ComboBox = CType(sender, ComboBox)
		Dim itemString As String = CType(TheBox.Items(e.Index), String)

		If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
			e.Graphics.FillRectangle(Brushes.White, e.Bounds)
		ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
		Else
			e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
		End If

		Dim rect As Rectangle = e.Bounds
		rect.Height -= 1 : rect.Width -= 1
		Dim pty As Single = rect.Y + (rect.Height / 2)
		Dim p1 As New PointF(6, pty)
		Dim p2 As New PointF(rect.Width - 12, pty)
		Dim pn As New Pen(Color.Black, 8) With {
			.EndCap = [Enum].Parse(GetType(LineCap), itemString)
		}
		e.Graphics.DrawLine(pn, p1, p2)
		pn.Dispose()

		e.DrawFocusRectangle()
	End Sub
#End Region

#Region "Shape&Brush"
	Private Sub cb_Shape_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Shape.SelectedIndexChanged
		If rDraw.Checked Then Return
		If Not IsNothing(MainShape) Then
			MainShape.MShape.SType = [Enum].Parse(GetType(MyShape.ShapeStyle), cb_Shape.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_Brush_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Brush.SelectedIndexChanged
		If tbFill.BackColor = Color.FromArgb(50, 50, 50) Then
			HideAllPanels()
			Select Case cb_Brush.SelectedItem
				Case "Solid"
					pSolid.Visible = True
				Case "LinearGradient"
					pLinear.Visible = True
				Case "PathGradient"
					pPath.Visible = True
				Case "Hatch"
					pHatch.Visible = True
				Case "Texture"
					pTexture.Visible = True
			End Select
		End If
		If rDraw.Checked Then Return
		If Not IsNothing(MainShape) Then
			MainShape.FBrush.BType = [Enum].Parse(GetType(MyBrush.BrushType), cb_Brush.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Solid"
	Private Sub CE_Solid_ColorChanged(sender As Object, e As EventArgs) Handles CE_Solid.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.SolidColor = CE_Solid.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Texture"
	Private Sub B_TImage_Click(sender As Object, e As EventArgs) Handles B_TImage.Click
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			openDialog.Multiselect = False
			openDialog.Title = "Choose Image"
			openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.gif; *.png"
			If openDialog.ShowDialog = DialogResult.OK Then
				Dim img As Image
				Using bmpTemp = New Bitmap(openDialog.FileName)
					img = New Bitmap(bmpTemp)
				End Using
				shp.FBrush.TImage = img
				PB_Texture.Image = shp.FBrush.TImage
			End If
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub B_TClip_Click(sender As Object, e As EventArgs) Handles B_TClip.Click
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			If My.Computer.Clipboard.ContainsImage() Then
				shp.FBrush.TImage = My.Computer.Clipboard.GetImage()
				PB_Texture.Image = shp.FBrush.TImage
			End If
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_Trans_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Trans.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.TTransparency = CB_Trans.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_Trans_ColorChanged(sender As Object, e As EventArgs) Handles CE_Trans.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.TColor = Color.FromArgb(255, CE_Trans.SelectedColor)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_RotateFlip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_RotateFlip.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.TRotateFlip = [Enum].Parse(GetType(RotateFlipType), cb_RotateFlip.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Hatch"
	Private Sub CE_H1_ColorChanged(sender As Object, e As EventArgs) Handles CE_H1.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.HFore = CE_H1.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_H2_ColorChanged(sender As Object, e As EventArgs) Handles CE_H2.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.HBack = CE_H2.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_HatchStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_HatchStyle.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.HStyle = [Enum].Parse(GetType(HatchStyle), cb_HatchStyle.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Linear Gradient"
	Private Sub CE_L1_ColorChanged(sender As Object, e As EventArgs) Handles CE_L1.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LColor1 = CE_L1.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_L2_ColorChanged(sender As Object, e As EventArgs) Handles CE_L2.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LColor2 = CE_L2.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_Gamma_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Gamma.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LGamma = CB_Gamma.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_LAngle_ValueChanged(sender As Object, e As EventArgs) Handles TB_LAngle.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LinearAngle = TB_LAngle.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_LTri_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LTri.CheckedChanged
		If CB_LTri.Checked Then CB_LBell.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LTriangular = CB_LTri.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub LTriFocus_ValueChanged(sender As Object, e As EventArgs) Handles LTriFocus.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LTriFocus = LTriFocus.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub LTriScale_ValueChanged(sender As Object, e As EventArgs) Handles LTriScale.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LTriScale = LTriScale.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_LBell_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LBell.CheckedChanged
		If CB_LBell.Checked Then CB_LTri.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LBell = CB_LBell.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub LBellFocus_ValueChanged(sender As Object, e As EventArgs) Handles LBellFocus.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LBellFocus = LBellFocus.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub LBellScale_ValueChanged(sender As Object, e As EventArgs) Handles LBellScale.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LBellScale = LBellScale.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_LColorBlend_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LColorBlend.CheckedChanged
		If CB_LColorBlend.Checked Then CB_LBlend.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LInterpolate = CB_LColorBlend.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub L_CBEditor_BlendChanged(sender As Object, e As EventArgs) Handles L_CBEditor.BlendChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LInterColors = L_CBEditor.Colors
			shp.FBrush.LInterPositions = L_CBEditor.Positions
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_LBlend_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LBlend.CheckedChanged
		If CB_LBlend.Checked Then CB_LColorBlend.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LBlend = CB_LBlend.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub L_BEditor_BlendChanged(sender As Object, e As EventArgs) Handles L_BEditor.BlendChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.LBlendFactors = L_BEditor.Factors
			shp.FBrush.LBlendPositions = L_BEditor.Positions
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Path Gradient"
	Private Sub CE_P1_ColorChanged(sender As Object, e As EventArgs) Handles CE_P1.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PCenter = CE_P1.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub B_Surround_Click(sender As Object, e As EventArgs) Handles B_Surround.Click
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			Dim dlg As New ColorListDialog
			dlg.LoadColors(shp.FBrush.PSurround)
			If dlg.ShowDialog = DialogResult.OK Then
				shp.FBrush.PSurround = dlg.GetColors
				MainCanvas.Invalidate()
			End If
		End If
	End Sub

	Private Sub PFocusX_ValueChanged(sender As Object, e As EventArgs) Handles PFocusX.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PFocusX = PFocusX.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PFocusY_ValueChanged(sender As Object, e As EventArgs) Handles PFocusY.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PFocusY = PFocusY.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_PTri_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PTri.CheckedChanged
		If CB_PTri.Checked Then CB_PBell.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PTriangular = CB_PTri.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PTriFocus_ValueChanged(sender As Object, e As EventArgs) Handles PTriFocus.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PTriFocus = PTriFocus.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PTriScale_ValueChanged(sender As Object, e As EventArgs) Handles PTriScale.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PTriScale = PTriScale.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_PBell_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PBell.CheckedChanged
		If CB_PBell.Checked Then CB_PTri.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PBell = CB_PBell.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PBellFocus_ValueChanged(sender As Object, e As EventArgs) Handles PBellFocus.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PBellFocus = PBellFocus.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PBellScale_ValueChanged(sender As Object, e As EventArgs) Handles PBellScale.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PBellScale = PBellScale.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_PColorBlend_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PColorBlend.CheckedChanged
		If CB_PColorBlend.Checked Then CB_PBlend.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PInterpolate = CB_PColorBlend.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub P_CBEditor_BlendChanged(sender As Object, e As EventArgs) Handles P_CBEditor.BlendChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PInterColors = P_CBEditor.Colors
			shp.FBrush.PInterPositions = P_CBEditor.Positions
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_PBlend_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PBlend.CheckedChanged
		If CB_PBlend.Checked Then CB_PColorBlend.Checked = False
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PBlend = CB_PBlend.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub P_BEditor_BlendChanged(sender As Object, e As EventArgs) Handles P_BEditor.BlendChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.FBrush.PBlendFactors = P_BEditor.Factors
			shp.FBrush.PBlendPositions = P_BEditor.Positions
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Operation"
	Private Sub rDraw_CheckedChanged(sender As Object, e As EventArgs) Handles rSelect.CheckedChanged, rDraw.CheckedChanged
		Dim cn = MainCanvas()
		If Not IsNothing(cn) Then
			cn.ClearDrawingData()
			cn.Invalidate()
		End If
	End Sub
#End Region

#Region "Pen"
	Private Sub rbp_CheckedChanged(sender As Object, e As EventArgs) Handles rbpSolid.CheckedChanged, rbpHatch.CheckedChanged, rbpLinear.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			If rbpSolid.Checked Then
				shp.DPen.PBrush.BType = MyBrush.BrushType.Solid
			ElseIf rbpLinear.Checked Then
				shp.DPen.PBrush.BType = MyBrush.BrushType.LinearGradient
			ElseIf rbpHatch.Checked Then
				shp.DPen.PBrush.BType = MyBrush.BrushType.Hatch
			End If
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PWidth_ValueChanged(sender As Object, e As EventArgs) Handles PWidth.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PWidth = PWidth.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_PSolid_ColorChanged(sender As Object, e As EventArgs) Handles CE_PSolid.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.SolidColor = CE_PSolid.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub LP_CBEditor_BlendChanged(sender As Object, e As EventArgs) Handles LP_CBEditor.BlendChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.LInterColors = LP_CBEditor.Colors
			shp.DPen.PBrush.LInterPositions = LP_CBEditor.Positions
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_PFore_ColorChanged(sender As Object, e As EventArgs) Handles CE_PFore.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.HFore = CE_PFore.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_PBack_ColorChanged(sender As Object, e As EventArgs) Handles CE_PBack.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.HBack = CE_PBack.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_PHatchStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_PHatchStyle.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.HStyle = [Enum].Parse(GetType(HatchStyle), cb_PHatchStyle.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_PGamma_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PGamma.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.LGamma = CB_PGamma.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_PAngle_ValueChanged(sender As Object, e As EventArgs) Handles TB_PAngle.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PBrush.LinearAngle = TB_PAngle.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_DStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_DStyle.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PDashstyle = [Enum].Parse(GetType(DashStyle), CB_DStyle.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_DCap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_DCap.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PDashCap = [Enum].Parse(GetType(DashCap), CB_DCap.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_SCap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SCap.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PStartCap = [Enum].Parse(GetType(LineCap), CB_SCap.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_ECap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_ECap.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PEndCap = [Enum].Parse(GetType(LineCap), CB_ECap.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CB_LJoin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_LJoin.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.PLineJoin = [Enum].Parse(GetType(LineJoin), CB_LJoin.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_PSX_ValueChanged(sender As Object, e As EventArgs) Handles TB_PSX.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.ScaleX = TB_PSX.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_PSY_ValueChanged(sender As Object, e As EventArgs) Handles TB_PSY.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.DPen.ScaleY = TB_PSY.Value
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Size"
	Private Sub ud_X_Leave(sender As Object, e As EventArgs) Handles ud_Y.Leave, ud_X.Leave, ud_W.Leave, ud_H.Leave
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			MainCanvas.FinalizeResize(shp)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub ud_X_ValueChanged(sender As Object, e As EventArgs) Handles ud_X.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			Dim rect = shp.BaseRect
			rect.X = ud_X.Value
			shp.BaseRect = rect
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub ud_Y_ValueChanged(sender As Object, e As EventArgs) Handles ud_Y.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			Dim rect = shp.BaseRect
			rect.Y = ud_Y.Value
			shp.BaseRect = rect
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub ud_W_ValueChanged(sender As Object, e As EventArgs) Handles ud_W.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			Dim rect = shp.BaseRect
			rect.Width = ud_W.Value
			shp.BaseRect = rect
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub ud_H_ValueChanged(sender As Object, e As EventArgs) Handles ud_H.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			Dim rect = shp.BaseRect
			rect.Height = ud_H.Value
			shp.BaseRect = rect
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub ud_A_ValueChanged(sender As Object, e As EventArgs) Handles ud_A.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Angle = ud_A.Value
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Shape"
	Private Sub bShape_Click(sender As Object, e As EventArgs) Handles bShape.Click
		Dim shp As Shape = MainShape
		If Not IsNothing(shp) Then
			Select Case shp.MShape.SType
				Case MyShape.ShapeStyle.Lines, MyShape.ShapeStyle.Polygon,
					 MyShape.ShapeStyle.Curves, MyShape.ShapeStyle.ClosedCurve
					Dim dlg As New PointsEditor(shp, MainCanvas)
					If dlg.ShowDialog = DialogResult.OK Then
						Select Case shp.MShape.SType
							Case MyShape.ShapeStyle.Polygon, MyShape.ShapeStyle.Lines
								shp.MShape.PolygonPoints = dlg.PEditor.Points
							Case MyShape.ShapeStyle.Curves, MyShape.ShapeStyle.ClosedCurve
								shp.MShape.CurvePoints = dlg.PEditor.Points
								shp.MShape.Tension = dlg.TB_Tension.Value
						End Select
					Else
						dlg.RestoreOld()
					End If
				Case MyShape.ShapeStyle.RoundedRectangle
					Dim dlg As New CornersDialog(shp, MainCanvas)
					dlg.ShowDialog()
				Case MyShape.ShapeStyle.Arc, MyShape.ShapeStyle.Pie
					Dim dlg As New AnglesDialog(shp, MainCanvas)
					dlg.ShowDialog()
				Case MyShape.ShapeStyle.Spiral
					Dim dlg As New SpiralDialog(shp, MainCanvas)
					dlg.ShowDialog()
				Case MyShape.ShapeStyle.Text
					Dim dlg As New TextEditor(shp)
					If dlg.ShowDialog = DialogResult.OK Then
						shp.MShape.FontName = dlg.TBox.Font.Name
						shp.MShape.FontSize = dlg.TBox.Font.Size
						shp.MShape.FontStyle = dlg.TBox.Font.Style
						shp.MShape.Text = dlg.TBox.Text
						shp.MShape.TextAlignment = [Enum].Parse(GetType(ContentAlignment), dlg.cb_Align.SelectedItem)
					End If
			End Select
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Glow"
	Private Sub TB_Feather_ValueChanged(sender As Object, e As EventArgs) Handles TB_Feather.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.Feather = TB_Feather.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_Glow_ValueChanged(sender As Object, e As EventArgs) Handles TB_Glow.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.Glow = TB_Glow.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub CE_Glow_ColorChanged(sender As Object, e As EventArgs) Handles CE_Glow.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.GlowColor = CE_Glow.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_GStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_GStyle.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.GStyle = [Enum].Parse(GetType(MyGlow.GlowStyle), cb_GStyle.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_gfill_CheckedChanged(sender As Object, e As EventArgs) Handles cb_gfill.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.BeforeFill = cb_gfill.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_EGlow_CheckedChanged(sender As Object, e As EventArgs) Handles cb_EGlow.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.Enabled = cb_EGlow.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_GClip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_GClip.SelectedIndexChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Glow.GClip = [Enum].Parse(GetType(MyGlow.Clip), cb_GClip.SelectedItem)
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Shadow"
	Private Sub CE_Shadow_ColorChanged(sender As Object, e As EventArgs) Handles CE_Shadow.ColorChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.ShadowColor = CE_Shadow.SelectedColor
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_SBlur_ValueChanged(sender As Object, e As EventArgs) Handles TB_SBlur.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.Blur = TB_SBlur.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TB_SFeather_ValueChanged(sender As Object, e As EventArgs) Handles TB_SFeather.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.Feather = TB_SFeather.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_clip_CheckedChanged(sender As Object, e As EventArgs) Handles cb_clip.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.RegionClipping = cb_clip.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_fill_CheckedChanged(sender As Object, e As EventArgs) Handles cb_fill.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.Fill = cb_fill.Checked
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub PS_Shadow_ValueChanged(sender As Object, e As EventArgs) Handles PS_Shadow.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.Offset = PS_Shadow.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub cb_EShadow_CheckedChanged(sender As Object, e As EventArgs) Handles cb_EShadow.CheckedChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.Shadow.Enabled = cb_EShadow.Checked
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Custom Tabs"
	Private Sub HideAllPanels()
		pSolid.Visible = False
		pLinear.Visible = False
		pPath.Visible = False
		pHatch.Visible = False
		pTexture.Visible = False
		pStroke.Visible = False
		pGlow.Visible = False
		pShadow.Visible = False
	End Sub

	Private Sub tbGlow_Click(sender As Object, e As EventArgs) Handles tbGlow.Click
		tbFill.BackColor = Color.Black
		tbFill.DrawEffect = True
		tbStroke.BackColor = Color.Black
		tbStroke.DrawEffect = True
		tbShadow.BackColor = Color.Black
		tbShadow.DrawEffect = True
		tbGlow.BackColor = Color.FromArgb(50, 50, 50)
		tbGlow.DrawEffect = False
		HideAllPanels()
		pGlow.Visible = True
		pGlow.Focus()
	End Sub

	Private Sub tbShadow_Click(sender As Object, e As EventArgs) Handles tbShadow.Click
		tbFill.BackColor = Color.Black
		tbFill.DrawEffect = True
		tbStroke.BackColor = Color.Black
		tbStroke.DrawEffect = True
		tbGlow.BackColor = Color.Black
		tbGlow.DrawEffect = True
		tbShadow.BackColor = Color.FromArgb(50, 50, 50)
		tbShadow.DrawEffect = False
		HideAllPanels()
		pShadow.Visible = True
		pShadow.Focus()
	End Sub

	Private Sub tbStroke_Click(sender As Object, e As EventArgs) Handles tbStroke.Click
		tbFill.BackColor = Color.Black
		tbFill.DrawEffect = True
		tbGlow.BackColor = Color.Black
		tbGlow.DrawEffect = True
		tbShadow.BackColor = Color.Black
		tbShadow.DrawEffect = True
		tbStroke.BackColor = Color.FromArgb(50, 50, 50)
		tbStroke.DrawEffect = False
		HideAllPanels()
		pStroke.Visible = True
		pStroke.Focus()
	End Sub

	Private Sub tbFill_Click(sender As Object, e As EventArgs) Handles tbFill.Click
		tbGlow.BackColor = Color.Black
		tbGlow.DrawEffect = True
		tbStroke.BackColor = Color.Black
		tbStroke.DrawEffect = True
		tbShadow.BackColor = Color.Black
		tbShadow.DrawEffect = True
		tbFill.BackColor = Color.FromArgb(50, 50, 50)
		tbFill.DrawEffect = False
		HideAllPanels()
		Select Case cb_Brush.SelectedItem
			Case "Solid"
				pSolid.Visible = True
				pSolid.Focus()
			Case "LinearGradient"
				pLinear.Visible = True
				pLinear.Focus()
			Case "PathGradient"
				pPath.Visible = True
				pPath.Focus()
			Case "Hatch"
				pHatch.Visible = True
				pHatch.Focus()
			Case "Texture"
				pTexture.Visible = True
				pTexture.Focus()
		End Select
	End Sub
#End Region

#Region "Menu Buttons"
	Private Sub btClone_Click(sender As Object, e As EventArgs) Handles btClone.Click
		If Not IsNothing(MainCanvas) Then
			MainCanvas.CloneSelected()
		End If
	End Sub

	Private Sub btFront_Click(sender As Object, e As EventArgs) Handles btFront.Click
		If Not IsNothing(MainCanvas) Then
			MainCanvas.ToFront()
		End If
	End Sub

	Private Sub btBack_Click(sender As Object, e As EventArgs) Handles btBack.Click
		If Not IsNothing(MainCanvas) Then
			MainCanvas.ToBack()
		End If
	End Sub

	Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
		If Not IsNothing(MainCanvas) Then
			MainCanvas.DeleteSelected()
		End If
	End Sub
#End Region

#Region "Side Bar"
	Private Sub btMenu_Click(sender As Object, e As EventArgs) Handles btMenu.Click
		If pSideBar.Width = 45 Then
			pSideBar.Width = 180
			btMenu.DrawText = True
			btSave.DrawText = True
			btOpen.DrawText = True
			btSettings.DrawText = True
			btExit.DrawText = True
			btNewC.DrawText = True
		Else
			pSideBar.Width = 45
			btMenu.DrawText = False
			btSave.DrawText = False
			btOpen.DrawText = False
			btSettings.DrawText = False
			btExit.DrawText = False
			btNewC.DrawText = False
		End If
	End Sub

	Private Sub pSideBar_Leave(sender As Object, e As EventArgs) Handles pSideBar.Leave
		If Not pSideBar.Width = 45 Then
			pSideBar.Width = 45
			btMenu.DrawText = False
			btSave.DrawText = False
			btOpen.DrawText = False
			btSettings.DrawText = False
			btExit.DrawText = False
			btNewC.DrawText = False
		End If
	End Sub

	Private Sub btNewC_Click(sender As Object, e As EventArgs) Handles btNewC.Click
		Dim cn As New CanvasControl
		cn.baseCanvas.BackColor = Color.Transparent
		cn.baseCanvas.MainForm = Me
		cn.Dock = DockStyle.Fill
		cn.Text = "Canvas" & tCanvas.TabCount + 1
		Dim tp As New TabPage(cn.Text) With {
			.BorderStyle = BorderStyle.FixedSingle
		}
		tp.Controls.Add(cn)
		tCanvas.TabPages.Add(tp)
		tCanvas.SelectedTab = tp
		MainCanvas = CurrentCanvas()
	End Sub

	Public Sub OpenFiles(paths As String())
		For Each str As String In paths
			Dim cn As New CanvasControl
			cn.baseCanvas.BackColor = Color.Transparent
			cn.baseCanvas.MainForm = Me
			cn.Dock = DockStyle.Fill
			Dim op = cn.baseCanvas.LoadProject(str)
			If Not IsNothing(op) Then
				cn.Dispose()
				MessageBox.Show(op.Message)
				Continue For
			End If
			cn.Text = Path.GetFileNameWithoutExtension(str)
			Dim tp As New TabPage(cn.Text) With {
				.BorderStyle = BorderStyle.FixedSingle
			}
			tp.Controls.Add(cn)
			tCanvas.TabPages.Add(tp)
			tCanvas.SelectedTab = tp
		Next
	End Sub

	Private Sub btOpen_Click(sender As Object, e As EventArgs) Handles btOpen.Click
		openDialog.Multiselect = True
		openDialog.Title = "Choose Project File"
		openDialog.Filter = "Binary File (*.bin)|*.bin|JSON File (*.json)|*.json"
		If openDialog.ShowDialog = DialogResult.OK Then
			OpenFiles(openDialog.FileNames)
		End If
	End Sub

	Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
		Dim cn = MainCanvas()
		If IsNothing(cn) Then Return
		saveDialog.Title = "Save As"
		saveDialog.Filter = "Binary File (*.bin)|*.bin|Image File (*.png)|*.png|JSON File (*.json)|*.json"
		saveDialog.DefaultExt = "*.bin"
		saveDialog.FileName = cn.Text
		If saveDialog.ShowDialog = DialogResult.OK Then
			Dim inf As New FileInfo(saveDialog.FileName)
			Select Case inf.Extension.ToLower
				Case ".bin", ".json"
					Dim op = cn.SaveProject(saveDialog.FileName)
					If Not IsNothing(op) Then
						MessageBox.Show(op.Message)
					End If
				Case ".png"
					Dim op = cn.SaveImage(saveDialog.FileName)
					If Not IsNothing(op) Then
						MessageBox.Show(op.Message)
					End If
				Case Else
					MessageBox.Show("Invalid Type!")
			End Select
		End If
	End Sub

	Private Sub btSettings_Click(sender As Object, e As EventArgs) Handles btSettings.Click
		UpdateSettings()
		pSettings.Visible = True
	End Sub

	Private Sub btExit_Click(sender As Object, e As EventArgs) Handles btExit.Click
		Close()
	End Sub
#End Region

#Region "Settings"
	Private Sub set_lpic_Click(sender As Object, e As EventArgs) Handles set_lpic.Click
		openDialog.Multiselect = False
		openDialog.Title = "Choose Image"
		openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.gif; *.png"
		If openDialog.ShowDialog = DialogResult.OK Then
			Dim img As Image
			Using bmpTemp = New Bitmap(openDialog.FileName)
				img = New Bitmap(bmpTemp)
			End Using
			set_PB.Image = img
		End If
	End Sub

	Private Sub set_cpic_Click(sender As Object, e As EventArgs) Handles set_cpic.Click
		set_PB.Image = Nothing
	End Sub

	Private Sub set_r1_CheckedChanged(sender As Object, e As EventArgs) Handles set_r2.CheckedChanged, set_r1.CheckedChanged
		set_W.Enabled = set_r2.Checked
		set_H.Enabled = set_W.Enabled
	End Sub

	Private Sub set_Apply_Click(sender As Object, e As EventArgs) Handles set_Apply.Click
		Dim cn = MainCanvas()
		If Not IsNothing(cn) Then
			cn.BackColor = set_BC.SelectedColor
			cn.BackgroundImage = set_PB.Image
			cn.Text = set_cname.Text
			cn.Docked = set_r1.Checked
			If Not cn.Docked Then
				cn.Width = set_W.Value
				cn.Height = set_H.Value
			End If
			cn.SelectionOrder = [Enum].Parse(GetType(Canvas.SelectOrder), set_ord.SelectedItem)
			cn.HighlightShapes = set_hgt.Checked
			cn.PathHighlightColor = set_pclr.SelectedColor
			cn.BorderHighlightColor = set_bclr.SelectedColor
			tCanvas.SelectedTab.Text = cn.Text
			CurrentCanvasControl.SetSize()
			pSettings.Visible = False
		End If
	End Sub

#End Region

#Region "Shear"
	Private Sub TBShrX_ValueChanged(sender As Object, e As EventArgs) Handles TBShrX.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.ShearX = TBShrX.Value
			MainCanvas.Invalidate()
		End If
	End Sub

	Private Sub TBShrY_ValueChanged(sender As Object, e As EventArgs) Handles TBShrY.ValueChanged
		If Not IsNothing(MainShape) Then
			Dim shp As Shape = MainShape
			shp.ShearY = TBShrY.Value
			MainCanvas.Invalidate()
		End If
	End Sub
#End Region

#Region "Keyboard"
	Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyData = Keys.F12 Then pShear.Visible = Not pShear.Visible
	End Sub
#End Region

#Region "DragDrop"
	Private Sub tCanvas_DragEnter(sender As Object, e As DragEventArgs) Handles tCanvas.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub

	Private Sub tCanvas_DragDrop(sender As Object, e As DragEventArgs) Handles tCanvas.DragDrop
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			Dim args As String() = e.Data.GetData(DataFormats.FileDrop)
			OpenFiles(args)
		End If
	End Sub

#End Region

End Class
