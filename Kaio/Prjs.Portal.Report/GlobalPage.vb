Option Strict Off
Imports System
Imports System.Web.UI
Imports System.Web.Security
Public Class GlobalPage
    Inherits System.Web.UI.Page
    Private UrlSuffix As String
    Private PageUrlBase As String
    Public IsView As Boolean = True
    Public IsUpdate As Boolean = True
    Public IsDelete As Boolean = True
    Public IsPrivilege As Integer = 0
   
#Region "Page New"
    Public Sub New()
        Try
            UrlSuffix = Context.Request.Url.Host & Context.Request.ApplicationPath
            PageUrlBase = "http://" & UrlSuffix
        Catch
            '// for design time
        End Try
    End Sub
#End Region
#Region "Page Load"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session(SessionInfo.UserInfo.Current_User) Is Nothing Then
            Response.Redirect("~/Login.aspx?ReturnURL=" & Context.Request.FilePath, True)
        Else
            Dim Url As String = Context.Request.FilePath.Trim().ToLower()
            If Url.IndexOf("/login.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/index.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/banner.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/footer.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/menuleft.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/menuleftfooter.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/menuleftfooter.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/splitout.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/splitoutfooter.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/menulefttop.aspx") > -1 Then
                Return
            End If
            If Url.IndexOf("/accessdenied.aspx") > -1 Then
                Return
            End If
            Dim vChannelId As Integer = IsChannelId(Context.Request.FilePath.ToLower())
            If Not IsAccessMenu(CurrentUser.GroupId, CurrentUser.UserId, vChannelId, Url) Then
                Response.Redirect(Constants.Url._Global.AccessDenied, True)
            End If
        End If

    End Sub
#End Region
#Region "Check Access Channel"
    Public Sub IsAccessChannel(ByVal vChannel As Boolean)
        If vChannel = False Then
            Response.Redirect(Constants.Url._Global.AccessDenied, True)
        End If
    End Sub
#End Region
#Region "Check Access Menu"
    Private Function IsAccessMenu(ByVal intGroupId As Integer, ByVal intUserId As Integer, ByVal intChannelId As Integer, ByVal Url As String) As Boolean
        Dim dt As DataTable = ObjDataTable.UrlManager.UrlAccessRights(intGroupId, intUserId, intChannelId, Url)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Check Privilege On Menu"
    Public Sub IsPrivilegeOnMenu()
        'If CurrentUser.GroupIsAdmin <> Constants.PrivilegesSystems.IsAdministrator Then
        Dim Url As String = Context.Request.FilePath.Trim().ToLower()
        Dim dt As DataTable = ObjDataTable.UrlManager.CheckPrivilege(CurrentUser.GroupId, Url)
        If dt.Rows.Count > 0 Then
            IsPrivilege = dt.Rows(0).Item("Privilege_Val")
        Else
            IsPrivilege = Constants.PrivilegesSystems.IsView
        End If
        IsView = IsPrivilege >= Constants.PrivilegesSystems.IsView
        IsUpdate = IsPrivilege >= Constants.PrivilegesSystems.IsUpdate
        IsDelete = IsPrivilege >= Constants.PrivilegesSystems.IsDelete
        'End If
    End Sub
