Public Class Answer
    Dim _intId As Integer
    Dim _strAnswer As String

    Sub New()

    End Sub

    Sub New(_id As Integer, _text As String)
        id = _id
        text = _text
    End Sub

    Property Id As Integer
        Get
            Return _intId
        End Get
        Set
            _intId = Value
        End Set
    End Property

    Property Text As String
        Get
            Return _strAnswer
        End Get
        Set
            _strAnswer = Value
        End Set
    End Property
End Class
