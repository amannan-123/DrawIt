<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ColorBlendEditor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Sort = New System.Windows.Forms.CheckBox()
        Me.B_Clear = New System.Windows.Forms.Button()
        Me.B_Balance = New System.Windows.Forms.Button()
        Me.BL_Pos = New MyControls.MyTrackBar()
        Me.CE_Button = New MyControls.ColorEditorButton()
        Me.B_Reverse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(3, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Position:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Location = New System.Drawing.Point(3, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Color:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Sort
        '
        Me.CB_Sort.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CB_Sort.AutoSize = True
        Me.CB_Sort.Checked = True
        Me.CB_Sort.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_Sort.Location = New System.Drawing.Point(6, 137)
        Me.CB_Sort.Name = "CB_Sort"
        Me.CB_Sort.Size = New System.Drawing.Size(73, 17)
        Me.CB_Sort.TabIndex = 3
        Me.CB_Sort.Text = "Sort Items"
        Me.CB_Sort.UseVisualStyleBackColor = True
        '
        'B_Clear
        '
        Me.B_Clear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.B_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Clear.Location = New System.Drawing.Point(203, 133)
        Me.B_Clear.Name = "B_Clear"
        Me.B_Clear.Size = New System.Drawing.Size(41, 23)
        Me.B_Clear.TabIndex = 4
        Me.B_Clear.Text = "Clear"
        Me.B_Clear.UseVisualStyleBackColor = True
        '
        'B_Balance
        '
        Me.B_Balance.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.B_Balance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Balance.Location = New System.Drawing.Point(146, 133)
        Me.B_Balance.Name = "B_Balance"
        Me.B_Balance.Size = New System.Drawing.Size(56, 23)
        Me.B_Balance.TabIndex = 4
        Me.B_Balance.Text = "Balance"
        Me.B_Balance.UseVisualStyleBackColor = True
        '
        'BL_Pos
        '
        Me.BL_Pos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.BL_Pos.Colors = New System.Drawing.Color() {System.Drawing.Color.SkyBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SkyBlue}
        Me.BL_Pos.Location = New System.Drawing.Point(60, 85)
        Me.BL_Pos.Name = "BL_Pos"
        Me.BL_Pos.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.BL_Pos.Size = New System.Drawing.Size(184, 20)
        Me.BL_Pos.TabIndex = 1
        '
        'CE_Button
        '
        Me.CE_Button.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CE_Button.Location = New System.Drawing.Point(60, 111)
        Me.CE_Button.MyText = "ChooseColor"
        Me.CE_Button.Name = "CE_Button"
        Me.CE_Button.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CE_Button.Size = New System.Drawing.Size(184, 20)
        Me.CE_Button.TabIndex = 0
        '
        'B_Reverse
        '
        Me.B_Reverse.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.B_Reverse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_Reverse.Location = New System.Drawing.Point(83, 133)
        Me.B_Reverse.Name = "B_Reverse"
        Me.B_Reverse.Size = New System.Drawing.Size(62, 23)
        Me.B_Reverse.TabIndex = 4
        Me.B_Reverse.Text = "Reverse"
        Me.B_Reverse.UseVisualStyleBackColor = True
        '
        'ColorBlendEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.B_Reverse)
        Me.Controls.Add(Me.B_Balance)
        Me.Controls.Add(Me.B_Clear)
        Me.Controls.Add(Me.BL_Pos)
        Me.Controls.Add(Me.CE_Button)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_Sort)
        Me.MinimumSize = New System.Drawing.Size(250, 160)
        Me.Name = "ColorBlendEditor"
        Me.Size = New System.Drawing.Size(250, 160)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CE_Button As ColorEditorButton
    Friend WithEvents BL_Pos As MyTrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_Sort As System.Windows.Forms.CheckBox
    Friend WithEvents B_Clear As System.Windows.Forms.Button
    Friend WithEvents B_Balance As System.Windows.Forms.Button
    Friend WithEvents B_Reverse As System.Windows.Forms.Button
End Class
