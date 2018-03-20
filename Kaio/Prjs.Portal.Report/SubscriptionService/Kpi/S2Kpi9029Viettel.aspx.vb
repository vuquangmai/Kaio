Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2Kpi9029Viettel
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO KPI DỊCH VỤ VIGAME 9029"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        Me.RadDatePickerFromDate.SelectedDate = Now
        Me.RadDatePickerToDate.SelectedDate = Now
        BindPartnerd()
    End Sub
    Private Sub BindPartnerd()
        Dim sql As String = "SELECT * FROM VMG_MPay_Partners WHERE PartnerType=2  Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_1"), sql)
        Me.RadDropDownListPartner.Items.Clear()
        If dt.Rows.Count > 0 Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.RadDropDownListPartner.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerId")))
                Next
            End If

        End If
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPartner.Items
            item.Checked = True
        Next
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
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
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
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "VIETTEL_MPay_Sub_Report"
        Dim vFromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDatePickerFromDate.SelectedDate.Value, "")
        Dim vToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDatePickerToDate.SelectedDate.Value, "")
        sql = "SELECT Year(NGAY) Year," & _
                " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(TEN_DOI_TAC,'Unknown') end ) as TEN_DOI_TAC," & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar,NGAY,103) end ) as NGAY," & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar,NGAY,112) end ) as NGAY_1," & _
                " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else isnull(MA,'Unknown') end ) as MA," & _
                " SUM(isnull(THUE_BAO_LUY_KE,0)) THUE_BAO_LUY_KE, " & _
                " SUM(isnull(DANG_KY_MOI_SMS,0)) DANG_KY_MOI_SMS, " & _
                " SUM(isnull(DANG_KY_MOI_WAP,0)) DANG_KY_MOI_WAP, " & _
                " SUM(isnull(TONG_DANG_KY_MOI,0)) TONG_DANG_KY_MOI, " & _
                " SUM(isnull(HUY_SMS,0)) HUY_SMS, " & _
                " SUM(isnull(HUY_WAP,0)) HUY_WAP, " & _
                " SUM(isnull(TONG_HUY,0)) TONG_HUY, " & _
                " SUM(isnull(GIA_HAN_THANH_CONG,0)) GIA_HAN_THANH_CONG, " & _
                " SUM(isnull(TONG_GIA_HAN,0)) TONG_GIA_HAN, " & _
                " SUM(isnull(TONG_TIEN_TU_DANG_KY,0)) TONG_TIEN_TU_DANG_KY, " & _
                " SUM(isnull(TONG_TIEN_TU_GIA_HAN,0)) TONG_TIEN_TU_GIA_HAN, " & _
                " SUM(isnull(TONG_DOANH_THU,0)) TONG_DOANH_THU, " & _
                " row_number() over( Order by Year(NGAY)  ) as RowNumber " & _
                "  FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1"
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And convert(varchar,NGAY,112) >='" & vFromDate & "' And convert(varchar,NGAY,112)<='" & vToDate & "'"
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Dim CollectionServiceId As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPartner.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionServiceId.Count = 0 Then
                Me.lblerror.Text = "Đối tác không hợp lệ !"
                Exit Sub
            Else
                If CollectionServiceId.Count < Me.RadDropDownListPartner.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionServiceId
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  ID_DOI_TAC In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxKeyword.Checked = True And Me.txtKeyword.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " And MA='" & Me.txtKeyword.Text.Trim & "'"
        End If


        sqlGroup = " GROUP BY Year(NGAY) "
        sqlOrder = " ORDER BY Year "
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", convert(varchar,NGAY,103) ,convert(varchar,NGAY,112) "
            sqlOrder = sqlOrder & ",NGAY_1"
        End If


        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", TEN_DOI_TAC"
            sqlOrder = sqlOrder & ",TEN_DOI_TAC"
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            sqlGroup = sqlGroup & ", MA"
        End If
        sql = sql & sqlConditional & sqlGroup

        If strAction = Constants.Action.Search Then
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_1"), "SELECT count(*) Total FROM (" & sql & ") T")
            sql = "SELECT * FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_1"), sql)

            Dim TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & TotalCount
                Next
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            sql = sql & sqlOrder
            ExportData.ExportExcel._S2.S2KpiViGame9029(sql)
        End If
    End Sub
#End Region

End Class