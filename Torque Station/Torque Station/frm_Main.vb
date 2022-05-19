
Imports System.Text

Imports System.Globalization
Imports System.IO
Imports System.IO.Ports
Imports System.Runtime.InteropServices

Public Class frm_Main

    'Dim BarcodePrinter As New WinSpooler("ZDesigner GC420t (EPL)")
    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn_About.Hide()
        'btn_Print.Hide()

        If frm_Login.txt_Password.Text = "CORLU" Then

            btn_ProcessSetup.Enabled = True
            btn_User_Setup.Enabled = True
            btn_Statistics.Enabled = True
            btn_Process.Enabled = True
            btn_Settings.Enabled = True
            btn_Print.Enabled=True
        Else
            Select Case frm_Login.loggedUserLevel
                Case "Supervisor"
                    btn_ProcessSetup.Enabled = True
                    btn_User_Setup.Enabled = True
                    btn_Statistics.Enabled = True
                    btn_Process.Enabled = True
                    btn_Settings.Enabled = True
                    btn_Print.Enabled=True
                Case "Mechanic"
                Case "Operator"
                    btn_ProcessSetup.Enabled = False
                    btn_User_Setup.Enabled = False
                    btn_Statistics.Enabled = False
                    btn_Settings.Enabled = False
                    btn_Process.Enabled = True
                    btn_Print.Enabled=False
            End Select
        End If



    End Sub

    ' Printer Test
    'Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click

    '    Dim strOrderNumber As String = "1234567890"
    '    CreateBarcode(strOrderNumber, "Station1", "Mehmet", "11.07.2019 09:14:20")
    '    PrintBarcode("ZDesigner GC420t (EPL)")
    'End Sub

    'Public Sub CreateBarcode(ByVal OrderNumber As String, ByVal StationId As String, ByVal OpId As String, ByVal DateTime As String)
    '    Dim strFile As String = "barcode.txt"
    '    Dim sw As IO.StreamWriter

    '    If IO.File.Exists(strFile) = False Then
    '        sw = IO.File.CreateText(strFile)
    '    Else
    '        IO.File.Delete(strFile)
    '        sw = IO.File.CreateText(strFile)
    '    End If
    '    sw.WriteLine("N")
    '    'sw.WriteLine("b20,20,Q,""" & OrderNumber & """")
    '    'sw.WriteLine("B20,20,0,3,3,5,200,B,""" & OrderNumber & """")
    '    'B50,50,0,3,3,5,200,B,"1%1"

    '    ' Part number
    '    Dim partNo As String = "Part Nr :" & OrderNumber
    '    sw.WriteLine("A50,5,0,4,1,1,N,""" & partNo & """")
    '    ' Station id
    '    'Dim stationId As String = "Station :"
    '    StationId = "Station :" & StationId
    '    sw.WriteLine("A50,50,0,4,1,1,N,""" & StationId & """")
    '    ' Operator Id
    '    'Dim operatorId As String = "Operator:"
    '    OpId = "Operator:" & OpId
    '    sw.WriteLine("A50,100,0,4,1,1,N,""" & OpId & """")

    '    ' Datetime
    '    sw.WriteLine("A50,150,0,4,1,1,N,""" & DateTime & """")

    '    'Dim strBarcode As String = "1234"
    '    sw.WriteLine("B50,200,0,1,3,5,150,B,""" & OrderNumber & """")
    '    'sw.WriteLine("A80,350,0,3,1,1,N,""This is text""")
    '    sw.WriteLine("P1")
    '    sw.Close()
    'End Sub

    '''''''''''
    'Public Sub CreateBarcode(ByVal OrderVariant As String, ByVal OrderNumber As String)
    '    Dim strFile As String = "barcode.txt"
    '    Dim sw As IO.StreamWriter

    '    If IO.File.Exists(strFile) = False Then
    '        sw = IO.File.CreateText(strFile)
    '    Else
    '        IO.File.Delete(strFile)
    '        sw = IO.File.CreateText(strFile)
    '    End If
    '    sw.WriteLine("N")
    '    sw.WriteLine("Q94.4,47.2+12")
    '    sw.WriteLine("S1")
    '    sw.WriteLine("D" & ini.ReadValue("BARCODE", "D"))

    '    sw.WriteLine("b" & ini.ReadValue("BARCODE", "X") & "," & ini.ReadValue("BARCODE", "Y") & ",D,c20,r20,h3,""" &
    '                         OrderVariant & " xx " & OrderNumber & " " &
    '                         Date.Today.ToString("yy") &
    '                         CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(Date.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString &
    '                         Chr(64 + 3 * (CInt(Date.Today.DayOfWeek) - 1) + IIf(TimeOfDay.Hour < 6, 1, IIf(TimeOfDay.Hour < 14, 2, 3))) & """")
    '    sw.WriteLine("P1")
    '    sw.Close()
    'End Sub

    'Public Sub PrintBarcode(ByVal printerName As String)
    '    Dim proc As New System.Diagnostics.Process
    '    With proc.StartInfo
    '        .UseShellExecute = True
    '        .FileName = "cmd.exe"
    '        .Arguments = "/C copy barcode.txt ""\\127.0.0.1\" & printerName & ""
    '        .WindowStyle = ProcessWindowStyle.Hidden
    '    End With
    '    proc.Start()
    '    Do
    '    Loop While Not proc.WaitForExit(100)
    'End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        frm_Login.Close()
        Me.Close()
    End Sub

    Private Sub btn_Statistics_Click(sender As Object, e As EventArgs) Handles btn_Statistics.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Statistics Then
                f.Activate()
                Return
            End If
        Next

        Dim frmStatistics As New frm_Statistics
        frmStatistics.Show()
    End Sub

    Private Sub btn_Process_Click(sender As Object, e As EventArgs) Handles btn_Process.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Process Then
                f.Activate()
                Return
            End If
        Next

        Dim frmProcess As New frm_Process
        frmProcess.Show()
    End Sub

    Private Sub btn_ProcessSetup_Click(sender As Object, e As EventArgs) Handles btn_ProcessSetup.Click

        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_ProcessSetup Then
                f.Activate()
                Return
            End If
        Next

        Dim frmProcessSetup As New frm_ProcessSetup
        frmProcessSetup.Show()
    End Sub

    Private Sub btn_User_Setup_Click(sender As Object, e As EventArgs) Handles btn_User_Setup.Click

        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_UserSetup Then
                f.Activate()
                Return
            End If
        Next

        Dim frmUserSetup As New frm_UserSetup
        frmUserSetup.ShowDialog()
    End Sub

    Private Sub frm_Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frm_Login.Close()

    End Sub

    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Settings Then
                f.Activate()
                Return
            End If
        Next

        Dim frmSetting As New frm_Settings
        frmSetting.ShowDialog()

    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is BarcodePrinter Then
                f.Activate()
                Return
            End If
        Next

        Dim BarcodePrinter As New BarcodePrinter
        BarcodePrinter.ShowDialog()
    End Sub

    Private Sub btn_deneme_Click(sender As Object, e As EventArgs) Handles btn_deneme.Click
        For Each f As Form In Application.OpenForms
            If TypeOf f Is frm_Deneme Then
                f.Activate()
                Return
            End If
        Next

        Dim deneme As New frm_Deneme
        deneme.ShowDialog()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    For Each f As Form In Application.OpenForms
    '        If TypeOf f Is frm_Deneme Then
    '            f.Activate()
    '            Return
    '        End If
    '    Next

    '    Dim deneme As New frm_Deneme
    '    deneme.ShowDialog()
    'End Sub
End Class
