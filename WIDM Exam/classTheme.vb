<Serializable()> Public Class Theme
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
    Public logoTest As Image' = Image.FromFile(CurDir() & "\" & name & "\logoTest.png")
    Public logoIntroEnabled As Boolean
    Public logoIntro As Image' = Image.FromFile(CurDir() & "\" & name & "\logoIntro.png")
    
    Public backgroundTestEnabled As Boolean
    Public backgroundTest As Image' = Image.FromFile(CurDir() & "\" & name & "\backgroundTest.png")
    Public backgroundIntroEnabled As Boolean
    Public backgroundIntro As Image' = Image.FromFile(CurDir() & "\" & name & "\backgroundIntro.png")

    Public backgroundColorTest As Color
    Public backgroundColorIntro As Color

    Public questionAlignment As ContentAlignment = ContentAlignment.MiddleLeft
    Public questionBackgroundEnabled As Boolean
    Public questionBackground As Image

    Public button As Image' = Image.FromFile(CurDir() & "\" & name & "\button.png")
    Public buttonClick As Image' = Image.FromFile(CurDir() & "\" & name & "\buttonClick.png")
    Public colorClickEnabled As Boolean
    Public colorClick As Color
    Public buttonHoverEnabled As Boolean
    Public buttonHover As Image' = Image.FromFile(CurDir() & "\" & name & "\buttonHover.png")

    Public greenScreen As Image' = Image.FromFile(CurDir() & "\" & name & "green.png")
    Public redScreen As Image' = Image.FromFile(CurDir() & "\" & name & "red.png")

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
End Class
