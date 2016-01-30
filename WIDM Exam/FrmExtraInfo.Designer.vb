<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExtraInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExtraInfo))
        Me.lAuthor = New System.Windows.Forms.Label()
        Me.lComment = New System.Windows.Forms.Label()
        Me.lMoleText = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.txtMoleText = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'lAuthor
        '
        resources.ApplyResources(Me.lAuthor, "lAuthor")
        Me.lAuthor.Name = "lAuthor"
        '
        'lComment
        '
        resources.ApplyResources(Me.lComment, "lComment")
        Me.lComment.Name = "lComment"
        '
        'lMoleText
        '
        resources.ApplyResources(Me.lMoleText, "lMoleText")
        Me.lMoleText.Name = "lMoleText"
        '
        'txtAuthor
        '
        resources.ApplyResources(Me.txtAuthor, "txtAuthor")
        Me.txtAuthor.Name = "txtAuthor"
        '
        'txtComment
        '
        resources.ApplyResources(Me.txtComment, "txtComment")
        Me.txtComment.Name = "txtComment"
        '
        'txtMoleText
        '
        resources.ApplyResources(Me.txtMoleText, "txtMoleText")
        Me.txtMoleText.Name = "txtMoleText"
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'FrmExtraInfo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtMoleText)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.lMoleText)
        Me.Controls.Add(Me.lComment)
        Me.Controls.Add(Me.lAuthor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmExtraInfo"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lAuthor As Label
    Friend WithEvents lComment As Label
    Friend WithEvents lMoleText As Label
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents txtComment As TextBox
    Friend WithEvents txtMoleText As TextBox
    Friend WithEvents btnSave As Button
End Class
