Imports System.Configuration
Imports System.IO
Imports System.Media
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml

Module eIO
    Public Function SaveXML()
        If FrmOpenTest.txtFolder.Text <> "" Then
            Try
                Dim settings As New XmlWriterSettings()
                settings.Indent = True
                settings.Encoding = Encoding.Default

                Dim XmlWrt As XmlWriter =
                        XmlWriter.Create(FrmOpenTest.txtFolder.Text & "\afl" & FrmOpenTest.numAflevering.Value & ".widm",
                                         settings)

                With XmlWrt

                    ' Write the Xml declaration.
                    .WriteStartDocument()

                    ' Write a comment.
                    .WriteComment("WIDM Exam v2 groepsmodus. Gemaakt door Koenvh (Koenvh.nl)")
                    .WriteStartElement("Data")
                    .WriteStartElement("candidates")
                    For Each item In FrmOpenTest.listKandidaten.Items
                        .WriteString(vbNewLine)
                        .WriteString(Replace(item, vbLf, ""))
                    Next
                    .WriteEndElement()
                    .WriteStartElement("mole")
                    .WriteString(FrmOpenTest.txtWieisdemol.Text)
                    .WriteEndElement()

                    .WriteStartElement("answers")
                    For Each myItem As ListViewItem In FrmOpenTest.listAntwoorden.Items
                        .WriteString(vbNewLine)
                        .WriteString(
                            Replace(
                                (myItem.Text & "#" & myItem.SubItems(1).Text & "#" & myItem.SubItems(2).Text & "#" &
                                 myItem.SubItems(3).Text), vbLf, "")) '// write Item and SubItem.
                    Next
                    .WriteEndElement()
                    .WriteStartElement("execution")
                    For Each myItem2 As ListViewItem In FrmOpenTest.listviewExecutie.Items
                        .WriteString(vbNewLine)
                        .WriteString(
                            Replace(
                                (myItem2.Text & "#" & myItem2.SubItems(1).Text & "#" & myItem2.SubItems(2).Text & "#" &
                                 myItem2.SubItems(3).Text & "#" & myItem2.SubItems(4).Text), vbLf, "")) _
                        '// write Item and SubItem.
                    Next
                    .WriteEndElement()
                    .WriteStartElement("screens")
                    For Each myItem3 As ListViewItem In FrmOpenTest.listviewScherm.Items
                        .WriteString(vbNewLine)
                        .WriteString(Replace((myItem3.Text & "#" & myItem3.SubItems(1).Text), vbLf, "")) _
                        '// write Item and SubItem.
                    Next
                    .WriteEndElement()
                    .WriteEndDocument()
                    .Close()

                End With
            Catch ex As Exception
                'MsgBox("Er ging iets mis met het opslaan!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            End Try

            Return True
        Else
            If FrmOpenTest.startedUp = True Then
                If My.Settings.language = "en" Then
                    MsgBox("No folder has been chosen yet", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Geen map gekozen", MsgBoxStyle.Exclamation)
                End If
            End If
            Return False
        End If
    End Function

    Public Function LoadXML()
        If FrmOpenTest.txtFolder.Text <> "" Then
            Try
                Dim candidates() As String = {""}
                Dim mole = ""
                Dim answers() As String = {""}
                Dim execution() As String = {""}
                Dim screens() As String = {""}

                Dim document As XmlReader
                document =
                    New XmlTextReader(FrmOpenTest.txtFolder.Text & "\afl" & FrmOpenTest.numAflevering.Value & ".widm")
                While (document.Read())

                    Dim type = document.NodeType


                    If (type = XmlNodeType.Element) Then
                        If (document.Name = "candidates") Then
                            candidates = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
                        End If
                        If (document.Name = "mole") Then
                            mole = WebUtility.HtmlDecode(document.ReadInnerXml.ToString)
                        End If
                        If (document.Name = "answers") Then
                            answers = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
                        End If
                        If (document.Name = "execution") Then
                            execution = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
                        End If
                        If (document.Name = "screens") Then
                            screens = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
                        End If
                    End If

                End While
                ' MsgBox("")
                document.Close()
                If Not FrmOpenTest.selectedLoad(0) = False Then
                    For Each item As String In candidates.Skip(1)
                        FrmOpenTest.listKandidaten.Items.Add(Replace(item, vbLf, ""))
                    Next
                    For Each item As String In FrmOpenTest.listKandidaten.Items
                        FrmOpenTest.txtWieisdemol.Items.Add(item)
                    Next
                    FrmOpenTest.txtWieisdemol.SelectedItem = mole
                End If
                If Not FrmOpenTest.selectedLoad(1) = False Then
                    For Each line As String In answers.Skip(1) '// loop thru array list.
                        Dim lineArray() As String = line.Split("#") '// separate by "#" character.
                        Dim newItem As New ListViewItem(Replace(lineArray(0).ToString.PadLeft(3), vbLf, "")) _
                        '// add text Item.

                        Try
                            newItem.SubItems.Add(lineArray(1))
                            newItem.SubItems.Add(lineArray(2))
                            newItem.SubItems.Add(lineArray(3))
                        Catch ex As Exception

                        End Try

                        'End If
                        FrmOpenTest.listAntwoorden.Items.Add(newItem) '// add Item to ListView.
                    Next
                End If
                If Not FrmOpenTest.selectedLoad(2) = False Then
                    For Each line2 As String In execution.Skip(1) '// loop thru array list.
                        Dim lineArray() As String = line2.Split("#") '// separate by "#" character.
                        Dim newItem As New ListViewItem(Replace(lineArray(0).ToString.PadLeft(3), vbLf, "")) _
                        '// add text Item.

                        Try
                            newItem.SubItems.Add(lineArray(1))
                            newItem.SubItems.Add(lineArray(2))
                            newItem.SubItems.Add(lineArray(3))
                            'newItem.SubItems.Add(lineArray(4))
                            Try
                                'MsgBox("Y")
                                newItem.SubItems.Add(lineArray(4))
                            Catch ex As Exception
                                'MsgBox("N")
                                newItem.SubItems.Add("0")
                            End Try

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        'End If
                        FrmOpenTest.listviewExecutie.Items.Add(newItem) '// add Item to ListView.
                    Next
                End If
                If Not FrmOpenTest.selectedLoad(3) = False Then
                    For Each line3 As String In screens.Skip(1) '// loop thru array list.
                        Dim lineArray() As String = line3.Split("#") '// separate by "#" character.
                        Dim _
                            newItem As _
                                New ListViewItem(WebUtility.HtmlDecode(Replace(lineArray(0).ToString.PadLeft(3), vbLf,
                                                                               ""))) '// add text Item.

                        Try
                            newItem.SubItems.Add(lineArray(1))
                            newItem.SubItems.Add(lineArray(2))
                        Catch ex As Exception

                        End Try

                        'End If
                        FrmOpenTest.listviewScherm.Items.Add(newItem) '// add Item to ListView.
                    Next
                End If
                FrmOpenTest.calculateCandidates()
                Return True
            Catch ex As Exception
                'MsgBox("Er ging iets mis met het inladen!", MsgBoxStyle.Exclamation)
                Return False
            End Try

        Else
            If FrmOpenTest.startedUp = True Then
                If My.Settings.language = "en" Then
                    MsgBox("No folder has been chosen yet", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Geen map gekozen", MsgBoxStyle.Exclamation)
                End If
            End If
            Return False
        End If
    End Function

    Public Function BackupXML()


        Dim time As DateTime = DateTime.Now
        Dim format = "yy-MM-dd HH.mm"
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Settings.folder & "\")
            If foundFile.EndsWith("widm3") Or foundFile.EndsWith("widm") Then
                'MsgBox(My.Settings.folder & "\" & FormatDateTime(DateTime.Now, DateFormat.ShortDate) & "\" & System.IO.Path.GetFileName(foundFile))
                My.Computer.FileSystem.CopyFile(foundFile,
                                                My.Settings.folder & "\" & "Back-up " & time.ToString(format) & "\" &
                                                Path.GetFileName(foundFile))
            End If
        Next
        Return 0
    End Function

    Public Sub webUpdate()
        FrmOpenTest.Timer1.Stop()
        'Dim Online As String
        FrmOpenTest.ToolStripButton2.Text = "Update"
        FrmOpenTest.ToolStripButton2.Enabled = True

        FrmUpdater.newversionnumber = FrmOpenTest.webclient.DocumentTitle.ToString
        If My.Computer.Network.IsAvailable = True Then
            If IsNumeric(FrmOpenTest.webclient.DocumentTitle.ToString) Then
                If FrmOpenTest.webclient.DocumentTitle.ToString > My.Application.Info.Version.ToString Then
                    My.Computer.Audio.PlaySystemSound(SystemSounds.Beep)
                    If My.Settings.language = "en" Then
                        FrmUpdater.Button1.Text = "Download now!"
                    Else
                        FrmUpdater.Button1.Text = "Download nu!"
                    End If
                    FrmUpdater.Button1.Enabled = True

                    FrmUpdater.Label7.Visible = True
                    FrmUpdater.Label8.Visible = True
                    FrmUpdater.newversion = True
                    FrmUpdater.txtLatest.BackColor = Color.LightGreen
                    FrmUpdater.txtCurrent.BackColor = Color.LightCoral

                    FrmUpdater.ShowDialog()
                Else
                    'MessageBox.Show("You have the current version")
                    FrmUpdater.newversion = False
                    If My.Settings.language = "en" Then
                        FrmUpdater.Button1.Text = "No update available"
                    Else
                        FrmUpdater.Button1.Text = "Geen update beschikbaar"
                    End If

                    FrmUpdater.Button1.Enabled = False
                    'MsgBox("Uw versie is up-to-date", MsgBoxStyle.Information)
                End If

            Else
                'MessageBox.Show("You have the current version")
                FrmUpdater.newversion = False
                If My.Settings.language = "en" Then
                    FrmUpdater.Button1.Text = "Can't check for updates"
                Else
                    FrmUpdater.Button1.Text = "Kan niet op updates controleren"
                End If
                FrmUpdater.Button1.Enabled = False
                'MsgBox("Uw versie is up-to-date", MsgBoxStyle.Information)
            End If
        Else
            FrmOpenTest.ToolStripButton2.Text = "Update offline"
            FrmOpenTest.ToolStripButton2.Enabled = False
        End If
    End Sub

    Public Sub exportSettings()
        My.Settings.Save()
        My.Settings.Reload()
        'http://www.vbforums.com/showthread.php?674434-Import-Export-of-My.Settings
        Dim sDialog As New SaveFileDialog()
        sDialog.DefaultExt = ".AppSettings"
        sDialog.Filter = "Application Settings (*.AppSettings)|*AppSettings"

        If sDialog.ShowDialog() = DialogResult.OK Then

            Using sWriter As New StreamWriter(sDialog.FileName)

                For Each setting As SettingsPropertyValue In My.Settings.PropertyValues
                    'Apparently the type font cannot be converted, catching errors as a workaround.
                    Try
                        sWriter.WriteLine(setting.Name & "," & setting.PropertyValue.ToString())
                    Catch ex As Exception

                    End Try


                Next

            End Using

            My.Settings.Save()
            If My.Settings.language = "en" Then
                MessageBox.Show("Settings are exported.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Instellingen zijn geëxporteerd.", "Exporteren", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            End If


        End If
    End Sub

    Public Sub importSettings()
        Dim oDialog As New OpenFileDialog
        oDialog.Filter = "Application Settings (*.AppSettings)|*AppSettings"

        If oDialog.ShowDialog() = DialogResult.OK Then

            Using sReader As New StreamReader(oDialog.FileName)

                While sReader.Peek() > 0

                    Dim input = sReader.ReadLine()

                    ' Split comma delimited data ( SettingName,SettingValue )  
                    Dim dataSplit = input.Split(CChar(","))

                    '           Setting         Value  
                    Try
                        My.Settings(dataSplit(0)) = dataSplit(1)


                    Catch ex As Exception

                    End Try


                End While

            End Using

            My.Settings.Save()

            If My.Settings.language = "en" Then
                MessageBox.Show("Settings are imported.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Instellingen zijn geïmporteerd.", "Importeren", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Function GetMd5Hash(md5Hash As MD5, input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()
    End Function 'GetMd5Hash
End Module
