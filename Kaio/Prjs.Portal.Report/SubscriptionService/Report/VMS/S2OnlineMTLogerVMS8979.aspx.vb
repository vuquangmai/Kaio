  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineMTLogerVMS8979
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO SỐ LIỆU MT ĐẦU SỐ 8979 - VMS"
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindPartner()
        BindDate()
        BindServiceId()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate)
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM S2_TTND_Partners where PartnerID>0 Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerID")))
            Next
        End If
    End Sub
    Private Sub BindServiceId()
        Dim sql As String = "SELECT * FROM S2_TTKD_Services  where Service_Type = 'VIOLET' Order by service_name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.DropDownListService_Id.Items.Clear()
        Me.DropDownListService_Id.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListService_Id.Items.Add(New ListItem(dt.Rows(i).Item("service_name"), dt.Rows(i).Item("service_Id")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                  Me.DropDownListFromDate, _
                                  Me.DropDownListToDate)
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
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "S2TTKD_VioletMT_Log" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)

        sql = "SELECT CONVERT(varchar,month(A.RequestTime))  as vMonth , " & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,A.RequestTime) end ) as vDate," & _
                " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  DATENAME(hour, A.RequestTime) end ) as vHour, " & _
                " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else A.MSISDN end ) as vUser_Id, " & _
                " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else CONVERT(nvarchar,B.service_name)  end ) as vService_Name,  " & _
                " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,C.PartnerName) end ) as vPartnerName," & _
                " COUNT(*) Total,  row_number() over( Order by CONVERT(varchar,month(A.RequestTime)) ) as RowNumber " & _
                " FROM " & vTable & " A inner join S2_TTKD_Services B on A.Service_ID COLLATE DATABASE_DEFAULT=B.Service_ID COLLATE DATABASE_DEFAULT " & _
                " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID "

        sqlTotal = "SELECT CONVERT(varchar,month(A.RequestTime)) as vMonth , " & _
                 " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,A.RequestTime) end ) as vDate," & _
                 " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  DATENAME(hour, A.RequestTime) end ) as vHour, " & _
                 " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else A.MSISDN end ) as vUser_Id, " & _
                 " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else CONVERT(nvarchar,B.service_name)  end ) as vService_Name,  " & _
                 " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,C.PartnerName) end ) as vPartnerName," & _
                 " COUNT(*) Total  " & _
                 " FROM " & vTable & " A inner join S2_TTKD_Services B on A.Service_ID COLLATE DATABASE_DEFAULT=B.Service_ID COLLATE DATABASE_DEFAULT " & _
                 " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID "

        sqlConditional = " WHERE  CONVERT(varchar,month(A.RequestTime))='" & Me.DropDownListMonth.SelectedItem.Value & "'"
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = " AND CONVERT(varchar,A.RequestTime,112) >='" & vFromDate & "' AND CONVERT(varchar,A.RequestTime,112)<='" & vToDate & "'"
        End If
        If Me.CheckBoxService_Id.Checked And Me.DropDownListService_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and convert(nvarchar,B.Service_ID) =N'" & Me.DropDownListService_Id.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxUser_Id.Checked = True And Me.txtUser_Id.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and convert(nvarchar,A.MSISDN) =N'" & Me.txtUser_Id.Text.Trim & "'"
        End If
        If Me.CheckBoxPartnerId.Checked And Me.DropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and convert(nvarchar,C.PartnerID)=N'" & Me.DropDownListPartner_Id.SelectedItem.Value & "'"
        End If

        sqlGroup = " GROUP BY CONVERT(varchar,month(A.RequestTime))"
        sqlOrder = " Order by vMonth"

        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", DATENAME(day,A.RequestTime)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ",  DATENAME(hour, A.RequestTime) "
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxService_Id.Checked Then
            sqlGroup = sqlGroup & ", convert(nvarchar,B.service_name)"
        End If
        If Me.CheckBoxUser_Id.Checked Then
            sqlGroup = sqlGroup & ",  A.MSISDN "
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", C.PartnerName"
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT  COUNT(*) TotalRecord, sum(Total) TotalMT From  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 where  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sqlTotal)
            Dim TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            pager1.ItemCount = TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & TotalCount
                Next
                ' IsColumnDataGrid()
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            'ExportData.ExportExcel._S2.S2TrafficTotal(sql, CurrentUser.UserName, _
            '                                                 Me.CheckBoxDate.Checked, _
            '                                                 Me.CheckBoxDayOfWeek.Checked, _
            '                                                 Me.CheckBoxMobile_Operator.Checked, _
            '                                                 Me.CheckBoxAccess_Number.Checked, _
            '                                                 Me.CheckBoxPrice_Unit.Checked, _
            '                                                 Me.CheckBoxService_Id.Checked, _
            '                                                 Me.CheckBoxPartnerId.Checked, _
            '                                                 Me.CheckBoxContractCode.Checked)

        End If
    End Sub
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
            Me.DataGrid.Columns(6).Visible = True
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
            Me.DataGrid.Columns(6).Visible = False
            Me.DataGrid.Columns(7).Visible = False
        End If
       

    End Sub

#End Region

End Class