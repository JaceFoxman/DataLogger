'Jason Permann
'Fall 2025
'Jason Permann
'RCET 3371
'Data Logger Application
'

Option Strict On
Option Explicit On
Option Compare Text
Imports System.IO.Ports 'Import Serial Port Namespace

Public Class DataLogger
    Dim DataBuffer As New Queue(Of Integer)
    'Initialize Form -------------------------------------------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDefaults()
    End Sub
    Sub SetDefaults()
        Try
            For Each port In SerialPort.GetPortNames()
                COMPort_ComboBox.Items.Add(port)
            Next
            COMPort_ComboBox.SelectedIndex = 0

            SecondsRadioButton.Checked = True 'Set default time unit to seconds
            MinutesRadioButton.Checked = False
            MiliSecondsRadioButton.Checked = False
            StartButton.Enabled = False
            StartToolStripMenuItem1.Enabled = False
            StartToolStripMenuItem.Enabled = False

            SampleRateComboBox.Items.Add("1 Second")
            SampleRateComboBox.Items.Add("5 Seconds")
            SampleRateComboBox.Items.Add("10 Seconds")
            SampleRateComboBox.Items.Add("30 Seconds")
            SampleRateComboBox.SelectedIndex = 0 'Set default sample rate to 1 second

            IterationTextBox.Text = "0" 'Set default iteration count to 0

        Catch ex As Exception
            'No COM Ports found
            MessageBox.Show("No COM Ports found. Please connect the Q@ Board and restart the application.")
        End Try
    End Sub
    'Serial Connection -----------------------------------------------------------------------------------
    ''' <summary>
    '''  Connect to Serial Port
    ''' </summary>
    Sub Connect()
        Try
            Dim comPort As String = COMPort_ComboBox.Text
            SerialPort.Close()
            SerialPort.BaudRate = 9600 'Q@ Board Default
            SerialPort.Parity = IO.Ports.Parity.None   'No Parity
            SerialPort.StopBits = IO.Ports.StopBits.One    '1 Stop Bit
            SerialPort.DataBits = 8    '8 Data Bits
            SerialPort.PortName = comPort 'Change to your COM Port

            SerialPort.Open()  'Open Serial Port
            If SerialPort.IsOpen Then  'Check if Serial Port is open
                MessageBox.Show("Connected to " & SerialPort.PortName) 'Show message if connected
                COMPortToolStripStatusLabel.Text = ("Connected to " & SerialPort.PortName)
                StartButton.Enabled = True
                StartToolStripMenuItem1.Enabled = True
                StartToolStripMenuItem.Enabled = True
                'SampleRateTimer.Enabled = True 'Enable Sample Rate Timer
                'CommandTimer.Enabled = True 'Enable Command Timer
            End If

        Catch ex As Exception
            'Show error message if port is invalid
            MessageBox.Show("Error: " & ex.Message)
            Return
        End Try
    End Sub
    'Graphing Analog Data-------------------------------------------------------------------------------
    Sub GetData(analogValue As Integer)
        Dim _last%
        _last = analogValue
        'If Me.DataBuffer.Count > 0 Then
        '    _last = Me.DataBuffer.Last
        'Else
        '    _last = analogValue
        'End If

        If Me.DataBuffer.Count >= 500 Then 'keep the queue trimmed to graph x length
            Me.DataBuffer.Dequeue()
        End If

        Me.DataBuffer.Enqueue(_last)
    End Sub
    Sub GraphData()
        Dim g As Graphics = GraphPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Lime)
        Dim eraser As New Pen(Color.Black)
        Dim scaleX! = CSng(GraphPictureBox.Width / Me.DataBuffer.Count)
        Dim scaleY! = CSng((GraphPictureBox.Height / 1024) * -1)

        g.Clear(Color.Black)
        g.TranslateTransform(0, GraphPictureBox.Height) 'move origin to bottom left
        g.ScaleTransform(scaleX, scaleY) 'scale to (me.DataBuffer.count x 1025) units
        pen.Width = 0.25 'fix pen so it is not too thick

        Dim oldY% = 0 
        Dim x = -1
        For Each analogDataY In Me.DataBuffer.Reverse
            x += 1
            'g.DrawLine(eraser, x, 0, x, Me.DataBuffer.Count)
            g.DrawLine(pen, x - 1, oldY, x, analogDataY)
            oldY = analogDataY
        Next

        g.Dispose()
        pen.Dispose()
        'eraser.Dispose()
    End Sub
    'Sample Rate ----------------------------------------------------------------------------------------
    Private Sub CommandTimer_Tick(sender As Object, e As EventArgs) Handles CommandTimer.Tick
        Dim command As Byte() = New Byte(0) {}
        If SerialPort.IsOpen Then
            command(0) = &H51 'Command to request data from Analog inputs of the Q@ Board
            CurrentTextBox.Text = "51 sent"
            SerialPort.Write(command, 0, 1)
        End If
    End Sub
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        CheckForIllegalCrossThreadCalls = False 'disable cross-thread checking
        Dim incomingData As Integer = SerialPort.BytesToRead 'get number of bytes to read
    End Sub
    Private Sub SampleRateTimer_Tick(sender As Object, e As EventArgs) Handles SampleRateTimer.Tick
        ReadAnalogData()
    End Sub
    Sub ReadAnalogData()
        If SerialPort.BytesToRead = 2 Then
            Dim incomingData(SerialPort.BytesToRead) As Byte    'create byte array to hold incoming data
            Dim value As String 'store incoming data as string
            SerialPort.Read(incomingData, 0, SerialPort.BytesToRead)    'read incoming data
            For Each dataByte In incomingData   'loop through incoming data bytes
                value &= $"{CStr(dataByte)},"   'build string of incoming data
            Next
            CurrentTextBox.Text = value 'display raw incoming data

            Dim valueSplit As String() = value.Split(","c)  'split incoming data into array

            Dim analogHighSplit As Integer = CInt(valueSplit(0)) 'get analog high byte
            HighByteTextBox.Text = analogHighSplit.ToString
            Dim analogLowSplit As Integer = CInt(valueSplit(1))  'get analog low byte
            LowByteTextBox.Text = analogLowSplit.ToString

            Dim analogHighWeighted As Integer = (analogHighSplit * 4) 'weight high byte
            Dim analogLowWeighted As Integer = (analogLowSplit \ 64)  'weight low byte
            Dim analogFinal As Integer = analogHighWeighted + analogLowWeighted    'final analog value
            AnalogFinalTextBox.Text = analogFinal.ToString
            IterationTextBox.Text = (CInt(IterationTextBox.Text) + 1).ToString 'increment iteration count
            LogAnalogData(analogHighSplit.ToString, analogLowSplit.ToString, analogFinal.ToString)

            GetData(analogFinal) 'write analog data to enqueueue
            GraphData() 'graph analog data
        End If
    End Sub
    'Data Logging ----------------------------------------------------------------------------------------
    Private Sub ThirtySecondTimer_Tick(sender As Object, e As EventArgs) Handles ThirtySecondTimer.Tick
        Dim path As String = "AnalogDataLog.log"
        FileOpen(1, path, OpenMode.Output)
        FileClose(1)
    End Sub

    Sub LogAnalogData(highByte As String, lowByte As String, analogValue As String)
        Dim path As String = "AnalogDataLog.log"
        'get current date and time
        Dim currentDateTime As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        'create log entry
        Dim logEntry As String = $"$$AN1, High Byte: {highByte}, Low Byte: {lowByte}, Analog Value: {analogValue}, {currentDateTime}"
        'append log entry to file
        FileOpen(1, path, OpenMode.Append)
        'PrintLine(1, "-------------------")
        WriteLine(1, {logEntry})
        FileClose(1)
        'LogFilePathToolStripStatusLabel.Text = $"Log File Path: {path}"
    End Sub
    'Read Date  ------------------------------------------------------------------------------------------
    Sub GrabAnalogData()
        Dim choice As DialogResult
        Dim fileNumber% = FreeFile()
        Dim currentRecord$
        Dim tempArray() As String
        Dim analogValue As String
        OpenFileDialog.Filter = "log file (*.log)|*.log"
        'OpenFileDialog.Title = "Select Analog Data Log File"
        choice = OpenFileDialog.ShowDialog()
        If choice = DialogResult.OK Then
            MsgBox(OpenFileDialog.FileName)
            LogFilePathToolStripStatusLabel.Text = $"Log File Path: {OpenFileDialog.FileName}"
            Try
                FileOpen(fileNumber, OpenFileDialog.FileName, OpenMode.Input)
                Me.DataBuffer.Clear()

                Do Until EOF(fileNumber)
                    currentRecord = LineInput(fileNumber)
                    tempArray = Split(currentRecord, ",")
                    analogValue = tempArray(3).Substring(tempArray(3).IndexOf(":") + 2)
                    'MsgBox(analogValue) 
                    Me.DataBuffer.Enqueue(CInt(analogValue))
                Loop

                FileClose(fileNumber)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Canceled")
            LogFilePathToolStripStatusLabel.Text = $"Log File Path: Not Selected"
        End If

        GraphData()

    End Sub
    'Event Handlers -------------------------------------------------------------------------------------
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        SerialPort.Close() 'Close Serial Port
        'Dim path As String = "AnalogDataLog.log"
        'FileOpen(1, path, OpenMode.Append)
        'PrintLine(1, $"Program Closed")
        'FileClose(1)
        Me.Close()
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        SampleRateTimer.Enabled = False 'Disaable Sample Rate Timer
        CommandTimer.Enabled = False 'Disable Command Timer
        ThirtySecondTimer.Enabled = False 'Disable 30 Second Timer
        DataLogTimer.Enabled = False 'Disable Data Log Timer
        CurrentTextBox.Text = "Stopped"
        AnalogFinalTextBox.Text = "Stopped"
        IterationTextBox.Text = "0" 'Set iteration count to 0

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        SampleRateTimer.Enabled = True 'Enable Sample Rate Timer
        CommandTimer.Enabled = True 'Enable Command Timer
        ThirtySecondTimer.Enabled = True 'Enable 30 Second Timer
        DataLogTimer.Enabled = True 'Enable Data Log Timer
    End Sub
    Private Sub Connect_Button_Click(sender As Object, e As EventArgs) Handles Connect_Button.Click
        Connect()
    End Sub
    Private Sub SampleRateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SampleRateComboBox.SelectedIndexChanged
        'Set Sample Rate Timer Interval based on selected sample rate
        Select Case SampleRateComboBox.SelectedItem.ToString()
            Case "100 Milliseconds"
                CommandTimer.Interval = 100
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 100 ms"
            Case "200 Milliseconds"
                CommandTimer.Interval = 200
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 200 ms"
            Case "500 Milliseconds"
                CommandTimer.Interval = 500
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 500 ms"
            Case "1 Second"
                CommandTimer.Interval = 1000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 1 Second"
            Case "5 Seconds"
                CommandTimer.Interval = 5000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 5 Seconds"
            Case "10 Seconds"
                CommandTimer.Interval = 10000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 10 Seconds"
            Case "30 Seconds"
                CommandTimer.Interval = 30000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 30 Seconds"
            Case "1 Minute"
                CommandTimer.Interval = 60000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 1 Minute"
            Case "5 Minutes"
                CommandTimer.Interval = 300000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 5 Minutes"
            Case "10 Minutes"
                CommandTimer.Interval = 600000
                SamplingRateToolStripStatusLabel.Text = "Sample Rate: 10 Minutes"
        End Select
    End Sub
    'Radio Buttons -----------------------------------------------------------------------------------
    Private Sub MinutesRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MinutesRadioButton.CheckedChanged
        If MinutesRadioButton.Checked Then
            SecondsRadioButton.Checked = False
            MiliSecondsRadioButton.Checked = False

            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add("1 Minute")
            SampleRateComboBox.Items.Add("5 Minutes")
            SampleRateComboBox.Items.Add("10 Minutes")
            SampleRateComboBox.SelectedIndex = 0 'Set default sample rate to 1 minute
        End If
    End Sub
    Private Sub SecondsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SecondsRadioButton.CheckedChanged
        If SecondsRadioButton.Checked Then
            MinutesRadioButton.Checked = False
            MiliSecondsRadioButton.Checked = False

            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add("1 Second")
            SampleRateComboBox.Items.Add("5 Seconds")
            SampleRateComboBox.Items.Add("10 Seconds")
            SampleRateComboBox.Items.Add("30 Seconds")
            SampleRateComboBox.SelectedIndex = 0 'Set default sample rate to 1 second
        End If
    End Sub
    Private Sub MiliSecondsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MiliSecondsRadioButton.CheckedChanged
        If MiliSecondsRadioButton.Checked Then
            MinutesRadioButton.Checked = False
            SecondsRadioButton.Checked = False

            SampleRateComboBox.Items.Clear()
            SampleRateComboBox.Items.Add("100 Milliseconds")
            SampleRateComboBox.Items.Add("200 Milliseconds")
            SampleRateComboBox.Items.Add("500 Milliseconds")
            SampleRateComboBox.SelectedIndex = 0 'Set default sample rate to 100 milliseconds
        End If
    End Sub
    'Menu Items --------------------------------------------------------------------------------------
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        SerialPort.Close() 'Close Serial Port
        Dim path As String = "AnalogDataLog.log"
        FileOpen(1, path, OpenMode.Append)
        PrintLine(1, $"Program Closed")
        FileClose(1)
        Me.Close()
    End Sub
    Private Sub StartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem1.Click
        SampleRateTimer.Enabled = True 'Enable Sample Rate Timer
        CommandTimer.Enabled = True 'Enable Command Timer
        DataLogTimer.Enabled = True 'Enable Data Log Timer
    End Sub
    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click

    End Sub
    Private Sub StopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem1.Click
        SampleRateTimer.Enabled = False 'Disaable Sample Rate Timer
        CommandTimer.Enabled = False 'Disable Command Timer
        DataLogTimer.Enabled = False 'Disable Data Log Timer
        CurrentTextBox.Text = "Stopped"
        AnalogFinalTextBox.Text = "Stopped"
    End Sub
    Private Sub ClearLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearLogToolStripMenuItem.Click
        Dim result As DialogResult
        result = MessageBox.Show("Doing this will clear all previous analog data that has been logged." & vbNewLine _
        & "Are you sure you want to proceed?", "Yes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Dim path As String = "AnalogDataLog.log"
            FileOpen(1, path, OpenMode.Output)
            FileClose(1)
        Else
        End If
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        GrabAnalogData()
    End Sub
    'Context Menu Items --------------------------------------------------------------------------------
    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click

    End Sub
    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click

    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        SerialPort.Close() 'Close Serial Port
        Dim path As String = "AnalogDataLog.log"
        FileOpen(1, path, OpenMode.Append)
        PrintLine(1, $"Program Closed")
        FileClose(1)
        Me.Close()
    End Sub
End Class
