

Public Class FrmUpdater
    Public Newversion As Boolean = False
    Public Newversionnumber As String = ""
    Dim _secondFile As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FrmOpenTest.rOCRAEXT.Checked Then
            Label1.Font = GetInstance(14, FontStyle.Regular)
        End If
        txtCurrent.Text = My.Application.Info.Version.ToString
        txtLatest.Text = newversionnumber
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("http://widmexam.sourceforge.net/?update=true")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked
        Process.Start("http://koenvh.nl/widm")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        Process.Start("http://widmexam.sourceforge.net")
    End Sub
End Class
