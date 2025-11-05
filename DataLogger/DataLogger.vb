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
        Catch ex As Exception
            'No COM Ports found
            MessageBox.Show("No COM Ports found. Please connect the Q@ Board and restart the application.")
        End Try
        SecondsRadioButton.Checked = True 'Set default time unit to seconds
        MinutesRadioButton.Checked = False
        MiliSecondsRadioButton.Checked = False

        SampleRateComboBox.Items.Add("1 Second")
        SampleRateComboBox.Items.Add("5 Seconds")
        SampleRateComboBox.Items.Add("10 Seconds")
        SampleRateComboBox.Items.Add("30 Seconds")
        SampleRateComboBox.SelectedIndex = 0 'Set default sample rate to 1 second

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
            End If

        Catch ex As Exception
            'Show error message if port is invalid
            MessageBox.Show("Error: " & ex.Message)
            Return
        End Try
    End Sub
    'Sample Rate ----------------------------------------------------------------------------------------
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        CheckForIllegalCrossThreadCalls = False 'disable cross-thread checking
        Dim incomingData As Integer = SerialPort.BytesToRead 'get number of bytes to read
    End Sub
    Private Sub SampleRateTimer_Tick(sender As Object, e As EventArgs) Handles SampleRateTimer.Tick

    End Sub
    'Event Handlers -------------------------------------------------------------------------------------
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        SerialPort.Close() 'Close Serial Port
        Me.Close()
    End Sub
    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click

    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

    End Sub
    'Menu Items --------------------------------------------------------------------------------------
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        SerialPort.Close() 'Close Serial Port
        Me.Close()
    End Sub
    Private Sub StartToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem1.Click

    End Sub
    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click

    End Sub
    Private Sub StopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem1.Click

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
        Me.Close()
    End Sub
End Class
