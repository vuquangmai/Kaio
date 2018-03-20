Imports System.Data.OleDb
Imports System.Data.OracleClient

Public Class CCareImportUserComplete1
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDictIndex()
            CreateFolder()
            Me.lbltitle.Text = "IMPORT FILE DỮ LIỆU KHÁCH HÀNG"
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
        End If
        Me.txtUserFile.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        ' Me.CheckBoxDelData.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGrid.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
#End Region
#Region "Dict Index"
    Private Sub BindDictIndex()
        BindPartner()
        BindSource()
        BindField()
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PARTNER Where STATUS_ID=1 Order by upper(PARTNER_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPARTNER_ID.Items.Clear()
        Me.DropDownListPARTNER_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPARTNER_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPARTNER_ID.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindBrand(ByVal PARTNER_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND  Where STATUS_ID=1 And PARTNER_ID=" & PARTNER_ID & " Order by (BRAND_NAME)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListBRAND_NAME.Items.Clear()
        Me.DropDownListBRAND_NAME.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListBRAND_NAME.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListBRAND_NAME.Items.Add(New ListItem(dt.Rows(i).Item("BRAND_NAME"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    
    Private Sub BindSource()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_SOURCE  Where STATUS_ID=1 Order by upper(SOURCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListSOURCE_ID.Items.Clear()
        Me.DropDownListSOURCE_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListSOURCE_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListSOURCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
     
    Private Sub BindField()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FIELD  Where STATUS_ID=1 Order by upper(FIELD_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.CheckBoxListFIELD_ID.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.CheckBoxListFIELD_ID.Items.Add(New ListItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
   
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtUserFile.Text.Trim = "" Then
            Me.lblerror.Text = "File dữ liệu không hợp lệ !"
            Exit Sub
        End If
        Dim vFile As String = txtUserFile.Text.Trim
        If vFile.ToLower.EndsWith(".xls") = True Or vFile.EndsWith(".xlsx") = True Or vFile.EndsWith(".csv") = True Or vFile.EndsWith(".txt") = True Then
            ProcFile()
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
        End If
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Proc File"
    Private Sub ProcFile()

        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim FILE_PATH As String = Me.txtUserFile.Text.Trim
        Dim STATUS_ID As Integer = 0
        Dim STATUS_TEXT As String = ""
        Dim GROUP_TEXT As String = Me.txtGROUP_TEXT.Text.Trim
        Dim MT As String = Me.txtMT.Text.Trim
        Dim BRAND_ID As Integer = 0
        Dim BRAND_NAME As String = ""
        If Me.DropDownListBRAND_NAME.SelectedItem.Text <> "--Chọn--" Then
            BRAND_ID = Me.DropDownListBRAND_NAME.SelectedItem.Value
            BRAND_NAME = Me.DropDownListBRAND_NAME.SelectedItem.Text.Trim
        End If
        Dim PROVINCE_ID As Integer = 0
        Dim PROVINCE_TEXT As String = ""
      
        Dim DISTRICT_ID As Integer = 0
        Dim DISTRICT_TEXT As String = ""
        
        Dim PARTNER_ID As Integer = 0
        Dim PARTNER_TEXT As String = ""
        If Me.DropDownListPARTNER_ID.SelectedItem.Value > 0 Then
            PARTNER_ID = Me.DropDownListPARTNER_ID.SelectedItem.Value
            PARTNER_TEXT = Me.DropDownListPARTNER_ID.SelectedItem.Text.Trim
        End If
        Dim SEX_ID As Integer = 0
        Dim SEX_TEXT As String = ""
        
        Dim FIELD_ID As String = 0
        Dim FIELD_TEXT As String = ""
        For i As Integer = 0 To Me.CheckBoxListFIELD_ID.Items.Count - 1
            If CheckBoxListFIELD_ID.Items(i).Selected = True Then
                If FIELD_TEXT.Trim = "" Then
                    FIELD_TEXT = Me.CheckBoxListFIELD_ID.Items(i).Text
                    FIELD_ID = Me.CheckBoxListFIELD_ID.Items(i).Value & ";"
                Else
                    FIELD_TEXT = FIELD_TEXT & ";" & Me.CheckBoxListFIELD_ID.Items(i).Text
                    FIELD_ID = FIELD_ID & Me.CheckBoxListFIELD_ID.Items(i).Value & ";"
                End If
            End If
        Next
        Dim SOURCE_ID As Integer = 0
        Dim SOURCE_TEXT As String = ""
        If Me.DropDownListSOURCE_ID.SelectedItem.Value > 0 Then
            SOURCE_ID = Me.DropDownListSOURCE_ID.SelectedItem.Value
            SOURCE_TEXT = Me.DropDownListSOURCE_ID.SelectedItem.Text.Trim
        End If
        Dim KEY_WORD As String = Me.txtKEY_WORD.Text.Trim
        Dim REMARK As String = ""
        Dim CUSTOMER_CODE As String = ""
        Dim CUSTOMER_NAME As String = ""
        Dim BIRTH_DAY As String = ""
        Dim ADDRESS As String = ""
        Dim EMAIL_ADDRESS As String = ""
        Dim FEES_ID As Integer = 0
        Dim FEES_TEXT As String = ""
        
        Dim INCOME_ID As Integer = 0
        Dim INCOME_TEXT As String = ""
        
        Dim EXACTLY_RATE As String = ""
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
        Dim FILE_STATUS_ID As Integer = 1
        Dim FILE_STATUS_TEXT As String = "Chờ xử lý"
        Dim cmd As New OracleCommand
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "CCARE_CUSTOMER.INSERT_CCARE_FILE_IMPORT"
            .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

            .Parameters.Add(New OracleParameter("p_FILE_STATUS_ID", OracleType.Number, 18))
            .Parameters("p_FILE_STATUS_ID").Value = FILE_STATUS_ID

            .Parameters.Add(New OracleParameter("p_FILE_STATUS_TEXT", OracleType.NVarChar, 200))
            .Parameters("p_FILE_STATUS_TEXT").Value = FILE_STATUS_TEXT

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

            .Connection = conn
            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                Exit Sub
            End Try
        End With

        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.txtUserFile.Text = ""
        Me.txtGROUP_TEXT.Text = ""
        Me.txtKEY_WORD.Text = ""
        Me.txtMT.Text = ""

    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPARTNER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID.SelectedIndexChanged
        BindBrand(Me.DropDownListPARTNER_ID.SelectedItem.Value)
    End Sub
    'Protected Sub txtUSER_ID_TextChanged(sender As Object, e As EventArgs) Handles txtUSER_ID.TextChanged
    '    Dim vPhone As String = Me.txtUSER_ID.Text.Trim
    '    If vPhone.StartsWith(0) = True Then
    '        vPhone = "84" & vPhone.Substring(1)
    '    ElseIf vPhone.StartsWith(84) = False Then
    '        vPhone = "84" & vPhone
    '    End If
    '    Me.txtUSER_ID.Text = vPhone
    '    Dim MobileOperator As String = Util.FormatOperator(vPhone)
    '    Me.DropDownListMOBILE_OPERATOR.SelectedValue = MobileOperator
    'End Sub
    
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT ID, FILE_STATUS_TEXT,FILE_IMPORT, (case when length(mt)>50 then substr(mt,1,50)||'...' else mt end) MT,MT as MTFull ,KEY_IMPORT,GROUP_TEXT,KEY_WORD,CREATE_BY_TEXT,to_char(CREATE_TIME,'YYYY-MM-DD') CREATE_TIME,RowNum as RowNumber " & _
                                     "FROM CCARE_FILE_IMPORT "
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
                Me.DataGrid.Columns(8).Visible = IsDelete
                Me.DataGrid.PagerStyle.Visible = False
                Me.DataGrid.Visible = True
                pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                pager1.Visible = True
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGrid.Items
                    thisButton = gridrow.FindControl("deleter")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
            Else
                Me.DataGrid.Visible = False
                pager1.Visible = False
                Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._B2C.UserImportTotal(sql, CurrentUser.UserName)
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
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete  From  CCARE_FILE_IMPORT  Where  ID ='" & e.CommandArgument & "'"
        Try
            OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region

End Class