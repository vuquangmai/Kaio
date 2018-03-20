Imports Novacode
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.Security
Public Class SMSContractCreate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CreateContract("SMS" & DateTime.Parse(Now).ToString("yyyyMMddHHmmss"))
    End Sub
    Private Sub CreateContract(ByVal DocFile As String)
        Dim UrlSuffix As String = Context.Request.Url.Host & Context.Request.PhysicalApplicationPath
        Using CurrentDocument As DocX = DocX.Create(Context.Request.PhysicalApplicationPath & "\Test\" & DocFile & ".docx")
            CurrentDocument.PageLayout.Orientation = Novacode.Orientation.Portrait
            'CurrentDocument.PageWidth = 816.0F
            'CurrentDocument.PageHeight = 1056.0F
            CurrentDocument.MarginTop = 50.0F
            CurrentDocument.MarginRight = 50.0F
            CurrentDocument.MarginBottom = 75.0F
            CurrentDocument.MarginLeft = 60.0F

            CurrentDocument.AddHeaders()
            CurrentDocument.AddFooters()
            CurrentDocument.DifferentFirstPage = True
            CurrentDocument.DifferentOddAndEvenPages = False

            Dim _BoldFormat = New Formatting()
            _BoldFormat.FontFamily = New System.Drawing.FontFamily("Times New Roman")
            _BoldFormat.Size = 12.0
            _BoldFormat.Position = 12 'Khoảng cách giữa các đoạn
            _BoldFormat.Bold = True

            Dim _ItalicFormat = New Formatting()
            _ItalicFormat.FontFamily = New System.Drawing.FontFamily("Times New Roman")
            _ItalicFormat.Size = 12.0
            _ItalicFormat.Position = 12
            _ItalicFormat.Italic = True
            _ItalicFormat.Bold = False

            Dim HeaderText_1 As String = "CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM"
            Dim HeaderText_2 As String = "Độc Lập - Tự Do - Hạnh Phúc"
            Dim HeaderText_3 As String = "------------------------------------------------"
            Dim HeaderText_4 As String = "HỢP ĐỒNG HỢP TÁC THANH TOÁN TRỰC TUYẾN KÊNH SMS PLUS 9029"
            Dim HeaderText_5 As String = "Số: 12072016/TTPTND/VMG-TIENTIEN"

            CurrentDocument.InsertParagraph(HeaderText_1, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_2, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_3, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_4, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_5, False, _BoldFormat).Alignment = Alignment.center
            Dim Title_1 As Paragraph = CurrentDocument.InsertParagraph()
            Title_1.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            Title_1.Append("-" & vbTab & "Căn cứ vào Luật Thương mại của Quốc hội nước CHXHCN Việt Nam số 36/2005/QH11 ngày 14/06/2005, có hiệu lực từ ngày 01/01/2006").FontSize(12).Font(New FontFamily("Times New Roman")).Italic()
            Title_1.AppendLine("-" & vbTab & "Căn cứ vào Bộ Luật dân sự của Quốc hội nước CHXHCN Việt Nam số 36/2005/QH11 ngày 14/06/2005, có hiệu lực từ ngày 01/01/2006").FontSize(12).Font(New FontFamily("Times New Roman")).Italic()
            Title_1.AppendLine("-" & vbTab & "Căn cứ chức năng, nhiệm vụ, khả năng và nhu cầu của các bên.").FontSize(12).Font(New FontFamily("Times New Roman")).Italic()

            ' TitleFormat.Spacing = 1 ' Khoảng cách giữa các chữ
            Dim Title_2 As Paragraph = CurrentDocument.InsertParagraph()
            Title_2.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            Title_2.Append("Hợp đồng Hợp tác thanh toán trực tuyến này (""").FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_2.Append("Hợp Đồng").Bold().FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_2.Append(""") được lập và ký ngày 12 tháng 07 năm 2016 giữa các bên:").FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_2.AppendLine()

            Dim BodyText_1 As String = "1." & vbTab & "CÔNG TY CỔ PHẦN TRUYỀN THÔNG VMG"
            CurrentDocument.InsertParagraph(BodyText_1, False, _BoldFormat).Alignment = Alignment.left

            Dim RowsCount As Integer = 7
            Dim ColumnsCount As Integer = 2
            Dim ColumnWidth_1 As Integer = 300
            Dim ColumnWidth_2 As Integer = 600
            Dim ColumnWidth_3 As Integer = 600

            Dim Table_1 As Table = CurrentDocument.AddTable(RowsCount, ColumnsCount)
            Table_1.Design = TableDesign.TableNormal
            Table_1.Alignment = Alignment.left
            Table_1.SetTableCellMargin(LineSpacingType.Line, 5.5F)
            For Each row As Row In Table_1.Rows
                row.Cells(0).Width = ColumnWidth_1
            Next

            For colIndex As Integer = 1 To ColumnsCount - 1
                'Table_1.InsertColumn(colIndex)
                For Each row As Row In Table_1.Rows
                    row.Cells(colIndex).Width = ColumnWidth_2
                Next
            Next

            Table_1.Rows(0).Cells(0).Paragraphs(0).Append("Địa chỉ").FontSize(12).Font(New FontFamily("Times New Roman"))  '.Spacing(1)  '.Alignment = Alignment.left
            Table_1.Rows(0).Cells(1).Paragraphs(0).Append("Tòa nhà Viễn Đông, 36 Hoàng Cầu, Đống Đa,Hà Nội").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)   '.Alignment = Alignment.left
            Table_1.Rows(1).Cells(0).Paragraphs(0).Append("Điện thoại").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)  '.Alignment = Alignment.left
            Table_1.Rows(1).Cells(1).Paragraphs(0).Append("043 5378820" & vbTab & "Fax: 043 7726091").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)   '.Alignment = Alignment.left
            Table_1.Rows(2).Cells(0).Paragraphs(0).Append("Mã số thuế").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(2).Cells(1).Paragraphs(0).Append("0101883619").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(3).Cells(0).Paragraphs(0).Append("Tài khoản số").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(3).Cells(1).Paragraphs(0).Append("05911.00.490.003").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(4).Cells(0).Paragraphs(0).Append("Mở tại ngân hàng").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(4).Cells(1).Paragraphs(0).Append("TMCP Quận Đội – Chi nhánh Đống Đa").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(5).Cells(0).Paragraphs(0).Append("Người đại diện").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(5).Cells(1).Paragraphs(0).Append("Ông ").Font(New FontFamily("Times New Roman")).FontSize(12).Append("TRẦN BÌNH DƯƠNG").Bold().Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(6).Cells(0).Paragraphs(0).Append("Chức vụ ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_1.Rows(6).Cells(1).Paragraphs(0).Append("Tổng giám đốc").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            CurrentDocument.InsertTable(Table_1)

            Dim BodyText_2 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_2.Append("(Sau đây gọi tắt là """).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Bên A").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append(""")").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_2.AppendLine()
            Dim BodyText_3 As String = "2." & vbTab & "CÔNG TY TNHH CÔNG NGHỆ VÀ SẢN PHẨM TIÊN TIẾN"
            CurrentDocument.InsertParagraph(BodyText_3, False, _BoldFormat).Alignment = Alignment.left

            Dim Table_2 As Table = CurrentDocument.AddTable(RowsCount, ColumnsCount)
            Table_2.Design = TableDesign.TableNormal
            Table_2.Alignment = Alignment.left
            For Each row As Row In Table_2.Rows
                row.Cells(0).Width = ColumnWidth_1
            Next
            For colIndex As Integer = 1 To ColumnsCount - 1
                'Table_2.InsertColumn(colIndex)
                For Each row As Row In Table_2.Rows
                    row.Cells(colIndex).Width = ColumnWidth_2
                Next
            Next
            Table_2.Rows(0).Cells(0).Paragraphs(0).Append("Địa chỉ").FontSize(12).Font(New FontFamily("Times New Roman")) '.Spacing(1)  '.Alignment = Alignment.left
            Table_2.Rows(0).Cells(1).Paragraphs(0).Append("Số 518 đường Trần Cung, Phường Cổ Nhuế 1,Quận Bắc Từ Liêm, TP.Hà Nội").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)   '.Alignment = Alignment.left
            Table_2.Rows(1).Cells(0).Paragraphs(0).Append("Điện thoại").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)  '.Alignment = Alignment.left
            Table_2.Rows(1).Cells(1).Paragraphs(0).Append("(84)916863369" & vbTab & "Fax: ").Font(New FontFamily("Times New Roman")).FontSize(12) '.Spacing(1)   '.Alignment = Alignment.left
            Table_2.Rows(2).Cells(0).Paragraphs(0).Append("Mã số thuế").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(2).Cells(1).Paragraphs(0).Append("0105074792").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(3).Cells(0).Paragraphs(0).Append("Tài khoản số").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(3).Cells(1).Paragraphs(0).Append("0561178666888").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(4).Cells(0).Paragraphs(0).Append("Mở tại ngân hàng").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(4).Cells(1).Paragraphs(0).Append("Ngân hàng TMCP Quân đội, CN Hoàng Quốc Việt").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(5).Cells(0).Paragraphs(0).Append("Người đại diện").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(5).Cells(1).Paragraphs(0).Append("Ông ").Font(New FontFamily("Times New Roman")).FontSize(12).Append("BÙI MẠNH CƯỜNG").Bold().Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(6).Cells(0).Paragraphs(0).Append("Chức vụ ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            Table_2.Rows(6).Cells(1).Paragraphs(0).Append("Giám đốc").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.left
            CurrentDocument.InsertTable(Table_2)

            Dim BodyText_4 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_4.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            BodyText_4.Append("(Sau đây gọi tắt là """).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Bên B").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append(""")").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Sau khi thoả thuận và thống nhất ý kiến, hai bên cùng ký vào Hợp Đồng này với những điều khoản và điều kiện như sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 1" & vbTab & "Giải thích từ ngữ").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.1" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Telcos: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("là các Công ty Viễn thông di động đang hoạt động trên lãnh thổ Việt Nam như Viettel, VinaPhone, MobiFone, Vietnamobile, Gmobile … ").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.2" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("CP: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("là công ty được phép kinh doanh, cung cấp dịch vụ nội dung theo quy định của pháp luật Việt nam;").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.3" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("GTGT: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("là nội dung/dịch vụ giá trị gia tăng cho điện thoại di động được cung cấp tới các thuê bao di động tại Việt Nam;").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.4" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Dịch vụ SMS Plus 9029: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("Dịch vụ Bên A cung cấp Cổng thanh toán cho phép Bên B kết nối tính cước nội dung các dịch vụ  Game và mạng xã hội qua đầu số 9029.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.5" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Khách hàng: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("là thuê bao di động của các nhà mạng tại Việt Nam;").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("1.6" & vbTab).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Doanh thu Dịch vụ: ").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append("là số tiền cước sử dụng dịch vụ mà bên A thực thu được từ Telcos đối với các dịch vụ được cung cấp trên hệ thống dịch vụsms.").FontSize(12).Font(New FontFamily("Times New Roman"))
            Dim BodyText_13 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_4.AppendLine("Điều 2:" & vbTab & "Nội dung hợp tác").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("2.1" & vbTab & "Hai bên nhất trí thoả thuận hợp tác trên cơ sở cùng có lợi để phát triển, tổ chức khai thác và cung cấp các dịch vụ nội dung trên các mạng thông tin di động qua các kênh thanh toán như Dịch vụ SMS Plus 9029 (sau đây gọi tắt là """).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Dịch Vụ SMS Plus").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append(""") phù hợp với quy định của pháp luật Việt Nam của bên A. Chi tiết các kênh hợp tác, kịch bản, cú pháp của từng dịch vụ và mã của các dịch vụ sẽ được ghi trong các phụ lục Hợp đồng kèm theo.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("2.2" & vbTab & "Các quy định cụ thể trong quá trình hợp tác kinh doanh khai thác các Dịch Vụ SMS Plus trên mạng viễn thông di động được quy định cụ thể tại Phụ lục kèm theo là một phần không thể tách rời của hợp đồng này. Phụ lục bao gồm các phần sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("-" & vbTab & "Phụ lục 01: Quy định hợp tác Dịch vụ SMS Plus").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("-" & vbTab & "Phụ lục 02: Danh sách mã hợp tác dịch vụ SMS Plus").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("2.3" & vbTab & "Các hình thức hợp tác khác: Nếu phát sinh các hướng hợp tác khác, hai bên sẽ thỏa thuận và thống nhất với nhau bằng văn bản. Các văn bản thỏa thuận hợp tác mới này sẽ được lập thành Phụ lục hợp đồng và được xem như một phần không thể tách rời của Hợp đồng Hợp tác này.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 3:" & vbTab & "Trách nhiệm và quyền lợi của Bên A").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Bên A có trách nhiệm thực hiện các công việc sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.1" & vbTab & "Xây dựng, triển khai và đảm bảo hoạt động cho các chương trình được cài đặt trên hệ thống của Bên A, bao gồm các chương trình phục vụ cung cấp Dịch Vụ SMS Plus đến khách hàng và các chương trình phục vụ kết nối, trao đổi, cung cấp dữ liệu cho Bên B.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.2" & vbTab & "Viết chương trình xử lý, và duy trì hoạt động của dịch vụ trên máy chủ của bên A đối với những dịch vụ mà bên A được bên B yêu cầu thực hiện.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.3" & vbTab & "Cung cấp các điều kiện cần thiết và hỗ trợ Bên B phát triển Dịch Vụ SMS Plus; thực hiện các kết nối vào hệ thống kỹ thuật của Bên A; xử lý sự cố thuộc hệ thống máy móc, thiết bị của Bên A nhằm cung cấp và đảm bảo chất lượng Dịch Vụ SMS Plus.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.4" & vbTab & "Hỗ trợ với Bên B quảng bá, giới thiệu thông tin Dịch Vụ SMS Plus đến khách hàng. ").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.5" & vbTab & "Đảm bảo các điều kiện khai thác, sử dụng Dịch Vụ SMS Plus cho khách hàng trong phạm vi khả năng và trách nhiệm của Bên A.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.6" & vbTab & "Cung cấp cho bên B các thông số kỹ thuật trong trao đổi thông tin giữa hệ thống của bên A và chương trình xử lý của bên B.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.7" & vbTab & "Đảm bảo bí mật nội dung tin nhắn của khách hàng qua hệ thống dịch vụ sms, mobile web, trừ khi có có yêu cầu khác của cơ quan có thẩm quyền.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.8" & vbTab & "Gửi đối soát cước của bên A, đối soát cước từ các Telco, xác nhận số liệu, tính cước, thu cước từ các công ty thông tin di động và thanh toán cho bên B theo mã nhắn tin, mã thẻ cào và thoại đã thống nhất và theo điều 05 của Hợp đồng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.9" & vbTab & "Đảm bảo chất lượng và duy trì hoạt động ổn định với các nhà cung cấp : Vinaphone, Mobifone, Viettel, ...").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.10" & vbTab & "Cam kết bảo mật các nội dung liên quan đến tập khách hàng của Bên B (không để lộ kho số ra ngoài).").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.11" & vbTab & "Thực hiện chăm sóc khách hàng đối với các Dịch Vụ SMS Plus mà hai bên hợp tác triển khai qua số 19001255.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Bên A có quyền hạn thực hiện các công việc sau").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("3.12" & vbTab & "Được quyền tạm ngưng hợp tác khi phát hiện hệ thống có sự cố hoặc trong thời gian nâng cấp hệ thống.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 4:" & vbTab & "Trách nhiệm và quyền lợi của Bên B").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Bên B có trách nhiệm thực hiện các công việc sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.1" & vbTab & "Phối hợp với bộ phận kỹ thuật của bên A trong việc kết nối, triển khai các Dịch Vụ SMS Plus của bên B.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.2" & vbTab & "Chịu trách nhiệm triển khai các chương trình quảng cáo, quảng bá và giới thiệu cho các Dịch Vụ SMS Plus mà hai bên hợp tác. ").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.3" & vbTab & "Chịu trách nhiệm triển khai và thiết kế Dịch Vụ SMS Plus, phát triển Dịch Vụ SMS Plus và cập nhật nội dung đáp ứng nhu cầu của khách hàng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.4" & vbTab & "Riêng kênh mobile web, đối với từng nội dung hoặc dịch vụ được cập nhật lên phải niêm yết giá rõ ràng ngay cạnh vị trí mà khách hàng sẽ bị trừ tiền khi tao tác vào vị trí đó; thông tin dịch vụ giới thiệu trên wapsite/ứng dụng phải đúng với nội dung mà khách hàng nhận được sau khi mua; nội dung hoặc dịch vụ phải phù hợp với máy điện thoại mà khách hàng đang sử dụng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.5" & vbTab & "Nếu có nhu cầu sử dụng các dịch vụ, nội dung hay kỹ thuật của bên A thì phải thông báo trước 07 ngày cho bên A về các dịch vụ sẽ triển khai để bên A chủ động bố trí nhân sự thực hiện đảm bảo về chất lượng và thời gian.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.6" & vbTab & "Chịu trách nhiệm trước pháp luật về nội dung thông tin được cung cấp qua hệ thống kênh thanh toán của bên A bao gồm: dịch vụ SMS Plus, mobile-web, mobile-wapđảm bảo các nội dung thông tin này là hợp pháp, không trái với đạo đức, thuần phong mỹ tục của Việt Nam và đảm bảo rằng Bên B có quyền sở hữu hoặc sử dụng, cung cấp các thông tin đó một cách hợp pháp. Bên B sẽ chịu mọi trách nhiệm liên quan đến nội dung của thông tin được cung cấp tới khách hang bao gồm nhưng không giới hạn trách nhiệm giải quyết các khiếu nại, yêu cầu của bên thứ ba liên quan đến quyền sở hữu trí tuệ và bất kỳ khiếu nại nào khác đối với nội dung thông tin được cung cấp tới khách hang; bồi thường thiệt hại cho Bên A và/hoặc bên thứ ba (nếu có) do các hành vi vi phạm của mình gây ra.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.7" & vbTab & "Phối hợp với bên A trong việc đối soát và thanh toán hàng tháng theo đúng quy định.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.8" & vbTab & "Cam kết không gửi quảng bá tin nhắn đến các thuê bao di động. Nếu bên B vi phạm và gây hậu quả cho bên A thì bên B có trách nhiệm bồi thường mọi thiệt hại gây ra cho bên A.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.9" & vbTab & "Cung cấp cho bên A các tài liệu hướng dẫn sử dụng Dịch Vụ SMS Plus trước khi tiến hành quảng bá, giới thiệu đến khách hàng. Phối hợp với Bên A thực hiện hỗ trợ và chăm sóc khách hàng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Bên B có quyền  thực hiện các công việc sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.10" & vbTab & "Được cấp tài khoản, mật mã và phân quyền để nắm được báo cáo thống kê và đối soát của dịch vụ  trong phạm vi hợp tác với bên A hàng ngày trên hệ thống.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.11" & vbTab & "Yêu cầu bên A cung cấp các báo cáo thống kê và đối soát sản lượng, doanh thu từ dịch vụ hợp tác của từng tháng sau khi bên A nhận được xác nhận số liệu đối soát từ các nhà khai thác thông tin di động.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.12" & vbTab & "Được phân chia doanh thu theo số lượng tin nhắn theo qui định chi tiết trong Phụ lục I của hợp đồng này.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.13" & vbTab & "Được quyền yêu cầu bên A thực hiện các yêu cầu kỹ thuật về khai báo, mở mã, viết các phần mềm tiếp nhận tin nhắn, xử lý tin nhắn.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.14" & vbTab & "Được bên A hỗ trợ, giải thích cho khách hàng các dịch vụ hợp tác với bên A qua số điện thoại 19001255 khi khách hàng có yêu cầu.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("4.1" & vbTab & "Được quyền yêu cầu bên A thanh toán đúng hạn theo quy định tại phụ lục I hợp đồng sau khi đã có biên bản đối soát cước hàng tháng của hai bên.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 5:" & vbTab & "Giá cước, Đối soát, Phân chia Thu nhập và thanh toán").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("5.1" & vbTab & "Những vấn đề về giá cước, đối soát, phân chia thu nhập và thanh toán từ Dịch Vụ SMS Plus sẽ được thực hiện theo quy định trong Phụ lục dịch vụ cụ thể kèm theo Hợp Đồng này. Tuỳ theo từng giai đoạn, theo nhu cầu của thị trường và các quy định của các cơ quan chức năng, các bên sẽ xây dựng bảng giá cước các Dịch Vụ và cùng nhau thống nhất phương án phân chia lại doanh thu cước dịch vụ.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("5.2" & vbTab & "Khi có bất kỳ sự thay đổi nào liên quan đến giá cước, đối soát, phân chia thu nhập và thanh toán từ Dịch Vụ SMS Plusnhư được đề cập trong các Phụ lục, hai bên sẽ có trách nhiệm thông báo cho nhau ngay lập tức bằng văn bản.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 6:" & vbTab & "Sửa đổi và chấm dứt Hợp đồng").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("6.1" & vbTab & "Hợp Đồng này và các Phụ lục của Hợp Đồng này có thể sửa đổi theo thoả thuận bằng văn bản của các bên và phải được cả 2 bên đồng ý bằng văn bản.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("6.2" & vbTab & "Hợp Đồng này sẽ chấm dứt trong trường hợp sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("a.	Cả hai bên đồng ý chấm dứt Hợp Đồng này; trong trường hợp đó hai bên sẽ thoả thuận về các điều kiện cụ thể liên quan tới việc chấm dứt Hợp Đồng, thỏa thuận chấm dứt họp đồng trước thời hạn phải được thỏa thuận bằng văn bản").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("b.	Việc hợp tác để khai thác dịch vụ khai thác và cung cấp dịch vụ nội dung trên mạng di động không đem lại lợi nhuận cho các bên trong vòng 06 tháng liên tục.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("c.	Bên B cam kết không lợi dụng các chính sách khuyến mại, chính sách khuyến khích bán hàng và các chính sách kinh doanh khác của các Công ty Viễn thông để nhắn tin đến số 9029 nhằm mục đích trục lợi. Bên B cam kết không gửi tin quảng cáo, tin nhắn lừa đảo và Bên B phải có trách nhiệm kiểm soát các bên thứ ba  (như Công ty con, đại lý, đối tác, nhân viên…) không gửi tin nhắn quảng cáo, tin nhắn lừa đảo đến các thuê bao của các Công ty Viễn thông. Nếu không thực hiện đúng Bên B sẽ bị chấm dứt hợp đồng và không được hưởng doanh thu phân chia trong tháng phát sinh hiện tượng lợi dụng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("d.	Nếu Bên A hoặc Bên B không thể thực hiện được nghĩa vụ của mình theo Hợp đồng này vì bên Đối tác có những biện pháp không hợp lý hoặc không thực hiện những nghĩa vụ của mình theo Hợp đồng thì Bên A hoặc Bên B có thể yêu cầu chấm dứt Hợp đồng trước thời hạn bằng việc gửi văn bản báo trước 30 ngày.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("e.	Nếu xảy ra một sự kiện bất khả kháng theo qui định của pháp luật khiến cho một Bên không thể thực hiện được nghĩa vụ của mình theo Hợp đồng này thì Bên đó được hoãn thực hiện nghĩa vụ có liên quan mà không bị coi là vi phạm Hợp đồng và không phải chịu phạt. Nếu sự kiện bất khả kháng tiếp diễn hơn một (01) tháng, mỗi Bên có thể chấm dứt Hợp đồng này bằng việc gửi văn bản thông báo trước 15 ngày cho Bên kia").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 7:" & vbTab & "Bảo mật").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("7.1" & vbTab & "Các bên có trách nhiệm phải giữ kín tất cả những thông tin mà mình nhận được từ phía bên kia trong suốt thời hạn và sau khi hết hạn của Hợp Đồng này tối thiểu là 06 tháng và phải thực hiện mọi biện pháp cần thiết duy trì tính bí mật của thông tin này.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("7.2" & vbTab & "Mỗi bên không được tiết lộ cho bất cứ bên thứ ba nào bất kỳ thông tin nói trên trừ trường hợp được chấp thuận bằng văn bản của hai bên.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("7.3" & vbTab & "Mỗi Bên phải tiến hành mọi biện pháp cần thiết để đảm bảo rằng không một nhân viên nào hay bất cứ ai thuộc sự quản lý của mình sẽ làm điều đó. Các nghĩa vụ nói trên vẫn sẽ kéo dài sau khi hết hạn Hợp Đồng tối thiểu là 06 tháng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 8:" & vbTab & "Giải quyết tranh chấp").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("8.1:" & vbTab & "Bên A được miễn trừ hoàn toàn mọi trách nhiệm liên quan đến các tranh chấp về bản quyền tác giả, sở hữu trí tuệ và các tranh chấp khác có liên quan trong quá trình cung cấp Dịch Vụ SMS Plus. Trong trường hợp phát sinh tranh chấp có liên quan đến việc cung cấp Dịch Vụ SMS Plus,  Bên B chịu trách nhiệm giải quyết tranh chấp và chịu mọi phí tổn liên quan.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("8.2:" & vbTab & "Các Bên cùng có trách nhiệm thực hiện đầy đủ nội dung Hợp Đồng. Mọi tranh chấp phát sinh liên quan đến Hợp Đồng trước hết sẽ được giải quyết thông qua thương lượng giữa các bên. Nếu việc giải quyết không đạt được bằng thương lượng, hòa giải thì một trong các bên có quyền đưa tranh chấp ra giải quyết tại cơ quan nhà nước có thẩm quyền.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 9:" & vbTab & "Thời hạn của Hợp đồng").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Hợp Đồng này có hiệu lực 01 năm kể từ ngày ký. Hợp đồng này sẽ tự động gia hạn và mỗi lần gia hạn sẽ là 01 năm nếu 30 ngày trước khi hết hạn Hợp Đồng, mỗi bên không thông báo cho phía bên kia về ý định chấm dứt Hợp Đồng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 10:" & vbTab & "Tính tổng thể của Hợp Đồng").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Hợp Đồng bao gồm cả các Phụ lục kèm theo, tạo nên một thoả thuận hoàn chỉnh của các bên về vấn đề mà các bên hướng tới và bao gồm những cam đoan, lời hứa, bảo đảm, và những thống nhất giữa các bên về vấn đề này. Mỗi bên trong Hợp Đồng thừa nhận rằng không một cam đoan, lời hứa, hay thoả thuận nào, bằng miệng hay bằng văn bản, do bên kia đưa ra, hoặc do người đại diện thay mặt của bên đó đưa ra, mà không được thể hiện trong Hợp Đồng và các Phụ lục kèm theo, sẽ có ý nghĩa và hiệu lực ràng buộc các bên.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 11:" & vbTab & "Vô hiệu từng phần").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Một điều khoản nào đó của Hợp đồng này vô hiệu sẽ không làm vô hiệu các điều khoản khác trong Hợp đồng này.Nếu xảy ra trường hợp vô hiệu của một hoặc một số điều khoản, Các Bên cam kết sẽ bàn bạc để khắc phục nguyên nhân dẫn đến việc vô hiệu nói trên.Trong trường hợp không thể khắc phục được, Các Bên cam kết sẽ đàm phán trên tinh thần thiện chí để thay thế những điều khoản vô hiệu bằng những điều khoản mới để toàn bộ Hợp đồng tiếp tục có hiệu lực.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Điều 12:" & vbTab & "Điều khoản chung").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("12.1" & vbTab & "Bất khả kháng").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("(a)" & vbTab & "Nếu một trong các bên không thể thực thi được toàn bộ hay một phần nghĩa vụ của mình theo Hợp Đồng này do Sự Kiện Bất Khả Kháng như thiên tai, hoả hoạn, lũ lụt, động đất, chiến tranh, đình công hoặc bạo loạn thì bên đó sẽ phải nhanh chóng thông báo cho bên kia bằng văn bản về việc không thực hiện được nghĩa vụ của mình do Sự Kiện Bất Khả Kháng, và phải thực hiện mọi nỗ lực để hoặc giảm thiểu ảnh hưởng của Sự Kiện Bất Khả Kháng đó.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("(b)" & vbTab & "Khi Sự Kiện Bất Khả Kháng xảy ra, thì nghĩa vụ của các Bên tạm thời không thực hiện và sẽ ngay lập tức phục hồi lại các nghĩa vụ của mình theo Hợp Đồng khi chấm dứt Sự Kiện Bất Khả Kháng hoặc khi Sự Kiện Bất Khả Kháng đó bị loại bỏ.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("12.2" & vbTab & "Thông báo").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("(a)" & vbTab & "Mọi thông báo và thông tin liên lạc chính thức liên quan đến Hợp Đồng này sẽ được gửi tới địa chỉ của các bên như nêu tại phần đầu của hợp đồng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("(b)" & vbTab & "Các bên có thể thay đổi địa chỉ bằng cách gửi thông báo hợp lệ bằng văn bản cho bên kia.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("12.3" & vbTab & "Luật áp dụng").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Việc lập Hợp Đồng này, hiệu lực, giải thích, ký kết và giải quyết tranh chấp phát sinh từ Hợp Đồng này sẽ tuân theo và được giải thích theo pháp luật của Việt Nam.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("12.4" & vbTab & "Luật áp dụng").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Hợp đồng này được lập thành 04 (bốn) bản gốc có giá trị pháp lý như nhau, mỗi bên giữ 02 (hai) bản làm căn cứ thực hiện.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("12.5" & vbTab & "Phạt vi phạm hợp đồng ").FontSize(12).Bold().Font(New FontFamily("Times New Roman"))
            BodyText_4.AppendLine("Hai bên cam kết thực hiện nghiêm túc các qui định của Hợp đồng này và các phụ lục kèm theo. Trong trường hợp bên nào vi phạm sẽ bị phạt, mức phạt tối thiểu là 100.000.000 đồng (một trăm triệu đồng).").FontSize(12).Font(New FontFamily("Times New Roman"))

            Dim Table_3 As Table = CurrentDocument.AddTable(1, 2)
            Table_3.Design = TableDesign.TableNormal
            Table_3.Alignment = Alignment.center
            For Each row As Row In Table_3.Rows
                row.Cells(0).Width = 500
                row.Cells(1).Width = 500
            Next
            Table_3.Rows(0).Cells(0).Paragraphs(0).Append("ĐẠI DIỆN BÊN A").FontSize(12).Font(New FontFamily("Times New Roman")).Bold().Alignment = Alignment.center
            Table_3.Rows(0).Cells(1).Paragraphs(0).Append("ĐẠI DIỆN BÊN B").Font(New FontFamily("Times New Roman")).FontSize(12).Bold().Alignment = Alignment.center
            CurrentDocument.InsertTable(Table_3)
            CurrentDocument.InsertParagraph()

            Dim Table_4 As Table = CurrentDocument.AddTable(1, 2)
            Table_4.Design = TableDesign.TableNormal
            Table_4.Alignment = Alignment.center
            For Each row As Row In Table_4.Rows
                row.Cells(0).Width = 500
                row.Cells(1).Width = 500
            Next
            Table_4.Rows(0).Cells(0).Paragraphs(0).Append("TỔNG GIÁM ĐỐC").FontSize(12).Font(New FontFamily("Times New Roman")).Bold().Alignment = Alignment.center
            Table_4.Rows(0).Cells(1).Paragraphs(0).Append("TỔNG GIÁM ĐỐC").Font(New FontFamily("Times New Roman")).FontSize(12).Bold().Alignment = Alignment.center
            CurrentDocument.InsertTable(Table_4)

            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()

            Dim Table_5 As Table = CurrentDocument.AddTable(1, 2)
            Table_5.Design = TableDesign.TableNormal
            Table_5.Alignment = Alignment.center
            For Each row As Row In Table_5.Rows
                row.Cells(0).Width = 500
                row.Cells(1).Width = 500
            Next
            Table_5.Rows(0).Cells(0).Paragraphs(0).Append("TRẦN BÌNH DƯƠNG").FontSize(12).Font(New FontFamily("Times New Roman")).Bold().Alignment = Alignment.center
            Table_5.Rows(0).Cells(1).Paragraphs(0).Append("%xxx%").Font(New FontFamily("Times New Roman")).FontSize(12).Bold().Alignment = Alignment.center
            CurrentDocument.InsertTable(Table_5)

            Dim Title_3 As Paragraph = CurrentDocument.InsertParagraph()
            Title_3.InsertPageBreakAfterSelf() ' Sang trang mới
            Dim HeaderText_6 As String = "PHỤ LỤC 01"
            Dim HeaderText_7 As String = "QUY ĐỊNH VỀ TIN NHẮN VÀ HÌNH THỨC XỬ LÝ DOANH THU TRỤC LỢI "
            Dim HeaderText_8 As String = "TRÊN MẠNG VMS 9029"
          
            CurrentDocument.InsertParagraph(HeaderText_6, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_7, False, _BoldFormat).Alignment = Alignment.center
            CurrentDocument.InsertParagraph(HeaderText_8, False, _BoldFormat).Alignment = Alignment.center

            Dim Title_4 As Paragraph = CurrentDocument.InsertParagraph()
            Title_4.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            Title_4.Append("(Kèm theo hợp đồng hợp tác số: 12072016/TTPTND/VMG-TIENTIEN-ký ngày12/07/2016 giữa Công ty CP Truyền Thông VMG và Công ty TNHH Công nghệ và sản phẩm tiên tiến)").FontSize(12).Font(New FontFamily("Times New Roman")).Italic()
           
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph(BodyText_1, False, _BoldFormat).Alignment = Alignment.left
            CurrentDocument.InsertTable(Table_1)
            Dim BodyText_5 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_5.Append("(Sau đây gọi tắt là """).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Bên A").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append(""")").FontSize(12).Font(New FontFamily("Times New Roman"))
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph(BodyText_3, False, _BoldFormat).Alignment = Alignment.left
            CurrentDocument.InsertTable(Table_2)
            Dim BodyText_6 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_6.Append("(Sau đây gọi tắt là """).FontSize(12).Font(New FontFamily("Times New Roman")).Append("Bên B").Bold().FontSize(12).Font(New FontFamily("Times New Roman")).Append(""")").FontSize(12).Font(New FontFamily("Times New Roman"))
            Dim BodyText_7 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_7.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            BodyText_7.Append("1." & vbTab & "Quy định về tin nhắn SMS 9029 trên mạng Mobifone").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()
            BodyText_7.AppendLine("-" & vbTab & "Bên B cam kết không thực hiện các giao dịch tin nhắn có nội dung giống hệt nhau (bao gồm số điện thoại, mệnh giá...) trong thời gian 3s. Những tin nhắn này sẽ không được ghi nhận sản lượng về bên B").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("-" & vbTab & "Với mỗi giao dịch, tối đa 100.000 đồng/lần giao dịch và tối đa 500.000 đồng/ngày/thuê bao.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("2." & vbTab & "Doanh thu có dấu hiệu trục lợi là Doanh thu Dịch vụ có đặc điểm sau").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()
            BodyText_7.AppendLine("-" & vbTab & "Doanh thu phát sinh từ SIM trục lợi (đã bao gồm thuế GTGT) từ 100 triệu (một trăm triệu) trở lên và chiếm từ 5% trở lên trên tổng doanh thu cước thu khách hàng trong tháng").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("-" & vbTab & "Trong đó, SIM trục lợi là SIM trả trước thỏa mãn đồng thời các điều kiện sau:").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("+" & vbTab & "Hòa mạng mới trong vòng 92 ngày về trước so với ngày phát sinh số liệu;").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("+" & vbTab & "Thuộc dải sim liên tiếp tương đối (có 05 số IMSI liên tục, có thể cách nhau đến 02 đơn vị);").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("+" & vbTab & "Sử dụng từ 90% đến 100% số tiền phát sinh cước trên tài khoản chính trong tháng đối soát để sử dụng dịch vụ giá trị gia tăng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_7.AppendLine("3." & vbTab & "Doanh thu biến động tăng trưởng bất thường như sau").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()

            ColumnsCount = 3
            RowsCount = 5
            ColumnWidth_1 = 50
            ColumnWidth_2 = 600
            Dim Table_6 As Table = CurrentDocument.AddTable(RowsCount, ColumnsCount)
            Table_6.Design = TableDesign.TableGrid
            Table_6.Alignment = Alignment.center

            Table_6.SetTableCellMargin(LineSpacingType.Line, 5.5F)
            For Each row As Row In Table_6.Rows
                row.Cells(0).Width = ColumnWidth_1
            Next
            For colIndex As Integer = 1 To ColumnsCount - 1
                For Each row As Row In Table_6.Rows
                    row.Cells(colIndex).Width = ColumnWidth_2
                Next
            Next
            Table_6.Rows(0).Cells(0).Paragraphs(0).Append("STT").FontSize(12).Font(New FontFamily("Times New Roman")).Alignment = Alignment.center
            Table_6.Rows(0).Cells(1).Paragraphs(0).Append("Doanh thu phát sinh/tháng (đồng)").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(0).Cells(2).Paragraphs(0).Append("Mức biến động so với tháng trước").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(1).Cells(0).Paragraphs(0).Append("1").FontSize(12).Font(New FontFamily("Times New Roman")).Alignment = Alignment.center
            Table_6.Rows(1).Cells(1).Paragraphs(0).Append("500 triệu < doanh thu ≤ 1 tỷ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(1).Cells(2).Paragraphs(0).Append("≥ 70%").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(2).Cells(0).Paragraphs(0).Append("2").FontSize(12).Font(New FontFamily("Times New Roman")).Alignment = Alignment.center
            Table_6.Rows(2).Cells(1).Paragraphs(0).Append("1 tỷ < doanh thu ≤ 3 tỷ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(2).Cells(2).Paragraphs(0).Append("≥ 50%").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(3).Cells(0).Paragraphs(0).Append("3").FontSize(12).Font(New FontFamily("Times New Roman")).Alignment = Alignment.center
            Table_6.Rows(3).Cells(1).Paragraphs(0).Append("3 tỷ < doanh thu ≤ 5 tỷ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(3).Cells(2).Paragraphs(0).Append("≥ 25%").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(4).Cells(0).Paragraphs(0).Append("4").FontSize(12).Font(New FontFamily("Times New Roman")).Alignment = Alignment.center
            Table_6.Rows(4).Cells(1).Paragraphs(0).Append("Doanh thu > 5 tỷ").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            Table_6.Rows(4).Cells(2).Paragraphs(0).Append("≥ 15%").Font(New FontFamily("Times New Roman")).FontSize(12).Alignment = Alignment.center
            CurrentDocument.InsertTable(Table_6)
            Dim BodyText_8 As Paragraph = CurrentDocument.InsertParagraph()
            BodyText_8.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            BodyText_8.AppendLine("4." & vbTab & "Xử lý doanh thu có dấu hiệu trục lợi").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()
            BodyText_8.AppendLine("-" & vbTab & "Bên A sẽ thông báo cho Bên B bằng văn bản về việc Dịch Vụ phát sinh doanh thu có dấu hiệu trục lợi (nếu có). ").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("-" & vbTab & "Các Bên thống nhất không phân chia doanh thu phát sinh từ SIM trục lợi. ").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("-" & vbTab & "Trường hợp có doanh thu tăng trưởng bất thường, Bên B phải cung cấp cho Bên A đầy đủ thông tin về nguyên nhân tăng trưởng doanh thu theo yêu cầu của Bên A; Trường hợp Bên B không cung cấp thông tin hoặc cung cấp thông tin không đúng thời hạn, Bên A có quyền không đối soát, thanh toán tháng phát sinh doanh thu tăng trưởng bất thường").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("-" & vbTab & "Nguồn số liệu từ các hệ thống của Bên A là cơ sở để xác định doanh thu trục lợi.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("-" & vbTab & "Nếu Dịch vụ liên tục phát sinh doanh thu trục lợi, Bên A có quyền đơn phương chấm dứt Hợp đồng.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("Các quy định trên có thể được thay đổi và phải được sự đồng ý của hai bên.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine("Phụ lục này có hiệu lực kể từ ngày 12 Tháng 07 năm 2016.Phụ lục này được lập thành 04 bản có giá trị như nhau, mỗi bên giữ 02 bản.").FontSize(12).Font(New FontFamily("Times New Roman"))
            BodyText_8.AppendLine()
            CurrentDocument.InsertTable(Table_3)
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertTable(Table_4)

            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()
            CurrentDocument.InsertParagraph()

            CurrentDocument.InsertTable(Table_5)


            Dim ms2 As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim document2 As DocX = DocX.Create(ms2)
            document2.PageLayout.Orientation = Novacode.Orientation.Portrait
            'document2.PageWidth = 1056.0F
            'document2.PageHeight = 816.0F
            document2.MarginTop = 50.0F
            document2.MarginRight = 50.0F
            document2.MarginBottom = 75.0F
            document2.MarginLeft = 50.0F
            Dim HeaderText_9 As String = "PHỤ LỤC 02"
            Dim HeaderText_10 As String = "QUY ĐỊNH PHÂN CHIA DOANH THU, THANH TOÁN VÀ ĐỐI SOÁT"
            document2.InsertParagraph(HeaderText_9, False, _BoldFormat).Alignment = Alignment.center
            document2.InsertParagraph(HeaderText_10, False, _BoldFormat).Alignment = Alignment.center
            Dim Title_5 As Paragraph = document2.InsertParagraph()
            Title_5.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            Title_5.Append("(Kèm theo hợp đồng hợp tác số: 12072016/TTPTND/VMG-TIENTIEN -ký ngày 12/07/2016 giữa Công ty CP Truyền Thông VMG và Công ty TNHH Công nghệ và sản phẩm tiên tiến)").FontSize(12).Font(New FontFamily("Times New Roman")).Italic()
            document2.InsertParagraph()
            Dim Title_6 As Paragraph = document2.InsertParagraph()
            Title_6.SetLineSpacing(LineSpacingType.Line, 1.5F) ' Khoảng cách giữa các line
            Title_6.Append("I." & vbTab & "NGUYÊN TẮC CHUNG").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()
            Title_6.AppendLine("-" & vbTab & "Các khoản chi phí đầu tư máy móc, trang thiết bị cần thiết tại bên nào thì bên đó chịu.").FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_6.AppendLine("-" & vbTab & "Bên A chịu trách nhiệm hoàn toàn các khoản chi phí liên quan đến việc xây dựng và phát triển dịch vụ").FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_6.AppendLine("-" & vbTab & "Các chi phí phát sinh trong quá trình điều hành tại bên nào sẽ do bên đó tự chịu. Riêng đối với các chi phí phát sinh do giải quyết tranh chấp, khiếu kiện của khách hàng sử dụng dịch vụ sẽ do hai bên cùng xem xét giải quyết theo nguyên tắc: sai sót ở bên nào sẽ do bên đó chịu trách nhiệm.").FontSize(12).Font(New FontFamily("Times New Roman"))
            Title_6.AppendLine("II." & vbTab & "PHÂN CHIA DOANH THU CƯỚC").FontSize(12).Font(New FontFamily("Times New Roman")).Bold()

            document2.Save()
            CurrentDocument.InsertSection()
            CurrentDocument.InsertDocument(document2)

            CurrentDocument.Save()
        End Using
    End Sub
   
End Class