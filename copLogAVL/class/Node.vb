Public Class Node

    Private _leftNode As Node = Nothing
    Private _rightNode As Node = Nothing
    Private _sourceid As String = ""
    Private _trackid As String =""
    Private _p_3_1_1 As Integer = 0
    Private _pClear_3_1_1 As Integer = 0
    Private _p_3_1_2 As Integer = 0
    Private _pClear_3_1_2 As Integer = 0
    Private _p_3_1_5 As Integer = 0
    Private _pClear_3_1_5 As Integer = 0
    Private _p_3_1_6 As Integer = 0
    Private _pClear_3_1_6 As Integer = 0
    Private _p_3_1_7 As Integer = 0
    Private _pClear_3_1_7 As Integer = 0
    Private _p_9_0_0 As Integer = 0
    Private _pClear_9_0_0 As Integer = 0

    Public Property LeftNode As Node
        Get
            Return _leftNode
        End Get
        Set(value As Node)
            _leftNode = value
        End Set
    End Property
    Public Property RightNode As Node
        Get
            Return _rightNode
        End Get
        Set(value As Node)
            _rightNode = value
        End Set
    End Property
    Public Property Sourceid As String
        Get
            Return _sourceid
        End Get
        Set(value As String)
            _sourceid = value
        End Set
    End Property
    Public Property Trackid As String
        Get
            Return _trackid
        End Get
        Set(value As String)
            _trackid = value
        End Set
    End Property
    Public Property P3_1_1 As Integer
        Get
            Return _p_3_1_1
        End Get
        Set(value As Integer)
            _p_3_1_1 = value
        End Set
    End Property
    Public Property PClear3_1_1 As Integer
        Get
            Return _pClear_3_1_1
        End Get
        Set(value As Integer)
            _pClear_3_1_1 = value
        End Set
    End Property
    Public Property P3_1_2 As Integer
        Get
            Return _p_3_1_2
        End Get
        Set(value As Integer)
            _p_3_1_2 = value
        End Set
    End Property
    Public Property PClear3_1_2 As Integer
        Get
            Return _pClear_3_1_2
        End Get
        Set(value As Integer)
            _pClear_3_1_2 = value
        End Set
    End Property
    Public Property P3_1_5 As Integer
        Get
            Return _p_3_1_5
        End Get
        Set(value As Integer)
            _p_3_1_5 = value
        End Set
    End Property
    Public Property PClear3_1_5 As Integer
        Get
            Return _pClear_3_1_5
        End Get
        Set(value As Integer)
            _pClear_3_1_5 = value
        End Set
    End Property
    Public Property P3_1_6 As Integer
        Get
            Return _p_3_1_6
        End Get
        Set(value As Integer)
            _p_3_1_6 = value
        End Set
    End Property
    Public Property PClear3_1_6 As Integer
        Get
            Return _pClear_3_1_6
        End Get
        Set(value As Integer)
            _pClear_3_1_6 = value
        End Set
    End Property
    Public Property P3_1_7 As Integer
        Get
            Return _p_3_1_7
        End Get
        Set(value As Integer)
            _p_3_1_7 = value
        End Set
    End Property
    Public Property PClear3_1_7 As Integer
        Get
            Return _pClear_3_1_7
        End Get
        Set(value As Integer)
            _pClear_3_1_7 = value
        End Set
    End Property
    Public Property P9_0_0 As Integer
        Get
            Return _p_9_0_0
        End Get
        Set(value As Integer)
            _p_9_0_0 = value
        End Set
    End Property
    Public Property PClear9_0_0 As Integer
        Get
            Return _pClear_9_0_0
        End Get
        Set(value As Integer)
            _pClear_9_0_0 = value
        End Set
    End Property
    Public Sub New(ByVal source_value As String,ByVal track_value As String,Optional ByVal p311_value As Integer=0,Optional ByVal p312_value As Integer=0,Optional ByVal p315_value As Integer=0,Optional ByVal p316_value As Integer=0,Optional ByVal p317_value As Integer=0,Optional ByVal p900_value As Integer=0)
'-- new nodes don't have children yet, just a value
        _leftNode = Nothing
        _rightNode = Nothing
        _sourceid = source_value
        _trackid = track_value
        _p_3_1_1 = p311_value
        _pClear_3_1_1 = 0
        _p_3_1_2 = p312_value
        _pClear_3_1_2 = 0
        _p_3_1_5 = p315_value
        _pClear_3_1_5 = 0
        _p_3_1_6 = p316_value
        _pClear_3_1_6 = 0
        _p_3_1_7 = p317_value
        _pClear_3_1_7 = 0
        _p_9_0_0 = p900_value
        _pClear_9_0_0 = 0
    End Sub
End Class
