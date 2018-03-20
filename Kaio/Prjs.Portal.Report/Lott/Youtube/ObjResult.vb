
Public Class ObjResultInfo
    Private _Company_Id As String = ""
    Private _Prize_0_1 As String = ""
    Private _Prize_1_1 As String = ""
    Private _Prize_2_1 As String = ""
    Private _Prize_2_2 As String = ""
    Private _Prize_3_1 As String = ""
    Private _Prize_3_2 As String = ""
    Private _Prize_3_3 As String = ""
    Private _Prize_3_4 As String = ""
    Private _Prize_3_5 As String = ""
    Private _Prize_3_6 As String = ""
    Private _Prize_4_1 As String = ""
    Private _Prize_4_2 As String = ""
    Private _Prize_4_3 As String = ""
    Private _Prize_4_4 As String = ""
    Private _Prize_4_5 As String = ""
    Private _Prize_4_6 As String = ""
    Private _Prize_4_7 As String = ""
    Private _Prize_5_1 As String = ""
    Private _Prize_5_2 As String = ""
    Private _Prize_5_3 As String = ""
    Private _Prize_5_4 As String = ""
    Private _Prize_5_5 As String = ""
    Private _Prize_5_6 As String = ""
    Private _Prize_6_1 As String = ""
    Private _Prize_6_2 As String = ""
    Private _Prize_6_3 As String = ""
    Private _Prize_7_1 As String = ""
    Private _Prize_7_2 As String = ""
    Private _Prize_7_3 As String = ""
    Private _Prize_7_4 As String = ""
    Private _Prize_8_1 As String = ""
    Private _Symbol_1 As String = ""
    Private _Symbol_2 As String = ""
    Private _Symbol_3 As String = ""
    Private _Symbol As String = ""
    Private _Lot_Time As String = ""
    Private _Exist As String = ""
    'Public Sub New(ByVal CompanyId As Integer)
    '    Dim sql As String = "SELECT TOP 1 Company_Id,Lot_Time,Prize_0_1,Prize_1_1,Prize_2_1,Prize_2_2,Prize_3_1,Prize_3_2,Prize_3_3,Prize_3_4,Prize_3_5,Prize_3_6,Prize_4_1,Prize_4_2,Prize_4_3,Prize_4_4,Prize_4_5,Prize_4_6,Prize_4_7,Prize_5_1,Prize_5_2,Prize_5_3,Prize_5_4,Prize_5_5,Prize_5_6,Prize_6_1,Prize_6_2,Prize_6_3,Prize_7_1,Prize_7_2,Prize_7_3,Prize_7_4,Prize_8_1,Symbol_1,Symbol_2,Symbol_3   FROM  Lottery_Result_Live_YouTube WHERE Company_Id=" & CompanyId & " ORDER BY Id desc"
    '    LogService.WriteLog(Constants.LogLevel._Debug, DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "#" & sql)
    '    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
    '    If dt.Rows.Count > 0 Then
    '        _Company_Id = dt.Rows(0).Item("Company_Id")
    '        _Prize_0_1 = dt.Rows(0).Item("Prize_0_1")
    '        _Prize_1_1 = dt.Rows(0).Item("Prize_1_1")
    '        _Prize_2_1 = dt.Rows(0).Item("Prize_2_1")
    '        _Prize_2_2 = dt.Rows(0).Item("Prize_2_2")
    '        _Prize_3_1 = dt.Rows(0).Item("Prize_3_1")
    '        _Prize_3_2 = dt.Rows(0).Item("Prize_3_2")
    '        _Prize_3_3 = dt.Rows(0).Item("Prize_3_3")
    '        _Prize_3_4 = dt.Rows(0).Item("Prize_3_4")
    '        _Prize_3_5 = dt.Rows(0).Item("Prize_3_5")
    '        _Prize_3_6 = dt.Rows(0).Item("Prize_3_6")
    '        _Prize_4_1 = dt.Rows(0).Item("Prize_4_1")
    '        _Prize_4_2 = dt.Rows(0).Item("Prize_4_2")
    '        _Prize_4_3 = dt.Rows(0).Item("Prize_4_3")
    '        _Prize_4_4 = dt.Rows(0).Item("Prize_4_4")
    '        _Prize_4_5 = dt.Rows(0).Item("Prize_4_5")
    '        _Prize_4_6 = dt.Rows(0).Item("Prize_4_6")
    '        _Prize_4_7 = dt.Rows(0).Item("Prize_4_7")
    '        _Prize_5_1 = dt.Rows(0).Item("Prize_5_1")
    '        _Prize_5_2 = dt.Rows(0).Item("Prize_5_2")
    '        _Prize_5_3 = dt.Rows(0).Item("Prize_5_3")
    '        _Prize_5_4 = dt.Rows(0).Item("Prize_5_4")
    '        _Prize_5_5 = dt.Rows(0).Item("Prize_5_5")
    '        _Prize_5_6 = dt.Rows(0).Item("Prize_5_6")
    '        _Prize_6_1 = dt.Rows(0).Item("Prize_6_1")
    '        _Prize_6_2 = dt.Rows(0).Item("Prize_6_2")
    '        _Prize_6_3 = dt.Rows(0).Item("Prize_6_3")
    '        _Prize_7_1 = dt.Rows(0).Item("Prize_7_1")
    '        _Prize_7_2 = dt.Rows(0).Item("Prize_7_2")
    '        _Prize_7_3 = dt.Rows(0).Item("Prize_7_3")
    '        _Prize_7_4 = dt.Rows(0).Item("Prize_7_4")
    '        _Prize_8_1 = dt.Rows(0).Item("Prize_8_1")
    '        _Symbol_1 = dt.Rows(0).Item("Symbol_1")
    '        _Symbol_2 = dt.Rows(0).Item("Symbol_2")
    '        _Symbol_3 = dt.Rows(0).Item("Symbol_3")
    '        _Lot_Time = dt.Rows(0).Item("Lot_Time")
    '        If _Symbol_1.Trim <> "" And _Symbol_2.Trim <> "" And _Symbol_3.Trim <> "" Then
    '            _Symbol = Symbol_1 & "-" & Symbol_2 & "-" & Symbol_3
    '        End If

    '    End If
    'End Sub
    Public Sub New(ByVal CompanyId As Integer)
        Dim sql As String = "SELECT TOP 1 Company_Id,Lot_Time,Prize_0_1,Prize_1_1,Prize_2_1,Prize_2_2,Prize_3_1,Prize_3_2,Prize_3_3,Prize_3_4,Prize_3_5,Prize_3_6,Prize_4_1,Prize_4_2,Prize_4_3,Prize_4_4,Prize_4_5,Prize_4_6,Prize_4_7,Prize_5_1,Prize_5_2,Prize_5_3,Prize_5_4,Prize_5_5,Prize_5_6,Prize_6_1,Prize_6_2,Prize_6_3,Prize_7_1,Prize_7_2,Prize_7_3,Prize_7_4,Prize_8_1,Symbol_1,Symbol_2,Symbol_3 " &
            "  FROM  Lottery_Result_Live_YouTube " &
            " WHERE Company_Id=" & CompanyId & " AND CONVERT(varchar,Lot_Time,112)='" & DateTime.Parse(Now).ToString("yyyyMMdd") & "'"
        Dim cmd As New SqlClient.SqlCommand

        With cmd
            .CommandType = CommandType.Text
            .CommandText = sql
            .Connection = GlobalConnection
        End With
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim dt As DataTable = ds.Tables(0)
        If (Not da Is Nothing) Then da.Dispose()
        If dt.Rows.Count > 0 Then
            _Company_Id = dt.Rows(0).Item("Company_Id")
            _Prize_0_1 = dt.Rows(0).Item("Prize_0_1")
            _Prize_1_1 = dt.Rows(0).Item("Prize_1_1")
            _Prize_2_1 = dt.Rows(0).Item("Prize_2_1")
            _Prize_2_2 = dt.Rows(0).Item("Prize_2_2")
            _Prize_3_1 = dt.Rows(0).Item("Prize_3_1")
            _Prize_3_2 = dt.Rows(0).Item("Prize_3_2")
            _Prize_3_3 = dt.Rows(0).Item("Prize_3_3")
            _Prize_3_4 = dt.Rows(0).Item("Prize_3_4")
            _Prize_3_5 = dt.Rows(0).Item("Prize_3_5")
            _Prize_3_6 = dt.Rows(0).Item("Prize_3_6")
            _Prize_4_1 = dt.Rows(0).Item("Prize_4_1")
            _Prize_4_2 = dt.Rows(0).Item("Prize_4_2")
            _Prize_4_3 = dt.Rows(0).Item("Prize_4_3")
            _Prize_4_4 = dt.Rows(0).Item("Prize_4_4")
            _Prize_4_5 = dt.Rows(0).Item("Prize_4_5")
            _Prize_4_6 = dt.Rows(0).Item("Prize_4_6")
            _Prize_4_7 = dt.Rows(0).Item("Prize_4_7")
            _Prize_5_1 = dt.Rows(0).Item("Prize_5_1")
            _Prize_5_2 = dt.Rows(0).Item("Prize_5_2")
            _Prize_5_3 = dt.Rows(0).Item("Prize_5_3")
            _Prize_5_4 = dt.Rows(0).Item("Prize_5_4")
            _Prize_5_5 = dt.Rows(0).Item("Prize_5_5")
            _Prize_5_6 = dt.Rows(0).Item("Prize_5_6")
            _Prize_6_1 = dt.Rows(0).Item("Prize_6_1")
            _Prize_6_2 = dt.Rows(0).Item("Prize_6_2")
            _Prize_6_3 = dt.Rows(0).Item("Prize_6_3")
            _Prize_7_1 = dt.Rows(0).Item("Prize_7_1")
            _Prize_7_2 = dt.Rows(0).Item("Prize_7_2")
            _Prize_7_3 = dt.Rows(0).Item("Prize_7_3")
            _Prize_7_4 = dt.Rows(0).Item("Prize_7_4")
            _Prize_8_1 = dt.Rows(0).Item("Prize_8_1")
            _Symbol_1 = dt.Rows(0).Item("Symbol_1")
            _Symbol_2 = dt.Rows(0).Item("Symbol_2")
            _Symbol_3 = dt.Rows(0).Item("Symbol_3")
            _Lot_Time = dt.Rows(0).Item("Lot_Time")
            If _Symbol_1.Trim <> "" And _Symbol_2.Trim <> "" And _Symbol_3.Trim <> "" Then
                _Symbol = Symbol_1 & "-" & Symbol_2 & "-" & Symbol_3
            End If
            _Exist = "1"
        Else
            _Exist = "0"
        End If

    End Sub
    Public Property Company_Id() As String
        Get
            Return _Company_Id
        End Get
        Set(ByVal value As String)
            _Company_Id = value
        End Set
    End Property
    Public Property Prize_0_1() As String
        Get
            Return _Prize_0_1
        End Get
        Set(ByVal value As String)
            _Prize_0_1 = value
        End Set
    End Property
    Public Property Prize_1_1() As String
        Get
            Return _Prize_1_1
        End Get
        Set(ByVal value As String)
            _Prize_1_1 = value
        End Set
    End Property
    Public Property Prize_2_1() As String
        Get
            Return _Prize_2_1
        End Get
        Set(ByVal value As String)
            _Prize_2_1 = value
        End Set
    End Property
    Public Property Prize_2_2() As String
        Get
            Return _Prize_2_2
        End Get
        Set(ByVal value As String)
            _Prize_2_2 = value
        End Set
    End Property
    Public Property Prize_3_1() As String
        Get
            Return _Prize_3_1
        End Get
        Set(ByVal value As String)
            _Prize_3_1 = value
        End Set
    End Property
    Public Property Prize_3_2() As String
        Get
            Return _Prize_3_2
        End Get
        Set(ByVal value As String)
            _Prize_3_2 = value
        End Set
    End Property
    Public Property Prize_3_3() As String
        Get
            Return _Prize_3_3
        End Get
        Set(ByVal value As String)
            _Prize_3_3 = value
        End Set
    End Property
    Public Property Prize_3_4() As String
        Get
            Return _Prize_3_4
        End Get
        Set(ByVal value As String)
            _Prize_3_4 = value
        End Set
    End Property
    Public Property Prize_3_5() As String
        Get
            Return _Prize_3_5
        End Get
        Set(ByVal value As String)
            _Prize_3_5 = value
        End Set
    End Property
    Public Property Prize_3_6() As String
        Get
            Return _Prize_3_6
        End Get
        Set(ByVal value As String)
            _Prize_3_6 = value
        End Set
    End Property
    Public Property Prize_4_1() As String
        Get
            Return _Prize_4_1
        End Get
        Set(ByVal value As String)
            _Prize_4_1 = value
        End Set
    End Property
    Public Property Prize_4_2() As String
        Get
            Return _Prize_4_2
        End Get
        Set(ByVal value As String)
            _Prize_4_2 = value
        End Set
    End Property
    Public Property Prize_4_3() As String
        Get
            Return _Prize_4_3
        End Get
        Set(ByVal value As String)
            _Prize_4_3 = value
        End Set
    End Property
    Public Property Prize_4_4() As String
        Get
            Return _Prize_4_4
        End Get
        Set(ByVal value As String)
            _Prize_4_4 = value
        End Set
    End Property
    Public Property Prize_4_5() As String
        Get
            Return _Prize_4_5
        End Get
        Set(ByVal value As String)
            _Prize_4_5 = value
        End Set
    End Property
    Public Property Prize_4_6() As String
        Get
            Return _Prize_4_6
        End Get
        Set(ByVal value As String)
            _Prize_4_6 = value
        End Set
    End Property
    Public Property Prize_4_7() As String
        Get
            Return _Prize_4_7
        End Get
        Set(ByVal value As String)
            _Prize_4_7 = value
        End Set
    End Property

    Public Property Prize_5_1() As String
        Get
            Return _Prize_5_1
        End Get
        Set(ByVal value As String)
            _Prize_5_1 = value
        End Set
    End Property
    Public Property Prize_5_2() As String
        Get
            Return _Prize_5_2
        End Get
        Set(ByVal value As String)
            _Prize_5_2 = value
        End Set
    End Property
    Public Property Prize_5_3() As String
        Get
            Return _Prize_5_3
        End Get
        Set(ByVal value As String)
            _Prize_5_3 = value
        End Set
    End Property
    Public Property Prize_5_4() As String
        Get
            Return _Prize_5_4
        End Get
        Set(ByVal value As String)
            _Prize_5_4 = value
        End Set
    End Property
    Public Property Prize_5_5() As String
        Get
            Return _Prize_5_5
        End Get
        Set(ByVal value As String)
            _Prize_5_5 = value
        End Set
    End Property
    Public Property Prize_5_6() As String
        Get
            Return _Prize_5_6
        End Get
        Set(ByVal value As String)
            _Prize_5_6 = value
        End Set
    End Property
    Public Property Prize_6_1() As String
        Get
            Return _Prize_6_1
        End Get
        Set(ByVal value As String)
            _Prize_6_1 = value
        End Set
    End Property
    Public Property Prize_6_2() As String
        Get
            Return _Prize_6_2
        End Get
        Set(ByVal value As String)
            _Prize_6_2 = value
        End Set
    End Property
    Public Property Prize_6_3() As String
        Get
            Return _Prize_6_3
        End Get
        Set(ByVal value As String)
            _Prize_6_3 = value
        End Set
    End Property

    Public Property Prize_7_1() As String
        Get
            Return _Prize_7_1
        End Get
        Set(ByVal value As String)
            _Prize_7_1 = value
        End Set
    End Property
    Public Property Prize_7_2() As String
        Get
            Return _Prize_7_2
        End Get
        Set(ByVal value As String)
            _Prize_7_2 = value
        End Set
    End Property
    Public Property Prize_7_3() As String
        Get
            Return _Prize_7_3
        End Get
        Set(ByVal value As String)
            _Prize_7_3 = value
        End Set
    End Property
    Public Property Prize_7_4() As String
        Get
            Return _Prize_7_4
        End Get
        Set(ByVal value As String)
            _Prize_7_4 = value
        End Set
    End Property
    Public Property Prize_8_1() As String
        Get
            Return _Prize_8_1
        End Get
        Set(ByVal value As String)
            _Prize_8_1 = value
        End Set
    End Property
    Public Property Symbol_1() As String
        Get
            Return _Symbol_1
        End Get
        Set(ByVal value As String)
            _Symbol_1 = value
        End Set
    End Property
    Public Property Symbol_2() As String
        Get
            Return _Symbol_2
        End Get
        Set(ByVal value As String)
            _Symbol_2 = value
        End Set
    End Property
    Public Property Symbol_3() As String
        Get
            Return _Symbol_3
        End Get
        Set(ByVal value As String)
            _Symbol_3 = value
        End Set
    End Property
    Public Property Symbol() As String
        Get
            Return _Symbol
        End Get
        Set(ByVal value As String)
            _Symbol = value
        End Set
    End Property
    Public Property Lot_Time() As String
        Get
            Return "Kết quả xổ số Miền Bắc ngày, " & DateTime.Parse(Now).ToString("dd-MM-yyyy")
        End Get
        Set(ByVal value As String)
            _Lot_Time = value
        End Set
    End Property

    Public Property Exist() As String
        Get
            Return _Exist
        End Get
        Set(ByVal value As String)
            _Exist = value
        End Set
    End Property
End Class

