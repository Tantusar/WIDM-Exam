Class ListViewItemComparerInteger
    Implements IComparer

    Private ReadOnly col As Integer
    Private ReadOnly col2 As Integer
    Private ReadOnly order As SortOrder

    Public Sub New(column As Integer, column2 As Integer, order As SortOrder)
        col = column
        col2 = column2
        Me.order = order
    End Sub


    Public Function Compare(x As Object, y As Object) As Integer _
        Implements IComparer.Compare
        Dim returnVal As Integer = - 1
        returnVal = (Val(CType(x, ListViewItem).SubItems(col).Text) + Val(CType(x, ListViewItem).SubItems(col2).Text)).
            CompareTo(
                (Val(CType(y, ListViewItem).SubItems(col).Text) + Val(CType(y, ListViewItem).SubItems(col2).Text)))

        If order = SortOrder.Descending Then
            ' Invert the value returned by String.Compare.
            returnVal *= - 1
        End If

        Return returnVal
    End Function
End Class
