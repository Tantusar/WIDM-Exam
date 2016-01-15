﻿Imports WMPLib

Public Class FrmEnterName
    Public closePass As Boolean = False
    ReadOnly checkTested As New ListBox
    Private Declare Function SetWindowTheme Lib "uxtheme" (
                                                          hWnd As IntPtr,
                                                          ByRef pszSubAppName As String,
                                                          ByRef pszSubIdList As String) _
        As Integer

    Private Sub pressedEnter()
        If FrmOpenTest.rGroep.Checked Then

            If FrmOpenTest.listKandidaten.Items.Contains(TextBox1.Text) = False Then
                If My.Settings.language = "en" Then
                    MsgBox("Name hasn't been found. Are you sure it exists?", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Naam niet gevonden, komt deze naam wel voor?", MsgBoxStyle.Exclamation)
                End If
            Else
                If checkTested.Items.Contains(TextBox1.Text) Then
                    If My.Settings.language = "en" Then
                        MsgBox("Quiz was already made by this candidate!", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Test is al uitgevoerd door deze kandidaat!", MsgBoxStyle.Exclamation)
                    End If

                Else
                    checkTested.Items.Add(TextBox1.Text)
                    Try
                        ComboBox1.Items.Remove(TextBox1.Text)
                    Catch ex As Exception

                    End Try
                    start()
                End If

            End If
        ElseIf TextBox1.Text = "nyan" Then
            My.Computer.Audio.Stop()
            WMP1.URL = "http://www.nyan.cat/music/zombie.mp3"
            WMP1.settings.setMode("loop", True)
            WMP1.Ctlcontrols.play()
            start()
        Else

            start()
        End If
    End Sub

    Private Sub CloseNow()
    End Sub

    Private Sub FrmEnterName_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    FrmOpenTest.groepsmodusUpdate()
        'Catch ex As Exception

        'End Try
        If closePass = True Then
        Else
            If FrmOpenTest.rGroep.Checked Then
                If My.Settings.password = "" Then

                Else
                    FrmPassword.ShowDialog()
                    If FrmPassword.cancel = True Then
                        e.Cancel = True
                    ElseIf FrmPassword.TextBox1.Text = My.Settings.password Then
                    Else
                        If My.Settings.language = "en" Then
                            MsgBox("Wrong password", MsgBoxStyle.Exclamation)
                        Else
                            MsgBox("Verkeerd wachtwoord", MsgBoxStyle.Exclamation)
                        End If

                        e.Cancel = True
                    End If
                End If
            End If

        End If


        My.Computer.Audio.Stop()
        WMP1.Ctlcontrols.stop()
    End Sub

    Private Sub FrmEnterName_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Do you want to exit the quiz?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If

            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        expandToMonitor(Me)

        FrmOpenTest.LoadTheme()

        If FrmOpenTest.rGeluidTest.Checked = False Then
            WMP1.settings.mute = True
        End If

        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel2.Top = (Me.Height / 2) - (Panel2.Height / 2)
        Panel2.Left = (Me.Width / 2) - (Panel2.Width / 2)
        Panel3.Top = (Me.Height / 2) - (Panel3.Height / 2)
        Panel3.Left = (Me.Width / 2) - (Panel3.Width / 2)
        If FrmOpenTest.rGroep.Checked Then
            If FrmOpenTest.rCombobox.Checked Then
                If My.Settings.language = "en" Then
                    Label1.Text = "Choose a name from the list:"
                Else
                    Label1.Text = "Kies uw naam uit de lijst:"
                End If

            Else
                If My.Settings.language = "en" Then
                    Label1.Text = "Enter your name:"
                Else
                    Label1.Text = "Voer uw naam in:"
                End If

            End If
        Else
            If My.Settings.language = "en" Then
                Label1.Text = "Enter your name:"
            Else
                Label1.Text = "Voer uw naam in:"
            End If
        End If

        ComboBox1.Visible = True
        TextBox1.Visible = True

        'Default
        Label1.Font = FrmOpenTest.theme.fontIntroText
        TextBox1.Font = FrmOpenTest.theme.fontIntroTextfield

        Label1.ForeColor = FrmOpenTest.theme.colorIntroText
        TextBox1.ForeColor = FrmOpenTest.theme.colorIntroTextfield
        'US
        Label5.Font = FrmOpenTest.theme.fontIntroText
        TextBox3.Font = FrmOpenTest.theme.fontIntroTextfield
        'Nostalgia
        Label2.Font = FrmOpenTest.theme.fontIntroText
        TextBox2.Font = FrmOpenTest.theme.fontIntroTextfield
        Button1.Font = FrmOpenTest.theme.fontIntroText

        'If FrmOpenTest.rLucidaConsole.Checked Then
        '    'Default
        '    Label1.Font = New Font("Lucida Console", 14, FontStyle.Regular)
        '    TextBox1.Font = New Font("Lucida Console", 18, FontStyle.Regular)
        '    'US
        '    Label5.Font = New Font("Lucida Console", 36, FontStyle.Regular)
        '    TextBox3.Font = New Font("Lucida Console", 36, FontStyle.Regular)
        '    'Nostalgia
        '    Label2.Font = New Font("Lucida Console", 12, FontStyle.Regular)
        '    TextBox2.Font = New Font("Lucida Console", 12, FontStyle.Regular)
        '    Button1.Font = New Font("Lucida Console", 11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    'Default
        '    Label1.Font = GetInstance(14, FontStyle.Regular)
        '    TextBox1.Font = GetInstance(18, FontStyle.Regular)
        '    'US
        '    Label5.Font = GetInstance(36, FontStyle.Regular)
        '    TextBox3.Font = GetInstance(36, FontStyle.Regular)
        '    'Nostalgia
        '    Label2.Font = GetInstance(12, FontStyle.Regular)
        '    TextBox2.Font = GetInstance(12, FontStyle.Regular)
        '    Button1.Font = GetInstance(11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rComicSansMS.Checked Then
        '    'Default
        '    Label1.Font = New Font("Comic Sans MS", 14, FontStyle.Regular)
        '    TextBox1.Font = New Font("Comic Sans MS", 18, FontStyle.Regular)
        '    'US
        '    Label5.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    TextBox3.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    'Nostalgia
        '    Label2.Font = New Font("Comic Sans MS", 12, FontStyle.Regular)
        '    TextBox2.Font = New Font("Comic Sans MS", 12, FontStyle.Regular)
        '    Button1.Font = New Font("Comic Sans MS", 11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rMicrosoftSansSerif.Checked Then
        '    'Default
        '    Label1.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
        '    TextBox1.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        '    'US
        '    Label5.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    TextBox3.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    'Nostalgia
        '    Label2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        '    TextBox2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        '    Button1.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rUbuntuCondensed.Checked Then
        '    'Default
        '    Label1.Font = New Font("Ubuntu Condensed", 14)
        '    TextBox1.Font = New Font("Ubuntu Condensed", 18)
        '    'US
        '    Label5.Font = New Font("Ubuntu Condensed", 36)
        '    TextBox3.Font = New Font("Ubuntu Condensed", 36)
        '    'Nostalgia
        '    Label2.Font = New Font("Ubuntu Condensed", 12, FontStyle.Regular)
        '    TextBox2.Font = New Font("Ubuntu Condensed", 12, FontStyle.Regular)
        '    Button1.Font = New Font("Ubuntu Condensed", 11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rMicroFLF.Checked Then
        '    'Default
        '    Label1.Font = New Font("MicroFLF", 14, FontStyle.Italic)
        '    TextBox1.Font = New Font("MicroFLF", 18, FontStyle.Bold Or FontStyle.Italic)
        '    'US
        '    Label5.Font = New Font("MicroFLF", 36, FontStyle.Italic)
        '    TextBox3.Font = New Font("MicroFLF", 36, FontStyle.Bold Or FontStyle.Italic)
        '    'Nostalgia
        '    Label2.Font = New Font("MicroFLF", 12, FontStyle.Regular)
        '    TextBox2.Font = New Font("MicroFLF", 12, FontStyle.Regular)
        '    Button1.Font = New Font("MicroFLF", 11.25, FontStyle.Regular)
        'ElseIf FrmOpenTest.rCustomFont.Checked Then
        '    'Default
        '    Label1.Font = New Font(My.Settings.customFont.OriginalFontName, 14, FontStyle.Regular)
        '    TextBox1.Font = New Font(My.Settings.customFont.OriginalFontName, 18, FontStyle.Regular)
        '    'US
        '    Label5.Font = New Font(My.Settings.customFont.OriginalFontName, 36, FontStyle.Regular)
        '    TextBox3.Font = New Font(My.Settings.customFont.OriginalFontName, 36, FontStyle.Regular)
        '    'Nostalgia
        '    Label2.Font = New Font(My.Settings.customFont.OriginalFontName, 12, FontStyle.Regular)
        '    TextBox2.Font = New Font(My.Settings.customFont.OriginalFontName, 12, FontStyle.Regular)
        '    Button1.Font = New Font(My.Settings.customFont.OriginalFontName, 11.25, FontStyle.Regular)
        'End If
        'If FrmOpenTest.rOCRAEXT.Checked Then
        '    Label1.Font = loadFont.GetInstance(14, FontStyle.Regular)
        '    TextBox1.Font = loadFont.GetInstance(11, FontStyle.Regular)
        'End If

        If FrmOpenTest.theme.musicTestEnabled Then
            WMP1.URL = CurDir() & "\Geluid\" & FrmOpenTest.theme.musicTest
            WMP1.settings.setMode("loop", True)
            WMP1.Ctlcontrols.play()
        End If
        If FrmOpenTest.theme.logoIntroEnabled Then
            PictureBox1.Image = FrmOpenTest.theme.imglogoIntro
        Else
            PictureBox1.Visible = False
        End If
        If FrmOpenTest.theme.backgroundIntroEnabled Then
            BackgroundImage = FrmOpenTest.theme.imgbackgroundIntro
        Else
            BackgroundImage = Nothing
        End If
        BackColor = FrmOpenTest.theme.backgroundColorIntro
        If FrmOpenTest.theme.introStyle = Theme.Style.Old Then
            Panel1.Visible = False
            Panel2.Visible = True
            Panel3.Visible = False
        ElseIf FrmOpenTest.theme.introStyle = Theme.Style.US Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
        Else
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
        End If
        Button1.FlatStyle = FlatStyle.System
        SetWindowTheme(Button1.Handle, "BUTTON", "")
        SetWindowTheme(TextBox2.Handle, "TEXTBOX", "")

        'If FrmOpenTest.rOudeMuziek.Checked Then
        '    WMP1.URL = CurDir() & "\Geluid\test_old.mp3"
        '    WMP1.settings.setMode("loop", True)
        '    WMP1.Ctlcontrols.play()
        'Else
        '    WMP1.URL = CurDir() & "\Geluid\test.mp3"
        '    WMP1.settings.setMode("loop", True)
        '    WMP1.Ctlcontrols.play()
        'End If
        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUK.Checked Then
        '    My.Computer.Audio.Stop()

        '    If FrmOpenTest.rNostalgia.Checked Then
        '        PictureBox1.Image = My.Resources.WIDM_logo_2004
        '        WMP1.URL = CurDir() & "\Geluid\test_old.mp3"
        '    Else
        '        PictureBox1.Image = My.Resources.UK_Logo
        '        WMP1.URL = CurDir() & "\Geluid\test_UK.mp3"
        '    End If

        '    WMP1.settings.setMode("loop", True)
        '    WMP1.Ctlcontrols.play()
        '    Label1.Font = New Font("Comic Sans MS", 14.25, FontStyle.Regular)
        '    Panel1.Visible = False
        '    Panel2.Visible = True
        '    Button1.FlatStyle = FlatStyle.System
        '    SetWindowTheme(Button1.Handle, "BUTTON", "")
        '    SetWindowTheme(TextBox2.Handle, "TEXTBOX", "")
        'ElseIf FrmOpenTest.rUS.Checked Then
        '    My.Computer.Audio.Stop()
        '    WMP1.URL = CurDir() & "\Geluid\test_US.mp3"
        '    WMP1.settings.setMode("loop", True)
        '    WMP1.Ctlcontrols.play()
        '    PictureBox1.Image = My.Resources.US_Logo
        '    Panel1.Visible = False
        '    Panel2.Visible = False
        '    Panel3.Visible = True
        '    BackgroundImage = My.Resources.US_Background
        '    PictureBox1.Hide()
        'ElseIf FrmOpenTest.rFrankrijk.Checked Then
        '    PictureBox1.Show()
        '    My.Computer.Audio.Stop()
        '    WMP1.URL = CurDir() & "\Geluid\test_FR.mp3"
        '    WMP1.settings.setMode("loop", True)
        '    WMP1.Ctlcontrols.play()
        '    PictureBox1.Image = My.Resources.Fr_Logo
        '    Panel1.Visible = True
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        '    BackgroundImage = Nothing
        'Else
        '    PictureBox1.Show()
        '    PictureBox1.Image = My.Resources.SmallLogoDark
        '    BackgroundImage = Nothing

        '    Panel1.Visible = True
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        'End If
        'If My.Settings.logo <> "" Then
        '    PictureBox1.ImageLocation = My.Settings.logo
        'End If
        'If My.Settings.background <> "" Then
        '    Me.BackgroundImage = Image.FromFile(My.Settings.background)
        '    Me.BackColor = My.Settings.backgroundColor
        'End If
        checkTested.Items.Clear()
        If FrmOpenTest.rGroep.Checked Then
            If FrmOpenTest.rCombobox.Checked Then
                For Each item In FrmOpenTest.listKandidaten.Items
                    ComboBox1.Items.Add(item)
                Next
                TextBox1.Visible = False
            Else
                ComboBox1.Visible = False
            End If
        Else
            ComboBox1.Visible = False
        End If
    End Sub

    Private Sub start()
        Try
            If FrmOpenTest.rVirtualKeyboard.Checked Then
                FrmOpenTest.killVirtualKeyboard()
            End If
            FrmTest.Show()
            FrmTest.tmTime.Start()
            If Not WMP1.playState = WMPPlayState.wmppsPlaying Then
                WMP1.Ctlcontrols.play()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            pressedEnter()

        End If
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Do you want to exit the quiz?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If
            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        If FrmOpenTest.rVirtualKeyboard.Checked Then
            FrmOpenTest.callVirtualKeyboard()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedItem
        pressedEnter()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = TextBox2.Text
        pressedEnter()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim response
        If My.Settings.language = "en" Then
            response = MsgBox("Do you want to exit the quiz?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        Else
            response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        End If
        If response = MsgBoxResult.Yes Then
            Close()
        End If
        '    If FrmOpenTest.rGroep.Checked Then
        '        If My.Settings.password = "" Then
        '            Close()
        '        Else
        '            FrmPassword.ShowDialog()
        '            If FrmPassword.cancel = True Then

        '            ElseIf FrmPassword.TextBox1.Text = My.Settings.password Then
        '                Close()
        '                Close()
        '            Else
        '                MsgBox("Verkeerd wachtwoord", MsgBoxStyle.Exclamation)

        '            End If
        '        End If
        '    Else
        '        Close()
        '    End If
        'Else

        'End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim response
        If My.Settings.language = "en" Then
            response = MsgBox("Do you want to exit the quiz?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        Else
            response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        End If
        If response = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Do you want to exit the quiz?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If

            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBox1.Text = TextBox3.Text
            pressedEnter()
        End If
    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        If FrmOpenTest.rVirtualKeyboard.Checked Then
            FrmOpenTest.callVirtualKeyboard()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBox1.Text = TextBox2.Text
            pressedEnter()
        End If
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick
        If FrmOpenTest.rVirtualKeyboard.Checked Then
            FrmOpenTest.callVirtualKeyboard()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim response
        If My.Settings.language = "en" Then
            response = MsgBox("Do you want to exit the quiz?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        Else
            response = MsgBox("Weet u zeker dat u de test wilt afsluiten?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        End If

        If response = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub
End Class
