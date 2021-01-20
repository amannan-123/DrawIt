<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextEditor
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
        Me.cb_Font = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.bBold = New System.Windows.Forms.CheckBox()
        Me.bItalic = New System.Windows.Forms.CheckBox()
        Me.bUnder = New System.Windows.Forms.CheckBox()
        Me.TBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_Size = New MyControls.MyTrackBar()
        Me.bCancel = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.bStrike = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_Align = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cb_Font
        '
        Me.cb_Font.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cb_Font.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_Font.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_Font.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cb_Font.DropDownHeight = 250
        Me.cb_Font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Font.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Font.IntegralHeight = False
        Me.cb_Font.ItemHeight = 25
        Me.cb_Font.Location = New System.Drawing.Point(77, 12)
        Me.cb_Font.MaxDropDownItems = 14
        Me.cb_Font.Name = "cb_Font"
        Me.cb_Font.Size = New System.Drawing.Size(354, 31)
        Me.cb_Font.TabIndex = 0
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 21)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 13)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Font Family:"
        '
        'bBold
        '
        Me.bBold.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bBold.Appearance = System.Windows.Forms.Appearance.Button
        Me.bBold.BackColor = System.Drawing.Color.Gray
        Me.bBold.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.bBold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.bBold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.bBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bBold.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bBold.ForeColor = System.Drawing.Color.White
        Me.bBold.Location = New System.Drawing.Point(47, 49)
        Me.bBold.Name = "bBold"
        Me.bBold.Size = New System.Drawing.Size(25, 25)
        Me.bBold.TabIndex = 1
        Me.bBold.Text = "B"
        Me.bBold.UseVisualStyleBackColor = False
        '
        'bItalic
        '
        Me.bItalic.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bItalic.Appearance = System.Windows.Forms.Appearance.Button
        Me.bItalic.BackColor = System.Drawing.Color.Gray
        Me.bItalic.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.bItalic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.bItalic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.bItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bItalic.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bItalic.ForeColor = System.Drawing.Color.White
        Me.bItalic.Location = New System.Drawing.Point(79, 49)
        Me.bItalic.Name = "bItalic"
        Me.bItalic.Size = New System.Drawing.Size(25, 25)
        Me.bItalic.TabIndex = 2
        Me.bItalic.Text = "I"
        Me.bItalic.UseVisualStyleBackColor = False
        '
        'bUnder
        '
        Me.bUnder.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bUnder.Appearance = System.Windows.Forms.Appearance.Button
        Me.bUnder.BackColor = System.Drawing.Color.Gray
        Me.bUnder.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bUnder.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.bUnder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.bUnder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.bUnder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bUnder.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bUnder.ForeColor = System.Drawing.Color.White
        Me.bUnder.Location = New System.Drawing.Point(111, 49)
        Me.bUnder.Name = "bUnder"
        Me.bUnder.Size = New System.Drawing.Size(25, 25)
        Me.bUnder.TabIndex = 3
        Me.bUnder.Text = "U"
        Me.bUnder.UseVisualStyleBackColor = False
        '
        'TBox
        '
        Me.TBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBox.Location = New System.Drawing.Point(12, 102)
        Me.TBox.Multiline = True
        Me.TBox.Name = "TBox"
        Me.TBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TBox.Size = New System.Drawing.Size(420, 172)
        Me.TBox.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Size:"
        '
        'TB_Size
        '
        Me.TB_Size.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TB_Size.Colors = New System.Drawing.Color() {System.Drawing.Color.Black, System.Drawing.Color.SteelBlue, System.Drawing.Color.Black}
        Me.TB_Size.Factors = New Single() {0!, 1.0!}
        Me.TB_Size.Location = New System.Drawing.Point(44, 77)
        Me.TB_Size.Maximum = 200.0!
        Me.TB_Size.Minimum = 10.0!
        Me.TB_Size.Name = "TB_Size"
        Me.TB_Size.Positions = New Single() {0!, 0.5!, 1.0!}
        Me.TB_Size.Size = New System.Drawing.Size(392, 20)
        Me.TB_Size.TabIndex = 6
        Me.TB_Size.Value = 30.0!
        '
        'bCancel
        '
        Me.bCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancel.Location = New System.Drawing.Point(373, 280)
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Size = New System.Drawing.Size(58, 23)
        Me.bCancel.TabIndex = 14
        Me.bCancel.Text = "Cancel"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'bOK
        '
        Me.bOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOK.Location = New System.Drawing.Point(309, 280)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(58, 23)
        Me.bOK.TabIndex = 14
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'bStrike
        '
        Me.bStrike.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bStrike.Appearance = System.Windows.Forms.Appearance.Button
        Me.bStrike.BackColor = System.Drawing.Color.Gray
        Me.bStrike.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.bStrike.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.bStrike.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.bStrike.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.bStrike.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bStrike.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bStrike.ForeColor = System.Drawing.Color.White
        Me.bStrike.Location = New System.Drawing.Point(143, 49)
        Me.bStrike.Name = "bStrike"
        Me.bStrike.Size = New System.Drawing.Size(25, 25)
        Me.bStrike.TabIndex = 4
        Me.bStrike.Text = "S"
        Me.bStrike.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Style:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Alignment:"
        '
        'cb_Align
        '
        Me.cb_Align.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cb_Align.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Align.FormattingEnabled = True
        Me.cb_Align.Location = New System.Drawing.Point(252, 50)
        Me.cb_Align.Name = "cb_Align"
        Me.cb_Align.Size = New System.Drawing.Size(179, 23)
        Me.cb_Align.TabIndex = 5
        '
        'TextEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 315)
        Me.Controls.Add(Me.cb_Align)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.TB_Size)
        Me.Controls.Add(Me.TBox)
        Me.Controls.Add(Me.bStrike)
        Me.Controls.Add(Me.bUnder)
        Me.Controls.Add(Me.bItalic)
        Me.Controls.Add(Me.bBold)
        Me.Controls.Add(Me.cb_Font)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextEditor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TextEditor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cb_Font As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents bBold As CheckBox
    Friend WithEvents bItalic As CheckBox
    Friend WithEvents bUnder As CheckBox
    Friend WithEvents TBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_Size As MyControls.MyTrackBar
    Friend WithEvents bCancel As Button
    Friend WithEvents bOK As Button
    Friend WithEvents bStrike As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_Align As ComboBox
End Class
