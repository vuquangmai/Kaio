Public Class AndroidAppsDictIndexList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ APP ID"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
        End If
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
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT  Id,App_Id," & _
             " Status_Id= case  Status_Id when 0 then N'ONLINE' else N'REMOVE' end," & _
             " Sync_Date,Crawler_Date,Crawler_Num," & _
             " Row_Number() Over ( Order by App_Id ) as RowNumber " & _
             " FROM ADK_Apps  WHERE Id>0"
        If Me.DropDownListStatus_Id.SelectedItem.Value > -1 Then
            sql = sql & " AND Status_Id=" & Me.DropDownListStatus_Id.SelectedItem.Value
        End If
        If Me.txtApp_Id.Text.Trim <> "" Then
            sql = sql & " AND App_Id like N' %" & Me.txtApp_Id.Text.Trim & "%'"
        End If
        If Me.txtCrawler_Num.Text.Trim <> "" Then
            sql = sql & " AND Crawler_Num='" & Me.txtCrawler_Num.Text.Trim & "'"
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
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Columns(6).Visible = IsUpdate
            Me.DataGrid.Columns(7).Visible = IsDelete
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True
            Me.pager1.Visible = True
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Me.lblTotal.Text = "Tổng số: " & Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
            Me.lblTotal.Text = "Tổng số: " & Constants.AlertInfo.ZeroRecord
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
        Dim sql As String = "Delete  From  ADK_Apps  Where  Id =" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
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
#Region "Submit Click"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect(Constants.Url._AndroidApps.AndroidAppsDictIndexList)
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region


End Class