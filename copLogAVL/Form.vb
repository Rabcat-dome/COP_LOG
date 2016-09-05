Imports System.IO.Ports
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Drawing.Text

Public Class copLogAVL

    Dim Count As Integer = 0                    'นับข้อมูลที่เข้ามา
    Dim DayCount As Integer = 0         'นับ Hitของทั้งวัน 
    Dim countTimeRun As Integer = 0     'count time run in application
    Dim smsNum() As String                'Phone number to sms
    Dim tabPage As Integer = 1          'กำหนดเลขแท๊บ

    Dim aData() As HSDDB.COPStdMsgCls = {}
    Dim DDSRead As New HSDDB.COPDataDistributionCls 'DDS only read
    Private WithEvents DataReader As HSDDB.COPDataReaderMessageTrackMod1Cls  'cop_track_mod_1

    Dim mylist() As MsgData
    Dim Fil_Item() As String            'array ของ Source_filter
    Dim Fil_SMS() As String             'array ของ SMS_filter

    'ต้องไปติดตั้ง userName/Pass ใน DB Server ด้วย
    Private myConnMas As SqlConnection  'SQL MASTER DB
    Private myConnDB As SqlConnection   'SQL MY DB
    Private myCmd As SqlCommand
    'font
    Dim arialN As New PrivateFontCollection()
    Dim arialNB As New PrivateFontCollection()
    Dim lF As New PrivateFontCollection()
    Dim lFB As New PrivateFontCollection()
    Private Sub copLogAVL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'set form size
        Me.Width = 400
        
        'advance setting
        SMSTextBox.Enabled = False
        SMSFilter.Enabled = False
        IPBox.Enabled = False
        UserBox.Enabled = False
        PassBox.Enabled = False
        SourceBox.Enabled = False
        COMPortText.Enabled = False
        
        arialN.AddFontFile(".\Resources\ARIALN.TTF")
        arialNB.AddFontFile(".\Resources\ARIALNB.TTF")
        lF.AddFontFile(".\Resources\LFAX.TTF")
        lFB.AddFontFile(".\Resources\LFAXD.TTF")
        Dim fontaN As New System.Drawing.Font(arialN.Families(0), 9.75)
        lblSMS.Font = fontaN
        lblSMS3.Font = fontaN
        Dim fontaNB AS New System.Drawing.Font(arialNB.Families(0), 12,FontStyle.Bold)
        SMSLabel.Font = fontaNB
        lblLogstat.Font = fontaNB
        lblLogError.Font = fontaNB
        lblSourceFilter.Font = fontaNB
        Dim fontlF As New System.Drawing.Font(lF.Families(0), 15.75)
        ButtonStart.Font = fontlF
        Dim fontlFB As New System.Drawing.Font(lF.Families(0), 6.75,FontStyle.Bold)
        ButSet.Font = fontlFB
    End Sub

    'click Start
    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        'for Advance setting
        SMSTextBox.Enabled = False
        SMSFilter.Enabled = False
        
        SliderSMS.Enabled = False
        SliderStat.Enabled = False
        SliderError.Enabled = False
        SliderFilter.Enabled = False
        If SliderSMS.sety Then
            If smsNum is Nothing Then validatePhone_LostFocus(SMSTextBox, smsNum)
            SMSTextBox.Text = ""
            For Each strblock As String In smsNum
                If SMSTextBox.Text = "" then SMSTextBox.Text += strblock Else SMSTextBox.Text += "," + strblock
            Next
        End If
        
        IPBox.Enabled = False
        UserBox.Enabled = False
        PassBox.Enabled = False
        SourceBox.Enabled = False
        RadioTMode.Enabled = False
        RadioDMode.Enabled = False
        ButtonStart.Enabled = False
        COMPortText.Enabled = False
        If RadioDMode.Checked Then lblTrack.Text = "Total Stations  :"
        
        If Not CreateReader(DDSRead, DataReader) Then                       'เชื่อมต่อ dds
            DDSRead.LeaveDomain()
            Exit Sub
        End If
        
        'status begin count
        timeRun.Font = New Font(timeRun.Font, FontStyle.Bold)
        timeRun.Text = "<! START !>"
        TimerMinute.Enabled = True
        TimerSecOnLoad.Enabled = True
        TimerHour.Enabled = True
        TimerFullHour.Enabled = True
        If SliderStat.sety Or SliderError.sety Then TimerDay.Enabled = True
        If SliderFilter.sety Then Fil_Item = SourceBox.Text.Split(","c)                         'Source filter
        If SliderSMS.sety or SliderError.sety Then Fil_SMS = SMSFilter.Text.Split(","c)         'SMS filter

        If SliderStat.sety Or SliderError.sety Then                         'SQL DB=cop_counter table=cop_Log
            myConnMas = New SqlConnection("packet size=4096;Server=" + IPBox.Text + ";Database=master;User Id=" + UserBox.Text + ";Password=" + PassBox.Text)
            myConnDB = New SqlConnection("packet size=4096;Server=" + IPBox.Text + ";Database=cop_counter;User Id=" + UserBox.Text + ";Password=" + PassBox.Text + ";MultipleActiveResultSets=true;")
            CheckDatabaseExists(myConnMas)
            CheckTableExists(myConnDB)
        End If

        Dim smsCT() As String
        If SliderSMS.sety or SliderError.sety Then
            ReDim Preserve mylist(Fil_SMS.Length - 1)
                Dim i As Integer = 0
                For Each temp As String In Fil_SMS
                    smsCT = temp.Split(":"c)
                    mylist(i).SourceNode = smsCT(0)
                    mylist(i).CopNode = New BinTree(smsCT(0), "02500", 0, 0, 0, 0, 0, 0)
                    mylist(i).NumTrack = 0
                    mylist(i).CountSMS = 0
                    i += 1
                Next
        End If
        
    End Sub

    Private Sub DataReader_eDataAvailable(TopicName As String, COPDataType As HSDDB.COPDataCls.enuCOPDataType) Handles DataReader.eDataAvailable

        Count = DataReader.GetCOPStdMsg(aData)      'Count total hit
        If Count = 0 Then
            timeRun.Text = "COUNT=0"
            Exit Sub
        End If
        DayCount += Count

        If RadioTMode.Checked Then ReadaDataTmode(aData, mylist, SliderFilter.sety, Fil_Item) Else If RadioDMode.Checked Then ReadaDataDmode(aData, mylist, SliderFilter.sety, Fil_Item)
    End Sub

    'animation form
    Private Sub Slider_move(sender As Object, e As EventArgs) Handles ButSet.Click
        If Me.Width < 600 Then
            Do Until Me.Width > 600
                Me.Width = Me.Width + 2
            Loop
        Else
            Do Until Me.Width = 400
                Me.Width = Me.Width - 2
            Loop
        End If
    End Sub

    'For silder SMS
    Private Sub Slider_SMS(sender As Object, e As EventArgs) Handles SliderSMS.SetyChanged
        If SliderSMS.sety = True Then
            SMSTextBox.Enabled = True
            COMPortText.Enabled = True
        Else
            SMSTextBox.Enabled = False
            COMPortText.Enabled = False
        End If

        If SliderError.sety or SliderSMS.sety Then SMSFilter.Enabled = True Else SMSFilter.Enabled = False
    End Sub
    'For silder Log stat and error
    Private Sub Slider_LogStat(sender As Object, e As EventArgs) Handles SliderStat.SetyChanged, SliderError.SetyChanged
        If SliderStat.sety = True Or SliderError.sety = True Then
            IPBox.Enabled = True
            UserBox.Enabled = True
            PassBox.Enabled = True
        Else
            IPBox.Enabled = False
            UserBox.Enabled = False
            PassBox.Enabled = False
        End If
        If SliderError.sety or SliderSMS.sety Then SMSFilter.Enabled = True Else SMSFilter.Enabled = False
    End Sub
    'For silder Source filter
    Private Sub Slider_Filter(sender As Object, e As EventArgs) Handles SliderFilter.SetyChanged
        If SliderFilter.sety = True Then SourceBox.Enabled = True Else SourceBox.Enabled = False
    End Sub

    'For SMS TEXTBOX Validate
    Private Sub SMSTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SMSTextBox.KeyPress
        e.Handled = validate_Press(e.KeyChar, 1)
    End Sub
    Private Sub SMSTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SMSTextBox.LostFocus
        validatePhone_LostFocus(SMSTextBox, smsNum)
    End Sub
    Private Sub SMSFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SMSFilter.KeyPress
        e.Handled = validate_Press(e.KeyChar, 3)
    End Sub
    Private Sub SMSFilter_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SMSFilter.LostFocus
        validateSMSFilter_LostFocus(SMSFilter)
    End Sub

    'For IP Validate
    Private Sub IPBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IPBox.KeyPress
        e.Handled = validate_Press(e.KeyChar, 2)
    End Sub
    Private Sub txtIP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles IPBox.LostFocus
        validateIP_LostFocus(IPBox)
    End Sub

    'For Sourcefilter Validate
    Private Sub SoureBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SourceBox.KeyPress
        e.Handled = validate_Press(e.KeyChar, 4)
    End Sub
    Private Sub SourceBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SourceBox.LostFocus
        validateSourceFilter_LostFocus(SourceBox)
    End Sub
    ' กดปุ่ม clear Log
    Private Sub Log_Clear_Click(sender As Object, e As EventArgs) Handles Log_Clear.Click
        LogText.Text = ""
    End Sub

    'fade form from start
    Private Sub TimerFadeForm_Tick(sender As Object, e As EventArgs) Handles TimerFadeForm.Tick  '0.1 sec
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity >= 1 Then
            TimerFadeForm.Enabled = False
        End If
    End Sub

    'show system time
    Private Sub TimerSecOnLoad_Tick(sender As Object, e As EventArgs) Handles TimerSecOnLoad.Tick   '1 sec
        DateLabel.Text = getDateTimeThai()
        valueHit.Text = DayCount.ToString("N0")

        Dim temp As Integer = 0                             'นับจำนวน track ทั้งหมด
        If mylist Is Nothing Then Exit Sub
        For i As Integer = 0 To mylist.Length - 1
            temp += mylist(i).NumTrack
        Next
        trackHit.Text = temp.ToString("N0")
        sourceHit.Text = mylist.Length.ToString("N0")

        textScroll.Text = ""
        TextAd.Text = ""
        If tabPage = 1 Then
            For i As Integer = 0 To mylist.Length - 1
                textScroll.Text += "From:" + mylist(i).SourceNode + " Send:" + mylist(i).NumTrack.ToString("N0")
                If mylist(i).NumTrack > 1 Then
                    If RadioTMode.Checked Then textScroll.Text += " tracks" Else textScroll.Text += " stations"
                Else
                    If RadioTMode.Checked Then textScroll.Text += " track" Else textScroll.Text += " station"
                End If
                textScroll.Text += vbNewLine
            Next
        ElseIf tabPage = 2 Then
            For i As Integer = 0 To mylist.Length - 1
                TextAd.Text += "From:" + mylist(i).SourceNode + " Send:" + mylist(i).NumTrack.ToString("N0")
                If mylist(i).NumTrack > 1 Then
                    If RadioTMode.Checked Then TextAd.Text += " tracks" Else TextAd.Text += " stations"
                Else
                    If RadioTMode.Checked Then TextAd.Text += " track" Else TextAd.Text += " station"
                End If

                temp = mylist(i).CopNode.PreOrder
                TextAd.Text += " (" + temp.ToString("N0")
                If temp > 1 Then
                    TextAd.Text += " hits)"
                Else
                    TextAd.Text += " hit)"
                End If
                TextAd.Text += vbNewLine

            Next
        End If
    End Sub
    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        If TabControl.SelectedTab Is Summary Then
            tabPage = 1
        ElseIf TabControl.SelectedTab Is SumAd Then
            tabPage = 2
        ElseIf TabControl.SelectedTab Is Log Then
            tabPage = 3
        End If
    End Sub

    'count how much time that apllication run
    Private Sub TimerMinute_Tick(sender As Object, e As EventArgs) Handles TimerMinute.Tick '1 min
        countTimeRun += 1                                                                   'คำนวณเวลาของระบบ
        timeRun.Font = New Font(timeRun.Font, FontStyle.Regular)
        timeRun.Text = GetTime(countTimeRun) + " Hrs."

        If SliderStat.sety Then
            For i As Integer = 0 To mylist.Length - 1
                mylist(i).CopNode.PutIntoDB(myConnDB)                                       'บันทึกลง DB ทุกนาที
            Next
        End If
    End Sub
    'count For SMS ERROR Log
    Private Sub TimerHour_Tick(sender As Object, e As EventArgs) Handles TimerHour.Tick     'แต่ซอยเป็นทุกครึ่งชม.
        'ตรวจเช็คสภาพภาพด้วยการส่ง SMS
        Dim smsCT() As String
        If SliderSMS.sety or SliderError.Sety Then
            For Each temp As String In Fil_SMS
                smsCT = temp.Split(":"c)
                For i As Integer = 0 To mylist.Length - 1
                    If mylist(i).SourceNode = smsCT(0) Then mylist(i).CountSMS += 1                                                 'ทุกๆ 2 หน่วย นับเป็น 1 ชม.
                    If mylist(i).SourceNode = smsCT(0) AndAlso mylist(i).CountSMS >= CInt(smsCT(2))*2  AndAlso mylist(i).CountSMS mod CDbl(smsCT(3))*2 = 0 Then

                        If SliderSMS.sety then
                            Dim SMSEngine As New SMS_Sender(COMPortText.Text)
                            SMSEngine.Open() 'open the port
                            SMSEngine.SendSMS(smsNum, "No Tracks/Data sent from " + smsCT(1) + " for more than " + (CSng(mylist(i).CountSMS) / 2).ToString + " hours.")         'send the SMS
                            lblSMS2.Text = (CInt(lblSMS2.Text) + smsNum.Length).toString
                        end if

                        timeRun.Text = "SMS SENT"
                        LogText.Text += "No Tracks/Data sent from " + smsCT(1) + " for more than " + (CSng(mylist(i).CountSMS) / 2).ToString + " hours." + vbNewLine
                        LogText.SelectionStart = LogText.TextLength()
                        LogText.ScrollToCaret()

                        If SliderError.sety then insertLog(myConnDB, mylist(i).SourceNode, "No Tracks/Data sent from " + smsCT(1) + " for more than " + (CSng(mylist(i).CountSMS) / 2).ToString + " hours.")

                    End If

                    If mylist(i).SourceNode = smsCT(0) andAlso mylist(i).SourceNode = "4.1.1.1" Then 
                        mylist(i).CountForPos += 1
                        If mylist(i).CountForPos >= CInt(smsCT(2))*2  AndAlso mylist(i).CountForPos mod CDbl(smsCT(3))*2 = 0 Then
                            If SliderSMS.sety then
                                Dim SMSEngine As New SMS_Sender(COMPortText.Text)
                                SMSEngine.Open() 'open the port
                                SMSEngine.SendSMS(smsNum, "GBAD(COP interface) may be set to default setting. Please check that GBAD ID 38 is sending all tracks for 530 NM radius.(" + (CSng(mylist(i).CountForPos) / 2).ToString + " hrs.)")         'send the SMS
                                lblSMS2.Text = (CInt(lblSMS2.Text) + smsNum.Length).toString
                            end if

                            timeRun.Text = "GBAD ERROR"
                            LogText.Text += "GBAD(COP interface) may be set to default setting. Please check that GBAD ID 38 is sending all tracks for 530 NM radius.(" + (CSng(mylist(i).CountForPos) / 2).ToString + " hrs.) " + getDateTimeThai() + vbNewLine
                            LogText.SelectionStart = LogText.TextLength()
                            LogText.ScrollToCaret()

                            If SliderError.sety then insertLog(myConnDB, mylist(i).SourceNode, "GBAD(COP interface) may be set to default setting. Please check that GBAD ID 38 is sending all tracks for 530 NM radius.(" + (CSng(mylist(i).CountForPos) / 2).ToString + " hrs.)")

                        End If
                    end If
                Next

            Next
        End If


    End Sub
    Private Sub TimerFullHour_Tick( sender As Object,  e As EventArgs) Handles TimerFullHour.Tick
        Dim smsCT() As String
        'เคลียร์ค่าวนลูปใหม่ทุกสิ้นวัน
        If DateTime.Now.ToString("HH", CultureInfo.CreateSpecificCulture("en-US")) = "00" Then
          
                If SliderSMS.sety then
                    Dim SMSEngine As New SMS_Sender(COMPortText.Text)
                    SMSEngine.Open() 'open the port
                    
                        Dim tempStr As String = ""
                        Dim temp As Integer
                        For i As Integer = 0 To mylist.Length - 1
                            Dim chk As String = ""
                            For Each tempSMS As String In Fil_SMS
                                smsCT = tempsms.Split(":"c)
                                If mylist(i).SourceNode = smsCT(0)  then
                                    chk = smsCT(1)
                                    Exit For
                                End If
                            Next

                            If Not chk="" Then tempStr += chk else tempStr +=  mylist(i).SourceNode

                            tempStr += ":" + mylist(i).NumTrack.ToString("N0")
                            If mylist(i).NumTrack > 1 Then
                                If RadioTMode.Checked Then tempStr += "tracks" Else tempStr += "stations"
                            Else
                                If RadioTMode.Checked Then tempStr += "track" Else tempStr += "station"
                            End If

                            temp = mylist(i).CopNode.PreOrder
                            tempStr += vbCrLf + temp.ToString("N0")
                            If temp > 1 Then
                                tempStr += "hits"
                            Else
                                tempStr += "hit"
                            End If
                                tempStr += vbCrLf
                        Next
                    
                    SMSEngine.SendSMSLong(smsNum, tempStr )         'send the SMS 68
                    lblSMS2.Text = (CInt(lblSMS2.Text) + smsNum.Length).toString
                end if
                


            Dim array2D(1,Fil_SMS.Length - 1) As String                                  'Count SMS ที่ไม่เคลียร์ค่า
            Dim numAr As Integer = 0
            If SliderSMS.sety then
                For i As Integer = 0 To (mylist.Length - 1)
                    For Each temp As String In Fil_SMS
                        smsCT = temp.Split(":"c)
                        If smsCT(0) = mylist(i).SourceNode Then
                        array2D(0,numAr) = smsCT(0)
                        array2D(1,numAr) = mylist(i).CountSMS.ToString
                        numAr +=1
                        End If
                    Next
                Next
            End If

            DayCount = 0
            mylist = Nothing

            If SliderSMS.sety or SliderError.sety Then                                  'sms keep counting
                ReDim Preserve mylist(Fil_SMS.Length - 1)
                For i As Integer = 0 To (Fil_SMS.Length-1)
                    mylist(i).SourceNode = array2D(0,i)
                    mylist(i).CopNode = New BinTree(array2D(0,i), "02500", 0, 0, 0, 0, 0, 0)
                    mylist(i).NumTrack = 0
                    mylist(i).CountSMS = CInt(array2D(1,i))
                Next
            End If
        End If
    End Sub
    'create new db > new year
    Private Sub TimerDay_Tick(sender As Object, e As EventArgs) Handles TimerDay.Tick
        If DateTime.Now.ToString("dd:MM", CultureInfo.CreateSpecificCulture("en-US")) = "31:12" Then CheckTableExists(myConnDB, 1)
    End Sub

End Class
