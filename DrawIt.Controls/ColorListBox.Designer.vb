<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ColorListBox
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
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
		Me.MyVScrollBar1 = New Controls.MyVScrollBar()
		Me.SuspendLayout()
		'
		'MyVScrollBar1
		'
		Me.MyVScrollBar1.Dock = System.Windows.Forms.DockStyle.Right
		Me.MyVScrollBar1.Location = New System.Drawing.Point(135, 0)
		Me.MyVScrollBar1.MinimumSize = New System.Drawing.Size(0, 45)
		Me.MyVScrollBar1.Name = "MyVScrollBar1"
		Me.MyVScrollBar1.Size = New System.Drawing.Size(15, 150)
		Me.MyVScrollBar1.SmallChange = 5
		Me.MyVScrollBar1.TabIndex = 0
		Me.MyVScrollBar1.TabStop = False
		'
		'ColorListBox
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
		Me.Controls.Add(Me.MyVScrollBar1)
		Me.ForeColor = System.Drawing.Color.White
		Me.Name = "ColorListBox"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents MyVScrollBar1 As MyVScrollBar
End Class
