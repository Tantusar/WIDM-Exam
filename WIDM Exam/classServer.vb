'Imports System.IO
'Imports System.Net
'Imports System.Net.Sockets
'Imports System.Text
'Imports System.Threading
'Imports Newtonsoft.Json
'Imports tcpServer

'Class Host
'    Public Delegate Sub invokeDelegate()

'    Sub New()
'        'Import tcpServer.dll
'        Dim TCPServer As New tcpServer.TcpServer
'        TCPServer.Port = 9255

'        TCPServer.Open()
'        AddHandler TCPServer.OnDataAvailable, AddressOf tcpServer_OnDataAvailable
'    End Sub


'    Public Sub logData(text As String)
'        Dim tempObject As Object = JsonConvert.DeserializeObject(text)
'        If tempObject("Type") = "GivenAnswer" Then
'            Dim answer As GivenAnswer = JsonConvert.DeserializeObject(tempObject("Data").ToString())
'            CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).Answers.Add(answer)
'        ElseIf tempObject("Type") = "ExecutionResult" Then
'            Dim result As ExecutionResult = JsonConvert.DeserializeObject(tempObject("Data").ToString())
'            If CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults.ContainsKey(result.Candidate) Then
'                CurrentGroup.ExecutionRemove(result.Candidate)
'            End If
'            CurrentGroup.Episodes(CurrentGroup.CurrentEpisode).ExecutionResults.Add(result.Candidate, result)
'        End If
'        ReloadDataviews()
'    End Sub

'    Private Sub tcpServer_OnDataAvailable(ByVal connection As TcpServerConnection)

'        Dim data As Byte() = readStream(connection.Socket)

'        If data IsNot Nothing Then
'            Dim dataStr As String = Encoding.ASCII.GetString(data)

'            Dim del As invokeDelegate = Sub()
'                                            logData(dataStr)

'                                        End Sub
'            del.Invoke()

'            data = Nothing
'        End If

'    End Sub


'    Protected Function readStream(client As TcpClient) As Byte()
'        Dim stream As NetworkStream = client.GetStream()
'        If stream.DataAvailable Then
'            Dim data As Byte() = New Byte(client.Available - 1) {}

'            Dim bytesRead As Integer = 0
'            Try
'                bytesRead = stream.Read(data, 0, data.Length)
'            Catch generatedExceptionName As IOException
'            End Try

'            If bytesRead < data.Length Then
'                Dim lastData As Byte() = data
'                data = New Byte(bytesRead - 1) {}
'                Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead)
'            End If
'            Return data
'        End If
'        Return Nothing
'    End Function
'End Class

'Class Client

'    Private _client As TcpClient

'    Private _sReader As StreamReader
'    Private _sWriter As StreamWriter

'    Private _isConnected As [Boolean]

'    Public Sub New(ipAddress As [String], portNum As Integer, message As [String])
'        Try


'            _client = New TcpClient()
'            _client.Connect(ipAddress, portNum)


'            HandleCommunication(message)


'        Catch ex As Exception

'        End Try
'    End Sub

'    Public Sub HandleCommunication(ByVal sData As String)
'        _sReader = New StreamReader(_client.GetStream(), Encoding.ASCII)
'        _sWriter = New StreamWriter(_client.GetStream(), Encoding.ASCII)

'        _isConnected = True
'        'Dim sData As [String] = Nothing
'        While _isConnected
'            'Console.Write("&gt; ")
'            'sData = Console.ReadLine()

'            ' write data and make sure to flush, or the buffer will continue to 
'            ' grow, and your data might not be sent when you want it, and will
'            ' only be sent once the buffer is filled.
'            _sWriter.WriteLine(sData)

'            ' if you want to receive anything
'            ' String sDataIncomming = _sReader.ReadLine();
'            _sWriter.Flush()

'            _client.Close()
'            _isConnected = False
'        End While
'    End Sub
'End Class
