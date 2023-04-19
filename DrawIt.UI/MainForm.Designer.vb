<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(MainForm))
		openDialog = New OpenFileDialog()
		saveDialog = New SaveFileDialog()
		pSettings = New Controls.MovablePanel()
		Label64 = New Label()
		set_cname = New TextBox()
		set_cpic = New Controls.MyButton()
		set_lpic = New Controls.MyButton()
		set_PB = New PictureBox()
		set_ord = New ComboBox()
		set_Apply = New Controls.MyButton()
		Label25 = New Label()
		Label22 = New Label()
		set_bclr = New Controls.ColorEditorButton()
		set_pclr = New Controls.ColorEditorButton()
		set_hgt = New CheckBox()
		set_H = New NumericUpDown()
		set_W = New NumericUpDown()
		Label60 = New Label()
		Label19 = New Label()
		Label59 = New Label()
		Label63 = New Label()
		Label3 = New Label()
		set_BC = New Controls.ColorEditorButton()
		pSideBar = New Controls.MyPanel()
		btNewC = New Controls.FlatButton()
		btExit = New Controls.FlatButton()
		btSettings = New Controls.FlatButton()
		btSave = New Controls.FlatButton()
		btOpen = New Controls.FlatButton()
		btMenu = New Controls.FlatButton()
		tTop = New Controls.MyPanel()
		btDelete = New Controls.FlatButton()
		btClone = New Controls.FlatButton()
		btBack = New Controls.FlatButton()
		btFront = New Controls.FlatButton()
		cb_Brush = New ComboBox()
		cb_Shape = New ComboBox()
		rDraw = New RadioButton()
		rSelect = New RadioButton()
		Label29 = New Label()
		Label1 = New Label()
		tbShadow = New Controls.MyButton()
		tbGlow = New Controls.MyButton()
		tBottom = New Controls.MyPanel()
		TBZoom = New Controls.MyTrackBar()
		bResetZoom = New Controls.MyButton()
		bShape = New Controls.MyButton()
		Label51 = New Label()
		Label49 = New Label()
		Label48 = New Label()
		Label47 = New Label()
		Label46 = New Label()
		Label45 = New Label()
		ud_A = New NumericUpDown()
		ud_H = New NumericUpDown()
		ud_W = New NumericUpDown()
		ud_Y = New NumericUpDown()
		ud_X = New NumericUpDown()
		tbStroke = New Controls.MyButton()
		tbFill = New Controls.MyButton()
		pMain = New Controls.MyPanel()
		pShadow = New Controls.MyPanel()
		PS_Shadow = New Controls.PointSelector()
		TB_SFeather = New Controls.MyTrackBar()
		Label55 = New Label()
		TB_SBlur = New Controls.MyTrackBar()
		Label57 = New Label()
		Label56 = New Label()
		cb_EShadow = New CheckBox()
		cb_clip = New CheckBox()
		cb_fill = New CheckBox()
		Label58 = New Label()
		CE_Shadow = New Controls.ColorEditorButton()
		pGlow = New Controls.MyPanel()
		cb_EGlow = New CheckBox()
		TB_Feather = New Controls.MyTrackBar()
		Label54 = New Label()
		TB_Glow = New Controls.MyTrackBar()
		Label53 = New Label()
		cb_gfill = New CheckBox()
		cb_GClip = New ComboBox()
		Label2 = New Label()
		cb_GStyle = New ComboBox()
		Label52 = New Label()
		Label50 = New Label()
		CE_Glow = New Controls.ColorEditorButton()
		pSolid = New Controls.MyPanel()
		Label4 = New Label()
		CE_Solid = New Controls.ColorEditorButton()
		pLinear = New Controls.MyPanel()
		L_CBEditor = New Controls.ColorBlendEditor()
		L_BEditor = New Controls.BlendEditor()
		LBellScale = New Controls.MyTrackBar()
		LTriScale = New Controls.MyTrackBar()
		Label11 = New Label()
		Label9 = New Label()
		LBellFocus = New Controls.MyTrackBar()
		LTriFocus = New Controls.MyTrackBar()
		Label10 = New Label()
		Label8 = New Label()
		TB_LAngle = New Controls.MyTrackBar()
		Label7 = New Label()
		CB_LBlend = New CheckBox()
		CB_LColorBlend = New CheckBox()
		CB_LBell = New CheckBox()
		CB_LTri = New CheckBox()
		CB_Gamma = New CheckBox()
		Label6 = New Label()
		Label5 = New Label()
		CE_L2 = New Controls.ColorEditorButton()
		CE_L1 = New Controls.ColorEditorButton()
		pStroke = New Controls.MyPanel()
		LP_CBEditor = New Controls.ColorBlendEditor()
		TB_PSY = New Controls.MyTrackBar()
		Label44 = New Label()
		TB_PSX = New Controls.MyTrackBar()
		Label43 = New Label()
		Label42 = New Label()
		CB_LJoin = New ComboBox()
		Label41 = New Label()
		CB_ECap = New ComboBox()
		Label40 = New Label()
		CB_SCap = New ComboBox()
		Label39 = New Label()
		CB_DCap = New ComboBox()
		Label36 = New Label()
		CB_DStyle = New ComboBox()
		Label35 = New Label()
		TB_PAngle = New Controls.MyTrackBar()
		Label34 = New Label()
		CB_PGamma = New CheckBox()
		PWidth = New Controls.MyTrackBar()
		Label33 = New Label()
		cb_PHatchStyle = New ComboBox()
		Label30 = New Label()
		Label31 = New Label()
		CE_PBack = New Controls.ColorEditorButton()
		CE_PFore = New Controls.ColorEditorButton()
		Label32 = New Label()
		rbpHatch = New RadioButton()
		rbpLinear = New RadioButton()
		rbpSolid = New RadioButton()
		Label37 = New Label()
		CE_PSolid = New Controls.ColorEditorButton()
		Label38 = New Label()
		pPath = New Controls.MyPanel()
		P_CBEditor = New Controls.ColorBlendEditor()
		P_BEditor = New Controls.BlendEditor()
		B_Surround = New Controls.MyButton()
		PFocusY = New Controls.MyTrackBar()
		Label27 = New Label()
		PFocusX = New Controls.MyTrackBar()
		Label28 = New Label()
		PBellScale = New Controls.MyTrackBar()
		PTriScale = New Controls.MyTrackBar()
		Label12 = New Label()
		Label13 = New Label()
		PBellFocus = New Controls.MyTrackBar()
		PTriFocus = New Controls.MyTrackBar()
		Label14 = New Label()
		Label15 = New Label()
		CB_PBlend = New CheckBox()
		CB_PColorBlend = New CheckBox()
		CB_PBell = New CheckBox()
		CB_PTri = New CheckBox()
		Label17 = New Label()
		Label18 = New Label()
		CE_P1 = New Controls.ColorEditorButton()
		pTexture = New Controls.MyPanel()
		cb_RotateFlip = New ComboBox()
		Label26 = New Label()
		B_TImage = New Controls.MyButton()
		B_TClip = New Controls.MyButton()
		Label20 = New Label()
		PB_Texture = New PictureBox()
		CB_Trans = New CheckBox()
		Label21 = New Label()
		CE_Trans = New Controls.ColorEditorButton()
		pHatch = New Controls.MyPanel()
		cb_HatchStyle = New ComboBox()
		Label23 = New Label()
		Label24 = New Label()
		CE_H2 = New Controls.ColorEditorButton()
		CE_H1 = New Controls.ColorEditorButton()
		Label16 = New Label()
		tCanvas = New Controls.MyTabControl()
		TabPage1 = New TabPage()
		CanvasControl1 = New CanvasControl()
		pShear = New Controls.MovablePanel()
		TBShrY = New Controls.MyTrackBar()
		Label62 = New Label()
		TBShrX = New Controls.MyTrackBar()
		Label61 = New Label()
		pCanvas = New Controls.MyPanel()
		pSettings.SuspendLayout()
		CType(set_PB, ComponentModel.ISupportInitialize).BeginInit()
		CType(set_H, ComponentModel.ISupportInitialize).BeginInit()
		CType(set_W, ComponentModel.ISupportInitialize).BeginInit()
		pSideBar.SuspendLayout()
		tTop.SuspendLayout()
		tBottom.SuspendLayout()
		CType(ud_A, ComponentModel.ISupportInitialize).BeginInit()
		CType(ud_H, ComponentModel.ISupportInitialize).BeginInit()
		CType(ud_W, ComponentModel.ISupportInitialize).BeginInit()
		CType(ud_Y, ComponentModel.ISupportInitialize).BeginInit()
		CType(ud_X, ComponentModel.ISupportInitialize).BeginInit()
		pMain.SuspendLayout()
		pShadow.SuspendLayout()
		pGlow.SuspendLayout()
		pSolid.SuspendLayout()
		pLinear.SuspendLayout()
		pStroke.SuspendLayout()
		pPath.SuspendLayout()
		pTexture.SuspendLayout()
		CType(PB_Texture, ComponentModel.ISupportInitialize).BeginInit()
		pHatch.SuspendLayout()
		tCanvas.SuspendLayout()
		TabPage1.SuspendLayout()
		pShear.SuspendLayout()
		pCanvas.SuspendLayout()
		SuspendLayout()
		' 
		' openDialog
		' 
		openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.gif; *.png"""
		openDialog.Title = "Choose Image"
		' 
		' pSettings
		' 
		pSettings.BackColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
		pSettings.Controls.Add(Label64)
		pSettings.Controls.Add(set_cname)
		pSettings.Controls.Add(set_cpic)
		pSettings.Controls.Add(set_lpic)
		pSettings.Controls.Add(set_PB)
		pSettings.Controls.Add(set_ord)
		pSettings.Controls.Add(set_Apply)
		pSettings.Controls.Add(Label25)
		pSettings.Controls.Add(Label22)
		pSettings.Controls.Add(set_bclr)
		pSettings.Controls.Add(set_pclr)
		pSettings.Controls.Add(set_hgt)
		pSettings.Controls.Add(set_H)
		pSettings.Controls.Add(set_W)
		pSettings.Controls.Add(Label60)
		pSettings.Controls.Add(Label19)
		pSettings.Controls.Add(Label59)
		pSettings.Controls.Add(Label63)
		pSettings.Controls.Add(Label3)
		pSettings.Controls.Add(set_BC)
		pSettings.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		pSettings.ForeColor = Color.White
		pSettings.Location = New Point(850, 48)
		pSettings.Margin = New Padding(4, 5, 4, 5)
		pSettings.Name = "pSettings"
		pSettings.Resizable = False
		pSettings.Size = New Size(250, 466)
		pSettings.TabIndex = 8
		pSettings.Text = "Settings"
		pSettings.Visible = False
		' 
		' Label64
		' 
		Label64.Anchor = AnchorStyles.Bottom
		Label64.AutoSize = True
		Label64.BackColor = Color.Transparent
		Label64.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label64.Location = New Point(4, 216)
		Label64.Name = "Label64"
		Label64.Size = New Size(38, 13)
		Label64.TabIndex = 20
		Label64.Text = "Name:"
		' 
		' set_cname
		' 
		set_cname.Anchor = AnchorStyles.Bottom
		set_cname.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		set_cname.Location = New Point(6, 230)
		set_cname.MaxLength = 30
		set_cname.Name = "set_cname"
		set_cname.Size = New Size(238, 25)
		set_cname.TabIndex = 19
		' 
		' set_cpic
		' 
		set_cpic.Anchor = AnchorStyles.None
		set_cpic.BackColor = Color.Black
		set_cpic.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		set_cpic.ForeColor = Color.White
		set_cpic.Location = New Point(189, 108)
		set_cpic.MyText = "Clear"
		set_cpic.Name = "set_cpic"
		set_cpic.Size = New Size(58, 25)
		set_cpic.TabIndex = 18
		' 
		' set_lpic
		' 
		set_lpic.Anchor = AnchorStyles.None
		set_lpic.BackColor = Color.Black
		set_lpic.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		set_lpic.ForeColor = Color.White
		set_lpic.Location = New Point(188, 77)
		set_lpic.MyText = "Load"
		set_lpic.Name = "set_lpic"
		set_lpic.Size = New Size(58, 25)
		set_lpic.TabIndex = 18
		' 
		' set_PB
		' 
		set_PB.BorderStyle = BorderStyle.FixedSingle
		set_PB.Location = New Point(3, 77)
		set_PB.Name = "set_PB"
		set_PB.Size = New Size(179, 135)
		set_PB.SizeMode = PictureBoxSizeMode.StretchImage
		set_PB.TabIndex = 17
		set_PB.TabStop = False
		' 
		' set_ord
		' 
		set_ord.Anchor = AnchorStyles.Bottom
		set_ord.DropDownStyle = ComboBoxStyle.DropDownList
		set_ord.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		set_ord.FormattingEnabled = True
		set_ord.Items.AddRange(New Object() {"AboveFirst", "BelowFirst"})
		set_ord.Location = New Point(92, 294)
		set_ord.Name = "set_ord"
		set_ord.Size = New Size(154, 25)
		set_ord.TabIndex = 10
		' 
		' set_Apply
		' 
		set_Apply.Anchor = AnchorStyles.Bottom
		set_Apply.BackColor = Color.Black
		set_Apply.ForeColor = Color.White
		set_Apply.Location = New Point(88, 421)
		set_Apply.MyText = "Apply"
		set_Apply.Name = "set_Apply"
		set_Apply.Size = New Size(75, 30)
		set_Apply.TabIndex = 16
		' 
		' Label25
		' 
		Label25.Anchor = AnchorStyles.Bottom
		Label25.AutoSize = True
		Label25.BackColor = Color.Transparent
		Label25.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label25.Location = New Point(27, 398)
		Label25.Name = "Label25"
		Label25.Size = New Size(41, 13)
		Label25.TabIndex = 14
		Label25.Text = "Border:"
		' 
		' Label22
		' 
		Label22.Anchor = AnchorStyles.Bottom
		Label22.AutoSize = True
		Label22.BackColor = Color.Transparent
		Label22.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label22.Location = New Point(27, 368)
		Label22.Name = "Label22"
		Label22.Size = New Size(32, 13)
		Label22.TabIndex = 12
		Label22.Text = "Path:"
		' 
		' set_bclr
		' 
		set_bclr.Anchor = AnchorStyles.Bottom
		set_bclr.BackColor = Color.White
		set_bclr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_bclr.Location = New Point(75, 392)
		set_bclr.Margin = New Padding(4, 5, 4, 5)
		set_bclr.MyText = "ChooseColor"
		set_bclr.Name = "set_bclr"
		set_bclr.SelectedColor = Color.FromArgb(CByte(0), CByte(255), CByte(0))
		set_bclr.Size = New Size(170, 25)
		set_bclr.TabIndex = 15
		' 
		' set_pclr
		' 
		set_pclr.Anchor = AnchorStyles.Bottom
		set_pclr.BackColor = Color.White
		set_pclr.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_pclr.Location = New Point(75, 362)
		set_pclr.Margin = New Padding(4, 5, 4, 5)
		set_pclr.MyText = "ChooseColor"
		set_pclr.Name = "set_pclr"
		set_pclr.SelectedColor = Color.FromArgb(CByte(0), CByte(0), CByte(255))
		set_pclr.Size = New Size(170, 25)
		set_pclr.TabIndex = 13
		' 
		' set_hgt
		' 
		set_hgt.Anchor = AnchorStyles.Bottom
		set_hgt.AutoSize = True
		set_hgt.BackColor = Color.Transparent
		set_hgt.Checked = True
		set_hgt.CheckState = CheckState.Checked
		set_hgt.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_hgt.Location = New Point(5, 342)
		set_hgt.Name = "set_hgt"
		set_hgt.Size = New Size(106, 17)
		set_hgt.TabIndex = 11
		set_hgt.Text = "Highlight Shapes"
		set_hgt.UseVisualStyleBackColor = False
		' 
		' set_H
		' 
		set_H.Anchor = AnchorStyles.Bottom
		set_H.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_H.Location = New Point(174, 263)
		set_H.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		set_H.Minimum = New [Decimal](New Integer() {10, 0, 0, 0})
		set_H.Name = "set_H"
		set_H.Size = New Size(70, 20)
		set_H.TabIndex = 8
		set_H.Value = New [Decimal](New Integer() {500, 0, 0, 0})
		' 
		' set_W
		' 
		set_W.Anchor = AnchorStyles.Bottom
		set_W.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_W.Location = New Point(47, 263)
		set_W.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		set_W.Minimum = New [Decimal](New Integer() {10, 0, 0, 0})
		set_W.Name = "set_W"
		set_W.Size = New Size(70, 20)
		set_W.TabIndex = 6
		set_W.Value = New [Decimal](New Integer() {500, 0, 0, 0})
		' 
		' Label60
		' 
		Label60.Anchor = AnchorStyles.Bottom
		Label60.AutoSize = True
		Label60.BackColor = Color.Transparent
		Label60.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label60.Location = New Point(131, 266)
		Label60.Name = "Label60"
		Label60.Size = New Size(41, 13)
		Label60.TabIndex = 7
		Label60.Text = "Height:"
		' 
		' Label19
		' 
		Label19.Anchor = AnchorStyles.Bottom
		Label19.AutoSize = True
		Label19.BackColor = Color.Transparent
		Label19.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label19.Location = New Point(5, 300)
		Label19.Name = "Label19"
		Label19.Size = New Size(83, 13)
		Label19.TabIndex = 9
		Label19.Text = "Selection Order:"
		' 
		' Label59
		' 
		Label59.Anchor = AnchorStyles.Bottom
		Label59.AutoSize = True
		Label59.BackColor = Color.Transparent
		Label59.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label59.Location = New Point(7, 266)
		Label59.Name = "Label59"
		Label59.Size = New Size(38, 13)
		Label59.TabIndex = 5
		Label59.Text = "Width:"
		' 
		' Label63
		' 
		Label63.AutoSize = True
		Label63.BackColor = Color.Transparent
		Label63.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label63.Location = New Point(3, 61)
		Label63.Name = "Label63"
		Label63.Size = New Size(100, 13)
		Label63.TabIndex = 0
		Label63.Text = "Background Image:"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.BackColor = Color.Transparent
		Label3.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label3.Location = New Point(3, 38)
		Label3.Name = "Label3"
		Label3.Size = New Size(62, 13)
		Label3.TabIndex = 0
		Label3.Text = "Back Color:"
		' 
		' set_BC
		' 
		set_BC.BackColor = Color.White
		set_BC.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		set_BC.Location = New Point(72, 32)
		set_BC.Margin = New Padding(4, 5, 4, 5)
		set_BC.MyText = "ChooseColor"
		set_BC.Name = "set_BC"
		set_BC.SelectedColor = Color.FromArgb(CByte(0), CByte(240), CByte(248), CByte(255))
		set_BC.Size = New Size(174, 25)
		set_BC.TabIndex = 1
		' 
		' pSideBar
		' 
		pSideBar.Controls.Add(btNewC)
		pSideBar.Controls.Add(btExit)
		pSideBar.Controls.Add(btSettings)
		pSideBar.Controls.Add(btSave)
		pSideBar.Controls.Add(btOpen)
		pSideBar.Controls.Add(btMenu)
		pSideBar.Dock = DockStyle.Left
		pSideBar.Location = New Point(0, 0)
		pSideBar.Name = "pSideBar"
		pSideBar.Size = New Size(45, 705)
		pSideBar.TabIndex = 7
		' 
		' btNewC
		' 
		btNewC.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btNewC.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btNewC.DrawText = False
		btNewC.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btNewC.FontSizeIncrement = 0.4F
		btNewC.Icon = CType(resources.GetObject("btNewC.Icon"), Image)
		btNewC.Location = New Point(0, 45)
		btNewC.Margin = New Padding(0)
		btNewC.MyText = "New"
		btNewC.Name = "btNewC"
		btNewC.Size = New Size(45, 45)
		btNewC.TabIndex = 17
		' 
		' btExit
		' 
		btExit.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btExit.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		btExit.DrawText = False
		btExit.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btExit.FontSizeIncrement = 0.4F
		btExit.Icon = CType(resources.GetObject("btExit.Icon"), Image)
		btExit.Location = New Point(0, 660)
		btExit.Margin = New Padding(0)
		btExit.MyText = "Exit"
		btExit.Name = "btExit"
		btExit.Size = New Size(45, 45)
		btExit.TabIndex = 15
		' 
		' btSettings
		' 
		btSettings.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btSettings.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btSettings.DrawText = False
		btSettings.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btSettings.FontSizeIncrement = 0.4F
		btSettings.Icon = CType(resources.GetObject("btSettings.Icon"), Image)
		btSettings.Location = New Point(0, 180)
		btSettings.Margin = New Padding(0)
		btSettings.MyText = "Settings"
		btSettings.Name = "btSettings"
		btSettings.Size = New Size(45, 45)
		btSettings.TabIndex = 11
		' 
		' btSave
		' 
		btSave.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btSave.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btSave.DrawText = False
		btSave.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btSave.FontSizeIncrement = 0.4F
		btSave.Icon = CType(resources.GetObject("btSave.Icon"), Image)
		btSave.Location = New Point(0, 135)
		btSave.Margin = New Padding(0)
		btSave.MyText = "Save"
		btSave.Name = "btSave"
		btSave.Size = New Size(45, 45)
		btSave.TabIndex = 12
		' 
		' btOpen
		' 
		btOpen.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btOpen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btOpen.DrawText = False
		btOpen.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btOpen.FontSizeIncrement = 0.4F
		btOpen.Icon = CType(resources.GetObject("btOpen.Icon"), Image)
		btOpen.Location = New Point(0, 90)
		btOpen.Margin = New Padding(0)
		btOpen.MyText = "Open"
		btOpen.Name = "btOpen"
		btOpen.Size = New Size(45, 45)
		btOpen.TabIndex = 13
		' 
		' btMenu
		' 
		btMenu.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btMenu.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		btMenu.DrawText = False
		btMenu.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point)
		btMenu.FontSizeIncrement = 0F
		btMenu.Icon = CType(resources.GetObject("btMenu.Icon"), Image)
		btMenu.Location = New Point(0, 0)
		btMenu.Margin = New Padding(0)
		btMenu.MyText = "Menu"
		btMenu.Name = "btMenu"
		btMenu.Size = New Size(45, 45)
		btMenu.TabIndex = 14
		' 
		' tTop
		' 
		tTop.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		tTop.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		tTop.Controls.Add(btDelete)
		tTop.Controls.Add(btClone)
		tTop.Controls.Add(btBack)
		tTop.Controls.Add(btFront)
		tTop.Controls.Add(cb_Brush)
		tTop.Controls.Add(cb_Shape)
		tTop.Controls.Add(rDraw)
		tTop.Controls.Add(rSelect)
		tTop.Controls.Add(Label29)
		tTop.Controls.Add(Label1)
		tTop.ForeColor = Color.White
		tTop.Location = New Point(45, 0)
		tTop.Name = "tTop"
		tTop.Size = New Size(1054, 45)
		tTop.TabIndex = 0
		' 
		' btDelete
		' 
		btDelete.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		btDelete.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		btDelete.Icon = CType(resources.GetObject("btDelete.Icon"), Image)
		btDelete.Location = New Point(1009, 0)
		btDelete.Margin = New Padding(0)
		btDelete.MyText = ""
		btDelete.Name = "btDelete"
		btDelete.Size = New Size(45, 45)
		btDelete.TabIndex = 5
		' 
		' btClone
		' 
		btClone.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btClone.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		btClone.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		btClone.Icon = CType(resources.GetObject("btClone.Icon"), Image)
		btClone.Location = New Point(964, 0)
		btClone.Margin = New Padding(0)
		btClone.MyText = ""
		btClone.Name = "btClone"
		btClone.Size = New Size(45, 45)
		btClone.TabIndex = 6
		' 
		' btBack
		' 
		btBack.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btBack.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		btBack.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		btBack.Icon = CType(resources.GetObject("btBack.Icon"), Image)
		btBack.Location = New Point(919, 0)
		btBack.Margin = New Padding(0)
		btBack.MyText = ""
		btBack.Name = "btBack"
		btBack.Size = New Size(45, 45)
		btBack.TabIndex = 7
		' 
		' btFront
		' 
		btFront.ActiveColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
		btFront.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		btFront.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
		btFront.Icon = CType(resources.GetObject("btFront.Icon"), Image)
		btFront.Location = New Point(874, 0)
		btFront.Margin = New Padding(0)
		btFront.MyText = ""
		btFront.Name = "btFront"
		btFront.Size = New Size(45, 45)
		btFront.TabIndex = 8
		' 
		' cb_Brush
		' 
		cb_Brush.Anchor = AnchorStyles.None
		cb_Brush.AutoCompleteMode = AutoCompleteMode.Append
		cb_Brush.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_Brush.DrawMode = DrawMode.OwnerDrawFixed
		cb_Brush.DropDownHeight = 250
		cb_Brush.DropDownStyle = ComboBoxStyle.DropDownList
		cb_Brush.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_Brush.IntegralHeight = False
		cb_Brush.ItemHeight = 20
		cb_Brush.Location = New Point(610, 9)
		cb_Brush.MaxDropDownItems = 14
		cb_Brush.Name = "cb_Brush"
		cb_Brush.Size = New Size(171, 26)
		cb_Brush.TabIndex = 3
		' 
		' cb_Shape
		' 
		cb_Shape.Anchor = AnchorStyles.None
		cb_Shape.AutoCompleteMode = AutoCompleteMode.Append
		cb_Shape.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_Shape.DrawMode = DrawMode.OwnerDrawFixed
		cb_Shape.DropDownHeight = 250
		cb_Shape.DropDownStyle = ComboBoxStyle.DropDownList
		cb_Shape.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_Shape.IntegralHeight = False
		cb_Shape.ItemHeight = 20
		cb_Shape.Location = New Point(390, 9)
		cb_Shape.MaxDropDownItems = 14
		cb_Shape.Name = "cb_Shape"
		cb_Shape.Size = New Size(171, 26)
		cb_Shape.TabIndex = 2
		' 
		' rDraw
		' 
		rDraw.Anchor = AnchorStyles.None
		rDraw.AutoSize = True
		rDraw.Checked = True
		rDraw.Location = New Point(274, 4)
		rDraw.Name = "rDraw"
		rDraw.Size = New Size(52, 19)
		rDraw.TabIndex = 0
		rDraw.TabStop = True
		rDraw.Text = "Draw"
		rDraw.UseVisualStyleBackColor = True
		' 
		' rSelect
		' 
		rSelect.Anchor = AnchorStyles.None
		rSelect.AutoSize = True
		rSelect.Location = New Point(274, 24)
		rSelect.Name = "rSelect"
		rSelect.Size = New Size(56, 19)
		rSelect.TabIndex = 1
		rSelect.Text = "Select"
		rSelect.UseVisualStyleBackColor = True
		' 
		' Label29
		' 
		Label29.Anchor = AnchorStyles.None
		Label29.AutoSize = True
		Label29.Location = New Point(343, 16)
		Label29.Name = "Label29"
		Label29.Size = New Size(42, 15)
		Label29.TabIndex = 3
		Label29.Text = "Shape:"
		' 
		' Label1
		' 
		Label1.Anchor = AnchorStyles.None
		Label1.AutoSize = True
		Label1.Location = New Point(567, 16)
		Label1.Name = "Label1"
		Label1.Size = New Size(40, 15)
		Label1.TabIndex = 3
		Label1.Text = "Brush:"
		' 
		' tbShadow
		' 
		tbShadow.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		tbShadow.BackColor = Color.Black
		tbShadow.DrawFocus = False
		tbShadow.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		tbShadow.ForeColor = Color.White
		tbShadow.Location = New Point(1287, 0)
		tbShadow.MyText = "Shadow"
		tbShadow.Name = "tbShadow"
		tbShadow.Size = New Size(79, 30)
		tbShadow.TabIndex = 4
		' 
		' tbGlow
		' 
		tbGlow.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		tbGlow.BackColor = Color.Black
		tbGlow.DrawFocus = False
		tbGlow.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		tbGlow.ForeColor = Color.White
		tbGlow.Location = New Point(1220, 0)
		tbGlow.MyText = "Glow"
		tbGlow.Name = "tbGlow"
		tbGlow.Size = New Size(67, 30)
		tbGlow.TabIndex = 3
		' 
		' tBottom
		' 
		tBottom.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		tBottom.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		tBottom.Controls.Add(TBZoom)
		tBottom.Controls.Add(bResetZoom)
		tBottom.Controls.Add(bShape)
		tBottom.Controls.Add(Label51)
		tBottom.Controls.Add(Label49)
		tBottom.Controls.Add(Label48)
		tBottom.Controls.Add(Label47)
		tBottom.Controls.Add(Label46)
		tBottom.Controls.Add(Label45)
		tBottom.Controls.Add(ud_A)
		tBottom.Controls.Add(ud_H)
		tBottom.Controls.Add(ud_W)
		tBottom.Controls.Add(ud_Y)
		tBottom.Controls.Add(ud_X)
		tBottom.ForeColor = Color.White
		tBottom.Location = New Point(45, 660)
		tBottom.Name = "tBottom"
		tBottom.Size = New Size(1054, 45)
		tBottom.TabIndex = 2
		' 
		' TBZoom
		' 
		TBZoom.AllowDecimal = False
		TBZoom.BackColor = Color.Transparent
		TBZoom.BarBorderColor = Color.White
		TBZoom.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TBZoom.Factors = New Single() {0F, 1F}
		TBZoom.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		TBZoom.Increment = 10F
		TBZoom.Location = New Point(800, 12)
		TBZoom.Margin = New Padding(4, 5, 4, 5)
		TBZoom.Maximum = 1000F
		TBZoom.Minimum = 20F
		TBZoom.Name = "TBZoom"
		TBZoom.Positions = New Single() {0F, 0.5F, 1F}
		TBZoom.Size = New Size(177, 20)
		TBZoom.TabIndex = 6
		TBZoom.ThumbBorderColor = Color.White
		TBZoom.Value = 100F
		' 
		' bResetZoom
		' 
		bResetZoom.Anchor = AnchorStyles.None
		bResetZoom.BackColor = Color.Black
		bResetZoom.ForeColor = Color.White
		bResetZoom.Location = New Point(979, 8)
		bResetZoom.MyText = "Reset"
		bResetZoom.Name = "bResetZoom"
		bResetZoom.Size = New Size(60, 30)
		bResetZoom.TabIndex = 5
		' 
		' bShape
		' 
		bShape.Anchor = AnchorStyles.None
		bShape.BackColor = Color.Black
		bShape.ForeColor = Color.White
		bShape.Location = New Point(586, 8)
		bShape.MyText = "Edit Shape"
		bShape.Name = "bShape"
		bShape.Size = New Size(75, 30)
		bShape.TabIndex = 5
		' 
		' Label51
		' 
		Label51.Anchor = AnchorStyles.None
		Label51.AutoSize = True
		Label51.Location = New Point(759, 14)
		Label51.Name = "Label51"
		Label51.Size = New Size(42, 15)
		Label51.TabIndex = 1
		Label51.Text = "Zoom:"
		' 
		' Label49
		' 
		Label49.Anchor = AnchorStyles.None
		Label49.AutoSize = True
		Label49.Location = New Point(476, 15)
		Label49.Name = "Label49"
		Label49.Size = New Size(41, 15)
		Label49.TabIndex = 1
		Label49.Text = "Angle:"
		' 
		' Label48
		' 
		Label48.Anchor = AnchorStyles.None
		Label48.AutoSize = True
		Label48.Location = New Point(385, 15)
		Label48.Name = "Label48"
		Label48.Size = New Size(19, 15)
		Label48.TabIndex = 1
		Label48.Text = "H:"
		' 
		' Label47
		' 
		Label47.Anchor = AnchorStyles.None
		Label47.AutoSize = True
		Label47.Location = New Point(291, 15)
		Label47.Name = "Label47"
		Label47.Size = New Size(21, 15)
		Label47.TabIndex = 1
		Label47.Text = "W:"
		' 
		' Label46
		' 
		Label46.Anchor = AnchorStyles.None
		Label46.AutoSize = True
		Label46.Location = New Point(201, 15)
		Label46.Name = "Label46"
		Label46.Size = New Size(17, 15)
		Label46.TabIndex = 1
		Label46.Text = "Y:"
		' 
		' Label45
		' 
		Label45.Anchor = AnchorStyles.None
		Label45.AutoSize = True
		Label45.Location = New Point(111, 15)
		Label45.Name = "Label45"
		Label45.Size = New Size(17, 15)
		Label45.TabIndex = 1
		Label45.Text = "X:"
		' 
		' ud_A
		' 
		ud_A.Anchor = AnchorStyles.None
		ud_A.DecimalPlaces = 2
		ud_A.Location = New Point(519, 12)
		ud_A.Maximum = New [Decimal](New Integer() {360, 0, 0, 0})
		ud_A.Name = "ud_A"
		ud_A.Size = New Size(61, 23)
		ud_A.TabIndex = 4
		' 
		' ud_H
		' 
		ud_H.Anchor = AnchorStyles.None
		ud_H.DecimalPlaces = 2
		ud_H.Location = New Point(409, 12)
		ud_H.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		ud_H.Name = "ud_H"
		ud_H.Size = New Size(61, 23)
		ud_H.TabIndex = 3
		' 
		' ud_W
		' 
		ud_W.Anchor = AnchorStyles.None
		ud_W.DecimalPlaces = 2
		ud_W.Location = New Point(318, 12)
		ud_W.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		ud_W.Name = "ud_W"
		ud_W.Size = New Size(61, 23)
		ud_W.TabIndex = 2
		' 
		' ud_Y
		' 
		ud_Y.Anchor = AnchorStyles.None
		ud_Y.DecimalPlaces = 2
		ud_Y.Location = New Point(224, 12)
		ud_Y.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		ud_Y.Minimum = New [Decimal](New Integer() {5000, 0, 0, Integer.MinValue})
		ud_Y.Name = "ud_Y"
		ud_Y.Size = New Size(61, 23)
		ud_Y.TabIndex = 1
		' 
		' ud_X
		' 
		ud_X.Anchor = AnchorStyles.None
		ud_X.DecimalPlaces = 2
		ud_X.Location = New Point(134, 12)
		ud_X.Maximum = New [Decimal](New Integer() {5000, 0, 0, 0})
		ud_X.Minimum = New [Decimal](New Integer() {5000, 0, 0, Integer.MinValue})
		ud_X.Name = "ud_X"
		ud_X.Size = New Size(61, 23)
		ud_X.TabIndex = 0
		' 
		' tbStroke
		' 
		tbStroke.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		tbStroke.BackColor = Color.Black
		tbStroke.DrawFocus = False
		tbStroke.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		tbStroke.ForeColor = Color.White
		tbStroke.Location = New Point(1153, 0)
		tbStroke.MyText = "Stroke"
		tbStroke.Name = "tbStroke"
		tbStroke.Size = New Size(67, 30)
		tbStroke.TabIndex = 2
		' 
		' tbFill
		' 
		tbFill.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		tbFill.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
		tbFill.DrawEffect = False
		tbFill.DrawFocus = False
		tbFill.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		tbFill.ForeColor = Color.White
		tbFill.Location = New Point(1099, 0)
		tbFill.MyText = "Fill"
		tbFill.Name = "tbFill"
		tbFill.Size = New Size(54, 30)
		tbFill.TabIndex = 1
		' 
		' pMain
		' 
		pMain.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		pMain.AutoScroll = True
		pMain.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
		pMain.Controls.Add(pShadow)
		pMain.Controls.Add(pGlow)
		pMain.Controls.Add(pSolid)
		pMain.Controls.Add(pLinear)
		pMain.Controls.Add(pStroke)
		pMain.Controls.Add(pPath)
		pMain.Controls.Add(pTexture)
		pMain.Controls.Add(pHatch)
		pMain.Location = New Point(1099, 30)
		pMain.Name = "pMain"
		pMain.Size = New Size(267, 675)
		pMain.TabIndex = 5
		' 
		' pShadow
		' 
		pShadow.Controls.Add(PS_Shadow)
		pShadow.Controls.Add(TB_SFeather)
		pShadow.Controls.Add(Label55)
		pShadow.Controls.Add(TB_SBlur)
		pShadow.Controls.Add(Label57)
		pShadow.Controls.Add(Label56)
		pShadow.Controls.Add(cb_EShadow)
		pShadow.Controls.Add(cb_clip)
		pShadow.Controls.Add(cb_fill)
		pShadow.Controls.Add(Label58)
		pShadow.Controls.Add(CE_Shadow)
		pShadow.Location = New Point(0, 0)
		pShadow.Name = "pShadow"
		pShadow.Size = New Size(250, 427)
		pShadow.TabIndex = 0
		' 
		' PS_Shadow
		' 
		PS_Shadow.BackColor = Color.Transparent
		PS_Shadow.BackRectColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		PS_Shadow.BordersColor = Color.White
		PS_Shadow.Font = New Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		PS_Shadow.Location = New Point(5, 174)
		PS_Shadow.Margin = New Padding(4, 3, 4, 3)
		PS_Shadow.Maximum = New Point(50, 50)
		PS_Shadow.Minimum = New Point(-50, -50)
		PS_Shadow.Name = "PS_Shadow"
		PS_Shadow.Size = New Size(240, 240)
		PS_Shadow.TabIndex = 6
		PS_Shadow.ThumbColor = Color.Black
		PS_Shadow.Value = New Point(10, 10)
		' 
		' TB_SFeather
		' 
		TB_SFeather.AllowDecimal = False
		TB_SFeather.BarBorderColor = Color.White
		TB_SFeather.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_SFeather.Factors = New Single() {0F, 1F}
		TB_SFeather.Location = New Point(83, 83)
		TB_SFeather.Margin = New Padding(4, 3, 4, 3)
		TB_SFeather.Minimum = 10F
		TB_SFeather.Name = "TB_SFeather"
		TB_SFeather.Positions = New Single() {0F, 0.5F, 1F}
		TB_SFeather.Size = New Size(160, 20)
		TB_SFeather.TabIndex = 3
		TB_SFeather.ThumbBorderColor = Color.White
		TB_SFeather.Value = 100F
		' 
		' Label55
		' 
		Label55.AutoSize = True
		Label55.Location = New Point(4, 86)
		Label55.Name = "Label55"
		Label55.Size = New Size(55, 15)
		Label55.TabIndex = 14
		Label55.Text = "Strength:"
		' 
		' TB_SBlur
		' 
		TB_SBlur.AllowDecimal = False
		TB_SBlur.BarBorderColor = Color.White
		TB_SBlur.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_SBlur.Factors = New Single() {0F, 1F}
		TB_SBlur.Location = New Point(83, 57)
		TB_SBlur.Margin = New Padding(4, 3, 4, 3)
		TB_SBlur.Maximum = 30F
		TB_SBlur.Name = "TB_SBlur"
		TB_SBlur.Positions = New Single() {0F, 0.5F, 1F}
		TB_SBlur.Size = New Size(160, 20)
		TB_SBlur.TabIndex = 2
		TB_SBlur.ThumbBorderColor = Color.White
		TB_SBlur.Value = 10F
		' 
		' Label57
		' 
		Label57.AutoSize = True
		Label57.Location = New Point(9, 158)
		Label57.Name = "Label57"
		Label57.Size = New Size(42, 15)
		Label57.TabIndex = 14
		Label57.Text = "Offset:"
		' 
		' Label56
		' 
		Label56.AutoSize = True
		Label56.Location = New Point(4, 60)
		Label56.Name = "Label56"
		Label56.Size = New Size(45, 15)
		Label56.TabIndex = 14
		Label56.Text = "Radius:"
		' 
		' cb_EShadow
		' 
		cb_EShadow.AutoSize = True
		cb_EShadow.Location = New Point(9, 6)
		cb_EShadow.Name = "cb_EShadow"
		cb_EShadow.Size = New Size(98, 19)
		cb_EShadow.TabIndex = 0
		cb_EShadow.Text = "Draw Shadow"
		cb_EShadow.UseVisualStyleBackColor = True
		' 
		' cb_clip
		' 
		cb_clip.AutoSize = True
		cb_clip.Checked = True
		cb_clip.CheckState = CheckState.Checked
		cb_clip.Location = New Point(9, 135)
		cb_clip.Name = "cb_clip"
		cb_clip.Size = New Size(111, 19)
		cb_clip.TabIndex = 5
		cb_clip.Text = "Region Clipping"
		cb_clip.UseVisualStyleBackColor = True
		' 
		' cb_fill
		' 
		cb_fill.AutoSize = True
		cb_fill.Checked = True
		cb_fill.CheckState = CheckState.Checked
		cb_fill.Location = New Point(9, 112)
		cb_fill.Name = "cb_fill"
		cb_fill.Size = New Size(41, 19)
		cb_fill.TabIndex = 4
		cb_fill.Text = "Fill"
		cb_fill.UseVisualStyleBackColor = True
		' 
		' Label58
		' 
		Label58.AutoSize = True
		Label58.Location = New Point(4, 35)
		Label58.Name = "Label58"
		Label58.Size = New Size(39, 15)
		Label58.TabIndex = 8
		Label58.Text = "Color:"
		' 
		' CE_Shadow
		' 
		CE_Shadow.BackColor = SystemColors.Control
		CE_Shadow.Location = New Point(83, 31)
		CE_Shadow.Margin = New Padding(4, 3, 4, 3)
		CE_Shadow.MyText = "ChooseColor"
		CE_Shadow.Name = "CE_Shadow"
		CE_Shadow.SelectedColor = Color.FromArgb(CByte(128), CByte(128), CByte(128))
		CE_Shadow.Size = New Size(160, 22)
		CE_Shadow.TabIndex = 1
		' 
		' pGlow
		' 
		pGlow.Controls.Add(cb_EGlow)
		pGlow.Controls.Add(TB_Feather)
		pGlow.Controls.Add(Label54)
		pGlow.Controls.Add(TB_Glow)
		pGlow.Controls.Add(Label53)
		pGlow.Controls.Add(cb_gfill)
		pGlow.Controls.Add(cb_GClip)
		pGlow.Controls.Add(Label2)
		pGlow.Controls.Add(cb_GStyle)
		pGlow.Controls.Add(Label52)
		pGlow.Controls.Add(Label50)
		pGlow.Controls.Add(CE_Glow)
		pGlow.Location = New Point(0, 0)
		pGlow.Name = "pGlow"
		pGlow.Size = New Size(250, 199)
		pGlow.TabIndex = 0
		' 
		' cb_EGlow
		' 
		cb_EGlow.AutoSize = True
		cb_EGlow.Location = New Point(9, 6)
		cb_EGlow.Name = "cb_EGlow"
		cb_EGlow.Size = New Size(83, 19)
		cb_EGlow.TabIndex = 0
		cb_EGlow.Text = "Draw Glow"
		cb_EGlow.UseVisualStyleBackColor = True
		' 
		' TB_Feather
		' 
		TB_Feather.AllowDecimal = False
		TB_Feather.BarBorderColor = Color.White
		TB_Feather.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_Feather.Factors = New Single() {0F, 1F}
		TB_Feather.Location = New Point(83, 119)
		TB_Feather.Margin = New Padding(4, 3, 4, 3)
		TB_Feather.Minimum = 10F
		TB_Feather.Name = "TB_Feather"
		TB_Feather.Positions = New Single() {0F, 0.5F, 1F}
		TB_Feather.Size = New Size(160, 20)
		TB_Feather.TabIndex = 4
		TB_Feather.ThumbBorderColor = Color.White
		TB_Feather.Value = 35F
		' 
		' Label54
		' 
		Label54.AutoSize = True
		Label54.Location = New Point(4, 122)
		Label54.Name = "Label54"
		Label54.Size = New Size(55, 15)
		Label54.TabIndex = 14
		Label54.Text = "Strength:"
		' 
		' TB_Glow
		' 
		TB_Glow.AllowDecimal = False
		TB_Glow.BarBorderColor = Color.White
		TB_Glow.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_Glow.Factors = New Single() {0F, 1F}
		TB_Glow.Location = New Point(83, 93)
		TB_Glow.Margin = New Padding(4, 3, 4, 3)
		TB_Glow.Minimum = 10F
		TB_Glow.Name = "TB_Glow"
		TB_Glow.Positions = New Single() {0F, 0.5F, 1F}
		TB_Glow.Size = New Size(160, 20)
		TB_Glow.TabIndex = 3
		TB_Glow.ThumbBorderColor = Color.White
		TB_Glow.Value = 35F
		' 
		' Label53
		' 
		Label53.AutoSize = True
		Label53.Location = New Point(4, 96)
		Label53.Name = "Label53"
		Label53.Size = New Size(45, 15)
		Label53.TabIndex = 14
		Label53.Text = "Radius:"
		' 
		' cb_gfill
		' 
		cb_gfill.AutoSize = True
		cb_gfill.Checked = True
		cb_gfill.CheckState = CheckState.Checked
		cb_gfill.Location = New Point(9, 144)
		cb_gfill.Name = "cb_gfill"
		cb_gfill.Size = New Size(78, 19)
		cb_gfill.TabIndex = 5
		cb_gfill.Text = "Before Fill"
		cb_gfill.UseVisualStyleBackColor = True
		' 
		' cb_GClip
		' 
		cb_GClip.AutoCompleteMode = AutoCompleteMode.Append
		cb_GClip.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_GClip.DropDownHeight = 250
		cb_GClip.DropDownStyle = ComboBoxStyle.DropDownList
		cb_GClip.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_GClip.IntegralHeight = False
		cb_GClip.ItemHeight = 17
		cb_GClip.Location = New Point(83, 168)
		cb_GClip.MaxDropDownItems = 14
		cb_GClip.Name = "cb_GClip"
		cb_GClip.Size = New Size(160, 25)
		cb_GClip.TabIndex = 6
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Location = New Point(4, 173)
		Label2.Name = "Label2"
		Label2.Size = New Size(55, 15)
		Label2.TabIndex = 12
		Label2.Text = "Clipping:"
		' 
		' cb_GStyle
		' 
		cb_GStyle.AutoCompleteMode = AutoCompleteMode.Append
		cb_GStyle.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_GStyle.DropDownHeight = 250
		cb_GStyle.DropDownStyle = ComboBoxStyle.DropDownList
		cb_GStyle.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_GStyle.IntegralHeight = False
		cb_GStyle.ItemHeight = 17
		cb_GStyle.Location = New Point(83, 61)
		cb_GStyle.MaxDropDownItems = 14
		cb_GStyle.Name = "cb_GStyle"
		cb_GStyle.Size = New Size(160, 25)
		cb_GStyle.TabIndex = 2
		' 
		' Label52
		' 
		Label52.AutoSize = True
		Label52.Location = New Point(4, 66)
		Label52.Name = "Label52"
		Label52.Size = New Size(65, 15)
		Label52.TabIndex = 12
		Label52.Text = "Glow Style:"
		' 
		' Label50
		' 
		Label50.AutoSize = True
		Label50.Location = New Point(4, 35)
		Label50.Name = "Label50"
		Label50.Size = New Size(69, 15)
		Label50.TabIndex = 8
		Label50.Text = "Glow Color:"
		' 
		' CE_Glow
		' 
		CE_Glow.BackColor = SystemColors.Control
		CE_Glow.Location = New Point(83, 31)
		CE_Glow.Margin = New Padding(4, 3, 4, 3)
		CE_Glow.MyText = "ChooseColor"
		CE_Glow.Name = "CE_Glow"
		CE_Glow.SelectedColor = Color.Red
		CE_Glow.Size = New Size(160, 22)
		CE_Glow.TabIndex = 1
		' 
		' pSolid
		' 
		pSolid.Controls.Add(Label4)
		pSolid.Controls.Add(CE_Solid)
		pSolid.Location = New Point(0, 0)
		pSolid.Name = "pSolid"
		pSolid.Size = New Size(250, 38)
		pSolid.TabIndex = 0
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Location = New Point(4, 12)
		Label4.Name = "Label4"
		Label4.Size = New Size(68, 15)
		Label4.TabIndex = 8
		Label4.Text = "Solid Color:"
		' 
		' CE_Solid
		' 
		CE_Solid.BackColor = SystemColors.Control
		CE_Solid.Location = New Point(83, 8)
		CE_Solid.Margin = New Padding(4, 3, 4, 3)
		CE_Solid.MyText = "ChooseColor"
		CE_Solid.Name = "CE_Solid"
		CE_Solid.SelectedColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
		CE_Solid.Size = New Size(160, 22)
		CE_Solid.TabIndex = 0
		' 
		' pLinear
		' 
		pLinear.Controls.Add(L_CBEditor)
		pLinear.Controls.Add(L_BEditor)
		pLinear.Controls.Add(LBellScale)
		pLinear.Controls.Add(LTriScale)
		pLinear.Controls.Add(Label11)
		pLinear.Controls.Add(Label9)
		pLinear.Controls.Add(LBellFocus)
		pLinear.Controls.Add(LTriFocus)
		pLinear.Controls.Add(Label10)
		pLinear.Controls.Add(Label8)
		pLinear.Controls.Add(TB_LAngle)
		pLinear.Controls.Add(Label7)
		pLinear.Controls.Add(CB_LBlend)
		pLinear.Controls.Add(CB_LColorBlend)
		pLinear.Controls.Add(CB_LBell)
		pLinear.Controls.Add(CB_LTri)
		pLinear.Controls.Add(CB_Gamma)
		pLinear.Controls.Add(Label6)
		pLinear.Controls.Add(Label5)
		pLinear.Controls.Add(CE_L2)
		pLinear.Controls.Add(CE_L1)
		pLinear.Location = New Point(0, 0)
		pLinear.Name = "pLinear"
		pLinear.Size = New Size(250, 644)
		pLinear.TabIndex = 0
		' 
		' L_CBEditor
		' 
		L_CBEditor.BackColor = Color.White
		L_CBEditor.Colors = New Color() {Color.FromArgb(CByte(255), CByte(255), CByte(255)), Color.Black}
		L_CBEditor.ForeColor = Color.Black
		L_CBEditor.Location = New Point(5, 287)
		L_CBEditor.MinimumSize = New Size(240, 160)
		L_CBEditor.Name = "L_CBEditor"
		L_CBEditor.Positions = New Single() {0F, 1F}
		L_CBEditor.Size = New Size(240, 160)
		L_CBEditor.TabIndex = 14
		' 
		' L_BEditor
		' 
		L_BEditor.BackColor = Color.White
		L_BEditor.Color1 = Color.White
		L_BEditor.Color2 = Color.Black
		L_BEditor.Factors = New Single() {0F, 1F}
		L_BEditor.ForeColor = Color.Black
		L_BEditor.Location = New Point(5, 474)
		L_BEditor.MinimumSize = New Size(240, 160)
		L_BEditor.Name = "L_BEditor"
		L_BEditor.Positions = New Single() {0F, 1F}
		L_BEditor.Size = New Size(240, 160)
		L_BEditor.TabIndex = 13
		' 
		' LBellScale
		' 
		LBellScale.BarBorderColor = Color.White
		LBellScale.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		LBellScale.Factors = New Single() {0F, 1F}
		LBellScale.Increment = 0.1F
		LBellScale.Location = New Point(83, 239)
		LBellScale.Margin = New Padding(4, 3, 4, 3)
		LBellScale.Maximum = 1F
		LBellScale.Name = "LBellScale"
		LBellScale.Positions = New Single() {0F, 0.5F, 1F}
		LBellScale.Size = New Size(160, 20)
		LBellScale.TabIndex = 9
		LBellScale.ThumbBorderColor = Color.White
		LBellScale.Value = 1F
		' 
		' LTriScale
		' 
		LTriScale.BarBorderColor = Color.White
		LTriScale.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		LTriScale.Factors = New Single() {0F, 1F}
		LTriScale.Increment = 0.1F
		LTriScale.Location = New Point(83, 164)
		LTriScale.Margin = New Padding(4, 3, 4, 3)
		LTriScale.Maximum = 1F
		LTriScale.Name = "LTriScale"
		LTriScale.Positions = New Single() {0F, 0.5F, 1F}
		LTriScale.Size = New Size(160, 20)
		LTriScale.TabIndex = 6
		LTriScale.ThumbBorderColor = Color.White
		LTriScale.Value = 1F
		' 
		' Label11
		' 
		Label11.AutoSize = True
		Label11.Location = New Point(3, 242)
		Label11.Name = "Label11"
		Label11.Size = New Size(37, 15)
		Label11.TabIndex = 10
		Label11.Text = "Scale:"
		' 
		' Label9
		' 
		Label9.AutoSize = True
		Label9.Location = New Point(3, 167)
		Label9.Name = "Label9"
		Label9.Size = New Size(37, 15)
		Label9.TabIndex = 10
		Label9.Text = "Scale:"
		' 
		' LBellFocus
		' 
		LBellFocus.BarBorderColor = Color.White
		LBellFocus.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		LBellFocus.Factors = New Single() {0F, 1F}
		LBellFocus.Increment = 0.1F
		LBellFocus.Location = New Point(83, 213)
		LBellFocus.Margin = New Padding(4, 3, 4, 3)
		LBellFocus.Maximum = 1F
		LBellFocus.Name = "LBellFocus"
		LBellFocus.Positions = New Single() {0F, 0.5F, 1F}
		LBellFocus.Size = New Size(160, 20)
		LBellFocus.TabIndex = 8
		LBellFocus.ThumbBorderColor = Color.White
		LBellFocus.Value = 0.5F
		' 
		' LTriFocus
		' 
		LTriFocus.BarBorderColor = Color.White
		LTriFocus.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		LTriFocus.Factors = New Single() {0F, 1F}
		LTriFocus.Increment = 0.1F
		LTriFocus.Location = New Point(83, 138)
		LTriFocus.Margin = New Padding(4, 3, 4, 3)
		LTriFocus.Maximum = 1F
		LTriFocus.Name = "LTriFocus"
		LTriFocus.Positions = New Single() {0F, 0.5F, 1F}
		LTriFocus.Size = New Size(160, 20)
		LTriFocus.TabIndex = 5
		LTriFocus.ThumbBorderColor = Color.White
		LTriFocus.Value = 0.5F
		' 
		' Label10
		' 
		Label10.AutoSize = True
		Label10.Location = New Point(3, 216)
		Label10.Name = "Label10"
		Label10.Size = New Size(41, 15)
		Label10.TabIndex = 10
		Label10.Text = "Focus:"
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Location = New Point(3, 141)
		Label8.Name = "Label8"
		Label8.Size = New Size(41, 15)
		Label8.TabIndex = 10
		Label8.Text = "Focus:"
		' 
		' TB_LAngle
		' 
		TB_LAngle.AllowDecimal = False
		TB_LAngle.BarBorderColor = Color.White
		TB_LAngle.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_LAngle.Factors = New Single() {0F, 1F}
		TB_LAngle.Location = New Point(83, 87)
		TB_LAngle.Margin = New Padding(4, 3, 4, 3)
		TB_LAngle.Maximum = 360F
		TB_LAngle.Name = "TB_LAngle"
		TB_LAngle.Positions = New Single() {0F, 0.5F, 1F}
		TB_LAngle.Size = New Size(160, 20)
		TB_LAngle.TabIndex = 3
		TB_LAngle.ThumbBorderColor = Color.White
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Location = New Point(4, 90)
		Label7.Name = "Label7"
		Label7.Size = New Size(41, 15)
		Label7.TabIndex = 10
		Label7.Text = "Angle:"
		' 
		' CB_LBlend
		' 
		CB_LBlend.AutoSize = True
		CB_LBlend.Location = New Point(6, 453)
		CB_LBlend.Name = "CB_LBlend"
		CB_LBlend.Size = New Size(56, 19)
		CB_LBlend.TabIndex = 12
		CB_LBlend.Text = "Blend"
		CB_LBlend.UseVisualStyleBackColor = True
		' 
		' CB_LColorBlend
		' 
		CB_LColorBlend.AutoSize = True
		CB_LColorBlend.Location = New Point(6, 264)
		CB_LColorBlend.Name = "CB_LColorBlend"
		CB_LColorBlend.Size = New Size(88, 19)
		CB_LColorBlend.TabIndex = 10
		CB_LColorBlend.Text = "Color Blend"
		CB_LColorBlend.UseVisualStyleBackColor = True
		' 
		' CB_LBell
		' 
		CB_LBell.AutoSize = True
		CB_LBell.Location = New Point(6, 189)
		CB_LBell.Name = "CB_LBell"
		CB_LBell.Size = New Size(135, 19)
		CB_LBell.TabIndex = 7
		CB_LBell.Text = "Set Sigma Bell Shape"
		CB_LBell.UseVisualStyleBackColor = True
		' 
		' CB_LTri
		' 
		CB_LTri.AutoSize = True
		CB_LTri.Location = New Point(6, 114)
		CB_LTri.Name = "CB_LTri"
		CB_LTri.Size = New Size(165, 19)
		CB_LTri.TabIndex = 4
		CB_LTri.Text = "Set Blend Triangular Shape"
		CB_LTri.UseVisualStyleBackColor = True
		' 
		' CB_Gamma
		' 
		CB_Gamma.AutoSize = True
		CB_Gamma.Location = New Point(6, 68)
		CB_Gamma.Name = "CB_Gamma"
		CB_Gamma.Size = New Size(127, 19)
		CB_Gamma.TabIndex = 2
		CB_Gamma.Text = "Gamma Correction"
		CB_Gamma.UseVisualStyleBackColor = True
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Location = New Point(4, 43)
		Label6.Name = "Label6"
		Label6.Size = New Size(48, 15)
		Label6.TabIndex = 10
		Label6.Text = "Color 2:"
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Location = New Point(4, 12)
		Label5.Name = "Label5"
		Label5.Size = New Size(48, 15)
		Label5.TabIndex = 10
		Label5.Text = "Color 1:"
		' 
		' CE_L2
		' 
		CE_L2.BackColor = SystemColors.Control
		CE_L2.Location = New Point(83, 39)
		CE_L2.Margin = New Padding(4, 3, 4, 3)
		CE_L2.MyText = "ChooseColor"
		CE_L2.Name = "CE_L2"
		CE_L2.SelectedColor = Color.FromArgb(CByte(0), CByte(0), CByte(0))
		CE_L2.Size = New Size(160, 22)
		CE_L2.TabIndex = 1
		' 
		' CE_L1
		' 
		CE_L1.BackColor = SystemColors.Control
		CE_L1.Location = New Point(83, 8)
		CE_L1.Margin = New Padding(4, 3, 4, 3)
		CE_L1.MyText = "ChooseColor"
		CE_L1.Name = "CE_L1"
		CE_L1.SelectedColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
		CE_L1.Size = New Size(160, 22)
		CE_L1.TabIndex = 0
		' 
		' pStroke
		' 
		pStroke.Controls.Add(LP_CBEditor)
		pStroke.Controls.Add(TB_PSY)
		pStroke.Controls.Add(Label44)
		pStroke.Controls.Add(TB_PSX)
		pStroke.Controls.Add(Label43)
		pStroke.Controls.Add(Label42)
		pStroke.Controls.Add(CB_LJoin)
		pStroke.Controls.Add(Label41)
		pStroke.Controls.Add(CB_ECap)
		pStroke.Controls.Add(Label40)
		pStroke.Controls.Add(CB_SCap)
		pStroke.Controls.Add(Label39)
		pStroke.Controls.Add(CB_DCap)
		pStroke.Controls.Add(Label36)
		pStroke.Controls.Add(CB_DStyle)
		pStroke.Controls.Add(Label35)
		pStroke.Controls.Add(TB_PAngle)
		pStroke.Controls.Add(Label34)
		pStroke.Controls.Add(CB_PGamma)
		pStroke.Controls.Add(PWidth)
		pStroke.Controls.Add(Label33)
		pStroke.Controls.Add(cb_PHatchStyle)
		pStroke.Controls.Add(Label30)
		pStroke.Controls.Add(Label31)
		pStroke.Controls.Add(CE_PBack)
		pStroke.Controls.Add(CE_PFore)
		pStroke.Controls.Add(Label32)
		pStroke.Controls.Add(rbpHatch)
		pStroke.Controls.Add(rbpLinear)
		pStroke.Controls.Add(rbpSolid)
		pStroke.Controls.Add(Label37)
		pStroke.Controls.Add(CE_PSolid)
		pStroke.Controls.Add(Label38)
		pStroke.Location = New Point(0, 0)
		pStroke.Name = "pStroke"
		pStroke.Size = New Size(250, 696)
		pStroke.TabIndex = 0
		' 
		' LP_CBEditor
		' 
		LP_CBEditor.BackColor = Color.White
		LP_CBEditor.Colors = New Color() {Color.FromArgb(CByte(255), CByte(255), CByte(255)), Color.Black}
		LP_CBEditor.ForeColor = Color.Black
		LP_CBEditor.Location = New Point(5, 111)
		LP_CBEditor.MinimumSize = New Size(240, 160)
		LP_CBEditor.Name = "LP_CBEditor"
		LP_CBEditor.Positions = New Single() {0F, 1F}
		LP_CBEditor.Size = New Size(240, 160)
		LP_CBEditor.TabIndex = 30
		' 
		' TB_PSY
		' 
		TB_PSY.BarBorderColor = Color.White
		TB_PSY.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_PSY.Factors = New Single() {0F, 1F}
		TB_PSY.Increment = 0.1F
		TB_PSY.Location = New Point(83, 669)
		TB_PSY.Margin = New Padding(4, 3, 4, 3)
		TB_PSY.Maximum = 2F
		TB_PSY.Minimum = 0.1F
		TB_PSY.Name = "TB_PSY"
		TB_PSY.Positions = New Single() {0F, 0.5F, 1F}
		TB_PSY.Size = New Size(160, 20)
		TB_PSY.TabIndex = 17
		TB_PSY.ThumbBorderColor = Color.White
		TB_PSY.Value = 1F
		' 
		' Label44
		' 
		Label44.AutoSize = True
		Label44.Location = New Point(2, 672)
		Label44.Name = "Label44"
		Label44.Size = New Size(47, 15)
		Label44.TabIndex = 29
		Label44.Text = "Scale Y:"
		' 
		' TB_PSX
		' 
		TB_PSX.BarBorderColor = Color.White
		TB_PSX.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_PSX.Factors = New Single() {0F, 1F}
		TB_PSX.Increment = 0.1F
		TB_PSX.Location = New Point(83, 644)
		TB_PSX.Margin = New Padding(4, 3, 4, 3)
		TB_PSX.Maximum = 2F
		TB_PSX.Minimum = 0.1F
		TB_PSX.Name = "TB_PSX"
		TB_PSX.Positions = New Single() {0F, 0.5F, 1F}
		TB_PSX.Size = New Size(160, 20)
		TB_PSX.TabIndex = 16
		TB_PSX.ThumbBorderColor = Color.White
		TB_PSX.Value = 1F
		' 
		' Label43
		' 
		Label43.AutoSize = True
		Label43.Location = New Point(2, 647)
		Label43.Name = "Label43"
		Label43.Size = New Size(47, 15)
		Label43.TabIndex = 29
		Label43.Text = "Scale X:"
		' 
		' Label42
		' 
		Label42.BackColor = Color.Transparent
		Label42.Font = New Font("Consolas", 17F, FontStyle.Regular, GraphicsUnit.Point)
		Label42.ForeColor = Color.White
		Label42.Location = New Point(1, 426)
		Label42.Name = "Label42"
		Label42.Size = New Size(248, 30)
		Label42.TabIndex = 28
		Label42.Text = "Style"
		Label42.TextAlign = ContentAlignment.MiddleCenter
		' 
		' CB_LJoin
		' 
		CB_LJoin.AutoCompleteMode = AutoCompleteMode.Append
		CB_LJoin.AutoCompleteSource = AutoCompleteSource.ListItems
		CB_LJoin.DropDownHeight = 250
		CB_LJoin.DropDownStyle = ComboBoxStyle.DropDownList
		CB_LJoin.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		CB_LJoin.IntegralHeight = False
		CB_LJoin.ItemHeight = 17
		CB_LJoin.Location = New Point(83, 613)
		CB_LJoin.MaxDropDownItems = 14
		CB_LJoin.Name = "CB_LJoin"
		CB_LJoin.Size = New Size(160, 25)
		CB_LJoin.TabIndex = 15
		' 
		' Label41
		' 
		Label41.AutoSize = True
		Label41.Location = New Point(2, 618)
		Label41.Name = "Label41"
		Label41.Size = New Size(56, 15)
		Label41.TabIndex = 26
		Label41.Text = "Line Join:"
		' 
		' CB_ECap
		' 
		CB_ECap.AutoCompleteMode = AutoCompleteMode.Append
		CB_ECap.AutoCompleteSource = AutoCompleteSource.ListItems
		CB_ECap.DrawMode = DrawMode.OwnerDrawFixed
		CB_ECap.DropDownHeight = 250
		CB_ECap.DropDownStyle = ComboBoxStyle.DropDownList
		CB_ECap.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		CB_ECap.IntegralHeight = False
		CB_ECap.ItemHeight = 20
		CB_ECap.Location = New Point(83, 580)
		CB_ECap.MaxDropDownItems = 14
		CB_ECap.Name = "CB_ECap"
		CB_ECap.Size = New Size(160, 26)
		CB_ECap.TabIndex = 14
		' 
		' Label40
		' 
		Label40.AutoSize = True
		Label40.Location = New Point(2, 586)
		Label40.Name = "Label40"
		Label40.Size = New Size(54, 15)
		Label40.TabIndex = 26
		Label40.Text = "End Cap:"
		' 
		' CB_SCap
		' 
		CB_SCap.AutoCompleteMode = AutoCompleteMode.Append
		CB_SCap.AutoCompleteSource = AutoCompleteSource.ListItems
		CB_SCap.DrawMode = DrawMode.OwnerDrawFixed
		CB_SCap.DropDownHeight = 250
		CB_SCap.DropDownStyle = ComboBoxStyle.DropDownList
		CB_SCap.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		CB_SCap.IntegralHeight = False
		CB_SCap.ItemHeight = 20
		CB_SCap.Location = New Point(83, 548)
		CB_SCap.MaxDropDownItems = 14
		CB_SCap.Name = "CB_SCap"
		CB_SCap.Size = New Size(160, 26)
		CB_SCap.TabIndex = 13
		' 
		' Label39
		' 
		Label39.AutoSize = True
		Label39.Location = New Point(2, 554)
		Label39.Name = "Label39"
		Label39.Size = New Size(58, 15)
		Label39.TabIndex = 26
		Label39.Text = "Start Cap:"
		' 
		' CB_DCap
		' 
		CB_DCap.AutoCompleteMode = AutoCompleteMode.Append
		CB_DCap.AutoCompleteSource = AutoCompleteSource.ListItems
		CB_DCap.DrawMode = DrawMode.OwnerDrawFixed
		CB_DCap.DropDownHeight = 250
		CB_DCap.DropDownStyle = ComboBoxStyle.DropDownList
		CB_DCap.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		CB_DCap.IntegralHeight = False
		CB_DCap.ItemHeight = 20
		CB_DCap.Location = New Point(83, 516)
		CB_DCap.MaxDropDownItems = 14
		CB_DCap.Name = "CB_DCap"
		CB_DCap.Size = New Size(160, 26)
		CB_DCap.TabIndex = 12
		' 
		' Label36
		' 
		Label36.AutoSize = True
		Label36.Location = New Point(2, 522)
		Label36.Name = "Label36"
		Label36.Size = New Size(60, 15)
		Label36.TabIndex = 26
		Label36.Text = "Dash Cap:"
		' 
		' CB_DStyle
		' 
		CB_DStyle.AutoCompleteMode = AutoCompleteMode.Append
		CB_DStyle.AutoCompleteSource = AutoCompleteSource.ListItems
		CB_DStyle.DrawMode = DrawMode.OwnerDrawFixed
		CB_DStyle.DropDownHeight = 250
		CB_DStyle.DropDownStyle = ComboBoxStyle.DropDownList
		CB_DStyle.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		CB_DStyle.IntegralHeight = False
		CB_DStyle.ItemHeight = 20
		CB_DStyle.Location = New Point(83, 484)
		CB_DStyle.MaxDropDownItems = 14
		CB_DStyle.Name = "CB_DStyle"
		CB_DStyle.Size = New Size(160, 26)
		CB_DStyle.TabIndex = 11
		' 
		' Label35
		' 
		Label35.AutoSize = True
		Label35.Location = New Point(2, 490)
		Label35.Name = "Label35"
		Label35.Size = New Size(64, 15)
		Label35.TabIndex = 26
		Label35.Text = "Dash Style:"
		' 
		' TB_PAngle
		' 
		TB_PAngle.AllowDecimal = False
		TB_PAngle.BarBorderColor = Color.White
		TB_PAngle.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TB_PAngle.Factors = New Single() {0F, 1F}
		TB_PAngle.Location = New Point(83, 296)
		TB_PAngle.Margin = New Padding(4, 3, 4, 3)
		TB_PAngle.Maximum = 360F
		TB_PAngle.Name = "TB_PAngle"
		TB_PAngle.Positions = New Single() {0F, 0.5F, 1F}
		TB_PAngle.Size = New Size(160, 20)
		TB_PAngle.TabIndex = 5
		TB_PAngle.ThumbBorderColor = Color.White
		' 
		' Label34
		' 
		Label34.AutoSize = True
		Label34.Location = New Point(2, 299)
		Label34.Name = "Label34"
		Label34.Size = New Size(41, 15)
		Label34.TabIndex = 23
		Label34.Text = "Angle:"
		' 
		' CB_PGamma
		' 
		CB_PGamma.AutoSize = True
		CB_PGamma.Location = New Point(4, 275)
		CB_PGamma.Name = "CB_PGamma"
		CB_PGamma.Size = New Size(127, 19)
		CB_PGamma.TabIndex = 4
		CB_PGamma.Text = "Gamma Correction"
		CB_PGamma.UseVisualStyleBackColor = True
		' 
		' PWidth
		' 
		PWidth.BarBorderColor = Color.White
		PWidth.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PWidth.Factors = New Single() {0F, 1F}
		PWidth.Location = New Point(83, 459)
		PWidth.Margin = New Padding(4, 3, 4, 3)
		PWidth.Maximum = 50F
		PWidth.Name = "PWidth"
		PWidth.Positions = New Single() {0F, 0.5F, 1F}
		PWidth.Size = New Size(160, 20)
		PWidth.TabIndex = 10
		PWidth.ThumbBorderColor = Color.White
		PWidth.Value = 1F
		' 
		' Label33
		' 
		Label33.AutoSize = True
		Label33.Location = New Point(3, 462)
		Label33.Name = "Label33"
		Label33.Size = New Size(42, 15)
		Label33.TabIndex = 21
		Label33.Text = "Width:"
		' 
		' cb_PHatchStyle
		' 
		cb_PHatchStyle.AutoCompleteMode = AutoCompleteMode.Append
		cb_PHatchStyle.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_PHatchStyle.DrawMode = DrawMode.OwnerDrawFixed
		cb_PHatchStyle.DropDownHeight = 250
		cb_PHatchStyle.DropDownStyle = ComboBoxStyle.DropDownList
		cb_PHatchStyle.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_PHatchStyle.IntegralHeight = False
		cb_PHatchStyle.ItemHeight = 20
		cb_PHatchStyle.Location = New Point(83, 397)
		cb_PHatchStyle.MaxDropDownItems = 14
		cb_PHatchStyle.Name = "cb_PHatchStyle"
		cb_PHatchStyle.Size = New Size(160, 26)
		cb_PHatchStyle.TabIndex = 9
		' 
		' Label30
		' 
		Label30.AutoSize = True
		Label30.Location = New Point(2, 372)
		Label30.Name = "Label30"
		Label30.Size = New Size(64, 15)
		Label30.TabIndex = 17
		Label30.Text = "BackColor:"
		' 
		' Label31
		' 
		Label31.AutoSize = True
		Label31.Location = New Point(2, 341)
		Label31.Name = "Label31"
		Label31.Size = New Size(62, 15)
		Label31.TabIndex = 18
		Label31.Text = "ForeColor:"
		' 
		' CE_PBack
		' 
		CE_PBack.BackColor = SystemColors.Control
		CE_PBack.Location = New Point(83, 368)
		CE_PBack.Margin = New Padding(4, 3, 4, 3)
		CE_PBack.MyText = "ChooseColor"
		CE_PBack.Name = "CE_PBack"
		CE_PBack.SelectedColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
		CE_PBack.Size = New Size(160, 22)
		CE_PBack.TabIndex = 8
		' 
		' CE_PFore
		' 
		CE_PFore.BackColor = SystemColors.Control
		CE_PFore.Location = New Point(83, 337)
		CE_PFore.Margin = New Padding(4, 3, 4, 3)
		CE_PFore.MyText = "ChooseColor"
		CE_PFore.Name = "CE_PFore"
		CE_PFore.SelectedColor = Color.FromArgb(CByte(0), CByte(0), CByte(0))
		CE_PFore.Size = New Size(160, 22)
		CE_PFore.TabIndex = 7
		' 
		' Label32
		' 
		Label32.AutoSize = True
		Label32.Location = New Point(2, 403)
		Label32.Name = "Label32"
		Label32.Size = New Size(70, 15)
		Label32.TabIndex = 19
		Label32.Text = "Hatch Style:"
		' 
		' rbpHatch
		' 
		rbpHatch.AutoSize = True
		rbpHatch.Location = New Point(5, 318)
		rbpHatch.Name = "rbpHatch"
		rbpHatch.Size = New Size(57, 19)
		rbpHatch.TabIndex = 6
		rbpHatch.Text = "Hatch"
		rbpHatch.UseVisualStyleBackColor = True
		' 
		' rbpLinear
		' 
		rbpLinear.AutoSize = True
		rbpLinear.Location = New Point(4, 86)
		rbpLinear.Name = "rbpLinear"
		rbpLinear.Size = New Size(102, 19)
		rbpLinear.TabIndex = 2
		rbpLinear.Text = "LinearGradient"
		rbpLinear.UseVisualStyleBackColor = True
		' 
		' rbpSolid
		' 
		rbpSolid.AutoSize = True
		rbpSolid.Checked = True
		rbpSolid.Location = New Point(5, 32)
		rbpSolid.Name = "rbpSolid"
		rbpSolid.Size = New Size(51, 19)
		rbpSolid.TabIndex = 0
		rbpSolid.TabStop = True
		rbpSolid.Text = "Solid"
		rbpSolid.UseVisualStyleBackColor = True
		' 
		' Label37
		' 
		Label37.AutoSize = True
		Label37.Location = New Point(2, 61)
		Label37.Name = "Label37"
		Label37.Size = New Size(68, 15)
		Label37.TabIndex = 10
		Label37.Text = "Solid Color:"
		' 
		' CE_PSolid
		' 
		CE_PSolid.BackColor = SystemColors.Control
		CE_PSolid.Location = New Point(83, 57)
		CE_PSolid.Margin = New Padding(4, 3, 4, 3)
		CE_PSolid.MyText = "ChooseColor"
		CE_PSolid.Name = "CE_PSolid"
		CE_PSolid.SelectedColor = Color.Black
		CE_PSolid.Size = New Size(160, 22)
		CE_PSolid.TabIndex = 1
		' 
		' Label38
		' 
		Label38.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		Label38.BackColor = Color.Transparent
		Label38.Font = New Font("Consolas", 17F, FontStyle.Regular, GraphicsUnit.Point)
		Label38.ForeColor = Color.White
		Label38.Location = New Point(1, 5)
		Label38.Name = "Label38"
		Label38.Size = New Size(248, 30)
		Label38.TabIndex = 0
		Label38.Text = "Fill"
		Label38.TextAlign = ContentAlignment.MiddleCenter
		' 
		' pPath
		' 
		pPath.Controls.Add(P_CBEditor)
		pPath.Controls.Add(P_BEditor)
		pPath.Controls.Add(B_Surround)
		pPath.Controls.Add(PFocusY)
		pPath.Controls.Add(Label27)
		pPath.Controls.Add(PFocusX)
		pPath.Controls.Add(Label28)
		pPath.Controls.Add(PBellScale)
		pPath.Controls.Add(PTriScale)
		pPath.Controls.Add(Label12)
		pPath.Controls.Add(Label13)
		pPath.Controls.Add(PBellFocus)
		pPath.Controls.Add(PTriFocus)
		pPath.Controls.Add(Label14)
		pPath.Controls.Add(Label15)
		pPath.Controls.Add(CB_PBlend)
		pPath.Controls.Add(CB_PColorBlend)
		pPath.Controls.Add(CB_PBell)
		pPath.Controls.Add(CB_PTri)
		pPath.Controls.Add(Label17)
		pPath.Controls.Add(Label18)
		pPath.Controls.Add(CE_P1)
		pPath.Location = New Point(0, 0)
		pPath.Name = "pPath"
		pPath.Size = New Size(250, 657)
		pPath.TabIndex = 0
		' 
		' P_CBEditor
		' 
		P_CBEditor.BackColor = Color.White
		P_CBEditor.Colors = New Color() {Color.Black, Color.FromArgb(CByte(255), CByte(255), CByte(255))}
		P_CBEditor.ForeColor = Color.Black
		P_CBEditor.Location = New Point(3, 302)
		P_CBEditor.MinimumSize = New Size(240, 160)
		P_CBEditor.Name = "P_CBEditor"
		P_CBEditor.Positions = New Single() {0F, 1F}
		P_CBEditor.Size = New Size(240, 160)
		P_CBEditor.TabIndex = 14
		' 
		' P_BEditor
		' 
		P_BEditor.BackColor = Color.White
		P_BEditor.Color1 = Color.Black
		P_BEditor.Color2 = Color.White
		P_BEditor.Factors = New Single() {0F, 1F}
		P_BEditor.ForeColor = Color.Black
		P_BEditor.Location = New Point(7, 490)
		P_BEditor.MinimumSize = New Size(240, 160)
		P_BEditor.Name = "P_BEditor"
		P_BEditor.Positions = New Single() {0F, 1F}
		P_BEditor.Size = New Size(240, 160)
		P_BEditor.TabIndex = 13
		' 
		' B_Surround
		' 
		B_Surround.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		B_Surround.ForeColor = Color.White
		B_Surround.Location = New Point(83, 39)
		B_Surround.MyText = "Edit Surround Colors"
		B_Surround.Name = "B_Surround"
		B_Surround.Size = New Size(160, 22)
		B_Surround.TabIndex = 1
		' 
		' PFocusY
		' 
		PFocusY.BarBorderColor = Color.White
		PFocusY.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PFocusY.Factors = New Single() {0F, 1F}
		PFocusY.Increment = 0.1F
		PFocusY.Location = New Point(83, 98)
		PFocusY.Margin = New Padding(4, 3, 4, 3)
		PFocusY.Maximum = 1F
		PFocusY.Name = "PFocusY"
		PFocusY.Positions = New Single() {0F, 0.5F, 1F}
		PFocusY.Size = New Size(160, 20)
		PFocusY.TabIndex = 3
		PFocusY.ThumbBorderColor = Color.White
		' 
		' Label27
		' 
		Label27.AutoSize = True
		Label27.Location = New Point(3, 101)
		Label27.Name = "Label27"
		Label27.Size = New Size(78, 15)
		Label27.TabIndex = 15
		Label27.Text = "FocusScale Y:"
		' 
		' PFocusX
		' 
		PFocusX.BarBorderColor = Color.White
		PFocusX.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PFocusX.Factors = New Single() {0F, 1F}
		PFocusX.Increment = 0.1F
		PFocusX.Location = New Point(83, 72)
		PFocusX.Margin = New Padding(4, 3, 4, 3)
		PFocusX.Maximum = 1F
		PFocusX.Name = "PFocusX"
		PFocusX.Positions = New Single() {0F, 0.5F, 1F}
		PFocusX.Size = New Size(160, 20)
		PFocusX.TabIndex = 2
		PFocusX.ThumbBorderColor = Color.White
		' 
		' Label28
		' 
		Label28.AutoSize = True
		Label28.Location = New Point(3, 75)
		Label28.Name = "Label28"
		Label28.Size = New Size(78, 15)
		Label28.TabIndex = 16
		Label28.Text = "FocusScale X:"
		' 
		' PBellScale
		' 
		PBellScale.BarBorderColor = Color.White
		PBellScale.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PBellScale.Factors = New Single() {0F, 1F}
		PBellScale.Increment = 0.1F
		PBellScale.Location = New Point(83, 255)
		PBellScale.Margin = New Padding(4, 3, 4, 3)
		PBellScale.Maximum = 1F
		PBellScale.Name = "PBellScale"
		PBellScale.Positions = New Single() {0F, 0.5F, 1F}
		PBellScale.Size = New Size(160, 20)
		PBellScale.TabIndex = 9
		PBellScale.ThumbBorderColor = Color.White
		PBellScale.Value = 1F
		' 
		' PTriScale
		' 
		PTriScale.BarBorderColor = Color.White
		PTriScale.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PTriScale.Factors = New Single() {0F, 1F}
		PTriScale.Increment = 0.1F
		PTriScale.Location = New Point(83, 180)
		PTriScale.Margin = New Padding(4, 3, 4, 3)
		PTriScale.Maximum = 1F
		PTriScale.Name = "PTriScale"
		PTriScale.Positions = New Single() {0F, 0.5F, 1F}
		PTriScale.Size = New Size(160, 20)
		PTriScale.TabIndex = 6
		PTriScale.ThumbBorderColor = Color.White
		PTriScale.Value = 1F
		' 
		' Label12
		' 
		Label12.AutoSize = True
		Label12.Location = New Point(3, 258)
		Label12.Name = "Label12"
		Label12.Size = New Size(37, 15)
		Label12.TabIndex = 10
		Label12.Text = "Scale:"
		' 
		' Label13
		' 
		Label13.AutoSize = True
		Label13.Location = New Point(3, 183)
		Label13.Name = "Label13"
		Label13.Size = New Size(37, 15)
		Label13.TabIndex = 10
		Label13.Text = "Scale:"
		' 
		' PBellFocus
		' 
		PBellFocus.BarBorderColor = Color.White
		PBellFocus.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PBellFocus.Factors = New Single() {0F, 1F}
		PBellFocus.Increment = 0.1F
		PBellFocus.Location = New Point(83, 229)
		PBellFocus.Margin = New Padding(4, 3, 4, 3)
		PBellFocus.Maximum = 1F
		PBellFocus.Name = "PBellFocus"
		PBellFocus.Positions = New Single() {0F, 0.5F, 1F}
		PBellFocus.Size = New Size(160, 20)
		PBellFocus.TabIndex = 8
		PBellFocus.ThumbBorderColor = Color.White
		PBellFocus.Value = 0.5F
		' 
		' PTriFocus
		' 
		PTriFocus.BarBorderColor = Color.White
		PTriFocus.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		PTriFocus.Factors = New Single() {0F, 1F}
		PTriFocus.Increment = 0.1F
		PTriFocus.Location = New Point(83, 154)
		PTriFocus.Margin = New Padding(4, 3, 4, 3)
		PTriFocus.Maximum = 1F
		PTriFocus.Name = "PTriFocus"
		PTriFocus.Positions = New Single() {0F, 0.5F, 1F}
		PTriFocus.Size = New Size(160, 20)
		PTriFocus.TabIndex = 5
		PTriFocus.ThumbBorderColor = Color.White
		PTriFocus.Value = 0.5F
		' 
		' Label14
		' 
		Label14.AutoSize = True
		Label14.Location = New Point(3, 232)
		Label14.Name = "Label14"
		Label14.Size = New Size(41, 15)
		Label14.TabIndex = 10
		Label14.Text = "Focus:"
		' 
		' Label15
		' 
		Label15.AutoSize = True
		Label15.Location = New Point(3, 157)
		Label15.Name = "Label15"
		Label15.Size = New Size(41, 15)
		Label15.TabIndex = 10
		Label15.Text = "Focus:"
		' 
		' CB_PBlend
		' 
		CB_PBlend.AutoSize = True
		CB_PBlend.Location = New Point(6, 469)
		CB_PBlend.Name = "CB_PBlend"
		CB_PBlend.Size = New Size(56, 19)
		CB_PBlend.TabIndex = 12
		CB_PBlend.Text = "Blend"
		CB_PBlend.UseVisualStyleBackColor = True
		' 
		' CB_PColorBlend
		' 
		CB_PColorBlend.AutoSize = True
		CB_PColorBlend.Location = New Point(6, 280)
		CB_PColorBlend.Name = "CB_PColorBlend"
		CB_PColorBlend.Size = New Size(88, 19)
		CB_PColorBlend.TabIndex = 10
		CB_PColorBlend.Text = "Color Blend"
		CB_PColorBlend.UseVisualStyleBackColor = True
		' 
		' CB_PBell
		' 
		CB_PBell.AutoSize = True
		CB_PBell.Location = New Point(6, 205)
		CB_PBell.Name = "CB_PBell"
		CB_PBell.Size = New Size(135, 19)
		CB_PBell.TabIndex = 7
		CB_PBell.Text = "Set Sigma Bell Shape"
		CB_PBell.UseVisualStyleBackColor = True
		' 
		' CB_PTri
		' 
		CB_PTri.AutoSize = True
		CB_PTri.Location = New Point(6, 130)
		CB_PTri.Name = "CB_PTri"
		CB_PTri.Size = New Size(165, 19)
		CB_PTri.TabIndex = 4
		CB_PTri.Text = "Set Blend Triangular Shape"
		CB_PTri.UseVisualStyleBackColor = True
		' 
		' Label17
		' 
		Label17.AutoSize = True
		Label17.Location = New Point(4, 43)
		Label17.Name = "Label17"
		Label17.Size = New Size(59, 15)
		Label17.TabIndex = 10
		Label17.Text = "Surround:"
		' 
		' Label18
		' 
		Label18.AutoSize = True
		Label18.Location = New Point(4, 12)
		Label18.Name = "Label18"
		Label18.Size = New Size(45, 15)
		Label18.TabIndex = 10
		Label18.Text = "Center:"
		' 
		' CE_P1
		' 
		CE_P1.BackColor = SystemColors.Control
		CE_P1.Location = New Point(83, 8)
		CE_P1.Margin = New Padding(4, 3, 4, 3)
		CE_P1.MyText = "ChooseColor"
		CE_P1.Name = "CE_P1"
		CE_P1.SelectedColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
		CE_P1.Size = New Size(160, 22)
		CE_P1.TabIndex = 0
		' 
		' pTexture
		' 
		pTexture.Controls.Add(cb_RotateFlip)
		pTexture.Controls.Add(Label26)
		pTexture.Controls.Add(B_TImage)
		pTexture.Controls.Add(B_TClip)
		pTexture.Controls.Add(Label20)
		pTexture.Controls.Add(PB_Texture)
		pTexture.Controls.Add(CB_Trans)
		pTexture.Controls.Add(Label21)
		pTexture.Controls.Add(CE_Trans)
		pTexture.Location = New Point(0, 0)
		pTexture.Name = "pTexture"
		pTexture.Size = New Size(250, 404)
		pTexture.TabIndex = 0
		' 
		' cb_RotateFlip
		' 
		cb_RotateFlip.AutoCompleteMode = AutoCompleteMode.Append
		cb_RotateFlip.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_RotateFlip.DropDownHeight = 250
		cb_RotateFlip.DropDownStyle = ComboBoxStyle.DropDownList
		cb_RotateFlip.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_RotateFlip.IntegralHeight = False
		cb_RotateFlip.ItemHeight = 17
		cb_RotateFlip.Location = New Point(83, 365)
		cb_RotateFlip.MaxDropDownItems = 14
		cb_RotateFlip.Name = "cb_RotateFlip"
		cb_RotateFlip.Size = New Size(160, 25)
		cb_RotateFlip.TabIndex = 4
		' 
		' Label26
		' 
		Label26.AutoSize = True
		Label26.Location = New Point(3, 370)
		Label26.Name = "Label26"
		Label26.Size = New Size(63, 15)
		Label26.TabIndex = 15
		Label26.Text = "RotateFlip:"
		' 
		' B_TImage
		' 
		B_TImage.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		B_TImage.ForeColor = Color.White
		B_TImage.Location = New Point(126, 272)
		B_TImage.MyText = "Choose File"
		B_TImage.Name = "B_TImage"
		B_TImage.Size = New Size(119, 30)
		B_TImage.TabIndex = 1
		' 
		' B_TClip
		' 
		B_TClip.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
		B_TClip.ForeColor = Color.White
		B_TClip.Location = New Point(5, 272)
		B_TClip.MyText = "From Clipboard"
		B_TClip.Name = "B_TClip"
		B_TClip.Size = New Size(119, 30)
		B_TClip.TabIndex = 0
		' 
		' Label20
		' 
		Label20.AutoSize = True
		Label20.Location = New Point(5, 6)
		Label20.Name = "Label20"
		Label20.Size = New Size(43, 15)
		Label20.TabIndex = 13
		Label20.Text = "Image:"
		' 
		' PB_Texture
		' 
		PB_Texture.BorderStyle = BorderStyle.FixedSingle
		PB_Texture.Location = New Point(5, 26)
		PB_Texture.Name = "PB_Texture"
		PB_Texture.Size = New Size(240, 240)
		PB_Texture.SizeMode = PictureBoxSizeMode.StretchImage
		PB_Texture.TabIndex = 12
		PB_Texture.TabStop = False
		' 
		' CB_Trans
		' 
		CB_Trans.AutoSize = True
		CB_Trans.Location = New Point(6, 309)
		CB_Trans.Name = "CB_Trans"
		CB_Trans.Size = New Size(95, 19)
		CB_Trans.TabIndex = 2
		CB_Trans.Text = "Transparency"
		CB_Trans.UseVisualStyleBackColor = True
		' 
		' Label21
		' 
		Label21.AutoSize = True
		Label21.Location = New Point(3, 335)
		Label21.Name = "Label21"
		Label21.Size = New Size(39, 15)
		Label21.TabIndex = 10
		Label21.Text = "Color:"
		' 
		' CE_Trans
		' 
		CE_Trans.BackColor = SystemColors.Control
		CE_Trans.Location = New Point(83, 331)
		CE_Trans.Margin = New Padding(4, 3, 4, 3)
		CE_Trans.MyText = "ChooseColor"
		CE_Trans.Name = "CE_Trans"
		CE_Trans.SelectedColor = Color.White
		CE_Trans.Size = New Size(160, 22)
		CE_Trans.TabIndex = 3
		' 
		' pHatch
		' 
		pHatch.Controls.Add(cb_HatchStyle)
		pHatch.Controls.Add(Label23)
		pHatch.Controls.Add(Label24)
		pHatch.Controls.Add(CE_H2)
		pHatch.Controls.Add(CE_H1)
		pHatch.Controls.Add(Label16)
		pHatch.ForeColor = Color.White
		pHatch.Location = New Point(0, 0)
		pHatch.Name = "pHatch"
		pHatch.Size = New Size(250, 103)
		pHatch.TabIndex = 0
		' 
		' cb_HatchStyle
		' 
		cb_HatchStyle.AutoCompleteMode = AutoCompleteMode.Append
		cb_HatchStyle.AutoCompleteSource = AutoCompleteSource.ListItems
		cb_HatchStyle.DrawMode = DrawMode.OwnerDrawFixed
		cb_HatchStyle.DropDownHeight = 250
		cb_HatchStyle.DropDownStyle = ComboBoxStyle.DropDownList
		cb_HatchStyle.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
		cb_HatchStyle.IntegralHeight = False
		cb_HatchStyle.ItemHeight = 20
		cb_HatchStyle.Location = New Point(83, 68)
		cb_HatchStyle.MaxDropDownItems = 14
		cb_HatchStyle.Name = "cb_HatchStyle"
		cb_HatchStyle.Size = New Size(160, 26)
		cb_HatchStyle.TabIndex = 2
		' 
		' Label23
		' 
		Label23.AutoSize = True
		Label23.Location = New Point(4, 43)
		Label23.Name = "Label23"
		Label23.Size = New Size(64, 15)
		Label23.TabIndex = 10
		Label23.Text = "BackColor:"
		' 
		' Label24
		' 
		Label24.AutoSize = True
		Label24.Location = New Point(4, 12)
		Label24.Name = "Label24"
		Label24.Size = New Size(62, 15)
		Label24.TabIndex = 10
		Label24.Text = "ForeColor:"
		' 
		' CE_H2
		' 
		CE_H2.BackColor = SystemColors.Control
		CE_H2.Location = New Point(83, 39)
		CE_H2.Margin = New Padding(4, 3, 4, 3)
		CE_H2.MyText = "ChooseColor"
		CE_H2.Name = "CE_H2"
		CE_H2.SelectedColor = Color.White
		CE_H2.Size = New Size(160, 22)
		CE_H2.TabIndex = 1
		' 
		' CE_H1
		' 
		CE_H1.BackColor = SystemColors.Control
		CE_H1.Location = New Point(83, 8)
		CE_H1.Margin = New Padding(4, 3, 4, 3)
		CE_H1.MyText = "ChooseColor"
		CE_H1.Name = "CE_H1"
		CE_H1.SelectedColor = Color.Black
		CE_H1.Size = New Size(160, 22)
		CE_H1.TabIndex = 0
		' 
		' Label16
		' 
		Label16.AutoSize = True
		Label16.Location = New Point(4, 74)
		Label16.Name = "Label16"
		Label16.Size = New Size(70, 15)
		Label16.TabIndex = 10
		Label16.Text = "Hatch Style:"
		' 
		' tCanvas
		' 
		tCanvas.AllowDrop = True
		tCanvas.Controls.Add(TabPage1)
		tCanvas.Dock = DockStyle.Fill
		tCanvas.ItemSize = New Size(100, 24)
		tCanvas.Location = New Point(0, 0)
		tCanvas.MinimumTabs = 0
		tCanvas.Name = "tCanvas"
		tCanvas.SelectedIndex = 0
		tCanvas.SelectedTabColor = Color.DimGray
		tCanvas.Size = New Size(1054, 615)
		tCanvas.TabIndex = 1
		' 
		' TabPage1
		' 
		TabPage1.BorderStyle = BorderStyle.FixedSingle
		TabPage1.Controls.Add(CanvasControl1)
		TabPage1.Location = New Point(4, 28)
		TabPage1.Name = "TabPage1"
		TabPage1.Size = New Size(1046, 583)
		TabPage1.TabIndex = 0
		TabPage1.Text = "Canvas1"
		' 
		' CanvasControl1
		' 
		CanvasControl1.Dock = DockStyle.Fill
		CanvasControl1.Location = New Point(0, 0)
		CanvasControl1.Margin = New Padding(0)
		CanvasControl1.Name = "CanvasControl1"
		CanvasControl1.Size = New Size(1044, 581)
		CanvasControl1.TabIndex = 0
		' 
		' pShear
		' 
		pShear.BackColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
		pShear.Controls.Add(TBShrY)
		pShear.Controls.Add(Label62)
		pShear.Controls.Add(TBShrX)
		pShear.Controls.Add(Label61)
		pShear.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		pShear.ForeColor = Color.White
		pShear.Location = New Point(850, 521)
		pShear.Margin = New Padding(4, 5, 4, 5)
		pShear.Name = "pShear"
		pShear.Resizable = False
		pShear.Size = New Size(250, 103)
		pShear.TabIndex = 9
		pShear.Text = "Shear"
		pShear.Visible = False
		' 
		' TBShrY
		' 
		TBShrY.BackColor = Color.Transparent
		TBShrY.BarBorderColor = Color.White
		TBShrY.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TBShrY.Factors = New Single() {0F, 1F}
		TBShrY.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		TBShrY.Increment = 0.1F
		TBShrY.Location = New Point(58, 64)
		TBShrY.Margin = New Padding(4, 5, 4, 5)
		TBShrY.Maximum = 0.99F
		TBShrY.Minimum = -0.99F
		TBShrY.Name = "TBShrY"
		TBShrY.Positions = New Single() {0F, 0.5F, 1F}
		TBShrY.Size = New Size(188, 20)
		TBShrY.TabIndex = 3
		TBShrY.ThumbBorderColor = Color.White
		' 
		' Label62
		' 
		Label62.AutoSize = True
		Label62.BackColor = Color.Transparent
		Label62.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label62.Location = New Point(3, 68)
		Label62.Name = "Label62"
		Label62.Size = New Size(48, 13)
		Label62.TabIndex = 2
		Label62.Text = "Shear Y:"
		' 
		' TBShrX
		' 
		TBShrX.BackColor = Color.Transparent
		TBShrX.BarBorderColor = Color.White
		TBShrX.Colors = New Color() {Color.Black, Color.SteelBlue, Color.Black}
		TBShrX.Factors = New Single() {0F, 1F}
		TBShrX.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		TBShrX.Increment = 0.1F
		TBShrX.Location = New Point(58, 34)
		TBShrX.Margin = New Padding(4, 5, 4, 5)
		TBShrX.Maximum = 0.99F
		TBShrX.Minimum = -0.99F
		TBShrX.Name = "TBShrX"
		TBShrX.Positions = New Single() {0F, 0.5F, 1F}
		TBShrX.Size = New Size(188, 20)
		TBShrX.TabIndex = 1
		TBShrX.ThumbBorderColor = Color.White
		' 
		' Label61
		' 
		Label61.AutoSize = True
		Label61.BackColor = Color.Transparent
		Label61.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
		Label61.Location = New Point(3, 38)
		Label61.Name = "Label61"
		Label61.Size = New Size(48, 13)
		Label61.TabIndex = 0
		Label61.Text = "Shear X:"
		' 
		' pCanvas
		' 
		pCanvas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		pCanvas.Controls.Add(tCanvas)
		pCanvas.Location = New Point(45, 45)
		pCanvas.Name = "pCanvas"
		pCanvas.Size = New Size(1054, 615)
		pCanvas.TabIndex = 10
		' 
		' MainForm
		' 
		AutoScaleMode = AutoScaleMode.None
		BackColor = Color.Black
		ClientSize = New Size(1366, 705)
		Controls.Add(pShear)
		Controls.Add(pSettings)
		Controls.Add(pSideBar)
		Controls.Add(tTop)
		Controls.Add(tbShadow)
		Controls.Add(tbGlow)
		Controls.Add(tBottom)
		Controls.Add(tbStroke)
		Controls.Add(tbFill)
		Controls.Add(pMain)
		Controls.Add(pCanvas)
		DoubleBuffered = True
		ForeColor = Color.White
		KeyPreview = True
		Name = "MainForm"
		ShowIcon = False
		Text = "MainForm"
		WindowState = FormWindowState.Maximized
		pSettings.ResumeLayout(False)
		pSettings.PerformLayout()
		CType(set_PB, ComponentModel.ISupportInitialize).EndInit()
		CType(set_H, ComponentModel.ISupportInitialize).EndInit()
		CType(set_W, ComponentModel.ISupportInitialize).EndInit()
		pSideBar.ResumeLayout(False)
		tTop.ResumeLayout(False)
		tTop.PerformLayout()
		tBottom.ResumeLayout(False)
		tBottom.PerformLayout()
		CType(ud_A, ComponentModel.ISupportInitialize).EndInit()
		CType(ud_H, ComponentModel.ISupportInitialize).EndInit()
		CType(ud_W, ComponentModel.ISupportInitialize).EndInit()
		CType(ud_Y, ComponentModel.ISupportInitialize).EndInit()
		CType(ud_X, ComponentModel.ISupportInitialize).EndInit()
		pMain.ResumeLayout(False)
		pShadow.ResumeLayout(False)
		pShadow.PerformLayout()
		pGlow.ResumeLayout(False)
		pGlow.PerformLayout()
		pSolid.ResumeLayout(False)
		pSolid.PerformLayout()
		pLinear.ResumeLayout(False)
		pLinear.PerformLayout()
		pStroke.ResumeLayout(False)
		pStroke.PerformLayout()
		pPath.ResumeLayout(False)
		pPath.PerformLayout()
		pTexture.ResumeLayout(False)
		pTexture.PerformLayout()
		CType(PB_Texture, ComponentModel.ISupportInitialize).EndInit()
		pHatch.ResumeLayout(False)
		pHatch.PerformLayout()
		tCanvas.ResumeLayout(False)
		TabPage1.ResumeLayout(False)
		pShear.ResumeLayout(False)
		pShear.PerformLayout()
		pCanvas.ResumeLayout(False)
		ResumeLayout(False)
	End Sub
	Friend WithEvents rDraw As RadioButton
	Friend WithEvents rSelect As RadioButton
	Friend WithEvents tTop As Controls.MyPanel
	Friend WithEvents Label1 As Label
	Friend WithEvents cb_Shape As ComboBox
	Friend WithEvents cb_Brush As ComboBox
	Friend WithEvents CE_Solid As Controls.ColorEditorButton
	Friend WithEvents pSolid As Controls.MyPanel
	Friend WithEvents Label4 As Label
	Friend WithEvents pLinear As Controls.MyPanel
	Friend WithEvents CB_Gamma As CheckBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents CE_L2 As Controls.ColorEditorButton
	Friend WithEvents CE_L1 As Controls.ColorEditorButton
	Friend WithEvents TB_LAngle As Controls.MyTrackBar
	Friend WithEvents Label7 As Label
	Friend WithEvents LTriScale As Controls.MyTrackBar
	Friend WithEvents Label9 As Label
	Friend WithEvents LTriFocus As Controls.MyTrackBar
	Friend WithEvents Label8 As Label
	Friend WithEvents CB_LTri As CheckBox
	Friend WithEvents LBellScale As Controls.MyTrackBar
	Friend WithEvents Label11 As Label
	Friend WithEvents LBellFocus As Controls.MyTrackBar
	Friend WithEvents Label10 As Label
	Friend WithEvents CB_LBell As CheckBox
	Friend WithEvents CB_LBlend As CheckBox
	Friend WithEvents CB_LColorBlend As CheckBox
	Friend WithEvents pPath As Controls.MyPanel
	Friend WithEvents PBellScale As Controls.MyTrackBar
	Friend WithEvents PTriScale As Controls.MyTrackBar
	Friend WithEvents Label12 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents PBellFocus As Controls.MyTrackBar
	Friend WithEvents PTriFocus As Controls.MyTrackBar
	Friend WithEvents Label14 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents CB_PBlend As CheckBox
	Friend WithEvents CB_PColorBlend As CheckBox
	Friend WithEvents CB_PBell As CheckBox
	Friend WithEvents CB_PTri As CheckBox
	Friend WithEvents Label17 As Label
	Friend WithEvents Label18 As Label
	Friend WithEvents CE_P1 As Controls.ColorEditorButton
	Friend WithEvents pHatch As Controls.MyPanel
	Friend WithEvents Label23 As Label
	Friend WithEvents Label24 As Label
	Friend WithEvents CE_H2 As Controls.ColorEditorButton
	Friend WithEvents CE_H1 As Controls.ColorEditorButton
	Friend WithEvents cb_HatchStyle As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents pTexture As Controls.MyPanel
	Friend WithEvents CB_Trans As CheckBox
	Friend WithEvents Label21 As Label
	Friend WithEvents CE_Trans As Controls.ColorEditorButton
	Friend WithEvents Label20 As Label
	Friend WithEvents PB_Texture As PictureBox
	Friend WithEvents openDialog As OpenFileDialog
	Friend WithEvents cb_RotateFlip As ComboBox
	Friend WithEvents Label26 As Label
	Friend WithEvents B_TImage As Controls.MyButton
	Friend WithEvents B_TClip As Controls.MyButton
	Friend WithEvents PFocusY As Controls.MyTrackBar
	Friend WithEvents Label27 As Label
	Friend WithEvents PFocusX As Controls.MyTrackBar
	Friend WithEvents Label28 As Label
	Friend WithEvents Label29 As Label
	Friend WithEvents B_Surround As Controls.MyButton
	Friend WithEvents tBottom As Controls.MyPanel
	Friend WithEvents tCanvas As Controls.MyTabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents pStroke As Controls.MyPanel
	Friend WithEvents Label37 As Label
	Friend WithEvents CE_PSolid As Controls.ColorEditorButton
	Friend WithEvents Label38 As Label
	Friend WithEvents rbpLinear As RadioButton
	Friend WithEvents rbpSolid As RadioButton
	Friend WithEvents cb_PHatchStyle As ComboBox
	Friend WithEvents Label30 As Label
	Friend WithEvents Label31 As Label
	Friend WithEvents CE_PBack As Controls.ColorEditorButton
	Friend WithEvents CE_PFore As Controls.ColorEditorButton
	Friend WithEvents Label32 As Label
	Friend WithEvents rbpHatch As RadioButton
	Friend WithEvents PWidth As Controls.MyTrackBar
	Friend WithEvents Label33 As Label
	Friend WithEvents TB_PAngle As Controls.MyTrackBar
	Friend WithEvents Label34 As Label
	Friend WithEvents CB_PGamma As CheckBox
	Friend WithEvents CB_SCap As ComboBox
	Friend WithEvents Label39 As Label
	Friend WithEvents CB_DCap As ComboBox
	Friend WithEvents Label36 As Label
	Friend WithEvents CB_DStyle As ComboBox
	Friend WithEvents Label35 As Label
	Friend WithEvents CB_LJoin As ComboBox
	Friend WithEvents Label41 As Label
	Friend WithEvents CB_ECap As ComboBox
	Friend WithEvents Label40 As Label
	Friend WithEvents TB_PSY As Controls.MyTrackBar
	Friend WithEvents Label44 As Label
	Friend WithEvents TB_PSX As Controls.MyTrackBar
	Friend WithEvents Label43 As Label
	Friend WithEvents Label42 As Label
	Friend WithEvents Label48 As Label
	Friend WithEvents Label47 As Label
	Friend WithEvents Label46 As Label
	Friend WithEvents Label45 As Label
	Friend WithEvents ud_H As NumericUpDown
	Friend WithEvents ud_W As NumericUpDown
	Friend WithEvents ud_Y As NumericUpDown
	Friend WithEvents ud_X As NumericUpDown
	Friend WithEvents Label49 As Label
	Friend WithEvents ud_A As NumericUpDown
	Friend WithEvents bShape As Controls.MyButton
	Friend WithEvents pGlow As Controls.MyPanel
	Friend WithEvents TB_Feather As Controls.MyTrackBar
	Friend WithEvents Label54 As Label
	Friend WithEvents TB_Glow As Controls.MyTrackBar
	Friend WithEvents Label53 As Label
	Friend WithEvents cb_gfill As CheckBox
	Friend WithEvents cb_GStyle As ComboBox
	Friend WithEvents Label52 As Label
	Friend WithEvents Label50 As Label
	Friend WithEvents CE_Glow As Controls.ColorEditorButton
	Friend WithEvents pShadow As Controls.MyPanel
	Friend WithEvents TB_SFeather As Controls.MyTrackBar
	Friend WithEvents Label55 As Label
	Friend WithEvents TB_SBlur As Controls.MyTrackBar
	Friend WithEvents Label56 As Label
	Friend WithEvents cb_fill As CheckBox
	Friend WithEvents Label58 As Label
	Friend WithEvents CE_Shadow As Controls.ColorEditorButton
	Friend WithEvents cb_clip As CheckBox
	Friend WithEvents PS_Shadow As Controls.PointSelector
	Friend WithEvents cb_EGlow As CheckBox
	Friend WithEvents Label57 As Label
	Friend WithEvents cb_EShadow As CheckBox
	Friend WithEvents pMain As Controls.MyPanel
	Friend WithEvents tbFill As Controls.MyButton
	Friend WithEvents tbStroke As Controls.MyButton
	Friend WithEvents tbGlow As Controls.MyButton
	Friend WithEvents tbShadow As Controls.MyButton
	Friend WithEvents btDelete As Controls.FlatButton
	Friend WithEvents btClone As Controls.FlatButton
	Friend WithEvents btBack As Controls.FlatButton
	Friend WithEvents btFront As Controls.FlatButton
	Friend WithEvents pSideBar As Controls.MyPanel
	Friend WithEvents btExit As Controls.FlatButton
	Friend WithEvents btSettings As Controls.FlatButton
	Friend WithEvents btSave As Controls.FlatButton
	Friend WithEvents btOpen As Controls.FlatButton
	Friend WithEvents btMenu As Controls.FlatButton
	Friend WithEvents btNewC As Controls.FlatButton
	Friend WithEvents saveDialog As SaveFileDialog
	Friend WithEvents cb_GClip As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents CanvasControl1 As CanvasControl
	Friend WithEvents pSettings As Controls.MovablePanel
	Friend WithEvents Label3 As Label
	Friend WithEvents set_BC As Controls.ColorEditorButton
	Friend WithEvents Label25 As Label
	Friend WithEvents Label22 As Label
	Friend WithEvents set_bclr As Controls.ColorEditorButton
	Friend WithEvents set_pclr As Controls.ColorEditorButton
	Friend WithEvents set_hgt As CheckBox
	Friend WithEvents set_H As NumericUpDown
	Friend WithEvents set_W As NumericUpDown
	Friend WithEvents Label60 As Label
	Friend WithEvents Label59 As Label
	Friend WithEvents set_Apply As Controls.MyButton
	Friend WithEvents set_ord As ComboBox
	Friend WithEvents Label19 As Label
	Friend WithEvents pShear As Controls.MovablePanel
	Friend WithEvents TBShrY As Controls.MyTrackBar
	Friend WithEvents Label62 As Label
	Friend WithEvents TBShrX As Controls.MyTrackBar
	Friend WithEvents Label61 As Label
	Friend WithEvents set_cpic As Controls.MyButton
	Friend WithEvents set_lpic As Controls.MyButton
	Friend WithEvents set_PB As PictureBox
	Friend WithEvents Label63 As Label
	Friend WithEvents Label64 As Label
	Friend WithEvents set_cname As TextBox
	Friend WithEvents L_BEditor As Controls.BlendEditor
	Friend WithEvents L_CBEditor As Controls.ColorBlendEditor
	Friend WithEvents LP_CBEditor As Controls.ColorBlendEditor
	Friend WithEvents P_CBEditor As Controls.ColorBlendEditor
	Friend WithEvents P_BEditor As Controls.BlendEditor
	Friend WithEvents pCanvas As Controls.MyPanel
	Friend WithEvents TBZoom As Controls.MyTrackBar
	Friend WithEvents Label51 As Label
	Friend WithEvents bResetZoom As Controls.MyButton
End Class
