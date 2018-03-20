Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class SMS9029OndemandRev
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "BÁO CÁO DOANH THU SMS MO 9029 "
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindPartner()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SELECTedValue = Now.Year
        Me.DropDownListMonth.SELECTedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SELECTedItem.Value, _
                                                          Me.DropDownListFromDate, _
                                                          Me.DropDownListToDate)
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM VMG_MPay_Partners  WHERE Status =1 And PartnerType=1 "
        sql = sql & " Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
        Me.DropDownListPartnerId.Items.Clear()
        Me.DropDownListPartnerId.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartnerId.Items.Add(New ListItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerId")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SELECTedItem.Value, _
                                                            Me.DropDownListFromDate, _
                                                            Me.DropDownListToDate)
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
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VMG_MPay_TransactionLog_" & Me.DropDownListYear.SelectedItem.Value & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)
        Dim vTable1 As String = ""
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        '@2016 thay đổi đơn giá mạng VIETTEL 60%; VMS:	 65%; VNP:	60%
        vTable1 = "SELECT YEAR(A.LoggingTime) as vYear, convert(varchar,month(A.LoggingTime)) vMonth,DATENAME(day,A.LoggingTime) vDate,DATENAME(hour, A.LoggingTime) vHour, " & _
         " A.Isdn, A.ServiceId,A.TransactionType,A.ContentCode,cast(round(convert(int,A.TotalAmount)/1.1,0) as decimal(18,0)) TotalAmount  ,A.Operator, C.PartnerName,C.PartnerId," & _
         " vMoneyVMG= CASE A.Operator " & _
         " WHEN 'VIETTEL' THEN cast(round(convert(int,A.TotalAmount)*60/110,0) as decimal(18,0)) " & _
         " WHEN 'VMS' THEN cast(round(convert(int,A.TotalAmount)*65/110,0) as decimal(18,0))  " & _
         " WHEN 'VNP' THEN cast(round(convert(int,A.TotalAmount)*60/110,0) as decimal(18,0))  " & _
         " ELSE  '0' END, " & _
         " vMoneyOperator= CASE A.Operator " & _
         " WHEN 'VIETTEL' THEN cast(round(convert(int,A.TotalAmount)*40/110,0) as decimal(18,0)) " & _
         " WHEN 'VMS' THEN cast(round(convert(int,A.TotalAmount)*35/110,0) as decimal(18,0))  " & _
         " WHEN 'VNP' THEN cast(round(convert(int,A.TotalAmount)*40/110,0) as decimal(18,0))  " & _
         " ELSE  '0' END " & _
         " FROM  " & _
           vTable & " A " & _
         " INNER JOIN VMG_MPay_Partners C ON convert(varchar,A.PartnerId)=convert(varchar,C.PartnerId)" & _
          " WHERE   A.PaymentStatus = 1  And A.synstatus = 0"
        If Me.CheckBoxAllDate.Checked = False Then
            vTable1 = vTable1 & " and CONVERT(VARCHAR(10), LoggingTime, 112) >='" & vFromDate & "' and CONVERT(VARCHAR(10), LoggingTime, 112) <='" & vToDate & "'"
        End If
        sql = "SELECT   vYear ,vMonth," & _
        " (case WHEN '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  T.vDate end ) as vDate ," & _
        " (case WHEN '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  T.vHour end ) as vHour ," & _
        " (case WHEN '" & Me.CheckBoxPrice.Checked & "'='False' then '--all--' else  convert(nvarchar,T.TotalAmount) end ) as vCharging_Price ," & _
        " (case WHEN '" & Me.CheckBoxPhone.Checked & "'='False' then '--all--' else convert(nvarchar,T.Isdn) end ) as vUser_Id ," & _
        " (case WHEN '" & Me.CheckBoxOperator.Checked & "'='False' then '--all--' else convert(nvarchar,T.Operator) end ) as vOperator ," & _
        " (case WHEN '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else convert(nvarchar,T.ContentCode) end ) as vContentCode ," & _
        " (case WHEN '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,T.PartnerName) end ) as vPartnerName ," & _
        " Count(*) vTotal,  sum(cast(TotalAmount as decimal))  vMoneyTotal, sum(cast(vMoneyVMG as decimal))  vMoneyVMG,(sum(cast(TotalAmount as decimal))  - sum(cast(vMoneyVMG as decimal)))  vMoneyOperator,row_number() over( Order by vYear desc) as RowNumber " & _
        " FROM (" & vTable1 & ") T"
        sqlConditional = " WHERE  T.vYear >0"
        If Me.CheckBoxOperator.Checked And Me.DropDownListOperator.SelectedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " and T.Operator='" & Me.DropDownListOperator.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxPartnerId.Checked And Me.DropDownListPartnerId.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.PartnerId='" & Me.DropDownListPartnerId.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxPhone.Checked And Me.txtPhoneNumber.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and T.Isdn='" & Me.txtPhoneNumber.Text.Trim & "'"
        End If
        If Me.CheckBoxKeyword.Checked And Me.txtKeyword.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and T.ContentCode='" & Me.txtKeyword.Text.Trim & "'"
        End If
        sqlOrder = " ORDER BY vYear "
        sqlGroup = " GROUP BY T.vYear,T.vMonth"

        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", T.vDate"
            sqlOrder = sqlOrder & ",CAST(vDate as INT)"
        End If
        If Me.CheckBoxPrice.Checked = True Then
            sqlGroup = sqlGroup & ", T.TotalAmount"
            sqlOrder = sqlOrder & ",CAST(vCharging_Price as INT)"
        End If
        If Me.CheckBoxHour.Checked = True Then
            sqlGroup = sqlGroup & ", T.vHour"
            sqlOrder = sqlOrder & ",CAST(vHour as INT)"
        End If
        If Me.CheckBoxPhone.Checked = True Then
            sqlGroup = sqlGroup & ", T.Isdn"
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            sqlGroup = sqlGroup & ", T.ContentCode"
        End If

        If Me.CheckBoxOperator.Checked = True Then
            sqlGroup = sqlGroup & ", T.Operator"
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", T.PartnerName"
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT sum(vTotal) vTotalCDR,sum(vMoneyVMG) vMoneyVMG,sum(vMoneyOperator) vMoneyOperator, sum(vMoneyTotal) as vMoneyTotal, count(*) TotalRecord from  (" & sql & ") T1 "
            sql = "SELECT * from (" & sql & ") T1 where  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.lblTotalVMG.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("vMoneyVMG"), 0)
                Me.lblTotalVNM.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("vMoneyOperator"), 0)
                Me.lblTotalMoney.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("vMoneyTotal"), 0)
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                IsColumnDataGrid()
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            ExportData.ExportExcel._SMS.SMS9029OndemandRev(sql, CurrentUser.UserName, Me.CheckBoxOperator.Checked, Me.CheckBoxPartnerId.Checked, Me.CheckBoxKeyword.Checked, Me.CheckBoxPhone.Checked, Me.CheckBoxPrice.Checked, Me.CheckBoxDate.Checked, Me.CheckBoxHour.Checked)
        End If

    End Sub
#End Region
#Region "Is Column"
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
        If Me.CheckBoxPhone.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxOperator.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPrice.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(13).Visible = True
        Else
            Me.DataGrid.Columns(13).Visible = False
        End If
    End Sub
#End Region
End Class