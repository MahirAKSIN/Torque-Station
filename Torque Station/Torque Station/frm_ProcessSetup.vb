
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports Microsoft.VisualBasic.PowerPacks

Public Class frm_ProcessSetup

    Dim WithEvents shapeContainer As New ShapeContainer

    Dim isMouseDown As Boolean = False
    Dim mouseDownX As Integer
    Dim mouseDownY As Integer

    Dim prevLocation As New Point
    Dim location As New Point

    Dim shapeLocation As New Point

    Dim radius As Integer = 15

    Dim errProvider As New ErrorProvider
    Dim errProviderJob As New ErrorProvider


    Dim jobNo As Integer = 0
    Dim minTorque As Double = 0.0
    Dim maxTorque As Double = 0.0
    Dim minAngle As Integer = 0
    Dim maxAngle As Integer = 0


    Dim isDeviceValidated As Boolean = False
    Dim isAddressValidated As Boolean = False

    Dim isJobDescValidated As Boolean = False
    Dim isJobNoValidated As Boolean = False
    Dim isMinTorqueValidated As Boolean = False
    Dim isMaxTorqueValidated As Boolean = False
    Dim isMinAngleValidated As Boolean = False
    Dim isMaxAngleValidated As Boolean = False


    'Dim ini As New INIfile(IO.Directory.GetCurrentDirectory() & "\elopar.ini")

    Public LocalDB As New SQLiteTools("TorqueStation")

    ' PLC Connection
    Dim WithEvents PLCComm As New PLC
    Dim req As New StringBuilder(1024)
    Dim res As New StringBuilder(1024)
    Dim Logger As New LogFile(IO.Directory.GetCurrentDirectory() & "\Logs")

    Dim schraubCoordX As Integer = 0
    Dim schraubCoordY As Integer = 0

    Dim g_NutX As Integer = 0
    Dim g_NutY As Integer = 0

    Private Sub frm_DefineScrew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pb_Socket.MinimumSize = pb_Socket.MaximumSize

        shapeContainer.Parent = pb_Socket

        txt_Device.Enabled = False
        cmb_Type.Enabled = False
        txt_Address.Enabled = False

        txt_JobDesc.Enabled = False
        txt_JobNo.Enabled = False
        txt_MinTorque.Enabled = False
        txt_MaxTorque.Enabled = False
        txt_MinAngle.Enabled = False
        txt_MaxAngle.Enabled = False
        txt_issueP.Text=String.Empty
        ' Hide edit buttons. No need to use
        btn_EditIO.Hide()
        btn_EditJob.Hide()

        grd_PLCIO.DataSource = LocalDB.PopulateGrid("SELECT * FROM PLCIO")

        grd_JobDescription.DataSource = LocalDB.PopulateGrid("SELECT * FROM JOB")
        grd_JobDescription.ReadOnly = True

        cmb_Type.DataSource = LocalDB.PopulateComboBox("SELECT * FROM IOType", "Type", True)

        'grd_ProcessDesc.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC")

        ' Disable Save buttons
        btn_SaveIO.Enabled = False
        btn_SaveJob.Enabled = False

        If grd_PLCIO.Rows.Count > 0 Then
            btn_DeleteIO.Enabled = True
            btn_EditIO.Enabled = True
        Else
            btn_DeleteIO.Enabled = False
            btn_EditIO.Enabled = False
        End If

        If grd_JobDescription.Rows.Count > 0 Then
            btn_EditJob.Enabled = True
            btn_DeleteJob.Enabled = True
        Else
            btn_EditJob.Enabled = False
            btn_DeleteJob.Enabled = False
        End If

        ' Populate nuts
        cmb_NutType.DataSource = LocalDB.PopulateComboBox("SELECT Device FROM PLCIO WHERE Type='Input' AND Device LIKE 'M%' OR 'm%'", "Device", True)

        Dim item As String = String.Empty
        For i = 1 To 99
            If i < 10 Then
                item = "0" & i.ToString
            Else
                item = i.ToString
            End If
            cmb_ScrewOrder.Items.Add(item)
        Next

        cmb_JobNo.DataSource = LocalDB.PopulateComboBox("SELECT JobNo FROM JOB", "JobNo", True)

        btn_AddNut.Enabled = False
        btn_SaveNut.Enabled = False
        If grd_ProcessDesc.Rows.Count > 0 Then
            btn_DeleteNut.Enabled = True
            ' Create Shapes
            For i = 0 To grd_ProcessDesc.Rows.Count - 1
                Dim shapeX As Integer = CInt(grd_ProcessDesc.Item("NutX", i).Value)
                Dim shapeY As Integer = CInt(grd_ProcessDesc.Item("NutY", i).Value)
                Dim order As Integer = CInt(grd_ProcessDesc.Item("ScrewOrder", i).Value)

                CreateShape(shapeX, shapeY, order)

            Next
        Else
            btn_DeleteNut.Enabled = False
        End If

        ' Populate variant combobox
        cmb_SelectVariant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName From VARIANT", "VariantName", True)


        ' Connect to PLC
        If PLCComm.OpenConnection() > 0 Then
            'txt_Status.AppendText("Connected." & vbCrLf)
            tmr_Indicator.Enabled = True

        Else
            tmr_Indicator.Enabled = False
            'txt_Status.AppendText("Not Connected." & vbCrLf)
            MessageBox.Show("PLC Connection not found." & vbCrLf & "Please check your connection.")
            ' You can close conneciton.
            PLCComm.CloseConnection()
            'Me.Close()
        End If

    End Sub

    ' Disable validation on form closing
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.WParam.ToInt32 = &HF060 Then Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        MyBase.WndProc(m)
    End Sub

    Private Sub frm_DefineScrew_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MinTorque.KeyDown, txt_MinAngle.KeyDown, txt_MaxTorque.KeyDown, txt_MaxAngle.KeyDown, txt_JobNo.KeyDown, txt_JobDesc.KeyDown, txt_Device.KeyDown, txt_Address.KeyDown, MyBase.KeyDown, cmb_Type.KeyDown

        If e.KeyCode = Keys.Escape Then
            ' IO Definitions
            txt_Device.Enabled = False
            txt_Device.CausesValidation = False
            txt_Device.Clear()

            cmb_Type.SelectedIndex = 0
            cmb_Type.Enabled = False

            txt_Address.Enabled = False
            txt_Address.CausesValidation = False
            txt_Address.Clear()

            'errProvider.SetError(txt_Device, "")
            errProvider.Clear()

            ' Job Description
            txt_JobDesc.Enabled = False
            txt_JobDesc.CausesValidation = False
            txt_JobDesc.Clear()

            txt_JobNo.Enabled = False
            txt_JobNo.CausesValidation = False
            txt_JobNo.Clear()

            txt_MinTorque.Enabled = False
            txt_MinTorque.CausesValidation = False
            txt_MinTorque.Clear()

            txt_MaxTorque.Enabled = False
            txt_MaxTorque.CausesValidation = False
            txt_MaxTorque.Clear()

            txt_MinAngle.Enabled = False
            txt_MinAngle.CausesValidation = False
            txt_MinAngle.Clear()

            txt_MaxAngle.Enabled = False
            txt_MaxAngle.CausesValidation = False
            txt_MaxAngle.Clear()

            errProviderJob.Clear()


            ' Disable save buttons
            btn_SaveIO.Enabled = False
            btn_SaveJob.Enabled = False
        End If

    End Sub

    Private Sub tab_Main_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_Main.SelectedIndexChanged

        Dim tabIndex = tab_Main.SelectedIndex

        ' IO Definition
        If tabIndex = 0 Then

        End If

        ' Variant & layout desc tab
        If tabIndex = 1 Then

            shapeContainer.Shapes.Clear()
            cmb_Master.DataSource = Nothing
            cmb_Master.DataSource = LocalDB.PopulateComboBox("SELECT MasterName FROM PICTURE", "MasterName", True)

            btn_DeleteMaster.Enabled = False
            btn_DeleteVariant.Enabled = False

            cmb_Variant.DataSource = Nothing
            cmb_Variant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName FROM VARIANT", "VariantName", True)
        End If

        ' Process description tab
        If tabIndex = 2 Then
            ' Repopulate all
            cmb_SelectVariant.DataSource = Nothing
            cmb_SelectVariant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName From VARIANT", "VariantName", True)

            cmb_NutType.DataSource = Nothing
            cmb_NutType.DataSource = LocalDB.PopulateComboBox("SELECT Device FROM PLCIO WHERE Type='Input' AND Device LIKE 'M%' OR 'm%'", "Device", True)

            'cmb_ScrewOrder.DataSource = Nothing

            cmb_JobNo.DataSource = Nothing
            cmb_JobNo.DataSource = LocalDB.PopulateComboBox("SELECT JobNo FROM JOB", "JobNo", True)

        End If

    End Sub

