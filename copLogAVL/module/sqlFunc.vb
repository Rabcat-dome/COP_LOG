Imports System.Globalization
Imports System.Data.SqlClient

Module sqlFunc
    Public Function CheckTableExists(ByVal connString As SqlConnection,ByVal Optional setType As Integer = 0) As Boolean

        Debug.Print("CheckTableExist")
        Dim cmdText As String =""
        Dim cmdTextLog As String =""
        Dim intNumRows As Int32
        Dim intNumRowsLog As Int32

        If setType = 0 then
            cmdText = ("select COUNT(*) from sys.objects where object_id = OBJECT_ID(N'[dbo].[cop_Stat" + DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "]') " + "AND type in (N'U')")
            cmdTextLog = ("select COUNT(*) from sys.objects where object_id = OBJECT_ID(N'[dbo].[copstatLog" + DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")) + "]') " + "AND type in (N'U')")
        Else If setType = 1 then
            cmdText = ("select COUNT(*) from sys.objects where object_id = OBJECT_ID(N'[dbo].[cop_Stat" + (CInt(DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")))+1).ToString + "]') " + "AND type in (N'U')")
            cmdTextLog = ("select COUNT(*) from sys.objects where object_id = OBJECT_ID(N'[dbo].[copstatLog" + (CInt(DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")))+1).ToString + "]') " + "AND type in (N'U')")
        End If

        If connString.State = ConnectionState.Closed Then connString.Open()
            Try
                Dim sqlCmd As SqlCommand = New SqlCommand(cmdText, connString)
                    intNumRows = Convert.ToInt32(sqlCmd.ExecuteScalar())
                Dim sqlCmdLog As SqlCommand = New SqlCommand(cmdTextLog, connString)
                    intNumRowsLog  = Convert.ToInt32(sqlCmdLog.ExecuteScalar())
                    If (intNumRowsLog > 0) and (intNumRows > 0) Then return True
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                Return False
            Finally
                If (connString.State = ConnectionState.Open) Then connString.Close()
            End Try

            Debug.Print("create table")
            Dim my_query As String=""
            Dim my_queryLog As String=""
            If setType = 0 then
                my_query = "CREATE TABLE cop_Stat"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+" (datet date NOT NULL , trackid varchar(11) NOT NULL,sourceid varchar(11) NOT NULL,p3_1_1 integer,p3_1_2 integer,p3_1_5 integer,p3_1_6 integer,p3_1_7 integer,p9_0_0 integer,primary key (datet,trackid,sourceid))"
                my_queryLog = "CREATE TABLE copstatLog"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+" (datet datetime NOT NULL ,sourceid varchar(11) NOT NULL,log text,primary key (datet,sourceid))"
            Else If setType = 1 then
                my_query =  "CREATE TABLE cop_Stat"+(CInt(DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")))+1).ToString+" (datet date NOT NULL , trackid varchar(11) NOT NULL,sourceid varchar(11) NOT NULL,p3_1_1 integer,p3_1_2 integer,p3_1_5 integer,p3_1_6 integer,p3_1_7 integer,p9_0_0 integer,primary key (datet,trackid,sourceid))"
                my_queryLog =  "CREATE TABLE copstatLog"+(CInt(DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")))+1).ToString+" (datet datetime NOT NULL ,sourceid varchar(11) NOT NULL,log text,primary key (datet,sourceid))"
            End If

            Dim myCommand As SqlCommand = New SqlCommand(my_query, connString)
            Dim myCommandLog As SqlCommand = New SqlCommand(my_queryLog, connString)
            Try
                If connString.State = ConnectionState.Closed Then connString.Open()
                If Not intNumRows > 0 Then myCommand.ExecuteNonQuery()
                If Not intNumRowsLog > 0 Then myCommandLog.ExecuteNonQuery()
                MessageBox.Show("table is created successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                Return False
            Finally
                If (connString.State = ConnectionState.Open) Then connString.Close()
            End Try

        Return true
    End Function

    Public Function CheckDatabaseExists(ByVal connString As SqlConnection) As Boolean

        Debug.Print("CheckDatabaseExist")
        Dim cmdText As String = ("select COUNT(*) from master.dbo.sysdatabases where name='cop_counter'")
        If connString.State = ConnectionState.Closed Then connString.Open()
        Try
            Using sqlCmd As SqlCommand = New SqlCommand(cmdText, connString)
                Dim intNumRows As Int32 = Convert.ToInt32(sqlCmd.ExecuteScalar())
                If (intNumRows > 0) Then Return False
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return False
        Finally
            If (connString.State = ConnectionState.Open) Then connString.Close()
        End Try

        Debug.Print("create db")
        Dim str As String = "CREATE DATABASE cop_counter"
        Dim myCommand As SqlCommand = New SqlCommand(str, connString)
        Try
            If connString.State = ConnectionState.Closed Then connString.Open()
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Database is created successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return False
        Finally
            If (connString.State = ConnectionState.Open) Then connString.Close()
        End Try
        
        Return True
    End Function

    Public Sub checkToInsert(ByVal connString As SqlConnection,ByVal source As String,ByVal track As String,ByVal p311 As Integer,ByVal p312 As Integer,ByVal p315 As Integer,ByVal p316 As Integer,ByVal p317 As Integer,ByVal p900 As Integer)

        Dim my_query As String = "SELECT p3_1_1,p3_1_2,p3_1_5,p3_1_6,p3_1_7,p9_0_0 FROM cop_Stat"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+" WHERE datet='" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + "' and trackid='" + track.ToString + "' and sourceid ='" + source + "'"
        Dim myCommand As SqlCommand = New SqlCommand(my_query, connString)

        Try
            If connString.State = ConnectionState.Closed Then connString.Open()
            Dim objDrFy As SqlDataReader = myCommand.ExecuteReader()
                If objDrFy.HasRows Then
                    While objDrFy.Read()
                        my_query = "UPDATE cop_Stat"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+" SET p3_1_1='" + (CType(objDrFy("p3_1_1"),Integer)+p311).ToString + "',p3_1_2='" + (CType(objDrFy("p3_1_2"),Integer)+p312).ToString + "',p3_1_5='" + (CType(objDrFy("p3_1_5"),Integer)+p315).ToString + "',p3_1_6='" + (CType(objDrFy("p3_1_6"),Integer)+p316).ToString + "',p3_1_7='" + (CType(objDrFy("p3_1_7"),Integer)+p317).ToString + "',p9_0_0='" + (CType(objDrFy("p9_0_0"),Integer)+p900).ToString + "' WHERE datet='" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + "' and trackid='" + track.ToString + "' and sourceid ='" + source.ToString+"'"
                    End While
                Else 
                    my_query = "INSERT INTO cop_Stat"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+"(datet,trackid,sourceid,p3_1_1,p3_1_2,p3_1_5,p3_1_6,p3_1_7,p9_0_0) Values('" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en-US")) + "','" + track.ToString + "','" + source.ToString + "','" + p311.ToString+ "','" + p312.ToString+ "','" + p315.ToString+ "','" + p316.ToString+ "','" + p317.ToString+ "','" + p900.ToString+ "')"
                End If
                    Dim myCommand2 As New SqlCommand(my_query, connString)
                    myCommand2.ExecuteNonQuery()
        Catch ex As Exception
                MessageBox.Show(ex.ToString())
        Finally
                If (connString.State = ConnectionState.Open) Then connString.Close()
        End Try

    End Sub

    Public Sub insertLog(ByVal connString As SqlConnection,ByVal source As String,ByVal Log_Text As String)
        Try
            If connString.State = ConnectionState.Closed Then connString.Open()
            Dim my_query As String = "INSERT INTO copstatLog"+DateTime.Now.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US"))+"(datet,sourceid,log) Values('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + "','" + source.ToString + "','" + Log_Text+ "')"
            Dim myCommand As New SqlCommand(my_query, connString)
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (connString.State = ConnectionState.Open) Then connString.Close()
        End Try
    End Sub
End Module
