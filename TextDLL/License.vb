Imports System.IO

Public Class License
    Private Sub License_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtContent.Text = My.Resources.License
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Hide()
    End Sub
End Class