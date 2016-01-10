Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports Newtonsoft.Json

Public Class FrmTheme
    Dim theme As New Theme

    Sub ReloadExamples()
        txtName.Text = theme.name
        txtAuthor.Text = theme.author

        txtMusicTest.Text = theme.musicTest
        txtMusicExecution.Text = theme.musicExecution

        rBackgroundTest.Checked = theme.backgroundTestEnabled
        rBackgroundIntro.Checked = theme.backgroundIntroEnabled
        rHover.Checked = theme.buttonHoverEnabled
        rLogoQuestion.Checked = theme.logoTestEnabled
        rLogoIntro.Checked = theme.logoIntroEnabled
        rMusicTest.Checked = theme.musicTestEnabled
        rMusicExecution.Checked = theme.musicExecutionEnabled
        rColorClick.Checked = theme.colorClickEnabled
        rQuestionBackground.Checked = theme.questionBackgroundEnabled

        If theme.logoTestEnabled Then
            picLogo.Image = theme.logoTest
        Else
            picLogo.Image = Nothing
        End If
        lQuestion.Font = theme.fontQuestion
        lQuestion.ForeColor = theme.colorQuestion
        Try
            lQuestion.TextAlign = theme.questionAlignment
        Catch ex As Exception

        End Try
        If theme.questionBackgroundEnabled Then
            lQuestion.BackgroundImage = theme.questionBackground
            lQuestion.BackgroundImageLayout = ImageLayout.Stretch
        Else
            lQuestion.BackgroundImage = Nothing
        End If
        pnlExampleTest.BackColor = theme.backgroundColorTest
        If theme.backgroundTestEnabled Then
            pnlExampleTest.BackgroundImage = theme.backgroundTest
        Else
            pnlExampleTest.BackgroundImage = Nothing
        End If
        lAnswer.Font = theme.fontAnswers
        lAnswer.ForeColor = theme.colorAnswers
        picAnswer.Image = theme.button

        comboStyle.SelectedItem = theme.introStyle

        If theme.backgroundIntroEnabled Then
            pnlExampleIntro.BackgroundImage = theme.backgroundIntro
        Else
            pnlExampleIntro.BackgroundImage = Nothing
        End If
        pnlExampleIntro.BackColor = theme.backgroundColorIntro

        If theme.logoIntroEnabled Then
            picLogoIntro.Image = theme.logoIntro
        Else
            picLogoIntro.Image = Nothing
        End If


        If theme.introStyle = Theme.Style.Old Then
            pnlNew.Visible = False
            pnlOld.Visible = True
            pnlUS.Visible = False
        ElseIf theme.introStyle = Theme.Style.US Then
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

        lUSname.Font = theme.fontIntroText
        lUStext.Font = theme.fontIntroTextfield

        lNewname.Font = theme.fontIntroText
        lNewname.ForeColor = theme.colorIntroText
        lNewtext.Font = theme.fontIntroTextfield
        lNewtext.ForeColor = theme.colorIntroTextfield

        lOldname.Font = theme.fontIntroText
        lOldname.ForeColor = theme.colorIntroText
        lOldtext.Font = theme.fontIntroTextfield
        lOldtext.ForeColor = theme.colorIntroTextfield
        lOldbutton.Font = theme.fontIntroText
        lOldbutton.ForeColor = theme.colorIntroText

        tabExample.TabPages("green").BackgroundImage = theme.greenScreen
        tabExample.TabPages("red").BackgroundImage = theme.redScreen
    End Sub

    Private Sub btnFontQuestion_Click(sender As Object, e As EventArgs) Handles btnFontQuestion.Click
        FontDialogQuestion.Font = theme.fontQuestion
        FontDialogQuestion.Color = theme.colorQuestion
        Try
            If FontDialogQuestion.ShowDialog() = DialogResult.OK Then
                theme.fontQuestion = FontDialogQuestion.Font
                theme.colorQuestion = FontDialogQuestion.Color
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

    Private Sub btnLogoQuestion_Click(sender As Object, e As EventArgs) Handles btnLogoQuestion.Click
        Try
            If OpenLogoQuestion.ShowDialog() = DialogResult.OK Then
                theme.logoTest = Image.FromFile(OpenLogoQuestion.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnBackgroundImage_Click(sender As Object, e As EventArgs) Handles btnBackgroundImage.Click
        Try
            If OpenBackground.ShowDialog() = DialogResult.OK Then
                theme.backgroundTest = Image.FromFile(OpenBackground.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColor_Click(sender As Object, e As EventArgs) Handles btnBackgroundColor.Click
        ColorBackground.Color = theme.backgroundColorTest
        Try
            If ColorBackground.ShowDialog() = DialogResult.OK Then
                theme.backgroundColorTest = ColorBackground.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnFontAnswers_Click(sender As Object, e As EventArgs) Handles btnFontAnswers.Click
        FontDialogAnswers.Font = theme.fontAnswers
        FontDialogAnswers.Color = theme.colorAnswers
        Try
            If FontDialogAnswers.ShowDialog() = DialogResult.OK Then
                theme.fontAnswers = FontDialogAnswers.Font
                theme.colorAnswers = FontDialogAnswers.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnButtonNormal_Click(sender As Object, e As EventArgs) Handles btnButtonNormal.Click
        Try
            If OpenNormal.ShowDialog() = DialogResult.OK Then
                theme.button = Image.FromFile(OpenNormal.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnButtonClick_Click(sender As Object, e As EventArgs) Handles btnButtonClick.Click
        Try
            If OpenClick.ShowDialog() = DialogResult.OK Then
                theme.buttonClick = Image.FromFile(OpenClick.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnButtonHover_Click(sender As Object, e As EventArgs) Handles btnButtonHover.Click
        Try
            If OpenHover.ShowDialog() = DialogResult.OK Then
                theme.buttonHover = Image.FromFile(OpenHover.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnFontIntroText_Click(sender As Object, e As EventArgs) Handles btnFontIntroText.Click
        FontIntroText.Font = theme.fontIntroText
        FontIntroText.Color = theme.colorIntroText
        Try
            If FontIntroText.ShowDialog() = DialogResult.OK Then
                theme.fontIntroText = FontIntroText.Font
                theme.colorIntroText = FontIntroText.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnLogoIntro_Click(sender As Object, e As EventArgs) Handles btnLogoIntro.Click
        Try
            If OpenLogoIntro.ShowDialog() = DialogResult.OK Then
                theme.logoIntro = Image.FromFile(OpenLogoIntro.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnBackgroundImageIntro_Click(sender As Object, e As EventArgs) Handles btnBackgroundImageIntro.Click
        Try
            If OpenBackgroundIntro.ShowDialog() = DialogResult.OK Then
                theme.backgroundIntro = Image.FromFile(OpenBackgroundIntro.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnBackgroundColorIntro_Click(sender As Object, e As EventArgs) Handles btnBackgroundColorIntro.Click
        ColorBackgroundIntro.Color = theme.backgroundColorIntro
        Try
            If ColorBackgroundIntro.ShowDialog() = DialogResult.OK Then
                theme.backgroundColorIntro = ColorBackgroundIntro.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnGreen_Click(sender As Object, e As EventArgs) Handles btnGreen.Click
        Try
            If OpenGreen.ShowDialog() = DialogResult.OK Then
                theme.greenScreen = Image.FromFile(OpenGreen.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnRed_Click(sender As Object, e As EventArgs) Handles btnRed.Click
        Try
            If OpenRed.ShowDialog() = DialogResult.OK Then
                theme.redScreen = Image.FromFile(OpenRed.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        ReloadExamples()

    End Sub

    Private Sub picAnswer_Click(sender As Object, e As EventArgs) Handles picAnswer.Click
        picAnswer.Image = theme.buttonClick
        If theme.colorClickEnabled Then
            lAnswer.ForeColor = theme.colorClick
        End If
        timerButton.Start()
    End Sub

    Private Sub picAnswer_MouseEnter(sender As Object, e As EventArgs) Handles picAnswer.MouseEnter
        If theme.buttonHoverEnabled Then
            picAnswer.Image = theme.buttonHover
        End If
    End Sub

    Private Sub picAnswer_MouseLeave(sender As Object, e As EventArgs) Handles picAnswer.MouseLeave
        If theme.buttonHoverEnabled Then
            picAnswer.Image = theme.button
        End If
    End Sub

    Private Sub timerButton_Tick(sender As Object, e As EventArgs) Handles timerButton.Tick
        picAnswer.Image = theme.button
        If theme.colorClickEnabled Then
            lAnswer.ForeColor = theme.colorAnswers
        End If
        timerButton.Stop()
    End Sub

    Private Sub ToolStripSave_Click(sender As Object, e As EventArgs) Handles ToolStripSave.Click
        Dim objFileStream As New FileStream(CurDir() & "\Thema's\" & txtName.Text & ".widmthema", FileMode.Create)
        Dim formatter As New BinaryFormatter
        Try
            formatter.Serialize(objFileStream, theme)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Throw
        Finally
            objFileStream.Close()
        End Try
    End Sub

    Private Sub ToolStripOpen_Click(sender As Object, e As EventArgs) Handles ToolStripOpen.Click
        OpenTheme.InitialDirectory = CurDir() & "\Thema's"
        If OpenTheme.ShowDialog() = DialogResult.OK Then
            Dim fs As New FileStream(OpenTheme.FileName, FileMode.Open)
            Try
                Dim formatter As New BinaryFormatter

                ' Deserialize the hashtable from the file and 
                ' assign the reference to the local variable.
                theme = DirectCast(formatter.Deserialize(fs), Theme)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Throw
            Finally
                fs.Close()
                ReloadExamples()
            End Try

        End If

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        theme.name = txtName.Text
    End Sub

    Private Sub txtAuthor_TextChanged(sender As Object, e As EventArgs) Handles txtAuthor.TextChanged
        theme.author = txtAuthor.Text
    End Sub

    Private Sub rHover_CheckedChanged(sender As Object, e As EventArgs) Handles rHover.CheckedChanged
        btnButtonHover.Enabled = rHover.Checked
        theme.buttonHoverEnabled = rHover.Checked
    End Sub

    Private Sub comboStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboStyle.SelectedIndexChanged
        theme.introStyle = CType(comboStyle.SelectedValue, Theme.Style)
    End Sub

    Private Sub rBackgroundTest_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundTest.CheckedChanged
        btnBackgroundImage.Enabled = rBackgroundTest.Checked
        theme.backgroundTestEnabled = rBackgroundTest.Checked
    End Sub

    Private Sub rBackgroundIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rBackgroundIntro.CheckedChanged
        btnBackgroundImageIntro.Enabled = rBackgroundIntro.Checked
        theme.backgroundIntroEnabled = rBackgroundIntro.Checked
    End Sub

    Private Sub btnIntroTextfield_Click(sender As Object, e As EventArgs) Handles btnIntroTextfield.Click
        FontIntroTextfield.Font = theme.fontIntroTextfield
        FontIntroTextfield.Color = theme.colorIntroTextfield
        Try
            If FontIntroTextfield.ShowDialog() = DialogResult.OK Then
                theme.fontIntroTextfield = FontIntroTextfield.Font
                theme.colorIntroTextfield = FontIntroTextfield.Color
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
        theme.logoTestEnabled = rLogoQuestion.Checked
    End Sub

    Private Sub rLogoIntro_CheckedChanged(sender As Object, e As EventArgs) Handles rLogoIntro.CheckedChanged
        btnLogoIntro.Enabled = rLogoIntro.Checked
        theme.logoIntroEnabled = rLogoIntro.Checked
    End Sub

    Private Sub rMusicTest_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicTest.CheckedChanged
        txtMusicTest.Enabled = rMusicTest.Checked
        theme.musicTestEnabled = rMusicTest.Checked
    End Sub

    Private Sub rMusicExecution_CheckedChanged(sender As Object, e As EventArgs) Handles rMusicExecution.CheckedChanged
        txtMusicExecution.Enabled = rMusicExecution.Checked
        theme.musicExecutionEnabled = rMusicExecution.Checked
    End Sub

    Private Sub txtMusicTest_TextChanged(sender As Object, e As EventArgs) Handles txtMusicTest.TextChanged
        theme.musicTest = txtMusicTest.Text
    End Sub

    Private Sub txtMusicExecution_TextChanged(sender As Object, e As EventArgs) Handles txtMusicExecution.TextChanged
        theme.musicExecution = txtMusicExecution.Text
    End Sub

    Private Sub btnColorClick_Click(sender As Object, e As EventArgs) Handles btnColorClick.Click
        ColorClick.Color = theme.colorClick
        Try
            If ColorClick.ShowDialog() = DialogResult.OK Then
                theme.colorClick = ColorClick.Color
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub rColorClick_CheckedChanged(sender As Object, e As EventArgs) Handles rColorClick.CheckedChanged
        btnColorClick.Enabled = rColorClick.Checked
        theme.colorClickEnabled = rColorClick.Checked
    End Sub

    Private Sub rQuestionBackground_CheckedChanged(sender As Object, e As EventArgs) Handles rQuestionBackground.CheckedChanged
        btnQuestionBackground.Enabled = rQuestionBackground.Checked
        theme.questionBackgroundEnabled = rQuestionBackground.Checked
    End Sub

    Private Sub btnQuestionBackground_Click(sender As Object, e As EventArgs) Handles btnQuestionBackground.Click
        Try
            If OpenQuestionBackground.ShowDialog() = DialogResult.OK Then
                theme.questionBackground = Image.FromFile(OpenQuestionBackground.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        ReloadExamples()
    End Sub

    Private Sub comboAlignment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAlignment.SelectedIndexChanged
        theme.questionAlignment = CType(comboAlignment.SelectedValue, ContentAlignment)
    End Sub

    Private Sub btnMusicTest_Click(sender As Object, e As EventArgs) Handles btnMusicTest.Click
        OpenMusicTest.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicTest.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicTest.FileName) = CurDir() & "\Geluid" Then
                txtMusicTest.Text = OpenMusicTest.SafeFileName
            Else
                MsgBox(getLang("WrongFolder"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnMusicExecution_Click(sender As Object, e As EventArgs) Handles btnMusicExecution.Click
        OpenMusicExecution.InitialDirectory = CurDir() & "\Geluid\"
        If OpenMusicExecution.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(OpenMusicExecution.FileName) = CurDir() & "\Geluid" Then
                txtMusicExecution.Text = OpenMusicExecution.SafeFileName
            Else
                MsgBox(getLang("WrongFolder"), MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
End Class