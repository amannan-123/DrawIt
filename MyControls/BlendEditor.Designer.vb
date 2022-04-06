<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BlendEditor
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
		Me.B_Reverse = New MyControls.MyButton()
		Me.B_Balance = New MyControls.MyButton()
		Me.B_Clear = New MyControls.MyButton()
		Me.BL_Fac = New MyControls.MyTrackBar()
		Me.BL_Pos = New MyControls.MyTrackBar()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Label1.Location = New System.Drawing.Point(3, 85)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(51, 20)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Position:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Label2.Location = New System.Drawing.Point(3, 111)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(51, 20)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Factor:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'CB_Sort
		'
		Me.CB_Sort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.CB_Sort.AutoSize = True
		Me.CB_Sort.Checked = True
		Me.CB_Sort.CheckState = System.Windows.Forms.CheckState.Checked
		Me.CB_Sort.Location = New System.Drawing.Point(5, 137)
		Me.CB_Sort.Name = "CB_Sort"
		Me.CB_Sort.Size = New System.Drawing.Size(79, 19)
		Me.CB_Sort.TabIndex = 2
		Me.CB_Sort.Text = "Sort Items"
		Me.CB_Sort.UseVisualStyleBackColor = True
		'
		'B_Reverse
		'
		Me.B_Reverse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.B_Reverse.BackColor = System.Drawing.Color.White
		Me.B_Reverse.DrawBorder = True
		Me.B_Reverse.DrawEffect = False
		Me.B_Reverse.ForeColor = System.Drawing.Color.Black
		Me.B_Reverse.Location = New System.Drawing.Point(97, 135)
		Me.B_Reverse.MyText = "Reverse"
		Me.B_Reverse.Name = "B_Reverse"
		Me.B_Reverse.Size = New System.Drawing.Size(47, 23)
		Me.B_Reverse.TabIndex = 3
		'
		'B_Balance
		'
		Me.B_Balance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.B_Balance.BackColor = System.Drawing.Color.White
		Me.B_Balance.DrawBorder = True
		Me.B_Balance.DrawEffect = False
		Me.B_Balance.ForeColor = System.Drawing.Color.Black
		Me.B_Balance.Location = New System.Drawing.Point(145, 135)
		Me.B_Balance.MyText = "Balance"
		Me.B_Balance.Name = "B_Balance"
		Me.B_Balance.Size = New System.Drawing.Size(56, 23)
		Me.B_Balance.TabIndex = 4
		'
		'B_Clear
		'
		Me.B_Clear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.B_Clear.BackColor = System.Drawing.Color.White
		Me.B_Clear.DrawBorder = True
		Me.B_Clear.DrawEffect = False
		Me.B_Clear.ForeColor = System.Drawing.Color.Black
		Me.B_Clear.Location = New System.Drawing.Point(202, 135)
		Me.B_Clear.MyText = "Clear"
		Me.B_Clear.Name = "B_Clear"
		Me.B_Clear.Size = New System.Drawing.Size(36, 23)
		Me.B_Clear.TabIndex = 5
		'
		'BL_Fac
		'
		Me.BL_Fac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.BL_Fac.Colors = New System.Drawing.Color() {System.Drawing.Color.White, System.Drawing.Color.Black}
		Me.BL_Fac.Factors = New Single() {0!, 1.0!}
		Me.BL_Fac.Location = New System.Drawing.Point(60, 111)
		Me.BL_Fac.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.BL_Fac.Name = "BL_Fac"
		Me.BL_Fac.Positions = New Single() {0!, 1.0!}
		Me.BL_Fac.Size = New System.Drawing.Size(174, 20)
		Me.BL_Fac.TabIndex = 1
		'
		'BL_Pos
		'
		Me.BL_Pos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.BL_Pos.Colors = New System.Drawing.Color() {System.Drawing.Color.SkyBlue, System.Drawing.Color.DodgerBlue, System.Drawing.Color.SkyBlue}
		Me.BL_Pos.Factors = New Single() {0!, 1.0!}
		Me.BL_Pos.Location = New System.Drawing.Point(60, 85)
		Me.BL_Pos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.BL_Pos.Name = "BL_Pos"
		Me.BL_Pos.Positions = New Single() {0!, 1.0!}
		Me.BL_Pos.Size = New System.Drawing.Size(174, 20)
		Me.BL_Pos.TabIndex = 0
		Me.BL_Pos.Type = MyControls.MyTrackBar.BlendType.Blend
		'
		'BlendEditor
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.Controls.Add(Me.B_Reverse)
		Me.Controls.Add(Me.B_Balance)
		Me.Controls.Add(Me.B_Clear)
		Me.Controls.Add(Me.BL_Fac)
		Me.Controls.Add(Me.BL_Pos)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.CB_Sort)
		Me.MinimumSize = New System.Drawing.Size(240, 160)
		Me.Name = "BlendEditor"
		Me.Size = New System.Drawing.Size(240, 160)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents BL_Pos As MyTrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB_Sort As System.Windows.Forms.CheckBox
    Friend WithEvents BL_Fac As MyTrackBar
    Friend WithEvents B_Reverse As MyButton
    Friend WithEvents B_Balance As MyButton
    Friend WithEvents B_Clear As MyButton
End Class
