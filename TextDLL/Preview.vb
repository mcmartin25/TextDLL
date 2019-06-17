Imports System.ComponentModel
Imports System.IO

Public Class Preview
    Dim openedDialog As Boolean = True
    Dim fnp As String
    Private Sub Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnVisualMode.Enabled = False
        fnp = Form1.fn2
        If File.Exists(Application.StartupPath + "\" + fnp) Then
            txtFileName.Text = fnp
            txtPreview.Text = File.ReadAllText(Application.StartupPath + "\" + fnp)
            btnVisualMode.Enabled = True
        Else
            txtFileName.Text = "No file"
            txtPreview.Text = "Click Browse to open file..."
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Close()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
        ReadFile(OpenFileDialog1.FileName)
        txtFileName.Text = OpenFileDialog1.FileName
        openedDialog = True
    End Sub

    Sub ReadFile(fileName As String)
        Dim preview As String = File.ReadAllText(fileName) 'OpenFileDialog1.FileName
        Dim ff As Integer = FreeFile()
        Dim startText As String = "[TextDLL]"
        Dim propertyJumper As Integer = 0
        Dim valJumper As Integer = 1
        Dim chars As Char() = New Char() {"="c, ";"c}
        Dim finalPreview As String() = Replace(preview, startText, "").Split(chars, StringSplitOptions.RemoveEmptyEntries) ', vbCrLf)
        Dim totalLines As Integer = finalPreview.Length
        FileOpen(ff, fileName, OpenMode.Input, OpenAccess.Read,
         OpenShare.Default, -1)
        btnVisualMode.Enabled = True

        If preview.Contains(startText) Then
            'txtPreview.Text = preview
            'Dim pl() As String
            'Do While Not EOF(ff)
            'use sr.Readline here and use the split method with your delimiter 
            'which will give you an array, so send the right element to the right place
            'If Not preview.Contains("[TextDLL]") Then
            'Process lines that don't start with "#"
            'pl = Split(preview, " = ")
            'txtPreview.Text = pl(0) + "'s value is " + pl(1)
            'End If

            'preview -> nextPreview -> finalPreview

            txtPreview.Clear()
            Do While Not EOF(ff) And valJumper <= totalLines

                txtPreview.Text += finalPreview(propertyJumper) + " 's value is " + finalPreview(valJumper) '+ vbCrLf
                propertyJumper += 2
                valJumper += 2

                'There is an expection as the application added an empty line in the text file.

                'txtPreview.Text += "" 'for ending text

            Loop
        Else
            txtPreview.Text = "Error:" + vbCrLf + fileName + vbCrLf + "This file is not a proper file format."
        End If
        FileClose()
    End Sub

    Private Sub BtnVisualMode_Click(sender As Object, e As EventArgs) Handles btnVisualMode.Click
        VisualModeDetection()
    End Sub

    Sub VisualModeDetection()
        If btnVisualMode.Text = "Visual Mode" Then
            If openedDialog = False Then
                txtPreview.Text = File.ReadAllText(Application.StartupPath + "\" + fnp)
            Else
                txtPreview.Text = File.ReadAllText(txtFileName.Text)
            End If
            btnVisualMode.Text = "Source Mode"
        ElseIf btnVisualMode.Text = "Source Mode" Then
            If openedDialog = False Then
                ReadFile(Application.StartupPath + "\" + fnp)
            Else
                ReadFile(txtFileName.Text)
            End If
            btnVisualMode.Text = "Visual Mode"
        End If
    End Sub
End Class