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
        Me.lAuthor.Location = New System.Drawing.Point(12, 9)
        Me.lAuthor.Name = "lAuthor"
        Me.lAuthor.Size = New System.Drawing.Size(100, 23)
        Me.lAuthor.TabIndex = 0
        Me.lAuthor.Text = "Auteur:"
        Me.lAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lComment
        '
        Me.lComment.Location = New System.Drawing.Point(12, 37)
        Me.lComment.Name = "lComment"
        Me.lComment.Size = New System.Drawing.Size(100, 23)
        Me.lComment.TabIndex = 1
        Me.lComment.Text = "Commentaar:"
        Me.lComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lMoleText
        '
        Me.lMoleText.Location = New System.Drawing.Point(12, 117)
        Me.lMoleText.Name = "lMoleText"
        Me.lMoleText.Size = New System.Drawing.Size(100, 23)
        Me.lMoleText.TabIndex = 2
        Me.lMoleText.Text = "Tekst voor de mol:"
        Me.lMoleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAuthor
        '
        Me.txtAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtAuthor.Location = New System.Drawing.Point(118, 11)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(426, 20)
        Me.txtAuthor.TabIndex = 3
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(118, 37)
        Me.txtComment.Multiline = true
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtComment.Size = New System.Drawing.Size(426, 74)
        Me.txtComment.TabIndex = 4
        '
        'txtMoleText
        '
        Me.txtMoleText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMoleText.Location = New System.Drawing.Point(118, 117)
        Me.txtMoleText.Multiline = true
        Me.txtMoleText.Name = "txtMoleText"
        Me.txtMoleText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMoleText.Size = New System.Drawing.Size(426, 74)
        Me.txtMoleText.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(469, 202)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Opslaan"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'FrmExtraInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 237)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtMoleText)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.lMoleText)
        Me.Controls.Add(Me.lComment)
        Me.Controls.Add(Me.lAuthor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmExtraInfo"
        Me.Text = "WIDM Exam"
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
