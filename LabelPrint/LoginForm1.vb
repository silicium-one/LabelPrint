Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Try
            PasswordTextBox.Text = Form1.Ru_sb_tames1.t_Settings.Select("varName = 'addParts'").GetValue(0).item(1)
            If PasswordTextBox.Text = Form1.Ru_sb_tames1.t_Settings.Select("varName = 'addParts'").GetValue(0).item(1) Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                PasswordTextBox.Text = vbNullString
                Me.Close()
            Else
                MsgBox("Invalid Password")
                PasswordTextBox.Text = vbNullString
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class

