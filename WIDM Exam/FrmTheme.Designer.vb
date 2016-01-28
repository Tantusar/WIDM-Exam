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
        Me.FontIntroText = New System.Windows.Forms.FontDialog()
        Me.FontIntroTextfield = New System.Windows.Forms.FontDialog()
        Me.grpMusic = New System.Windows.Forms.GroupBox()
        Me.btnMusicExecution = New System.Windows.Forms.Button()
        Me.btnMusicTest = New System.Windows.Forms.Button()
        Me.txtMusicExecution = New System.Windows.Forms.TextBox()
        Me.txtMusicTest = New System.Windows.Forms.TextBox()
        Me.lMusicExecution = New System.Windows.Forms.Label()
        Me.lMusicTest = New System.Windows.Forms.Label()
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
        Me.grpGeneral.Location = New System.Drawing.Point(6, 28)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(380, 78)
        Me.grpGeneral.TabIndex = 0
        Me.grpGeneral.TabStop = false
        Me.grpGeneral.Text = "Thema-instellingen"
        '
        'txtAuthor
        '
        Me.txtAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtAuthor.Location = New System.Drawing.Point(126, 42)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(248, 20)
        Me.txtAuthor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Auteur:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(126, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(248, 20)
        Me.txtName.TabIndex = 1
        '
        'lName
        '
        Me.lName.Location = New System.Drawing.Point(6, 16)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(114, 20)
        Me.lName.TabIndex = 0
        Me.lName.Text = "Naam van het thema:"
        Me.lName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.grpQuestion.Location = New System.Drawing.Point(6, 112)
        Me.grpQuestion.Name = "grpQuestion"
        Me.grpQuestion.Size = New System.Drawing.Size(380, 253)
        Me.grpQuestion.TabIndex = 1
        Me.grpQuestion.TabStop = false
        Me.grpQuestion.Text = "Vraag"
        '
        'rQuestionBackground
        '
        Me.rQuestionBackground.AutoSize = true
        Me.rQuestionBackground.Location = New System.Drawing.Point(280, 76)
        Me.rQuestionBackground.Name = "rQuestionBackground"
        Me.rQuestionBackground.Size = New System.Drawing.Size(15, 14)
        Me.rQuestionBackground.TabIndex = 35
        Me.ToolTip.SetToolTip(Me.rQuestionBackground, "Laat een logo linksboven zien voor de vraag")
        Me.rQuestionBackground.UseVisualStyleBackColor = true
        '
        'btnQuestionBackground
        '
        Me.btnQuestionBackground.Enabled = false
        Me.btnQuestionBackground.Location = New System.Drawing.Point(299, 71)
        Me.btnQuestionBackground.Name = "btnQuestionBackground"
        Me.btnQuestionBackground.Size = New System.Drawing.Size(75, 23)
        Me.btnQuestionBackground.TabIndex = 34
        Me.btnQuestionBackground.Text = "Afbeelding"
        Me.btnQuestionBackground.UseVisualStyleBackColor = true
        '
        'lQuestionBackground
        '
        Me.lQuestionBackground.Location = New System.Drawing.Point(6, 72)
        Me.lQuestionBackground.Name = "lQuestionBackground"
        Me.lQuestionBackground.Size = New System.Drawing.Size(105, 20)
        Me.lQuestionBackground.TabIndex = 33
        Me.lQuestionBackground.Text = "Vraag achtergrond"
        Me.lQuestionBackground.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboAlignment
        '
        Me.comboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboAlignment.FormattingEnabled = true
        Me.comboAlignment.Location = New System.Drawing.Point(152, 44)
        Me.comboAlignment.Name = "comboAlignment"
        Me.comboAlignment.Size = New System.Drawing.Size(222, 21)
        Me.comboAlignment.TabIndex = 28
        '
        'lAlignment
        '
        Me.lAlignment.Location = New System.Drawing.Point(6, 45)
        Me.lAlignment.Name = "lAlignment"
        Me.lAlignment.Size = New System.Drawing.Size(105, 20)
        Me.lAlignment.TabIndex = 32
        Me.lAlignment.Text = "Vraag uitlijning"
        Me.lAlignment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rColorClick
        '
        Me.rColorClick.AutoSize = true
        Me.rColorClick.Location = New System.Drawing.Point(280, 221)
        Me.rColorClick.Name = "rColorClick"
        Me.rColorClick.Size = New System.Drawing.Size(15, 14)
        Me.rColorClick.TabIndex = 31
        Me.ToolTip.SetToolTip(Me.rColorClick, "Verander de tekstkleur bij een klik")
        Me.rColorClick.UseVisualStyleBackColor = true
        '
        'btnColorClick
        '
        Me.btnColorClick.Enabled = false
        Me.btnColorClick.Location = New System.Drawing.Point(299, 216)
        Me.btnColorClick.Name = "btnColorClick"
        Me.btnColorClick.Size = New System.Drawing.Size(75, 23)
        Me.btnColorClick.TabIndex = 30
        Me.btnColorClick.Text = "Kleur"
        Me.btnColorClick.UseVisualStyleBackColor = true
        '
        'lColorClick
        '
        Me.lColorClick.Location = New System.Drawing.Point(6, 217)
        Me.lColorClick.Name = "lColorClick"
        Me.lColorClick.Size = New System.Drawing.Size(124, 20)
        Me.lColorClick.TabIndex = 29
        Me.lColorClick.Text = "Kleur bij klik en hover:"
        Me.lColorClick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rLogoQuestion
        '
        Me.rLogoQuestion.AutoSize = true
        Me.rLogoQuestion.Location = New System.Drawing.Point(280, 105)
        Me.rLogoQuestion.Name = "rLogoQuestion"
        Me.rLogoQuestion.Size = New System.Drawing.Size(15, 14)
        Me.rLogoQuestion.TabIndex = 28
        Me.ToolTip.SetToolTip(Me.rLogoQuestion, "Laat een logo linksboven zien voor de vraag")
        Me.rLogoQuestion.UseVisualStyleBackColor = true
        '
        'rBackgroundTest
        '
        Me.rBackgroundTest.AutoSize = true
        Me.rBackgroundTest.Location = New System.Drawing.Point(280, 134)
        Me.rBackgroundTest.Name = "rBackgroundTest"
        Me.rBackgroundTest.Size = New System.Drawing.Size(15, 14)
        Me.rBackgroundTest.TabIndex = 19
        Me.ToolTip.SetToolTip(Me.rBackgroundTest, "Gebruik achtergrondafbeelding tijdens de test")
        Me.rBackgroundTest.UseVisualStyleBackColor = true
        '
        'rHover
        '
        Me.rHover.AutoSize = true
        Me.rHover.Location = New System.Drawing.Point(280, 192)
        Me.rHover.Name = "rHover"
        Me.rHover.Size = New System.Drawing.Size(15, 14)
        Me.rHover.TabIndex = 18
        Me.ToolTip.SetToolTip(Me.rHover, "Zet hover effect aan of uit")
        Me.rHover.UseVisualStyleBackColor = true
        '
        'btnButtonNormal
        '
        Me.btnButtonNormal.Location = New System.Drawing.Point(118, 187)
        Me.btnButtonNormal.Name = "btnButtonNormal"
        Me.btnButtonNormal.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonNormal.TabIndex = 17
        Me.btnButtonNormal.Text = "Normaal"
        Me.btnButtonNormal.UseVisualStyleBackColor = true
        '
        'btnButtonHover
        '
        Me.btnButtonHover.Enabled = false
        Me.btnButtonHover.Location = New System.Drawing.Point(299, 187)
        Me.btnButtonHover.Name = "btnButtonHover"
        Me.btnButtonHover.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonHover.TabIndex = 16
        Me.btnButtonHover.Text = "Hover"
        Me.btnButtonHover.UseVisualStyleBackColor = true
        '
        'btnButtonClick
        '
        Me.btnButtonClick.Location = New System.Drawing.Point(199, 187)
        Me.btnButtonClick.Name = "btnButtonClick"
        Me.btnButtonClick.Size = New System.Drawing.Size(75, 23)
        Me.btnButtonClick.TabIndex = 15
        Me.btnButtonClick.Text = "Klik"
        Me.btnButtonClick.UseVisualStyleBackColor = true
        '
        'lButtonAnswers
        '
        Me.lButtonAnswers.Location = New System.Drawing.Point(6, 188)
        Me.lButtonAnswers.Name = "lButtonAnswers"
        Me.lButtonAnswers.Size = New System.Drawing.Size(106, 20)
        Me.lButtonAnswers.TabIndex = 14
        Me.lButtonAnswers.Text = "Knop antwoorden:"
        Me.lButtonAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBackgroundImage
        '
        Me.btnBackgroundImage.Enabled = false
        Me.btnBackgroundImage.Location = New System.Drawing.Point(299, 129)
        Me.btnBackgroundImage.Name = "btnBackgroundImage"
        Me.btnBackgroundImage.Size = New System.Drawing.Size(75, 23)
        Me.btnBackgroundImage.TabIndex = 13
        Me.btnBackgroundImage.Text = "Afbeelding"
        Me.btnBackgroundImage.UseVisualStyleBackColor = true
        '
        'btnFontAnswers
        '
        Me.btnFontAnswers.Location = New System.Drawing.Point(299, 158)
        Me.btnFontAnswers.Name = "btnFontAnswers"
        Me.btnFontAnswers.Size = New System.Drawing.Size(75, 23)
        Me.btnFontAnswers.TabIndex = 11
        Me.btnFontAnswers.Text = "Lettertype"
        Me.btnFontAnswers.UseVisualStyleBackColor = true
        '
        'lFontAnswers
        '
        Me.lFontAnswers.Location = New System.Drawing.Point(6, 159)
        Me.lFontAnswers.Name = "lFontAnswers"
        Me.lFontAnswers.Size = New System.Drawing.Size(138, 20)
        Me.lFontAnswers.TabIndex = 10
        Me.lFontAnswers.Text = "Lettertype antwoorden:"
        Me.lFontAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBackgroundColor
        '
        Me.btnBackgroundColor.Location = New System.Drawing.Point(199, 129)
        Me.btnBackgroundColor.Name = "btnBackgroundColor"
        Me.btnBackgroundColor.Size = New System.Drawing.Size(75, 23)
        Me.btnBackgroundColor.TabIndex = 9
        Me.btnBackgroundColor.Text = "Kleur"
        Me.btnBackgroundColor.UseVisualStyleBackColor = true
        '
        'lBackgroundColor
        '
        Me.lBackgroundColor.Location = New System.Drawing.Point(6, 130)
        Me.lBackgroundColor.Name = "lBackgroundColor"
        Me.lBackgroundColor.Size = New System.Drawing.Size(105, 20)
        Me.lBackgroundColor.TabIndex = 8
        Me.lBackgroundColor.Text = "Achtergrond:"
        Me.lBackgroundColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLogoQuestion
        '
        Me.btnLogoQuestion.Enabled = false
        Me.btnLogoQuestion.Location = New System.Drawing.Point(299, 100)
        Me.btnLogoQuestion.Name = "btnLogoQuestion"
        Me.btnLogoQuestion.Size = New System.Drawing.Size(75, 23)
        Me.btnLogoQuestion.TabIndex = 7
        Me.btnLogoQuestion.Text = "Afbeelding"
        Me.btnLogoQuestion.UseVisualStyleBackColor = true
        '
        'lLogo
        '
        Me.lLogo.Location = New System.Drawing.Point(6, 101)
        Me.lLogo.Name = "lLogo"
        Me.lLogo.Size = New System.Drawing.Size(105, 20)
        Me.lLogo.TabIndex = 6
        Me.lLogo.Text = "Logo voor vraag:"
        Me.lLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFontQuestion
        '
        Me.btnFontQuestion.Location = New System.Drawing.Point(299, 15)
        Me.btnFontQuestion.Name = "btnFontQuestion"
        Me.btnFontQuestion.Size = New System.Drawing.Size(75, 23)
        Me.btnFontQuestion.TabIndex = 3
        Me.btnFontQuestion.Text = "Lettertype"
        Me.btnFontQuestion.UseVisualStyleBackColor = true
        '
        'lFont
        '
        Me.lFont.Location = New System.Drawing.Point(6, 16)
        Me.lFont.Name = "lFont"
        Me.lFont.Size = New System.Drawing.Size(105, 20)
        Me.lFont.TabIndex = 2
        Me.lFont.Text = "Lettertype vraag:"
        Me.lFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpExample
        '
        Me.grpExample.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpExample.BackColor = System.Drawing.SystemColors.Control
        Me.grpExample.Controls.Add(Me.btnReload)
        Me.grpExample.Controls.Add(Me.tabExample)
        Me.grpExample.Location = New System.Drawing.Point(392, 122)
        Me.grpExample.Name = "grpExample"
        Me.grpExample.Size = New System.Drawing.Size(346, 725)
        Me.grpExample.TabIndex = 2
        Me.grpExample.TabStop = false
        Me.grpExample.Text = "Voorbeeld"
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnReload.Location = New System.Drawing.Point(268, 0)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(78, 23)
        Me.btnReload.TabIndex = 26
        Me.btnReload.Text = "Herladen"
        Me.btnReload.UseVisualStyleBackColor = true
        '
        'tabExample
        '
        Me.tabExample.Controls.Add(Me.tabTest)
        Me.tabExample.Controls.Add(Me.tabIntro)
        Me.tabExample.Controls.Add(Me.green)
        Me.tabExample.Controls.Add(Me.red)
        Me.tabExample.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabExample.Location = New System.Drawing.Point(3, 16)
        Me.tabExample.Name = "tabExample"
        Me.tabExample.SelectedIndex = 0
        Me.tabExample.Size = New System.Drawing.Size(340, 706)
        Me.tabExample.TabIndex = 4
        '
        'tabTest
        '
        Me.tabTest.Controls.Add(Me.pnlExampleTest)
        Me.tabTest.Location = New System.Drawing.Point(4, 22)
        Me.tabTest.Name = "tabTest"
        Me.tabTest.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTest.Size = New System.Drawing.Size(332, 680)
        Me.tabTest.TabIndex = 0
        Me.tabTest.Text = "Test"
        Me.tabTest.UseVisualStyleBackColor = true
        '
        'pnlExampleTest
        '
        Me.pnlExampleTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlExampleTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExampleTest.Controls.Add(Me.lAnswer)
        Me.pnlExampleTest.Controls.Add(Me.picAnswer)
        Me.pnlExampleTest.Controls.Add(Me.picLogo)
        Me.pnlExampleTest.Controls.Add(Me.lQuestion)
        Me.pnlExampleTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlExampleTest.Location = New System.Drawing.Point(3, 3)
        Me.pnlExampleTest.Name = "pnlExampleTest"
        Me.pnlExampleTest.Size = New System.Drawing.Size(326, 674)
        Me.pnlExampleTest.TabIndex = 3
        '
        'lAnswer
        '
        Me.lAnswer.BackColor = System.Drawing.Color.Transparent
        Me.lAnswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lAnswer.Location = New System.Drawing.Point(146, 144)
        Me.lAnswer.Name = "lAnswer"
        Me.lAnswer.Size = New System.Drawing.Size(151, 50)
        Me.lAnswer.TabIndex = 3
        Me.lAnswer.Text = "Answer"
        Me.lAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picAnswer
        '
        Me.picAnswer.BackColor = System.Drawing.Color.Transparent
        Me.picAnswer.Location = New System.Drawing.Point(90, 144)
        Me.picAnswer.Name = "picAnswer"
        Me.picAnswer.Size = New System.Drawing.Size(50, 50)
        Me.picAnswer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAnswer.TabIndex = 2
        Me.picAnswer.TabStop = false
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Location = New System.Drawing.Point(-1, -1)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(141, 133)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 1
        Me.picLogo.TabStop = false
        '
        'lQuestion
        '
        Me.lQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lQuestion.BackColor = System.Drawing.Color.Transparent
        Me.lQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lQuestion.Location = New System.Drawing.Point(146, 41)
        Me.lQuestion.Name = "lQuestion"
        Me.lQuestion.Size = New System.Drawing.Size(175, 48)
        Me.lQuestion.TabIndex = 0
        Me.lQuestion.Text = "Question"
        Me.lQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabIntro
        '
        Me.tabIntro.Controls.Add(Me.pnlExampleIntro)
        Me.tabIntro.Location = New System.Drawing.Point(4, 22)
        Me.tabIntro.Name = "tabIntro"
        Me.tabIntro.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIntro.Size = New System.Drawing.Size(349, 649)
        Me.tabIntro.TabIndex = 1
        Me.tabIntro.Text = "Naam invoeren"
        Me.tabIntro.UseVisualStyleBackColor = true
        '
        'pnlExampleIntro
        '
        Me.pnlExampleIntro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlExampleIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExampleIntro.Controls.Add(Me.pnlOld)
        Me.pnlExampleIntro.Controls.Add(Me.pnlUS)
        Me.pnlExampleIntro.Controls.Add(Me.pnlNew)
        Me.pnlExampleIntro.Controls.Add(Me.picLogoIntro)
        Me.pnlExampleIntro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlExampleIntro.Location = New System.Drawing.Point(3, 3)
        Me.pnlExampleIntro.Name = "pnlExampleIntro"
        Me.pnlExampleIntro.Size = New System.Drawing.Size(343, 643)
        Me.pnlExampleIntro.TabIndex = 29
        '
        'pnlOld
        '
        Me.pnlOld.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlOld.BackColor = System.Drawing.SystemColors.Control
        Me.pnlOld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOld.Controls.Add(Me.Label4)
        Me.pnlOld.Controls.Add(Me.lOldname)
        Me.pnlOld.Controls.Add(Me.lOldtext)
        Me.pnlOld.Controls.Add(Me.lOldbutton)
        Me.pnlOld.Location = New System.Drawing.Point(18, 398)
        Me.pnlOld.Name = "pnlOld"
        Me.pnlOld.Size = New System.Drawing.Size(260, 128)
        Me.pnlOld.TabIndex = 30
        Me.pnlOld.Visible = false
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(242, -1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "×"
        '
        'lOldname
        '
        Me.lOldname.AutoSize = true
        Me.lOldname.Font = New System.Drawing.Font("Comic Sans MS", 12!)
        Me.lOldname.ForeColor = System.Drawing.Color.Red
        Me.lOldname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lOldname.Location = New System.Drawing.Point(18, 32)
        Me.lOldname.Name = "lOldname"
        Me.lOldname.Size = New System.Drawing.Size(50, 23)
        Me.lOldname.TabIndex = 8
        Me.lOldname.Text = "Naam"
        '
        'lOldtext
        '
        Me.lOldtext.Font = New System.Drawing.Font("Comic Sans MS", 12!)
        Me.lOldtext.ForeColor = System.Drawing.Color.Red
        Me.lOldtext.Location = New System.Drawing.Point(77, 29)
        Me.lOldtext.Name = "lOldtext"
        Me.lOldtext.Size = New System.Drawing.Size(167, 30)
        Me.lOldtext.TabIndex = 6
        '
        'lOldbutton
        '
        Me.lOldbutton.Font = New System.Drawing.Font("Comic Sans MS", 11.25!)
        Me.lOldbutton.ForeColor = System.Drawing.Color.Red
        Me.lOldbutton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lOldbutton.Location = New System.Drawing.Point(36, 81)
        Me.lOldbutton.Name = "lOldbutton"
        Me.lOldbutton.Size = New System.Drawing.Size(188, 33)
        Me.lOldbutton.TabIndex = 7
        Me.lOldbutton.Text = "Naam ingeven"
        Me.lOldbutton.UseVisualStyleBackColor = true
        '
        'pnlUS
        '
        Me.pnlUS.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlUS.BackColor = System.Drawing.Color.Transparent
        Me.pnlUS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlUS.Controls.Add(Me.lUStext)
        Me.pnlUS.Controls.Add(Me.lUSname)
        Me.pnlUS.Location = New System.Drawing.Point(165, 269)
        Me.pnlUS.Name = "pnlUS"
        Me.pnlUS.Size = New System.Drawing.Size(432, 159)
        Me.pnlUS.TabIndex = 31
        Me.pnlUS.Visible = false
        '
        'lUStext
        '
        Me.lUStext.Font = New System.Drawing.Font("Microsoft Sans Serif", 36!)
        Me.lUStext.Location = New System.Drawing.Point(27, 74)
        Me.lUStext.Name = "lUStext"
        Me.lUStext.Size = New System.Drawing.Size(378, 62)
        Me.lUStext.TabIndex = 1
        Me.lUStext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lUSname
        '
        Me.lUSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 36!, System.Drawing.FontStyle.Bold)
        Me.lUSname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.lUSname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lUSname.Location = New System.Drawing.Point(27, 16)
        Me.lUSname.Name = "lUSname"
        Me.lUSname.Size = New System.Drawing.Size(378, 55)
        Me.lUSname.TabIndex = 0
        Me.lUSname.Text = "PLAYER"
        Me.lUSname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlNew
        '
        Me.pnlNew.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlNew.BackColor = System.Drawing.Color.Transparent
        Me.pnlNew.Controls.Add(Me.Label11)
        Me.pnlNew.Controls.Add(Me.lNewtext)
        Me.pnlNew.Controls.Add(Me.lNewname)
        Me.pnlNew.Location = New System.Drawing.Point(75, 340)
        Me.pnlNew.Name = "pnlNew"
        Me.pnlNew.Size = New System.Drawing.Size(359, 82)
        Me.pnlNew.TabIndex = 29
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(311, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 28)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "×"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lNewtext
        '
        Me.lNewtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lNewtext.Font = New System.Drawing.Font("Lucida Console", 18!)
        Me.lNewtext.Location = New System.Drawing.Point(22, 40)
        Me.lNewtext.Name = "lNewtext"
        Me.lNewtext.Size = New System.Drawing.Size(312, 31)
        Me.lNewtext.TabIndex = 1
        '
        'lNewname
        '
        Me.lNewname.AutoSize = true
        Me.lNewname.Font = New System.Drawing.Font("Lucida Console", 14.25!)
        Me.lNewname.ForeColor = System.Drawing.Color.White
        Me.lNewname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lNewname.Location = New System.Drawing.Point(18, 18)
        Me.lNewname.Name = "lNewname"
        Me.lNewname.Size = New System.Drawing.Size(185, 19)
        Me.lNewname.TabIndex = 0
        Me.lNewname.Text = "Voer uw naam in:"
        '
        'picLogoIntro
        '
        Me.picLogoIntro.BackColor = System.Drawing.Color.Transparent
        Me.picLogoIntro.Location = New System.Drawing.Point(-1, -1)
        Me.picLogoIntro.Name = "picLogoIntro"
        Me.picLogoIntro.Size = New System.Drawing.Size(307, 307)
        Me.picLogoIntro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogoIntro.TabIndex = 1
        Me.picLogoIntro.TabStop = false
        '
        'green
        '
        Me.green.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.green.Location = New System.Drawing.Point(4, 22)
        Me.green.Name = "green"
        Me.green.Size = New System.Drawing.Size(349, 649)
        Me.green.TabIndex = 2
        Me.green.Text = "Groen scherm"
        Me.green.UseVisualStyleBackColor = true
        '
        'red
        '
        Me.red.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.red.Location = New System.Drawing.Point(4, 22)
        Me.red.Name = "red"
        Me.red.Size = New System.Drawing.Size(349, 649)
        Me.red.TabIndex = 3
        Me.red.Text = "Rood scherm"
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
        Me.grpIntro.Location = New System.Drawing.Point(6, 371)
        Me.grpIntro.Name = "grpIntro"
        Me.grpIntro.Size = New System.Drawing.Size(380, 166)
        Me.grpIntro.TabIndex = 3
        Me.grpIntro.TabStop = false
        Me.grpIntro.Text = "Naam invoeren"
        '
        'rLogoIntro
        '
        Me.rLogoIntro.AutoSize = true
        Me.rLogoIntro.Location = New System.Drawing.Point(280, 78)
        Me.rLogoIntro.Name = "rLogoIntro"
        Me.rLogoIntro.Size = New System.Drawing.Size(15, 14)
        Me.rLogoIntro.TabIndex = 27
        Me.ToolTip.SetToolTip(Me.rLogoIntro, "Laat een logo linksboven zien bij het invoeren van de naam")
        Me.rLogoIntro.UseVisualStyleBackColor = true
        '
        'btnIntroTextfield
        '
        Me.btnIntroTextfield.Location = New System.Drawing.Point(299, 44)
        Me.btnIntroTextfield.Name = "btnIntroTextfield"
        Me.btnIntroTextfield.Size = New System.Drawing.Size(75, 23)
        Me.btnIntroTextfield.TabIndex = 26
        Me.btnIntroTextfield.Text = "Lettertype"
        Me.btnIntroTextfield.UseVisualStyleBackColor = true
        '
        'lIntroTextfield
        '
        Me.lIntroTextfield.Location = New System.Drawing.Point(6, 45)
        Me.lIntroTextfield.Name = "lIntroTextfield"
        Me.lIntroTextfield.Size = New System.Drawing.Size(105, 20)
        Me.lIntroTextfield.TabIndex = 25
        Me.lIntroTextfield.Text = "Lettertype tekstveld:"
        Me.lIntroTextfield.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rBackgroundIntro
        '
        Me.rBackgroundIntro.AutoSize = true
        Me.rBackgroundIntro.Location = New System.Drawing.Point(280, 107)
        Me.rBackgroundIntro.Name = "rBackgroundIntro"
        Me.rBackgroundIntro.Size = New System.Drawing.Size(15, 14)
        Me.rBackgroundIntro.TabIndex = 20
        Me.ToolTip.SetToolTip(Me.rBackgroundIntro, "Gebruik achtergrondafbeelding tijdens het naam invoeren")
        Me.rBackgroundIntro.UseVisualStyleBackColor = true
        '
        'btnFontIntroText
        '
        Me.btnFontIntroText.Location = New System.Drawing.Point(299, 15)
        Me.btnFontIntroText.Name = "btnFontIntroText"
        Me.btnFontIntroText.Size = New System.Drawing.Size(75, 23)
        Me.btnFontIntroText.TabIndex = 20
        Me.btnFontIntroText.Text = "Lettertype"
        Me.btnFontIntroText.UseVisualStyleBackColor = true
        '
        'comboStyle
        '
        Me.comboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStyle.FormattingEnabled = true
        Me.comboStyle.Location = New System.Drawing.Point(118, 131)
        Me.comboStyle.Name = "comboStyle"
        Me.comboStyle.Size = New System.Drawing.Size(256, 21)
        Me.comboStyle.TabIndex = 24
        '
        'lFontIntroText
        '
        Me.lFontIntroText.Location = New System.Drawing.Point(6, 16)
        Me.lFontIntroText.Name = "lFontIntroText"
        Me.lFontIntroText.Size = New System.Drawing.Size(105, 20)
        Me.lFontIntroText.TabIndex = 19
        Me.lFontIntroText.Text = "Lettertype naam:"
        Me.lFontIntroText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lStyle
        '
        Me.lStyle.Location = New System.Drawing.Point(6, 130)
        Me.lStyle.Name = "lStyle"
        Me.lStyle.Size = New System.Drawing.Size(105, 20)
        Me.lStyle.TabIndex = 23
        Me.lStyle.Text = "Stijl:"
        Me.lStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBackgroundImageIntro
        '
        Me.btnBackgroundImageIntro.Enabled = false
        Me.btnBackgroundImageIntro.Location = New System.Drawing.Point(299, 102)
        Me.btnBackgroundImageIntro.Name = "btnBackgroundImageIntro"
        Me.btnBackgroundImageIntro.Size = New System.Drawing.Size(75, 23)
        Me.btnBackgroundImageIntro.TabIndex = 22
        Me.btnBackgroundImageIntro.Text = "Afbeelding"
        Me.btnBackgroundImageIntro.UseVisualStyleBackColor = true
        '
        'lLogoIntro
        '
        Me.lLogoIntro.Location = New System.Drawing.Point(6, 74)
        Me.lLogoIntro.Name = "lLogoIntro"
        Me.lLogoIntro.Size = New System.Drawing.Size(105, 20)
        Me.lLogoIntro.TabIndex = 18
        Me.lLogoIntro.Text = "Logo linksboven:"
        Me.lLogoIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBackgroundColorIntro
        '
        Me.btnBackgroundColorIntro.Location = New System.Drawing.Point(199, 102)
        Me.btnBackgroundColorIntro.Name = "btnBackgroundColorIntro"
        Me.btnBackgroundColorIntro.Size = New System.Drawing.Size(75, 23)
        Me.btnBackgroundColorIntro.TabIndex = 21
        Me.btnBackgroundColorIntro.Text = "Kleur"
        Me.btnBackgroundColorIntro.UseVisualStyleBackColor = true
        '
        'btnLogoIntro
        '
        Me.btnLogoIntro.Enabled = false
        Me.btnLogoIntro.Location = New System.Drawing.Point(299, 73)
        Me.btnLogoIntro.Name = "btnLogoIntro"
        Me.btnLogoIntro.Size = New System.Drawing.Size(75, 23)
        Me.btnLogoIntro.TabIndex = 19
        Me.btnLogoIntro.Text = "Afbeelding"
        Me.btnLogoIntro.UseVisualStyleBackColor = true
        '
        'btnBackgroundIntro
        '
        Me.btnBackgroundIntro.Location = New System.Drawing.Point(6, 103)
        Me.btnBackgroundIntro.Name = "btnBackgroundIntro"
        Me.btnBackgroundIntro.Size = New System.Drawing.Size(105, 20)
        Me.btnBackgroundIntro.TabIndex = 20
        Me.btnBackgroundIntro.Text = "Achtergrond:"
        Me.btnBackgroundIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpScreens
        '
        Me.grpScreens.Controls.Add(Me.btnRed)
        Me.grpScreens.Controls.Add(Me.lScreens)
        Me.grpScreens.Controls.Add(Me.btnGreen)
        Me.grpScreens.Location = New System.Drawing.Point(6, 543)
        Me.grpScreens.Name = "grpScreens"
        Me.grpScreens.Size = New System.Drawing.Size(380, 49)
        Me.grpScreens.TabIndex = 23
        Me.grpScreens.TabStop = false
        Me.grpScreens.Text = "Schermen"
        '
        'btnRed
        '
        Me.btnRed.Location = New System.Drawing.Point(299, 15)
        Me.btnRed.Name = "btnRed"
        Me.btnRed.Size = New System.Drawing.Size(75, 23)
        Me.btnRed.TabIndex = 25
        Me.btnRed.Text = "Rood"
        Me.btnRed.UseVisualStyleBackColor = true
        '
        'lScreens
        '
        Me.lScreens.Location = New System.Drawing.Point(6, 16)
        Me.lScreens.Name = "lScreens"
        Me.lScreens.Size = New System.Drawing.Size(105, 20)
        Me.lScreens.TabIndex = 23
        Me.lScreens.Text = "Schermen:"
        Me.lScreens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGreen
        '
        Me.btnGreen.Location = New System.Drawing.Point(218, 15)
        Me.btnGreen.Name = "btnGreen"
        Me.btnGreen.Size = New System.Drawing.Size(75, 23)
        Me.btnGreen.TabIndex = 24
        Me.btnGreen.Text = "Groen"
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
        Me.OpenLogoQuestion.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenBackground
        '
        Me.OpenBackground.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenNormal
        '
        Me.OpenNormal.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenClick
        '
        Me.OpenClick.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenHover
        '
        Me.OpenHover.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenLogoIntro
        '
        Me.OpenLogoIntro.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenBackgroundIntro
        '
        Me.OpenBackgroundIntro.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenGreen
        '
        Me.OpenGreen.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenRed
        '
        Me.OpenRed.Filter = "Alle afbeeldingen|*.*"
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
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSave
        '
        Me.ToolStripSave.Image = CType(resources.GetObject("ToolStripSave.Image"),System.Drawing.Image)
        Me.ToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSave.Name = "ToolStripSave"
        Me.ToolStripSave.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripSave.Text = "Opslaan"
        '
        'ToolStripOpen
        '
        Me.ToolStripOpen.Image = CType(resources.GetObject("ToolStripOpen.Image"),System.Drawing.Image)
        Me.ToolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripOpen.Name = "ToolStripOpen"
        Me.ToolStripOpen.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripOpen.Text = "Openen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripExport
        '
        Me.ToolStripExport.Image = CType(resources.GetObject("ToolStripExport.Image"),System.Drawing.Image)
        Me.ToolStripExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripExport.Name = "ToolStripExport"
        Me.ToolStripExport.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripExport.Text = "Exporteren"
        '
        'OpenTheme
        '
        Me.OpenTheme.Filter = "WIDM thema's (.widmthema)|*.widmthema"
        '
        'rMusicTest
        '
        Me.rMusicTest.AutoSize = true
        Me.rMusicTest.Location = New System.Drawing.Point(136, 19)
        Me.rMusicTest.Name = "rMusicTest"
        Me.rMusicTest.Size = New System.Drawing.Size(15, 14)
        Me.rMusicTest.TabIndex = 30
        Me.ToolTip.SetToolTip(Me.rMusicTest, "Laat een logo linksboven zien voor de vraag")
        Me.rMusicTest.UseVisualStyleBackColor = true
        '
        'rMusicExecution
        '
        Me.rMusicExecution.AutoSize = true
        Me.rMusicExecution.Location = New System.Drawing.Point(136, 51)
        Me.rMusicExecution.Name = "rMusicExecution"
        Me.rMusicExecution.Size = New System.Drawing.Size(15, 14)
        Me.rMusicExecution.TabIndex = 29
        Me.ToolTip.SetToolTip(Me.rMusicExecution, "Gebruik achtergrondafbeelding tijdens de test")
        Me.rMusicExecution.UseVisualStyleBackColor = true
        '
        'FontIntroText
        '
        Me.FontIntroText.ShowColor = true
        '
        'FontIntroTextfield
        '
        Me.FontIntroTextfield.ShowColor = true
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
        Me.grpMusic.Location = New System.Drawing.Point(395, 28)
        Me.grpMusic.Name = "grpMusic"
        Me.grpMusic.Size = New System.Drawing.Size(364, 88)
        Me.grpMusic.TabIndex = 29
        Me.grpMusic.TabStop = false
        Me.grpMusic.Text = "Muziek"
        '
        'btnMusicExecution
        '
        Me.btnMusicExecution.Location = New System.Drawing.Point(283, 47)
        Me.btnMusicExecution.Name = "btnMusicExecution"
        Me.btnMusicExecution.Size = New System.Drawing.Size(75, 23)
        Me.btnMusicExecution.TabIndex = 32
        Me.btnMusicExecution.Text = "Bladeren..."
        Me.btnMusicExecution.UseVisualStyleBackColor = true
        '
        'btnMusicTest
        '
        Me.btnMusicTest.Location = New System.Drawing.Point(283, 14)
        Me.btnMusicTest.Name = "btnMusicTest"
        Me.btnMusicTest.Size = New System.Drawing.Size(75, 23)
        Me.btnMusicTest.TabIndex = 31
        Me.btnMusicTest.Text = "Bladeren..."
        Me.btnMusicTest.UseVisualStyleBackColor = true
        '
        'txtMusicExecution
        '
        Me.txtMusicExecution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMusicExecution.Enabled = false
        Me.txtMusicExecution.Location = New System.Drawing.Point(165, 48)
        Me.txtMusicExecution.Name = "txtMusicExecution"
        Me.txtMusicExecution.Size = New System.Drawing.Size(106, 20)
        Me.txtMusicExecution.TabIndex = 5
        '
        'txtMusicTest
        '
        Me.txtMusicTest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMusicTest.Enabled = false
        Me.txtMusicTest.Location = New System.Drawing.Point(165, 16)
        Me.txtMusicTest.Name = "txtMusicTest"
        Me.txtMusicTest.Size = New System.Drawing.Size(106, 20)
        Me.txtMusicTest.TabIndex = 4
        '
        'lMusicExecution
        '
        Me.lMusicExecution.Location = New System.Drawing.Point(7, 49)
        Me.lMusicExecution.Name = "lMusicExecution"
        Me.lMusicExecution.Size = New System.Drawing.Size(144, 20)
        Me.lMusicExecution.TabIndex = 5
        Me.lMusicExecution.Text = "Muziek tijdens executie:"
        Me.lMusicExecution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lMusicTest
        '
        Me.lMusicTest.Location = New System.Drawing.Point(7, 17)
        Me.lMusicTest.Name = "lMusicTest"
        Me.lMusicTest.Size = New System.Drawing.Size(114, 20)
        Me.lMusicTest.TabIndex = 4
        Me.lMusicTest.Text = "Muziek tijdens test:"
        Me.lMusicTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColorClick
        '
        Me.ColorClick.FullOpen = true
        '
        'OpenQuestionBackground
        '
        Me.OpenQuestionBackground.Filter = "Alle afbeeldingen|*.*"
        '
        'OpenMusicTest
        '
        Me.OpenMusicTest.Filter = "Alle muziek|*.*"
        '
        'OpenMusicExecution
        '
        Me.OpenMusicExecution.Filter = "Alle muziek|*.*"
        '
        'SaveExport
        '
        Me.SaveExport.Filter = "(*.zip)|*.zip"
        '
        'FrmTheme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(937, 561)
        Me.Controls.Add(Me.grpMusic)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpScreens)
        Me.Controls.Add(Me.grpIntro)
        Me.Controls.Add(Me.grpExample)
        Me.Controls.Add(Me.grpQuestion)
        Me.Controls.Add(Me.grpGeneral)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "FrmTheme"
        Me.Text = "WIDM Exam"
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
