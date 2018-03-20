  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineRevVNM94x
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU ĐẦU SỐ 949 - V//"
            BindDictIndex()
            InitData()
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
                                      Me.DropDownListFROMDate, _
                                      Me.DropDownListToDate)
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM S2_TTND_Partners WHERE PartnerID>0 Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerID")))
            Next
        End If
    End Sub
    Private Sub BindServiceId()
        Dim sql As String = "SELECT * FROM S2_TTND_Subscription_Services WHERE Service_Type='1006' Order by Service_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Service_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        BindDate()
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblTotalCDR.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListShortCode.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPriceUnit.Items
            item.Checked = True
        Next
    End Sub

#End Region
#Region "Pager"
    Protected Sub pager_CommAND(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommANDArgument, Int32)
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
        Dim LowerBAND As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBAND = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "S2_TTND_3gChargingLog_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFROMDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFROMDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)

        Dim vTableTemplate As String = "SELECT YEAR(A.Charging_Time) as vYear , convert(varchar,month(A.Charging_Time))  as vMonth,DATENAME(day,A.Charging_Time)  vDay,DATENAME(hour, A.Charging_Time) vHour, " & _
      " A.Short_Code as vShortcode,  convert(nvarchar,B.Service_Name) as vServices,   convert(nvarchar,C.PartnerName) as vPartnerName ,Charging_Account," & _
        " vCharging_Price= case convert(nvarchar,A.Charging_Price)  " & _
        " WHEN '500' THEN cast(round(convert(int,454)*1,0) as decimal(18,0)) " & _
        " WHEN '1000' THEN cast(round(convert(int,909)*1,0) as decimal(18,0)) " & _
        " WHEN '2000' THEN cast(round(convert(int,1818)*1,0) as decimal(18,0)) " & _
        " WHEN '3000' THEN cast(round(convert(int,2727)*1,0) as decimal(18,0)) " & _
        " WHEN '4000' THEN cast(round(convert(int,3636)*1,0) as decimal(18,0)) " & _
        " WHEN '5000' THEN cast(round(convert(int,4545)*1,0) as decimal(18,0)) " & _
        " WHEN '10000' THEN cast(round(convert(int,9090)*1,0) as decimal(18,0)) " & _
        " WHEN '15000' THEN cast(round(convert(int,13636)*1,0) as decimal(18,0)) " & _
        " else  '0' end,  " & _
        " vMoneyTotalVMG= case A.Charging_Price  " & _
        " WHEN '500' THEN cast(round(convert(int,182)*1,0) as decimal(18,0)) " & _
        " WHEN '1000' THEN cast(round(convert(int,364)*1,0) as decimal(18,0)) " & _
        " WHEN '2000' THEN cast(round(convert(int,727)*1,0) as decimal(18,0)) " & _
        " WHEN '3000' THEN cast(round(convert(int,1091)*1,0) as decimal(18,0)) " & _
        " WHEN '4000' THEN cast(round(convert(int,1454)*1,0) as decimal(18,0)) " & _
        " WHEN '5000' THEN cast(round(convert(int,1818)*1,0) as decimal(18,0)) " & _
        " WHEN '10000' THEN cast(round(convert(int,3636 )*1,0) as decimal(18,0)) " & _
        " WHEN '15000' THEN cast(round(convert(int,5454)*1,0) as decimal(18,0)) " & _
        " else  '0' end, " & _
        " vMoneyTotalVNM= case A.Charging_Price  " & _
        " WHEN '500' THEN cast(round(convert(int,454-182)*1,0) as decimal(18,0)) " & _
        " WHEN '1000' THEN cast(round(convert(int,909-364)*1,0) as decimal(18,0)) " & _
        " WHEN '2000' THEN cast(round(convert(int,1818-727)*1,0) as decimal(18,0)) " & _
        " WHEN '3000' THEN cast(round(convert(int,2727-1091)*1,0) as decimal(18,0)) " & _
        " WHEN '4000' THEN cast(round(convert(int,3636-1454)*1,0) as decimal(18,0)) " & _
        " WHEN '5000' THEN cast(round(convert(int,4545-1818)*1,0) as decimal(18,0)) " & _
        " WHEN '10000' THEN cast(round(convert(int,9090-3636 )*1,0) as decimal(18,0)) " & _
        " WHEN '15000' THEN cast(round(convert(int,13636-5454)*1,0) as decimal(18,0)) " & _
        " else  '0' end,  " & _
        " vMoneyTotal= case A.Charging_Price  " & _
        " WHEN '500' THEN cast(round(convert(int,454)*1,0) as decimal(18,0)) " & _
        " WHEN '1000' THEN cast(round(convert(int,909)*1,0) as decimal(18,0)) " & _
        " WHEN '2000' THEN cast(round(convert(int,1818)*1,0) as decimal(18,0)) " & _
        " WHEN '3000' THEN cast(round(convert(int,2727)*1,0) as decimal(18,0)) " & _
        " WHEN '4000' THEN cast(round(convert(int,3636)*1,0) as decimal(18,0)) " & _
        " WHEN '5000' THEN cast(round(convert(int,4545)*1,0) as decimal(18,0)) " & _
        " WHEN '10000' THEN cast(round(convert(int,9090)*1,0) as decimal(18,0)) " & _
        " WHEN '15000' THEN cast(round(convert(int,13636)*1,0) as decimal(18,0)) " & _
        " else  '0' end   " & _
        "  FROM " & vTable & " A" & _
        " inner join S2_TTND_Subscription_Services B on A.Service_ID=B.ID " & _
        " left join S2_TTND_Partners C on B.PartnerID =C.PartnerID   " & _
       IIf(Me.RadDropDownListStatus.SelectedItem.Value = 1, "  WHERE B.Service_Type='1006'  AND Charging_Status=1 ", " WHERE B.Service_Type='1006'  AND Charging_Status=0")

        vTableTemplate = "(" & vTableTemplate & " ) T"

        sqlOrder = " order by vYear "
        sql = "SELECT  vYear,Charging_Account,vMonth, " & _
        " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  T.vDay end ) as Day," & _
        " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  T.vHour end ) as Hour, " & _
        " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else T.vShortcode end ) as ShortCode, " & _
        " (case when '" & Me.CheckBoxPriceUnit.Checked & "'='False' then '--all--' else  convert(nvarchar,T.vCharging_Price) end ) as Charging_Price, " & _
        " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,T.vServices) end ) as ServicesName," & _
        " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,T.vPartnerName) end ) as PartnerName," & _
        " COUNT(*) Total,  SUM(cast(vMoneyTotal as decimal))  MoneyTotal,  SUM(cast(vMoneyTotalVMG as decimal))  MoneyTotalVMG,  SUM(cast(vMoneyTotalVNM as decimal))  MoneyTotalVNM, " & _
        " row_number() over( Order by count(*) desc) as RowNumber  FROM  " & vTableTemplate
        sqlTotal = "SELECT  vYear,Charging_Account,convert(varchar,month(A.Charging_Time))  as vMonth" & _
        " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  T.vDay end ) as Day," & _
        " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  T.vHour end ) as Hour, " & _
        " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else T.vShortcode end ) as ShortCode, " & _
        " (case when '" & Me.CheckBoxPriceUnit.Checked & "'='False' then '--all--' else  convert(nvarchar,T.vCharging_Price) end ) as Charging_Price, " & _
        " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,T.vServices) end ) as Services," & _
        " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,T.vPartnerName) end ) as PartnerName," & _
        " COUNT(*) Total,  SUM(cast(vMoneyTotal as decimal))  MoneyTotal,  SUM(cast(vMoneyTotalVMG as decimal))  MoneyTotalVMG,  SUM(cast(vMoneyTotalVNM as decimal))  MoneyTotalVNM " & _
        " FROM  " & vTableTemplate
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = " WHERE T.vDay>=" & Me.DropDownListFromDate.SelectedItem.Value & " and T.vDay<=" & Me.DropDownListToDate.SelectedItem.Value
        Else
            sqlConditional = " WHERE T.vYear>0"
        End If
        If Me.CheckBoxService_Id.Checked And Me.RadDropDownListService_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.vServices='" & Me.RadDropDownListService_Id.SelectedItem.Text & "'"
        End If
        If Me.CheckBoxPartnerId.Checked And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.vPartnerName=N'" & Me.RadDropDownListPartner_Id.SelectedItem.Text & "'"
        End If

        If Me.CheckBoxShortCode.Checked = True Then
            Dim CollectionShortCode As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListShortCode.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionShortCode.Count = 0 Then
                Me.lblerror.Text = "Đơn giá không hợp lệ !"
                Exit Sub
            Else
                If CollectionShortCode.Count < Me.RadDropDownListShortCode.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionShortCode
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  T.vShortcode In (" & sb.ToString() & ")"
                End If
            End If
        End If

        If Me.CheckBoxPriceUnit.Checked = True Then
            Dim CollectionPrice_Unit As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPriceUnit.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPrice_Unit.Count = 0 Then
                Me.lblerror.Text = "Đơn giá không hợp lệ !"
                Exit Sub
            Else
                If CollectionPrice_Unit.Count < Me.RadDropDownListPriceUnit.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPrice_Unit
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  vCharging_Price In (" & sb.ToString() & ")"
                End If
            End If
        End If

        sqlGroup = " GROUP BY T.vYear,vMonth,Charging_Account"
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", T.vDay"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ", T.vHour"
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxShortCode.Checked Then
            sqlGroup = sqlGroup & ", T.vShortCode"
            sqlOrder = sqlOrder & ",shortcode"
        End If
        If Me.CheckBoxPriceUnit.Checked Then
            sqlGroup = sqlGroup & ", T.vCharging_Price"
            sqlOrder = sqlOrder & ",Charging_Price"
        End If
        If Me.CheckBoxService_Id.Checked Then
            sqlGroup = sqlGroup & ", T.vServices"
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", T.vPartnerName"
        End If
        sql = sql & sqlConditional & sqlGroup

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(Total) TotalCDR,SUM(MoneyTotalVMG) MoneyTotalVMG,SUM(MoneyTotalVNM) MoneyTotalVNM, SUM(MoneyTotal)  as MoneyTotal, COUNT(*)  TotalRecord FROM  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBAND & " AND  T1.RowNumber < " & UpperBAND & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
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
                IsColumnDataGrid()
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotalVMG"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotalVNM"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotal"), 0)
                Me.lblTotalCDR.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("TotalCDR"), 0)

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
        If Me.CheckBoxHour.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxShortCode.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(12).Visible = True
        Else
            Me.DataGrid.Columns(12).Visible = False
        End If
    End Sub

#End Region

End Class