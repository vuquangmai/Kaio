Public Class BilSMSReportTotal
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public IsTotal As Integer = 0
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN VỚI ĐỐI TÁC - DỊCH VỤ SMS MO"
            BindDictIndex()
            Me.pager1.Visible = False
            Me.Panel1.Visible = False

        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindYear()
        BindMonth()
        BindPartner()
        BindTask()
        DeptExe()

    End Sub
#End Region
    Private Sub BindYear()
        Me.DropDownListYear.Items.Clear()
        For i As Integer = 2015 To 2020
            Me.DropDownListYear.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListYear.SelectedValue = Now.AddMonths(-1).Year
    End Sub
    Private Sub BindMonth()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.DropDownListMonth.Items
            If item.Text.Trim = Now.AddMonths(-1).Month Then
                item.Checked = True
                Exit Sub
            End If
        Next
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT A.Id,A.Partner_Text,A.Partner_Code " & _
        " FROM  Ccare_Management_Partner A INNER JOIN Ccare_Management_Contract B ON A.Id=B.Partner_Id " & _
        " WHERE B.Service_Id= " & Constants.ServiceInfo.Id.SMS
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindTask()
        Dim sql As String = "SELECT * FROM Billing_SMS_DictIndex_Task  Order by Task_Order "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListTask_Id.Items.Clear()
        Me.DropDownListTask_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListTask_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListTask_Id.Items.Add(New ListItem("[" & dt.Rows(i).Item("Task_Order") & "]   " & dt.Rows(i).Item("Task_Name"), dt.Rows(i).Item("Id")))
            Next
        End If

    End Sub
    Private Sub DeptExe()
        Dim sql As String = "SELECT Dept_Id_Execute,Dept_Text_Execute FROM Billing_SMS_DictIndex_Task GROUP BY Dept_Id_Execute,Dept_Text_Execute ORDER BY Dept_Text_Execute"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDept_Id_Execute_Current.Items.Clear()
        Me.DropDownListDept_Id_Execute_Current.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDept_Id_Execute_Current.SelectedValue = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Me.DropDownListDept_Id_Execute_Current.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text_Execute"), dt.Rows(i).Item("Dept_Id_Execute")))
        Next
    End Sub
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlOrder As String = " Order by Year"
        Dim sqlTotal As String = ""

        Dim sql As String = " SELECT  Year,Month," & _
               " (case when '" & Me.CheckBoxPartner_Id.Checked & "'='False' then '--all--' else convert(nvarchar(2000),Partner_Text) end ) as Partner_Text," & _
               " (case when '" & Me.CheckBoxStatus_Id.Checked & "'='False' then '--all--' else convert(nvarchar(2000),Status_Text) end ) as Status_Text," & _
               " (case when '" & Me.CheckBoxTask_Id.Checked & "'='False' then '--all--' else convert(nvarchar(2000),Task_Text_Curent) end ) as Task_Text_Curent," & _
               " (case when '" & Me.CheckBoxStatus_Debts_Id.Checked & "'='False' then '--all--' else convert(nvarchar(100),Status_Debts_Text) end ) as Status_Debts_Text," & _
               " (case when '" & Me.CheckBoxDept_Id_Execute_Current.Checked & "'='False' then '--all--' else convert(nvarchar(2000),Dept_Text_Execute_Current) end ) as Dept_Text_Execute_Current," & _
               "SUM(Total_Revenue) Total_Revenue,(SUM(Total_Payment_1)+SUM(Total_Payment_2)) Total_Payment,SUM(Total_Debts) Total_Debts," & _
               " ROW_NUMBER() OVER (order by Year ) as RowNumber ,count(*) vTotal " & _
               " From Billing_SMS_Work_Follow Where Year =" & Me.DropDownListYear.SelectedItem.Value
        Dim collection As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.DropDownListMonth.CheckedItems
        Dim sb As New StringBuilder()
        If collection.Count = 0 Then
            Me.lblerror.Text = "Dữ liệu tháng không hợp lệ !"
            Exit Sub
        Else
            If collection.Count < 12 Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In collection
                    If sb.ToString = "" Then
                        sb.Append(item.Text)
                    Else
                        sb.Append("," + item.Text)
                    End If
                Next
                sql = sql & " And  Month In (" & sb.ToString() & ")"
            End If
        End If

        If Me.CheckBoxPartner_Id.Checked = True And Me.DropDownListPartner_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Partner_Id=" & Me.DropDownListPartner_Id.SelectedItem.Value
        End If

        If Me.CheckBoxStatus_Id.Checked = True And Me.DropDownListStatus_Id.SelectedItem.Value <> -1 Then
            sql = sql & " and Status_Id=N'" & Me.DropDownListStatus_Id.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxTask_Id.Checked = True And Me.DropDownListTask_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Task_Id_Current=" & Me.DropDownListTask_Id.SelectedItem.Value
        End If
        If Me.CheckBoxDept_Id_Execute_Current.Checked = True And Me.DropDownListDept_Id_Execute_Current.SelectedItem.Value > 0 Then
            sql = sql & " and Dept_Id_Execute_Current=" & Me.DropDownListDept_Id_Execute_Current.SelectedItem.Value
        End If
        'If Me.DropDownListPayment.SelectedItem.Value > 0 Then
        '    If Me.DropDownListPayment.SelectedItem.Value = 1 Then ' Đã thanh toán
        '        sql = sql & " And Total_Payment >0 And Total_Debts=0"
        '    ElseIf Me.DropDownListPayment.SelectedItem.Value = 2 Then ' Thanh toán 1 phần
        '        sql = sql & " And Total_Payment >0 And Total_Debts >0"
        '    ElseIf Me.DropDownListPayment.SelectedItem.Value = 3 Then ' Chưa thanh toán
        '        sql = sql & " And Total_Payment =0 And Total_Debts >=0"
        '    End If
        'End If
        If Me.CheckBoxStatus_Debts_Id.Checked = True And Me.DropDownListPayment.SelectedItem.Value > -1 Then
            sql = sql & " and Status_Debts_Id=" & Me.DropDownListPayment.SelectedItem.Value
        End If
        If Me.DropDownListTypeOfPartner.SelectedItem.Value <> "--all--" Then
            sql = sql & " And  TypeOfPartner =" & Me.DropDownListTypeOfPartner.SelectedItem.Value
        End If
        sql = sql & " Group by Year,Month "
        If Me.CheckBoxPartner_Id.Checked = True Then
            sql = sql & ", Partner_Text"
        End If
        If Me.CheckBoxStatus_Id.Checked = True Then
            sql = sql & ", Status_Text"
        End If
        If Me.CheckBoxTask_Id.Checked = True Then
            sql = sql & " ,Task_Text_Curent"
        End If
        If Me.CheckBoxDept_Id_Execute_Current.Checked = True Then
            sql = sql & ", Dept_Text_Execute_Current"
        End If
        If Me.CheckBoxStatus_Debts_Id.Checked = True Then
            sql = sql & ", Status_Debts_Text"
        End If

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) TotalRecord, SUM(Total_Revenue)  Total_Revenue, SUM(Total_Payment) Total_Payment, SUM(Total_Debts) Total_Debts FROM (" & sql & ") T"
            sql = "SELECT Year,Month,Partner_Text,Status_Text,Task_Text_Curent,Dept_Text_Execute_Current,Status_Debts_Text,Total_Revenue,Total_Payment,Total_Debts,vTotal " & _
            " FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
            End If
            ViewState("DATA_GRID") = dt
            ViewState("DATA_COUNT") = dtPageCount
            Dim _totalCount As Integer = 0
            If dtPageCount.Rows.Count > 0 Then
                _totalCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            End If
            If dt.Rows.Count > 0 Then
                pager1.ItemCount = _totalCount
                Me.DataGrid.DataSource = dt
                Me.DataGrid.DataBind()
                Me.DataGrid.PagerStyle.Visible = False
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.Panel1.Visible = True
                IsColumn()
                Me.lblTotal_Revenue.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Revenue"), 0)
                Me.lblTotal_Payment.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Payment"), 0)
                Me.lblTotal_Debts.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Debts"), 0)

            Else
                Me.DataGrid.Visible = False
                Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
                Me.pager1.Visible = False
                Me.Panel1.Visible = False
            End If
        Else
            ExportData.ExportExcel._Bil.BilSMSReportTotal(sql, CurrentUser.UserFullName)

        End If
    End Sub
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Submit button"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Is Column"
    Private Sub IsColumn()
        If Me.CheckBoxPartner_Id.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxTask_Id.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxStatus_Id.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxStatus_Debts_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxDept_Id_Execute_Current.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
    End Sub
#End Region

End Class