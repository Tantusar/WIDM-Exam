Public Class Test
    Dim strMoleText As String
    Dim strAuthor As String
    Dim strComment As String

    Sub New()

    End Sub

    Sub New(_author As String, _comment As String, _questions As Question(), ByVal _moleText As String)
        author = _author
        comment = _comment
        questions = _questions
        moleText = _moleText
    End Sub

    Property author As String
        Get
            Return strAuthor
        End Get
        Set(value As String)
            strAuthor = value
        End Set
    End Property

    Property comment As String
        Get
            Return strComment
        End Get
        Set(value As String)
            strComment = value
        End Set
    End Property

    Public questions As Question()

    Property moleText As String
        Get
            Return strMoleText
        End Get
        Set(value As String)
            strMoleText = value
        End Set
    End Property
End Class
