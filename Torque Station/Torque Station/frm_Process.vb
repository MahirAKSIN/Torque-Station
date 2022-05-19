
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports Microsoft.VisualBasic.PowerPacks

Imports System.Data.SqlClient

Imports LBSoft.IndustrialCtrls.Leds

Public Class frm_Process

    Dim WithEvents shapeContainer As New ShapeContainer
    Dim nutSp As New PowerPacks.OvalShape
    Dim radius As Integer = 20

    ' Linear ruler tolerance
    Dim posXTol As Integer = 50
    ' Rotary encoder tolerance
    Dim posYTol As Double = 50

    Dim isPosition As Boolean = False

    Public LocalDB As New SQLiteTools("TorqueStation")

    'Dim globalBitOk As Boolean = False
    Dim gridStep As Integer = 0
    Dim AllBitBoxes As Boolean = False
    Dim isDesiredNut As Boolean = False
    Dim isUndesiredNut As Boolean = False
    Dim isBarcodeScanned As Boolean = False
    Dim isProcessFinished As Boolean = False
    Dim strLastNut As String = String.Empty
    'Dim isResultOK As Boolean = True

    Dim BitBoxes As New Dictionary(Of String, String)
    Dim BitboxTable As DataTable

    Dim BitBoxLedTable As DataTable
    Dim BitBoxLeds As New Dictionary(Of String, String)

    ' PLC Connection
    Dim WithEvents PLCComm As New PLC
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    Private SerialPort As New CommManager()

    Dim strVariantNumber As String = String.Empty
    Dim strPrinterName As String = String.Empty
    Dim strSerialPort As String = String.Empty

    Dim frmAuth As New frm_Authentication
    Dim dlgResult As DialogResult
    Dim isError As Boolean = False

    Dim strStationId As String = String.Empty
    Dim strLoggedUser As String = String.Empty

    ' Serialport read delay
    Dim startTime As DateTime
    Dim endTime As DateTime
    Dim elapsed As TimeSpan
    Dim delayTime As Integer = 0

    Public Enum CaseSteps
        OnProcessStarted = 0
        OnCheckCycle ' Check the selected cycle number on torque controller
        OnBitBoxSelection
        OnScrewPosition
        InCycle
        OutCycle
        'OnUnscrew
        'OnTightening
        OnNewStep
        OnWaitForBit
        OnLastNut
    End Enum

    Dim stepProcess As CaseSteps = CaseSteps.OnProcessStarted

    Dim frmMessageBox As MessageBox

    ' Warning message dialog
    Dim formWarning As New frm_Warning

    ' MSSQL
    Dim iniPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ELOPAR\" & Application.ProductName & "\"
    Dim iniFileName = iniPath & "Torque.ini"

    Dim iniFile As New INIfile(iniFileName)

    Dim conn As New SqlConnection
    Dim sqlServerName As String = iniFile.ReadValue("MSSQL", "Servername")
    Dim sqlDatabase As String = iniFile.ReadValue("MSSQL", "Database")
    Dim sqlUserName As String = iniFile.ReadValue("MSSQL", "Username")
    Dim sqlPassword As String = iniFile.ReadValue("MSSQL", "Password")

    Dim RemoteDB As New MSSqlTools(sqlDatabase, sqlServerName, sqlUserName, sqlPassword)

    Private Sub frm_Process_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_Process.MinimumSize = pb_Process.MaximumSize
        shapeContainer.Parent = pb_Process
        nutSp.Parent = shapeContainer
        nutSp.Left = 10
        nutSp.Top = 10
        nutSp.Width = radius
        nutSp.Height = radius
        nutSp.FillStyle = PowerPacks.FillStyle.Solid
        nutSp.FillColor = Color.Yellow
        nutSp.Hide()

        ' Get logged username
        strLoggedUser = frm_Login.loggedUserName

        ' Hide serialport textbox
        txt_SerialPort.Hide()
        txt_PLCError.Hide()

        ' Get bitboxes
        BitboxTable = LocalDB.PopulateGrid("SELECT Device, Address FROM PLCIO WHERE Type='Input' And Device LIKE 'M%' OR 'm%'  ORDER BY Address ASC")
        For Each rows As DataRow In BitboxTable.Rows
            BitBoxes.Add(rows.Item("Device"), rows.Item("Address"))
        Next

        ' Get bitbox leds
        BitBoxLedTable = LocalDB.PopulateGrid("SELECT Device, Address FROM PLCIO WHERE Type='Output' And Device LIKE 'BITLD_%' ORDER BY Address ASC")
        For Each row As DataRow In BitBoxLedTable.Rows
            BitBoxLeds.Add(row.Item("Device"), row.Item("Address"))
        Next

        ' Position tolerances
        posXTol = CInt(LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'XTolerance' ", "Value"))
        posYTol = CInt(LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'YTolerance' ", "Value"))
        'MessageBox.Show("Tol: " & LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'XTolerance' ", "Value"))

        txt_Info.Text = "XPos Tolerance: " & posXTol.ToString & ", YPos Tolerance: " & posYTol.ToString

        strPrinterName = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'Printer' ", "Value")
        strStationId = LocalDB.GetSingleValue("SELECT * From INI WHERE Key = 'StationId' ", "Value")
        strSerialPort = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'COM' ", "Value")

        ' Delay time for reading serial port
        delayTime = CInt(LocalDB.GetSingleValue("SELECT * From INI WHERE Key = 'Delay' ", "Value"))

        ' Connect to PLC
        If PLCComm.OpenConnection() > 0 Then
            'txt_Status.AppendText("Connected." & vbCrLf)
            tmr_Indicator.Enabled = True

            SerialPortInit(strSerialPort)
            SerialPort.OpenPort()

            PLCComm.PLCDO(PLCComm.Device("ACTIV_MODUL"), 1, res, req)

        Else
            'tmr_Indicator.Enabled = False
            'tmr_Process.Enabled = False
            'txt_Status.AppendText("Not Connected." & vbCrLf)
            MessageBox.Show("PLC Connection not found." & vbCrLf & "Please check your connection.")
            ' You can close conneciton.
            PLCComm.CloseConnection()
            'Me.Close()
        End If

        'led_InCycle.State = LBLed.LedState.On
        'led_InCycle.LedColor = Color.Lime
        'led_InCycle.State = LBLed.LedState.Blink

        lbl_BitWarning.Text = ""
        lbl_BitWarning.ForeColor = Color.Red
        ' Check for bits position
        ' 20210313 bunu geri al
        InitialBitboxCheck()

        PLCComm.PLCDO(PLCComm.Device("VPSLOO"), 0, res, req)

        formWarning.FormMessage("Can not read report from controller. Please check the serial connection.")


        'If RemoteDB.ConnectionControl = True Then
        '    MessageBox.Show("Conn succ")

        'Else
        '    MessageBox.Show("Not conn")
        'End If

    End Sub

#Region "PLC Connection"
    ' PLC Connection Error Event
    Private Sub PLCConnection() Handles PLCComm.PLCErrorEvent
        Select Case PLCComm.PLCError
            Case 0
                'txt_ConnStatus.Text = "Connection Error"
                txt_PLCError.Text = "PLC Error" & PLCComm.PLCError.ToString
            Case 1
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCDIError" & vbCrLf)
                txt_PLCError.Text = "PLC Error" & PLCComm.PLCError.ToString

            Case 2
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCDOError" & vbCrLf)
                txt_PLCError.Text = "PLC Error" & PLCComm.PLCError.ToString
            Case 3
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCReadRamError" & vbCrLf)
                txt_PLCError.Text = "PLC Error" & PLCComm.PLCError.ToString
            Case 4
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCWriteRamError" & vbCrLf)
                txt_PLCError.Text = "PLC Error" & PLCComm.PLCError.ToString
        End Select

        If PLCComm.PLCError > 0 Then
            tmr_Indicator.Enabled = False
            tmr_Process.Enabled = False
            txt_PLCError.Text = "Err:" & PLCComm.PLCError.ToString
            'errCntr = errCntr + 1
            'If errCntr > 10 Then
            '    MessageBox.Show("Communication Error. Check your connection.")
            '    Exit Sub
            'Else
            '    tmr_Indicator.Enabled = True
            '    errCntr = 0
            'End If
            'frmMessageBox.Show("Communication Error. Check your connection.")
            txt_Info.Text = "Communication Error. Check your connection."
        Else
            ' No Error
            tmr_Indicator.Enabled = True
            tmr_Process.Enabled = True
            'txt_Info.Text = ""
        End If
    End Sub
#End Region

    Private Sub SerialPortInit(ByVal _portName As String)
        SerialPort.PortName = _portName
        SerialPort.BaudRate = 19200
        SerialPort.Parity = Parity.None
        SerialPort.StopBits = StopBits.One
        SerialPort.DataBits = 8
        'BarcodePort.Mask = True
        SerialPort.STX = vbCr
        SerialPort.ETX = vbLf

        SerialPort.CurrentTransmissionType = CommManager.TransmissionType.Text
        SerialPort.DisplayWindow = txt_SerialPort
        SerialPort.comPort.RtsEnable = True
        SerialPort.comPort.DtrEnable = True
    End Sub

    Private Sub txt_VariantBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_VariantBarcode.KeyPress

        ' Refresh grid, delete everything and give a message warning
        grd_Process.DataSource = Nothing
        grd_Process.Refresh()
        pb_Process.Image = Nothing
        nutSp.Hide()

        tmr_Process.Enabled = False

        ' Enter key detected
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then

            ' Get variant from Chassie Number 

            'Dim chassieVariant As String = 





            ' Old code
            Dim variantName As String = txt_VariantBarcode.Text.ToString

            If variantName.Contains("'") Or variantName.Contains("""") Then
                MessageBox.Show("Invalid variant text")
                txt_VariantBarcode.Clear()
                txt_VariantBarcode.Focus()
                Exit Sub
            End If
            
            If LocalDB.isThere("SELECT * FROM PROCESSDESC WHERE VariantName='" & variantName & "'") Then

        'SELECT [Harness No] as variant,[Issue]
        'FROM DPS.guest.ProdPlan
        'where [Prod No] = 'O336569' 
                If Not RemoteDB.isThere("SELECT [Harness No] as variant, [Issue]" &
                                        "FROM DPS.guest.ProdPlan " &
                                        "where [Prod No] = '" & variantName & "' ") Then
                    MessageBox.Show("Invalid variant in Remote database")
                    txt_VariantBarcode.Clear()
                    txt_VariantBarcode.Focus()
                    Exit Sub
                Else
                    Dim chassieVariant As String = RemoteDB.GetSingleValue("SELECT [Harness No] as variant, [Issue] " &
                            "FROM  DPS.guest.ProdPlan " &
                            "where [Prod No] = '" & variantName & "' ", "variant")
                    variantName = chassieVariant
                End If

            End If
            
            If Not LocalDB.isThere("SELECT * FROM PROCESSDESC WHERE VariantName='" & variantName & "'") Then
                grd_Process.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC WHERE VariantName='" & variantName & "' ORDER BY ScrewOrder ASC")
                grd_Process.Refresh()

                ' Get the pic
                Dim masterName As String = LocalDB.GetSingleValue("SELECT * FROM VARIANT WHERE VariantName='" & variantName & "'", "MasterName")
                'MessageBox.Show("Master name: " & masterName)
                pb_Process.Image = LocalDB.GetImage("SELECT MasterPicture FROM PICTURE WHERE MasterName='" & masterName & "'", "MasterPicture")

                ' Move the shape to first location

                Dim nutX As Integer = CInt(grd_Process.Item("NutX", gridStep).Value)
                Dim nutY As Integer = CInt(grd_Process.Item("NutY", gridStep).Value)
                nutSp.Left = nutX
                nutSp.Top = nutY
                nutSp.FillColor = Color.Yellow
                nutSp.Show()
                tmr_Process.Enabled = True
                'tmr_Indicator.Enabled = True
                gridStep = 0
                isBarcodeScanned = True
                stepProcess = CaseSteps.OnProcessStarted

                strVariantNumber = txt_VariantBarcode.Text

                txt_VariantBarcode.Enabled = False

            Else
                ' Refresh grid, delete everything and give a message warning
                grd_Process.DataSource = Nothing
                grd_Process.Refresh()
                txt_VariantBarcode.Clear()

                nutSp.Hide()
                tmr_Process.Enabled = False
                'tmr_Indicator.Enabled = False
                pb_Process.Image = Nothing
                MessageBox.Show("Variant not found")
                txt_VariantBarcode.Enabled = True
                Me.ActiveControl = txt_VariantBarcode

            End If

            e.Handled = True
        End If

    End Sub

    ' Always focus on textbox
    Private Sub txt_VariantBarcode_Leave(sender As Object, e As EventArgs) Handles txt_VariantBarcode.Leave
        txt_VariantBarcode.Select()
    End Sub

    Private Sub frm_Process_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        ' Disable 

        PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
        ' Disable leds
        PLCComm.PLCDO(PLCComm.Device("BITLD_M6_N"), 0, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLD_M8_N"), 0, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLD_M5_N"), 0, res, req)

        ' TODO:: bitbox release

        SerialPort.ClosePort()
        tmr_Indicator.Enabled = False
        tmr_Process.Enabled = False
        PLCComm.CloseConnection()
    End Sub

    Private Sub tmr_Indicator_Tick(sender As Object, e As EventArgs) Handles tmr_Indicator.Tick

        ' Read Linear Ruler
        PLCComm.data_to_dev = New UInt32() {0}
        PLCComm.PLCReadRAM("D100", PLCComm.data_from_dev.Length, PLCComm.data_from_dev, res, req)
        txt_LinearRuler.Text = PLCComm.data_from_dev(0).ToString
        Dim currXPos As Integer = PLCComm.data_from_dev(0)

        ' Read Rotary Encoder
        PLCComm.data_to_dev = New UInt32() {0}
        PLCComm.PLCReadRAM("D102", PLCComm.data_from_dev.Length, PLCComm.data_from_dev, res, req)
        txt_RotaryEncoder.Text = PLCComm.data_from_dev(0).ToString
        Dim currYPos As Integer = PLCComm.data_from_dev(0)

        ' Check the correct position of nut
        If stepProcess = CaseSteps.OnScrewPosition Or
         stepProcess = CaseSteps.InCycle Or
            stepProcess = CaseSteps.OutCycle Then 'Or stepProcess = CaseSteps.InCycle Or stepProcess = CaseSteps.OutCycle Then
            ' Linear Ruler
            Dim realXPos As Integer = CInt(grd_Process.Item("CoordX", gridStep).Value)
            ' Rotary Encoder
            Dim realYPos As Integer = CInt(grd_Process.Item("CoordY", gridStep).Value)

            'If ((currXPos >= (realXPos - posXTol)) And (currXPos <= (realXPos + posXTol))) And
            '    ((currYPos >= (realYPos - posYTol)) And (currYPos <= (realYPos + posYTol))) Then
            If ((realXPos >= (currXPos - posXTol)) And
                (realXPos <= (currXPos + posXTol))) And
                    ((realYPos >= (currYPos - posYTol)) And
                    (realYPos <= (currYPos + posYTol))) Then

                nutSp.FillColor = Color.Lime
                ' In position
                isPosition = True
                If isError = True Then
                    'Label6.Text = "bits NOK isError"
                    PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
                Else
                    ' variant disbled then test is active 
                    If txt_VariantBarcode.Enabled Then
                        'Label6.Text = "bits NOK textbox enabled"
                        PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
                    Else
                        'If globalBitOk = True Then
                        '    Label6.Text = "bits OK global BIT"
                        '    PLCComm.PLCDO(PLCComm.Device("VALSP"), 1, res, req)
                        'Else
                        '    Label6.Text = "bits NOK global BIT"
                        '    PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
                        'End If

                        Dim nutType As String = grd_Process.Item("NutType", gridStep).Value
                        Dim bitLed As String = "BITLD_" & nutType

                        Dim x As Boolean = True
                        ' Check for bit switch
                        Dim readBit As Integer = 0
                        For Each bitSW In BitBoxes.Keys
                            PLCComm.PLCDI(PLCComm.Device(bitSW), 1, PLCComm.data_from_dev, res, req)
                            readBit = PLCComm.data_from_dev(0)

                            If (bitSW = nutType) Then
                                x = x And (readBit = 0)
                            Else
                                x = x And (readBit = 1)
                            End If

                        Next

                        If x = False Then
                            PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
                            txt_Info.Text = "Bits not in their position"
                            'Label6.Text = "bits NOK global BIT"
                        Else
                            'globalBitOk = True
                            'stepProcess = CaseSteps.OnScrewPosition
                            PLCComm.PLCDO(PLCComm.Device("VALSP"), 1, res, req)
                            txt_Info.Text = ""
                            'Label6.Text = "bits OK global BIT"
                        End If

                    End If

                End If

            Else
                nutSp.FillColor = Color.Yellow
                isPosition = False
                ' Disable VALSP
                'Label6.Text = "position NOK"
                PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
            End If

        Else
            'Label6.Text = "not in predefined cases"
            PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
        End If

    End Sub

    Private Sub tmr_Process_Tick(sender As Object, e As EventArgs) Handles tmr_Process.Tick

        tmr_Process.Enabled = False

        Select Case stepProcess
            Case CaseSteps.OnProcessStarted
                If isBarcodeScanned Then

                    Dim jobNo As Integer = CInt(grd_Process.Item("JobNo", gridStep).Value)

                    Dim cyc1 As Integer = jobNo And &B1
                    Dim cyc2 As Integer = (jobNo And &B10) >> 1
                    Dim cyc4 As Integer = (jobNo And &B100) >> 2

                    ' Choose program and output related plc outs
                    PLCComm.PLCDO(PLCComm.Device("CYC1"), cyc1, res, req)
                    PLCComm.PLCDO(PLCComm.Device("CYC2"), cyc2, res, req)
                    PLCComm.PLCDO(PLCComm.Device("CYC4"), cyc4, res, req)

                    ' Activate Modules
                    'PLCComm.PLCDO(PLCComm.Device("ACTIV_MODUL"), 1, res, req)

                    txt_Info.Text = stepProcess.ToString

                    stepProcess = CaseSteps.OnCheckCycle

                End If

            Case CaseSteps.OnCheckCycle

                txt_Info.Text = stepProcess.ToString

                ' Check the selected program cycle from plc
                Dim jobNo As Integer = CInt(grd_Process.Item("JobNo", gridStep).Value)

                Dim cyc1 As Integer = jobNo And &B1
                Dim cyc2 As Integer = (jobNo And &B10) >> 1
                Dim cyc4 As Integer = (jobNo And &B100) >> 2

                ' Read CYC Inputs
                Dim cyc1Read As Integer = 0
                Dim cyc2Read As Integer = 0
                Dim cyc4Read As Integer = 0

                PLCComm.PLCDI(PLCComm.Device("CYC1"), 1, PLCComm.data_from_dev, res, req)
                cyc1Read = CInt(PLCComm.data_from_dev(0))

                PLCComm.PLCDI(PLCComm.Device("CYC2"), 1, PLCComm.data_from_dev, res, req)
                cyc2Read = CInt(PLCComm.data_from_dev(0))

                PLCComm.PLCDI(PLCComm.Device("CYC4"), 1, PLCComm.data_from_dev, res, req)
                cyc4Read = CInt(PLCComm.data_from_dev(0))

                If (cyc1Read = cyc1) And (cyc2Read = cyc2) And (cyc4Read = cyc4) Then
                    stepProcess = CaseSteps.OnBitBoxSelection

                Else
                    ' Selected program not defined on controller
                    MessageBox.Show("Cycle not found")

                    ' Disable cycle
                    PLCComm.PLCDO(PLCComm.Device("CYC1"), 0, res, req)
                    PLCComm.PLCDO(PLCComm.Device("CYC2"), 0, res, req)
                    PLCComm.PLCDO(PLCComm.Device("CYC4"), 0, res, req)

                    txt_VariantBarcode.Clear()
                    grd_Process.DataSource = Nothing
                    grd_Process.Refresh()

                    pb_Process.Image = Nothing
                    nutSp.Hide()

                    ' Release sockets
                    PLCComm.PLCDO(PLCComm.Device("ACTIV_MODUL"), 0, res, req)
                    stepProcess = CaseSteps.OnProcessStarted
                    tmr_Process.Enabled = False

                End If


            Case CaseSteps.OnBitBoxSelection

                txt_Info.Text = stepProcess.ToString

                Dim nutType As String = grd_Process.Item("NutType", gridStep).Value
                Dim bitLed As String = "BITLD_" & nutType
                ' Check for nut
                'BitBoxLeds
                For Each bit In BitBoxLeds.Keys
                    If bit = bitLed Then
                        ' Enable led
                        PLCComm.PLCDO(PLCComm.Device(bit), 1, res, req)

                        ' Disable Lock
                        PLCComm.PLCDO(PLCComm.Device("BITLC_" & nutType), 0, res, req)
                    Else
                        ' Disable led
                        PLCComm.PLCDO(PLCComm.Device(bit), 0, res, req)

                    End If
                Next


                'Dim x As Boolean = True
                '' Check for bit switch
                'Dim readBit As Integer = 0
                'For Each bitSW In BitBoxes.Keys
                '    PLCComm.PLCDI(PLCComm.Device(bitSW), 1, PLCComm.data_from_dev, res, req)
                '    readBit = PLCComm.data_from_dev(0)

                '    If (bitSW = nutType) Then
                '        x = x And (readBit = 0)
                '    Else
                '        x = x And (readBit = 1)
                '    End If

                'Next

                'If x = False Then
                '    txt_Info.Text = "Bits not in their position"
                'Else
                '    ' Read for the bit
                '    'PLCComm.PLCDI(PLCComm.Device(nutType), 1, PLCComm.data_from_dev, res, req)
                '    'If PLCComm.data_from_dev(0) = 0 Then
                '    ' correct bit is on Schraube 
                '    globalBitOk = True
                '        stepProcess = CaseSteps.OnScrewPosition
                '        txt_Info.Text = ""
                '        'End If

                '    End If

                stepProcess = CaseSteps.OnScrewPosition

            Case CaseSteps.OnScrewPosition

                txt_Info.Text = stepProcess.ToString

                led_InCycle.State = LBLed.LedState.Off
                led_ResultOK.State = LBLed.LedState.Off
                led_ResultNOK.State = LBLed.LedState.Off

                If isPosition Then
                    'stepProcess = CaseSteps.InCycle
                    nutSp.FillColor = Color.Lime
                Else
                    nutSp.FillColor = Color.Yellow
                End If

                ' Read InCycle
                PLCComm.PLCDI(PLCComm.Device("INCYC"), 1, PLCComm.data_from_dev, res, req)
                If PLCComm.data_from_dev(0) = 1 Then
                    ' In Cycle
                    led_InCycle.LedColor = Color.Lime
                    led_InCycle.State = LBLed.LedState.Blink
                    ' Jump to next case

                    stepProcess = CaseSteps.InCycle

                End If

            Case CaseSteps.InCycle

                txt_Info.Text = stepProcess.ToString

                ' Read OutCycle
                PLCComm.PLCDI(PLCComm.Device("INCYC"), 1, PLCComm.data_from_dev, res, req)
                If PLCComm.data_from_dev(0) = 0 Then
                    ' Out Cycle -> Cycle finished
                    led_InCycle.State = LBLed.LedState.Off
                    stepProcess = CaseSteps.OutCycle
                    startTime = Now
                    ' correct bit is NOT on Schraube



                    '' Read Result OK
                    'Dim resultOk As Integer = 0
                    'PLCComm.PLCDI(PLCComm.Device("ACCRP"), 1, PLCComm.data_from_dev, res, req)
                    'resultOk = PLCComm.data_from_dev(0)

                    '' Read Result NOK
                    'Dim resultNOK As Integer = 0
                    'PLCComm.PLCDI(PLCComm.Device("REJRP"), 1, PLCComm.data_from_dev, res, req)
                    'resultNOK = PLCComm.data_from_dev(0)

                    'If resultNOK = 1 Then
                    '    txt_Info.Text = "Result NOK"

                    'End If

                    'If resultOk = 1 Or resultNOK = 1 Then
                    '    stepProcess = CaseSteps.OutCycle
                    'End If

                End If

            Case CaseSteps.OutCycle

                txt_Info.Text = stepProcess.ToString

                ' Read the report from serial
                If txt_SerialPort.Text.Length > 0 Then



                    ' Process data
                    Dim strCycleNumber As String = String.Empty
                    Dim strDateTime As String = String.Empty
                    Dim strTorqueVal As String = String.Empty
                    Dim strAngle As String = String.Empty
                    Dim strReport As String = String.Empty

                    'Dim screwOrder As Integer = CInt()

                    strCycleNumber = txt_SerialPort.Text.Substring(9, 2)
                    strDateTime = txt_SerialPort.Text.Substring(15, 17)
                    strTorqueVal = txt_SerialPort.Text.Substring(32, 7)
                    Dim truncatedTorqueVal As Double = Math.Truncate(CDbl(strTorqueVal) * 100) / 100

                    strAngle = txt_SerialPort.Text.Substring(41, 6)

                    Dim indexOf As Integer = 0
                    If txt_SerialPort.Text.Contains("A") Then
                        indexOf = txt_SerialPort.Text.LastIndexOf("A")

                        led_ResultOK.State = LBLed.LedState.Blink
                        led_ResultNOK.State = LBLed.LedState.Off
                    End If

                    If txt_SerialPort.Text.Contains("R") Then
                        indexOf = txt_SerialPort.Text.LastIndexOf("R")
                        nutSp.FillColor = Color.Yellow
                        led_ResultNOK.State = LBLed.LedState.Blink
                        led_ResultOK.State = LBLed.LedState.Off
                    End If

                    strReport = txt_SerialPort.Text.Substring(indexOf, 3)

                    strReport.Trim()
                    Dim strStatus As String = String.Empty

                    ' MBL, 22.08.2019
                    Dim screwOrder As Integer = 0

                    screwOrder = CInt(grd_Process.Item("ScrewOrder", gridStep).Value)

                    Dim processFinishedTime As New DateTime
                    processFinishedTime = Convert.ToDateTime(strDateTime)
                    ' MBL End

                    If strReport.StartsWith("A") Then
                        strStatus = "OK"
                        ' MBL 22.08.2019 screwOrder added
                        LocalDB.ExecuteNonQuery("INSERT INTO STATISTICS Values('" & strStationId & "','" & strLoggedUser & "','" & strVariantNumber & "','" & CInt(strCycleNumber) & "'," & screwOrder & ",'" & processFinishedTime.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & truncatedTorqueVal & "','" & CDbl(strAngle) & "', '" & strReport & "','" & strStatus & "' )")
                        txt_SerialPort.Clear()

                        strReport = String.Empty
                        ' Jump to next case
                        stepProcess = CaseSteps.OnNewStep

                    End If

                    If strReport.StartsWith("R") Then
                        strStatus = "NOK"
                        ' MBL 22.08.2019 screwOrder added
                        LocalDB.ExecuteNonQuery("INSERT INTO STATISTICS Values('" & strStationId & "','" & strLoggedUser & "','" & strVariantNumber & "','" & CInt(strCycleNumber) & "'," & screwOrder & ",'" & processFinishedTime.ToString("yyyy-MM-dd HH:mm:ss") & "', '" & truncatedTorqueVal & "','" & CDbl(strAngle) & "', '" & strReport & "','" & strStatus & "' )")
                        txt_SerialPort.Clear()
                        strReport = String.Empty
                        nutSp.FillColor = Color.Yellow

                        ' Disable VALSP
                        PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)
                        isError = True
                        ' Call Supervisor
                        Dim frmPassword As New frm_Authentication
                        Dim diaResult As Integer = frmPassword.ShowDialog()
                        If diaResult = DialogResult.OK Then
                            nutSp.FillColor = Color.Yellow
                            isError = False
                            startTime = Now
                            'globalBitOk = True
                            stepProcess = CaseSteps.OnScrewPosition
                        End If

                    End If

                Else

                    endTime = Now
                    ' Can not read from serial
                    elapsed = endTime.Subtract(startTime)
                    If elapsed.TotalSeconds > delayTime Then
                        ' What will we do?

                        '' Read Result OK
                        Dim resultOk As Integer = 0
                        PLCComm.PLCDI(PLCComm.Device("ACCRP"), 1, PLCComm.data_from_dev, res, req)
                        resultOk = PLCComm.data_from_dev(0)

                        ' Read Result NOK
                        Dim resultNOK As Integer = 0
                        PLCComm.PLCDI(PLCComm.Device("REJRP"), 1, PLCComm.data_from_dev, res, req)
                        resultNOK = PLCComm.data_from_dev(0)

                        If resultOk = 1 Or resultNOK = 1 Then
                            tmr_Process.Enabled = False
                            If isError = False Then
                                If formWarning.Visible = False Then
                                    Dim result As DialogResult = formWarning.ShowDialog()
                                    If result = DialogResult.OK Then
                                        Me.Close()
                                        If frm_Main.Visible = False Then
                                            frm_Main.Show()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Case CaseSteps.OnNewStep

                'globalBitOk = False

                txt_Info.Text = stepProcess.ToString

                gridStep += 1

                If gridStep = grd_Process.Rows.Count Then
                    ' Process finished
                    txt_Info.Text = "Process finished"

                    nutSp.Left = 0
                    nutSp.Top = 0
                    nutSp.FillColor = Color.Yellow
                    nutSp.Hide()

                    PLCComm.PLCDO(PLCComm.Device("VALSP"), 0, res, req)


                    ' Print barcode
                    CreateBarcode(txt_VariantBarcode.Text, strStationId, strLoggedUser, DateTime.Now.ToString)
                    PrintBarcode(strPrinterName)

                    'tmr_Process.Enabled = False
                    isProcessFinished = True

                    strLastNut = grd_Process.Item("NutType", (grd_Process.Rows.Count - 1)).Value

                    txt_VariantBarcode.Clear()


                    grd_Process.DataSource = Nothing
                    isBarcodeScanned = False
                    led_InCycle.State = LBLed.LedState.Off
                    led_ResultOK.State = LBLed.LedState.Off
                    led_ResultNOK.State = LBLed.LedState.Off

                    txt_LinearRuler.Clear()
                    txt_RotaryEncoder.Clear()

                    stepProcess = CaseSteps.OnLastNut


                End If

                If gridStep < grd_Process.Rows.Count Then

                    Dim nutX As Integer = CInt(grd_Process.Item("NutX", gridStep).Value)
                    Dim nutY As Integer = CInt(grd_Process.Item("NutY", gridStep).Value)
                    nutSp.Left = nutX
                    nutSp.Top = nutY
                    nutSp.FillColor = Color.Yellow

                    grd_Process.ClearSelection()
                    grd_Process.Rows(gridStep).Selected = True

                    led_InCycle.State = LBLed.LedState.Off
                    led_ResultOK.State = LBLed.LedState.Off
                    led_ResultNOK.State = LBLed.LedState.Off

                    ' Check for bit
                    Dim prevBit As String = grd_Process.Item("NutType", (gridStep - 1)).Value
                    Dim currBit As String = grd_Process.Item("NutType", gridStep).Value

                    If currBit = prevBit Then
                        ' Jump to position case
                        'globalBitOk = True
                        stepProcess = CaseSteps.OnScrewPosition
                    Else
                        stepProcess = CaseSteps.OnWaitForBit
                        lbl_BitWarning.ForeColor = Color.Red
                        lbl_BitWarning.Text = "Bit change. Put the bit to its location back."
                        ' Change bit
                        'txt_Info.Text = "Change bit."

                    End If

                Else
                    ' Do nothing

                End If

            Case CaseSteps.OnWaitForBit

                txt_Info.Text = stepProcess.ToString

                ' Check for bit
                Dim prevBit As String = grd_Process.Item("NutType", (gridStep - 1)).Value
                Dim currBit As String = grd_Process.Item("NutType", gridStep).Value

                ' Lock the previous bit
                PLCComm.PLCDO(PLCComm.Device("BITLC_" & prevBit), 1, res, req)

                ' Read bit on the position
                PLCComm.PLCDI(PLCComm.Device(prevBit), 1, PLCComm.data_from_dev, res, req)
                Dim bitSW As Integer = PLCComm.data_from_dev(0)

                If bitSW = 1 Then
                    lbl_BitWarning.Text = ""
                    ' Jump to bit selection case
                    stepProcess = CaseSteps.OnProcessStarted
                End If

            Case CaseSteps.OnLastNut

                txt_Info.Text = "Put the bit to its location back."
                lbl_BitWarning.ForeColor = Color.Red
                lbl_BitWarning.Text = "Put the bit to its location back."

                'If isProcessFinished Then
                Dim readBit As Integer = 0
                Dim bitLed As String = "BITLD_" & strLastNut

                ' last state enable check 
                PLCComm.PLCDI(PLCComm.Device(strLastNut), 1, PLCComm.data_from_dev, res, req)
                readBit = PLCComm.data_from_dev(0)

                If readBit = 1 Then
                    ' Turn off the led
                    PLCComm.PLCDO(PLCComm.Device(bitLed), 0, res, req)

                    gridStep = 0
                    ' Lock all bits
                    ' Lock all the bits. When bits button pressed, bit not released
                    PLCComm.PLCDO(PLCComm.Device("BITLC_M6_N"), 1, res, req)
                    PLCComm.PLCDO(PLCComm.Device("BITLC_M8_N"), 1, res, req)
                    PLCComm.PLCDO(PLCComm.Device("BITLC_M5_N"), 1, res, req)
                    isProcessFinished = False
                    tmr_Process.Enabled = False

                    txt_Info.Text = ""
                    lbl_BitWarning.Text = ""
                    stepProcess = CaseSteps.OnProcessStarted
                    ' Enable new barcode
                    txt_VariantBarcode.Enabled = True
                    txt_VariantBarcode.Select()
                End If

        End Select

        If Not (stepProcess = CaseSteps.OnLastNut) Then
            tmr_Process.Enabled = True
        End If

    End Sub

    Public Sub InitialBitboxCheck()

        ' Enable Locks
        ' Lock all the bits. When bits button pressed, bit not released
        PLCComm.PLCDO(PLCComm.Device("BITLC_M6_N"), 1, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLC_M8_N"), 1, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLC_M5_N"), 1, res, req)

        ' Disable leds
        PLCComm.PLCDO(PLCComm.Device("BITLD_M6_N"), 0, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLD_M8_N"), 0, res, req)
        PLCComm.PLCDO(PLCComm.Device("BITLD_M5_N"), 0, res, req)

        ' Check for bits
        Dim bitM6In As Integer = 0
        Dim bitM8In As Integer = 0
        Dim bitM5In As Integer = 0

        PLCComm.PLCDI(PLCComm.Device("M6_N"), 1, PLCComm.data_from_dev, res, req)
        bitM6In = PLCComm.data_from_dev(0)

        PLCComm.PLCDI(PLCComm.Device("M8_N"), 1, PLCComm.data_from_dev, res, req)
        bitM8In = PLCComm.data_from_dev(0)

        PLCComm.PLCDI(PLCComm.Device("M5_N"), 1, PLCComm.data_from_dev, res, req)
        bitM5In = PLCComm.data_from_dev(0)

        ' If placed properly 1 signal will be gotten
        If bitM6In = 1 And bitM8In = 1 And bitM5In = 1 Then
            ' All bits in their places
        Else
            ' Some bits are not in their position
            MessageBox.Show("Please place the bits.")

            Me.Close()
        End If


    End Sub
#Region "Barcode"


    ' Create barcode text
    Public Sub CreateBarcode(ByVal OrderNumber As String, ByVal StationId As String, ByVal OpId As String, ByVal DateTime As String)
        Dim strFile As String = "barcode.txt"
        Dim sw As IO.StreamWriter

        If IO.File.Exists(strFile) = False Then
            sw = IO.File.CreateText(strFile)
        Else
            IO.File.Delete(strFile)
            sw = IO.File.CreateText(strFile)
        End If
        sw.WriteLine("N")
        
        ' Part number
        Dim partNo As String = "Part Nr :" & OrderNumber
        sw.WriteLine("A50,5,0,3,1,1,N,""" & partNo & """")

        ' Station id
        StationId = "Station :" & StationId
        sw.WriteLine("A50,30,0,3,1,1,N,""" & StationId & """")

        ' Operator Id
        OpId = "Operator:" & OpId
        sw.WriteLine("A50,55,0,3,1,1,N,""" & OpId & """")

        ' Datetime
        sw.WriteLine("A50,80,0,3,1,1,N,""" & DateTime & """")

        ' Barcode
        sw.WriteLine("B50,105,0,1,2,5,100,B,""" & OrderNumber & """")

        sw.WriteLine("P1")
        'Önceki Büyük Hali
        '' Part number
        'Dim partNo As String = "Part Nr :" & OrderNumber
        'sw.WriteLine("A50,5,0,4,1,1,N,""" & partNo & """")

        '' Station id
        'StationId = "Station :" & StationId
        'sw.WriteLine("A50,50,0,4,1,1,N,""" & StationId & """")

        '' Operator Id
        'OpId = "Operator:" & OpId
        'sw.WriteLine("A50,100,0,4,1,1,N,""" & OpId & """")

        '' Datetime
        'sw.WriteLine("A50,150,0,4,1,1,N,""" & DateTime & """")

        '' Barcode
        'sw.WriteLine("B50,200,0,1,3,5,150,B,""" & OrderNumber & """")

        'sw.WriteLine("P1")
        sw.Close()
    End Sub

    ' Print Barcode
    Public Sub PrintBarcode(ByVal printerName As String)
        Dim proc As New System.Diagnostics.Process
        With proc.StartInfo
            .UseShellExecute = True
            .FileName = "cmd.exe"
            .Arguments = "/C copy barcode.txt ""\\127.0.0.1\" & printerName & ""
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        proc.Start()
        Do
        Loop While Not proc.WaitForExit(100)
    End Sub



    ' Usage
    ' First call CreateBarcode method and next line call PrintBarcode
    ' CreateBarcode(strOrderNumber, "Station1", "Mehmet", "11.07.2019 09:14:20")
    ' PrintBarcode("ZDesigner GC420t (EPL)")


#End Region

End Class