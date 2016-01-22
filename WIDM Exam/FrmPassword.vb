Public Class FrmPassword
    Public Cancel As Boolean = False

    Private Sub FrmPassword_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    End Sub

    Private Sub FrmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Dock = DockStyle.Fill
        If FrmOpenTest.startedUp Then
            LinkLabel1.Visible = False
        End If
        cancel = False
        If FrmOpenTest.rOCRAEXT.Checked Then
            Label1.Font = GetInstance(14, FontStyle.Regular)
        End If
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cancel = True
        Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked
        If My.Settings.language = "en" Then
            If _
                MsgBox("Are you sure you want to reset the settings?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) =
                DialogResult.Yes Then
                My.Settings.Reset()
                MsgBox("The settings are reset." & vbCrLf & "Restart for the changes to take effect.",
                       MsgBoxStyle.Information)
            End If
        Else
            If _
                MsgBox("Weet je zeker dat je je instellingen terug naar standaard wilt zetten?",
                       MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = DialogResult.Yes Then
                My.Settings.Reset()
                MsgBox("Instellingen terug naar standaard gezet." & vbCrLf & "Herstart om de wijzigingen te zien.",
                       MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class