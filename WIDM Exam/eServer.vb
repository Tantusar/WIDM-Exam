Imports System.Collections.Concurrent
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Module EServer
    Private _listener As TcpListener
    Private ReadOnly Connections As New List(Of ConnectionInfo)
    Private _connectionMontior As Task

    Public Sub StartServer()
        _listener = New TcpListener(IPAddress.Any, FrmOpenTest.numPort.Value)
        _listener.Start()
        Dim monitor As New MonitorInfo(_listener, Connections)
        ListenForClient(monitor)
        _connectionMontior = Task.Factory.StartNew(AddressOf DoMonitorConnections, monitor,
                                                  TaskCreationOptions.LongRunning)
    End Sub

    Public Sub StopServer()
        CType(_connectionMontior.AsyncState, MonitorInfo).Cancel = True
        _listener.Stop()
        _listener = Nothing
    End Sub

    Private Sub ListenForClient(monitor As MonitorInfo)
        Dim info As New ConnectionInfo(monitor)
        _listener.BeginAcceptTcpClient(AddressOf DoAcceptClient, info)
    End Sub

    Private Sub DoAcceptClient(result As IAsyncResult)
        Dim monitorInfo = CType(_connectionMontior.AsyncState, MonitorInfo)
        If monitorInfo.Listener IsNot Nothing AndAlso Not monitorInfo.Cancel Then
            Dim info = CType(result.AsyncState, ConnectionInfo)
            monitorInfo.Connections.Add(info)
            info.AcceptClient(result)
            ListenForClient(monitorInfo)
            info.AwaitData()
            Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
            doUpdateConnectionCountLabel()
        End If
    End Sub

    Private Sub DoMonitorConnections()
        'Create delegate for updating output display
        Dim doAppendOutput As New Action(Of String)(AddressOf AppendOutput)
        'Create delegate for updating connection count label
        Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)

        'Get MonitorInfo instance from thread-save Task instance
        Dim monitorInfo = CType(_connectionMontior.AsyncState, MonitorInfo)

        'Report progress
        doAppendOutput("Monitor Started.")

        'Implement client connection processing loop
        Do
            'Create temporary list for recording closed connections
            Dim lostCount = 0
            'Examine each connection for processing
            For index As Integer = monitorInfo.Connections.Count - 1 To 0 Step - 1
                Dim info As ConnectionInfo = monitorInfo.Connections(index)
                If info.Client.Connected Then
                    'Process connected client
                    If info.DataQueue.Count > 0 Then
                        'The code in this If-Block should be modified to build 'message' objects
                        'according to the protocol you defined for your data transmissions.
                        'This example simply sends all pending message bytes to the output textbox.
                        'Without a protocol we cannot know what constitutes a complete message, so
                        'with multiple active clients we could see part of client1's first message,
                        'then part of a message from client2, followed by the rest of client1's
                        'first message (assuming client1 sent more than 64 bytes).
                        Dim messageBytes As New List(Of Byte)
                        While info.DataQueue.Count > 0
                            Dim value As Byte
                            If info.DataQueue.TryDequeue(value) Then
                                messageBytes.Add(value)
                            End If
                        End While
                        doAppendOutput(Encoding.ASCII.GetString(messageBytes.ToArray))
                    End If
                Else
                    'Clean-up any closed client connections
                    monitorInfo.Connections.Remove(info)
                    lostCount += 1
                End If
            Next
            If lostCount > 0 Then
                doUpdateConnectionCountLabel()
            End If

            'Throttle loop to avoid wasting CPU time
            _connectionMontior.Wait(1)
        Loop While Not monitorInfo.Cancel

        'Close all connections before exiting monitor
        For Each info As ConnectionInfo In monitorInfo.Connections
            info.Client.Close()
        Next
        monitorInfo.Connections.Clear()

        'Update the connection count label and report status
        doUpdateConnectionCountLabel()
        doAppendOutput("Monitor Stopped.")
    End Sub

    Private Sub AppendOutput(message As String)
        If FrmOpenTest.txtLogServer.TextLength > 0 Then
            FrmOpenTest.txtLogServer.AppendText(ControlChars.NewLine)
        End If
        FrmOpenTest.txtLogServer.AppendText(message)
        FrmOpenTest.txtLogServer.ScrollToCaret()
    End Sub

    Private Sub UpdateConnectionCountLabel()
        FrmOpenTest.txtConnectedCount.Text = String.Format("{0} Connections", Connections.Count)
    End Sub
