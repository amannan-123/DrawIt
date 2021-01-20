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
        Me.imgDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tControls = New System.Windows.Forms.TabControl()
        Me.tpFill = New System.Windows.Forms.TabPage()
        Me.pHatch = New MyControls.MyPanel()
        Me.cb_HatchStyle = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CE_H2 = New MyControls.ColorEditorButton()
        Me.CE_H1 = New MyControls.ColorEditorButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pPath = New MyControls.MyPanel()
        Me.B_Surround = New System.Windows.Forms.Button()
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
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pSolid = New MyControls.MyPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CE_Solid = New MyControls.ColorEditorButton()
        Me.pTexture = New MyControls.MyPanel()
        Me.cb_RotateFlip = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.B_TImage = New System.Windows.Forms.Button()
        Me.B_TClip = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PB_Texture = New System.Windows.Forms.PictureBox()
        Me.CB_Trans = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CE_Trans = New MyControls.ColorEditorButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tpStroke = New System.Windows.Forms.TabPage()
        Me.pPen = New MyControls.MyPanel()
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
        Me.tpGlow = New System.Windows.Forms.TabPage()
        Me.pGlow = New MyControls.MyPanel()
        Me.TB_Feather = New MyControls.MyTrackBar()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TB_Glow = New MyControls.MyTrackBar()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.cb_gfill = New System.Windows.Forms.CheckBox()
        Me.cb_GStyle = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.CE_Glow = New MyControls.ColorEditorButton()
        Me.tpShadow = New System.Windows.Forms.TabPage()
        Me.tCanvas = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tBottom = New MyControls.MyPanel()
        Me.bShape = New System.Windows.Forms.Button()
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
        Me.tTop = New MyControls.MyPanel()
        Me.cb_Brush = New System.Windows.Forms.ComboBox()
        Me.cb_Shape = New System.Windows.Forms.ComboBox()
        Me.rDraw = New System.Windows.Forms.RadioButton()
        Me.rSelect = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pShadow = New MyControls.MyPanel()
        Me.TB_SFeather = New MyControls.MyTrackBar()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TB_SBlur = New MyControls.MyTrackBar()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cb_fill = New System.Windows.Forms.CheckBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.CE_Shadow = New MyControls.ColorEditorButton()
        Me.cb_clip = New System.Windows.Forms.CheckBox()
        Me.PS_Shadow = New MyControls.PointSelector()
        Me.cb_EShadow = New System.Windows.Forms.CheckBox()
        Me.cb_EGlow = New System.Windows.Forms.CheckBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Canvas1 = New DrawIt.Canvas()
        Me.Canvas2 = New DrawIt.Canvas()
        Me.tControls.SuspendLayout()
        Me.tpFill.SuspendLayout()
        Me.pHatch.SuspendLayout()
        Me.pPath.SuspendLayout()
        Me.pLinear.SuspendLayout()
        Me.pSolid.SuspendLayout()
        Me.pTexture.SuspendLayout()
        CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStroke.SuspendLayout()
        Me.pPen.SuspendLayout()
        Me.tpGlow.SuspendLayout()
        Me.pGlow.SuspendLayout()
        Me.tpShadow.SuspendLayout()
        Me.tCanvas.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.tBottom.SuspendLayout()
        CType(Me.ud_A, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_H, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_W, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ud_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tTop.SuspendLayout()
        Me.pShadow.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgDialog
        '
        Me.imgDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.jpe; *" &
    ".bmp; *.gif; *.png"""
        Me.imgDialog.Title = "Choose Image"
        '
        'tControls
        '
        Me.tControls.Controls.Add(Me.tpFill)
        Me.tControls.Controls.Add(Me.tpStroke)
        Me.tControls.Controls.Add(Me.tpGlow)
        Me.tControls.Controls.Add(Me.tpShadow)
        Me.tControls.Dock = System.Windows.Forms.DockStyle.Right
        Me.tControls.Location = New System.Drawing.Point(1080, 0)
        Me.tControls.Name = "tControls"
        Me.tControls.SelectedIndex = 0
        Me.tControls.Size = New System.Drawing.Size(286, 705)
        Me.tControls.TabIndex = 16
        '
        'tpFill
        '
        Me.tpFill.AutoScroll = True
        Me.tpFill.BackColor = System.Drawing.Color.White
        Me.tpFill.Controls.Add(Me.pHatch)
        Me.tpFill.Controls.Add(Me.pPath)
        Me.tpFill.Controls.Add(Me.pLinear)
        Me.tpFill.Controls.Add(Me.pSolid)
        Me.tpFill.Controls.Add(Me.pTexture)
        Me.tpFill.Location = New System.Drawing.Point(4, 22)
        Me.tpFill.Name = "tpFill"
        Me.tpFill.Size = New System.Drawing.Size(278, 679)
        Me.tpFill.TabIndex = 0
        Me.tpFill.Text = "Fill"
        '
        'pHatch
        '
        Me.pHatch.Controls.Add(Me.cb_HatchStyle)
        Me.pHatch.Controls.Add(Me.Label23)
        Me.pHatch.Controls.Add(Me.Label24)
        Me.pHatch.Controls.Add(Me.CE_H2)
        Me.pHatch.Controls.Add(Me.CE_H1)
        Me.pHatch.Controls.Add(Me.Label25)
        Me.pHatch.Controls.Add(Me.Label16)
        Me.pHatch.Location = New System.Drawing.Point(0, 0)
        Me.pHatch.Name = "pHatch"
        Me.pHatch.Size = New System.Drawing.Size(255, 149)
        Me.pHatch.TabIndex = 13
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
        Me.cb_HatchStyle.Location = New System.Drawing.Point(67, 108)
        Me.cb_HatchStyle.MaxDropDownItems = 14
        Me.cb_HatchStyle.Name = "cb_HatchStyle"
        Me.cb_HatchStyle.Size = New System.Drawing.Size(186, 26)
        Me.cb_HatchStyle.TabIndex = 11
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1, 83)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(59, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "BackColor:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(1, 52)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "ForeColor:"
        '
        'CE_H2
        '
        Me.CE_H2.BackColor = System.Drawing.SystemColors.Control
        Me.CE_H2.Location = New System.Drawing.Point(67, 77)
        Me.CE_H2.MyText = "ChooseColor"
        Me.CE_H2.Name = "CE_H2"
        Me.CE_H2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_H2.Size = New System.Drawing.Size(186, 25)
        Me.CE_H2.TabIndex = 9
        '
        'CE_H1
        '
        Me.CE_H1.BackColor = System.Drawing.SystemColors.Control
        Me.CE_H1.Location = New System.Drawing.Point(67, 46)
        Me.CE_H1.MyText = "ChooseColor"
        Me.CE_H1.Name = "CE_H1"
        Me.CE_H1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CE_H1.Size = New System.Drawing.Size(186, 25)
        Me.CE_H1.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(0, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(255, 29)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Hatch Brush"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Hatch Style:"
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
        Me.pPath.Controls.Add(Me.Label19)
        Me.pPath.Location = New System.Drawing.Point(0, 0)
        Me.pPath.Name = "pPath"
        Me.pPath.Size = New System.Drawing.Size(255, 704)
        Me.pPath.TabIndex = 12
        '
        'B_Surround
        '
        Me.B_Surround.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Surround.Location = New System.Drawing.Point(68, 77)
        Me.B_Surround.Name = "B_Surround"
        Me.B_Surround.Size = New System.Drawing.Size(186, 25)
        Me.B_Surround.TabIndex = 19
        Me.B_Surround.Text = "Edit Surround Colors"
        Me.B_Surround.UseVisualStyleBackColor = True
        '
        'PFocusY
        '
        Me.PFocusY.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PFocusY.Factors = New Single() {0!, 1.0!}
        Me.PFocusY.Increment = 0.1!
        Me.PFocusY.Location = New System.Drawing.Point(83, 137)
        Me.PFocusY.Maximum = 1.0!
        Me.PFocusY.Name = "PFocusY"
        Me.PFocusY.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PFocusY.Size = New System.Drawing.Size(170, 20)
        Me.PFocusY.TabIndex = 17
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1, 141)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 13)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "FocusScale Y:"
        '
        'PFocusX
        '
        Me.PFocusX.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PFocusX.Factors = New Single() {0!, 1.0!}
        Me.PFocusX.Increment = 0.1!
        Me.PFocusX.Location = New System.Drawing.Point(83, 111)
        Me.PFocusX.Maximum = 1.0!
        Me.PFocusX.Name = "PFocusX"
        Me.PFocusX.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PFocusX.Size = New System.Drawing.Size(170, 20)
        Me.PFocusX.TabIndex = 18
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(1, 115)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 13)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "FocusScale X:"
        '
        'P_BEditor
        '
        Me.P_BEditor.Color1 = System.Drawing.Color.Black
        Me.P_BEditor.Color2 = System.Drawing.Color.White
        Me.P_BEditor.Factors = New Single() {0!, 1.0!}
        Me.P_BEditor.Location = New System.Drawing.Point(2, 532)
        Me.P_BEditor.MinimumSize = New System.Drawing.Size(250, 160)
        Me.P_BEditor.Name = "P_BEditor"
        Me.P_BEditor.Positions = New Single() {0!, 1.0!}
        Me.P_BEditor.Size = New System.Drawing.Size(250, 160)
        Me.P_BEditor.TabIndex = 14
        '
        'P_CBEditor
        '
        Me.P_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))}
        Me.P_CBEditor.Location = New System.Drawing.Point(2, 343)
        Me.P_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
        Me.P_CBEditor.Name = "P_CBEditor"
        Me.P_CBEditor.Positions = New Single() {0!, 1.0!}
        Me.P_CBEditor.Size = New System.Drawing.Size(250, 160)
        Me.P_CBEditor.TabIndex = 13
        '
        'PBellScale
        '
        Me.PBellScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PBellScale.Factors = New Single() {0!, 1.0!}
        Me.PBellScale.Increment = 0.1!
        Me.PBellScale.Location = New System.Drawing.Point(67, 294)
        Me.PBellScale.Maximum = 1.0!
        Me.PBellScale.Name = "PBellScale"
        Me.PBellScale.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PBellScale.Size = New System.Drawing.Size(186, 20)
        Me.PBellScale.TabIndex = 12
        Me.PBellScale.Value = 1.0!
        '
        'PTriScale
        '
        Me.PTriScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PTriScale.Factors = New Single() {0!, 1.0!}
        Me.PTriScale.Increment = 0.1!
        Me.PTriScale.Location = New System.Drawing.Point(67, 219)
        Me.PTriScale.Maximum = 1.0!
        Me.PTriScale.Name = "PTriScale"
        Me.PTriScale.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PTriScale.Size = New System.Drawing.Size(186, 20)
        Me.PTriScale.TabIndex = 12
        Me.PTriScale.Value = 1.0!
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1, 298)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Scale:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 223)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Scale:"
        '
        'PBellFocus
        '
        Me.PBellFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PBellFocus.Factors = New Single() {0!, 1.0!}
        Me.PBellFocus.Increment = 0.1!
        Me.PBellFocus.Location = New System.Drawing.Point(67, 268)
        Me.PBellFocus.Maximum = 1.0!
        Me.PBellFocus.Name = "PBellFocus"
        Me.PBellFocus.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PBellFocus.Size = New System.Drawing.Size(186, 20)
        Me.PBellFocus.TabIndex = 12
        Me.PBellFocus.Value = 0.5!
        '
        'PTriFocus
        '
        Me.PTriFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PTriFocus.Factors = New Single() {0!, 1.0!}
        Me.PTriFocus.Increment = 0.1!
        Me.PTriFocus.Location = New System.Drawing.Point(67, 193)
        Me.PTriFocus.Maximum = 1.0!
        Me.PTriFocus.Name = "PTriFocus"
        Me.PTriFocus.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PTriFocus.Size = New System.Drawing.Size(186, 20)
        Me.PTriFocus.TabIndex = 12
        Me.PTriFocus.Value = 0.5!
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 272)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Focus:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 197)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Focus:"
        '
        'CB_PBlend
        '
        Me.CB_PBlend.AutoSize = True
        Me.CB_PBlend.Location = New System.Drawing.Point(4, 509)
        Me.CB_PBlend.Name = "CB_PBlend"
        Me.CB_PBlend.Size = New System.Drawing.Size(53, 17)
        Me.CB_PBlend.TabIndex = 11
        Me.CB_PBlend.Text = "Blend"
        Me.CB_PBlend.UseVisualStyleBackColor = True
        '
        'CB_PColorBlend
        '
        Me.CB_PColorBlend.AutoSize = True
        Me.CB_PColorBlend.Location = New System.Drawing.Point(4, 320)
        Me.CB_PColorBlend.Name = "CB_PColorBlend"
        Me.CB_PColorBlend.Size = New System.Drawing.Size(80, 17)
        Me.CB_PColorBlend.TabIndex = 11
        Me.CB_PColorBlend.Text = "Color Blend"
        Me.CB_PColorBlend.UseVisualStyleBackColor = True
        '
        'CB_PBell
        '
        Me.CB_PBell.AutoSize = True
        Me.CB_PBell.Location = New System.Drawing.Point(4, 245)
        Me.CB_PBell.Name = "CB_PBell"
        Me.CB_PBell.Size = New System.Drawing.Size(128, 17)
        Me.CB_PBell.TabIndex = 11
        Me.CB_PBell.Text = "Set Sigma Bell Shape"
        Me.CB_PBell.UseVisualStyleBackColor = True
        '
        'CB_PTri
        '
        Me.CB_PTri.AutoSize = True
        Me.CB_PTri.Location = New System.Drawing.Point(4, 170)
        Me.CB_PTri.Name = "CB_PTri"
        Me.CB_PTri.Size = New System.Drawing.Size(156, 17)
        Me.CB_PTri.TabIndex = 11
        Me.CB_PTri.Text = "Set Blend Triangular Shape"
        Me.CB_PTri.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Surround:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Center:"
        '
        'CE_P1
        '
        Me.CE_P1.BackColor = System.Drawing.SystemColors.Control
        Me.CE_P1.Location = New System.Drawing.Point(68, 46)
        Me.CE_P1.MyText = "ChooseColor"
        Me.CE_P1.Name = "CE_P1"
        Me.CE_P1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_P1.Size = New System.Drawing.Size(186, 25)
        Me.CE_P1.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(255, 29)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Path Gradient Brush"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pLinear.Controls.Add(Me.Label3)
        Me.pLinear.Location = New System.Drawing.Point(0, 0)
        Me.pLinear.Name = "pLinear"
        Me.pLinear.Size = New System.Drawing.Size(255, 685)
        Me.pLinear.TabIndex = 11
        '
        'L_BEditor
        '
        Me.L_BEditor.Color1 = System.Drawing.Color.White
        Me.L_BEditor.Color2 = System.Drawing.Color.Black
        Me.L_BEditor.Factors = New Single() {0!, 1.0!}
        Me.L_BEditor.Location = New System.Drawing.Point(2, 516)
        Me.L_BEditor.MinimumSize = New System.Drawing.Size(250, 160)
        Me.L_BEditor.Name = "L_BEditor"
        Me.L_BEditor.Positions = New Single() {0!, 1.0!}
        Me.L_BEditor.Size = New System.Drawing.Size(250, 160)
        Me.L_BEditor.TabIndex = 14
        '
        'L_CBEditor
        '
        Me.L_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.Black}
        Me.L_CBEditor.Location = New System.Drawing.Point(2, 327)
        Me.L_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
        Me.L_CBEditor.Name = "L_CBEditor"
        Me.L_CBEditor.Positions = New Single() {0!, 1.0!}
        Me.L_CBEditor.Size = New System.Drawing.Size(250, 160)
        Me.L_CBEditor.TabIndex = 13
        '
        'LBellScale
        '
        Me.LBellScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.LBellScale.Factors = New Single() {0!, 1.0!}
        Me.LBellScale.Increment = 0.1!
        Me.LBellScale.Location = New System.Drawing.Point(67, 278)
        Me.LBellScale.Maximum = 1.0!
        Me.LBellScale.Name = "LBellScale"
        Me.LBellScale.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.LBellScale.Size = New System.Drawing.Size(186, 20)
        Me.LBellScale.TabIndex = 12
        Me.LBellScale.Value = 1.0!
        '
        'LTriScale
        '
        Me.LTriScale.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.LTriScale.Factors = New Single() {0!, 1.0!}
        Me.LTriScale.Increment = 0.1!
        Me.LTriScale.Location = New System.Drawing.Point(67, 203)
        Me.LTriScale.Maximum = 1.0!
        Me.LTriScale.Name = "LTriScale"
        Me.LTriScale.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.LTriScale.Size = New System.Drawing.Size(186, 20)
        Me.LTriScale.TabIndex = 12
        Me.LTriScale.Value = 1.0!
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Scale:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Scale:"
        '
        'LBellFocus
        '
        Me.LBellFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.LBellFocus.Factors = New Single() {0!, 1.0!}
        Me.LBellFocus.Increment = 0.1!
        Me.LBellFocus.Location = New System.Drawing.Point(67, 252)
        Me.LBellFocus.Maximum = 1.0!
        Me.LBellFocus.Name = "LBellFocus"
        Me.LBellFocus.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.LBellFocus.Size = New System.Drawing.Size(186, 20)
        Me.LBellFocus.TabIndex = 12
        Me.LBellFocus.Value = 0.5!
        '
        'LTriFocus
        '
        Me.LTriFocus.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.LTriFocus.Factors = New Single() {0!, 1.0!}
        Me.LTriFocus.Increment = 0.1!
        Me.LTriFocus.Location = New System.Drawing.Point(67, 177)
        Me.LTriFocus.Maximum = 1.0!
        Me.LTriFocus.Name = "LTriFocus"
        Me.LTriFocus.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.LTriFocus.Size = New System.Drawing.Size(186, 20)
        Me.LTriFocus.TabIndex = 12
        Me.LTriFocus.Value = 0.5!
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Focus:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Focus:"
        '
        'TB_LAngle
        '
        Me.TB_LAngle.AllowDecimal = False
        Me.TB_LAngle.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_LAngle.Factors = New Single() {0!, 1.0!}
        Me.TB_LAngle.Location = New System.Drawing.Point(67, 128)
        Me.TB_LAngle.Maximum = 360.0!
        Me.TB_LAngle.Name = "TB_LAngle"
        Me.TB_LAngle.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_LAngle.Size = New System.Drawing.Size(186, 20)
        Me.TB_LAngle.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Angle:"
        '
        'CB_LBlend
        '
        Me.CB_LBlend.AutoSize = True
        Me.CB_LBlend.Location = New System.Drawing.Point(4, 493)
        Me.CB_LBlend.Name = "CB_LBlend"
        Me.CB_LBlend.Size = New System.Drawing.Size(53, 17)
        Me.CB_LBlend.TabIndex = 11
        Me.CB_LBlend.Text = "Blend"
        Me.CB_LBlend.UseVisualStyleBackColor = True
        '
        'CB_LColorBlend
        '
        Me.CB_LColorBlend.AutoSize = True
        Me.CB_LColorBlend.Location = New System.Drawing.Point(4, 304)
        Me.CB_LColorBlend.Name = "CB_LColorBlend"
        Me.CB_LColorBlend.Size = New System.Drawing.Size(80, 17)
        Me.CB_LColorBlend.TabIndex = 11
        Me.CB_LColorBlend.Text = "Color Blend"
        Me.CB_LColorBlend.UseVisualStyleBackColor = True
        '
        'CB_LBell
        '
        Me.CB_LBell.AutoSize = True
        Me.CB_LBell.Location = New System.Drawing.Point(4, 229)
        Me.CB_LBell.Name = "CB_LBell"
        Me.CB_LBell.Size = New System.Drawing.Size(128, 17)
        Me.CB_LBell.TabIndex = 11
        Me.CB_LBell.Text = "Set Sigma Bell Shape"
        Me.CB_LBell.UseVisualStyleBackColor = True
        '
        'CB_LTri
        '
        Me.CB_LTri.AutoSize = True
        Me.CB_LTri.Location = New System.Drawing.Point(4, 154)
        Me.CB_LTri.Name = "CB_LTri"
        Me.CB_LTri.Size = New System.Drawing.Size(156, 17)
        Me.CB_LTri.TabIndex = 11
        Me.CB_LTri.Text = "Set Blend Triangular Shape"
        Me.CB_LTri.UseVisualStyleBackColor = True
        '
        'CB_Gamma
        '
        Me.CB_Gamma.AutoSize = True
        Me.CB_Gamma.Location = New System.Drawing.Point(4, 108)
        Me.CB_Gamma.Name = "CB_Gamma"
        Me.CB_Gamma.Size = New System.Drawing.Size(113, 17)
        Me.CB_Gamma.TabIndex = 11
        Me.CB_Gamma.Text = "Gamma Correction"
        Me.CB_Gamma.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Color 2:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Color 1:"
        '
        'CE_L2
        '
        Me.CE_L2.BackColor = System.Drawing.SystemColors.Control
        Me.CE_L2.Location = New System.Drawing.Point(67, 77)
        Me.CE_L2.MyText = "ChooseColor"
        Me.CE_L2.Name = "CE_L2"
        Me.CE_L2.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CE_L2.Size = New System.Drawing.Size(186, 25)
        Me.CE_L2.TabIndex = 9
        '
        'CE_L1
        '
        Me.CE_L1.BackColor = System.Drawing.SystemColors.Control
        Me.CE_L1.Location = New System.Drawing.Point(67, 46)
        Me.CE_L1.MyText = "ChooseColor"
        Me.CE_L1.Name = "CE_L1"
        Me.CE_L1.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_L1.Size = New System.Drawing.Size(186, 25)
        Me.CE_L1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(255, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Linear Gradient Brush"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pSolid
        '
        Me.pSolid.Controls.Add(Me.Label4)
        Me.pSolid.Controls.Add(Me.Label2)
        Me.pSolid.Controls.Add(Me.CE_Solid)
        Me.pSolid.Location = New System.Drawing.Point(0, 0)
        Me.pSolid.Name = "pSolid"
        Me.pSolid.Size = New System.Drawing.Size(255, 92)
        Me.pSolid.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Solid Color:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Solid Brush"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CE_Solid
        '
        Me.CE_Solid.BackColor = System.Drawing.SystemColors.Control
        Me.CE_Solid.Location = New System.Drawing.Point(67, 47)
        Me.CE_Solid.MyText = "ChooseColor"
        Me.CE_Solid.Name = "CE_Solid"
        Me.CE_Solid.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_Solid.Size = New System.Drawing.Size(186, 25)
        Me.CE_Solid.TabIndex = 7
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
        Me.pTexture.Controls.Add(Me.Label22)
        Me.pTexture.Location = New System.Drawing.Point(0, 0)
        Me.pTexture.Name = "pTexture"
        Me.pTexture.Size = New System.Drawing.Size(255, 427)
        Me.pTexture.TabIndex = 14
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
        Me.cb_RotateFlip.Location = New System.Drawing.Point(68, 387)
        Me.cb_RotateFlip.MaxDropDownItems = 14
        Me.cb_RotateFlip.Name = "cb_RotateFlip"
        Me.cb_RotateFlip.Size = New System.Drawing.Size(185, 25)
        Me.cb_RotateFlip.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(2, 393)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "RotateFlip:"
        '
        'B_TImage
        '
        Me.B_TImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_TImage.Location = New System.Drawing.Point(130, 292)
        Me.B_TImage.Name = "B_TImage"
        Me.B_TImage.Size = New System.Drawing.Size(121, 24)
        Me.B_TImage.TabIndex = 14
        Me.B_TImage.Text = "Choose File"
        Me.B_TImage.UseVisualStyleBackColor = True
        '
        'B_TClip
        '
        Me.B_TClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_TClip.Location = New System.Drawing.Point(4, 292)
        Me.B_TClip.Name = "B_TClip"
        Me.B_TClip.Size = New System.Drawing.Size(125, 24)
        Me.B_TClip.TabIndex = 14
        Me.B_TClip.Text = "From Clipboard"
        Me.B_TClip.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(2, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Image:"
        '
        'PB_Texture
        '
        Me.PB_Texture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB_Texture.Location = New System.Drawing.Point(3, 56)
        Me.PB_Texture.Name = "PB_Texture"
        Me.PB_Texture.Size = New System.Drawing.Size(249, 230)
        Me.PB_Texture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Texture.TabIndex = 12
        Me.PB_Texture.TabStop = False
        '
        'CB_Trans
        '
        Me.CB_Trans.AutoSize = True
        Me.CB_Trans.Location = New System.Drawing.Point(4, 332)
        Me.CB_Trans.Name = "CB_Trans"
        Me.CB_Trans.Size = New System.Drawing.Size(91, 17)
        Me.CB_Trans.TabIndex = 11
        Me.CB_Trans.Text = "Transparency"
        Me.CB_Trans.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 358)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Color:"
        '
        'CE_Trans
        '
        Me.CE_Trans.BackColor = System.Drawing.SystemColors.Control
        Me.CE_Trans.Location = New System.Drawing.Point(68, 352)
        Me.CE_Trans.MyText = "ChooseColor"
        Me.CE_Trans.Name = "CE_Trans"
        Me.CE_Trans.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_Trans.Size = New System.Drawing.Size(185, 25)
        Me.CE_Trans.TabIndex = 9
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(0, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(255, 29)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Texture Brush"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tpStroke
        '
        Me.tpStroke.AutoScroll = True
        Me.tpStroke.BackColor = System.Drawing.Color.White
        Me.tpStroke.Controls.Add(Me.pPen)
        Me.tpStroke.Location = New System.Drawing.Point(4, 22)
        Me.tpStroke.Name = "tpStroke"
        Me.tpStroke.Size = New System.Drawing.Size(278, 679)
        Me.tpStroke.TabIndex = 1
        Me.tpStroke.Text = "Stroke"
        '
        'pPen
        '
        Me.pPen.Controls.Add(Me.TB_PSY)
        Me.pPen.Controls.Add(Me.Label44)
        Me.pPen.Controls.Add(Me.TB_PSX)
        Me.pPen.Controls.Add(Me.Label43)
        Me.pPen.Controls.Add(Me.Label42)
        Me.pPen.Controls.Add(Me.CB_LJoin)
        Me.pPen.Controls.Add(Me.Label41)
        Me.pPen.Controls.Add(Me.CB_ECap)
        Me.pPen.Controls.Add(Me.Label40)
        Me.pPen.Controls.Add(Me.CB_SCap)
        Me.pPen.Controls.Add(Me.Label39)
        Me.pPen.Controls.Add(Me.CB_DCap)
        Me.pPen.Controls.Add(Me.Label36)
        Me.pPen.Controls.Add(Me.CB_DStyle)
        Me.pPen.Controls.Add(Me.Label35)
        Me.pPen.Controls.Add(Me.TB_PAngle)
        Me.pPen.Controls.Add(Me.Label34)
        Me.pPen.Controls.Add(Me.CB_PGamma)
        Me.pPen.Controls.Add(Me.PWidth)
        Me.pPen.Controls.Add(Me.Label33)
        Me.pPen.Controls.Add(Me.cb_PHatchStyle)
        Me.pPen.Controls.Add(Me.Label30)
        Me.pPen.Controls.Add(Me.Label31)
        Me.pPen.Controls.Add(Me.CE_PBack)
        Me.pPen.Controls.Add(Me.CE_PFore)
        Me.pPen.Controls.Add(Me.Label32)
        Me.pPen.Controls.Add(Me.rbpHatch)
        Me.pPen.Controls.Add(Me.rbpLinear)
        Me.pPen.Controls.Add(Me.rbpSolid)
        Me.pPen.Controls.Add(Me.LP_CBEditor)
        Me.pPen.Controls.Add(Me.Label37)
        Me.pPen.Controls.Add(Me.CE_PSolid)
        Me.pPen.Controls.Add(Me.Label38)
        Me.pPen.Location = New System.Drawing.Point(0, 0)
        Me.pPen.Name = "pPen"
        Me.pPen.Size = New System.Drawing.Size(255, 696)
        Me.pPen.TabIndex = 13
        '
        'TB_PSY
        '
        Me.TB_PSY.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_PSY.Factors = New Single() {0!, 1.0!}
        Me.TB_PSY.Increment = 0.1!
        Me.TB_PSY.Location = New System.Drawing.Point(67, 668)
        Me.TB_PSY.Maximum = 2.0!
        Me.TB_PSY.Minimum = 0.1!
        Me.TB_PSY.Name = "TB_PSY"
        Me.TB_PSY.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_PSY.Size = New System.Drawing.Size(186, 20)
        Me.TB_PSY.TabIndex = 30
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
        Me.TB_PSX.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_PSX.Factors = New Single() {0!, 1.0!}
        Me.TB_PSX.Increment = 0.1!
        Me.TB_PSX.Location = New System.Drawing.Point(67, 643)
        Me.TB_PSX.Maximum = 2.0!
        Me.TB_PSX.Minimum = 0.1!
        Me.TB_PSX.Name = "TB_PSX"
        Me.TB_PSX.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_PSX.Size = New System.Drawing.Size(186, 20)
        Me.TB_PSX.TabIndex = 30
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
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(0, 426)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(255, 29)
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
        Me.CB_LJoin.TabIndex = 27
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
        Me.CB_ECap.TabIndex = 27
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
        Me.CB_SCap.TabIndex = 27
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
        Me.CB_DCap.TabIndex = 27
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
        Me.CB_DStyle.TabIndex = 27
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
        Me.TB_PAngle.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_PAngle.Factors = New Single() {0!, 1.0!}
        Me.TB_PAngle.Location = New System.Drawing.Point(67, 295)
        Me.TB_PAngle.Maximum = 360.0!
        Me.TB_PAngle.Name = "TB_PAngle"
        Me.TB_PAngle.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_PAngle.Size = New System.Drawing.Size(186, 20)
        Me.TB_PAngle.TabIndex = 25
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
        Me.CB_PGamma.TabIndex = 24
        Me.CB_PGamma.Text = "Gamma Correction"
        Me.CB_PGamma.UseVisualStyleBackColor = True
        '
        'PWidth
        '
        Me.PWidth.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.PWidth.Factors = New Single() {0!, 1.0!}
        Me.PWidth.Location = New System.Drawing.Point(47, 458)
        Me.PWidth.Maximum = 50.0!
        Me.PWidth.Minimum = 1.0!
        Me.PWidth.Name = "PWidth"
        Me.PWidth.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.PWidth.Size = New System.Drawing.Size(208, 20)
        Me.PWidth.TabIndex = 22
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
        Me.cb_PHatchStyle.TabIndex = 20
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
        Me.CE_PBack.TabIndex = 15
        '
        'CE_PFore
        '
        Me.CE_PFore.BackColor = System.Drawing.SystemColors.Control
        Me.CE_PFore.Location = New System.Drawing.Point(67, 335)
        Me.CE_PFore.MyText = "ChooseColor"
        Me.CE_PFore.Name = "CE_PFore"
        Me.CE_PFore.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CE_PFore.Size = New System.Drawing.Size(186, 25)
        Me.CE_PFore.TabIndex = 16
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
        Me.rbpHatch.TabIndex = 14
        Me.rbpHatch.Text = "Hatch"
        Me.rbpHatch.UseVisualStyleBackColor = True
        '
        'rbpLinear
        '
        Me.rbpLinear.AutoSize = True
        Me.rbpLinear.Location = New System.Drawing.Point(4, 86)
        Me.rbpLinear.Name = "rbpLinear"
        Me.rbpLinear.Size = New System.Drawing.Size(94, 17)
        Me.rbpLinear.TabIndex = 14
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
        Me.rbpSolid.TabIndex = 14
        Me.rbpSolid.TabStop = True
        Me.rbpSolid.Text = "Solid"
        Me.rbpSolid.UseVisualStyleBackColor = True
        '
        'LP_CBEditor
        '
        Me.LP_CBEditor.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.Black}
        Me.LP_CBEditor.Location = New System.Drawing.Point(2, 109)
        Me.LP_CBEditor.MinimumSize = New System.Drawing.Size(250, 160)
        Me.LP_CBEditor.Name = "LP_CBEditor"
        Me.LP_CBEditor.Positions = New Single() {0!, 1.0!}
        Me.LP_CBEditor.Size = New System.Drawing.Size(250, 160)
        Me.LP_CBEditor.TabIndex = 13
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
        Me.CE_PSolid.TabIndex = 9
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(0, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(255, 29)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Fill"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tpGlow
        '
        Me.tpGlow.AutoScroll = True
        Me.tpGlow.BackColor = System.Drawing.Color.White
        Me.tpGlow.Controls.Add(Me.pGlow)
        Me.tpGlow.Location = New System.Drawing.Point(4, 22)
        Me.tpGlow.Name = "tpGlow"
        Me.tpGlow.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGlow.Size = New System.Drawing.Size(278, 679)
        Me.tpGlow.TabIndex = 2
        Me.tpGlow.Text = "Glow"
        '
        'pGlow
        '
        Me.pGlow.Controls.Add(Me.cb_EGlow)
        Me.pGlow.Controls.Add(Me.TB_Feather)
        Me.pGlow.Controls.Add(Me.Label54)
        Me.pGlow.Controls.Add(Me.TB_Glow)
        Me.pGlow.Controls.Add(Me.Label53)
        Me.pGlow.Controls.Add(Me.cb_gfill)
        Me.pGlow.Controls.Add(Me.cb_GStyle)
        Me.pGlow.Controls.Add(Me.Label52)
        Me.pGlow.Controls.Add(Me.Label50)
        Me.pGlow.Controls.Add(Me.Label51)
        Me.pGlow.Controls.Add(Me.CE_Glow)
        Me.pGlow.Location = New System.Drawing.Point(0, 0)
        Me.pGlow.Name = "pGlow"
        Me.pGlow.Size = New System.Drawing.Size(255, 194)
        Me.pGlow.TabIndex = 11
        '
        'TB_Feather
        '
        Me.TB_Feather.AllowDecimal = False
        Me.TB_Feather.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_Feather.Factors = New Single() {0!, 1.0!}
        Me.TB_Feather.Location = New System.Drawing.Point(53, 144)
        Me.TB_Feather.Minimum = 10.0!
        Me.TB_Feather.Name = "TB_Feather"
        Me.TB_Feather.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_Feather.Size = New System.Drawing.Size(200, 20)
        Me.TB_Feather.TabIndex = 16
        Me.TB_Feather.Value = 35.0!
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(1, 148)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(46, 13)
        Me.Label54.TabIndex = 14
        Me.Label54.Text = "Feather:"
        '
        'TB_Glow
        '
        Me.TB_Glow.AllowDecimal = False
        Me.TB_Glow.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_Glow.Factors = New Single() {0!, 1.0!}
        Me.TB_Glow.Location = New System.Drawing.Point(53, 118)
        Me.TB_Glow.Minimum = 10.0!
        Me.TB_Glow.Name = "TB_Glow"
        Me.TB_Glow.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_Glow.Size = New System.Drawing.Size(200, 20)
        Me.TB_Glow.TabIndex = 16
        Me.TB_Glow.Value = 35.0!
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(1, 122)
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
        Me.cb_gfill.Location = New System.Drawing.Point(6, 170)
        Me.cb_gfill.Name = "cb_gfill"
        Me.cb_gfill.Size = New System.Drawing.Size(72, 17)
        Me.cb_gfill.TabIndex = 15
        Me.cb_gfill.Text = "Before Fill"
        Me.cb_gfill.UseVisualStyleBackColor = True
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
        Me.cb_GStyle.Location = New System.Drawing.Point(67, 86)
        Me.cb_GStyle.MaxDropDownItems = 14
        Me.cb_GStyle.Name = "cb_GStyle"
        Me.cb_GStyle.Size = New System.Drawing.Size(186, 25)
        Me.cb_GStyle.TabIndex = 13
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(1, 92)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(60, 13)
        Me.Label52.TabIndex = 12
        Me.Label52.Text = "Glow Style:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(1, 61)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(61, 13)
        Me.Label50.TabIndex = 8
        Me.Label50.Text = "Glow Color:"
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label51.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(0, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(255, 29)
        Me.Label51.TabIndex = 0
        Me.Label51.Text = "Glow"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CE_Glow
        '
        Me.CE_Glow.BackColor = System.Drawing.SystemColors.Control
        Me.CE_Glow.Location = New System.Drawing.Point(67, 55)
        Me.CE_Glow.MyText = "ChooseColor"
        Me.CE_Glow.Name = "CE_Glow"
        Me.CE_Glow.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CE_Glow.Size = New System.Drawing.Size(186, 25)
        Me.CE_Glow.TabIndex = 7
        '
        'tpShadow
        '
        Me.tpShadow.BackColor = System.Drawing.Color.White
        Me.tpShadow.Controls.Add(Me.pShadow)
        Me.tpShadow.Location = New System.Drawing.Point(4, 22)
        Me.tpShadow.Name = "tpShadow"
        Me.tpShadow.Padding = New System.Windows.Forms.Padding(3)
        Me.tpShadow.Size = New System.Drawing.Size(278, 679)
        Me.tpShadow.TabIndex = 3
        Me.tpShadow.Text = "Shadow"
        '
        'tCanvas
        '
        Me.tCanvas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tCanvas.Controls.Add(Me.TabPage1)
        Me.tCanvas.Controls.Add(Me.TabPage2)
        Me.tCanvas.Location = New System.Drawing.Point(0, 45)
        Me.tCanvas.Name = "tCanvas"
        Me.tCanvas.SelectedIndex = 0
        Me.tCanvas.Size = New System.Drawing.Size(1080, 615)
        Me.tCanvas.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Canvas1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1072, 589)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Canvas1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Canvas2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1072, 589)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Canvas2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tBottom
        '
        Me.tBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tBottom.BackColor = System.Drawing.Color.White
        Me.tBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.tBottom.Location = New System.Drawing.Point(0, 660)
        Me.tBottom.Name = "tBottom"
        Me.tBottom.Size = New System.Drawing.Size(1080, 45)
        Me.tBottom.TabIndex = 17
        '
        'bShape
        '
        Me.bShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bShape.Location = New System.Drawing.Point(478, 9)
        Me.bShape.Name = "bShape"
        Me.bShape.Size = New System.Drawing.Size(70, 24)
        Me.bShape.TabIndex = 5
        Me.bShape.Text = "Edit Shape"
        Me.bShape.UseVisualStyleBackColor = True
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(368, 13)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(37, 13)
        Me.Label49.TabIndex = 1
        Me.Label49.Text = "Angle:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(277, 13)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(18, 13)
        Me.Label48.TabIndex = 1
        Me.Label48.Text = "H:"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(183, 13)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(21, 13)
        Me.Label47.TabIndex = 1
        Me.Label47.Text = "W:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(93, 13)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(17, 13)
        Me.Label46.TabIndex = 1
        Me.Label46.Text = "Y:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(3, 13)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(17, 13)
        Me.Label45.TabIndex = 1
        Me.Label45.Text = "X:"
        '
        'ud_A
        '
        Me.ud_A.DecimalPlaces = 2
        Me.ud_A.Location = New System.Drawing.Point(411, 11)
        Me.ud_A.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.ud_A.Name = "ud_A"
        Me.ud_A.Size = New System.Drawing.Size(61, 20)
        Me.ud_A.TabIndex = 4
        '
        'ud_H
        '
        Me.ud_H.DecimalPlaces = 2
        Me.ud_H.Location = New System.Drawing.Point(301, 11)
        Me.ud_H.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.ud_H.Name = "ud_H"
        Me.ud_H.Size = New System.Drawing.Size(61, 20)
        Me.ud_H.TabIndex = 3
        '
        'ud_W
        '
        Me.ud_W.DecimalPlaces = 2
        Me.ud_W.Location = New System.Drawing.Point(210, 11)
        Me.ud_W.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.ud_W.Name = "ud_W"
        Me.ud_W.Size = New System.Drawing.Size(61, 20)
        Me.ud_W.TabIndex = 2
        '
        'ud_Y
        '
        Me.ud_Y.DecimalPlaces = 2
        Me.ud_Y.Location = New System.Drawing.Point(116, 11)
        Me.ud_Y.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.ud_Y.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.ud_Y.Name = "ud_Y"
        Me.ud_Y.Size = New System.Drawing.Size(61, 20)
        Me.ud_Y.TabIndex = 1
        '
        'ud_X
        '
        Me.ud_X.DecimalPlaces = 2
        Me.ud_X.Location = New System.Drawing.Point(26, 11)
        Me.ud_X.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.ud_X.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.ud_X.Name = "ud_X"
        Me.ud_X.Size = New System.Drawing.Size(61, 20)
        Me.ud_X.TabIndex = 0
        '
        'tTop
        '
        Me.tTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tTop.BackColor = System.Drawing.Color.White
        Me.tTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tTop.Controls.Add(Me.cb_Brush)
        Me.tTop.Controls.Add(Me.cb_Shape)
        Me.tTop.Controls.Add(Me.rDraw)
        Me.tTop.Controls.Add(Me.rSelect)
        Me.tTop.Controls.Add(Me.Label29)
        Me.tTop.Controls.Add(Me.Label1)
        Me.tTop.Location = New System.Drawing.Point(0, 0)
        Me.tTop.Name = "tTop"
        Me.tTop.Size = New System.Drawing.Size(1080, 45)
        Me.tTop.TabIndex = 0
        '
        'cb_Brush
        '
        Me.cb_Brush.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cb_Brush.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_Brush.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cb_Brush.DropDownHeight = 250
        Me.cb_Brush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Brush.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Brush.IntegralHeight = False
        Me.cb_Brush.ItemHeight = 20
        Me.cb_Brush.Location = New System.Drawing.Point(350, 9)
        Me.cb_Brush.MaxDropDownItems = 14
        Me.cb_Brush.Name = "cb_Brush"
        Me.cb_Brush.Size = New System.Drawing.Size(171, 26)
        Me.cb_Brush.TabIndex = 3
        '
        'cb_Shape
        '
        Me.cb_Shape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cb_Shape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_Shape.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cb_Shape.DropDownHeight = 250
        Me.cb_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Shape.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Shape.IntegralHeight = False
        Me.cb_Shape.ItemHeight = 20
        Me.cb_Shape.Location = New System.Drawing.Point(130, 9)
        Me.cb_Shape.MaxDropDownItems = 14
        Me.cb_Shape.Name = "cb_Shape"
        Me.cb_Shape.Size = New System.Drawing.Size(171, 26)
        Me.cb_Shape.TabIndex = 2
        '
        'rDraw
        '
        Me.rDraw.AutoSize = True
        Me.rDraw.Checked = True
        Me.rDraw.Location = New System.Drawing.Point(14, 4)
        Me.rDraw.Name = "rDraw"
        Me.rDraw.Size = New System.Drawing.Size(50, 17)
        Me.rDraw.TabIndex = 0
        Me.rDraw.TabStop = True
        Me.rDraw.Text = "Draw"
        Me.rDraw.UseVisualStyleBackColor = True
        '
        'rSelect
        '
        Me.rSelect.AutoSize = True
        Me.rSelect.Location = New System.Drawing.Point(14, 24)
        Me.rSelect.Name = "rSelect"
        Me.rSelect.Size = New System.Drawing.Size(55, 17)
        Me.rSelect.TabIndex = 1
        Me.rSelect.Text = "Select"
        Me.rSelect.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(83, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(41, 13)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "Shape:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(307, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Brush:"
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
        Me.pShadow.Controls.Add(Me.Label59)
        Me.pShadow.Controls.Add(Me.CE_Shadow)
        Me.pShadow.Location = New System.Drawing.Point(0, 0)
        Me.pShadow.Name = "pShadow"
        Me.pShadow.Size = New System.Drawing.Size(255, 461)
        Me.pShadow.TabIndex = 12
        '
        'TB_SFeather
        '
        Me.TB_SFeather.AllowDecimal = False
        Me.TB_SFeather.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_SFeather.Factors = New Single() {0!, 1.0!}
        Me.TB_SFeather.Location = New System.Drawing.Point(55, 112)
        Me.TB_SFeather.Minimum = 10.0!
        Me.TB_SFeather.Name = "TB_SFeather"
        Me.TB_SFeather.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_SFeather.Size = New System.Drawing.Size(197, 20)
        Me.TB_SFeather.TabIndex = 16
        Me.TB_SFeather.Value = 100.0!
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(1, 112)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(46, 13)
        Me.Label55.TabIndex = 14
        Me.Label55.Text = "Feather:"
        '
        'TB_SBlur
        '
        Me.TB_SBlur.AllowDecimal = False
        Me.TB_SBlur.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_SBlur.Factors = New Single() {0!, 1.0!}
        Me.TB_SBlur.Location = New System.Drawing.Point(55, 86)
        Me.TB_SBlur.Maximum = 10.0!
        Me.TB_SBlur.Name = "TB_SBlur"
        Me.TB_SBlur.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_SBlur.Size = New System.Drawing.Size(197, 20)
        Me.TB_SBlur.TabIndex = 16
        Me.TB_SBlur.Value = 2.0!
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(1, 86)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(28, 13)
        Me.Label56.TabIndex = 14
        Me.Label56.Text = "Blur:"
        '
        'cb_fill
        '
        Me.cb_fill.AutoSize = True
        Me.cb_fill.Checked = True
        Me.cb_fill.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_fill.Location = New System.Drawing.Point(6, 138)
        Me.cb_fill.Name = "cb_fill"
        Me.cb_fill.Size = New System.Drawing.Size(38, 17)
        Me.cb_fill.TabIndex = 15
        Me.cb_fill.Text = "Fill"
        Me.cb_fill.UseVisualStyleBackColor = True
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(1, 61)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(76, 13)
        Me.Label58.TabIndex = 8
        Me.Label58.Text = "Shadow Color:"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label59.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.Black
        Me.Label59.Location = New System.Drawing.Point(0, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(255, 29)
        Me.Label59.TabIndex = 0
        Me.Label59.Text = "Shadow"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CE_Shadow
        '
        Me.CE_Shadow.BackColor = System.Drawing.SystemColors.Control
        Me.CE_Shadow.Location = New System.Drawing.Point(83, 55)
        Me.CE_Shadow.MyText = "ChooseColor"
        Me.CE_Shadow.Name = "CE_Shadow"
        Me.CE_Shadow.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CE_Shadow.Size = New System.Drawing.Size(170, 25)
        Me.CE_Shadow.TabIndex = 7
        '
        'cb_clip
        '
        Me.cb_clip.AutoSize = True
        Me.cb_clip.Checked = True
        Me.cb_clip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_clip.Location = New System.Drawing.Point(6, 161)
        Me.cb_clip.Name = "cb_clip"
        Me.cb_clip.Size = New System.Drawing.Size(100, 17)
        Me.cb_clip.TabIndex = 15
        Me.cb_clip.Text = "Region Clipping"
        Me.cb_clip.UseVisualStyleBackColor = True
        '
        'PS_Shadow
        '
        Me.PS_Shadow.Location = New System.Drawing.Point(2, 209)
        Me.PS_Shadow.Maximum = New System.Drawing.Point(50, 50)
        Me.PS_Shadow.Minimum = New System.Drawing.Point(-50, -50)
        Me.PS_Shadow.Name = "PS_Shadow"
        Me.PS_Shadow.Size = New System.Drawing.Size(249, 249)
        Me.PS_Shadow.TabIndex = 17
        Me.PS_Shadow.Value = New System.Drawing.Point(10, 10)
        '
        'cb_EShadow
        '
        Me.cb_EShadow.AutoSize = True
        Me.cb_EShadow.Location = New System.Drawing.Point(6, 32)
        Me.cb_EShadow.Name = "cb_EShadow"
        Me.cb_EShadow.Size = New System.Drawing.Size(93, 17)
        Me.cb_EShadow.TabIndex = 15
        Me.cb_EShadow.Text = "Draw Shadow"
        Me.cb_EShadow.UseVisualStyleBackColor = True
        '
        'cb_EGlow
        '
        Me.cb_EGlow.AutoSize = True
        Me.cb_EGlow.Location = New System.Drawing.Point(6, 32)
        Me.cb_EGlow.Name = "cb_EGlow"
        Me.cb_EGlow.Size = New System.Drawing.Size(78, 17)
        Me.cb_EGlow.TabIndex = 17
        Me.cb_EGlow.Text = "Draw Glow"
        Me.cb_EGlow.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(5, 193)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(38, 13)
        Me.Label57.TabIndex = 14
        Me.Label57.Text = "Offset:"
        '
        'Canvas1
        '
        Me.Canvas1.BackColor = System.Drawing.Color.Transparent
        Me.Canvas1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas1.Location = New System.Drawing.Point(3, 3)
        Me.Canvas1.MainForm = Nothing
        Me.Canvas1.Name = "Canvas1"
        Me.Canvas1.Size = New System.Drawing.Size(1066, 583)
        Me.Canvas1.TabIndex = 1
        '
        'Canvas2
        '
        Me.Canvas2.BackColor = System.Drawing.Color.Transparent
        Me.Canvas2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Canvas2.Location = New System.Drawing.Point(3, 3)
        Me.Canvas2.MainForm = Nothing
        Me.Canvas2.Name = "Canvas2"
        Me.Canvas2.Size = New System.Drawing.Size(1066, 583)
        Me.Canvas2.TabIndex = 2
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 705)
        Me.Controls.Add(Me.tBottom)
        Me.Controls.Add(Me.tControls)
        Me.Controls.Add(Me.tTop)
        Me.Controls.Add(Me.tCanvas)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.ShowIcon = False
        Me.Text = "MainForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tControls.ResumeLayout(False)
        Me.tpFill.ResumeLayout(False)
        Me.pHatch.ResumeLayout(False)
        Me.pHatch.PerformLayout()
        Me.pPath.ResumeLayout(False)
        Me.pPath.PerformLayout()
        Me.pLinear.ResumeLayout(False)
        Me.pLinear.PerformLayout()
        Me.pSolid.ResumeLayout(False)
        Me.pSolid.PerformLayout()
        Me.pTexture.ResumeLayout(False)
        Me.pTexture.PerformLayout()
        CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStroke.ResumeLayout(False)
        Me.pPen.ResumeLayout(False)
        Me.pPen.PerformLayout()
        Me.tpGlow.ResumeLayout(False)
        Me.pGlow.ResumeLayout(False)
        Me.pGlow.PerformLayout()
        Me.tpShadow.ResumeLayout(False)
        Me.tCanvas.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.tBottom.ResumeLayout(False)
        Me.tBottom.PerformLayout()
        CType(Me.ud_A, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_H, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_W, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ud_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tTop.ResumeLayout(False)
        Me.tTop.PerformLayout()
        Me.pShadow.ResumeLayout(False)
        Me.pShadow.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rDraw As RadioButton
    Friend WithEvents rSelect As RadioButton
    Friend WithEvents Canvas1 As Canvas
    Friend WithEvents tTop As MyControls.MyPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cb_Shape As ComboBox
    Friend WithEvents cb_Brush As ComboBox
    Friend WithEvents CE_Solid As MyControls.ColorEditorButton
    Friend WithEvents pSolid As MyControls.MyPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pLinear As MyControls.MyPanel
    Friend WithEvents CB_Gamma As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CE_L2 As MyControls.ColorEditorButton
    Friend WithEvents CE_L1 As MyControls.ColorEditorButton
    Friend WithEvents Label3 As Label
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
    Friend WithEvents Label19 As Label
    Friend WithEvents pHatch As MyControls.MyPanel
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents CE_H2 As MyControls.ColorEditorButton
    Friend WithEvents CE_H1 As MyControls.ColorEditorButton
    Friend WithEvents Label25 As Label
    Friend WithEvents cb_HatchStyle As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents pTexture As MyControls.MyPanel
    Friend WithEvents CB_Trans As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents CE_Trans As MyControls.ColorEditorButton
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents PB_Texture As PictureBox
    Friend WithEvents imgDialog As OpenFileDialog
    Friend WithEvents cb_RotateFlip As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents B_TImage As Button
    Friend WithEvents B_TClip As Button
    Friend WithEvents PFocusY As MyControls.MyTrackBar
    Friend WithEvents Label27 As Label
    Friend WithEvents PFocusX As MyControls.MyTrackBar
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents B_Surround As Button
    Friend WithEvents tControls As TabControl
    Friend WithEvents tpFill As TabPage
    Friend WithEvents tpStroke As TabPage
    Friend WithEvents tBottom As MyControls.MyPanel
    Friend WithEvents tCanvas As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Canvas2 As Canvas
    Friend WithEvents pPen As MyControls.MyPanel
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
    Friend WithEvents bShape As Button
    Friend WithEvents tpGlow As TabPage
    Friend WithEvents tpShadow As TabPage
    Friend WithEvents pGlow As MyControls.MyPanel
    Friend WithEvents TB_Feather As MyControls.MyTrackBar
    Friend WithEvents Label54 As Label
    Friend WithEvents TB_Glow As MyControls.MyTrackBar
    Friend WithEvents Label53 As Label
    Friend WithEvents cb_gfill As CheckBox
    Friend WithEvents cb_GStyle As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents CE_Glow As MyControls.ColorEditorButton
    Friend WithEvents pShadow As MyControls.MyPanel
    Friend WithEvents TB_SFeather As MyControls.MyTrackBar
    Friend WithEvents Label55 As Label
    Friend WithEvents TB_SBlur As MyControls.MyTrackBar
    Friend WithEvents Label56 As Label
    Friend WithEvents cb_fill As CheckBox
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents CE_Shadow As MyControls.ColorEditorButton
    Friend WithEvents cb_clip As CheckBox
    Friend WithEvents PS_Shadow As MyControls.PointSelector
    Friend WithEvents cb_EGlow As CheckBox
    Friend WithEvents Label57 As Label
    Friend WithEvents cb_EShadow As CheckBox
End Class
