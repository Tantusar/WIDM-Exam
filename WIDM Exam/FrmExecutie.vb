Imports WMPLib

Public Class FrmExecutie
    Private Sub FrmExecutie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If frmStartExecutie.WMP3.playState = WMPPlayState.wmppsPlaying Then
            frmStartExecutie.WMP3.Ctlcontrols.stop()
            frmStartExecutie.WMP2.Ctlcontrols.play()
        End If

        If FrmOpenTest.rMuziekDoorspelen.Checked = False Then
            frmStartExecutie.WMP2.Ctlcontrols.pause()
        End If
        PictureBox1.Image = Nothing
        PictureBox1.ImageLocation = ""
        Me.BackgroundImage = Nothing
    End Sub

    Private Sub FrmExecutie_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
        Cursor.Show()
        FrmStartExecutie.TextBox1.Text = ""
        FrmStartExecutie.TextBox2.Text = ""
        FrmStartExecutie.TextBox3.Text = ""
        FrmStartExecutie.TextBox4.Text = ""
        'If FrmOpenTest.rMuziekDoorspelen.Checked Then
        '    frmStartExecutie.WMP2.Ctlcontrols.play()
        'Else
        '    frmStartExecutie.WMP2.Ctlcontrols.stop()
        'End If
        Close()
        'End If
    End Sub

    Private Sub FrmExecutie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        expandToMonitor(Me)
        Cursor.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Cursor.Show()
        FrmStartExecutie.TextBox1.Text = ""
        FrmStartExecutie.TextBox2.Text = ""
        FrmStartExecutie.TextBox3.Text = ""
        FrmStartExecutie.TextBox4.Text = ""
        Close()
    End Sub
End Class