Imports System.Runtime.CompilerServices

Module Extensions
    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub

    <System.Runtime.CompilerServices.Extension()>
    Public Sub RemoveAt(Of T)(ByRef arr As T(), ByVal index As Integer)
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException(
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            arr = outArr
        End If
    End Sub

<Extension()>
Function Randomize(Of T)(ByVal list As List(Of T)) As List(Of T)
    Dim rand As New Random()
    Dim temp As T
    Dim indexRand As Integer
    Dim indexLast As Integer = list.Count - 1
    For index As Integer = 0 To indexLast
        indexRand = rand.Next(index, indexLast)
        temp = list(indexRand)
        list(indexRand) = list(index)
        list(index) = temp
    Next index
    Return list
End Function
End Module
