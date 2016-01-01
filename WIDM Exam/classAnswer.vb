Public Class Answer
    Dim intId As Integer
    Dim strAnswer As String

    Sub New(_id As Integer, _text As String)
        id = _id
        text = _text
    End Sub

    Property id As Integer
        Get
            Return intId
        End Get
        Set
            intId = value
        End Set
    End Property

    Property text As String
        Get
            Return strAnswer
        End Get
        Set
            strAnswer = value
        End Set
    End Property
End Class
