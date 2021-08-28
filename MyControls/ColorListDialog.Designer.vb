<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ColorListDialog
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
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.lstColors = New MyControls.ColorListBox()
		Me.b_Down = New MyControls.MyButton()
		Me.b_Up = New MyControls.MyButton()
		Me.b_Remove = New MyControls.MyButton()
		Me.b_Add = New MyControls.MyButton()
		Me.CE_Button = New MyControls.ColorEditorButton()
		Me.SuspendLayout()
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.OK_Button.Location = New System.Drawing.Point(102, 256)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(67, 23)
		Me.OK_Button.TabIndex = 6
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(175, 256)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
		Me.Cancel_Button.TabIndex = 7
		Me.Cancel_Button.Text = "Cancel"
		'
		'lstColors
		'
		Me.lstColors.AutoScroll = True
		Me.lstColors.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
		Me.lstColors.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstColors.ForeColor = System.Drawing.Color.White
		Me.lstColors.ItemHeight = 25
		Me.lstColors.Location = New System.Drawing.Point(12, 12)
		Me.lstColors.Name = "lstColors"
		Me.lstColors.Size = New System.Drawing.Size(230, 166)
		Me.lstColors.TabIndex = 8
		'
		'b_Down
		'
		Me.b_Down.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.b_Down.BackColor = System.Drawing.Color.White
		Me.b_Down.DrawBorder = True
		Me.b_Down.DrawEffect = False
		Me.b_Down.ForeColor = System.Drawing.Color.Black
		Me.b_Down.Location = New System.Drawing.Point(185, 215)
		Me.b_Down.MyText = "Down"
		Me.b_Down.Name = "b_Down"
		Me.b_Down.Size = New System.Drawing.Size(57, 26)
		Me.b_Down.TabIndex = 5
		'
		'b_Up
		'
		Me.b_Up.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.b_Up.BackColor = System.Drawing.Color.White
		Me.b_Up.DrawBorder = True
		Me.b_Up.DrawEffect = False
		Me.b_Up.ForeColor = System.Drawing.Color.Black
		Me.b_Up.Location = New System.Drawing.Point(134, 215)
		Me.b_Up.MyText = "Up"
		Me.b_Up.Name = "b_Up"
		Me.b_Up.Size = New System.Drawing.Size(45, 26)
		Me.b_Up.TabIndex = 4
		'
		'b_Remove
		'
		Me.b_Remove.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.b_Remove.BackColor = System.Drawing.Color.White
		Me.b_Remove.DrawBorder = True
		Me.b_Remove.DrawEffect = False
		Me.b_Remove.ForeColor = System.Drawing.Color.Black
		Me.b_Remove.Location = New System.Drawing.Point(71, 215)
		Me.b_Remove.MyText = "Remove"
		Me.b_Remove.Name = "b_Remove"
		Me.b_Remove.Size = New System.Drawing.Size(57, 26)
		Me.b_Remove.TabIndex = 3
		'
		'b_Add
		'
		Me.b_Add.Anchor = System.Windows.Forms.AnchorStyles.Bottom
		Me.b_Add.BackColor = System.Drawing.Color.White
		Me.b_Add.DrawBorder = True
		Me.b_Add.DrawEffect = False
		Me.b_Add.ForeColor = System.Drawing.Color.Black
		Me.b_Add.Location = New System.Drawing.Point(12, 215)
		Me.b_Add.MyText = "Add"
		Me.b_Add.Name = "b_Add"
		Me.b_Add.Size = New System.Drawing.Size(53, 26)
		Me.b_Add.TabIndex = 2
		'
		'CE_Button
		'
		Me.CE_Button.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.CE_Button.Location = New System.Drawing.Point(12, 184)
		Me.CE_Button.MyText = "ChooseColor"
		Me.CE_Button.Name = "CE_Button"
		Me.CE_Button.SelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CE_Button.Size = New System.Drawing.Size(230, 25)
		Me.CE_Button.TabIndex = 1
		'
		'ColorListDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(254, 291)
		Me.Controls.Add(Me.lstColors)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.b_Down)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.b_Up)
		Me.Controls.Add(Me.b_Remove)
		Me.Controls.Add(Me.b_Add)
		Me.Controls.Add(Me.CE_Button)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ColorListDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "ColorListDialog"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents CE_Button As ColorEditorButton
	Friend WithEvents b_Add As MyButton
	Friend WithEvents b_Remove As MyButton
	Friend WithEvents b_Up As MyButton
	Friend WithEvents b_Down As MyButton
	Friend WithEvents lstColors As ColorListBox
End Class
