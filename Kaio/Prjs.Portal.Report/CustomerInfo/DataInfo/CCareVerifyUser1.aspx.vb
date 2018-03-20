Imports System.Data.OracleClient

Public Class CCareVerifyUser1
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CẬP NHẬT THÔNG TIN KHÁCH HÀNG"
            BindDictIndex()
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.pager1.Visible = False
        End If
        Me.btnDeletePage.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Me.btnDeleteAll.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")

        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
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
        BindBirthday()
        BindExactlyRate()
        BindDate()
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PARTNER Where STATUS_ID=1 Order by upper(PARTNER_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPARTNER_ID.Items.Clear()
        Me.DropDownListPARTNER_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPARTNER_ID.SelectedValue = 0
        Me.DropDownListPARTNER_ID_Add.Items.Clear()
        Me.DropDownListPARTNER_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPARTNER_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPARTNER_ID.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListPARTNER_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
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
    Private Sub BindBrand_Add(ByVal PARTNER_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND  Where STATUS_ID=1 And PARTNER_ID=" & PARTNER_ID & " Order by upper(BRAND_NAME)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListBRAND_NAME_Add.Items.Clear()
        Me.DropDownListBRAND_NAME_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListBRAND_NAME_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListBRAND_NAME_Add.Items.Add(New ListItem(dt.Rows(i).Item("BRAND_NAME"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindProvince()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PROVINCE  Where STATUS_ID=1 Order by upper(PROVINCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPROVINCE_ID.Items.Clear()
        Me.DropDownListPROVINCE_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPROVINCE_ID.SelectedValue = 0
        Me.DropDownListPROVINCE_ID_Add.Items.Clear()
        Me.DropDownListPROVINCE_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPROVINCE_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPROVINCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("PROVINCE_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListPROVINCE_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("PROVINCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindSource()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_SOURCE  Where STATUS_ID=1 Order by upper(SOURCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListSOURCE_ID.Items.Clear()
        Me.DropDownListSOURCE_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListSOURCE_ID.SelectedValue = 0
        Me.DropDownListSOURCE_ID_Add.Items.Clear()
        Me.DropDownListSOURCE_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListSOURCE_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListSOURCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListSOURCE_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindFees()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FEES  Where STATUS_ID=1 Order by upper(FEES_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListFEES_ID.Items.Clear()
        Me.DropDownListFEES_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListFEES_ID.SelectedValue = 0
        Me.DropDownListFEES_ID_Add.Items.Clear()
        Me.DropDownListFEES_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListFEES_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListFEES_ID.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListFEES_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindField()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FIELD  Where STATUS_ID=1 Order by upper(FIELD_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.CheckBoxListFIELD_ID.Items.Clear()
        Me.CheckBoxListFIELD_ID_Add.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.CheckBoxListFIELD_ID.Items.Add(New ListItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
                Me.CheckBoxListFIELD_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindIncome()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_INCOME  Where STATUS_ID=1 Order by upper(INCOME_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListINCOME_ID.Items.Clear()
        Me.DropDownListINCOME_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListINCOME_ID.SelectedValue = 0
        Me.DropDownListINCOME_ID_Add.Items.Clear()
        Me.DropDownListINCOME_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListINCOME_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListINCOME_ID.Items.Add(New ListItem(dt.Rows(i).Item("INCOME_TEXT"), dt.Rows(i).Item("ID")))
                Me.DropDownListINCOME_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("INCOME_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindBirthday()

        Me.DropDownListYEAR_Add.Items.Clear()
        Me.DropDownListMONTH_Add.Items.Clear()
        Me.DropDownListDAY_Add.Items.Clear()
        Me.DropDownListYEAR_Add.Items.Add(New ListItem("--Chọn--", "--Chọn--"))
        Me.DropDownListMONTH_Add.Items.Add(New ListItem("--Chọn--", "--Chọn--"))
        Me.DropDownListDAY_Add.Items.Add(New ListItem("--Chọn--", "--Chọn--"))
        Me.DropDownListYEAR_Add.Items.Add(New ListItem("NA", "NA"))
        Me.DropDownListMONTH_Add.Items.Add(New ListItem("NA", "NA"))
        Me.DropDownListDAY_Add.Items.Add(New ListItem("NA", "NA"))
        For i As Integer = 1940 To 2012
            Me.DropDownListYEAR_Add.Items.Add(New ListItem(i, i))
        Next
        For j As Integer = 1 To 12
            Me.DropDownListMONTH_Add.Items.Add(New ListItem(Util.StringBuilder.ConvertDigit(j), Util.StringBuilder.ConvertDigit(j)))
        Next
        For k As Integer = 1 To 31
            Me.DropDownListDAY_Add.Items.Add(New ListItem(Util.StringBuilder.ConvertDigit(k), Util.StringBuilder.ConvertDigit(k)))
        Next

    End Sub
    Private Sub BindExactlyRate()
        Me.DropDownListEXACTLY_RATE_NUMBER.Items.Clear()
        Me.DropDownListEXACTLY_RATE_NUMBER.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListEXACTLY_RATE_Add.Items.Clear()
        Me.DropDownListEXACTLY_RATE_Add.Items.Add(New ListItem("--Chọn--", "--Chọn--"))
        For i As Integer = 0 To 100 Step 10
            Me.DropDownListEXACTLY_RATE_NUMBER.Items.Add(New ListItem(i, i))
            Me.DropDownListEXACTLY_RATE_Add.Items.Add(New ListItem(i, i))
        Next
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
    End Sub
    Private Sub BindDistrict(ByVal PROVINCE_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_DISTRICT  Where STATUS_ID=1 And PROVINCE_ID=" & PROVINCE_ID & " Order by upper(DISTRICT_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListDISTRICT_ID.Items.Clear()
        Me.DropDownListDISTRICT_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDISTRICT_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDISTRICT_ID.Items.Add(New ListItem(dt.Rows(i).Item("DISTRICT_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindDistrict_Add(ByVal PROVINCE_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_DISTRICT  Where STATUS_ID=1 And PROVINCE_ID=" & PROVINCE_ID & " Order by upper(DISTRICT_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListDISTRICT_ID_Add.Items.Clear()
        Me.DropDownListDISTRICT_ID_Add.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDISTRICT_ID_Add.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDISTRICT_ID_Add.Items.Add(New ListItem(dt.Rows(i).Item("DISTRICT_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPARTNER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID.SelectedIndexChanged
        BindBrand(Me.DropDownListPARTNER_ID.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListPARTNER_ID_Add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID_Add.SelectedIndexChanged
        BindBrand_Add(Me.DropDownListPARTNER_ID_Add.SelectedItem.Value)
    End Sub
#End Region
#Region "Bind Data Search"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT ID,USER_ID,  STATUS_ID,  STATUS_TEXT,  GROUP_TEXT,  (case when length(mt)>25 then substr(mt,1,25)||'...' else mt end) MT,  BRAND_ID,  BRAND_NAME,  PARTNER_ID,  PARTNER_TEXT,  PROVINCE_ID,  PROVINCE_TEXT,  SEX_ID,  SEX_TEXT,  FIELD_ID,  FIELD_TEXT, " & _
"SOURCE_ID,  SOURCE_TEXT,  KEY_WORD,  REMARK,  CUSTOMER_CODE,  CUSTOMER_NAME,  BIRTH_DAY,  ADDRESS,  EMAIL_ADDRESS,  FEES_ID,  FEES_TEXT,  INCOME_ID,  INCOME_TEXT,  EXACTLY_RATE, " & _
"MOBILE_OPERATOR,  IS_VERIFY_1,  VERIFY_BY_1_ID,  VERIFY_BY_1_TEXT,  VERIFY_TIME_1,  IS_VERIFY_2,  VERIFY_BY_2_ID,  VERIFY_BY_2_TEXT,  VERIFY_TIME_2,  IS_VERIFY_3,  VERIFY_BY_3_ID,  VERIFY_BY_3_TEXT," & _
"VERIFY_TIME_3,  KEY_IMPORT,  FILE_IMPORT,  DUPLICATE_NUMBER,  EXIST_NUMBER,  CREATE_BY_ID,  CREATE_BY_TEXT,  CREATE_TIME,  UPDATE_BY_ID,  UPDATE_BY_TEXT,  UPDATE_TIME,  LOGER_INFO,DISTRICT_ID,DISTRICT_TEXT,RowNum as RowNumber" & _
" FROM CCARE_CUSTOMER_IMPORT Where Id >0"
        sql = sql & IsSqlSearch()
        If Me.txtTOP.Text.Trim <> "" Then
            sql = "SELECT * From (" & sql & ") T1 WHERE  T1.RowNumber  >" & 0 & " and  T1.RowNumber <= " & Me.txtTOP.Text.Trim
        End If
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        If strAction = Constants.Action.Search Then
            Dim dtProc As DataTable = Nothing
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                dtProc = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
                dt = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                dtPageCount = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sqlTotal)
            Else
                dtProc = CType(ViewState("DATA_PROC"), DataTable)
                dt = CType(ViewState("DATA_GRID"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
            End If
            ViewState("DATA_PROC") = dtProc
            ViewState("DATA_GRID") = dt
            ViewState("DATA_COUNT") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGrid.DataSource = dt
                Me.DataGrid.DataBind()
                Me.lblTotal.Text = "(" & Utils_1.FormatDecimal(dtPageCount.Rows(0).Item("Total"), 0) & ")"
                Me.pager1.Visible = True
                pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                ViewState("result_search") = "Y"
            Else
                Me.lblTotal.Text = "0"
                Me.pager1.Visible = False
                ViewState("result_search") = "N"
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._B2C.UserImport(sql, CurrentUser.UserName)
        End If
       
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
        If Me.DropDownListDISTRICT_ID.SelectedItem.Value > 0 Then
            sql = sql & " And DISTRICT_ID=" & Me.DropDownListDISTRICT_ID.SelectedItem.Value
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
    Private Function IsSqlUpdate() As String
        Dim sql As String = ""
        If txtUSER_ID_Add.Text <> "" Then
            sql = sql & ",USER_ID='" & Me.txtUSER_ID_Add.Text.Trim & "'"
        End If
        If Me.txtMT_Add.Text.Trim <> "" Then
            sql = sql & ",MT='" & Me.txtMT_Add.Text.Trim & "'"
        End If
        If Me.DropDownListPARTNER_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",PARTNER_ID=" & Me.DropDownListPARTNER_ID_Add.SelectedItem.Value
            sql = sql & ",PARTNER_TEXT='" & Me.DropDownListPARTNER_ID_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListBRAND_NAME_Add.SelectedItem.Value > 0 Then
            sql = sql & ",BRAND_ID=" & Me.DropDownListBRAND_NAME_Add.SelectedItem.Value
            sql = sql & ",BRAND_NAME='" & Me.DropDownListBRAND_NAME_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListPROVINCE_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",PROVINCE_ID=" & Me.DropDownListPROVINCE_ID_Add.SelectedItem.Value
            sql = sql & ", PROVINCE_TEXT='" & Me.DropDownListPROVINCE_ID_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListDISTRICT_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",DISTRICT_ID=" & Me.DropDownListDISTRICT_ID_Add.SelectedItem.Value
            sql = sql & ", DISTRICT_TEXT='" & Me.DropDownListDISTRICT_ID_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListSEX_Add.SelectedItem.Value > -1 Then
            sql = sql & ",SEX_ID=" & Me.DropDownListSEX_Add.SelectedItem.Value
            sql = sql & ",SEX_TEXT='" & Me.DropDownListSEX_Add.SelectedItem.Text & "'"
        End If
        Dim FIELD_ID As String = 0
        Dim FIELD_TEXT As String = ""
        For i As Integer = 0 To Me.CheckBoxListFIELD_ID_Add.Items.Count - 1
            If CheckBoxListFIELD_ID_Add.Items(i).Selected = True Then
                If FIELD_TEXT.Trim = "" Then
                    FIELD_TEXT = Me.CheckBoxListFIELD_ID_Add.Items(i).Text
                    FIELD_ID = Me.CheckBoxListFIELD_ID_Add.Items(i).Value & ";"
                Else
                    FIELD_TEXT = FIELD_TEXT & ";" & Me.CheckBoxListFIELD_ID_Add.Items(i).Text
                    FIELD_ID = FIELD_ID & Me.CheckBoxListFIELD_ID_Add.Items(i).Value & ";"
                End If
            End If
        Next
        If FIELD_TEXT <> "" Then
            sql = sql & ",FIELD_ID='" & FIELD_ID & "'"
            sql = sql & ",FIELD_TEXT='" & FIELD_TEXT & "'"
        End If
        If Me.DropDownListSOURCE_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",SOURCE_ID=" & Me.DropDownListSOURCE_ID_Add.SelectedItem.Value
            sql = sql & ",SOURCE_TEXT='" & Me.DropDownListSOURCE_ID_Add.SelectedItem.Text & "'"
        End If
        If txtKEY_WORD_Add.Text <> "" Then
            sql = sql & ",KEY_WORD='" & Me.txtKEY_WORD_Add.Text.Trim & "'"
        End If
        If txtGROUP_TEXT_Add.Text <> "" Then
            sql = sql & ",GROUP_TEXT='" & Me.txtGROUP_TEXT_Add.Text.Trim & "'"
        End If
        If txtREMARK_Add.Text <> "" Then
            sql = sql & ",REMARK='" & Me.txtREMARK_Add.Text.Trim & "'"
        End If
        If txtCUSTOMER_CODE_Add.Text <> "" Then
            sql = sql & ",CUSTOMER_CODE='" & Me.txtCUSTOMER_CODE_Add.Text.Trim & "'"
        End If
        If txtCUSTOMER_NAME_Add.Text <> "" Then
            sql = sql & ",CUSTOMER_NAME='" & Me.txtCUSTOMER_NAME_Add.Text.Trim & "'"
        End If
        If Me.DropDownListYEAR_Add.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & ",BIRTH_DAY=SUBSTR(BIRTH_DAY,1,6)||'" & Me.DropDownListYEAR_Add.Text.Trim & "'"
        End If
        If Me.DropDownListMONTH_Add.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & ",BIRTH_DAY=SUBSTR(BIRTH_DAY,1,3||'" & Me.DropDownListMONTH_Add.Text.Trim & "'||SUBSTR(BIRTH_DAY,6)"
        End If
        If Me.DropDownListDAY_Add.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & ",BIRTH_DAY='" & DropDownListDAY_Add.SelectedItem.Text & "'||SUBSTR(BIRTH_DAY,3)'"
        End If
        If txtADDRESS_Add.Text <> "" Then
            sql = sql & ",ADDRESS='" & Me.txtADDRESS_Add.Text.Trim & "'"
        End If
        If txtEMAIL_ADDRESS_Add.Text <> "" Then
            sql = sql & ",EMAIL_ADDRESS='" & Me.txtEMAIL_ADDRESS_Add.Text.Trim & "'"
        End If
        If Me.DropDownListFEES_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",FEES_ID=" & Me.DropDownListFEES_ID_Add.SelectedItem.Value
            sql = sql & ",FEES_TEXT='" & Me.DropDownListFEES_ID_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListINCOME_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",INCOME_ID=" & Me.DropDownListINCOME_ID_Add.SelectedItem.Value
            sql = sql & ",INCOME_TEXT='" & Me.DropDownListINCOME_ID_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListMOBILE_OPERATOR_Add.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & ",MOBILE_OPERATOR='" & Me.DropDownListMOBILE_OPERATOR_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListEXACTLY_RATE_Add.SelectedItem.Text <> "--Chọn--" Then
            sql = sql & ",EXACTLY_RATE='" & Me.DropDownListEXACTLY_RATE_Add.SelectedItem.Text & "'"
        End If
        If Me.DropDownListSTATUS_ID_Add.SelectedItem.Value > 0 Then
            sql = sql & ",STATUS_ID=" & Me.DropDownListSTATUS_ID_Add.SelectedItem.Value
            sql = sql & ", STATUS_TEXT='" & Me.DropDownListSTATUS_ID_Add.SelectedItem.Text & "'"
        End If
        Return sql
    End Function
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim vTotal As Integer = 0
        Dim result As String = UpdateDataPage(IsSqlUpdate, vTotal)
        If result = "" Then
            Me.lblerror.Text = "Cập nhật đươc " & vTotal & " bản ghi !"
            Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), "SELECT * FROM CCARE_CUSTOMER_IMPORT WHERE ID IN (" & ViewState("Id_Page") & ")")
            If Me.CheckBoxSaveCall.Checked = True Then
                Dim TotalExistCall As Integer = 0
                If MoveDataPage(dt, TotalExistCall) = "" Then
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Chuyển dữ liệu thành công " & vTotal - TotalExistCall & " bản ghi sang bảng gọi. Số bản ghi trùng: " & TotalExistCall
                Else
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi chuyển dữ liệu sang bảng gọi"
                End If
            End If
            If Me.CheckBoxSaveDone.Checked = True Then
                Dim TotalExistDone As Integer = 0
                If MoveDataPageDone(dt, TotalExistDone) = "" Then
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Chuyển dữ liệu thành công " & vTotal - TotalExistDone & " bản ghi sang bảng chính thức. Số bản ghi trùng: " & TotalExistDone
                Else
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi chuyển dữ liệu sang bảng chính thức"
                End If
            End If

            If Me.CheckBoxDelImport.Checked = True Then
                Dim TotalDel As Integer = 0
                If DelDataPage(TotalDel) = "" Then
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu thành công " & TotalDel & " bản ghi !"
                Else
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu "
                End If
            End If
            If Me.CheckBoxDelThesame.Checked = True Then
                If DelDataPageTheSame() = "" Then
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu liên quan thành công !"
                Else
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu liên quan"
                End If
            End If
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Else
            Me.lblerror.Text = result
        End If
    End Sub
    Protected Sub btnUpdateAll_Click(sender As Object, e As EventArgs) Handles btnUpdateAll.Click
        If ViewState("result_search") = "N" Then
            Me.lblerror.Text = "Không có bản ghi nào được cập nhật thông tin !"
        Else
            Dim result As String = UpdateDataAll(IsSqlUpdate, CType(ViewState("DATA_PROC"), DataTable))
            If result = "" Then
                Me.lblerror.Text = "Cập nhật được " & CType(ViewState("DATA_PROC"), DataTable).Rows.Count & " bản ghi !"
                If Me.CheckBoxSaveCall.Checked = True Then
                    Dim TotalExistCall As Integer = 0
                    If MoveDataAll(CType(ViewState("DATA_PROC"), DataTable), TotalExistCall) = "" Then
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Chuyển dữ liệu thành công " & CType(ViewState("DATA_PROC"), DataTable).Rows.Count - TotalExistCall & " bản ghi sang bảng gọi. Số bản ghi trùng: " & TotalExistCall
                    Else
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi chuyển dữ liệu sang bảng gọi"
                    End If
                End If
                If Me.CheckBoxSaveDone.Checked = True Then
                    Dim TotalExistDone As Integer = 0
                    If MoveDataAllDone(CType(ViewState("DATA_PROC"), DataTable), TotalExistDone) = "" Then
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Chuyển dữ liệu thành công " & CType(ViewState("DATA_PROC"), DataTable).Rows.Count - TotalExistDone & " bản ghi sang bảng chính thức. Số bản ghi trùng: " & TotalExistDone
                    Else
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi chuyển dữ liệu sang bảng chính thức"
                    End If
                End If
                If Me.CheckBoxDelImport.Checked = True Then
                    Dim TotalDel As Integer = 0
                    If DelDataAll(CType(ViewState("DATA_PROC"), DataTable), TotalDel) = "" Then
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu thành công " & TotalDel & " bản ghi !"
                    Else
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu "
                    End If
                End If
                If Me.CheckBoxDelThesame.Checked = True Then
                    If DelDataAllTheSame(CType(ViewState("DATA_PROC"), DataTable)) = "" Then
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu liên quan thành công !"
                    Else
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu liên quan "
                    End If
                End If
                ViewState("DATA_GRID") = Nothing
                ViewState("DATA_COUNT") = Nothing
                Dim intPageSize As Integer = pager1.PageSize
                Dim intCurentPage As Integer = pager1.CurrentIndex
                BindData(intPageSize, intCurentPage, Constants.Action.Search)
            Else
                Me.lblerror.Text = result
            End If
        End If
    End Sub
    Protected Sub btnDeletePage_Click(sender As Object, e As EventArgs) Handles btnDeletePage.Click
        Dim Total As Integer = 0
        Dim result As String = DelDataPage(Total)
        If result = "" Then
            Me.lblerror.Text = "Xóa dữ liệu thành công " & Total & " bản ghi !"
        Else
            Me.lblerror.Text = result
        End If
    End Sub
    Protected Sub btnDeleteAll_Click(sender As Object, e As EventArgs) Handles btnDeleteAll.Click
        If ViewState("result_search") = "N" Then
            Me.lblerror.Text = "Không có bản ghi nào được cập nhật thông tin !"
        Else
            Dim TotalDel As Integer = 0
            Dim result As String = DelDataAll(CType(ViewState("DATA_PROC"), DataTable), TotalDel)
            If result = "" Then
                Me.lblerror.Text = "Đã xóa " & TotalDel & "/" & CType(ViewState("DATA_PROC"), DataTable).Rows.Count & " bản ghi !"
            Else
                Me.lblerror.Text = result
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Update Data"
    Private Function UpdateDataPage(ByVal SqlUpdateField As String, ByRef vTotal As Integer) As String
        Dim retval As String = ""
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGrid.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                    vTotal = vTotal + 1
                End If
            End If
        Next
        ViewState("Id_Page") = vId
        If SqlUpdateField <> "" Then
            If vId <> "0" Then
                sql = "Update CCARE_CUSTOMER_IMPORT " & _
                        " SET IS_VERIFY_1=1" & _
                        ",VERIFY_BY_1_ID=" & CurrentUser.UserId & _
                        ",VERIFY_BY_1_TEXT='" & CurrentUser.UserName & _
                        "',VERIFY_TIME_1=TO_DATE('" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "', 'YYYY-MM-DD HH24:MI:SS')" & _
                        SqlUpdateField & _
                        " WHERE ID IN (" & vId & ")"
                Try
                    OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                Catch ex As Exception
                    retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                End Try
            End If
        End If
        Return retval
    End Function
    Private Function UpdateDataAll(ByVal sqlUpdateField As String, ByVal dt As DataTable) As String
        Dim retval As String = ""
        Dim sql As String = ""
        If sqlUpdateField <> "" Then
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    Me.lblerror.Text = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                End Try
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                sql = "Update CCARE_CUSTOMER_IMPORT " & _
                   " SET IS_VERIFY_1=1" & _
                   ",VERIFY_BY_1_ID=" & CurrentUser.UserId & _
                   ",VERIFY_BY_1_TEXT='" & CurrentUser.UserName & _
                   "',VERIFY_TIME_1=TO_DATE('" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "', 'YYYY-MM-DD HH24:MI:SS')" & _
                   sqlUpdateField & _
                   " WHERE Id =  " & dt.Rows(i).Item("ID")
                Dim cmd As New OracleCommand
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = sql
                    .Connection = conn
                End With
                Try
                    OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                Catch ex As Exception
                    If (conn.State = ConnectionState.Open) Then
                        conn.Close()
                        conn.Dispose()
                    End If
                    retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                End Try
            Next
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
        End If
        Return retval
    End Function
#End Region
#Region "Delete Data"
    Private Function DelDataPage(ByRef Total As Integer) As String
        Dim retval As String = ""
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGrid.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                    Total = Total + 1
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From CCARE_CUSTOMER_IMPORT  WHERE ID IN (" & vId & ")"
            Try
                OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            Catch ex As Exception
                retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
        Return retval
    End Function
    Private Function DelDataPageTheSame() As String
        Dim retval As String = ""
        Dim User_Id As String = ""
        Dim vId As String = ""

        Dim sql As String = ""
        ' Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        Dim lblUser_Id As Label
        For Each DataGridItem In DataGrid.Items
            If TypeOf DataGridItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(DataGridItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                lblUser_Id = CType(DataGridItem.Cells(1).Controls(1).FindControl("lblUser_Id"), Label)
                'lblUser_Id = DataGridItem.FindControl("lblUser_Id")
                If ckObj.Checked Then
                    If User_Id = "" Then
                        User_Id = "'" & lblUser_Id.Text & "'"
                        vId = ckObj.Value
                    Else
                        User_Id = User_Id & ",'" & lblUser_Id.Text.Trim & "'"
                        vId = vId & "," & ckObj.Value
                    End If
                End If
            End If
        Next
        If User_Id <> "" Then
            sql = "Delete From CCARE_CUSTOMER_IMPORT  WHERE USER_ID In (" & User_Id & ") And ID Not In (" & vId & ") "
            Try
                OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            Catch ex As Exception
                retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
        Return retval
    End Function
    Private Function DelDataAll(ByVal dt As DataTable, ByRef Total As Integer) As String
        Dim retval As String = ""
        Dim sql As String = ""
        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            sql = "Delete From CCARE_CUSTOMER_IMPORT WHERE Id =  " & dt.Rows(i).Item("ID")
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = conn
            End With
            Try
                OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                Total = Total + 1
            Catch ex As Exception
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                    conn.Dispose()
                End If
                retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        Next
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Return retval
    End Function
    Private Function DelDataAllTheSame(ByVal dt As DataTable) As String
        Dim retval As String = ""
        Dim sql As String = ""
        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            sql = "Delete From CCARE_CUSTOMER_IMPORT WHERE USER_ID =  '" & dt.Rows(i).Item("USER_ID") & "' And Id <> " & dt.Rows(i).Item("ID")
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.Text
                .CommandText = sql
                .Connection = conn
            End With
            Try
                OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            Catch ex As Exception
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                    conn.Dispose()
                End If
                retval = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        Next
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Return retval
    End Function
#End Region
#Region "Move Data"
    Private Function MoveDataPage(ByVal dt As DataTable, ByRef TotalExist As Integer) As String
        Dim retval As String = ""
        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sql As String = "SELECT * From  CCARE_CUSTOMER_VERIFY_1  Where  upper(USER_ID)='" & dt.Rows(i).Item("USER_ID").ToUpper & "'"
            If Me.B2CCheckData(sql) = False Then
                Dim cmd As New OracleCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "CCARE_CUSTOMER.INSERT_CCARE_CUSTOMER_VERIFY_1"
                    .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                    .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                    .Parameters("p_USER_ID").Value = dt.Rows(i).Item("USER_ID")

                    .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                    .Parameters("p_STATUS_ID").Value = dt.Rows(i).Item("STATUS_ID")

                    .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                    .Parameters("p_STATUS_TEXT").Value = dt.Rows(i).Item("STATUS_TEXT")

                    .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_GROUP_TEXT").Value = dt.Rows(i).Item("GROUP_TEXT")

                    .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                    .Parameters("p_MT").Value = dt.Rows(i).Item("MT")

                    .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                    .Parameters("p_BRAND_ID").Value = dt.Rows(i).Item("BRAND_ID")

                    .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                    .Parameters("p_BRAND_NAME").Value = dt.Rows(i).Item("BRAND_NAME")

                    .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                    .Parameters("p_PARTNER_ID").Value = dt.Rows(i).Item("PARTNER_ID")

                    .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_PARTNER_TEXT").Value = dt.Rows(i).Item("PARTNER_TEXT")

                    .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                    .Parameters("p_PROVINCE_ID").Value = dt.Rows(i).Item("PROVINCE_ID")

                    .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_PROVINCE_TEXT").Value = dt.Rows(i).Item("PROVINCE_TEXT")

                    .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                    .Parameters("p_DISTRICT_ID").Value = dt.Rows(i).Item("DISTRICT_ID")

                    .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_DISTRICT_TEXT").Value = dt.Rows(i).Item("DISTRICT_TEXT")

                    .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                    .Parameters("p_SEX_ID").Value = dt.Rows(i).Item("SEX_ID")

                    .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_SEX_TEXT").Value = dt.Rows(i).Item("SEX_TEXT")

                    .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 200))
                    .Parameters("p_FIELD_ID").Value = dt.Rows(i).Item("FIELD_ID")

                    .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_FIELD_TEXT").Value = dt.Rows(i).Item("FIELD_TEXT")

                    .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                    .Parameters("p_SOURCE_ID").Value = dt.Rows(i).Item("SOURCE_ID")

                    .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                    .Parameters("p_SOURCE_TEXT").Value = dt.Rows(i).Item("SOURCE_TEXT")

                    .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                    .Parameters("p_KEY_WORD").Value = dt.Rows(i).Item("KEY_WORD")

                    .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                    .Parameters("p_REMARK").Value = dt.Rows(i).Item("REMARK")

                    .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                    .Parameters("p_CUSTOMER_CODE").Value = dt.Rows(i).Item("CUSTOMER_CODE")

                    .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                    .Parameters("p_CUSTOMER_NAME").Value = dt.Rows(i).Item("CUSTOMER_NAME")

                    .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                    .Parameters("p_BIRTH_DAY").Value = dt.Rows(i).Item("BIRTH_DAY")

                    .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                    .Parameters("p_ADDRESS").Value = dt.Rows(i).Item("ADDRESS")

                    .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                    .Parameters("p_EMAIL_ADDRESS").Value = dt.Rows(i).Item("EMAIL_ADDRESS")

                    .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                    .Parameters("p_FEES_ID").Value = dt.Rows(i).Item("FEES_ID")

                    .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_FEES_TEXT").Value = dt.Rows(i).Item("FEES_TEXT")

                    .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                    .Parameters("p_INCOME_ID").Value = dt.Rows(i).Item("INCOME_ID")

                    .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_INCOME_TEXT").Value = dt.Rows(i).Item("INCOME_TEXT")

                    .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                    .Parameters("p_EXACTLY_RATE").Value = dt.Rows(i).Item("EXACTLY_RATE")

                    .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                    .Parameters("p_MOBILE_OPERATOR").Value = dt.Rows(i).Item("MOBILE_OPERATOR")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_1", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_1").Value = dt.Rows(i).Item("IS_VERIFY_1")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_1_ID").Value = dt.Rows(i).Item("VERIFY_BY_1_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_1_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_1_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_1", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_1").Value = dt.Rows(i).Item("VERIFY_TIME_1")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_2", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_2").Value = dt.Rows(i).Item("IS_VERIFY_2")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_2_ID").Value = dt.Rows(i).Item("VERIFY_BY_2_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_2_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_2_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_2", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_2").Value = dt.Rows(i).Item("VERIFY_TIME_2")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_3", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_3").Value = dt.Rows(i).Item("IS_VERIFY_3")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_3_ID").Value = dt.Rows(i).Item("VERIFY_BY_3_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_3_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_3_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_3", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_3").Value = dt.Rows(i).Item("VERIFY_TIME_3")

                    .Parameters.Add(New OracleParameter("p_KEY_IMPORT", OracleType.VarChar, 200))
                    .Parameters("p_KEY_IMPORT").Value = dt.Rows(i).Item("KEY_IMPORT")

                    .Parameters.Add(New OracleParameter("p_FILE_IMPORT", OracleType.VarChar, 200))
                    .Parameters("p_FILE_IMPORT").Value = dt.Rows(i).Item("FILE_IMPORT")

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_CREATE_BY_ID").Value = dt.Rows(i).Item("CREATE_BY_ID")

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_CREATE_BY_TEXT").Value = dt.Rows(i).Item("CREATE_BY_TEXT")

                    .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_CREATE_TIME").Value = dt.Rows(i).Item("CREATE_TIME")

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_UPDATE_BY_ID").Value = dt.Rows(i).Item("UPDATE_BY_ID")

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                    .Parameters("p_UPDATE_BY_TEXT").Value = dt.Rows(i).Item("UPDATE_BY_TEXT")

                    .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_UPDATE_TIME").Value = dt.Rows(i).Item("UPDATE_TIME")

                    .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                    .Parameters("p_LOGER_INFO").Value = dt.Rows(i).Item("LOGER_INFO")

                    .Parameters.Add(New OracleParameter("p_DUPLICATE_NUMBER", OracleType.Int32, 10))
                    .Parameters("p_DUPLICATE_NUMBER").Value = dt.Rows(i).Item("DUPLICATE_NUMBER")

                    .Parameters.Add(New OracleParameter("p_EXIST_NUMBER", OracleType.Int32, 10))
                    .Parameters("p_EXIST_NUMBER").Value = dt.Rows(i).Item("EXIST_NUMBER")

                    .Connection = conn
                    Try
                        .ExecuteNonQuery()

                    Catch ex As Exception
                        retval = ex.Message
                        If (conn.State = ConnectionState.Open) Then
                            conn.Close()
                            conn.Dispose()
                        End If
                        Return retval
                    End Try
                End With
            Else
                TotalExist = TotalExist + 1
            End If

        Next


        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Return retval
    End Function
    Private Function MoveDataPageDone(ByVal dt As DataTable, ByRef TotalExist As Integer) As String
        Dim retval As String = ""
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim sql As String = "SELECT * From  CCARE_CUSTOMER_INFO  Where  upper(USER_ID)='" & dt.Rows(i).Item("USER_ID").ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then
                    retval = UpdateObject.B2CManagement.MoveImport_To_Info(dt.Rows(i).Item("ID"))
                Else
                    TotalExist = TotalExist + 1
                End If
            Next
        Catch ex As Exception
            retval = ex.Message
            Return retval
        End Try
        Return retval
    End Function
    Private Function MoveDataAll(ByVal dt As DataTable, ByRef TotalExist As Integer)
        Dim retval As String = ""
        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim sql As String = "SELECT * From  CCARE_CUSTOMER_VERIFY_1  Where   upper(USER_ID)='" & dt.Rows(i).Item("USER_ID").ToUpper & "'"
            If Me.B2CCheckData(sql) = False Then
                Dim cmd As New OracleCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "CCARE_CUSTOMER.INSERT_CCARE_CUSTOMER_VERIFY_1"
                    .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                    .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                    .Parameters("p_USER_ID").Value = dt.Rows(i).Item("USER_ID")

                    .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                    .Parameters("p_STATUS_ID").Value = 2 ' dt.Rows(i).Item("STATUS_ID")

                    .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                    .Parameters("p_STATUS_TEXT").Value = dt.Rows(i).Item("STATUS_TEXT")

                    .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_GROUP_TEXT").Value = "Call" ' dt.Rows(i).Item("GROUP_TEXT")

                    .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                    .Parameters("p_MT").Value = dt.Rows(i).Item("MT")

                    .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                    .Parameters("p_BRAND_ID").Value = dt.Rows(i).Item("BRAND_ID")

                    .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                    .Parameters("p_BRAND_NAME").Value = dt.Rows(i).Item("BRAND_NAME")

                    .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                    .Parameters("p_PARTNER_ID").Value = dt.Rows(i).Item("PARTNER_ID")

                    .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_PARTNER_TEXT").Value = dt.Rows(i).Item("PARTNER_TEXT")

                    .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                    .Parameters("p_PROVINCE_ID").Value = dt.Rows(i).Item("PROVINCE_ID")

                    .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_PROVINCE_TEXT").Value = dt.Rows(i).Item("PROVINCE_TEXT")

                    .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                    .Parameters("p_DISTRICT_ID").Value = dt.Rows(i).Item("DISTRICT_ID")

                    .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_DISTRICT_TEXT").Value = dt.Rows(i).Item("DISTRICT_TEXT")

                    .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                    .Parameters("p_SEX_ID").Value = dt.Rows(i).Item("SEX_ID")

                    .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_SEX_TEXT").Value = dt.Rows(i).Item("SEX_TEXT")

                    .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 200))
                    .Parameters("p_FIELD_ID").Value = dt.Rows(i).Item("FIELD_ID")

                    .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_FIELD_TEXT").Value = dt.Rows(i).Item("FIELD_TEXT")

                    .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                    .Parameters("p_SOURCE_ID").Value = dt.Rows(i).Item("SOURCE_ID")

                    .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                    .Parameters("p_SOURCE_TEXT").Value = dt.Rows(i).Item("SOURCE_TEXT")

                    .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                    .Parameters("p_KEY_WORD").Value = dt.Rows(i).Item("KEY_WORD")

                    .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                    .Parameters("p_REMARK").Value = dt.Rows(i).Item("REMARK")

                    .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                    .Parameters("p_CUSTOMER_CODE").Value = dt.Rows(i).Item("CUSTOMER_CODE")

                    .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                    .Parameters("p_CUSTOMER_NAME").Value = dt.Rows(i).Item("CUSTOMER_NAME")

                    .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                    .Parameters("p_BIRTH_DAY").Value = dt.Rows(i).Item("BIRTH_DAY")

                    .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                    .Parameters("p_ADDRESS").Value = dt.Rows(i).Item("ADDRESS")

                    .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                    .Parameters("p_EMAIL_ADDRESS").Value = dt.Rows(i).Item("EMAIL_ADDRESS")

                    .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                    .Parameters("p_FEES_ID").Value = dt.Rows(i).Item("FEES_ID")

                    .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_FEES_TEXT").Value = dt.Rows(i).Item("FEES_TEXT")

                    .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                    .Parameters("p_INCOME_ID").Value = dt.Rows(i).Item("INCOME_ID")

                    .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_INCOME_TEXT").Value = dt.Rows(i).Item("INCOME_TEXT")

                    .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                    .Parameters("p_EXACTLY_RATE").Value = dt.Rows(i).Item("EXACTLY_RATE")

                    .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                    .Parameters("p_MOBILE_OPERATOR").Value = dt.Rows(i).Item("MOBILE_OPERATOR")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_1", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_1").Value = dt.Rows(i).Item("IS_VERIFY_1")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_1_ID").Value = dt.Rows(i).Item("VERIFY_BY_1_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_1_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_1_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_1", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_1").Value = dt.Rows(i).Item("VERIFY_TIME_1")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_2", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_2").Value = dt.Rows(i).Item("IS_VERIFY_2")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_2_ID").Value = dt.Rows(i).Item("VERIFY_BY_2_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_2_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_2_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_2", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_2").Value = dt.Rows(i).Item("VERIFY_TIME_2")

                    .Parameters.Add(New OracleParameter("p_IS_VERIFY_3", OracleType.Number, 18))
                    .Parameters("p_IS_VERIFY_3").Value = dt.Rows(i).Item("IS_VERIFY_3")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_ID", OracleType.Number, 18))
                    .Parameters("p_VERIFY_BY_3_ID").Value = dt.Rows(i).Item("VERIFY_BY_3_ID")

                    .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_VERIFY_BY_3_TEXT").Value = dt.Rows(i).Item("VERIFY_BY_3_TEXT")

                    .Parameters.Add(New OracleParameter("p_VERIFY_TIME_3", OracleType.DateTime, 200))
                    .Parameters("p_VERIFY_TIME_3").Value = dt.Rows(i).Item("VERIFY_TIME_3")

                    .Parameters.Add(New OracleParameter("p_KEY_IMPORT", OracleType.VarChar, 200))
                    .Parameters("p_KEY_IMPORT").Value = dt.Rows(i).Item("KEY_IMPORT")

                    .Parameters.Add(New OracleParameter("p_FILE_IMPORT", OracleType.VarChar, 200))
                    .Parameters("p_FILE_IMPORT").Value = dt.Rows(i).Item("FILE_IMPORT")

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_CREATE_BY_ID").Value = dt.Rows(i).Item("CREATE_BY_ID")

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_CREATE_BY_TEXT").Value = dt.Rows(i).Item("CREATE_BY_TEXT")

                    .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_CREATE_TIME").Value = dt.Rows(i).Item("CREATE_TIME")

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_UPDATE_BY_ID").Value = dt.Rows(i).Item("UPDATE_BY_ID")

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                    .Parameters("p_UPDATE_BY_TEXT").Value = dt.Rows(i).Item("UPDATE_BY_TEXT")

                    .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_UPDATE_TIME").Value = dt.Rows(i).Item("UPDATE_TIME")

                    .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                    .Parameters("p_LOGER_INFO").Value = dt.Rows(i).Item("LOGER_INFO")

                    .Parameters.Add(New OracleParameter("p_DUPLICATE_NUMBER", OracleType.Int32, 10))
                    .Parameters("p_DUPLICATE_NUMBER").Value = dt.Rows(i).Item("DUPLICATE_NUMBER")

                    .Parameters.Add(New OracleParameter("p_EXIST_NUMBER", OracleType.Int32, 10))
                    .Parameters("p_EXIST_NUMBER").Value = dt.Rows(i).Item("EXIST_NUMBER")

                    .Connection = conn
                    Try
                        .ExecuteNonQuery()

                    Catch ex As Exception
                        retval = ex.Message
                        If (conn.State = ConnectionState.Open) Then
                            conn.Close()
                            conn.Dispose()
                        End If
                        Return retval
                    End Try
                End With
            Else
                TotalExist = TotalExist + 1
            End If

        Next
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Return retval
    End Function
    Private Function MoveDataAllDone(ByVal dt As DataTable, ByRef TotalExist As Integer)
        Dim retval As String = ""
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim sql As String = "SELECT * From  CCARE_CUSTOMER_INFO  Where  upper(USER_ID)='" & dt.Rows(i).Item("USER_ID").ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then
                    retval = UpdateObject.B2CManagement.MoveImport_To_Info(dt.Rows(i).Item("ID"))
                Else
                    TotalExist = TotalExist + 1
                End If
            Next
        Catch ex As Exception
            retval = ex.Message
            Return retval
        End Try
        Return retval
    End Function
#End Region
#Region "Ajax"
    Protected Sub DropDownListSTATUS_ID_Add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListSTATUS_ID_Add.SelectedIndexChanged
        If Me.DropDownListSTATUS_ID_Add.SelectedItem.Value = 2 Then
            Me.CheckBoxSaveCall.Checked = True
        End If
    End Sub
    Protected Sub DropDownListPROVINCE_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPROVINCE_ID.SelectedIndexChanged
        BindDistrict(Me.DropDownListPROVINCE_ID.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListPROVINCE_ID_Add_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPROVINCE_ID_Add.SelectedIndexChanged
        BindDistrict_Add(Me.DropDownListPROVINCE_ID_Add.SelectedItem.Value)
    End Sub
#End Region
End Class
