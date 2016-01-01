Imports System.Runtime.CompilerServices

Module Extensions
    <Extension()> _
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub
End Module
