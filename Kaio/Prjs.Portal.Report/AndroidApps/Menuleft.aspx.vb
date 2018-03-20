Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class AndroidApps_Menuleft
    Inherits GlobalPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(DataAccess.GetSqlConnectionString(MSSQLConnectionStringGlobal), "select ID,NAME,URL,PARENT_ID = case PARENT_ID when 0 then NULL      Else PARENT_ID		end from System_Url order by IS_ORDER_ROOT") 'ManagerUrl.selectUrlList(Session(Constants.UserInfoSession.USER_GROUP_ID), Session(Constants.UserInfoSession.USER_ID))
            Dim dt As DataTable = ObjDataTable.UrlManager.UrlByGroupId(CurrentUser.GroupId, CurrentUser.UserId, Constants.Channel.Id.AndroidApps)
            If dt.Rows.Count > 0 Then
                Me.RadMenuList.DataSource = dt
                Me.RadMenuList.DataBind()
                RadMenuList.DataFieldID = "Id"
                RadMenuList.DataFieldParentID = "Parent_Id"
                RadMenuList.SingleExpandPath = True
                RadMenuList.ShowLineImages = True
            End If
        End If
    End Sub

End Class