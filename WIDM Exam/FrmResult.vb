﻿Public Class FrmResult
    Private Sub FrmResult_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Stop()
    End Sub

    Private Sub FrmResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        expandToMonitor(Me)
        If CurrentTheme.backgroundTestEnabled Then
            BackgroundImage = CurrentTheme.imgbackgroundTest
            Else 
            BackgroundImage = Nothing

        End If
        BackColor = CurrentTheme.backgroundColorTest

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

        txtNaam.Font = New Font(CurrentTheme.fontQuestion.OriginalFontName, 36, FontStyle.Regular)
        Label2.Font = New Font(CurrentTheme.fontQuestion.OriginalFontName, 36, FontStyle.Regular)
        txtScore.Font = New Font(CurrentTheme.fontQuestion.OriginalFontName, 24, FontStyle.Regular)
        txtNaam.ForeColor = CurrentTheme.colorQuestion
        Label2.ForeColor = CurrentTheme.colorQuestion
        txtScore.ForeColor = CurrentTheme.colorQuestion

        txtNaam.Text = FrmEnterName.TextBox1.Text
        My.Computer.Audio.Play(My.Resources.WIDM_Percentagegeluid,
                               AudioPlayMode.Background)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        FrmTest.Close()
        FrmEnterName.Close()
        Close()
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmEnterName.Close()
    End Sub
End Class