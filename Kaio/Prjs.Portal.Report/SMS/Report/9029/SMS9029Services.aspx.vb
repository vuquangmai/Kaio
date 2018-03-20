Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
    Public Class SMS9029Services
        Inherits GlobalPage
        Public Utils As New Util.Encrypt
        Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
            Me.lblTitle.Text = "DANH SÁCH DỊCH VỤ 9029"
                IsPrivilegeOnMenu()
                Me.pager1.Visible = False
            End If
        End Sub
#End Region
 
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VMG_MPay_Services"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand As Integer = (intCurentPage * intPageSize) + 1
        Dim sql As String = "SELECT ServiceId,ServiceType,ServiceCode,ServiceName,ServiceDesc,ContentCode,ContentId,TotalAmount,Message,Endpoint,PartnerId,Status, row_number() over( Order by   ServiceName) as RowNumber  FROM " & vTable
        If strAction = Constants.Action.Search Then
            Dim sqlTotal As String = "SELECT count(*) Total FROM (" & sql & ") T1"
            sql = "SELECT * FROM (" & sql & ") T1 where  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            Dim _TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Me.lblTotal.Text = _totalCount
            pager1.ItemCount = _totalCount
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
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End Sub
        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Export)
        End Sub
#End Region
#Region "Pager"
        Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
            Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
            pager1.CurrentIndex = currnetPageIndx
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End Sub
#End Region
    End Class