#Region "Oval Shape"
    Private Sub OvalShape_MouseDown(sender As Object, e As MouseEventArgs)

        prevLocation = sender.Location
        location = e.Location

        isMouseDown = True

    End Sub

    Private Sub OvalShape_MouseMove(sender As Object, e As MouseEventArgs)

        If isMouseDown = True Then
            Dim deltaX As Integer = location.X - e.Location.X
            Dim deltaY As Integer = location.Y - e.Location.Y
            sender.Location = New Point(sender.Location.X - deltaX, sender.Location.Y - deltaY)

            If sender.Left < sender.Parent.ClientRectangle.Left Then
                sender.Left = sender.Parent.ClientRectangle.Left
                If sender.Top < sender.Parent.ClientRectangle.Top Then
                    sender.Top = sender.Parent.ClientRectangle.Top
                    If sender.Top + sender.Height > sender.Parent.ClientRectangle.Height Then
                        sender.Top = sender.Parent.ClientRectangle.Height - Height
                        If sender.Left + sender.Width > sender.Parent.ClientRectangle.Width Then
                            sender.Left = sender.Parent.ClientRectangle.Width - sender.Width
                        End If
                    End If
                End If
            End If

            txt_NutPos.Text = "X:" & sender.Left.ToString & ", Y:" & sender.Top.ToString

        End If
    End Sub

    Private Sub OvalShape_MouseUp(sender As Object, e As MouseEventArgs)

        isMouseDown = False
        'txt.AppendText("Shape name: " & sender.Name.ToString & vbCrLf)
        'txt.AppendText("Shape new loc:" & sender.Location.ToString)
        btn_SaveNut.Enabled = True

        g_NutX = sender.Left
        g_NutY = sender.Top

    End Sub

    Private Sub OvalShape_Click(sender As Object, e As EventArgs)
        'btn_DeletePoint.Enabled = True

    End Sub

    Private Sub pb_Socket_MouseClick(sender As Object, e As MouseEventArgs) Handles pb_Socket.MouseClick
        isMouseDown = False

        For i = 0 To shapeContainer.Shapes.Count - 1
            shapeContainer.Shapes.Item(i).SendToBack()
        Next
        pb_Socket.Focus()
        'btn_DeletePoint.Enabled = False
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        radius = NumericUpDown1.Value

        For i = 0 To shapeContainer.Shapes.Count - 1
            shapeContainer.Shapes.Item(i).Width = radius
            shapeContainer.Shapes.Item(i).Height = radius
        Next
    End Sub

#End Region

