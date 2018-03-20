  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class ViSportRevVNM
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU DỊCH VỤ VISPORT - V//"
            BindDictIndex()
            InitData()
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now.AddDays(-(Today.Day) + 1)
        Me.RadToDate.SelectedDate = Now
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblTotalCDR.Text = 0
        Me.pager1.Visible = False
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
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim vFromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim vToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        Dim vTable As String = "Sport_Game_Hero_Charged_Users_Log "
        Dim vTable1 As String = "(SELECT YEAR(ChargingDate) as vYear,convert(varchar,month(ChargingDate)) as vMonth, DATENAME(day,ChargingDate) as vDay, DATENAME(hour, ChargingDate) as vHour, convert(varchar,Price)   as vPrice," & _
            " convert(varchar,Service_ID)  as vShortcode,  Command_Code as vCommand_Code, " & _
            " case convert(varchar,Service_Type)+ Registration_Channel when '1SMS' then 'SMS' when '1WAP' then 'WAP' when '0SMS' then 'SUB' when '0WAP' then 'SUB' else 'SUB' end as vRegistration_Channel," & _
            " Operator as vOperator, count(*) vTotal," & _
            " cast(round(SUM(Price)*1,0) as decimal(18,0)) vMoneyTotal,  " & _
            " cast(round(SUM(Price)*0.60,0) as decimal(18,0))  vMoneyTotalVNM, " & _
            " cast(round(SUM(Price)*0.40,0) as decimal(18,0))  vMoneyTotalVMG " & _
            "  FROM " & vTable & _
            IIf(Me.DropDownListStatus.SelectedItem.Value = 1, "  WHERE Reason ='Succ' ", " WHERE Reason<>'Succ'")
        If Me.CheckBoxAllDate.Checked = False Then
            vTable1 = vTable1 & " AND CONVERT(varchar, ChargingDate,112) >='" & vFromDate & "' AND CONVERT(varchar ,ChargingDate,112)<='" & vToDate & "'"
        End If
        vTable1 = vTable1 & " GROUP BY YEAR(ChargingDate),convert(varchar,month(ChargingDate)),DATENAME(day,ChargingDate),DATENAME(hour, ChargingDate) ,convert(varchar,Price) ,convert(varchar,Service_ID)  ,  Command_Code,convert(varchar,Service_Type)+ Registration_Channel,Operator) T"
        sqlOrder = " Order by vYear "
        sql = "SELECT  vYear , (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  T.vMonth end) as Month," & _
        " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  T.vDay end ) as Day," & _
        " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  T.vHour end ) as Hour, " & _
        " (case when '" & Me.CheckBoxPrice.Checked & "'='False' then '--all--' else T.vPrice end ) as Price, " & _
        " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else T.vShortcode end ) as ShortCode, " & _
        " (case when '" & Me.CheckBoxOperator.Checked & "'='False' then '--all--' else T.vOperator end ) as Operator, " & _
        " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else convert(nvarchar,T.vCommand_Code) end ) as Command_Code," & _
        " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else convert(nvarchar,T.vRegistration_Channel) end ) as Registration_Channel," & _
        " SUM(vTotal) Total,  SUM(cast(vMoneyTotal as decimal))  MoneyTotal,  SUM(cast(vMoneyTotalVMG as decimal))  MoneyTotalVMG,  SUM(cast(vMoneyTotalVNM as decimal))  MoneyTotalVNM, " & _
        " row_number() over( Order by SUM(vTotal) desc) as RowNumber  FROM " & vTable1
        sqlConditional = " WHERE  T.vYear >0 "
        If Me.CheckBoxOperator.Checked And Me.DropDownListOperator.SelectedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " and T.vOperator='" & Me.DropDownListOperator.SelectedItem.Text & "'"
        End If
        If Me.CheckBoxChannel.Checked And Me.DropDownListChannel.SelectedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " and T.vRegistration_Channel='" & Me.DropDownListChannel.SelectedItem.Text & "'"
        End If
        If Me.CheckBoxKeyword.Checked And Me.txtKeyword.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and T.vCommand_Code=N'" & Me.txtKeyword.Text.Trim & "'"
        End If
        If Me.CheckBoxShortCode.Checked And Me.DropDownListShortCode.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and T.vShortcode='" & Me.DropDownListShortCode.SelectedItem.Text & "'"
        End If
        sqlGroup = " GROUP BY T.vYear"
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ", T.vMonth"
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", T.vDay"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ", T.vHour"
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxPrice.Checked Then
            sqlGroup = sqlGroup & ", T.vPrice"
            sqlOrder = sqlOrder & ",Price"
        End If
        If Me.CheckBoxShortCode.Checked Then
            sqlGroup = sqlGroup & ", T.vShortCode"
            sqlOrder = sqlOrder & ",shortcode"
        End If
        If Me.CheckBoxKeyword.Checked Then
            sqlGroup = sqlGroup & ", T.vCommand_Code"
        End If
        If Me.CheckBoxKeyword.Checked Then
            sqlGroup = sqlGroup & ", T.vCommand_Code"
        End If
        If Me.CheckBoxOperator.Checked Then
            sqlGroup = sqlGroup & ", T.vOperator"
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ", T.vRegistration_Channel"
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT COUNT(*) Total,  SUM(cast(MoneyTotal as decimal))  MoneyTotal,  SUM(cast(MoneyTotalVMG as decimal))  MoneyTotalVMG,  SUM(cast(MoneyTotalVNM as decimal))  MoneyTotalVNM FROM   (" & sql & ") T1")
            pager1.ItemCount = dtPageCount.Rows(0).Item("Total")
            If dt.Rows.Count > 0 Then
                Me.DataGrid.DataSource = dt
                Me.DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & dtPageCount.Rows(0).Item("Total")
                Next
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotalVMG"), 0)
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotalVNM"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MoneyTotal"), 0)

                IsColumnDataGrid()
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
        End If
    End Sub
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxMonth.Checked = True Then
            Me.DataGrid.Columns(2).Visible = True
        Else
            Me.DataGrid.Columns(2).Visible = False
        End If
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
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxShortCode.Checked = True Then
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
            Me.DataGrid.Columns(9).Visible = True
        Else
            Me.DataGrid.Columns(9).Visible = False
        End If
    End Sub
#End Region

End Class