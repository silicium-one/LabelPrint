Imports System.Windows.Forms

Public Class ProductivityApplyDlg
    Sub New(ByVal plannedProductivity As Dictionary(Of String, Integer))
        InitializeComponent()
        For Each item In plannedProductivity
            table.Items.Add(New ListViewItem(New String() {item.Key, item.Value}))
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
