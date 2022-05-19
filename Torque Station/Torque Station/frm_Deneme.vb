
Imports System.IO
Imports System.IO.Ports
Imports System.Text

Public Class frm_Deneme

    Dim WithEvents PLCComm As New PLC
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)

    'Public Shared data_from_dev(7) As UInt32
    'Public data_to_dev() As UInt32

    Dim errCntr As Integer = 0


    Private Sub frm_Deneme_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If PLCComm.OpenConnection() > 0 Then

            'txt_Status.AppendText("Connected." & vbCrLf)
            tmr_Indicator.Enabled = True

        Else
            'txt_Status.AppendText("Not Connected." & vbCrLf)
            tmr_Indicator.Enabled = False
            MessageBox.Show("PLC Connection not found." & vbCrLf & "Please check your connection.")
            ' You can close conneciton.
            PLCComm.CloseConnection()
            'Me.Close()
        End If

        For i = 1 To 8
            cmb_SelectCycle.Items.Add(i)
        Next

    End Sub

    ' PLC Connection Error Event
    Private Sub PLCConnection() Handles PLCComm.PLCErrorEvent
        Select Case PLCComm.PLCError
            Case 0
                'txt_Status.AppendText("PLCNoError" & vbCrLf)
            Case 1
                'txt_Status.AppendText("PLCDIError" & vbCrLf)
            Case 2
                'txt_Status.AppendText("PLCDOError" & vbCrLf)
            Case 3
                'txt_Status.AppendText("PLCReadRamError" & vbCrLf)
            Case 4
                'txt_Status.AppendText("PLCWriteRamError" & vbCrLf)
        End Select

        If PLCComm.PLCError > 0 Then
            tmr_Indicator.Enabled = False
            errCntr = errCntr + 1
            If errCntr > 10 Then
                MessageBox.Show("Communication Error. Check your connection.")
                Exit Sub
            Else
                tmr_Indicator.Enabled = True
                errCntr = 0
            End If
        End If

    End Sub

    Public Sub checkinputState(ByVal inputBlock As String, ByVal p As Panel)

        PLCComm.PLCDI(inputBlock, 8, PLCComm.data_from_dev, res, req)
        Dim c As New CheckBox

        For Each ctrl As Control In p.Controls
            If (TypeOf ctrl Is CheckBox) And (ctrl.Name.ToString.StartsWith("X")) Then
                If (CInt(ctrl.Name.Remove(0, 1)) >= CInt(inputBlock.Remove(0, 1))) And (CInt(ctrl.Name.Remove(0, 1)) <= CInt(inputBlock.Remove(0, 1)) + 7) Then
                    c = DirectCast(ctrl, CheckBox)
                    If PLCComm.data_from_dev(CInt(ctrl.Name.Remove(0, 1)) Mod 10) = 1 Then
                        c.Checked = True
                    Else
                        c.Checked = False
                    End If
                End If
            End If
        Next

    End Sub

    Public Sub checkOutputState(ByVal outputBlock As String, ByVal p As Panel)

        PLCComm.PLCDI(outputBlock, 8, PLCComm.data_from_dev, res, req)
        Dim c As New CheckBox

        For Each ctrl As Control In p.Controls
            If (TypeOf ctrl Is CheckBox) And (ctrl.Name.ToString.StartsWith("Y")) Then
                If (CInt(ctrl.Name.Remove(0, 1)) >= CInt(outputBlock.Remove(0, 1))) And (CInt(ctrl.Name.Remove(0, 1)) <= CInt(outputBlock.Remove(0, 1)) + 7) Then
                    c = DirectCast(ctrl, CheckBox)
                    If PLCComm.data_from_dev(CInt(ctrl.Name.Remove(0, 1)) Mod 10) = 1 Then
                        c.Checked = True
                    Else
                        c.Checked = False
                    End If
                End If
            End If
        Next

    End Sub

    Private Sub Y20_CheckedChanged(sender As Object, e As EventArgs) Handles Y20.CheckedChanged, Y21.CheckedChanged, Y22.CheckedChanged, Y23.CheckedChanged, Y24.CheckedChanged, Y25.CheckedChanged, Y26.CheckedChanged, Y27.CheckedChanged,
        Y30.CheckedChanged, Y31.CheckedChanged, Y32.CheckedChanged, Y33.CheckedChanged, Y34.CheckedChanged, Y35.CheckedChanged, Y36.CheckedChanged, Y37.CheckedChanged,
        Y40.CheckedChanged, Y41.CheckedChanged, Y42.CheckedChanged, Y43.CheckedChanged, Y44.CheckedChanged, Y45.CheckedChanged, Y46.CheckedChanged, Y47.CheckedChanged


        If sender.CheckState = CheckState.Checked Then
            PLCComm.PLCDO(sender.name.ToString, 1, res, req)
        Else
            PLCComm.PLCDO(sender.name.ToString, 0, res, req)
        End If

    End Sub

    Private Sub PLCSocket() Handles PLCComm.PLCSocketErrorEvent
        'txt_SocketErrorStatus.AppendText(PLCComm.SocketError.ToString & vbCrLf)

        'If PLCComm.SocketError > 0 Then
        '    errCntr = errCntr + 1

        '    If errCntr > 3 Then
        '        MessageBox.Show("PLC Connection Error")
        '        Exit Sub
        '    End If
        'Else
        '    errCntr = 0
        'End If


    End Sub

    Private Sub tmr_Indicator_Tick(sender As Object, e As EventArgs) Handles tmr_Indicator.Tick
        'PLCComm.PLCReadRAM("D0",)

        'PLCComm.data_to_dev = New UInt32() {2500}
        'PLCComm.PLCReadRAM("D100", PLCComm.data_from_dev.Length, PLCComm.data_from_dev, res, req)
        'txt_AnalogInput.Text = PLCComm.data_from_dev(0).ToString

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

        checkinputState("X20", TLP_IO)
        checkinputState("X30", TLP_IO)
        checkinputState("X40", TLP_IO)

        checkOutputState("Y20", TLP_IO)
        checkOutputState("Y30", TLP_IO)
        checkOutputState("Y40", TLP_IO)

    End Sub


    Private Sub cmb_SelectCycle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_SelectCycle.SelectedIndexChanged
        Dim index As Integer = cmb_SelectCycle.SelectedIndex

        If index > 0 Then
            'MessageBox.Show(index)
            Select Case index
                Case 1
                    PLCComm.PLCDO("Y20", 1, res, req)
                    PLCComm.PLCDO("Y21", 0, res, req)
                    PLCComm.PLCDO("Y22", 0, res, req)
                Case 2
                    PLCComm.PLCDO("Y20", 0, res, req)
                    PLCComm.PLCDO("Y21", 1, res, req)
                    PLCComm.PLCDO("Y22", 0, res, req)
                Case 3
                    PLCComm.PLCDO("Y20", 1, res, req)
                    PLCComm.PLCDO("Y21", 1, res, req)
                    PLCComm.PLCDO("Y22", 0, res, req)
                Case 4
                    PLCComm.PLCDO("Y20", 0, res, req)
                    PLCComm.PLCDO("Y21", 0, res, req)
                    PLCComm.PLCDO("Y22", 1, res, req)
            End Select

        End If
    End Sub

    Private Sub btn_EnableSchraub_Click(sender As Object, e As EventArgs) Handles btn_EnableSchraub.Click
        PLCComm.PLCDO("Y25", 1, res, req)
    End Sub

    Private Sub btn_DisableSchraub_Click(sender As Object, e As EventArgs) Handles btn_DisableSchraub.Click
        PLCComm.PLCDO("Y25", 0, res, req)
    End Sub

End Class