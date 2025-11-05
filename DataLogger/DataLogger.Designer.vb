<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataLogger
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ButtonGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LogFilePathToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SamplingRateToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.COMPortToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Connect_Button = New System.Windows.Forms.Button()
        Me.COMPort_ComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.SampleRateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SampleRateComboBox = New System.Windows.Forms.ComboBox()
        Me.SampleRateGroupBox = New System.Windows.Forms.GroupBox()
        Me.MinutesRadioButton = New System.Windows.Forms.RadioButton()
        Me.SecondsRadioButton = New System.Windows.Forms.RadioButton()
        Me.MiliSecondsRadioButton = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopMenuStrip.SuspendLayout()
        Me.RightClickContextMenuStrip.SuspendLayout()
        Me.ButtonGroupBox.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SampleRateGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox1.Location = New System.Drawing.Point(1, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(864, 398)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.TopMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(866, 33)
        Me.TopMenuStrip.TabIndex = 1
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(54, 29)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(141, 34)
        Me.ExitToolStripMenuItem1.Text = "&Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem1, Me.SaveToolStripMenuItem1, Me.StopToolStripMenuItem1})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(58, 29)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'StartToolStripMenuItem1
        '
        Me.StartToolStripMenuItem1.Name = "StartToolStripMenuItem1"
        Me.StartToolStripMenuItem1.Size = New System.Drawing.Size(151, 34)
        Me.StartToolStripMenuItem1.Text = "Start"
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(151, 34)
        Me.SaveToolStripMenuItem1.Text = "Save"
        '
        'StopToolStripMenuItem1
        '
        Me.StopToolStripMenuItem1.Name = "StopToolStripMenuItem1"
        Me.StopToolStripMenuItem1.Size = New System.Drawing.Size(151, 34)
        Me.StopToolStripMenuItem1.Text = "Stop"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(65, 29)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(164, 34)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'RightClickContextMenuStrip
        '
        Me.RightClickContextMenuStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.RightClickContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartToolStripMenuItem, Me.StopToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.RightClickContextMenuStrip.Name = "RightClickContextMenuStrip"
        Me.RightClickContextMenuStrip.Size = New System.Drawing.Size(122, 132)
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(121, 32)
        Me.StartToolStripMenuItem.Text = "Start"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(121, 32)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(121, 32)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(121, 32)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(11, 25)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(93, 75)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ButtonGroupBox
        '
        Me.ButtonGroupBox.Controls.Add(Me.ExitButton)
        Me.ButtonGroupBox.Controls.Add(Me.SaveButton)
        Me.ButtonGroupBox.Controls.Add(Me.StopButton)
        Me.ButtonGroupBox.Controls.Add(Me.StartButton)
        Me.ButtonGroupBox.Location = New System.Drawing.Point(649, 440)
        Me.ButtonGroupBox.Name = "ButtonGroupBox"
        Me.ButtonGroupBox.Size = New System.Drawing.Size(216, 205)
        Me.ButtonGroupBox.TabIndex = 3
        Me.ButtonGroupBox.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(110, 124)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(93, 75)
        Me.ExitButton.TabIndex = 5
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(110, 25)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(93, 75)
        Me.SaveButton.TabIndex = 4
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(11, 124)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(93, 75)
        Me.StopButton.TabIndex = 3
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogFilePathToolStripStatusLabel, Me.SamplingRateToolStripStatusLabel, Me.COMPortToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 658)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(866, 32)
        Me.StatusStrip.TabIndex = 4
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'LogFilePathToolStripStatusLabel
        '
        Me.LogFilePathToolStripStatusLabel.Name = "LogFilePathToolStripStatusLabel"
        Me.LogFilePathToolStripStatusLabel.Size = New System.Drawing.Size(112, 25)
        Me.LogFilePathToolStripStatusLabel.Text = "Log File Path"
        '
        'SamplingRateToolStripStatusLabel
        '
        Me.SamplingRateToolStripStatusLabel.Name = "SamplingRateToolStripStatusLabel"
        Me.SamplingRateToolStripStatusLabel.Size = New System.Drawing.Size(127, 25)
        Me.SamplingRateToolStripStatusLabel.Text = "Sampling Rate"
        '
        'COMPortToolStripStatusLabel
        '
        Me.COMPortToolStripStatusLabel.Name = "COMPortToolStripStatusLabel"
        Me.COMPortToolStripStatusLabel.Size = New System.Drawing.Size(90, 25)
        Me.COMPortToolStripStatusLabel.Text = "COM Port"
        '
        'Connect_Button
        '
        Me.Connect_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Connect_Button.BackColor = System.Drawing.Color.Green
        Me.Connect_Button.ForeColor = System.Drawing.Color.GhostWhite
        Me.Connect_Button.Location = New System.Drawing.Point(15, 505)
        Me.Connect_Button.Name = "Connect_Button"
        Me.Connect_Button.Size = New System.Drawing.Size(136, 35)
        Me.Connect_Button.TabIndex = 6
        Me.Connect_Button.Text = "Connect"
        Me.Connect_Button.UseVisualStyleBackColor = False
        '
        'COMPort_ComboBox
        '
        Me.COMPort_ComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.COMPort_ComboBox.Font = New System.Drawing.Font("Consolas", 10.0!)
        Me.COMPort_ComboBox.FormattingEnabled = True
        Me.COMPort_ComboBox.Location = New System.Drawing.Point(15, 459)
        Me.COMPort_ComboBox.Name = "COMPort_ComboBox"
        Me.COMPort_ComboBox.Size = New System.Drawing.Size(133, 31)
        Me.COMPort_ComboBox.TabIndex = 5
        '
        'SerialPort
        '
        '
        'SampleRateTimer
        '
        '
        'SampleRateComboBox
        '
        Me.SampleRateComboBox.FormattingEnabled = True
        Me.SampleRateComboBox.Location = New System.Drawing.Point(174, 459)
        Me.SampleRateComboBox.Name = "SampleRateComboBox"
        Me.SampleRateComboBox.Size = New System.Drawing.Size(245, 28)
        Me.SampleRateComboBox.TabIndex = 7
        '
        'SampleRateGroupBox
        '
        Me.SampleRateGroupBox.Controls.Add(Me.MiliSecondsRadioButton)
        Me.SampleRateGroupBox.Controls.Add(Me.SecondsRadioButton)
        Me.SampleRateGroupBox.Controls.Add(Me.MinutesRadioButton)
        Me.SampleRateGroupBox.Location = New System.Drawing.Point(443, 465)
        Me.SampleRateGroupBox.Name = "SampleRateGroupBox"
        Me.SampleRateGroupBox.Size = New System.Drawing.Size(200, 174)
        Me.SampleRateGroupBox.TabIndex = 8
        Me.SampleRateGroupBox.TabStop = False
        Me.SampleRateGroupBox.Text = "Sample Rate Select"
        '
        'MinutesRadioButton
        '
        Me.MinutesRadioButton.AutoSize = True
        Me.MinutesRadioButton.Location = New System.Drawing.Point(6, 40)
        Me.MinutesRadioButton.Name = "MinutesRadioButton"
        Me.MinutesRadioButton.Size = New System.Drawing.Size(90, 24)
        Me.MinutesRadioButton.TabIndex = 0
        Me.MinutesRadioButton.TabStop = True
        Me.MinutesRadioButton.Text = "Minutes"
        Me.MinutesRadioButton.UseVisualStyleBackColor = True
        '
        'SecondsRadioButton
        '
        Me.SecondsRadioButton.AutoSize = True
        Me.SecondsRadioButton.Location = New System.Drawing.Point(6, 85)
        Me.SecondsRadioButton.Name = "SecondsRadioButton"
        Me.SecondsRadioButton.Size = New System.Drawing.Size(97, 24)
        Me.SecondsRadioButton.TabIndex = 1
        Me.SecondsRadioButton.TabStop = True
        Me.SecondsRadioButton.Text = "Seconds"
        Me.SecondsRadioButton.UseVisualStyleBackColor = True
        '
        'MiliSecondsRadioButton
        '
        Me.MiliSecondsRadioButton.AutoSize = True
        Me.MiliSecondsRadioButton.Location = New System.Drawing.Point(6, 124)
        Me.MiliSecondsRadioButton.Name = "MiliSecondsRadioButton"
        Me.MiliSecondsRadioButton.Size = New System.Drawing.Size(116, 24)
        Me.MiliSecondsRadioButton.TabIndex = 2
        Me.MiliSecondsRadioButton.TabStop = True
        Me.MiliSecondsRadioButton.Text = "Miliseconds"
        Me.MiliSecondsRadioButton.UseVisualStyleBackColor = True
        '
        'DataLogger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 690)
        Me.Controls.Add(Me.SampleRateGroupBox)
        Me.Controls.Add(Me.SampleRateComboBox)
        Me.Controls.Add(Me.Connect_Button)
        Me.Controls.Add(Me.COMPort_ComboBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ButtonGroupBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "DataLogger"
        Me.Text = "Data Logger Application"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.RightClickContextMenuStrip.ResumeLayout(False)
        Me.ButtonGroupBox.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.SampleRateGroupBox.ResumeLayout(False)
        Me.SampleRateGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RightClickContextMenuStrip As ContextMenuStrip
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartButton As Button
    Friend WithEvents ButtonGroupBox As GroupBox
    Friend WithEvents ExitButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents LogFilePathToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents SamplingRateToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents COMPortToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents Connect_Button As Button
    Friend WithEvents COMPort_ComboBox As ComboBox
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents StartToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SampleRateTimer As Timer
    Friend WithEvents SampleRateComboBox As ComboBox
    Friend WithEvents SampleRateGroupBox As GroupBox
    Friend WithEvents MiliSecondsRadioButton As RadioButton
    Friend WithEvents SecondsRadioButton As RadioButton
    Friend WithEvents MinutesRadioButton As RadioButton
End Class
