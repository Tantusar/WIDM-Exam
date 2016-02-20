Imports System.IO
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class FrmTheme
    Const Afbeeldingen = "Afbeeldingen"

    Dim _saved As Boolean = True

    Dim _currentTheme As New Theme

    Public Shared Function IsFontInstalled(ByVal fontName As String) As Boolean
        Try
            Using testFont As Font = New Font(fontName, 10)
                Return CBool(String.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase) = 0)
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Sub ReloadExamples()
        _saved = False

        txtName.Text = _currentTheme.Name
        txtAuthor.Text = _currentTheme.Author

        txtMusicTest.Text = _currentTheme.MusicTest
        txtMusicExecution.Text = _currentTheme.MusicExecution

        rBackgroundTest.Checked = _currentTheme.BackgroundTestEnabled
        rBackgroundIntro.Checked = _currentTheme.BackgroundIntroEnabled
        rHover.Checked = _currentTheme.ButtonHoverEnabled
        rLogoQuestion.Checked = _currentTheme.LogoTestEnabled
        rLogoIntro.Checked = _currentTheme.LogoIntroEnabled
        rMusicTest.Checked = _currentTheme.MusicTestEnabled
        rMusicExecution.Checked = _currentTheme.MusicExecutionEnabled
        rColorClick.Checked = _currentTheme.ColorClickEnabled
        rQuestionBackground.Checked = _currentTheme.QuestionBackgroundEnabled

        If _currentTheme.LogoTestEnabled Then
            picLogo.Image = _currentTheme.ImgLogoTest
        Else
            picLogo.Image = Nothing
        End If
        If _currentTheme.LogoTestPosition = Theme.Position.TopRight Then
            picLogo.Location = New Point(Me.Width - picLogo.Size.Width - 200, picLogo.Location.Y)
        End If

        lQuestion.Font = _currentTheme.FontQuestion

        lQuestion.ForeColor = _currentTheme.ColorQuestion
        Try
            lQuestion.TextAlign = _currentTheme.QuestionAlignment
        Catch ex As Exception

        End Try
        If _currentTheme.QuestionBackgroundEnabled Then
            lQuestion.BackgroundImage = _currentTheme.ImgQuestionBackground
            lQuestion.BackgroundImageLayout = ImageLayout.Stretch
        Else
            lQuestion.BackgroundImage = Nothing
        End If
        pnlExampleTest.BackColor = _currentTheme.BackgroundColorTest
        If _currentTheme.BackgroundTestEnabled Then
            pnlExampleTest.BackgroundImage = _currentTheme.ImgBackgroundTest
        Else
            pnlExampleTest.BackgroundImage = Nothing
        End If
        lAnswer.Font = _currentTheme.FontAnswers

        lAnswer.ForeColor = _currentTheme.ColorAnswers
        picAnswer.Image = _currentTheme.ImgButton

        If _currentTheme.BackgroundIntroEnabled Then
            pnlExampleIntro.BackgroundImage = _currentTheme.ImgBackgroundIntro
        Else
            pnlExampleIntro.BackgroundImage = Nothing
        End If
        pnlExampleIntro.BackColor = _currentTheme.BackgroundColorIntro

        If _currentTheme.LogoIntroEnabled Then
            picLogoIntro.Image = _currentTheme.ImgLogoIntro
        Else
            picLogoIntro.Image = Nothing
        End If
        If _currentTheme.LogoIntroPosition = Theme.Position.TopRight Then
            picLogoIntro.Location = New Point(Me.Width - picLogoIntro.Size.Width - 200, picLogoIntro.Location.Y)
        End If


        If _currentTheme.IntroStyle = Theme.Style.Old Then
            pnlNew.Visible = False
            pnlOld.Visible = True
            pnlUS.Visible = False
            pnlBelgium.Visible = False
        ElseIf _currentTheme.IntroStyle = Theme.Style.Us Then
            pnlNew.Visible = False
            pnlOld.Visible = False
            pnlUS.Visible = True
            pnlBelgium.Visible = False
        ElseIf _currentTheme.IntroStyle = Theme.Style.Belgium Then
            pnlNew.Visible = False
            pnlOld.Visible = False
            pnlUS.Visible = False
            pnlBelgium.Visible = True
        Else
            pnlNew.Visible = True
            pnlOld.Visible = False
            pnlUS.Visible = False
            pnlBelgium.Visible = False
        End If

        pnlNew.Top = (pnlExampleIntro.Height / 2) - (pnlNew.Height / 2)
        pnlNew.Left = (pnlExampleIntro.Width / 2) - (pnlNew.Width / 2)
        pnlOld.Top = (pnlExampleIntro.Height / 2) - (pnlOld.Height / 2)
        pnlOld.Left = (pnlExampleIntro.Width / 2) - (pnlOld.Width / 2)
        pnlUS.Top = (pnlExampleIntro.Height / 2) - (pnlUS.Height / 2)
        pnlUS.Left = (pnlExampleIntro.Width / 2) - (pnlUS.Width / 2)
        pnlBelgium.Left = (pnlExampleIntro.Width / 2) - (pnlBelgium.Width / 2)
        pnlBelgium.Top = (pnlExampleIntro.Height / 2) - (pnlBelgium.Height / 2)

        lUSname.Font = _currentTheme.FontIntroText
        lUStext.Font = _currentTheme.FontIntroTextfield

        lNewname.Font = _currentTheme.FontIntroText
        lNewname.ForeColor = _currentTheme.ColorIntroText
        lNewtext.Font = _currentTheme.FontIntroTextfield
        lNewtext.ForeColor = _currentTheme.ColorIntroTextfield

        lOldname.Font = _currentTheme.FontIntroText
        lOldname.ForeColor = _currentTheme.ColorIntroText
        lOldtext.Font = _currentTheme.FontIntroTextfield
        lOldtext.ForeColor = _currentTheme.ColorIntroTextfield
        lOldbutton.Font = _currentTheme.FontIntroText
        lOldbutton.ForeColor = _currentTheme.ColorIntroText

        'Belgium
        lNameBelgium.Font = CurrentTheme.FontIntroText
        TextBox4.Font = CurrentTheme.FontIntroTextfield
        TextBox4.BackColor = CurrentTheme.BackgroundColorIntro
        pnlBelgium.BackColor = CurrentTheme.BackgroundColorIntro
        TextBox4.ForeColor = CurrentTheme.ColorIntroTextfield
        lNameBelgium.ForeColor = CurrentTheme.ColorIntroText

        tabExample.TabPages("green").BackgroundImage = _currentTheme.ImgGreenScreen
        tabExample.TabPages("red").BackgroundImage = _currentTheme.ImgRedScreen

        Try
            IsFontInstalled(_currentTheme.FontQuestion.Name)
            IsFontInstalled(_currentTheme.FontAnswers.Name)
            IsFontInstalled(_currentTheme.FontIntroText.Name)
            IsFontInstalled(_currentTheme.FontIntroTextfield.Name)
        Catch ex As Exception

        End Try

        comboStyle.SelectedItem = _currentTheme.IntroStyle
        comboAlignment.SelectedItem = _currentTheme.QuestionAlignment
        comboLogoPosition.SelectedItem = _currentTheme.LogoTestPosition
        comboIntroPosition.SelectedItem = _currentTheme.LogoIntroPosition
        comboBackgroundTestSizeMode.SelectedItem = _currentTheme.BackgroundTestSizeMode
        comboBackgroundIntroSizeMode.SelectedItem = _currentTheme.BackgroundIntroSizeMode
    End Sub

    Private Sub btnFontQuestion_Click(sender As Object, e As EventArgs) Handles btnFontQuestion.Click
        FontDialogQuestion.Font = _currentTheme.FontQuestion
        FontDialogQuestion.Color = _currentTheme.ColorQuestion
        Try
            If FontDialogQuestion.ShowDialog() = DialogResult.OK Then
                _currentTheme.FontQuestion = FontDialogQuestion.Font
                _currentTheme.ColorQuestion = FontDialogQuestion.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub FrmTheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _currentTheme Is Nothing Then
            _currentTheme = New Theme()
        End If
        comboStyle.DataSource = [Enum].GetValues(GetType(Theme.Style))
        comboLogoPosition.DataSource = [Enum].GetValues(GetType(Theme.Position))
        comboIntroPosition.DataSource = [Enum].GetValues(GetType(Theme.Position))
        comboAlignment.DataSource = [Enum].GetValues(GetType(ContentAlignment))
        comboBackgroundIntroSizeMode.DataSource = [Enum].GetValues(GetType(PictureBoxSizeMode))
        comboBackgroundTestSizeMode.DataSource = [Enum].GetValues(GetType(PictureBoxSizeMode))
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Sub New(ByVal currentThemeName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Open(CurDir() & "\Thema's\" & currentThemeName)
    End Sub

    Private Sub btnLogoQuestion_Click(sender As Object, e As EventArgs) Handles btnLogoQuestion.Click
        Try
            With OpenLogoQuestion
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.LogoTest = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundImage_Click(sender As Object, e As EventArgs) Handles btnBackgroundImage.Click
        Try
            With OpenBackground
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.BackgroundTest = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColor_Click(sender As Object, e As EventArgs) Handles btnBackgroundColor.Click
        ColorBackground.Color = _currentTheme.BackgroundColorTest
        Try
            If ColorBackground.ShowDialog() = DialogResult.OK Then
                _currentTheme.BackgroundColorTest = ColorBackground.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnFontAnswers_Click(sender As Object, e As EventArgs) Handles btnFontAnswers.Click
        FontDialogAnswers.Font = _currentTheme.FontAnswers
        FontDialogAnswers.Color = _currentTheme.ColorAnswers
        Try
            If FontDialogAnswers.ShowDialog() = DialogResult.OK Then
                _currentTheme.FontAnswers = FontDialogAnswers.Font
                _currentTheme.ColorAnswers = FontDialogAnswers.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnButtonNormal_Click(sender As Object, e As EventArgs) Handles btnButtonNormal.Click
        Try
            With OpenNormal
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.Button = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnButtonClick_Click(sender As Object, e As EventArgs) Handles btnButtonClick.Click
        Try
            With OpenClick
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.ButtonClick = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnButtonHover_Click(sender As Object, e As EventArgs) Handles btnButtonHover.Click
        Try
            With OpenHover
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.ButtonHover = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnFontIntroText_Click(sender As Object, e As EventArgs) Handles btnFontIntroText.Click
        FontIntroText.Font = _currentTheme.FontIntroText
        FontIntroText.Color = _currentTheme.ColorIntroText
        Try
            If FontIntroText.ShowDialog() = DialogResult.OK Then
                _currentTheme.FontIntroText = FontIntroText.Font
                _currentTheme.ColorIntroText = FontIntroText.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnLogoIntro_Click(sender As Object, e As EventArgs) Handles btnLogoIntro.Click
        Try
            With OpenLogoIntro
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.LogoIntro = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundImageIntro_Click(sender As Object, e As EventArgs) Handles btnBackgroundImageIntro.Click
        Try
            With OpenBackgroundIntro
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.BackgroundIntro = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColorIntro_Click(sender As Object, e As EventArgs) Handles btnBackgroundColorIntro.Click
        ColorBackgroundIntro.Color = _currentTheme.BackgroundColorIntro
        Try
            If ColorBackgroundIntro.ShowDialog() = DialogResult.OK Then
                _currentTheme.BackgroundColorIntro = ColorBackgroundIntro.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnGreen_Click(sender As Object, e As EventArgs) Handles btnGreen.Click
        Try
            With OpenGreen
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.GreenScreen = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnRed_Click(sender As Object, e As EventArgs) Handles btnRed.Click
        Try
            With OpenRed
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.RedScreen = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        ReloadExamples()
        'Dim frm As New FrmTest
        'frm.TopLevel = False
        'frm.Parent = pnlExampleTest 'tabExample.TabPages(0)
        'frm.Show()
        'pnlExampleTest.AutoScroll = True
        'pnlExampleTest.Hide()
    End Sub

    Private Sub picAnswer_Click(sender As Object, e As EventArgs) Handles picAnswer.Click
        picAnswer.Image = _currentTheme.ImgButtonClick
        If _currentTheme.ColorClickEnabled Then
            lAnswer.ForeColor = _currentTheme.ColorClick
        End If
        timerButton.Start()
    End Sub

    Private Sub picAnswer_MouseEnter(sender As Object, e As EventArgs) Handles picAnswer.MouseEnter
        If _currentTheme.ButtonHoverEnabled Then
            picAnswer.Image = _currentTheme.ImgButtonHover
        End If
    End Sub

    Private Sub picAnswer_MouseLeave(sender As Object, e As EventArgs) Handles picAnswer.MouseLeave
        If _currentTheme.ButtonHoverEnabled Then
            picAnswer.Image = _currentTheme.ImgButton
        End If
    End Sub

    Private Sub timerButton_Tick(sender As Object, e As EventArgs) Handles timerButton.Tick
        picAnswer.Image = _currentTheme.ImgButton
        If _currentTheme.ColorClickEnabled Then
            lAnswer.ForeColor = _currentTheme.ColorAnswers
        End If
        timerButton.Stop()
    End Sub
    Private Sub Save(ByVal messageBox As Boolean)
        Try
            Dim objStreamWriter As New IO.StreamWriter(CurDir() & "\Thema's\" & txtName.Text & ".widmthema")
            objStreamWriter.Write(JsonConvert.SerializeObject(_currentTheme, Formatting.Indented))
            objStreamWriter.Close()
            _saved = True
            If messageBox Then MsgBox(GetLang("SavedSuccess"), MsgBoxStyle.Information)
            ReloadExamples()
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripSave_Click(sender As Object, e As EventArgs) Handles ToolStripSave.Click
        Save(True)
    End Sub
    Private Sub Open(ByVal fileName As String)
        Try
            Dim objStreamReader As New IO.StreamReader(fileName)
            _currentTheme = JsonConvert.DeserializeObject(Of Theme)(objStreamReader.ReadToEnd())
            objStreamReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub ToolStripOpen_Click(sender As Object, e As EventArgs) Handles ToolStripOpen.Click
        OpenTheme.InitialDirectory = CurDir() & "\Thema's"
        If OpenTheme.ShowDialog() = DialogResult.OK Then
            'Dim fs As New FileStream(OpenTheme.FileName, FileMode.Open)
            'Try
            '    Dim formatter As New BinaryFormatter

            '    ' Deserialize the hashtable from the file and 
            '    ' assign the reference to the local variable.
            '    CurrentTheme = DirectCast(formatter.Deserialize(fs), Theme)
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical)
            '    Throw
            'Finally
            '    fs.Close()

            'End Try
            Open(OpenTheme.FileName)

        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        _currentTheme.Name = txtName.Text
        Me.Text = txtName.Text & ".widmthema - WIDM Exam"
    End Sub

    Private Sub txtAuthor_TextChanged(sender As Object, e As EventArgs) Handles txtAuthor.TextChanged
        _currentTheme.Author = txtAuthor.Text
    End Sub

    Private Sub rHover_CheckedChanged(sender As Object, e As EventArgs) Handles rHover.CheckedChanged
        btnButtonHover.Enabled = rHover.Checked
        _currentTheme.ButtonHoverEnabled = rHover.Checked
    End Sub

    Private Sub comboStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboStyle.SelectedIndexChanged
        _currentTheme.IntroStyle = CType(comboStyle.SelectedValue, Theme.Style)
    End Sub

    Private Sub rBackgroundTest_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundTest.CheckedChanged
        btnBackgroundImage.Enabled = rBackgroundTest.Checked
        _currentTheme.BackgroundTestEnabled = rBackgroundTest.Checked
    End Sub

    Private Sub rBackgroundIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundIntro.CheckedChanged
        btnBackgroundImageIntro.Enabled = rBackgroundIntro.Checked
        _currentTheme.BackgroundIntroEnabled = rBackgroundIntro.Checked
    End Sub

    Private Sub btnIntroTextfield_Click(sender As Object, e As EventArgs) Handles btnIntroTextfield.Click
        FontIntroTextfield.Font = _currentTheme.FontIntroTextfield
        FontIntroTextfield.Color = _currentTheme.ColorIntroTextfield
        Try
            If FontIntroTextfield.ShowDialog() = DialogResult.OK Then
                _currentTheme.FontIntroTextfield = FontIntroTextfield.Font
                _currentTheme.ColorIntroTextfield = FontIntroTextfield.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub grpQuestion_Enter(sender As Object, e As EventArgs) Handles grpQuestion.Enter

    End Sub

    Private Sub rLogoQuestion_CheckedChanged(sender As Object, e As EventArgs) Handles rLogoQuestion.CheckedChanged
        btnLogoQuestion.Enabled = rLogoQuestion.Checked
        _currentTheme.LogoTestEnabled = rLogoQuestion.Checked
    End Sub

    Private Sub rLogoIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rLogoIntro.CheckedChanged
        btnLogoIntro.Enabled = rLogoIntro.Checked
        _currentTheme.LogoIntroEnabled = rLogoIntro.Checked
    End Sub

    Private Sub rMusicTest_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicTest.CheckedChanged
        txtMusicTest.Enabled = rMusicTest.Checked
        _currentTheme.MusicTestEnabled = rMusicTest.Checked
    End Sub

    Private Sub rMusicExecution_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicExecution.CheckedChanged
        txtMusicExecution.Enabled = rMusicExecution.Checked
        _currentTheme.MusicExecutionEnabled = rMusicExecution.Checked
    End Sub

    Private Sub txtMusicTest_TextChanged(sender As Object, e As EventArgs) Handles txtMusicTest.TextChanged
        _currentTheme.MusicTest = txtMusicTest.Text
    End Sub

    Private Sub txtMusicExecution_TextChanged(sender As Object, e As EventArgs) Handles txtMusicExecution.TextChanged
        _currentTheme.MusicExecution = txtMusicExecution.Text
    End Sub

    Private Sub btnColorClick_Click(sender As Object, e As EventArgs) Handles btnColorClick.Click
        ColorClick.Color = _currentTheme.ColorClick
        Try
            If ColorClick.ShowDialog() = DialogResult.OK Then
                _currentTheme.ColorClick = ColorClick.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub rColorClick_CheckedChanged(sender As Object, e As EventArgs) Handles rColorClick.CheckedChanged
        btnColorClick.Enabled = rColorClick.Checked
        _currentTheme.ColorClickEnabled = rColorClick.Checked
    End Sub

    Private Sub rQuestionBackground_CheckedChanged(sender As Object, e As EventArgs) Handles rQuestionBackground.CheckedChanged
        btnQuestionBackground.Enabled = rQuestionBackground.Checked
        _currentTheme.QuestionBackgroundEnabled = rQuestionBackground.Checked
    End Sub

    Private Sub btnQuestionBackground_Click(sender As Object, e As EventArgs) Handles btnQuestionBackground.Click
        Try
            With OpenQuestionBackground
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.QuestionBackground = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(GetLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub comboAlignment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAlignment.SelectedIndexChanged
        _currentTheme.QuestionAlignment = CType(comboAlignment.SelectedValue, ContentAlignment)
    End Sub

    Private Sub btnMusicTest_Click(sender As Object, e As EventArgs) Handles btnMusicTest.Click
        OpenMusicTest.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicTest.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicTest.FileName) = CurDir() & "\Geluid" Then
                txtMusicTest.Text = OpenMusicTest.SafeFileName
            Else
                MsgBox(GetLang("WrongFolderGeluid"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnMusicExecution_Click(sender As Object, e As EventArgs) Handles btnMusicExecution.Click
        OpenMusicExecution.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicExecution.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicExecution.FileName) = CurDir() & "\Geluid" Then
                txtMusicExecution.Text = OpenMusicExecution.SafeFileName
            Else
                MsgBox(GetLang("WrongFolderGeluid"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub FrmTheme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _saved = False Then
            Dim result = MsgBox(GetLang("SaveChanges"), vbYesNoCancel Or MsgBoxStyle.Question)
            If result = MsgBoxResult.Yes Then
                Save(False)
            ElseIf result = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Sub Export(ByVal location As String)
        Try
            Save(False)
            Dim rootDir = CurDir() & "\Afbeeldingen"
            Dim rootDirGeluid = CurDir() & "\Geluid\"
            Dim afbeeldingen = "Afbeeldingen"
            Dim geluid = "Geluid\"
            Using zip As ZipFile = New ZipFile()
                'zip.AddDirectoryByName("Thema's")
                zip.AddFile(CurDir() & "\Thema's\" & _currentTheme.Name & ".widmthema", "\Thema's")

                'zip.AddDirectoryByName("Afbeeldingen")
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.LogoTest, "\", "/")) Then
                    If _currentTheme.LogoTestEnabled Then zip.AddFile(rootDir & _currentTheme.LogoTest, afbeeldingen & Path.GetDirectoryName(_currentTheme.LogoTest))
                End If
                'MsgBox(zip.EntryFileNames(1).ToString())
                'MsgBox(Replace(afbeeldingen & CurrentTheme.logoIntro, "\", "/"))
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.LogoIntro, "\", "/")) Then
                    If _currentTheme.LogoIntroEnabled Then zip.AddFile(rootDir & _currentTheme.LogoIntro, afbeeldingen & Path.GetDirectoryName(_currentTheme.LogoIntro))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.BackgroundTest, "\", "/")) Then
                    If _currentTheme.BackgroundTestEnabled Then zip.AddFile(rootDir & _currentTheme.BackgroundTest, afbeeldingen & Path.GetDirectoryName(_currentTheme.BackgroundTest))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.BackgroundIntro, "\", "/")) Then
                    If _currentTheme.BackgroundIntroEnabled Then zip.AddFile(rootDir & _currentTheme.BackgroundIntro, afbeeldingen & Path.GetDirectoryName(_currentTheme.BackgroundIntro))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.QuestionBackground, "\", "/")) Then
                    If _currentTheme.QuestionBackgroundEnabled Then zip.AddFile(rootDir & _currentTheme.QuestionBackground, afbeeldingen & Path.GetDirectoryName(_currentTheme.QuestionBackground))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.Button, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.Button, afbeeldingen & Path.GetDirectoryName(_currentTheme.Button))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.ButtonClick, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.ButtonClick, afbeeldingen & Path.GetDirectoryName(_currentTheme.ButtonClick))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.ButtonHover, "\", "/")) Then
                    If _currentTheme.ButtonHoverEnabled Then zip.AddFile(rootDir & _currentTheme.ButtonHover, afbeeldingen & Path.GetDirectoryName(_currentTheme.ButtonHover))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.GreenScreen, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.GreenScreen, afbeeldingen & Path.GetDirectoryName(_currentTheme.GreenScreen))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.RedScreen, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.RedScreen, afbeeldingen & Path.GetDirectoryName(_currentTheme.RedScreen))
                End If

                'zip.AddDirectoryByName("Geluid")
                If Not zip.ContainsEntry(Replace(geluid & _currentTheme.MusicTest, "\", "/")) Then
                    If _currentTheme.MusicTestEnabled Then zip.AddFile(rootDirGeluid & _currentTheme.MusicTest, geluid)
                End If
                If Not zip.ContainsEntry(Replace(geluid & _currentTheme.MusicExecution, "\", "/")) Then
                    If _currentTheme.MusicExecutionEnabled Then zip.AddFile(rootDirGeluid & _currentTheme.MusicExecution, geluid)
                End If

                'Dim temp As String = ""
                'For Each item In zip.Entries
                '    temp += item.FileName & vbCrLf
                'Next
                'MsgBox(temp)
                zip.Save(location)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripExport_Click(sender As Object, e As EventArgs) Handles ToolStripExport.Click
        SaveExport.FileName = _currentTheme.Name
        If SaveExport.ShowDialog() = DialogResult.OK Then
            Export(SaveExport.FileName)
        End If
    End Sub

    Private Sub comboLogoPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboLogoPosition.SelectedIndexChanged
        _currentTheme.LogoTestPosition = CType(comboLogoPosition.SelectedValue, Theme.Position)
    End Sub

    Private Sub comboIntroLogo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboIntroPosition.SelectedIndexChanged
        _currentTheme.LogoIntroPosition = CType(comboIntroPosition.SelectedValue, Theme.Position)
    End Sub

    Private Sub comboBackgroundTestSizeMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBackgroundTestSizeMode.SelectedIndexChanged
        _currentTheme.BackgroundTestSizeMode = CType(comboBackgroundTestSizeMode.SelectedValue, PictureBoxSizeMode)
    End Sub

    Private Sub comboBackgroundIntroSizeMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBackgroundIntroSizeMode.SelectedIndexChanged
        _currentTheme.BackgroundIntroSizeMode = CType(comboBackgroundIntroSizeMode.SelectedValue, PictureBoxSizeMode)
    End Sub
End Class