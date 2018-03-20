Imports System.Data.SqlClient

Public Class UserInfo
    Private _UserName As String
    Private _UserId As String
    Private _UserFullName As String
    Private _UserPwd As String
    Private _UserEmail As String
    Private _UserPhone As String
    Private _UserStatus As Integer = 0
    Private _UserLevel As Integer = 0
    Private _GroupStatus As Integer = 0
    Private _GroupId As Integer = 0
    Private _GroupLevel As Integer = 0
    Private _GroupName As String
    Private _GroupIsAdmin As Integer = 0
    Private _GroupRootId As Integer = 0
    Private _DeptId As Integer = 0
    Private _PartnerId As Integer = 0
    Private _LastLogin As String
    Private _IsAccess As Integer = 0 '//=0 Chua duoc KT; =1 Ton tai User;

    Public Sub New(ByVal vUserName As String, ByVal vPassword As String)
        If (IsUserInfo(vUserName, vPassword)) Then
            'IsACL()  ' Lấy thông tin quyền hạn vào biến  _dsACL (Access Control List)
            _IsAccess = 1
        End If

    End Sub
    Private Function IsUserInfo(ByVal vUserName As String, ByVal vPassword As String) As Boolean
        Dim drUserInfo As SqlDataReader = ObjDataReader.UserManager.UserInfo(vUserName, vPassword)
        If drUserInfo.Read() Then '//Ton tai user ? 
            _UserName = drUserInfo("User_Name").ToString()
            _UserFullName = drUserInfo("Full_Name").ToString()
            _UserPwd = drUserInfo("Pass_Word").ToString()
            _UserEmail = drUserInfo("Email").ToString()
            _UserPhone = drUserInfo("Telephone").ToString()
            _UserId = drUserInfo("Id").ToString()
            _UserStatus = drUserInfo("Status").ToString()
            _GroupId = drUserInfo("Group_Id").ToString()
            _GroupStatus = drUserInfo("Group_Status").ToString()
            _GroupName = drUserInfo("Group_Text").ToString
            _LastLogin = DateTime.Parse(drUserInfo("Last_Login")).ToString
            _GroupIsAdmin = drUserInfo("Is_Admin").ToString()
            _GroupLevel = drUserInfo("Group_Level").ToString()
            _GroupRootId = drUserInfo("Group_Root_Id").ToString()
            _UserLevel = drUserInfo("Is_Level").ToString()
            _DeptId = drUserInfo("Dept_Id").ToString
            _PartnerId = drUserInfo("Partner_Id").ToString
            '_ChannelAccess = drUserInfo("Channel_Id").ToString()

            Return True
        End If
        Return False
    End Function
    'Protected Sub IsACL()
    '    Dim sql As String = "SELECT * FROM System_Group_Channel  Where Group_Id=" & GroupId
    '    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
    '    If dt.Rows.Count > 0 Then
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Administrator Then
    '                GlobalManager.Administrator = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.AndroidApps Then
    '                GlobalManager.AndroidApps = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.SMS Then
    '                GlobalManager.SMS = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.S2 Then
    '                GlobalManager.S2 = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Vinabox Then
    '                GlobalManager.Vinabox = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.GamePortal Then
    '                GlobalManager.GamePortal = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.Vishare Then
    '                GlobalManager.Vishare = True
    '            End If
    '            If dt.Rows(i).Item("Channel_Id") = Constants.Channel.Id.CustomerInfo Then
    '                GlobalManager.CustomerInfo = True
    '            End If
    '        Next
    '    End If
    'End Sub
    Public Function IsAuthenticate(ByVal intStatus As Integer) As Boolean
        If ((intStatus = Constants.DatabaseField.Is_Status_UnLock) And (_IsAccess = Constants.PrivilegesSystems.IsSignIn)) Then '// Tồn tại thông tin User và không bị khóa
            Return True
        Else
            Return False
        End If

    End Function
    Public ReadOnly Property IsAccess() As Integer
        Get
            Return _IsAccess
        End Get

    End Property
    Public ReadOnly Property UserName() As String
        Get
            Return _UserName
        End Get
    End Property
    Public ReadOnly Property UserId() As String
        Get
            Return _UserId
        End Get
    End Property
    Public ReadOnly Property UserFullName() As String
        Get
            Return _UserFullName
        End Get
    End Property
    Public ReadOnly Property UserEmail() As String
        Get
            Return _UserEmail
        End Get
    End Property
    Public ReadOnly Property UserPhone() As String
        Get
            Return _UserPhone
        End Get
    End Property
    Public Property UserPassword() As String

        Get
            Return _UserPwd
        End Get

        Set(ByVal Value As String)
            Dim _id() As String = _UserId.Split("="c)
            Dim cmd As SqlCommand = New SqlCommand("Update System_Users  set Pass_Word='" & Value & "' Where Id='" & _id(0).Trim & "'", GlobalConnection)
            If cmd.ExecuteNonQuery() = 1 Then
                _UserPwd = Value
            End If
        End Set

    End Property
    Public ReadOnly Property UserStatus() As Integer

        Get
            Return _UserStatus
        End Get

    End Property
    Public ReadOnly Property GroupStatus() As Integer

        Get
            Return _GroupStatus
        End Get

    End Property
    Public ReadOnly Property GroupId() As Integer
        Get
            Return _GroupId
        End Get

    End Property
    Public ReadOnly Property GroupName() As String
        Get
            Return _GroupName
        End Get

    End Property
    Public ReadOnly Property LastLogin() As String
        Get
            Return _LastLogin
        End Get

    End Property
    Public ReadOnly Property GroupIsAdmin() As Integer
        Get
            Return _GroupIsAdmin
        End Get

    End Property
    Public ReadOnly Property GroupLevel() As Integer
        Get
            Return _GroupLevel
        End Get

    End Property
    Public ReadOnly Property GroupRootId() As Integer
        Get
            Return _GroupRootId
        End Get

    End Property
    Public ReadOnly Property UserLevel() As Integer
        Get
            Return _UserLevel
        End Get

    End Property
    Public ReadOnly Property DeptId() As Integer
        Get
            Return _DeptId
        End Get

    End Property
    Public ReadOnly Property PartnerId() As Integer
        Get
            Return _PartnerId
        End Get

    End Property
End Class
