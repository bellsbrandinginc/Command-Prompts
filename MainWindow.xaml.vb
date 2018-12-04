Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text



Class MainWindow

    Dim outputFile As String = "\\gsodata2\pss Data\Special Projects\Development\Output\output.txt"
    Dim _server = "\\bndata2"




    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim proc As New Process
        Dim sb As New StringBuilder()

        'proc.StartInfo.WorkingDirectory = "H:\"
        proc.StartInfo.FileName = "cmd.exe"
        proc.StartInfo.Arguments = "/C " + "net view " + _server
        proc.StartInfo.CreateNoWindow = False
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.Start()
        proc.WaitForExit()

        Dim output() As String = proc.StandardOutput.ReadToEnd.Split(CChar(vbLf))
        For Each ln As String In output
            ListView1.Items.Add(ln & vbNewLine)
            ' File.WriteAllText(ListView1.SelectedItems.ToString)
        Next

        For Each item As Object In ListView1.Items
            sb.AppendFormat("{0} {1}", item, Environment.NewLine)
        Next

        Dim writer As StreamWriter = New StreamWriter(outputFile)
        writer.Write(sb.ToString())
        writer.WriteLine()
        writer.Close()

        Process.Start(outputFile)

    End Sub


End Class
