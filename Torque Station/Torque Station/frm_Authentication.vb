

Public Class frm_Authentication

    Public LocalDB As New SQLiteTools("TorqueStation")

    Private Sub frm_Authentication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.MinimumSize
        txt_Password.Clear()

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

        Dim strPassword As String = txt_Password.Text
        Dim strUserName As String = LocalDB.GetSingleValue("SELECT * FROM USER WHERE Password='" & strPassword & "'", "Username")
        If strUserName.Length > 0 Then
            ' User exist
            'MessageBox.Show("User exist.")
            Me.DialogResult = DialogResult.OK
        Else
            ' User not exist. Warn
            MessageBox.Show("Incorrect password.")
            txt_Password.Clear()
            txt_Password.Focus()

        End If

    End Sub
    Private Sub txt_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Password.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Dim strPassword As String = txt_Password.Text
            Dim strUserName As String = LocalDB.GetSingleValue("SELECT * FROM USER WHERE Password='" & strPassword & "'", "Username")
            If strUserName.Length > 0 Then
                ' User exist
                'MessageBox.Show("User exist.")
                Me.DialogResult = DialogResult.OK
            Else
                ' User not exist. Warn
                MessageBox.Show("Incorrect password.")
                txt_Password.Clear()
                txt_Password.Focus()

            End If
            e.Handled = True
        End If
    End Sub
End Class