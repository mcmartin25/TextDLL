Imports System.ComponentModel
Imports System.IO

Public Class Preview
    Dim fnp As String
    Private Sub Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fnp = Form1.fn2
        If File.Exists(Application.StartupPath + "\" + fnp) Then
            txtFileName.Text = fnp
            txtPreview.Text = File.ReadAllText(Application.StartupPath + "\" + fnp)
        Else
            txtFileName.Text = "No file"
            txtPreview.Text = "Click Browse to open file..."
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Close()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtFileName.Text = OpenFileDialog1.FileName
        txtPreview.Text = File.ReadAllText(OpenFileDialog1.FileName)
    End Sub

End Class