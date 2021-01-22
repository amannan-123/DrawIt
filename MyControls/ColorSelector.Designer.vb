<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cb_Colors = New System.Windows.Forms.ComboBox()
        Me.MyPanel2 = New MyControls.MyPanel()
        Me.Button2 = New MyControls.MyButton()
        Me.Button1 = New MyControls.MyButton()
        Me.t_Hex = New System.Windows.Forms.TextBox()
        Me.t_alpha = New MyControls.MyTrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MyPanel3 = New MyControls.MyPanel()
        Me.r_hsb = New System.Windows.Forms.RadioButton()
        Me.r_hsl = New System.Windows.Forms.RadioButton()
        Me.r_rgb = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.p_rgb = New MyControls.MyPanel()
        Me.t_blue = New MyControls.MyTrackBar()
        Me.t_green = New MyControls.MyTrackBar()
        Me.t_red = New MyControls.MyTrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.p_hsl = New MyControls.MyPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.t_lum = New MyControls.MyTrackBar()
        Me.t_sat1 = New MyControls.MyTrackBar()
        Me.t_hue1 = New MyControls.MyTrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.p_hsb = New MyControls.MyPanel()
        Me.t_bri = New MyControls.MyTrackBar()
        Me.t_sat2 = New MyControls.MyTrackBar()
        Me.t_hue2 = New MyControls.MyTrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MyPanel1 = New MyControls.MyPanel()
        Me.MyPanel2.SuspendLayout()
        Me.MyPanel3.SuspendLayout()
        Me.p_rgb.SuspendLayout()
        Me.p_hsl.SuspendLayout()
        Me.p_hsb.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(58, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(219, 22)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        '
        'cb_Colors
        '
        Me.cb_Colors.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cb_Colors.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_Colors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cb_Colors.DropDownHeight = 250
        Me.cb_Colors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Colors.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Colors.IntegralHeight = False
        Me.cb_Colors.ItemHeight = 20
        Me.cb_Colors.Location = New System.Drawing.Point(58, 28)
        Me.cb_Colors.MaxDropDownItems = 14
        Me.cb_Colors.Name = "cb_Colors"
        Me.cb_Colors.Size = New System.Drawing.Size(219, 26)
        Me.cb_Colors.TabIndex = 6
        '
        'MyPanel2
        '
        Me.MyPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MyPanel2.Controls.Add(Me.Button2)
        Me.MyPanel2.Controls.Add(Me.Button1)
        Me.MyPanel2.Controls.Add(Me.t_Hex)
        Me.MyPanel2.Controls.Add(Me.t_alpha)
        Me.MyPanel2.Controls.Add(Me.Label1)
        Me.MyPanel2.Controls.Add(Me.MyPanel3)
        Me.MyPanel2.Controls.Add(Me.Label11)
        Me.MyPanel2.Controls.Add(Me.p_rgb)
        Me.MyPanel2.Controls.Add(Me.p_hsl)
        Me.MyPanel2.Controls.Add(Me.p_hsb)
        Me.MyPanel2.Location = New System.Drawing.Point(2, 60)
        Me.MyPanel2.Name = "MyPanel2"
        Me.MyPanel2.Size = New System.Drawing.Size(275, 202)
        Me.MyPanel2.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.DrawBorder = True
        Me.Button2.DrawEffect = False
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(220, 169)
        Me.Button2.MyText = "Close"
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(42, 22)
        Me.Button2.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.DrawBorder = True
        Me.Button1.DrawEffect = False
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(177, 169)
        Me.Button1.MyText = "Set"
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 22)
        Me.Button1.TabIndex = 4
        '
        't_Hex
        '
        Me.t_Hex.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.t_Hex.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_Hex.Location = New System.Drawing.Point(103, 169)
        Me.t_Hex.MaxLength = 8
        Me.t_Hex.Name = "t_Hex"
        Me.t_Hex.Size = New System.Drawing.Size(70, 22)
        Me.t_Hex.TabIndex = 3
        '
        't_alpha
        '
        Me.t_alpha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.t_alpha.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_alpha.Factors = New Single() {0!, 1.0!}
        Me.t_alpha.Location = New System.Drawing.Point(62, 12)
        Me.t_alpha.Maximum = 255.0!
        Me.t_alpha.Name = "t_alpha"
        Me.t_alpha.Positions = New Single() {0!, 1.0!}
        Me.t_alpha.Size = New System.Drawing.Size(194, 20)
        Me.t_alpha.TabIndex = 0
        Me.t_alpha.Value = 255.0!
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Alpha:"
        '
        'MyPanel3
        '
        Me.MyPanel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MyPanel3.Controls.Add(Me.r_hsb)
        Me.MyPanel3.Controls.Add(Me.r_hsl)
        Me.MyPanel3.Controls.Add(Me.r_rgb)
        Me.MyPanel3.Location = New System.Drawing.Point(10, 36)
        Me.MyPanel3.Name = "MyPanel3"
        Me.MyPanel3.Size = New System.Drawing.Size(254, 23)
        Me.MyPanel3.TabIndex = 1
        '
        'r_hsb
        '
        Me.r_hsb.AutoSize = True
        Me.r_hsb.Location = New System.Drawing.Point(157, 3)
        Me.r_hsb.Name = "r_hsb"
        Me.r_hsb.Size = New System.Drawing.Size(47, 17)
        Me.r_hsb.TabIndex = 2
        Me.r_hsb.Text = "HSB"
        Me.r_hsb.UseVisualStyleBackColor = True
        '
        'r_hsl
        '
        Me.r_hsl.AutoSize = True
        Me.r_hsl.Location = New System.Drawing.Point(105, 3)
        Me.r_hsl.Name = "r_hsl"
        Me.r_hsl.Size = New System.Drawing.Size(46, 17)
        Me.r_hsl.TabIndex = 1
        Me.r_hsl.Text = "HSL"
        Me.r_hsl.UseVisualStyleBackColor = True
        '
        'r_rgb
        '
        Me.r_rgb.AutoSize = True
        Me.r_rgb.Checked = True
        Me.r_rgb.Location = New System.Drawing.Point(51, 3)
        Me.r_rgb.Name = "r_rgb"
        Me.r_rgb.Size = New System.Drawing.Size(48, 17)
        Me.r_rgb.TabIndex = 0
        Me.r_rgb.TabStop = True
        Me.r_rgb.Text = "RGB"
        Me.r_rgb.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(57, 171)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Hex:  #"
        '
        'p_rgb
        '
        Me.p_rgb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.p_rgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.p_rgb.Controls.Add(Me.t_blue)
        Me.p_rgb.Controls.Add(Me.t_green)
        Me.p_rgb.Controls.Add(Me.t_red)
        Me.p_rgb.Controls.Add(Me.Label2)
        Me.p_rgb.Controls.Add(Me.Label3)
        Me.p_rgb.Controls.Add(Me.Label4)
        Me.p_rgb.Location = New System.Drawing.Point(10, 65)
        Me.p_rgb.Name = "p_rgb"
        Me.p_rgb.Size = New System.Drawing.Size(252, 96)
        Me.p_rgb.TabIndex = 2
        '
        't_blue
        '
        Me.t_blue.AllowDecimal = False
        Me.t_blue.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_blue.Factors = New Single() {0!, 1.0!}
        Me.t_blue.Location = New System.Drawing.Point(74, 64)
        Me.t_blue.Maximum = 255.0!
        Me.t_blue.Name = "t_blue"
        Me.t_blue.Positions = New Single() {0!, 1.0!}
        Me.t_blue.Size = New System.Drawing.Size(172, 20)
        Me.t_blue.TabIndex = 2
        '
        't_green
        '
        Me.t_green.AllowDecimal = False
        Me.t_green.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_green.Factors = New Single() {0!, 1.0!}
        Me.t_green.Location = New System.Drawing.Point(74, 38)
        Me.t_green.Maximum = 255.0!
        Me.t_green.Name = "t_green"
        Me.t_green.Positions = New Single() {0!, 1.0!}
        Me.t_green.Size = New System.Drawing.Size(172, 20)
        Me.t_green.TabIndex = 1
        '
        't_red
        '
        Me.t_red.AllowDecimal = False
        Me.t_red.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_red.Factors = New Single() {0!, 1.0!}
        Me.t_red.Location = New System.Drawing.Point(74, 12)
        Me.t_red.Maximum = 255.0!
        Me.t_red.Name = "t_red"
        Me.t_red.Positions = New Single() {0!, 1.0!}
        Me.t_red.Size = New System.Drawing.Size(172, 20)
        Me.t_red.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Red:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Green:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Blue:"
        '
        'p_hsl
        '
        Me.p_hsl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.p_hsl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.p_hsl.Controls.Add(Me.Label5)
        Me.p_hsl.Controls.Add(Me.t_lum)
        Me.p_hsl.Controls.Add(Me.t_sat1)
        Me.p_hsl.Controls.Add(Me.t_hue1)
        Me.p_hsl.Controls.Add(Me.Label6)
        Me.p_hsl.Controls.Add(Me.Label7)
        Me.p_hsl.Location = New System.Drawing.Point(10, 65)
        Me.p_hsl.Name = "p_hsl"
        Me.p_hsl.Size = New System.Drawing.Size(252, 96)
        Me.p_hsl.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Hue:"
        '
        't_lum
        '
        Me.t_lum.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_lum.Factors = New Single() {0!, 1.0!}
        Me.t_lum.Location = New System.Drawing.Point(74, 64)
        Me.t_lum.Name = "t_lum"
        Me.t_lum.Positions = New Single() {0!, 1.0!}
        Me.t_lum.Size = New System.Drawing.Size(172, 20)
        Me.t_lum.TabIndex = 2
        '
        't_sat1
        '
        Me.t_sat1.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_sat1.Factors = New Single() {0!, 1.0!}
        Me.t_sat1.Location = New System.Drawing.Point(74, 38)
        Me.t_sat1.Name = "t_sat1"
        Me.t_sat1.Positions = New Single() {0!, 1.0!}
        Me.t_sat1.Size = New System.Drawing.Size(172, 20)
        Me.t_sat1.TabIndex = 1
        '
        't_hue1
        '
        Me.t_hue1.AllowDecimal = False
        Me.t_hue1.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_hue1.Factors = New Single() {0!, 1.0!}
        Me.t_hue1.Location = New System.Drawing.Point(74, 12)
        Me.t_hue1.Maximum = 359.0!
        Me.t_hue1.Name = "t_hue1"
        Me.t_hue1.Positions = New Single() {0!, 1.0!}
        Me.t_hue1.Size = New System.Drawing.Size(172, 20)
        Me.t_hue1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Saturation:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Lumination:"
        '
        'p_hsb
        '
        Me.p_hsb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.p_hsb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.p_hsb.Controls.Add(Me.t_bri)
        Me.p_hsb.Controls.Add(Me.t_sat2)
        Me.p_hsb.Controls.Add(Me.t_hue2)
        Me.p_hsb.Controls.Add(Me.Label8)
        Me.p_hsb.Controls.Add(Me.Label9)
        Me.p_hsb.Controls.Add(Me.Label10)
        Me.p_hsb.Location = New System.Drawing.Point(10, 65)
        Me.p_hsb.Name = "p_hsb"
        Me.p_hsb.Size = New System.Drawing.Size(252, 96)
        Me.p_hsb.TabIndex = 2
        '
        't_bri
        '
        Me.t_bri.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_bri.Factors = New Single() {0!, 1.0!}
        Me.t_bri.Location = New System.Drawing.Point(74, 64)
        Me.t_bri.Name = "t_bri"
        Me.t_bri.Positions = New Single() {0!, 1.0!}
        Me.t_bri.Size = New System.Drawing.Size(172, 20)
        Me.t_bri.TabIndex = 2
        '
        't_sat2
        '
        Me.t_sat2.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_sat2.Factors = New Single() {0!, 1.0!}
        Me.t_sat2.Location = New System.Drawing.Point(74, 38)
        Me.t_sat2.Name = "t_sat2"
        Me.t_sat2.Positions = New Single() {0!, 1.0!}
        Me.t_sat2.Size = New System.Drawing.Size(172, 20)
        Me.t_sat2.TabIndex = 1
        '
        't_hue2
        '
        Me.t_hue2.AllowDecimal = False
        Me.t_hue2.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
        Me.t_hue2.Factors = New Single() {0!, 1.0!}
        Me.t_hue2.Location = New System.Drawing.Point(74, 12)
        Me.t_hue2.Maximum = 359.0!
        Me.t_hue2.Name = "t_hue2"
        Me.t_hue2.Positions = New Single() {0!, 1.0!}
        Me.t_hue2.Size = New System.Drawing.Size(172, 20)
        Me.t_hue2.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Hue:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Saturation:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Brightness:"
        '
        'MyPanel1
        '
        Me.MyPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MyPanel1.Location = New System.Drawing.Point(2, 4)
        Me.MyPanel1.Name = "MyPanel1"
        Me.MyPanel1.Size = New System.Drawing.Size(50, 50)
        Me.MyPanel1.TabIndex = 4
        '
        'ColorSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MyPanel2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MyPanel1)
        Me.Controls.Add(Me.cb_Colors)
        Me.Name = "ColorSelector"
        Me.Size = New System.Drawing.Size(280, 265)
        Me.MyPanel2.ResumeLayout(False)
        Me.MyPanel2.PerformLayout()
        Me.MyPanel3.ResumeLayout(False)
        Me.MyPanel3.PerformLayout()
        Me.p_rgb.ResumeLayout(False)
        Me.p_rgb.PerformLayout()
        Me.p_hsl.ResumeLayout(False)
        Me.p_hsl.PerformLayout()
        Me.p_hsb.ResumeLayout(False)
        Me.p_hsb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MyPanel2 As MyPanel
    Friend WithEvents t_Hex As System.Windows.Forms.TextBox
    Friend WithEvents t_alpha As MyTrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MyPanel3 As MyPanel
    Friend WithEvents r_hsb As System.Windows.Forms.RadioButton
    Friend WithEvents r_hsl As System.Windows.Forms.RadioButton
    Friend WithEvents r_rgb As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents p_rgb As MyPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents t_blue As MyTrackBar
    Friend WithEvents t_green As MyTrackBar
    Friend WithEvents t_red As MyTrackBar
    Friend WithEvents p_hsl As MyPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents t_lum As MyTrackBar
    Friend WithEvents t_sat1 As MyTrackBar
    Friend WithEvents t_hue1 As MyTrackBar
    Friend WithEvents p_hsb As MyPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents t_bri As MyTrackBar
    Friend WithEvents t_sat2 As MyTrackBar
    Friend WithEvents t_hue2 As MyTrackBar
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MyPanel1 As MyPanel
    Friend WithEvents cb_Colors As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As MyButton
    Friend WithEvents Button1 As MyButton
End Class
