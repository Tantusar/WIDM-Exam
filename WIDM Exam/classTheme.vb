Imports System.Drawing.Text
Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptOut)>
Public Class Theme
    Dim _afbeeldingenFolder = CurDir() & "\Afbeeldingen"

    Enum Style
        NewStyle
        Old
        Us
        Belgium
    End Enum

    Enum Position
        TopLeft
        TopRight
    End Enum

    Public Name As String
    Public Author As String

    Public FontQuestion As Font
    Public ColorQuestion As Color

    Public FontAnswers As Font
    Public ColorAnswers As Color

    Public FontIntroText As Font
    Public ColorIntroText As Color

    Public FontIntroTextfield As Font
    Public ColorIntroTextfield As Color

    Public LogoTestEnabled As Boolean
    Public LogoTest As String ' = Image.FromFile(CurDir() & "\" & name & "\logoTest.png")
    Public LogoTestPosition As Position = Position.TopLeft
    Public LogoIntroEnabled As Boolean
    Public LogoIntro As String ' = Image.FromFile(CurDir() & "\" & name & "\logoIntro.png")
    Public LogoIntroPosition As Position = Position.TopLeft

    Public BackgroundTestEnabled As Boolean
    Public BackgroundTest As String ' = Image.FromFile(CurDir() & "\" & name & "\backgroundTest.png")
    Public BackgroundTestSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.Zoom
    Public BackgroundIntroEnabled As Boolean
    Public BackgroundIntro As String ' = Image.FromFile(CurDir() & "\" & name & "\backgroundIntro.png")
    Public BackgroundIntroSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.Zoom

    Public BackgroundColorTest As Color
    Public BackgroundColorIntro As Color

    Public QuestionAlignment As ContentAlignment = ContentAlignment.MiddleLeft
    Public QuestionBackgroundEnabled As Boolean
    Public QuestionBackground As String

    Public Button As String ' = Image.FromFile(CurDir() & "\" & name & "\button.png")
    Public ButtonClick As String ' = Image.FromFile(CurDir() & "\" & name & "\buttonClick.png")
    Public ColorClickEnabled As Boolean
    Public ColorClick As Color
    Public ButtonHoverEnabled As Boolean
    Public ButtonHover As String ' = Image.FromFile(CurDir() & "\" & name & "\buttonHover.png")

    Public GreenScreen As String ' = Image.FromFile(CurDir() & "\" & name & "green.png")
    Public RedScreen As String ' = Image.FromFile(CurDir() & "\" & name & "red.png")

    Public IntroStyle As Style

    Public MusicTestEnabled As Boolean
    Public MusicTest As String
    Public MusicExecutionEnabled As Boolean
    Public MusicExecution As String

    Function IsFontInstalled(ByVal font As String) As Boolean
        Dim fontFamilies() As FontFamily

        Dim installedFontCollection As New InstalledFontCollection()

        ' Get the array of FontFamily objects.
        fontFamilies = installedFontCollection.Families

        ' The loop below creates a large string that is a comma-separated
        ' list of all font family names.
        For Each family In fontFamilies
            If family.Name = font Then
                Return True
            End If
        Next
        Return False
    End Function

    Function IsFontInstalled() As Boolean
        If IsFontInstalled(FontQuestion.OriginalFontName) And IsFontInstalled(FontAnswers.OriginalFontName) And IsFontInstalled(FontIntroText.OriginalFontName) And IsFontInstalled(FontIntroTextfield.OriginalFontName) Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub New()

    End Sub

    Sub New(_name As String)
        Name = _name
    End Sub

    <JsonIgnore()> ReadOnly Property ImgLogoTest As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & LogoTest)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgLogoIntro As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & LogoIntro)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgBackgroundTest As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & BackgroundTest)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgBackgroundIntro As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & BackgroundIntro)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgQuestionBackground As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & QuestionBackground)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgButton As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & Button)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgButtonClick As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & ButtonClick)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgButtonHover As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & ButtonHover)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgGreenScreen As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & GreenScreen)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property ImgRedScreen As Image
        Get
            Try
                Return Image.FromFile(_afbeeldingenFolder & RedScreen)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property
End Class
