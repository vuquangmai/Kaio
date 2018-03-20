Public Class ChannelInfo
    Private _Administrator As Boolean = False
    Private _AndroidApps As Boolean = False
    Private _Ccare As Boolean = False
    Private _S2 As Boolean = False
    Private _Vinabox As Boolean = False
    Private _GamePortal As Boolean = False
    Private _Vishare As Boolean = False
    Private _SimToolKit As Boolean = False
    Private _Billing As Boolean = False
    Private _CustomerInfo As Boolean = False
    Private _Charging As Boolean = False
    Private _MGame As Boolean = False
    Private _KPI As Boolean = False
    Private _ContractInfo As Boolean = False
    Public Sub New(ByVal vGroupId As Integer)
        IsACL(vGroupId)  ' Lấy thông tin quyền hạn vào biến  _dsACL (Access Control List)
    End Sub
    Protected Sub IsACL(ByVal GroupId As Integer)
        Dim sql As String = "SELECT * FROM System_Group_Channel  Where Group_Id=" & GroupId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Administrator Then
                    _Administrator = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.AndroidApps Then
                    _AndroidApps = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Ccare Then
                    _Ccare = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.S2 Then
                    _S2 = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Vinabox Then
                    _Vinabox = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.GamePortal Then
                    _GamePortal = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Vishare Then
                    _Vishare = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.SimToolKit Then
                    _SimToolKit = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Billing Then
                    _Billing = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.CustomerInfo Then
                    _CustomerInfo = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Charging Then
                    _Charging = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.MGame Then
                    _MGame = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.KPI Then
                    _KPI = True
                End If
                If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.ContractInfo Then
                    _ContractInfo = True
                End If
            Next
        End If
    End Sub
    Public Property Administrator() As Boolean
        Get
            Return _Administrator
        End Get
        Set(ByVal Value As Boolean)
            _Administrator = Value
        End Set
    End Property
    Public Property AndroidApps() As Boolean
        Get
            Return _AndroidApps
        End Get
        Set(ByVal Value As Boolean)
            _AndroidApps = Value
        End Set
    End Property
    Public Property Ccare() As Boolean
        Get
            Return _Ccare
        End Get
        Set(ByVal Value As Boolean)
            _Ccare = Value
        End Set
    End Property
    Public Property S2() As Boolean
        Get
            Return _S2
        End Get
        Set(ByVal Value As Boolean)
            _S2 = Value
        End Set
    End Property
    Public Property Vinabox() As Boolean
        Get
            Return _Vinabox
        End Get
        Set(ByVal Value As Boolean)
            _Vinabox = Value
        End Set
    End Property
    Public Property GamePortal() As Boolean
        Get
            Return _GamePortal
        End Get
        Set(ByVal Value As Boolean)
            _GamePortal = Value
        End Set
    End Property
    Public Property Vishare() As Boolean
        Get
            Return _Vishare
        End Get
        Set(ByVal Value As Boolean)
            _Vishare = Value
        End Set
    End Property
    Public Property SimToolKit() As Boolean
        Get
            Return _SimToolKit
        End Get
        Set(ByVal Value As Boolean)
            _SimToolKit = Value
        End Set
    End Property
    Public Property Billing() As Boolean
        Get
            Return _Billing
        End Get
        Set(ByVal Value As Boolean)
            _Billing = Value
        End Set
    End Property
    Public Property CustomerInfo() As Boolean
        Get
            Return _CustomerInfo
        End Get
        Set(ByVal Value As Boolean)
            _CustomerInfo = Value
        End Set
    End Property
    Public Property Charging() As Boolean
        Get
            Return _Charging
        End Get
        Set(ByVal Value As Boolean)
            _Charging = Value
        End Set
    End Property
    Public Property MGame() As Boolean
        Get
            Return _MGame
        End Get
        Set(ByVal Value As Boolean)
            _MGame = Value
        End Set
    End Property
    Public Property KPI() As Boolean
        Get
            Return _KPI
        End Get
        Set(ByVal Value As Boolean)
            _KPI = Value
        End Set
    End Property
    Public Property ContractInfo() As Boolean
        Get
            Return _ContractInfo
        End Get
        Set(ByVal Value As Boolean)
            _ContractInfo = Value
        End Set
    End Property
End Class
