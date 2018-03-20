  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class UnitelVillageMillionaire
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU DỊCH VỤ LÀNG TRIỆU PHÚ - UNITEL"
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

    End Sub

#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblTotal_Charge.Text = 0
        Me.lblTotal_VMG.Text = 0
        Me.lblTotal_Charge.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListTypeOfTransaction.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListChannel.Items
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

        Dim vTable As String = "Transactions"
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Day)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Day)
        sql = "SELECT DATEPART(yyyy,Time) as Year, " & _
                              " (case when '" & Me.CheckBoxTypeOfTransaction.Checked & "'='False' then '--all--' else convert(varchar, Type) end ) as TypeOfTransaction," & _
                              " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else isnull(Channel,'Unknown') end ) as ChannelRegister," & _
                              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else convert(varchar(2), DATEPART(mm,Time)) end ) as Month," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar(2), DATEPART(dd,Time)) end ) as Day," & _
                              " ROUND(SUM(cast(ChargedFee as decimal))/1.1,0) TotalMoney, ROUND(SUM(cast(ChargedFee as decimal))*0.4/1.1,0) VMG,ROUND(SUM(cast(ChargedFee as decimal))*0.6/1.1,0) Unitel, COUNT(*) TotalCharge," & _
                              " row_number() over( Order by DATEPART(yyyy,Time) ) as RowNumber " & _
                              " FROM " & vTable
        sqlTotal = "SELECT DATEPART(yyyy,Time) as Year, " & _
                              " (case when '" & Me.CheckBoxTypeOfTransaction.Checked & "'='False' then '--all--' else convert(varchar, Type) end ) as TypeOfTransaction," & _
                              " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else isnull(Channel,'Unknown') end ) as ChannelRegister," & _
                              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else convert(varchar(2), DATEPART(mm,Time)) end ) as Month," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else convert(varchar(2), DATEPART(dd,Time)) end ) as Day," & _
                               " ROUND(SUM(cast(ChargedFee as decimal))/1.1,0) TotalMoney, ROUND(SUM(cast(ChargedFee as decimal))*0.4/1.1,0) VMG,ROUND(SUM(cast(ChargedFee as decimal))*0.6/1.1,0) Unitel, COUNT(*) TotalCharge " & _
                              " FROM " & vTable
        sqlConditional = sqlConditional & " WHERE Status=" & Me.RadDropDownListStatus.SelectedItem.Value

        sqlConditional = sqlConditional & " And convert(varchar,Time,112)>='" & vFromDate & "' And convert(varchar,Time,112)<='" & vToDate & "'"

        If Me.CheckBoxTypeOfTransaction.Checked = True Then
            Dim CollectionTypeOfTransaction As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListTypeOfTransaction.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionTypeOfTransaction.Count = 0 Then
                Me.lblerror.Text = "Loại giao dịch không hợp lệ !"
                Exit Sub
            Else
                If CollectionTypeOfTransaction.Count < Me.RadDropDownListTypeOfTransaction.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionTypeOfTransaction
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Type In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Dim CollectionChannel As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListChannel.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionChannel.Count = 0 Then
                Me.lblerror.Text = "Kênh đăng ký không hợp lệ !"
                Exit Sub
            Else
                If CollectionChannel.Count < Me.RadDropDownListTypeOfTransaction.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionChannel
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Channel In (" & sb.ToString() & ")"
                End If
            End If
        End If
        sqlGroup = " GROUP BY DATEPART(yyyy,Time) "
        sqlOrder = " ORDER BY Year "
        If Me.CheckBoxTypeOfTransaction.Checked = True Then
            sqlGroup = sqlGroup & ", Type"
            sqlOrder = sqlOrder & ",TypeOfTransaction"
        End If
        If Me.CheckBoxChannel.Checked = True Then
            sqlGroup = sqlGroup & ", Channel"
            sqlOrder = sqlOrder & ",ChannelRegister"
        End If
        If Me.CheckBoxMonth.Checked = True Then
            sqlGroup = sqlGroup & ", DATEPART(mm,Time)"
            sqlOrder = sqlOrder & ",CAST(Month as INT)"
        End If
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", DATEPART(dd,Time)"
            sqlOrder = sqlOrder & ",CAST(Day as INT)"
        End If
        sql = sql & sqlConditional & sqlGroup & sqlCriteria
        sqlTotal = sqlTotal & sqlConditional & sqlGroup & sqlCriteria
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(TotalMoney) TotalMoney, SUM(VMG) VMG, SUM(Unitel) Unitel,SUM(TotalCharge) TotalCharge,COUNT(*) Total FROM (" & sqlTotal & ") T"

            sql = "SELECT Year, (CASE TypeOfTransaction  WHEN '0' THEN 'Register' WHEN '1' THEN 'Renew' WHEN '2' THEN 'Unregister'  WHEN '3' THEN 'BuyQuestion'   WHEN '-1' THEN 'Unknown' Else TypeOfTransaction END) as TypeOfTransaction, ChannelRegister, Month, Day,TotalMoney, VMG, Unitel,TotalCharge " & _
                     "FROM (" & sql & ") T  where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionStringUnitel"), sqlTotal)
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionStringUnitel"), sql)
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
                'IsColumnDataGrid()
                Me.lblTotal.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("TotalMoney"), 0)
                Me.lblTotal_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("VMG"), 0)
                Me.lblTotal_Unitel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Unitel"), 0)
                Me.lblTotal_Charge.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("TotalCharge"), 0)

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
#End Region

End Class