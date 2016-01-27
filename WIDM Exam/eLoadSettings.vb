Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Module ELoadSettings
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
        'FrmOpenTest.header = My.Resources.header_2014_2
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
        FrmOpenTest.txtFolder.Text = My.Settings.folder
        FrmOpenTest.txtWedstrijdFile.Text = My.Settings.wedstrijdfile
        'FrmOpenTest.numAflevering.Value = Val(My.Settings.aflevering)

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

        'Add schermen to general combobox source
        If My.Settings.standaardinladen = True Then
            FrmOpenTest.rStandaardInladen.Checked = True
            FrmOpenTest.allesinladen()
        End If

        'FrmOpenTest.Label44.Text = My.Application.Info.Version.ToString

        Return 0
    End Function

    Public Function ExpandToMonitor(sender As Form)
        sender.Location = New Point(Screen.AllScreens(FrmOpenTest.rMonitor.SelectedIndex).Bounds.Location)
        sender.WindowState = FormWindowState.Maximized
        Return True
    End Function
End Module