End Module

'Provides a simple container object to be used for the state object passed to the connection monitoring thread
Public Class MonitorInfo
    Public Property Cancel As Boolean

    Private ReadOnly _connections As List(Of ConnectionInfo)

    Public ReadOnly Property Connections As List(Of ConnectionInfo)
        Get
            Return _Connections
        End Get
    End Property

    Private ReadOnly _listener As TcpListener

    Public ReadOnly Property Listener As TcpListener
        Get
            Return _Listener
        End Get
    End Property

    Public Sub New(tcpListener As TcpListener, connectionInfoList As List(Of ConnectionInfo))
        _Listener = tcpListener
        _Connections = connectionInfoList
    End Sub
End Class

'Provides a container object to serve as the state object for async client and stream operations
Public Class ConnectionInfo
    'hold a reference to entire monitor instead of just the listener
    Private ReadOnly _monitor As MonitorInfo

    Public ReadOnly Property Monitor As MonitorInfo
        Get
            Return _Monitor
        End Get
    End Property

    Private _client As TcpClient

    Public ReadOnly Property Client As TcpClient
        Get
            Return _Client
        End Get
    End Property

    Private _stream As NetworkStream

    Public ReadOnly Property Stream As NetworkStream
        Get
            Return _Stream
        End Get
    End Property

    Private ReadOnly _dataQueue As ConcurrentQueue(Of Byte)

    Public ReadOnly Property DataQueue As ConcurrentQueue(Of Byte)
        Get
            Return _DataQueue
        End Get
    End Property

    Private _lastReadLength As Integer

    Public ReadOnly Property LastReadLength As Integer
        Get
            Return _LastReadLength
        End Get
    End Property

    'The buffer size is an arbitrary value which should be selected based on the
    'amount of data you need to transmit, the rate of transmissions, and the
    'anticipalted number of clients. These are the considerations for designing
    'the communicaition protocol for data transmissions, and the size of the read
    'buffer must be based upon the needs of the protocol.
    Private ReadOnly _buffer(63) As Byte

    Public Sub New(monitor As MonitorInfo)
        _Monitor = monitor
        _DataQueue = New ConcurrentQueue(Of Byte)
    End Sub

    Public Sub AcceptClient(result As IAsyncResult)
        _Client = _Monitor.Listener.EndAcceptTcpClient(result)
        If _Client IsNot Nothing AndAlso _Client.Connected Then
            _Stream = _Client.GetStream
        End If
    End Sub

    Public Sub AwaitData()
        _Stream.BeginRead(_Buffer, 0, _Buffer.Length, AddressOf DoReadData, Me)
    End Sub

    Private Sub DoReadData(result As IAsyncResult)
        Dim info = CType(result.AsyncState, ConnectionInfo)
        Try
            'If the stream is valid for reading, get the current data and then
            'begin another async read
            If info.Stream IsNot Nothing AndAlso info.Stream.CanRead Then
                info._LastReadLength = info.Stream.EndRead(result)
                For index = 0 To _LastReadLength - 1
                    info._DataQueue.Enqueue(info._Buffer(index))
                Next

                'The example responds to all data reception with the number of bytes received;
                'you would likely change this behavior when implementing your own protocol.
                info.SendMessage("Received " & info._LastReadLength & " Bytes")

                For Each otherInfo As ConnectionInfo In info.Monitor.Connections
                    If Not otherInfo Is info Then
                        otherInfo.SendMessage(Encoding.ASCII.GetString(info._Buffer))
                    End If
                Next

                info.AwaitData()
            Else
                'If we cannot read from the stream, the example assumes the connection is
                'invalid and closes the client connection. You might modify this behavior
                'when implementing your own protocol.
                info.Client.Close()
            End If
        Catch ex As Exception
            info._LastReadLength = - 1
        End Try
    End Sub

    Private Sub SendMessage(message As String)
        If _Stream IsNot Nothing Then
            Dim messageData() As Byte = Encoding.ASCII.GetBytes(message)
            Stream.Write(messageData, 0, messageData.Length)
        End If
    End Sub
End Class
