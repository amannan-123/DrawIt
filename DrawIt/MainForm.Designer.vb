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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.openDialog = New System.Windows.Forms.OpenFileDialog()
		Me.saveDialog = New System.Windows.Forms.SaveFileDialog()
		Me.pSettings = New MyControls.MovablePanel()
		Me.Label64 = New System.Windows.Forms.Label()
		Me.set_cname = New System.Windows.Forms.TextBox()
		Me.set_cpic = New MyControls.MyButton()
		Me.set_lpic = New MyControls.MyButton()
		Me.set_PB = New System.Windows.Forms.PictureBox()
		Me.set_ord = New System.Windows.Forms.ComboBox()
		Me.set_Apply = New MyControls.MyButton()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.set_bclr = New MyControls.ColorEditorButton()
		Me.set_pclr = New MyControls.ColorEditorButton()
		Me.set_hgt = New System.Windows.Forms.CheckBox()
		Me.set_H = New System.Windows.Forms.NumericUpDown()
		Me.set_W = New System.Windows.Forms.NumericUpDown()
		Me.set_r2 = New System.Windows.Forms.RadioButton()
		Me.set_r1 = New System.Windows.Forms.RadioButton()
		Me.Label51 = New System.Windows.Forms.Label()
		Me.Label60 = New System.Windows.Forms.Label()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label59 = New System.Windows.Forms.Label()
		Me.Label63 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.set_BC = New MyControls.ColorEditorButton()
		Me.pSideBar = New MyControls.MyPanel()
		Me.btNewC = New MyControls.FlatButton()
		Me.btExit = New MyControls.FlatButton()
		Me.btSettings = New MyControls.FlatButton()
		Me.btSave = New MyControls.FlatButton()
		Me.btOpen = New MyControls.FlatButton()
		Me.btMenu = New MyControls.FlatButton()
		Me.tTop = New MyControls.MyPanel()
		Me.btDelete = New MyControls.FlatButton()
		Me.btClone = New MyControls.FlatButton()
		Me.btBack = New MyControls.FlatButton()
		Me.btFront = New MyControls.FlatButton()
		Me.cb_Brush = New System.Windows.Forms.ComboBox()
		Me.cb_Shape = New System.Windows.Forms.ComboBox()
		Me.rDraw = New System.Windows.Forms.RadioButton()
		Me.rSelect = New System.Windows.Forms.RadioButton()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.tbShadow = New MyControls.MyButton()
		Me.tbGlow = New MyControls.MyButton()
		Me.tBottom = New MyControls.MyPanel()
		Me.bShape = New MyControls.MyButton()
		Me.Label49 = New System.Windows.Forms.Label()
		Me.Label48 = New System.Windows.Forms.Label()
		Me.Label47 = New System.Windows.Forms.Label()
		Me.Label46 = New System.Windows.Forms.Label()
		Me.Label45 = New System.Windows.Forms.Label()
		Me.ud_A = New System.Windows.Forms.NumericUpDown()
		Me.ud_H = New System.Windows.Forms.NumericUpDown()
		Me.ud_W = New System.Windows.Forms.NumericUpDown()
		Me.ud_Y = New System.Windows.Forms.NumericUpDown()
		Me.ud_X = New System.Windows.Forms.NumericUpDown()
		Me.tbStroke = New MyControls.MyButton()
		Me.tbFill = New MyControls.MyButton()
		Me.pMain = New MyControls.MyPanel()
		Me.pSolid = New MyControls.MyPanel()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.CE_Solid = New MyControls.ColorEditorButton()
		Me.pLinear = New MyControls.MyPanel()
		Me.L_BEditor = New MyControls.BlendEditor()
		Me.L_CBEditor = New MyControls.ColorBlendEditor()
		Me.LBellScale = New MyControls.MyTrackBar()
		Me.LTriScale = New MyControls.MyTrackBar()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.LBellFocus = New MyControls.MyTrackBar()
		Me.LTriFocus = New MyControls.MyTrackBar()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.TB_LAngle = New MyControls.MyTrackBar()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.CB_LBlend = New System.Windows.Forms.CheckBox()
		Me.CB_LColorBlend = New System.Windows.Forms.CheckBox()
		Me.CB_LBell = New System.Windows.Forms.CheckBox()
		Me.CB_LTri = New System.Windows.Forms.CheckBox()
		Me.CB_Gamma = New System.Windows.Forms.CheckBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.CE_L2 = New MyControls.ColorEditorButton()
		Me.CE_L1 = New MyControls.ColorEditorButton()
		Me.pPath = New MyControls.MyPanel()
		Me.B_Surround = New MyControls.MyButton()
		Me.PFocusY = New MyControls.MyTrackBar()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.PFocusX = New MyControls.MyTrackBar()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.P_BEditor = New MyControls.BlendEditor()
		Me.P_CBEditor = New MyControls.ColorBlendEditor()
		Me.PBellScale = New MyControls.MyTrackBar()
		Me.PTriScale = New MyControls.MyTrackBar()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.PBellFocus = New MyControls.MyTrackBar()
		Me.PTriFocus = New MyControls.MyTrackBar()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.CB_PBlend = New System.Windows.Forms.CheckBox()
		Me.CB_PColorBlend = New System.Windows.Forms.CheckBox()
		Me.CB_PBell = New System.Windows.Forms.CheckBox()
		Me.CB_PTri = New System.Windows.Forms.CheckBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.CE_P1 = New MyControls.ColorEditorButton()
		Me.pHatch = New MyControls.MyPanel()
		Me.cb_HatchStyle = New System.Windows.Forms.ComboBox()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.CE_H2 = New MyControls.ColorEditorButton()
		Me.CE_H1 = New MyControls.ColorEditorButton()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.pTexture = New MyControls.MyPanel()
		Me.cb_RotateFlip = New System.Windows.Forms.ComboBox()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.B_TImage = New MyControls.MyButton()
		Me.B_TClip = New MyControls.MyButton()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.PB_Texture = New System.Windows.Forms.PictureBox()
		Me.CB_Trans = New System.Windows.Forms.CheckBox()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.CE_Trans = New MyControls.ColorEditorButton()
		Me.pStroke = New MyControls.MyPanel()
		Me.TB_PSY = New MyControls.MyTrackBar()
		Me.Label44 = New System.Windows.Forms.Label()
		Me.TB_PSX = New MyControls.MyTrackBar()
		Me.Label43 = New System.Windows.Forms.Label()
		Me.Label42 = New System.Windows.Forms.Label()
		Me.CB_LJoin = New System.Windows.Forms.ComboBox()
		Me.Label41 = New System.Windows.Forms.Label()
		Me.CB_ECap = New System.Windows.Forms.ComboBox()
		Me.Label40 = New System.Windows.Forms.Label()
		Me.CB_SCap = New System.Windows.Forms.ComboBox()
		Me.Label39 = New System.Windows.Forms.Label()
		Me.CB_DCap = New System.Windows.Forms.ComboBox()
		Me.Label36 = New System.Windows.Forms.Label()
		Me.CB_DStyle = New System.Windows.Forms.ComboBox()
		Me.Label35 = New System.Windows.Forms.Label()
		Me.TB_PAngle = New MyControls.MyTrackBar()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.CB_PGamma = New System.Windows.Forms.CheckBox()
		Me.PWidth = New MyControls.MyTrackBar()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.cb_PHatchStyle = New System.Windows.Forms.ComboBox()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.CE_PBack = New MyControls.ColorEditorButton()
		Me.CE_PFore = New MyControls.ColorEditorButton()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.rbpHatch = New System.Windows.Forms.RadioButton()
		Me.rbpLinear = New System.Windows.Forms.RadioButton()
		Me.rbpSolid = New System.Windows.Forms.RadioButton()
		Me.LP_CBEditor = New MyControls.ColorBlendEditor()
		Me.Label37 = New System.Windows.Forms.Label()
		Me.CE_PSolid = New MyControls.ColorEditorButton()
		Me.Label38 = New System.Windows.Forms.Label()
		Me.pGlow = New MyControls.MyPanel()
		Me.cb_EGlow = New System.Windows.Forms.CheckBox()
		Me.TB_Feather = New MyControls.MyTrackBar()
		Me.Label54 = New System.Windows.Forms.Label()
		Me.TB_Glow = New MyControls.MyTrackBar()
		Me.Label53 = New System.Windows.Forms.Label()
		Me.cb_gfill = New System.Windows.Forms.CheckBox()
		Me.cb_GClip = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cb_GStyle = New System.Windows.Forms.ComboBox()
		Me.Label52 = New System.Windows.Forms.Label()
		Me.Label50 = New System.Windows.Forms.Label()
		Me.CE_Glow = New MyControls.ColorEditorButton()
		Me.pShadow = New MyControls.MyPanel()
		Me.PS_Shadow = New MyControls.PointSelector()
		Me.TB_SFeather = New MyControls.MyTrackBar()
		Me.Label55 = New System.Windows.Forms.Label()
		Me.TB_SBlur = New MyControls.MyTrackBar()
		Me.Label57 = New System.Windows.Forms.Label()
		Me.Label56 = New System.Windows.Forms.Label()
		Me.cb_EShadow = New System.Windows.Forms.CheckBox()
		Me.cb_clip = New System.Windows.Forms.CheckBox()
		Me.cb_fill = New System.Windows.Forms.CheckBox()
		Me.Label58 = New System.Windows.Forms.Label()
		Me.CE_Shadow = New MyControls.ColorEditorButton()
		Me.pCanvas = New MyControls.MyPanel()
		Me.tCanvas = New MyControls.MyTabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.pShear = New MyControls.MovablePanel()
		Me.TBShrY = New MyControls.MyTrackBar()
		Me.Label62 = New System.Windows.Forms.Label()
		Me.TBShrX = New MyControls.MyTrackBar()
		Me.Label61 = New System.Windows.Forms.Label()
		Me.CanvasControl1 = New DrawIt.CanvasControl()
		Me.pSettings.SuspendLayout()
		CType(Me.set_PB, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.set_H, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.set_W, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pSideBar.SuspendLayout()
		Me.tTop.SuspendLayout()
		Me.tBottom.SuspendLayout()
		CType(Me.ud_A, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ud_H, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ud_W, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ud_Y, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ud_X, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pMain.SuspendLayout()
		Me.pSolid.SuspendLayout()
		Me.pLinear.SuspendLayout()
		Me.pPath.SuspendLayout()
		Me.pHatch.SuspendLayout()
		Me.pTexture.SuspendLayout()
		CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pStroke.SuspendLayout()
		Me.pGlow.SuspendLayout()
		Me.pShadow.SuspendLayout()
		Me.pCanvas.SuspendLayout()
		Me.tCanvas.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.pShear.SuspendLayout()
		Me.SuspendLayout()
		'
		'openDialog
		'
		Me.openDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.jpe; *" &
	".bmp; *.gif; *.png"""
		Me.openDialog.Title = "Choose Image"
		'
		'pSettings
		'
		Me.pSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
		Me.pSettings.Controls.Add(Me.Label64)
		Me.pSettings.Controls.Add(Me.set_cname)
		Me.pSettings.Controls.Add(Me.set_cpic)
		Me.pSettings.Controls.Add(Me.set_lpic)
		Me.pSettings.Controls.Add(Me.set_PB)
		Me.pSettings.Controls.Add(Me.set_ord)
		Me.pSettings.Controls.Add(Me.set_Apply)
		Me.pSettings.Controls.Add(Me.Label25)
		Me.pSettings.Controls.Add(Me.Label22)
		Me.pSettings.Controls.Add(Me.set_bclr)
		Me.pSettings.Controls.Add(Me.set_pclr)
		Me.pSettings.Controls.Add(Me.set_hgt)
		Me.pSettings.Controls.Add(Me.set_H)
		Me.pSettings.Controls.Add(Me.set_W)
		Me.pSettings.Controls.Add(Me.set_r2)
		Me.pSettings.Controls.Add(Me.set_r1)
		Me.pSettings.Controls.Add(Me.Label51)
		Me.pSettings.Controls.Add(Me.Label60)
		Me.pSettings.Controls.Add(Me.Label19)
		Me.pSettings.Controls.Add(Me.Label59)
		Me.pSettings.Controls.Add(Me.Label63)
		Me.pSettings.Controls.Add(Me.Label3)
		Me.pSettings.Controls.Add(Me.set_BC)
		Me.pSettings.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.pSettings.ForeColor = System.Drawing.Color.White
		Me.pSettings.Location = New System.Drawing.Point(828, 79)
		Me.pSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.pSettings.Name = "pSettings"
		Me.pSettings.Resizable = False
		Me.pSettings.Size = New System.Drawing.Size(250, 466)
		Me.pSettings.TabIndex = 8
		Me.pSettings.Text = "Settings"
		Me.pSettings.Visible = False
		'
		'Label64
		'
		Me.Label64.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label64.AutoSize = True
		Me.Label64.BackColor = System.Drawing.Color.Transparent
		Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label64.Location = New System.Drawing.Point(4, 216)
		Me.Label64.Name = "Label64"
		Me.Label64.Size = New System.Drawing.Size(38, 13)
		Me.Label64.TabIndex = 20
		Me.Label64.Text = "Name:"
		'
		'set_cname
		'
		Me.set_cname.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_cname.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.set_cname.Location = New System.Drawing.Point(5, 230)
		Me.set_cname.MaxLength = 30
		Me.set_cname.Name = "set_cname"
		Me.set_cname.Size = New System.Drawing.Size(238, 25)
		Me.set_cname.TabIndex = 19
		'
		'set_cpic
		'
		Me.set_cpic.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.set_cpic.BackColor = System.Drawing.Color.Black
		Me.set_cpic.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.set_cpic.ForeColor = System.Drawing.Color.White
		Me.set_cpic.Location = New System.Drawing.Point(189, 108)
		Me.set_cpic.MyText = "Clear"
		Me.set_cpic.Name = "set_cpic"
		Me.set_cpic.Size = New System.Drawing.Size(58, 25)
		Me.set_cpic.TabIndex = 18
		'
		'set_lpic
		'
		Me.set_lpic.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.set_lpic.BackColor = System.Drawing.Color.Black
		Me.set_lpic.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.set_lpic.ForeColor = System.Drawing.Color.White
		Me.set_lpic.Location = New System.Drawing.Point(188, 77)
		Me.set_lpic.MyText = "Load"
		Me.set_lpic.Name = "set_lpic"
		Me.set_lpic.Size = New System.Drawing.Size(58, 25)
		Me.set_lpic.TabIndex = 18
		'
		'set_PB
		'
		Me.set_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.set_PB.Location = New System.Drawing.Point(3, 77)
		Me.set_PB.Name = "set_PB"
		Me.set_PB.Size = New System.Drawing.Size(179, 135)
		Me.set_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.set_PB.TabIndex = 17
		Me.set_PB.TabStop = False
		'
		'set_ord
		'
		Me.set_ord.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_ord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.set_ord.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.set_ord.FormattingEnabled = True
		Me.set_ord.Items.AddRange(New Object() {"AboveFirst", "BelowFirst"})
		Me.set_ord.Location = New System.Drawing.Point(91, 316)
		Me.set_ord.Name = "set_ord"
		Me.set_ord.Size = New System.Drawing.Size(154, 25)
		Me.set_ord.TabIndex = 10
		'
		'set_Apply
		'
		Me.set_Apply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_Apply.BackColor = System.Drawing.Color.Black
		Me.set_Apply.ForeColor = System.Drawing.Color.White
		Me.set_Apply.Location = New System.Drawing.Point(88, 421)
		Me.set_Apply.MyText = "Apply"
		Me.set_Apply.Name = "set_Apply"
		Me.set_Apply.Size = New System.Drawing.Size(75, 30)
		Me.set_Apply.TabIndex = 16
		'
		'Label25
		'
		Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label25.AutoSize = True
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label25.Location = New System.Drawing.Point(27, 398)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(41, 13)
		Me.Label25.TabIndex = 14
		Me.Label25.Text = "Border:"
		'
		'Label22
		'
		Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label22.AutoSize = True
		Me.Label22.BackColor = System.Drawing.Color.Transparent
		Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label22.Location = New System.Drawing.Point(27, 368)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(32, 13)
		Me.Label22.TabIndex = 12
		Me.Label22.Text = "Path:"
		'
		'set_bclr
		'
		Me.set_bclr.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_bclr.BackColor = System.Drawing.Color.White
		Me.set_bclr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.set_bclr.Location = New System.Drawing.Point(75, 392)
		Me.set_bclr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.set_bclr.MyText = "ChooseColor"
		Me.set_bclr.Name = "set_bclr"
		Me.set_bclr.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.set_bclr.Size = New System.Drawing.Size(170, 25)
		Me.set_bclr.TabIndex = 15
		'
		'set_pclr
		'
		Me.set_pclr.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_pclr.BackColor = System.Drawing.Color.White
		Me.set_pclr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.set_pclr.Location = New System.Drawing.Point(75, 362)
		Me.set_pclr.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.set_pclr.MyText = "ChooseColor"
		Me.set_pclr.Name = "set_pclr"
		Me.set_pclr.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.set_pclr.Size = New System.Drawing.Size(170, 25)
		Me.set_pclr.TabIndex = 13
		'
		'set_hgt
		'
		Me.set_hgt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_hgt.AutoSize = True
		Me.set_hgt.BackColor = System.Drawing.Color.Transparent
		Me.set_hgt.Checked = True
		Me.set_hgt.CheckState = System.Windows.Forms.CheckState.Checked
		Me.set_hgt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.set_hgt.Location = New System.Drawing.Point(5, 342)
		Me.set_hgt.Name = "set_hgt"
		Me.set_hgt.Size = New System.Drawing.Size(106, 17)
		Me.set_hgt.TabIndex = 11
		Me.set_hgt.Text = "Highlight Shapes"
		Me.set_hgt.UseVisualStyleBackColor = False
		'
		'set_H
		'
		Me.set_H.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.set_H.Location = New System.Drawing.Point(175, 290)
		Me.set_H.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.set_H.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.set_H.Name = "set_H"
		Me.set_H.Size = New System.Drawing.Size(70, 20)
		Me.set_H.TabIndex = 8
		Me.set_H.Value = New Decimal(New Integer() {500, 0, 0, 0})
		'
		'set_W
		'
		Me.set_W.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_W.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.set_W.Location = New System.Drawing.Point(48, 290)
		Me.set_W.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.set_W.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.set_W.Name = "set_W"
		Me.set_W.Size = New System.Drawing.Size(70, 20)
		Me.set_W.TabIndex = 6
		Me.set_W.Value = New Decimal(New Integer() {500, 0, 0, 0})
		'
		'set_r2
		'
		Me.set_r2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_r2.AutoSize = True
		Me.set_r2.BackColor = System.Drawing.Color.Transparent
		Me.set_r2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.set_r2.Location = New System.Drawing.Point(130, 267)
		Me.set_r2.Name = "set_r2"
		Me.set_r2.Size = New System.Drawing.Size(60, 17)
		Me.set_r2.TabIndex = 4
		Me.set_r2.Text = "Manual"
		Me.set_r2.UseVisualStyleBackColor = False
		'
		'set_r1
		'
		Me.set_r1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.set_r1.AutoSize = True
		Me.set_r1.BackColor = System.Drawing.Color.Transparent
		Me.set_r1.Checked = True
		Me.set_r1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.set_r1.Location = New System.Drawing.Point(63, 267)
		Me.set_r1.Name = "set_r1"
		Me.set_r1.Size = New System.Drawing.Size(61, 17)
		Me.set_r1.TabIndex = 3
		Me.set_r1.TabStop = True
		Me.set_r1.Text = "Auto Fit"
		Me.set_r1.UseVisualStyleBackColor = False
		'
		'Label51
		'
		Me.Label51.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label51.AutoSize = True
		Me.Label51.BackColor = System.Drawing.Color.Transparent
		Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label51.Location = New System.Drawing.Point(4, 258)
		Me.Label51.Name = "Label51"
		Me.Label51.Size = New System.Drawing.Size(38, 13)
		Me.Label51.TabIndex = 2
		Me.Label51.Text = "Sizing:"
		'
		'Label60
		'
		Me.Label60.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label60.AutoSize = True
		Me.Label60.BackColor = System.Drawing.Color.Transparent
		Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label60.Location = New System.Drawing.Point(128, 292)
		Me.Label60.Name = "Label60"
		Me.Label60.Size = New System.Drawing.Size(41, 13)
		Me.Label60.TabIndex = 7
		Me.Label60.Text = "Height:"
		'
		'Label19
		'
		Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label19.Location = New System.Drawing.Point(4, 322)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(83, 13)
		Me.Label19.TabIndex = 9
		Me.Label19.Text = "Selection Order:"
		'
		'Label59
		'
		Me.Label59.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.Label59.AutoSize = True
		Me.Label59.BackColor = System.Drawing.Color.Transparent
		Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label59.Location = New System.Drawing.Point(4, 292)
		Me.Label59.Name = "Label59"
		Me.Label59.Size = New System.Drawing.Size(38, 13)
		Me.Label59.TabIndex = 5
		Me.Label59.Text = "Width:"
		'
		'Label63
		'
		Me.Label63.AutoSize = True
		Me.Label63.BackColor = System.Drawing.Color.Transparent
		Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label63.Location = New System.Drawing.Point(3, 61)
		Me.Label63.Name = "Label63"
		Me.Label63.Size = New System.Drawing.Size(100, 13)
		Me.Label63.TabIndex = 0
		Me.Label63.Text = "Background Image:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(3, 38)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(62, 13)
		Me.Label3.TabIndex = 0
		Me.Label3.Text = "Back Color:"
		'
		'set_BC
		'
		Me.set_BC.BackColor = System.Drawing.Color.White
		Me.set_BC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.set_BC.Location = New System.Drawing.Point(72, 32)
		Me.set_BC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.set_BC.MyText = "ChooseColor"
		Me.set_BC.Name = "set_BC"
		Me.set_BC.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.set_BC.Size = New System.Drawing.Size(174, 25)
		Me.set_BC.TabIndex = 1
		'
		'pSideBar
		'
		Me.pSideBar.Controls.Add(Me.btNewC)
		Me.pSideBar.Controls.Add(Me.btExit)
		Me.pSideBar.Controls.Add(Me.btSettings)
		Me.pSideBar.Controls.Add(Me.btSave)
		Me.pSideBar.Controls.Add(Me.btOpen)
		Me.pSideBar.Controls.Add(Me.btMenu)
		Me.pSideBar.Dock = System.Windows.Forms.DockStyle.Left
		Me.pSideBar.Location = New System.Drawing.Point(0, 0)
		Me.pSideBar.Name = "pSideBar"
		Me.pSideBar.Size = New System.Drawing.Size(45, 705)
		Me.pSideBar.TabIndex = 7
		'
		'btNewC
		'
		Me.btNewC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btNewC.DrawText = False
		Me.btNewC.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btNewC.FontSizeIncrement = 0.4!
		Me.btNewC.Icon = CType(resources.GetObject("btNewC.Icon"), System.Drawing.Image)
		Me.btNewC.Location = New System.Drawing.Point(0, 45)
		Me.btNewC.Margin = New System.Windows.Forms.Padding(0)
		Me.btNewC.MyText = "New"
		Me.btNewC.Name = "btNewC"
		Me.btNewC.Size = New System.Drawing.Size(45, 45)
		Me.btNewC.TabIndex = 17
		'
		'btExit
		'
		Me.btExit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btExit.DrawText = False
		Me.btExit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btExit.FontSizeIncrement = 0.4!
		Me.btExit.Icon = CType(resources.GetObject("btExit.Icon"), System.Drawing.Image)
		Me.btExit.Location = New System.Drawing.Point(0, 660)
		Me.btExit.Margin = New System.Windows.Forms.Padding(0)
		Me.btExit.MyText = "Exit"
		Me.btExit.Name = "btExit"
		Me.btExit.Size = New System.Drawing.Size(45, 45)
		Me.btExit.TabIndex = 15
		'
		'btSettings
		'
		Me.btSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btSettings.DrawText = False
		Me.btSettings.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btSettings.FontSizeIncrement = 0.4!
		Me.btSettings.Icon = CType(resources.GetObject("btSettings.Icon"), System.Drawing.Image)
		Me.btSettings.Location = New System.Drawing.Point(0, 180)
		Me.btSettings.Margin = New System.Windows.Forms.Padding(0)
		Me.btSettings.MyText = "Settings"
		Me.btSettings.Name = "btSettings"
		Me.btSettings.Size = New System.Drawing.Size(45, 45)
		Me.btSettings.TabIndex = 11
		'
		'btSave
		'
		Me.btSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btSave.DrawText = False
		Me.btSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btSave.FontSizeIncrement = 0.4!
		Me.btSave.Icon = CType(resources.GetObject("btSave.Icon"), System.Drawing.Image)
		Me.btSave.Location = New System.Drawing.Point(0, 135)
		Me.btSave.Margin = New System.Windows.Forms.Padding(0)
		Me.btSave.MyText = "Save"
		Me.btSave.Name = "btSave"
		Me.btSave.Size = New System.Drawing.Size(45, 45)
		Me.btSave.TabIndex = 12
		'
		'btOpen
		'
		Me.btOpen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btOpen.DrawText = False
		Me.btOpen.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btOpen.FontSizeIncrement = 0.4!
		Me.btOpen.Icon = CType(resources.GetObject("btOpen.Icon"), System.Drawing.Image)
		Me.btOpen.Location = New System.Drawing.Point(0, 90)
		Me.btOpen.Margin = New System.Windows.Forms.Padding(0)
		Me.btOpen.MyText = "Open"
		Me.btOpen.Name = "btOpen"
		Me.btOpen.Size = New System.Drawing.Size(45, 45)
		Me.btOpen.TabIndex = 13
		'
		'btMenu
		'
		Me.btMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btMenu.DrawText = False
		Me.btMenu.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btMenu.FontSizeIncrement = 0!
		Me.btMenu.Icon = CType(resources.GetObject("btMenu.Icon"), System.Drawing.Image)
		Me.btMenu.Location = New System.Drawing.Point(0, 0)
		Me.btMenu.Margin = New System.Windows.Forms.Padding(0)
		Me.btMenu.MyText = "Menu"
		Me.btMenu.Name = "btMenu"
		Me.btMenu.Size = New System.Drawing.Size(45, 45)
		Me.btMenu.TabIndex = 14
		'
		'tTop
		'
		Me.tTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.tTop.Controls.Add(Me.btDelete)
		Me.tTop.Controls.Add(Me.btClone)
		Me.tTop.Controls.Add(Me.btBack)
		Me.tTop.Controls.Add(Me.btFront)
		Me.tTop.Controls.Add(Me.cb_Brush)
		Me.tTop.Controls.Add(Me.cb_Shape)
		Me.tTop.Controls.Add(Me.rDraw)
		Me.tTop.Controls.Add(Me.rSelect)
		Me.tTop.Controls.Add(Me.Label29)
		Me.tTop.Controls.Add(Me.Label1)
		Me.tTop.ForeColor = System.Drawing.Color.White
		Me.tTop.Location = New System.Drawing.Point(45, 0)
		Me.tTop.Name = "tTop"
		Me.tTop.Size = New System.Drawing.Size(1042, 45)
		Me.tTop.TabIndex = 0
		'
		'btDelete
		'
		Me.btDelete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btDelete.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btDelete.Icon = CType(resources.GetObject("btDelete.Icon"), System.Drawing.Image)
		Me.btDelete.Location = New System.Drawing.Point(997, 0)
		Me.btDelete.Margin = New System.Windows.Forms.Padding(0)
		Me.btDelete.MyText = ""
		Me.btDelete.Name = "btDelete"
		Me.btDelete.Size = New System.Drawing.Size(45, 45)
		Me.btDelete.TabIndex = 5
		'
		'btClone
		'
		Me.btClone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btClone.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btClone.Icon = CType(resources.GetObject("btClone.Icon"), System.Drawing.Image)
		Me.btClone.Location = New System.Drawing.Point(952, 0)
		Me.btClone.Margin = New System.Windows.Forms.Padding(0)
		Me.btClone.MyText = ""
		Me.btClone.Name = "btClone"
		Me.btClone.Size = New System.Drawing.Size(45, 45)
		Me.btClone.TabIndex = 6
		'
		'btBack
		'
		Me.btBack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btBack.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btBack.Icon = CType(resources.GetObject("btBack.Icon"), System.Drawing.Image)
		Me.btBack.Location = New System.Drawing.Point(907, 0)
		Me.btBack.Margin = New System.Windows.Forms.Padding(0)
		Me.btBack.MyText = ""
		Me.btBack.Name = "btBack"
		Me.btBack.Size = New System.Drawing.Size(45, 45)
		Me.btBack.TabIndex = 7
		'
		'btFront
		'
		Me.btFront.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btFront.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btFront.Icon = CType(resources.GetObject("btFront.Icon"), System.Drawing.Image)
		Me.btFront.Location = New System.Drawing.Point(862, 0)
		Me.btFront.Margin = New System.Windows.Forms.Padding(0)
		Me.btFront.MyText = ""
		Me.btFront.Name = "btFront"
		Me.btFront.Size = New System.Drawing.Size(45, 45)
		Me.btFront.TabIndex = 8
		'
		'cb_Brush
		'
		Me.cb_Brush.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.cb_Brush.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_Brush.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_Brush.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cb_Brush.DropDownHeight = 250
		Me.cb_Brush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_Brush.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_Brush.IntegralHeight = False
		Me.cb_Brush.ItemHeight = 20
		Me.cb_Brush.Location = New System.Drawing.Point(604, 9)
		Me.cb_Brush.MaxDropDownItems = 14
		Me.cb_Brush.Name = "cb_Brush"
		Me.cb_Brush.Size = New System.Drawing.Size(171, 26)
		Me.cb_Brush.TabIndex = 3
		'
		'cb_Shape
		'
		Me.cb_Shape.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.cb_Shape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_Shape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_Shape.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cb_Shape.DropDownHeight = 250
		Me.cb_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_Shape.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_Shape.IntegralHeight = False
		Me.cb_Shape.ItemHeight = 20
		Me.cb_Shape.Location = New System.Drawing.Point(384, 9)
		Me.cb_Shape.MaxDropDownItems = 14
		Me.cb_Shape.Name = "cb_Shape"
		Me.cb_Shape.Size = New System.Drawing.Size(171, 26)
		Me.cb_Shape.TabIndex = 2
		'
		'rDraw
		'
		Me.rDraw.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.rDraw.AutoSize = True
		Me.rDraw.Checked = True
		Me.rDraw.Location = New System.Drawing.Point(268, 4)
		Me.rDraw.Name = "rDraw"
		Me.rDraw.Size = New System.Drawing.Size(50, 17)
		Me.rDraw.TabIndex = 0
		Me.rDraw.TabStop = True
		Me.rDraw.Text = "Draw"
		Me.rDraw.UseVisualStyleBackColor = True
		'
		'rSelect
		'
		Me.rSelect.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.rSelect.AutoSize = True
		Me.rSelect.Location = New System.Drawing.Point(268, 24)
		Me.rSelect.Name = "rSelect"
		Me.rSelect.Size = New System.Drawing.Size(55, 17)
		Me.rSelect.TabIndex = 1
		Me.rSelect.Text = "Select"
		Me.rSelect.UseVisualStyleBackColor = True
		'
		'Label29
		'
		Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label29.AutoSize = True
		Me.Label29.Location = New System.Drawing.Point(337, 16)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(41, 13)
		Me.Label29.TabIndex = 3
		Me.Label29.Text = "Shape:"
		'
		'Label1
		'
		Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(561, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(37, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Brush:"
		'
		'tbShadow
		'
		Me.tbShadow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tbShadow.BackColor = System.Drawing.Color.Black
		Me.tbShadow.DrawFocus = False
		Me.tbShadow.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbShadow.ForeColor = System.Drawing.Color.White
		Me.tbShadow.Location = New System.Drawing.Point(1287, 0)
		Me.tbShadow.MyText = "Shadow"
		Me.tbShadow.Name = "tbShadow"
		Me.tbShadow.Size = New System.Drawing.Size(79, 30)
		Me.tbShadow.TabIndex = 4
		'
		'tbGlow
		'
		Me.tbGlow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tbGlow.BackColor = System.Drawing.Color.Black
		Me.tbGlow.DrawFocus = False
		Me.tbGlow.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbGlow.ForeColor = System.Drawing.Color.White
		Me.tbGlow.Location = New System.Drawing.Point(1220, 0)
		Me.tbGlow.MyText = "Glow"
		Me.tbGlow.Name = "tbGlow"
		Me.tbGlow.Size = New System.Drawing.Size(67, 30)
		Me.tbGlow.TabIndex = 3
		'
		'tBottom
		'
		Me.tBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.tBottom.Controls.Add(Me.bShape)
		Me.tBottom.Controls.Add(Me.Label49)
		Me.tBottom.Controls.Add(Me.Label48)
		Me.tBottom.Controls.Add(Me.Label47)
		Me.tBottom.Controls.Add(Me.Label46)
		Me.tBottom.Controls.Add(Me.Label45)
		Me.tBottom.Controls.Add(Me.ud_A)
		Me.tBottom.Controls.Add(Me.ud_H)
		Me.tBottom.Controls.Add(Me.ud_W)
		Me.tBottom.Controls.Add(Me.ud_Y)
		Me.tBottom.Controls.Add(Me.ud_X)
		Me.tBottom.ForeColor = System.Drawing.Color.White
		Me.tBottom.Location = New System.Drawing.Point(45, 660)
		Me.tBottom.Name = "tBottom"
		Me.tBottom.Size = New System.Drawing.Size(1042, 45)
		Me.tBottom.TabIndex = 2
		'
		'bShape
		'
		Me.bShape.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.bShape.BackColor = System.Drawing.Color.Black
		Me.bShape.ForeColor = System.Drawing.Color.White
		Me.bShape.Location = New System.Drawing.Point(721, 7)
		Me.bShape.MyText = "Edit Shape"
		Me.bShape.Name = "bShape"
		Me.bShape.Size = New System.Drawing.Size(75, 30)
		Me.bShape.TabIndex = 5
		'
		'Label49
		'
		Me.Label49.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label49.AutoSize = True
		Me.Label49.Location = New System.Drawing.Point(611, 14)
		Me.Label49.Name = "Label49"
		Me.Label49.Size = New System.Drawing.Size(37, 13)
		Me.Label49.TabIndex = 1
		Me.Label49.Text = "Angle:"
		'
		'Label48
		'
		Me.Label48.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label48.AutoSize = True
		Me.Label48.Location = New System.Drawing.Point(520, 14)
		Me.Label48.Name = "Label48"
		Me.Label48.Size = New System.Drawing.Size(18, 13)
		Me.Label48.TabIndex = 1
		Me.Label48.Text = "H:"
		'
		'Label47
		'
		Me.Label47.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label47.AutoSize = True
		Me.Label47.Location = New System.Drawing.Point(426, 14)
		Me.Label47.Name = "Label47"
		Me.Label47.Size = New System.Drawing.Size(21, 13)
		Me.Label47.TabIndex = 1
		Me.Label47.Text = "W:"
		'
		'Label46
		'
		Me.Label46.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label46.AutoSize = True
		Me.Label46.Location = New System.Drawing.Point(336, 14)
		Me.Label46.Name = "Label46"
		Me.Label46.Size = New System.Drawing.Size(17, 13)
		Me.Label46.TabIndex = 1
		Me.Label46.Text = "Y:"
		'
		'Label45
		'
		Me.Label45.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Label45.AutoSize = True
		Me.Label45.Location = New System.Drawing.Point(246, 14)
		Me.Label45.Name = "Label45"
		Me.Label45.Size = New System.Drawing.Size(17, 13)
		Me.Label45.TabIndex = 1
		Me.Label45.Text = "X:"
		'
		'ud_A
		'
		Me.ud_A.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.ud_A.DecimalPlaces = 2
		Me.ud_A.Location = New System.Drawing.Point(654, 12)
		Me.ud_A.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
		Me.ud_A.Name = "ud_A"
		Me.ud_A.Size = New System.Drawing.Size(61, 20)
		Me.ud_A.TabIndex = 4
		'
		'ud_H
		'
		Me.ud_H.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.ud_H.DecimalPlaces = 2
		Me.ud_H.Location = New System.Drawing.Point(544, 12)
		Me.ud_H.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.ud_H.Name = "ud_H"
		Me.ud_H.Size = New System.Drawing.Size(61, 20)
		Me.ud_H.TabIndex = 3
		'
		'ud_W
		'
		Me.ud_W.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.ud_W.DecimalPlaces = 2
		Me.ud_W.Location = New System.Drawing.Point(453, 12)
		Me.ud_W.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.ud_W.Name = "ud_W"
		Me.ud_W.Size = New System.Drawing.Size(61, 20)
		Me.ud_W.TabIndex = 2
		'
		'ud_Y
		'
		Me.ud_Y.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.ud_Y.DecimalPlaces = 2
		Me.ud_Y.Location = New System.Drawing.Point(359, 12)
		Me.ud_Y.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.ud_Y.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
		Me.ud_Y.Name = "ud_Y"
		Me.ud_Y.Size = New System.Drawing.Size(61, 20)
		Me.ud_Y.TabIndex = 1
		'
		'ud_X
		'
		Me.ud_X.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.ud_X.DecimalPlaces = 2
		Me.ud_X.Location = New System.Drawing.Point(269, 12)
		Me.ud_X.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
		Me.ud_X.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
		Me.ud_X.Name = "ud_X"
		Me.ud_X.Size = New System.Drawing.Size(61, 20)
		Me.ud_X.TabIndex = 0
		'
		'tbStroke
		'
		Me.tbStroke.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tbStroke.BackColor = System.Drawing.Color.Black
		Me.tbStroke.DrawFocus = False
		Me.tbStroke.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbStroke.ForeColor = System.Drawing.Color.White
		Me.tbStroke.Location = New System.Drawing.Point(1153, 0)
		Me.tbStroke.MyText = "Stroke"
		Me.tbStroke.Name = "tbStroke"
		Me.tbStroke.Size = New System.Drawing.Size(67, 30)
		Me.tbStroke.TabIndex = 2
		'
		'tbFill
		'
		Me.tbFill.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tbFill.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
		Me.tbFill.DrawEffect = False
		Me.tbFill.DrawFocus = False
		Me.tbFill.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbFill.ForeColor = System.Drawing.Color.White
		Me.tbFill.Location = New System.Drawing.Point(1088, 0)
		Me.tbFill.MyText = "Fill"
		Me.tbFill.Name = "tbFill"
		Me.tbFill.Size = New System.Drawing.Size(65, 30)
		Me.tbFill.TabIndex = 1
		'
		'pMain
		'
		Me.pMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pMain.AutoScroll = True
		Me.pMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
		Me.pMain.Controls.Add(Me.pSolid)
		Me.pMain.Controls.Add(Me.pLinear)
		Me.pMain.Controls.Add(Me.pPath)
		Me.pMain.Controls.Add(Me.pHatch)
		Me.pMain.Controls.Add(Me.pTexture)
		Me.pMain.Controls.Add(Me.pStroke)
		Me.pMain.Controls.Add(Me.pGlow)
		Me.pMain.Controls.Add(Me.pShadow)
		Me.pMain.Location = New System.Drawing.Point(1088, 30)
		Me.pMain.Name = "pMain"
		Me.pMain.Size = New System.Drawing.Size(278, 675)
		Me.pMain.TabIndex = 5
		'
		'pSolid
		'
		Me.pSolid.Controls.Add(Me.Label4)
		Me.pSolid.Controls.Add(Me.CE_Solid)
		Me.pSolid.Location = New System.Drawing.Point(0, 0)
		Me.pSolid.Name = "pSolid"
		Me.pSolid.Size = New System.Drawing.Size(260, 40)
		Me.pSolid.TabIndex = 0
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(4, 12)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(60, 13)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "Solid Color:"
		'
		'CE_Solid
		'
		Me.CE_Solid.BackColor = System.Drawing.SystemColors.Control
		Me.CE_Solid.Location = New System.Drawing.Point(69, 6)
		Me.CE_Solid.MyText = "ChooseColor"
		Me.CE_Solid.Name = "CE_Solid"
		Me.CE_Solid.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_Solid.Size = New System.Drawing.Size(186, 25)
		Me.CE_Solid.TabIndex = 0
		'
		'pLinear
		'
		Me.pLinear.Controls.Add(Me.L_BEditor)
		Me.pLinear.Controls.Add(Me.L_CBEditor)
		Me.pLinear.Controls.Add(Me.LBellScale)
		Me.pLinear.Controls.Add(Me.LTriScale)
		Me.pLinear.Controls.Add(Me.Label11)
		Me.pLinear.Controls.Add(Me.Label9)
		Me.pLinear.Controls.Add(Me.LBellFocus)
		Me.pLinear.Controls.Add(Me.LTriFocus)
		Me.pLinear.Controls.Add(Me.Label10)
		Me.pLinear.Controls.Add(Me.Label8)
		Me.pLinear.Controls.Add(Me.TB_LAngle)
		Me.pLinear.Controls.Add(Me.Label7)
		Me.pLinear.Controls.Add(Me.CB_LBlend)
		Me.pLinear.Controls.Add(Me.CB_LColorBlend)
		Me.pLinear.Controls.Add(Me.CB_LBell)
		Me.pLinear.Controls.Add(Me.CB_LTri)
		Me.pLinear.Controls.Add(Me.CB_Gamma)
		Me.pLinear.Controls.Add(Me.Label6)
		Me.pLinear.Controls.Add(Me.Label5)
		Me.pLinear.Controls.Add(Me.CE_L2)
		Me.pLinear.Controls.Add(Me.CE_L1)
		Me.pLinear.Location = New System.Drawing.Point(0, 0)
		Me.pLinear.Name = "pLinear"
		Me.pLinear.Size = New System.Drawing.Size(260, 644)
		Me.pLinear.TabIndex = 0
		'
		'L_BEditor
		'
		Me.L_BEditor.BackColor = System.Drawing.Color.White
		Me.L_BEditor.Color1 = System.Drawing.Color.White
		Me.L_BEditor.Color2 = System.Drawing.Color.Black
		Me.L_BEditor.Factors = New Single() {0!, 1.0!}
		Me.L_BEditor.ForeColor = System.Drawing.Color.Black
		Me.L_BEditor.Location = New System.Drawing.Point(7, 476)
		Me.L_BEditor.MinimumSize = New System.Drawing.Size(250, 160)
		Me.L_BEditor.Name = "L_BEditor"
		Me.L_BEditor.Positions = New Single() {0!, 1.0!}
		Me.L_BEditor.Size = New System.Drawing.Size(250, 160)
		Me.L_BEditor.TabIndex = 13
		'
		'L_CBEditor
		'
		Me.L_CBEditor.BackColor = System.Drawing.Color.White
		Me.L_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.Black}
		Me.L_CBEditor.ForeColor = System.Drawing.Color.Black
		Me.L_CBEditor.Location = New System.Drawing.Point(7, 287)
		Me.L_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
		Me.L_CBEditor.Name = "L_CBEditor"
		Me.L_CBEditor.Positions = New Single() {0!, 1.0!}
		Me.L_CBEditor.Size = New System.Drawing.Size(250, 160)
		Me.L_CBEditor.TabIndex = 11
		'
		'LBellScale
		'
		Me.LBellScale.BarBorderColor = System.Drawing.Color.White
		Me.LBellScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.LBellScale.Factors = New Single() {0!, 1.0!}
		Me.LBellScale.Increment = 0.1!
		Me.LBellScale.Location = New System.Drawing.Point(69, 238)
		Me.LBellScale.Maximum = 1.0!
		Me.LBellScale.Name = "LBellScale"
		Me.LBellScale.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.LBellScale.Size = New System.Drawing.Size(186, 20)
		Me.LBellScale.TabIndex = 9
		Me.LBellScale.ThumbBorderColor = System.Drawing.Color.White
		Me.LBellScale.Value = 1.0!
		'
		'LTriScale
		'
		Me.LTriScale.BarBorderColor = System.Drawing.Color.White
		Me.LTriScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.LTriScale.Factors = New Single() {0!, 1.0!}
		Me.LTriScale.Increment = 0.1!
		Me.LTriScale.Location = New System.Drawing.Point(69, 163)
		Me.LTriScale.Maximum = 1.0!
		Me.LTriScale.Name = "LTriScale"
		Me.LTriScale.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.LTriScale.Size = New System.Drawing.Size(186, 20)
		Me.LTriScale.TabIndex = 6
		Me.LTriScale.ThumbBorderColor = System.Drawing.Color.White
		Me.LTriScale.Value = 1.0!
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(3, 242)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(37, 13)
		Me.Label11.TabIndex = 10
		Me.Label11.Text = "Scale:"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(3, 167)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(37, 13)
		Me.Label9.TabIndex = 10
		Me.Label9.Text = "Scale:"
		'
		'LBellFocus
		'
		Me.LBellFocus.BarBorderColor = System.Drawing.Color.White
		Me.LBellFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.LBellFocus.Factors = New Single() {0!, 1.0!}
		Me.LBellFocus.Increment = 0.1!
		Me.LBellFocus.Location = New System.Drawing.Point(69, 212)
		Me.LBellFocus.Maximum = 1.0!
		Me.LBellFocus.Name = "LBellFocus"
		Me.LBellFocus.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.LBellFocus.Size = New System.Drawing.Size(186, 20)
		Me.LBellFocus.TabIndex = 8
		Me.LBellFocus.ThumbBorderColor = System.Drawing.Color.White
		Me.LBellFocus.Value = 0.5!
		'
		'LTriFocus
		'
		Me.LTriFocus.BarBorderColor = System.Drawing.Color.White
		Me.LTriFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.LTriFocus.Factors = New Single() {0!, 1.0!}
		Me.LTriFocus.Increment = 0.1!
		Me.LTriFocus.Location = New System.Drawing.Point(69, 137)
		Me.LTriFocus.Maximum = 1.0!
		Me.LTriFocus.Name = "LTriFocus"
		Me.LTriFocus.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.LTriFocus.Size = New System.Drawing.Size(186, 20)
		Me.LTriFocus.TabIndex = 5
		Me.LTriFocus.ThumbBorderColor = System.Drawing.Color.White
		Me.LTriFocus.Value = 0.5!
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(3, 216)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(39, 13)
		Me.Label10.TabIndex = 10
		Me.Label10.Text = "Focus:"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(3, 141)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(39, 13)
		Me.Label8.TabIndex = 10
		Me.Label8.Text = "Focus:"
		'
		'TB_LAngle
		'
		Me.TB_LAngle.AllowDecimal = False
		Me.TB_LAngle.BarBorderColor = System.Drawing.Color.White
		Me.TB_LAngle.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_LAngle.Factors = New Single() {0!, 1.0!}
		Me.TB_LAngle.Location = New System.Drawing.Point(69, 88)
		Me.TB_LAngle.Maximum = 360.0!
		Me.TB_LAngle.Name = "TB_LAngle"
		Me.TB_LAngle.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_LAngle.Size = New System.Drawing.Size(186, 20)
		Me.TB_LAngle.TabIndex = 3
		Me.TB_LAngle.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(4, 92)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(37, 13)
		Me.Label7.TabIndex = 10
		Me.Label7.Text = "Angle:"
		'
		'CB_LBlend
		'
		Me.CB_LBlend.AutoSize = True
		Me.CB_LBlend.Location = New System.Drawing.Point(6, 453)
		Me.CB_LBlend.Name = "CB_LBlend"
		Me.CB_LBlend.Size = New System.Drawing.Size(53, 17)
		Me.CB_LBlend.TabIndex = 12
		Me.CB_LBlend.Text = "Blend"
		Me.CB_LBlend.UseVisualStyleBackColor = True
		'
		'CB_LColorBlend
		'
		Me.CB_LColorBlend.AutoSize = True
		Me.CB_LColorBlend.Location = New System.Drawing.Point(6, 264)
		Me.CB_LColorBlend.Name = "CB_LColorBlend"
		Me.CB_LColorBlend.Size = New System.Drawing.Size(80, 17)
		Me.CB_LColorBlend.TabIndex = 10
		Me.CB_LColorBlend.Text = "Color Blend"
		Me.CB_LColorBlend.UseVisualStyleBackColor = True
		'
		'CB_LBell
		'
		Me.CB_LBell.AutoSize = True
		Me.CB_LBell.Location = New System.Drawing.Point(6, 189)
		Me.CB_LBell.Name = "CB_LBell"
		Me.CB_LBell.Size = New System.Drawing.Size(128, 17)
		Me.CB_LBell.TabIndex = 7
		Me.CB_LBell.Text = "Set Sigma Bell Shape"
		Me.CB_LBell.UseVisualStyleBackColor = True
		'
		'CB_LTri
		'
		Me.CB_LTri.AutoSize = True
		Me.CB_LTri.Location = New System.Drawing.Point(6, 114)
		Me.CB_LTri.Name = "CB_LTri"
		Me.CB_LTri.Size = New System.Drawing.Size(156, 17)
		Me.CB_LTri.TabIndex = 4
		Me.CB_LTri.Text = "Set Blend Triangular Shape"
		Me.CB_LTri.UseVisualStyleBackColor = True
		'
		'CB_Gamma
		'
		Me.CB_Gamma.AutoSize = True
		Me.CB_Gamma.Location = New System.Drawing.Point(6, 68)
		Me.CB_Gamma.Name = "CB_Gamma"
		Me.CB_Gamma.Size = New System.Drawing.Size(113, 17)
		Me.CB_Gamma.TabIndex = 2
		Me.CB_Gamma.Text = "Gamma Correction"
		Me.CB_Gamma.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(4, 43)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(43, 13)
		Me.Label6.TabIndex = 10
		Me.Label6.Text = "Color 2:"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(4, 12)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(43, 13)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "Color 1:"
		'
		'CE_L2
		'
		Me.CE_L2.BackColor = System.Drawing.SystemColors.Control
		Me.CE_L2.Location = New System.Drawing.Point(69, 37)
		Me.CE_L2.MyText = "ChooseColor"
		Me.CE_L2.Name = "CE_L2"
		Me.CE_L2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.CE_L2.Size = New System.Drawing.Size(186, 25)
		Me.CE_L2.TabIndex = 1
		'
		'CE_L1
		'
		Me.CE_L1.BackColor = System.Drawing.SystemColors.Control
		Me.CE_L1.Location = New System.Drawing.Point(69, 6)
		Me.CE_L1.MyText = "ChooseColor"
		Me.CE_L1.Name = "CE_L1"
		Me.CE_L1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_L1.Size = New System.Drawing.Size(186, 25)
		Me.CE_L1.TabIndex = 0
		'
		'pPath
		'
		Me.pPath.Controls.Add(Me.B_Surround)
		Me.pPath.Controls.Add(Me.PFocusY)
		Me.pPath.Controls.Add(Me.Label27)
		Me.pPath.Controls.Add(Me.PFocusX)
		Me.pPath.Controls.Add(Me.Label28)
		Me.pPath.Controls.Add(Me.P_BEditor)
		Me.pPath.Controls.Add(Me.P_CBEditor)
		Me.pPath.Controls.Add(Me.PBellScale)
		Me.pPath.Controls.Add(Me.PTriScale)
		Me.pPath.Controls.Add(Me.Label12)
		Me.pPath.Controls.Add(Me.Label13)
		Me.pPath.Controls.Add(Me.PBellFocus)
		Me.pPath.Controls.Add(Me.PTriFocus)
		Me.pPath.Controls.Add(Me.Label14)
		Me.pPath.Controls.Add(Me.Label15)
		Me.pPath.Controls.Add(Me.CB_PBlend)
		Me.pPath.Controls.Add(Me.CB_PColorBlend)
		Me.pPath.Controls.Add(Me.CB_PBell)
		Me.pPath.Controls.Add(Me.CB_PTri)
		Me.pPath.Controls.Add(Me.Label17)
		Me.pPath.Controls.Add(Me.Label18)
		Me.pPath.Controls.Add(Me.CE_P1)
		Me.pPath.Location = New System.Drawing.Point(0, 0)
		Me.pPath.Name = "pPath"
		Me.pPath.Size = New System.Drawing.Size(260, 657)
		Me.pPath.TabIndex = 0
		'
		'B_Surround
		'
		Me.B_Surround.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.B_Surround.ForeColor = System.Drawing.Color.White
		Me.B_Surround.Location = New System.Drawing.Point(69, 37)
		Me.B_Surround.MyText = "Edit Surround Colors"
		Me.B_Surround.Name = "B_Surround"
		Me.B_Surround.Size = New System.Drawing.Size(186, 25)
		Me.B_Surround.TabIndex = 1
		'
		'PFocusY
		'
		Me.PFocusY.BarBorderColor = System.Drawing.Color.White
		Me.PFocusY.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PFocusY.Factors = New Single() {0!, 1.0!}
		Me.PFocusY.Increment = 0.1!
		Me.PFocusY.Location = New System.Drawing.Point(85, 97)
		Me.PFocusY.Maximum = 1.0!
		Me.PFocusY.Name = "PFocusY"
		Me.PFocusY.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PFocusY.Size = New System.Drawing.Size(170, 20)
		Me.PFocusY.TabIndex = 3
		Me.PFocusY.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.Location = New System.Drawing.Point(3, 101)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(76, 13)
		Me.Label27.TabIndex = 15
		Me.Label27.Text = "FocusScale Y:"
		'
		'PFocusX
		'
		Me.PFocusX.BarBorderColor = System.Drawing.Color.White
		Me.PFocusX.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PFocusX.Factors = New Single() {0!, 1.0!}
		Me.PFocusX.Increment = 0.1!
		Me.PFocusX.Location = New System.Drawing.Point(85, 71)
		Me.PFocusX.Maximum = 1.0!
		Me.PFocusX.Name = "PFocusX"
		Me.PFocusX.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PFocusX.Size = New System.Drawing.Size(170, 20)
		Me.PFocusX.TabIndex = 2
		Me.PFocusX.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.Location = New System.Drawing.Point(3, 75)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(76, 13)
		Me.Label28.TabIndex = 16
		Me.Label28.Text = "FocusScale X:"
		'
		'P_BEditor
		'
		Me.P_BEditor.BackColor = System.Drawing.Color.White
		Me.P_BEditor.Color1 = System.Drawing.Color.Black
		Me.P_BEditor.Color2 = System.Drawing.Color.White
		Me.P_BEditor.Factors = New Single() {0!, 1.0!}
		Me.P_BEditor.ForeColor = System.Drawing.Color.Black
		Me.P_BEditor.Location = New System.Drawing.Point(7, 492)
		Me.P_BEditor.MinimumSize = New System.Drawing.Size(250, 160)
		Me.P_BEditor.Name = "P_BEditor"
		Me.P_BEditor.Positions = New Single() {0!, 1.0!}
		Me.P_BEditor.Size = New System.Drawing.Size(250, 160)
		Me.P_BEditor.TabIndex = 13
		'
		'P_CBEditor
		'
		Me.P_CBEditor.BackColor = System.Drawing.Color.White
		Me.P_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))}
		Me.P_CBEditor.ForeColor = System.Drawing.Color.Black
		Me.P_CBEditor.Location = New System.Drawing.Point(7, 303)
		Me.P_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
		Me.P_CBEditor.Name = "P_CBEditor"
		Me.P_CBEditor.Positions = New Single() {0!, 1.0!}
		Me.P_CBEditor.Size = New System.Drawing.Size(250, 160)
		Me.P_CBEditor.TabIndex = 11
		'
		'PBellScale
		'
		Me.PBellScale.BarBorderColor = System.Drawing.Color.White
		Me.PBellScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PBellScale.Factors = New Single() {0!, 1.0!}
		Me.PBellScale.Increment = 0.1!
		Me.PBellScale.Location = New System.Drawing.Point(69, 254)
		Me.PBellScale.Maximum = 1.0!
		Me.PBellScale.Name = "PBellScale"
		Me.PBellScale.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PBellScale.Size = New System.Drawing.Size(186, 20)
		Me.PBellScale.TabIndex = 9
		Me.PBellScale.ThumbBorderColor = System.Drawing.Color.White
		Me.PBellScale.Value = 1.0!
		'
		'PTriScale
		'
		Me.PTriScale.BarBorderColor = System.Drawing.Color.White
		Me.PTriScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PTriScale.Factors = New Single() {0!, 1.0!}
		Me.PTriScale.Increment = 0.1!
		Me.PTriScale.Location = New System.Drawing.Point(69, 179)
		Me.PTriScale.Maximum = 1.0!
		Me.PTriScale.Name = "PTriScale"
		Me.PTriScale.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PTriScale.Size = New System.Drawing.Size(186, 20)
		Me.PTriScale.TabIndex = 6
		Me.PTriScale.ThumbBorderColor = System.Drawing.Color.White
		Me.PTriScale.Value = 1.0!
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(3, 258)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(37, 13)
		Me.Label12.TabIndex = 10
		Me.Label12.Text = "Scale:"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(3, 183)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(37, 13)
		Me.Label13.TabIndex = 10
		Me.Label13.Text = "Scale:"
		'
		'PBellFocus
		'
		Me.PBellFocus.BarBorderColor = System.Drawing.Color.White
		Me.PBellFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PBellFocus.Factors = New Single() {0!, 1.0!}
		Me.PBellFocus.Increment = 0.1!
		Me.PBellFocus.Location = New System.Drawing.Point(69, 228)
		Me.PBellFocus.Maximum = 1.0!
		Me.PBellFocus.Name = "PBellFocus"
		Me.PBellFocus.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PBellFocus.Size = New System.Drawing.Size(186, 20)
		Me.PBellFocus.TabIndex = 8
		Me.PBellFocus.ThumbBorderColor = System.Drawing.Color.White
		Me.PBellFocus.Value = 0.5!
		'
		'PTriFocus
		'
		Me.PTriFocus.BarBorderColor = System.Drawing.Color.White
		Me.PTriFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PTriFocus.Factors = New Single() {0!, 1.0!}
		Me.PTriFocus.Increment = 0.1!
		Me.PTriFocus.Location = New System.Drawing.Point(69, 153)
		Me.PTriFocus.Maximum = 1.0!
		Me.PTriFocus.Name = "PTriFocus"
		Me.PTriFocus.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PTriFocus.Size = New System.Drawing.Size(186, 20)
		Me.PTriFocus.TabIndex = 5
		Me.PTriFocus.ThumbBorderColor = System.Drawing.Color.White
		Me.PTriFocus.Value = 0.5!
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(3, 232)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(39, 13)
		Me.Label14.TabIndex = 10
		Me.Label14.Text = "Focus:"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(3, 157)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(39, 13)
		Me.Label15.TabIndex = 10
		Me.Label15.Text = "Focus:"
		'
		'CB_PBlend
		'
		Me.CB_PBlend.AutoSize = True
		Me.CB_PBlend.Location = New System.Drawing.Point(6, 469)
		Me.CB_PBlend.Name = "CB_PBlend"
		Me.CB_PBlend.Size = New System.Drawing.Size(53, 17)
		Me.CB_PBlend.TabIndex = 12
		Me.CB_PBlend.Text = "Blend"
		Me.CB_PBlend.UseVisualStyleBackColor = True
		'
		'CB_PColorBlend
		'
		Me.CB_PColorBlend.AutoSize = True
		Me.CB_PColorBlend.Location = New System.Drawing.Point(6, 280)
		Me.CB_PColorBlend.Name = "CB_PColorBlend"
		Me.CB_PColorBlend.Size = New System.Drawing.Size(80, 17)
		Me.CB_PColorBlend.TabIndex = 10
		Me.CB_PColorBlend.Text = "Color Blend"
		Me.CB_PColorBlend.UseVisualStyleBackColor = True
		'
		'CB_PBell
		'
		Me.CB_PBell.AutoSize = True
		Me.CB_PBell.Location = New System.Drawing.Point(6, 205)
		Me.CB_PBell.Name = "CB_PBell"
		Me.CB_PBell.Size = New System.Drawing.Size(128, 17)
		Me.CB_PBell.TabIndex = 7
		Me.CB_PBell.Text = "Set Sigma Bell Shape"
		Me.CB_PBell.UseVisualStyleBackColor = True
		'
		'CB_PTri
		'
		Me.CB_PTri.AutoSize = True
		Me.CB_PTri.Location = New System.Drawing.Point(6, 130)
		Me.CB_PTri.Name = "CB_PTri"
		Me.CB_PTri.Size = New System.Drawing.Size(156, 17)
		Me.CB_PTri.TabIndex = 4
		Me.CB_PTri.Text = "Set Blend Triangular Shape"
		Me.CB_PTri.UseVisualStyleBackColor = True
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Location = New System.Drawing.Point(4, 43)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(53, 13)
		Me.Label17.TabIndex = 10
		Me.Label17.Text = "Surround:"
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(4, 12)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(41, 13)
		Me.Label18.TabIndex = 10
		Me.Label18.Text = "Center:"
		'
		'CE_P1
		'
		Me.CE_P1.BackColor = System.Drawing.SystemColors.Control
		Me.CE_P1.Location = New System.Drawing.Point(69, 6)
		Me.CE_P1.MyText = "ChooseColor"
		Me.CE_P1.Name = "CE_P1"
		Me.CE_P1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_P1.Size = New System.Drawing.Size(186, 25)
		Me.CE_P1.TabIndex = 0
		'
		'pHatch
		'
		Me.pHatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
		Me.pHatch.Controls.Add(Me.cb_HatchStyle)
		Me.pHatch.Controls.Add(Me.Label23)
		Me.pHatch.Controls.Add(Me.Label24)
		Me.pHatch.Controls.Add(Me.CE_H2)
		Me.pHatch.Controls.Add(Me.CE_H1)
		Me.pHatch.Controls.Add(Me.Label16)
		Me.pHatch.ForeColor = System.Drawing.Color.White
		Me.pHatch.Location = New System.Drawing.Point(0, 0)
		Me.pHatch.Name = "pHatch"
		Me.pHatch.Size = New System.Drawing.Size(260, 103)
		Me.pHatch.TabIndex = 0
		'
		'cb_HatchStyle
		'
		Me.cb_HatchStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_HatchStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_HatchStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cb_HatchStyle.DropDownHeight = 250
		Me.cb_HatchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_HatchStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_HatchStyle.IntegralHeight = False
		Me.cb_HatchStyle.ItemHeight = 20
		Me.cb_HatchStyle.Location = New System.Drawing.Point(69, 68)
		Me.cb_HatchStyle.MaxDropDownItems = 14
		Me.cb_HatchStyle.Name = "cb_HatchStyle"
		Me.cb_HatchStyle.Size = New System.Drawing.Size(186, 26)
		Me.cb_HatchStyle.TabIndex = 2
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Location = New System.Drawing.Point(4, 43)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(59, 13)
		Me.Label23.TabIndex = 10
		Me.Label23.Text = "BackColor:"
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.Location = New System.Drawing.Point(4, 12)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(55, 13)
		Me.Label24.TabIndex = 10
		Me.Label24.Text = "ForeColor:"
		'
		'CE_H2
		'
		Me.CE_H2.BackColor = System.Drawing.SystemColors.Control
		Me.CE_H2.Location = New System.Drawing.Point(69, 37)
		Me.CE_H2.MyText = "ChooseColor"
		Me.CE_H2.Name = "CE_H2"
		Me.CE_H2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_H2.Size = New System.Drawing.Size(186, 25)
		Me.CE_H2.TabIndex = 1
		'
		'CE_H1
		'
		Me.CE_H1.BackColor = System.Drawing.SystemColors.Control
		Me.CE_H1.Location = New System.Drawing.Point(69, 6)
		Me.CE_H1.MyText = "ChooseColor"
		Me.CE_H1.Name = "CE_H1"
		Me.CE_H1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.CE_H1.Size = New System.Drawing.Size(186, 25)
		Me.CE_H1.TabIndex = 0
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(4, 74)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(65, 13)
		Me.Label16.TabIndex = 10
		Me.Label16.Text = "Hatch Style:"
		'
		'pTexture
		'
		Me.pTexture.Controls.Add(Me.cb_RotateFlip)
		Me.pTexture.Controls.Add(Me.Label26)
		Me.pTexture.Controls.Add(Me.B_TImage)
		Me.pTexture.Controls.Add(Me.B_TClip)
		Me.pTexture.Controls.Add(Me.Label20)
		Me.pTexture.Controls.Add(Me.PB_Texture)
		Me.pTexture.Controls.Add(Me.CB_Trans)
		Me.pTexture.Controls.Add(Me.Label21)
		Me.pTexture.Controls.Add(Me.CE_Trans)
		Me.pTexture.Location = New System.Drawing.Point(0, 0)
		Me.pTexture.Name = "pTexture"
		Me.pTexture.Size = New System.Drawing.Size(260, 385)
		Me.pTexture.TabIndex = 0
		'
		'cb_RotateFlip
		'
		Me.cb_RotateFlip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_RotateFlip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_RotateFlip.DropDownHeight = 250
		Me.cb_RotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_RotateFlip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_RotateFlip.IntegralHeight = False
		Me.cb_RotateFlip.ItemHeight = 17
		Me.cb_RotateFlip.Location = New System.Drawing.Point(71, 353)
		Me.cb_RotateFlip.MaxDropDownItems = 14
		Me.cb_RotateFlip.Name = "cb_RotateFlip"
		Me.cb_RotateFlip.Size = New System.Drawing.Size(185, 25)
		Me.cb_RotateFlip.TabIndex = 4
		'
		'Label26
		'
		Me.Label26.AutoSize = True
		Me.Label26.Location = New System.Drawing.Point(5, 359)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(58, 13)
		Me.Label26.TabIndex = 15
		Me.Label26.Text = "RotateFlip:"
		'
		'B_TImage
		'
		Me.B_TImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.B_TImage.ForeColor = System.Drawing.Color.White
		Me.B_TImage.Location = New System.Drawing.Point(132, 258)
		Me.B_TImage.MyText = "Choose File"
		Me.B_TImage.Name = "B_TImage"
		Me.B_TImage.Size = New System.Drawing.Size(123, 30)
		Me.B_TImage.TabIndex = 1
		'
		'B_TClip
		'
		Me.B_TClip.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.B_TClip.ForeColor = System.Drawing.Color.White
		Me.B_TClip.Location = New System.Drawing.Point(6, 258)
		Me.B_TClip.MyText = "From Clipboard"
		Me.B_TClip.Name = "B_TClip"
		Me.B_TClip.Size = New System.Drawing.Size(123, 30)
		Me.B_TClip.TabIndex = 0
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.Location = New System.Drawing.Point(5, 6)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(39, 13)
		Me.Label20.TabIndex = 13
		Me.Label20.Text = "Image:"
		'
		'PB_Texture
		'
		Me.PB_Texture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PB_Texture.Location = New System.Drawing.Point(6, 22)
		Me.PB_Texture.Name = "PB_Texture"
		Me.PB_Texture.Size = New System.Drawing.Size(249, 230)
		Me.PB_Texture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PB_Texture.TabIndex = 12
		Me.PB_Texture.TabStop = False
		'
		'CB_Trans
		'
		Me.CB_Trans.AutoSize = True
		Me.CB_Trans.Location = New System.Drawing.Point(7, 298)
		Me.CB_Trans.Name = "CB_Trans"
		Me.CB_Trans.Size = New System.Drawing.Size(91, 17)
		Me.CB_Trans.TabIndex = 2
		Me.CB_Trans.Text = "Transparency"
		Me.CB_Trans.UseVisualStyleBackColor = True
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Location = New System.Drawing.Point(5, 324)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(34, 13)
		Me.Label21.TabIndex = 10
		Me.Label21.Text = "Color:"
		'
		'CE_Trans
		'
		Me.CE_Trans.BackColor = System.Drawing.SystemColors.Control
		Me.CE_Trans.Location = New System.Drawing.Point(71, 318)
		Me.CE_Trans.MyText = "ChooseColor"
		Me.CE_Trans.Name = "CE_Trans"
		Me.CE_Trans.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_Trans.Size = New System.Drawing.Size(185, 25)
		Me.CE_Trans.TabIndex = 3
		'
		'pStroke
		'
		Me.pStroke.Controls.Add(Me.TB_PSY)
		Me.pStroke.Controls.Add(Me.Label44)
		Me.pStroke.Controls.Add(Me.TB_PSX)
		Me.pStroke.Controls.Add(Me.Label43)
		Me.pStroke.Controls.Add(Me.Label42)
		Me.pStroke.Controls.Add(Me.CB_LJoin)
		Me.pStroke.Controls.Add(Me.Label41)
		Me.pStroke.Controls.Add(Me.CB_ECap)
		Me.pStroke.Controls.Add(Me.Label40)
		Me.pStroke.Controls.Add(Me.CB_SCap)
		Me.pStroke.Controls.Add(Me.Label39)
		Me.pStroke.Controls.Add(Me.CB_DCap)
		Me.pStroke.Controls.Add(Me.Label36)
		Me.pStroke.Controls.Add(Me.CB_DStyle)
		Me.pStroke.Controls.Add(Me.Label35)
		Me.pStroke.Controls.Add(Me.TB_PAngle)
		Me.pStroke.Controls.Add(Me.Label34)
		Me.pStroke.Controls.Add(Me.CB_PGamma)
		Me.pStroke.Controls.Add(Me.PWidth)
		Me.pStroke.Controls.Add(Me.Label33)
		Me.pStroke.Controls.Add(Me.cb_PHatchStyle)
		Me.pStroke.Controls.Add(Me.Label30)
		Me.pStroke.Controls.Add(Me.Label31)
		Me.pStroke.Controls.Add(Me.CE_PBack)
		Me.pStroke.Controls.Add(Me.CE_PFore)
		Me.pStroke.Controls.Add(Me.Label32)
		Me.pStroke.Controls.Add(Me.rbpHatch)
		Me.pStroke.Controls.Add(Me.rbpLinear)
		Me.pStroke.Controls.Add(Me.rbpSolid)
		Me.pStroke.Controls.Add(Me.LP_CBEditor)
		Me.pStroke.Controls.Add(Me.Label37)
		Me.pStroke.Controls.Add(Me.CE_PSolid)
		Me.pStroke.Controls.Add(Me.Label38)
		Me.pStroke.Location = New System.Drawing.Point(0, 0)
		Me.pStroke.Name = "pStroke"
		Me.pStroke.Size = New System.Drawing.Size(260, 696)
		Me.pStroke.TabIndex = 0
		'
		'TB_PSY
		'
		Me.TB_PSY.BarBorderColor = System.Drawing.Color.White
		Me.TB_PSY.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_PSY.Factors = New Single() {0!, 1.0!}
		Me.TB_PSY.Increment = 0.1!
		Me.TB_PSY.Location = New System.Drawing.Point(67, 668)
		Me.TB_PSY.Maximum = 2.0!
		Me.TB_PSY.Minimum = 0.1!
		Me.TB_PSY.Name = "TB_PSY"
		Me.TB_PSY.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_PSY.Size = New System.Drawing.Size(186, 20)
		Me.TB_PSY.TabIndex = 17
		Me.TB_PSY.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_PSY.Value = 1.0!
		'
		'Label44
		'
		Me.Label44.AutoSize = True
		Me.Label44.Location = New System.Drawing.Point(2, 672)
		Me.Label44.Name = "Label44"
		Me.Label44.Size = New System.Drawing.Size(47, 13)
		Me.Label44.TabIndex = 29
		Me.Label44.Text = "Scale Y:"
		'
		'TB_PSX
		'
		Me.TB_PSX.BarBorderColor = System.Drawing.Color.White
		Me.TB_PSX.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_PSX.Factors = New Single() {0!, 1.0!}
		Me.TB_PSX.Increment = 0.1!
		Me.TB_PSX.Location = New System.Drawing.Point(67, 643)
		Me.TB_PSX.Maximum = 2.0!
		Me.TB_PSX.Minimum = 0.1!
		Me.TB_PSX.Name = "TB_PSX"
		Me.TB_PSX.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_PSX.Size = New System.Drawing.Size(186, 20)
		Me.TB_PSX.TabIndex = 16
		Me.TB_PSX.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_PSX.Value = 1.0!
		'
		'Label43
		'
		Me.Label43.AutoSize = True
		Me.Label43.Location = New System.Drawing.Point(2, 647)
		Me.Label43.Name = "Label43"
		Me.Label43.Size = New System.Drawing.Size(47, 13)
		Me.Label43.TabIndex = 29
		Me.Label43.Text = "Scale X:"
		'
		'Label42
		'
		Me.Label42.BackColor = System.Drawing.Color.Transparent
		Me.Label42.Font = New System.Drawing.Font("Consolas", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label42.ForeColor = System.Drawing.Color.White
		Me.Label42.Location = New System.Drawing.Point(0, 426)
		Me.Label42.Name = "Label42"
		Me.Label42.Size = New System.Drawing.Size(260, 29)
		Me.Label42.TabIndex = 28
		Me.Label42.Text = "Style"
		Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'CB_LJoin
		'
		Me.CB_LJoin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.CB_LJoin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CB_LJoin.DropDownHeight = 250
		Me.CB_LJoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_LJoin.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_LJoin.IntegralHeight = False
		Me.CB_LJoin.ItemHeight = 17
		Me.CB_LJoin.Location = New System.Drawing.Point(67, 612)
		Me.CB_LJoin.MaxDropDownItems = 14
		Me.CB_LJoin.Name = "CB_LJoin"
		Me.CB_LJoin.Size = New System.Drawing.Size(186, 25)
		Me.CB_LJoin.TabIndex = 15
		'
		'Label41
		'
		Me.Label41.AutoSize = True
		Me.Label41.Location = New System.Drawing.Point(2, 618)
		Me.Label41.Name = "Label41"
		Me.Label41.Size = New System.Drawing.Size(52, 13)
		Me.Label41.TabIndex = 26
		Me.Label41.Text = "Line Join:"
		'
		'CB_ECap
		'
		Me.CB_ECap.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.CB_ECap.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CB_ECap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.CB_ECap.DropDownHeight = 250
		Me.CB_ECap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_ECap.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_ECap.IntegralHeight = False
		Me.CB_ECap.ItemHeight = 20
		Me.CB_ECap.Location = New System.Drawing.Point(67, 580)
		Me.CB_ECap.MaxDropDownItems = 14
		Me.CB_ECap.Name = "CB_ECap"
		Me.CB_ECap.Size = New System.Drawing.Size(186, 26)
		Me.CB_ECap.TabIndex = 14
		'
		'Label40
		'
		Me.Label40.AutoSize = True
		Me.Label40.Location = New System.Drawing.Point(2, 586)
		Me.Label40.Name = "Label40"
		Me.Label40.Size = New System.Drawing.Size(51, 13)
		Me.Label40.TabIndex = 26
		Me.Label40.Text = "End Cap:"
		'
		'CB_SCap
		'
		Me.CB_SCap.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.CB_SCap.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CB_SCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.CB_SCap.DropDownHeight = 250
		Me.CB_SCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_SCap.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_SCap.IntegralHeight = False
		Me.CB_SCap.ItemHeight = 20
		Me.CB_SCap.Location = New System.Drawing.Point(67, 548)
		Me.CB_SCap.MaxDropDownItems = 14
		Me.CB_SCap.Name = "CB_SCap"
		Me.CB_SCap.Size = New System.Drawing.Size(186, 26)
		Me.CB_SCap.TabIndex = 13
		'
		'Label39
		'
		Me.Label39.AutoSize = True
		Me.Label39.Location = New System.Drawing.Point(2, 554)
		Me.Label39.Name = "Label39"
		Me.Label39.Size = New System.Drawing.Size(54, 13)
		Me.Label39.TabIndex = 26
		Me.Label39.Text = "Start Cap:"
		'
		'CB_DCap
		'
		Me.CB_DCap.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.CB_DCap.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CB_DCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.CB_DCap.DropDownHeight = 250
		Me.CB_DCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_DCap.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_DCap.IntegralHeight = False
		Me.CB_DCap.ItemHeight = 20
		Me.CB_DCap.Location = New System.Drawing.Point(67, 516)
		Me.CB_DCap.MaxDropDownItems = 14
		Me.CB_DCap.Name = "CB_DCap"
		Me.CB_DCap.Size = New System.Drawing.Size(186, 26)
		Me.CB_DCap.TabIndex = 12
		'
		'Label36
		'
		Me.Label36.AutoSize = True
		Me.Label36.Location = New System.Drawing.Point(2, 522)
		Me.Label36.Name = "Label36"
		Me.Label36.Size = New System.Drawing.Size(57, 13)
		Me.Label36.TabIndex = 26
		Me.Label36.Text = "Dash Cap:"
		'
		'CB_DStyle
		'
		Me.CB_DStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.CB_DStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CB_DStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.CB_DStyle.DropDownHeight = 250
		Me.CB_DStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CB_DStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CB_DStyle.IntegralHeight = False
		Me.CB_DStyle.ItemHeight = 20
		Me.CB_DStyle.Location = New System.Drawing.Point(67, 484)
		Me.CB_DStyle.MaxDropDownItems = 14
		Me.CB_DStyle.Name = "CB_DStyle"
		Me.CB_DStyle.Size = New System.Drawing.Size(186, 26)
		Me.CB_DStyle.TabIndex = 11
		'
		'Label35
		'
		Me.Label35.AutoSize = True
		Me.Label35.Location = New System.Drawing.Point(2, 490)
		Me.Label35.Name = "Label35"
		Me.Label35.Size = New System.Drawing.Size(61, 13)
		Me.Label35.TabIndex = 26
		Me.Label35.Text = "Dash Style:"
		'
		'TB_PAngle
		'
		Me.TB_PAngle.AllowDecimal = False
		Me.TB_PAngle.BarBorderColor = System.Drawing.Color.White
		Me.TB_PAngle.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_PAngle.Factors = New Single() {0!, 1.0!}
		Me.TB_PAngle.Location = New System.Drawing.Point(67, 295)
		Me.TB_PAngle.Maximum = 360.0!
		Me.TB_PAngle.Name = "TB_PAngle"
		Me.TB_PAngle.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_PAngle.Size = New System.Drawing.Size(186, 20)
		Me.TB_PAngle.TabIndex = 5
		Me.TB_PAngle.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.Location = New System.Drawing.Point(2, 299)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(37, 13)
		Me.Label34.TabIndex = 23
		Me.Label34.Text = "Angle:"
		'
		'CB_PGamma
		'
		Me.CB_PGamma.AutoSize = True
		Me.CB_PGamma.Location = New System.Drawing.Point(4, 275)
		Me.CB_PGamma.Name = "CB_PGamma"
		Me.CB_PGamma.Size = New System.Drawing.Size(113, 17)
		Me.CB_PGamma.TabIndex = 4
		Me.CB_PGamma.Text = "Gamma Correction"
		Me.CB_PGamma.UseVisualStyleBackColor = True
		'
		'PWidth
		'
		Me.PWidth.BarBorderColor = System.Drawing.Color.White
		Me.PWidth.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.PWidth.Factors = New Single() {0!, 1.0!}
		Me.PWidth.Location = New System.Drawing.Point(47, 458)
		Me.PWidth.Maximum = 50.0!
		Me.PWidth.Name = "PWidth"
		Me.PWidth.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.PWidth.Size = New System.Drawing.Size(208, 20)
		Me.PWidth.TabIndex = 10
		Me.PWidth.ThumbBorderColor = System.Drawing.Color.White
		Me.PWidth.Value = 1.0!
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.Location = New System.Drawing.Point(3, 462)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(38, 13)
		Me.Label33.TabIndex = 21
		Me.Label33.Text = "Width:"
		'
		'cb_PHatchStyle
		'
		Me.cb_PHatchStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_PHatchStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_PHatchStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.cb_PHatchStyle.DropDownHeight = 250
		Me.cb_PHatchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_PHatchStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_PHatchStyle.IntegralHeight = False
		Me.cb_PHatchStyle.ItemHeight = 20
		Me.cb_PHatchStyle.Location = New System.Drawing.Point(67, 397)
		Me.cb_PHatchStyle.MaxDropDownItems = 14
		Me.cb_PHatchStyle.Name = "cb_PHatchStyle"
		Me.cb_PHatchStyle.Size = New System.Drawing.Size(186, 26)
		Me.cb_PHatchStyle.TabIndex = 9
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.Location = New System.Drawing.Point(2, 372)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(59, 13)
		Me.Label30.TabIndex = 17
		Me.Label30.Text = "BackColor:"
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.Location = New System.Drawing.Point(2, 341)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(55, 13)
		Me.Label31.TabIndex = 18
		Me.Label31.Text = "ForeColor:"
		'
		'CE_PBack
		'
		Me.CE_PBack.BackColor = System.Drawing.SystemColors.Control
		Me.CE_PBack.Location = New System.Drawing.Point(67, 366)
		Me.CE_PBack.MyText = "ChooseColor"
		Me.CE_PBack.Name = "CE_PBack"
		Me.CE_PBack.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_PBack.Size = New System.Drawing.Size(186, 25)
		Me.CE_PBack.TabIndex = 8
		'
		'CE_PFore
		'
		Me.CE_PFore.BackColor = System.Drawing.SystemColors.Control
		Me.CE_PFore.Location = New System.Drawing.Point(67, 335)
		Me.CE_PFore.MyText = "ChooseColor"
		Me.CE_PFore.Name = "CE_PFore"
		Me.CE_PFore.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.CE_PFore.Size = New System.Drawing.Size(186, 25)
		Me.CE_PFore.TabIndex = 7
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.Location = New System.Drawing.Point(2, 403)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(65, 13)
		Me.Label32.TabIndex = 19
		Me.Label32.Text = "Hatch Style:"
		'
		'rbpHatch
		'
		Me.rbpHatch.AutoSize = True
		Me.rbpHatch.Location = New System.Drawing.Point(5, 318)
		Me.rbpHatch.Name = "rbpHatch"
		Me.rbpHatch.Size = New System.Drawing.Size(54, 17)
		Me.rbpHatch.TabIndex = 6
		Me.rbpHatch.Text = "Hatch"
		Me.rbpHatch.UseVisualStyleBackColor = True
		'
		'rbpLinear
		'
		Me.rbpLinear.AutoSize = True
		Me.rbpLinear.Location = New System.Drawing.Point(4, 86)
		Me.rbpLinear.Name = "rbpLinear"
		Me.rbpLinear.Size = New System.Drawing.Size(94, 17)
		Me.rbpLinear.TabIndex = 2
		Me.rbpLinear.Text = "LinearGradient"
		Me.rbpLinear.UseVisualStyleBackColor = True
		'
		'rbpSolid
		'
		Me.rbpSolid.AutoSize = True
		Me.rbpSolid.Checked = True
		Me.rbpSolid.Location = New System.Drawing.Point(5, 32)
		Me.rbpSolid.Name = "rbpSolid"
		Me.rbpSolid.Size = New System.Drawing.Size(48, 17)
		Me.rbpSolid.TabIndex = 0
		Me.rbpSolid.TabStop = True
		Me.rbpSolid.Text = "Solid"
		Me.rbpSolid.UseVisualStyleBackColor = True
		'
		'LP_CBEditor
		'
		Me.LP_CBEditor.BackColor = System.Drawing.Color.White
		Me.LP_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.Black}
		Me.LP_CBEditor.ForeColor = System.Drawing.Color.Black
		Me.LP_CBEditor.Location = New System.Drawing.Point(2, 109)
		Me.LP_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
		Me.LP_CBEditor.Name = "LP_CBEditor"
		Me.LP_CBEditor.Positions = New Single() {0!, 1.0!}
		Me.LP_CBEditor.Size = New System.Drawing.Size(250, 160)
		Me.LP_CBEditor.TabIndex = 3
		'
		'Label37
		'
		Me.Label37.AutoSize = True
		Me.Label37.Location = New System.Drawing.Point(2, 61)
		Me.Label37.Name = "Label37"
		Me.Label37.Size = New System.Drawing.Size(60, 13)
		Me.Label37.TabIndex = 10
		Me.Label37.Text = "Solid Color:"
		'
		'CE_PSolid
		'
		Me.CE_PSolid.BackColor = System.Drawing.SystemColors.Control
		Me.CE_PSolid.Location = New System.Drawing.Point(67, 55)
		Me.CE_PSolid.MyText = "ChooseColor"
		Me.CE_PSolid.Name = "CE_PSolid"
		Me.CE_PSolid.SelectedColor = System.Drawing.Color.Black
		Me.CE_PSolid.Size = New System.Drawing.Size(186, 25)
		Me.CE_PSolid.TabIndex = 1
		'
		'Label38
		'
		Me.Label38.BackColor = System.Drawing.Color.Transparent
		Me.Label38.Font = New System.Drawing.Font("Consolas", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label38.ForeColor = System.Drawing.Color.White
		Me.Label38.Location = New System.Drawing.Point(0, 5)
		Me.Label38.Name = "Label38"
		Me.Label38.Size = New System.Drawing.Size(260, 29)
		Me.Label38.TabIndex = 0
		Me.Label38.Text = "Fill"
		Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'pGlow
		'
		Me.pGlow.Controls.Add(Me.cb_EGlow)
		Me.pGlow.Controls.Add(Me.TB_Feather)
		Me.pGlow.Controls.Add(Me.Label54)
		Me.pGlow.Controls.Add(Me.TB_Glow)
		Me.pGlow.Controls.Add(Me.Label53)
		Me.pGlow.Controls.Add(Me.cb_gfill)
		Me.pGlow.Controls.Add(Me.cb_GClip)
		Me.pGlow.Controls.Add(Me.Label2)
		Me.pGlow.Controls.Add(Me.cb_GStyle)
		Me.pGlow.Controls.Add(Me.Label52)
		Me.pGlow.Controls.Add(Me.Label50)
		Me.pGlow.Controls.Add(Me.CE_Glow)
		Me.pGlow.Location = New System.Drawing.Point(0, 0)
		Me.pGlow.Name = "pGlow"
		Me.pGlow.Size = New System.Drawing.Size(260, 199)
		Me.pGlow.TabIndex = 0
		'
		'cb_EGlow
		'
		Me.cb_EGlow.AutoSize = True
		Me.cb_EGlow.Location = New System.Drawing.Point(9, 6)
		Me.cb_EGlow.Name = "cb_EGlow"
		Me.cb_EGlow.Size = New System.Drawing.Size(78, 17)
		Me.cb_EGlow.TabIndex = 0
		Me.cb_EGlow.Text = "Draw Glow"
		Me.cb_EGlow.UseVisualStyleBackColor = True
		'
		'TB_Feather
		'
		Me.TB_Feather.AllowDecimal = False
		Me.TB_Feather.BarBorderColor = System.Drawing.Color.White
		Me.TB_Feather.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_Feather.Factors = New Single() {0!, 1.0!}
		Me.TB_Feather.Location = New System.Drawing.Point(56, 118)
		Me.TB_Feather.Minimum = 10.0!
		Me.TB_Feather.Name = "TB_Feather"
		Me.TB_Feather.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_Feather.Size = New System.Drawing.Size(200, 20)
		Me.TB_Feather.TabIndex = 4
		Me.TB_Feather.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_Feather.Value = 35.0!
		'
		'Label54
		'
		Me.Label54.AutoSize = True
		Me.Label54.Location = New System.Drawing.Point(4, 122)
		Me.Label54.Name = "Label54"
		Me.Label54.Size = New System.Drawing.Size(46, 13)
		Me.Label54.TabIndex = 14
		Me.Label54.Text = "Feather:"
		'
		'TB_Glow
		'
		Me.TB_Glow.AllowDecimal = False
		Me.TB_Glow.BarBorderColor = System.Drawing.Color.White
		Me.TB_Glow.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_Glow.Factors = New Single() {0!, 1.0!}
		Me.TB_Glow.Location = New System.Drawing.Point(56, 92)
		Me.TB_Glow.Minimum = 10.0!
		Me.TB_Glow.Name = "TB_Glow"
		Me.TB_Glow.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_Glow.Size = New System.Drawing.Size(200, 20)
		Me.TB_Glow.TabIndex = 3
		Me.TB_Glow.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_Glow.Value = 35.0!
		'
		'Label53
		'
		Me.Label53.AutoSize = True
		Me.Label53.Location = New System.Drawing.Point(4, 96)
		Me.Label53.Name = "Label53"
		Me.Label53.Size = New System.Drawing.Size(34, 13)
		Me.Label53.TabIndex = 14
		Me.Label53.Text = "Glow:"
		'
		'cb_gfill
		'
		Me.cb_gfill.AutoSize = True
		Me.cb_gfill.Checked = True
		Me.cb_gfill.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cb_gfill.Location = New System.Drawing.Point(9, 144)
		Me.cb_gfill.Name = "cb_gfill"
		Me.cb_gfill.Size = New System.Drawing.Size(72, 17)
		Me.cb_gfill.TabIndex = 5
		Me.cb_gfill.Text = "Before Fill"
		Me.cb_gfill.UseVisualStyleBackColor = True
		'
		'cb_GClip
		'
		Me.cb_GClip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_GClip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_GClip.DropDownHeight = 250
		Me.cb_GClip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_GClip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_GClip.IntegralHeight = False
		Me.cb_GClip.ItemHeight = 17
		Me.cb_GClip.Location = New System.Drawing.Point(70, 167)
		Me.cb_GClip.MaxDropDownItems = 14
		Me.cb_GClip.Name = "cb_GClip"
		Me.cb_GClip.Size = New System.Drawing.Size(186, 25)
		Me.cb_GClip.TabIndex = 6
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(4, 173)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(47, 13)
		Me.Label2.TabIndex = 12
		Me.Label2.Text = "Clipping:"
		'
		'cb_GStyle
		'
		Me.cb_GStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
		Me.cb_GStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cb_GStyle.DropDownHeight = 250
		Me.cb_GStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_GStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cb_GStyle.IntegralHeight = False
		Me.cb_GStyle.ItemHeight = 17
		Me.cb_GStyle.Location = New System.Drawing.Point(70, 60)
		Me.cb_GStyle.MaxDropDownItems = 14
		Me.cb_GStyle.Name = "cb_GStyle"
		Me.cb_GStyle.Size = New System.Drawing.Size(186, 25)
		Me.cb_GStyle.TabIndex = 2
		'
		'Label52
		'
		Me.Label52.AutoSize = True
		Me.Label52.Location = New System.Drawing.Point(4, 66)
		Me.Label52.Name = "Label52"
		Me.Label52.Size = New System.Drawing.Size(60, 13)
		Me.Label52.TabIndex = 12
		Me.Label52.Text = "Glow Style:"
		'
		'Label50
		'
		Me.Label50.AutoSize = True
		Me.Label50.Location = New System.Drawing.Point(4, 35)
		Me.Label50.Name = "Label50"
		Me.Label50.Size = New System.Drawing.Size(61, 13)
		Me.Label50.TabIndex = 8
		Me.Label50.Text = "Glow Color:"
		'
		'CE_Glow
		'
		Me.CE_Glow.BackColor = System.Drawing.SystemColors.Control
		Me.CE_Glow.Location = New System.Drawing.Point(70, 29)
		Me.CE_Glow.MyText = "ChooseColor"
		Me.CE_Glow.Name = "CE_Glow"
		Me.CE_Glow.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.CE_Glow.Size = New System.Drawing.Size(186, 25)
		Me.CE_Glow.TabIndex = 1
		'
		'pShadow
		'
		Me.pShadow.Controls.Add(Me.PS_Shadow)
		Me.pShadow.Controls.Add(Me.TB_SFeather)
		Me.pShadow.Controls.Add(Me.Label55)
		Me.pShadow.Controls.Add(Me.TB_SBlur)
		Me.pShadow.Controls.Add(Me.Label57)
		Me.pShadow.Controls.Add(Me.Label56)
		Me.pShadow.Controls.Add(Me.cb_EShadow)
		Me.pShadow.Controls.Add(Me.cb_clip)
		Me.pShadow.Controls.Add(Me.cb_fill)
		Me.pShadow.Controls.Add(Me.Label58)
		Me.pShadow.Controls.Add(Me.CE_Shadow)
		Me.pShadow.Location = New System.Drawing.Point(0, 0)
		Me.pShadow.Name = "pShadow"
		Me.pShadow.Size = New System.Drawing.Size(260, 427)
		Me.pShadow.TabIndex = 0
		'
		'PS_Shadow
		'
		Me.PS_Shadow.BackColor = System.Drawing.Color.Transparent
		Me.PS_Shadow.BackRectColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
		Me.PS_Shadow.BordersColor = System.Drawing.Color.White
		Me.PS_Shadow.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PS_Shadow.Location = New System.Drawing.Point(6, 174)
		Me.PS_Shadow.Maximum = New System.Drawing.Point(50, 50)
		Me.PS_Shadow.Minimum = New System.Drawing.Point(-50, -50)
		Me.PS_Shadow.Name = "PS_Shadow"
		Me.PS_Shadow.Size = New System.Drawing.Size(249, 249)
		Me.PS_Shadow.TabIndex = 6
		Me.PS_Shadow.ThumbColor = System.Drawing.Color.Black
		Me.PS_Shadow.Value = New System.Drawing.Point(10, 10)
		'
		'TB_SFeather
		'
		Me.TB_SFeather.AllowDecimal = False
		Me.TB_SFeather.BarBorderColor = System.Drawing.Color.White
		Me.TB_SFeather.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_SFeather.Factors = New Single() {0!, 1.0!}
		Me.TB_SFeather.Location = New System.Drawing.Point(58, 86)
		Me.TB_SFeather.Minimum = 10.0!
		Me.TB_SFeather.Name = "TB_SFeather"
		Me.TB_SFeather.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_SFeather.Size = New System.Drawing.Size(197, 20)
		Me.TB_SFeather.TabIndex = 3
		Me.TB_SFeather.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_SFeather.Value = 100.0!
		'
		'Label55
		'
		Me.Label55.AutoSize = True
		Me.Label55.Location = New System.Drawing.Point(4, 86)
		Me.Label55.Name = "Label55"
		Me.Label55.Size = New System.Drawing.Size(46, 13)
		Me.Label55.TabIndex = 14
		Me.Label55.Text = "Feather:"
		'
		'TB_SBlur
		'
		Me.TB_SBlur.AllowDecimal = False
		Me.TB_SBlur.BarBorderColor = System.Drawing.Color.White
		Me.TB_SBlur.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TB_SBlur.Factors = New Single() {0!, 1.0!}
		Me.TB_SBlur.Location = New System.Drawing.Point(58, 60)
		Me.TB_SBlur.Maximum = 10.0!
		Me.TB_SBlur.Name = "TB_SBlur"
		Me.TB_SBlur.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TB_SBlur.Size = New System.Drawing.Size(197, 20)
		Me.TB_SBlur.TabIndex = 2
		Me.TB_SBlur.ThumbBorderColor = System.Drawing.Color.White
		Me.TB_SBlur.Value = 2.0!
		'
		'Label57
		'
		Me.Label57.AutoSize = True
		Me.Label57.Location = New System.Drawing.Point(9, 158)
		Me.Label57.Name = "Label57"
		Me.Label57.Size = New System.Drawing.Size(38, 13)
		Me.Label57.TabIndex = 14
		Me.Label57.Text = "Offset:"
		'
		'Label56
		'
		Me.Label56.AutoSize = True
		Me.Label56.Location = New System.Drawing.Point(4, 60)
		Me.Label56.Name = "Label56"
		Me.Label56.Size = New System.Drawing.Size(28, 13)
		Me.Label56.TabIndex = 14
		Me.Label56.Text = "Blur:"
		'
		'cb_EShadow
		'
		Me.cb_EShadow.AutoSize = True
		Me.cb_EShadow.Location = New System.Drawing.Point(9, 6)
		Me.cb_EShadow.Name = "cb_EShadow"
		Me.cb_EShadow.Size = New System.Drawing.Size(93, 17)
		Me.cb_EShadow.TabIndex = 0
		Me.cb_EShadow.Text = "Draw Shadow"
		Me.cb_EShadow.UseVisualStyleBackColor = True
		'
		'cb_clip
		'
		Me.cb_clip.AutoSize = True
		Me.cb_clip.Checked = True
		Me.cb_clip.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cb_clip.Location = New System.Drawing.Point(9, 135)
		Me.cb_clip.Name = "cb_clip"
		Me.cb_clip.Size = New System.Drawing.Size(100, 17)
		Me.cb_clip.TabIndex = 5
		Me.cb_clip.Text = "Region Clipping"
		Me.cb_clip.UseVisualStyleBackColor = True
		'
		'cb_fill
		'
		Me.cb_fill.AutoSize = True
		Me.cb_fill.Checked = True
		Me.cb_fill.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cb_fill.Location = New System.Drawing.Point(9, 112)
		Me.cb_fill.Name = "cb_fill"
		Me.cb_fill.Size = New System.Drawing.Size(38, 17)
		Me.cb_fill.TabIndex = 4
		Me.cb_fill.Text = "Fill"
		Me.cb_fill.UseVisualStyleBackColor = True
		'
		'Label58
		'
		Me.Label58.AutoSize = True
		Me.Label58.Location = New System.Drawing.Point(4, 35)
		Me.Label58.Name = "Label58"
		Me.Label58.Size = New System.Drawing.Size(76, 13)
		Me.Label58.TabIndex = 8
		Me.Label58.Text = "Shadow Color:"
		'
		'CE_Shadow
		'
		Me.CE_Shadow.BackColor = System.Drawing.SystemColors.Control
		Me.CE_Shadow.Location = New System.Drawing.Point(86, 29)
		Me.CE_Shadow.MyText = "ChooseColor"
		Me.CE_Shadow.Name = "CE_Shadow"
		Me.CE_Shadow.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.CE_Shadow.Size = New System.Drawing.Size(170, 25)
		Me.CE_Shadow.TabIndex = 1
		'
		'pCanvas
		'
		Me.pCanvas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pCanvas.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
		Me.pCanvas.Controls.Add(Me.tCanvas)
		Me.pCanvas.ForeColor = System.Drawing.Color.Black
		Me.pCanvas.Location = New System.Drawing.Point(45, 45)
		Me.pCanvas.Name = "pCanvas"
		Me.pCanvas.Size = New System.Drawing.Size(1042, 615)
		Me.pCanvas.TabIndex = 6
		'
		'tCanvas
		'
		Me.tCanvas.AllowDrop = True
		Me.tCanvas.Controls.Add(Me.TabPage1)
		Me.tCanvas.Dock = System.Windows.Forms.DockStyle.Fill
		Me.tCanvas.ItemSize = New System.Drawing.Size(100, 24)
		Me.tCanvas.Location = New System.Drawing.Point(0, 0)
		Me.tCanvas.MinimumTabs = 0
		Me.tCanvas.Name = "tCanvas"
		Me.tCanvas.SelectedIndex = 0
		Me.tCanvas.SelectedTabColor = System.Drawing.Color.DimGray
		Me.tCanvas.Size = New System.Drawing.Size(1042, 615)
		Me.tCanvas.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.AutoScroll = True
		Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.TabPage1.Controls.Add(Me.CanvasControl1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 28)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Size = New System.Drawing.Size(1034, 583)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Canvas1"
		'
		'pShear
		'
		Me.pShear.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
		Me.pShear.Controls.Add(Me.TBShrY)
		Me.pShear.Controls.Add(Me.Label62)
		Me.pShear.Controls.Add(Me.TBShrX)
		Me.pShear.Controls.Add(Me.Label61)
		Me.pShear.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.pShear.ForeColor = System.Drawing.Color.White
		Me.pShear.Location = New System.Drawing.Point(828, 548)
		Me.pShear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.pShear.Name = "pShear"
		Me.pShear.Resizable = False
		Me.pShear.Size = New System.Drawing.Size(250, 103)
		Me.pShear.TabIndex = 9
		Me.pShear.Text = "Shear"
		Me.pShear.Visible = False
		'
		'TBShrY
		'
		Me.TBShrY.BackColor = System.Drawing.Color.Transparent
		Me.TBShrY.BarBorderColor = System.Drawing.Color.White
		Me.TBShrY.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TBShrY.Factors = New Single() {0!, 1.0!}
		Me.TBShrY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.TBShrY.Increment = 0.1!
		Me.TBShrY.Location = New System.Drawing.Point(58, 64)
		Me.TBShrY.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.TBShrY.Maximum = 0.99!
		Me.TBShrY.Minimum = -0.99!
		Me.TBShrY.Name = "TBShrY"
		Me.TBShrY.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TBShrY.Size = New System.Drawing.Size(188, 20)
		Me.TBShrY.TabIndex = 3
		Me.TBShrY.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label62
		'
		Me.Label62.AutoSize = True
		Me.Label62.BackColor = System.Drawing.Color.Transparent
		Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label62.Location = New System.Drawing.Point(3, 68)
		Me.Label62.Name = "Label62"
		Me.Label62.Size = New System.Drawing.Size(48, 13)
		Me.Label62.TabIndex = 2
		Me.Label62.Text = "Shear Y:"
		'
		'TBShrX
		'
		Me.TBShrX.BackColor = System.Drawing.Color.Transparent
		Me.TBShrX.BarBorderColor = System.Drawing.Color.White
		Me.TBShrX.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
		Me.TBShrX.Factors = New Single() {0!, 1.0!}
		Me.TBShrX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
		Me.TBShrX.Increment = 0.1!
		Me.TBShrX.Location = New System.Drawing.Point(58, 34)
		Me.TBShrX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.TBShrX.Maximum = 0.99!
		Me.TBShrX.Minimum = -0.99!
		Me.TBShrX.Name = "TBShrX"
		Me.TBShrX.Positions = New Single() {0!, 0.5!, 1.0!}
		Me.TBShrX.Size = New System.Drawing.Size(188, 20)
		Me.TBShrX.TabIndex = 1
		Me.TBShrX.ThumbBorderColor = System.Drawing.Color.White
		'
		'Label61
		'
		Me.Label61.AutoSize = True
		Me.Label61.BackColor = System.Drawing.Color.Transparent
		Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label61.Location = New System.Drawing.Point(3, 38)
		Me.Label61.Name = "Label61"
		Me.Label61.Size = New System.Drawing.Size(48, 13)
		Me.Label61.TabIndex = 0
		Me.Label61.Text = "Shear X:"
		'
		'CanvasControl1
		'
		Me.CanvasControl1.AutoScroll = True
		Me.CanvasControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.CanvasControl1.Location = New System.Drawing.Point(0, 0)
		Me.CanvasControl1.Margin = New System.Windows.Forms.Padding(0)
		Me.CanvasControl1.Name = "CanvasControl1"
		Me.CanvasControl1.Size = New System.Drawing.Size(1032, 581)
		Me.CanvasControl1.TabIndex = 0
		'
		'MainForm
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(1366, 705)
		Me.Controls.Add(Me.pShear)
		Me.Controls.Add(Me.pSettings)
		Me.Controls.Add(Me.pSideBar)
		Me.Controls.Add(Me.tTop)
		Me.Controls.Add(Me.tbShadow)
		Me.Controls.Add(Me.tbGlow)
		Me.Controls.Add(Me.tBottom)
		Me.Controls.Add(Me.tbStroke)
		Me.Controls.Add(Me.tbFill)
		Me.Controls.Add(Me.pMain)
		Me.Controls.Add(Me.pCanvas)
		Me.DoubleBuffered = True
		Me.ForeColor = System.Drawing.Color.White
		Me.KeyPreview = True
		Me.Name = "MainForm"
		Me.ShowIcon = False
		Me.Text = "MainForm"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.pSettings.ResumeLayout(False)
		Me.pSettings.PerformLayout()
		CType(Me.set_PB, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.set_H, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.set_W, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pSideBar.ResumeLayout(False)
		Me.tTop.ResumeLayout(False)
		Me.tTop.PerformLayout()
		Me.tBottom.ResumeLayout(False)
		Me.tBottom.PerformLayout()
		CType(Me.ud_A, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ud_H, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ud_W, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ud_Y, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ud_X, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pMain.ResumeLayout(False)
		Me.pSolid.ResumeLayout(False)
		Me.pSolid.PerformLayout()
		Me.pLinear.ResumeLayout(False)
		Me.pLinear.PerformLayout()
		Me.pPath.ResumeLayout(False)
		Me.pPath.PerformLayout()
		Me.pHatch.ResumeLayout(False)
		Me.pHatch.PerformLayout()
		Me.pTexture.ResumeLayout(False)
		Me.pTexture.PerformLayout()
		CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pStroke.ResumeLayout(False)
		Me.pStroke.PerformLayout()
		Me.pGlow.ResumeLayout(False)
		Me.pGlow.PerformLayout()
		Me.pShadow.ResumeLayout(False)
		Me.pShadow.PerformLayout()
		Me.pCanvas.ResumeLayout(False)
		Me.tCanvas.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.pShear.ResumeLayout(False)
		Me.pShear.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents rDraw As RadioButton
	Friend WithEvents rSelect As RadioButton
	Friend WithEvents tTop As MyControls.MyPanel
	Friend WithEvents Label1 As Label
	Friend WithEvents cb_Shape As ComboBox
	Friend WithEvents cb_Brush As ComboBox
	Friend WithEvents CE_Solid As MyControls.ColorEditorButton
	Friend WithEvents pSolid As MyControls.MyPanel
	Friend WithEvents Label4 As Label
	Friend WithEvents pLinear As MyControls.MyPanel
	Friend WithEvents CB_Gamma As CheckBox
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents CE_L2 As MyControls.ColorEditorButton
	Friend WithEvents CE_L1 As MyControls.ColorEditorButton
	Friend WithEvents TB_LAngle As MyControls.MyTrackBar
	Friend WithEvents Label7 As Label
	Friend WithEvents LTriScale As MyControls.MyTrackBar
	Friend WithEvents Label9 As Label
	Friend WithEvents LTriFocus As MyControls.MyTrackBar
	Friend WithEvents Label8 As Label
	Friend WithEvents CB_LTri As CheckBox
	Friend WithEvents LBellScale As MyControls.MyTrackBar
	Friend WithEvents Label11 As Label
	Friend WithEvents LBellFocus As MyControls.MyTrackBar
	Friend WithEvents Label10 As Label
	Friend WithEvents CB_LBell As CheckBox
	Friend WithEvents L_BEditor As MyControls.BlendEditor
	Friend WithEvents L_CBEditor As MyControls.ColorBlendEditor
	Friend WithEvents CB_LBlend As CheckBox
	Friend WithEvents CB_LColorBlend As CheckBox
	Friend WithEvents pPath As MyControls.MyPanel
	Friend WithEvents P_BEditor As MyControls.BlendEditor
	Friend WithEvents P_CBEditor As MyControls.ColorBlendEditor
	Friend WithEvents PBellScale As MyControls.MyTrackBar
	Friend WithEvents PTriScale As MyControls.MyTrackBar
	Friend WithEvents Label12 As Label
	Friend WithEvents Label13 As Label
	Friend WithEvents PBellFocus As MyControls.MyTrackBar
	Friend WithEvents PTriFocus As MyControls.MyTrackBar
	Friend WithEvents Label14 As Label
	Friend WithEvents Label15 As Label
	Friend WithEvents CB_PBlend As CheckBox
	Friend WithEvents CB_PColorBlend As CheckBox
	Friend WithEvents CB_PBell As CheckBox
	Friend WithEvents CB_PTri As CheckBox
	Friend WithEvents Label17 As Label
	Friend WithEvents Label18 As Label
	Friend WithEvents CE_P1 As MyControls.ColorEditorButton
	Friend WithEvents pHatch As MyControls.MyPanel
	Friend WithEvents Label23 As Label
	Friend WithEvents Label24 As Label
	Friend WithEvents CE_H2 As MyControls.ColorEditorButton
	Friend WithEvents CE_H1 As MyControls.ColorEditorButton
	Friend WithEvents cb_HatchStyle As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents pTexture As MyControls.MyPanel
	Friend WithEvents CB_Trans As CheckBox
	Friend WithEvents Label21 As Label
	Friend WithEvents CE_Trans As MyControls.ColorEditorButton
	Friend WithEvents Label20 As Label
	Friend WithEvents PB_Texture As PictureBox
	Friend WithEvents openDialog As OpenFileDialog
	Friend WithEvents cb_RotateFlip As ComboBox
	Friend WithEvents Label26 As Label
	Friend WithEvents B_TImage As MyControls.MyButton
	Friend WithEvents B_TClip As MyControls.MyButton
	Friend WithEvents PFocusY As MyControls.MyTrackBar
	Friend WithEvents Label27 As Label
	Friend WithEvents PFocusX As MyControls.MyTrackBar
	Friend WithEvents Label28 As Label
	Friend WithEvents Label29 As Label
	Friend WithEvents B_Surround As MyControls.MyButton
	Friend WithEvents tBottom As MyControls.MyPanel
	Friend WithEvents tCanvas As MyControls.MyTabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents pStroke As MyControls.MyPanel
	Friend WithEvents LP_CBEditor As MyControls.ColorBlendEditor
	Friend WithEvents Label37 As Label
	Friend WithEvents CE_PSolid As MyControls.ColorEditorButton
	Friend WithEvents Label38 As Label
	Friend WithEvents rbpLinear As RadioButton
	Friend WithEvents rbpSolid As RadioButton
	Friend WithEvents cb_PHatchStyle As ComboBox
	Friend WithEvents Label30 As Label
	Friend WithEvents Label31 As Label
	Friend WithEvents CE_PBack As MyControls.ColorEditorButton
	Friend WithEvents CE_PFore As MyControls.ColorEditorButton
	Friend WithEvents Label32 As Label
	Friend WithEvents rbpHatch As RadioButton
	Friend WithEvents PWidth As MyControls.MyTrackBar
	Friend WithEvents Label33 As Label
	Friend WithEvents TB_PAngle As MyControls.MyTrackBar
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
	Friend WithEvents TB_PSY As MyControls.MyTrackBar
	Friend WithEvents Label44 As Label
	Friend WithEvents TB_PSX As MyControls.MyTrackBar
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
	Friend WithEvents bShape As MyControls.MyButton
	Friend WithEvents pGlow As MyControls.MyPanel
	Friend WithEvents TB_Feather As MyControls.MyTrackBar
	Friend WithEvents Label54 As Label
	Friend WithEvents TB_Glow As MyControls.MyTrackBar
	Friend WithEvents Label53 As Label
	Friend WithEvents cb_gfill As CheckBox
	Friend WithEvents cb_GStyle As ComboBox
	Friend WithEvents Label52 As Label
	Friend WithEvents Label50 As Label
	Friend WithEvents CE_Glow As MyControls.ColorEditorButton
	Friend WithEvents pShadow As MyControls.MyPanel
	Friend WithEvents TB_SFeather As MyControls.MyTrackBar
	Friend WithEvents Label55 As Label
	Friend WithEvents TB_SBlur As MyControls.MyTrackBar
	Friend WithEvents Label56 As Label
	Friend WithEvents cb_fill As CheckBox
	Friend WithEvents Label58 As Label
	Friend WithEvents CE_Shadow As MyControls.ColorEditorButton
	Friend WithEvents cb_clip As CheckBox
	Friend WithEvents PS_Shadow As MyControls.PointSelector
	Friend WithEvents cb_EGlow As CheckBox
	Friend WithEvents Label57 As Label
	Friend WithEvents cb_EShadow As CheckBox
	Friend WithEvents pMain As MyControls.MyPanel
	Friend WithEvents tbFill As MyControls.MyButton
	Friend WithEvents tbStroke As MyControls.MyButton
	Friend WithEvents tbGlow As MyControls.MyButton
	Friend WithEvents tbShadow As MyControls.MyButton
	Friend WithEvents pCanvas As MyControls.MyPanel
	Friend WithEvents btDelete As MyControls.FlatButton
	Friend WithEvents btClone As MyControls.FlatButton
	Friend WithEvents btBack As MyControls.FlatButton
	Friend WithEvents btFront As MyControls.FlatButton
	Friend WithEvents pSideBar As MyControls.MyPanel
	Friend WithEvents btExit As MyControls.FlatButton
	Friend WithEvents btSettings As MyControls.FlatButton
	Friend WithEvents btSave As MyControls.FlatButton
	Friend WithEvents btOpen As MyControls.FlatButton
	Friend WithEvents btMenu As MyControls.FlatButton
	Friend WithEvents btNewC As MyControls.FlatButton
	Friend WithEvents saveDialog As SaveFileDialog
	Friend WithEvents cb_GClip As ComboBox
	Friend WithEvents Label2 As Label
	Friend WithEvents CanvasControl1 As CanvasControl
	Friend WithEvents pSettings As MyControls.MovablePanel
	Friend WithEvents Label3 As Label
	Friend WithEvents set_BC As MyControls.ColorEditorButton
	Friend WithEvents Label25 As Label
	Friend WithEvents Label22 As Label
	Friend WithEvents set_bclr As MyControls.ColorEditorButton
	Friend WithEvents set_pclr As MyControls.ColorEditorButton
	Friend WithEvents set_hgt As CheckBox
	Friend WithEvents set_H As NumericUpDown
	Friend WithEvents set_W As NumericUpDown
	Friend WithEvents set_r2 As RadioButton
	Friend WithEvents set_r1 As RadioButton
	Friend WithEvents Label51 As Label
	Friend WithEvents Label60 As Label
	Friend WithEvents Label59 As Label
	Friend WithEvents set_Apply As MyControls.MyButton
	Friend WithEvents set_ord As ComboBox
	Friend WithEvents Label19 As Label
	Friend WithEvents pShear As MyControls.MovablePanel
	Friend WithEvents TBShrY As MyControls.MyTrackBar
	Friend WithEvents Label62 As Label
	Friend WithEvents TBShrX As MyControls.MyTrackBar
	Friend WithEvents Label61 As Label
	Friend WithEvents set_cpic As MyControls.MyButton
	Friend WithEvents set_lpic As MyControls.MyButton
	Friend WithEvents set_PB As PictureBox
	Friend WithEvents Label63 As Label
	Friend WithEvents Label64 As Label
	Friend WithEvents set_cname As TextBox
End Class
