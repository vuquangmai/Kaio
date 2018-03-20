Public Class KpiLotDictIndexTechnicalQualityOperatorList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ XỔ SỐ - TỪ ĐIỂN THỜI GIAN GỬI MT SANG TELCOS"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = False 'IsUpdate
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End If


    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_DictIndex_Technical_Quality_Mobile_Operator "
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        Dim dt As DataTable = Nothing
        Dim dtPageCount As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
        Else
            dt = CType(ViewState("DATA_GRID"), DataTable)
            dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
        End If
        ViewState("DATA_GRID") = dt
        ViewState("DATA_COUNT") = dtPageCount
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Columns(8).Visible = IsUpdate
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True
            Me.pager1.Visible = True
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
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
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
    '#Region "Submit Click"
    '    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
    '        Response.Redirect(Constants.Url._GamePortal.VMGameDictIndexServiceEdit)
    '    End Sub
    '#End Region
End Class