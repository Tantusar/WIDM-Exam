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

    Public logoTest As Image' = Image.FromFile(CurDir() & "\" & name & "\logoTest.png")
    Public logoIntro As Image' = Image.FromFile(CurDir() & "\" & name & "\logoIntro.png")
    
    Public backgroundTestEnabled As Boolean
    Public backgroundTest As Image' = Image.FromFile(CurDir() & "\" & name & "\backgroundTest.png")
    Public backgroundIntroEnabled As Boolean
    Public backgroundIntro As Image' = Image.FromFile(CurDir() & "\" & name & "\backgroundIntro.png")

    Public backgroundColorTest As Color
    Public backgroundColorIntro As Color

    Public button As Image' = Image.FromFile(CurDir() & "\" & name & "\button.png")
    Public buttonClick As Image' = Image.FromFile(CurDir() & "\" & name & "\buttonClick.png")
    Public buttonHoverEnabled As Boolean
    Public buttonHover As Image' = Image.FromFile(CurDir() & "\" & name & "\buttonHover.png")

    Public greenScreen As Image' = Image.FromFile(CurDir() & "\" & name & "green.png")
    Public redScreen As Image' = Image.FromFile(CurDir() & "\" & name & "red.png")

    Public introStyle As Style

    Sub New()
        
    End Sub

    Sub New(_name As String)
        name = _name
    End Sub
End Class
