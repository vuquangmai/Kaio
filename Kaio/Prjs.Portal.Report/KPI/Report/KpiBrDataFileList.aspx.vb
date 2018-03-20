Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class KpiBrDataFileList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO KPI DỊCH VỤ SMS BRANDNAME"
            BindYear()
            BindMonth()
            Me.pager1.Visible = False
            Me.DataGrid.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindYear()
        Me.DropDownListYear.Items.Clear()
        For i As Integer = 2015 To 2020
            Me.DropDownListYear.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListYear.SelectedValue = Now.AddMonths(-1).Year
    End Sub
    Private Sub BindMonth()
        Me.DropDownListMonth.Items.Clear()
        For i As Integer = 1 To 12
            Me.DropDownListMonth.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListMonth.SelectedValue = Now.Month
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
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT Month,TypeOf_Text,File_Name,File_Path,File_Url,Create_Time,Row_Number() Over ( Order by Month desc ) as RowNumber  FROM Kpi_Data_File" & _
             " WHERE TypeOf_Id= 2 AND Month=" & Me.DropDownListYear.SelectedItem.Value & IIf(Me.DropDownListMonth.SelectedItem.Value < 10, "0" & Me.DropDownListMonth.SelectedItem.Value, Me.DropDownListMonth.SelectedItem.Value)
        If Me.DropDownListService_Id.SelectedItem.Value > 0 Then
            sql = sql & " AND TypeOf_Id=" & Me.DropDownListService_Id.SelectedItem.Value
        End If
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
        Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Visible = True
            Me.pager1.Visible = True
            pager1.ItemCount = _totalCount
            Me.lblerror.Text = ""
            For j As Integer = 0 To DataGrid.Items.Count - 1
                Dim lbID As Label
                lbID = DataGrid.Items(j).FindControl("lblOrder")
                lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _totalCount
            Next
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub
#End Region
End Class