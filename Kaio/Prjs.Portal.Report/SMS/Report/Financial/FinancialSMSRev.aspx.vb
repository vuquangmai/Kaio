Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Xml.Xsl
Imports System.Xml
Public Class FinancialSMSRev
    Inherits GlobalPage
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU LŨY KẾ DỊCH VỤ SMS MO"
            BindYear()
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindYear()

        Me.DropDownListYear.Items.Clear()
        For i As Integer = Now.AddYears(-1).Year To Now.AddYears(10).Year
            Me.DropDownListYear.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListYear.SelectedValue = Now.AddMonths(-1).Year
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            CreateFile()
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xử lý dữ liệu !"
            Me.lblFileDownload.Text = ""
        End Try
    End Sub
#End Region
#Region "Create File Download"
    Private Sub CreateFile()
        Dim ShortCode As String = Me.DropDownListShortCode.SelectedItem.Text
        Dim RangShortCode As String = Me.DropDownListShortCode.SelectedItem.Value
        Dim Year As String = Me.DropDownListYear.SelectedItem.Value

        Dim sql As String = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "' And Mobile_Operator='VIETTEL'"
        Dim dtViettel As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "' And Mobile_Operator='VMS'"
        Dim dtVMS As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "' And Mobile_Operator='GPC'"
        Dim dtVNP As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "' And Mobile_Operator='VNM'"
        Dim dtVNM As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "' And Mobile_Operator='GTEL'"
        Dim dtGTEL As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT  Dept_Text_En , Dept_Text_Vi ,SUM(Money_Over_MT_T1) Money_Over_MT_T1, SUM(Money_Share_T1) Money_Share_T1, SUM(Money_Total_T1) Money_Total_T1," & _
       "SUM(Money_Over_MT_T2) Money_Over_MT_T2, SUM(Money_Share_T2) Money_Share_T2, SUM(Money_Total_T2) Money_Total_T2," & _
       "SUM(Money_Over_MT_T3) Money_Over_MT_T3, SUM(Money_Share_T3) Money_Share_T3, SUM(Money_Total_T3) Money_Total_T3," & _
       "SUM(Money_Over_MT_T4) Money_Over_MT_T4, SUM(Money_Share_T4) Money_Share_T4, SUM(Money_Total_T4) Money_Total_T4," & _
       "SUM(Money_Over_MT_T5) Money_Over_MT_T5, SUM(Money_Share_T5) Money_Share_T5, SUM(Money_Total_T5) Money_Total_T5," & _
       "SUM(Money_Over_MT_T6) Money_Over_MT_T6, SUM(Money_Share_T6) Money_Share_T6, SUM(Money_Total_T6) Money_Total_T6," & _
       "SUM(Money_Over_MT_T7) Money_Over_MT_T7, SUM(Money_Share_T7) Money_Share_T7, SUM(Money_Total_T7) Money_Total_T7," & _
       "SUM(Money_Over_MT_T8) Money_Over_MT_T8, SUM(Money_Share_T8) Money_Share_T8, SUM(Money_Total_T8) Money_Total_T8," & _
       "SUM(Money_Over_MT_T9) Money_Over_MT_T9, SUM(Money_Share_T9) Money_Share_T9, SUM(Money_Total_T9) Money_Total_T9," & _
       "SUM(Money_Over_MT_T10) Money_Over_MT_T10, SUM(Money_Share_T10) Money_Share_T10, SUM(Money_Total_T10) Money_Total_T10," & _
       "SUM(Money_Over_MT_T11) Money_Over_MT_T11, SUM(Money_Share_T11) Money_Share_T11, SUM(Money_Total_T11) Money_Total_T11," & _
       "SUM(Money_Over_MT_T12) Money_Over_MT_T12, SUM(Money_Share_T12) Money_Share_T12, SUM(Money_Total_T12) Money_Total_T12 " & _
       " FROM  Finance_SMS_Rev_2 " & _
       " WHERE RangOfShortCode='" & RangShortCode & "' And Year='" & Year & "'" & _
       " GROUP BY Dept_Text_En , Dept_Text_Vi"
        Dim dtTotal As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
        Dim xmlDoc As XmlDocument = New XmlDocument()

        'Write down the XML declaration
        Dim xmlDeclaration As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "")

        ' Create the root element
        Dim rootNode As XmlElement = xmlDoc.CreateElement("ReportDataSet")
        xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(rootNode)

        Dim DausoNode As XmlElement = xmlDoc.CreateElement("DauSo")
        rootNode.AppendChild(DausoNode)
        Dim Row_TotalDept As Integer = 5 '(SubCPs, TTKD,TTND,LKF, HQ)
        Dim Row_TotalHeader As Integer = 5
        Dim Row_TotalFooter As Integer = 7
        Dim Row_Separator As Integer = 6

        'Lần 1 TyLeIndexNodeText=5(header)+Total DoiTac+ 7
        'Lần thứ 2 trở đi TyLeIndexNodeText=Tổng lần 1+6 +5(header)+Total DoiTac+ 7
        Dim TyLeIndex As Integer = 0
        Dim TyLeAnChia As Integer = 15
        Select Case RangShortCode
            Case "99x"
                TyLeAnChia = 15
            Case "6x66"
                TyLeAnChia = 5
            Case "8x79"
                TyLeAnChia = 0
            Case "8x99"
                TyLeAnChia = 15
        End Select
        For i As Integer = 1 To 6 '5 Telcos
            Select Case i
                Case 1
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/VIETTEL/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_TotalDept + Row_TotalHeader + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtViettel, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
                Case 2
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/VMS/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_Separator + Row_TotalHeader + Row_TotalDept + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtVMS, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
                Case 3
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/VNP/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_Separator + Row_TotalHeader + Row_TotalDept + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtVNP, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
                Case 4
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/VNM/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_Separator + Row_TotalHeader + Row_TotalDept + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtVNM, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
                Case 5
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/GTEL/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_Separator + Row_TotalHeader + Row_TotalDept + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtGTEL, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
                Case 6
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode(ShortCode & "/TỔNG/" & Year)
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(Row_TotalDept)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    TyLeIndex = TyLeIndex + Row_Separator + Row_TotalHeader + Row_TotalDept + Row_TotalFooter

                    xmlDoc = BuildXmlDocument(dtTotal, xmlDoc, TelcoNode, TyLeIndex, TyLeAnChia)
            End Select

        Next

        If Not Directory.Exists(Server.MapPath("/Download/SMS/" & CurrentUser.UserId & "/" & Now.Year & "/" & Now.Month & "/")) Then
            Directory.CreateDirectory(Server.MapPath("/Download/SMS/" & CurrentUser.UserId & "/" & Now.Year & "/" & Now.Month & "/"))
        End If
        'ds.Dispose();
        Dim CurrentDateTime As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim downloadFile As FileStream = File.Create(Server.MapPath("/Download/SMS/" & CurrentUser.UserId & "/" & Now.Year & "/" & Now.Month & "/") & "SMS_Rev_" & CurrentDateTime & ".xls")

        ' transform
        Dim xsl As New XslTransform()
        Dim TemplateFile As String = "Finance_SMS_Rev_2.xsl"
        xsl.Load(Server.MapPath("/Templates/SMS/" & TemplateFile))
        xsl.Transform(xmlDoc, Nothing, downloadFile, Nothing)
        downloadFile.Flush()
        downloadFile.Close()
        Dim Url As String = " <a href=" & ("../../../Download/SMS/" & CurrentUser.UserId & "/" & Now.Year & "/" & Now.Month & "/") + "SMS_Rev_" + CurrentDateTime + ".xls" & " target=""_blank"" class=""itemMenu""  title =""Download File"" >" & "SMS_Rev_" + CurrentDateTime + ".xls" & "</a>"
        Me.lblFileDownload.Text = Url
    End Sub
