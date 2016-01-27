Public Class FrmPercentage
    Private Sub FrmExecutie_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Panel1.Visible = True
            Label2.Visible = False
            Label1.Visible = True
            My.Computer.Audio.Play(My.Resources.WIDM_Percentagegeluid, AudioPlayMode.Background)
            If FrmOpenTest.rExecutie.checked Then
                tmExecutie.Start()
            End If
        End If
    End Sub

    Private Sub FrmExecutie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        expandToMonitor(Me)
        Label1.Text = FrmOpenTest.percentage & "%"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub


    Private Sub tmExecutie_Tick(sender As Object, e As EventArgs) Handles tmExecutie.Tick
        tmExecutie.Stop()
        frmStartExecutie.Show()
        Close()
    End Sub
End Class