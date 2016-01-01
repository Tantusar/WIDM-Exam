Public Class FrmIdentify
    Sub ScreenClick(sender As Object, e As EventArgs)
        FrmOpenTest.rMonitor.SelectedIndex = sender.name
        MsgBox(String.Format(getLang("MonitorChanged"), sender.name + 1), MsgBoxStyle.Information)
    End Sub

    Private Sub FrmIdentify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim screenIndex = 0
        For Each item In Screen.AllScreens

            Dim l As Label
            l = New Label()
            l.AutoSize = False
            l.TextAlign = ContentAlignment.MiddleCenter
            l.BorderStyle = BorderStyle.FixedSingle
            l.Font = New Font("Lucida Console", 18, FontStyle.Regular)
            l.Location = New Point(item.Bounds.Location.X/10 + (Panel1.Width/2) - (Screen.PrimaryScreen.Bounds.Width/20),
                                   (item.Bounds.Location.Y/10 + (Panel1.Height/2) -
                                    (Screen.PrimaryScreen.Bounds.Height/20)))
            l.Size = New Point((item.Bounds.Width)/10 - 2, (item.Bounds.Height)/10 - 2)
            l.BackColor = Color.LightGray
            l.Visible = True
            l.Name = screenIndex
            If item.Primary Then
                l.Text = Replace(item.DeviceName, "\\.\DISPLAY", "") & " (" & getLang("Primair") & ")"
            Else
                l.Text = Replace(item.DeviceName, "\\.\DISPLAY", "")
            End If

            AddHandler l.Click, AddressOf ScreenClick
            Panel1.Controls.Add(l)

            screenIndex += 1
        Next
    End Sub
End Class