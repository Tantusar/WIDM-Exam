Imports ComponentOwl.BetterListView

Class ExecutionItemComparer
    Inherits BetterListViewItemComparer

    Public Overrides Function Compare(itemA As BetterListViewItem, itemB As BetterListViewItem) As Integer

        If itemA IsNot Nothing AndAlso itemB IsNot Nothing Then
            Dim jokersA As Integer = 0
            Dim jokersB As Integer = 0

            If itemA.SubItems(4).Text = FrmOpenTest.Vrijstelling Then
                jokersA = 214748364
            Else
                jokersA = CInt(itemA.SubItems(4).Text)
            End If

            If itemB.SubItems(4).Text = FrmOpenTest.Vrijstelling Then
                jokersB = 214748364
            Else
                jokersB = CInt(itemB.SubItems(4).Text)
            End If

            If itemA.SubItems(2).Text = 0 Then
                itemA.SubItems(2).Text = 1
            End If

            If itemB.SubItems(2).Text = 0 Then
                itemB.SubItems(2).Text = 1
            End If

            Dim valueA As Double = CInt(itemA.SubItems(1).Text) + jokersA + (1 / CDbl(itemA.SubItems(2).Text))

            Dim valueB As Double = CInt(itemB.SubItems(1).Text) + jokersB + (1 / CDbl(itemB.SubItems(2).Text))

            Dim result As Double = valueB.CompareTo(valueA)

            If result <> 0 Then
                Return result
            End If

        End If

        Return MyBase.Compare(itemA, itemB)

    End Function

End Class

Class CandidateItemComparer
    Inherits BetterListViewItemComparer

    Public Overrides Function Compare(itemA As BetterListViewItem, itemB As BetterListViewItem) As Integer

        If itemA IsNot Nothing AndAlso itemB IsNot Nothing Then


            Dim valueA As String = ""
            For Each subItem In itemA.SubItems
                valueA = valueA & "," & subItem.Tag
            Next
            'Console.WriteLine(valueA)

            Dim valueB As String = ""
            For Each subItem In itemB.SubItems
                valueB = valueB & "," & subItem.Tag
            Next

            Dim result As String = valueB.CompareTo(valueA)

            If result <> 0 Then
                Return result
            End If

        End If

        Return MyBase.Compare(itemA, itemB)

    End Function

End Class