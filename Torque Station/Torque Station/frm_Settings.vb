
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Imports System.Data.SqlClient

Imports System.Drawing.Printing

Public Class frm_Settings

    Public LocalDB As New SQLiteTools("TorqueStation")

    Dim iniPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ELOPAR\" & Application.ProductName & "\"
    Dim iniFileName = iniPath & "Torque.ini"

    Dim iniFile As New INIfile(iniFileName)

    ''
    'Dim sqlServerName As String = iniFile.ReadValue("MSSQL", "Servername")
    'Dim sqlDatabase As String = iniFile.ReadValue("MSSQL", "Database")
    'Dim sqlUserName As String = iniFile.ReadValue("MSSQL", "Username")
    'Dim sqlPassword As String = iniFile.ReadValue("MSSQL", "Password")

    'Dim RemoteDB As New MSSqlTools(sqlDatabase, sqlServerName, sqlUserName, sqlPassword)
    ''

    Dim xTolerance As Integer = 0
    Dim yTolerance As Integer = 0

    Dim strXTolerance As String = String.Empty
    Dim strYTolerance As String = String.Empty

    Dim strStationId As String = String.Empty
    Dim strPrinterName As String = String.Empty
    Dim strSerialPort As String = String.Empty

    Dim intSerialTimeout As Integer = 0

    Private Sub frm_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.MaximumSize

        strXTolerance = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'XTolerance' ", "Value")
        strYTolerance = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'YTolerance' ", "Value")
        strStationId = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'StationId' ", "Value")
        strPrinterName = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'Printer' ", "Value")
        strSerialPort = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'COM' ", "Value")

        intSerialTimeout = CInt(LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'Delay'", "Value"))
        nmrc_SerialTimeout.Value = intSerialTimeout

        txt_StationId.Text = strStationId
        'txt_XTolerance.Text = strXTolerance
        'txt_YTolerance.Text = strYTolerance
        nmrc_XTolerance.Value = CInt(strXTolerance)
        nmrc_YTolerance.Value = CInt(strYTolerance)

        ' Get list of printers
        cmb_LabelPrinter.Items.Add("Please select")
        cmb_LabelPrinter.SelectedIndex = 0

        Dim pkInstalledPrinters As String
        ' Find all printers installed
        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            cmb_LabelPrinter.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters
        If Not strPrinterName = String.Empty Then
            cmb_LabelPrinter.SelectedItem = strPrinterName
        Else
            cmb_LabelPrinter.SelectedIndex = 0
        End If

        cmb_SerialPort.Items.Add("Please select")
        cmb_SerialPort.SelectedIndex = 0


        ' Get list of serial ports
        For Each portName In SerialPort.GetPortNames()
            cmb_SerialPort.Items.Add(portName)
        Next

        If Not strSerialPort = String.Empty Then
            cmb_SerialPort.SelectedItem = strSerialPort
        Else
            cmb_SerialPort.SelectedIndex = 0
        End If

        txt_SQLServerName.Text = iniFile.ReadValue("MSSQL", "Servername")
        txt_SQLDatabase.Text = iniFile.ReadValue("MSSQL", "Database")
        txt_SQLUsername.Text = iniFile.ReadValue("MSSQL", "Username")
        txt_SQLPassword.Text = iniFile.ReadValue("MSSQL", "Password")



    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click

        If (txt_StationId.Text <> String.Empty And txt_StationId.Text <> "") And (txt_SQLServerName.Text <> String.Empty And txt_SQLServerName.Text <> "") And
            (txt_SQLDatabase.Text <> String.Empty And txt_SQLDatabase.Text <> "") And (txt_SQLUsername.Text <> String.Empty And txt_SQLUsername.Text <> "") And
            (txt_SQLPassword.Text <> String.Empty And txt_SQLPassword.Text <> "") Then
            If cmb_LabelPrinter.SelectedIndex <> 0 Then
                If cmb_SerialPort.SelectedIndex <> 0 Then
                    ' Numeric Up downs not checked
                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & cmb_SerialPort.SelectedItem.ToString & "' WHERE Key = 'COM' ")
                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & txt_StationId.Text & "' WHERE Key = 'StationId' ")
                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & cmb_LabelPrinter.SelectedItem.ToString & "' WHERE Key = 'Printer' ")
                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & nmrc_XTolerance.Value.ToString & "' WHERE Key = 'XTolerance' ")
                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & nmrc_YTolerance.Value.ToString & "' WHERE Key = 'YTolerance' ")

                    LocalDB.ExecuteNonQuery("UPDATE INI SET Value = '" & nmrc_SerialTimeout.Value.ToString & "' WHERE Key = 'Delay'")

                    ' MSSQL
                    iniFile.WriteValue("MSSQL", "Servername", txt_SQLServerName.Text)
                    iniFile.WriteValue("MSSQL", "Database", txt_SQLDatabase.Text)
                    iniFile.WriteValue("MSSQL", "Username", txt_SQLUsername.Text)
                    iniFile.WriteValue("MSSQL", "Password", txt_SQLPassword.Text)

                    MessageBox.Show("Settings saved.")
                    Me.Close()
                Else
                    ' Serial port not selected
                    MessageBox.Show("Please fill all areas.")
                End If
            Else
                ' Printer not selected
                MessageBox.Show("Please fill all areas.")
            End If
        Else
            ' Station name empty
            MessageBox.Show("Please fill all areas.")
        End If

    End Sub

    Private Sub btn_ConnectionTest_Click(sender As Object, e As EventArgs) Handles btn_ConnectionTest.Click
        If (txt_SQLServerName.Text <> String.Empty And txt_SQLServerName.Text <> "") And
        (txt_SQLUsername.Text <> String.Empty And txt_SQLUsername.Text <> "") And
        (txt_SQLPassword.Text <> String.Empty And txt_SQLPassword.Text <> "") Then
            ' Check connection
            Dim strMSSQLServerName As String = txt_SQLServerName.Text
            Dim strMSSQLDatabase As String = txt_SQLDatabase.Text
            Dim strMSSQLUsername As String = txt_SQLUsername.Text
            Dim strMSSQLPassword As String = txt_SQLPassword.Text

            Dim conn As New SqlConnection
            conn.ConnectionString = "Data Source=" & strMSSQLServerName & ";Database=" & strMSSQLDatabase & ";uid=" & strMSSQLUsername & ";pwd=" & strMSSQLPassword & ";Persist Security Info=True"

            Try
                conn.Open()

                If conn.State.Open Then

                    MessageBox.Show("Connection successful.")
                    conn.Close()
                Else

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        End If

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If RemoteDB.ConnectionControl Then
    '        MessageBox.Show("Conn succ")
    '    Else
    '        MessageBox.Show("Not conn")
    '    End If
    'End Sub
End Class