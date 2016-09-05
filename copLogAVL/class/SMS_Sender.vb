Imports System.IO.Ports
Imports System.Threading

Public Class SMS_Sender
    Private WithEvents SMSPort As SerialPort
    Private SMSThread As Thread
    Private ReadThread As Thread
    Shared _Continue As Boolean = False
    Private _Wait As Boolean = False
    Shared _ReadPort As Boolean = False
    Public Event Sending(ByVal Done As Boolean)
    Public Event DataReceived(ByVal Message As String)

    Public Sub New(ByRef COMMPORT As String)
        'initialize all values
        SMSPort = New SerialPort
        With SMSPort
            .PortName = COMMPORT
            .BaudRate = 115200
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
        End With
    End Sub
    Public Function SendSMS(ByVal tempNum() As String, ByVal tempText As String) As Boolean
        If SMSPort.IsOpen = True Then
            'sending AT commands
            Thread.Sleep(1000)
            SMSPort.WriteLine("AT+CMGF=1" + vbCrLf)                         'set command message format to text mode(1)
            Thread.Sleep(700)
            SMSPort.WriteLine("AT&K4" + vbCrLf) 
            Thread.Sleep(700)
            SMSPort.WriteLine("AT+CSMP=17,167,0,0" + vbCrLf)

            For Each number As String In tempNum                            'ส่งแบบหลายๆเบอร์
                Thread.Sleep(1000)
                SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                Thread.Sleep(1000)
                SMSPort.WriteLine(tempText + vbCrLf + Chr(26))              'SMS sending
                Thread.Sleep(7000)
                SMSPort.WriteLine("AT+CMGD=1,4" + vbCrLf)
                Thread.Sleep(1000)
            Next
            
            Thread.Sleep(4000)
            SMSPort.Close()
        End If
        Return true
    End Function

    Public Function SendSMSLong(ByVal tempNum() As String, ByVal tempText As String) As Boolean 'For long text SMS
        If SMSPort.IsOpen = True Then
            'sending AT commands
            Thread.Sleep(1000)
            SMSPort.WriteLine("AT+CMGF=1" + vbCrLf)                         'set command message format to text mode(1)
            Thread.Sleep(700)
            SMSPort.WriteLine("AT&K4" + vbCrLf) 
            Thread.Sleep(700)
            SMSPort.WriteLine("AT+CSMP=17,167,0,0" + vbCrLf)

            For Each number As String In tempNum                            'ส่งแบบหลายๆเบอร์
                If(tempText.Length()<151) then
                    Thread.Sleep(1000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGD=1,4" + vbCrLf)
                    Thread.Sleep(1000)
                Else If (tempText.Length()>150) and (tempText.Length()<301)  then
                    Thread.Sleep(1000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText.Substring(0,150) + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText.Substring(151,300) + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGD=1,4" + vbCrLf)
                    Thread.Sleep(1000)
                Else If tempText.Length()>300 then
                    Thread.Sleep(1000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText.Substring(0,150) + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText.Substring(151,300) + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGS=""" + number + """" + vbCrLf)    'enter the mobile number whom you want to send the SMS
                    Thread.Sleep(1000)
                    SMSPort.WriteLine(tempText.Substring(301) + Chr(26))              'SMS sending
                    Thread.Sleep(15000)
                    SMSPort.WriteLine("AT+CMGD=1,4" + vbCrLf)
                    Thread.Sleep(1000)
                End If
            Next
            
            Thread.Sleep(10000)
            SMSPort.Close()
        End If
        Return true
    End Function

    Public Sub Open()
        If Not (SMSPort.IsOpen = True) Then
            SMSPort.Open()
        End If
    End Sub

    Public Sub Close()
        If SMSPort.IsOpen = True Then
            SMSPort.Close()
        End If
    End Sub

End Class
