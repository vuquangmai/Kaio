Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SimToolKit_Menuleft
    Inherits GlobalPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim dt As DataTable = ObjDataTable.UrlManager.UrlByGroupId(CurrentUser.GroupId, CurrentUser.UserId, Constants.Channel.Id.SimToolKit)
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