<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTheme
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTheme))
        Me.grpGeneral = New System.Windows.Forms.GroupBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lName = New System.Windows.Forms.Label()
        Me.grpQuestion = New System.Windows.Forms.GroupBox()
        Me.rQuestionBackground = New System.Windows.Forms.CheckBox()
        Me.btnQuestionBackground = New System.Windows.Forms.Button()
        Me.lQuestionBackground = New System.Windows.Forms.Label()
        Me.comboAlignment = New System.Windows.Forms.ComboBox()
        Me.lAlignment = New System.Windows.Forms.Label()
        Me.rColorClick = New System.Windows.Forms.CheckBox()
        Me.btnColorClick = New System.Windows.Forms.Button()
        Me.lColorClick = New System.Windows.Forms.Label()
        Me.rLogoQuestion = New System.Windows.Forms.CheckBox()
        Me.rBackgroundTest = New System.Windows.Forms.CheckBox()
        Me.rHover = New System.Windows.Forms.CheckBox()
        Me.btnButtonNormal = New System.Windows.Forms.Button()
        Me.btnButtonHover = New System.Windows.Forms.Button()
        Me.btnButtonClick = New System.Windows.Forms.Button()
        Me.lButtonAnswers = New System.Windows.Forms.Label()
        Me.btnBackgroundImage = New System.Windows.Forms.Button()
        Me.btnFontAnswers = New System.Windows.Forms.Button()
        Me.lFontAnswers = New System.Windows.Forms.Label()
        Me.btnBackgroundColor = New System.Windows.Forms.Button()
        Me.lBackgroundColor = New System.Windows.Forms.Label()
        Me.btnLogoQuestion = New System.Windows.Forms.Button()
        Me.lLogo = New System.Windows.Forms.Label()
        Me.btnFontQuestion = New System.Windows.Forms.Button()
        Me.lFont = New System.Windows.Forms.Label()
        Me.grpExample = New System.Windows.Forms.GroupBox()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.tabExample = New System.Windows.Forms.TabControl()
        Me.tabTest = New System.Windows.Forms.TabPage()
        Me.pnlExampleTest = New System.Windows.Forms.Panel()
        Me.lAnswer = New System.Windows.Forms.Label()
        Me.picAnswer = New System.Windows.Forms.PictureBox()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lQuestion = New System.Windows.Forms.Label()
        Me.tabIntro = New System.Windows.Forms.TabPage()
        Me.pnlExampleIntro = New System.Windows.Forms.Panel()
        Me.pnlOld = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lOldname = New System.Windows.Forms.Label()
        Me.lOldtext = New System.Windows.Forms.TextBox()
        Me.lOldbutton = New System.Windows.Forms.Button()
        Me.pnlUS = New System.Windows.Forms.Panel()
        Me.lUStext = New System.Windows.Forms.TextBox()
        Me.lUSname = New System.Windows.Forms.Label()
        Me.pnlNew = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lNewtext = New System.Windows.Forms.TextBox()
        Me.lNewname = New System.Windows.Forms.Label()
        Me.picLogoIntro = New System.Windows.Forms.PictureBox()
        Me.green = New System.Windows.Forms.TabPage()
        Me.red = New System.Windows.Forms.TabPage()
        Me.grpIntro = New System.Windows.Forms.GroupBox()
        Me.rLogoIntro = New System.Windows.Forms.CheckBox()
        Me.btnIntroTextfield = New System.Windows.Forms.Button()
        Me.lIntroTextfield = New System.Windows.Forms.Label()
        Me.rBackgroundIntro = New System.Windows.Forms.CheckBox()
        Me.btnFontIntroText = New System.Windows.Forms.Button()
        Me.comboStyle = New System.Windows.Forms.ComboBox()
        Me.lFontIntroText = New System.Windows.Forms.Label()
        Me.lStyle = New System.Windows.Forms.Label()
        Me.btnBackgroundImageIntro = New System.Windows.Forms.Button()
        Me.lLogoIntro = New System.Windows.Forms.Label()
        Me.btnBackgroundColorIntro = New System.Windows.Forms.Button()
        Me.btnLogoIntro = New System.Windows.Forms.Button()
        Me.btnBackgroundIntro = New System.Windows.Forms.Label()
        Me.grpScreens = New System.Windows.Forms.GroupBox()
        Me.btnRed = New System.Windows.Forms.Button()
        Me.lScreens = New System.Windows.Forms.Label()
        Me.btnGreen = New System.Windows.Forms.Button()
        Me.FontDialogQuestion = New System.Windows.Forms.FontDialog()
        Me.FontDialogAnswers = New System.Windows.Forms.FontDialog()
        Me.OpenLogoQuestion = New System.Windows.Forms.OpenFileDialog()
        Me.OpenBackground = New System.Windows.Forms.OpenFileDialog()
        Me.OpenNormal = New System.Windows.Forms.OpenFileDialog()
        Me.OpenClick = New System.Windows.Forms.OpenFileDialog()
        Me.OpenHover = New System.Windows.Forms.OpenFileDialog()
        Me.OpenLogoIntro = New System.Windows.Forms.OpenFileDialog()
        Me.OpenBackgroundIntro = New System.Windows.Forms.OpenFileDialog()
        Me.OpenGreen = New System.Windows.Forms.OpenFileDialog()
        Me.OpenRed = New System.Windows.Forms.OpenFileDialog()
        Me.ColorBackground = New System.Windows.Forms.ColorDialog()
        Me.ColorBackgroundIntro = New System.Windows.Forms.ColorDialog()
        Me.timerButton = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripExport = New System.Windows.Forms.ToolStripButton()
        Me.OpenTheme = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.rMusicTest = New System.Windows.Forms.CheckBox()
        Me.rMusicExecution = New System.Windows.Forms.CheckBox()
        Me.grpMusic = New System.Windows.Forms.GroupBox()
        Me.btnMusicExecution = New System.Windows.Forms.Button()
        Me.btnMusicTest = New System.Windows.Forms.Button()
        Me.txtMusicExecution = New System.Windows.Forms.TextBox()
        Me.txtMusicTest = New System.Windows.Forms.TextBox()
        Me.lMusicExecution = New System.Windows.Forms.Label()
        Me.lMusicTest = New System.Windows.Forms.Label()
        Me.FontIntroText = New System.Windows.Forms.FontDialog()
        Me.FontIntroTextfield = New System.Windows.Forms.FontDialog()
        Me.ColorClick = New System.Windows.Forms.ColorDialog()
        Me.OpenQuestionBackground = New System.Windows.Forms.OpenFileDialog()
        Me.OpenMusicTest = New System.Windows.Forms.OpenFileDialog()
        Me.OpenMusicExecution = New System.Windows.Forms.OpenFileDialog()
        Me.SaveExport = New System.Windows.Forms.SaveFileDialog()
        Me.grpGeneral.SuspendLayout
        Me.grpQuestion.SuspendLayout
        Me.grpExample.SuspendLayout
        Me.tabExample.SuspendLayout
        Me.tabTest.SuspendLayout
        Me.pnlExampleTest.SuspendLayout
        CType(Me.picAnswer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.picLogo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabIntro.SuspendLayout
        Me.pnlExampleIntro.SuspendLayout
        Me.pnlOld.SuspendLayout
        Me.pnlUS.SuspendLayout
        Me.pnlNew.SuspendLayout
        CType(Me.picLogoIntro,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpIntro.SuspendLayout
        Me.grpScreens.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.grpMusic.SuspendLayout
        Me.SuspendLayout
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.txtAuthor)
        Me.grpGeneral.Controls.Add(Me.Label1)
        Me.grpGeneral.Controls.Add(Me.txtName)
        Me.grpGeneral.Controls.Add(Me.lName)
        resources.ApplyResources(Me.grpGeneral, "grpGeneral")
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.TabStop = false
        '
        'txtAuthor
        '
        resources.ApplyResources(Me.txtAuthor, "txtAuthor")
        Me.txtAuthor.Name = "txtAuthor"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lName
        '
        resources.ApplyResources(Me.lName, "lName")
        Me.lName.Name = "lName"
        '
        'grpQuestion
        '
        Me.grpQuestion.Controls.Add(Me.rQuestionBackground)
        Me.grpQuestion.Controls.Add(Me.btnQuestionBackground)
        Me.grpQuestion.Controls.Add(Me.lQuestionBackground)
        Me.grpQuestion.Controls.Add(Me.comboAlignment)
        Me.grpQuestion.Controls.Add(Me.lAlignment)
        Me.grpQuestion.Controls.Add(Me.rColorClick)
        Me.grpQuestion.Controls.Add(Me.btnColorClick)
        Me.grpQuestion.Controls.Add(Me.lColorClick)
        Me.grpQuestion.Controls.Add(Me.rLogoQuestion)
        Me.grpQuestion.Controls.Add(Me.rBackgroundTest)
        Me.grpQuestion.Controls.Add(Me.rHover)
        Me.grpQuestion.Controls.Add(Me.btnButtonNormal)
        Me.grpQuestion.Controls.Add(Me.btnButtonHover)
        Me.grpQuestion.Controls.Add(Me.btnButtonClick)
        Me.grpQuestion.Controls.Add(Me.lButtonAnswers)
        Me.grpQuestion.Controls.Add(Me.btnBackgroundImage)
        Me.grpQuestion.Controls.Add(Me.btnFontAnswers)
        Me.grpQuestion.Controls.Add(Me.lFontAnswers)
        Me.grpQuestion.Controls.Add(Me.btnBackgroundColor)
        Me.grpQuestion.Controls.Add(Me.lBackgroundColor)
        Me.grpQuestion.Controls.Add(Me.btnLogoQuestion)
        Me.grpQuestion.Controls.Add(Me.lLogo)
        Me.grpQuestion.Controls.Add(Me.btnFontQuestion)
        Me.grpQuestion.Controls.Add(Me.lFont)
        resources.ApplyResources(Me.grpQuestion, "grpQuestion")
        Me.grpQuestion.Name = "grpQuestion"
        Me.grpQuestion.TabStop = false
        '
        'rQuestionBackground
        '
        resources.ApplyResources(Me.rQuestionBackground, "rQuestionBackground")
        Me.rQuestionBackground.Name = "rQuestionBackground"
        Me.ToolTip.SetToolTip(Me.rQuestionBackground, resources.GetString("rQuestionBackground.ToolTip"))
        Me.rQuestionBackground.UseVisualStyleBackColor = true
        '
        'btnQuestionBackground
        '
        resources.ApplyResources(Me.btnQuestionBackground, "btnQuestionBackground")
        Me.btnQuestionBackground.Name = "btnQuestionBackground"
        Me.btnQuestionBackground.UseVisualStyleBackColor = true
        '
        'lQuestionBackground
        '
        resources.ApplyResources(Me.lQuestionBackground, "lQuestionBackground")
        Me.lQuestionBackground.Name = "lQuestionBackground"
        '
        'comboAlignment
        '
        Me.comboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAlignment.FormattingEnabled = true
        resources.ApplyResources(Me.comboAlignment, "comboAlignment")
        Me.comboAlignment.Name = "comboAlignment"
        '
        'lAlignment
        '
        resources.ApplyResources(Me.lAlignment, "lAlignment")
        Me.lAlignment.Name = "lAlignment"
        '
        'rColorClick
        '
        resources.ApplyResources(Me.rColorClick, "rColorClick")
        Me.rColorClick.Name = "rColorClick"
        Me.ToolTip.SetToolTip(Me.rColorClick, resources.GetString("rColorClick.ToolTip"))
        Me.rColorClick.UseVisualStyleBackColor = true
        '
        'btnColorClick
        '
        resources.ApplyResources(Me.btnColorClick, "btnColorClick")
        Me.btnColorClick.Name = "btnColorClick"
        Me.btnColorClick.UseVisualStyleBackColor = true
        '
        'lColorClick
        '
        resources.ApplyResources(Me.lColorClick, "lColorClick")
        Me.lColorClick.Name = "lColorClick"
        '
        'rLogoQuestion
        '
        resources.ApplyResources(Me.rLogoQuestion, "rLogoQuestion")
        Me.rLogoQuestion.Name = "rLogoQuestion"
        Me.ToolTip.SetToolTip(Me.rLogoQuestion, resources.GetString("rLogoQuestion.ToolTip"))
        Me.rLogoQuestion.UseVisualStyleBackColor = true
        '
        'rBackgroundTest
        '
        resources.ApplyResources(Me.rBackgroundTest, "rBackgroundTest")
        Me.rBackgroundTest.Name = "rBackgroundTest"
        Me.ToolTip.SetToolTip(Me.rBackgroundTest, resources.GetString("rBackgroundTest.ToolTip"))
        Me.rBackgroundTest.UseVisualStyleBackColor = true
        '
        'rHover
        '
        resources.ApplyResources(Me.rHover, "rHover")
        Me.rHover.Name = "rHover"
        Me.ToolTip.SetToolTip(Me.rHover, resources.GetString("rHover.ToolTip"))
        Me.rHover.UseVisualStyleBackColor = true
        '
        'btnButtonNormal
        '
        resources.ApplyResources(Me.btnButtonNormal, "btnButtonNormal")
        Me.btnButtonNormal.Name = "btnButtonNormal"
        Me.btnButtonNormal.UseVisualStyleBackColor = true
        '
        'btnButtonHover
        '
        resources.ApplyResources(Me.btnButtonHover, "btnButtonHover")
        Me.btnButtonHover.Name = "btnButtonHover"
        Me.btnButtonHover.UseVisualStyleBackColor = true
        '
        'btnButtonClick
        '
        resources.ApplyResources(Me.btnButtonClick, "btnButtonClick")
        Me.btnButtonClick.Name = "btnButtonClick"
        Me.btnButtonClick.UseVisualStyleBackColor = true
        '
        'lButtonAnswers
        '
        resources.ApplyResources(Me.lButtonAnswers, "lButtonAnswers")
        Me.lButtonAnswers.Name = "lButtonAnswers"
        '
        'btnBackgroundImage
        '
        resources.ApplyResources(Me.btnBackgroundImage, "btnBackgroundImage")
        Me.btnBackgroundImage.Name = "btnBackgroundImage"
        Me.btnBackgroundImage.UseVisualStyleBackColor = true
        '
        'btnFontAnswers
        '
        resources.ApplyResources(Me.btnFontAnswers, "btnFontAnswers")
        Me.btnFontAnswers.Name = "btnFontAnswers"
        Me.btnFontAnswers.UseVisualStyleBackColor = true
        '
        'lFontAnswers
        '
        resources.ApplyResources(Me.lFontAnswers, "lFontAnswers")
        Me.lFontAnswers.Name = "lFontAnswers"
        '
        'btnBackgroundColor
        '
        resources.ApplyResources(Me.btnBackgroundColor, "btnBackgroundColor")
        Me.btnBackgroundColor.Name = "btnBackgroundColor"
        Me.btnBackgroundColor.UseVisualStyleBackColor = true
        '
        'lBackgroundColor
        '
        resources.ApplyResources(Me.lBackgroundColor, "lBackgroundColor")
        Me.lBackgroundColor.Name = "lBackgroundColor"
        '
        'btnLogoQuestion
        '
        resources.ApplyResources(Me.btnLogoQuestion, "btnLogoQuestion")
        Me.btnLogoQuestion.Name = "btnLogoQuestion"
        Me.btnLogoQuestion.UseVisualStyleBackColor = true
        '
        'lLogo
        '
        resources.ApplyResources(Me.lLogo, "lLogo")
        Me.lLogo.Name = "lLogo"
        '
        'btnFontQuestion
        '
        resources.ApplyResources(Me.btnFontQuestion, "btnFontQuestion")
        Me.btnFontQuestion.Name = "btnFontQuestion"
        Me.btnFontQuestion.UseVisualStyleBackColor = true
        '
        'lFont
        '
        resources.ApplyResources(Me.lFont, "lFont")
        Me.lFont.Name = "lFont"
        '
        'grpExample
        '
        resources.ApplyResources(Me.grpExample, "grpExample")
        Me.grpExample.BackColor = System.Drawing.SystemColors.Control
        Me.grpExample.Controls.Add(Me.btnReload)
        Me.grpExample.Controls.Add(Me.tabExample)
        Me.grpExample.Name = "grpExample"
        Me.grpExample.TabStop = false
        '
        'btnReload
        '
        resources.ApplyResources(Me.btnReload, "btnReload")
        Me.btnReload.Name = "btnReload"
        Me.btnReload.UseVisualStyleBackColor = true
        '
        'tabExample
        '
        Me.tabExample.Controls.Add(Me.tabTest)
        Me.tabExample.Controls.Add(Me.tabIntro)
        Me.tabExample.Controls.Add(Me.green)
        Me.tabExample.Controls.Add(Me.red)
        resources.ApplyResources(Me.tabExample, "tabExample")
        Me.tabExample.Name = "tabExample"
        Me.tabExample.SelectedIndex = 0
        '
        'tabTest
        '
        Me.tabTest.Controls.Add(Me.pnlExampleTest)
        resources.ApplyResources(Me.tabTest, "tabTest")
        Me.tabTest.Name = "tabTest"
        Me.tabTest.UseVisualStyleBackColor = true
        '
        'pnlExampleTest
        '
        resources.ApplyResources(Me.pnlExampleTest, "pnlExampleTest")
        Me.pnlExampleTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExampleTest.Controls.Add(Me.lAnswer)
        Me.pnlExampleTest.Controls.Add(Me.picAnswer)
        Me.pnlExampleTest.Controls.Add(Me.picLogo)
        Me.pnlExampleTest.Controls.Add(Me.lQuestion)
        Me.pnlExampleTest.Name = "pnlExampleTest"
        '
        'lAnswer
        '
        Me.lAnswer.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lAnswer, "lAnswer")
        Me.lAnswer.Name = "lAnswer"
        '
        'picAnswer
        '
        Me.picAnswer.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picAnswer, "picAnswer")
        Me.picAnswer.Name = "picAnswer"
        Me.picAnswer.TabStop = false
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picLogo, "picLogo")
        Me.picLogo.Name = "picLogo"
        Me.picLogo.TabStop = false
        '
        'lQuestion
        '
        resources.ApplyResources(Me.lQuestion, "lQuestion")
        Me.lQuestion.BackColor = System.Drawing.Color.Transparent
        Me.lQuestion.Name = "lQuestion"
        '
        'tabIntro
        '
        Me.tabIntro.Controls.Add(Me.pnlExampleIntro)
        resources.ApplyResources(Me.tabIntro, "tabIntro")
        Me.tabIntro.Name = "tabIntro"
        Me.tabIntro.UseVisualStyleBackColor = true
        '
        'pnlExampleIntro
        '
        resources.ApplyResources(Me.pnlExampleIntro, "pnlExampleIntro")
        Me.pnlExampleIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExampleIntro.Controls.Add(Me.pnlOld)
        Me.pnlExampleIntro.Controls.Add(Me.pnlUS)
        Me.pnlExampleIntro.Controls.Add(Me.pnlNew)
        Me.pnlExampleIntro.Controls.Add(Me.picLogoIntro)
        Me.pnlExampleIntro.Name = "pnlExampleIntro"
        '
        'pnlOld
        '
        resources.ApplyResources(Me.pnlOld, "pnlOld")
        Me.pnlOld.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOld.Controls.Add(Me.Label4)
        Me.pnlOld.Controls.Add(Me.lOldname)
        Me.pnlOld.Controls.Add(Me.lOldtext)
        Me.pnlOld.Controls.Add(Me.lOldbutton)
        Me.pnlOld.Name = "pnlOld"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'lOldname
        '
        resources.ApplyResources(Me.lOldname, "lOldname")
        Me.lOldname.ForeColor = System.Drawing.Color.Red
        Me.lOldname.Name = "lOldname"
        '
        'lOldtext
        '
        resources.ApplyResources(Me.lOldtext, "lOldtext")
        Me.lOldtext.ForeColor = System.Drawing.Color.Red
        Me.lOldtext.Name = "lOldtext"
        '
        'lOldbutton
        '
        resources.ApplyResources(Me.lOldbutton, "lOldbutton")
        Me.lOldbutton.ForeColor = System.Drawing.Color.Red
        Me.lOldbutton.Name = "lOldbutton"
        Me.lOldbutton.UseVisualStyleBackColor = true
        '
        'pnlUS
        '
        resources.ApplyResources(Me.pnlUS, "pnlUS")
        Me.pnlUS.BackColor = System.Drawing.Color.Transparent
        Me.pnlUS.Controls.Add(Me.lUStext)
        Me.pnlUS.Controls.Add(Me.lUSname)
        Me.pnlUS.Name = "pnlUS"
        '
        'lUStext
        '
        resources.ApplyResources(Me.lUStext, "lUStext")
        Me.lUStext.Name = "lUStext"
        '
        'lUSname
        '
        resources.ApplyResources(Me.lUSname, "lUSname")
        Me.lUSname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lUSname.Name = "lUSname"
        '
        'pnlNew
        '
        resources.ApplyResources(Me.pnlNew, "pnlNew")
        Me.pnlNew.BackColor = System.Drawing.Color.Transparent
        Me.pnlNew.Controls.Add(Me.Label11)
        Me.pnlNew.Controls.Add(Me.lNewtext)
        Me.pnlNew.Controls.Add(Me.lNewname)
        Me.pnlNew.Name = "pnlNew"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Name = "Label11"
        '
        'lNewtext
        '
        Me.lNewtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.lNewtext, "lNewtext")
        Me.lNewtext.Name = "lNewtext"
        '
        'lNewname
        '
        resources.ApplyResources(Me.lNewname, "lNewname")
        Me.lNewname.ForeColor = System.Drawing.Color.White
        Me.lNewname.Name = "lNewname"
        '
        'picLogoIntro
        '
        Me.picLogoIntro.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picLogoIntro, "picLogoIntro")
        Me.picLogoIntro.Name = "picLogoIntro"
        Me.picLogoIntro.TabStop = false
        '
        'green
        '
        resources.ApplyResources(Me.green, "green")
        Me.green.Name = "green"
        Me.green.UseVisualStyleBackColor = true
        '
        'red
        '
        resources.ApplyResources(Me.red, "red")
        Me.red.Name = "red"
        Me.red.UseVisualStyleBackColor = true
        '
        'grpIntro
        '
        Me.grpIntro.Controls.Add(Me.rLogoIntro)
        Me.grpIntro.Controls.Add(Me.btnIntroTextfield)
        Me.grpIntro.Controls.Add(Me.lIntroTextfield)
        Me.grpIntro.Controls.Add(Me.rBackgroundIntro)
        Me.grpIntro.Controls.Add(Me.btnFontIntroText)
        Me.grpIntro.Controls.Add(Me.comboStyle)
        Me.grpIntro.Controls.Add(Me.lFontIntroText)
        Me.grpIntro.Controls.Add(Me.lStyle)
        Me.grpIntro.Controls.Add(Me.btnBackgroundImageIntro)
        Me.grpIntro.Controls.Add(Me.lLogoIntro)
        Me.grpIntro.Controls.Add(Me.btnBackgroundColorIntro)
        Me.grpIntro.Controls.Add(Me.btnLogoIntro)
        Me.grpIntro.Controls.Add(Me.btnBackgroundIntro)
        resources.ApplyResources(Me.grpIntro, "grpIntro")
        Me.grpIntro.Name = "grpIntro"
        Me.grpIntro.TabStop = false
        '
        'rLogoIntro
        '
        resources.ApplyResources(Me.rLogoIntro, "rLogoIntro")
        Me.rLogoIntro.Name = "rLogoIntro"
        Me.ToolTip.SetToolTip(Me.rLogoIntro, resources.GetString("rLogoIntro.ToolTip"))
        Me.rLogoIntro.UseVisualStyleBackColor = true
        '
        'btnIntroTextfield
        '
        resources.ApplyResources(Me.btnIntroTextfield, "btnIntroTextfield")
        Me.btnIntroTextfield.Name = "btnIntroTextfield"
        Me.btnIntroTextfield.UseVisualStyleBackColor = true
        '
        'lIntroTextfield
        '
        resources.ApplyResources(Me.lIntroTextfield, "lIntroTextfield")
        Me.lIntroTextfield.Name = "lIntroTextfield"
        '
        'rBackgroundIntro
        '
        resources.ApplyResources(Me.rBackgroundIntro, "rBackgroundIntro")
        Me.rBackgroundIntro.Name = "rBackgroundIntro"
        Me.ToolTip.SetToolTip(Me.rBackgroundIntro, resources.GetString("rBackgroundIntro.ToolTip"))
        Me.rBackgroundIntro.UseVisualStyleBackColor = true
        '
        'btnFontIntroText
        '
        resources.ApplyResources(Me.btnFontIntroText, "btnFontIntroText")
        Me.btnFontIntroText.Name = "btnFontIntroText"
        Me.btnFontIntroText.UseVisualStyleBackColor = true
        '
        'comboStyle
        '
        Me.comboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStyle.FormattingEnabled = true
        resources.ApplyResources(Me.comboStyle, "comboStyle")
        Me.comboStyle.Name = "comboStyle"
        '
        'lFontIntroText
        '
        resources.ApplyResources(Me.lFontIntroText, "lFontIntroText")
        Me.lFontIntroText.Name = "lFontIntroText"
        '
        'lStyle
        '
        resources.ApplyResources(Me.lStyle, "lStyle")
        Me.lStyle.Name = "lStyle"
        '
        'btnBackgroundImageIntro
        '
        resources.ApplyResources(Me.btnBackgroundImageIntro, "btnBackgroundImageIntro")
        Me.btnBackgroundImageIntro.Name = "btnBackgroundImageIntro"
        Me.btnBackgroundImageIntro.UseVisualStyleBackColor = true
        '
        'lLogoIntro
        '
        resources.ApplyResources(Me.lLogoIntro, "lLogoIntro")
        Me.lLogoIntro.Name = "lLogoIntro"
        '
        'btnBackgroundColorIntro
        '
        resources.ApplyResources(Me.btnBackgroundColorIntro, "btnBackgroundColorIntro")
        Me.btnBackgroundColorIntro.Name = "btnBackgroundColorIntro"
        Me.btnBackgroundColorIntro.UseVisualStyleBackColor = true
        '
        'btnLogoIntro
        '
        resources.ApplyResources(Me.btnLogoIntro, "btnLogoIntro")
        Me.btnLogoIntro.Name = "btnLogoIntro"
        Me.btnLogoIntro.UseVisualStyleBackColor = true
        '
        'btnBackgroundIntro
        '
        resources.ApplyResources(Me.btnBackgroundIntro, "btnBackgroundIntro")
        Me.btnBackgroundIntro.Name = "btnBackgroundIntro"
        '
        'grpScreens
        '
        Me.grpScreens.Controls.Add(Me.btnRed)
        Me.grpScreens.Controls.Add(Me.lScreens)
        Me.grpScreens.Controls.Add(Me.btnGreen)
        resources.ApplyResources(Me.grpScreens, "grpScreens")
        Me.grpScreens.Name = "grpScreens"
        Me.grpScreens.TabStop = false
        '
        'btnRed
        '
        resources.ApplyResources(Me.btnRed, "btnRed")
        Me.btnRed.Name = "btnRed"
        Me.btnRed.UseVisualStyleBackColor = true
        '
        'lScreens
        '
        resources.ApplyResources(Me.lScreens, "lScreens")
        Me.lScreens.Name = "lScreens"
        '
        'btnGreen
        '
        resources.ApplyResources(Me.btnGreen, "btnGreen")
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.UseVisualStyleBackColor = true
        '
        'FontDialogQuestion
        '
        Me.FontDialogQuestion.ShowColor = true
        '
        'FontDialogAnswers
        '
        Me.FontDialogAnswers.ShowColor = true
        '
        'OpenLogoQuestion
        '
        resources.ApplyResources(Me.OpenLogoQuestion, "OpenLogoQuestion")
        '
        'OpenBackground
        '
        resources.ApplyResources(Me.OpenBackground, "OpenBackground")
        '
        'OpenNormal
        '
        resources.ApplyResources(Me.OpenNormal, "OpenNormal")
        '
        'OpenClick
        '
        resources.ApplyResources(Me.OpenClick, "OpenClick")
        '
        'OpenHover
        '
        resources.ApplyResources(Me.OpenHover, "OpenHover")
        '
        'OpenLogoIntro
        '
        resources.ApplyResources(Me.OpenLogoIntro, "OpenLogoIntro")
        '
        'OpenBackgroundIntro
        '
        resources.ApplyResources(Me.OpenBackgroundIntro, "OpenBackgroundIntro")
        '
        'OpenGreen
        '
        resources.ApplyResources(Me.OpenGreen, "OpenGreen")
        '
        'OpenRed
        '
        resources.ApplyResources(Me.OpenRed, "OpenRed")
        '
        'ColorBackground
        '
        Me.ColorBackground.FullOpen = true
        '
        'ColorBackgroundIntro
        '
        Me.ColorBackgroundIntro.FullOpen = true
        '
        'timerButton
        '
        Me.timerButton.Interval = 500
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSave, Me.ToolStripOpen, Me.ToolStripSeparator1, Me.ToolStripExport})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripSave
        '
        resources.ApplyResources(Me.ToolStripSave, "ToolStripSave")
        Me.ToolStripSave.Name = "ToolStripSave"
        '
        'ToolStripOpen
        '
        resources.ApplyResources(Me.ToolStripOpen, "ToolStripOpen")
        Me.ToolStripOpen.Name = "ToolStripOpen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripExport
        '
        resources.ApplyResources(Me.ToolStripExport, "ToolStripExport")
        Me.ToolStripExport.Name = "ToolStripExport"
        '
        'OpenTheme
        '
        resources.ApplyResources(Me.OpenTheme, "OpenTheme")
        '
        'rMusicTest
        '
        resources.ApplyResources(Me.rMusicTest, "rMusicTest")
        Me.rMusicTest.Name = "rMusicTest"
        Me.rMusicTest.UseVisualStyleBackColor = true
        '
        'rMusicExecution
        '
        resources.ApplyResources(Me.rMusicExecution, "rMusicExecution")
        Me.rMusicExecution.Name = "rMusicExecution"
        Me.rMusicExecution.UseVisualStyleBackColor = true
        '
        'grpMusic
        '
        Me.grpMusic.Controls.Add(Me.btnMusicExecution)
        Me.grpMusic.Controls.Add(Me.btnMusicTest)
        Me.grpMusic.Controls.Add(Me.txtMusicExecution)
        Me.grpMusic.Controls.Add(Me.rMusicTest)
        Me.grpMusic.Controls.Add(Me.txtMusicTest)
        Me.grpMusic.Controls.Add(Me.rMusicExecution)
        Me.grpMusic.Controls.Add(Me.lMusicExecution)
        Me.grpMusic.Controls.Add(Me.lMusicTest)
        resources.ApplyResources(Me.grpMusic, "grpMusic")
        Me.grpMusic.Name = "grpMusic"
        Me.grpMusic.TabStop = false
        '
        'btnMusicExecution
        '
        resources.ApplyResources(Me.btnMusicExecution, "btnMusicExecution")
        Me.btnMusicExecution.Name = "btnMusicExecution"
        Me.btnMusicExecution.UseVisualStyleBackColor = true
        '
        'btnMusicTest
        '
        resources.ApplyResources(Me.btnMusicTest, "btnMusicTest")
        Me.btnMusicTest.Name = "btnMusicTest"
        Me.btnMusicTest.UseVisualStyleBackColor = true
        '
        'txtMusicExecution
        '
        resources.ApplyResources(Me.txtMusicExecution, "txtMusicExecution")
        Me.txtMusicExecution.Name = "txtMusicExecution"
        '
        'txtMusicTest
        '
        resources.ApplyResources(Me.txtMusicTest, "txtMusicTest")
        Me.txtMusicTest.Name = "txtMusicTest"
        '
        'lMusicExecution
        '
        resources.ApplyResources(Me.lMusicExecution, "lMusicExecution")
        Me.lMusicExecution.Name = "lMusicExecution"
        '
        'lMusicTest
        '
        resources.ApplyResources(Me.lMusicTest, "lMusicTest")
        Me.lMusicTest.Name = "lMusicTest"
        '
        'FontIntroText
        '
        Me.FontIntroText.ShowColor = true
        '
        'FontIntroTextfield
        '
        Me.FontIntroTextfield.ShowColor = true
        '
        'ColorClick
        '
        Me.ColorClick.FullOpen = true
        '
        'OpenQuestionBackground
        '
        resources.ApplyResources(Me.OpenQuestionBackground, "OpenQuestionBackground")
        '
        'OpenMusicTest
        '
        resources.ApplyResources(Me.OpenMusicTest, "OpenMusicTest")
        '
        'OpenMusicExecution
        '
        resources.ApplyResources(Me.OpenMusicExecution, "OpenMusicExecution")
        '
        'SaveExport
        '
        resources.ApplyResources(Me.SaveExport, "SaveExport")
        '
        'FrmTheme
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpMusic)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpScreens)
        Me.Controls.Add(Me.grpIntro)
        Me.Controls.Add(Me.grpExample)
        Me.Controls.Add(Me.grpQuestion)
        Me.Controls.Add(Me.grpGeneral)
        Me.Name = "FrmTheme"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpGeneral.ResumeLayout(false)
        Me.grpGeneral.PerformLayout
        Me.grpQuestion.ResumeLayout(false)
        Me.grpQuestion.PerformLayout
        Me.grpExample.ResumeLayout(false)
        Me.tabExample.ResumeLayout(false)
        Me.tabTest.ResumeLayout(false)
        Me.pnlExampleTest.ResumeLayout(false)
        CType(Me.picAnswer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.picLogo,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabIntro.ResumeLayout(false)
        Me.pnlExampleIntro.ResumeLayout(false)
        Me.pnlOld.ResumeLayout(false)
        Me.pnlOld.PerformLayout
        Me.pnlUS.ResumeLayout(false)
        Me.pnlUS.PerformLayout
        Me.pnlNew.ResumeLayout(false)
        Me.pnlNew.PerformLayout
        CType(Me.picLogoIntro,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpIntro.ResumeLayout(false)
        Me.grpIntro.PerformLayout
        Me.grpScreens.ResumeLayout(false)
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.grpMusic.ResumeLayout(false)
        Me.grpMusic.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents grpGeneral As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents lName As Label
    Friend WithEvents grpQuestion As GroupBox
    Friend WithEvents btnFontQuestion As Button
    Friend WithEvents lFont As Label
    Friend WithEvents grpExample As GroupBox
    Friend WithEvents pnlExampleTest As Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lQuestion As Label
    Friend WithEvents picAnswer As PictureBox
    Friend WithEvents lAnswer As Label
    Friend WithEvents lLogo As Label
    Friend WithEvents lBackgroundColor As Label
    Friend WithEvents btnLogoQuestion As Button
    Friend WithEvents btnBackgroundColor As Button
    Friend WithEvents btnFontAnswers As Button
    Friend WithEvents lFontAnswers As Label
    Friend WithEvents btnBackgroundImage As Button
    Friend WithEvents btnButtonNormal As Button
    Friend WithEvents btnButtonHover As Button
    Friend WithEvents btnButtonClick As Button
    Friend WithEvents lButtonAnswers As Label
    Friend WithEvents grpIntro As GroupBox
    Friend WithEvents btnBackgroundImageIntro As Button
    Friend WithEvents lLogoIntro As Label
    Friend WithEvents btnBackgroundColorIntro As Button
    Friend WithEvents btnLogoIntro As Button
    Friend WithEvents btnBackgroundIntro As Label
    Friend WithEvents grpScreens As GroupBox
    Friend WithEvents btnRed As Button
    Friend WithEvents lScreens As Label
    Friend WithEvents btnGreen As Button
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FontDialogQuestion As FontDialog
    Friend WithEvents FontDialogAnswers As FontDialog
    Friend WithEvents OpenLogoQuestion As OpenFileDialog
    Friend WithEvents OpenBackground As OpenFileDialog
    Friend WithEvents OpenNormal As OpenFileDialog
    Friend WithEvents OpenClick As OpenFileDialog
    Friend WithEvents OpenHover As OpenFileDialog
    Friend WithEvents OpenLogoIntro As OpenFileDialog
    Friend WithEvents OpenBackgroundIntro As OpenFileDialog
    Friend WithEvents OpenGreen As OpenFileDialog
    Friend WithEvents OpenRed As OpenFileDialog
    Friend WithEvents ColorBackground As ColorDialog
    Friend WithEvents ColorBackgroundIntro As ColorDialog
    Friend WithEvents btnReload As Button
    Friend WithEvents timerButton As Timer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSave As ToolStripButton
    Friend WithEvents ToolStripOpen As ToolStripButton
    Friend WithEvents OpenTheme As OpenFileDialog
    Friend WithEvents comboStyle As ComboBox
    Friend WithEvents lStyle As Label
    Friend WithEvents rHover As CheckBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents tabExample As TabControl
    Friend WithEvents tabTest As TabPage
    Friend WithEvents tabIntro As TabPage
    Friend WithEvents pnlExampleIntro As Panel
    Friend WithEvents picLogoIntro As PictureBox
    Friend WithEvents pnlOld As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lOldname As Label
    Friend WithEvents lOldtext As TextBox
    Friend WithEvents lOldbutton As Button
    Friend WithEvents pnlUS As Panel
    Friend WithEvents lUStext As TextBox
    Friend WithEvents lUSname As Label
    Friend WithEvents pnlNew As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents lNewtext As TextBox
    Friend WithEvents lNewname As Label
    Friend WithEvents btnFontIntroText As Button
    Friend WithEvents lFontIntroText As Label
    Friend WithEvents FontIntroText As FontDialog
    Friend WithEvents rBackgroundTest As CheckBox
    Friend WithEvents rBackgroundIntro As CheckBox
    Friend WithEvents green As TabPage
    Friend WithEvents red As TabPage
    Friend WithEvents btnIntroTextfield As Button
    Friend WithEvents lIntroTextfield As Label
    Friend WithEvents FontIntroTextfield As FontDialog
    Friend WithEvents rLogoQuestion As CheckBox
    Friend WithEvents rLogoIntro As CheckBox
    Friend WithEvents grpMusic As GroupBox
    Friend WithEvents txtMusicExecution As TextBox
    Friend WithEvents rMusicTest As CheckBox
    Friend WithEvents txtMusicTest As TextBox
    Friend WithEvents rMusicExecution As CheckBox
    Friend WithEvents lMusicExecution As Label
    Friend WithEvents lMusicTest As Label
    Friend WithEvents btnColorClick As Button
    Friend WithEvents lColorClick As Label
    Friend WithEvents ColorClick As ColorDialog
    Friend WithEvents rColorClick As CheckBox
    Friend WithEvents rQuestionBackground As CheckBox
    Friend WithEvents btnQuestionBackground As Button
    Friend WithEvents lQuestionBackground As Label
    Friend WithEvents comboAlignment As ComboBox
    Friend WithEvents lAlignment As Label
    Friend WithEvents OpenQuestionBackground As OpenFileDialog
    Friend WithEvents btnMusicExecution As Button
    Friend WithEvents btnMusicTest As Button
    Friend WithEvents OpenMusicTest As OpenFileDialog
    Friend WithEvents OpenMusicExecution As OpenFileDialog
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripExport As ToolStripButton
    Friend WithEvents SaveExport As SaveFileDialog
End Class
