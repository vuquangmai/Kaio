Public Class CCareCustomerInfoList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ THÔNG TIN KHÁCH HÀNG"
            IsPrivilegeOnMenu()
            BindDictIndex()
            Me.btnAdd.Visible = IsUpdate
            pager1.Visible = False
        End If
        If Not ViewState("DATA_GRID") Is Nothing Then
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End If
       
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
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPARTNER_ID.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
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
    Private Sub BindDistrict(ByVal ProvinceId As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_DISTRICT  Where STATUS_ID=1 And PROVINCE_ID=" & ProvinceId & " Order by upper(DISTRICT_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.RadDropDownListDISTRICT_ID.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListDISTRICT_ID.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("DISTRICT_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDISTRICT_ID.Items
            item.Checked = True
        Next
    End Sub
    Private Sub BindSource()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_SOURCE  Where STATUS_ID=1 Order by upper(SOURCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListSOURCE_ID.Items.Clear()
        Me.DropDownListSOURCE_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListSOURCE_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListSOURCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindFees()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FEES  Where STATUS_ID=1 Order by upper(FEES_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.RadDropDownListFEES_ID.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListFEES_ID.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListFEES_ID.Items
            item.Checked = True
        Next
    End Sub
    Private Sub BindField()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FIELD  Where STATUS_ID=1 Order by upper(FIELD_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.RadDropDownListFIELD_ID.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListFIELD_ID.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
        'For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListFIELD_ID.Items
        '    item.Checked = True
        'Next

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
        If Me.CheckBoxAllDate.Checked = False Then
            sql = sql & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')>='" & FromDate & "'"
            sql = sql & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')<='" & ToDate & "'"
        End If
     
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
        'For i As Integer = 0 To Me.CheckBoxListFIELD_ID.Items.Count - 1
        '    If CheckBoxListFIELD_ID.Items(i).Selected = True Then
        '        If IsField.Trim = "" Then
        '            IsField = "( FIELD_ID like '%" & Me.CheckBoxListFIELD_ID.Items(i).Value & ";%'"
        '        Else
        '            IsField = IsField & " OR FIELD_ID like '%" & Me.CheckBoxListFIELD_ID.Items(i).Value & ";%'"
        '        End If
        '    End If
        'Next
        Dim CollectionField As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListFIELD_ID.CheckedItems
        If CollectionField.Count > 0 Then
            If CollectionField.Count < Me.RadDropDownListFIELD_ID.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionField
                    If IsField.Trim = "" Then
                        IsField = "( FIELD_ID like '%" & item.Value & ";%'"
                    Else
                        IsField = IsField & " OR FIELD_ID like '%" & item.Value & ";%'"
                    End If
                Next
            End If
        End If

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
        Dim CollectionDistrict As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListDISTRICT_ID.CheckedItems
        Dim sbDistrict As New StringBuilder()
        If CollectionDistrict.Count > 0 Then
            If CollectionDistrict.Count < Me.RadDropDownListDISTRICT_ID.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionDistrict
                    If sbDistrict.ToString = "" Then
                        sbDistrict.Append("'" + item.Value + "'")
                    Else
                        sbDistrict.Append(",'" + item.Value + "'")
                    End If
                Next
                sql = sql & " And  DISTRICT_ID In (" & sbDistrict.ToString() & ")"
            End If
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

        Dim CollectionFees As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListFEES_ID.CheckedItems
        Dim sbFees As New StringBuilder()
        If CollectionFees.Count > 0 Then
            If CollectionFees.Count < Me.RadDropDownListFEES_ID.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionFees
                    If sbFees.ToString = "" Then
                        sbFees.Append("'" + item.Value + "'")
                    Else
                        sbFees.Append(",'" + item.Value + "'")
                    End If
                Next
                sql = sql & " And  FEES_ID In (" & sbFees.ToString() & ")"
            End If
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
        Dim sql As String = "SELECT ID,USER_ID,  STATUS_ID,  STATUS_TEXT,  GROUP_TEXT,  (case when length(mt)>25 then substr(mt,1,25)||'...' else mt end) MT,  BRAND_ID,  BRAND_NAME,  PARTNER_ID,  PARTNER_TEXT,  PROVINCE_ID,  PROVINCE_TEXT,DISTRICT_TEXT,  SEX_ID,  SEX_TEXT,  FIELD_ID,  FIELD_TEXT, " & _
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
#Region "Delete Data"
    Private Sub DelDataPage()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGrid.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From CCARE_CUSTOMER_INFO  WHERE ID IN (" & vId & ")"
            Try
                OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
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
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DelDataPage()
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPROVINCE_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPROVINCE_ID.SelectedIndexChanged
        BindDistrict(Me.DropDownListPROVINCE_ID.SelectedItem.Value)
    End Sub
#End Region
End Class