#Region "IO Definitions"

    Private Sub btn_NewIO_Click(sender As Object, e As EventArgs) Handles btn_NewIO.Click

        txt_Device.Clear()
        txt_Device.CausesValidation = True
        txt_Device.Enabled = True
        txt_Device.Focus()

        cmb_Type.Enabled = True
        cmb_Type.SelectedIndex = 0

        'txt_Address.Enabled = True
        txt_Address.CausesValidation = True
        txt_Address.Clear()

        btn_SaveIO.Enabled = True

    End Sub

    Private Sub btn_EditIO_Click(sender As Object, e As EventArgs) Handles btn_EditIO.Click

        txt_Device.Text = grd_PLCIO.SelectedRows(0).Cells(0).Value.ToString
        cmb_Type.SelectedItem = grd_PLCIO.SelectedRows(0).Cells(1).Value.ToString
        txt_Address.Text = grd_PLCIO.SelectedRows(0).Cells(2).Value.ToString

    End Sub

    Private Sub btn_SaveIO_Click(sender As Object, e As EventArgs) Handles btn_SaveIO.Click

        If isDeviceValidated And isAddressValidated Then
            'MessageBox.Show("Everything is validated")
            '    ' Do the saving
            LocalDB.ExecuteNonQuery("INSERT INTO PLCIO VALUES ('" & txt_Device.Text & "', '" & cmb_Type.SelectedItem.ToString & "','" & txt_Address.Text & "')")
            grd_PLCIO.DataSource = Nothing
            grd_PLCIO.DataSource = LocalDB.PopulateGrid("SELECT * FROM PLCIO")

            txt_Address.Clear()
            cmb_Type.SelectedIndex = 0
            txt_Device.Clear()

            txt_Address.Enabled = False
            cmb_Type.Enabled = False
            txt_Device.Enabled = False

            btn_SaveIO.Enabled = False

            isDeviceValidated = False
            isAddressValidated = False

        Else
            MessageBox.Show("Please fill the the areas.")
        End If

    End Sub

    Private Sub btn_DeleteIO_Click(sender As Object, e As EventArgs) Handles btn_DeleteIO.Click

        Dim rowCount As Integer = grd_PLCIO.Rows.Count

        If rowCount > 0 Then
            Dim device As String = grd_PLCIO.Item("Device", grd_PLCIO.CurrentRow.Index).Value.ToString
            Dim type As String = grd_PLCIO.Item("Type", grd_PLCIO.CurrentRow.Index).Value.ToString
            Dim addr As String = grd_PLCIO.Item("Address", grd_PLCIO.CurrentRow.Index).Value.ToString

            'MessageBox.Show("dev: " & device & ", type: " & type & ", addr: " & addr)

            LocalDB.ExecuteNonQuery("DELETE FROM PLCIO WHERE Device='" & device & "' AND Type='" & type & "' AND Address='" & addr & "' ")

        End If

        grd_PLCIO.DataSource = Nothing
        grd_PLCIO.DataSource = LocalDB.PopulateGrid("SELECT * FROM PLCIO")

        grd_PLCIO.Refresh()

        rowCount = grd_PLCIO.Rows.Count

        If rowCount > 0 Then
            btn_EditIO.Enabled = True
            btn_DeleteIO.Enabled = True
        Else
            btn_EditIO.Enabled = False
            btn_DeleteIO.Enabled = False
        End If

    End Sub

    Private Sub txt_Device_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_Device.Validating

        ' If textbox is empty
        If Not (txt_Device.Text.Length > 0 And txt_Device.Text.Length < 20) Then
            e.Cancel = True
            'isValidated = False
            errProvider.SetError(txt_Device, "Invalid Device Name")
        Else
            isDeviceValidated = True
            errProvider.SetError(txt_Device, "")
        End If
    End Sub

    Private Sub txt_Device_Validated(sender As Object, e As EventArgs) Handles txt_Device.Validated
        errProvider.SetError(txt_Device, "")
        isDeviceValidated = True
    End Sub

    Private Sub txt_Address_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_Address.Validating

        If cmb_Type.SelectedItem.ToString = "Input" Then

            If Not ((txt_Address.Text Like "X#") Or (txt_Address.Text Like "X##")) Then
                e.Cancel = True
                txt_Address.Select(0, txt_Address.Text.Length)
                errProvider.SetError(txt_Address, "Invalid Adress Format")
            Else
                isAddressValidated = True
                errProvider.SetError(txt_Address, "")
            End If

        End If

        If cmb_Type.SelectedItem.ToString = "Output" Then
            If Not ((txt_Address.Text Like "Y#") Or (txt_Address.Text Like "Y##")) Then
                e.Cancel = True
                txt_Address.Select(0, txt_Address.Text.Length)
                errProvider.SetError(txt_Address, "Invalid Adress Format")
            Else
                isAddressValidated = True
                errProvider.SetError(txt_Address, "")
            End If
        End If

        If cmb_Type.SelectedItem.ToString = "Other" Then
            If Not ((txt_Address.Text Like "D###") Or (txt_Address.Text Like "M###")) Then
                e.Cancel = True
                txt_Address.Select(0, txt_Address.Text.Length)
                errProvider.SetError(txt_Address, "Invalid Adress Format")
            Else
                isAddressValidated = True
                errProvider.SetError(txt_Address, "")
            End If
        End If

    End Sub

    Private Sub txt_Address_Validated(sender As Object, e As EventArgs) Handles txt_Address.Validated
        errProvider.SetError(txt_Address, "")
        isAddressValidated = True
    End Sub

    Private Sub cmb_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Type.SelectedIndexChanged
        If cmb_Type.SelectedIndex > 0 Then
            txt_Address.Enabled = True
            txt_Address.Focus()
        Else
            txt_Address.Enabled = False
        End If
    End Sub

    Private Sub grd_PLCIO_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles grd_PLCIO.RowsAdded
        btn_EditIO.Enabled = True
        btn_DeleteIO.Enabled = True
    End Sub

#End Region

