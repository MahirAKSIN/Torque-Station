
Imports System.IO
Imports System.Data.SqlTypes
Imports System.Text

Public Class frm_Statistics

    Dim LocalDB As New SQLiteTools("TorqueStation")
    Private Sub frm_Statistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        grd_Statistics.DataSource = LocalDB.PopulateGrid("SELECT * FROM STATISTICS ORDER BY [ProcessDateTime] ASC ")

        cmb_OperatorId.DataSource = LocalDB.PopulateComboBox("SELECT * FROM USER", "Username", True)

        cmb_processResult.Items.Add("Please Select")
        cmb_processResult.Items.Add("OK")
        cmb_processResult.Items.Add("NOK")
        cmb_processResult.SelectedIndex = 0

        lbl_OperatorID.Hide()
        cmb_OperatorId.Hide()

    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click

        Me.Close()
    End Sub

    Private Sub btn_Reset_Click(sender As Object, e As EventArgs) Handles btn_Reset.Click

        cmb_OperatorId.SelectedIndex = 0
        cmb_processResult.SelectedIndex = 0
        dtp_StartDate.Value = Date.Now
        dtp_EndDate.Value = Date.Now

        grd_Statistics.DataSource = LocalDB.PopulateGrid("SELECT * FROM STATISTICS")
    End Sub

    Private Sub btn_Filter_Click(sender As Object, e As EventArgs) Handles btn_Filter.Click

        ' Check Date
        If dtp_StartDate.Value.Date > dtp_EndDate.Value.Date Then
            MessageBox.Show("Start date can not be greater than End date.")

            dtp_StartDate.Value = Date.Now
            dtp_EndDate.Value = Date.Now

        Else

            If dtp_EndDate.Value.Date > dtp_StartDate.Value.Date Then

                Dim startDate As String = dtp_StartDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Dim endDate As String = dtp_EndDate.Value.ToString("yyyy-MM-dd") & " 23:59:00"

                'MessageBox.Show("From date: " & startDate)
                'MessageBox.Show(endDate)


                Dim sqlStr As SqlString
                sqlStr = "SELECT * FROM STATISTICS WHERE "

                If cmb_processResult.SelectedIndex <> 0 Then
                    sqlStr += "Status='" & cmb_processResult.SelectedItem.ToString & "' AND "
                End If

                sqlStr += "ProcessDateTime BETWEEN '" & startDate & "' AND '" & endDate & "' "

                grd_Statistics.DataSource = LocalDB.PopulateGrid(sqlStr)

            End If

            ' Same day
            If dtp_EndDate.Value.Date = dtp_StartDate.Value.Date Then
                Dim startDate As String = dtp_StartDate.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Dim endDate As String = dtp_EndDate.Value.ToString("yyyy-MM-dd") & " 23:59:00"

                Dim sqlStr As SqlString
                sqlStr = "SELECT * FROM STATISTICS WHERE "

                If cmb_processResult.SelectedIndex <> 0 Then
                    sqlStr += "Status='" & cmb_processResult.SelectedItem.ToString & "' AND "
                End If

                sqlStr += "ProcessDateTime BETWEEN '" & startDate & "' AND '" & endDate & "' "

                grd_Statistics.DataSource = LocalDB.PopulateGrid(sqlStr)

            End If


        End If

#Region "temp closed"
        'Dim sqlStr As SqlString
        'sqlStr = "SELECT * FROM STATISTICS WHERE "

        'If cmb_processResult.SelectedIndex <> 0 Then
        '    sqlStr += "Status='" & cmb_processResult.SelectedItem.ToString & "' AND "
        'End If

        'sqlStr += "DateTime LIKE'" & dtp_StartDate.Text & "%' "

        'grd_Statistics.DataSource = LocalDB.PopulateGrid(sqlStr)
#End Region

    End Sub

    Private Sub btn_ExportStatistics_Click(sender As Object, e As EventArgs) Handles btn_ExportStatistics.Click
        ' Save to csv
        save_Fd.Filter = "CSV Files|*.csv;"
        save_Fd.FilterIndex = 1
        save_Fd.FileName = String.Empty
        save_Fd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)), "Documents")

        If save_Fd.ShowDialog(Me) = DialogResult.OK Then
            Dim filePath As String = save_Fd.FileName
            Dim delimeter As String = ","
            Dim sb As New StringBuilder

            For i As Integer = 0 To grd_Statistics.Rows.Count - 1
                Dim array As String() = New String(grd_Statistics.Columns.Count - 1) {}
                If i.Equals(0) Then
                    For j As Integer = 0 To grd_Statistics.Columns.Count - 1
                        array(j) = grd_Statistics.Columns(j).HeaderText
                    Next
                    sb.AppendLine(String.Join(delimeter, array))
                End If
                For j As Integer = 0 To grd_Statistics.Columns.Count - 1
                    If Not grd_Statistics.Rows(i).IsNewRow Then
                        array(j) = grd_Statistics(j, i).Value.ToString
                    End If
                Next
                If Not grd_Statistics.Rows(i).IsNewRow Then
                    sb.AppendLine(String.Join(delimeter, array))
                End If
            Next
            File.WriteAllText(filePath, sb.ToString)

            MessageBox.Show(" File saved.")

        End If


    End Sub
End Class