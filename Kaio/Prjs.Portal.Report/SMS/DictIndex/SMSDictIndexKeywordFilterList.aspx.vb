Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMSDictIndexKeywordFilterList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ MÃ DỊCH VỤ SMS - HỆ THỐNG MÃ VIETTEL FILTER"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
            Me.pager1.Visible = False
            BindDictIndex()
        End If
        If ViewState("DATA_GRID") Is Nothing Then
            'Not Load database
        Else
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindShortCode(Me.DropDownListRangeShortCode.SelectedItem.Value)
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
    End Sub
    Private Sub BindShortCode(ByVal Range_Of_Short_Code As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where  Short_Code  not like '8%76' And  Short_Code not like '6%35' "
        If Range_Of_Short_Code <> "--all--" Then
            sql = sql & "  And  Range_Of_Short_Code='" & Range_Of_Short_Code & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCode.Items.Clear()
        Me.DropDownListShortCode.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub

#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "service_viettel_filter"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        sql = "SELECT Id,shortcode,keyword,create_date,last_updated,description,(CASE status WHEN 1 THEN 'Duyệt'   WHEN 2 THEN 'Hủy' WHEN 0 THEN 'Chờ duyệt' ELSE  'Unknown' END ) as status FROM " & vTable & " WHERE Id >0 "
        If Me.CheckBoxAllDate.Checked = False Then
            sql = sql & " AND date_format(create_date,'%Y%m%d%H')>=" & FromDate
            sql = sql & " AND date_format(create_date,'%Y%m%d%H')<=" & ToDate
        End If
        If Me.DropDownListRangeShortCode.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND shortcode like '" & Me.DropDownListRangeShortCode.SelectedItem.Value.Replace("x", "%") & "'"
        End If
        If Me.DropDownListShortCode.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND shortcode='" & Me.DropDownListShortCode.SelectedItem.Value & "'"
        End If

        If Me.txtKeyWord.Text.Trim <> "" Then
            sql = sql & " AND keyword='" & Me.txtKeyWord.Text.Trim & "'"
        End If
        If Me.DropDownListStatus.SelectedItem.Value > -1 Then
            sql = sql & " AND status =  '" & Me.DropDownListStatus.SelectedItem.Value & "'"
        End If

        sqlTotal = "SELECT count(*) Total   FROM (" & sql & ") A"
        If strAction = Constants.Action.Search Then
            sql = sql & " LIMIT " & LowerBand & ", " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                dt = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
                dtPageCount = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
            End If
            ViewState("DATA_GRID") = dt
            ViewState("DATA_COUNT") = dtPageCount
            Dim _TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = _TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _TotalCount
                Next
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblTotal.Text = _TotalCount
                Me.lblerror.Text = ""
                Me.DataGrid.Columns(7).Visible = IsUpdate
                Me.DataGrid.Columns(8).Visible = IsDelete
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete From  service_viettel_filter  Where Id=" & (CType(e.CommandArgument, Integer))
        Try
            MySQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordFilterEdit)
    End Sub
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
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
    Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
        BindShortCode(DropDownListRangeShortCode.SelectedItem.Text)
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