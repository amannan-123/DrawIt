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
		Me.MyTabControl1 = New MyControls.MyTabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.TabPage3 = New System.Windows.Forms.TabPage()
		Me.TabPage4 = New System.Windows.Forms.TabPage()
		Me.MyTabControl1.SuspendLayout()
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
		Me.ColorListBox1.AutoScroll = True
		Me.ColorListBox1.ForeColor = System.Drawing.Color.White
		Me.ColorListBox1.Items.Add(System.Drawing.Color.Empty)
		Me.ColorListBox1.Items.Add(System.Drawing.Color.Empty)
		Me.ColorListBox1.Items.Add(System.Drawing.Color.Empty)
		Me.ColorListBox1.Items.Add(System.Drawing.Color.Empty)
		Me.ColorListBox1.Location = New System.Drawing.Point(12, 35)
		Me.ColorListBox1.Name = "ColorListBox1"
		Me.ColorListBox1.SelectedIndex = -1
		Me.ColorListBox1.Size = New System.Drawing.Size(109, 256)
		Me.ColorListBox1.TabIndex = 1
		'
		'MyTabControl1
		'
		Me.MyTabControl1.Controls.Add(Me.TabPage1)
		Me.MyTabControl1.Controls.Add(Me.TabPage3)
		Me.MyTabControl1.Controls.Add(Me.TabPage4)
		Me.MyTabControl1.Location = New System.Drawing.Point(179, 35)
		Me.MyTabControl1.Name = "MyTabControl1"
		Me.MyTabControl1.SelectedIndex = 0
		Me.MyTabControl1.Size = New System.Drawing.Size(364, 224)
		Me.MyTabControl1.TabIndex = 2
		'
		'TabPage1
		'
		Me.TabPage1.Location = New System.Drawing.Point(4, 25)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(356, 195)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "TabPage1"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'TabPage3
		'
		Me.TabPage3.Location = New System.Drawing.Point(4, 25)
		Me.TabPage3.Name = "TabPage3"
		Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage3.Size = New System.Drawing.Size(356, 195)
		Me.TabPage3.TabIndex = 2
		Me.TabPage3.Text = "TabPage3"
		Me.TabPage3.UseVisualStyleBackColor = True
		'
		'TabPage4
		'
		Me.TabPage4.Location = New System.Drawing.Point(4, 25)
		Me.TabPage4.Name = "TabPage4"
		Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage4.Size = New System.Drawing.Size(356, 195)
		Me.TabPage4.TabIndex = 3
		Me.TabPage4.Text = "TabPage4"
		Me.TabPage4.UseVisualStyleBackColor = True
		'
		'TestForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(683, 307)
		Me.Controls.Add(Me.MyTabControl1)
		Me.Controls.Add(Me.ColorListBox1)
		Me.Controls.Add(Me.CheckBox1)
		Me.Name = "TestForm"
		Me.Text = "TestForm"
		Me.MyTabControl1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents CheckBox1 As CheckBox
	Friend WithEvents ColorListBox1 As MyControls.ColorListBox
	Friend WithEvents MyTabControl1 As MyControls.MyTabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents TabPage3 As TabPage
	Friend WithEvents TabPage4 As TabPage
End Class
