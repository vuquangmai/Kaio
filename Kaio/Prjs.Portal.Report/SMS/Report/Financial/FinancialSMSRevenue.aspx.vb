Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Xml.Xsl
Imports System.Xml
Public Class FinancialSMSRevenue
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("E:\Projects\netPrjs\HQ\Prjs.Portal.Report\Templates\SMS\Test.xml")

        If Not Directory.Exists(Server.MapPath("/UpLoad/Temp/admin/")) Then
            Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/admin/"))
        End If
        'ds.Dispose();
        Dim datetime_1 As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim downloadFile As FileStream = File.Create(Server.MapPath("/UpLoad/Temp/admin/") & "Test_" & datetime_1 & ".xls")

        ' transform
        Dim xsl As New XslTransform()
        xsl.Load(Server.MapPath("/Templates/SMS/" & "Test.xsl"))
        xsl.Transform(xmlDoc, Nothing, downloadFile, Nothing)
        downloadFile.Flush()
        downloadFile.Close()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql As String = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='99x' And Year='2015' And Mobile_Operator='VIETTEL'"
        Dim dtVT As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        sql = "SELECT * FROM Finance_SMS_Rev_2 WHERE RangOfShortCode='99x' And Year='2015' And Mobile_Operator='VMS'"
        Dim dtVMS As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)

        Dim xmlDoc As XmlDocument = New XmlDocument()

        'Write down the XML declaration
        Dim xmlDeclaration As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "")

        ' Create the root element
        Dim rootNode As XmlElement = xmlDoc.CreateElement("ReportDataSet")
        xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(rootNode)

        Dim DausoNode As XmlElement = xmlDoc.CreateElement("DauSo")
        rootNode.AppendChild(DausoNode)
        'Lần 1 TyLeIndexNodeText=5(header)+Total DoiTac+ 7
        'Lần thứ 2 trở đi TyLeIndexNodeText=Tổng lần 1+6 +5(header)+Total DoiTac+ 7
        Dim TyLeIndex As Integer = 5 + 5 + 7
        For i As Integer = 1 To 2
            Select Case i
                Case 1
                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode("997 VIETTEL")
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(5)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    xmlDoc = BuildXmlDocument(dtVT, xmlDoc, TelcoNode, TyLeIndex)
                Case 2

                    Dim TelcoNode As XmlElement = xmlDoc.CreateElement("Telco")
                    DausoNode.AppendChild(TelcoNode)

                    Dim TelcoTextNode As XmlElement = xmlDoc.CreateElement("TelcoText")
                    Dim TelcoTextNodeText As XmlText = xmlDoc.CreateTextNode("997 VMS")
                    TelcoTextNode.AppendChild(TelcoTextNodeText)

                    Dim NumOfDoiTacNode As XmlElement = xmlDoc.CreateElement("NumOfDoiTac")
                    Dim NumOfDoiTacNodeText As XmlText = xmlDoc.CreateTextNode(5)
                    NumOfDoiTacNode.AppendChild(NumOfDoiTacNodeText)

                    TelcoNode.AppendChild(TelcoTextNode)
                    TelcoNode.AppendChild(NumOfDoiTacNode)

                    xmlDoc = BuildXmlDocument(dtVMS, xmlDoc, TelcoNode, TyLeIndex + 6 + 5 + 5 + 7)
            End Select
          
        Next
      



       If Not Directory.Exists(Server.MapPath("/UpLoad/Temp/admin/")) Then
            Directory.CreateDirectory(Server.MapPath("/UpLoad/Temp/admin/"))
        End If
        'ds.Dispose();
        Dim datetime_1 As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim downloadFile As FileStream = File.Create(Server.MapPath("/UpLoad/Temp/admin/") & "Test_" & datetime_1 & ".xls")

        ' transform
        Dim xsl As New XslTransform()
        xsl.Load(Server.MapPath("/Templates/SMS/" & "Test.xsl"))
        xsl.Transform(xmlDoc, Nothing, downloadFile, Nothing)
        downloadFile.Flush()
        downloadFile.Close()
    End Sub
    Private Function BuildXmlDocument(source As DataTable, xmlDoc As XmlDocument, tableNode As XmlElement, TyLeIndex As Integer) As XmlDocument
        If source.Rows.Count > 0 Then
        
            For Each item As DataRow In source.Rows
                Dim DoiTacNode As XmlElement = xmlDoc.CreateElement("DoiTac")
                tableNode.AppendChild(DoiTacNode)

                Dim TyLeIndexNode As XmlElement = xmlDoc.CreateElement("TyLeIndex")
                Dim TyLeIndexNodeText As XmlText = xmlDoc.CreateTextNode(TyLeIndex)
                TyLeIndexNode.AppendChild(TyLeIndexNodeText)

                Dim TenNode As XmlElement = xmlDoc.CreateElement("Ten")
                Dim TenNodeText As XmlText = xmlDoc.CreateTextNode("INCOM")
                TenNode.AppendChild(TenNodeText)
                'Tháng 1
                Dim Thang1Node As XmlElement = xmlDoc.CreateElement("Thang1")

                Dim DoanhThu1Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu1NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu1Node.AppendChild(DoanhThu1NodeText)
                Thang1Node.AppendChild(DoanhThu1Node)

                Dim MTVuot1Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot1NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot1Node.AppendChild(MTVuot1NodeText)
                Thang1Node.AppendChild(MTVuot1Node)

                Dim TraDoiTac1Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac1NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac1Node.AppendChild(TraDoiTac1NodeText)
                Thang1Node.AppendChild(TraDoiTac1Node)
                'Tháng 2
                Dim Thang2Node As XmlElement = xmlDoc.CreateElement("Thang2")

                Dim DoanhThu2Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu2NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu2Node.AppendChild(DoanhThu2NodeText)
                Thang2Node.AppendChild(DoanhThu2Node)

                Dim MTVuot2Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot2NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot2Node.AppendChild(MTVuot2NodeText)
                Thang2Node.AppendChild(MTVuot2Node)

                Dim TraDoiTac2Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac2NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac2Node.AppendChild(TraDoiTac2NodeText)
                Thang2Node.AppendChild(TraDoiTac2Node)
                'Tháng 3
                Dim Thang3Node As XmlElement = xmlDoc.CreateElement("Thang3")

                Dim DoanhThu3Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu3NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu3Node.AppendChild(DoanhThu3NodeText)
                Thang3Node.AppendChild(DoanhThu3Node)

                Dim MTVuot3Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot3NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot3Node.AppendChild(MTVuot3NodeText)
                Thang3Node.AppendChild(MTVuot3Node)

                Dim TraDoiTac3Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac3NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac3Node.AppendChild(TraDoiTac3NodeText)
                Thang3Node.AppendChild(TraDoiTac3Node)


                'Tháng 4
                Dim Thang4Node As XmlElement = xmlDoc.CreateElement("Thang4")

                Dim DoanhThu4Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu4NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu4Node.AppendChild(DoanhThu4NodeText)
                Thang4Node.AppendChild(DoanhThu4Node)

                Dim MTVuot4Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot4NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot4Node.AppendChild(MTVuot4NodeText)
                Thang4Node.AppendChild(MTVuot4Node)

                Dim TraDoiTac4Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac4NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac4Node.AppendChild(TraDoiTac4NodeText)
                Thang4Node.AppendChild(TraDoiTac4Node)
                'Tháng 5
                Dim Thang5Node As XmlElement = xmlDoc.CreateElement("Thang5")

                Dim DoanhThu5Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu5NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu5Node.AppendChild(DoanhThu5NodeText)
                Thang5Node.AppendChild(DoanhThu5Node)

                Dim MTVuot5Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot5NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot5Node.AppendChild(MTVuot5NodeText)
                Thang5Node.AppendChild(MTVuot5Node)

                Dim TraDoiTac5Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac5NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac5Node.AppendChild(TraDoiTac5NodeText)
                Thang5Node.AppendChild(TraDoiTac5Node)
                'Tháng 6
                Dim Thang6Node As XmlElement = xmlDoc.CreateElement("Thang6")

                Dim DoanhThu6Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu6NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu6Node.AppendChild(DoanhThu6NodeText)
                Thang6Node.AppendChild(DoanhThu6Node)

                Dim MTVuot6Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot6NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot6Node.AppendChild(MTVuot6NodeText)
                Thang6Node.AppendChild(MTVuot6Node)

                Dim TraDoiTac6Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac6NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac6Node.AppendChild(TraDoiTac6NodeText)
                Thang6Node.AppendChild(TraDoiTac6Node)
                'Tháng 7
                Dim Thang7Node As XmlElement = xmlDoc.CreateElement("Thang7")

                Dim DoanhThu7Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu7NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu7Node.AppendChild(DoanhThu7NodeText)
                Thang7Node.AppendChild(DoanhThu7Node)

                Dim MTVuot7Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot7NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot7Node.AppendChild(MTVuot7NodeText)
                Thang7Node.AppendChild(MTVuot7Node)

                Dim TraDoiTac7Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac7NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac7Node.AppendChild(TraDoiTac7NodeText)
                Thang7Node.AppendChild(TraDoiTac7Node)
                'Tháng 8
                Dim Thang8Node As XmlElement = xmlDoc.CreateElement("Thang8")

                Dim DoanhThu8Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu8NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu8Node.AppendChild(DoanhThu8NodeText)
                Thang8Node.AppendChild(DoanhThu8Node)

                Dim MTVuot8Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot8NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot8Node.AppendChild(MTVuot8NodeText)
                Thang8Node.AppendChild(MTVuot8Node)

                Dim TraDoiTac8Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac8NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac8Node.AppendChild(TraDoiTac8NodeText)
                Thang8Node.AppendChild(TraDoiTac8Node)
                'Tháng 9
                Dim Thang9Node As XmlElement = xmlDoc.CreateElement("Thang9")

                Dim DoanhThu9Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu9NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu9Node.AppendChild(DoanhThu9NodeText)
                Thang9Node.AppendChild(DoanhThu9Node)

                Dim MTVuot9Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot9NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot9Node.AppendChild(MTVuot9NodeText)
                Thang9Node.AppendChild(MTVuot9Node)

                Dim TraDoiTac9Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac9NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac9Node.AppendChild(TraDoiTac9NodeText)
                Thang9Node.AppendChild(TraDoiTac9Node)
                'Tháng 10
                Dim Thang10Node As XmlElement = xmlDoc.CreateElement("Thang10")

                Dim DoanhThu10Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu10NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu10Node.AppendChild(DoanhThu10NodeText)
                Thang10Node.AppendChild(DoanhThu10Node)

                Dim MTVuot10Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot10NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot10Node.AppendChild(MTVuot10NodeText)
                Thang10Node.AppendChild(MTVuot10Node)

                Dim TraDoiTac10Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac10NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac10Node.AppendChild(TraDoiTac10NodeText)
                Thang10Node.AppendChild(TraDoiTac10Node)
                'Tháng 11
                Dim Thang11Node As XmlElement = xmlDoc.CreateElement("Thang11")

                Dim DoanhThu11Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu11NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu11Node.AppendChild(DoanhThu11NodeText)
                Thang11Node.AppendChild(DoanhThu11Node)

                Dim MTVuot11Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot11NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot11Node.AppendChild(MTVuot11NodeText)
                Thang11Node.AppendChild(MTVuot11Node)

                Dim TraDoiTac11Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac11NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac11Node.AppendChild(TraDoiTac11NodeText)
                Thang11Node.AppendChild(TraDoiTac11Node)

                'Tháng 12
                Dim Thang12Node As XmlElement = xmlDoc.CreateElement("Thang12")

                Dim DoanhThu12Node As XmlElement = xmlDoc.CreateElement("DoanhThu")
                Dim DoanhThu12NodeText As XmlText = xmlDoc.CreateTextNode("3")
                DoanhThu12Node.AppendChild(DoanhThu12NodeText)
                Thang12Node.AppendChild(DoanhThu12Node)

                Dim MTVuot12Node As XmlElement = xmlDoc.CreateElement("MTVuot")
                Dim MTVuot12NodeText As XmlText = xmlDoc.CreateTextNode("1")
                MTVuot12Node.AppendChild(MTVuot12NodeText)
                Thang12Node.AppendChild(MTVuot12Node)

                Dim TraDoiTac12Node As XmlElement = xmlDoc.CreateElement("TraDoiTac")
                Dim TraDoiTac12NodeText As XmlText = xmlDoc.CreateTextNode("2")
                TraDoiTac12Node.AppendChild(TraDoiTac12NodeText)
                Thang12Node.AppendChild(TraDoiTac12Node)

                DoiTacNode.AppendChild(TyLeIndexNode)
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
End Class