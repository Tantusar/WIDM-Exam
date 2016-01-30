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
        'FrmConvert
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.comboVersion)
        Me.Controls.Add(Me.btnOld)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOld)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "FrmConvert"
        Me.ResumeLayout(false)
        Me.PerformLayout

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
End Class