#Region "Job Description"
    Private Sub btn_NewJob_Click(sender As Object, e As EventArgs) Handles btn_NewJob.Click

        ' Job Description
        txt_JobDesc.Enabled = True
        txt_JobDesc.CausesValidation = True
        txt_JobDesc.Clear()
        txt_JobDesc.Focus()

        txt_JobNo.Enabled = True
        txt_JobNo.CausesValidation = True
        txt_JobNo.Clear()

        txt_MinTorque.Enabled = True
        txt_MinTorque.CausesValidation = True
        txt_MinTorque.Clear()

        txt_MaxTorque.Enabled = True
        txt_MaxTorque.CausesValidation = True
        txt_MaxTorque.Clear()

        txt_MinAngle.Enabled = True
        txt_MinAngle.CausesValidation = True
        txt_MinAngle.Clear()

        txt_MaxAngle.Enabled = True
        txt_MaxAngle.CausesValidation = True
        txt_MaxAngle.Clear()

        btn_SaveJob.Enabled = True

    End Sub

    Private Sub btn_EditJob_Click(sender As Object, e As EventArgs)

        grd_JobDescription.ReadOnly = False
        'grd_JobDescription.CurrentCell.ReadOnly = False
        grd_JobDescription.BeginEdit(True)

    End Sub

    Private Sub btn_DeleteJob_Click(sender As Object, e As EventArgs) Handles btn_DeleteJob.Click

        Dim rowCount As Integer = grd_JobDescription.Rows.Count

        If rowCount > 0 Then
            Dim jobDesc As String = grd_JobDescription.Item("JobDesc", grd_JobDescription.CurrentRow.Index).Value.ToString
            Dim jobNo As Integer = CInt(grd_JobDescription.Item("JobNo", grd_JobDescription.CurrentRow.Index).Value)

            Dim minTorque As Double = CDbl(grd_JobDescription.Item("MinTorque", grd_JobDescription.CurrentRow.Index).Value)
            Dim maxTorque As Double = CDbl(grd_JobDescription.Item("MaxTorque", grd_JobDescription.CurrentRow.Index).Value)

            Dim minAngle As Double = CDbl(grd_JobDescription.Item("MinAngle", grd_JobDescription.CurrentRow.Index).Value)
            Dim maxAngle As Double = CDbl(grd_JobDescription.Item("MaxAngle", grd_JobDescription.CurrentRow.Index).Value)

            LocalDB.ExecuteNonQuery("DELETE FROM JOB WHERE JobDesc='" & jobDesc & "' AND JobNo=" & jobNo & " AND MinTorque=" & minTorque & " AND MaxTorque=" & maxTorque & " AND MinAngle=" & minAngle & " AND MaxAngle=" & maxAngle & "")
        End If

        grd_JobDescription.DataSource = Nothing
        grd_JobDescription.DataSource = LocalDB.PopulateGrid("SELECT * FROM JOB")
        grd_JobDescription.Refresh()

        ' Check row count
        rowCount = grd_JobDescription.Rows.Count

        If rowCount > 0 Then
            btn_EditJob.Enabled = True
            btn_DeleteJob.Enabled = True
        Else
            btn_EditJob.Enabled = False
            btn_DeleteJob.Enabled = False
        End If

    End Sub

    Private Sub btn_SaveJob_Click(sender As Object, e As EventArgs) Handles btn_SaveJob.Click

        'MessageBox.Show("Desc: " & jobDesc & vbCrLf &
        '                "Job No: " & jobNo)
        If isJobDescValidated And isJobNoValidated And isMinTorqueValidated And
                isMaxTorqueValidated And isMinAngleValidated And isMaxAngleValidated Then

            LocalDB.ExecuteNonQuery("INSERT INTO JOB VALUES ('" & txt_JobDesc.Text & "', " & jobNo & "," & minTorque & ", " & maxTorque & ", " & minAngle & " ," & maxAngle & ")")
            grd_JobDescription.DataSource = Nothing
            grd_JobDescription.DataSource = LocalDB.PopulateGrid("SELECT * FROM JOB")

            txt_JobDesc.Clear()
            txt_JobNo.Clear()
            txt_MinTorque.Clear()
            txt_MaxTorque.Clear()
            txt_MinAngle.Clear()
            txt_MaxAngle.Clear()

            txt_JobDesc.Enabled = False
            txt_JobNo.Enabled = False
            txt_MinTorque.Enabled = False
            txt_MaxTorque.Enabled = False
            txt_MinAngle.Enabled = False
            txt_MaxAngle.Enabled = False

            btn_SaveJob.Enabled = False

            isJobDescValidated = False
            isJobNoValidated = False
            isMinTorqueValidated = False
            isMaxTorqueValidated = False
            isMinAngleValidated = False
            isMaxAngleValidated = False

        Else
            MessageBox.Show("Please fill the the areas.")

        End If

    End Sub

    Private Sub txt_JobDesc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_JobDesc.Validating
        ' If textbox is empty
        If Not (txt_JobDesc.Text.Length > 0) Then
            e.Cancel = True
            errProviderJob.SetError(txt_JobDesc, "Empty Job Description ")
        Else
            isJobDescValidated = True
            errProviderJob.SetError(txt_JobDesc, "")
        End If
    End Sub

    Private Sub txt_JobDesc_Validated(sender As Object, e As EventArgs) Handles txt_JobDesc.Validated
        errProviderJob.SetError(txt_JobDesc, "")
        isJobDescValidated = True
    End Sub

    Private Sub txt_JobNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_JobNo.Validating

        If Not Integer.TryParse(txt_JobNo.Text, jobNo) Then
            e.Cancel = True
            errProviderJob.SetError(txt_JobNo, "Invalid Job No.")
        Else
            If Not (jobNo > 0 And jobNo < 32) Then
                e.Cancel = True
                errProviderJob.SetError(txt_JobNo, "Invalid Job No.")
            Else
                isJobNoValidated = True
                errProviderJob.SetError(txt_JobNo, "")
            End If
        End If

    End Sub

    Private Sub txt_JobNo_Validated(sender As Object, e As EventArgs) Handles txt_JobNo.Validated
        errProviderJob.SetError(txt_JobNo, "")
        isJobNoValidated = True
    End Sub

    Private Sub txt_MinTorque_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_MinTorque.Validating

        If Not Double.TryParse(txt_MinTorque.Text, minTorque) Then
            e.Cancel = True
            errProviderJob.SetError(txt_MinTorque, "Invalid Torque Value." & vbCrLf & "Tip: Use dot(.) for decimal")
        Else
            isMinTorqueValidated = True
            errProviderJob.SetError(txt_MinTorque, "")
        End If

    End Sub

    Private Sub txt_MinTorque_Validated(sender As Object, e As EventArgs) Handles txt_MinTorque.Validated
        errProviderJob.SetError(txt_MinTorque, "")
        isMinTorqueValidated = True
    End Sub

    Private Sub txt_MaxTorque_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_MaxTorque.Validating

        If Not Double.TryParse(txt_MaxTorque.Text, maxTorque) Then
            e.Cancel = True
            errProviderJob.SetError(txt_MaxTorque, "Invalid Torque Value." & vbCrLf & "Tip: Use dot(.) for decimal")
        Else
            isMaxTorqueValidated = True
            errProviderJob.SetError(txt_MaxTorque, "")
        End If
    End Sub

    Private Sub txt_MaxTorque_Validated(sender As Object, e As EventArgs) Handles txt_MaxTorque.Validated
        errProviderJob.SetError(txt_MaxTorque, "")
        isMaxTorqueValidated = True
    End Sub

    Private Sub txt_MinAngle_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_MinAngle.Validating

        If Not Integer.TryParse(txt_MinAngle.Text, minAngle) Then
            e.Cancel = True
            errProviderJob.SetError(txt_MinAngle, "Invalid Angle Value.")
            'Else
            '    If Not (minAngle > 0 And jobNo < 99) Then
            '        e.Cancel = True
            '        errProviderJob.SetError(txt_JobNo, "Invalid Job No.")
            '    End If
        Else
            isMinAngleValidated = True
            errProviderJob.SetError(txt_MinAngle, "")
        End If

    End Sub

    Private Sub txt_MinAngle_Validated(sender As Object, e As EventArgs) Handles txt_MinAngle.Validated
        errProviderJob.SetError(txt_MinAngle, "")
        isMinAngleValidated = True
    End Sub

    Private Sub txt_MaxAngle_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txt_MaxAngle.Validating

        If Not Integer.TryParse(txt_MaxAngle.Text, maxAngle) Then
            e.Cancel = True
            errProviderJob.SetError(txt_MaxAngle, "Invalid Angle Value.")
            'Else
            '    If Not (minAngle > 0 And jobNo < 99) Then
            '        e.Cancel = True
            '        errProviderJob.SetError(txt_JobNo, "Invalid Job No.")
            '    End If
        Else
            isMaxAngleValidated = True
            errProviderJob.SetError(txt_MaxAngle, "")
        End If
    End Sub

    Private Sub txt_MaxAngle_Validated(sender As Object, e As EventArgs) Handles txt_MaxAngle.Validated
        errProviderJob.SetError(txt_MaxAngle, "")
        isMaxAngleValidated = True
    End Sub

    Private Sub grd_JobDescription_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles grd_JobDescription.RowsAdded
        btn_EditJob.Enabled = True
        btn_DeleteJob.Enabled = True

    End Sub

#End Region

