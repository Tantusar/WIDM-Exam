Public Class Question
    'Vraag
    Dim strQuestion As String
    Public answers As Answer()
    Dim strRightAnswer As String
    Dim intQuestionPoints As Integer = 0

    'Tekst tussendoor
    Dim strText1 As String
    Dim strText2 As String

    Sub New(_text As String, _answers As Answer(), _rightAnswer As String, ByVal _questionPoints As Integer)
        text = _text
        answers = _answers
        rightAnswer = _rightAnswer
        points = _questionPoints
    End Sub

    Sub New(_text1 As String, _text2 As String)
        text1 = _text1
        text2 = _text2
    End Sub

    Property text As String
        Get
            Return strQuestion
        End Get
        Set
            strQuestion = value
        End Set
    End Property

    Property rightAnswer As String
        Get
            Return strRightAnswer
        End Get
        Set
            strRightAnswer = value
        End Set
    End Property

    Property points As Integer
        Get
            Return intQuestionPoints
        End Get
        Set(value As Integer)
            intQuestionPoints = value 
        End Set
    End Property

    Property text1 As String
        Get
            Return strText1
        End Get
        Set
            strText1 = value
        End Set
    End Property

    Property text2 As String
        Get
            Return strText2
        End Get
        Set
            strText2 = value
        End Set
    End Property
End Class
