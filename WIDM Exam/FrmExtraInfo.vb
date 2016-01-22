Public Class FrmExtraInfo
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub FrmExtraInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub New ()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New (ByVal author As String, ByVal comment As String, ByVal moleText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtAuthor.Text = author
        txtComment.Text = comment
        txtMoleText.Text = moleText
    End Sub
End Class