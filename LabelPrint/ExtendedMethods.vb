Module ExtendedMethods
    Public Sub Writelog(info As String)
        Try
            Dim file As String = Application.StartupPath & "\Log.txt"
            If IO.File.Exists(file) Then

                My.Computer.FileSystem.WriteAllText(file, Now.ToString("dd.MM.yyyy HH:mm:ss") & " <" & info & ">" & vbNewLine, True)

            Else

                My.Computer.FileSystem.WriteAllText(file, Now.ToString("dd.MM.yyyy HH:mm:ss") & " <" & info & ">" & vbNewLine, False)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Module
