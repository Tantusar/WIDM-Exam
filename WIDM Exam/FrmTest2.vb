Imports System.IO
Imports System.Xml
Public Class FrmTest2
    Private amountquestions As Integer
    Dim document As XmlReader = New XmlTextReader("C:\Users\Koen\Documents\WIDM Software\Testen\v2\test.txt")
    Private Sub loadQuestionAnwers()
        While (document.Read())

            Dim type = document.NodeType

            If (type = XmlNodeType.Element) Then

                If (document.Name = "amountofquestions") Then
                    amountquestions = amountquestions.ToString
                End If
                MessageBox.Show(amountquestions)
            End If

        End While
        document.Close()
    End Sub
    Private Sub FrmTest2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.Sleep(500)
        loadQuestionAnwers()
    End Sub
End Class