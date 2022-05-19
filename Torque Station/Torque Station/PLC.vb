

Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions

Imports System.Net.Sockets
Public Class PLC

#Region "PLC Error Definitions"

    Enum PLCErr
        PLCNoError = 0
        PLCDIError = 1
        PLCDOError = 2
        PLCReadRamError = 3
        PLCWriteRamError = 4
    End Enum
#End Region

#Region "Socket Error Definitions"
    Enum SocketErr
        NoSocketError
        InvalidSocketErrorCode
        AcceptingRemoteSocketError
        SocketCannotBeBound
        BufferOverflows
        SocketCannotBeConnected
        SocketHasBeenDisconnected
        FileLengthDoesNotMatchTheExpectedValue
        FileModificationTimeAndDatesDoNotMatch
        AFileSystemErrorOccurs
        AcquiringSocketOptionError
        CouldNotResolveHostname
        InitializationError
        ListenError
        AcquiringPeerNameError
        UnknownProtocolRequested
        ReceivingError
        RequestTimeout
        UnknownServiceRequested
        IncorrectSocketOptionSettings
        AcquiringSocketNameError
        UnknownSocketTypeRequested
        TransmissionError
    End Enum

#End Region

    ' DMT Declerations 
    Public Shared hDMTDll As System.IntPtr 'handle of a loaded dll ,used for dynamic link -dinamik bağlantı için kullanılan yüklü bir dll'nin tanıtıcısı
    Delegate Sub DelegateClose(ByVal conn_num As Integer) ' function pointer for disconnection-bağlantı kesilmesi için işlev göstergesi
    'DelegateClose : 

    Declare Auto Function LoadLibrary Lib "kernel32.dll" (ByVal dllPath As String) As IntPtr
    Declare Auto Function FreeLibrary Lib "kernel32.dll" (ByVal hDll As IntPtr) As Boolean

    Public Shared CloseModbus As DelegateClose
    Dim ip As Integer

    Dim strDev As String
    Dim dev_qty As Integer
    Dim addr As Integer
    Dim socket_error As Integer
    Dim serial_error As Integer

    Public Shared conn_num As Integer = 0
    Dim status As Integer = 0
    Dim comm_type As Integer = 1 ' 0:RS-232 , 1:Ethernet
    Dim strProduct As String = "DVP"
    Dim slave_addr As Integer = 1

    'Public Shared data_from_dev(7) As UInt32
    Public data_from_dev(7) As UInt32
    Public data_to_dev() As UInt32

    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    'Dim IP_PLC As String = ini.ReadValue("SYSTEM", "IP")
    Dim IP_PLC As String = "192.168.1.200"

    Dim Logger As New LogFile(IO.Directory.GetCurrentDirectory() & "\Logs")

    Public LocalDB As New SQLiteTools("TorqueStation")
    Dim PLCIO As New Dictionary(Of String, String)
    Dim IOTable As DataTable


    Private _plcSocketError As Integer
    Public Event PLCSocketErrorEvent(ByVal socketErrorCode As Integer)
    Public Property SocketError() As Integer
        Get
            SocketError = _plcSocketError
        End Get
        Set(value As Integer)
            _plcSocketError = value
            RaiseEvent PLCSocketErrorEvent(_plcSocketError)
        End Set
    End Property


    Private Sub SocketStatusChangedSub(ByVal errType As Integer) Handles Me.PLCSocketErrorEvent
        Select Case errType

            Case SocketErr.NoSocketError

            Case SocketErr.InvalidSocketErrorCode 'Geçersiz soket hata kodu
                DMT.OpenModbusTCPSocket(conn_num, ip)
            Case SocketErr.AcceptingRemoteSocketError 'Uzak soket hatası kabul ediliyor.
                DMT.OpenModbusTCPSocket(conn_num, ip)
            Case SocketErr.SocketCannotBeBound 'Soket bağlı olamaz

            Case SocketErr.BufferOverflows

            Case SocketErr.SocketCannotBeConnected 'Soket bağlanılamaz
                DMT.OpenModbusTCPSocket(conn_num, ip)

            Case SocketErr.SocketHasBeenDisconnected 'Soket bağlantısı kesildi 
                DMT.OpenModbusTCPSocket(conn_num, ip)

            Case SocketErr.FileLengthDoesNotMatchTheExpectedValue

            Case SocketErr.FileModificationTimeAndDatesDoNotMatch

            Case SocketErr.AFileSystemErrorOccurs

            Case SocketErr.AcquiringSocketOptionError

            Case SocketErr.CouldNotResolveHostname

            Case SocketErr.InitializationError

            Case SocketErr.ListenError

            Case SocketErr.AcquiringPeerNameError

            Case SocketErr.UnknownProtocolRequested

            Case SocketErr.ReceivingError

            Case SocketErr.RequestTimeout

            Case SocketErr.UnknownServiceRequested

            Case SocketErr.IncorrectSocketOptionSettings

            Case SocketErr.AcquiringSocketNameError

            Case SocketErr.UnknownSocketTypeRequested

            Case SocketErr.TransmissionError 'İletim hatası
                DMT.OpenModbusTCPSocket(conn_num, ip)
        End Select

    End Sub


    Private _plcError As Integer = 0
    Public Event PLCErrorEvent(ByVal plcErrorCode As Integer)
    Public Property PLCError() As Integer
        Get
            PLCError = _plcError
        End Get
        Set(ByVal value As Integer)
            _plcError = value
            RaiseEvent PLCErrorEvent(_plcError)
        End Set
    End Property


    ' Class ctor
    Public Sub New()

        ' IO Table
        IOTable = LocalDB.PopulateGrid("SELECT Device, Address FROM PLCIO")
        For i = 0 To IOTable.Rows.Count - 1
            PLCIO.Add(IOTable.Rows(i).Item(0).ToString, IOTable.Rows(i).Item(1).ToString)
        Next

        'DLL Loader
        Dim dllpath As String
        dllpath = System.Environment.CurrentDirectory
        dllpath = dllpath.Replace("bin\Debug", "")
        dllpath = dllpath.Replace("\\", "\\\\")
        dllpath = dllpath.Insert(dllpath.Length, "DMT.dll") ' obtain the relative path where the DMT.dll resides
        hDMTDll = LoadLibrary(dllpath) ' explicitly link to DMT.dll        Dim path As String



        ' DMT Initialize
        ip = BitConverter.ToInt32(IPAddress.Parse(IP_PLC).GetAddressBytes(), 0) ' same as inet_addr()
        ' 192.168.1.251
        CloseModbus = AddressOf DMT.CloseSocket

        ' TODO:: Marshal class i ile LoadLibrary load edip etmediği alınabilir.
        Logger.WriteLog("PLC library loaded to memory:")

    End Sub

    ' Dtor
    Protected Overrides Sub Finalize()
        CloseModbus.Invoke(conn_num)
        Dim retVal As Boolean = False
        retVal = FreeLibrary(hDMTDll)
        If retVal = True Then
            Logger.WriteLog("PLC library freed from memory.")
        End If
    End Sub

    Public Function OpenConnection() As Integer

        Dim socketcounter As Integer = 1
        ' PLC Initialize 
        Do
            socketcounter += 1
            status = DMT.OpenModbusTCPSocket(conn_num, ip)
            If status < 0 Then
                Me.SocketError = DMT.GetLastSocketErr()
                DMT.ResetSocketErr()

            Else
                ' Connected
                Return 1

            End If
            If socketcounter > 3 Then
                GoTo EndOfLoad
            End If
        Loop While (status < 0) And (socketcounter < 5)

