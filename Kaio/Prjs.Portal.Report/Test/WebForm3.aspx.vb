Imports System.IO

Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If True Then
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=WordDocument.doc")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-word "
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim HTMLdata As String = "<HTML><HEAD></HEAD><BODY>CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM" & _
"Độc Lập - Tự Do - Hạnh Phúc" & _
"------------------------------------------------" & _
"HỢP ĐỒNG HỢP TÁC THANH TOÁN TRỰC TUYẾN KÊNH SMS PLUS 9029" & _
"Số: 12072016/TTPTND/VMG-TIENTIEN" & _
"-	Căn cứ vào Luật Thương mại của Quốc hội nước CHXHCN Việt Nam số 36/2005/QH11 ngày 14/06/2005, có hiệu lực từ ngày 01/01/2006" & _
"-	Căn cứ vào Bộ Luật dân sự của Quốc hội nước CHXHCN Việt Nam số 36/2005/QH11 ngày 14/06/2005, có hiệu lực từ ngày 01/01/2006" & _
"-	Căn cứ chức năng, nhiệm vụ, khả năng và nhu cầu của các bên." & _
"Hợp đồng Hợp tác thanh toán trực tuyến này (""Hợp Đồng"") được lập và ký ngày 12 tháng07năm 2016 giữa các bên:" & _
"<BR><B style=""color:red"">ITs WORKING! " & "<table border='2'>" & "<tr><TH>NAME</TH><TH>AGE</TH></tr>" & "<tr><TD>SAM</TD><TD>26</TD></tr>" & "<tr><TD>JOE</TD><TD>36</TD></tr>" & "</table>" & "</B></BODY></HTML>"
            hw.Write(HTMLdata)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()

        End If

    End Sub

End Class