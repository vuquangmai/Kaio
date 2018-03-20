  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2ExpRevVNM1119
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU, CHI PHÍ ĐẦU SỐ 1119-VNM"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindPartner()
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)
        BindDate()
        BindServiceId()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDDHH(Me.DropDownListYear.SelectedItem.Value, _
                                      Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate, _
                                      Me.DropDownListFromHour, _
                                      Me.DropDownListToHour)
    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Where Id In (4) Order by Dept_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListDepartment_Id.Items.Clear()
        Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Dept_Code") & " [" & dt.Rows(i).Item("Dept_Text") & "]", dt.Rows(i).Item("ID")))
                Next
            End If

        End If
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.S2 & ") Order by Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Partner_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindPartner(ByVal Department_Id As Integer)
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.S2
        If Department_Id > 0 Then
            sql = sql & " And Department_Id=" & Department_Id & ") "
        Else
            sql = sql & ") "
        End If
        sql = sql & " Order by Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Partner_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindContract(ByVal Partner_Id As Integer)
        Dim sql As String = "SELECT *  FROM Ccare_Management_Contract Where Service_Id= " & Constants.ServiceInfo.Id.S2
        If Partner_Id > 0 Then
            sql = sql & " And Partner_Id='" & Partner_Id & "'"
        End If
        sql = sql & "  Order by Contract_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListContract_Code.Items.Clear()
        Me.RadDropDownListContract_Code.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListContract_Code.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Contract_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("Contract_Code")))
            Next
        End If
    End Sub
    Private Sub BindServiceId()
        Dim sql As String = "SELECT  * FROM S2_DictIndex_Service Order by Service_Text "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Service_Text"), dt.Rows(i).Item("Service_Id")))
            Next
        End If
    End Sub
    Private Sub BindServiceId(ByVal Mobile_Operator As String)
        Dim sql As String = "SELECT  * FROM S2_DictIndex_Service Where Mobile_Operator='" & Mobile_Operator & "' Order by Service_Text "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Service_Text"), dt.Rows(i).Item("Service_Id").ToString.Trim))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub RadDropListMobile_Operator_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropListMobile_Operator.SelectedIndexChanged
        BindServiceId(Me.RadDropListMobile_Operator.SelectedItem.Value)
    End Sub

    Protected Sub RadDropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListDepartment_Id.SelectedIndexChanged
        BindPartner(RadDropDownListDepartment_Id.SelectedItem.Value)
    End Sub

    Protected Sub RadDropDownListPartner_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListPartner_Id.SelectedIndexChanged
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)

    End Sub
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
        Me.lblMoney_VMG_Partner.Text = 0
        Me.lblMoney_Partner_VMG.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListAccess_Number.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDayOfWeek.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPrice_Unit.Items
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

        Dim vTable As String = "S2_Data_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)

        sql = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                              " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Code,'Unknown') end ) as Partner_Code," & _
                              " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                              " (case when '" & Me.CheckBoxMobile_Operator.Checked & "'='False' then '--all--' else isnull(Mobile_Operator,'Unknown') end ) as Mobile_Operator," & _
                              " (case when '" & Me.CheckBoxAccess_Number.Checked & "'='False' then '--all--' else  isnull(Access_Number,'Unknown') end ) as Access_Number," & _
                              " (case when '" & Me.CheckBoxPrice_Unit.Checked & "'='False' then '--all--' else  convert(varchar,Price_Unit) end ) as Price_Unit," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else isnull(Service_Text,'Unknown') end ) as Service_Text," & _
                              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else isnull(Subscription_Command_Word,'Unknown') end ) as Subscription_Command_Word," & _
                              " SUM(cast(Money_Ccare as decimal)) Money_Ccare, SUM(cast(Money_Telcos_VMG as decimal))  Money_Telcos_VMG, SUM(cast(Money_VMG_Telcos as decimal))  Money_VMG_Telcos," & _
                              " SUM(cast(Money_VMG_Partner as decimal)) Money_VMG_Partner, SUM(cast(Money_Partner_VMG as decimal)) Money_Partner_VMG, SUM(CDR) CDR," & _
                              " row_number() over( Order by substring(date,1,4) ) as RowNumber " & _
                              " FROM " & vTable
        sqlTotal = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                           " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Code,'Unknown') end ) as Partner_Code," & _
                              " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                              " (case when '" & Me.CheckBoxMobile_Operator.Checked & "'='False' then '--all--' else isnull(Mobile_Operator,'Unknown') end ) as Mobile_Operator," & _
                              " (case when '" & Me.CheckBoxAccess_Number.Checked & "'='False' then '--all--' else  isnull(Access_Number,'Unknown') end ) as Access_Number," & _
                              " (case when '" & Me.CheckBoxPrice_Unit.Checked & "'='False' then '--all--' else  convert(varchar,Price_Unit) end ) as Price_Unit," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else isnull(Service_Text,'Unknown') end ) as Service_Text," & _
                              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else isnull(Subscription_Command_Word,'Unknown') end ) as Subscription_Command_Word," & _
                              " SUM(cast(Money_Ccare as decimal)) Money_Ccare, SUM(cast(Money_Telcos_VMG as decimal))  Money_Telcos_VMG, SUM(cast(Money_VMG_Telcos as decimal))  Money_VMG_Telcos," & _
                              " SUM(cast(Money_VMG_Partner as decimal)) Money_VMG_Partner, SUM(cast(Money_Partner_VMG as decimal)) Money_Partner_VMG, SUM(CDR) CDR " & _
                            " FROM " & vTable
        sqlConditional = sqlConditional & " WHERE Mobile_Operator='VNM' AND Access_Number='1119' "
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And Date>='" & vFromDate & "' And Date<='" & vToDate & "'"
        End If

        If Me.CheckBoxPartnerId.Checked = True And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Partner_Id =" & Me.RadDropDownListPartner_Id.SelectedItem.Value
        End If
        If Me.CheckBoxContractCode.Checked = True And Me.RadDropDownListContract_Code.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Contract_Code =N'" & Me.RadDropDownListContract_Code.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxMobile_Operator.Checked = True And Me.RadDropListMobile_Operator.SelectedItem.Value <> "--all--" Then
            sqlConditional = sqlConditional & " And Mobile_Operator =N'" & Me.RadDropListMobile_Operator.SelectedItem.Value & "'"
        End If

        If Me.CheckBoxAccess_Number.Checked = True Then
            Dim CollectionAccess_Number As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListAccess_Number.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionAccess_Number.Count = 0 Then
                Me.lblerror.Text = "Đầu số không hợp lệ !"
                Exit Sub
            Else
                If CollectionAccess_Number.Count < Me.RadDropDownListAccess_Number.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionAccess_Number
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Access_Number In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxPrice_Unit.Checked = True Then
            Dim CollectionPrice_Unit As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPrice_Unit.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPrice_Unit.Count = 0 Then
                Me.lblerror.Text = "Đơn giá không hợp lệ !"
                Exit Sub
            Else
                If CollectionPrice_Unit.Count < Me.RadDropDownListPrice_Unit.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPrice_Unit
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Price_Unit In (" & sb.ToString() & ")"
                End If
            End If
        End If

        If Me.CheckBoxDayOfWeek.Checked = True Then
            Dim CollectionDayOfWeek As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListDayOfWeek.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionDayOfWeek.Count = 0 Then
                Me.lblerror.Text = "Thứ của tuần không hợp lệ !"
                Exit Sub
            Else
                If CollectionDayOfWeek.Count < Me.RadDropDownListDayOfWeek.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionDayOfWeek
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  DayOfWeek_Id In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxService_Id.Checked = True And Me.RadDropDownListService_Id.SelectedItem.Value <> "0" Then
            sqlConditional = sqlConditional & " And Service_Id =N'" & Me.RadDropDownListService_Id.SelectedItem.Value & "'"
        End If
        sqlGroup = " GROUP BY substring(Date,1,4),substring(Date,5,2) "
        sqlOrder = " ORDER BY Year "

        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,7,2)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If

        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", Partner_Code"
            sqlOrder = sqlOrder & ",Partner_Code"
        End If
        If Me.CheckBoxContractCode.Checked = True Then
            sqlGroup = sqlGroup & ", Contract_Code"
            sqlOrder = sqlOrder & ",Contract_Code"
        End If
        If Me.CheckBoxMobile_Operator.Checked = True Then
            sqlGroup = sqlGroup & ", Mobile_Operator"
            sqlOrder = sqlOrder & ",Mobile_Operator"
        End If
        If Me.CheckBoxAccess_Number.Checked = True Then
            sqlGroup = sqlGroup & ", Access_Number"
            sqlOrder = sqlOrder & ",Access_Number"
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            sqlGroup = sqlGroup & ", DayOfWeek_Text"
            sqlOrder = sqlOrder & ",DayOfWeek_Text"
        End If
        If Me.CheckBoxPrice_Unit.Checked = True Then
            sqlGroup = sqlGroup & ", Price_Unit"
            sqlOrder = sqlOrder & ",Price_Unit"
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            sqlGroup = sqlGroup & ", Service_Text,Subscription_Command_Word"
            sqlOrder = sqlOrder & ",Service_Text"
        End If
        sql = sql & sqlConditional & sqlGroup & sqlCriteria
        sqlTotal = sqlTotal & sqlConditional & sqlGroup & sqlCriteria
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(Money_Ccare) Money_Ccare, SUM(Money_Telcos_VMG) Money_Telcos_VMG, SUM(Money_VMG_Telcos) Money_VMG_Telcos," & _
                            "SUM(Money_VMG_Partner) Money_VMG_Partner, SUM(Money_Partner_VMG) Money_Partner_VMG, " & _
                            "COUNT(*) Total FROM (" & sqlTotal & ") T"
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sqlTotal)
            sql = "SELECT * FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
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
                IsColumnDataGrid()
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_VMG_Telcos"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Telcos_VMG"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Ccare"), 0)
                Me.lblMoney_VMG_Partner.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_VMG_Partner"), 0)
                Me.lblMoney_Partner_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Partner_VMG"), 0)

                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._S2.S2TrafficTotal(sql, CurrentUser.UserName, _
                                                             Me.CheckBoxDate.Checked, _
                                                             Me.CheckBoxDayOfWeek.Checked, _
                                                             Me.CheckBoxMobile_Operator.Checked, _
                                                             Me.CheckBoxAccess_Number.Checked, _
                                                             Me.CheckBoxPrice_Unit.Checked, _
                                                             Me.CheckBoxService_Id.Checked, _
                                                             Me.CheckBoxPartnerId.Checked, _
                                                             Me.CheckBoxContractCode.Checked)

        End If
    End Sub
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(1).Visible = True
        Else
            Me.DataGrid.Columns(1).Visible = False
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            Me.DataGrid.Columns(2).Visible = True
        Else
            Me.DataGrid.Columns(2).Visible = False
        End If
        If Me.CheckBoxMobile_Operator.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxAccess_Number.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxPrice_Unit.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(14).Visible = True
        Else
            Me.DataGrid.Columns(14).Visible = False
        End If
        If Me.CheckBoxContractCode.Checked = True Then
            Me.DataGrid.Columns(15).Visible = True
        Else
            Me.DataGrid.Columns(15).Visible = False
        End If

    End Sub

#End Region

End Class