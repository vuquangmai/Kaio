Public Class AdminGroupUserEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI NHÓM ACCOUNT"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                    Me.btnDelete.Visible = True
                Else
                    Me.lbltitle.Text = "THÊM NHÓM ACCOUNT"
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                    Me.btnDelete.Visible = False
                End If
            End If
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDept_Id.Items.Clear()
        Me.DropDownListDept_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDept_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDept_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
   
#End Region
 
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM System_Group_User Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtGroup_Text.Text = dt.Rows(0).Item("Group_Text")
            Me.DropDownListDept_Id.SelectedValue = dt.Rows(0).Item("Dept_Id")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtGroup_Text.Text = "" Then
            Me.lblerror.Text = "Tên Menu không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListDept_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Phòng ban không hợp lệ !"
            Exit Sub
        End If
        Dim Root_Id As Integer = CurrentUser.GroupRootId + 1
        Dim Group_Text As String = Me.txtGroup_Text.Text.Trim
        Dim Dept_Id As Integer = Me.DropDownListDept_Id.SelectedItem.Value
        Dim Is_Admin As Integer = 0
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Is_Delete As Integer = 0
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
            sql = "Insert Into System_Group_User(Root_Id, Group_Text, Dept_Id, Is_Admin, Status, Is_Delete, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                "Values (N'" & Root_Id & "',N'" & Group_Text & "',N'" & Dept_Id & "',N'" & Is_Admin & "',N'" & Status & "',N'" & Is_Delete & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
        ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
            sql = "Update System_Group_User Set Group_Text=N'" & Group_Text & "'," & _
            "Dept_Id=N'" & Dept_Id & "'," & _
            "Status=N'" & Status & "'," & _
            "Update_Time=N'" & Update_Time & "'," & _
            "Update_By_Id=N'" & Update_By_Id & "'," & _
            "Update_By_Text=N'" & Update_By_Text & "'," & _
            "Description=N'" & Description & "'" & _
            " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        End If
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Update System_Group_User Set Is_Delete=1 " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            sql = "Delete From System_Url Where Id=" & ViewState(ViewStateInfo.Object_Id)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try

    End Sub
#End Region

End Class