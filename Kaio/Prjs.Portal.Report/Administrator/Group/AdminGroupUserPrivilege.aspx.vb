Public Class AdminGroupUserPrivilege
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "PHÂN QUYỀN CHỨC NĂNG CHO NHÓM"
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            bindGroupName(ViewState(ViewStateInfo.Object_Id))
        End If
        bindData(ViewState(ViewStateInfo.Object_Id), CurrentUser.GroupRootId)
    End Sub
#End Region
#Region "Bind DictIndex"
    Private Sub BindGroupName(ByVal GroupId As Integer)
        Dim sql As String = "SELECT * FROM System_Group_User Where Id=" & GroupId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblgroupUser.Text = dt.Rows(0).Item("Group_Text").ToString.ToUpper
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal Groupid As Integer, ByVal Rootid As Integer)
        Try
            Dim dt As DataTable = ObjDataTable.GroupUserManager.GroupPrivilege(Groupid, Rootid)
            If dt.Rows.Count > 0 Then
                Me.grddata.DataSource = dt
                Me.grddata.DataBind()
                Me.grddata.Visible = True
                Me.btnUpdate.Visible = True
                Dim dgItem As DataGridItem
                Dim lblmaxvalues As Label
                Dim lblitemName As Label
                Dim DropDownListFunction As DropDownList
                For Each dgItem In grddata.Items
                    lblitemName = dgItem.Cells(0).Controls(1).FindControl("lblitemName")
                    Dim str As String = lblitemName.Text.Trim
                    lblmaxvalues = dgItem.Cells(0).Controls(1).FindControl("lblmaxvalues")
                    DropDownListFunction = dgItem.Cells(0).Controls(1).FindControl("DropDownListFunction")
                    For i As Integer = 0 To DropDownListFunction.Items.Count - 1
                        If DropDownListFunction.Items(i).Value > CInt(lblmaxvalues.Text.Trim) Then
                            Try
                                DropDownListFunction.Items(i).Enabled = False
                            Catch ex As Exception
                                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
                                Exit Sub
                            End Try
                        End If
                    Next
                Next
            Else
                Me.lblerror.Text = "Nhóm account này chưa được truy cập bất kỳ chức năng nào !"
                Me.grddata.Visible = False
            End If
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim dgItem As DataGridItem
        Dim lblPrivilegeId As Label
        Dim CurrentPrivilege_Val As Label
        Dim DropDownListFunction As DropDownList
        Dim sql As String = ""
        For Each dgItem In grddata.Items
            lblPrivilegeId = dgItem.Cells(0).Controls(1).FindControl("lblfunid")
            CurrentPrivilege_Val = dgItem.Cells(0).Controls(1).FindControl("funvalue")
            DropDownListFunction = dgItem.Cells(0).Controls(1).FindControl("DropDownListFunction")
            If CInt(CurrentPrivilege_Val.Text.Trim) <> CInt(DropDownListFunction.SelectedItem.Value) Then
                sql = "Update System_Group_Privilege SET Privilege_Val=" & DropDownListFunction.SelectedItem.Value & _
                    " Where Id=" & lblPrivilegeId.Text.Trim
                Try
                    MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                Catch ex As Exception
                    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
                    Exit Sub
                End Try
            End If
        Next
        bindData(ViewState(ViewStateInfo.Object_Id), CurrentUser.GroupRootId)
        Me.lblerror.Text = Constants.AlertInfo.ExcuteSuccess
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
    End Sub
#End Region
End Class