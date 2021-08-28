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
		Me.SuspendLayout()
		'
		'CheckBox1
		'
		Me.CheckBox1.AutoSize = True
		Me.CheckBox1.ForeColor = System.Drawing.Color.Red
		Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
		Me.CheckBox1.Name = "CheckBox1"
		Me.CheckBox1.Size = New System.Drawing.Size(44, 17)
		Me.CheckBox1.TabIndex = 0
		Me.CheckBox1.Text = "Blur"
		Me.CheckBox1.UseVisualStyleBackColor = True
		'
		'ColorListBox1
		'
		Me.ColorListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
		Me.ColorListBox1.ForeColor = System.Drawing.Color.White
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Location = New System.Drawing.Point(129, 63)
		Me.ColorListBox1.Name = "ColorListBox1"
		Me.ColorListBox1.Size = New System.Drawing.Size(186, 185)
		Me.ColorListBox1.TabIndex = 1
		'
		'TestForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(683, 307)
		Me.Controls.Add(Me.ColorListBox1)
		Me.Controls.Add(Me.CheckBox1)
		Me.DoubleBuffered = True
		Me.Name = "TestForm"
		Me.Text = "TestForm"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents CheckBox1 As CheckBox
	Friend WithEvents ColorListBox1 As MyControls.ColorListBox
End Class
