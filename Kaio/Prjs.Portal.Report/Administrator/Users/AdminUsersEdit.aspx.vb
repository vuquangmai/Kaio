Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Public Class AdminUsersEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN ACCOUNT"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                    Me.lbltitle.Text = "THÊM THÔNG TIN ACCOUNT"
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Me.btnDelete.Visible = False
                Me.btnResetPassWord.Visible = False
            End If
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Group_User Where Status=1 And Is_Delete=0 Order by Group_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListGroup_Id.Items.Clear()
        Me.DropDownListGroup_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListGroup_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListGroup_Id.Items.Add(New ListItem(dt.Rows(i).Item("Group_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
   
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM System_Users Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtUser_Name.Text = dt.Rows(0).Item("User_Name")
            Me.txtFull_Name.Text = dt.Rows(0).Item("Full_Name")
            Me.DropDownListGroup_Id.SelectedValue = dt.Rows(0).Item("Group_Id")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.txtEmail.Text = IIf(IsDBNull(dt.Rows(0).Item("Email")) = True, "", dt.Rows(0).Item("Email"))
            Me.txtTelephone.Text = IIf(IsDBNull(dt.Rows(0).Item("Telephone")) = True, "", dt.Rows(0).Item("Telephone"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtUser_Name.Text = "" Then
            Me.lblerror.Text = "Tên đăng nhập không hợp lệ !"
            Exit Sub
        End If
        If Me.txtFull_Name.Text = "" Then
            Me.lblerror.Text = "Tên đầy đủ không hợp lệ !"
            Exit Sub
        End If
        'If Me.txtPass_Word.Text = "" Then
        '    Me.lblerror.Text = "Mật khẩu không hợp lệ !"
        '    Exit Sub
        'End If
        If Me.DropDownListGroup_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Nhóm không hợp lệ !"
            Exit Sub
        End If
        Dim Root_Id As Integer = CurrentUser.UserLevel
        Dim User_Name As String = Me.txtUser_Name.Text.Trim
        Dim IsPassWord As String = Util.Randomize.RandomString
        Dim Pass_Word As String = FormsAuthentication.HashPasswordForStoringInConfigFile(IsPassWord, Constants.Encrypt.Encrypt_MD5)
        Dim Full_Name As String = Me.txtFull_Name.Text.Trim
        Dim Group_Id As Integer = Me.DropDownListGroup_Id.SelectedItem.Value
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Email As String = Me.txtEmail.Text.Trim
        Dim Telephone As String = Me.txtTelephone.Text.Trim
        Dim Last_Login As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Is_Delete As Integer = 0
        Dim Is_Level As Integer = CurrentUser.UserLevel + 1
        Dim Is_Login As Integer = ConfigurationManager.AppSettings("LoginNumber")
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  System_Users  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And User_Name=N'" & User_Name & "'"
        Dim User_Id As Integer = 0
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                User_Id = InsertUser(Root_Id, User_Name, Pass_Word, Full_Name, Group_Id, Status, Email, Telephone, Last_Login, Is_Delete, Is_Level, Is_Login, Create_By_Id, Create_By_Text, Create_Time, Update_By_Id, Update_By_Text, Update_Time, Description)
                If User_Id > 0 Then
                    If SentEmail(IsPassWord) = "" Then
                        RedirectUrl(Constants.Url._Admin.AdminUsersList)
                    Else
                        Me.lblerror.Text = "Lỗi gửi e-mail !"
                    End If
                Else
                    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
                End If
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                Pass_Word = ""
                User_Id = UpdateUser(ViewState(ViewStateInfo.Object_Id), Root_Id, User_Name, Pass_Word, Full_Name, Group_Id, Status, Email, Telephone, Last_Login, Is_Delete, Is_Level, Is_Login, Update_By_Id, Update_By_Text, Update_Time, Description)
                If User_Id > 0 Then
                    RedirectUrl(Constants.Url._Admin.AdminUsersList)
                Else
                    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
                End If
            End If
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminUrlList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Update System_Users Set Is_Delete=1 " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminUsersList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
    Protected Sub btnResetPassWord_Click(sender As Object, e As EventArgs) Handles btnResetPassWord.Click
        Dim IsPassWord As String = Util.Randomize.RandomString
        Dim Pass_Word As String = FormsAuthentication.HashPasswordForStoringInConfigFile(IsPassWord, Constants.Encrypt.Encrypt_MD5)
        Dim sql As String = "Update System_Users Set Pass_Word='" & Pass_Word & "'" & _
                                   " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

            If SentEmail(IsPassWord) = "" Then
                Me.lblerror.Text = "Mật khẩu đã được thay đổi !"
            Else
                Me.lblerror.Text = "Lỗi thao tác dữ liệu !"
            End If
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub

#End Region
#Region "Insert User"
    Private Function InsertUser(ByVal Root_Id As Integer, _
                     ByVal User_Name As String, _
                     ByVal Pass_Word As String, _
                     ByVal Full_Name As String, _
                     ByVal Group_Id As Integer, _
                     ByVal Status As Integer, _
                     ByVal Email As String, _
                     ByVal Telephone As String, _
                     ByVal Last_Login As String, _
                     ByVal Is_Delete As Integer, _
                     ByVal Is_Level As Integer, _
                     ByVal Is_Login As Integer, _
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
            .CommandText = "System_Insert_Users"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters("@Id").Direction = ParameterDirection.Output

            .Parameters.Add(New SqlParameter("@Root_Id", SqlDbType.Int))
            .Parameters("@Root_Id").Value = Root_Id

            .Parameters.Add(New SqlParameter("@User_Name", SqlDbType.NVarChar, 50))
            .Parameters("@User_Name").Value = User_Name

            .Parameters.Add(New SqlParameter("@Pass_Word", SqlDbType.NVarChar, 250))
            .Parameters("@Pass_Word").Value = Pass_Word

            .Parameters.Add(New SqlParameter("@Full_Name", SqlDbType.NVarChar, 250))
            .Parameters("@Full_Name").Value = Full_Name

            .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int))
            .Parameters("@Group_Id").Value = Group_Id

            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
            .Parameters("@Status").Value = Status

            .Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, 250))
            .Parameters("@Email").Value = Email

            .Parameters.Add(New SqlParameter("@Telephone", SqlDbType.NVarChar, 250))
            .Parameters("@Telephone").Value = Telephone

            .Parameters.Add(New SqlParameter("@Last_Login", SqlDbType.NVarChar, 500))
            .Parameters("@Last_Login").Value = Last_Login

            .Parameters.Add(New SqlParameter("@Is_Delete", SqlDbType.Int))
            .Parameters("@Is_Delete").Value = Is_Delete

            .Parameters.Add(New SqlParameter("@Is_Level", SqlDbType.Int))
            .Parameters("@Is_Level").Value = Is_Level

            .Parameters.Add(New SqlParameter("@Is_Login", SqlDbType.Int))
            .Parameters("@Is_Login").Value = Is_Login

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
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Update Users"
    Private Function UpdateUser(ByVal Id As Integer, _
                   ByVal Root_Id As Integer, _
                   ByVal User_Name As String, _
                   ByVal Pass_Word As String, _
                   ByVal Full_Name As String, _
                   ByVal Group_Id As Integer, _
                   ByVal Status As Integer, _
                   ByVal Email As String, _
                   ByVal Telephone As String, _
                   ByVal Last_Login As String, _
                   ByVal Is_Delete As Integer, _
                   ByVal Is_Level As Integer, _
                   ByVal Is_Login As Integer, _
                   ByVal Update_By_Id As Integer, _
                   ByVal Update_By_Text As String, _
                   ByVal Update_Time As String, _
                   ByVal Description As String) As String
        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "System_Update_Users"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters("@Id").Value = Id

            .Parameters.Add(New SqlParameter("@Root_Id", SqlDbType.Int))
            .Parameters("@Root_Id").Value = Root_Id

            .Parameters.Add(New SqlParameter("@User_Name", SqlDbType.NVarChar, 50))
            .Parameters("@User_Name").Value = User_Name

            .Parameters.Add(New SqlParameter("@Pass_Word", SqlDbType.NVarChar, 250))
            .Parameters("@Pass_Word").Value = Pass_Word

            .Parameters.Add(New SqlParameter("@Full_Name", SqlDbType.NVarChar, 250))
            .Parameters("@Full_Name").Value = Full_Name

            .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int))
            .Parameters("@Group_Id").Value = Group_Id

            .Parameters.Add(New SqlParameter("@Status", SqlDbType.Int))
            .Parameters("@Status").Value = Status

            .Parameters.Add(New SqlParameter("@Email", SqlDbType.NVarChar, 250))
            .Parameters("@Email").Value = Email

            .Parameters.Add(New SqlParameter("@Telephone", SqlDbType.NVarChar, 250))
            .Parameters("@Telephone").Value = Telephone

            .Parameters.Add(New SqlParameter("@Last_Login", SqlDbType.NVarChar, 500))
            .Parameters("@Last_Login").Value = Last_Login

            .Parameters.Add(New SqlParameter("@Is_Delete", SqlDbType.Int))
            .Parameters("@Is_Delete").Value = Is_Delete

            .Parameters.Add(New SqlParameter("@Is_Level", SqlDbType.Int))
            .Parameters("@Is_Level").Value = Is_Level

            .Parameters.Add(New SqlParameter("@Is_Login", SqlDbType.Int))
            .Parameters("@Is_Login").Value = Is_Login

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
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Send Email"
    Private Function SentEmail(ByVal vPassWord As String) As String
        Dim vEmail As String = Me.txtEmail.Text.Trim
        Dim vFullName As String = "Dear <b>" & Me.txtFull_Name.Text.Trim & ",</b>"
        Dim vUrl As String = "http://" & Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & "/index.aspx" ' Request.ServerVariables("URL")
        Dim vContent As String = "Thông tin truy cập hệ thống báo cáo - Kaio Report: <br>" & _
        "<li>Tên đăng nhập: " & Me.txtUser_Name.Text.Trim & "</li>" & _
        "<li>Họ tên: " & Me.txtFull_Name.Text.Trim & "</li>" & _
        "<li>Địa chỉ e-mail: " & Me.txtEmail.Text.Trim & "</li>" & _
        "<li>Điện thoại: " & Me.txtTelephone.Text.Trim & "</li>" & _
        "<li>Mật khẩu: " & vPassWord & "</li>" & _
        "<li>Địa chỉ truy cập: " & vUrl & "</li>" & _
        "<br>" & _
         "<br>" & _
         " <i>Đây là email tự động, vui lòng không gửi thư vào địa chỉ này. Mọi vướng mắc liên quan đến hệ thống hãy liên hệ:</i>" & _
         " <li>Phòng Đối Soát Tính Cước - Kaio</li>" & _
         " <li>Điện thoại: 84-4-33578820. Ext 732 </li>" & _
         " <li>E-mail: support@vmgmedia.vn</li>" & _
         "<br>" & _
        "------------------------------------------------------------------"
        Util.DoStuff()
        If EmailData.Sent2Account(vEmail, vFullName, vContent) = False Then
            LogService.WriteLog(Constants.LogLevel._Debug, "Lỗi gửi e-mail")
            Return "Lỗi gửi e-mail"
        Else
            Return ""
        End If

    End Function
#End Region

End Class