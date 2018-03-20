Imports System.Data.SqlClient

Public Class AdminGroupUserEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            BindPartner()
            BindChannel()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI NHÓM ACCOUNT"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM NHÓM ACCOUNT"
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Me.btnDelete.Visible = False
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
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Order by Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindChannel()
        Dim sql As String = "SELECT * FROM System_Channel Order by Channel_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.CheckBoxListChannel.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.CheckBoxListChannel.Items.Add(New ListItem(dt.Rows(i).Item("Channel_Text"), dt.Rows(i).Item("ID")))
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
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            sql = "SELECT * FROM System_Group_Channel Where Group_Id=" & intId
            Dim dtChannel As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dtChannel.Rows.Count > 0 Then
                For i As Integer = 0 To dtChannel.Rows.Count - 1
                    Me.CheckBoxListChannel.Items.FindByValue(dtChannel.Rows(i).Item("Channel_Id")).Selected = True
                Next
            End If
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtGroup_Text.Text = "" Then
            Me.lblerror.Text = "Tên nhóm không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListDept_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Phòng ban không hợp lệ !"
            Exit Sub
        End If
        Dim Root_Id As Integer = CurrentUser.GroupId
        Dim Group_Text As String = Me.txtGroup_Text.Text.Trim
        Dim Dept_Id As Integer = Me.DropDownListDept_Id.SelectedItem.Value
        Dim Dept_Text As String = Me.DropDownListDept_Id.SelectedItem.Text.Trim
        Dim Partner_Id As Integer = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Partner_Text As String = IIf(Partner_Id = 0, "", Me.DropDownListPartner_Id.SelectedItem.Text.Trim)
        Dim Is_Admin As Integer = 0
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Is_Delete As Integer = 0
        Dim Is_Level As Integer = CurrentUser.GroupLevel + 1
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        Dim Group_Id As Integer = 0
        sql = "SELECT * From  System_Group_User  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Group_Text=N'" & Group_Text & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                'sql = "Insert Into System_Group_User(Root_Id, Group_Text, Dept_Id, Is_Admin, Status, Is_Delete,Is_Level, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                '    "Values (N'" & Root_Id & "',N'" & Group_Text & "',N'" & Dept_Id & "',N'" & Is_Admin & "',N'" & Status & "',N'" & Is_Delete & "',N'" & Is_Level & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
                Group_Id = InsertGroup(Root_Id, Group_Text, Dept_Id, Dept_Text, Partner_Id, Partner_Text, Is_Admin, Status, Is_Delete, Is_Level, Create_By_Id, Create_By_Text, Create_Time, Update_By_Id, Update_By_Text, Update_Time, Description)
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                Group_Id = UpdateGroup(Group_Text, Dept_Id, Dept_Text, Partner_Id, Partner_Text, Status, Update_Time, Update_By_Id, Update_By_Text, Description)
            End If
            If Group_Id > 0 Then
                UpdateChannel(Group_Id)
                RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
            Else
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End If
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Update System_Group_User Set Is_Delete=1 " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminGroupUserList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region
#Region "Insert Group"
    Private Function InsertGroup(ByVal Root_Id As Integer, _
                     ByVal Group_Text As String, _
                     ByVal Dept_Id As Integer, _
                     ByVal Dept_Text As String, _
                     ByVal Partner_Id As Integer, _
                     ByVal Partner_Text As String, _
                     ByVal Is_Admin As Integer, _
                     ByVal Status As Integer, _
                     ByVal Is_Delete As Integer, _
                     ByVal Is_Level As Integer, _
                     ByVal Create_By_Id As Integer, _
                     ByVal Create_By_Text As String, _
                     ByVal Create_Time As String, _
                     ByVal Update_By_Id As Integer, _
                     ByVal Update_By_Text As String, _
                     ByVal Update_Time As String, _
                     ByVal Description As String) As String
        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "System_Insert_Group_Account"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters("@Id").Direction = ParameterDirection.Output

            .Parameters.Add(New SqlParameter("@Root_Id", SqlDbType.Int))
            .Parameters("@Root_Id").Value = Root_Id

            .Parameters.Add(New SqlParameter("@Group_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Group_Text").Value = Group_Text

            .Parameters.Add(New SqlParameter("@Dept_Id", SqlDbType.Int))
            .Parameters("@Dept_Id").Value = Dept_Id

            .Parameters.Add(New SqlParameter("@Dept_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text").Value = Dept_Text

            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int))
            .Parameters("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Partner_Text").Value = Partner_Text

            .Parameters.Add(New SqlParameter("@Is_Admin", SqlDbType.Int))
            .Parameters("@Is_Admin").Value = Is_Admin

            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
            .Parameters("@Status").Value = Status

            .Parameters.Add(New SqlParameter("@Is_Delete", SqlDbType.Int))
            .Parameters("@Is_Delete").Value = Is_Delete

            .Parameters.Add(New SqlParameter("@Is_Level", SqlDbType.Int))
            .Parameters("@Is_Level").Value = Is_Level

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
            .Parameters("@Description").Value = Description

            Try
                .ExecuteNonQuery()
                retval = .Parameters("@Id").Value
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thêm nhóm account. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Update Group"
    Private Function UpdateGroup(ByVal Group_Text As String, _
                                ByVal Dept_Id As Integer, _
                                ByVal Dept_Text As String, _
                                ByVal Partner_Id As Integer, _
                                ByVal Partner_Text As String, _
                                ByVal Status As Integer, _
                                ByVal Update_Time As String, _
                                ByVal Update_By_Id As Integer, _
                                ByVal Update_By_Text As String, _
                                ByVal Description As String) As Integer
        Dim retval As Integer = 0
        Dim sql As String = "Update System_Group_User Set Group_Text=N'" & Group_Text & "'," & _
       "Dept_Id=N'" & Dept_Id & "'," & _
       "Dept_Text=N'" & Dept_Text & "'," & _
       "Partner_Id=N'" & Partner_Id & "'," & _
       "Partner_Text=N'" & Partner_Text & "'," & _
       "Status=N'" & Status & "'," & _
       "Update_Time=N'" & Update_Time & "'," & _
       "Update_By_Id=N'" & Update_By_Id & "'," & _
       "Update_By_Text=N'" & Update_By_Text & "'," & _
       "Description=N'" & Description & "'" & _
       " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            retval = ViewState(ViewStateInfo.Object_Id)
        Catch ex As Exception
            retval = 0
        End Try
        Return retval
    End Function
