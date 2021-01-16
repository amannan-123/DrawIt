<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CornersDialog
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
        Me.T_TL = New MyControls.MyTrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C_TL = New System.Windows.Forms.ComboBox()
        Me.T_TR = New MyControls.MyTrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C_TR = New System.Windows.Forms.ComboBox()
        Me.T_BL = New MyControls.MyTrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.C_BL = New System.Windows.Forms.ComboBox()
        Me.T_BR = New MyControls.MyTrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.C_BR = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'T_TL
        '
        Me.T_TL.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_TL.Factors = New Single() {0!, 1.0!}
        Me.T_TL.Location = New System.Drawing.Point(12, 25)
        Me.T_TL.Name = "T_TL"
        Me.T_TL.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_TL.Size = New System.Drawing.Size(184, 20)
        Me.T_TL.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "TopLeft:"
        '
        'C_TL
        '
        Me.C_TL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_TL.FormattingEnabled = True
        Me.C_TL.Location = New System.Drawing.Point(202, 24)
        Me.C_TL.Name = "C_TL"
        Me.C_TL.Size = New System.Drawing.Size(101, 21)
        Me.C_TL.TabIndex = 6
        '
        'T_TR
        '
        Me.T_TR.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_TR.Factors = New Single() {0!, 1.0!}
        Me.T_TR.Location = New System.Drawing.Point(12, 64)
        Me.T_TR.Name = "T_TR"
        Me.T_TR.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_TR.Size = New System.Drawing.Size(184, 20)
        Me.T_TR.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "TopRight:"
        '
        'C_TR
        '
        Me.C_TR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_TR.FormattingEnabled = True
        Me.C_TR.Location = New System.Drawing.Point(202, 63)
        Me.C_TR.Name = "C_TR"
        Me.C_TR.Size = New System.Drawing.Size(101, 21)
        Me.C_TR.TabIndex = 6
        '
        'T_BL
        '
        Me.T_BL.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_BL.Factors = New Single() {0!, 1.0!}
        Me.T_BL.Location = New System.Drawing.Point(12, 103)
        Me.T_BL.Name = "T_BL"
        Me.T_BL.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_BL.Size = New System.Drawing.Size(184, 20)
        Me.T_BL.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "BottomLeft"
        '
        'C_BL
        '
        Me.C_BL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_BL.FormattingEnabled = True
        Me.C_BL.Location = New System.Drawing.Point(202, 102)
        Me.C_BL.Name = "C_BL"
        Me.C_BL.Size = New System.Drawing.Size(101, 21)
        Me.C_BL.TabIndex = 6
        '
        'T_BR
        '
        Me.T_BR.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.T_BR.Factors = New Single() {0!, 1.0!}
        Me.T_BR.Location = New System.Drawing.Point(12, 142)
        Me.T_BR.Name = "T_BR"
        Me.T_BR.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.T_BR.Size = New System.Drawing.Size(184, 20)
        Me.T_BR.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "BottomRight:"
        '
        'C_BR
        '
        Me.C_BR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.C_BR.FormattingEnabled = True
        Me.C_BR.Location = New System.Drawing.Point(202, 141)
        Me.C_BR.Name = "C_BR"
        Me.C_BR.Size = New System.Drawing.Size(101, 21)
        Me.C_BR.TabIndex = 6
        '
        'CornersDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 176)
        Me.Controls.Add(Me.C_BR)
        Me.Controls.Add(Me.C_BL)
        Me.Controls.Add(Me.C_TR)
        Me.Controls.Add(Me.C_TL)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_BR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_BL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_TR)
        Me.Controls.Add(Me.T_TL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CornersDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CornersDialog"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T_TL As MyControls.MyTrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents C_TL As ComboBox
    Friend WithEvents T_TR As MyControls.MyTrackBar
    Friend WithEvents Label2 As Label
    Friend WithEvents C_TR As ComboBox
    Friend WithEvents T_BL As MyControls.MyTrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents C_BL As ComboBox
    Friend WithEvents T_BR As MyControls.MyTrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents C_BR As ComboBox
End Class
