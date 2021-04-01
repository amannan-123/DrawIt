<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CanvasControl
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
		Me.baseCanvas = New DrawIt.Canvas()
		Me.SuspendLayout()
		'
		'baseCanvas
		'
		Me.baseCanvas.BackColor = System.Drawing.Color.Transparent
		Me.baseCanvas.FResizing = False
		Me.baseCanvas.Location = New System.Drawing.Point(0, 0)
		Me.baseCanvas.MainForm = Nothing
		Me.baseCanvas.Margin = New System.Windows.Forms.Padding(0)
		Me.baseCanvas.Name = "baseCanvas"
		Me.baseCanvas.Size = New System.Drawing.Size(300, 300)
		Me.baseCanvas.TabIndex = 2
		'
		'CanvasControl
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.AutoScroll = True
		Me.Controls.Add(Me.baseCanvas)
		Me.DoubleBuffered = True
		Me.Margin = New System.Windows.Forms.Padding(0)
		Me.Name = "CanvasControl"
		Me.Size = New System.Drawing.Size(316, 316)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents baseCanvas As Canvas
End Class
