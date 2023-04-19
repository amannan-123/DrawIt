<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MyHScrollBar
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
		Me.components = New System.ComponentModel.Container()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'Timer1
		'
		Me.Timer1.Interval = 500
		'
		'MyHScrollBar
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.Name = "MyHScrollBar"
		Me.Size = New System.Drawing.Size(173, 20)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