#End Region
#Region "Build XML Document"
    Private Function BuildXmlDocument(ByVal dt As DataTable, ByVal xmlDoc As XmlDocument, ByVal tableNode As XmlElement, ByVal TyLeIndex As Integer, ByVal TyLeAnChia As Integer) As XmlDocument
        If dt.Rows.Count > 0 Then
            For Each item As DataRow In dt.Rows
                Dim DoiTacNode As XmlElement = xmlDoc.CreateElement("DoiTac")
                tableNode.AppendChild(DoiTacNode)

                Dim TyLeIndexNode As XmlElement = xmlDoc.CreateElement("TyLeIndex")
                Dim TyLeIndexNodeText As XmlText = xmlDoc.CreateTextNode(TyLeIndex)
                TyLeIndexNode.AppendChild(TyLeIndexNodeText)

                Dim TyLeAnChiaNode As XmlElement = xmlDoc.CreateElement("TyLeAnChia")
                Dim TyLeAnChiaNodeText As XmlText = xmlDoc.CreateTextNode(TyLeAnChia)
                TyLeAnChiaNode.AppendChild(TyLeAnChiaNodeText)

                Dim TenNode As XmlElement = xmlDoc.CreateElement("Ten")
                Dim TenNodeText As XmlText = xmlDoc.CreateTextNode(item("Dept_Text_Vi"))
                TenNode.AppendChild(TenNodeText)
                'Tháng 1
                Dim Thang1Node As XmlElement = xmlDoc.CreateElement("Thang1")

                Dim DoanhThu1Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu1NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T1"))
                DoanhThu1Node.AppendChild(DoanhThu1NodeText)
                Thang1Node.AppendChild(DoanhThu1Node)

                Dim MTVuot1Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot1NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T1"))
                MTVuot1Node.AppendChild(MTVuot1NodeText)
                Thang1Node.AppendChild(MTVuot1Node)

                Dim TraDoiTac1Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac1NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T1"))
                TraDoiTac1Node.AppendChild(TraDoiTac1NodeText)
                Thang1Node.AppendChild(TraDoiTac1Node)
                'Tháng 2
                Dim Thang2Node As XmlElement = xmlDoc.CreateElement("Thang2")

                Dim DoanhThu2Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu2NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T2"))
                DoanhThu2Node.AppendChild(DoanhThu2NodeText)
                Thang2Node.AppendChild(DoanhThu2Node)

                Dim MTVuot2Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot2NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T2"))
                MTVuot2Node.AppendChild(MTVuot2NodeText)
                Thang2Node.AppendChild(MTVuot2Node)

                Dim TraDoiTac2Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac2NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T2"))
                TraDoiTac2Node.AppendChild(TraDoiTac2NodeText)
                Thang2Node.AppendChild(TraDoiTac2Node)
                'Tháng 3
                Dim Thang3Node As XmlElement = xmlDoc.CreateElement("Thang3")

                Dim DoanhThu3Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu3NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T3"))
                DoanhThu3Node.AppendChild(DoanhThu3NodeText)
                Thang3Node.AppendChild(DoanhThu3Node)

                Dim MTVuot3Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot3NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T3"))
                MTVuot3Node.AppendChild(MTVuot3NodeText)
                Thang3Node.AppendChild(MTVuot3Node)

                Dim TraDoiTac3Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac3NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T3"))
                TraDoiTac3Node.AppendChild(TraDoiTac3NodeText)
                Thang3Node.AppendChild(TraDoiTac3Node)


                'Tháng 4
                Dim Thang4Node As XmlElement = xmlDoc.CreateElement("Thang4")

                Dim DoanhThu4Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu4NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T4"))
                DoanhThu4Node.AppendChild(DoanhThu4NodeText)
                Thang4Node.AppendChild(DoanhThu4Node)

                Dim MTVuot4Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot4NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T4"))
                MTVuot4Node.AppendChild(MTVuot4NodeText)
                Thang4Node.AppendChild(MTVuot4Node)

                Dim TraDoiTac4Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac4NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T4"))
                TraDoiTac4Node.AppendChild(TraDoiTac4NodeText)
                Thang4Node.AppendChild(TraDoiTac4Node)
                'Tháng 5
                Dim Thang5Node As XmlElement = xmlDoc.CreateElement("Thang5")

                Dim DoanhThu5Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu5NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T5"))
                DoanhThu5Node.AppendChild(DoanhThu5NodeText)
                Thang5Node.AppendChild(DoanhThu5Node)

                Dim MTVuot5Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot5NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T5"))
                MTVuot5Node.AppendChild(MTVuot5NodeText)
                Thang5Node.AppendChild(MTVuot5Node)

                Dim TraDoiTac5Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac5NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T5"))
                TraDoiTac5Node.AppendChild(TraDoiTac5NodeText)
                Thang5Node.AppendChild(TraDoiTac5Node)
                'Tháng 6
                Dim Thang6Node As XmlElement = xmlDoc.CreateElement("Thang6")

                Dim DoanhThu6Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu6NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T6"))
                DoanhThu6Node.AppendChild(DoanhThu6NodeText)
                Thang6Node.AppendChild(DoanhThu6Node)

                Dim MTVuot6Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot6NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T6"))
                MTVuot6Node.AppendChild(MTVuot6NodeText)
                Thang6Node.AppendChild(MTVuot6Node)

                Dim TraDoiTac6Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac6NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T6"))
                TraDoiTac6Node.AppendChild(TraDoiTac6NodeText)
                Thang6Node.AppendChild(TraDoiTac6Node)
                'Tháng 7
                Dim Thang7Node As XmlElement = xmlDoc.CreateElement("Thang7")

                Dim DoanhThu7Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu7NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T7"))
                DoanhThu7Node.AppendChild(DoanhThu7NodeText)
                Thang7Node.AppendChild(DoanhThu7Node)

                Dim MTVuot7Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot7NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T7"))
                MTVuot7Node.AppendChild(MTVuot7NodeText)
                Thang7Node.AppendChild(MTVuot7Node)

                Dim TraDoiTac7Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac7NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T7"))
                TraDoiTac7Node.AppendChild(TraDoiTac7NodeText)
                Thang7Node.AppendChild(TraDoiTac7Node)
                'Tháng 8
                Dim Thang8Node As XmlElement = xmlDoc.CreateElement("Thang8")

                Dim DoanhThu8Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu8NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T8"))
                DoanhThu8Node.AppendChild(DoanhThu8NodeText)
                Thang8Node.AppendChild(DoanhThu8Node)

                Dim MTVuot8Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot8NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T8"))
                MTVuot8Node.AppendChild(MTVuot8NodeText)
                Thang8Node.AppendChild(MTVuot8Node)

                Dim TraDoiTac8Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac8NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T8"))
                TraDoiTac8Node.AppendChild(TraDoiTac8NodeText)
                Thang8Node.AppendChild(TraDoiTac8Node)
                'Tháng 9
                Dim Thang9Node As XmlElement = xmlDoc.CreateElement("Thang9")

                Dim DoanhThu9Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu9NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T9"))
                DoanhThu9Node.AppendChild(DoanhThu9NodeText)
                Thang9Node.AppendChild(DoanhThu9Node)

                Dim MTVuot9Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot9NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T9"))
                MTVuot9Node.AppendChild(MTVuot9NodeText)
                Thang9Node.AppendChild(MTVuot9Node)

                Dim TraDoiTac9Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac9NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T9"))
                TraDoiTac9Node.AppendChild(TraDoiTac9NodeText)
                Thang9Node.AppendChild(TraDoiTac9Node)
                'Tháng 10
                Dim Thang10Node As XmlElement = xmlDoc.CreateElement("Thang10")

                Dim DoanhThu10Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu10NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T10"))
                DoanhThu10Node.AppendChild(DoanhThu10NodeText)
                Thang10Node.AppendChild(DoanhThu10Node)

                Dim MTVuot10Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot10NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T10"))
                MTVuot10Node.AppendChild(MTVuot10NodeText)
                Thang10Node.AppendChild(MTVuot10Node)

                Dim TraDoiTac10Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac10NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T10"))
                TraDoiTac10Node.AppendChild(TraDoiTac10NodeText)
                Thang10Node.AppendChild(TraDoiTac10Node)
                'Tháng 11
                Dim Thang11Node As XmlElement = xmlDoc.CreateElement("Thang11")

                Dim DoanhThu11Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu11NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T11"))
                DoanhThu11Node.AppendChild(DoanhThu11NodeText)
                Thang11Node.AppendChild(DoanhThu11Node)

                Dim MTVuot11Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot11NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T11"))
                MTVuot11Node.AppendChild(MTVuot11NodeText)
                Thang11Node.AppendChild(MTVuot11Node)

                Dim TraDoiTac11Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac11NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T11"))
                TraDoiTac11Node.AppendChild(TraDoiTac11NodeText)
                Thang11Node.AppendChild(TraDoiTac11Node)

                'Tháng 12
                Dim Thang12Node As XmlElement = xmlDoc.CreateElement("Thang12")

                Dim DoanhThu12Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu12NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Total_T12"))
                DoanhThu12Node.AppendChild(DoanhThu12NodeText)
                Thang12Node.AppendChild(DoanhThu12Node)

                Dim MTVuot12Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot12NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Over_MT_T12"))
                MTVuot12Node.AppendChild(MTVuot12NodeText)
                Thang12Node.AppendChild(MTVuot12Node)

                Dim TraDoiTac12Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac12NodeText As XmlText = xmlDoc.CreateTextNode(item("Money_Share_T12"))
                TraDoiTac12Node.AppendChild(TraDoiTac12NodeText)
                Thang12Node.AppendChild(TraDoiTac12Node)

                DoiTacNode.AppendChild(TyLeIndexNode)
                DoiTacNode.AppendChild(TyLeAnChiaNode)
                DoiTacNode.AppendChild(TenNode)
                DoiTacNode.AppendChild(Thang1Node)
                DoiTacNode.AppendChild(Thang2Node)
                DoiTacNode.AppendChild(Thang3Node)
                DoiTacNode.AppendChild(Thang4Node)
                DoiTacNode.AppendChild(Thang5Node)
                DoiTacNode.AppendChild(Thang6Node)
                DoiTacNode.AppendChild(Thang7Node)
                DoiTacNode.AppendChild(Thang8Node)
                DoiTacNode.AppendChild(Thang9Node)
                DoiTacNode.AppendChild(Thang10Node)
                DoiTacNode.AppendChild(Thang11Node)
                DoiTacNode.AppendChild(Thang12Node)
            Next
        End If

        Return xmlDoc
    End Function
#End Region
End Class