Public Class FrmOver
    Private Sub FrmOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FrmOpenTest.rOCRAEXT.Checked Then
            Label1.Font = GetInstance(16, FontStyle.Regular)
            Label3.Font = GetInstance(10, FontStyle.Regular)
        End If
        Label3.Text = "v" & My.Application.Info.Version.ToString
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("http://creativecommons.org/licenses/by-nc-nd/3.0/nl/")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Process.Start("http://koenvh.nl")
    End Sub
End Class