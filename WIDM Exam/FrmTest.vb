Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Xml
Imports Newtonsoft.Json

Public Class FrmTest
    Dim _closePass As Boolean = False
    Dim _answersRight As Integer = 0
    Dim _time As Integer = 0
    Dim _question As Integer = 1
    Dim _questionDisplay As Integer = 1
    Dim _answer As String
    Dim _value As Integer = 0
    Dim _locationValue As Integer = 0
    Dim _qAmount As Integer
    Public Spacebetweenanswers As Integer = My.Settings.numRuimteTussenAntwoorden2
    Public Spacebetweenanswershorizontal As Integer = My.Settings.numRuimteTussenAntwoordenHorizontaal
    Dim _b As PictureBox
    Public S As PictureBox
    Dim _correctanswertemp As String
    Dim _amountQuestions As Integer
    Dim _amountAnswers As Integer = 0
    Dim _wedstrijdantwoordentemp As String = ""
    Dim _buttonpressed As Boolean = False
    Dim _rand As New Random

    Dim _questions As New List(Of Question)

    Private Sub Open()
        Try
            Dim objStreamReader As New StreamReader(FrmOpenTest.file)
            Dim output As String = objStreamReader.ReadToEnd()
            objStreamReader.Close()

            Dim jsoNdeserialized As Test = JsonConvert.DeserializeObject(Of Test)(output)

            'Loop through questions
            For Each item In JSONdeserialized.questions
                'Add them to the list
                _questions.Add(item)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Private Sub FrmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        expandToMonitor(Me)

        'Intialize the Windows Media Player entity, load the right sound for the clicking
        WMP1.URL = CurDir() & "\Geluid\klik.wav"
        WMP1.Ctlcontrols.stop()
        'Set closePass to false in case it has been turned to true when the window was opened previously. Makes sure a password promt will appear when leaving (if password is specified)
        _closePass = False
        _question = 1
        _questionDisplay = 1
        WMP1.Ctlcontrols.stop()

        txtQuestion.Size = New Size(Me.Width - 200 * (FrmOpenTest.dpiPercent.Text / 96), txtQuestion.Size.Height)

        txtTekst1.Font = New Font(CurrentTheme.fontQuestion.OriginalFontName, 36, FontStyle.Regular)
        txtTekst2.Font = New Font(CurrentTheme.fontQuestion.OriginalFontName, 36, FontStyle.Regular)
        txtQuestion.Font = CurrentTheme.fontQuestion
        t1.Font = CurrentTheme.fontAnswers
        t3.Font = CurrentTheme.fontAnswers

        txtTekst1.ForeColor = CurrentTheme.colorQuestion
        txtTekst2.ForeColor = CurrentTheme.colorQuestion
        txtQuestion.ForeColor = CurrentTheme.colorQuestion
        Try
            txtQuestion.TextAlign = CurrentTheme.questionAlignment
        Catch ex As Exception

        End Try
        If CurrentTheme.questionBackgroundEnabled Then
            txtQuestion.BackgroundImage = CurrentTheme.imgQuestionBackground
            txtQuestion.BackgroundImageLayout = ImageLayout.Stretch
        End If

        t1.ForeColor = CurrentTheme.colorAnswers
        t3.ForeColor = CurrentTheme.colorAnswers

        t2.Image = CurrentTheme.imgButton

        If CurrentTheme.logoTestEnabled Then
            smallLogo.Image = CurrentTheme.imgLogoTest
        Else
            smallLogo.Hide()
        End If
        If CurrentTheme.backgroundTestEnabled Then
            BackgroundImage = CurrentTheme.imgBackgroundTest
        Else
            BackgroundImage = Nothing
        End If

        BackColor = CurrentTheme.backgroundColorTest


        'txtQuestion.Size = New Size(txtQuestion.Size.Width * (Me.Width / 1024), txtQuestion.Size.Height)
        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUK.Checked Then
        '    'Fonts are now in the dedicated fonts section
        '    txtTekst1.ForeColor = Color.Red
        '    txtTekst2.ForeColor = Color.Red
        '    txtQuestion.ForeColor = Color.Red
        '    t1.ForeColor = Color.Gold
        '    t3.ForeColor = Color.Gold

        '    t2.Image = My.Resources.button_2004

        '    If FrmOpenTest.rNostalgia.Checked Then
        '        smallLogo.Image = My.Resources.WIDM_logo_2004
        '    Else
        '        smallLogo.Image = My.Resources.UK_Logo
        '    End If


        '    BackgroundImage = Nothing
        'ElseIf FrmOpenTest.rUS.Checked Then
        '    'Fonts are now in the dedicated fonts section
        '    txtTekst1.ForeColor = Color.White
        '    txtTekst1.BackgroundImage = My.Resources.Background_question_US
        '    txtTekst1.BackgroundImageLayout = ImageLayout.Stretch


        '    txtTekst2.ForeColor = Color.White
        '    txtTekst2.BackgroundImage = My.Resources.Background_question_US
        '    txtTekst2.BackgroundImageLayout = ImageLayout.Stretch


        '    txtQuestion.ForeColor = Color.White
        '    txtQuestion.TextAlign = ContentAlignment.TopCenter
        '    txtQuestion.BackgroundImage = My.Resources.Background_question_US
        '    txtQuestion.BackgroundImageLayout = ImageLayout.Stretch
        '    t1.ForeColor = Color.White
        '    t3.ForeColor = Color.White

        '    t2.Image = My.Resources.button_2004


        '    smallLogo.Image = Nothing

        '    BackgroundImage = My.Resources.US_Background
        'ElseIf FrmOpenTest.rFrankrijk.Checked Then
        '    txtTekst1.ForeColor = Color.White

        '    txtTekst2.ForeColor = Color.White

        '    txtQuestion.ForeColor = Color.White
        '    t1.ForeColor = Color.White
        '    t3.ForeColor = Color.White

        '    t2.Image = My.Resources.Fr_unpressed


        '    smallLogo.Image = Nothing
        '    smallLogo.BackColor = Color.Transparent

        '    BackgroundImage = My.Resources.Fr_Background
        'End If
        'If My.Settings.logo <> "" Then
        '    smallLogo.ImageLocation = My.Settings.logo
        'End If

        'If My.Settings.background <> "" Then
        '    Me.BackgroundImage = Image.FromFile(My.Settings.background)
        '    Me.BackColor = My.Settings.backgroundColor
        'End If

        'Dedicated font section


        'If FrmOpenTest.rLucidaConsole.Checked Then
        '    'Is Lucida Console by default, no need to set it. 
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    txtTekst1.Font = GetInstance(36, FontStyle.Regular)
        '    txtTekst2.Font = GetInstance(36, FontStyle.Regular)
        '    txtQuestion.Font = GetInstance(20.25, FontStyle.Regular)
        '    t1.Font = GetInstance(16, FontStyle.Regular)
        '    t3.Font = GetInstance(16, FontStyle.Regular)
        'ElseIf FrmOpenTest.rComicSansMS.Checked Then
        '    txtTekst1.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    txtTekst2.Font = New Font("Comic Sans MS", 36, FontStyle.Regular)
        '    txtQuestion.Font = New Font("Comic Sans MS", 20, FontStyle.Regular)
        '    t1.Font = New Font("Comic Sans MS", 16, FontStyle.Regular)
        '    t3.Font = New Font("Comic Sans MS", 16, FontStyle.Regular)
        'ElseIf FrmOpenTest.rMicrosoftSansSerif.Checked Then
        '    txtTekst1.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    txtTekst2.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Regular)
        '    txtQuestion.Font = New Font("Microsoft Sans Serif", 20, FontStyle.Bold)
        '    t1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
        '    t3.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
        'ElseIf FrmOpenTest.rUbuntuCondensed.Checked Then
        '    txtTekst1.Font = New Font("Ubuntu Condensed", 36)
        '    txtTekst2.Font = New Font("Ubuntu Condensed", 36)
        '    txtQuestion.Font = New Font("Ubuntu Condensed", 20.25)
        '    t1.Font = New Font("Ubuntu Condensed", 16)
        '    t3.Font = New Font("Ubuntu Condensed", 16)
        'ElseIf FrmOpenTest.rMicroFLF.Checked Then
        '    txtTekst1.Font = New Font("MicroFLF", 36, FontStyle.Italic)
        '    txtTekst2.Font = New Font("MicroFLF", 36, FontStyle.Italic)
        '    txtQuestion.Font = New Font("MicroFLF", 24, FontStyle.Italic)
        '    t1.Font = New Font("MicroFLF", 16, FontStyle.Bold Or FontStyle.Italic)
        '    t3.Font = New Font("MicroFLF", 16, FontStyle.Bold Or FontStyle.Italic)
        'ElseIf FrmOpenTest.rCustomFont.Checked Then
        '    txtTekst1.Font = New Font(My.Settings.customFont.OriginalFontName, 36)
        '    txtTekst2.Font = New Font(My.Settings.customFont.OriginalFontName, 36)
        '    txtQuestion.Font = New Font(My.Settings.customFont.OriginalFontName, 20)
        '    t1.Font = New Font(My.Settings.customFont.OriginalFontName, 16)
        '    t3.Font = New Font(My.Settings.customFont.OriginalFontName, 16)
        'End If

        'For some reason, it tends to load this first before resizing the form to fill the screen. Resetting that here.

        txtTekst1.Top = (Me.Height / 2) - (txtTekst1.Height / 2)
        txtTekst1.Left = (Me.Width / 2) - (txtTekst1.Width / 2)

        txtTekst2.Top = (Me.Height / 2) - (txtTekst2.Height / 2)
        txtTekst2.Left = (Me.Width / 2) - (txtTekst2.Width / 2)

        txtTekst1.Width = Me.Width
        txtTekst2.Width = Me.Width
        txtTekst1.Left = 0
        txtTekst2.Left = 0

        Open()
        loadQuestionAnswers()

        '
    End Sub

    Sub Addbutton(ByVal answer As Answer)
        _amountAnswers = _amountAnswers + 1
        _b = New PictureBox()
        'If FrmOpenTest.rRandom.Checked Then
        '    Try

        '        'For i As Integer = 1 To randomValuesLeft.Items.Count Step 1

        '        Console.WriteLine("COUNT: " & randomValuesLeft.Items.Count)
        '        'Dim selectedIndex As Integer = rand.Next(0, (randomValuesLeft.Items.Count - 1))
        '        Dim selectedIndex = CInt(Int(((randomValuesLeft.Items.Count) * Rnd())))
        '        Dim selectedNumber As Integer = randomValuesLeft.Items(selectedIndex)
        '        value = selectedNumber
        '        randomValuesLeft.Items.Remove(selectedNumber)


        '        Console.WriteLine("VALUE: " & value)
        '        ' MsgBox(value)
        '        'Next 'i
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        '    End Try


        'Else
        '    value = value + 1
        'End If
        _value = answer.id
        _locationValue = _locationValue + 1
        Console.WriteLine("ENDVALUE: " & _value)
        _b.Name = "b" & _value
        _b.Tag = _locationValue
        _b.BackColor = Color.Transparent

        _b.Image = CurrentTheme.imgButton
        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUS.Checked Or FrmOpenTest.rUK.Checked Then
        '    b.Image = My.Resources.button_2004
        'ElseIf FrmOpenTest.rFrankrijk.Checked Then
        '    b.Image = My.Resources.Fr_unpressed
        'Else
        '    b.Image = My.Resources.Button
        'End If


        _b.Visible = True
        _b.Size = New Size(50, 50)
        _b.SizeMode = PictureBoxSizeMode.Zoom

        Dim answerStop As Integer = Math.Ceiling(_questions(_question - 1).answers.Count / 2)

        If FrmOpenTest.rThreeRows.Checked = True Then
            If ((_locationValue Mod 3) = 0) Then
                _b.Location = New Point(96 + (spacebetweenanswershorizontal * 2),
                                       spacebetweenanswers * (_locationValue - 3) + 190 + (FrmOpenTest.dpiPercent.Text * 2) -
                                       192)
            ElseIf (((_locationValue + 1) Mod 3) = 0) Then
                _b.Location = New Point(96 + spacebetweenanswershorizontal,
                                       spacebetweenanswers * (_locationValue - 2) + 190 + (FrmOpenTest.dpiPercent.Text * 2) -
                                       192)
            Else
                _b.Location = New Point(96,
                                       spacebetweenanswers * (_locationValue - 1) + 190 + FrmOpenTest.dpiPercent.Text - 96)
            End If
        Else
            If _locationValue <= answerStop Then
                _b.Location = New Point(96,
                                       (spacebetweenanswers * 2) * (_locationValue - 1) + 192 +
                                       (FrmOpenTest.dpiPercent.Text * 2) - 192)

            Else
                _b.Location = New Point(96 + spacebetweenanswershorizontal,
                                       (spacebetweenanswers * 2) * (_locationValue - 1 - answerStop) + 192 +
                                       (FrmOpenTest.dpiPercent.Text * 2) - 192)

            End If

            'If ((value Mod 2) = 0) Then
            '    b.Location = New Point(96 + spacebetweenanswershorizontal, spacebetweenanswers * (value - 2) + 190 + FrmOpenTest.dpiPercent.Text - 96)
            'Else
            '    b.Location = New Point(96, spacebetweenanswers * (value - 1) + 190 + FrmOpenTest.dpiPercent.Text - 96)
            'End If
        End If
        If FrmOpenTest.rNummers.Checked = True Then
            AddHandler _b.Paint, AddressOf buttonpaint
        End If
        AddHandler _b.Click, AddressOf buttonpress
        AddHandler _b.MouseEnter, AddressOf buttonhover
        AddHandler _b.MouseLeave, AddressOf buttonleave
        _b.BringToFront()
        Me.Controls.Add(_b)

        Dim l = New Label()
        l.Name = "l" & _value

        Try
            l.Text = answer.text
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
        l.BackColor = Color.Transparent
        l.ForeColor = CurrentTheme.colorAnswers
        l.Font = CurrentTheme.fontAnswers
        'If FrmOpenTest.rNostalgia.Checked Or FrmOpenTest.rUK.Checked Then
        '    l.ForeColor = Color.Gold
        'ElseIf FrmOpenTest.rUS.Checked Then
        '    l.ForeColor = Color.White
        'Else
        '    l.ForeColor = Color.White
        'End If
        'If FrmOpenTest.rLucidaConsole.Checked Then
        '    l.Font = New Font("Lucida Console", 16, FontStyle.Regular)
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    l.Font = GetInstance(16, FontStyle.Regular)
        'ElseIf FrmOpenTest.rComicSansMS.Checked Then
        '    l.Font = New Font("Comic Sans MS", 17, FontStyle.Regular)
        'ElseIf FrmOpenTest.rMicrosoftSansSerif.Checked Then
        '    l.Font = New Font("Microsoft Sans Serif", 17, FontStyle.Regular)
        'ElseIf FrmOpenTest.rUbuntuCondensed.Checked Then
        '    l.Font = New Font("Ubuntu Condensed", 16)
        'ElseIf FrmOpenTest.rMicroFLF.Checked Then
        '    l.Font = New Font("MicroFLF", 16, FontStyle.Bold Or FontStyle.Italic)
        'ElseIf FrmOpenTest.rCustomFont.Checked Then
        '    l.Font = New Font(My.Settings.customFont.OriginalFontName, 17, FontStyle.Regular)
        'End If
        l.Size = New Size(420 + (spacebetweenanswershorizontal - 500), 50 + (spacebetweenanswers - 25))
        If FrmOpenTest.rThreeRows.Checked = True Then
            If ((_locationValue Mod 3) = 0) Then
                l.Location = New Point(170 + (spacebetweenanswershorizontal * 2),
                                       spacebetweenanswers * (_locationValue - 3) + 205 + (FrmOpenTest.dpiPercent.Text * 2) -
                                       192)
            ElseIf (((_locationValue + 1) Mod 3) = 0) Then
                l.Location = New Point(170 + spacebetweenanswershorizontal,
                                       spacebetweenanswers * (_locationValue - 2) + 205 + (FrmOpenTest.dpiPercent.Text * 2) -
                                       192)
            Else
                l.Location = New Point(170,
                                       spacebetweenanswers * (_locationValue - 1) + 205 + (FrmOpenTest.dpiPercent.Text * 2) -
                                       192)
            End If
        Else
            If _locationValue <= answerStop Then
                l.Location = New Point(170,
                                       (spacebetweenanswers * 2) * (_locationValue - 1) + 205 +
                                       (FrmOpenTest.dpiPercent.Text * 2) - 192)
            Else
                l.Location = New Point(170 + spacebetweenanswershorizontal,
                                       (spacebetweenanswers * 2) * (_locationValue - 1 - answerStop) + 205 +
                                       (FrmOpenTest.dpiPercent.Text * 2) - 192)
            End If
        End If
        l.Visible = True
        l.UseMnemonic = False
        Me.Controls.Add(l)
    End Sub

    Sub Buttonpress(sender As Object, e As EventArgs)
        If _buttonpressed = False Then
            _buttonpressed = True
            s = sender

            WMP1.Ctlcontrols.stop()
            WMP1.Ctlcontrols.play()
            If s.Name.ToString = _correctanswertemp Then
                correctAnswer()
            End If
            Dim loadanswer As Integer
            'Try
            loadanswer = CInt(s.Name.ToString.Replace("b", ""))
            _answer = _questions(_question - 1).answers(loadanswer).text
            _answer = Replace(_answer, vbTab, "")
            'MsgBox(answer)
            'Catch ex As Exception
            '    Console.Write(ex.Message)
            'End Try
            saveLastQuestion()

            s.Image = CurrentTheme.imgButtonClick
            If CurrentTheme.colorClickEnabled Then
                Me.Controls(s.Name.Replace("b", "l")).ForeColor = CurrentTheme.colorClick
            End If
            'If FrmOpenTest.rNewTheme.Checked Then
            '    s.Image = My.Resources.aButton
            'ElseIf FrmOpenTest.rFrankrijk.Checked Then
            '    s.Image = My.Resources.Fr_Cross
            '    Me.Controls(s.Name.Replace("b", "l")).ForeColor = Color.Turquoise
            'End If

            tmButton.Start()
        End If
    End Sub

    Sub Buttonhover(sender As Object, e As EventArgs)
        Try
            If CurrentTheme.buttonHoverEnabled Then
                sender.image = CurrentTheme.buttonHover
                If CurrentTheme.colorClickEnabled Then
                    Dim correspondingLabel As String
                    correspondingLabel = sender.name.replace("b", "l")
                    Me.Controls(correspondingLabel).ForeColor = CurrentTheme.colorClick
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Buttonleave(sender As Object, e As EventArgs)
        Try
            If CurrentTheme.buttonHoverEnabled Then
                sender.image = CurrentTheme.button
                If CurrentTheme.colorClickEnabled Then
                    Dim correspondingLabel As String
                    correspondingLabel = sender.name.replace("b", "l")
                    Me.Controls(correspondingLabel).ForeColor = CurrentTheme.colorAnswers
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Buttonpaint(sender As Object, e As PaintEventArgs)
        Dim canvas As Graphics = e.Graphics
        Dim mainFont As Font = New Font(CurrentTheme.fontAnswers.OriginalFontName, 18, FontStyle.Regular)
        Dim plateTextEntry As New TextBox
        PlateTextEntry.Text = sender.Tag.ToString()
        Dim textStyle As New FontStyle
        'If FrmOpenTest.rLucidaConsole.Checked Then
        '    mainFont = New Font("Courier New", 18, FontStyle.Bold)
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    mainFont = New Font("OCR A Extended", 19, textStyle)
        'ElseIf FrmOpenTest.rComicSansMS.Checked Then
        '    mainFont = New Font("Comic Sans MS", 19, textStyle)
        'ElseIf FrmOpenTest.rMicrosoftSansSerif.Checked Then
        '    mainFont = New Font("Microsoft Sans Serif", 19, textStyle)
        'ElseIf FrmOpenTest.rUbuntuCondensed.Checked Then
        '    mainFont = New Font("Ubuntu Condensed", 19, textStyle)
        'ElseIf FrmOpenTest.rCustomFont.Checked Then
        '    mainFont = New Font(My.Settings.customFont.OriginalFontName, 18, FontStyle.Regular)
        'Else
        '    mainFont = New Font("Courier New", 18, FontStyle.Bold)
        'End If
        'If FrmOpenTest.rUS.Checked Then
        '    mainFont = New Font("Microsoft Sans Serif", 19, textStyle)
        'ElseIf FrmOpenTest.rUK.Checked Or FrmOpenTest.rNostalgia.Checked Then
        '    mainFont = New Font("Comic Sans MS", 19, textStyle)
        'ElseIf FrmOpenTest.rOCRAEXT.Checked Then
        '    mainFont = New Font("OCR A Extended", 19, textStyle)
        'Else
        '    mainFont = New Font("Courier New", 18, FontStyle.Bold)
        'End If
        Dim textArea = New Rectangle(0, 0, sender.Width, sender.Height)
        Dim textFormat = New StringFormat
        textFormat.LineAlignment = StringAlignment.Center
        'added this line
        textFormat.Alignment = StringAlignment.Center

        'If FrmOpenTest.rUS.Checked Then
        '    e.Graphics.DrawRectangle(Pens.Transparent, textArea)
        '    e.Graphics.DrawString(PlateTextEntry.Text, mainFont, Brushes.Black, textArea, textFormat)
        'ElseIf FrmOpenTest.rUK.Checked Or FrmOpenTest.rNostalgia.Checked Then
        '    e.Graphics.DrawRectangle(Pens.Transparent, textArea)
        '    e.Graphics.DrawString(PlateTextEntry.Text, mainFont, Brushes.Gold, textArea, textFormat)
        'Else

        'End If
        Dim br As New SolidBrush(CurrentTheme.colorAnswers)

        e.Graphics.DrawRectangle(Pens.Transparent, textArea)
        e.Graphics.DrawString(PlateTextEntry.Text, mainFont, br, textArea, textFormat)
        canvas = Nothing
    End Sub

    Private Sub LoadQuestionAnswers()
        Try
            _amountQuestions = _questions.Count

            If _question > _amountQuestions Then
                afterLastQuestion()
            Else

                'Index is one lower.
                Dim index As Integer = _question - 1

                If _questions(index).text2 <> "" Then
                    txtTekst2.Text = _questions(index).text2
                End If
                If _questions(index).text1 <> "" Then
                    txtTekst1.Text = _questions(index).text1
                    tmTekst2.Interval = 5000
                    txtTekst1.Visible = True
                    txtQuestion.Visible = False
                    smallLogo.Visible = False
                    tmTekst1.Start()
                    _questionDisplay = _questionDisplay - 1
                Else
                    If FrmOpenTest.rNumberBeforeQuestion.Checked Then
                        txtQuestion.Text = _questionDisplay & ". " & _questions(index).text
                    Else
                        txtQuestion.Text = _questions(index).text
                    End If
                    'Looking for an open question, if not found, it will continue to load the answers
                    If IsNothing(_questions(index).answers) Then
                        t1.Visible = True
                        t2.Visible = True
                        t3.Visible = True
                    Else
                        Dim iList As New List(Of Integer)
                        For i = 0 To _questions(index).answers.Count - 1
                            iList.Add(i)
                        Next

                        If FrmOpenTest.rRandom.Checked Then
                            iList.Randomize()
                            'For i = 0 To Questions(index).answers.Count - 1
                            '    Dim selectedIndex As Integer = CInt(Int(((iList.Count) * Rnd())))
                            '    addbutton(Questions(index).answers(selectedIndex))
                            '    iList.Remove(selectedIndex)
                            'Next
                        End If
                        For Each item In iList
                            addbutton(_questions(index).answers(item))
                        Next

                        'qAnswers = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())

                        'If (document.Name = "q" & question & "amount") Then
                        '    randomValuesLeft.Items.Clear()
                        '    Dim intCount0 = 0
                        '    qAmount = Val(document.ReadInnerXml.ToString())
                        '    For i = 1 To qAmount Step 1
                        '        randomValuesLeft.Items.Add(i)
                        '    Next
                        '    For intCount0 = 1 To qAmount
                        '        addbutton()

                        '    Next
                        'End If


                        'Write the correct answer to a temporary variable, will be used later on the buttonpressed event
                        _correctanswertemp = _questions(index).rightAnswer
                    End If
                End If
            End If

            'Dim document As XmlReader = New XmlTextReader(FrmOpenTest.file)
            'While (document.Read())

            '    Dim type = document.NodeType
            '    'Loading the amount of questions, while not strictly necessary still useful
            '    If (type = XmlNodeType.Element) Then
            '        If (document.Name = "questionscount") Then
            '            amountQuestions = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())
            '        End If
            '        If (document.Name = "q" & question & "text2") Then
            '            txtTekst2.Text = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())
            '        End If
            '        'Checking for text version first, if not found it will revert to a question.
            '        If (document.Name = "q" & question & "text1") Then
            '            tmTekst2.Interval = 5000
            '            txtTekst1.Text = document.ReadInnerXml.ToString
            '            txtTekst1.Visible = True
            '            txtQuestion.Visible = False
            '            smallLogo.Visible = False
            '            tmTekst1.Start()
            '            questionDisplay = questionDisplay - 1
            '        Else

            '            If (document.Name = "q" & question & "question") Then
            '                If FrmOpenTest.rNumberBeforeQuestion.Checked Then
            '                    txtQuestion.Text = questionDisplay & ". " &
            '                                       WebUtility.HtmlDecode(document.ReadInnerXml.ToString())
            '                Else
            '                    txtQuestion.Text = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())
            '                End If
            '            End If
            '            'Looking for an open question, if not found, it will continue to load the answers
            '            If document.Name = "q" & question & "openquestion" Then
            '                t1.Visible = True
            '                t2.Visible = True
            '                t3.Visible = True
            '            Else
            '                If (document.Name = "q" & question & "answers") Then
            '                    qAnswers = WebUtility.HtmlDecode(document.ReadInnerXml.ToString())

            '                End If

            '                If (document.Name = "q" & question & "amount") Then
            '                    randomValuesLeft.items.clear()
            '                    Dim intCount0 = 0
            '                    qAmount = Val(document.ReadInnerXml.ToString())
            '                    For i = 1 To qAmount Step 1
            '                        randomValuesLeft.Items.Add(i)
            '                    Next
            '                    For intCount0 = 1 To qAmount
            '                        addbutton()

            '                    Next
            '                End If


            '                'Write the correct answer to a temporary variable, will be used later on the buttonpressed event
            '                If (document.Name = "q" & question & "correctanswer") Then

            '                    correctanswertemp = document.ReadInnerXml.ToString

            '                End If
            '            End If

            '        End If
            '    End If

            'End While
            'document.Close()
            'Determining whether this is the last question. Note the > instead of >=

        Catch ex As Exception
            If My.Settings.language = "en" Then
                MsgBox("Something went wrong when loading the quiz!" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Else
                MsgBox("Er ging iets mis met het inladen van de test!" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            End If

            Close()
        End Try
        'Fixing overlap by the question and image
        txtQuestion.SendToBack()
        smallLogo.SendToBack()
    End Sub

    Private Sub NextQuestion()
        'Setting everything to default
        t1.Visible = False
        t2.Visible = False
        t3.Visible = False
        txtQuestion.Visible = True
        If CurrentTheme.logoTestEnabled Then
            smallLogo.Visible = True
        End If
        _question = _question + 1
        _questionDisplay = _questionDisplay + 1
        _value = 0
        _locationValue = 0
        _amountAnswers = 0
        _buttonpressed = False
        t1.Text = ""
        'Deleting all PictureBoxes and Labels, with exceptions
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If _
                TypeOf Me.Controls(i) Is Label And Me.Controls(i).Name <> "txtQuestion" And
                Me.Controls(i).Name <> "txtTekst1" And Me.Controls(i).Name <> "txtTekst2" And
                Me.Controls(i).Name <> "t3" And Me.Controls(i).Name <> "txtTime" Then
                Me.Controls.RemoveAt(i)
            End If
        Next
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If _
                TypeOf Me.Controls(i) Is PictureBox And Me.Controls(i).Name <> "smallLogo" And
                Me.Controls(i).Name <> "t2" Then
                Me.Controls.RemoveAt(i)
            End If
        Next
        loadQuestionAnswers()
    End Sub

    Private Sub AfterLastQuestion()
        _closePass = True

        tmTime.Stop()
        If FrmOpenTest.rAlleen.Checked Then
            If FrmOpenTest.rWedstrijd.Checked = True Then
                Dim source As String = FrmEnterName.TextBox1.Text & "#" & _answersRight & "#" & _time & "#" & "Groen"
                Using md5Hash As MD5 = MD5.Create()
                    Dim hash As String = GetMd5Hash(md5Hash, source)
                    Dim settings As New XmlWriterSettings()

                    'lets tell to our xmlwritersettings that it must use indention for our xml
                    settings.Indent = True

                    'lets create the MyXML.xml document, the first parameter was the Path/filename of xml file
                    ' the second parameter was our xml settings

                    Dim xmlWrt As XmlWriter = XmlWriter.Create(FrmOpenTest.txtWedstrijdFile.Text)

                    With XmlWrt

                        ' Write the Xml declaration.
                        .WriteStartDocument()

                        ' Write a comment.
                        .WriteComment("WIDM Exam v2 wedstrijdresultaten. Gemaakt door Koenvh (Koenvh.nl)")
                        .WriteStartElement("Data")
                        .WriteStartElement("hash")
                        .WriteString(hash)
                        .WriteEndElement()
                        .WriteStartElement("result")
                        .WriteString(FrmEnterName.TextBox1.Text & "#" & _answersRight & "#" & _time & "#" & "Groen")
                        .WriteEndElement()
                        .WriteStartElement("answers")
                        .WriteString(_wedstrijdantwoordentemp)
                        .WriteEndElement()
                        ' Write the root element.
                        ' Close the XmlTextWriter.
                        .WriteEndDocument()
                        .Close()

                    End With
                    _wedstrijdantwoordentemp = ""
                End Using
            End If
            If My.Settings.language = "en" Then
                FrmResult.txtScore.Text = _answersRight & " answers right in " & Val(_time) / 10 & " seconds."
            Else
                FrmResult.txtScore.Text = _answersRight & " antwoorden goed in " & Val(_time) / 10 & " seconden."
            End If


            FrmResult.Show()
            FrmResult.Activate()
            'Now, the person will see the score.. Which is presented in FrmResult.
            'We calculated the score using the following formula:
            'Time adds every second 1 to the score
            'Every wrong answer adds 20 to the score
            '1000 - score = Result... How less "score" you have, how higher your result.
        ElseIf FrmOpenTest.rGroep.Checked Then
            Dim result = 0
            Try
                'Try adding the results to the listview
                Dim newItem As New ListViewItem(FrmEnterName.TextBox1.Text) '// add text Item.
                newItem.SubItems.Add(_answersRight)
                newItem.SubItems.Add(_time) '// add SubItem.
                newItem.SubItems.Add("Groen") '// add SubItem.
                newItem.SubItems.Add("0")
                FrmOpenTest.listviewExecutie.Items.Add(newItem) '// add Item to ListView.

                FrmEnterName.TextBox1.Text = ""
                FrmEnterName.TextBox2.Text = ""
                FrmEnterName.TextBox3.Text = ""

                If FrmOpenTest.rSaveAtClose.Checked = True Then
                    SaveXML()
                End If
                _closePass = True


                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox(
                "Something went wrong when choosing rAlleen or rGroep.. Please report this to the developer.. FASTER! FASTER! :D")
        End If
    End Sub


    Private Sub FrmTest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'My.Computer.Audio.Stop()
        If _closePass = True Then
        Else

            If FrmOpenTest.rGroep.Checked Then
                If My.Settings.password = "" Then

                Else
                    FrmPassword.ShowDialog()
                    If FrmPassword.cancel = True Then
                        e.Cancel = True
                    ElseIf FrmPassword.TextBox1.Text = My.Settings.password Then
                        FrmEnterName.closePass = True
                        FrmEnterName.Close()
                    Else
                        If My.Settings.language = "en" Then
                            MsgBox("Wrong password", MsgBoxStyle.Exclamation)
                        Else
                            MsgBox("Verkeerd wachtwoord", MsgBoxStyle.Exclamation)
                        End If
                        e.Cancel = True
                    End If
                End If
            Else
                FrmEnterName.Close()
            End If

        End If
    End Sub

    Private Sub FrmTest_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

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

    Private Sub tmTime_Tick(sender As Object, e As EventArgs) Handles tmTime.Tick
        _time = _time + 1
    End Sub

    Private Sub CorrectAnswer()

        If My.Computer.FileSystem.FileExists(FrmOpenTest.file & "a") Then
            Dim lines() As String = File.ReadAllLines(FrmOpenTest.file & "a")
            Try
                _answersRight = _answersRight + lines(_question - 1)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                _answersRight = _answersRight + 1
            End Try
        Else
            _answersRight = _answersRight + 1
        End If
    End Sub

    Private Sub SaveLastQuestion()
        If FrmOpenTest.rGroep.Checked Then
            'Dim temp As String = ""
            'Try
            '    Dim Read As New System.IO.StreamReader(FrmOpenTest.file & "l")
            '    temp = Read.ReadToEnd
            '    Read.Close()
            'Catch ex As Exception

            'End Try
            'Dim Write As New System.IO.StreamWriter(FrmOpenTest.file & "l")
            'Write.Write(temp)
            'Write.WriteLine(question & "#" & txtQuestion.Text & "#" & FrmEnterName.TextBox1.Text & "#" & answer)
            'Write.Close()

            Dim newItem As New ListViewItem(_question.ToString.PadLeft(3)) '// add text Item.
            newItem.SubItems.Add(txtQuestion.Text)
            newItem.SubItems.Add(FrmEnterName.TextBox1.Text) '// add SubItem.
            newItem.SubItems.Add(_answer) '// add SubItem.
            FrmOpenTest.listAntwoorden.Items.Add(newItem)
        ElseIf FrmOpenTest.rWedstrijd.Checked Then
            _wedstrijdantwoordentemp = _wedstrijdantwoordentemp & _question & "#" & txtQuestion.Text & "#" &
                                      FrmEnterName.TextBox1.Text & "#" & _answer & vbCrLf
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmToBack.Tick
        tmToBack.Stop()
        txtQuestion.SendToBack()
        smallLogo.SendToBack()
    End Sub

    Private Sub tmButton_Tick(sender As Object, e As EventArgs) Handles tmButton.Tick

        'If FrmOpenTest.rNewTheme.Checked Then
        Try
            s.Image = CurrentTheme.imgButton
        Catch ex As Exception

        End Try
        t2.Image = CurrentTheme.imgButton
        'End If


        tmButton.Stop()
        nextQuestion()
    End Sub

    Private Sub tmTekst1_Tick(sender As Object, e As EventArgs) Handles tmTekst1.Tick
        txtTekst2.Visible = True
        txtTekst1.Visible = False
        tmTekst1.Stop()
        If txtTekst2.Text = "" Then
            tmTekst2.Interval = 10
        Else
            tmTekst2.Interval = 5000
        End If
        tmTekst2.Start()
    End Sub

    Private Sub tmTekst2_Tick(sender As Object, e As EventArgs) Handles tmTekst2.Tick
        tmTekst2.Stop()
        txtTekst2.Visible = False
        'afterLastQuestion()
        'question = question + 1
        'lastQuestion = True
        'loadQuestionAnswers()
        nextQuestion()
    End Sub

    Private Sub t2_Click(sender As Object, e As EventArgs) Handles t2.Click
        WMP1.Ctlcontrols.stop()
        WMP1.Ctlcontrols.play()
        If FrmOpenTest.rVirtualKeyboard.Checked Then
            FrmOpenTest.killVirtualKeyboard()
        End If
        _answer = t1.Text
        'Try

        'MsgBox(answer)
        'Catch ex As Exception
        '    Console.Write(ex.Message)
        'End Try
        saveLastQuestion()
        t2.Image = CurrentTheme.imgButtonClick


        tmButton.Start()
    End Sub

    Private Sub t1_KeyDown(sender As Object, e As KeyEventArgs) Handles t1.KeyDown
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

    Private Sub t1_MouseClick(sender As Object, e As MouseEventArgs) Handles t1.MouseClick
        If FrmOpenTest.rVirtualKeyboard.Checked Then
            FrmOpenTest.callVirtualKeyboard()
        End If
    End Sub

    Private Sub t1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged
    End Sub

    Private Sub t2_MouseEnter(sender As Object, e As EventArgs) Handles t2.MouseEnter
        If CurrentTheme.buttonHoverEnabled Then
            t2.Image = CurrentTheme.imgButtonHover
        End If
    End Sub

    Private Sub t2_MouseLeave(sender As Object, e As EventArgs) Handles t2.MouseLeave
        If CurrentTheme.buttonHoverEnabled Then
            t2.Image = CurrentTheme.imgButton
        End If
    End Sub
End Class