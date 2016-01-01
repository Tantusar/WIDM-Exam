Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Module eLoadSettings
    Public Function LoadSettings()
        'Detecting default language chosen by the installer. Cannot use register because I refuse to use it.
        If My.Computer.FileSystem.FileExists(CurDir() & "\language.ini") Then
            Try
                Dim read As New StreamReader(CurDir() & "\language.ini")
                If read.ReadToEnd() = "en" Then
                    My.Settings.language = "en"
                Else
                    My.Settings.language = "nl"
                End If
                read.Close()
                My.Computer.FileSystem.DeleteFile(CurDir() & "\language.ini")
                Application.Restart()
            Catch ex As Exception
            End Try
        End If

        'Detecting highDPI.
        FrmOpenTest.dpiPercent.Text = FrmOpenTest.CreateGraphics.DpiX.ToString
        FrmOpenTest.dpiPercent.Select(0, 0)
        If FrmOpenTest.dpiPercent.Text > 96 Then
            FrmOpenTest.pnl120dpi.Visible = True
            FrmOpenTest.Label38.Text = String.Format(getLang("dpiMessage"), FrmOpenTest.dpiPercent.Text)

        End If

        'Loading settings, mainly checkboxes
        If My.Settings.oudemuziek = True Then
            FrmOpenTest.rOudeMuziek.Checked = True
        End If
        checkFontAvailable()
        'FrmOpenTest.header = My.Resources.header_2014_2
        If My.Settings.theme = 0 Then
            FrmOpenTest.rNewTheme.Checked = True
        ElseIf My.Settings.theme = 1 Then
            FrmOpenTest.rNostalgia.Checked = True
        ElseIf My.Settings.theme = 2 Then
            FrmOpenTest.rUS.Checked = True
        ElseIf My.Settings.theme = 3 Then
            FrmOpenTest.rUK.Checked = True
        ElseIf My.Settings.theme = 4 Then
            FrmOpenTest.rFrankrijk.Checked = True
        End If
        If My.Settings.rWedstrijd = True Then
            FrmOpenTest.rWedstrijd.Checked = True
        End If


        If My.Settings.rComboBox = True Then
            FrmOpenTest.rCombobox.Checked = True
        End If
        If My.Settings.threerows = True Then
            FrmOpenTest.rThreeRows.Checked = True
        End If
        If My.Settings.saveatclose = True Then
            FrmOpenTest.rSaveAtClose.Checked = True
        End If
        If My.Settings.rLangereGeluiden = True Then
            FrmOpenTest.rLangereGeluiden.Checked = True
        End If
        If My.Settings.rMuziekAfspelen = True Then
            FrmOpenTest.rMuziekAfspelen.Checked = True
        End If
        If My.Settings.rAfscheidsmuziek = True Then
            FrmOpenTest.rAfscheidsmuziek.Checked = True
        End If
        If My.Settings.rSchermGeluid = True Then
            FrmOpenTest.rSchermGeluid.Checked = True
        End If
        If My.Settings.rVerwijderNaam = True Then
            FrmOpenTest.rVerwijderNaam.Checked = True
        End If
        If My.Settings.rMuziekDoorspelen = True Then
            FrmOpenTest.rMuziekDoorspelen.Checked = True
        End If
        If My.Settings.rGeluidTest = True Then
            FrmOpenTest.rGeluidTest.Checked = True
        End If
        If My.Settings.rNummers = True Then
            FrmOpenTest.rNummers.Checked = True
        End If
        If My.Settings.rBackup = True Then
            FrmOpenTest.rBackup.Checked = True
        End If
        If My.Settings.rVirtualKeyboard = True Then
            FrmOpenTest.rVirtualKeyboard.Checked = True
        End If
        If My.Settings.rNumberBeforeQuestion = True Then
            FrmOpenTest.rNumberBeforeQuestion.Checked = True
        End If
        If My.Settings.rRandom = True Then
            FrmOpenTest.rRandom.Checked = True
        End If
        FrmOpenTest.txtTest.Text = My.Settings.file
        FrmOpenTest.txtLogo.Text = My.Settings.logo
        FrmOpenTest.txtFolder.Text = My.Settings.folder
        FrmOpenTest.txtRoodscherm.Text = My.Settings.roodscherm
        FrmOpenTest.txtGroenscherm.Text = My.Settings.groenscherm
        FrmOpenTest.txtWedstrijdFile.Text = My.Settings.wedstrijdfile
        FrmOpenTest.numAflevering.Value = Val(My.Settings.aflevering)
        FrmOpenTest.txtCustomFont.Font = My.Settings.customFont
        FrmOpenTest.txtBackground.Text = My.Settings.background
        FrmOpenTest.pBackgroundColor.BackColor = My.Settings.backgroundColor

        Dim strHostName As String = Dns.GetHostName()
        Dim iphe As IPHostEntry = Dns.GetHostEntry(strHostName)

        For Each ipheal As IPAddress In iphe.AddressList
            If ipheal.AddressFamily = AddressFamily.InterNetwork Then
                FrmOpenTest.txtThisIP.Text = ipheal.ToString()
            End If
        Next

        If My.Settings.groepsmodus = True Then
            FrmOpenTest.rGroep.Checked = True
            FrmOpenTest.txtTest.Text = getLang("GroepsmodusAan")
            FrmOpenTest.Button1.Enabled = False
            FrmOpenTest.txtTest.Enabled = False
        Else
            FrmOpenTest.rAlleen.Checked = True
        End If

        Select Case My.Settings.schermstyle
            Case 0
                FrmOpenTest.rModern1.Checked = True
            Case 1
                FrmOpenTest.rModern2.Checked = True
            Case 2
                FrmOpenTest.rOud.Checked = True
            Case 3
                FrmOpenTest.rAangepast.Checked = True
            Case 4
                FrmOpenTest.rOud2.Checked = True
            Case 5
                FrmOpenTest.rwidm3015_1.Checked = True
            Case 6
                FrmOpenTest.rwidm3015_2.Checked = True
            Case 7
                FrmOpenTest.rFrankrijkSchermen.Checked = True
        End Select

        Select Case My.Settings.font
            Case 0
                FrmOpenTest.rLucidaConsole.Checked = True
            Case 1
                If FrmOpenTest.rOCRAEXT.Enabled = True Then
                    FrmOpenTest.rOCRAEXT.Checked = True
                Else
                    FrmOpenTest.rLucidaConsole.Checked = True
                End If
            Case 2
                FrmOpenTest.rComicSansMS.Checked = True
            Case 3
                FrmOpenTest.rMicrosoftSansSerif.Checked = True
            Case 4
                If FrmOpenTest.rUbuntuCondensed.Enabled = True Then
                    FrmOpenTest.rUbuntuCondensed.Checked = True
                Else
                    FrmOpenTest.rLucidaConsole.Checked = True
                End If
            Case 5
                FrmOpenTest.rCustomFont.Checked = True
            Case 6
                FrmOpenTest.rMicroFLF.Checked = True
            Case 999
                If FrmOpenTest.rUbuntuCondensed.Enabled = True Then
                    FrmOpenTest.rUbuntuCondensed.Checked = True
                Else
                    FrmOpenTest.rLucidaConsole.Checked = True
                End If
        End Select
        If FrmOpenTest.rAangepast.Checked Then
            FrmOpenTest.txtGroenscherm.Enabled = True
            FrmOpenTest.txtRoodscherm.Enabled = True
            FrmOpenTest.Button16.Enabled = True
            FrmOpenTest.Button17.Enabled = True
        Else
            FrmOpenTest.txtGroenscherm.Enabled = False
            FrmOpenTest.txtRoodscherm.Enabled = False
            FrmOpenTest.Button16.Enabled = False
            FrmOpenTest.Button17.Enabled = False
        End If

        'Add schermen to general combobox source
        If My.Settings.standaardinladen = True Then
            FrmOpenTest.rStandaardInladen.Checked = True
            FrmOpenTest.allesinladen()
        End If

        'FrmOpenTest.Label44.Text = My.Application.Info.Version.ToString

        Return 0
    End Function

    Public Function checkFontAvailable()
        Dim WindowsFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows)

        If Not My.Computer.FileSystem.FileExists(WindowsFolder & "\Fonts\Ubuntu-C.ttf") Then
            FrmOpenTest.rUbuntuCondensed.Enabled = False
        Else
            FrmOpenTest.rUbuntuCondensed.Font = New Font("Ubuntu Condensed", 8)
        End If
        If Not My.Computer.FileSystem.FileExists(WindowsFolder & "\Fonts\OCRAEXT.ttf") Then
            FrmOpenTest.rOCRAEXT.Enabled = False
        Else
            FrmOpenTest.rOCRAEXT.Font = GetInstance(8.25, FontStyle.Regular)
        End If
        If Not My.Computer.FileSystem.FileExists(WindowsFolder & "\Fonts\MicroFLF.ttf") Then
            FrmOpenTest.rMicroFLF.Enabled = False
        Else
            FrmOpenTest.rMicroFLF.Font = New Font("MicroFLF", 8)
        End If
        Return 0
    End Function

    Public Function expandToMonitor(sender As Form)
        sender.Location = New Point(Screen.AllScreens(FrmOpenTest.rMonitor.SelectedIndex).Bounds.Location)
        sender.WindowState = FormWindowState.Maximized
        Return True
    End Function
End Module
