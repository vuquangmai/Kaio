Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class SMS9029SubscriptionRev
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "BÁO CÁO DOANH THU SUBS 9029 "
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindPartner()
        BindDate()
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
    Private Sub BindDate()
        Me.DropDownListYear.SELECTedValue = Now.Year
        Me.DropDownListMonth.SELECTedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SELECTedItem.Value, _
                                                          Me.DropDownListFromDate, _
                                                          Me.DropDownListToDate)
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VIETTEL_MPay_Sub_TransactionLogs_" & Me.DropDownListYear.SelectedItem.Value & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim ToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)
        Dim vTable1 As String = ""
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        vTable1 = "SELECT YEAR(Time) as vYear,convert(varchar,month(Time)) as vMonth,DATENAME(day,Time) as vDay,DATENAME(hour,Time) as vHour,Detail, " & _
            " Type as TypeOf ,ChargedFee,Status,PartnerId,Channel, count(*) TotalCDR,(count(*)*ChargedFee) TotalMoney, " & _
            " vMoneyVMG= case Type  " & _
            " when 1 then  round(count(*)*ChargedFee*0.6,0)   " & _
            "  when 3 then count(*)*ChargedFee*0.55 " & _
            " else  '0' end, " & _
           " vMoneyViettel= case Type  " & _
            " when 1 then  round(count(*)*ChargedFee*0.4,0)   " & _
            "  when 3 then count(*)*ChargedFee*0.45 " & _
            " else  '0' end  " & _
            " FROM " & vTable
        If Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) >= "201602" Then
            vTable1 = "SELECT YEAR(Time) as vYear,convert(varchar,month(Time)) as vMonth,DATENAME(day,Time) as vDay,DATENAME(hour,Time) as vHour,Detail, " & _
               " Type as TypeOf ,ChargedFee,Status,PartnerId,Channel, count(*) TotalCDR,cast(cast(count(*) as decimal(18,0))*ChargedFee as decimal(18,0))  TotalMoney, " & _
               " vMoneyVMG= case Type  " & _
               " when 1 then  round(count(*)*ChargedFee*0.4,0)   " & _
               "  when 3 then count(*)*ChargedFee*0.40 " & _
               " else  '0' end, " & _
              " vMoneyViettel= case Type  " & _
               " when 1 then  round(count(*)*ChargedFee*0.6,0)   " & _
               "  when 3 then count(*)*ChargedFee*0.60 " & _
               " else  '0' end  " & _
               " FROM " & vTable
        End If
        If Me.CheckBoxAllDate.Checked = False Then
            vTable1 = vTable1 & " WHERE convert(varchar,Time,112)>=" & FromDate
            vTable1 = vTable1 & " AND convert(varchar,Time,112)<=" & ToDate
        End If
        vTable1 = vTable1 & " GROUP BY YEAR(Time) ,convert(varchar,month(Time)) ,DATENAME(day,Time),DATENAME(hour,Time) ,Type,ChargedFee,Status,PartnerId,Channel,Detail "
        sql = "SELECT  A.vYear , " & _
            " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  convert(varchar,A.vMonth) end) as vMonth," & _
            " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  convert(varchar,A.vDay)  end ) as vDay," & _
            " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  convert(varchar,A.vHour) end ) as vHour, " & _
            " (case when '" & Me.CheckBoxPrice.Checked & "'='False' then '--all--' else convert(varchar,A.ChargedFee)  end ) as ChargedFee, " & _
            " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else convert(varchar,A.Channel) end ) as Channel, " & _
            " (case when '" & Me.CheckBoxTypeOf.Checked & "'='False' then '--all--' else convert(varchar,A.TypeOf) end ) as TypeOf, " & _
            " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,B.PartnerName)  end ) as PartnerName,  " & _
            " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else convert(nvarchar,A.Detail)  end ) as Detail,  " & _
            " cast(SUM(A.TotalCDR)  as decimal(18,0))  TotalCDR, cast(SUM(A.TotalMoney)  as decimal(18,0))  TotalMoney, cast(SUM(vMoneyVMG)  as decimal(18,0)) vMoneyVMG, cast(SUM(vMoneyViettel)  as decimal(18,0)) vMoneyViettel ,row_number() over( Order by  A.vYear) as RowNumber  " & _
            "  FROM (" & vTable1 & ")  As  A Left join VMG_MPay_Partners B on A.PartnerId=B.PartnerId "

        sqlConditional = " WHERE A.Status =" & Me.DropDownListStatus.SelectedItem.Value
        If Me.CheckBoxPartnerId.Checked And Me.DropDownListPartnerId.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and convert(nvarchar,B.PartnerId) =N'" & Me.DropDownListPartnerId.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxChannel.Checked And Me.DropDownListChannel.SelectedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " and Channel =N'" & Me.DropDownListChannel.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxTypeOf.Checked And Me.DropDownListTypeOf.SelectedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " and TypeOf =N'" & Me.DropDownListTypeOf.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxPrice.Checked = True And Me.txChargedFee.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and convert(nvarchar,A.ChargedFee) =N'" & Me.txChargedFee.Text.Trim & "'"
        End If
        If Me.CheckBoxKeyword.Checked = True And Me.txtDetail.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and convert(nvarchar,A.Detail) =N'" & Me.txtDetail.Text.Trim & "'"
        End If

        sqlGroup = " GROUP BY vYear "
        sqlOrder = " ORDER BY vYear"
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ",vMonth"
            sqlOrder = sqlOrder & ",CAST(vMonth as INT)"
        End If
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", vDay"
            sqlOrder = sqlOrder & ",CAST(vDay as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ",  vHour"
            sqlOrder = sqlOrder & ",CAST(vHour as INT)"
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", PartnerName "
        End If
        If Me.CheckBoxTypeOf.Checked Then
            sqlGroup = sqlGroup & ", TypeOf "
        End If
        If Me.CheckBoxPrice.Checked Then
            sqlGroup = sqlGroup & ",ChargedFee "
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ",Channel "
        End If
        If Me.CheckBoxKeyword.Checked Then
            sqlGroup = sqlGroup & ", Detail "
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", PartnerName "
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT  COUNT(*) TotalRecord, cast(SUM(TotalCDR)  as decimal(18,0)) TotalCDR,cast(SUM(TotalMoney)  as decimal(18,0)) TotalMoney,cast(SUM(vMoneyVMG) as decimal(18,0)) vMoneyVMG,cast(SUM(vMoneyViettel)  as decimal(18,0)) vMoneyViettel FROM  (" & sql & ") T1 "
            sql = "SELECT vYear,vMonth,vDay, vHour,ChargedFee,Channel,Detail," & _
                " (CASE TypeOf WHEN '1' THEN N'Đăng ký' WHEN '2' THEN N'Hủy' WHEN '3' THEN N'Gia hạn' ELSE TypeOf END) as TypeOf , PartnerName, TotalCDR, TotalMoney,vMoneyVMG,vMoneyViettel  FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.lblTotalCDR.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("TotalCDR"), 0)
                Me.lblTotalMoney.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("TotalMoney"), 0)
                Me.pager1.Visible = True
                Me.DataGrid.Visible = True
                IsColumnDataGrid()
            Else
                Me.pager1.Visible = False
                Me.DataGrid.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            'ExportS2._9029Sub(dt, Session(Constants.UserInfoSession.USER_FULL_NAME), Me.RadDatePickerFromDate.SELECTedDate.Value.Year, Me.RadDatePickerFromDate.SELECTedDate.Value.Month)
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
        If Me.CheckBoxTypeOf.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
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
#Region "Ajax"
    Protected Sub DropDownListMonth_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SELECTedItem.Value, _
                                                            Me.DropDownListFromDate, _
                                                            Me.DropDownListToDate)
    End Sub
#End Region
End Class