Imports ComponentOwl.BetterListView

Public Class FrmResult
    Private Sub FrmResult_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Stop()
    End Sub

    Private Sub FrmResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExpandToMonitor(Me)
        If CurrentTheme.BackgroundTestEnabled Then
            BackgroundImage = CurrentTheme.ImgBackgroundTest
        Else
            BackgroundImage = Nothing

        End If
        BackColor = CurrentTheme.BackgroundColorTest

        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUK.Checked Then

        '    txtNaam.ForeColor = Color.Gold
        '    Label2.ForeColor = Color.Gold
        '    txtScore.ForeColor = Color.Gold
        '    Me.BackgroundImage = Nothing
        'ElseIf FrmOpenTest.rUS.Checked Then
        '    BackgroundImage = My.Resources.US_Background
        '    'txtNaam.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    'Label2.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    'txtScore.Font = New Font("Microsoft Sans Serif", 24, FontStyle.Regular)

        '    'ElseIf FrmOpenTest.rOCRAEXT.Checked Then

        '    '    txtNaam.Font = loadFont.GetInstance(36, FontStyle.Regular)
        '    '    Label2.Font = loadFont.GetInstance(36, FontStyle.Regular)
        '    '    txtScore.Font = loadFont.GetInstance(24, FontStyle.Regular)

        'ElseIf FrmOpenTest.rFrankrijk.Checked Then
        '    BackgroundImage = My.Resources.Fr_Background
        'End If
        'If FrmOpenTest.rLucidaConsole.Checked Then
        '    'Is Lucide Console by default, no need to set it. 
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    txtNaam.Font = GetInstance(36, FontStyle.Regular)
        '    Label2.Font = GetInstance(36, FontStyle.Regular)
        '    txtScore.Font = GetInstance(24, FontStyle.Regular)
        'ElseIf FrmOpenTest.rComicSansMS.Checked Then
        '    txtNaam.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    Label2.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    txtScore.Font = New Font("Comic Sans MS", 24, FontStyle.Regular)
        'ElseIf FrmOpenTest.rMicrosoftSansSerif.Checked Then
        '    txtNaam.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    Label2.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    txtScore.Font = New Font("Microsoft Sans Serif", 24, FontStyle.Regular)
        'ElseIf FrmOpenTest.rUbuntuCondensed.Checked Then
        '    txtNaam.Font = New Font("Ubuntu Condensed", 36)
        '    Label2.Font = New Font("Ubuntu Condensed", 36)
        '    txtScore.Font = New Font("Ubuntu Condensed", 24)
        'ElseIf FrmOpenTest.rMicroFLF.Checked Then
        '    txtNaam.Font = New Font("MicroFLF", 36)
        '    Label2.Font = New Font("MicroFLF", 36)
        '    txtScore.Font = New Font("MicroFLF", 24)
        'ElseIf FrmOpenTest.rCustomFont.Checked Then
        '    txtNaam.Font = New Font(My.Settings.customFont.OriginalFontName, 36, FontStyle.Regular)
        '    Label2.Font = New Font(My.Settings.customFont.OriginalFontName, 36, FontStyle.Regular)
        '    txtScore.Font = New Font(My.Settings.customFont.OriginalFontName, 24, FontStyle.Regular)
        'End If

        txtNaam.Font = New Font(CurrentTheme.FontQuestion.OriginalFontName, 36, FontStyle.Regular)
        Label2.Font = New Font(CurrentTheme.FontQuestion.OriginalFontName, 36, FontStyle.Regular)
        txtScore.Font = New Font(CurrentTheme.FontQuestion.OriginalFontName, 24, FontStyle.Regular)
        txtNaam.ForeColor = CurrentTheme.ColorQuestion
        Label2.ForeColor = CurrentTheme.ColorQuestion
        txtScore.ForeColor = CurrentTheme.ColorQuestion

        txtNaam.Text = FrmEnterName.TextBox1.Text
        My.Computer.Audio.Play(My.Resources.WIDM_Percentagegeluid,
                               AudioPlayMode.Background)
        Timer1.Start()
    End Sub

    Sub CloseForm()
        FrmTest.Close()
        FrmEnterName.Close()
        My.Computer.Audio.Stop()
        listAnswers.Items.Clear()
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmEnterName.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseForm()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If SaveFileHTMLExport.ShowDialog() = DialogResult.OK Then
            Dim Write As New IO.StreamWriter(SaveFileHTMLExport.FileName)
            Write.Write(My.Resources.htmlExport01)
            If My.Settings.language = "en" Then
                Write.WriteLine(
                    "<tr>" & vbCrLf & "<th>#</th>" & vbCrLf & "<th>Question</th>" & vbCrLf & "<th>Answer</th>" & vbCrLf & "<th>Correct</th>" & vbCrLf & "</tr>")
            Else
                Write.WriteLine(
                    "<tr>" & vbCrLf & "<th>#</th>" & vbCrLf & "<th>Vraag</th>" & vbCrLf & "<th>Antwoord</th>" & vbCrLf & "<th>Correct</th>" & vbCrLf & "</tr>")
            End If

            For Each item In FrmTest._givenAnswer
                'If item.Correct Then
                '    Write.WriteLine("<tr style=""background-color:greenyellow"">")
                'Else
                '    Write.WriteLine("<tr style=""background-color:orangered"">")
                'End If

                Write.WriteLine("<td>" & item.Number & "</td>")
                Write.WriteLine("<td>" & item.Question & "</td>")
                Write.WriteLine("<td>" & item.Answer & "</td>")
                If My.Settings.language = "en" Then
                    If item.Correct Then
                        Write.WriteLine("<td style=""background-color:greenyellow; color:greenyellow"">Yes</td>")
                    Else
                        Write.WriteLine("<td style=""background-color:orangered; color:orangered"">No</td>")
                    End If
                Else
                    If item.Correct Then
                        Write.WriteLine("<td style=""background-color:greenyellow; color:greenyellow"">Ja</td>")
                    Else
                        Write.WriteLine("<td style=""background-color:orangered; color:orangered"">Nee</td>")
                    End If
                End If


                Write.WriteLine("</tr>")
            Next
            Write.WriteLine("</table>")
            If My.Settings.language = "en" Then
                Write.WriteLine("<p><A HREF=""javascript:window.print()"">Print this page</a></p>")
            Else
                Write.WriteLine("<p><A HREF=""javascript:window.print()"">Print deze pagina</a></p>")
            End If
            Write.WriteLine("</body>")
            Write.WriteLine("</html>")
            Write.Close()

            'rSorting.Checked = sortCheckState
            Try
                Process.Start(SaveFileHTMLExport.FileName)
            Catch ex As Exception
                Log(ex.ToString())
            End Try
            CloseForm()

        End If
    End Sub
End Class