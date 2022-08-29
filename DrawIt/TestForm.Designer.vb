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
		Me.ColorListBox1 = New MyControls.ColorListBox()
		Me.MyVScrollBar1 = New MyControls.MyHScrollBar()
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
		'MyVScrollBar1
		'
		Me.MyVScrollBar1.Location = New System.Drawing.Point(323, 112)
		Me.MyVScrollBar1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.MyVScrollBar1.Maximum = 10000
		Me.MyVScrollBar1.Name = "MyVScrollBar1"
		Me.MyVScrollBar1.Size = New System.Drawing.Size(368, 25)
		Me.MyVScrollBar1.TabIndex = 0
		'
		'TestForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(797, 354)
		Me.Controls.Add(Me.MyVScrollBar1)
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
	Friend WithEvents MyVScrollBar1 As MyControls.MyHScrollBar
End Class
