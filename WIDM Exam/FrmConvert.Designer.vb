<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConvert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConvert))
        Me.txtOld = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOld = New System.Windows.Forms.Button()
        Me.comboVersion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.OpenOld = New System.Windows.Forms.OpenFileDialog()
        Me.SaveNew = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.numEpisodeCount = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConvertGroup = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnNewGroup = New System.Windows.Forms.Button()
        Me.txtOldGroup = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOldGroup = New System.Windows.Forms.Button()
        Me.txtNewGroup = New System.Windows.Forms.TextBox()
        Me.FolderOldGroup = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveNewGroup = New System.Windows.Forms.SaveFileDialog()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        CType(Me.numEpisodeCount,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtOld
        '
        resources.ApplyResources(Me.txtOld, "txtOld")
        Me.txtOld.Name = "txtOld"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'btnOld
        '
        resources.ApplyResources(Me.btnOld, "btnOld")
        Me.btnOld.Name = "btnOld"
        Me.btnOld.UseVisualStyleBackColor = true
        '
        'comboVersion
        '
        resources.ApplyResources(Me.comboVersion, "comboVersion")
        Me.comboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboVersion.FormattingEnabled = true
        Me.comboVersion.Name = "comboVersion"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnNew
        '
        resources.ApplyResources(Me.btnNew, "btnNew")
        Me.btnNew.Name = "btnNew"
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtNew
        '
        resources.ApplyResources(Me.txtNew, "txtNew")
        Me.txtNew.Name = "txtNew"
        '
        'btnConvert
        '
        resources.ApplyResources(Me.btnConvert, "btnConvert")
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.UseVisualStyleBackColor = true
        '
        'OpenOld
        '
        resources.ApplyResources(Me.OpenOld, "OpenOld")
        '
        'SaveNew
        '
        resources.ApplyResources(Me.SaveNew, "SaveNew")
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.btnConvert)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.txtOld)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnOld)
        Me.GroupBox1.Controls.Add(Me.txtNew)
        Me.GroupBox1.Controls.Add(Me.comboVersion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.numEpisodeCount)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnConvertGroup)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnNewGroup)
        Me.GroupBox2.Controls.Add(Me.txtOldGroup)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnOldGroup)
        Me.GroupBox2.Controls.Add(Me.txtNewGroup)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = false
        '
        'numEpisodeCount
        '
        resources.ApplyResources(Me.numEpisodeCount, "numEpisodeCount")
        Me.numEpisodeCount.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numEpisodeCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numEpisodeCount.Name = "numEpisodeCount"
        Me.numEpisodeCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'btnConvertGroup
        '
        resources.ApplyResources(Me.btnConvertGroup, "btnConvertGroup")
        Me.btnConvertGroup.Name = "btnConvertGroup"
        Me.btnConvertGroup.UseVisualStyleBackColor = true
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'btnNewGroup
        '
        resources.ApplyResources(Me.btnNewGroup, "btnNewGroup")
        Me.btnNewGroup.Name = "btnNewGroup"
        Me.btnNewGroup.UseVisualStyleBackColor = true
        '
        'txtOldGroup
        '
        resources.ApplyResources(Me.txtOldGroup, "txtOldGroup")
        Me.txtOldGroup.Name = "txtOldGroup"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'btnOldGroup
        '
        resources.ApplyResources(Me.btnOldGroup, "btnOldGroup")
        Me.btnOldGroup.Name = "btnOldGroup"
        Me.btnOldGroup.UseVisualStyleBackColor = true
        '
        'txtNewGroup
        '
        resources.ApplyResources(Me.txtNewGroup, "txtNewGroup")
        Me.txtNewGroup.Name = "txtNewGroup"
        '
        'FolderOldGroup
        '
        resources.ApplyResources(Me.FolderOldGroup, "FolderOldGroup")
        '
        'SaveNewGroup
        '
        Me.SaveNewGroup.FileName = "group.widm"
        resources.ApplyResources(Me.SaveNewGroup, "SaveNewGroup")
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'FrmConvert
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "FrmConvert"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        CType(Me.numEpisodeCount,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents txtOld As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOld As Button
    Friend WithEvents comboVersion As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNew As TextBox
    Friend WithEvents btnConvert As Button
    Friend WithEvents OpenOld As OpenFileDialog
    Friend WithEvents SaveNew As SaveFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnConvertGroup As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnNewGroup As Button
    Friend WithEvents txtOldGroup As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOldGroup As Button
    Friend WithEvents txtNewGroup As TextBox
    Friend WithEvents FolderOldGroup As FolderBrowserDialog
    Friend WithEvents SaveNewGroup As SaveFileDialog
    Friend WithEvents numEpisodeCount As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
