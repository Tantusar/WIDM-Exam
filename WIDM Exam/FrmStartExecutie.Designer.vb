<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStartExecutie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStartExecutie))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.WMP2 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.WMP1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.WMP3 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.WMP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WMP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WMP3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Name = "Panel1"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Name = "Label11"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Name = "ComboBox1"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WIDM_Exam.My.Resources.Resources.SmallLogoDark
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 15000
        '
        'Timer2
        '
        Me.Timer2.Interval = 3000
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Name = "Panel2"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Name = "Label2"
        '
        'TextBox2
        '
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.ForeColor = System.Drawing.Color.Red
        Me.TextBox2.Name = "TextBox2"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'WMP2
        '
        resources.ApplyResources(Me.WMP2, "WMP2")
        Me.WMP2.Name = "WMP2"
        Me.WMP2.OcxState = CType(resources.GetObject("WMP2.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'WMP1
        '
        resources.ApplyResources(Me.WMP1, "WMP1")
        Me.WMP1.Name = "WMP1"
        Me.WMP1.OcxState = CType(resources.GetObject("WMP1.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'WMP3
        '
        resources.ApplyResources(Me.WMP3, "WMP3")
        Me.WMP3.Name = "WMP3"
        Me.WMP3.OcxState = CType(resources.GetObject("WMP3.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.WIDM_Exam.My.Resources.Resources.US_Background_Textfield
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Name = "Panel3"
        '
        'TextBox3
        '
        resources.ApplyResources(Me.TextBox3, "TextBox3")
        Me.TextBox3.Name = "TextBox3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Name = "Label5"
        '
        'FrmStartExecutie
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.WMP3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.WMP2)
        Me.Controls.Add(Me.WMP1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmStartExecutie"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.WMP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WMP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WMP3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents WMP1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WMP2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents WMP3 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
