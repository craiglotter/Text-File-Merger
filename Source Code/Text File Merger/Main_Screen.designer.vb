<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.startAsyncButton = New System.Windows.Forms.Button
        Me.Status_Textbox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FullErrors_Checkbox = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.InputTargetFiles = New System.Windows.Forms.ListBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.cancelAsyncButton = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.output3lbl = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.output4lbl = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.output2lbl = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.datelaunched_label = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.output1lbl = New System.Windows.Forms.Label
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'startAsyncButton
        '
        Me.startAsyncButton.BackColor = System.Drawing.SystemColors.Control
        Me.startAsyncButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.startAsyncButton.Location = New System.Drawing.Point(17, 382)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(90, 23)
        Me.startAsyncButton.TabIndex = 15
        Me.startAsyncButton.Text = "Begin"
        Me.startAsyncButton.UseVisualStyleBackColor = False
        '
        'Status_Textbox
        '
        Me.Status_Textbox.BackColor = System.Drawing.SystemColors.Control
        Me.Status_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Status_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_Textbox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Status_Textbox.Location = New System.Drawing.Point(12, 12)
        Me.Status_Textbox.Name = "Status_Textbox"
        Me.Status_Textbox.ReadOnly = True
        Me.Status_Textbox.Size = New System.Drawing.Size(333, 10)
        Me.Status_Textbox.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(351, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "20060522.1"
        Me.ToolTip1.SetToolTip(Me.Label1, "Application Build Number")
        '
        'FullErrors_Checkbox
        '
        Me.FullErrors_Checkbox.AutoSize = True
        Me.FullErrors_Checkbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullErrors_Checkbox.Location = New System.Drawing.Point(421, 9)
        Me.FullErrors_Checkbox.Name = "FullErrors_Checkbox"
        Me.FullErrors_Checkbox.Size = New System.Drawing.Size(15, 14)
        Me.FullErrors_Checkbox.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.FullErrors_Checkbox, "Check to enable full error processing mode.")
        Me.FullErrors_Checkbox.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Drag your input text files here"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.InputTargetFiles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(17, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 180)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Text Files"
        '
        'InputTargetFiles
        '
        Me.InputTargetFiles.AllowDrop = True
        Me.InputTargetFiles.BackColor = System.Drawing.SystemColors.ControlLight
        Me.InputTargetFiles.FormattingEnabled = True
        Me.InputTargetFiles.HorizontalScrollbar = True
        Me.InputTargetFiles.Location = New System.Drawing.Point(6, 40)
        Me.InputTargetFiles.Name = "InputTargetFiles"
        Me.InputTargetFiles.Size = New System.Drawing.Size(386, 134)
        Me.InputTargetFiles.TabIndex = 25
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 417)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(398, 23)
        Me.ProgressBar1.TabIndex = 39
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.BackColor = System.Drawing.SystemColors.Control
        Me.cancelAsyncButton.Enabled = False
        Me.cancelAsyncButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cancelAsyncButton.Location = New System.Drawing.Point(113, 382)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(94, 23)
        Me.cancelAsyncButton.TabIndex = 38
        Me.cancelAsyncButton.Text = "Cancel"
        Me.cancelAsyncButton.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.output3lbl)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.output4lbl)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.output2lbl)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.datelaunched_label)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.output1lbl)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(17, 192)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(398, 172)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operation Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(16, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Lines Processed:"
        '
        'output3lbl
        '
        Me.output3lbl.ForeColor = System.Drawing.Color.Teal
        Me.output3lbl.Location = New System.Drawing.Point(160, 67)
        Me.output3lbl.Name = "output3lbl"
        Me.output3lbl.Size = New System.Drawing.Size(232, 23)
        Me.output3lbl.TabIndex = 36
        Me.output3lbl.Text = "(no result)"
        Me.output3lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Generated File Size:"
        '
        'output4lbl
        '
        Me.output4lbl.ForeColor = System.Drawing.Color.Teal
        Me.output4lbl.Location = New System.Drawing.Point(160, 95)
        Me.output4lbl.Name = "output4lbl"
        Me.output4lbl.Size = New System.Drawing.Size(232, 23)
        Me.output4lbl.TabIndex = 33
        Me.output4lbl.Text = "(no result)"
        Me.output4lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(15, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Current File:"
        '
        'output2lbl
        '
        Me.output2lbl.ForeColor = System.Drawing.Color.Teal
        Me.output2lbl.Location = New System.Drawing.Point(160, 42)
        Me.output2lbl.Name = "output2lbl"
        Me.output2lbl.Size = New System.Drawing.Size(232, 23)
        Me.output2lbl.TabIndex = 20
        Me.output2lbl.Text = "(no result)"
        Me.output2lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Operational Time:"
        '
        'datelaunched_label
        '
        Me.datelaunched_label.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.datelaunched_label.Location = New System.Drawing.Point(16, 138)
        Me.datelaunched_label.Name = "datelaunched_label"
        Me.datelaunched_label.Size = New System.Drawing.Size(376, 23)
        Me.datelaunched_label.TabIndex = 23
        Me.datelaunched_label.Text = "(no result)"
        Me.datelaunched_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(15, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Combining File:"
        '
        'output1lbl
        '
        Me.output1lbl.ForeColor = System.Drawing.Color.Teal
        Me.output1lbl.Location = New System.Drawing.Point(160, 16)
        Me.output1lbl.Name = "output1lbl"
        Me.output1lbl.Size = New System.Drawing.Size(232, 23)
        Me.output1lbl.TabIndex = 25
        Me.output1lbl.Text = "(no result)"
        Me.output1lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Status_Textbox)
        Me.Panel1.Controls.Add(Me.FullErrors_Checkbox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel1.Location = New System.Drawing.Point(0, 447)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 31)
        Me.Panel1.TabIndex = 42
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 0
        Me.ToolTip1.AutoPopDelay = 0
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 0
        Me.ToolTip1.UseAnimation = False
        Me.ToolTip1.UseFading = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProgressBar2.Location = New System.Drawing.Point(224, 382)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(191, 23)
        Me.ProgressBar2.TabIndex = 46
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "txt"
        Me.SaveFileDialog1.Filter = "Text files|*.txt|All files|*.*"
        Me.SaveFileDialog1.Title = "Save your merged text file"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(331, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Clear"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(438, 477)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.startAsyncButton)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(446, 511)
        Me.MinimumSize = New System.Drawing.Size(446, 511)
        Me.Name = "Main_Screen"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Text File Merger"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents startAsyncButton As System.Windows.Forms.Button
    Friend WithEvents Status_Textbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FullErrors_Checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents output2lbl As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents datelaunched_label As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents output1lbl As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents output4lbl As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents output3lbl As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents InputTargetFiles As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
