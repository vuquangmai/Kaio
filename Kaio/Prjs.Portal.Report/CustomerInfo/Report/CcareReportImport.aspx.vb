Public Class CcareReportImport
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DỮ LIỆU IMPORT"
            IsPrivilegeOnMenu()
            BindDictIndex()
            pager1.Visible = False

        End If
    End Sub
#End Region
#Region "Dict Index"
    Private Sub BindDictIndex()
        BindPartner()
        BindProvince()
        BindSource()
        BindFees()
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
        Me.DropDownListFEES_ID.Items.Clear()
        Me.DropDownListFEES_ID.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListFEES_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListFEES_ID.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
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
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")

        Dim vTable As String = "CCARE_CUSTOMER_INFO"
        Dim sqlTotal As String = ""
        Dim sql As String = ""
        Dim slSQL As String = ""

        Dim wSQL As String = ""
        Dim gSQL As String = ""
        Dim oSQL As String = ""
        slSQL = "SELECT to_char(CREATE_TIME,'yyyy') YEAR , " & _
        " (case when '" & Me.CheckBoxPARTNER_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(PARTNER_TEXT) end ) as PARTNER_TEXT ," & _
        " (case when '" & Me.CheckBoxBRAND_NAME.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(BRAND_NAME) end ) as BRAND_NAME ," & _
        " (case when '" & Me.CheckBoxKEY_WORD.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(KEY_WORD) end ) as KEY_WORD ," & _
        " (case when '" & Me.CheckBoxGROUP_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(GROUP_TEXT) end ) as GROUP_TEXT ," & _
        " (case when '" & Me.CheckBoxSOURCE_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(SOURCE_TEXT) end ) as SOURCE_TEXT ," & _
        " (case when '" & Me.CheckBoxSTATUS_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(STATUS_TEXT) end ) as STATUS_TEXT ," & _
        " (case when '" & Me.CheckBoxMOBILE_OPERATOR.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(MOBILE_OPERATOR) end ) as MOBILE_OPERATOR ," & _
        " (case when '" & Me.CheckBoxUSER_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(USER_ID) end ) as USER_ID ," & _
        " (case when '" & Me.CheckBoxSEX_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(SEX_TEXT) end ) as SEX_TEXT ," & _
        " (case when '" & Me.CheckBoxPROVINCE_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(PROVINCE_TEXT) end ) as PROVINCE_TEXT ," & _
        " (case when '" & Me.CheckBoxFEES_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(FEES_TEXT) end ) as FEES_TEXT ," & _
        " (case when '" & Me.CheckBoxINCOME_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(INCOME_TEXT) end ) as INCOME_TEXT ," & _
        " (case when '" & Me.CheckBoxEXACTLY_RATE.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(EXACTLY_RATE) end ) as EXACTLY_RATE ," & _
        " count(*) Total " & _
        " FROM " & vTable

        gSQL = " GROUP BY " & _
        " to_char(CREATE_TIME,'yyyy')," & _
        " (case when '" & Me.CheckBoxPARTNER_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(PARTNER_TEXT) end )  ," & _
        " (case when '" & Me.CheckBoxBRAND_NAME.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(BRAND_NAME) end )  ," & _
        " (case when '" & Me.CheckBoxKEY_WORD.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(KEY_WORD) end )  ," & _
        " (case when '" & Me.CheckBoxGROUP_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(GROUP_TEXT) end )  ," & _
        " (case when '" & Me.CheckBoxSOURCE_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(SOURCE_TEXT) end ), " & _
        " (case when '" & Me.CheckBoxSTATUS_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(STATUS_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxMOBILE_OPERATOR.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(MOBILE_OPERATOR) end )," & _
        "  (case when '" & Me.CheckBoxUSER_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(USER_ID) end )," & _
        "  (case when '" & Me.CheckBoxSEX_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(SEX_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxPROVINCE_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(PROVINCE_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxFEES_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(FEES_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxINCOME_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(INCOME_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxEXACTLY_RATE.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(EXACTLY_RATE) end )"

        wSQL = " WHERE to_char(CREATE_TIME,'yyyyMMdd') >='" & FromDate & "'"
        wSQL = wSQL & " And to_char(CREATE_TIME,'yyyyMMdd') <='" & ToDate & "'"

        If Me.CheckBoxPARTNER_ID.Checked = True And Me.DropDownListPARTNER_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and PARTNER_ID=" & Me.DropDownListPARTNER_ID.SelectedItem.Value
        End If
        If Me.CheckBoxBRAND_NAME.Checked = True And Me.DropDownListBRAND_NAME.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and BRAND_ID=" & Me.DropDownListBRAND_NAME.SelectedItem.Value
        End If
        If Me.CheckBoxKEY_WORD.Checked = True And Me.txtKEY_WORD.Text.Trim <> "" Then
            wSQL = wSQL & " and upper(KEY_WORD)='" & Me.txtKEY_WORD.Text.Trim.ToUpper & "'"
        End If
        If Me.CheckBoxGROUP_TEXT.Checked = True And Me.txtGROUP_TEXT.Text.Trim <> "" Then
            wSQL = wSQL & " and upper(GROUP_TEXT)='" & Me.txtGROUP_TEXT.Text.Trim.ToUpper & "'"
        End If
        If Me.CheckBoxSOURCE_TEXT.Checked = True And Me.DropDownListSOURCE_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and SOURCE_ID=" & Me.DropDownListSOURCE_ID.SelectedItem.Value
        End If
        If Me.CheckBoxSTATUS_TEXT.Checked = True And Me.DropDownListSTATUS_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and STATUS_ID=" & Me.DropDownListSTATUS_ID.SelectedItem.Value
        End If
        If Me.CheckBoxMOBILE_OPERATOR.Checked = True And Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text <> "--all--" Then
            wSQL = wSQL & " and upper(MOBILE_OPERATOR)='" & Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text.Trim.ToUpper & "'"
        End If
        If Me.CheckBoxUSER_ID.Checked = True And Me.txtUSER_ID.Text.Trim <> "" Then
            wSQL = wSQL & " and upper(USER_ID)='" & Me.txtUSER_ID.Text.Trim.ToUpper & "'"
        End If
        If Me.CheckBoxSEX_TEXT.Checked = True And Me.DropDownListSEX.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and SEX_ID=" & Me.DropDownListSEX.SelectedItem.Value
        End If
        If Me.CheckBoxPROVINCE_TEXT.Checked = True And Me.DropDownListPROVINCE_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and PROVINCE_ID=" & Me.DropDownListPROVINCE_ID.SelectedItem.Value
        End If
        If Me.CheckBoxFEES_TEXT.Checked = True And Me.DropDownListFEES_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and FIELD_ID=" & Me.DropDownListFEES_ID.SelectedItem.Value
        End If
        If Me.CheckBoxINCOME_TEXT.Checked = True And Me.DropDownListINCOME_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and INCOME_ID=" & Me.DropDownListINCOME_ID.SelectedItem.Value
        End If
        If Me.CheckBoxEXACTLY_RATE.Checked = True And Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Value <> "--all--" Then
            wSQL = wSQL & " and EXACTLY_RATE=" & Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Value
        End If
        sql = slSQL & wSQL & gSQL
        sqlTotal = "SELECT count(*) TotalRecord, sum(Total) Total FROM (" & slSQL & wSQL & gSQL & ")"
        If strAction = Constants.Action.Search Then
            sql = "SELECT T.*,ROWNUM as RowNumber FROM (" & slSQL & wSQL & gSQL & ") T "
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
                Me.lblTotal.Text = Utils_1.FormatDecimal(dtPageCount.Rows(0).Item("Total"), 0)
                Me.pager1.Visible = True
                pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
                IsColumn()
            Else
                Me.lblTotal.Text = "0"
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._B2C.UserImport(sql, CurrentUser.UserName)
        End If
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
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPARTNER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID.SelectedIndexChanged
        BindBrand(Me.DropDownListPARTNER_ID.SelectedItem.Value)
    End Sub
#End Region
#Region "IsColumn"
    Private Sub IsColumn()
        If Me.CheckBoxPARTNER_ID.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxBRAND_NAME.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxKEY_WORD.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxGROUP_TEXT.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxSOURCE_TEXT.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If
        If Me.CheckBoxUSER_ID.Checked = True Then
            Me.DataGrid.Columns(9).Visible = True
        Else
            Me.DataGrid.Columns(9).Visible = False
        End If
        If Me.CheckBoxSEX_TEXT.Checked = True Then
            Me.DataGrid.Columns(10).Visible = True
        Else
            Me.DataGrid.Columns(10).Visible = False
        End If
        If Me.CheckBoxPROVINCE_TEXT.Checked = True Then
            Me.DataGrid.Columns(11).Visible = True
        Else
            Me.DataGrid.Columns(11).Visible = False
        End If
        If Me.CheckBoxFEES_TEXT.Checked = True Then
            Me.DataGrid.Columns(12).Visible = True
        Else
            Me.DataGrid.Columns(12).Visible = False
        End If
        If Me.CheckBoxINCOME_TEXT.Checked = True Then
            Me.DataGrid.Columns(13).Visible = True
        Else
            Me.DataGrid.Columns(13).Visible = False
        End If
        If Me.CheckBoxEXACTLY_RATE.Checked = True Then
            Me.DataGrid.Columns(14).Visible = True
        Else
            Me.DataGrid.Columns(14).Visible = False
        End If
    End Sub
#End Region
End Class