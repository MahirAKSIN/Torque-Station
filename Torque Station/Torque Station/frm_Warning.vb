Public Class frm_Warning
  

    Public Sub FormMessage(ByVal message As String)
        lbl_Warning.Text = message
    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.Hide()

        Me.DialogResult = DialogResult.OK
    End Sub
End Class