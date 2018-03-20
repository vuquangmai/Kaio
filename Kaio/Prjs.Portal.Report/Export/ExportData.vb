Public Class ExportData
#Region "Excel"
    Public Class ExportExcel

#Region "B2B"
        Public Class _B2B
            Public Shared Sub CcareContractList(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = HD_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 8
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ KHÁCH HÀNG B2B</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">THÔNG TIN HỢP ĐỒNG KHÁCH HÀNG B2B</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ HỢP ĐỒNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ HỢP ĐỒNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHU KỲ HỢP ĐỒNG</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Service_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Number") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Text").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Cycle_Contract_Text").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "B2C"
        Public Class _B2C
            Public Shared Sub UserImportTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = UserImportTotal_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=7  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=7 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">QUẢN LÝ THÔNG TIN KHÁCH HÀNG B2C</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=7 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO THÔNG TIN IMPORT DỮ LIỆU KHÁCH HÀNG</td>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NHÓM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỪ KHÓA</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGƯỜI IMPORT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> THỜI GIAN IMPORT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỔNG SỐ</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & ReplaceSpecial(IIf(IsDBNull(dt.Rows(j).Item("MTFull")), "", dt.Rows(j).Item("MTFull"))) & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("GROUP_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("KEY_WORD").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CREATE_BY_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CREATE_TIME").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub UserImport(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = UserImport_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=26  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=26 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">QUẢN LÝ THÔNG TIN KHÁCH HÀNG B2C</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=26 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO DANH SÁCH KHÁCH HÀNG</td>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ ĐIỆN THOẠI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NHÓM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> BRAND</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỈNH/THÀNH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> QUẬN/HUYỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> GIỚI TÍNH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NGÀNH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NGUỒN DỮ LIỆU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỪ KHÓA</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> GHI CHÚ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MÃ KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> HỌ TÊN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NGÀY SINH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> ĐỊA CHỈ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> EMAIL</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MỨC CƯỚC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MỨC THU NHẬP</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> ĐỘ CHÍNH XÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> SỐ LẦN LẶP</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỒN TẠI BẢNG CHÍNH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> THỜI GIAN CẬP NHẬT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NGƯỜI CẬP NHẬT</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("USER_ID").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("STATUS_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("GROUP_TEXT").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & ReplaceSpecial(IIf(IsDBNull(dt.Rows(j).Item("MT")), "", dt.Rows(j).Item("MT"))) & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("BRAND_NAME").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("PARTNER_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("PROVINCE_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DISTRICT_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SEX_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("FIELD_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SOURCE_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("KEY_WORD") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & ReplaceSpecial(IIf(IsDBNull(dt.Rows(j).Item("REMARK")), "", dt.Rows(j).Item("REMARK"))) & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CUSTOMER_CODE") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CUSTOMER_NAME") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("BIRTH_DAY") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & ReplaceSpecial(IIf(IsDBNull(dt.Rows(j).Item("ADDRESS")), "", dt.Rows(j).Item("ADDRESS"))) & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("EMAIL_ADDRESS") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("FEES_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt"" >" & dt.Rows(j).Item("INCOME_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("EXACTLY_RATE") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DUPLICATE_NUMBER").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("EXIST_NUMBER").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("UPDATE_TIME")).ToString("dd-MM-yyyy HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("UPDATE_BY_TEXT") & "   </td>")

                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub UserComplete(ByVal sql As String, ByVal vCreateby As String)

                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = UserComplete_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=14  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=14 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">QUẢN LÝ THÔNG TIN KHÁCH HÀNG B2C</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=14 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO DANH SÁCH KHÁCH HÀNG</td>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BRAND NAME</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỪ KHÓA</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NHÓM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> NGUỒN DỮ LIỆU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MẠNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> GIỚI TÍNH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỈNH THÀNH</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MỨC CƯỚC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MỨC THU NHẬP</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> ĐỘ CHÍNH XÁC</td>")

                sb.Append("</tr>")
                Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("PARTNER_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("BRAND_NAME") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("KEY_WORD").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("GROUP_TEXT") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SOURCE_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("STATUS_TEXT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MOBILE_OPERATOR").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("USER_ID") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SEX_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("PROVINCE_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("FEES_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("INCOME_TEXT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("EXACTLY_RATE") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "LKF"
        Public Class _LKF
            Public Shared Sub CycleReport(ByVal Year As Integer, ByVal Company_Id As Integer, ByVal CompanyText As String)

                Dim sql As String = "SELECT * FROM SMS_LKF_Month_Cycle WHERE Company_Id=" & Company_Id & " And Year=" & Year
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                If dt.Rows.Count > 0 Then
                    Dim TotalCycle As Integer = dt.Rows(0).Item("Total")
                    Dim TotalT1 As Integer = dt.Rows(0).Item("T1")
                    Dim TotalT2 As Integer = dt.Rows(0).Item("T2")
                    Dim TotalT3 As Integer = dt.Rows(0).Item("T3")
                    Dim TotalT4 As Integer = dt.Rows(0).Item("T4")
                    Dim TotalT5 As Integer = dt.Rows(0).Item("T5")
                    Dim TotalT6 As Integer = dt.Rows(0).Item("T6")
                    Dim TotalT7 As Integer = dt.Rows(0).Item("T7")
                    Dim TotalT8 As Integer = dt.Rows(0).Item("T8")
                    Dim TotalT9 As Integer = dt.Rows(0).Item("T9")
                    Dim TotalT10 As Integer = dt.Rows(0).Item("T10")
                    Dim TotalT11 As Integer = dt.Rows(0).Item("T11")
                    Dim TotalT12 As Integer = dt.Rows(0).Item("T12")
                    Dim TotalCol As Integer = 3 + TotalCycle + 12 * 2 + 2
                    Dim Color_1 As String = "#F2DDDC"
                    Dim Color_2 As String = "#DBEEF3"
                    Dim Color As String = ""
                    Dim vTable As String = "SMS_LKF_Data_Cycle_" & CompanyText
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = " & CompanyText & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">TRUNG TÂM LUCKY FONE</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO THEO KỲ PHÁT HÀNH VÉ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblHeader
                    sb.Append("<table id=""tblParam1"" border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & 3 & " style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #FFFFFF; font-weight: bold; font-size: 12pt;""> </td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT1 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 1/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT2 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 2/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT3 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 3/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT4 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 4/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT5 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 5/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT6 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 6/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT7 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 7/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT8 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 8/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT9 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 9/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT10 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 10/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT11 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 11/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & TotalT12 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 12pt;"">Tháng 12/" & Year & "</td>")
                    sb.Append("<td align=""center"" colspan=" & 2 & " style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #FFFFFF; font-weight: bold; font-size: 12pt;""></td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblParam1
                    sb.Append("<table id=""tblParam2"" border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Mạng </td>")
                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Trung bình tháng </td>")
                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Trung bình kỳ </td>")
                    For k As Integer = 1 To 12
                        If k Mod 2 = 0 Then
                            Color = Color_2
                        Else
                            Color = Color_1
                        End If
                        sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & Company_Id & " And Cycle_Month=" & k
                        Dim dt1 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                        For j As Integer = 0 To dt1.Rows.Count - 1
                            sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">Kỳ " & dt1.Rows(j).Item("Cycle_Id") & "<br>(" & CInt(dt1.Rows(j).Item("From_Date").ToString.Substring(6, 2)) & "-" & CInt(dt1.Rows(j).Item("To_Date").ToString.Substring(6, 2)) & ")</td>")
                        Next
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">Tổng Tháng " & k & "<br> (theo chu kỳ)" & "</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">Tổng Tháng " & k & "<br> (theo ngày)" & "</td>")
                    Next
                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tổng tháng</td>")
                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tổng kỳ</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblParam2
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sql = "SELECT * FROM " & vTable & " WHERE Year=" & Year & " Order by  Id "
                    Dim dt2 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                    For i As Integer = 0 To dt2.Rows.Count - 1
                        Dim Current_Cycle As Integer = dt2.Rows(i).Item("Current_Cycle")
                        If dt2.Rows(i).Item("Criteria_Report_En") = "Total_Operator" Or dt2.Rows(i).Item("Criteria_Report_En") = "Total_ShortCode" Then
                            sb.Append("<tr>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt2.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Month"), 0) & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Cycle"), 0) & "</td>")
                            Dim Cycle_Id As Integer = 1
                            For z As Integer = 1 To 12
                                If z Mod 2 = 0 Then
                                    Color = Color_2
                                Else
                                    Color = Color_1
                                End If
                                sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & Company_Id & " And Cycle_Month=" & z
                                Dim dt3 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                                For x As Integer = 0 To dt3.Rows.Count - 1
                                    If Current_Cycle >= Cycle_Id Then
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Cycle_" & Cycle_Id), 0) & "</td>")
                                    Else
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;""> </td>")
                                    End If
                                    Cycle_Id = Cycle_Id + 1
                                Next
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;""> " & FormatDecimal(dt2.Rows(i).Item("Total_Cycle_" & z), 0) & "</td>")
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">  " & FormatDecimal(dt2.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                            Next
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Month"), 0) & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Cycle"), 0) & "</td>")
                            sb.Append("</tr>")
                        Else
                            sb.Append("<tr>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt2.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Month"), 0) & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Cycle"), 0) & "</td>")
                            Dim Cycle_Id As Integer = 1
                            For z As Integer = 1 To 12
                                If z Mod 2 = 0 Then
                                    Color = Color_2
                                Else
                                    Color = Color_1
                                End If
                                sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & Company_Id & " And Cycle_Month=" & z
                                Dim dt3 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                                For x As Integer = 0 To dt3.Rows.Count - 1
                                    If Current_Cycle >= Cycle_Id Then
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Cycle_" & Cycle_Id), 0) & "</td>")
                                    Else
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> </td>")
                                    End If
                                    Cycle_Id = Cycle_Id + 1
                                Next
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> " & FormatDecimal(dt2.Rows(i).Item("Total_Cycle_" & z), 0) & "</td>")
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">  " & FormatDecimal(dt2.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                            Next
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Month"), 0) & "</td>")
                            sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Cycle"), 0) & "</td>")
                            sb.Append("</tr>")
                        End If


                    Next
                    sb.Append("</table>") 'tblDetail
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td  style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;""  >Người lập biểu:   </td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblBound
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()

                End If

            End Sub
            Public Shared Sub CycleReportAll(ByVal Year As Integer, ByVal RegionId As Integer, ByVal CompanyId As Integer)
                Dim TotalColspan As Integer = 106
                Dim sql As String = "SELECT * FROM SMS_DictIndex_Lottery_Company A " & _
                                            " INNER JOIN SMS_LKF_Month_Cycle B ON A.Id=B.Company_Id " & _
                                            " Where B.Year='" & Year & "'"
                If RegionId > 0 Then
                    sql = sql & " And A.Region_Id=" & RegionId
                End If
                If CompanyId > 0 Then
                    sql = sql & " And A.Id=" & CompanyId
                End If
                sql = sql & " Order by A.Region_Id,A.Company_Text"
                Dim dtCompany As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                If dtCompany.Rows.Count > 0 Then
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = BaoCaoKy.xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;""></td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & " style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family:Times New Roman; font-size: 16px; font-weight: bold; color: #0070C0""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "  style=""font-family:Times New Roman; font-size: 16px; font-weight: bold; color: #0070C0"">TRUNG TÂM LUCKY FONE</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left"" style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "   style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO DOANH THU THEO KỲ PHÁT HÀNH VÉ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "   style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("</tr>")

                    sb.Append("</table>") 'tblHeader
                    ' Xử lý số liệu từng tỉnh
                    For t As Integer = 0 To dtCompany.Rows.Count - 1 '1
                        Dim vCompany_Text As String = IsDataTable(dtCompany.Rows(t).Item("Id"))
                        Dim vCompany_Id As Integer = dtCompany.Rows(t).Item("Id")
                        sb.Append("<table id=""tblDescription" & t & """ border=""0"" cellpadding=""2"" cellspacing=""2"" width=""100%"">")
                        sb.Append("<tr>")
                        sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 9pt;""></td>")
                        sb.Append("<td align=""left""  colspan=" & TotalColspan & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 9pt;"">" & t + 1 & ". " & dtCompany.Rows(t).Item("Company_Text") & "</td>")
                        sb.Append("</tr>")
                        sb.Append("<tr>")
                        sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 9pt;""></td>")
                        sb.Append("<td align=""left""  colspan=" & TotalColspan & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 9pt;"">" & dtCompany.Rows(t).Item("Region_Text") & "; Tổng kỳ: " & dtCompany.Rows(t).Item("Total") & "; Mở thưởng : " & dtCompany.Rows(t).Item("Date_Result_Text") & " </td>")
                        sb.Append("</tr>")
                        sb.Append("</table>") 'tblDescription

                        sql = "SELECT * FROM SMS_LKF_Month_Cycle WHERE Company_Id=" & vCompany_Id & " And Year=" & Year
                        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                        If dt.Rows.Count > 0 Then
                            Dim TotalCycle As Integer = dt.Rows(0).Item("Total")
                            Dim TotalT1 As Integer = dt.Rows(0).Item("T1")
                            Dim TotalT2 As Integer = dt.Rows(0).Item("T2")
                            Dim TotalT3 As Integer = dt.Rows(0).Item("T3")
                            Dim TotalT4 As Integer = dt.Rows(0).Item("T4")
                            Dim TotalT5 As Integer = dt.Rows(0).Item("T5")
                            Dim TotalT6 As Integer = dt.Rows(0).Item("T6")
                            Dim TotalT7 As Integer = dt.Rows(0).Item("T7")
                            Dim TotalT8 As Integer = dt.Rows(0).Item("T8")
                            Dim TotalT9 As Integer = dt.Rows(0).Item("T9")
                            Dim TotalT10 As Integer = dt.Rows(0).Item("T10")
                            Dim TotalT11 As Integer = dt.Rows(0).Item("T11")
                            Dim TotalT12 As Integer = dt.Rows(0).Item("T12")
                            Dim TotalCol As Integer = 3 + TotalCycle + 12 * 2 + 2
                            Dim Color_1 As String = "#F2DDDC"
                            Dim Color_2 As String = "#DBEEF3"
                            Dim Color As String = ""
                            Dim vTable As String = "SMS_LKF_Data_Cycle_" & vCompany_Text

                            sb.Append("<table id=""tblParam1" & t & """ border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                            sb.Append("<tr>")
                            sb.Append("<td align=""center"" colspan=" & 3 & " style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #FFFFFF; font-weight: bold; font-size: 9pt;""> </td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT1 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 1/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT2 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 2/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT3 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 3/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT4 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 4/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT5 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 5/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT6 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 6/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT7 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 7/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT8 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 8/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT9 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 9/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT10 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 10/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT11 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 11/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & TotalT12 + 2 & " style=""font-family:Times New Roman; background-color: " & Color_2 & "; color: #000000; font-weight: bold; font-size: 9pt;"">Tháng 12/" & Year & "</td>")
                            sb.Append("<td align=""center"" colspan=" & 2 & " style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #FFFFFF; font-weight: bold; font-size: 9pt;""></td>")
                            sb.Append("</tr>")
                            sb.Append("</table>") 'tblParam1
                            sb.Append("<table id=""tblParam2" & t & """ border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                            sb.Append("<tr>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">Mạng </td>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">Trung bình tháng </td>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">Trung bình kỳ </td>")
                            For k As Integer = 1 To 12
                                If k Mod 2 = 0 Then
                                    Color = Color_2
                                Else
                                    Color = Color_1
                                End If
                                sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & vCompany_Id & " And Cycle_Month=" & k
                                Dim dt1 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                                For j As Integer = 0 To dt1.Rows.Count - 1
                                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;"">Kỳ " & dt1.Rows(j).Item("Cycle_Id") & "<br>(" & CInt(dt1.Rows(j).Item("From_Date").ToString.Substring(6, 2)) & "-" & CInt(dt1.Rows(j).Item("To_Date").ToString.Substring(6, 2)) & ")</td>")
                                Next
                                sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;"">Tổng Tháng " & k & "<br> (theo chu kỳ)" & "</td>")
                                sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;"">Tổng Tháng " & k & "<br> (theo ngày)" & "</td>")
                            Next
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">Tổng tháng</td>")
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">Tổng kỳ</td>")
                            sb.Append("</tr>")
                            sb.Append("</table>") 'tblParam2

                            sql = "SELECT * FROM " & vTable & " WHERE Year=" & Year & " Order by  Id "
                            Dim dt2 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                            sb.Append("<table id=""tblDetail" & t & """  border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 9pt; width=""100%"">")
                            For i As Integer = 0 To dt2.Rows.Count - 1
                                Dim Current_Cycle As Integer = dt2.Rows(i).Item("Current_Cycle")
                                If dt2.Rows(i).Item("Criteria_Report_En") = "Total_Operator" Or dt2.Rows(i).Item("Criteria_Report_En") = "Total_ShortCode" Then
                                    sb.Append("<tr>")
                                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt2.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Month"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Cycle"), 0) & "</td>")
                                    Dim Cycle_Id As Integer = 1
                                    For z As Integer = 1 To 12
                                        If z Mod 2 = 0 Then
                                            Color = Color_2
                                        Else
                                            Color = Color_1
                                        End If
                                        sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & vCompany_Id & " And Cycle_Month=" & z
                                        Dim dt3 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                                        For x As Integer = 0 To dt3.Rows.Count - 1
                                            If Current_Cycle >= Cycle_Id Then
                                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Cycle_" & Cycle_Id), 0) & "</td>")
                                            Else
                                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;""> </td>")
                                            End If
                                            Cycle_Id = Cycle_Id + 1
                                        Next
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;""> " & FormatDecimal(dt2.Rows(i).Item("Total_Cycle_" & z), 0) & "</td>")
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">  " & FormatDecimal(dt2.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                    Next
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Month"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Cycle"), 0) & "</td>")
                                    sb.Append("</tr>")
                                Else
                                    sb.Append("<tr>")
                                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">" & dt2.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Month"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Average_Cycle"), 0) & "</td>")
                                    Dim Cycle_Id As Integer = 1
                                    For z As Integer = 1 To 12
                                        If z Mod 2 = 0 Then
                                            Color = Color_2
                                        Else
                                            Color = Color_1
                                        End If
                                        sql = "SELECT * FROM SMS_LKF_Company_Cycle Where Year= " & Year & " And Company_Id=" & vCompany_Id & " And Cycle_Month=" & z
                                        Dim dt3 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                                        For x As Integer = 0 To dt3.Rows.Count - 1
                                            If Current_Cycle >= Cycle_Id Then
                                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Cycle_" & Cycle_Id), 0) & "</td>")
                                            Else
                                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;""> </td>")
                                            End If
                                            Cycle_Id = Cycle_Id + 1
                                        Next
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;""> " & FormatDecimal(dt2.Rows(i).Item("Total_Cycle_" & z), 0) & "</td>")
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 9pt;"">  " & FormatDecimal(dt2.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                    Next
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Month"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 9pt;"">" & FormatDecimal(dt2.Rows(i).Item("Total_Cycle"), 0) & "</td>")
                                    sb.Append("</tr>")
                                End If
                            Next
                            sb.Append("</table>") 'tblDetail
                        End If
                    Next '1


                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End If 'dtCompany
            End Sub
            Public Shared Sub MonthReportAll(ByVal Year As Integer, ByVal RegionId As Integer, ByVal CompanyId As Integer)
                Dim TotalColspan As Integer = 15
                Dim RegionText As String = ""
                Dim vTableTotal As String = ""
                Select Case RegionId
                    Case 1
                        RegionText = "MIỀN BẮC"
                        vTableTotal = "SMS_LKF_Data_Month_XSMB"
                    Case 2
                        RegionText = "MIỀN TRUNG"
                        vTableTotal = "SMS_LKF_Data_Month_XSMT"
                    Case 3
                        RegionText = "MIỀN NAM"
                        vTableTotal = "SMS_LKF_Data_Month_XSMN"
                End Select
                Dim Color_1 As String = "#FFFF00"
                Dim Color_2 As String = "#DBEEF3"
                Dim Color As String = ""
                Dim sql As String = "SELECT * FROM SMS_DictIndex_Lottery_Company  Where Region_Id=" & RegionId
                If CompanyId > 0 Then
                    sql = sql & " And Id=" & CompanyId
                End If
                sql = sql & " Order by Company_Text"
                Dim dtCompany As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                If dtCompany.Rows.Count > 0 Then
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = BaoCaoThang.xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;""></td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & " style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family:Times New Roman; font-size: 16px; font-weight: bold; color: #0070C0""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "  style=""font-family:Times New Roman; font-size: 16px; font-weight: bold; color: #0070C0"">TRUNG TÂM LUCKY FONE</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left"" style=""font-family: Times New Roman; font-size: 10pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "   style=""font-family: Times New Roman; font-size: 10pt; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO DOANH THU THEO THÁNG CÁC TỈNH " & RegionText & ", NĂM " & Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  style=""font-family: Times New Roman; font-size: 10pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("<td align=""left"" colspan=" & TotalColspan & "   style=""font-family: Times New Roman; font-size: 10pt; text-decoration: underline; font-weight: bold; color: #000000""> </td>")
                    sb.Append("</tr>")

                    sb.Append("</table>") 'tblHeader
                    ' Xử lý số liệu từng tỉnh
                    For t As Integer = 0 To dtCompany.Rows.Count - 1 '1
                        Dim vCompany_Text As String = IsDataTable(dtCompany.Rows(t).Item("Id"))
                        Dim vCompany_Id As Integer = dtCompany.Rows(t).Item("Id")
                        sb.Append("<table id=""tblDescription" & t & """ border=""0"" cellpadding=""2"" cellspacing=""2"" width=""100%"">")
                        sb.Append("<tr>")
                        sb.Append("<td align=""left""  colspan=" & TotalColspan & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 12pt;"">" & t + 1 & ". " & dtCompany.Rows(t).Item("Company_Text") & "</td>")
                        sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 12pt;""></td>")
                        sb.Append("</tr>")
                        sb.Append("</table>") 'tblDescription
                        sb.Append("<table id=""tblParam1" & t & """ border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                        sb.Append("<tr>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #E46D0A; color: #000000; font-weight: normal; font-size: 10pt;"">#</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #538ED5; color: #000000; font-weight: normal; font-size: 10pt;"">Trung bình năm " & Year - 1 & "</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #FFFF00; color: #000000; font-weight: normal; font-size: 10pt;"">Trung bình đến tháng hiện tại</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 1</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 2</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 3</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 4</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 5</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 6</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 7</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 8</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 9</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 10</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 11</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 12</td>")
                        sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC00; color: #000000; font-weight: normal; font-size: 10pt;"">Tổng năm " & Year & "</td>")
                        sb.Append("</tr>")
                        sb.Append("</table>") 'tblParam1
                        Dim vTable As String = "SMS_LKF_Data_Month_" & vCompany_Text
                        sql = "SELECT * FROM " & vTable & " WHERE Year=" & Year & " Order by  Id "
                        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                        If dt.Rows.Count > 0 Then
                            sb.Append("<table id=""tblDetail" & t & """  border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                            For i As Integer = 0 To dt.Rows.Count - 1
                                Dim Current_Month As Integer = dt.Rows(0).Item("Current_Month")
                                If dt.Rows(i).Item("Criteria_Report_En") = "Total_Operator" Or dt.Rows(i).Item("Criteria_Report_En") = "Total_ShortCode" Then
                                    sb.Append("<tr>")
                                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Average_Previous_Year"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Average_Current_Year"), 0) & "</td>")
                                    For z As Integer = 1 To 12
                                        If Current_Month >= z Then
                                            sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                        Else
                                            sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;""> </td>")
                                        End If
                                    Next
                                    sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Total_Current_Year"), 0) & "</td>")
                                    sb.Append("</tr>")
                                Else
                                    sb.Append("<tr>")
                                    sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: bold; font-size: 10pt;"">" & dt.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Average_Previous_Year"), 0) & "</td>")
                                    sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Average_Current_Year"), 0) & "</td>")
                                    For z As Integer = 1 To 12
                                        If Current_Month >= z Or dt.Rows(i).Item("Criteria_Report_Vi") = "Total_Time" Then
                                            sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dt.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                        Else
                                            sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;""> </td>")
                                        End If
                                    Next
                                    sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;""> " & FormatDecimal(dt.Rows(i).Item("Total_Current_Year"), 0) & "</td>")
                                    sb.Append("</tr>")
                                End If
                            Next
                            sb.Append("</table>") 'tblDetail
                        End If
                    Next '1
                    'Build Table Total
                    sb.Append("<table id=""HeaderTotal"" border=""0"" cellpadding=""2"" cellspacing=""2"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""left""  colspan=" & TotalColspan & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 10pt;"">CỘNG THEO KHU VỰC</td>")
                    sb.Append("<td align=""left""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 10pt;""></td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'HeaderTotal
                    sb.Append("<table id=""tblParamTotal"" border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #E46D0A; color: #000000; font-weight: normal; font-size: 10pt;"">#</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #538ED5; color: #000000; font-weight: normal; font-size: 10pt;"">Trung bình năm " & Year - 1 & "</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #FFFF00; color: #000000; font-weight: normal; font-size: 10pt;"">Trung bình đến tháng hiện tại</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 1</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 2</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 3</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 4</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 5</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 6</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 7</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 8</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 9</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 10</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 11</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC99; color: #000000; font-weight: normal; font-size: 10pt;"">Tháng 12</td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #00CC00; color: #000000; font-weight: normal; font-size: 10pt;"">Tổng năm " & Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblParamTotal


                    sql = "SELECT * FROM " & vTableTotal & " WHERE Year=" & Year & " Order by  Id "
                    Dim dtTotal As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                    If dtTotal.Rows.Count > 0 Then
                        sb.Append("<table id=""tblDetail_Total" & """  border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                        For i As Integer = 0 To dtTotal.Rows.Count - 1
                            Dim Current_Month As Integer = dtTotal.Rows(0).Item("Current_Month")
                            If dtTotal.Rows(i).Item("Criteria_Report_En") = "Total_Operator" Or dtTotal.Rows(i).Item("Criteria_Report_En") = "Total_ShortCode" Then
                                sb.Append("<tr>")
                                sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #FF0000; font-weight: bold; font-size: 12pt;"">" & dtTotal.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Average_Previous_Year"), 0) & "</td>")
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Average_Current_Year"), 0) & "</td>")
                                For z As Integer = 1 To 12
                                    If Current_Month >= z Then
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                    Else
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;""> </td>")
                                    End If
                                Next
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Total_Current_Year"), 0) & "</td>")
                                sb.Append("</tr>")
                            Else
                                sb.Append("<tr>")
                                sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 10pt;"">" & dtTotal.Rows(i).Item("Criteria_Report_Vi") & "</td>")
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Average_Previous_Year"), 0) & "</td>")
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Average_Current_Year"), 0) & "</td>")
                                For z As Integer = 1 To 12
                                    If Current_Month >= z Or dtTotal.Rows(i).Item("Criteria_Report_Vi") = "Total_Time" Then
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;"">" & FormatDecimal(dtTotal.Rows(i).Item("Total_Month_" & z), 0) & "</td>")
                                    Else
                                        sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #000000; font-weight: normal; font-size: 10pt;""> </td>")
                                    End If
                                Next
                                sb.Append("<td align=""right""  style=""font-family:Times New Roman; background-color: #A5A5A5; color: #000000; font-weight: bold; font-size: 10pt;""> " & FormatDecimal(dtTotal.Rows(i).Item("Total_Current_Year"), 0) & "</td>")
                                sb.Append("</tr>")
                            End If
                        Next
                        sb.Append("</table>") 'tblDetail
                    End If
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End If 'dtCompany
            End Sub
            Public Shared Sub CycleReportTotal_1(ByVal Year As Integer)
                Dim sql As String = "SELECT * FROM SMS_LKF_Data_Cycle_Total_1 WHERE   Year=" & Year & " Order by Id"
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                If dt.Rows.Count > 0 Then
                    Dim TotalCol As Integer = 3 + 53
                    Dim Color_1 As String = "#F2DDDC"
                    Dim Color_2 As String = "#DBEEF3"
                    Dim Color As String = ""
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChuKyTong_1 .xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">TRUNG TÂM LUCKY FONE</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO TỔNG HỢP THEO KỲ PHÁT HÀNH VÉ XỔ SỐ - MẠNG, ĐẦU SỐ </td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblHeader
                    sb.Append("<table id=""tblParam1"" border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">STT </td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tiêu chí </td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tổng</td>")
                    For i As Integer = 1 To 53
                        sb.Append("<td align=""center""   style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: normal; font-size: 12pt;"">Kỳ " & i & "</td>")
                    Next
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblParam1
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")

                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                    Dim CurrentWeek As Integer = Util.DateTimeFomat.GetWeekNumber(Now)
                    Dim vOrder As Integer = 1
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(j).Item("Criteria_Report_En") = "Total_Operator" Or dt.Rows(j).Item("Criteria_Report_En") = "Total_ShortCode" Then
                            Color = "#A5A5A5"
                            vOrder = 0
                        Else
                            Color = "#FFFFFF"
                        End If
                        sb.Append("<tr>")
                        If dt.Rows(j).Item("Criteria_Report_En") = "Total_Operator" Or dt.Rows(j).Item("Criteria_Report_En") = "Total_ShortCode" Then
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> </td>")
                        Else
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">" & vOrder & "</td>")
                        End If
                        sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt.Rows(j).Item("Criteria_Report_Vi") & "</td>")
                        sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt.Rows(j).Item("Total_Cycle"), 0) & "</td>")
                        For k As Integer = 1 To 53
                            If k <= CurrentWeek Then
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">" & FormatDecimal(dt.Rows(j).Item("Cycle_" & k), 0) & "</td>")
                            Else
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> </td>")
                            End If
                        Next
                        vOrder = vOrder + 1
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>") 'tblDetail
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td  style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;""  >Người lập biểu:   </td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblBound
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()

                End If
            End Sub
            Public Shared Sub CycleReportTotal_2(ByVal Year As Integer)
                Dim sql As String = "SELECT * FROM SMS_LKF_Data_Cycle_Total_2 WHERE   Year=" & Year & " Order by Region_Id,"
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                If dt.Rows.Count > 0 Then
                    Dim TotalCol As Integer = 3 + 53
                    Dim Color_1 As String = "#F2DDDC"
                    Dim Color_2 As String = "#DBEEF3"
                    Dim Color As String = ""
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChuKyTong_1 .xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">TRUNG TÂM LUCKY FONE</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=" & TotalCol & " style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO TỔNG HỢP THEO KỲ PHÁT HÀNH VÉ XỔ SỐ - MẠNG, ĐẦU SỐ </td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblHeader
                    sb.Append("<table id=""tblParam1"" border=""1"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">STT </td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tiêu chí </td>")
                    sb.Append("<td align=""center""  style=""font-family:Times New Roman; background-color: #2B7B69;color: #FFFFFF; color: #000000; font-weight: bold; font-size: 12pt;"">Tổng</td>")
                    For i As Integer = 1 To 53
                        sb.Append("<td align=""center""   style=""font-family:Times New Roman; background-color: " & Color_1 & "; color: #000000; font-weight: normal; font-size: 12pt;"">Kỳ " & i & "</td>")
                    Next
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblParam1
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")

                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                    Dim CurrentWeek As Integer = Util.DateTimeFomat.GetWeekNumber(Now)
                    Dim vOrder As Integer = 1
                    For j As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(j).Item("Criteria_Report_En") = "Total_Operator" Or dt.Rows(j).Item("Criteria_Report_En") = "Total_ShortCode" Then
                            Color = "#A5A5A5"
                            vOrder = 0
                        Else
                            Color = "#FFFFFF"
                        End If
                        sb.Append("<tr>")
                        If dt.Rows(j).Item("Criteria_Report_En") = "Total_Operator" Or dt.Rows(j).Item("Criteria_Report_En") = "Total_ShortCode" Then
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> </td>")
                        Else
                            sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">" & vOrder & "</td>")
                        End If
                        sb.Append("<td align=""center"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: bold; font-size: 12pt;"">" & dt.Rows(j).Item("Criteria_Report_Vi") & "</td>")
                        sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: bold; font-size: 12pt;"">" & FormatDecimal(dt.Rows(j).Item("Total_Cycle"), 0) & "</td>")
                        For k As Integer = 1 To 53
                            If k <= CurrentWeek Then
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;"">" & FormatDecimal(dt.Rows(j).Item("Cycle_" & k), 0) & "</td>")
                            Else
                                sb.Append("<td align=""right"" valign=""middle"" style=""font-family:Times New Roman; background-color: " & Color & "; color: #000000; font-weight: normal; font-size: 12pt;""> </td>")
                            End If
                        Next
                        vOrder = vOrder + 1
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>") 'tblDetail
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td  style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style= ""background-color: #FFFFFF; font-family:Times New Roman; font-style: italic; font-size: 12pt;""  >Người lập biểu:   </td>")
                    sb.Append("</tr>")
                    sb.Append("</table>") 'tblBound
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()

                End If
            End Sub
#Region "Data Table"
            Public Shared Function IsDataTable(ByVal Company_Id As Integer) As String
                Select Case Company_Id
                    Case Constants.Company.CompanyId._AnGiang
                        Return Constants.Company.CompanyText._AnGiang
                    Case Constants.Company.CompanyId._BacLieu
                        Return Constants.Company.CompanyText._BacLieu
                    Case Constants.Company.CompanyId._BenTre
                        Return Constants.Company.CompanyText._BenTre
                    Case Constants.Company.CompanyId._BinhDuong
                        Return Constants.Company.CompanyText._BinhDuong
                    Case Constants.Company.CompanyId._BinhPhuoc
                        Return Constants.Company.CompanyText._BinhPhuoc
                    Case Constants.Company.CompanyId._BinhThuan
                        Return Constants.Company.CompanyText._BinhThuan
                    Case Constants.Company.CompanyId._CaMau
                        Return Constants.Company.CompanyText._CaMau
                    Case Constants.Company.CompanyId._CanTho
                        Return Constants.Company.CompanyText._CanTho
                    Case Constants.Company.CompanyId._DongNai
                        Return Constants.Company.CompanyText._DongNai
                    Case Constants.Company.CompanyId._DongThap
                        Return Constants.Company.CompanyText._DongThap
                    Case Constants.Company.CompanyId._HauGiang
                        Return Constants.Company.CompanyText._HauGiang
                    Case Constants.Company.CompanyId._HCM
                        Return Constants.Company.CompanyText._HCM
                    Case Constants.Company.CompanyId._KienGiang
                        Return Constants.Company.CompanyText._KienGiang
                    Case Constants.Company.CompanyId._LamDong
                        Return Constants.Company.CompanyText._LamDong
                    Case Constants.Company.CompanyId._LongAn
                        Return Constants.Company.CompanyText._LongAn
                    Case Constants.Company.CompanyId._SocTrang
                        Return Constants.Company.CompanyText._SocTrang
                    Case Constants.Company.CompanyId._TayNinh
                        Return Constants.Company.CompanyText._TayNinh
                    Case Constants.Company.CompanyId._TienGiang
                        Return Constants.Company.CompanyText._TienGiang
                    Case Constants.Company.CompanyId._TraVinh
                        Return Constants.Company.CompanyText._TraVinh
                    Case Constants.Company.CompanyId._VinhLong
                        Return Constants.Company.CompanyText._VinhLong
                    Case Constants.Company.CompanyId._VungTau
                        Return Constants.Company.CompanyText._VungTau
                    Case Constants.Company.CompanyId._BinhDinh
                        Return Constants.Company.CompanyText._BinhDinh
                    Case Constants.Company.CompanyId._DakLak
                        Return Constants.Company.CompanyText._DakLak
                    Case Constants.Company.CompanyId._DakNong
                        Return Constants.Company.CompanyText._DakNong
                    Case Constants.Company.CompanyId._DaNang
                        Return Constants.Company.CompanyText._DaNang
                    Case Constants.Company.CompanyId._GiaLai
                        Return Constants.Company.CompanyText._GiaLai
                    Case Constants.Company.CompanyId._NinhThuan
                        Return Constants.Company.CompanyText._NinhThuan
                    Case Constants.Company.CompanyId._KhanhHoa
                        Return Constants.Company.CompanyText._KhanhHoa
                    Case Constants.Company.CompanyId._KonTum
                        Return Constants.Company.CompanyText._KonTum
                    Case Constants.Company.CompanyId._PhuYen
                        Return Constants.Company.CompanyText._PhuYen
                    Case Constants.Company.CompanyId._QuangBinh
                        Return Constants.Company.CompanyText._QuangBinh
                    Case Constants.Company.CompanyId._QuangNgai
                        Return Constants.Company.CompanyText._QuangNgai
                    Case Constants.Company.CompanyId._QuangNam
                        Return Constants.Company.CompanyText._QuangNam
                    Case Constants.Company.CompanyId._QuangTri
                        Return Constants.Company.CompanyText._QuangTri
                    Case Constants.Company.CompanyId._Hue
                        Return Constants.Company.CompanyText._Hue
                    Case Constants.Company.CompanyId._MienBacKhac
                        Return Constants.Company.CompanyText._MienBacKhac
                    Case Constants.Company.CompanyId._MienNam
                        Return Constants.Company.CompanyText._MienNam
                    Case Constants.Company.CompanyId._MienTrung
                        Return Constants.Company.CompanyText._MienTrung
                    Case Constants.Company.CompanyId._MienBac
                        Return Constants.Company.CompanyText._MienBac
                    Case Constants.Company.CompanyId._ThuDo
                        Return Constants.Company.CompanyText._ThuDo
                    Case Else
                        Return ""
                End Select

            End Function
#End Region

        End Class
#End Region
#Region "SMS"
        Public Class _SMS
            Public Shared Sub MobileTrafficSummery(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsError As Boolean, _
                                                   ByVal IsRefund As Boolean, _
                                                   ByVal IsDeptId As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean, _
                                                   ByVal IsRouting As Boolean, _
                                                   ByVal IsOperator As Boolean, _
                                                   ByVal IsRangOfShortCode As Boolean, _
                                                   ByVal IsShortCode As Boolean, _
                                                   ByVal IsKeyWord As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsHour As Boolean, _
                                                   ByVal IsCate_1 As Boolean, _
                                                   ByVal IsCate_2 As Boolean)
                Dim InitTotalCol As Integer = 7
                If IsError = True Then
                    InitTotalCol = InitTotalCol + 6
                End If
                If IsRefund = True Then
                    InitTotalCol = InitTotalCol + 4
                End If
                If IsOperator = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsRangOfShortCode = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsShortCode = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsKeyWord = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDeptId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCate_1 = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCate_2 = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsRouting = True Then
                    InitTotalCol = InitTotalCol + 1
                End If

                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO SMS MO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">  BÁO CÁO SẢN LƯỢNG SMS THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CDR</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                If IsError = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MO LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CDR LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCO LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG LỖI</td>")
                End If
                If IsRefund = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> MO HOÀN CƯỚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG HOÀN CƯỚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCO HOÀN CƯỚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG HOÀN CƯỚC</td>")
                End If
                If IsOperator = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                End If
                If IsRangOfShortCode = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DẢI SỐ</td>")
                End If
                If IsShortCode = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐẦU SỐ</td>")
                End If
                If IsKeyWord = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ DỊCH VỤ</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsDeptId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN</td>")
                End If
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If
                If IsCate_1 = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NHÓM DỊCH VỤ</td>")
                End If
                If IsCate_2 = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                End If
                If IsRouting = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỊNH TUYẾN</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MO").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MT") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CDR").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Share") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Operator").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Total").ToString & "   </td>")
                    If IsError = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MO_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MT_Error") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CDR_Error").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Share_Error") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Operator_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Total_Error").ToString & "   </td>")
                    End If
                    If IsRefund = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MO_Refund").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Share_Refund") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Operator_Refund").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Total_Refund").ToString & "   </td>")
                    End If
                    If IsOperator = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Mobile_Operator").ToString & "   </td>")
                    End If
                    If IsRangOfShortCode = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Range_Short_Code") & "   </td>")
                    End If
                    If IsShortCode = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Short_Code") & "   </td>")
                    End If
                    If IsKeyWord = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Key_Word") & "   </td>")
                    End If
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Hour") & "   </td>")
                    End If
                    If IsDeptId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Department_Text") & "   </td>")
                    End If
                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    If IsCate_1 = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Cate1_Text") & "   </td>")
                    End If
                    If IsCate_2 = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Cate2_Text") & "   </td>")
                    End If
                    If IsRouting = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("ThirdParty_Text") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub MobileTrafficTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_Telcos_Total_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 10
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO ĐỐI SOÁT VỚI CÁC TELCOS</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">SẢN LƯỢNG MO,MT,CDR THEO THÁNG</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐẦU SỐ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MO GATEWAY</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT GATEWAY</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CDR GATEWAY</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MO REPORT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MT REPORT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CDR REPORT</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MonthData") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Mobile_Operator") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Short_Code").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MO").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MT").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CDR").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MO_Rpt").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("MT_Rpt").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CDR_Rpt").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub SMS9029OndemandRev(ByVal sql As String, ByVal vCreateby As String, _
                                             ByVal IsOperator As Boolean, _
                                             ByVal IsPartnerId As Boolean, _
                                             ByVal IsKeyWord As Boolean, _
                                             ByVal IsUserId As Boolean, _
                                             ByVal IsPriceUnit As Boolean, _
                                             ByVal IsDate As Boolean, _
                                             ByVal IsHour As Boolean)
                Dim InitTotalCol As Integer = 6
                If IsOperator = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsKeyWord = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsUserId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_9029_DoiTac" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO SMS 9029</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO SẢN LƯỢNG SMS MO 9029 VỚI ĐỐI TÁC</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsUserId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHÁCH HÀNG</td>")
                End If
                If IsKeyWord = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ</td>")
                End If
                If IsOperator = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                End If
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CDR</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vYear").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth") & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vDate").ToString & "  </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vHour") & "  </td>")
                    End If
                    If IsUserId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vUser_Id").ToString & "   </td>")
                    End If
                    If IsKeyWord = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vContentCode").ToString & "   </td>")
                    End If
                    If IsOperator = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vOperator").ToString & "   </td>")
                    End If
                    If IsPriceUnit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCharging_Price").ToString & "  </td>")
                    End If
                    
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMoneyVMG") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMoneyOperator") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMoneyTotal") & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vPartnerName") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "VINABOX"
        Public Class _Vinabox
            Public Shared Sub VinaboxTrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsHour As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsTransactionType As Boolean, _
                                                   ByVal IsChannel_Text As Boolean, _
                                                   ByVal IsApp_Text As Boolean, _
                                                   ByVal IsPlan_Text As Boolean, _
                                                   ByVal IsContent_Type_Text As Boolean, _
                                                   ByVal IsPriceUnit As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean, _
                                                   ByVal IsUrl As Boolean)
                Dim InitTotalCol As Integer = 7

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsTransactionType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannel_Text = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsApp_Text = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPlan_Text = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContent_Type_Text = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsUrl = True Then
                    InitTotalCol = InitTotalCol + 1
                End If

                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = VinaboxTotal_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ VINABOX</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG VINABOX THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsTransactionType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIAO DỊCH</td>")
                End If
                If IsChannel_Text = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH</td>")
                End If
                If IsApp_Text = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ỨNG DỤNG</td>")
                End If
                If IsPlan_Text = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GÓI DỊCH VỤ</td>")
                End If
                If IsContent_Type_Text = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG</td>")
                End If
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG</td>")

                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If
                If IsUrl = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LINK TRUYỀN THÔNG</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Hour") & "   </td>")
                    End If
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    If IsTransactionType = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Transaction_Type_Text").ToString & "   </td>")
                    End If
                    If IsChannel_Text = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Channel_Text").ToString & "   </td>")
                    End If
                    If IsApp_Text = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("App_Text").ToString & "   </td>")
                    End If
                    If IsPlan_Text = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Plan_Text").ToString & "   </td>")
                    End If
                    If IsContent_Type_Text = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Content_Type_Text").ToString & "   </td>")
                    End If
                    If IsPriceUnit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Price_Unit") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Telcos") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Telcos_VMG").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Partner_VMG") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Partner").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Quantity").ToString & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    If IsUrl = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Url_Text") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "VISHARE"
        Public Class _Vishare
            Public Shared Sub VishareTrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsTransactionType As Boolean, _
                                                   ByVal IsPriceUnit As Boolean, _
                                                   ByVal IsRegister As Boolean, _
                                                   ByVal IsCancel As Boolean, _
                                                   ByVal IsRenewal As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean, _
                                                   ByVal IsUrl As Boolean)
                Dim InitTotalCol As Integer = 6

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsTransactionType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsRegister = True Then
                    InitTotalCol = InitTotalCol + 4
                End If
                If IsCancel = True Then
                    InitTotalCol = InitTotalCol + 4
                End If
                If IsRenewal = True Then
                    InitTotalCol = InitTotalCol + 3
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsUrl = True Then
                    InitTotalCol = InitTotalCol + 1
                End If


                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = VishareTotal_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ VISHARE</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG VISHARE THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsTransactionType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                End If
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU ĐỐI TÁC</td>")
                If IsRegister = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG ĐĂNG KÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐĂNG KÝ KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐĂNG KÝ KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LŨY KẾ ĐĂNG KÝ</td>")
                End If
                If IsCancel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG HỦY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỦY KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỦY KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LŨY KẾ HỦY</td>")
                End If
                If IsRenewal = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG GIA HẠN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIA HẠN KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIA HẠN KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIAO DỊCH TRỪ TIỀN</td>")
                End If

                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If
              
                If IsUrl = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LINK TRUYỀN THÔNG</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If
                
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    If IsTransactionType = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Transaction_Type_Text").ToString & "   </td>")
                    End If
                    If IsPriceUnit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Price_Unit") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Money_VMG_Telcos") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Money_Telcos_VMG").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Money_Partner_VMG") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Money_VMG_Partner").ToString & "   </td>")
                    If IsRegister = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Registration").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Registration") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Registration").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Active_Member") & "  </td>")
                    End If
                    If IsCancel = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Cancel").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Cancel") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Cancel").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Cancel_Member").ToString & "   </td>")
                    End If
                    If IsRenewal = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Renewal").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Renewal") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Renewal").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Registration_Charge").ToString & "   </td>")
                    End If

                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    If IsUrl = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Url_Text") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "BIL"
        Public Class _Bil
            Public Shared Sub BilBrandWorkFollowList(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Brand_Bil_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 10
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS BRAND NAME</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilBrandReportDetail(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Brand_Bil_Detail_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 14
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO CHI TIẾT TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS BRAND NAME</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilBrandReportTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Brand_Bil_Total_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 12
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO TỔNG HỢP TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS BRAND NAME</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Year") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub

            Public Shared Sub BilSMSWorkFollowList(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Bil_SMS" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 10
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS MO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilSMSReportTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_Bil_Total_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 12
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO TỔNG HỢP TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS MO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Year") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilSMSReportDetail(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_Bil_Detail_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 14
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO CHI TIẾT TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ SMS MO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment_1") + dt.Rows(j).Item("Total_Payment_2") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub

            Public Shared Sub BilScratchWorkFollowList(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Bil_Scratch" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 10
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilScratchReportTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_Scratch_Card_Total_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 12
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO TỔNG HỢP TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Year") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilScratchReportDetail(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Bil_Scratch_Card_Detail_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 14
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO CHI TIẾT TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment_1") + dt.Rows(j).Item("Total_Payment_2") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub

            Public Shared Sub BilS2WorkFollowList(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Bil_S2" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 10
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ S2</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilS2ReportTotal(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SMS_S2_Total_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 12
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO TỔNG HỢP TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ S2</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Year") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub BilS2ReportDetail(ByVal sql As String, ByVal vCreateby As String)
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Bil_S2_Detail_" & Now.Year & "-" & Now.Month & "-" & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                Dim InitTotalCol As Integer = 14
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">QUẢN LÝ ĐỐI SOÁT THANH TOÁN</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO CHI TIẾT TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN DỊCH VỤ S2</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỐNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG ĐỐI SOÁT</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BỘ PHẬN THỰC HIỆN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THANH TOÁN</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CÔNG NỢ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KHỞI TẠO</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G CẬP NHẬT</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Month") & "/" & dt.Rows(j).Item("Year") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Order_Current").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Task_Text_Curent").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Dept_Text_Execute_Current").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Debts_Text").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Revenue").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Payment_1") + dt.Rows(j).Item("Total_Payment_2") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Debts").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & DateTime.Parse(dt.Rows(j).Item("Update_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "CHARGING"
        Public Class _Charging
            Public Utils As New Util.Numeric
            Public Shared Sub ChargingTotalMonth(ByVal sql As String, _
                                                   ByVal vCreateby As String, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsHour As Boolean, _
                                                   ByVal IsCardType As Boolean, _
                                                   ByVal IsChannel As Boolean, _
                                                   ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 6
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannel = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardChargingMonth_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO THEO THÁNG</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                If IsChannel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardCharging), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vYear") & "  </td>")
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth") & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vDate").ToString & "  </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vHour").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    If IsChannel = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vChannel").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Card") & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Amount") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub ChargingTotalOnline(ByVal sql As String, _
                                                ByVal vCreateby As String, _
                                                ByVal IsPartnerId As Boolean, _
                                                ByVal IsDate As Boolean, _
                                                ByVal IsHour As Boolean, _
                                                ByVal IsCardType As Boolean, _
                                                ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 5
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardChargingMonth_" & Now.Year & Util.StringBuilder.ConvertDigit(Now.Month) & Util.StringBuilder.ConvertDigit(Now.Day) & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO THEO THÁNG</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardCharging), sql)
                Dim vTotal_Card As Integer = 0
                Dim vTotal_Amount As Decimal = 0

                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth") & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vDate").ToString & "  </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vHour").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("vTotal_Card"), 0) & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("vTotal_Amount"), 0) & "   </td>")
                    sb.Append("</tr>")
                    vTotal_Card = vTotal_Card + dt.Rows(j).Item("vTotal_Card")
                    vTotal_Amount = vTotal_Amount + dt.Rows(j).Item("vTotal_Amount")
                Next
                sb.Append("<tr>")
                sb.Append("<td align=""left"" colspan=" & InitTotalCol - 2 & "    style=""font-family: Times New Roman; font-size: 12pt; text-decoration: underline; font-weight: bold"">TỔNG CỘNG:</td>")
                sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt;font-weight: bold "" >" & Util.Numeric.Number2Decimal(vTotal_Card, 0) & "</td>")
                sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt;font-weight: bold "" >" & Util.Numeric.Number2Decimal(vTotal_Amount, 0) & " </td>")
                sb.Append("</tr>")

                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub ChargingTotalYear(ByVal sql As String, _
                                                ByVal vCreateby As String, _
                                                ByVal IsPartnerId As Boolean, _
                                                ByVal IsMonth As Boolean, _
                                                ByVal IsCardType As Boolean, _
                                                ByVal IsChannel As Boolean, _
                                                ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 5
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsMonth = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannel = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardChargingYear_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO THEO NĂM</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                If IsMonth = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                If IsChannel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardCharging), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vYear") & "  </td>")
                    If IsMonth = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    If IsChannel = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vChannel").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Card").ToString & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Amount").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub ChargingBizMonth(ByVal sql As String, _
                                                ByVal vCreateby As String, _
                                                ByVal IsPartnerId As Boolean, _
                                                ByVal IsDate As Boolean, _
                                                ByVal IsHour As Boolean, _
                                                ByVal IsCardType As Boolean, _
                                                ByVal IsChannel As Boolean, _
                                                ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 6
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannel = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardChargingBizMonth_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO THEO THÁNG - TRUNG TÂM KINH DOANH</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                If IsChannel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vYear") & "  </td>")
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth") & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vDate").ToString & "  </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vHour").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    If IsChannel = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vChannel").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Card") & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Amount") & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub ChargingBizOnline(ByVal sql As String, _
                                              ByVal vCreateby As String, _
                                              ByVal IsPartnerId As Boolean, _
                                              ByVal IsDate As Boolean, _
                                              ByVal IsHour As Boolean, _
                                              ByVal IsCardType As Boolean, _
                                              ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 5
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardCharging_Partner_" & Now.Year & Util.StringBuilder.ConvertDigit(Now.Month) & Util.StringBuilder.ConvertDigit(Now.Day) & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO ĐỐI TÁC VMG</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sql)
                Dim vTotal_Card As Integer = 0
                Dim vTotal_Amount As Decimal = 0

                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth") & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vDate").ToString & "  </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vHour").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("vTotal_Card"), 0) & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("vTotal_Amount"), 0) & "   </td>")
                    sb.Append("</tr>")
                    vTotal_Card = vTotal_Card + dt.Rows(j).Item("vTotal_Card")
                    vTotal_Amount = vTotal_Amount + dt.Rows(j).Item("vTotal_Amount")
                Next
                sb.Append("<tr>")
                sb.Append("<td align=""left"" colspan=" & InitTotalCol - 2 & "    style=""font-family: Times New Roman; font-size: 12pt; text-decoration: underline; font-weight: bold"">TỔNG CỘNG:</td>")
                sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt;font-weight: bold "" >" & Util.Numeric.Number2Decimal(vTotal_Card, 0) & "</td>")
                sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt;font-weight: bold "" >" & Util.Numeric.Number2Decimal(vTotal_Amount, 0) & " </td>")
                sb.Append("</tr>")

                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub ChargingBizYear(ByVal sql As String, _
                                                ByVal vCreateby As String, _
                                                ByVal IsPartnerId As Boolean, _
                                                ByVal IsMonth As Boolean, _
                                                ByVal IsCardType As Boolean, _
                                                ByVal IsChannel As Boolean, _
                                                ByVal IsPriceUnit As Boolean)
                Dim InitTotalCol As Integer = 5
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsMonth = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsCardType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannel = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = CardChargingBizYear_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000"">   </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">HỆ THỐNG THẺ CÀO</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO DOANH THU THẺ CÀO THEO NĂM - TRUNG TÂM KINH DOANH</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail"" border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NĂM</td>")
                If IsMonth = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                End If
                If IsCardType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI THẺ</td>")
                End If
                If IsChannel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỆNH GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LƯỢNG THẺ</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU</td>")
                sb.Append("</tr>")

                Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsPartnerId = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vSubcp_name") & "  </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vYear") & "  </td>")
                    If IsMonth = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vMonth").ToString & "  </td>")
                    End If
                    If IsCardType = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardName").ToString & "   </td>")
                    End If
                    If IsChannel = True Then
                        sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vChannel").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""center"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vStatus").ToString & "   </td>")
                    If IsPriceUnit = True Then
                        sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vCardAmount").ToString & "   </td>")
                    End If
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Card").ToString & "   </td>")
                    sb.Append("<td align=""right"" style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("vTotal_Amount").ToString & "   </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td ></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "GAME PORTAL"
        Public Class _GamePortal
            Public Shared Sub GamePortalTrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsHour As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsChannelId As Boolean, _
                                                   ByVal IsServiceId As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean)
                Dim InitTotalCol As Integer = 6

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannelId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsServiceId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If

                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = GamePortalTotal_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ GAME PORTAL</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG GAME PORTAL THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsChannelId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH GAME</td>")
                End If
                If IsServiceId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU ĐỐI TÁC</td>")

                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Hour") & "   </td>")
                    End If
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    If IsChannelId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Channel_Text").ToString & "   </td>")
                    End If
                    If IsServiceId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Service_Text") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Telcos") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Telcos_VMG").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Partner_VMG") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Partner").ToString & "   </td>")

                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "S2"
        Public Class _S2
            Public Shared Sub S2TrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsMobile_Operator As Boolean, _
                                                   ByVal IsAccess_Number As Boolean, _
                                                   ByVal IsPrice_Unit As Boolean, _
                                                   ByVal IsService_Id As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean)
                Dim InitTotalCol As Integer = 6

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsMobile_Operator = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsAccess_Number = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPrice_Unit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsService_Id = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = S2_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ SUBSCRIPTION SERVICE (S2)</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG S2 THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsMobile_Operator = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                End If
                If IsAccess_Number = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐẦU SỐ</td>")
                End If
                If IsPrice_Unit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                If IsService_Id = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU ĐỐI TÁC</td>")

                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & " </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "</td>")
                    End If
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "</td>")
                    End If
                    If IsMobile_Operator = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Mobile_Operator").ToString & "</td>")
                    End If
                    If IsAccess_Number = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Access_Number") & "</td>")
                    End If
                    If IsPrice_Unit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Price_Unit") & "</td>")
                    End If
                    If IsService_Id = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Service_Text") & "</td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Telcos") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Telcos_VMG").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Partner_VMG") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Partner").ToString & "   </td>")

                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
            Public Shared Sub S2KpiViGame9029(ByVal sql As String )
                Dim InitTotalCol As Integer = 15
                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = Kpi_Vigame_9029" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ SUBSCRIPTION SERVICE (S2) 9029</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO KPI VIGAME</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""2%"">STT</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">NGÀY</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">THUÊ BAO LŨY KẾ</td>")
                sb.Append("<td align=""center"" colspan=""3"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""21%"">ĐĂNG KÝ MỚI</td>")
                sb.Append("<td align=""center"" colspan=""3"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""21%"">THUÊ BAO HỦY</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG GIA HẠN THÀNH CÔNG</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG GIA HẠN</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG TIỀN ĐK</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG TIỀN GIA HẠN</td>")
                sb.Append("<td align=""center"" rowspan=""2"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG DOANH THU</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">SMS</td>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">WAP</td>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG ĐK MỚI</td>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">SMS</td>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">WAP</td>")
                sb.Append("<td align=""center""  style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""7%"">TỔNG HỦY</td>")

                sb.Append("</tr>")

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_1"), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & " </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("NGAY").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TEN_DOI_TAC") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("THUE_BAO_LUY_KE").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DANG_KY_MOI_SMS") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DANG_KY_MOI_WAP").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_DANG_KY_MOI").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("HUY_SMS").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("HUY_WAP").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_HUY").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("GIA_HAN_THANH_CONG").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_GIA_HAN").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_TIEN_TU_DANG_KY").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_TIEN_TU_GIA_HAN").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("TONG_DOANH_THU").ToString & "   </td>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập </td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "SIM TOOL KIT"
        Public Class _STK
            Public Shared Sub SimToolKitTrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsHour As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsChannelId As Boolean, _
                                                   ByVal IsServiceId As Boolean, _
                                                   ByVal IsAccess_Number As Boolean, _
                                                   ByVal IsPrice_Unit As Boolean)
                Dim InitTotalCol As Integer = 7

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsHour = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsChannelId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsServiceId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsAccess_Number = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPrice_Unit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If

                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SimToolKitTotal_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ SIM TOOL KIT</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG STK THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsHour = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIỜ</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRẠNG THÁI</td>")

                If IsChannelId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KÊNH DỊCH VỤ</td>")
                End If
                If IsServiceId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                End If
                If IsAccess_Number = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐẦU SỐ</td>")
                End If
                If IsPrice_Unit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG CDR</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VNM</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU NMS</td>")
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If
                    If IsHour = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Hour") & "   </td>")
                    End If
                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Status_Text").ToString & "   </td>")
                    If IsChannelId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Channel_Text").ToString & "   </td>")
                    End If
                    If IsServiceId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Service_Text") & "   </td>")
                    End If
                    If IsAccess_Number = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Access_Number") & "   </td>")
                    End If
                    If IsPrice_Unit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Price_Unit") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("CDR").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VNM").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_NMS") & "  </td>")
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "PREGNANCY DIARY"
        Public Class _PregnancyDiary
            Public Shared Sub PregnancyDiaryTrafficTotal(ByVal sql As String, ByVal vCreateby As String, _
                                                   ByVal IsDate As Boolean, _
                                                   ByVal IsDayOfWeek As Boolean, _
                                                   ByVal IsTransactionType As Boolean, _
                                                   ByVal IsPriceUnit As Boolean, _
                                                   ByVal IsRegister As Boolean, _
                                                   ByVal IsCancel As Boolean, _
                                                   ByVal IsRenewal As Boolean, _
                                                   ByVal IsPartnerId As Boolean, _
                                                   ByVal IsContract As Boolean, _
                                                   ByVal IsUrl As Boolean)
                Dim InitTotalCol As Integer = 6

                If IsDate = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsDayOfWeek = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsTransactionType = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsPriceUnit = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsRegister = True Then
                    InitTotalCol = InitTotalCol + 4
                End If
                If IsCancel = True Then
                    InitTotalCol = InitTotalCol + 4
                End If
                If IsRenewal = True Then
                    InitTotalCol = InitTotalCol + 3
                End If
                If IsPartnerId = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsContract = True Then
                    InitTotalCol = InitTotalCol + 1
                End If
                If IsUrl = True Then
                    InitTotalCol = InitTotalCol + 1
                End If


                HttpContext.Current.Response.ContentType = "application/ms-excel"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = NKMTTotal_" & Now.Year & Now.Month & Now.Day & ".xls")
                Dim sb As New StringBuilder()
                sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "  style=""font-family:Times New Roman; background-color: #FFFFFF; color: #FF0000; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "   style=""font-family:Times New Roman; font-size: 12pt; font-weight: bold; color: #0070C0"">BÁO CÁO DỊCH VỤ NHẬT KÝ MANG THAI</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 14pt; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO SẢN LƯỢNG NHẬT KÝ MANG THAI THEO NGÀY</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" colspan=" & InitTotalCol & "    style=""font-family: Times New Roman; font-size: 9pt; text-decoration: underline; font-weight: bold; color: #000000""></td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append("<table id=""tblDetail""  border=""1"" bordercolor=""#cccccc"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 12pt; width=""100%"">")
                sb.Append("<tr>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                If IsDate = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                End If
                If IsDayOfWeek = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỨ</td>")
                End If
                If IsTransactionType = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                End If
                If IsPriceUnit = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƠN GIÁ</td>")
                End If
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU KHÁCH HÀNG</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU TELCOS</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU ĐỐI TÁC</td>")
                sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DOANH THU VMG SAU ĐỐI TÁC</td>")
                If IsRegister = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG ĐĂNG KÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐĂNG KÝ KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐĂNG KÝ KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LŨY KẾ ĐĂNG KÝ</td>")
                End If
                If IsCancel = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG HỦY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỦY KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỦY KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LŨY KẾ HỦY</td>")
                End If
                If IsRenewal = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG GIA HẠN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIA HẠN KÊNH WAP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIA HẠN KÊNH SMS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GIAO DỊCH TRỪ TIỀN</td>")
                End If

                If IsPartnerId = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                End If
                If IsContract = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỢP ĐỒNG</td>")
                End If

                If IsUrl = True Then
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LINK TRUYỀN THÔNG</td>")
                End If
                sb.Append("</tr>")
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
                For j As Integer = 0 To dt.Rows.Count - 1
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & j + 1 & "   </td>")
                    If IsDate = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Day") & "   </td>")
                    End If

                    If IsDayOfWeek = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("DayOfWeek_Text") & "   </td>")
                    End If
                    If IsTransactionType = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Transaction_Type_Text").ToString & "   </td>")
                    End If
                    If IsPriceUnit = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Price_Unit") & "   </td>")
                    End If
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Ccare").ToString & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Telcos") & "   </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Telcos_VMG").ToString & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_Partner_VMG") & "  </td>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Money_VMG_Partner").ToString & "   </td>")
                    If IsRegister = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Registration").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Registration") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Registration").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Active_Member") & "  </td>")
                    End If
                    If IsCancel = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Cancel").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Cancel") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Cancel").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Cancel_Member").ToString & "   </td>")
                    End If
                    If IsRenewal = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Renewal").ToString & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("WAP_Renewal") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("SMS_Renewal").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Total_Registration_Charge").ToString & "   </td>")
                    End If

                    If IsPartnerId = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Partner_Code") & "   </td>")
                    End If
                    If IsContract = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Contract_Code") & "   </td>")
                    End If
                    If IsUrl = True Then
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 12pt "" >" & dt.Rows(j).Item("Url_Text") & "   </td>")
                    End If
                    sb.Append("</tr>")
                Next
                sb.Append("</table>")
                sb.Append("</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                sb.Append("</tr>")
                sb.Append("<tr>")
                sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                sb.Append("</tr>")
                sb.Append("</table>")
                HttpContext.Current.Response.Write(sb.ToString())
                HttpContext.Current.Response.End()
            End Sub
        End Class
#End Region
#Region "KPI"
        Public Class _KPI
            Public Class Lott

                Public Shared Sub InputDataLot(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = NhapLieuXoSo_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG NHẬP LIỆU - KẾT QUẢ XỔ SỐ</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MIỀN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỈNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Region_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Company_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataLuckyNumber(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = NhapLieuSoiCau_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG NHẬP LIỆU - SOI CẦU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MIỀN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỈNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN SỬ DỤNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN NHẬP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Region_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Company_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataErr(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiNhapLieu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG NHẬP LIỆU - LỖI NHẬP LIỆU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỈNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Company_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputSoftwareErr(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SuCoPhanMemNhapLieu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG NHẬP LIỆU - SỰ CỐ PHẦN MỀM NHẬP LIỆU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỈNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Company_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalMTHandset(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianNhanMTVeMay_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN NHẬN MT VỀ MÁY</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ TRỌNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("dd-MM-yyyy") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Percentage").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_1").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_2").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalTimeProc(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianProcess_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN PROCESS</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ </td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("dd-MM-yyyy") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalMTTelcos(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianMTSangTelcos_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN MT SANG TELCOS</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("dd-MM-yyyy") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalSysErr(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiHeThong_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - LỖI HỆ THỐNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG T/G</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRỪ T/G</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("dd-MM-yyyy") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalMTErr(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = MTLoi_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - MT LỖI</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ MT LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("dd-MM-yyyy") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CcareComplain(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianXLKhieuNai_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG PHỤC VỤ KHÁCH HÀNG - THỜI GIAN XỬ LÝ KHIẾU NẠI</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHÁCH HÀNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG KHIẾU NẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN NHẬN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("User_Id")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Info")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CcareServe(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChamSocKH_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ XỔ SỐ</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG PHỤC VỤ KHÁCH HÀNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ PHỤC VỤ KHÁCH HÀNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KH CHỜ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MỨC ĐỘ HÀI LÒNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ PHỤC VỤ KH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ KH CHỜ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ HÀI LÒNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Total_Serve")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Total_Wait")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Satisfied") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Serve") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Wait").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Satisfied").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
            End Class
            Public Class Brand
                Public Shared Sub InputDataUpAdv(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = UpNoiDungQC_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO THỜI GIAN UP NỘI DUNG QUẢNG CÁO</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỔNG SỐ PHÚT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Program_Code") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataApproveBrandCcare(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = DuyetBrandCSKH_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO THỜI GIAN DUYỆT BRAND CSKH</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÃ CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỔNG SỐ PHÚT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Program_Code") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataError(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiNhapLieu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO LỖI NHẬP LIỆU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỔNG SỐ PHÚT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Program_Code") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataMTErrorNoCharge(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = MTLoiKhongTinhPhi_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000"">MT LỖI KHÔNG TÍNH PHÍ </td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG MT LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG TIN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> SỐ TIN LỖI CHO PHÉP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Program_Code") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_MT_Error") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_MT") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_MT_Error_Threshold") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Rate_Error") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InputDataSoftwareError(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiPhanMemNhapLieu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO LỖI PHẦN MỀM NHẬP LIỆU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%""> TỔNG SỐ PHÚT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Program_Code") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalQualityMTTelcos(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianTraTin_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN TRẢ TIN QC/CSKH</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƯỜNG TRẢ TIN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN TRẢ TIN(Giây)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN TRẢ TIN(Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ X/L CHẬM</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("TypeOf_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Sec") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Rate_Delay").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalQualityMTHandset(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianTraTinVeMayKH_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN TRẢ TIN VỀ MÁY KHÁCH HÀNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ MÁY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("TypeOf_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Mobile_Operator_Text") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("User_Id") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalQualitySystemError(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiHeThong_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - LỖI HỆ THỐNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Error_Desc")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TimeHandleCcareComplain(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianXLKhieuNai_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=13  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=13 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=13 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG PHỤC VỤ KHÁCH HÀNG - THỜI GIAN XỬ LÝ KHIẾU NẠI</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHÁCH HÀNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG KHIẾU NẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN NHẬN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("TypeOf_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Mobile_Operator_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Complain_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Handle_Text")) & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TotalHandleCcareComplain(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SoLuongKhieuNai_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=9 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG PHỤC VỤ KHÁCH HÀNG - SỐ LƯỢNG KHIẾU NẠI</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THÁNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG KHIẾU NẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGƯỠNG CHUẨN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">BƯỚC NHẢY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Month") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Complain") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Program") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Standar_Threshold_Handle") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Standar_Threshold_Handle_Over") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub ReportQuality(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChatLuongBaoCao_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG  BÁO CÁO</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG SỐ CHƯƠNG TRÌNH</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHƯƠNG TRÌNH LỖI CHO PHÉP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHƯƠNG TRÌNH LỖI BÁO CÁO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Program") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Program_Error") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Program_Error_Threshold") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub ReportTime(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianTraBaoCao_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO THỜI GIAN TRẢ  BÁO CÁO</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN IMPORT BÁO CÁO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN CHO PHÉP</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHÊNH LỆCH THỜI GIAN(GIỜ)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Standar_Threshold_Handle") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Hour") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CheckingQuality(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChatLuongDoiSoat_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG  ĐỐI SOÁT</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">SỐ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Error") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CheckingTime1(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TGGuiDoiTac_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> THỜI GIAN ĐSTC GỬI BIÊN BẢN ĐỐI SOÁT CHO ĐỐI TÁC</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G ĐSTC TỔNG HỢP SỐ LIỆU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G ĐSTC GỬI ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CheckingTime2(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TGGuiBanCungQCS_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> THỜI GIAN ĐSTC HOÀN THÀNH HỒ SƠ GỬI QCS</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G ĐSTC NHẬN BẢN CỨNG TỪ ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G ĐSTC GỬI QCS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub PaymentQuanlity1(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TGGuiYCThanhToan_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> THỜI GIAN QCS HOÀN THÀNH HỒ SƠ GỬI KẾ TOÁN</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G QCS NHẬN HỒ SÓ TỪ ĐSTC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G QCS GỬI HỒ SƠ CHO KT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub PaymentQuanlity2(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TGKTXuatHoaDon_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ SMS BRANDNAME</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> THỜI GIAN KẾ TOÁN XUẤT HÓA ĐƠN</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐỐI TÁC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KT NHẬN HỒ SÓ TỪ QCS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G KT XUẤT HÓA ĐƠN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Partner_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
            End Class
            Public Class ScratchCard
                Public Shared Sub TechnicalQualitySystemError(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = LoiHeThong_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ THẺ CÀO</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - LỖI HỆ THỐNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN BẮT ĐẦU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KẾT THÚC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Error_Desc")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Text") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_Time").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Error").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub HandleTransaction(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = XuLyGiaoDich_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ THẺ CÀO</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - XỬ LÝ GIAO DỊCH</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GD <1s</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GD 1s ĐẾN 2s</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GD >2s</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG SỐ GD</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GD PENDING</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ PENDING</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM X/L GD</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ PENDING</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Trans_1") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Trans_2") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Trans_3") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Trans") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Pending").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Rate_Pending").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("KPI_Handle_Transaction").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CheckingData(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TienDoDoiSoat_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ THẺ CÀO</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO TIẾN ĐỘ ĐỐI SOÁT</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G THỐNG NHẤT TELCOS</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G GỬI KẾ TOÁN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Mobile_Operator_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("TypeOf_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Day") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub OutBill(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TienDoThanhToan_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=14  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=14 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ THẺ CÀO</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=14 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO TIẾN ĐỘ XUẤT HÓA ĐƠN, TELCOS THANH TOÁN</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỂ LOẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G NHẬN THÔNG TIN TỪ ĐSTC</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G XUẤT HĐ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">T/G THANH TOÁN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHÊNH LỆCH T/G XUẤT HĐ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">CHÊNH LỆCH T/G THANH TOÁN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ XUẤT HĐ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THANH TOÁN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Mobile_Operator_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("TypeOf_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Payment_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Day_1") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Day_2") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_1") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total_2") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CcareComplain(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianXLKhieuNai_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI DỊCH VỤ THẺ CÀO</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG PHỤC VỤ KHÁCH HÀNG - THỜI GIAN XỬ LÝ KHIẾU NẠI</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG KHIẾU NẠI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NỘI DUNG XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN NHẬN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN (Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Complain_Text")) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & ReplaceSpecial(dt.Rows(j).Item("Handle_Text")) & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
            End Class
            Public Class Infras
                Public Shared Sub TechnicalQualitySystemDowntime(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ThoiGianDownTime_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - THỜI GIAN DOWNTIME TRÊN TOÀN HỆ THỐNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT SINH LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Total_Min"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Quantity_Total") & "</td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalQualityServerError(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = SuCoMayChu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - SỰ CỐ MÁY CHỦ</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">LOẠI LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT HIỆN LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Total_Min"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Quantity_Total") & "</td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TechnicalQualityServerPerformance(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = HieuNangMayChu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG KỸ THUẬT - HIỆU NĂNG MÁY CHỦ</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">RAM, CPU, HDD</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGƯỠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GHI CHÚ</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Standar_Threshold_Handle") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "</td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub InternetBandwidth(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = BangThongInternet_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG MẠNG - BĂNG THÔNG INTERNET</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƯỜNG TRUYỀN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỶ LỆ BĂNG THÔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Ratio_Percent"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub LeaselineBandwidth(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = BangThongKenhRieng_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG MẠNG - BĂNG THÔNG KÊNH RIÊNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐƯỜNG TRUYỀN</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ TỶ LỆ BĂNG THÔNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Ratio_Percent"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub ServicesOfMobileOperator(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = ChatLuongDichVuTelcos_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG MẠNG - CHẤT LƯỢNG CUNG CẤP DỊCH VỤ CỦA TELCOS</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT HIỆN LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(PHÚT)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub StabilityOfInternet(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = DoOnDinhMangInternet_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG MẠNG - ĐỘ ỔN ĐỊNH MẠNG INTERNET</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT HIỆN LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(PHÚT)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub StabilityOfLeaseline(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = DoOnDinhKenhRieng_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=10 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG MẠNG - ĐỘ ỔN ĐỊNH KÊNH RIÊNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MẠNG</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT HIỆN LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(PHÚT)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Total_Min") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub CapacitySystem(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = NangLucHeThong_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=8 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO NĂNG LỰC HỆ THỐNG</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỆ THỐNG DỊCH VỤ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Ratio_Percent"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub IntegrityData(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = OnlineDuLieu_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=12 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG TOÀN VẸN DỮ LIỆU</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT SINH LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ KHÔI PHỤC DỮ LIỆU</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Total_Min"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Quantity_Total") & "</td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_NoRecover_Total") & "</td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub Security(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = BaoMat_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=11 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000""> BÁO CÁO CHẤT LƯỢNG BẢO MẬT</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">DỊCH VỤ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN PHÁT SINH LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHẮC PHỤC LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỔNG THỜI GIAN XỬ LÝ(Phút)</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ THỜI GIAN XỬ LÝ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Error_Desc") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_Start_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Time_End_Id")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Total_Min"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Time_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Quantity_Total") & "</td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub MonitorAlert(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = MonitorCanhBao_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=6 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000"">BÁO CÁO CHẤT LƯỢNG HẠ TẦNG PHÒNG MÁY 36 HOÀNG CẦU-CẢNH BÁO MONITOR</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">HỆ THỐNG CẢNH BÁO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">MÔ TẢ LỖI</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Criteria_Text") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub AirConditional(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = DieuHoaPhongMay_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000"">CHẤT LƯỢNG HẠ TẦNG PHÒNG MÁY 36 HOÀNG CẦU - ĐIỀU HÒA  PHÒNG MÁY</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NHIỆT ĐỘ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GHI CHÚ</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Ratio_Percent"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
                Public Shared Sub TransmissionPower(ByVal sql As String, ByVal vCreateby As String)
                    HttpContext.Current.Response.ContentType = "application/ms-excel"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "filename = TaiDienTrenMoiPha_" & Now.Year & Now.Month & Now.Day & ".xls")
                    Dim sb As New StringBuilder()
                    sb.Append("<table id=""tblBound"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblHeader"" border=""0"" cellpadding=""5"" cellspacing=""5"" width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7  style=""font-family:Times New Roman; background-color: #4F81BD; color: #FFFFFF; font-weight: bold; font-size: 14pt;"">TẬP ĐOÀN VIỄN THÔNG Kaio </td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family:Times New Roman; font-size: 18px; font-weight: bold; color: #000000"">KPI HẠ TẦNG</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" colspan=7 style=""font-family: Calibri; font-size: 18px; text-decoration: underline; font-weight: bold; color: #000000"">CHẤT LƯỢNG HẠ TẦNG PHÒNG MÁY 36 HOÀNG CẦU - TẢI ĐIỆN TRÊN MỖI PHA</td>")
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td>")
                    sb.Append("<table id=""tblDetail"" border=""1"" cellpadding=""10"" cellspacing=""10"" font-family:Times New Roman; font-size: 10pt; width=""100%"">")
                    sb.Append("<tr>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">STT</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">NGÀY</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">TỶ LỆ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">ĐIỂM TRỪ</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">THỜI GIAN KHỞI TẠO</td>")
                    sb.Append("<td align=""center"" style=""background-color: #2B7B69;color: #FFFFFF; font-family:Times New Roman; font-size: 10pt; font-weight: bold"" width=""10%"">GHI CHÚ</td>")
                    sb.Append("</tr>")
                    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    For j As Integer = 0 To dt.Rows.Count - 1
                        sb.Append("<tr>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & j + 1 & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Date_Id")).ToString("yyyy-MM-dd") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & Util.Numeric.Number2Decimal(dt.Rows(j).Item("Ratio_Percent"), 0) & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Decrease_Percent_Total") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Create_By_Text").ToString & "   </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & DateTime.Parse(dt.Rows(j).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss") & "  </td>")
                        sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman; font-size: 10pt "" >" & dt.Rows(j).Item("Description") & "   </td>")
                        sb.Append("</tr>")
                    Next
                    sb.Append("</table>")
                    sb.Append("</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic;font-size: 12pt;"" >Ngày " & Now.Day & ", tháng " & Now.Month & ", năm " & Now.Year & "</td>")
                    sb.Append("</tr>")
                    sb.Append("<tr>")
                    sb.Append("<td style=""background-color: #FFFFFF; font-family:Times New Roman;font-style: italic; font-size: 12pt;"" >Người lập biểu:  " & vCreateby & "</td>")
                    sb.Append("</tr>")
                    sb.Append("</table>")
                    HttpContext.Current.Response.Write(sb.ToString())
                    HttpContext.Current.Response.End()
                End Sub
            End Class
            End Class
