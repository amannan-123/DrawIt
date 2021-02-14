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
		Me.pChild = New MyControls.MyPanel()
		Me.SuspendLayout()
		'
		'pChild
		'
		Me.pChild.Location = New System.Drawing.Point(0, 0)
		Me.pChild.Name = "pChild"
		Me.pChild.Size = New System.Drawing.Size(133, 150)
		Me.pChild.TabIndex = 0
		'
		'ColorListBox
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoScroll = True
		Me.Controls.Add(Me.pChild)
		Me.ForeColor = System.Drawing.Color.White
		Me.Name = "ColorListBox"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents pChild As MyPanel
End Class