EndOfLoad:

        If socketcounter > 3 Then

            ' MBL, 02.05.2019
            'FreeLibrary(hDMTDll)
            'CloseModbus.Invoke(conn_num)
            Me.SocketError = DMT.GetLastSocketErr()
            ' Not connected
            Return -1
        End If
        Return 0
    End Function

    Public Sub CloseConnection()

        CloseModbus.Invoke(conn_num)
        ' Add to destructor
        'FreeLibrary(hDMTDll)

    End Sub

    Public Sub PLCDI(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByRef reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.ReadInputsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                Me.SocketError = err
                DMT.ResetSocketErr
                PLCError = PLCErr.PLCDIError
                'Logger.WriteLog("PLCDI Error  :" & err.ToString)
                'If err = SocketErr.SocketHasBeenDisconnected Then
                '    DMT.OpenModbusTCPSocket(conn_num, ip)

                'End If
            Else
                DMT.ResetSocketErr
                Me.SocketError = DMT.GetLastSocketErr
                ' No error
                PLCError = PLCErr.PLCNoError
            End If
        Loop While (ret < 0)

    End Sub

    Public Sub PLCDO(ByVal device As String, ByRef data As UInt32, ByVal reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, 1)
        Dim ret As Integer
        Do
            DMT.ResetSocketErr
            ret = DMT.WriteSingleCoilW(comm_type, conn_num, slave_addr, addr, data, res, req)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                Me.SocketError = err
                'DMT.ResetSocketErr
                PLCError = PLCErr.PLCDOError

                'Logger.WriteLog("PLCDO Error  :" & err.ToString)

                'If err = SocketErr.Sockethasbeendisconnected Then
                '    DMT.OpenModbusTCPSocket(conn_num, ip)

                '    ' MBL 24.04.2019
                'Else
                '    ' Close comm
                '    ' Exit Loop
                '    'Exit Do
                '    DMT.OpenModbusTCPSocket(conn_num, ip)
                '    Me.SocketStatus = DMT.GetLastSocketErr()
                '    DMT.ResetSocketErr
                '    Logger.WriteLog("Else PLCDO Error  :" & Me.SocketStatus.ToString)

                'End If

            Else
                DMT.ResetSocketErr
                Me.SocketError = DMT.GetLastSocketErr
                ' No error
                PLCError = PLCErr.PLCNoError
            End If
        Loop While (ret < 0)

    End Sub

    Public Sub PLCReadRAM(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByRef reqx As StringBuilder, ByRef resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.ReadHoldRegsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                Me.SocketError = err
                DMT.ResetSocketErr
                PLCError = PLCErr.PLCReadRamError
                'Logger.WriteLog("PLCReadRAM Error  :" & err.ToString)
                'If err = SocketErr.SocketHasBeenDisconnected Then
                '    DMT.OpenModbusTCPSocket(conn_num, ip)
                'End If
            Else
                DMT.ResetSocketErr
                Me.SocketError = DMT.GetLastSocketErr
                ' No error
                PLCError = PLCErr.PLCNoError
            End If
        Loop While (ret < 0)

    End Sub

    Public Sub PLCWriteRAM(ByVal device As String, ByVal qty As Integer, ByRef data() As UInt32, ByVal reqx As StringBuilder, ByVal resx As StringBuilder)

        Dim addr As Integer = DMT.DevToAddrW(strProduct, device, qty)
        Dim ret As Integer

        Do
            ret = DMT.WriteMultiRegsW(comm_type, conn_num, slave_addr, addr, qty, data(0), reqx, resx)
            If ret < 0 Then
                Dim err As SocketErr = DMT.GetLastSocketErr
                Me.SocketError = err
                DMT.ResetSocketErr
                PLCError = PLCErr.PLCWriteRamError
                'Logger.WriteLog("PLCWriteRAM Error  :" & err.ToString)
                'If err = SocketErr.SocketHasBeenDisconnected Then
                '    DMT.OpenModbusTCPSocket(conn_num, ip)
                'End If
            Else
                DMT.ResetSocketErr
                Me.SocketError = DMT.GetLastSocketErr
                ' No error
                PLCError = PLCErr.PLCNoError

            End If
        Loop While (ret < 0)

    End Sub

    ' Devices
    Public Function Device(ByVal strDeviceName As String) As String
        'DeviceName = strDeviceName
        Return PLCIO.Item(strDeviceName)
    End Function


End Class
