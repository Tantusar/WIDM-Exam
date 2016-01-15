Imports Newtonsoft.Json

<JsonObject(MemberSerialization.OptOut)>
 Public Class Theme
    Dim AfbeeldingenFolder = CurDir() & "\Afbeeldingen"

    Enum Style
        NewStyle
        Old
        US
    End Enum

    Public name As String
    Public author As String

    Public fontQuestion As Font
    Public colorQuestion As Color

    Public fontAnswers As Font
    Public colorAnswers As Color

    Public fontIntroText As Font
    Public colorIntroText As Color

    Public fontIntroTextfield As Font
    Public colorIntroTextfield As Color

    Public logoTestEnabled As Boolean
    Public logoTest As String ' = Image.FromFile(CurDir() & "\" & name & "\logoTest.png")
    Public logoIntroEnabled As Boolean
    Public logoIntro As String ' = Image.FromFile(CurDir() & "\" & name & "\logoIntro.png")

    Public backgroundTestEnabled As Boolean
    Public backgroundTest As String ' = Image.FromFile(CurDir() & "\" & name & "\backgroundTest.png")
    Public backgroundIntroEnabled As Boolean
    Public backgroundIntro As String ' = Image.FromFile(CurDir() & "\" & name & "\backgroundIntro.png")

    Public backgroundColorTest As Color
    Public backgroundColorIntro As Color

    Public questionAlignment As ContentAlignment = ContentAlignment.MiddleLeft
    Public questionBackgroundEnabled As Boolean
    Public questionBackground As String

    Public button As String ' = Image.FromFile(CurDir() & "\" & name & "\button.png")
    Public buttonClick As String ' = Image.FromFile(CurDir() & "\" & name & "\buttonClick.png")
    Public colorClickEnabled As Boolean
    Public colorClick As Color
    Public buttonHoverEnabled As Boolean
    Public buttonHover As String ' = Image.FromFile(CurDir() & "\" & name & "\buttonHover.png")

    Public greenScreen As String ' = Image.FromFile(CurDir() & "\" & name & "green.png")
    Public redScreen As String ' = Image.FromFile(CurDir() & "\" & name & "red.png")

    Public introStyle As Style

    Public musicTestEnabled As Boolean
    Public musicTest As String
    Public musicExecutionEnabled As Boolean
    Public musicExecution As String

    Sub New()

    End Sub

    Sub New(_name As String)
        name = _name
    End Sub

    <JsonIgnore()> ReadOnly Property imgLogoTest As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & logoTest)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgLogoIntro As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & logoIntro)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgBackgroundTest As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & backgroundTest)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgBackgroundIntro As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & backgroundIntro)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgQuestionBackground As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & questionBackground)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgButton As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & button)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgButtonClick As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & buttonClick)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgButtonHover As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & buttonHover)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgGreenScreen As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & greenScreen)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property

    <JsonIgnore()> ReadOnly Property imgRedScreen As Image
        Get
            Try
                Return Image.FromFile(AfbeeldingenFolder & redScreen)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return Nothing
            End Try
        End Get
    End Property
End Class
