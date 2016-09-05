Imports System.Text.RegularExpressions

Module validateFunc

    'Validate key press
    Public Function validate_Press(ByVal temp As Char, ByVal tempNum As Integer) As Boolean
        Select Case tempNum
            Case 1 'phone
                Return Not ((Char.IsDigit(temp) Or temp = "-"c Or temp = ","c Or Asc(temp) = Keys.Delete Or Asc(temp) = Keys.Right Or Asc(temp) = Keys.Left Or Asc(temp) = Keys.Back) And (temp <> "."c And temp <> "%"c))
            Case 2 'IP
                Return Not ((Char.IsDigit(temp) Or Asc(temp) = Keys.Delete Or Asc(temp) = Keys.Right Or Asc(temp) = Keys.Left Or Asc(temp) = Keys.Back) And (temp <> "%"c))
            Case 3 'SMSFilter
                Return Not ((Char.IsLetter(temp) Or Char.IsDigit(temp) Or Asc(temp) = Keys.Delete Or Asc(temp) = Keys.Right Or Asc(temp) = Keys.Left Or Asc(temp) = Keys.Back Or temp = ","c Or temp = ":"c) And (temp <> "%"c And temp <> "'"c))
            Case 4 'SourceFilter
                Return Not ((Char.IsDigit(temp) Or Asc(temp) = Keys.Delete Or Asc(temp) = Keys.Right Or Asc(temp) = Keys.Left Or Asc(temp) = Keys.Back Or temp = ","c) And (temp <> "%"c))
        End Select
        Return True
    End Function

    'Validate PhoneNum
    Public Function validatePhone_LostFocus(ByRef sender As PlaceHolderTextBox, ByRef smsNum() As String) As Boolean
        If sender.Text = "" Then Return False
        smsNum = sender.Text.Split(","c)
        For index As Integer = 0 To smsNum.Length-1
            smsNum(index) = smsNum(index).Replace("-", "")
            If smsNum(index).Length <> 10 Then 'chk length
                MsgBox("Phone Number format should have a length of 10 characters. (0##-###-####)")
                sender.Focus()
                sender.SelectionStart = sender.Text.Length
                Return False
            End If
            smsNum(index) = Int32.Parse(Regex.Replace(smsNum(index), "\D", "")).ToString("#########")
            smsNum(index) = String.Format("{0:+66000000000}", CDbl(smsNum(index).Trim))
        Next
        Return True
    End Function
    'validate SMSFilter
    Public Function validateSMSFilter_LostFocus(ByRef sender As PlaceHolderTextBox) As Boolean
        If sender.Text = "" Then Return False
        Dim IPAddTime() As String = sender.Text.Split(","c)
        For Each item As String In IPAddTime
            Dim IP() As String = item.Split(":"c)
            If IP.Length <> 4 Then
                MsgBox("format incorrect")
                sender.Focus()
                sender.SelectionStart = sender.Text.Length
            End If
            
            IF IP(2).Contains(".") or IsNumeric(IP(2)) = False Then
                MsgBox("Hours format should have only a integer number.")
                sender.Focus()
                sender.SelectionStart = sender.Text.Length
            End If

            IF IsNumeric(IP(3)) = False Then
                MsgBox("Hours format should have only a number.")
                sender.Focus()
                sender.SelectionStart = sender.Text.Length
            End If

            IF IsNumeric(IP(3)) = True Then
                If CDbl(IP(3)) Mod 0.5 <> 0 Then
                MsgBox("Hours format should have only a number and times of 0.5 Hours.")
                sender.Focus()
                sender.SelectionStart = sender.Text.Length
                end If
            End If

            validateIP_LostFocus(sender, IP(0))
        Next
        Return True
    End Function

    'Validate RangeIP
    Public Function validateIP_LostFocus(ByRef sender As PlaceHolderTextBox, Optional ByVal item As String = "NO") As Boolean
        Dim IP() As String

        If item = "NO" Then
            IP = sender.Text.Split("."c)
        Else
            IP = item.Split("."c)
        End If
        
        Dim Test As Integer
        If IP.Length = 4 Then 'If 3 "."
            Dim Proper As Boolean = True
            For I As Integer = 0 To 3
                If IP(I) = "" Then IP(I) = "256"
                Test = Integer.Parse(IP(I)) 'Parse the string for an integer, if its not return -1
                If Test < 0 Or Test > 255 Then 'If not between 0-255 then the ip is not a proper format
                    MsgBox("IP Address is not in a proper format! All numbers entered must be between 0 - 255")
                    sender.Focus()
                    sender.SelectionStart = sender.Text.Length
                    Return False
                End If
            Next
        Else
            MsgBox("IP Address is not in a proper format! There must be 4 numbers entered, in XXX.XXX.XXX.XXX format")
            sender.Focus()
            sender.SelectionStart = sender.Text.Length
            Return False
        End If
        Return True
    End Function

    'validate Source Filter
    Public Function validateSourceFilter_LostFocus(ByRef sender As PlaceHolderTextBox) As Boolean
        Dim IP() As String = sender.Text.Split(","c)
        For Each item As String In IP
            validateIP_LostFocus(sender, item)
        Next
        Return True
    End Function
End Module
