Public Class Question
    'Vraag
    Dim _strQuestion As String
    Public Answers As Answer()
    Dim _strRightAnswer As String
    Dim _intQuestionPoints As Integer = 0

    'Tekst tussendoor
    Dim _strText1 As String
    Dim _strText2 As String
    
    Sub New()
        
    End Sub

    Sub New(_text As String, _answers As Answer(), _rightAnswer As String, ByVal questionPoints As Integer)
        text = _text
        answers = _answers
        rightAnswer = _rightAnswer
        points = questionPoints
    End Sub

    Sub New(_text1 As String, _text2 As String)
        text1 = _text1
        text2 = _text2
    End Sub

    Property Text As String
        Get
            Return _strQuestion
        End Get
        Set
            _strQuestion = value
        End Set
    End Property

    Property RightAnswer As String
        Get
            Return _strRightAnswer
        End Get
        Set
            _strRightAnswer = value
        End Set
    End Property

    Property Points As Integer
        Get
            Return _intQuestionPoints
        End Get
        Set(value As Integer)
            _intQuestionPoints = value 
        End Set
    End Property

    Property Text1 As String
        Get
            Return _strText1
        End Get
        Set
            _strText1 = value
        End Set
    End Property

    Property Text2 As String
        Get
            Return _strText2
        End Get
        Set
            _strText2 = value
        End Set
    End Property
End Class
