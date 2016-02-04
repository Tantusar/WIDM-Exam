<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTest
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTest))
        Me.smallLogo = New System.Windows.Forms.PictureBox()
        Me.txtQuestion = New System.Windows.Forms.Label()
        Me.tmTime = New System.Windows.Forms.Timer(Me.components)
        Me.tmToBack = New System.Windows.Forms.Timer(Me.components)
        Me.tmButton = New System.Windows.Forms.Timer(Me.components)
        Me.tmTekst1 = New System.Windows.Forms.Timer(Me.components)
        Me.tmTekst2 = New System.Windows.Forms.Timer(Me.components)
        Me.txtTekst2 = New System.Windows.Forms.Label()
        Me.txtTekst1 = New System.Windows.Forms.Label()
        Me.WMP2 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.WMP1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.t2 = New System.Windows.Forms.PictureBox()
        Me.t3 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.TextBox()
        CType(Me.smallLogo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.WMP2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.WMP1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.t2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'smallLogo
        '
        resources.ApplyResources(Me.smallLogo, "smallLogo")
        Me.smallLogo.Name = "smallLogo"
        Me.smallLogo.TabStop = false
        '
        'txtQuestion
        '
        resources.ApplyResources(Me.txtQuestion, "txtQuestion")
        Me.txtQuestion.BackColor = System.Drawing.Color.Transparent
        Me.txtQuestion.ForeColor = System.Drawing.SystemColors.Window
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.UseMnemonic = false
        '
        'tmTime
        '
        '
        'tmToBack
        '
        Me.tmToBack.Enabled = true
        Me.tmToBack.Interval = 50
        '
        'tmButton
        '
        Me.tmButton.Interval = 500
        '
        'tmTekst1
        '
        Me.tmTekst1.Interval = 5000
        '
        'tmTekst2
        '
        Me.tmTekst2.Interval = 5000
        '
        'txtTekst2
        '
        resources.ApplyResources(Me.txtTekst2, "txtTekst2")
        Me.txtTekst2.BackColor = System.Drawing.Color.Transparent
        Me.txtTekst2.ForeColor = System.Drawing.SystemColors.Window
        Me.txtTekst2.Name = "txtTekst2"
        Me.txtTekst2.UseMnemonic = false
        '
        'txtTekst1
        '
        resources.ApplyResources(Me.txtTekst1, "txtTekst1")
        Me.txtTekst1.BackColor = System.Drawing.Color.Transparent
        Me.txtTekst1.ForeColor = System.Drawing.SystemColors.Window
        Me.txtTekst1.Name = "txtTekst1"
        Me.txtTekst1.UseMnemonic = false
        '
        'WMP2
        '
        resources.ApplyResources(Me.WMP2, "WMP2")
        Me.WMP2.Name = "WMP2"
        Me.WMP2.OcxState = CType(resources.GetObject("WMP2.OcxState"),System.Windows.Forms.AxHost.State)
        '
        'WMP1
        '
        resources.ApplyResources(Me.WMP1, "WMP1")
        Me.WMP1.Name = "WMP1"
        Me.WMP1.OcxState = CType(resources.GetObject("WMP1.OcxState"),System.Windows.Forms.AxHost.State)
        '
        't2
        '
        Me.t2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.t2, "t2")
        Me.t2.Name = "t2"
        Me.t2.TabStop = false
        '
        't3
        '
        resources.ApplyResources(Me.t3, "t3")
        Me.t3.BackColor = System.Drawing.Color.Transparent
        Me.t3.ForeColor = System.Drawing.Color.White
        Me.t3.Name = "t3"
        '
        't1
        '
        Me.t1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.t1.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.t1, "t1")
        Me.t1.ForeColor = System.Drawing.Color.White
        Me.t1.Name = "t1"
        '
        'FrmTest
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.t3)
        Me.Controls.Add(Me.txtTekst2)
        Me.Controls.Add(Me.txtTekst1)
        Me.Controls.Add(Me.WMP2)
        Me.Controls.Add(Me.WMP1)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.smallLogo)
        Me.DoubleBuffered = true
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTest"
        Me.TopMost = true
        CType(Me.smallLogo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.WMP2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.WMP1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.t2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents smallLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtQuestion As System.Windows.Forms.Label
    Friend WithEvents tmTime As System.Windows.Forms.Timer
    Friend WithEvents tmToBack As System.Windows.Forms.Timer
    Friend WithEvents WMP1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents tmButton As System.Windows.Forms.Timer
    Friend WithEvents tmTekst1 As System.Windows.Forms.Timer
    Friend WithEvents tmTekst2 As System.Windows.Forms.Timer
    Friend WithEvents WMP2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents txtTekst2 As System.Windows.Forms.Label
    Friend WithEvents txtTekst1 As System.Windows.Forms.Label
    Friend WithEvents t2 As System.Windows.Forms.PictureBox
    Friend WithEvents t3 As System.Windows.Forms.Label
    Friend WithEvents t1 As System.Windows.Forms.TextBox
End Class
