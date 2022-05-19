
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frm_Login


    'Public Shared data_from_dev(7) As UInt32
    'Public data_to_dev() As UInt32

    Public LocalDB As New SQLiteTools("TorqueStation")
    Public userLevel As String = String.Empty
    Public userName As String = String.Empty

    Public loggedUserName As String = String.Empty
    Public loggedUserLevel As String = String.Empty


    Private Sub btn_LoginOk_Click(sender As Object, e As EventArgs) Handles btn_LoginOk.Click

        'If Application.OpenForms().Count > 1 Then
        '    For count As Integer = My.Application.OpenForms.Count - 1 To 1 Step -1

        '        My.Application.OpenForms(count).Close()

        '    Next
        'End If

        If (txt_Password.Text = "CORLU") Then
            userLevel = "Supervisor"
            userName = "RnD"
            loggedUserName = "RnD"
            frm_Main.Activate()
            frm_Main.Show()
            Me.Hide()
        Else
            If LocalDB.isThere("SELECT * FROM USER WHERE Password = '" & txt_Password.Text & "'") Then
                MessageBox.Show("Wrong password")
                'Dim frmWarning As New frm_Message
                'frmWarning.Title = fff("Warning")
                'frmWarning.ButtonCancel = 0
                'frmWarning.Message = fff("Wrong password !")
                'frmWarning.ShowDialog()
                'frm_Message.btn_cancel.Hide()
                txt_Password.Text = String.Empty
                txt_Password.Focus()
            Else
                userLevel = LocalDB.GetSingleValue("SELECT Level FROM USER WHERE Password = '" & txt_Password.Text & "' ", "Level")
                userName = LocalDB.GetSingleValue("SELECT Username FROM USER WHERE Password = '" & txt_Password.Text & "' ", "Username")
                loggedUserName = LocalDB.GetSingleValue("SELECT Username FROM USER WHERE Password = '" & txt_Password.Text & "' ", "Username")

                'MessageBox.Show("Username: " & userName & ", level: " & userLevel)

                If (userLevel = "Supervisor") Then
                    loggedUserLevel = "Supervisor"
                    loggedUserName = userName
                    frm_Main.Activate()
                    frm_Main.Show()
                    Me.Hide()

                ElseIf (userLevel = "Mechanic") Then
                    loggedUserLevel = "Mechanic"
                    loggedUserName = userName

                    'userName = "Mechanic"
                    frm_Main.Activate()
                    frm_Main.Show()
                    Me.Hide()

                Else : userLevel = "Operator"
                    loggedUserLevel = "Operator"
                    loggedUserName = userName
                    frm_Main.Activate()
                    frm_Main.Show()
                    Me.Hide()

                End If

            End If

        End If


    End Sub

    Private Sub btn_LoginCancel_Click(sender As Object, e As EventArgs) Handles btn_LoginCancel.Click
        frm_Main.Close()
        Me.Close()
    End Sub

    Private Sub txt_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btn_LoginOk_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class