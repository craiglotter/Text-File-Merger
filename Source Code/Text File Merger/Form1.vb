Imports System.IO


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim inputfolder As String
        inputfolder = "C:\ebegroups"
        Dim finfo As FileInfo
        Dim dinfo As DirectoryInfo = New DirectoryInfo(inputfolder)
        Dim filewriter As StreamWriter = New StreamWriter("c:\merged.txt", True)
        Dim filereader As StreamReader
        For Each finfo In dinfo.GetFiles
            filereader = New StreamReader(finfo.FullName)
            filewriter.WriteLine(filereader.ReadToEnd)
            filereader.Close()
        Next
        filewriter.Close()
        MsgBox("completed")
    End Sub
End Class
