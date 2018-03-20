Public Class AdminUsersList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ TÀI KHOẢN ĐĂNG NHẬP"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
        End If
        BindData()
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
        Dim sql As String = "SELECT  A.Id, A.User_Name, A.Full_Name, A.Email, A.Telephone, A.Create_By_Text,A.Create_Time,A.Update_By_Text,A.Update_Time, A.Description, " & _
             " Status= case A.Status when 1 then N'Active' else N'Locked' end," & _
             " B.Group_Text," & _
             " C.Dept_Text,C.Dept_Code" & _
             " From System_Users A  Inner Join System_Group_User B On A.Group_Id=B.Id" & _
             " Inner Join System_Department C On B.Dept_Id=C.Id" & _
             " Where A.Is_Delete=0 Order by Group_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Columns(9).Visible = IsUpdate
            Me.DataGrid.Columns(10).Visible = IsDelete
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
        Dim sql As String =  "Update System_Users Set Is_Delete=1 Where Id=" & CType(e.CommandArgument, Integer)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                BindData()
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect(Constants.Url._Admin.AdminUsersEdit)
    End Sub
#End Region
End Class