Public Class CcareReportUserComplete
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DỮ LIỆU HOÀN THÀNH"
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
        BindUser()
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
        'Me.DropDownListFEES_ID.Items.Clear()
        'Me.DropDownListFEES_ID.Items.Add(New ListItem("--all--", 0))
        'Me.DropDownListFEES_ID.SelectedValue = 0
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        Me.DropDownListFEES_ID.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
        '    Next
        'End If
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
    Private Sub BindUser()
        Dim sql As String = "SELECT A.Id, A.User_Name,A.Full_Name, A.Email,A.Telephone,A.Create_Time, B.Group_Text  " & _
            " FROM System_Users A " & _
            " INNER JOIN System_Group_User B ON A.Group_Id=B.ID " & _
            " INNER JOIN System_Group_Channel C ON A.Group_Id=C.Group_Id " & _
            " WHERE A.Is_Delete=0 and A.Status=1 and B.Is_Delete=0 and B.Status=1 " & _
            " AND C.Channel_Id =" & Constants.Channel.Id.CustomerInfo & " order by A.User_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCREATE_BY_TEXT.Items.Clear()
        Me.DropDownListUPDATE_BY_TEXT.Items.Clear()
        Me.DropDownListCREATE_BY_TEXT.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListUPDATE_BY_TEXT.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListCREATE_BY_TEXT.SelectedValue = 0
        Me.DropDownListUPDATE_BY_TEXT.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCREATE_BY_TEXT.Items.Add(New ListItem(dt.Rows(i).Item("User_Name"), dt.Rows(i).Item("Id")))
                Me.DropDownListUPDATE_BY_TEXT.Items.Add(New ListItem(dt.Rows(i).Item("User_Name"), dt.Rows(i).Item("Id")))
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

        Dim wSQL As String = " WHERE ID>0"
        Dim gSQL As String = ""
        Dim oSQL As String = " ORDER BY  dbms_random.value "
      
        slSQL = "SELECT to_char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'yyyy') YEAR , " & _
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
        " (case when '" & Me.CheckBoxDISTRICT_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(DISTRICT_TEXT) end ) as DISTRICT_TEXT ," & _
        " (case when '" & Me.CheckBoxFEES_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(FEES_TEXT) end ) as FEES_TEXT ," & _
        " (case when '" & Me.CheckBoxINCOME_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(INCOME_TEXT) end ) as INCOME_TEXT ," & _
        " (case when '" & Me.CheckBoxEXACTLY_RATE.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(EXACTLY_RATE) end ) as EXACTLY_RATE ," & _
         " (case when '" & Me.CheckBoxCREATE_BY_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(CREATE_BY_TEXT) end ) as CREATE_BY_TEXT ," & _
        " (case when '" & Me.CheckBoxUPDATE_BY_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(UPDATE_BY_TEXT) end ) as UPDATE_BY_TEXT ," & _
        " count(*) Total " & _
        " FROM " & vTable

        gSQL = " GROUP BY " & _
        " to_char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'yyyy')," & _
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
        "  (case when '" & Me.CheckBoxDISTRICT_ID.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(DISTRICT_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxFEES_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(FEES_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxINCOME_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(INCOME_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxEXACTLY_RATE.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(EXACTLY_RATE) end )," & _
        "  (case when '" & Me.CheckBoxCREATE_BY_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(CREATE_BY_TEXT) end )," & _
        "  (case when '" & Me.CheckBoxUPDATE_BY_TEXT.Checked.ToString.ToUpper & "'='FALSE' then '--all--' else  to_char(UPDATE_BY_TEXT) end )"

        If Me.CheckBoxAllDate.Checked = False Then
            wSQL = wSQL & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')>='" & FromDate & "'"
            wSQL = wSQL & " And to_Char(" & Me.DropDownListTypeOfTime.SelectedItem.Value & ",'YYYYMMDD')<='" & ToDate & "'"
        End If
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
        
            If Me.CheckBoxDISTRICT_ID.Checked = True Then
                Dim CollectionDistrict As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListDISTRICT_ID.CheckedItems
                Dim sb As New StringBuilder()
                If CollectionDistrict.Count = 0 Then
                    Me.lblerror.Text = "Quận/Huyện không hợp lệ !"
                    Exit Sub
                Else
                    If CollectionDistrict.Count < Me.RadDropDownListDISTRICT_ID.Items.Count Then
                        For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionDistrict
                            If sb.ToString = "" Then
                                sb.Append("'" + item.Value + "'")
                            Else
                                sb.Append(",'" + item.Value + "'")
                            End If
                        Next
                        wSQL = wSQL & " And  DISTRICT_ID In (" & sb.ToString() & ")"
                    End If
                End If
            End If

        'If Me.CheckBoxFEES_TEXT.Checked = True And Me.DropDownListFEES_ID.SelectedItem.Value > 0 Then
        '    wSQL = wSQL & " and FIELD_ID=" & Me.DropDownListFEES_ID.SelectedItem.Value
        'End If
        If Me.CheckBoxFEES_TEXT.Checked = True Then
            Dim CollectionFees As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListFEES_ID.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionFees.Count = 0 Then
                Me.lblerror.Text = "Mức cước không hợp lệ !"
                Exit Sub
            Else
                If CollectionFees.Count < Me.RadDropDownListFEES_ID.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionFees
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    wSQL = wSQL & " And  FEES_ID In (" & sb.ToString() & ")"
                End If
            End If
        End If
     
        If Me.CheckBoxINCOME_TEXT.Checked = True And Me.DropDownListINCOME_ID.SelectedItem.Value > 0 Then
            wSQL = wSQL & " and INCOME_ID=" & Me.DropDownListINCOME_ID.SelectedItem.Value
        End If
        If Me.CheckBoxEXACTLY_RATE.Checked = True And Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Value <> "--all--" Then
            wSQL = wSQL & " and EXACTLY_RATE=" & Me.DropDownListEXACTLY_RATE_NUMBER.SelectedItem.Value
        End If
        If Me.CheckBoxCREATE_BY_TEXT.Checked = True And Me.DropDownListCREATE_BY_TEXT.SelectedItem.Value <> 0 Then
            wSQL = wSQL & " and CREATE_BY_ID=" & Me.DropDownListCREATE_BY_TEXT.SelectedItem.Value
        End If
        If Me.CheckBoxUPDATE_BY_TEXT.Checked = True And Me.DropDownListUPDATE_BY_TEXT.SelectedItem.Value <> 0 Then
            wSQL = wSQL & " and UPDATE_BY_ID=" & Me.DropDownListUPDATE_BY_TEXT.SelectedItem.Value
        End If
        If Me.txtFromYear.Text.Trim <> "" And Me.txtToYear.Text.Trim <> "" Then
            wSQL = wSQL & " And REGEXP_LIKE(SUBSTR(BIRTH_DAY,7,4), '^[[:digit:]]+$') "
            wSQL = wSQL & " And  length(BIRTH_DAY)=10  And to_number(to_char(sysdate,'YYYY')) - to_number(SUBSTR(BIRTH_DAY,7,4))>='" & Me.txtFromYear.Text.Trim & "'"
            wSQL = wSQL & " And to_number(to_char(sysdate,'YYYY')) - to_number(SUBSTR(BIRTH_DAY,7,4))<='" & Me.txtToYear.Text.Trim & "'"
        End If
        If Me.txtTOP.Text.Trim <> "" Then
            wSQL = wSQL & " And ROWNUM  >" & 0 & " and   ROWNUM <= " & Me.txtTOP.Text.Trim
        End If
        sql = slSQL & wSQL & gSQL & oSQL
     
        sqlTotal = "SELECT count(*) TotalRecord, sum(Total) Total FROM (" & sql & ")"
        If strAction = Constants.Action.Search Then
            sql = "SELECT T.*,ROWNUM as RowNumber FROM (" & sql & ") T "
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
            If Me.CheckBoxExpUserOnly.Checked = True Then
                ExportData.CSVExporter._B2C.UserComplete(sql, Me.DropDownListFileType.SelectedItem.Value)
            Else
                ExportData.ExportExcel._B2C.UserComplete(sql, CurrentUser.UserName)

            End If
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
    Protected Sub DropDownListPROVINCE_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPROVINCE_ID.SelectedIndexChanged
        BindDistrict(Me.DropDownListPROVINCE_ID.SelectedItem.Value)
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
        If Me.CheckBoxDISTRICT_ID.Checked = True Then
            Me.DataGrid.Columns(12).Visible = True
        Else
            Me.DataGrid.Columns(12).Visible = False
        End If
        If Me.CheckBoxFEES_TEXT.Checked = True Then
            Me.DataGrid.Columns(13).Visible = True
        Else
            Me.DataGrid.Columns(13).Visible = False
        End If
        If Me.CheckBoxINCOME_TEXT.Checked = True Then
            Me.DataGrid.Columns(14).Visible = True
        Else
            Me.DataGrid.Columns(14).Visible = False
        End If
        If Me.CheckBoxEXACTLY_RATE.Checked = True Then
            Me.DataGrid.Columns(15).Visible = True
        Else
            Me.DataGrid.Columns(15).Visible = False
        End If
        If Me.CheckBoxCREATE_BY_TEXT.Checked = True Then
            Me.DataGrid.Columns(16).Visible = True
        Else
            Me.DataGrid.Columns(16).Visible = False
        End If
        If Me.CheckBoxUPDATE_BY_TEXT.Checked = True Then
            Me.DataGrid.Columns(17).Visible = True
        Else
            Me.DataGrid.Columns(17).Visible = False
        End If
    End Sub
#End Region
End Class