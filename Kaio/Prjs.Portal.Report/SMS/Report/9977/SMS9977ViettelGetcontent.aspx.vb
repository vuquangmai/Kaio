Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMS9977ViettelGetcontent
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "LOG GIAO DỊCH MUA LẺ"
            BindDate()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
    End Sub
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "getcontent"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand As Integer = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        Dim sql As String = "SELECT * FROM getcontent  WHERE date_format(Created_at,'%Y%m%d')>='" & FromDate & "'"
        sql = sql & " AND date_format(Created_at,'%Y%m%d')<='" & ToDate & "'"
        If Me.txtMsisdn.Text.Trim <> "" Then
            sql = sql & " AND msisdn ='" & Me.txtMsisdn.Text.Trim & "'"
        End If
        If Me.txtServicId.Text.Trim <> "" Then
            sql = sql & " AND serviceid = '" & Me.txtServicId.Text.Trim & "'"
        End If
        If strAction = Constants.Action.Search Then
            Dim sqlTotal As String = "SELECT count(*) Total FROM (" & sql & ") T1"
            sql = sql & " LIMIT " & LowerBand & ", " & UpperBand
            Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_9977_Viettel"), sql)
            Dim dtPageCount As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_9977_Viettel"), sqlTotal)
            Dim _TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Me.lblTotal.Text = _TotalCount
            pager1.ItemCount = _TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                pager1.ItemCount = 0
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If

    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
End Class