Imports System.Data.SqlClient

Public Class BinTree
    Private _root As Node = Nothing '-- tree has to have a root.

    Public Sub New(ByVal source_value As String, ByVal track_value As String, Optional ByVal p311_value As Integer = 0, Optional ByVal p312_value As Integer = 0, Optional ByVal p315_value As Integer = 0, Optional ByVal p316_value As Integer = 0, Optional ByVal p317_value As Integer = 0, Optional ByVal p900_value As Integer = 0)
        _root = New Node(source_value, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
    End Sub

    '-- Inserting takes two nodes.  The current node we want to do the insert on, and a next node for the loop.
    Public Sub InsertNode(ByVal source_value As String, ByVal track_value As String, Optional ByVal p311_value As Integer = 0, Optional ByVal p312_value As Integer = 0, Optional ByVal p315_value As Integer = 0, Optional ByVal p316_value As Integer = 0, Optional ByVal p317_value As Integer = 0, Optional ByVal p900_value As Integer = 0)
        Dim currentNode As Node = _root
        Dim nextNode As Node = _root

        '-- loop through all the nodes left to right based on our rule of greater than/less than.
        While currentNode.Trackid <> track_value AndAlso nextNode IsNot Nothing
            currentNode = nextNode
            If nextNode.Trackid < track_value Then
                nextNode = nextNode.RightNode
            Else
                nextNode = nextNode.LeftNode
            End If
        End While

        If currentNode.Trackid = track_value Then
            Debug.WriteLine("Can't insert duplicates!")
        ElseIf currentNode.Trackid < track_value Then
            currentNode.RightNode = New Node(source_value, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
        Else
            currentNode.LeftNode = New Node(source_value, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
        End If
    End Sub

    '-- Printing is loads of recursive fun.  I have two basic types here: Inorder and PreOrder.
    'Public Sub Print(ByVal doInOrder As Boolean)
    '    If doInOrder Then
    '        InOrder(_root)
    '    Else
    '        PreOrder(_root)
    '    End If
    'End Sub

    '-- InOrder follows a depth first run.  check left, print, check right.
    Public Function InOrder(ByVal myNode As Node) As Integer
        If myNode.LeftNode IsNot Nothing Then InOrder(myNode.LeftNode)
        'เรียงลำดับจากน้อยไปมาก   คำสั่งออกตรงนี้
        If myNode.RightNode IsNot Nothing Then InOrder(myNode.RightNode)
        Return 0
    End Function


    Public Function PreOrder() As Integer
        Return PreOrder(_root)
    End Function
    Public Function PreOrder(ByVal myNode As Node) As Integer                       '--ไล่นับ Hit ของ action ของ source
        Dim countAction As Integer = 0

        'คำสั่งที่ออกจากตรงนี้จะเรียงเป็นภาพต้นไม้
        countAction = myNode.P3_1_1 + myNode.P3_1_2 + myNode.P3_1_5 + myNode.P3_1_6 + myNode.P3_1_7 + myNode.P9_0_0 + myNode.PClear3_1_1 + myNode.PClear3_1_2 + myNode.PClear3_1_5 + myNode.PClear3_1_6 + myNode.PClear3_1_7 + myNode.PClear9_0_0
        If myNode.LeftNode IsNot Nothing Then countAction += PreOrder(myNode.LeftNode)
        If myNode.RightNode IsNot Nothing Then countAction += PreOrder(myNode.RightNode)

        Return countAction
    End Function

    '-- find the path to that value.  
    Public Function FindNodeToAoU(ByVal source_value As String, ByVal track_value As String, Optional ByVal p311_value As Integer = 0, Optional ByVal p312_value As Integer = 0, Optional ByVal p315_value As Integer = 0, Optional ByVal p316_value As Integer = 0, Optional ByVal p317_value As Integer = 0, Optional ByVal p900_value As Integer = 0) As Integer
        '-- Dive into the recursion.
        If FindNode(_root, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value) Is Nothing Then
            InsertNode(source_value, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
            Return 1
        End If
        Return 0
    End Function

    '-- ค้นหา node เพื่ออัพเดทค่า
    Private Function FindNode(ByVal myNode As Node, ByVal track_value As String, Optional ByVal p311_value As Integer = 0, Optional ByVal p312_value As Integer = 0, Optional ByVal p315_value As Integer = 0, Optional ByVal p316_value As Integer = 0, Optional ByVal p317_value As Integer = 0, Optional ByVal p900_value As Integer = 0) As Node
        '-- Find and update
        If myNode.LeftNode IsNot Nothing AndAlso myNode.Trackid > track_value Then
            Return FindNode(myNode.LeftNode, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
        Else If myNode.RightNode IsNot Nothing AndAlso myNode.Trackid < track_value Then
            Return FindNode(myNode.RightNode, track_value, p311_value, p312_value,p315_value, p316_value, p317_value, p900_value)
        End If

        If myNode.Trackid = track_value Then
            myNode.P3_1_1 += p311_value
            myNode.P3_1_2 += p312_value
            myNode.P3_1_5 += p315_value
            myNode.P3_1_6 += p316_value
            myNode.P3_1_7 += p317_value
            myNode.P9_0_0 += p900_value
            Return myNode
        End If

        Return Nothing
    End Function

    Public Sub PutIntoDB(ByVal connString As SqlConnection)                                                  '--เรียก recursion
        PutIntoDB(_root, connString)
    End Sub
    Public Sub PutIntoDB(ByVal myNode As Node, ByVal connString As SqlConnection)                              '--จ่ายข้อมูลมาเป็นก้อนเพื่อเอาไปใช้ใน SQL
        If myNode.P3_1_1 <> 0 Or myNode.P3_1_2 <> 0 Or myNode.P3_1_5 <> 0 Or myNode.P3_1_6 <> 0 Or myNode.P3_1_7 <> 0 Or myNode.P9_0_0 <> 0 Then 
            checkToInsert(connString,myNode.Sourceid, myNode.Trackid, myNode.P3_1_1, myNode.P3_1_2, myNode.P3_1_5, myNode.P3_1_6, myNode.P3_1_7, myNode.P9_0_0)
            myNode.PClear3_1_1 += myNode.P3_1_1
            myNode.PClear3_1_2 += myNode.P3_1_2
            myNode.PClear3_1_5 += myNode.P3_1_5
            myNode.PClear3_1_6 += myNode.P3_1_6
            myNode.PClear3_1_7 += myNode.P3_1_7
            myNode.PClear9_0_0 += myNode.P9_0_0
            myNode.P3_1_1 = 0
            myNode.P3_1_2 = 0
            myNode.P3_1_5 = 0
            myNode.P3_1_6 = 0
            myNode.P3_1_7 = 0
            myNode.P9_0_0 = 0
        End if
        If myNode.LeftNode IsNot Nothing Then PutIntoDB(myNode.LeftNode,connString)
        If myNode.RightNode IsNot Nothing Then PutIntoDB(myNode.RightNode,connString)
    End Sub

End Class
