Public Class Test
    Dim _strMoleText As String
    Dim _strAuthor As String
    Dim _strComment As String

    Sub New()

    End Sub

    Sub New(_author As String, _comment As String, _questions As Question(), ByVal _moleText As String)
        author = _author
        comment = _comment
        questions = _questions
        moleText = _moleText
    End Sub

    Property Author As String
        Get
            Return _strAuthor
        End Get
        Set(value As String)
            _strAuthor = value
        End Set
    End Property

    Property Comment As String
        Get
            Return _strComment
        End Get
        Set(value As String)
            _strComment = value
        End Set
    End Property

    Public Questions As Question()

    Property MoleText As String
        Get
            Return _strMoleText
        End Get
        Set(value As String)
            _strMoleText = value
        End Set
    End Property
End Class
