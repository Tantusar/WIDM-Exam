Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Xml
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json
Imports Question = WIDM_Exam.Question

Public Class FrmTestMaken
    Const Vraag = "Vraag"
    Const TekstTussendoor = "Tekst tussendoor"
    Const OpenVraag = "Open vraag"

    Dim document As XmlReader
    Dim question As String = ""
    Dim answers As String = ""
    Dim amount As String = ""
    Dim correctanswer As String = ""
    Dim text1 As String = ""
    Dim text2 As String = ""
    Dim intCount0 As Integer = 0
    Dim encryptedTest As Boolean = False
    Dim usesave As Boolean = False

    Private Sub FrmTestMaken_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim result
        If My.Settings.language = "en" Then
            result = MessageBox.Show("Do you want to save the quiz before closing?", "Save?",
                                     MessageBoxButtons.YesNoCancel)
        Else
            result = MessageBox.Show("Wilt u de test opslaan alvorens het venster te sluiten?", "Opslaan?",
                                     MessageBoxButtons.YesNoCancel)
        End If

        If result = DialogResult.Yes Then
            savebutton()
        ElseIf result = DialogResult.No Then
        ElseIf result = DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmTestMaken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQuestion.AutoCompleteMode = AutoCompleteMode.Append
        'txtQuestion.DropDownStyle = ComboBoxStyle.DropDownList
        txtQuestion.AutoCompleteSource = AutoCompleteSource.ListItems
        If FrmOpenTest.rAlleen.Checked = True Then
            rNormalTest.Checked = True
            rGroepsModusTest.Checked = False
        Else
            rNormalTest.Checked = False
            rGroepsModusTest.Checked = True
        End If

        NumericUpDown1.Value = FrmOpenTest.numAflevering.Value
        NumericUpDown1.Minimum = 1
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Not ComboBox1.SelectedItem = "" Then
            Dim newItem As New ListViewItem
            If txtAnswers.Text <> "" Then
                newItem.Text = "Vraag" '// add text Item.
            Else
                newItem.Text = "Open vraag" '// add text Item.
            End If
            newItem.Name = "b" & ComboBox1.SelectedIndex + 1

            newItem.SubItems.Add(txtQuestion.Text)

            newItem.SubItems.Add(Replace(txtAnswers.Text, vbNewLine, "##")) '// add SubItem.

            newItem.SubItems.Add(ComboBox1.SelectedItem.ToString) '// add SubItem.

            newItem.SubItems.Add(txtAnswers.Lines.Count.ToString) '// add SubItem.

            newItem.SubItems.Add("b" & ComboBox1.SelectedIndex + 1)

            listPanel.Items.Add(newItem) '// add Item to ListView.

            txtQuestion.Items.Clear()
            BuildDatabase()

            txtAnswers.Clear()
            ComboBox1.Items.Clear()
            txtQuestion.Text = ""
        Else
            If My.Settings.language = "en" Then
                MsgBox("Are you sure there isn't a right answer?", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Hmm... Zeker weten dat er geen goed antwoord is?", MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        Dim temp As String = ComboBox1.SelectedItem
        ComboBox1.Items.Clear()
        Dim item As String
        For Each item In txtAnswers.Lines
            ComboBox1.Items.Add(item)
        Next
        ComboBox1.Items.Add("(geen)")
        ComboBox1.SelectedItem = "(geen)"
        ComboBox1.SelectedItem = temp
    End Sub

    Private Sub txtAnswers_TextChanged(sender As Object, e As EventArgs) Handles txtAnswers.TextChanged
        Dim temp As String = ComboBox1.SelectedItem
        ComboBox1.Items.Clear()
        Dim item As String
        For Each item In txtAnswers.Lines
            ComboBox1.Items.Add(item)
        Next
        ComboBox1.Items.Add("(geen)")
        ComboBox1.SelectedItem = temp
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim newItem As New ListViewItem("Tekst tussendoor") '// add text Item.
        newItem.SubItems.Add(txtTekst1.Text)

        newItem.SubItems.Add(txtTekst2.Text) '// add SubItem.

        listPanel.Items.Add(newItem) '// add Item to ListView.

        txtTekst1.Clear()
        txtTekst2.Clear()
    End Sub

    Private Sub Save()
        'Create a list
        Dim questions As Question() = {}
        For Each row As ListViewItem In listPanel.Items
            If row.SubItems(0).Text = Vraag Then
                Dim tempAnswers As Answer() = {}
                Dim i = 0
                'Split answers to array
                For i = 0 To row.SubItems(2).Text.Split(New String() {"##"}, StringSplitOptions.RemoveEmptyEntries).Count - 1
                    tempAnswers.Add(New Answer(i, row.SubItems(2).Text.Split(New String() {"##"}, StringSplitOptions.RemoveEmptyEntries)(i)))
                Next
                'Add to list
                questions.Add(New Question(row.SubItems(1).Text, tempAnswers, row.SubItems(5).Text, 1))
            ElseIf row.SubItems(0).Text = TekstTussendoor Then
                questions.Add(New Question(row.SubItems(1).Text, row.SubItems(2).Text))

            ElseIf row.SubItems(0).Text = OpenVraag Then
                Dim openQuestion As New Question
                openQuestion.text = row.SubItems(1).Text
                questions.Add(openQuestion)
            End If
        Next

        Dim test As New Test()
        test.author = "Koen! :-)"
        'TODO: Create way to use user input for author and comment.
        test.questions = questions


        Dim objStreamWriter As New IO.StreamWriter(SaveFileDialog1.FileName)
        'Serialize list
        objStreamWriter.Write(JsonConvert.SerializeObject(test, Newtonsoft.Json.Formatting.Indented))
        objStreamWriter.Close()
    End Sub

    Sub Open(ByVal buildDatabase As Boolean)

        Try
            'Check whether file exists, if not > create.
            If Dir(OpenFileDialog1.FileName) <> "" Then
            Else
                File.Create(OpenFileDialog1.FileName).Dispose()
            End If

            'Read and deserialize content
            Dim objStreamReader As New StreamReader(OpenFileDialog1.FileName)
            Dim output As String = objStreamReader.ReadToEnd()
            objStreamReader.Close()

            Dim JSONdeserialized = JsonConvert.DeserializeObject(output)

            'Loop through questions
            For Each item In JSONdeserialized("questions")
                Dim newItem
                'Check type
                If item("text").ToString() <> "" Then
                    If item("answers").ToString() = "" Then
                        newItem = New ListViewItem(OpenVraag) '// add text Item.
                        newItem.SubItems.Add(item("text").ToString())
                    Else
                        newItem = New ListViewItem(Vraag) '// add text Item.
                        newItem.SubItems.Add(item("text").ToString())
                        Dim answerString As String = ""
                        For Each answer In item("answers")
                            'Add answers to string, split by ##
                            answerString += answer("text").ToString() & "##"
                        Next
                        'Remove last ##, why would we want that? :-)
                        newItem.SubItems.Add(answerString.TrimEnd("##"))
                        Dim indexRightAnswer As Integer = Val(Replace(item("rightAnswer").ToString(), "b", ""))
                        'Convert to val, replace bn to n.
                        newItem.SubItems.Add(item("answers")(indexRightAnswer).ToString())
                        newItem.SubItems.Add(item("answers").Count)
                        newItem.SubItems.Add(item("rightAnswer").ToString())
                    End If
                Else
                    newItem = New ListViewItem("Tekst tussendoor") '// add text Item.
                    newItem.SubItems.Add(item("text1").ToString())
                    newItem.SubItems.Add(item("text2").ToString())
                End If
                'Look whether the database with existing questions is building. Will cause duplicates if not properly handled.
                If buildDatabase = True Then
                    listDB.Items.Add(newItem)
                Else
                    listPanel.Items.Add(newItem)
                End If

            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        For Each i As ListViewItem In listPanel.SelectedItems
            listPanel.Items.Remove(i)
        Next
    End Sub

    Private Sub listPanel_KeyDown(sender As Object, e As KeyEventArgs) Handles listPanel.KeyDown
        If e.KeyCode = Keys.Delete Then
            For Each lv As ListViewItem In listPanel.SelectedItems
                listPanel.Items.Remove(lv)
            Next
        End If
    End Sub

    Private Sub listPanel_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles listPanel.MouseDoubleClick
        btnBewerken()
    End Sub

    'Private Sub listPanel_MouseHover(sender As Object, ByVal e As MouseEventArgs) Handles listPanel.MouseHover
    '    Dim itm As ListViewItem
    '    itm = Me.listPanel.GetItemAt(e.X, e.Y)
    '    If Not itm Is Nothing Then
    '        ' MessageBox.Show(itm.Text)
    '    End If
    '    Dim tt As New ToolTip
    '    tt.SetToolTip(listPanel, itm.Text)
    '    itm = Nothing
    'End Sub

    Private Sub listPanel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listPanel.SelectedIndexChanged
        If listPanel.SelectedItems.Count = 0 Then
            Button3.Enabled = False
            Button4.Enabled = False
        Else
            Button3.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Sub savebutton()
        If rNormalTest.Checked Then
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                Save()

            Else
                If My.Settings.language = "en" Then
                    MsgBox("Houston, we have a problem with saving the file.", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Houston, we have a problem with saving the file.", MsgBoxStyle.Exclamation)
                End If

            End If
        Else
            If FrmOpenTest.rGroep.Checked Then
                If Not My.Settings.folder = "" Then
                    If usesave = False Then
                        SaveFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
                    End If
                    'MsgBox(OpenFileDialog1.FileName)
                    Save()
                Else
                    If My.Settings.language = "en" Then
                        MsgBox("No folder chosen under 'Group mode'", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Geen map onder 'Groepsmodus' gekozen!", MsgBoxStyle.Exclamation)
                    End If

                End If
            Else
                If My.Settings.language = "en" Then
                    MsgBox("Group mode has to be on before you can edit those quizzes!", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Groepsmodus moet aanstaan om testen hiervan te kunnen bewerken!", MsgBoxStyle.Exclamation)
                End If

            End If
        End If
        OpenFileDialog1.FileName = SaveFileDialog1.FileName
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        SaveFileDialog1.FileName = OpenFileDialog1.SafeFileName
        savebutton()
    End Sub

    Sub btnBewerken()
        Try
            Dim lvi As ListViewItem
            For Each lvi In listPanel.SelectedItems
                If lvi.SubItems(0).Text = Vraag Then
                    txtQuestion.Text = lvi.SubItems(1).Text
                    txtAnswers.Text = Replace(lvi.SubItems(2).Text, "##", vbNewLine)
                    ComboBox1.SelectedIndex = Val(Replace(lvi.SubItems(5).Text, "b", "") - 1)
                ElseIf lvi.SubItems(0).Text = OpenVraag Then
                    txtQuestion.Text = lvi.SubItems(1).Text
                ElseIf lvi.SubItems(0).Text = TekstTussendoor Then
                    txtTekst1.Text = lvi.SubItems(1).Text
                    txtTekst2.Text = lvi.SubItems(2).Text
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs)
        btnBewerken()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.SelectedItem = "" Then
            If My.Settings.language = "en" Then
                MsgBox("Are you sure there is no right answer?", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Hmm... Zeker weten dat er geen goed antwoord is?", MsgBoxStyle.Exclamation)
            End If

        Else


            Try
                Dim lvi As ListViewItem
                For Each lvi In listPanel.SelectedItems
                    lvi.Name = "b" & ComboBox1.SelectedIndex + 1
                    If txtAnswers.Text <> "" Then
                        lvi.SubItems(0).Text = "Vraag" '// add text Item.
                    Else
                        lvi.SubItems(0).Text = "Open vraag" '// add text Item.
                    End If
                    lvi.SubItems(1).Text = txtQuestion.Text
                    lvi.SubItems(2).Text = Replace(txtAnswers.Text, vbNewLine, "##")
                    lvi.SubItems(3).Text = ComboBox1.SelectedItem.ToString
                    lvi.SubItems(4).Text = txtAnswers.Lines.Count.ToString
                    lvi.SubItems(5).Text = "b" & ComboBox1.SelectedIndex + 1
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            txtQuestion.Items.Clear()
            BuildDatabase()
            txtAnswers.Clear()
            ComboBox1.Items.Clear()
            txtQuestion.Text = ""
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim lvi As ListViewItem
            For Each lvi In listPanel.SelectedItems
                lvi.SubItems(1).Text = txtTekst1.Text
                lvi.SubItems(2).Text = txtTekst2.Text

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        txtTekst1.Clear()
        txtTekst2.Clear()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        For Each i As ListViewItem In listPanel.Items
            listPanel.Items.Remove(i)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    End Sub

    Sub ConvertCorrectAnswerToText()

        Dim lv As ListViewItem

        For Each lv In listPanel.Items
            Try
                If lv.SubItems(0).Text = "Vraag" Then
                    If Not Replace(lv.SubItems(5).Text, "b", "") = "0" Then


                        txtAnswers.Text = Replace(lv.SubItems(2).Text, "##", vbNewLine)
                        ComboBox1.SelectedIndex = Val(Replace(lv.SubItems(5).Text, "b", "") - 1)
                        lv.SubItems(3).Text = ComboBox1.SelectedItem.ToString
                        'Dim TextLines As Array

                        'TextLines = Replace(lv.SubItems(2).Text, "##", vbNewLine)

                        'lv.SubItems(3).Text = TextLines.FindIndex(lv.SubItems(3).Text)
                        ' lv.SubItems(3).Text = lv.SubItems(2).Text.Split("##")(Val(Replace(lv.Name, "b", "")) + 2)
                    Else
                        lv.SubItems(3).Text = "(geen)"
                        lv.SubItems(5).Text = Val(lv.SubItems(4).Text) + 1
                        'MsgBox(lv.Name)
                    End If
                End If
            Catch ex As Exception
                ' MsgBox(ex.Message)

            End Try

        Next
        txtAnswers.Clear()
        ComboBox1.Items.Clear()
    End Sub

    Sub removeallitems()
        Dim li As ListViewItem
        For Each li In listPanel.Items
            listPanel.Items.Remove(li)
        Next
        txtQuestion.SelectedText = ""
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) _
        Handles ToolStripSplitButton1.ButtonClick
        If listPanel.Items.Count <= 0 Then
            '  OpenFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
            loadtest()
        Else
            Dim result
            If My.Settings.language = "en" Then
                result = MessageBox.Show("Do you want to save the current quiz before loading the next one?", "Save?",
                                         MessageBoxButtons.YesNoCancel)
            Else
                result = MessageBox.Show("Wilt u uw huidige test opslaan alvorens u de volgende test inlaadt?",
                                         "Opslaan?", MessageBoxButtons.YesNoCancel)
            End If

            If result = DialogResult.Yes Then
                SaveFileDialog1.FileName = OpenFileDialog1.FileName
                usesave = True
                savebutton()
                usesave = False
                loadtest()
            End If
            If result = DialogResult.No Then
                loadtest()

            End If
        End If

        'loadtest()
        'If rNormalTest.Checked Then
        '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        removeallitems()
        '        intCount0 = 0
        '        OpenXML()
        '        ConvertCorrectAnswerToText()
        '        MsgBox("Bestand ingeladen!", MsgBoxStyle.Information)
        '    Else
        '        MsgBox("Probleem met het openen van het bestand!", MsgBoxStyle.Exclamation)
        '    End If
        'Else
        '    If FrmOpenTest.rGroep.Checked Then
        '        If Not My.Settings.folder = "" Then
        '            OpenFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
        '            removeallitems()
        '            intCount0 = 0
        '            'MsgBox(OpenFileDialog1.FileName)
        '            OpenXML()
        '            ConvertCorrectAnswerToText()
        '            MsgBox("Bestand ingeladen!", MsgBoxStyle.Information)
        '            builddatabase()
        '        Else
        '            MsgBox("Geen map onder 'Groepsmodus' gekozen!", MsgBoxStyle.Exclamation)
        '        End If
        '    Else
        '        MsgBox("Groepsmodus moet aanstaan om testen hiervan te kunnen bewerken!", MsgBoxStyle.Exclamation)
        '    End If
        'End If
    End Sub

    Sub BuildDatabase()
        Try
            If rGroepsModusTest.Checked = True Then
                If My.Settings.folder <> "" Then
                    For Each item As ListViewItem In listDB.Items
                        item.Remove()
                    Next
                    txtQuestion.Text = ""
                    txtQuestion.Items.Clear()
                    For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Settings.folder)
                        If foundFile.EndsWith(".widm3") Then
                            OpenFileDialog1.FileName = foundFile
                            'intCount0 = 0
                            'ConvertCorrectAnswerToText()
                            Open(True)
                        End If
                    Next
                    For Each item As ListViewItem In listDB.Items
                        If Not txtQuestion.Items.Contains(item.SubItems(1).Text) Then
                            txtQuestion.Items.Add(item.SubItems(1).Text)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub loadtest()
        BuildDatabase()
        If rNormalTest.Checked Then
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                removeallitems()
                intCount0 = 0
                Open(False)
                ConvertCorrectAnswerToText()
                If My.Settings.language = "en" Then
                    MsgBox("File loaded!", MsgBoxStyle.Information)
                Else
                    MsgBox("Bestand ingeladen!", MsgBoxStyle.Information)
                End If

            Else
                If My.Settings.language = "en" Then
                    MsgBox("Encountered a problem when opening the file!", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Probleem met het openen van het bestand!", MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            If FrmOpenTest.rGroep.Checked Then
                If Not My.Settings.folder = "" Then
                    OpenFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
                    removeallitems()
                    intCount0 = 0
                    'MsgBox(OpenFileDialog1.FileName)
                    Open(False)
                    ConvertCorrectAnswerToText()
                    'MsgBox("Bestand ingeladen!", MsgBoxStyle.Information)
                Else
                    If My.Settings.language = "en" Then
                        MsgBox("No folder under 'Group mode' was chosen!", MsgBoxStyle.Exclamation)
                    Else
                        MsgBox("Geen map onder 'Groepsmodus' gekozen!", MsgBoxStyle.Exclamation)
                    End If

                    rNormalTest.Checked = True
                End If
            Else
                If My.Settings.language = "en" Then
                    MsgBox("Group mode has to be on to edit its quizzes!", MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Groepsmodus moet aanstaan om testen hiervan te kunnen bewerken!", MsgBoxStyle.Exclamation)
                End If

            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked
        'If rNormalTest.Checked Then
        'Else
        If listPanel.Items.Count <= 0 Then
            '  OpenFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
            loadtest()
        Else
            Dim result
            If My.Settings.language = "en" Then
                result = MessageBox.Show("Do you want to save the current quiz before loading the next one?", "Save?",
                                         MessageBoxButtons.YesNoCancel)
            Else
                result = MessageBox.Show("Wilt u uw huidige test opslaan alvorens u de volgende test inlaadt?",
                                         "Opslaan?", MessageBoxButtons.YesNoCancel)
            End If
            If result = DialogResult.Yes Then
                SaveFileDialog1.FileName = OpenFileDialog1.FileName
                usesave = True
                savebutton()
                usesave = False
                loadtest()
            End If
            If result = DialogResult.No Then
                loadtest()

            End If
        End If
        'End If
    End Sub

    Private Sub rNormalTest_CheckedChanged(sender As Object, e As EventArgs) Handles rNormalTest.CheckedChanged
    End Sub

    Sub openOldTest()
        Dim lines() As String = File.ReadAllLines(OpenFileDialog2.FileName)
        Dim aantalvragen As Integer = lines(0)
        Dim recogniseQuestion As Integer
        Dim intCount1 As Integer
        For intCount1 = 1 To aantalvragen
            recogniseQuestion = intCount1 * 13 - 12
            If lines(recogniseQuestion) = "1" Then
                Dim newItem As New ListViewItem("Tekst tussendoor") '// add text Item.
                newItem.SubItems.Add(lines(recogniseQuestion + 1))
                newItem.SubItems.Add(lines(recogniseQuestion + 2))
                'newItem.SubItems.Add(correctanswer)
                'newItem.SubItems.Add(amount) '// add SubItem.
                listPanel.Items.Add(newItem) '// add Item to ListView.
            ElseIf lines(recogniseQuestion) = "2" Then
                Dim newItem As New ListViewItem("Open vraag") '// add text Item.
                newItem.SubItems.Add(lines(recogniseQuestion + 1))
                'newItem.SubItems.Add(lines(recogniseQuestion + 2))
                'newItem.SubItems.Add(correctanswer)
                'newItem.SubItems.Add(amount) '// add SubItem.
                listPanel.Items.Add(newItem) '// add Item to ListView.
            Else
                Dim newItem As New ListViewItem("Vraag") '// add text Item.
                newItem.Name = "b" & lines(recogniseQuestion + 1)
                newItem.SubItems.Add(lines(recogniseQuestion))
                Dim answers2 As String = lines(recogniseQuestion + 2) & "##" & lines(recogniseQuestion + 3) & "##" &
                                         lines(recogniseQuestion + 4) & "##" & lines(recogniseQuestion + 5) & "##" &
                                         lines(recogniseQuestion + 6) & "##" & lines(recogniseQuestion + 7) & "##" &
                                         lines(recogniseQuestion + 8) & "##" & lines(recogniseQuestion + 9) & "##" &
                                         lines(recogniseQuestion + 10) & "##" & lines(recogniseQuestion + 11)
                Dim item As String
                Dim amount2 As Integer
                amount2 = 10
                For Each item In answers2
                    If answers2.EndsWith("##") Then
                        answers2 = answers2.Remove(answers2.Length - 2)
                        amount2 = amount2 - 1
                    Else
                        Exit For
                    End If
                Next
                newItem.SubItems.Add(answers2)
                newItem.SubItems.Add(lines(recogniseQuestion + 1))
                newItem.SubItems.Add(amount2) '// add SubItem.
                newItem.SubItems.Add("b" & lines(recogniseQuestion + 1))
                listPanel.Items.Add(newItem) '// add Item to ListView.
            End If
        Next

        ConvertCorrectAnswerToText()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            openOldTest()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Code from:
        'http://www.xtremedotnettalk.com/showthread.php?t=85072

        If Me.listPanel.SelectedIndices.Count = 0 Then
            If My.Settings.language = "en" Then
                MessageBox.Show("There is no selected item!")
            Else
                MessageBox.Show("Geen item geselecteerd!")
            End If

            Exit Sub
        ElseIf Me.listPanel.SelectedIndices.Count > 1 Then
            MessageBox.Show("This code only supports single selection...")
            Exit Sub
        End If

        Dim SelIndex As Integer = Me.listPanel.SelectedIndices.Item(0)  'ListVisw must only support single seleccion

        If SelIndex = 0 Then
            If My.Settings.language = "en" Then
                MessageBox.Show("Item is already on top!")
            Else
                MessageBox.Show("Item staat al bovenaan!")
            End If

            Exit Sub
        End If

        'Reorder items in the arraylist
        Dim tItem As ListViewItem
        tItem = Me.listPanel.Items(SelIndex - 1)
        Me.listPanel.Items(SelIndex - 1) = Me.listPanel.Items(SelIndex).Clone
        Me.listPanel.Items(SelIndex) = tItem.Clone

        listPanel.Items(SelIndex - 1).Selected = True


        listPanel.Select()


        'For I As Integer = 0 To listPanel.Items.Count - 1
        '    If listPanel.Items(I).Index = SelIndex - 1 Then
        '        listPanel.Items(I).Selected = True
        '    End If
        'Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If Me.listPanel.SelectedIndices.Count = 0 Then
            If My.Settings.language = "en" Then
                MessageBox.Show("There is no selected item!")
            Else
                MessageBox.Show("Geen item geselecteerd!")
            End If
            Exit Sub
        ElseIf Me.listPanel.SelectedIndices.Count > 1 Then
            MessageBox.Show("This code only supports single selection...")
            Exit Sub
        End If

        Dim SelIndex As Integer = Me.listPanel.SelectedIndices.Item(0) 'ListView must only support single seleccion

        If SelIndex = Me.listPanel.Items.Count - 1 Then
            If My.Settings.language = "en" Then
                MessageBox.Show("Item is already on the bottom!")
            Else
                MessageBox.Show("Item staat al onderaan!")
            End If
            Exit Sub
        End If

        'Reorder items in the arraylist
        Dim tItem As ListViewItem
        tItem = Me.listPanel.Items(SelIndex + 1)
        Me.listPanel.Items(SelIndex + 1) = Me.listPanel.Items(SelIndex).Clone
        Me.listPanel.Items(SelIndex) = tItem.Clone

        listPanel.Items(SelIndex + 1).Selected = True
        listPanel.Select()
    End Sub

    Private Sub testTest()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        'If OpenFileDialog1.FileName <> "" Then

        Dim oldtest As String
        oldtest = FrmOpenTest.file
        Dim checkstatus As Boolean
        If FrmOpenTest.rAlleen.Checked = True Then
            checkstatus = True
        Else
            checkstatus = False
        End If
        FrmOpenTest.rAlleen.Checked = True
        FrmOpenTest.rGroep.Checked = False
        SaveFileDialog1.FileName = CurDir() & "\testtesten.tmp"
        Save()
        FrmOpenTest.file = CurDir() & "\testtesten.tmp"
        FrmEnterName.ShowDialog()
        FrmOpenTest.file = oldtest
        FrmOpenTest.txtTest.Text = oldtest
        FrmOpenTest.rAlleen.Checked = checkstatus
        FrmOpenTest.rGroep.Checked = Not checkstatus

        My.Computer.FileSystem.DeleteFile(CurDir() & "\testtesten.tmp", UIOption.OnlyErrorDialogs,
                                          RecycleOption.DeletePermanently, UICancelOption.DoNothing)

        'Else

        'End If
    End Sub

    Private Sub OudeTestOpenenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OudeTestOpenenToolStripMenuItem.Click
        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            openOldTest()
        End If
    End Sub

    Private Sub VersleuteldeTestOpenenToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles VersleuteldeTestOpenenToolStripMenuItem.Click
        If OpenFileDialog3.ShowDialog() = DialogResult.OK Then
            Dim read As New StreamReader(OpenFileDialog3.FileName)

            Dim cipherText As String = read.ReadToEnd

            read.Close()
            FrmPassword.ShowDialog()
            Dim password As String = FrmPassword.TextBox1.Text
            Dim wrapper As New Simple3DES(password)

            ' DecryptData throws if the wrong password is used. 
            Try
                Dim plainText As String = wrapper.DecryptData(cipherText)
                Try
                    My.Computer.FileSystem.DeleteFile(OpenFileDialog3.FileName & ".tmp", UIOption.OnlyErrorDialogs,
                                                      RecycleOption.DeletePermanently)
                Catch ex As Exception

                End Try
                Dim Write As New StreamWriter(OpenFileDialog3.FileName & ".tmp")
                Write.Write(plainText)
                Write.Close()
                SetAttr(OpenFileDialog3.FileName & ".tmp", vbHidden)
                ' encryptedTest = True
                OpenFileDialog2.FileName = OpenFileDialog3.FileName & ".tmp"
                openOldTest()
                ' encryptedTest = False
                Try
                    My.Computer.FileSystem.DeleteFile(OpenFileDialog3.FileName & ".tmp", UIOption.OnlyErrorDialogs,
                                                      RecycleOption.DeletePermanently)
                Catch ex As Exception

                End Try
            Catch ex As CryptographicException
                If My.Settings.language = "en" Then
                    MsgBox("Wrong password", MsgBoxStyle.Critical)
                Else
                    MsgBox("Verkeerd wachtwoord", MsgBoxStyle.Critical)
                End If

            End Try
        End If
    End Sub

    Private Sub txtQuestion_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles txtQuestion.SelectedIndexChanged
        For Each item As ListViewItem In listDB.Items
            If item.SubItems(1).Text = txtQuestion.Text Then
                txtAnswers.Text = Replace(item.SubItems(2).Text, "##", vbNewLine)
                ComboBox1.SelectedIndex = Replace(item.SubItems(5).Text, "b", "") - 1
                'Exit For
            End If
        Next
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel2.LinkClicked
        savebutton()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If rGroepsModusTest.Checked Then
            If listPanel.Items.Count <= 0 Then
                '  OpenFileDialog1.FileName = My.Settings.folder & "\" & "afl" & NumericUpDown1.Value & ".widm3"
                loadtest()
            Else
                Dim result
                If My.Settings.language = "en" Then
                    result = MessageBox.Show("Do you want to save the current quiz before loading the next one?",
                                             "Save?", MessageBoxButtons.YesNoCancel)
                Else
                    result = MessageBox.Show("Wilt u uw huidige test opslaan alvorens u de volgende test inlaadt?",
                                             "Opslaan?", MessageBoxButtons.YesNoCancel)
                End If
                If result = DialogResult.Yes Then
                    SaveFileDialog1.FileName = OpenFileDialog1.FileName
                    usesave = True
                    savebutton()
                    usesave = False
                    loadtest()
                End If
                If result = DialogResult.No Then
                    loadtest()

                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    End Sub

    Private Sub txtQuestion_TextChanged(sender As Object, e As EventArgs) Handles txtQuestion.TextChanged
        ComboBox1.Items.Clear()
        Dim item1 As String
        For Each item1 In txtAnswers.Lines
            ComboBox1.Items.Add(item1)
        Next
        ComboBox1.Items.Add("(geen)")
        ComboBox1.SelectedItem = "(geen)"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        For Each i As ListViewItem In listPanel.SelectedItems
            listPanel.Items.Remove(i)
        Next
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        btnBewerken()
    End Sub

    Private Sub rGroepsModusTest_CheckedChanged(sender As Object, e As EventArgs) _
        Handles rGroepsModusTest.CheckedChanged
        If rNormalTest.Checked Then
            Panel3.Enabled = False
            My.Settings.rNormal = True
        ElseIf rGroepsModusTest.Checked = True Then
            Panel3.Enabled = True
            My.Settings.rNormal = False
            If My.Settings.folder = "" Then
                'Console.WriteLine("Voor|" & NumericUpDown1.Value & "|" & rNormalTest.Checked.ToString & "|" & rGroepsModusTest.Checked.ToString)
                If My.Settings.language = "en" Then
                    MsgBox(
                        "It looks like no folder was chosen under ""Group mode""!" & vbCrLf &
                        "Choose a folder before editing a group mode quiz", MsgBoxStyle.Exclamation)
                Else
                    MsgBox(
                        "Het lijkt erop dat er nog geen map is gekozen onder ""Groepsmodus""!" & vbCrLf &
                        "Selecteer eerst een map alvorens u een groepsmodustest gaat bewerken", MsgBoxStyle.Exclamation)
                End If
                'Console.WriteLine("Na|" & NumericUpDown1.Value & "|" & rNormalTest.Checked.ToString & "|" & rGroepsModusTest.Checked.ToString)
                rNormalTest.Checked = True
            End If
        End If
    End Sub
End Class