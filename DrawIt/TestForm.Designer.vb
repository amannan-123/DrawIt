<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
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
		Me.CheckBox1 = New System.Windows.Forms.CheckBox()
		Me.CornersEditor1 = New MyControls.CornersEditor()
		Me.ColorListBox1 = New MyControls.ColorListBox()
		Me.ColorBlendEditor1 = New MyControls.ColorBlendEditor()
		Me.SuspendLayout()
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = True
		Me.CheckBox1.ForeColor = System.Drawing.Color.Red
		Me.CheckBox1.Location = New System.Drawing.Point(14, 14)
		Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(47, 19)
		Me.CheckBox1.TabIndex = 0
		Me.CheckBox1.Text = "Blur"
		Me.CheckBox1.UseVisualStyleBackColor = True
		'
		'CornersEditor1
		'
		Me.CornersEditor1.BackColor = System.Drawing.Color.White
		Me.CornersEditor1.BLReversed = False
		Me.CornersEditor1.BRReversed = False
		Me.CornersEditor1.Corners = New Single() {25.0!, 25.0!, 25.0!, 25.0!, 75.0!, 75.0!, 75.0!, 75.0!}
		Me.CornersEditor1.Location = New System.Drawing.Point(453, 14)
		Me.CornersEditor1.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
		Me.CornersEditor1.Name = "CornersEditor1"
		Me.CornersEditor1.Size = New System.Drawing.Size(112, 98)
		Me.CornersEditor1.TabIndex = 2
		Me.CornersEditor1.ULReversed = False
		Me.CornersEditor1.URReversed = False
		'
		'ColorListBox1
		'
		Me.ColorListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.ColorListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
		Me.ColorListBox1.ForeColor = System.Drawing.Color.White
		Me.ColorListBox1.ItemHeight = 25
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(99, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Location = New System.Drawing.Point(72, 14)
		Me.ColorListBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.ColorListBox1.Name = "ColorListBox1"
		Me.ColorListBox1.Size = New System.Drawing.Size(177, 192)
		Me.ColorListBox1.TabIndex = 1
		'
		'ColorBlendEditor1
		'
		Me.ColorBlendEditor1.BackColor = System.Drawing.Color.White
		Me.ColorBlendEditor1.Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.Black}
		Me.ColorBlendEditor1.Location = New System.Drawing.Point(315, 158)
		Me.ColorBlendEditor1.MinimumSize = New System.Drawing.Size(250, 160)
		Me.ColorBlendEditor1.Name = "ColorBlendEditor1"
		Me.ColorBlendEditor1.Positions = New Single() {0!, 1.0!}
		Me.ColorBlendEditor1.Size = New System.Drawing.Size(250, 160)
		Me.ColorBlendEditor1.TabIndex = 3
		'
		'TestForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Black
		Me.ClientSize = New System.Drawing.Size(797, 354)
		Me.Controls.Add(Me.ColorBlendEditor1)
		Me.Controls.Add(Me.CornersEditor1)
		Me.Controls.Add(Me.ColorListBox1)
		Me.Controls.Add(Me.CheckBox1)
		Me.DoubleBuffered = True
		Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.Name = "TestForm"
		Me.Text = "TestForm"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents CheckBox1 As CheckBox
	Friend WithEvents ColorListBox1 As MyControls.ColorListBox
	Friend WithEvents CornersEditor1 As MyControls.CornersEditor
	Friend WithEvents ColorBlendEditor1 As MyControls.ColorBlendEditor
End Class