#Region "Variant & Layout"
    Private Sub cmb_Master_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Master.SelectedIndexChanged
        Dim index As Integer = cmb_Master.SelectedIndex

        If index > 0 Then
            Dim masterName = cmb_Master.SelectedItem.ToString
            pb_Layout.Image = LocalDB.GetImage("SELECT MasterPicture FROM PICTURE WHERE MasterName='" & masterName & "'", "MasterPicture")
            btn_DeleteMaster.Enabled = True
        Else
            btn_DeleteMaster.Enabled = False
            pb_Layout.Image = Nothing
        End If
    End Sub

    Private Sub btn_AddMaster_Click(sender As Object, e As EventArgs) Handles btn_AddMaster.Click
        If (txt_MasterName.Text.Length <= 0 And pb_Layout.Image Is Nothing) Or (txt_MasterName.Text.Length > 0 And pb_Layout.Image Is Nothing) Or
            txt_MasterName.Text.Length <= 0 Then
            MessageBox.Show("Please enter Master name and select master picture.")
        Else
            ' Save the master
            Dim existMasterName As String = LocalDB.GetSingleValue("SELECT * FROM PICTURE WHERE MasterName='" & txt_MasterName.Text & "'", "MasterName")
            ' Image comparasion not working 
            'Dim existMasterImage As Image = LocalDB.GetImage("SELECT MasterPicture FROM PICTURE WHERE MasterName='" & txt_MasterName.Text & "'", "MasterPicture")
            'If existMasterImage Is pb_Layout.Image Then
            '    MessageBox.Show("Same images")
            'End If
            If existMasterName.Length > 0 Then
                ' Master exist, enter a different name
                MessageBox.Show("Please enter a different master name.")
                txt_MasterName.Focus()
                'MessageBox.Show("db mastername:" & existMasterName)
            Else
                ' New master save
                LocalDB.SetImage("INSERT INTO PICTURE VALUES('" & txt_MasterName.Text & "',@MasterPicture)", "@MasterPicture", pb_Layout.Image)
                cmb_Master.DataSource = Nothing
                cmb_Master.DataSource = LocalDB.PopulateComboBox("SELECT MasterName FROM PICTURE", "MasterName", True)

                MessageBox.Show("Master saved.")
                pb_Layout.Image = Nothing
                txt_MasterName.Clear()
            End If


        End If
    End Sub

    Private Sub btn_DeleteMaster_Click(sender As Object, e As EventArgs) Handles btn_DeleteMaster.Click
        If cmb_Master.SelectedIndex > 0 Then

            MessageBox.Show("Master and its related variants and process definitions will be deleted.")
            Dim masterName As String = cmb_Master.SelectedItem.ToString


            LocalDB.ExecuteNonQuery("DELETE FROM PICTURE WHERE MasterName='" & masterName & "'")
            ' Two trigger created on db. Deletes realted variants and process definitions
            pb_Layout.Image = Nothing
            cmb_Master.DataSource = Nothing
            cmb_Master.DataSource = LocalDB.PopulateComboBox("SELECT MasterName FROM PICTURE", "MasterName", True)

            cmb_Variant.DataSource = Nothing
            cmb_Variant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName FROM VARIANT", "VariantName", True)
        Else
            MessageBox.Show("Please select a master")
        End If
    End Sub

    Private Sub btn_SelectPicture_Click(sender As Object, e As EventArgs) Handles btn_SelectPicture.Click

        openFileDialog.Filter = "Image Files (BMP,JPG,PNG)|*.BMP;*.JPG;*.PNG;"
        Dim dlgResult As DialogResult = openFileDialog.ShowDialog()

        Dim isValidImage As Boolean = False
        If dlgResult = DialogResult.OK Then
            'MessageBox.Show("dialog result")
            ' Get file name
            Dim filePathName As String = openFileDialog.FileName
            Dim fileName As String = IO.Path.GetFileName(openFileDialog.FileName)


            Try
                Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(filePathName)
                isValidImage = True
            Catch generatedExceptionName As OutOfMemoryException
                ' Image.FromFile throws an OutOfMemoryException  
                ' if the file does not have a valid image format or 
                ' GDI+ does not support the pixel format of the file. 
                ' 
                'Return False
                isValidImage = False
            End Try

            If isValidImage Then

                'Dim fileData As Byte() = File.ReadAllBytes(filePathName)
                pb_Layout.Image = Image.FromFile(filePathName)
                'LocalDB.SetImage("INSERT INTO PICTURE VALUES('" & fileName & "',@MasterPicture)", "@MasterPicture", pb_Layout.Image)
            Else
                MessageBox.Show("File is not an valid image.")
            End If

            'MessageBox.Show(filePathName & " file name: " & fileName)

        Else
            MessageBox.Show("Please select a picture file.")
        End If
    End Sub

    Private Sub cmb_Variant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Variant.SelectedIndexChanged
        Dim index As Integer = cmb_Variant.SelectedIndex

        If index > 0 Then
            Dim variantName = cmb_Variant.SelectedItem.ToString
            Dim masterName As String = LocalDB.GetSingleValue("SELECT * FROM VARIANT WHERE VariantName='" & variantName & "'", "MasterName")
            'MessageBox.Show("Master name: " & masterName)
            pb_Layout.Image = LocalDB.GetImage("SELECT MasterPicture FROM PICTURE WHERE MasterName='" & masterName & "'", "MasterPicture")
            btn_DeleteVariant.Enabled = True
        Else
            btn_DeleteVariant.Enabled = False
            pb_Layout.Image = Nothing
        End If
    End Sub

    'Private Sub txt_VariantName_TextChanged(sender As Object, e As EventArgs)
    '    If txt_VariantName.Text.Length > 0 Then
    '        btn_AddNut.Enabled = True
    '    Else
    '        btn_AddNut.Enabled = False
    '    End If
    'End Sub

    Private Sub btn_AddVariant_Click(sender As Object, e As EventArgs) Handles btn_AddVariant.Click

        If (txt_VariantName.Text.Length <= 0 And cmb_Master.SelectedIndex <= 0) Or (txt_VariantName.Text.Length > 0 And cmb_Master.SelectedIndex <= 0) Then
            MessageBox.Show("Please select master and enter variant name.")
        Else
            ' Check for variant name and master name
            Dim variantName As String = txt_VariantName.Text
            Dim issue As String = txt_issue.Text
            Dim existVariant As String = LocalDB.GetSingleValue("SELECT VariantName FROM VARIANT WHERE VariantName='" & variantName & "'", "VariantName")
            'MessageBox.Show("Exist variant name: " & existVariant)
            If existVariant.Length > 0 Then
                ' Variant exist
                MessageBox.Show("Please enter a different variant name.")
                txt_VariantName.Focus()
                txt_issue.Focus()
            Else
                ' New variant save
                LocalDB.ExecuteNonQuery("INSERT INTO VARIANT Values('" & variantName & "','" & issue & "','" & cmb_Master.SelectedItem.ToString & "')")
                cmb_Variant.DataSource = Nothing
                cmb_Variant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName FROM VARIANT", "VariantName", True)

                MessageBox.Show("Variant saved.")
                pb_Layout.Image = Nothing
                txt_VariantName.Clear()
                txt_issue.Clear()
            End If
        End If
    End Sub

    Private Sub btn_DeleteVariant_Click(sender As Object, e As EventArgs) Handles btn_DeleteVariant.Click
        ' Delete variant and its related process desc
        If cmb_Variant.SelectedIndex > 0 Then
            Dim variantName As String = cmb_Variant.SelectedItem.ToString
            MessageBox.Show("Variant and tis related process descriptions will be deleted.")
            LocalDB.ExecuteNonQuery("DELETE FROM PROCESSDESC WHERE VariantName='" & variantName & "'")
            LocalDB.ExecuteNonQuery("DELETE FROM VARIANT WHERE VariantName='" & variantName & "'")
            pb_Layout.Image = Nothing

            cmb_Variant.DataSource = Nothing
            cmb_Variant.DataSource = LocalDB.PopulateComboBox("SELECT VariantName FROM VARIANT", "VariantName", True)
            cmb_Variant.SelectedIndex = 0
        Else
            ' Warn for variant selection
            ' You may no need to warn. If index <= 0 delete button disabled
        End If
    End Sub

