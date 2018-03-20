Public Class AdminGroupUserList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "DANH SÁCH NHÓM ACCOUNT"
        End If
        Me.btnAdd.Visible = IsUpdate
        bindData()
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGrid.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData()
        Dim sql As String = "SELECT  A.Id, A.Root_Id, A.Group_Text, A.Dept_Id, A.Is_Admin, A.Create_By_Text,A.Create_Time,A.Update_By_Text,A.Update_Time, A.Description, " & _
             " Status= case A.Status when 1 then N'Active' else N'Locked' end," & _
             "B.Dept_Text,B.Dept_Code" & _
             " From System_Group_User A  Inner Join System_Department B On A.Dept_Id=B.Id" & _
             " Where A.Is_Level<=2 Order by Group_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            'Me.DataGrid.Columns(11).Visible = IsUpdate
            'Me.DataGrid.Columns(12).Visible = IsDelete
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True

            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGrid.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Select * from  System_Group_User  where  Root_Id =" & CType(e.CommandArgument, Integer)
        If IsCheckData(sql) = False Then
            sql = "Delete From System_Group_User Where Id=" & CType(e.CommandArgument, Integer)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                BindData()
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordDelete
            Exit Sub
        End If

    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect(Constants.Url._Admin.AdminGroupUserEdit)
    End Sub
#End Region
End Class