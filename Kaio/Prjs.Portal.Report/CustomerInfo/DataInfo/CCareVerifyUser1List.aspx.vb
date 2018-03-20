Public Class CCareVerifyUser1List
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "DANH SÁCH CHỜ GỌI XÁC MINH THÔNG TIN"
            IsPrivilegeOnMenu()
            Me.RadFromDate.SelectedDate = Now
            Me.RadToDate.SelectedDate = Now
            pager1.Visible = False
        End If
     
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate, "")

        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT ID,USER_ID,CUSTOMER_CODE,CUSTOMER_NAME,PROVINCE_TEXT,EXACTLY_RATE,MOBILE_OPERATOR,UPDATE_BY_ID,UPDATE_BY_TEXT,UPDATE_TIME,REMARK, RowNum as RowNumber " & _
                                     " FROM CCARE_CUSTOMER_VERIFY_1 Where STATUS_ID=2 "
        If Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text <> "--all--" Then
            sql = sql & " And MOBILE_OPERATOR='" & Me.DropDownListMOBILE_OPERATOR.SelectedItem.Text.Trim & "'"
        End If
        sql = sql & " AND to_char(update_time,'YYYYMMDD')>='" & FromDate & "'"
        sql = sql & " AND to_char(update_time,'YYYYMMDD')<='" & ToDate & "'"

        If Me.txtUser_Id.Text.Trim <> "" Then
            sql = sql & " And USER_ID='" & Me.txtUser_Id.Text.Trim & "'"
        End If
        If Me.txtGroup_Text.Text.Trim <> "" Then
            sql = sql & " And upper(GROUP_TEXT) like '%" & Me.txtGroup_Text.Text.Trim.ToUpper & "%'"
        End If
        If Me.txtKey_Word.Text.Trim <> "" Then
            sql = sql & " And upper(KEY_WORD) like '%" & Me.txtKey_Word.Text.Trim.ToUpper & "%'"
        End If
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        Dim dt As DataTable = Nothing
        Dim dtPageCount As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
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
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.Visible = True
          
        Else
            Me.DataGrid.Visible = False
            pager1.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
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
    
#End Region

End Class