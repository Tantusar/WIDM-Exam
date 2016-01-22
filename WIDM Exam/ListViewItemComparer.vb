'https://msdn.microsoft.com/en-us/library/ms996467.aspx

Class ListViewItemComparer
    Implements IComparer
    Private ReadOnly _col As Integer
    Private ReadOnly _order As SortOrder

    Public Sub New()
        _col = 0
        _order = SortOrder.Ascending
    End Sub

    Public Sub New(column As Integer, order As SortOrder)
        _col = column
        Me._order = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer _
        Implements IComparer.Compare
        Dim returnVal As Integer = - 1
        returnVal = [String].Compare(CType(x,
                                           ListViewItem).SubItems(_col).Text,
                                     CType(y, ListViewItem).SubItems(_col).Text)
        ' Determine whether the sort order is descending.
        If _order = SortOrder.Descending Then
            ' Invert the value returned by String.Compare.
            returnVal *= - 1
        End If

        Return returnVal
    End Function
End Class
