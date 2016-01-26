<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSplash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSplash))
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.picKoenvh = New System.Windows.Forms.PictureBox()
        CType(Me.picLogo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picKoenvh,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Image = Global.WIDM_Exam.My.Resources.Resources.WIDM_Exam
        Me.picLogo.Location = New System.Drawing.Point(56, 33)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(400, 70)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = false
        '
        'picKoenvh
        '
        Me.picKoenvh.BackColor = System.Drawing.Color.Transparent
        Me.picKoenvh.Image = Global.WIDM_Exam.My.Resources.Resources.Koenvh_inverted_text
        Me.picKoenvh.Location = New System.Drawing.Point(12, 225)
        Me.picKoenvh.Name = "picKoenvh"
        Me.picKoenvh.Size = New System.Drawing.Size(158, 46)
        Me.picKoenvh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picKoenvh.TabIndex = 1
        Me.picKoenvh.TabStop = false
        '
        'FrmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.WIDM_Exam.My.Resources.Resources.splash
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(512, 288)
        Me.Controls.Add(Me.picKoenvh)
        Me.Controls.Add(Me.picLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "FrmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WIDM Exam"
        CType(Me.picLogo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picKoenvh,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents picLogo As PictureBox
    Friend WithEvents picKoenvh As PictureBox
End Class
