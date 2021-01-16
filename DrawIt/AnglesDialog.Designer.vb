<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnglesDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_Sweep = New MyControls.MyTrackBar()
        Me.T_Start = New MyControls.MyTrackBar()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sweep Angle:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Start Angle:"
        '
        'T_Sweep
        '
        Me.T_Sweep.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_Sweep.Factors = New Single() {0!, 1.0!}
        Me.T_Sweep.Location = New System.Drawing.Point(6, 64)
        Me.T_Sweep.Maximum = 360.0!
        Me.T_Sweep.Name = "T_Sweep"
        Me.T_Sweep.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_Sweep.Size = New System.Drawing.Size(207, 20)
        Me.T_Sweep.TabIndex = 6
        Me.T_Sweep.Value = 270.0!
        '
        'T_Start
        '
        Me.T_Start.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_Start.Factors = New Single() {0!, 1.0!}
        Me.T_Start.Location = New System.Drawing.Point(6, 25)
        Me.T_Start.Maximum = 360.0!
        Me.T_Start.Name = "T_Start"
        Me.T_Start.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_Start.Size = New System.Drawing.Size(207, 20)
        Me.T_Start.TabIndex = 7
        '
        'AnglesDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 95)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_Sweep)
        Me.Controls.Add(Me.T_Start)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AnglesDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AnglesDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents T_Sweep As MyControls.MyTrackBar
    Friend WithEvents T_Start As MyControls.MyTrackBar
End Class
