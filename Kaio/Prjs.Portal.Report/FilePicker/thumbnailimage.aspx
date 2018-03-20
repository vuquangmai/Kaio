<%@ Page %>
<%@ Import Namespace=System.Drawing %>
<%@ Import Namespace=System %>
<%@ Import Namespace=System.Web %>

<html>
<script language="VB" runat="server">

'
' Written by Nguyen Thanh Tung
' nguyenthanhtungtinbk@yahoo.com
' Create thumbnail images on the fly which will double as image conversion (bmp to jpg/gif etc) utility
'

  Sub Page_Load(Sender As Object, E As EventArgs)
	
        Dim orginalimg, thumb As System.Drawing.Image
        Dim FileName As String
        Dim inp As New IntPtr()
        Dim width, height As Integer
        Dim rootpath As String

        rootpath = Server.MapPath("/") ' Get Root Application Folder

        FileName = rootpath & Request.QueryString("FileName") ' Root Folder + FileName
        Try
            orginalimg = orginalimg.FromFile(FileName) ' Fetch User Filename
        Catch
            orginalimg = orginalimg.FromFile(rootpath & "error.gif") ' Fetch error.gif
        End Try

        ' Get width using QueryString.
        If Request.QueryString("width") = Nothing Then
            width = orginalimg.Width  ' Use Orginal Width. 
        ElseIf Request.QueryString("width") = 0 Then  ' Assign default width of 100.
            width = 100
        Else
            width = Request.QueryString("width") ' Use User Specified width.
        End If

        ' Get height using QueryString.
        If Request.QueryString("height") = Nothing Then
            height = orginalimg.Height ' Use Orginal Height.
        ElseIf Request.QueryString("height") = 0 Then ' Assign default height of 100.
            height = 100
        Else
            height = Request.QueryString("height") ' Use User Specified height.
        End If

        thumb = orginalimg.GetThumbnailImage(width, height, Nothing, inp)

        ' Sending Response JPEG type to the browser. 
        Response.ContentType = "image/jpeg"
        thumb.Save(Response.OutputStream, Imaging.ImageFormat.Jpeg)

        ' Disposing the objects.
        orginalimg.Dispose()
        thumb.Dispose()

  End Sub
</script>
</html>