#End Region
        Public Shared Function FormatDecimal(ByVal Value As Object, ByVal DecimalPlace As Integer) As String
            Dim str As String = ""
            If Value Is Nothing Or IsDBNull(Value) Then
                str = ""
                Return str
            End If
            If Value = 0 Then
                Return Value
            End If
            If IsNumeric(Value) = True Then
                ' If Value > 0 Then
                str = FormatNumber(Value, DecimalPlace, TriState.False)
                'Else
                'str = Value
                'End If
            Else
                str = Value
            End If
            Return str
        End Function
        Public Shared Function ReplaceSpecial(ByVal str As String) As String
            str = str.Replace(">", "&gt;")
            str = str.Replace("<", "&lt;")
            Return str
        End Function
    End Class
#End Region
#Region "Csv"
    Public Class CSVExporter
        Public Class _B2C
            Public Shared Sub UserComplete(ByVal sql As String, FileType As String)
                Dim attachment As String = "attachment; filename=User_B2C." & FileType
                HttpContext.Current.Response.Clear()
                HttpContext.Current.Response.ClearHeaders()
                HttpContext.Current.Response.ClearContent()
                HttpContext.Current.Response.AddHeader("content-disposition", attachment)
                HttpContext.Current.Response.ContentType = "text/csv"
                HttpContext.Current.Response.AddHeader("Pragma", "public")
                Dim str As String = "USER_ID"
                HttpContext.Current.Response.Write(str)
                HttpContext.Current.Response.Write(Environment.NewLine)
                Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim strb As New StringBuilder()
                    If FileType = "csv" Then
                        AddComma(dt.Rows(i).Item("USER_ID"), strb)
                    Else
                        strb.Append(dt.Rows(i).Item("USER_ID").Replace(","c, " "c))
                    End If
                    HttpContext.Current.Response.Write(strb.ToString())
                    HttpContext.Current.Response.Write(Environment.NewLine)
                Next

                HttpContext.Current.Response.End()
            End Sub
        End Class

        Private Shared Sub AddComma(ByVal item As String, ByVal strb As StringBuilder)
            strb.Append(item.Replace(","c, " "c))
            strb.Append(" ,")
        End Sub
    End Class
#End Region
End Class
