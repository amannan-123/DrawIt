<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CanvasControl
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
		Me.baseCanvas = New DrawIt.Canvas()
		Me.basePnl = New System.Windows.Forms.Panel()
		Me.VScrollBar = New MyControls.MyVScrollBar()
		Me.HScrollBar = New MyControls.MyHScrollBar()
		Me.basePnl.SuspendLayout()
		Me.SuspendLayout()
		'
		'baseCanvas
		'
		Me.baseCanvas.AbsSize = New System.Drawing.Size(500.0!, 500.0!)
		Me.baseCanvas.BackColor = System.Drawing.Color.White
		Me.baseCanvas.Location = New System.Drawing.Point(0, 0)
		Me.baseCanvas.Margin = New System.Windows.Forms.Padding(0)
		Me.baseCanvas.Name = "baseCanvas"
		Me.baseCanvas.Size = New System.Drawing.Size(500, 500)
		Me.baseCanvas.TabIndex = 2
		Me.baseCanvas.Zoom = 1.0!
		'
		'basePnl
		'
		Me.basePnl.Controls.Add(Me.baseCanvas)
		Me.basePnl.Location = New System.Drawing.Point(0, 0)
		Me.basePnl.Name = "basePnl"
		Me.basePnl.Size = New System.Drawing.Size(500, 500)
		Me.basePnl.TabIndex = 3
		'
		'VScrollBar
		'
		Me.VScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.VScrollBar.Location = New System.Drawing.Point(500, 0)
		Me.VScrollBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.VScrollBar.MinimumSize = New System.Drawing.Size(0, 45)
		Me.VScrollBar.Name = "VScrollBar"
		Me.VScrollBar.Size = New System.Drawing.Size(20, 500)
		Me.VScrollBar.SmallChange = 5
		Me.VScrollBar.TabIndex = 4
		Me.VScrollBar.TabStop = False
		'
		'HScrollBar
		'
		Me.HScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.HScrollBar.Location = New System.Drawing.Point(0, 500)
		Me.HScrollBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.HScrollBar.Name = "HScrollBar"
		Me.HScrollBar.Size = New System.Drawing.Size(500, 20)
		Me.HScrollBar.TabIndex = 0
		'
		'CanvasControl
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.Controls.Add(Me.HScrollBar)
		Me.Controls.Add(Me.VScrollBar)
		Me.Controls.Add(Me.basePnl)
		Me.DoubleBuffered = True
		Me.Margin = New System.Windows.Forms.Padding(0)
		Me.Name = "CanvasControl"
		Me.Size = New System.Drawing.Size(520, 520)
		Me.basePnl.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents baseCanvas As Canvas
	Friend WithEvents basePnl As Panel
	Friend WithEvents VScrollBar As MyControls.MyVScrollBar
	Friend WithEvents HScrollBar As MyControls.MyHScrollBar
End Class
