  Imports System.Data.OleDb
Imports System.Data.OracleClient

    Public Class CCareImportUserComplete
        Inherits GlobalPage
        Public Utils As New Util.Encrypt
        Public Utils_1 As New Util.Numeric
#Region "Page Load"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
            CreateFolder()
            Me.lbltitle.Text = "IMPORT THÔNG TIN KHÁCH HÀNG"
            IsPrivilegeOnMenu()
            BindDictIndex()
            Me.btnAdd.Visible = IsUpdate
            pager1.Visible = False
            End If
            Me.txtUserFile.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
            ' Me.CheckBoxDelData.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        'Dim intPageSize As Integer = pager1.PageSize
        'Dim intCurentPage As Integer = pager1.CurrentIndex
        'BindData(intPageSize, intCurentPage, Constants.Action.Search)
        'Dim gridrow As DataGridItem
        'Dim thisButton As ImageButton
        'For Each gridrow In Me.DataGrid.Items
        '    thisButton = gridrow.FindControl("deleter")
        '    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        'Next
        End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
        If Me.txtUserFile.Text.Trim = "" Then
            Me.lblerror.Text = "File dữ liệu không hợp lệ !"
            Exit Sub
        End If
        'If Me.txtGROUP_TEXT_IMPORT.Text.Trim = "" Then
        '    Me.lblerror.Text = "Nhóm không hợp lệ !"
        '    Exit Sub
        'End If
        'If Me.txtKEY_WORD_IMPORT.Text.Trim = "" Then
        '    Me.lblerror.Text = "Từ khóa không hợp lệ !"
        '    Exit Sub
        'End If
        'If Me.txtMT_IMPORT.Text.Trim = "" Then
        '    Me.lblerror.Text = "MT không hợp lệ !"
        '    Exit Sub
        'End If
        'If Me.DropDownListPARTNER_ID_IMPORT.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Đối tác không hợp lệ !"
        '    Exit Sub
        'End If
        'If Me.DropDownListBRAND_ID_IMPORT.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Brandname không hợp lệ !"
        '    Exit Sub
        'End If
        'If Me.DropDownListSOURCE_ID_IMPORT.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Nguồn dữ liệu không hợp lệ !"
        '    Exit Sub
        'End If
        'Dim CollectionField As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListFIELD_ID_IMPORT.CheckedItems
        'If CollectionField.Count <= 0 Then
        '    Me.lblerror.Text = "Ngành hàng không hợp lệ !"
        '    Exit Sub
        'End If

        Dim vFile As String = txtUserFile.Text.Trim
        If vFile.ToLower.EndsWith(".xls") = True Or vFile.EndsWith(".xlsx") = True Then
            ProcXLS(vFile)
        ElseIf vFile.ToLower.EndsWith(".csv") = True Then
            'ProcCSV(vFile)
        ElseIf vFile.ToLower.EndsWith(".txt") = True Then
            ' ProcTXT(vFile)
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
        End If
       
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._CcareB2C.CCareCustomerInfoList)
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect(Constants.Url._CcareB2C.CCareCustomerInfoEdit)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "xls File"
    Private Sub ProcXLS(ByVal xlsFile As String)
        Dim dt As DataTable = Nothing
        Dim sql As String = ""
        If xlsFile.EndsWith(".xls") = True Then
            sql = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 8.0"""
        ElseIf xlsFile.EndsWith(".xlsx") = True Then
            sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 12.0 Xml;HDR=YES"""
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
            Exit Sub
        End If
        Dim connFile As New OleDbConnection(sql)
        Try
            connFile.Open()
        Catch ex As Exception
            Me.lblerror.Text = " Error connect to excel file .Code: " & ex.Message
            Exit Sub
        End Try
        Dim strSqlStmt As String = "SELECT * FROM [" & Me.txtSheet.Text.Trim & "$]"
        Dim daFile As OleDbDataAdapter
        Dim cmdFile As New OleDbCommand
        Dim dsFile As New DataSet
        With cmdFile
            .CommandType = CommandType.Text
            .CommandText = strSqlStmt
            .Connection = connFile
        End With
        Try
            daFile = New OleDbDataAdapter(cmdFile)
            daFile.Fill(dsFile, "Data_File")
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi đọc file excel. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        connFile.Close()
        connFile = Nothing

        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        'Dim USER_ID As String = ""
        Dim STATUS_ID As Integer = 0
        'Dim STATUS_TEXT As String = ""
        Dim GROUP_TEXT As String = Me.txtGROUP_TEXT_IMPORT.Text.Trim
        Dim MT As String = Me.txtMT_IMPORT.Text.Trim
        Dim BRAND_ID As Integer = Me.DropDownListBRAND_ID_IMPORT.SelectedItem.Value
        Dim BRAND_NAME As String = IIf(BRAND_ID > 0, Me.DropDownListBRAND_ID_IMPORT.SelectedItem.Text, "")
        'Dim PROVINCE_ID As Integer = 0
        Dim PROVINCE_TEXT As String = ""
        'Dim DISTRICT_ID As Integer = 0
        Dim DISTRICT_TEXT As String = ""
        Dim PARTNER_ID As Integer = Me.DropDownListPARTNER_ID_IMPORT.SelectedItem.Value
        Dim PARTNER_TEXT As String = IIf(PARTNER_ID > 0, Me.DropDownListPARTNER_ID_IMPORT.SelectedItem.Text, "")
        'Dim SEX_ID As Integer = 0
        'Dim SEX_TEXT As String = ""
        Dim FIELD_ID As String = 0
        Dim FIELD_TEXT As String = ""
        Dim CollectionField As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListFIELD_ID_IMPORT.CheckedItems
        If CollectionField.Count > 0 Then
            For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionField
                If FIELD_TEXT.Trim = "" Then
                    FIELD_TEXT = item.Text
                    FIELD_ID = item.Value & ";"
                Else
                    FIELD_TEXT = FIELD_TEXT & ";" & item.Text
                    FIELD_ID = FIELD_ID & item.Value & ";"
                End If
            Next
        End If

        Dim SOURCE_ID As Integer = Me.DropDownListSOURCE_ID_IMPORT.SelectedItem.Value
        Dim SOURCE_TEXT As String = IIf(SOURCE_ID > 0, Me.DropDownListSOURCE_ID_IMPORT.SelectedItem.Text, "")
        Dim KEY_WORD As String = Me.txtKEY_WORD_IMPORT.Text.Trim
        Dim REMARK As String = ""
        Dim CUSTOMER_CODE As String = ""
        'Dim CUSTOMER_NAME As String = ""
        'Dim BIRTH_DAY As String = ""
        'Dim ADDRESS As String = ""
        'Dim EMAIL_ADDRESS As String = ""
        'Dim FEES_ID As Integer = 0
        Dim FEES_TEXT As String = ""
        'Dim INCOME_ID As Integer = 0
        Dim INCOME_TEXT As String = ""
        'Dim EXACTLY_RATE As String = ""
        Dim MOBILE_OPERATOR As String = ""
        Dim IS_VERIFY_1 As Integer = 0
        Dim VERIFY_BY_1_ID As Integer = 0
        Dim VERIFY_BY_1_TEXT As String = ""
        Dim VERIFY_TIME_1 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_2 As Integer = 0
        Dim VERIFY_BY_2_ID As Integer = 0
        Dim VERIFY_BY_2_TEXT As String = ""
        Dim VERIFY_TIME_2 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_3 As Integer = 0
        Dim VERIFY_BY_3_ID As Integer = 0
        Dim VERIFY_BY_3_TEXT As String = ""
        Dim VERIFY_TIME_3 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim LOGER_INFO As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                     CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") Import thông tin khách hàng <br>"
        Dim KEY_IMPORT As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")
        Dim FILE_IMPORT As String = Me.txtUserFile.Text.Trim
        Dim Total As Integer = dsFile.Tables("Data_File").Rows.Count
        Dim TotalImport As Integer = 0
        Dim TotalExist As Integer = 0
        Dim ListExist As String = ""
        'Load các bảng từ điển:
        'Dim dsBrand As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(BRAND_NAME) BRAND_NAME from CCARE_DICTINDEX_BRAND where STATUS_ID=1")
        'Dim dsPartner As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(PARTNER_TEXT) PARTNER_TEXT from CCARE_DICTINDEX_PARTNER where STATUS_ID=1")
        Dim dsProvince As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(PROVINCE_TEXT) PROVINCE_TEXT from CCARE_DICTINDEX_PROVINCE where STATUS_ID=1")
        Dim dsDistrict As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(DISTRICT_TEXT) DISTRICT_TEXT from CCARE_DICTINDEX_DISTRICT where STATUS_ID=1")

        'Dim dsField As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(FIELD_TEXT) FIELD_TEXT from CCARE_DICTINDEX_FIELD where STATUS_ID=1")
        'Dim dsSource As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(SOURCE_TEXT) SOURCE_TEXT from CCARE_DICTINDEX_SOURCE where STATUS_ID=1")
        Dim dsFees As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(FEES_TEXT) FEES_TEXT from CCARE_DICTINDEX_FEES where STATUS_ID=1")
        Dim dsIncome As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(INCOME_TEXT) INCOME_TEXT from CCARE_DICTINDEX_INCOME where STATUS_ID=1")

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                Dim USER_ID As String = ""
                USER_ID = dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim
                sql = "SELECT * From  CCARE_CUSTOMER_INFO  Where  upper(USER_ID)='" & USER_ID.ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then

                    STATUS_ID = 4
                    Dim STATUS_TEXT As String = ""
                    STATUS_TEXT = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim

                    Dim PROVINCE_ID As Integer = 0
                    PROVINCE_TEXT = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim ' Format  Id
                    If PROVINCE_TEXT <> "" Then
                        Dim filteProvince As String = " PROVINCE_TEXT='" & PROVINCE_TEXT.Trim.ToUpper & "'"
                        Dim sourceProvince As DataRow() = dsProvince.Tables(0).Select(filteProvince)
                        If sourceProvince.Length > 0 Then
                            PROVINCE_ID = sourceProvince(0).Item("Id")
                        End If
                    End If

                    Dim DISTRICT_ID As Integer = 0
                    DISTRICT_TEXT = dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim ' Format  Id
                    If DISTRICT_TEXT <> "" Then
                        Dim filteDistrict As String = " DISTRICT_TEXT='" & DISTRICT_TEXT.Trim.ToUpper & "'"
                        Dim sourceDistrict As DataRow() = dsDistrict.Tables(0).Select(filteDistrict)
                        If sourceDistrict.Length > 0 Then
                            DISTRICT_ID = sourceDistrict(0).Item("Id")
                        End If
                    End If
                    Dim SEX_ID As Integer = 0
                    Dim SEX_TEXT As String = ""
                    SEX_TEXT = dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim
                    If SEX_TEXT.ToUpper = "NAM" Then
                        SEX_ID = 1
                    ElseIf SEX_TEXT.ToUpper = "NỮ" Then
                        SEX_ID = 2
                    Else
                        SEX_ID = 3
                        SEX_TEXT = "CHƯA XÁC ĐỊNH"
                    End If
                
                    REMARK = dsFile.Tables("Data_File").Rows(i).Item(5).ToString.Trim
                    Dim CUSTOMER_NAME As String = ""
                    CUSTOMER_NAME = dsFile.Tables("Data_File").Rows(i).Item(6).ToString.Trim
                    Dim BIRTH_DAY As String = ""
                    BIRTH_DAY = dsFile.Tables("Data_File").Rows(i).Item(7).ToString.Trim
                    Dim ADDRESS As String = ""
                    ADDRESS = dsFile.Tables("Data_File").Rows(i).Item(8).ToString.Trim
                    Dim EMAIL_ADDRESS As String = ""
                    EMAIL_ADDRESS = dsFile.Tables("Data_File").Rows(i).Item(9).ToString.Trim

                    Dim FEES_ID As Integer = 0
                    FEES_TEXT = dsFile.Tables("Data_File").Rows(i).Item(10).ToString.Trim ' Format  Id
                    If FEES_TEXT <> "" Then
                        Dim filteFees As String = " FEES_TEXT='" & FEES_TEXT.Trim.ToUpper & "'"
                        Dim sourceFees As DataRow() = dsFees.Tables(0).Select(filteFees)
                        If sourceFees.Length > 0 Then
                            FEES_ID = sourceFees(0).Item("Id")
                        End If
                    End If

                    Dim INCOME_ID As Integer = 0
                    INCOME_TEXT = dsFile.Tables("Data_File").Rows(i).Item(11).ToString.Trim ' Format  Id
                    If INCOME_TEXT <> "" Then
                        Dim filteIncome As String = " INCOME_TEXT='" & INCOME_TEXT.Trim.ToUpper & "'"
                        Dim sourceIncome As DataRow() = dsIncome.Tables(0).Select(filteIncome)
                        If sourceIncome.Length > 0 Then
                            INCOME_ID = sourceIncome(0).Item("Id")
                        End If
                    End If
                    Dim EXACTLY_RATE As String = ""
                    EXACTLY_RATE = dsFile.Tables("Data_File").Rows(i).Item(12).ToString.Trim

                    MOBILE_OPERATOR = Util.FormatOperator(USER_ID)

                    Dim cmd As New OracleCommand
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "CCARE_CUSTOMER.IMPORT_CCARE_CUSTOMER"
                        .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                        .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                        .Parameters("p_USER_ID").Value = USER_ID

                        .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                        .Parameters("p_STATUS_ID").Value = STATUS_ID

                        .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                        .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

                        .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_GROUP_TEXT").Value = GROUP_TEXT

                        .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                        .Parameters("p_MT").Value = MT

                        .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                        .Parameters("p_BRAND_ID").Value = BRAND_ID

                        .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                        .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                        .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                        .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                        .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                        .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                        .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                        .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                        .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                        .Parameters("p_DISTRICT_ID").Value = DISTRICT_ID

                        .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                        .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                        .Parameters("p_SEX_ID").Value = SEX_ID

                        .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_SEX_TEXT").Value = SEX_TEXT

                        .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 200))
                        .Parameters("p_FIELD_ID").Value = FIELD_ID

                        .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                        .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                        .Parameters("p_SOURCE_ID").Value = SOURCE_ID

                        .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                        .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                        .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                        .Parameters("p_KEY_WORD").Value = KEY_WORD

                        .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                        .Parameters("p_REMARK").Value = REMARK

                        .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                        .Parameters("p_CUSTOMER_CODE").Value = CUSTOMER_CODE

                        .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                        .Parameters("p_CUSTOMER_NAME").Value = CUSTOMER_NAME

                        .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                        .Parameters("p_BIRTH_DAY").Value = BIRTH_DAY

                        .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                        .Parameters("p_ADDRESS").Value = ADDRESS

                        .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                        .Parameters("p_EMAIL_ADDRESS").Value = EMAIL_ADDRESS

                        .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                        .Parameters("p_FEES_ID").Value = FEES_ID

                        .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                        .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                        .Parameters("p_INCOME_ID").Value = INCOME_ID

                        .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                        .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                        .Parameters("p_EXACTLY_RATE").Value = EXACTLY_RATE

                        .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                        .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_1", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_1").Value = IS_VERIFY_1

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_1_ID").Value = VERIFY_BY_1_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_1_TEXT").Value = VERIFY_BY_1_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_1", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_1").Value = VERIFY_TIME_1

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_2", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_2").Value = IS_VERIFY_2

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_2_ID").Value = VERIFY_BY_2_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_2_TEXT").Value = VERIFY_BY_2_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_2", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_2").Value = VERIFY_TIME_2

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_3", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_3").Value = IS_VERIFY_3

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_3_ID").Value = VERIFY_BY_3_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_3_TEXT").Value = VERIFY_BY_3_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_3", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_3").Value = VERIFY_TIME_3

                        .Parameters.Add(New OracleParameter("p_KEY_IMPORT", OracleType.VarChar, 200))
                        .Parameters("p_KEY_IMPORT").Value = KEY_IMPORT

                        .Parameters.Add(New OracleParameter("p_FILE_IMPORT", OracleType.VarChar, 200))
                        .Parameters("p_FILE_IMPORT").Value = FILE_IMPORT

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_CREATE_BY_ID").Value = CREATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_CREATE_BY_TEXT").Value = CREATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_CREATE_TIME").Value = CREATE_TIME

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                        .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                        .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                        .Parameters("p_LOGER_INFO").Value = LOGER_INFO

                        .Parameters.Add(New OracleParameter("p_DUPLICATE_NUMBER", OracleType.Number, 18))
                        .Parameters("p_DUPLICATE_NUMBER").Value = 1

                        .Parameters.Add(New OracleParameter("p_EXIST_NUMBER", OracleType.Number, 18))
                        .Parameters("p_EXIST_NUMBER").Value = 1

                        .Connection = conn
                        Try
                            .ExecuteNonQuery()
                            TotalImport = TotalImport + 1
                        Catch ex As Exception
                            Me.lblerror.Text = ex.Message
                            Exit Sub
                        End Try
                    End With
                Else
                    TotalExist = TotalExist + 1
                    ListExist = ListExist & ", " & USER_ID
                End If
            Next
        End If
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số Import: " & TotalImport & " (Tồn tại:" & TotalExist & ":" & ListExist & ")"

    End Sub
    Private Sub ProcXLS_old(ByVal xlsFile As String)
        Dim dt As DataTable = Nothing
        Dim sql As String = ""
        If xlsFile.EndsWith(".xls") = True Then
            sql = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 8.0"""
        ElseIf xlsFile.EndsWith(".xlsx") = True Then
            sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 12.0 Xml;HDR=YES"""
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
            Exit Sub
        End If
        Dim connFile As New OleDbConnection(sql)
        Try
            connFile.Open()
        Catch ex As Exception
            Me.lblerror.Text = " Error connect to excel file .Code: " & ex.Message
            Exit Sub
        End Try
        Dim strSqlStmt As String = "SELECT * FROM [" & Me.txtSheet.Text.Trim & "$]"
        Dim daFile As OleDbDataAdapter
        Dim cmdFile As New OleDbCommand
        Dim dsFile As New DataSet
        With cmdFile
            .CommandType = CommandType.Text
            .CommandText = strSqlStmt
            .Connection = connFile
        End With
        Try
            daFile = New OleDbDataAdapter(cmdFile)
            daFile.Fill(dsFile, "Data_File")
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi đọc file excel. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        connFile.Close()
        connFile = Nothing

        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        'Dim USER_ID As String = ""
        Dim STATUS_ID As Integer = 0
        'Dim STATUS_TEXT As String = ""
        'Dim GROUP_TEXT As String = ""
        Dim MT As String = ""
        'Dim BRAND_ID As Integer = 0
        Dim BRAND_NAME As String = ""
        'Dim PROVINCE_ID As Integer = 0
        Dim PROVINCE_TEXT As String = ""
        'Dim DISTRICT_ID As Integer = 0
        Dim DISTRICT_TEXT As String = ""
        'Dim PARTNER_ID As Integer = 0
        Dim PARTNER_TEXT As String = ""
        'Dim SEX_ID As Integer = 0
        'Dim SEX_TEXT As String = ""
        'Dim FIELD_ID As String = 0
        Dim FIELD_TEXT As String = ""
        'Dim SOURCE_ID As Integer = 0
        Dim SOURCE_TEXT As String = ""
        Dim KEY_WORD As String = ""
        Dim REMARK As String = ""
        Dim CUSTOMER_CODE As String = ""
        'Dim CUSTOMER_NAME As String = ""
        'Dim BIRTH_DAY As String = ""
        'Dim ADDRESS As String = ""
        'Dim EMAIL_ADDRESS As String = ""
        'Dim FEES_ID As Integer = 0
        Dim FEES_TEXT As String = ""
        'Dim INCOME_ID As Integer = 0
        Dim INCOME_TEXT As String = ""
        'Dim EXACTLY_RATE As String = ""
        Dim MOBILE_OPERATOR As String = ""
        Dim IS_VERIFY_1 As Integer = 0
        Dim VERIFY_BY_1_ID As Integer = 0
        Dim VERIFY_BY_1_TEXT As String = ""
        Dim VERIFY_TIME_1 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_2 As Integer = 0
        Dim VERIFY_BY_2_ID As Integer = 0
        Dim VERIFY_BY_2_TEXT As String = ""
        Dim VERIFY_TIME_2 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_3 As Integer = 0
        Dim VERIFY_BY_3_ID As Integer = 0
        Dim VERIFY_BY_3_TEXT As String = ""
        Dim VERIFY_TIME_3 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim LOGER_INFO As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                     CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") Import thông tin khách hàng <br>"
        Dim KEY_IMPORT As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")
        Dim FILE_IMPORT As String = Me.txtUserFile.Text.Trim
        Dim Total As Integer = dsFile.Tables("Data_File").Rows.Count
        Dim TotalImport As Integer = 0
        Dim TotalExist As Integer = 0
        Dim ListExist As String = ""
        'Load các bảng từ điển:
        Dim dsBrand As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(BRAND_NAME) BRAND_NAME from CCARE_DICTINDEX_BRAND where STATUS_ID=1")
        Dim dsPartner As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(PARTNER_TEXT) PARTNER_TEXT from CCARE_DICTINDEX_PARTNER where STATUS_ID=1")
        Dim dsProvince As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(PROVINCE_TEXT) PROVINCE_TEXT from CCARE_DICTINDEX_PROVINCE where STATUS_ID=1")
        Dim dsDistrict As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(DISTRICT_TEXT) DISTRICT_TEXT from CCARE_DICTINDEX_DISTRICT where STATUS_ID=1")

        Dim dsField As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(FIELD_TEXT) FIELD_TEXT from CCARE_DICTINDEX_FIELD where STATUS_ID=1")
        Dim dsSource As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(SOURCE_TEXT) SOURCE_TEXT from CCARE_DICTINDEX_SOURCE where STATUS_ID=1")
        Dim dsFees As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(FEES_TEXT) FEES_TEXT from CCARE_DICTINDEX_FEES where STATUS_ID=1")
        Dim dsIncome As DataSet = OracleEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "select ID,upper(INCOME_TEXT) INCOME_TEXT from CCARE_DICTINDEX_INCOME where STATUS_ID=1")

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                Dim USER_ID As String = ""
                USER_ID = dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim
                sql = "SELECT * From  CCARE_CUSTOMER_INFO  Where  upper(USER_ID)='" & USER_ID.ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then

                    STATUS_ID = 4
                    Dim STATUS_TEXT As String = ""
                    STATUS_TEXT = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                    Dim GROUP_TEXT As String = ""
                    GROUP_TEXT = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim
                    MT = dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim

                    Dim BRAND_ID As Integer = 0
                    BRAND_NAME = dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim ' Format  Id
                    If BRAND_NAME <> "" Then
                        Dim filterBrand As String = " BRAND_NAME='" & BRAND_NAME.Trim.ToUpper & "'"
                        Dim sourceBrand As DataRow() = dsBrand.Tables(0).Select(filterBrand)
                        If sourceBrand.Length > 0 Then
                            BRAND_ID = sourceBrand(0).Item("Id")
                        End If
                    End If

                    Dim PARTNER_ID As Integer = 0
                    PARTNER_TEXT = dsFile.Tables("Data_File").Rows(i).Item(5).ToString.Trim ' Format  Id
                    If PARTNER_TEXT <> "" Then
                        Dim filtePartner As String = " PARTNER_TEXT='" & PARTNER_TEXT.Trim.ToUpper & "'"
                        Dim sourcePartner As DataRow() = dsPartner.Tables(0).Select(filtePartner)
                        If sourcePartner.Length > 0 Then
                            PARTNER_ID = sourcePartner(0).Item("Id")
                        End If
                    End If

                    Dim PROVINCE_ID As Integer = 0
                    PROVINCE_TEXT = dsFile.Tables("Data_File").Rows(i).Item(6).ToString.Trim ' Format  Id
                    If PROVINCE_TEXT <> "" Then
                        Dim filteProvince As String = " PROVINCE_TEXT='" & PROVINCE_TEXT.Trim.ToUpper & "'"
                        Dim sourceProvince As DataRow() = dsProvince.Tables(0).Select(filteProvince)
                        If sourceProvince.Length > 0 Then
                            PROVINCE_ID = sourceProvince(0).Item("Id")
                        End If
                    End If

                    Dim DISTRICT_ID As Integer = 0
                    DISTRICT_TEXT = dsFile.Tables("Data_File").Rows(i).Item(7).ToString.Trim ' Format  Id
                    If DISTRICT_TEXT <> "" Then
                        Dim filteDistrict As String = " DISTRICT_TEXT='" & DISTRICT_TEXT.Trim.ToUpper & "'"
                        Dim sourceDistrict As DataRow() = dsDistrict.Tables(0).Select(filteDistrict)
                        If sourceDistrict.Length > 0 Then
                            DISTRICT_ID = sourceDistrict(0).Item("Id")
                        End If
                    End If
                    Dim SEX_ID As Integer = 0
                    Dim SEX_TEXT As String = ""
                    SEX_TEXT = dsFile.Tables("Data_File").Rows(i).Item(8).ToString.Trim
                    If SEX_TEXT.ToUpper = "NAM" Then
                        SEX_ID = 1
                    ElseIf SEX_TEXT.ToUpper = "NỮ" Then
                        SEX_ID = 2
                    Else
                        SEX_ID = 3
                        SEX_TEXT = "CHƯA XÁC ĐỊNH"
                    End If
                    FIELD_TEXT = dsFile.Tables("Data_File").Rows(i).Item(9).ToString.Trim ' Format Id
                    Dim FIELD_ID As String = ""
                    Try
                        If FIELD_TEXT <> "" Then
                            If FIELD_TEXT.EndsWith(";") = False Then
                                FIELD_TEXT = FIELD_TEXT & ";"
                            End If
                            Dim splitout = Split(FIELD_TEXT, ";")
                            For k As Integer = 0 To UBound(splitout)
                                Dim vFIELD_TEXT As String = splitout(k)
                                Dim filteField As String = " FIELD_TEXT='" & vFIELD_TEXT.Trim.ToUpper & "'"
                                Dim sourceField As DataRow() = dsField.Tables(0).Select(filteField)
                                If sourceField.Length > 0 Then
                                    If FIELD_ID = "" Then
                                        FIELD_ID = sourceField(0).Item("Id") & ";"
                                    Else
                                        FIELD_ID = FIELD_ID & sourceField(0).Item("Id") & ";"
                                    End If
                                End If

                            Next
                        End If
                    Catch ex As Exception
                        Me.lblerror.Text = ex.Message
                        Exit Sub
                    End Try

                    Dim SOURCE_ID As Integer = 0
                    SOURCE_TEXT = dsFile.Tables("Data_File").Rows(i).Item(10).ToString.Trim ' Format  Id
                    If SOURCE_TEXT <> "" Then
                        Dim filteSource As String = " SOURCE_TEXT='" & SOURCE_TEXT.Trim.ToUpper & "'"
                        Dim sourceSource As DataRow() = dsSource.Tables(0).Select(filteSource)
                        If sourceSource.Length > 0 Then
                            SOURCE_ID = sourceSource(0).Item("Id")
                        End If
                    End If

                    KEY_WORD = dsFile.Tables("Data_File").Rows(i).Item(11).ToString.Trim
                    REMARK = dsFile.Tables("Data_File").Rows(i).Item(12).ToString.Trim
                    Dim CUSTOMER_NAME As String = ""
                    CUSTOMER_NAME = dsFile.Tables("Data_File").Rows(i).Item(13).ToString.Trim
                    Dim BIRTH_DAY As String = ""
                    BIRTH_DAY = dsFile.Tables("Data_File").Rows(i).Item(14).ToString.Trim
                    Dim ADDRESS As String = ""
                    ADDRESS = dsFile.Tables("Data_File").Rows(i).Item(15).ToString.Trim
                    Dim EMAIL_ADDRESS As String = ""
                    EMAIL_ADDRESS = dsFile.Tables("Data_File").Rows(i).Item(16).ToString.Trim

                    Dim FEES_ID As Integer = 0
                    FEES_TEXT = dsFile.Tables("Data_File").Rows(i).Item(17).ToString.Trim ' Format  Id
                    If FEES_TEXT <> "" Then
                        Dim filteFees As String = " FEES_TEXT='" & FEES_TEXT.Trim.ToUpper & "'"
                        Dim sourceFees As DataRow() = dsFees.Tables(0).Select(filteFees)
                        If sourceFees.Length > 0 Then
                            FEES_ID = sourceFees(0).Item("Id")
                        End If
                    End If

                    Dim INCOME_ID As Integer = 0
                    INCOME_TEXT = dsFile.Tables("Data_File").Rows(i).Item(18).ToString.Trim ' Format  Id
                    If INCOME_TEXT <> "" Then
                        Dim filteIncome As String = " INCOME_TEXT='" & INCOME_TEXT.Trim.ToUpper & "'"
                        Dim sourceIncome As DataRow() = dsIncome.Tables(0).Select(filteIncome)
                        If sourceIncome.Length > 0 Then
                            INCOME_ID = sourceIncome(0).Item("Id")
                        End If
                    End If
                    Dim EXACTLY_RATE As String = ""
                    EXACTLY_RATE = dsFile.Tables("Data_File").Rows(i).Item(19).ToString.Trim

                    MOBILE_OPERATOR = Util.FormatOperator(USER_ID)

                    Dim cmd As New OracleCommand
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "CCARE_CUSTOMER.IMPORT_CCARE_CUSTOMER"
                        .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                        .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                        .Parameters("p_USER_ID").Value = USER_ID

                        .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                        .Parameters("p_STATUS_ID").Value = STATUS_ID

                        .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                        .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

                        .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_GROUP_TEXT").Value = GROUP_TEXT

                        .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                        .Parameters("p_MT").Value = MT

                        .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                        .Parameters("p_BRAND_ID").Value = BRAND_ID

                        .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                        .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                        .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                        .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                        .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                        .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                        .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                        .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                        .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                        .Parameters("p_DISTRICT_ID").Value = DISTRICT_ID

                        .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                        .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                        .Parameters("p_SEX_ID").Value = SEX_ID

                        .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_SEX_TEXT").Value = SEX_TEXT

                        .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 200))
                        .Parameters("p_FIELD_ID").Value = FIELD_ID

                        .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                        .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                        .Parameters("p_SOURCE_ID").Value = SOURCE_ID

                        .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                        .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                        .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                        .Parameters("p_KEY_WORD").Value = KEY_WORD

                        .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                        .Parameters("p_REMARK").Value = REMARK

                        .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                        .Parameters("p_CUSTOMER_CODE").Value = CUSTOMER_CODE

                        .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                        .Parameters("p_CUSTOMER_NAME").Value = CUSTOMER_NAME

                        .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                        .Parameters("p_BIRTH_DAY").Value = BIRTH_DAY

                        .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                        .Parameters("p_ADDRESS").Value = ADDRESS

                        .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                        .Parameters("p_EMAIL_ADDRESS").Value = EMAIL_ADDRESS

                        .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                        .Parameters("p_FEES_ID").Value = FEES_ID

                        .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                        .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                        .Parameters("p_INCOME_ID").Value = INCOME_ID

                        .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                        .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                        .Parameters("p_EXACTLY_RATE").Value = EXACTLY_RATE

                        .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                        .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_1", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_1").Value = IS_VERIFY_1

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_1_ID").Value = VERIFY_BY_1_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_1_TEXT").Value = VERIFY_BY_1_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_1", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_1").Value = VERIFY_TIME_1

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_2", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_2").Value = IS_VERIFY_2

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_2_ID").Value = VERIFY_BY_2_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_2_TEXT").Value = VERIFY_BY_2_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_2", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_2").Value = VERIFY_TIME_2

                        .Parameters.Add(New OracleParameter("p_IS_VERIFY_3", OracleType.Number, 18))
                        .Parameters("p_IS_VERIFY_3").Value = IS_VERIFY_3

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_ID", OracleType.Number, 18))
                        .Parameters("p_VERIFY_BY_3_ID").Value = VERIFY_BY_3_ID

                        .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_VERIFY_BY_3_TEXT").Value = VERIFY_BY_3_TEXT

                        .Parameters.Add(New OracleParameter("p_VERIFY_TIME_3", OracleType.DateTime, 200))
                        .Parameters("p_VERIFY_TIME_3").Value = VERIFY_TIME_3

                        .Parameters.Add(New OracleParameter("p_KEY_IMPORT", OracleType.VarChar, 200))
                        .Parameters("p_KEY_IMPORT").Value = KEY_IMPORT

                        .Parameters.Add(New OracleParameter("p_FILE_IMPORT", OracleType.VarChar, 200))
                        .Parameters("p_FILE_IMPORT").Value = FILE_IMPORT

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_CREATE_BY_ID").Value = CREATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_CREATE_BY_TEXT").Value = CREATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_CREATE_TIME").Value = CREATE_TIME

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                        .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                        .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                        .Parameters("p_LOGER_INFO").Value = LOGER_INFO

                        .Parameters.Add(New OracleParameter("p_DUPLICATE_NUMBER", OracleType.Number, 18))
                        .Parameters("p_DUPLICATE_NUMBER").Value = 1

                        .Parameters.Add(New OracleParameter("p_EXIST_NUMBER", OracleType.Number, 18))
                        .Parameters("p_EXIST_NUMBER").Value = 1

                        .Connection = conn
                        Try
                            .ExecuteNonQuery()
                            TotalImport = TotalImport + 1
                        Catch ex As Exception
                            Me.lblerror.Text = ex.Message
                            Exit Sub
                        End Try
                    End With
                Else
                    TotalExist = TotalExist + 1
                    ListExist = ListExist & ", " & USER_ID
                End If
            Next
        End If
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số Import: " & TotalImport & " (Tồn tại:" & TotalExist & ":" & ListExist & ")"

    End Sub
