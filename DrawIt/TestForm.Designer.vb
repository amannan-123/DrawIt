<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestForm
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
        Me.PointSelector1 = New MyControls.PointSelector()
        Me.SuspendLayout()
        '
        'PointSelector1
        '
        Me.PointSelector1.Location = New System.Drawing.Point(22, 21)
        Me.PointSelector1.Name = "PointSelector1"
        Me.PointSelector1.Size = New System.Drawing.Size(222, 225)
        Me.PointSelector1.TabIndex = 0
        Me.PointSelector1.Value = New System.Drawing.Point(100, 100)
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 308)
        Me.Controls.Add(Me.PointSelector1)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PointSelector1 As MyControls.PointSelector
End Class
