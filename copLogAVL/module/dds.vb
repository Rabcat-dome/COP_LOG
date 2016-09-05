Module dds
    Public Function CreateReader(ByRef DDSRead As HSDDB.COPDataDistributionCls,ByRef DataReader As HSDDB.COPDataReaderMessageTrackMod1Cls) As Boolean
        Debug.Print("CreateReader")
        Dim ErrDescription As String = ""

        'step 1 : create domain participant
        Dim DomainParticipantQoS As New HSDDB.DomainParticipantQoSCLs
        With DomainParticipantQoS
            .DomainID = 0
        End With
        If Not DDSRead.JoinDomain(DomainParticipantQoS, ErrDescription) Then Return False

        'step 2 : create subscriber
        Dim SubscriberQoS As New HSDDB.SubscriberQoSCls
        If Not DDSRead.CreateSubscriber(SubscriberQoS, ErrDescription) Then Return False

        'step 3 : create data reader type COP_MSG_TRACK_MOD1
        Dim DataReaderQoS As New HSDDB.DataReaderQoSCls
        With DataReaderQoS
            .DataType = HSDDB.COPDataCls.enuCOPDataType.cdt_COP_MSG_TRACK_MOD1
            .Topic = "COP_Track"
        End With
        If Not DDSRead.CreateDataReader(DataReaderQoS, ErrDescription) Then
            Debug.Print("not create COP_TRACK_MOD1 return false")
            Return False
        End If


        'step 3.1 :  create data reader type ActionValue
        Dim iDataReaderQoS As New HSDDB.DataReaderQoSCls
        With iDataReaderQoS
            .DataType = HSDDB.COPDataCls.enuCOPDataType.cdt_ACTION_VALUE
            .Topic = "ACTION_VALUE"  'NOT SURE
        End With
        If Not DDSRead.CreateDataReader(iDataReaderQoS, ErrDescription) Then
            Debug.Print("not create ActionValue return false")
            Return False
        End If


        'step 4 : get global variable "DataReader"
        DataReader = CType(DDSRead.GetDataReader(DataReaderQoS.Topic), HSDDB.COPDataReaderMessageTrackMod1Cls)
        
        Return True
    End Function

    Public Function ReadaDataTmode(ByRef aData() As HSDDB.COPStdMsgCls,ByRef mylist() As MsgData,ByVal fil_status As Boolean,ByRef Optional filter() As String = Nothing) As Boolean
        Dim trackNum As String=""
        Dim sourceNum As String =""
        For Each COPData As HSDDB.COPStdMsgCls In aData
            Select Case COPData.MessageNumber
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_3_1_1
                    Dim P311 As HSDDB.P_3_1_1 = CType(COPData, HSDDB.P_3_1_1)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P311.OwnerCOPID1, P311.OwnerCOPID2, P311.OwnerCOPID3, P311.OwnerCOPID4)
                    Debug.Print(P311.Longitude.ToString+" <> "+P311.Latitude.ToString)
                    If fil_status Then                                      'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then
                                trackNum = P311.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)                'เวลาขยาย  array เขาขยายด้วยค่า index
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,1,0,0,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15.1 or P311.Latitude < 12.75 or P311.Longitude < 99.55 Or P311.Longitude > 101.75 Then mylist(0).CountForPos = 0
                                        end if
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1     'เช็ค index ว่าตรงกับช่องไหน  แล้วไปอัพเดทค่า  จากนั้นจึงออกลูป
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,1,0,0,0,0)
                                        mylist(i).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15.1 or P311.Latitude < 12.75 or P311.Longitude < 99.55 Or P311.Longitude > 101.75 Then mylist(i).CountForPos = 0
                                        end if
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then            'เมื่อมาลูปสุดท้ายแล้วไม่เจอค่าอีก ให้ทำการเพิ่มโหนดใหม่ลงไป
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,1,0,0,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15.1 or P311.Latitude < 12.75 or P311.Longitude < 99.55 Or P311.Longitude > 101.75 Then mylist(i+1).CountForPos = 0
                                        end if
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P311.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)                'เวลาขยาย  array เขาขยายด้วยค่า index
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,1,0,0,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15 or P311.Latitude < 12.90 or P311.Longitude < 99.55 Or P311.Longitude > 101.65 Then mylist(0).CountForPos = 0
                                        end if
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1     'เช็ค index ว่าตรงกับช่องไหน  แล้วไปอัพเดทค่า  จากนั้นจึงออกลูป
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,1,0,0,0,0)
                                        mylist(i).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15 or P311.Latitude < 12.90 or P311.Longitude < 99.55 Or P311.Longitude > 101.65 Then mylist(i).CountForPos = 0
                                        end if
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then            'เมื่อมาลูปสุดท้ายแล้วไม่เจอค่าอีก ให้ทำการเพิ่มโหนดใหม่ลงไป
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,1,0,0,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        If sourceNum = "4.1.1.1" Then
                                            If P311.Latitude > 15 or P311.Latitude < 12.90 or P311.Longitude < 99.55 Or P311.Longitude > 101.65 Then mylist(i+1).CountForPos = 0
                                        end if
                                        Exit Select
                                    End If
                                Next
                        End If
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_3_1_2
                    Dim P312 As HSDDB.P_3_1_2 = CType(COPData, HSDDB.P_3_1_2)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P312.OwnerCOPID1, P312.OwnerCOPID2, P312.OwnerCOPID3, P312.OwnerCOPID4)

                    If fil_status Then                          'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then
                                trackNum = P312.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,1,0,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,1,0,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,1,0,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P312.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,1,0,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,1,0,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,1,0,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                    End If
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_3_1_5
                    Dim P315 As HSDDB.P_3_1_5 = CType(COPData, HSDDB.P_3_1_5)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P315.OwnerCOPID1, P315.OwnerCOPID2, P315.OwnerCOPID3, P315.OwnerCOPID4)
                    
                    If fil_status Then                          'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then
                                trackNum = P315.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,1,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,1,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,1,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P315.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,1,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,1,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,1,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                    End If
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_3_1_6
                    Dim P316 As HSDDB.P_3_1_6 = CType(COPData, HSDDB.P_3_1_6)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P316.OwnerCOPID1, P316.OwnerCOPID2, P316.OwnerCOPID3, P316.OwnerCOPID4)
                    
                    If fil_status Then                          'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then
                                trackNum = P316.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P316.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,1,0,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                    End If
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_3_1_7
                    Dim P317 As HSDDB.P_3_1_7 = CType(COPData, HSDDB.P_3_1_7)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P317.OwnerCOPID1, P317.OwnerCOPID2, P317.OwnerCOPID3, P317.OwnerCOPID4)
                    
                    If fil_status Then                          'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then 
                                trackNum = P317.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P317.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,1,0)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                    End If   
            End Select
        Next
        Return true
    End Function

    Public Function ReadaDataDmode(ByRef aData() As HSDDB.COPStdMsgCls,ByRef mylist() As MsgData,ByVal fil_status As Boolean,ByRef Optional Filter() As String=Nothing) As Boolean
        Dim trackNum As String = ""
        Dim sourceNum As String =""
        For Each COPData As HSDDB.COPStdMsgCls In aData
            Select Case COPData.MessageNumber
                Case HSDDB.COPStdMsgCls.enuCOPStdMsgNumber.P_9_0_0
                    Dim P900 As HSDDB.P_9_0_0 = CType(COPData, HSDDB.P_9_0_0)
                    sourceNum = String.Format("{0}.{1}.{2}.{3}", P900.OwnerCOPID1, P900.OwnerCOPID2, P900.OwnerCOPID3, P900.OwnerCOPID4)
                    
                    If fil_status Then                          'Source Filter
                        for each fil_chk as String in filter
                            If fil_chk = sourceNum Then
                                trackNum = P900.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    Else
                        trackNum = P900.TrackNumber
                                If mylist Is Nothing Then
                                    ReDim Preserve mylist(0)
                                        mylist(0).SourceNode = sourceNum
                                        mylist(0).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(0).NumTrack = 1
                                        mylist(0).CountSMS = 0
                                    Exit Select
                                End If
                                For i As Integer = 0 To mylist.Length-1 
                                    If  mylist(i).SourceNode = sourceNum Then
                                        mylist(i).NumTrack += mylist(i).CopNode.FindNodeToAoU(SourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(i).CountSMS = 0
                                        Exit Select
                                    End IF
                                    If i =  mylist.Length-1 Then   
                                        ReDim Preserve mylist(mylist.Length)
                                        mylist(i+1).SourceNode = sourceNum
                                        mylist(i+1).CopNode = new BinTree(sourceNum,trackNum,0,0,0,0,0,1)
                                        mylist(i+1).NumTrack = 1
                                        mylist(i+1).CountSMS = 0
                                        Exit Select
                                    End If
                                Next
                    End If
            End Select
        Next
        Return true
    End Function

End Module