#End Region

#Region "Process Description"

    Private Sub btn_AddNut_Click(sender As Object, e As EventArgs) Handles btn_AddNut.Click

        'MessageBox.Show("Variant: " & txt_VariantName.Text & vbCrLf &
        '                "Nut type: " & cmb_NutType.SelectedIndex.ToString & vbCrLf &
        '                "Screw order: " & cmb_ScrewOrder.SelectedIndex & vbCrLf &
        '                "Job No: " & cmb_JobNo.SelectedIndex.ToString)

        If (cmb_NutType.SelectedIndex > 0 And cmb_ScrewOrder.SelectedIndex >= 0 And cmb_JobNo.SelectedIndex > 0) Then
            'MessageBox.Show("Buraya giriyor mu")
            ' Add a nut to screen
            Dim ovalSp As New PowerPacks.OvalShape
            'Dim cnt As Integer = shapeContainer.Shapes.Count
            Dim objName As String = "nutSp_" & cmb_ScrewOrder.SelectedItem.ToString
            ovalSp.Name = objName
            ovalSp.Parent = shapeContainer
            ovalSp.Left = 10
            ovalSp.Top = 10
            ovalSp.Width = radius
            ovalSp.Height = radius
            ovalSp.FillStyle = PowerPacks.FillStyle.Solid
            ovalSp.FillColor = Color.Yellow

            AddHandler ovalSp.Click, AddressOf Me.OvalShape_Click
            AddHandler ovalSp.MouseDown, AddressOf Me.OvalShape_MouseDown
            AddHandler ovalSp.MouseMove, AddressOf Me.OvalShape_MouseMove
            AddHandler ovalSp.MouseUp, AddressOf Me.OvalShape_MouseUp

            btn_AddNut.Enabled = False

            ' Get the position of Nut
            txt_NutPos.Text = "X:" & ovalSp.Left.ToString & ", Y:" & ovalSp.Top.ToString
        Else
            MessageBox.Show("Please select nut type, screw order and job no.")
        End If

    End Sub

    Private Sub btn_DeleteNut_Click(sender As Object, e As EventArgs) Handles btn_DeleteNut.Click

        ' Get the item from the grid
        Dim itemX As Integer = CInt(grd_ProcessDesc.Item("NutX", grd_ProcessDesc.CurrentRow.Index).Value)
        Dim itemY As Integer = CInt(grd_ProcessDesc.Item("NutY", grd_ProcessDesc.CurrentRow.Index).Value)
        Dim strScrewOrder As String = grd_ProcessDesc.Item("ScrewOrder", grd_ProcessDesc.CurrentRow.Index).Value
        Dim nutName As String = "nutSp_" & strScrewOrder



        For Each shape In shapeContainer.Shapes
            If shape.Name = nutName Then
                'MessageBox.Show("This is the nut")
            End If

            If shape.Left = itemX And shape.Top = itemY Then
                MessageBox.Show("Nut on location:" & shape.Left.ToString & "," & shape.Top.ToString & " will be deleted.")
                Dim variantName As String = grd_ProcessDesc.Item("VariantName", grd_ProcessDesc.CurrentRow.Index).Value.ToString
                Dim issue As String = grd_ProcessDesc.Item("Issue", grd_ProcessDesc.CurrentRow.Index).Value.ToString
                Dim nutType As String = grd_ProcessDesc.Item("NutType", grd_ProcessDesc.CurrentRow.Index).Value.ToString
                Dim screwOrder As Integer = CInt(grd_ProcessDesc.Item("ScrewOrder", grd_ProcessDesc.CurrentRow.Index).Value)
                Dim jobNo As Integer = CInt(grd_ProcessDesc.Item("JobNo", grd_ProcessDesc.CurrentRow.Index).Value)

                LocalDB.ExecuteNonQuery("DELETE FROM PROCESSDESC WHERE VariantName='" & variantName & "' AND Issue='" & issue & "' AND NutType='" & nutType & "' AND ScrewOrder=" & screwOrder & " AND JobNo=" & jobNo & " AND NutX=" & itemX & " AND NutY=" & itemY & "")
                ' Dispose the shape
                'shapeContainer.Dispose()
                shape.Dispose()

                grd_ProcessDesc.DataSource = Nothing
                ' MBL 22.08.2019
                grd_ProcessDesc.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC WHERE VariantName='" & cmb_SelectVariant.SelectedItem.ToString & "'  ORDER BY ScrewOrder ASC")

                Dim orderItem As String = String.Empty
                If screwOrder < 10 Then
                    orderItem = screwOrder.ToString.PadLeft(2, "0")
                Else
                    orderItem = screwOrder.ToString
                End If
                cmb_ScrewOrder.Items.Add(orderItem)

                cmb_ScrewOrder.Sorted = True
                Exit For
            End If
        Next

        If grd_ProcessDesc.Rows.Count > 0 Then
            btn_DeleteNut.Enabled = True
        Else
            btn_DeleteNut.Enabled = False
        End If

        'For i = 0 To shapeContainer.Shapes.Count - 1
        '    If shapeContainer.Shapes.Item(i).Left = itemX Then
        '        shapeContainer.Shapes.Item(i).Dispose()
        '    End If
        '    Exit For
        'Next

    End Sub

    Private Sub btn_SaveNut_Click(sender As Object, e As EventArgs) Handles btn_SaveNut.Click
        If (cmb_NutType.SelectedIndex > 0 And cmb_ScrewOrder.SelectedIndex >= 0 And cmb_JobNo.SelectedIndex > 0) Then
            Dim variantName As String = cmb_SelectVariant.SelectedItem.ToString
            Dim issue As String = txt_issueP.Text.ToString
            Dim nutType As String = cmb_NutType.SelectedItem.ToString
            Dim screwOrder As Integer = CInt(cmb_ScrewOrder.SelectedItem.ToString)
            Dim jobNo As Integer = CInt(cmb_JobNo.SelectedItem.ToString)
            'Dim nutX As Integer = CInt()
            'Dim nutY As Integer = CInt()

            Dim coordX As Integer = 0
            Dim coordY As Integer = 0

            coordX = schraubCoordX
            coordY = schraubCoordY

            Dim picFile As String = cmb_SelectVariant.SelectedItem.ToString

            'MessageBox.Show("Variant: " & variantName & vbCrLf &
            '                "nutType: " & nutType & vbCrLf &
            '                "screwOrder: " & screwOrder.ToString & vbCrLf &
            '                "jobNo: " & jobNo.ToString & vbCrLf &
            '                "nutX: " & g_NutX.ToString & vbCrLf &
            '                "nutY: " & g_NutY & vbCrLf)


            ' Check if the order exists in grid
            'Dim orderInGrid As Integer = 0
            If grd_ProcessDesc.Rows.Count > 1 Then
                For i = 0 To grd_ProcessDesc.Rows.Count
                    'orderInGrid = CInt(grd_ProcessDesc.Item("Order", i).Value)
                    If grd_ProcessDesc.Item("ScrewOrder", i).Value.ToString.Contains(cmb_ScrewOrder.SelectedItem.ToString) Then
                        'If screwOrder = CInt(grd_ProcessDesc.Item("ScrewOrder", i).Value) Then
                        MessageBox.Show("Screw order already exists.")

                    Else
                        ' Insert into db
                        LocalDB.ExecuteNonQuery("INSERT INTO PROCESSDESC Values('" & variantName & "','" & issue & "', '" & nutType & "', " & screwOrder & "," & jobNo & "," & g_NutX & "," & g_NutY & "," & coordX & "," & coordY & ")")

                        grd_ProcessDesc.DataSource = Nothing
                        ' MBL 22.08.2019
                        grd_ProcessDesc.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC WHERE VariantName='" & cmb_SelectVariant.SelectedItem.ToString & "'  ORDER BY ScrewOrder ASC")
                        btn_SaveNut.Enabled = False

                        cmb_NutType.SelectedIndex = 0

                        cmb_ScrewOrder.Items.RemoveAt(cmb_ScrewOrder.Items.IndexOf(screwOrder.ToString.PadLeft(2, "0")))
                        cmb_ScrewOrder.SelectedIndex = 0
                        cmb_JobNo.SelectedIndex = 0

                        btn_DeleteNut.Enabled = True
                        btn_AddNut.Enabled = True
                        'Exit For
                    End If
                    Exit For
                Next
                ' First time insertion
            Else
                LocalDB.ExecuteNonQuery("INSERT INTO PROCESSDESC Values('" & variantName & "','" & issue & "', '" & nutType & "', " & screwOrder & "," & jobNo & "," & g_NutX & "," & g_NutY & "," & coordX & "," & coordY & ")")

                grd_ProcessDesc.DataSource = Nothing
                ' MBL 22.08.2019
                grd_ProcessDesc.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC WHERE VariantName='" & cmb_SelectVariant.SelectedItem.ToString & "'  ORDER BY ScrewOrder ASC")
                btn_SaveNut.Enabled = False

                cmb_NutType.SelectedIndex = 0
                cmb_ScrewOrder.Items.RemoveAt(cmb_ScrewOrder.Items.IndexOf(screwOrder.ToString.PadLeft(2, "0")))
                cmb_ScrewOrder.SelectedIndex = 0
                cmb_JobNo.SelectedIndex = 0

                btn_DeleteNut.Enabled = True
                btn_AddNut.Enabled = True
            End If

            'For Each shape In shapeContainer.Shapes
            '    MessageBox.Show("Shape obj:" & DirectCast(shape, OvalShape).Name)
            'Next

            '' Remove event handlers for saved nut
            'Dim shapeName As String = "nutSp_" & screwOrder.ToString
            'Dim index As Integer = shapeContainer.Shapes.IndexOfKey(shapeName)
            'If index >= 0 Then
            '    MessageBox.Show("Nut obj: " & DirectCast(shapeContainer.Shapes(index), OvalShape).Name)
            '    RemoveHandler DirectCast(shapeContainer.Shapes(index), OvalShape).Click, AddressOf Me.OvalShape_Click
            '    RemoveHandler DirectCast(shapeContainer.Shapes(index), OvalShape).MouseDown, AddressOf Me.OvalShape_MouseDown
            '    RemoveHandler DirectCast(shapeContainer.Shapes(index), OvalShape).MouseMove, AddressOf Me.OvalShape_MouseMove
            '    RemoveHandler DirectCast(shapeContainer.Shapes(index), OvalShape).MouseUp, AddressOf Me.OvalShape_MouseUp

            'End If

        End If

        'For Each shape In shapeContainer.Shapes
        '    MessageBox.Show("obj names: " & DirectCast(shape, OvalShape).Name.ToString)
        'Next
    End Sub

    Private Sub cmb_NutType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_NutType.SelectedIndexChanged

    End Sub

    ' Read the necessary values from PLC
    Private Sub tmr_Indicator_Tick(sender As Object, e As EventArgs) Handles tmr_Indicator.Tick

        Dim str_CoordX As String = String.Empty
        ' Read the coordX, Linear Ruler
        PLCComm.PLCReadRAM("D100", PLCComm.data_from_dev.Length, PLCComm.data_from_dev, res, req)
        'txt_AnalogInput.Text = PLCComm.data_from_dev(0).ToString
        str_CoordX = PLCComm.data_from_dev(0).ToString
        schraubCoordX = CInt(PLCComm.data_from_dev(0))

        ' Read the coordY, Rotary Encoder
        PLCComm.PLCReadRAM("D102", PLCComm.data_from_dev.Length, PLCComm.data_from_dev, res, req)
        txt_ScrewPos.Text = "X:" & str_CoordX & ", Y:" & PLCComm.data_from_dev(0).ToString
        schraubCoordY = CInt(PLCComm.data_from_dev(0))

    End Sub

    Private Sub CreateShape(ByVal X As Integer, ByVal Y As Integer, ByVal order As Integer)
        Dim ovalSp As New PowerPacks.OvalShape
        'Dim cnt As Integer = shapeContainer.Shapes.Count
        Dim objName As String = "nutSp_" & order.ToString
        ovalSp.Name = objName
        ovalSp.Parent = shapeContainer
        ovalSp.Left = X
        ovalSp.Top = Y
        ovalSp.Width = radius
        ovalSp.Height = radius
        ovalSp.FillStyle = PowerPacks.FillStyle.Solid
        ovalSp.FillColor = Color.Yellow

    End Sub

    Private Sub DisposeShapes()
        shapeContainer.Shapes.Clear()

    End Sub

    Private Sub cmb_SelectVariant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_SelectVariant.SelectedIndexChanged

        ' Repopulate screw order combobox
        cmb_ScrewOrder.Items.Clear()

        Dim item As String = String.Empty
        For i = 1 To 99
            If i < 10 Then
                item = "0" & i.ToString
            Else
                item = i.ToString
            End If
            cmb_ScrewOrder.Items.Add(item)
        Next

        'Dim numbers As IEnumerable(Of Integer) = Enumerable.Range(1, 32)

        'For Each i As Integer In numbers
        '    cmb_ScrewOrder.Items.Add(i.ToString)
        'Next

        Dim index As Integer = cmb_SelectVariant.SelectedIndex

        If index > 0 Then
            cmb_NutType.Enabled = True
            cmb_ScrewOrder.Enabled = True
            cmb_JobNo.Enabled = True
            Dim issueP As String

            Dim variantName = cmb_SelectVariant.SelectedItem.ToString

            
            If Not LocalDB.isThere("SELECT * FROM VARIANT WHERE VariantName='" & cmb_SelectVariant.SelectedItem.ToString & "'") Then
                issueP = LocalDB.GetSingleValue("SELECT * FROM VARIANT WHERE VariantName='" & variantName & "'", "Issue")
                Dim controlIssue As Boolean = False
                If issueP = "" Then
                    controlIssue = False
                Else
                    controlIssue = True
                End If
                
                If IsDBNull(controlIssue)=False Then
                    txt_issueP.Text = issueP
                Else
                    txt_issueP.Text = "NULL"
                    
                End If

            End If

            Dim masterName As String = LocalDB.GetSingleValue("SELECT * FROM VARIANT WHERE VariantName='" & variantName & "'", "MasterName")


            'MessageBox.Show("Master name: " & masterName)
            pb_Socket.Image = LocalDB.GetImage("SELECT MasterPicture FROM PICTURE WHERE MasterName='" & masterName & "'", "MasterPicture")
            'btn_DeleteVariant.Enabled = True
            DisposeShapes()
            ' Populate grid
            grd_ProcessDesc.DataSource = Nothing
            grd_ProcessDesc.DataSource = LocalDB.PopulateGrid("SELECT * FROM PROCESSDESC WHERE VariantName='" & variantName & "'  ORDER BY ScrewOrder ASC")

            btn_AddNut.Enabled = True
            If grd_ProcessDesc.Rows.Count > 0 Then
                btn_DeleteNut.Enabled = True
                For i = 0 To grd_ProcessDesc.Rows.Count - 1

                    Dim itemIndex As Integer = cmb_ScrewOrder.Items.IndexOf(grd_ProcessDesc.Item("ScrewOrder", i).Value.ToString.PadLeft(2, "0"))
                    'MessageBox.Show(itemIndex)
                    cmb_ScrewOrder.Items.RemoveAt(itemIndex)
                    'cmb_ScrewOrder.Items.Remove(grd_ProcessDesc.Item("ScrewOrder", i).Value)
                    'cmb_ScrewOrder.Refresh()

                Next
                'For Each DataGridViewRow row In grd_ProcessDesc.Rows
                '    If row.IsNewRow Then
                '        MessageBox.Show(rows.Cell(2).Value)
                'Next

            Else
                btn_DeleteNut.Enabled = False

            End If

            ' Create Shapes
            For i = 0 To grd_ProcessDesc.Rows.Count - 1
                Dim shapeX As Integer = CInt(grd_ProcessDesc.Item("NutX", i).Value)
                Dim shapeY As Integer = CInt(grd_ProcessDesc.Item("NutY", i).Value)
                Dim order As Integer = CInt(grd_ProcessDesc.Item("ScrewOrder", i).Value)
                CreateShape(shapeX, shapeY, order)
            Next

        Else
            btn_AddNut.Enabled = False
            btn_DeleteNut.Enabled = False

            cmb_NutType.Enabled = False
            cmb_ScrewOrder.Enabled = False
            cmb_JobNo.Enabled = False
            'btn_DeleteVariant.Enabled = False
            pb_Socket.Image = Nothing
            grd_ProcessDesc.DataSource = Nothing
            shapeContainer.Shapes.Clear()
        End If
    End Sub

    Private Sub grd_ProcessDesc_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles grd_ProcessDesc.RowsAdded
        btn_DeleteNut.Enabled = False

    End Sub

    Private Sub grd_ProcessDesc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_ProcessDesc.CellClick
        'MessageBox.Show("Cell clicked: " & e.RowIndex.ToString)
        Dim selectedIndex As Integer = e.RowIndex

        If selectedIndex <> -1 Then
            btn_DeleteNut.Enabled = True

            Dim strScrewOrder As String = grd_ProcessDesc.Item("ScrewOrder", selectedIndex).Value.ToString
            Dim nutName As String = "nutSp_" & strScrewOrder
            'MessageBox.Show("Selected nut: " & nutName)
            For Each shape In shapeContainer.Shapes
                If DirectCast(shape, OvalShape).Name.ToString = nutName Then
                    DirectCast(shape, OvalShape).FillColor = Color.Red
                Else
                    DirectCast(shape, OvalShape).FillColor = Color.Yellow
                End If
                'MessageBox.Show("Name: " & DirectCast(shape, OvalShape).Name)
            Next
        End If
    End Sub

#End Region

#Region "PLC Connection"
    ' PLC Connection Error Event
    Private Sub PLCConnection() Handles PLCComm.PLCErrorEvent
        Select Case PLCComm.PLCError
            Case 0
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCNoError" & vbCrLf)
            Case 1
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCDIError" & vbCrLf)
            Case 2
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCDOError" & vbCrLf)
            Case 3
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCReadRamError" & vbCrLf)
            Case 4
                'txt_ConnStatus.Text = "Connection Error"
                'txt_Status.AppendText("PLCWriteRamError" & vbCrLf)
        End Select

        If PLCComm.PLCError > 0 Then
            tmr_Indicator.Enabled = False
            'errCntr = errCntr + 1
            'If errCntr > 10 Then
            '    MessageBox.Show("Communication Error. Check your connection.")
            '    Exit Sub
            'Else
            '    tmr_Indicator.Enabled = True
            '    errCntr = 0
            'End If
        End If
    End Sub

    Private Sub frm_ProcessSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        tmr_Indicator.Enabled = False
        PLCComm.CloseConnection()

    End Sub



#End Region
End Class