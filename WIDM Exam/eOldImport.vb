Imports System.IO
Imports System.Net
Imports System.Xml
Imports Newtonsoft.Json

'This module contains the legacy load methods. The save methods have been discarded 
'The reason why this module exists is to provide a way to convert old tests to the new format
'No method was changed to guarantee maximum reliability. 

'It's ugly, but it worked :-)

Class OldImport

    'As required by the v2 model:
    Dim document As XmlReader
    Dim intCount0 As Integer = 0
    Dim question As String = ""
    Dim answers As String = ""
    Dim amount As String = ""
    Dim correctanswer As String = ""
    Dim text1 As String = ""
    Dim text2 As String = ""

    Const Vraag = "Vraag"
    Const TekstTussendoor = "Tekst tussendoor"
    Const OpenVraag = "Open vraag"

    'Create a non-visible listview to temporarily store all data in.
    Dim listQuestions As New ListView

    Enum FileVersion
        v1
        v2
    End Enum

    Public Function Importv1(ByVal fileLocation As String)
        Try
            Dim lines() As String = File.ReadAllLines(fileLocation)
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
                    listQuestions.Items.Add(newItem) '// add Item to ListView.
                ElseIf lines(recogniseQuestion) = "2" Then
                    Dim newItem As New ListViewItem("Open vraag") '// add text Item.
                    newItem.SubItems.Add(lines(recogniseQuestion + 1))
                    'newItem.SubItems.Add(lines(recogniseQuestion + 2))
                    'newItem.SubItems.Add(correctanswer)
                    'newItem.SubItems.Add(amount) '// add SubItem.
                    listQuestions.Items.Add(newItem) '// add Item to ListView.
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
                    listQuestions.Items.Add(newItem) '// add Item to ListView.
                End If
            Next

            FrmTestMaken.ConvertCorrectAnswerToText()
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Sub OpenTekstTussendoor(ByVal fileLocation As String)
        document = New XmlTextReader(fileLocation)
        While (document.Read())

            Dim type = document.NodeType

            'if node type was element
            If (type = XmlNodeType.Element) Then
                'Dim intCount0 As Integer = 1
                'if the loop found a <FirstName> tag
                If (document.Name = "q" & intCount0.ToString & "text2") Then

                    text2 = WebUtility.HtmlDecode(document.ReadInnerXml.ToString)

                End If
                If document.Name = "q" & intCount0 & "text1" Then
                    text1 = WebUtility.HtmlDecode(document.ReadInnerXml.ToString)
                End If
            End If

        End While
        ' MsgBox("")
        document.Close()
        Dim newItem As New ListViewItem("Tekst tussendoor") '// add text Item.
        newItem.SubItems.Add(text1)
        newItem.SubItems.Add(text2)

        listQuestions.Items.Add(newItem)

        OpenXML(fileLocation)
    End Sub
    Sub OpenQuestion(ByVal fileLocation As String)
        document = New XmlTextReader(fileLocation)



        While (document.Read())

            Dim type = document.NodeType

            'if node type was element
            If (type = XmlNodeType.Element) Then
                'Dim intCount0 As Integer = 1
                'if the loop found a <FirstName> tag
                If (document.Name = "q" & intCount0.ToString & "question") Then
                    question = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())
                End If
                If document.Name = "q" & intCount0 & "answers" Then
                    answers = WebUtility.HtmlDecode(Mid(Replace(document.ReadInnerXml.ToString, vbNewLine, "##"), 3))
                    'newItem.SubItems.Add() '// add SubItem.
                    'Console.Write("2!")
                End If
                If document.Name = "q" & intCount0 & "amount" Then
                    amount = document.ReadInnerXml.ToString
                    'Console.Write("3!")
                End If
                If document.Name = "q" & intCount0 & "correctanswer" Then
                    'newItem.SubItems.Add(reader.Value) '// add SubItem.
                    correctanswer = document.ReadInnerXml.ToString
                    'Console.Write("4!")
                End If
            End If

        End While
        document.Close()
        ' MsgBox("")
        Dim newItem As New ListViewItem
        If answers = Nothing Then
            newItem.Text = "Open vraag"
        Else
            newItem.Text = "Vraag"
        End If
        '// add text Item.
        newItem.Name = correctanswer
        newItem.SubItems.Add(question)
        newItem.SubItems.Add(answers)
        newItem.ToolTipText = answers
        'Dim AnswersTextboxed As TextBox
        'AnswersTextboxed.Text = answers
        'newItem.SubItems.Add(AnswersTextboxed.Lines(Replace(correctanswer, "b", "").ToString))


        newItem.SubItems.Add(Replace(correctanswer, "b", ""))
        newItem.SubItems.Add(amount) '// add SubItem.
        newItem.SubItems.Add(correctanswer)

        listQuestions.Items.Add(newItem)


        OpenXML(fileLocation)

    End Sub
    Sub OpenXML(ByVal fileLocation As String)


        If Dir(fileLocation) <> "" Then
        Else
            Exit Sub
        End If
        Dim amountquestions As Integer = 0
        Dim tempanswer As String = ""
        text1 = Nothing
        text2 = Nothing
        correctanswer = Nothing
        amount = Nothing
        question = Nothing
        answers = Nothing

        intCount0 = intCount0 + 1


        document = New XmlTextReader(fileLocation)
        Try
            While (document.Read())
                If document.NodeType = XmlNodeType.Element Then
                    If (document.Name = "questionscount") Then
                        amountquestions = Val(document.ReadInnerXml.ToString)
                    End If
                    'If (document.Name = "q" & intCount0.ToString & "text2") Then
                    '    If Not document.ReadInnerXml.ToString = "" Then
                    '        tempanswer = document.ReadInnerXml.ToString
                    '        MsgBox(tempanswer)
                    '    End If
                    'Else
                    'End If
                End If
            End While
        Catch ex As Exception
        End Try

        document.Close()

        Dim Read As New System.IO.StreamReader(fileLocation)
        Try
            If Not intCount0 > amountquestions Then

                If Read.ReadToEnd.Contains("q" & intCount0 & "question") Then
                    'If Read.ReadToEnd.Contains("q" & intCount0 & "openquestion") Then

                    'End If
                    OpenQuestion(fileLocation)
                Else
                    OpenTekstTussendoor(fileLocation)
                End If
                Read.Close()
            End If
        Catch ex As Exception
        End Try

        Read.Close()
        document.Close()
    End Sub

    Public Function Importv2(ByVal fileLocation As String)
        OpenXML(fileLocation)
        Return True
    End Function

    Public Function Save(ByVal fileLocation As String)
        Try
            'Create a list
            Dim questions As Question() = {}
            For Each row As ListViewItem In listQuestions.Items
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
                    openQuestion.Text = row.SubItems(1).Text
                    questions.Add(openQuestion)
                End If
            Next

            Dim _test As New Test

            _test.Questions = questions


            Dim objStreamWriter As New IO.StreamWriter(fileLocation)
            'Serialize list
            objStreamWriter.Write(JsonConvert.SerializeObject(_test, Newtonsoft.Json.Formatting.Indented))
            objStreamWriter.Close()
            Return True
        Catch ex As Exception
            Log(ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Public Function Convert(ByVal oldFile As String, ByVal oldVersion As FileVersion, ByVal newFile As String) As Boolean
        If My.Computer.FileSystem.FileExists(oldFile) Then
            Try
                If oldVersion = FileVersion.v1 Then
                    Importv1(oldFile)
                ElseIf oldVersion = FileVersion.v2 Then
                    Importv2(oldFile)
                End If
                Return Save(newFile)
            Catch ex As Exception
                Log(ex.ToString())
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try
        Else
            MsgBox(GetLang("FileNotFound"), MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function
End Class
