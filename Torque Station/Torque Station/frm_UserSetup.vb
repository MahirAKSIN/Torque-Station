Public Class frm_UserSetup

    Dim LocalDB As New SQLiteTools("TorqueStation")
    Private Sub frm_UserSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.MaximumSize

        'Hide
        btn_Edit_User.Hide()
        btn_Update_User.Hide()
        lbl_editPass.Hide()
        lbl_Pass1.Hide()
        lbl_UpdatePass.Hide()
        lbl_Pass2.Hide()

        btn_NewUser.Enabled = True
        btn_DeleteUser.Enabled = False
        btn_SaveUser.Enabled = False

        If Not LocalDB.isThere("SELECT * FROM USER ") Then
            grd_Users.DataSource = LocalDB.PopulateGrid("SELECT * FROM USER ")
            grd_Users.Rows(0).Selected = False

            grd_Users.Columns("Password").Visible = False

        End If


        If (cmb_UserLevel.Items.Count = 0) Then
            'cmb_UserLevel.Items.Add(fff("Selection"))
            cmb_UserLevel.Items.Add("Selection")
            cmb_UserLevel.Items.Add("Supervisor")
            cmb_UserLevel.Items.Add("Mechanic")
            cmb_UserLevel.Items.Add("Operator")
            cmb_UserLevel.SelectedIndex = 0
        End If


    End Sub

    Private Sub btn_NewUser_Click(sender As Object, e As EventArgs) Handles btn_NewUser.Click

        txt_Username.Clear()
        txt_Password.Clear()
        cmb_UserLevel.SelectedIndex = 0

        txt_Username.Enabled = True
        txt_Password.Enabled = True
        cmb_UserLevel.Enabled = True

        txt_Username.Focus()

        btn_SaveUser.Enabled = True
        btn_DeleteUser.Enabled = False

    End Sub

    Private Sub btn_DeleteUser_Click(sender As Object, e As EventArgs) Handles btn_DeleteUser.Click

        If grd_Users.Rows.Count > 0 Then
            If grd_Users.CurrentRow.Index >= 0 Then
                Dim strUserName As String = grd_Users.Item("Username", grd_Users.CurrentRow.Index).Value.ToString
                Dim strPassword As String = grd_Users.Item("Password", grd_Users.CurrentRow.Index).Value.ToString
                Dim strLevel As String = grd_Users.Item("Level", grd_Users.CurrentRow.Index).Value.ToString

                LocalDB.ExecuteNonQuery("DELETE FROM USER WHERE ( Username='" & strUserName & "') AND (Password='" & strPassword & "' ) ")

                MessageBox.Show("User '" & strUserName & "' deleted.")
                grd_Users.DataSource = Nothing
                grd_Users.DataSource = LocalDB.PopulateGrid("SELECT * FROM USER")
                grd_Users.Columns("Password").Visible = False

                txt_Username.Clear()
                txt_Password.Clear()
                cmb_UserLevel.SelectedIndex = 0

            End If

        Else
            btn_DeleteUser.Enabled = False
        End If

    End Sub

    Private Sub btn_SaveUser_Click(sender As Object, e As EventArgs) Handles btn_SaveUser.Click
        If txt_Username.Text <> String.Empty Then
            If txt_Password.Text <> String.Empty Then
                If cmb_UserLevel.SelectedIndex <> 0 Then
                    If (LocalDB.isThere("SELECT * FROM USER WHERE Username ='" & txt_Username.Text.ToString & "' ")) Then
                        If (LocalDB.isThere("SELECT * FROM USER WHERE Password='" & txt_Password.Text.ToString & "'")) Then

                            LocalDB.ExecuteNonQuery("INSERT INTO USER VALUES ( '" & txt_Username.Text.ToString & "','" & txt_Password.Text.ToString & "','" & cmb_UserLevel.SelectedItem.ToString() & "') ")
                            grd_Users.DataSource = Nothing
                            grd_Users.DataSource = LocalDB.PopulateGrid("SELECT * FROM USER ")
                            grd_Users.Columns("Password").Visible = False

                            MessageBox.Show("User '" & txt_Username.Text & "' created.")

                            txt_Username.Clear()
                            txt_Password.Clear()
                            cmb_UserLevel.SelectedIndex = 0
                            txt_Username.Enabled = False
                            txt_Password.Enabled = False
                            cmb_UserLevel.Enabled = False
                            btn_SaveUser.Enabled = False

                        Else
                            MessageBox.Show("Please select another password for the user.")
                            txt_Password.Focus()


                        End If
                    Else
                        MessageBox.Show("Please select another username.")
                        txt_Username.Focus()
                    End If
                Else
                    MessageBox.Show("Please select a user level.")

                End If
            Else
                MessageBox.Show("Please enter a password.")
                txt_Password.Focus()
            End If
        Else
            MessageBox.Show("Username cant be empty.")
        End If

    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub grd_Users_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grd_Users.CellClick
        txt_Username.Text = grd_Users.Item("Username", grd_Users.CurrentRow.Index).Value.ToString()
        txt_Password.Text = grd_Users.Item("Password", grd_Users.CurrentRow.Index).Value.ToString()
        cmb_UserLevel.SelectedItem = grd_Users.Item("Level", grd_Users.CurrentRow.Index).Value.ToString()

        txt_Username.Enabled = False
        txt_Password.Enabled = False

        Dim rowCount As Integer = grd_Users.Rows.Count
        If rowCount > 0 Then
            btn_DeleteUser.Enabled = True
        Else
            btn_DeleteUser.Enabled = False
        End If

    End Sub

    Private Sub grd_Users_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles grd_Users.RowsRemoved
        If grd_Users.Rows.Count <= 0 Then
            btn_DeleteUser.Enabled = False
        End If
    End Sub
End Class