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
        Me.txtOld.Location = New System.Drawing.Point(12, 25)
        Me.txtOld.Name = "txtOld"
        Me.txtOld.Size = New System.Drawing.Size(433, 20)
        Me.txtOld.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Locatie oude test:"
        '
        'btnOld
        '
        Me.btnOld.Location = New System.Drawing.Point(451, 23)
        Me.btnOld.Name = "btnOld"
        Me.btnOld.Size = New System.Drawing.Size(75, 23)
        Me.btnOld.TabIndex = 2
        Me.btnOld.Text = "Bladeren..."
        Me.btnOld.UseVisualStyleBackColor = true
        '
        'comboVersion
        '
        Me.comboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboVersion.FormattingEnabled = true
        Me.comboVersion.Location = New System.Drawing.Point(324, 52)
        Me.comboVersion.Name = "comboVersion"
        Me.comboVersion.Size = New System.Drawing.Size(121, 21)
        Me.comboVersion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(292, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Kies de versie van de oude test (*.widm is v1, *.widm2 is v2):"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(451, 91)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Text = "Bladeren..."
        Me.btnNew.UseVisualStyleBackColor = true
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(9, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Locatie nieuwe test:"
        '
        'txtNew
        '
        Me.txtNew.Location = New System.Drawing.Point(12, 93)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(433, 20)
        Me.txtNew.TabIndex = 5
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(343, 132)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(102, 40)
        Me.btnConvert.TabIndex = 8
        Me.btnConvert.Text = "Converteren"
        Me.btnConvert.UseVisualStyleBackColor = true
        '
        'OpenOld
        '
        Me.OpenOld.Filter = "(*.widm, *.widm2)|*.widm; *.widm2"
        '
        'SaveNew
        '
        Me.SaveNew.Filter = "(*.widm3)|*.widm3"
        '
        'FrmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 184)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "FrmConvert"
        Me.Text = "WIDM Exam test converteren"
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