#End Region
#Region "csv File"
      
#End Region
#Region "txt File"
     
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region

#Region "Dict Index"
    Private Sub BindDictIndex()
        BindPartner()
        BindProvince()
        BindSource()
        BindFees()
        BindField()
        BindIncome()
        BindExactlyRate()
        BindDate()
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PARTNER Where STATUS_ID=1 Order by upper(PARTNER_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPARTNER_ID.Items.Clear()
        Me.DropDownListPARTNER_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPARTNER_ID.SelectedValue = 0
        Me.DropDownListPARTNER_ID_IMPORT.Items.Clear()
        Me.DropDownListPARTNER_ID_IMPORT.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPARTNER_ID_IMPORT.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPARTNER_ID.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListPARTNER_ID_IMPORT.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindBrand(ByVal PARTNER_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND  Where STATUS_ID=1 And PARTNER_ID=" & PARTNER_ID & " Order by upper(BRAND_NAME)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListBRAND_NAME.Items.Clear()
        Me.DropDownListBRAND_NAME.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListBRAND_NAME.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListBRAND_NAME.Items.Add(New ListItem(dt.Rows(i).Item("BRAND_NAME"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindProvince()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PROVINCE  Where STATUS_ID=1 Order by upper(PROVINCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPROVINCE_ID.Items.Clear()
        Me.DropDownListPROVINCE_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPROVINCE_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPROVINCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("PROVINCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindSource()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_SOURCE  Where STATUS_ID=1 Order by upper(SOURCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListSOURCE_ID.Items.Clear()
        Me.DropDownListSOURCE_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListSOURCE_ID.SelectedValue = 0
        Me.DropDownListSOURCE_ID_IMPORT.Items.Clear()
        Me.DropDownListSOURCE_ID_IMPORT.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListSOURCE_ID_IMPORT.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListSOURCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListSOURCE_ID_IMPORT.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindFees()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FEES  Where STATUS_ID=1 Order by upper(FEES_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListFEES_ID.Items.Clear()
        Me.DropDownListFEES_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListFEES_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListFEES_ID.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindField()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FIELD  Where STATUS_ID=1 Order by upper(FIELD_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.CheckBoxListFIELD_ID.Items.Clear()
        Me.RadDropDownListFIELD_ID_IMPORT.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.CheckBoxListFIELD_ID.Items.Add(New ListItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
                Me.RadDropDownListFIELD_ID_IMPORT.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
        
    End Sub
    Private Sub BindIncome()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_INCOME  Where STATUS_ID=1 Order by upper(INCOME_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListINCOME_ID.Items.Clear()
        Me.DropDownListINCOME_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListINCOME_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListINCOME_ID.Items.Add(New ListItem(dt.Rows(i).Item("INCOME_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub

    Private Sub BindExactlyRate()
        Me.DropDownListEXACTLY_RATE_NUMBER.Items.Clear()
        Me.DropDownListEXACTLY_RATE_NUMBER.Items.Add(New ListItem("--all--", "--all--"))
        For i As Integer = 0 To 100 Step 10
            Me.DropDownListEXACTLY_RATE_NUMBER.Items.Add(New ListItem(i, i))
        Next
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
    End Sub

#End Region
#Region "Build sql Condition"
    Private Function IsSqlSearch() As String
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")

        Dim sql As String = ""
        sql = sql & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')>='" & FromDate & "'"
        sql = sql & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')<='" & ToDate & "'"
        If Me.DropDownListPARTNER_ID.SelectedItem.Value > 0 Then
            sql = sql & " And PARTNER_ID=" & Me.DropDownListPARTNER_ID.SelectedItem.Value
        End If
        If Me.DropDownListBRAND_NAME.SelectedItem.Text <> "--all--" Then
            If Me.CheckBoxBRAND_NAME.Checked = True Then
                sql = sql & " And upper(BRAND_NAME) like '%" & Me.DropDownListBRAND_NAME.SelectedItem.Text.ToUpper & "%'"
            Else
                sql = sql & " And upper(BRAND_NAME)='" & Me.DropDownListBRAND_NAME.SelectedItem.Text.ToUpper & "'"
            End If
        End If
        If Me.txtMT.Text.Trim <> "" Then
            If Me.CheckBoxMT.Checked = True Then
                sql = sql & " And upper(MT) like '%" & Me.txtMT.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(MT) = '" & Me.txtMT.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.txtKEY_WORD.Text.Trim <> "" Then
            If Me.CheckBoxKEY_WORD.Checked = True Then
                sql = sql & " And upper(KEY_WORD) like '%" & Me.txtKEY_WORD.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(KEY_WORD)='" & Me.txtKEY_WORD.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.txtGROUP_TEXT.Text.Trim <> "" Then
            If Me.CheckBoxGROUP_TEXT.Checked = True Then
                sql = sql & " And upper(GROUP_TEXT) like '%" & Me.txtGROUP_TEXT.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(GROUP_TEXT)='" & Me.txtGROUP_TEXT.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.DropDownListSOURCE_ID.SelectedItem.Value > 0 Then
            sql = sql & " And SOURCE_ID=" & Me.DropDownListSOURCE_ID.SelectedItem.Value
        End If
        If Me.DropDownListSTATUS_ID.SelectedItem.Value > 0 Then
            sql = sql & " And STATUS_ID='" & Me.DropDownListSTATUS_ID.SelectedItem.Value & "'"
        End If
        If Me.txtDUPLICATE_NUMBER.Text.Trim <> "" Then
            sql = sql & " And DUPLICATE_NUMBER " & Me.DropDownListDUPLICATE_NUMBER.SelectedItem.Text & Me.txtDUPLICATE_NUMBER.Text.Trim
        End If
        If Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Text <> "--all--" Then
            sql = sql & " And EXACTLY_RATE " & Me.DropDownListEXACTLY_RATE.SelectedItem.Text & Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Text.Trim
        End If
        Dim IsField As String = ""
        For i As Integer = 0 To Me.CheckBoxListFIELD_ID.Items.Count - 1
            If CheckBoxListFIELD_ID.Items(i).Selected = True Then
                If IsField.Trim = "" Then
                    IsField = "( FIELD_ID like '%" & Me.CheckBoxListFIELD_ID.Items(i).Value & ";%'"
                Else
                    IsField = IsField & " OR FIELD_ID like '%" & Me.CheckBoxListFIELD_ID.Items(i).Value & ";%'"
                End If
            End If
        Next
        If IsField <> "" Then
            sql = sql & " And " & IsField & ")"
        End If
        If Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text <> "--all--" Then
            sql = sql & " And MOBILE_OPERATOR='" & Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text & "'"
        End If
        If Me.txtUSER_ID.Text.Trim <> "" Then
            sql = sql & " And USER_ID='" & Me.txtUSER_ID.Text.Trim & "'"
        End If
        If Me.txtCUSTOMER_NAME.Text.Trim <> "" Then
            If CheckBoxCUSTOMER_NAME.Checked = True Then
                sql = sql & " And upper(CUSTOMER_NAME) like '%" & Me.txtCUSTOMER_NAME.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(CUSTOMER_NAME) = '" & Me.txtCUSTOMER_NAME.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.DropDownListSEX.SelectedItem.Value > -1 Then
            sql = sql & " And SEX_ID=" & Me.DropDownListSEX.SelectedItem.Value
        End If
        If Me.txtFromYear.Text.Trim <> "" And Me.txtToYear.Text.Trim <> "" Then
            sql = sql & " And  SUBSTR(BIRTH_DAY,7,2)<>'NA'  And to_number(to_char(sysdate,'YYYY')) - to_number(SUBSTR(BIRTH_DAY,7,4))>='" & Me.txtFromYear.Text.Trim & "'"
            sql = sql & " And to_number(to_char(sysdate,'YYYY')) - to_number(SUBSTR(BIRTH_DAY,7,4))<='" & Me.txtToYear.Text.Trim & "'"
        End If
        If Me.DropDownListPROVINCE_ID.SelectedItem.Value > 0 Then
            sql = sql & " And PROVINCE_ID=" & Me.DropDownListPROVINCE_ID.SelectedItem.Value
        End If
        If Me.txtADDRESS.Text.Trim <> "" Then
            If Me.CheckBoxADDRESS.Checked = True Then
                sql = sql & " And upper(ADDRESS) like '%" & Me.txtADDRESS.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(ADDRESS) = '" & Me.txtADDRESS.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.txtEMAIL_ADDRESS.Text.Trim <> "" Then
            sql = sql & " And upper(EMAIL_ADDRESS) like '%" & Me.txtEMAIL_ADDRESS.Text.Trim.ToUpper & "%'"
        End If
        If Me.DropDownListFEES_ID.SelectedItem.Value > 0 Then
            sql = sql & " And FEES_ID=" & Me.DropDownListFEES_ID.SelectedItem.Value
        End If
        If Me.DropDownListINCOME_ID.SelectedItem.Value > 0 Then
            sql = sql & " And INCOME_ID=" & Me.DropDownListINCOME_ID.SelectedItem.Value
        End If
        If Me.txtCUSTOMER_CODE.Text.Trim <> "" Then
            sql = sql & " And upper(CUSTOMER_CODE) like '%" & Me.txtCUSTOMER_CODE.Text.Trim.ToUpper & "%'"
        End If
        If Me.txtREMARK.Text.Trim <> "" Then
            If Me.CheckBoxREMARK.Checked = True Then
                sql = sql & " And upper(REMARK) like '%" & Me.txtREMARK.Text.Trim.ToUpper & "%'"
            Else
                sql = sql & " And upper(REMARK) ='" & Me.txtREMARK.Text.Trim.ToUpper & "'"
            End If
        End If
        If Me.DropDownListOrderField.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & " order by " & Me.DropDownListOrderField.SelectedItem.Value & Me.DropDownListOrder.SelectedItem.Value
        End If
        Return sql
    End Function

#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT ID,USER_ID,  STATUS_ID,  STATUS_TEXT,  GROUP_TEXT,  (case when length(mt)>25 then substr(mt,1,25)||'...' else mt end) MT,  BRAND_ID,  BRAND_NAME,  PARTNER_ID,  PARTNER_TEXT,  PROVINCE_ID,  PROVINCE_TEXT,  SEX_ID,  SEX_TEXT,  FIELD_ID,  FIELD_TEXT, " & _
"SOURCE_ID,  SOURCE_TEXT,  KEY_WORD,  REMARK,  CUSTOMER_CODE,  CUSTOMER_NAME,  BIRTH_DAY,  ADDRESS,  EMAIL_ADDRESS,  FEES_ID,  FEES_TEXT,  INCOME_ID,  INCOME_TEXT,  EXACTLY_RATE, " & _
"MOBILE_OPERATOR,  IS_VERIFY_1,  VERIFY_BY_1_ID,  VERIFY_BY_1_TEXT,  VERIFY_TIME_1,  IS_VERIFY_2,  VERIFY_BY_2_ID,  VERIFY_BY_2_TEXT,  VERIFY_TIME_2,  IS_VERIFY_3,  VERIFY_BY_3_ID,  VERIFY_BY_3_TEXT," & _
"VERIFY_TIME_3,  KEY_IMPORT,  FILE_IMPORT,  DUPLICATE_NUMBER,  EXIST_NUMBER,  CREATE_BY_ID,  CREATE_BY_TEXT,  CREATE_TIME,  UPDATE_BY_ID,  UPDATE_BY_TEXT,  UPDATE_TIME,  LOGER_INFO,RowNum as RowNumber" & _
" FROM CCARE_CUSTOMER_INFO Where Id >0"
        sql = sql & IsSqlSearch()
        If Me.txtTOP.Text.Trim <> "" Then
            sql = "SELECT * From (" & sql & ") T1 WHERE  T1.RowNumber  >" & 0 & " and  T1.RowNumber <= " & Me.txtTOP.Text.Trim
        End If
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
                dt = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                dtPageCount = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
            End If
            ViewState("DATA_GRID") = dt
            ViewState("DATA_COUNT") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGrid.DataSource = dt
                Me.DataGrid.DataBind()
                Me.DataGrid.Columns(9).Visible = IsUpdate
                Me.lblTotal.Text = Utils_1.FormatDecimal(dtPageCount.Rows(0).Item("Total"), 0)
                Me.pager1.Visible = True
                pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Else
                Me.lblTotal.Text = "0"
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._B2C.UserImport(sql, CurrentUser.UserName)
        End If


        'Dim sql As String = "SELECT ID,USER_ID,CUSTOMER_CODE,CUSTOMER_NAME,PROVINCE_TEXT,EXACTLY_RATE,MOBILE_OPERATOR,UPDATE_BY_ID,UPDATE_BY_TEXT,UPDATE_TIME,REMARK, RowNum as RowNumber " & _
        '                             " FROM CCARE_CUSTOMER_INFO Where Id>0 "
        'If Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text <> "--all--" Then
        '    sql = sql & " And MOBILE_OPERATOR='" & Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text.Trim & "'"
        'End If
        'If Me.txtUSER_ID.Text.Trim <> "" Then
        '    sql = sql & " And  USER_ID='" & Me.txtUSER_ID.Text.Trim & "'"
        'End If
        'sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        'sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        'Dim dt As DataTable = Nothing
        'Dim dtPageCount As DataTable = Nothing
        'If ViewState("DATA_GRID") Is Nothing Then
        '    dt = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        '    dtPageCount = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sqlTotal)
        'Else
        '    dt = CType(ViewState("DATA_GRID"), DataTable)
        '    dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
        'End If
        'ViewState("DATA_GRID") = dt
        'ViewState("DATA_COUNT") = dtPageCount
        'If dt.Rows.Count > 0 Then
        '    Me.DataGrid.DataSource = dt
        '    Me.DataGrid.DataBind()
        '    Me.DataGrid.Columns(9).Visible = IsUpdate
        '    'Me.DataGrid.Columns(7).Visible = IsDelete
        '    Me.DataGrid.PagerStyle.Visible = False
        '    Me.DataGrid.Visible = True
        '    pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
        '    pager1.Visible = True
        '    'Dim gridrow As DataGridItem
        '    'Dim thisButton As ImageButton
        '    'For Each gridrow In Me.DataGrid.Items
        '    '    thisButton = gridrow.FindControl("deleter")
        '    '    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        '    'Next
        'Else
        '    Me.DataGrid.Visible = False
        '    pager1.Visible = False
        '    Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        'End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPARTNER_ID_IMPORT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID_IMPORT.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND  Where STATUS_ID=1 And PARTNER_ID=" & DropDownListPARTNER_ID_IMPORT.SelectedItem.Value & " Order by upper(BRAND_NAME)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListBRAND_ID_IMPORT.Items.Clear()
        Me.DropDownListBRAND_ID_IMPORT.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListBRAND_ID_IMPORT.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListBRAND_ID_IMPORT.Items.Add(New ListItem(dt.Rows(i).Item("BRAND_NAME"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
  
End Class
