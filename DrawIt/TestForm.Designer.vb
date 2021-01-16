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
        Me.ShapePointsEditor1 = New MyControls.ShapePointsEditor()
        Me.SuspendLayout()
        '
        'ShapePointsEditor1
        '
        Me.ShapePointsEditor1.Location = New System.Drawing.Point(12, 12)
        Me.ShapePointsEditor1.Name = "ShapePointsEditor1"
        Me.ShapePointsEditor1.Points = New System.Drawing.PointF(-1) {}
        Me.ShapePointsEditor1.ShapeType = MyControls.ShapePointsEditor.DrawType.ClosedCurve
        Me.ShapePointsEditor1.Size = New System.Drawing.Size(250, 250)
        Me.ShapePointsEditor1.TabIndex = 0
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 308)
        Me.Controls.Add(Me.ShapePointsEditor1)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ShapePointsEditor1 As MyControls.ShapePointsEditor
End Class
