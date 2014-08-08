Imports System
Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms


Public Class Main_Screen

    Private force_exit As Boolean = False

    Private application_busy_exiting As Boolean = False
    Private busyworking As Boolean = False

    Private output1 As String = ""
    Private output2 As String = ""
    Private output2Name As String = ""
    Private output2FullName As String = ""
    Private output3 As String = ""
    Private output3Total As String = ""
    Private output4 As String = ""

    Private statusmessage As String = ""

    Private primaryprecount As Long = 0
    Private secondaryprecount As Long = 0

    Private datelaunched As Date = Now()
    Private pretestdone As Boolean = False
    
    Private primary_PercentComplete As Integer = 0
    Private secondary_PercentComplete As Integer = 0
    Private primary_highestPercentageReached As Integer = 0
    Private secondary_highestPercentageReached As Integer = 0

    Private outputfilename As String = ""


    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                If FullErrors_Checkbox.Checked = True Then
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.ToString
                Else
                    Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ":" & ex.Message.ToString
                End If
                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ":" & ex.ToString)
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub


    Private Sub Activity_Handler(ByVal Message As String)
        Try
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            dir = Nothing
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & Message)
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Activity_Logger")
        End Try
    End Sub

    Private Sub Status_Handler(ByVal Message As String)
        Try
            Status_Textbox.Text = Message.ToUpper
        Catch ex As Exception
            Error_Handler(ex, "Status_Handler")
        End Try
    End Sub


    Private Function File_Exists(ByVal file_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not file_path = "" And Not file_path Is Nothing Then
                Dim dinfo As FileInfo = New FileInfo(file_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "File_Exists")
        End Try
        Return result
    End Function

    Private Function Directory_Exists(ByVal directory_path As String) As Boolean
        Dim result As Boolean = False
        Try
            If Not directory_path = "" And Not directory_path Is Nothing Then
                Dim dinfo As DirectoryInfo = New DirectoryInfo(directory_path)
                If dinfo.Exists = False Then
                    result = False
                Else
                    result = True
                End If
                dinfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Directory_Exists")
        End Try
        Return result
    End Function


    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
      
            Label1.Text = My.Application.Info.Version.Major & My.Application.Info.Version.Minor & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
            Select Case My.Settings.FullErrors_Checkbox
                Case True
                    FullErrors_Checkbox.Checked = True
                    Exit Select
                Case False
                    FullErrors_Checkbox.Checked = False
                    Exit Select
                Case Else
                    FullErrors_Checkbox.Checked = True
                    Exit Select
            End Select
            Status_Handler("Application Load Successfull")

            If My.Application.CommandLineArgs.Count > 1 Then

                outputfilename = My.Application.CommandLineArgs(0)

                For Each str As String In My.Application.CommandLineArgs
                    'MsgBox(str)
                    If My.Computer.FileSystem.FileExists(str) = True Then
                        InputTargetFiles.Items.Add(str)
                    End If
                Next
 
                If InputTargetFiles.Items.Count > 0 Then
                    'outputfilename = SaveFileDialog1.FileName
                    force_exit = True
                    StartWorker()
                End If
            End If

        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Load")
        End Try
    End Sub

    Private Sub Main_Screen_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Status_Handler("Application Shutdown Initiated")

            ' Cancel the asynchronous operation.
            Me.BackgroundWorker1.CancelAsync()
            ' Disable the Cancel button.
            cancelAsyncButton.Enabled = False
            BackgroundWorker1.Dispose()
            My.Settings.FullErrors_Checkbox = FullErrors_Checkbox.Checked
            My.Settings.Save()


        Catch ex As Exception
            Error_Handler(ex, "Main_Screen_Close")
        End Try

    End Sub


    Private Sub FullErrors_Checkbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullErrors_Checkbox.CheckedChanged
        Status_Handler("Error Level Reporting Altered")
    End Sub


    Private Sub startAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startAsyncButton.Click
        If InputTargetFiles.Items.Count > 0 Then
            Dim result As DialogResult
            result = SaveFileDialog1.ShowDialog
            If result = Windows.Forms.DialogResult.OK Or result = Windows.Forms.DialogResult.Yes Then
                outputfilename = SaveFileDialog1.FileName
                StartWorker()
            End If
        End If
    End Sub


    Private Sub StartWorker()
        Try
            If busyworking = False Then

                busyworking = True
                statusmessage = "Initializing Application for Operation Launch"
                Status_Handler(statusmessage)

                ' Reset the text in the result label.

                datelaunched_label.Text = [String].Empty
                output1lbl.Text = [String].Empty
                output2lbl.Text = [String].Empty
                output4lbl.Text = [String].Empty
                output3lbl.Text = [String].Empty

                primaryprecount = 0
                secondaryprecount = 0

                output1 = ""
                output2 = ""
                output2Name = ""
                output2FullName = ""
                output3 = ""
                output3Total = ""
                output4 = ""

                primary_PercentComplete = 0
                secondary_PercentComplete = 0
                primary_highestPercentageReached = 0
                secondary_highestPercentageReached = 0

                datelaunched = Now()
                pretestdone = False


                Controls_Enabler("run")

                If File_Exists(outputfilename) = True Then
                    My.Computer.FileSystem.DeleteFile(outputfilename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If

                ' Start the asynchronous operation.
                BackgroundWorker1.RunWorkerAsync(InputTargetFiles.Items)
            End If
        Catch ex As Exception
            Error_Handler(ex, "StartWorker")
        End Try
    End Sub 'startAsyncButton_Click




    Private Sub cancelAsyncButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelAsyncButton.Click

        ' Cancel the asynchronous operation.
        Me.BackgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False

    End Sub 'cancelAsyncButton_Click

    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = MainWorkerFunction(worker, e)
    End Sub 'backgroundWorker1_DoWork

    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        busyworking = False
        ' First, handle the case where an exception was thrown.
        If Not (e.Error Is Nothing) Then
            Error_Handler(e.Error, "backgroundWorker1_RunWorkerCompleted")
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            Me.ProgressBar1.Value = 0
            Me.ProgressBar2.Value = 0

            output1lbl.Text = "Cancelled"
            output2lbl.Text = "Cancelled"
            output4lbl.Text = "Cancelled"
            output3lbl.Text = "Cancelled"

            Me.ToolTip1.SetToolTip(output1lbl, "Cancelled")
            Me.ToolTip1.SetToolTip(output2lbl, "Cancelled")
            Me.ToolTip1.SetToolTip(output3lbl, "Cancelled")
            Me.ToolTip1.SetToolTip(output4lbl, "Cancelled")

            statusmessage = "Operation Cancelled"

        Else
            ' Finally, handle the case where the operation succeeded.

            Dim finfo As FileInfo = New FileInfo(outputfilename)
            If finfo.Length < 1024 Then
                output4 = finfo.Length & " bytes"
            Else
                If finfo.Length < 1048576 Then
                    output4 = Math.Round(finfo.Length / 1024, 4) & " KB"
                Else
                    If finfo.Length < 1073741824 Then
                        output4 = Math.Round(finfo.Length / (1024 * 1024), 4) & " MB"
                    Else
                        ' If finfo.Length < 1073741824 Then
                        output4 = Math.Round(finfo.Length / (1024 * 1024 * 1024), 4) & " GB"
                        'End If
                    End If
                End If
            End If
            finfo = Nothing



            Status_Handler(e.Result)
            Me.ProgressBar1.Value = 100
            Me.ProgressBar2.Value = 100

            Me.output1lbl.Text = output2 & " of " & output1
            Me.output2lbl.Text = output2Name
            Me.output3lbl.Text = "Current: " & output3 & " Total: " & output3Total
            Me.output4lbl.Text = output4

            'Me.ToolTip1.SetToolTip(output1lbl, output1lbl.Text)
            Me.ToolTip1.SetToolTip(output2lbl, output2FullName)
            'Me.ToolTip1.SetToolTip(output3lbl, output3lbl.Text)
            'Me.ToolTip1.SetToolTip(output4lbl, output4lbl.Text)

            Me.datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"

            statusmessage = "Operation Completed"

        End If

        Status_Handler(statusmessage)
        Controls_Enabler("stop")
        If force_exit = True Then
            Application.Exit()
        End If
    End Sub 'backgroundWorker1_RunWorkerCompleted

    Private Sub Controls_Enabler(ByVal action As String)
        Select Case action.ToLower
            Case "run"
                Me.InputTargetFiles.Enabled = False
                Me.startAsyncButton.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
            Case "stop"
                Me.InputTargetFiles.Enabled = True
                Me.startAsyncButton.Enabled = True
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = False
                Exit Select
            Case Else
                Me.InputTargetFiles.Enabled = False
                Me.startAsyncButton.Enabled = False
                ' Disable the Cancel button.
                Me.cancelAsyncButton.Enabled = True
                Exit Select
        End Select
    End Sub

    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

        Me.ProgressBar2.Value = secondary_PercentComplete
        'Me.ProgressBar1.Value = e.ProgressPercentage
        Me.ProgressBar1.Value = primary_PercentComplete

        Me.output1lbl.Text = output2 & " of " & output1
        Me.output2lbl.Text = output2Name
        Me.output3lbl.Text = "Current: " & output3 & " (Total: " & output3Total & ")"
        Me.output4lbl.Text = output4

        'Me.ToolTip1.SetToolTip(output1lbl, output1lbl.Text)
        Me.ToolTip1.SetToolTip(output2lbl, output2FullName)
        'Me.ToolTip1.SetToolTip(output3lbl, output3lbl.Text)
        'Me.ToolTip1.SetToolTip(output4lbl, output4lbl.Text)

        datelaunched_label.Text = Format(datelaunched, "yyyy/MM/dd HH:mm:ss") & " - " & Format(Now, "yyyy/MM/dd HH:mm:ss") & " (" & Now.Subtract(Me.datelaunched).TotalSeconds() & " s)"
        If statusmessage.Length > 0 Then
            Status_Handler(statusmessage)
        End If
        statusmessage = ""
    End Sub

    ' This is the method that does the actual work. 
    Function MainWorkerFunction(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As String
        Dim result As String = ""
        Try

            ' Abort the operation if the user has canceled.
            ' Note that a call to CancelAsync may have set 
            ' CancellationPending to true just after the
            ' last invocation of this method exits, so this 
            ' code will not have the opportunity to set the 
            ' DoWorkEventArgs.Cancel flag to true. This means
            ' that RunWorkerCompletedEventArgs.Cancelled will
            ' not be set to true in your RunWorkerCompleted
            ' event handler. This is a race condition.
            If worker.CancellationPending Then
                e.Cancel = True
            End If

            secondaryprecount = InputTargetFiles.Items.Count


            primary_highestPercentageReached = 0
            output1 = secondaryprecount
            output2 = 0
            output2Name = ""
            output2FullName = ""
            output3 = 0
            output3Total = 0
            output4 = 0

            'If Me.pretestdone = False Then
            '    statusmessage = "Calculating Operation Parameters"
            '    primary_PercentComplete = 0
            '    worker.ReportProgress(0)
            '    PreCount_Function()
            '    Me.pretestdone = True

            'End If

            If worker.CancellationPending Then
                e.Cancel = True
                Exit Try
            End If

            statusmessage = "Beginning Operation"
            primary_PercentComplete = 0
            secondary_PercentComplete = 0
            worker.ReportProgress(0)
            Dim percentComplete As Integer
            Dim filename As String
            For Each filename In InputTargetFiles.Items
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
                output2 = output2 + 1
                Dim f As FileInfo = New FileInfo(filename)
                output2Name = f.Name
                output2FullName = f.FullName
                f = Nothing

                output3 = 0
                primary_highestPercentageReached = 0
                PreCount_Function(filename)

                Dim writer As StreamWriter = New StreamWriter(outputfilename, True)

                If File_Exists(filename) = True Then
                    Dim reader As StreamReader = New StreamReader(filename, True)
                    While reader.Peek > -1
                        output3 = output3 + 1
                        output3Total = output3Total + 1
                        writer.WriteLine(reader.ReadLine())
                        Dim finfo As FileInfo = New FileInfo(outputfilename)
                        If finfo.Length < 1024 Then
                            output4 = finfo.Length & " bytes"
                        Else
                            If finfo.Length < 1048576 Then
                                output4 = Math.Round(finfo.Length / 1024, 4) & " KB"
                            Else
                                If finfo.Length < 1073741824 Then
                                    output4 = Math.Round(finfo.Length / (1024 * 1024), 4) & " MB"
                                Else
                                    ' If finfo.Length < 1073741824 Then
                                    output4 = Math.Round(finfo.Length / (1024 * 1024 * 1024), 4) & " GB"
                                    'End If
                                End If
                            End If
                        End If
                        finfo = Nothing

                        percentComplete = 0
                        If primaryprecount > 0 Then
                            percentComplete = CSng(output3) / CSng(primaryprecount) * 100
                        Else
                            percentComplete = 100
                        End If
                        primary_PercentComplete = percentComplete
                        If percentComplete > primary_highestPercentageReached Then
                            primary_highestPercentageReached = percentComplete
                            statusmessage = "Writing File"
                            worker.ReportProgress(percentComplete)
                        End If

                    End While
                End If
                writer.Close()


                percentComplete = 0
                If secondaryprecount > 0 Then
                    percentComplete = CSng(output2) / CSng(secondaryprecount) * 100
                Else
                    percentComplete = 100
                End If
                secondary_PercentComplete = percentComplete
                If percentComplete > secondary_highestPercentageReached Then
                    secondary_highestPercentageReached = percentComplete
                    statusmessage = "Combining Files"
                    worker.ReportProgress(percentComplete)
                End If
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            Error_Handler(ex, "MainWorkerFunction")
        End Try

        Return result

    End Function

    Private Sub PreCount_Function(ByVal filename As String)
        Try
            primaryprecount = 0
            If File_Exists(filename) = True Then
                Dim reader As StreamReader = New StreamReader(filename, True)
                While reader.Peek > -1
                    reader.ReadLine()
                    primaryprecount = primaryprecount + 1
                End While
            End If
        Catch ex As Exception
            Error_Handler(ex, "PreCount_Function")
        End Try
    End Sub


    Private Function DosShellCommand(ByVal AppToRun As String) As String
        Dim s As String = ""
        Try
            Dim myProcess As Process = New Process

            myProcess.StartInfo.FileName = "cmd.exe"
            myProcess.StartInfo.UseShellExecute = False


            Dim sErr As StreamReader
            Dim sOut As StreamReader
            Dim sIn As StreamWriter


            myProcess.StartInfo.CreateNoWindow = True

            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True

            'myProcess.StartInfo.FileName = AppToRun

            myProcess.Start()
            sIn = myProcess.StandardInput
            sIn.AutoFlush = True

            sOut = myProcess.StandardOutput()
            sErr = myProcess.StandardError

            sIn.Write(AppToRun & System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()

            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If



            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()


        Catch ex As Exception
            Error_Handler(ex, "DosShellCommand")
        End Try

        Return s
    End Function

    Private Function ApplicationLauncher(ByVal AppToRun As String, ByVal apptorunArgs As String) As String
        Dim s As String = ""
        Try

            Dim myProcess As Process = New Process


            myProcess.StartInfo.UseShellExecute = False


            Dim sErr As StreamReader
            Dim sOut As StreamReader
            Dim sIn As StreamWriter


            myProcess.StartInfo.CreateNoWindow = True

            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True

            myProcess.StartInfo.FileName = AppToRun
            myProcess.StartInfo.Arguments = apptorunArgs

            myProcess.Start()
            sIn = myProcess.StandardInput
            sIn.AutoFlush = True

            sOut = myProcess.StandardOutput()
            sErr = myProcess.StandardError

            sIn.Write(AppToRun & System.Environment.NewLine)
            sIn.Write("exit" & System.Environment.NewLine)
            s = sOut.ReadToEnd()

            If Not myProcess.HasExited Then
                myProcess.Kill()
            End If

            sIn.Close()
            sOut.Close()
            sErr.Close()
            myProcess.Close()


        Catch ex As Exception
            Error_Handler(ex, "ApplicationLauncher")
        End Try
        Return s
    End Function


    Private Sub InputTargetFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputTargetFiles.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.All
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub

    Private Sub InputTargetFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InputTargetFiles.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim MyFiles() As String


                ' Assign the files to an array.
                MyFiles = e.Data.GetData(DataFormats.FileDrop)
                ' Loop through the array and add the files to the list.
                'For i = 0 To MyFiles.Length - 1
                If MyFiles.Length > 0 Then
                    Dim filename As String
                    Dim finfo As FileInfo
                    Dim dinfo As DirectoryInfo
                    For Each filename In MyFiles
                        finfo = New FileInfo(filename)
                        If finfo.Exists = True Then
                            InputTargetFiles.Items.Add(finfo.FullName)
                        End If
                        finfo = Nothing
                        dinfo = New DirectoryInfo(filename)
                        If dinfo.Exists = True Then
                            For Each finfo In dinfo.GetFiles
                                If finfo.Exists = True Then
                                    InputTargetFiles.Items.Add(finfo.FullName)
                                End If
                            Next
                        End If
                        finfo = Nothing
                        dinfo = Nothing
                    Next

                End If
                'Next
            End If
        Catch ex As Exception
            Error_Handler(ex)
        End Try
    End Sub


    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Try
            InputTargetFiles.Items.Clear()

        Catch ex As Exception
            Error_Handler(ex, "Clear listbox")
        End Try
    End Sub
End Class
