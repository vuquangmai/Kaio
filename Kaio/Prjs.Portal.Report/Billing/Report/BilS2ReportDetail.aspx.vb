  Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class BilS2ReportDetail
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO TIẾN ĐỘ ĐỐI SOÁT, THANH TOÁN VỚI ĐỐI TÁC - DỊCH VỤ S2"
            BindYear()
            BindMonth()
            DeptExe()
            BindPartner()
            BindTask()
            ReloadData()
        End If
    End Sub
#End Region
#Region "DictIndex"
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
    Private Sub DeptExe()
        Dim sql As String = "SELECT Dept_Id_Execute,Dept_Text_Execute FROM Billing_S2_DictIndex_Task GROUP BY Dept_Id_Execute,Dept_Text_Execute ORDER BY Dept_Text_Execute"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDeptExcute.Items.Clear()
        Me.DropDownListDeptExcute.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDeptExcute.SelectedValue = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Me.DropDownListDeptExcute.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text_Execute"), dt.Rows(i).Item("Dept_Id_Execute")))
        Next
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT A.Id,A.Partner_Text,A.Partner_Code " & _
        " FROM  Ccare_Management_Partner A INNER JOIN Ccare_Management_Contract B ON A.Id=B.Partner_Id " & _
        " WHERE B.Service_Id= " & Constants.ServiceInfo.Id.S2
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
        Dim sql As String = "SELECT * FROM Billing_S2_DictIndex_Task  Order by Task_Order "
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
#End Region
#Region "Reload Data"
    Private Sub ReloadData()
        If ViewState("DATA_GRID") Is Nothing Then
            'Not Load database
        Else
            Dim dt As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                Me.RadGrid.Visible = False
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                If dt.Rows.Count > 0 Then
                    Me.RadGrid.Visible = True
                    Me.RadGrid.DataSource = dt
                Else
                    Me.RadGrid.Visible = False
                End If
            End If
        End If
    End Sub
#End Region
#Region "RadGrid Event"
    Private Sub RadGrid_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        If Not e.IsFromDetailTable Then
            Dim sql As String = "SELECT * FROM Billing_S2_Work_Follow " & _
                " WHERE Year=" & Me.DropDownListYear.SelectedItem.Value
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
            If Me.DropDownListPayment.SelectedItem.Value > -1 Then
                sql = sql & " and Status_Debts_Id=" & Me.DropDownListPayment.SelectedItem.Value
            End If
            sql = sql & " ORDER BY Partner_Code"
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                RadGrid.DataSource = dt
                Me.RadGrid.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.RadGrid.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        End If
    End Sub
    Private Sub RadGrid_DetailTableDataBind(ByVal source As Object, ByVal e As GridDetailTableDataBindEventArgs) Handles RadGrid.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Dim sql As String = ""
        Select Case e.DetailTableView.Name
            Case "Orders"
                Dim Work_Follow_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT *  FROM Billing_S2_Work_Follow_Detail  " & _
               " Where Work_Follow_Id=" & Work_Follow_Id & _
               " ORDER BY Task_Order_Current "

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
            Case "OrderDetails"
                Dim vId As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim splitout = Split(vId.ToString(), "M")
                Dim Department_Id As Integer = splitout(0)
                Dim Service_Id As Integer = splitout(1)
                sql = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Contract_Text,A.Cycle_Contract_Text,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id=" & Department_Id & " AND A.Service_Id= " & Service_Id
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
        End Select
    End Sub
    Protected Sub RadGrid_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles RadGrid.PreRender
        'If Not Page.IsPostBack Then
        '    RadGrid.MasterTableView.Items(0).Expanded = True
        '    RadGrid.MasterTableView.Items(0).ChildItem.NestedTableViews(0).Items(0).Expanded = True
        'End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        ViewState("DATA_GRID") = Nothing
        Dim sql As String = "SELECT * FROM Billing_S2_Work_Follow " & _
                " WHERE Year=" & Me.DropDownListYear.SelectedItem.Value
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
        If Me.DropDownListPayment.SelectedItem.Value > -1 Then
            sql = sql & " and Status_Debts_Id=" & Me.DropDownListPayment.SelectedItem.Value
        End If
        If Me.DropDownListPartner_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Partner_Id=" & Me.DropDownListPartner_Id.SelectedItem.Value
        End If

        If Me.DropDownListStatus_Id.SelectedItem.Value <> -1 Then
            sql = sql & " and Status_Id=N'" & Me.DropDownListStatus_Id.SelectedItem.Value & "'"
        End If
        If Me.DropDownListTask_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Task_Id_Current=" & Me.DropDownListTask_Id.SelectedItem.Value
        End If
        If Me.DropDownListDeptExcute.SelectedItem.Value > 0 Then
            sql = sql & " and Dept_Id_Execute_Current=" & Me.DropDownListDeptExcute.SelectedItem.Value
        End If
        If Me.DropDownListTypeOfPartner.SelectedItem.Value <> "--all--" Then
            sql = sql & " And  TypeOfPartner =" & Me.DropDownListTypeOfPartner.SelectedItem.Value
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

        sql = sql & " ORDER BY Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            RadGrid.DataSource = dt
            RadGrid.DataBind()
            Me.RadGrid.Visible = True
            Me.lblerror.Text = ""
        Else
            Me.RadGrid.Visible = False
            Me.lblerror.Text = "Không có dữ liệu !"
        End If
    End Sub

    Protected Sub btnExp_Click(sender As Object, e As EventArgs) Handles btnExp.Click
        Dim sql As String = "SELECT * FROM Billing_S2_Work_Follow " & _
              " WHERE Year=" & Me.DropDownListYear.SelectedItem.Value
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
        If Me.DropDownListPayment.SelectedItem.Value > -1 Then
            sql = sql & " and Status_Debts_Id=" & Me.DropDownListPayment.SelectedItem.Value
        End If
        If Me.DropDownListPartner_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Partner_Id=" & Me.DropDownListPartner_Id.SelectedItem.Value
        End If

        If Me.DropDownListStatus_Id.SelectedItem.Value <> -1 Then
            sql = sql & " and Status_Id=N'" & Me.DropDownListStatus_Id.SelectedItem.Value & "'"
        End If
        If Me.DropDownListTask_Id.SelectedItem.Value > 0 Then
            sql = sql & " and Task_Id_Current=" & Me.DropDownListTask_Id.SelectedItem.Value
        End If
        If Me.DropDownListDeptExcute.SelectedItem.Value > 0 Then
            sql = sql & " and Dept_Id_Execute_Current=" & Me.DropDownListDeptExcute.SelectedItem.Value
        End If
        sql = sql & " ORDER BY Partner_Code"
        ExportData.ExportExcel._Bil.BilS2ReportDetail(sql, CurrentUser.UserFullName)

    End Sub
#End Region
End Class