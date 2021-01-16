<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorListDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lstColors = New System.Windows.Forms.ListBox()
        Me.bAdd = New System.Windows.Forms.Button()
        Me.bDown = New System.Windows.Forms.Button()
        Me.bRemove = New System.Windows.Forms.Button()
        Me.bUp = New System.Windows.Forms.Button()
        Me.CE_Button = New MyControls.ColorEditorButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(96, 250)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lstColors
        '
        Me.lstColors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstColors.FormattingEnabled = True
        Me.lstColors.IntegralHeight = False
        Me.lstColors.ItemHeight = 20
        Me.lstColors.Location = New System.Drawing.Point(12, 18)
        Me.lstColors.Name = "lstColors"
        Me.lstColors.Size = New System.Drawing.Size(230, 160)
        Me.lstColors.TabIndex = 1
        '
        'bAdd
        '
        Me.bAdd.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAdd.Location = New System.Drawing.Point(12, 215)
        Me.bAdd.Name = "bAdd"
        Me.bAdd.Size = New System.Drawing.Size(53, 26)
        Me.bAdd.TabIndex = 2
        Me.bAdd.Text = "Add"
        Me.bAdd.UseVisualStyleBackColor = True
        '
        'bDown
        '
        Me.bDown.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bDown.Location = New System.Drawing.Point(185, 215)
        Me.bDown.Name = "bDown"
        Me.bDown.Size = New System.Drawing.Size(57, 26)
        Me.bDown.TabIndex = 2
        Me.bDown.Text = "Down"
        Me.bDown.UseVisualStyleBackColor = True
        '
        'bRemove
        '
        Me.bRemove.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bRemove.Location = New System.Drawing.Point(71, 215)
        Me.bRemove.Name = "bRemove"
        Me.bRemove.Size = New System.Drawing.Size(57, 26)
        Me.bRemove.TabIndex = 2
        Me.bRemove.Text = "Remove"
        Me.bRemove.UseVisualStyleBackColor = True
        '
        'bUp
        '
        Me.bUp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bUp.Location = New System.Drawing.Point(134, 215)
        Me.bUp.Name = "bUp"
        Me.bUp.Size = New System.Drawing.Size(45, 26)
        Me.bUp.TabIndex = 2
        Me.bUp.Text = "Up"
        Me.bUp.UseVisualStyleBackColor = True
        '
        'CE_Button
        '
        Me.CE_Button.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CE_Button.Location = New System.Drawing.Point(12, 184)
        Me.CE_Button.MyText = "ChooseColor"
        Me.CE_Button.Name = "CE_Button"
        Me.CE_Button.SelectedColor = System.Drawing.SystemColors.Control
        Me.CE_Button.Size = New System.Drawing.Size(230, 25)
        Me.CE_Button.TabIndex = 3
        '
        'ColorListDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(254, 291)
        Me.Controls.Add(Me.CE_Button)
        Me.Controls.Add(Me.bDown)
        Me.Controls.Add(Me.bUp)
        Me.Controls.Add(Me.bRemove)
        Me.Controls.Add(Me.bAdd)
        Me.Controls.Add(Me.lstColors)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColorListDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ColorListDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lstColors As System.Windows.Forms.ListBox
    Friend WithEvents bAdd As System.Windows.Forms.Button
    Friend WithEvents bDown As System.Windows.Forms.Button
    Friend WithEvents CE_Button As ColorEditorButton
    Friend WithEvents bRemove As System.Windows.Forms.Button
    Friend WithEvents bUp As System.Windows.Forms.Button
End Class
