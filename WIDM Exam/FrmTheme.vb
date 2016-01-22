Imports System.IO
Imports Ionic.Zip
Imports Newtonsoft.Json

Public Class FrmTheme
    Const Afbeeldingen = "Afbeeldingen"

    Dim _saved As Boolean = True

    Dim _currentTheme As New Theme

    Public Shared Function IsFontInstalled(ByVal fontName As String) As Boolean
        Try
            Using testFont As Font = New Font(FontName, 10)
                Return CBool(String.Compare(FontName, TestFont.Name, StringComparison.InvariantCultureIgnoreCase) = 0)
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function

    Sub ReloadExamples()
        _saved = False

        txtName.Text = _currentTheme.name
        txtAuthor.Text = _currentTheme.author

        txtMusicTest.Text = _currentTheme.musicTest
        txtMusicExecution.Text = _currentTheme.musicExecution

        rBackgroundTest.Checked = _currentTheme.backgroundTestEnabled
        rBackgroundIntro.Checked = _currentTheme.backgroundIntroEnabled
        rHover.Checked = _currentTheme.buttonHoverEnabled
        rLogoQuestion.Checked = _currentTheme.logoTestEnabled
        rLogoIntro.Checked = _currentTheme.logoIntroEnabled
        rMusicTest.Checked = _currentTheme.musicTestEnabled
        rMusicExecution.Checked = _currentTheme.musicExecutionEnabled
        rColorClick.Checked = _currentTheme.colorClickEnabled
        rQuestionBackground.Checked = _currentTheme.questionBackgroundEnabled

        If _currentTheme.logoTestEnabled Then
            picLogo.Image = _currentTheme.imgLogoTest
        Else
            picLogo.Image = Nothing
        End If
        lQuestion.Font = _currentTheme.fontQuestion

        lQuestion.ForeColor = _currentTheme.colorQuestion
        Try
            lQuestion.TextAlign = _currentTheme.questionAlignment
        Catch ex As Exception

        End Try
        If _currentTheme.questionBackgroundEnabled Then
            lQuestion.BackgroundImage = _currentTheme.imgQuestionBackground
            lQuestion.BackgroundImageLayout = ImageLayout.Stretch
        Else
            lQuestion.BackgroundImage = Nothing
        End If
        pnlExampleTest.BackColor = _currentTheme.backgroundColorTest
        If _currentTheme.backgroundTestEnabled Then
            pnlExampleTest.BackgroundImage = _currentTheme.imgBackgroundTest
        Else
            pnlExampleTest.BackgroundImage = Nothing
        End If
        lAnswer.Font = _currentTheme.fontAnswers

        lAnswer.ForeColor = _currentTheme.colorAnswers
        picAnswer.Image = _currentTheme.imgButton

        comboStyle.SelectedItem = _currentTheme.introStyle
        comboAlignment.SelectedItem = _currentTheme.questionAlignment

        If _currentTheme.backgroundIntroEnabled Then
            pnlExampleIntro.BackgroundImage = _currentTheme.imgBackgroundIntro
        Else
            pnlExampleIntro.BackgroundImage = Nothing
        End If
        pnlExampleIntro.BackColor = _currentTheme.backgroundColorIntro

        If _currentTheme.logoIntroEnabled Then
            picLogoIntro.Image = _currentTheme.imgLogoIntro
        Else
            picLogoIntro.Image = Nothing
        End If


        If _currentTheme.introStyle = Theme.Style.Old Then
            pnlNew.Visible = False
            pnlOld.Visible = True
            pnlUS.Visible = False
        ElseIf _currentTheme.introStyle = Theme.Style.US Then
            pnlNew.Visible = False
            pnlOld.Visible = False
            pnlUS.Visible = True
        Else
            pnlNew.Visible = True
            pnlOld.Visible = False
            pnlUS.Visible = False
        End If

        pnlNew.Top = (pnlExampleIntro.Height / 2) - (pnlNew.Height / 2)
        pnlNew.Left = (pnlExampleIntro.Width / 2) - (pnlNew.Width / 2)
        pnlOld.Top = (pnlExampleIntro.Height / 2) - (pnlOld.Height / 2)
        pnlOld.Left = (pnlExampleIntro.Width / 2) - (pnlOld.Width / 2)
        pnlUS.Top = (pnlExampleIntro.Height / 2) - (pnlUS.Height / 2)
        pnlUS.Left = (pnlExampleIntro.Width / 2) - (pnlUS.Width / 2)

        lUSname.Font = _currentTheme.fontIntroText
        lUStext.Font = _currentTheme.fontIntroTextfield

        lNewname.Font = _currentTheme.fontIntroText
        lNewname.ForeColor = _currentTheme.colorIntroText
        lNewtext.Font = _currentTheme.fontIntroTextfield
        lNewtext.ForeColor = _currentTheme.colorIntroTextfield

        lOldname.Font = _currentTheme.fontIntroText
        lOldname.ForeColor = _currentTheme.colorIntroText
        lOldtext.Font = _currentTheme.fontIntroTextfield
        lOldtext.ForeColor = _currentTheme.colorIntroTextfield
        lOldbutton.Font = _currentTheme.fontIntroText
        lOldbutton.ForeColor = _currentTheme.colorIntroText

        tabExample.TabPages("green").BackgroundImage = _currentTheme.imgGreenScreen
        tabExample.TabPages("red").BackgroundImage = _currentTheme.imgRedScreen

        Try
            IsFontInstalled(_currentTheme.fontQuestion.Name)
            IsFontInstalled(_currentTheme.fontAnswers.Name)
            IsFontInstalled(_currentTheme.fontIntroText.Name)
            IsFontInstalled(_currentTheme.fontIntroTextfield.Name)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnFontQuestion_Click(sender As Object, e As EventArgs) Handles btnFontQuestion.Click
        FontDialogQuestion.Font = _currentTheme.fontQuestion
        FontDialogQuestion.Color = _currentTheme.colorQuestion
        Try
            If FontDialogQuestion.ShowDialog() = DialogResult.OK Then
                _currentTheme.fontQuestion = FontDialogQuestion.Font
                _currentTheme.colorQuestion = FontDialogQuestion.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub FrmTheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboStyle.DataSource = [Enum].GetValues(GetType(Theme.Style))
        comboAlignment.DataSource = [Enum].GetValues(GetType(ContentAlignment))
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
        Open(CurDir() & "\Thema's\" & CurrentThemeName)
    End Sub

    Private Sub btnLogoQuestion_Click(sender As Object, e As EventArgs) Handles btnLogoQuestion.Click
        Try
            With OpenLogoQuestion
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.logoTest = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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
                        _currentTheme.backgroundTest = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColor_Click(sender As Object, e As EventArgs) Handles btnBackgroundColor.Click
        ColorBackground.Color = _currentTheme.backgroundColorTest
        Try
            If ColorBackground.ShowDialog() = DialogResult.OK Then
                _currentTheme.backgroundColorTest = ColorBackground.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnFontAnswers_Click(sender As Object, e As EventArgs) Handles btnFontAnswers.Click
        FontDialogAnswers.Font = _currentTheme.fontAnswers
        FontDialogAnswers.Color = _currentTheme.colorAnswers
        Try
            If FontDialogAnswers.ShowDialog() = DialogResult.OK Then
                _currentTheme.fontAnswers = FontDialogAnswers.Font
                _currentTheme.colorAnswers = FontDialogAnswers.Color
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
                        _currentTheme.button = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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
                        _currentTheme.buttonClick = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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
                        _currentTheme.buttonHover = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnFontIntroText_Click(sender As Object, e As EventArgs) Handles btnFontIntroText.Click
        FontIntroText.Font = _currentTheme.fontIntroText
        FontIntroText.Color = _currentTheme.colorIntroText
        Try
            If FontIntroText.ShowDialog() = DialogResult.OK Then
                _currentTheme.fontIntroText = FontIntroText.Font
                _currentTheme.colorIntroText = FontIntroText.Color
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
                        _currentTheme.logoIntro = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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
                        _currentTheme.backgroundIntro = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColorIntro_Click(sender As Object, e As EventArgs) Handles btnBackgroundColorIntro.Click
        ColorBackgroundIntro.Color = _currentTheme.backgroundColorIntro
        Try
            If ColorBackgroundIntro.ShowDialog() = DialogResult.OK Then
                _currentTheme.backgroundColorIntro = ColorBackgroundIntro.Color
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
                        _currentTheme.greenScreen = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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
                        _currentTheme.redScreen = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
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

    End Sub

    Private Sub picAnswer_Click(sender As Object, e As EventArgs) Handles picAnswer.Click
        picAnswer.Image = _currentTheme.imgButtonClick
        If _currentTheme.colorClickEnabled Then
            lAnswer.ForeColor = _currentTheme.colorClick
        End If
        timerButton.Start()
    End Sub

    Private Sub picAnswer_MouseEnter(sender As Object, e As EventArgs) Handles picAnswer.MouseEnter
        If _currentTheme.buttonHoverEnabled Then
            picAnswer.Image = _currentTheme.imgButtonHover
        End If
    End Sub

    Private Sub picAnswer_MouseLeave(sender As Object, e As EventArgs) Handles picAnswer.MouseLeave
        If _currentTheme.buttonHoverEnabled Then
            picAnswer.Image = _currentTheme.imgButton
        End If
    End Sub

    Private Sub timerButton_Tick(sender As Object, e As EventArgs) Handles timerButton.Tick
        picAnswer.Image = _currentTheme.imgButton
        If _currentTheme.colorClickEnabled Then
            lAnswer.ForeColor = _currentTheme.colorAnswers
        End If
        timerButton.Stop()
    End Sub
    Private Sub Save(ByVal messageBox As Boolean)
        Try
            Dim objStreamWriter As New IO.StreamWriter(CurDir() & "\Thema's\" & txtName.Text & ".widmthema")
            objStreamWriter.Write(JsonConvert.SerializeObject(_currentTheme, Formatting.Indented))
            objStreamWriter.Close()
            _saved = True
            If messageBox Then MsgBox(getLang("SavedSuccess"), MsgBoxStyle.Information)
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
        _currentTheme.name = txtName.Text
        Me.Text = txtName.Text & ".widmthema - WIDM Exam"
    End Sub

    Private Sub txtAuthor_TextChanged(sender As Object, e As EventArgs) Handles txtAuthor.TextChanged
        _currentTheme.author = txtAuthor.Text
    End Sub

    Private Sub rHover_CheckedChanged(sender As Object, e As EventArgs) Handles rHover.CheckedChanged
        btnButtonHover.Enabled = rHover.Checked
        _currentTheme.buttonHoverEnabled = rHover.Checked
    End Sub

    Private Sub comboStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboStyle.SelectedIndexChanged
        _currentTheme.introStyle = CType(comboStyle.SelectedValue, Theme.Style)
    End Sub

    Private Sub rBackgroundTest_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundTest.CheckedChanged
        btnBackgroundImage.Enabled = rBackgroundTest.Checked
        _currentTheme.backgroundTestEnabled = rBackgroundTest.Checked
    End Sub

    Private Sub rBackgroundIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundIntro.CheckedChanged
        btnBackgroundImageIntro.Enabled = rBackgroundIntro.Checked
        _currentTheme.backgroundIntroEnabled = rBackgroundIntro.Checked
    End Sub

    Private Sub btnIntroTextfield_Click(sender As Object, e As EventArgs) Handles btnIntroTextfield.Click
        FontIntroTextfield.Font = _currentTheme.fontIntroTextfield
        FontIntroTextfield.Color = _currentTheme.colorIntroTextfield
        Try
            If FontIntroTextfield.ShowDialog() = DialogResult.OK Then
                _currentTheme.fontIntroTextfield = FontIntroTextfield.Font
                _currentTheme.colorIntroTextfield = FontIntroTextfield.Color
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
        _currentTheme.logoTestEnabled = rLogoQuestion.Checked
    End Sub

    Private Sub rLogoIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rLogoIntro.CheckedChanged
        btnLogoIntro.Enabled = rLogoIntro.Checked
        _currentTheme.logoIntroEnabled = rLogoIntro.Checked
    End Sub

    Private Sub rMusicTest_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicTest.CheckedChanged
        txtMusicTest.Enabled = rMusicTest.Checked
        _currentTheme.musicTestEnabled = rMusicTest.Checked
    End Sub

    Private Sub rMusicExecution_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicExecution.CheckedChanged
        txtMusicExecution.Enabled = rMusicExecution.Checked
        _currentTheme.musicExecutionEnabled = rMusicExecution.Checked
    End Sub

    Private Sub txtMusicTest_TextChanged(sender As Object, e As EventArgs) Handles txtMusicTest.TextChanged
        _currentTheme.musicTest = txtMusicTest.Text
    End Sub

    Private Sub txtMusicExecution_TextChanged(sender As Object, e As EventArgs) Handles txtMusicExecution.TextChanged
        _currentTheme.musicExecution = txtMusicExecution.Text
    End Sub

    Private Sub btnColorClick_Click(sender As Object, e As EventArgs) Handles btnColorClick.Click
        ColorClick.Color = _currentTheme.colorClick
        Try
            If ColorClick.ShowDialog() = DialogResult.OK Then
                _currentTheme.colorClick = ColorClick.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub rColorClick_CheckedChanged(sender As Object, e As EventArgs) Handles rColorClick.CheckedChanged
        btnColorClick.Enabled = rColorClick.Checked
        _currentTheme.colorClickEnabled = rColorClick.Checked
    End Sub

    Private Sub rQuestionBackground_CheckedChanged(sender As Object, e As EventArgs) Handles rQuestionBackground.CheckedChanged
        btnQuestionBackground.Enabled = rQuestionBackground.Checked
        _currentTheme.questionBackgroundEnabled = rQuestionBackground.Checked
    End Sub

    Private Sub btnQuestionBackground_Click(sender As Object, e As EventArgs) Handles btnQuestionBackground.Click
        Try
            With OpenQuestionBackground
                .InitialDirectory = CurDir() & "\" & Afbeeldingen & "\"
                If .ShowDialog() = DialogResult.OK Then
                    If Path.GetDirectoryName(.FileName).StartsWith(CurDir() & "\" & Afbeeldingen) Then
                        _currentTheme.questionBackground = .FileName.Replace(Path.GetDirectoryName(CurDir() & "\" & Afbeeldingen & "\"), "")
                    Else
                        MsgBox(getLang("WrongFolderAfbeelding"), MsgBoxStyle.Exclamation)
                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        ReloadExamples()
    End Sub

    Private Sub comboAlignment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAlignment.SelectedIndexChanged
        _currentTheme.questionAlignment = CType(comboAlignment.SelectedValue, ContentAlignment)
    End Sub

    Private Sub btnMusicTest_Click(sender As Object, e As EventArgs) Handles btnMusicTest.Click
        OpenMusicTest.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicTest.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicTest.FileName) = CurDir() & "\Geluid" Then
                txtMusicTest.Text = OpenMusicTest.SafeFileName
            Else
                MsgBox(getLang("WrongFolderGeluid"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnMusicExecution_Click(sender As Object, e As EventArgs) Handles btnMusicExecution.Click
        OpenMusicExecution.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicExecution.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicExecution.FileName) = CurDir() & "\Geluid" Then
                txtMusicExecution.Text = OpenMusicExecution.SafeFileName
            Else
                MsgBox(getLang("WrongFolderGeluid"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub FrmTheme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _saved = False Then
            Dim result = MsgBox(getLang("SaveChanges"), vbYesNoCancel Or MsgBoxStyle.Question)
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
                zip.AddFile(CurDir() & "\Thema's\" & _currentTheme.name & ".widmthema", "\Thema's")

                'zip.AddDirectoryByName("Afbeeldingen")
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.logoTest, "\", "/")) Then
                    If _currentTheme.logoTestEnabled Then zip.AddFile(rootDir & _currentTheme.logoTest, afbeeldingen & Path.GetDirectoryName(_currentTheme.logoTest))
                End If
                'MsgBox(zip.EntryFileNames(1).ToString())
                'MsgBox(Replace(afbeeldingen & CurrentTheme.logoIntro, "\", "/"))
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.logoIntro, "\", "/")) Then
                    If _currentTheme.logoIntroEnabled Then zip.AddFile(rootDir & _currentTheme.logoIntro, afbeeldingen & Path.GetDirectoryName(_currentTheme.logoIntro))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.backgroundTest, "\", "/")) Then
                    If _currentTheme.backgroundTestEnabled Then zip.AddFile(rootDir & _currentTheme.backgroundTest, afbeeldingen & Path.GetDirectoryName(_currentTheme.backgroundTest))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.backgroundIntro, "\", "/")) Then
                    If _currentTheme.backgroundIntroEnabled Then zip.AddFile(rootDir & _currentTheme.backgroundIntro, afbeeldingen & Path.GetDirectoryName(_currentTheme.backgroundIntro))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.questionBackground, "\", "/")) Then
                    If _currentTheme.questionBackgroundEnabled Then zip.AddFile(rootDir & _currentTheme.questionBackground, afbeeldingen & Path.GetDirectoryName(_currentTheme.questionBackground))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.button, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.button, afbeeldingen & Path.GetDirectoryName(_currentTheme.button))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.buttonClick, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.buttonClick, afbeeldingen & Path.GetDirectoryName(_currentTheme.buttonClick))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.buttonHover, "\", "/")) Then
                    If _currentTheme.buttonHoverEnabled Then zip.AddFile(rootDir & _currentTheme.buttonHover, afbeeldingen & Path.GetDirectoryName(_currentTheme.buttonHover))
                End If

                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.greenScreen, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.greenScreen, afbeeldingen & Path.GetDirectoryName(_currentTheme.greenScreen))
                End If
                If Not zip.ContainsEntry(Replace(afbeeldingen & _currentTheme.redScreen, "\", "/")) Then
                    zip.AddFile(rootDir & _currentTheme.redScreen, afbeeldingen & Path.GetDirectoryName(_currentTheme.redScreen))
                End If

                'zip.AddDirectoryByName("Geluid")
                If Not zip.ContainsEntry(Replace(geluid & _currentTheme.musicTest, "\", "/")) Then
                    If _currentTheme.musicTestEnabled Then zip.AddFile(rootDirGeluid & _currentTheme.musicTest, geluid)
                End If
                If Not zip.ContainsEntry(Replace(geluid & _currentTheme.musicExecution, "\", "/")) Then
                    If _currentTheme.musicExecutionEnabled Then zip.AddFile(rootDirGeluid & _currentTheme.musicExecution, geluid)
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
        SaveExport.FileName = _currentTheme.name 
        If SaveExport.ShowDialog() = DialogResult.OK Then
            Export(SaveExport.FileName)
        End If
    End Sub
End Class