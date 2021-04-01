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
		Me.MovablePanel1 = New MyControls.MovablePanel()
		Me.MyVScrollBar1 = New MyControls.MyVScrollBar()
		Me.FlatButton1 = New MyControls.FlatButton()
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
		'MovablePanel1
		'
		Me.MovablePanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
		Me.MovablePanel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MovablePanel1.ForeColor = System.Drawing.Color.White
		Me.MovablePanel1.Location = New System.Drawing.Point(305, 35)
		Me.MovablePanel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.MovablePanel1.Name = "MovablePanel1"
		Me.MovablePanel1.Size = New System.Drawing.Size(200, 250)
		Me.MovablePanel1.TabIndex = 4
		Me.MovablePanel1.Text = "MovablePanel1"
		'
		'MyVScrollBar1
		'
		Me.MyVScrollBar1.Location = New System.Drawing.Point(656, 12)
		Me.MyVScrollBar1.Name = "MyVScrollBar1"
		Me.MyVScrollBar1.Size = New System.Drawing.Size(15, 97)
		Me.MyVScrollBar1.TabIndex = 3
		'
		'FlatButton1
		'
		Me.FlatButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FlatButton1.Icon = Nothing
		Me.FlatButton1.Location = New System.Drawing.Point(196, 35)
		Me.FlatButton1.Margin = New System.Windows.Forms.Padding(0)
		Me.FlatButton1.MyText = "FlatButton"
		Me.FlatButton1.Name = "FlatButton1"
		Me.FlatButton1.Size = New System.Drawing.Size(105, 32)
		Me.FlatButton1.TabIndex = 2
		'
		'ColorListBox1
		'
		Me.ColorListBox1.DrawingMode = MyControls.ColorListBox.DrawMode.Custom
		Me.ColorListBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ColorListBox1.ForeColor = System.Drawing.Color.White
		Me.ColorListBox1.ItemHeight = 25
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)))
		Me.ColorListBox1.Items.Add(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)))
		Me.ColorListBox1.Location = New System.Drawing.Point(12, 35)
		Me.ColorListBox1.Name = "ColorListBox1"
		Me.ColorListBox1.SelectedIndex = -1
		Me.ColorListBox1.Size = New System.Drawing.Size(181, 164)
		Me.ColorListBox1.TabIndex = 1
		'
		'TestForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(683, 307)
		Me.Controls.Add(Me.MovablePanel1)
		Me.Controls.Add(Me.MyVScrollBar1)
		Me.Controls.Add(Me.FlatButton1)
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
	Friend WithEvents FlatButton1 As MyControls.FlatButton
	Friend WithEvents MyVScrollBar1 As MyControls.MyVScrollBar
	Friend WithEvents MovablePanel1 As MyControls.MovablePanel
End Class
