Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2Kpi8979Viettel
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO KPI DỊCH VỤ 8979 VIETTEL"
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        Me.RadDatePickerFromDate.SelectedDate = Now.AddDays(-(Today.Day) + 1)
        Me.RadDatePickerToDate.SelectedDate = Now
        BindPartnerd()
    End Sub
    Private Sub BindPartnerd()
        Dim sql As String = "SELECT * FROM VIETTEL_MPay_Sub_Partner WHERE Id>0"
        sql = sql & "   Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_87_1"), sql)
        Me.DropDownListPartner.Items.Clear()
        Me.DropDownListPartner.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.DropDownListPartner.Items.Add(New ListItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerId")))
                Next
            End If
        End If
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
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDatePickerFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(IIf(Me.RadDatePickerToDate.SelectedDate.Value = Now.Date, Now.AddDays(-1), RadDatePickerToDate.SelectedDate.Value), "")
        sql = "SELECT Year(NGAY) Year," & _
                " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(TEN_DOI_TAC,'Unknown') end ) as TEN_DOI_TAC," & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar,NGAY,103) end ) as NGAY," & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar,NGAY,112) end ) as NGAY_1," & _
                " (case when '" & Me.CheckBoxCode.Checked & "'='False' then '--all--' else isnull(MA,'Unknown') end ) as MA," & _
                " (case when '" & Me.CheckBoxPackage.Checked & "'='False' then '--all--' else isnull(TENGOI,'Unknown') end ) as TENGOI," & _
                " cast(SUM(isnull(THUE_BAO_LUY_KE,0))  as decimal(18,0)) THUE_BAO_LUY_KE, " & _
                " cast(SUM(isnull(THUE_BAO_HUY_LUY_KE,0))  as decimal(18,0))THUE_BAO_HUY_LUY_KE, " & _
                " cast(SUM(isnull(CDR,0))  as decimal(18,0)) CDR, " & _
                " cast(SUM(isnull(DANG_KY_MOI_SMS,0))  as decimal(18,0))DANG_KY_MOI_SMS, " & _
                " cast(SUM(isnull(DANG_KY_MOI_WAP,0))  as decimal(18,0))DANG_KY_MOI_WAP, " & _
                " cast(SUM(isnull(TONG_DANG_KY_MOI,0))  as decimal(18,0))TONG_DANG_KY_MOI, " & _
                " cast(SUM(isnull(HUY_SMS,0))  as decimal(18,0))HUY_SMS, " & _
                " cast(SUM(isnull(HUY_WAP,0))  as decimal(18,0))HUY_WAP, " & _
                " cast(SUM(isnull(TONG_HUY,0))  as decimal(18,0))TONG_HUY, " & _
                " cast(SUM(isnull(GIA_HAN_THANH_CONG,0))  as decimal(18,0))GIA_HAN_THANH_CONG, " & _
                " cast(SUM(isnull(TONG_GIA_HAN,0))  as decimal(18,0))TONG_GIA_HAN, " & _
                " cast(SUM(isnull(TONG_TIEN_TU_DANG_KY,0)) as decimal(18,0)) TONG_TIEN_TU_DANG_KY, " & _
                " cast(SUM(isnull(TONG_TIEN_TU_GIA_HAN,0))  as decimal(18,0))TONG_TIEN_TU_GIA_HAN, " & _
                " cast(SUM(isnull(TONG_DOANH_THU,0))  as decimal(18,0)) TONG_DOANH_THU, " & _
                " round(SUM(cast(TONG_DOANH_THU as decimal(18,0)))*42/100,0)  TONG_DOANH_THU_VMG, " & _
                " row_number() over( Order by Year(NGAY)  ) as RowNumber " & _
                "  FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1"
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And convert(varchar,NGAY,112) >='" & FromDate & "' And convert(varchar,NGAY,112)<='" & ToDate & "'"
        End If
        If CheckBoxPartnerId.Checked = True And Me.DropDownListPartner.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And ID_DOI_TAC='" & Me.DropDownListPartner.SelectedItem.Value & "'"
        End If
        If CheckBoxPackage.Checked = True And Me.DropDownListPackage.SelectedItem.Value <> "--all--" Then
            sqlConditional = sqlConditional & " And MAGOI='" & Me.DropDownListPackage.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxCode.Checked = True And Me.txtCode.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " And MA='" & Me.txtCode.Text.Trim & "'"
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
        If Me.CheckBoxPackage.Checked = True Then
            sqlGroup = sqlGroup & ", TENGOI"
            sqlOrder = sqlOrder & ",TENGOI"
        End If
        If Me.CheckBoxCode.Checked = True Then
            sqlGroup = sqlGroup & ", MA"
        End If
        sql = sql & sqlConditional & sqlGroup
        'Lấy tổng số thuê bao active
        Dim sql_1 As String = "SELECT SUM(THUE_BAO_LUY_KE) THUE_BAO_LUY_KE FROM " & vTable & sqlConditional & " AND convert(varchar,NGAY,112)='" & ToDate & "'"
        Dim dtUserData As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_87_1"), sql_1)
        Dim ThueBaoLuyKe As Integer = dtUserData.Rows(0).Item("THUE_BAO_LUY_KE")
        If strAction = Constants.Action.Search Then
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_87_1"), "SELECT count(*) Total,  cast(SUM(TONG_DOANH_THU) as decimal(18,0)) TONG_DOANH_THU,  cast(SUM(TONG_DOANH_THU_VMG)  as decimal(18,0))TONG_DOANH_THU_VMG  FROM (" & sql & ") T")
            If Me.CheckBoxDate.Checked = False And Me.CheckBoxCode.Checked = False And Me.CheckBoxPackage.Checked = False And Me.CheckBoxPartnerId.Checked = False Then
                sql = "SELECT Year,TEN_DOI_TAC, NGAY,NGAY_1,MA,TENGOI," & ThueBaoLuyKe & " as THUE_BAO_LUY_KE,THUE_BAO_HUY_LUY_KE,CDR,DANG_KY_MOI_SMS,DANG_KY_MOI_WAP, TONG_DANG_KY_MOI, " & _
         "HUY_SMS,HUY_WAP,TONG_HUY,GIA_HAN_THANH_CONG,TONG_GIA_HAN,TONG_TIEN_TU_DANG_KY,TONG_TIEN_TU_GIA_HAN,TONG_DOANH_THU,TONG_DOANH_THU_VMG " & _
         " FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            Else
                sql = "SELECT Year,TEN_DOI_TAC, NGAY,NGAY_1,MA,TENGOI,THUE_BAO_LUY_KE,THUE_BAO_HUY_LUY_KE,CDR,DANG_KY_MOI_SMS,DANG_KY_MOI_WAP, TONG_DANG_KY_MOI, " & _
          "HUY_SMS,HUY_WAP,TONG_HUY,GIA_HAN_THANH_CONG,TONG_GIA_HAN,TONG_TIEN_TU_DANG_KY,TONG_TIEN_TU_GIA_HAN,TONG_DOANH_THU,TONG_DOANH_THU_VMG " & _
          " FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            End If
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_87_1"), sql)
            Dim TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))

            pager1.ItemCount = TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
                Me.lblTotalMoney.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("TONG_DOANH_THU"), 0)
                Me.lblTotalMoneyVMG.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("TONG_DOANH_THU_VMG"), 0)
                Me.lblTotalUser.Text = Util.Numeric.Number2Decimal(dtUserData.Rows(0).Item("THUE_BAO_LUY_KE"), 0)
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            sql = sql & sqlOrder
            'ExportData.ExportExcel._S2.S2KpiViGame9029(sql)
        End If
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
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region

End Class