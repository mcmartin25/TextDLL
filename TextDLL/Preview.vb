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
        Dim preview As String = File.ReadAllText(OpenFileDialog1.FileName)
        Dim ff As Integer = FreeFile()
        'Dim sLine As String
        FileOpen(ff, OpenFileDialog1.FileName, OpenMode.Input, OpenAccess.Read,
         OpenShare.Default, -1)

        If Preview.Contains("[TextDLL]") Then
            'txtPreview.Text = preview
            Dim pl() As String
            Do While Not EOF(ff)
                'use sr.Readline here and use the split method with your delimiter 
                'which will give you an array, so send the right element to the right place
                If Not preview.Contains("[TextDLL]") Then
                    'Process lines that don't start with "#"
                    pl = Split(preview, " = ")
                    txtPreview.Text = pl(0) + "'s value is " + pl(1)
                End If
            Loop


        Else
            txtPreview.Text = "Error:" + vbCrLf + OpenFileDialog1.FileName + vbCrLf + "This file is not a proper file format."
        End If
    End Sub

End Class