#End Region
#Region "Update Channel"
    Private Sub UpdateChannel(ByVal Group_Id As Integer)
        Dim retval As String = ""
        Dim Channel_Id As Integer = 0
        For i As Integer = 0 To Me.CheckBoxListChannel.Items.Count - 1
            If Me.CheckBoxListChannel.Items(i).Selected = True Then
                Channel_Id = Me.CheckBoxListChannel.Items(i).Value
                If InsertChannel(Group_Id, Channel_Id) <> "" Then
                    Me.lblerror.Text = "Lỗi phân kênh cho nhóm !"
                    Exit Sub
                End If
            Else
                Channel_Id = Me.CheckBoxListChannel.Items(i).Value
                If DeleteChannel(Group_Id, Channel_Id) <> "" Then
                    Me.lblerror.Text = "Lỗi phân kênh cho nhóm !"
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Function InsertChannel(ByVal Group_Id As Integer, Channel_Id As Integer) As String
        Dim retval As String = ""
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "System_Insert_Group_Channel"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int))
            .Parameters("@Group_Id").Value = Group_Id

            .Parameters.Add(New SqlParameter("@Channel_Id", SqlDbType.Int))
            .Parameters("@Channel_Id").Value = Channel_Id
            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                retval = ex.Message
            End Try
        End With
        Return retval
    End Function
    Private Function DeleteChannel(ByVal Group_Id As Integer, Channel_Id As Integer) As String
        Dim retval As String = ""
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "System_Delete_Group_Channel"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int))
            .Parameters("@Group_Id").Value = Group_Id

            .Parameters.Add(New SqlParameter("@Channel_Id", SqlDbType.Int))
            .Parameters("@Channel_Id").Value = Channel_Id
            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                retval = ex.Message
            End Try
        End With
        Return retval
    End Function
#End Region
End Class