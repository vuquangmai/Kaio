Public Class EmailData
    Public Shared Function Sent2Account(ByVal strMailto As String, ByVal strFullname As String, ByVal strContent As String) As Boolean
        Dim objEmail As New EmailPacket()
        objEmail.Subject = ConfigurationManager.AppSettings("Subject")
        objEmail.[To] = strMailto
        objEmail.Bcc = ConfigurationManager.AppSettings("EmailBCC")
        objEmail.Cc = ConfigurationManager.AppSettings("EmailCC")

        objEmail.emailTemplate = HttpContext.Current.Server.MapPath(Constants.Templates.Email.UserInformation)
        'Build mail 
        Dim hst As New Hashtable()
        hst.Add("fullname", strFullname)
        hst.Add("content", strContent)
        Return objEmail.sendEmail(hst)
    End Function
    Public Shared Function AlertSMSDeclare(ByVal strSubject As String, ByVal strMailTo As String, ByVal strMailCC As String, ByVal strContent As String) As Boolean
        Dim objEmail As New EmailPacket()
        objEmail.Subject = strSubject
        objEmail.[To] = strMailTo
        objEmail.Bcc = ConfigurationManager.AppSettings("EmailBCC")
        objEmail.Cc = strMailCC

        objEmail.emailTemplate = HttpContext.Current.Server.MapPath(Constants.Templates.Email.UserInformation)
        'Build mail 
        Dim hst As New Hashtable()
        hst.Add("fullname", "Dear all,")
        hst.Add("content", strContent)
        Return objEmail.sendEmail(hst)
    End Function
End Class
