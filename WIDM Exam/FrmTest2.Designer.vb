<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTest2
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
        Me.txtQuestion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtQuestion
        '
        Me.txtQuestion.AutoSize = True
        Me.txtQuestion.Location = New System.Drawing.Point(41, 19)
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(60, 13)
        Me.txtQuestion.TabIndex = 0
        Me.txtQuestion.Text = "txtQuestion"
        '
        'FrmTest2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 378)
        Me.Controls.Add(Me.txtQuestion)
        Me.Name = "FrmTest2"
        Me.Text = "FrmTest2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuestion As System.Windows.Forms.Label
End Class