#End Region
#Region "Return Channel Id"
    Public Function IsChannelId(ByVal Url As String) As Integer
        Dim vChannelId As Integer = -1
        Me.Title = Constants.Channel.Text.HQPortal
        If Url.ToLower().IndexOf("/administrator/") >= 0 Then
            vChannelId = Constants.Channel.Id.Administrator
            Me.Title = Constants.Channel.Text.Administrator
        ElseIf Url.ToLower().IndexOf("/androidapps/") >= 0 Then
            vChannelId = Constants.Channel.Id.AndroidApps
            Me.Title = Constants.Channel.Text.AndroidApps
        ElseIf Url.ToLower().IndexOf("/ccare/") >= 0 Then
            vChannelId = Constants.Channel.Id.Ccare
            Me.Title = Constants.Channel.Text.Ccare
        ElseIf Url.ToLower().IndexOf("/subscriptionservice/") >= 0 Then
            vChannelId = Constants.Channel.Id.S2
            Me.Title = Constants.Channel.Text.S2
        ElseIf Url.ToLower().IndexOf("/vinabox/") >= 0 Then
            vChannelId = Constants.Channel.Id.Vinabox
            Me.Title = Constants.Channel.Text.Vinabox
        ElseIf Url.ToLower().IndexOf("/vishare/") >= 0 Then
            vChannelId = Constants.Channel.Id.Vishare
            Me.Title = Constants.Channel.Text.Vishare
        ElseIf Url.ToLower().IndexOf("/customerinfo/") >= 0 Then
            vChannelId = Constants.Channel.Id.CustomerInfo
            Me.Title = Constants.Channel.Text.CustomerInfo
        ElseIf Url.ToLower().IndexOf("/gameportal/") >= 0 Then
            vChannelId = Constants.Channel.Id.GamePortal
            Me.Title = Constants.Channel.Text.GamePortal
        ElseIf Url.ToLower().IndexOf("/simtoolkit/") >= 0 Then
            vChannelId = Constants.Channel.Id.SimToolKit
            Me.Title = Constants.Channel.Text.SimToolKit
        ElseIf Url.ToLower().IndexOf("/billing/") >= 0 Then
            vChannelId = Constants.Channel.Id.Billing
            Me.Title = Constants.Channel.Text.Billing
        ElseIf Url.ToLower().IndexOf("/charging/") >= 0 Then
            vChannelId = Constants.Channel.Id.Charging
            Me.Title = Constants.Channel.Text.Charging
        ElseIf Url.ToLower().IndexOf("/mgame/") >= 0 Then
            vChannelId = Constants.Channel.Id.MGame
            Me.Title = Constants.Channel.Text.MGame
        ElseIf Url.ToLower().IndexOf("/kpi/") >= 0 Then
            vChannelId = Constants.Channel.Id.KPI
            Me.Title = Constants.Channel.Text.KPI
        ElseIf Url.ToLower().IndexOf("/contractinfo/") >= 0 Then
            vChannelId = Constants.Channel.Id.ContractInfo
            Me.Title = Constants.Channel.Text.ContractInfo
        ElseIf Url.ToLower().IndexOf("/tools/") >= 0 Then
            vChannelId = Constants.Channel.Id.Administrator
            Me.Title = Constants.Channel.Text.Administrator
        End If
        Return vChannelId
    End Function
#End Region
#Region "Curent User"
    Protected Property CurrentUser() As UserInfo
        Get
            Try
                CurrentUser = Session(SessionInfo.UserInfo.Current_User)
            Catch
                CurrentUser = Nothing
            End Try
        End Get
        Set(ByVal Value As UserInfo)
            Session.Remove(SessionInfo.UserInfo.Current_User)
            If Not (Value Is Nothing) Then
                Session(SessionInfo.UserInfo.Current_User) = Value
            End If
        End Set

    End Property
#End Region
#Region "Channel User"
    Protected Property ChannelUser() As ChannelInfo
        Get
            Try
                ChannelUser = Session(SessionInfo.UserInfo.Channel_User)
            Catch
                ChannelUser = Nothing
            End Try
        End Get
        Set(ByVal Value As ChannelInfo)
            Session.Remove(SessionInfo.UserInfo.Channel_User)
            If Not (Value Is Nothing) Then
                Session(SessionInfo.UserInfo.Channel_User) = Value
            End If
        End Set
    End Property
#End Region
#Region "Check Exist Database"
    Public Function IsCheckData(ByVal sql As String) As Boolean
        If ObjDataTable.CheckExist.IsExistObject(sql).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function B2CCheckData(ByVal sql As String) As Boolean
        Dim dt As DataTable = Nothing
        dt = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region
#Region "Redirect Url"
    Public Sub RedirectUrl(ByVal Url As String)
        Response.Redirect(Url)
    End Sub
#End Region
  
End Class
