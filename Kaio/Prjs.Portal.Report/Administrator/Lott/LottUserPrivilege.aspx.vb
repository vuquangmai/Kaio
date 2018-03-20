Imports Telerik.Web.UI

Public Class LottUserPrivilege
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ QUYỀN NHẬP KẾT"
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                BindActive(ViewState(ViewStateInfo.Object_Id))
                BindDeactive(ViewState(ViewStateInfo.Object_Id))
                BindUserName(ViewState(ViewStateInfo.Object_Id))
            End If
        End If
    End Sub
#End Region
#Region "Bind DictIndex"
    Private Sub BindUserName(ByVal GroupId As Integer)
        Dim sql As String = "SELECT * FROM System_Users Where Id=" & GroupId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblUser.Text = dt.Rows(0).Item("User_Name").ToString.ToUpper
        End If
    End Sub
    Private Sub BindActive(ByVal UserId As Integer)
        Try
            Dim dt As DataTable = ObjDataTable.LottInterface.CompanyActiveByUser(UserId)
            If dt.Rows.Count > 0 Then
                Me.RadTreeViewUrlActive.DataSource = dt
                Me.RadTreeViewUrlActive.DataBind()
                RadTreeViewUrlActive.DataFieldID = "Id"
                RadTreeViewUrlActive.DataFieldParentID = "Parent_Id"
                RadTreeViewUrlActive.CollapseAllNodes()
                Me.RadTreeViewUrlActive.Visible = True
                ' Me.lblErorr1.Text = ""
            Else
                Me.RadTreeViewUrlActive.Nodes.Clear()
                ' Me.lblErorr1.Text = "Không có chức năng nào !"
            End If
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
    Private Sub BindDeactive(ByVal UserId As Integer)
        Try
            Dim dt As DataTable = ObjDataTable.LottInterface.CompanyDeActiveByUser(UserId)
            If dt.Rows.Count > 0 Then
                Me.RadTreeViewUrlDeactive.DataSource = dt
                Me.RadTreeViewUrlDeactive.DataBind()
                RadTreeViewUrlDeactive.DataFieldID = "Id"
                RadTreeViewUrlDeactive.DataFieldParentID = "Parent_Id"
                RadTreeViewUrlDeactive.MultipleSelect = True
                RadTreeViewUrlDeactive.CollapseAllNodes()
                Me.RadTreeViewUrlDeactive.Visible = True
                'Me.lblErorr2.Text = ""
            Else
                Me.RadTreeViewUrlDeactive.Nodes.Clear()
                'Me.lblErorr2.Text = "Không có chức năng nào !"
            End If
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim NodeId As String
        Dim Node As RadTreeNode
        Dim str As String = ""
        For Each Node In RadTreeViewUrlDeactive.CheckedNodes
            NodeId = Node.Value
            If NodeId < 46 Then
                str = UpdateObject.LottInterface.InsertCompanyUser(ViewState(ViewStateInfo.Object_Id), NodeId)
            End If
            If str = "" Then
                Me.lblErorr2.Text = Constants.AlertInfo.ExcuteSuccess
            Else
                Me.lblErorr2.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & str
                Exit For
            End If
        Next Node
        BindActive(ViewState(ViewStateInfo.Object_Id))
        BindDeactive(ViewState(ViewStateInfo.Object_Id))
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Dim nodeId As String
        Dim node As RadTreeNode
        Dim str As String = ""
        For Each node In RadTreeViewUrlActive.CheckedNodes
            nodeId = node.Value
            If nodeId <> "" Then
                str = DeleteObject.LottInterface.DeleteUserCompany(ViewState(ViewStateInfo.Object_Id), nodeId)
            End If
            If str = "" Then
                Me.lblErorr2.Text = Constants.AlertInfo.ExcuteSuccess
            Else
                Me.lblErorr2.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & str
                Exit For
            End If
        Next node
        BindActive(ViewState(ViewStateInfo.Object_Id))
        BindDeactive(ViewState(ViewStateInfo.Object_Id))
    End Sub
#End Region

End Class