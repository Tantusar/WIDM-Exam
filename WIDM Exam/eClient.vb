Imports System.Net.Sockets
Imports System.Text

Module eClient
    Dim ReadOnly clientSocket As New TcpClient()
    Dim serverStream As NetworkStream

    Public Sub SendMessage()
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        Dim buffSize As Integer
        Dim outStream As Byte() =
                Encoding.ASCII.GetBytes("Message from Client$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()

        Dim inStream(10024) As Byte
        buffSize = clientSocket.ReceiveBufferSize
        serverStream.Read(inStream, 0, buffSize)
        Dim returndata As String =
                Encoding.ASCII.GetString(inStream)
        msg("Data from Server : " + returndata)
    End Sub

    Public Sub StartClient()
        msg("Client Started")
        clientSocket.Connect(FrmOpenTest.txtIP.Text, FrmOpenTest.numPort.Value)
        'Label1.Text = "Client Socket Program - Server Connected ..."
    End Sub

    Public Sub StopClient()
        clientSocket.Close()
    End Sub

    Sub msg(mesg As String)
        FrmOpenTest.txtLogClient.Text = FrmOpenTest.txtLogClient.Text + Environment.NewLine + " >> " + mesg
    End Sub
End Module
