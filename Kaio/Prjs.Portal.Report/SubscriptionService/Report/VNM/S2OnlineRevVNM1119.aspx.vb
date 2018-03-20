  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineRevVNM1119
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU ĐẦU SỐ 1119 - V//"
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
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate)
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM S2_TTND_Partners WHERE PartnerID>0 Order by PartnerName "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerID")))
            Next
        End If
    End Sub
    Private Sub BindServiceId()
        Dim sql As String = "SELECT * FROM S2_Vnm_Services Order by ServiceName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("ServiceName"), dt.Rows(i).Item("ServiceId")))
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
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblTotalCDR.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPriceUnit.Items
            item.Checked = True
        Next
    End Sub

#End Region
#Region "Pager"
    Protected Sub pager_CommAND(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
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
        Dim LowerBAND As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBAND = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "S2_Vnm_ChargingLogs_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)

        Dim vTableTemplate As String = "SELECT YEAR(A.PaymentTime) as vYear, convert(varchar,month(A.PaymentTime)) vMonth,DATENAME(day,A.PaymentTime) vDate,DATENAME(hour, A.PaymentTime) vHour, " & _
          " A.UserId, A.ServiceId,B.ServiceName,B.SubscriptionKeyword, convert(nvarchar,A.Rental)  vCharging_Price,convert(nvarchar,C.PartnerName) as vPartnerName," & _
          " vMoneyVMG= case A.Rental  " & _
          " when '500' then cast(round(convert(int,159)*1,0) as decimal(18,0)) " & _
          " when '1000' then cast(round(convert(int,318)*1,0) as decimal(18,0)) " & _
          " when '2000' then cast(round(convert(int,636)*1,0) as decimal(18,0)) " & _
          " when '3000' then cast(round(convert(int,954)*1,0) as decimal(18,0)) " & _
          " when '4000' then cast(round(convert(int,1273)*1,0) as decimal(18,0)) " & _
          " when '5000' then cast(round(convert(int,1591)*1,0) as decimal(18,0)) " & _
          " when '10000' then cast(round(convert(int,3182 )*1,0) as decimal(18,0)) " & _
          " when '15000' then cast(round(convert(int,4773)*1,0) as decimal(18,0)) " & _
          " else  '0' end, " & _
          " vMoneyVNM= case A.Rental  " & _
          " when '500' then cast(round(convert(int,454-159)*1,0) as decimal(18,0)) " & _
          " when '1000' then cast(round(convert(int,909-318)*1,0) as decimal(18,0)) " & _
          " when '2000' then cast(round(convert(int,1818-636)*1,0) as decimal(18,0)) " & _
          " when '3000' then cast(round(convert(int,2727-954)*1,0) as decimal(18,0)) " & _
          " when '4000' then cast(round(convert(int,3636-1273)*1,0) as decimal(18,0)) " & _
          " when '5000' then cast(round(convert(int,4545-1591)*1,0) as decimal(18,0)) " & _
          " when '10000' then cast(round(convert(int,9090-3182 )*1,0) as decimal(18,0)) " & _
          " when '15000' then cast(round(convert(int,13636-4773)*1,0) as decimal(18,0)) " & _
          " else  '0' end  " & _
          " FROM  " & _
            vTable & " A left join S2_Vnm_Services B on convert(varchar,A.ServiceID)=convert(varchar,B.ServiceID)" & _
            " left join S2_TTND_Partners C on B.PartnerId=C.PartnerID" & _
           " Where   A.PaymentStatus = " & RadDropDownListStatus.SelectedItem.Value
        If Me.CheckBoxAllDate.Checked = False Then
            vTableTemplate = vTableTemplate & " and CONVERT(VARCHAR(10), PaymentTime, 112) >='" & vFromDate & "' and CONVERT(VARCHAR(10), PaymentTime, 112) <='" & vToDate & "'"
        End If

        sql = "SELECT   vYear ,vMonth," & _
      " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  T.vDate end ) as vDate ," & _
      " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  T.vHour end ) as vHour ," & _
      " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,T.vPartnerName) end ) as vPartnerName," & _
      " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,T.ServiceName) end ) as vService_Name ," & _
      " (case when '" & Me.CheckBoxPriceUnit.Checked & "'='False' then '--all--' else  T.vCharging_Price end ) as vCharging_Price ," & _
      " (case when '" & Me.CheckBoxKeyWord.Checked & "'='False' then '--all--' else convert(nvarchar,T.SubscriptionKeyword) end ) as vSubscriptionKeyword ," & _
      " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else convert(nvarchar,T.UserId) end ) as vUser_Id ," & _
      " COUNT(*) vTotal,  SUM(cast(vCharging_Price as decimal))  vMoneyTotal, SUM(cast(vMoneyVMG as decimal))  vMoneyVMG,SUM(cast(vMoneyVNM as decimal))  vMoneyVNM, " & _
      " row_number() over( Order by vYear desc) as RowNumber  FROM (" & vTableTemplate & ") T"
        sqlConditional = " Where  T.vYear >0"
        If Me.CheckBoxPartnerId.Checked And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.vPartnerName=N'" & Me.RadDropDownListPartner_Id.SelectedItem.Text & "'"
        End If
        If Me.CheckBoxService_Id.Checked And Me.RadDropDownListService_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.Service_ID='" & Me.RadDropDownListService_Id.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxUser_Id.Checked And Me.txtUser_Id.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and T.User_Id='" & Me.txtUser_Id.Text.Trim & "'"
        End If
        If Me.CheckBoxKeyWord.Checked And Me.txtKeyWord.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and T.SubscriptionKeyword='" & Me.txtKeyWord.Text.Trim & "'"
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
        sqlGroup = " GROUP BY T.vYear,T.vMonth"
        sqlOrder = " Order by vYear ,vMonth "

        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", T.vPartnerName"
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            sqlGroup = sqlGroup & ", T.ServiceName"
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            sqlGroup = sqlGroup & ", T.vCharging_Price"
            sqlOrder = sqlOrder & ",CAST(vCharging_Price as INT)"
        End If
        If Me.CheckBoxKeyWord.Checked = True Then
            sqlGroup = sqlGroup & ", T.SubscriptionKeyword"
        End If
        If Me.CheckBoxUser_Id.Checked = True Then
            sqlGroup = sqlGroup & ", T.UserId"
        End If
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", T.vDate"
            sqlOrder = sqlOrder & ",CAST(vDate as INT)"
        End If
        If Me.CheckBoxHour.Checked = True Then
            sqlGroup = sqlGroup & ", T.vHour"
            sqlOrder = sqlOrder & ",CAST(vHour as INT)"
        End If
        sql = sql & sqlConditional & sqlGroup

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(vTotal) vTotalCDR,SUM(vMoneyVMG) vMoneyVMG,SUM(vMoneyVNM) vMoneyVNM, (SUM(vMoneyVMG)+SUM(vMoneyVNM)) as vMoneyTotal, SUM(vTotal) TotalCDR,COUNT(*) TotalRecord FROM  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 where  T1.RowNumber  >" & LowerBAND & " and  T1.RowNumber < " & UpperBAND & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sqlTotal)
            Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            pager1.ItemCount = _totalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyVMG"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyVNM"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyTotal"), 0)
                Me.lblTotalCDR.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("TotalCDR"), 0)
                IsColumnDataGrid()
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

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
        If Me.CheckBoxUser_Id.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxKeyWord.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            Me.DataGrid.Columns(10).Visible = True
        Else
            Me.DataGrid.Columns(10).Visible = False
        End If
    End Sub

#End Region

End Class