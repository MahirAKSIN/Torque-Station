Imports System.IO
Imports System.Runtime.InteropServices

Public Class WinSpooler

    Public Property szPrinterName As String

    Public Sub New(ByVal PrinterName As String)
        _szPrinterName = PrinterName
    End Sub

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Class DOCINFOA

        <MarshalAs(UnmanagedType.LPStr)>
        Public pDocName As String

        <MarshalAs(UnmanagedType.LPStr)>
        Public pOutputFile As String

        <MarshalAs(UnmanagedType.LPStr)>
        Public pDataType As String

    End Class

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, <Out()> ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, <Out()> ByRef dwWritten As Int32) As Boolean
    End Function
    '=======================================================================================================================================================================
    Public Function SendBytesToPrinter(ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean

        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As IntPtr = New IntPtr(0)
        Dim di As DOCINFOA = New DOCINFOA()
        Dim bSuccess As Boolean = False
        di.pDocName = "Label"
        di.pDataType = "RAW"

        If OpenPrinter(szPrinterName.Normalize(), hPrinter, IntPtr.Zero) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If

        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If

        Return bSuccess

    End Function

    Public Function SendFileToPrinter(ByVal szFileName As String) As Boolean

        Dim fs As FileStream = New FileStream(szFileName, FileMode.Open)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim bytes As Byte() = New Byte(fs.Length - 1) {}
        Dim bSuccess As Boolean = False
        Dim pUnmanagedBytes As IntPtr = New IntPtr(0)
        Dim nLength As Integer

        nLength = Convert.ToInt32(fs.Length)
        bytes = br.ReadBytes(nLength)
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength)
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength)
        bSuccess = SendBytesToPrinter(pUnmanagedBytes, nLength)
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        fs.Dispose()
        fs.Close()

        Return bSuccess

    End Function

    Public Function SendStringToPrinter(ByVal szString As String) As Boolean

        Dim pBytes As IntPtr
        Dim dwCount As Int32

        dwCount = szString.Length
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        SendBytesToPrinter(pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)

        Return True

    End Function


End Class
