    Public Structure MsgData
        Public CopNode As BinTree       'เก็บข้อมูลที่รับเข้า
        Public SourceNode As String     'INDEX
        Public NumTrack As Integer      'เก็บจำนวน Track ของแต่ละ source
        Public CountSMS As Integer      'นับเลขเพื่อส่ง SMS
        Public CountForPos As Integer   'เช็ค GBAD สำหรับ 4.1.1.1
    End Structure 