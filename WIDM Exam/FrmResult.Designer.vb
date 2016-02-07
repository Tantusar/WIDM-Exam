<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmResult))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtScore = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtNaam = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.listAnswers = New ComponentOwl.BetterListView.BetterListView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.SaveFileHTMLExport = New System.Windows.Forms.SaveFileDialog()
        CType(Me.listAnswers,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.Window
        Me.Label2.Name = "Label2"
        '
        'txtScore
        '
        resources.ApplyResources(Me.txtScore, "txtScore")
        Me.txtScore.BackColor = System.Drawing.Color.Transparent
        Me.txtScore.ForeColor = System.Drawing.SystemColors.Window
        Me.txtScore.Name = "txtScore"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'txtNaam
        '
        resources.ApplyResources(Me.txtNaam, "txtNaam")
        Me.txtNaam.BackColor = System.Drawing.Color.Transparent
        Me.txtNaam.ForeColor = System.Drawing.SystemColors.Window
        Me.txtNaam.Name = "txtNaam"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = false
        '
        'listAnswers
        '
        resources.ApplyResources(Me.listAnswers, "listAnswers")
        Me.listAnswers.Columns.Add(CType(resources.GetObject("listAnswers.Columns"),ComponentOwl.BetterListView.BetterListViewColumnHeader))
        Me.listAnswers.Columns.Add(CType(resources.GetObject("listAnswers.Columns1"),ComponentOwl.BetterListView.BetterListViewColumnHeader))
        Me.listAnswers.Columns.Add(CType(resources.GetObject("listAnswers.Columns2"),ComponentOwl.BetterListView.BetterListViewColumnHeader))
        Me.listAnswers.Columns.Add(CType(resources.GetObject("listAnswers.Columns3"),ComponentOwl.BetterListView.BetterListViewColumnHeader))
        Me.listAnswers.GridLines = ComponentOwl.BetterListView.BetterListViewGridLines.Grid
        Me.listAnswers.Name = "listAnswers"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = false
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.BackColor = System.Drawing.SystemColors.Control
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = false
        '
        'SaveFileHTMLExport
        '
        resources.ApplyResources(Me.SaveFileHTMLExport, "SaveFileHTMLExport")
        '
        'FrmResult
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.listAnswers)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtNaam)
        Me.Controls.Add(Me.txtScore)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = true
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmResult"
        Me.TopMost = true
        CType(Me.listAnswers,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtScore As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtNaam As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents listAnswers As ComponentOwl.BetterListView.BetterListView
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents SaveFileHTMLExport As SaveFileDialog
End Class
