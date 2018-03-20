Public Class UserProfile
    Inherits GlobalPage

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            Me.lbltitle.Text = "THÔNG TIN CÁ NHÂN"
        End If
    End Sub
#End Region
#Region "Submit"
    Protected Sub btnResetPassWord_Click(sender As Object, e As EventArgs) Handles btnResetPassWord.Click
        Dim OldPass_Word As String = FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtOld_PassWord.Text.Trim, Constants.Encrypt.Encrypt_MD5)
        If OldPass_Word.ToLower <> CurrentUser.UserPassword.ToLower Then
            Me.lblerror.Text = "Mật khẩu cũ không đúng !"
            Exit Sub
        End If
        If Me.txtNew_PassWord.Text.Trim <> Me.txtReType_PassWord.Text.Trim Then
            Me.lblerror.Text = "Mật khẩu hai lần nhập không giống nhau !"
            Exit Sub
        End If
        Dim New_Pass_Word As String = FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtNew_PassWord.Text.Trim, Constants.Encrypt.Encrypt_MD5)
        Try
            CurrentUser.UserPassword = New_Pass_Word
            If SentEmail(Me.txtNew_PassWord.Text.Trim) = "" Then
                Me.lblerror.Text = "Mật khẩu đã được thay đổi !"
                Me.txtNew_PassWord.Text = ""
                Me.txtOld_PassWord.Text = ""
                Me.txtReType_PassWord.Text = ""
            Else
                Me.lblerror.Text = "Lỗi thay đổi mật khẩu. Hãy liên hệ với người quản trị hệ thống !"
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Show PassWord"
    Protected Sub CheckBoxShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowPass.CheckedChanged
        If Me.CheckBoxShowPass.Checked = True Then
            Me.txtNew_PassWord.TextMode = TextBoxMode.SingleLine
            Me.txtReType_PassWord.TextMode = TextBoxMode.SingleLine
        Else
            Me.txtNew_PassWord.TextMode = TextBoxMode.Password
            Me.txtReType_PassWord.TextMode = TextBoxMode.Password
        End If
    End Sub
#End Region
#Region "Send Email"
    Private Function SentEmail(ByVal vPassWord As String) As String
        Dim vEmail As String = CurrentUser.UserEmail
        Dim vFullName As String = "Dear <b>" & Me.CurrentUser.UserFullName & ",</b>"
        Dim vUrl As String = "http://" & Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & "/index.aspx" ' Request.ServerVariables("URL")
        Dim vContent As String = "Thông tin truy cập hệ thống báo cáo - Kaio Report: <br>" & _
        "<li>Tên đăng nhập: " & CurrentUser.UserName & "</li>" & _
        "<li>Họ tên: " & CurrentUser.UserFullName & "</li>" & _
        "<li>Địa chỉ e-mail: " & CurrentUser.UserEmail & "</li>" & _
        "<li>Điện thoại: " & CurrentUser.UserPhone & "</li>" & _
        "<li>Mật khẩu mới " & vPassWord & "</li>" & _
        "<li>Địa chỉ truy cập: " & vUrl & "</li>" & _
        "<br>" & _
         "<br>" & _
         " <i>Đây là email tự động, vui lòng không gửi thư vào địa chỉ này. Mọi vướng mắc liên quan đến hệ thống hãy liên hệ:</i>" & _
         " <li>Phòng Đối Soát Tính Cước - Kaio</li>" & _
         " <li>Điện thoại: 84-4-33578820. Ext 732 </li>" & _
         " <li>E-mail: support@vmgmedia.vn</li>" & _
         "<br>" & _
        "------------------------------------------------------------------"
        If EmailData.Sent2Account(vEmail, vFullName, vContent) = False Then
            LogService.WriteLog(Constants.LogLevel._Debug, "Lỗi gửi e-mail")
            Return "Lỗi gửi e-mail"
        Else
            Return ""
        End If

    End Function
#End Region
End Class