Imports System.IO
Imports WMPLib

Public Class FrmStartExecutie
    ReadOnly _checkTested As New ListBox
    Dim _number As Integer = 0
    ReadOnly _candidatesList As New ListBox
    ReadOnly _nonRed As New ListBox
    Dim _timerInterval As Integer = 1
    Private Declare Function SetWindowTheme Lib "uxtheme" (
                                                          hWnd As IntPtr,
                                                          ByRef pszSubAppName As String,
                                                          ByRef pszSubIdList As String) _
        As Integer

    Private Sub frmStartExecutie_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Computer.Audio.Stop()
        'If FrmOpenTest.rVerwijderNaam.Checked Then

        '    SaveXML()
        '    'Dim templist As New ListBox
        '    'For Each item In FrmOpenTest.listKandidaten.Items
        '    '    templist.Items.Add(item)
        '    'Next
        '    FrmOpenTest.numAflevering.Value = FrmOpenTest.numAflevering.Value + 1
        '    For Each item In _nonRed.Items
        '        FrmOpenTest.listKandidaten.Items.Add(item)
        '    Next
        '    SaveXML()

        '    FrmOpenTest.numAflevering.Value = FrmOpenTest.numAflevering.Value - 1
        'End If
    End Sub

    Private Sub PressedEnter()

        If FrmOpenTest.rGroep.Checked Then
            If _candidatesList.Items.Contains(TextBox1.Text) = False Then
                If My.Settings.language = "en" Then
                    MsgBox("Name wasn't found, does this name exists?", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Naam niet gevonden, komt deze naam wel voor?", MsgBoxStyle.Exclamation)
                End If

                TextBox1.ReadOnly = False
            Else
                If _checkTested.Items.Contains(TextBox1.Text) Then
                    If My.Settings.language = "en" Then
                        MsgBox("Elimination was already executed by this candidate!", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Executie is al uitgevoerd door deze kandidaat!", MsgBoxStyle.Exclamation)
                    End If

                    TextBox1.ReadOnly = False
                Else
                    _checkTested.Items.Add(TextBox1.Text)
                    If CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults(TextBox1.Text).Screen <> FrmOpenTest.Rood Then
                        _nonRed.Items.Add(TextBox1.Text)
                    End If
                    Try
                        ComboBox1.Items.Remove(TextBox1.Text)
                    Catch ex As Exception

                    End Try
                    Start()
                End If

            End If
        Else
            Start()
        End If
    End Sub

    Private Sub Start()


        'Dim listviewChecked As String
        'For Each item In FrmOpenTest.listviewExecutie.CheckedItems
        '    listviewChecked = listviewChecked & vbCrLf & item.Text
        'Next
        If FrmOpenTest.rSchermGeluid.Checked Then
            Sound()
            If FrmOpenTest.rLangereGeluiden.Checked Then
                Timer1.Interval = _timerInterval
                Timer1.Start()
            Else
                Start2()
            End If
        Else
            Start2()
        End If
    End Sub

    Private Sub Start2()
        TextBox1.ReadOnly = False
        'listviewChecked.Contains(TextBox1.Text) = False
        Try
            'Dim lst As String = FrmOpenTest.listviewExecutie.CheckedItems.Item(0).SubItems(1).Text

            ' If FrmOpenTest.listKandidaten.Items.Contains(TextBox1.Text) Then
            'MessageBox.Show(FrmOpenTest.listviewExecutie.Items(0).SubItems(3).Text)
            'loadMusic()


            If CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults(TextBox1.Text).Screen = FrmOpenTest.Rood Then
                FrmExecutie.BackgroundImage = CurrentTheme.ImgRedScreen

                If FrmOpenTest.rAfscheidsmuziek.Checked Then
                    My.Computer.Audio.Stop()
                    'If FrmOpenTest.rMusic.Checked And FrmOpenTest.rRood.Checked And FrmOpenTest.listExecutie.Items.Contains(TextBox1.Text) Then
                    Timer2.Start()
                    'End If
                End If

            ElseIf CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults(TextBox1.Text).Screen = FrmOpenTest.Groen Then
                FrmExecutie.BackgroundImage = CurrentTheme.ImgGreenScreen
            Else
                Try
                    FrmExecutie.BackgroundImage = Image.FromFile(CurrentGroup.Screens(CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults(TextBox1.Text).Screen).Location)
                Catch ex As Exception
                    Log(ex.ToString())
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                End Try


            End If

            'Dim test As String
            ''FrmOpenTest.listviewExecutie.Items.Item(TextBox1.Text)
            'For Each item In FrmOpenTest.listviewExecutie.Items
            '    If item = TextBox1.Text Then
            '        MessageBox.Show(item.itemData)
            '        Exit For
            '    End If
            'Next
            'test = FrmOpenTest.listviewExecutie.Items.Item(TextBox1.Text).SubItems(3).Text


            ' Else


            ' End If
            If FrmOpenTest.rMuziekDoorspelen.Checked = False Then
                WMP2.Ctlcontrols.pause()
            Else
                '    My.Computer.Audio.Stop()
                '    WMP2.Ctlcontrols.stop()
            End If
            If Not WMP2.playState = WMPPlayState.wmppsPlaying Then
                WMP2.Ctlcontrols.play()

            End If
            If FrmOpenTest.rVirtualKeyboard.Checked Then
                FrmOpenTest.KillVirtualKeyboard()
            End If
            FrmExecutie.Show()

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & "Controleer of u namen heeft geselecteerd voor de executie.",
                   MsgBoxStyle.Critical)
            Log(ex.ToString())
            Close()
        End Try
    End Sub

    Private Sub frmStartExecutie_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Are you sure you want to exit the elimination?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If

            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub frmStartExecutie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExpandToMonitor(Me)

        FrmOpenTest.LoadTheme()

        'If FrmOpenTest.rAlleen.Checked Then
        '    MsgBox("Een executie voor u alleen? Helaas, dat kan niet!", MsgBoxStyle.Information)
        '    WMP1.Ctlcontrols.stop()
        '    My.Computer.Audio.Stop()
        '    Close()

        'End If
        If FrmOpenTest.rGeluidTest.Checked = False Then
            WMP2.settings.mute = True
        End If
        'WMP1.settings.volume = WMP1.settings.volume / 2
        Panel1.Top = (Me.Height / 2) - (Panel1.Height / 2)
        Panel1.Left = (Me.Width / 2) - (Panel1.Width / 2)
        Panel2.Top = (Me.Height / 2) - (Panel2.Height / 2)
        Panel2.Left = (Me.Width / 2) - (Panel2.Width / 2)
        Panel3.Top = (Me.Height / 2) - (Panel3.Height / 2)
        Panel3.Left = (Me.Width / 2) - (Panel3.Width / 2)
        pnlBelgium.Top = (Me.Height / 2) - (pnlBelgium.Height / 2)
        pnlBelgium.Left = (Me.Width / 2) - (pnlBelgium.Width / 2)
        If FrmOpenTest.rGroep.Checked Then
            If FrmOpenTest.rCombobox.Checked Then
                If My.Settings.language = "en" Then
                    Label1.Text = "Choose a name from the list:"
                Else
                    Label1.Text = "Kies een naam uit de lijst:"
                End If

            Else
                If My.Settings.language = "en" Then
                    Label1.Text = "Enter a name:"
                Else
                    Label1.Text = "Voer een naam in:"
                End If

            End If
        Else
            If My.Settings.language = "en" Then
                Label1.Text = "Enter a name:"
            Else
                Label1.Text = "Voer een naam in:"
            End If
        End If

        ComboBox1.Visible = True
        TextBox1.Visible = True

        'Default
        Label1.Font = CurrentTheme.FontIntroText
        TextBox1.Font = CurrentTheme.FontIntroTextfield

        Label1.ForeColor = CurrentTheme.ColorIntroText
        TextBox1.ForeColor = CurrentTheme.ColorIntroTextfield
        'US
        Label5.Font = CurrentTheme.FontIntroText
        TextBox3.Font = CurrentTheme.FontIntroTextfield
        'Nostalgia
        Label2.Font = CurrentTheme.FontIntroText
        TextBox2.Font = CurrentTheme.FontIntroTextfield
        Button1.Font = CurrentTheme.FontIntroText
        'Belgium
        lNameBelgium.Font = CurrentTheme.FontIntroText
        TextBox4.Font = CurrentTheme.FontIntroTextfield

        If CurrentTheme.MusicExecutionEnabled Then
            WMP2.URL = CurDir() & "\Geluid\" & CurrentTheme.MusicExecution
            WMP2.settings.setMode("loop", True)
            WMP2.Ctlcontrols.play()
        End If
        If CurrentTheme.LogoIntroEnabled Then
            PictureBox1.Image = CurrentTheme.ImgLogoIntro
        Else
            PictureBox1.Visible = False
        End If
        If CurrentTheme.BackgroundIntroEnabled Then
            BackgroundImage = CurrentTheme.ImgBackgroundIntro
            BackgroundImageLayout = CurrentTheme.BackgroundIntroSizeMode
        Else
            BackgroundImage = Nothing
        End If
        BackColor = CurrentTheme.BackgroundColorIntro
        If CurrentTheme.IntroStyle = Theme.Style.Old Then
            Panel1.Visible = False
            Panel2.Visible = True
            Panel3.Visible = False
            pnlBelgium.Visible = False
        ElseIf CurrentTheme.IntroStyle = Theme.Style.Us Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
            pnlBelgium.Visible = False
        ElseIf CurrentTheme.IntroStyle = Theme.Style.Belgium Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            pnlBelgium.Visible = True
        Else
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            pnlBelgium.Visible = False
        End If
        Button1.FlatStyle = FlatStyle.System
        SetWindowTheme(Button1.Handle, "BUTTON", "")
        SetWindowTheme(TextBox2.Handle, "TEXTBOX", "")

        'If FrmOpenTest.rMuziekAfspelen.Checked Then
        '    loadMusic()
        'End If
        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUK.Checked Then
        '    My.Computer.Audio.Stop()
        '    If FrmOpenTest.rNostalgia.Checked Then
        '        PictureBox1.Image = My.Resources.WIDM_logo_2004
        '        WMP2.URL = CurDir() & "\Geluid\executie_old.mp3"
        '    Else
        '        PictureBox1.Image = My.Resources.UK_Logo
        '        WMP2.URL = CurDir() & "\Geluid\test_UK.mp3"
        '    End If
        '    WMP2.settings.setMode("loop", True)
        '    WMP2.Ctlcontrols.play()
        '    'PictureBox1.Image = My.Resources.WIDM_logo_2004
        '    'Label1.Font = New Font("Comic Sans MS", 14.25, FontStyle.Regular)
        '    Panel1.Visible = False
        '    Panel2.Visible = True
        '    Button1.FlatStyle = FlatStyle.System
        '    SetWindowTheme(Button1.Handle, "BUTTON", "")
        '    SetWindowTheme(TextBox2.Handle, "TEXTBOX", "")
        'ElseIf FrmOpenTest.rUS.Checked Then
        '    My.Computer.Audio.Stop()
        '    WMP2.URL = CurDir() & "\Geluid\test_UK.mp3"
        '    WMP2.settings.setMode("loop", True)
        '    WMP2.Ctlcontrols.play()
        '    PictureBox1.Image = My.Resources.US_Logo
        '    Panel1.Visible = False
        '    Panel2.Visible = False
        '    Panel3.Visible = True
        '    BackgroundImage = My.Resources.US_Background
        '    PictureBox1.Hide()
        '    'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    '    Label1.Font = loadFont.GetInstance(14, FontStyle.Regular)
        '    '    TextBox1.Font = loadFont.GetInstance(11, FontStyle.Regular)
        'ElseIf FrmOpenTest.rFrankrijk.Checked Then
        '    My.Computer.Audio.Stop()
        '    WMP2.URL = CurDir() & "\Geluid\test_UK.mp3"
        '    WMP2.settings.setMode("loop", True)
        '    WMP2.Ctlcontrols.play()
        '    PictureBox1.Image = My.Resources.Fr_Logo
        '    Panel1.Visible = True
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        '    ' BackgroundImage = My.Resources.US_Background
        'End If
        'If My.Settings.logo <> "" Then
        '    PictureBox1.ImageLocation = My.Settings.logo
        'End If
        'If My.Settings.background <> "" Then
        '    Me.BackgroundImage = Image.FromFile(My.Settings.background)
        '    Me.BackColor = My.Settings.backgroundColor
        'End If
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
        '    TextBox1.Font = New Font("MicroFLF", 18, FontStyle.Italic Or FontStyle.Bold)
        '    'US
        '    Label5.Font = New Font("MicroFLF", 36, FontStyle.Italic)
        '    TextBox3.Font = New Font("MicroFLF", 36, FontStyle.Italic Or FontStyle.Bold)
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

        _checkTested.Items.Clear()
        _nonRed.Items.Clear()
        For Each li In CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults.Values
            _candidatesList.Items.Add(li.Candidate)
        Next
        If FrmOpenTest.rGroep.Checked Then
            If FrmOpenTest.rCombobox.Checked Then
                For Each item In _candidatesList.Items
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

    Private Sub Sound()
        Try
            Dim lines() As String
            If FrmOpenTest.rLangereGeluiden.Checked Then
                lines = File.ReadAllLines(CurDir() & "\Geluid\Schermgeluid lang.ini")
            Else
                lines = File.ReadAllLines(CurDir() & "\Geluid\Schermgeluid kort.ini")
            End If
            Dim rndnumber = New Random

            _number = CInt(Int(((lines.Count - 1) * Rnd()) + 1))

            WMP1.Ctlcontrols.stop()
            Dim result() As String = lines(_number).Split("#")
            _timerInterval = Val(result(1).ToString)
            WMP1.URL = CurDir() & "\Geluid\" & result(0)
        Catch ex As Exception
            Log(ex.ToString())
        End Try

        WMP1.Ctlcontrols.play()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If TextBox1.ReadOnly = False Then

            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                TextBox1.ReadOnly = True
                PressedEnter()
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Are you sure you want to exit the elimination?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If
            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        FrmOpenTest.CallVirtualKeyboard()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedItem
        PressedEnter()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Start2()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        WMP2.Ctlcontrols.pause()
        WMP3.URL = CurDir() & "\Geluid\aftiteling.mp3"
        WMP3.Ctlcontrols.play()
        Timer2.Stop()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = TextBox2.Text
        PressedEnter()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim response
        If My.Settings.language = "en" Then
            response = MsgBox("Are you sure you want to exit the elimination?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        Else
            response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        End If
        If response = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim response
        If My.Settings.language = "en" Then
            response = MsgBox("Are you sure you want to exit the elimination?",
                              MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
        Else
            response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
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
                response = MsgBox("Are you sure you want to exit the elimination?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If
            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBox1.Text = TextBox3.Text
            PressedEnter()
        End If
    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick
        FrmOpenTest.CallVirtualKeyboard()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBox1.Text = TextBox2.Text
            PressedEnter()
        End If
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick
        FrmOpenTest.CallVirtualKeyboard()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub tmToBack_Tick(sender As Object, e As EventArgs) Handles tmToBack.Tick
        'tmToBack.Stop()
        If CurrentTheme.LogoIntroPosition = Theme.Position.TopRight Then
            PictureBox1.Location = New Point(Me.Width - PictureBox1.Size.Width - 50, PictureBox1.Location.Y)
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim response
            If My.Settings.language = "en" Then
                response = MsgBox("Are you sure you want to exit the elimination?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            Else
                response = MsgBox("Weet u zeker dat u de executie wilt afsluiten?",
                                  MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2)
            End If
            If response = MsgBoxResult.Yes Then
                Close()
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextBox1.Text = TextBox4.Text
            PressedEnter()
        End If
    End Sub
End Class