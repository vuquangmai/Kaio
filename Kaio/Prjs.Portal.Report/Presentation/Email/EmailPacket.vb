Imports System.Xml.Xsl
Imports System.Xml
Imports System.Net.Mail
Imports System.Xml.XPath
Imports System.IO
Imports System.Net
Public Class EmailPacket
#Region "Member"

    Private strBcc As String = String.Empty
    Private strBody As String = String.Empty
    Private strCc As String = String.Empty
    Private strEmailTemplate As String = String.Empty
    Private strFrom As String = String.Empty
    Private strFromAlias As String = String.Empty
    Private strSubject As String = String.Empty
    Private strTo As String = String.Empty

#End Region
#Region "Properties"

    Public Property Subject() As String
        Get
            Return strSubject
        End Get
        Set(ByVal value As String)
            strSubject = value
        End Set
    End Property

    Public Property Body() As String
        Get
            Return strBody
        End Get
        Set(ByVal value As String)
            strBody = value
        End Set
    End Property

    Public Property From() As String
        Get
            Return strFrom
        End Get
        Set(ByVal value As String)
            strFrom = value
        End Set
    End Property

    Public Property FromAlias() As String
        Get
            Return strFromAlias
        End Get
        Set(ByVal value As String)
            strFromAlias = value
        End Set
    End Property

    Public Property [To]() As String
        Get
            Return strTo
        End Get
        Set(ByVal value As String)
            strTo = value
        End Set
    End Property

    Public Property Bcc() As String
        Get
            Return strBcc
        End Get
        Set(ByVal value As String)
            strBcc = value
        End Set
    End Property

    Public Property Cc() As String
        Get
            Return strCc
        End Get
        Set(ByVal value As String)
            strCc = value
        End Set
    End Property

    Public Property emailTemplate() As String
        Get
            Return strEmailTemplate
        End Get
        Set(ByVal value As String)
            strEmailTemplate = value
        End Set
    End Property

#End Region
#Region "Method"
    Public Function sendEmail(ByVal objDictionary As IDictionary) As Boolean
        'XslTransform objXslt = new XslTransform(); 
        Dim objXslt As New XslCompiledTransform()
        objXslt.Load(strEmailTemplate)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.AppendChild(xmlDoc.CreateElement("EmailMessage"))
        Dim xpathNav As XPathNavigator = xmlDoc.CreateNavigator()

        Dim xslArg As New XsltArgumentList()
        If objDictionary IsNot Nothing Then
            For Each entry As DictionaryEntry In objDictionary
                xslArg.AddParam(entry.Key.ToString(), "", entry.Value)
            Next
        End If

        Dim emailBuilder As New StringBuilder()
        Dim xmlWriter As New XmlTextWriter(New StringWriter(emailBuilder))

        'objXslt.Transform(xpathNav, xslArg, xmlWriter, null); 
        objXslt.Transform(xpathNav, xslArg, xmlWriter)

        Dim bodyText As String

        Dim emailDoc As New XmlDocument()
        emailDoc.LoadXml(emailBuilder.ToString())
        Dim bodyNode As XmlNode = emailDoc.SelectSingleNode("//html")
        bodyText = HttpUtility.HtmlDecode(bodyNode.InnerXml)
        'bodyText = bodyNode.InnerXml; 

        Return sendEmail(strSubject, bodyText)
    End Function

    Private Function sendEmail(ByVal subjectText As String, ByVal bodyText As String) As Boolean
        'Builed The MSG 
        Dim msg As New MailMessage()
        msg.To.Add([To])
        If ConfigurationManager.AppSettings("EmailBCC") <> "" Then
            msg.Bcc.Add(Bcc)
        End If
        If ConfigurationManager.AppSettings("EmailCC") <> "" Then
            msg.CC.Add(Cc)
        End If
        msg.From = New MailAddress(ConfigurationManager.AppSettings("SystemEmail"), ConfigurationManager.AppSettings("SystemEmailAlias"), Encoding.UTF8)
        msg.Subject = subjectText
        msg.SubjectEncoding = Encoding.UTF8
        msg.Body = bodyText
        msg.BodyEncoding = Encoding.UTF8
        msg.IsBodyHtml = True
        msg.Priority = MailPriority.Normal
        'Add the Creddentials 
        Dim client As New SmtpClient()
        client.Credentials = New NetworkCredential(ConfigurationManager.AppSettings("SystemEmail"), ConfigurationManager.AppSettings("SystemEmailPasword"))
        client.Port = ConfigurationManager.AppSettings("SMTPMailServerPort")
        client.Host = ConfigurationManager.AppSettings("SMTPMailServer")
        client.EnableSsl = True ' ConfigurationManager.AppSettings("SMTPMailServerSecure")
        Try
            client.Send(msg)
        Catch ex As SmtpException
            LogService.WriteLog(Constants.LogLevel._Error, "Error sending e-mail. Code:  " & ex.Message)
            Return False
        End Try
        Return True
    End Function
#End Region
End Class
