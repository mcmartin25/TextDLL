Imports System.IO
Public Class Form1
    Dim m As MsgBoxResult
    Public fn As String
    Public fn2 As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If btnCreate.Text = "Create" Then
            Try
                If txtFileName.Text.Length > 0 Then
                    If txtProperty1.Text.Length > 0 Then
                        If txtValue1.Text.Length > 0 Then
                            fn = txtFileName.Text
                            Dim objWriter As New StreamWriter(fn + ".txt", True)
                            If Not txtProperty1.Text.Contains("=") And Not txtValue1.Text.Contains("=") Then
                                objWriter.Write(txtProperty1.Text + " = " + txtValue1.Text + vbCrLf)
                                objWriter.Close()
                                fn2 = fn + ".txt"
                                btnCreate.Text = "Add line"
                            End If
                        Else
                            m = MsgBox("Error: {0}'s Vaule cannot be empty", MsgBoxStyle.Critical, txtProperty1.Text)
                        End If
                    Else
                        m = MsgBox("Error: Property name cannot be empty", MsgBoxStyle.Critical)
                    End If
                Else
                    m = MsgBox("Error: File name cannot be empty", MsgBoxStyle.Critical)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf btnCreate.Text = "Add line" Then
            Dim text As String = File.ReadAllText(fn + ".txt")
            Dim index As String = txtProperty1.Text
            If text.Contains(index) Then
                ' String is in file, starting at character "index"
                m = MsgBox("Error: Property " + txtProperty1.Text + " is already exist", MsgBoxStyle.Critical)
            Else
                Try
                    If txtFileName.Text.Length > 0 Then
                        If txtProperty1.Text.Length > 0 Then
                            If txtValue1.Text.Length > 0 Then
                                fn = txtFileName.Text
                                Dim objWriter As New StreamWriter(fn + ".txt", True)
                                If Not txtProperty1.Text.Contains("=") And Not txtValue1.Text.Contains("=") Then
                                    objWriter.Write(txtProperty1.Text + " = " + txtValue1.Text + vbCrLf)
                                    objWriter.Close()
                                    fn2 = fn + ".txt"
                                    btnCreate.Text = "Add line"
                                End If
                            Else
                                m = MsgBox("Error: {0}'s Vaule cannot be empty", MsgBoxStyle.Critical, txtProperty1.Text)
                            End If
                        Else
                            m = MsgBox("Error: Property name cannot be empty", MsgBoxStyle.Critical)
                        End If
                    Else
                        m = MsgBox("Error: File name cannot be empty", MsgBoxStyle.Critical)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub txtFileName_TextChanged(sender As Object, e As EventArgs) Handles txtFileName.TextChanged
        If txtFileName.Text <> fn Then
            btnCreate.Text = "Create"
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Preview.Show()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        ToolTip1.Show(String.Empty, Me, New Point(btnHelp.Location.X + 20, btnHelp.Location.Y + 50), 10000)
        ToolTip1.Show("If the TextDLL doesn't have any value, the application will only show 'Create' button after you clicked. If have, this application will show 'Add Value'.
All the TextDLL will save in the same location as this application.", Me, New Point(btnHelp.Location.X + 20, btnHelp.Location.Y + 50), 10000)
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MsgBox("Text AppData Library (TextDLL) Create Application" + vbCrLf +
               "Under Construction" + vbCrLf +
               "by Chor Tsun Lam and Chor Tsun Lam Media LTD." + vbCrLf +
               "Copyright 2018-2019 (c) Martin C." + vbCrLf +
               "Click About > License to view the application license.", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub btnLicense_Click(sender As Object, e As EventArgs) Handles btnLicense.Click
        License.Show()
    End Sub
End Class
