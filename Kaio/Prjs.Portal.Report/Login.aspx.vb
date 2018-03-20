Public Class Login
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Session.RemoveAll()
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim vHttpCookie As HttpCookie
        Dim vCurrentUser As UserInfo
        Dim vCurrentChannel As ChannelInfo

        If Me.txtUserName.Text.Trim = "" Then
            Me.lblinfo.Text = "Tên đăng nhập không hợp lệ !"
            Return
        End If
        If Me.txtPassword.Text.Trim = "" Then
            Me.lblinfo.Text = "Mật khẩu đăng nhập không hợp lệ !"
            Return
        End If

        'If Util.IsRegexInfo(Constants.Regex.vPattern_None_Aphabet, Me.txtUserName.Text.Trim) Then
        '    Me.lblinfo.Text = "Tên đăng nhập không hợp lệ !"
        '    Return
        'Else
        vCurrentUser = New UserInfo(txtUserName.Text.Trim(), FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtPassword.Text.Trim, Constants.Encrypt.Encrypt_MD5))
        If vCurrentUser.IsAccess = Constants.PrivilegesSystems.IsSignIn Then
            FormsAuthentication.SignOut()
            If Me.ckRemember.Checked = True Then
                vHttpCookie = New HttpCookie("USER_NAME", Me.txtUserName.Text.Trim)
                vHttpCookie.Expires = DateTime.Now.AddYears(100)
                Response.Cookies.Set(vHttpCookie)
                vHttpCookie = New HttpCookie("PASS_WORD", Me.txtPassword.Text.Trim)
                vHttpCookie.Expires = DateTime.Now.AddYears(100)
                Response.Cookies.Set(vHttpCookie)
            End If
            If (vCurrentUser.IsAuthenticate(vCurrentUser.UserStatus)) Then
                If (vCurrentUser.IsAuthenticate(vCurrentUser.GroupStatus)) Then
                    Session(SessionInfo.UserInfo.Current_User) = vCurrentUser
                    Dim sql As String = "Update System_Users SET Last_Login=getdate() Where Id=" & vCurrentUser.UserId
                    Try
                        MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    Catch ex As Exception

                    End Try
                    vCurrentChannel = New ChannelInfo(vCurrentUser.GroupId)
                    Session(SessionInfo.UserInfo.Channel_User) = vCurrentChannel

                    Response.Redirect(Constants.Url._Global.Index, True)
                Else
                    lblinfo.Text = "Nhóm tài khoản đã bị khóa !"
                    Return
                End If
            Else
                lblinfo.Text = "Tài khoản đã bị khóa !"
                Return
            End If
        Else
            Me.lblinfo.Text = "Tài khoản không tồn tại hoặc mật khẩu không đúng !"
            Return
        End If
        'End If
    End Sub
End Class