Imports System.Configuration
Imports System.IO
Imports System.Media
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports ComponentOwl.BetterListView
Imports Newtonsoft.Json

Module eIo
    Public Sub Log(ByVal errorText As String)
        Dim location = CurDir() & "\WIDM Exam.log.txt"
        Dim temp As String = ""
        If My.Computer.FileSystem.FileExists(location) Then
            Dim objStreamReader As New IO.StreamReader(location)
            temp = objStreamReader.ReadToEnd
            objStreamReader.Close()
        End If
        Dim objStreamWriter As New IO.StreamWriter(location)
        objStreamWriter.Write(TimeOfDay & ":" & vbCrLf & " - " & errorText & vbCrLf & vbCrLf & temp)
        objStreamWriter.Close()
    End Sub

    Private Function BooleanToImage(ByVal bool As Boolean) As Image
        If bool = True Then
            Return My.Resources.tick
        Else
            Return My.Resources.cross
        End If
    End Function

    Public Function ReloadEpisodes()
        Try
            With FrmOpenTest.comboEpisode
                .Items.Clear()
                For Each ep As KeyValuePair(Of Integer, Episode) In CurrentGroup.Episodes
                    .Items.Add(ep.Key)
                Next
                .SelectedItem = CurrentGroup.CurrentEpisode
            End With

            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Public Function ReloadScreens()
        '   ToolStripComboBox1.Items.Clear()
        'txtListviewScherm.Items.Clear()
        'ToolStripComboBox1.Items.Add("Groen")
        'ToolStripComboBox1.Items.Add("Rood")
        'txtListviewScherm.Items.Add("Groen")
        'txtListviewScherm.Items.Add("Rood")
        'Dim li As ListViewItem
        'For Each li In Me.listviewScherm.Items
        '    ToolStripComboBox1.Items.Add(li.Text)
        '    txtListviewScherm.Items.Add(li.Text)
        'Next
        'ToolStripComboBox1.SelectedItem = "Rood"
        'txtListviewScherm.SelectedItem = "Groen"
        Try
            'Populate list
            With FrmOpenTest.listScreens
                .Items.Clear()
                For Each screen In CurrentGroup.Screens.Values
                    Dim newItem As New BetterListViewItem(screen.Name)
                    newItem.SubItems.Add(screen.Location)
                    .Items.Add(newItem)
                Next
            End With

            'Populate comboboxes
            With FrmOpenTest.ToolStripExecutionScreen
                .Items.Clear()
                .Items.Add(FrmOpenTest.Groen)
                .Items.Add(FrmOpenTest.Rood)
                For Each screen In CurrentGroup.Screens.Values
                    .Items.Add(screen.Name)
                Next
                .SelectedItem = FrmOpenTest.Rood
            End With
            With FrmOpenTest.txtListviewScherm
                .Items.Clear()
                .Items.Add(FrmOpenTest.Groen)
                .Items.Add(FrmOpenTest.Rood)
                For Each screen In CurrentGroup.Screens.Values
                    .Items.Add(screen.Name)
                Next
                .SelectedItem = FrmOpenTest.Groen
            End With
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Public Function ReloadExecution()
        Try
            With FrmOpenTest.listExecution
                .Items.Clear()
                For Each result In CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults.Values
                    Dim newItem As New BetterListViewItem(result.Candidate)
                    newItem.SubItems.Add(result.AnswersRight)
                    newItem.SubItems.Add(result.Time)
                    newItem.SubItems.Add(result.Screen)
                    If result.Jokers = "214748364" Then
                        newItem.SubItems.Add(FrmOpenTest.Vrijstelling)
                    Else
                        newItem.SubItems.Add(result.Jokers)
                    End If
                    .Items.Add(newItem)
                Next
                .ItemComparer = New ExecutionItemComparer()
                .ResumeSort(True)
            End With
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Public Function ReloadAnswers()
        Try
            With FrmOpenTest.listAnswers
                .Items.Clear()
                For Each answer In CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).Answers
                    If Not .Groups.ContainsKey(answer.Candidate) Then
                        .Groups.Add(New BetterListViewGroup(answer.Candidate, answer.Candidate))
                    End If
                    Dim newItem As New BetterListViewItem(answer.Number)
                    newItem.SubItems.Add(answer.Question)
                    newItem.SubItems.Add(answer.Candidate)
                    newItem.SubItems.Add(answer.Answer)
                    newItem.Group = .Groups(answer.Candidate)
                    .Items.Add(newItem)
                Next

            End With
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Public Function ReloadCandidates()
        Try
            With FrmOpenTest.listCandidates
                .Items.Clear()
                .Columns.Clear()
                FrmOpenTest.listCandidateActive.Items.Clear()

                Dim columnName As New BetterListViewColumnHeader
                columnName.Name = "listCandidatesName"
                columnName.Text = GetLang("Name")
                'columnName.CellTemplate = New DataGridViewTextBoxCell()
                'columnName.Style = BetterListViewColumnHeaderStyle.Sortable
                'columnName.SortMethod = BetterListViewSortMethod.Auto
                .Columns.Add(columnName)

                For Each ep As KeyValuePair(Of Integer, Episode) In CurrentGroup.Episodes
                    Dim columnEpisode As New BetterListViewColumnHeader
                    columnEpisode.Name = "dataCandidatesName" & ep.Key
                    columnEpisode.Text = GetLang("Afl") & ep.Key
                    columnEpisode.Width = 50
                    'columnEpisode.Style = BetterListViewColumnHeaderStyle.Sortable
                    'columnEpisode.SortMethod = BetterListViewSortMethod.Auto
                    .Columns.Add(columnEpisode)

                    FrmOpenTest.listCandidateActive.Items.Add(GetLang("Aflevering") & ep.Key)
                Next
                FrmOpenTest.listCandidateActive.SetItemChecked(0, True)

                For Each candidate In CurrentGroup.Candidates.Values
                    'Dim item As New OLVListItem(candidate.name)
                    'item.SubItems(0).Text = candidate.Value.name

                    Dim newItem As New BetterListViewItem(candidate.Name)
                    For Each ep As KeyValuePair(Of Integer, Episode) In CurrentGroup.Episodes
                        If candidate.Active.ContainsKey(ep.Key) Then
                            Dim subItem As New BetterListViewSubItem
                            subItem.Image = BooleanToImage(candidate.Active(ep.Key))
                            subItem.Tag = candidate.Active(ep.Key)
                            newItem.SubItems.Add(subItem)
                        Else
                            Dim subItem As New BetterListViewSubItem
                            subItem.Image = BooleanToImage(False)
                            subItem.Tag = False
                            newItem.SubItems.Add(subItem)
                        End If
                        'count += 1
                    Next

                    'Dim n As Integer = .Rows.Add()
                    '.Rows.Item(n).Cells(0).Value = candidate.name
                    'Dim count As Integer = 1
                    'For Each ep As KeyValuePair(Of Integer, Episode) In CurrentGroup.episodes
                    '    If candidate.active.ContainsKey(ep.Key) Then
                    '        .Rows.Item(n).Cells(count).Value = candidate.active(ep.Key)
                    '    Else
                    '        .Rows.Item(n).Cells(count).Value = False
                    '    End If
                    '    count += 1
                    'Next
                    .Items.Add(newItem)
                Next

                .ItemComparer = New CandidateItemComparer()
                .ResumeSort(True)
            End With

            With FrmOpenTest.txtWieisdemol
                .Items.Clear()
                For Each item In CurrentGroup.Candidates.Values
                    .Items.Add(item.Name)
                Next
                '.Items.Add(GetLang("geen"))
                .SelectedItem = CurrentGroup.Mole.Name
            End With
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Public Sub ReloadThemes()
        Try
            FrmOpenTest.comboThemes.Items.Clear()
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(CurDir() & "\Thema's\")
                If foundFile.EndsWith(".widmthema") Then
                    'FrmOpenTest.comboThemes.Items.Add(foundFile.Replace(CurDir() & "\Thema's\", ""))
                    FrmOpenTest.comboThemes.Items.Add(Path.GetFileName(foundFile))
                End If
            Next
        Catch ex As Exception
            Log(ex.ToString())
        End Try

    End Sub

    Public Function ReloadDataviews()
        ReloadCandidates()
        ReloadAnswers()
        ReloadExecution()
        ReloadScreens()
        ReloadEpisodes()
        Return True
    End Function

    Public Function LoadGroupmode()
        Try
            If Not My.Computer.FileSystem.FileExists(My.Settings.folder & "\group.widm") Then
                File.Create(My.Settings.folder & "\group.widm").Dispose()
                CurrentGroup = New Groupmode()
                Return True
            Else
                Dim objStreamReader As New IO.StreamReader(My.Settings.folder & "\group.widm")
                Dim temp As String = objStreamReader.ReadToEnd()
                'MsgBox(temp)
                CurrentGroup = JsonConvert.DeserializeObject(Of Groupmode)(temp)

                'Check validity of object. To prevent an empty file causing issues. (when disabling autosave)
                If CurrentGroup Is Nothing Then
                    CurrentGroup = New Groupmode()
                End If
                'MsgBox(CurrentGroup.episodes(1).number)
                objStreamReader.Close()
                Return True
            End If
        Catch ex As Exception
            Log(ex.ToString())
            Return False
        End Try
    End Function

    Public Function SaveGroupmode()
        Try
            Dim objStreamWriter As New IO.StreamWriter(My.Settings.folder & "\group.widm")
            objStreamWriter.Write(JsonConvert.SerializeObject(CurrentGroup, Newtonsoft.Json.Formatting.Indented))
            objStreamWriter.Close()
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            Return False
        End Try
    End Function

    'Public Function SaveXml()
    '    If FrmOpenTest.txtFolder.Text <> "" Then
    '        Try
    '            Dim settings As New XmlWriterSettings()
    '            settings.Indent = True
    '            settings.Encoding = Encoding.Default

    '            Dim xmlWrt As XmlWriter =
    '                    XmlWriter.Create(FrmOpenTest.txtFolder.Text & "\afl" & FrmOpenTest.numAflevering.Value & ".widm",
    '                                     settings)

    '            With xmlWrt

    '                ' Write the Xml declaration.
    '                .WriteStartDocument()

    '                ' Write a comment.
    '                .WriteComment("WIDM Exam v2 groepsmodus. Gemaakt door Koenvh (Koenvh.nl)")
    '                .WriteStartElement("Data")
    '                .WriteStartElement("candidates")
    '                For Each item In FrmOpenTest.listKandidaten.Items
    '                    .WriteString(vbNewLine)
    '                    .WriteString(Replace(item, vbLf, ""))
    '                Next
    '                .WriteEndElement()
    '                .WriteStartElement("mole")
    '                .WriteString(FrmOpenTest.txtWieisdemol.Text)
    '                .WriteEndElement()

    '                .WriteStartElement("answers")
    '                For Each myItem As ListViewItem In FrmOpenTest.listAntwoorden.Items
    '                    .WriteString(vbNewLine)
    '                    .WriteString(
    '                        Replace(
    '                            (myItem.Text & "#" & myItem.SubItems(1).Text & "#" & myItem.SubItems(2).Text & "#" &
    '                             myItem.SubItems(3).Text), vbLf, "")) '// write Item and SubItem.
    '                Next
    '                .WriteEndElement()
    '                .WriteStartElement("execution")
    '                For Each myItem2 As ListViewItem In FrmOpenTest.listviewExecutie.Items
    '                    .WriteString(vbNewLine)
    '                    .WriteString(
    '                        Replace(
    '                            (myItem2.Text & "#" & myItem2.SubItems(1).Text & "#" & myItem2.SubItems(2).Text & "#" &
    '                             myItem2.SubItems(3).Text & "#" & myItem2.SubItems(4).Text), vbLf, "")) _
    '                    '// write Item and SubItem.
    '                Next
    '                .WriteEndElement()
    '                .WriteStartElement("screens")
    '                For Each myItem3 As ListViewItem In FrmOpenTest.listviewScherm.Items
    '                    .WriteString(vbNewLine)
    '                    .WriteString(Replace((myItem3.Text & "#" & myItem3.SubItems(1).Text), vbLf, "")) _
    '                    '// write Item and SubItem.
    '                Next
    '                .WriteEndElement()
    '                .WriteEndDocument()
    '                .Close()

    '            End With
    '        Catch ex As Exception
    '            'MsgBox("Er ging iets mis met het opslaan!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
    '        End Try

    '        Return True
    '    Else
    '        If FrmOpenTest.StartedUp = True Then
    '            If My.Settings.language = "en" Then
    '                MsgBox("No folder has been chosen yet", MsgBoxStyle.Exclamation)
    '            Else
    '                MsgBox("Geen map gekozen", MsgBoxStyle.Exclamation)
    '            End If
    '        End If
    '        Return False
    '    End If
    'End Function

    'Public Function LoadXml()
    '    If FrmOpenTest.txtFolder.Text <> "" Then
    '        Try
    '            Dim candidates() As String = {""}
    '            Dim mole = ""
    '            Dim answers() As String = {""}
    '            Dim execution() As String = {""}
    '            Dim screens() As String = {""}

    '            Dim document As XmlReader
    '            document =
    '                New XmlTextReader(FrmOpenTest.txtFolder.Text & "\afl" & FrmOpenTest.numAflevering.Value & ".widm")
    '            While (document.Read())

    '                Dim type = document.NodeType


    '                If (type = XmlNodeType.Element) Then
    '                    If (document.Name = "candidates") Then
    '                        candidates = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
    '                    End If
    '                    If (document.Name = "mole") Then
    '                        mole = WebUtility.HtmlDecode(document.ReadInnerXml.ToString)
    '                    End If
    '                    If (document.Name = "answers") Then
    '                        answers = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
    '                    End If
    '                    If (document.Name = "execution") Then
    '                        execution = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
    '                    End If
    '                    If (document.Name = "screens") Then
    '                        screens = (WebUtility.HtmlDecode(document.ReadInnerXml.ToString)).Split(vbNewLine)
    '                    End If
    '                End If

    '            End While
    '            ' MsgBox("")
    '            document.Close()
    '            If Not FrmOpenTest.SelectedLoad(0) = False Then
    '                For Each item As String In candidates.Skip(1)
    '                    FrmOpenTest.listKandidaten.Items.Add(Replace(item, vbLf, ""))
    '                Next
    '                For Each item As String In FrmOpenTest.listKandidaten.Items
    '                    FrmOpenTest.txtWieisdemol.Items.Add(item)
    '                Next
    '                FrmOpenTest.txtWieisdemol.SelectedItem = mole
    '            End If
    '            If Not FrmOpenTest.SelectedLoad(1) = False Then
    '                For Each line As String In answers.Skip(1) '// loop thru array list.
    '                    Dim lineArray() As String = line.Split("#") '// separate by "#" character.
    '                    Dim newItem As New ListViewItem(Replace(lineArray(0).ToString.PadLeft(3), vbLf, "")) _
    '                    '// add text Item.

    '                    Try
    '                        newItem.SubItems.Add(lineArray(1))
    '                        newItem.SubItems.Add(lineArray(2))
    '                        newItem.SubItems.Add(lineArray(3))
    '                    Catch ex As Exception

    '                    End Try

    '                    'End If
    '                    FrmOpenTest.listAntwoorden.Items.Add(newItem) '// add Item to ListView.
    '                Next
    '            End If
    '            If Not FrmOpenTest.SelectedLoad(2) = False Then
    '                For Each line2 As String In execution.Skip(1) '// loop thru array list.
    '                    Dim lineArray() As String = line2.Split("#") '// separate by "#" character.
    '                    Dim newItem As New ListViewItem(Replace(lineArray(0).ToString.PadLeft(3), vbLf, "")) _
    '                    '// add text Item.

    '                    Try
    '                        newItem.SubItems.Add(lineArray(1))
    '                        newItem.SubItems.Add(lineArray(2))
    '                        newItem.SubItems.Add(lineArray(3))
    '                        'newItem.SubItems.Add(lineArray(4))
    '                        Try
    '                            'MsgBox("Y")
    '                            newItem.SubItems.Add(lineArray(4))
    '                        Catch ex As Exception
    '                            'MsgBox("N")
    '                            newItem.SubItems.Add("0")
    '                        End Try

    '                    Catch ex As Exception
    '                        MsgBox(ex.Message)
    '                    End Try

    '                    'End If
    '                    FrmOpenTest.listviewExecutie.Items.Add(newItem) '// add Item to ListView.
    '                Next
    '            End If
    '            If Not FrmOpenTest.SelectedLoad(3) = False Then
    '                For Each line3 As String In screens.Skip(1) '// loop thru array list.
    '                    Dim lineArray() As String = line3.Split("#") '// separate by "#" character.
    '                    Dim _
    '                        newItem As _
    '                            New ListViewItem(WebUtility.HtmlDecode(Replace(lineArray(0).ToString.PadLeft(3), vbLf,
    '                                                                           ""))) '// add text Item.

    '                    Try
    '                        newItem.SubItems.Add(lineArray(1))
    '                        newItem.SubItems.Add(lineArray(2))
    '                    Catch ex As Exception

    '                    End Try

    '                    'End If
    '                    FrmOpenTest.listviewScherm.Items.Add(newItem) '// add Item to ListView.
    '                Next
    '            End If
    '            FrmOpenTest.CalculateCandidates()
    '            Return True
    '        Catch ex As Exception
    '            'MsgBox("Er ging iets mis met het inladen!", MsgBoxStyle.Exclamation)
    '            Return False
    '        End Try

    '    Else
    '        If FrmOpenTest.StartedUp = True Then
    '            If My.Settings.language = "en" Then
    '                MsgBox("No folder has been chosen yet", MsgBoxStyle.Exclamation)
    '            Else
    '                MsgBox("Geen map gekozen", MsgBoxStyle.Exclamation)
    '            End If
    '        End If
    '        Return False
    '    End If
    'End Function

    Public Function BackupXml()


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

    Public Sub ExportSettings()
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

    Public Sub ImportSettings()
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
End Module
