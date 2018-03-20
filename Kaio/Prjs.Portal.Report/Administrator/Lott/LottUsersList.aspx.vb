Public Class LottUsersList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ TÀI KHOẢN ĐĂNG NHẬP KÊNH XỔ SỐ"
        End If
        BindData()
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
             " Where A.Is_Delete=0  AND B.Id IN ( SELECT Group_Id FROM System_Group_Channel WHERE Channel_Id IN (16,17) ) Order by Group_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True
            SetFunctionReport()

        Else
            Me.DataGrid.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub
#End Region
#Region "Set Function Report"
    Private Sub SetFunctionReport()
        Dim sql As String = "SELECT * FROM System_User_Function_Channel WHERE Channel_Lott_Report>0"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Dim lblUser_Id As Label
        Dim DropDownListReport As DropDownList
        Dim UserId As Integer = 0
        Dim IsFunction As Integer = 0
        Dim DataGridItem As DataGridItem
        If dt.Rows.Count > 0 Then
            For Each DataGridItem In DataGrid.Items
                lblUser_Id = DataGridItem.Cells(0).Controls(1).FindControl("lblUser_Id")
                UserId = lblUser_Id.Text
                DropDownListReport = DataGridItem.FindControl("DropDownListReport")
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("USER_ID") = UserId Then
                        If dt.Rows(i).Item("Channel_Lott_Report") > 0 Then
                            DropDownListReport.SelectedValue = dt.Rows(i).Item("Channel_Lott_Report")
                        Else
                            DropDownListReport.SelectedValue = 0
                        End If
                    End If
                Next
            Next
        End If
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Update System_Users Set Is_Delete=1 Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            BindData()
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim DataGridItem As DataGridItem
        Dim lblUser_Id As Label
        Dim DropDownListReport As DropDownList
        Dim str As String = ""
        For Each DataGridItem In DataGrid.Items
            lblUser_Id = DataGridItem.FindControl("lblUser_Id")
            DropDownListReport = DataGridItem.FindControl("DropDownListReport")
            If DropDownListReport.SelectedItem.Value > 0 Then
                str = UpdateObject.LottInterface.UpdateUserReportFunction(lblUser_Id.Text.Trim, CInt(DropDownListReport.SelectedItem.Value)).Trim
                If str <> "" Then
                    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & str
                    Exit Sub
                End If
            End If
        Next
        If str = "" Then
            BindData()
            Me.lblerror.Text = Constants.AlertInfo.ExcuteSuccess
        End If
    End Sub
#End Region
End Class