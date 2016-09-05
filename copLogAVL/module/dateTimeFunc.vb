Imports System.Globalization
Module dateTimeFunc
    
    'date time format thai
    Public Function getDateTimeThai() As String
        Dim DateThai =  DateTime.Now.ToString("วันdddd dd MMMM yyyy", CultureInfo.CreateSpecificCulture("th-TH"))
        return String.Format(" {1}  {0} " , DateTime.Now.ToString("HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")), DateThai)
    End Function

    'time format count hour 60 form
    Public Function GetTime(Time As Integer) As String
        Time = Time
        Dim Hrs As Integer  'number of hours
        Dim Min As Integer  'number of Minutes
        'Minutes
        Min = Time Mod 60
        'Hours
        Hrs = CInt((Time - Min) / 60)
        Return Format(Hrs, "#,#00") & ":" & Format(Min, "00")
    End Function

End Module
