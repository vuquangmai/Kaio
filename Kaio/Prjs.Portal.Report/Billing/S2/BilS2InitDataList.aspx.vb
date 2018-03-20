Imports System.Data.SqlClient

Public Class BilS2InitDataList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KHỞI TẠO DỮ LIỆU ĐỐI SOÁT THEO HỢP ĐỒNG -  DỊCH VỤ THẺ CÀO"
            BindYear()
            BindMonth()
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
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
        Me.DropDownListMonth.Items.Clear()
        For i As Integer = 1 To 12
            Me.DropDownListMonth.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListMonth.SelectedValue = Now.AddMonths(-1).Month
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT A.Id, A.Year, A.Month, A.Contract_Id, A.Contract_Code, A.Partner_Id,A.Partner_Text,A.Partner_Code,A.Account_Report, " & _
             " A.Dept_Id_Biz,A.Dept_Text_Biz," & _
             " A.Task_Order_Current,A.Task_Id_Current,A.Task_Text_Curent," & _
             " A.Task_Order_Next,A.Task_Id_Next,A.Task_Text_Next," & _
             " A.Dept_Id_Execute_Current,A.Dept_Text_Execute_Current,A.Dept_Id_Execute_Next,A.Dept_Text_Execute_Next," & _
             " A.Execute_Time,A.Status_Id,A.Status_Text, " & _
             " A.Create_By_Text,A.Create_Time,A.Update_By_Text,A.Update_Time, A.Description,A.Have_Revenue, " & _
             " Row_Number() Over ( Order by A.Id ) as RowNumber " & _
             " From Billing_S2_Work_Follow  A  " & _
             " Where Year=" & Me.DropDownListYear.SelectedItem.Value & " And Month=" & Me.DropDownListMonth.SelectedItem.Value
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
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
        Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Visible = True
            Me.pager1.Visible = True
            pager1.ItemCount = _totalCount
            Me.lblerror.Text = ""
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
            For j As Integer = 0 To DataGrid.Items.Count - 1
                Dim lbID As Label
                lbID = DataGrid.Items(j).FindControl("lblOrder")
                lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _totalCount
            Next
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim Year As Integer = Me.DropDownListYear.SelectedItem.Value
        Dim Month As Integer = Me.DropDownListMonth.SelectedItem.Value
        Dim TypeOfPartner As Integer = 0
        Dim Dept_Id_Of As Integer = 0
        Dim Dept_Text_Of As String = ""
        Dim Dept_Code_Of As String = ""
        Dim Contract_Id As Integer = 0
        Dim Contract_Code As String = ""
        Dim Contract_Number As String = ""
        Dim Partner_Id As Integer = 0
        Dim Partner_Text As String = ""
        Dim Partner_Code As String = ""
        Dim Account_Report As String = ""
        Dim Dept_Id_Biz As String = ""
        Dim Dept_Text_Biz As String = ""
        Dim Multi_Dept_Biz As Integer = 0
        Dim Task_Order_Current As Integer = 0
        Dim Task_Id_Current As Integer = 0
        Dim Task_Text_Curent As String = ""
        Dim Task_Order_Next As Integer = 0
        Dim Task_Id_Next As Integer = 0
        Dim Task_Text_Next As String = ""
        Dim Dept_Id_Execute_Current As String = ""
        Dim Dept_Text_Execute_Current As String = ""
        Dim Multi_Dept_Execute As String = ""
        Dim Dept_Id_Execute_Next As String = ""
        Dim Dept_Text_Execute_Next As String = ""
        Dim Execute_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Status_Id As Integer = 0
        Dim Status_Text As String = "Chưa hoàn thành"
        Dim Total_Task As Integer = 0
        Dim Hour_Implement_Current As Decimal = 0
        Dim Day_Implement_Current As Decimal = 0
        Dim Hour_Implement_Next As Decimal = 0
        Dim Day_Implement_Next As Decimal = 0
        Dim Total_Hour_Implement As Decimal = 0
        Dim Total_Day_Implement As Decimal = 0
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Task_Log As String = ""
        Dim Description As String = ""
        Dim sql As String = ""
        If Me.CheckBoxDel.Checked = True Then
            sql = "Delete  From  Billing_S2_Work_Follow  Where   Year =" & Year & " And Month=" & Month
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi xóa dữ liệu cũ. Mã lỗi: " & ex.Message
                Exit Sub
            End Try
            sql = "Delete  From  Billing_S2_Work_Follow_Detail  Where   Year =" & Year & " And Month=" & Month
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi xóa dữ liệu cũ. Mã lỗi: " & ex.Message
                Exit Sub
            End Try
        End If
        sql = "SELECT  SUM(Hour_Implement) TotalHour_Implement,SUM(Day_Implement) TotalDay_Implement, COUNT(*) Total_Task FROM   Billing_S2_DictIndex_Task "
        Dim dtTaskToal As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTaskToal.Rows.Count > 0 Then
            Total_Task = dtTaskToal.Rows(0).Item("Total_Task")
            Total_Hour_Implement = dtTaskToal.Rows(0).Item("TotalHour_Implement")
            Total_Day_Implement = dtTaskToal.Rows(0).Item("TotalDay_Implement")
        Else
            Me.lblerror.Text = "Dữ liệu khởi tạo không hợp lệ !"
            Exit Sub
        End If

        sql = "Select * From Billing_S2_DictIndex_Task Where Task_Order=1"
        Dim dtTaskCurrent As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTaskCurrent.Rows.Count > 0 Then
            Dept_Id_Biz = dtTaskCurrent.Rows(0).Item("Dept_Id_Biz")
            Dept_Text_Biz = dtTaskCurrent.Rows(0).Item("Dept_Text_Biz")
            Multi_Dept_Biz = dtTaskCurrent.Rows(0).Item("Multi_Dept_Biz")
            Task_Order_Current = dtTaskCurrent.Rows(0).Item("Task_Order")
            Task_Id_Current = dtTaskCurrent.Rows(0).Item("Id")
            Task_Text_Curent = dtTaskCurrent.Rows(0).Item("Task_Name")
            Dept_Id_Execute_Current = dtTaskCurrent.Rows(0).Item("Dept_Id_Execute")
            Dept_Text_Execute_Current = dtTaskCurrent.Rows(0).Item("Dept_Text_Execute")
            Multi_Dept_Execute = dtTaskCurrent.Rows(0).Item("Multi_Dept_Execute")
            Hour_Implement_Current = dtTaskCurrent.Rows(0).Item("Hour_Implement")
            Day_Implement_Current = dtTaskCurrent.Rows(0).Item("Day_Implement")
        Else
            Me.lblerror.Text = "Dữ liệu khởi tạo không hợp lệ !"
            Exit Sub
        End If
        sql = "Select * From Billing_S2_DictIndex_Task Where Task_Order=2"
        Dim dtTaskNext As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTaskNext.Rows.Count > 0 Then
            Task_Order_Next = dtTaskNext.Rows(0).Item("Task_Order")
            Task_Id_Next = dtTaskNext.Rows(0).Item("Id")
            Task_Text_Next = dtTaskNext.Rows(0).Item("Task_Name")
            Hour_Implement_Next = dtTaskNext.Rows(0).Item("Hour_Implement")
            Day_Implement_Next = dtTaskNext.Rows(0).Item("Day_Implement")
        Else
            Me.lblerror.Text = "Dữ liệu khởi tạo không hợp lệ !"
            Exit Sub
        End If

        sql = "SELECT A.Id,A.TypeOfPartner,A.Department_Id,A.Department_Text,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,Isnull(A.Account_Report,'') Account_Report," & _
            " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Id Partner_Id,D.Partner_Text,D.Partner_Code,E.Dept_Code " & _
            " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
            " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
            " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
            " INNER JOIN System_Department E ON A.Department_Id=E.Id " & _
            " WHERE A.Contract_Status=1 And  A.Service_Id=" & Constants.ServiceInfo.Id.S2 & _
            " ORDER BY D.Partner_Code "
        Dim dtPartner As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Dim Total As Integer = 0
        If dtPartner.Rows.Count > 0 Then
            For i As Integer = 0 To dtPartner.Rows.Count - 1
                Dept_Id_Of = dtPartner.Rows(i).Item("Department_Id")
                Dept_Text_Of = dtPartner.Rows(i).Item("Department_Text")
                Dept_Code_Of = dtPartner.Rows(i).Item("Dept_Code")
                TypeOfPartner = dtPartner.Rows(i).Item("TypeOfPartner")
                Contract_Id = dtPartner.Rows(i).Item("Id")
                Contract_Code = dtPartner.Rows(i).Item("Contract_Code")
                Contract_Number = dtPartner.Rows(i).Item("Contract_Number")
                Partner_Id = dtPartner.Rows(i).Item("Partner_Id")
                Partner_Text = dtPartner.Rows(i).Item("Partner_Text")
                Partner_Code = dtPartner.Rows(i).Item("Partner_Code")
                Account_Report = dtPartner.Rows(i).Item("Account_Report")
                If Multi_Dept_Biz = 1 Then
                    Dept_Id_Biz = Dept_Id_Of
                    Dept_Text_Biz = Dept_Code_Of
                End If
                If Multi_Dept_Execute = 1 Then
                    Dept_Id_Execute_Current = Dept_Id_Of
                    Dept_Text_Execute_Current = Dept_Code_Of
                End If
                Try
                    InitData(Year, _
                              Month, _
                              TypeOfPartner, _
                              Dept_Id_Of, _
                              Dept_Text_Of, _
                              Contract_Id, _
                              Contract_Code, _
                              Contract_Number, _
                              Partner_Id, _
                              Partner_Text, _
                              Partner_Code, _
                              Account_Report, _
                              Dept_Id_Biz, _
                              Dept_Text_Biz, _
                              Multi_Dept_Biz, _
                              Task_Order_Current, _
                              Task_Id_Current, _
                              Task_Text_Curent, _
                              Task_Order_Next, _
                              Task_Id_Next, _
                              Task_Text_Next, _
                              Dept_Id_Execute_Current, _
                              Dept_Text_Execute_Current, _
                              Multi_Dept_Execute, _
                              Dept_Id_Execute_Next, _
                              Dept_Text_Execute_Next, _
                              Execute_Time, _
                              Status_Id, _
                              Status_Text, _
                              Total_Task, _
                              Hour_Implement_Current, _
                              Day_Implement_Current, _
                              Hour_Implement_Next, _
                              Day_Implement_Next, _
                              Total_Hour_Implement, _
                              Total_Day_Implement, _
                              Create_By_Id, _
                              Create_By_Text, _
                              Create_Time, _
                              Update_By_Id, _
                              Update_By_Text, _
                              Update_Time, _
                              Task_Log, _
                              Description)
                    Total = Total + 1
                Catch ex As Exception
                    Me.lblerror.Text = "Lỗi khởi tạo dữ liệu !. Mã lỗi: " & ex.Message
                    Exit Sub
                End Try
            Next
        Else
            Me.lblerror.Text = "Chưa có hợp đồng đối tác nào !"
            Exit Sub
        End If
        Me.lblerror.Text = "Tổng số dữ liệu được khởi tạo: " & Total & " hợp đồng"
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGrid.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
    Protected Sub btnExp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExp.Click
    End Sub

#End Region
#Region "Init Data"
    Private Function InitData(ByVal Year As Integer, _
                     ByVal Month As Integer, _
                     ByVal TypeOfPartner As Integer, _
                     ByVal Dept_Id_Of As Integer, _
                     ByVal Dept_Text_Of As String, _
                     ByVal Contract_Id As Integer, _
                     ByVal Contract_Code As String, _
                     ByVal Contract_Number As String, _
                     ByVal Partner_Id As Integer, _
                     ByVal Partner_Text As String, _
                     ByVal Partner_Code As String, _
                     ByVal Account_Report As String, _
                     ByVal Dept_Id_Biz As String, _
                     ByVal Dept_Text_Biz As String, _
                     ByVal Multi_Dept_Biz As Integer, _
                     ByVal Task_Order_Current As Integer, _
                     ByVal Task_Id_Current As Integer, _
                     ByVal Task_Text_Curent As String, _
                     ByVal Task_Order_Next As Integer, _
                     ByVal Task_Id_Next As Integer, _
                     ByVal Task_Text_Next As String, _
                     ByVal Dept_Id_Execute_Current As String, _
                     ByVal Dept_Text_Execute_Current As String, _
                     ByVal Multi_Dept_Execute As Integer, _
                     ByVal Dept_Id_Execute_Next As String, _
                     ByVal Dept_Text_Execute_Next As String, _
                     ByVal Execute_Time As String, _
                     ByVal Status_Id As Integer, _
                     ByVal Status_Text As String, _
                     ByVal Total_Task As Integer, _
                     ByVal Hour_Implement_Current As Decimal, _
                     ByVal Day_Implement_Current As Decimal, _
                     ByVal Hour_Implement_Next As Decimal, _
                     ByVal Day_Implement_Next As Decimal, _
                     ByVal Total_Hour_Implement As Decimal, _
                     ByVal Total_Day_Implement As Decimal, _
                     ByVal Create_By_Id As Integer, _
                     ByVal Create_By_Text As String, _
                     ByVal Create_Time As String, _
                     ByVal Update_By_Id As Integer, _
                     ByVal Update_By_Text As String, _
                     ByVal Update_Time As String, _
                     ByVal Task_Log As String, _
                     ByVal Description As String) As String

        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "Billing_S2_Work_Follow_Init_Data"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Year", SqlDbType.Int))
            .Parameters("@Year").Value = Year

            .Parameters.Add(New SqlParameter("@Month", SqlDbType.Int))
            .Parameters("@Month").Value = Month

            .Parameters.Add(New SqlParameter("@TypeOfPartner", SqlDbType.Int))
            .Parameters("@TypeOfPartner").Value = TypeOfPartner

            .Parameters.Add(New SqlParameter("@Dept_Id_Of", SqlDbType.Int))
            .Parameters("@Dept_Id_Of").Value = Dept_Id_Of

            .Parameters.Add(New SqlParameter("@Dept_Text_Of", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Of").Value = Dept_Text_Of

            .Parameters.Add(New SqlParameter("@Contract_Id", SqlDbType.Int))
            .Parameters("@Contract_Id").Value = Contract_Id

            .Parameters.Add(New SqlParameter("@Contract_Code", SqlDbType.NVarChar, 500))
            .Parameters("@Contract_Code").Value = Contract_Code

            .Parameters.Add(New SqlParameter("@Contract_Number", SqlDbType.NVarChar, 500))
            .Parameters("@Contract_Number").Value = Contract_Number

            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int))
            .Parameters("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Partner_Text").Value = Partner_Text

            .Parameters.Add(New SqlParameter("@Partner_Code", SqlDbType.NVarChar, 500))
            .Parameters("@Partner_Code").Value = Partner_Code

            .Parameters.Add(New SqlParameter("@Account_Report", SqlDbType.NVarChar, 500))
            .Parameters("@Account_Report").Value = Account_Report

            .Parameters.Add(New SqlParameter("@Dept_Id_Biz", SqlDbType.NVarChar, 50))
            .Parameters("@Dept_Id_Biz").Value = Dept_Id_Biz

            .Parameters.Add(New SqlParameter("@Dept_Text_Biz", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Biz").Value = Dept_Text_Biz

            .Parameters.Add(New SqlParameter("@Multi_Dept_Biz", SqlDbType.Int))
            .Parameters("@Multi_Dept_Biz").Value = Multi_Dept_Biz

            .Parameters.Add(New SqlParameter("@Task_Order_Current", SqlDbType.Int))
            .Parameters("@Task_Order_Current").Value = Task_Order_Current

            .Parameters.Add(New SqlParameter("@Task_Id_Current", SqlDbType.Int))
            .Parameters("@Task_Id_Current").Value = Task_Id_Current

            .Parameters.Add(New SqlParameter("@Task_Text_Curent", SqlDbType.NVarChar, 500))
            .Parameters("@Task_Text_Curent").Value = Task_Text_Curent

            .Parameters.Add(New SqlParameter("@Task_Order_Next", SqlDbType.Int))
            .Parameters("@Task_Order_Next").Value = Task_Order_Next

            .Parameters.Add(New SqlParameter("@Task_Id_Next", SqlDbType.Int))
            .Parameters("@Task_Id_Next").Value = Task_Id_Next

            .Parameters.Add(New SqlParameter("@Task_Text_Next", SqlDbType.NVarChar, 500))
            .Parameters("@Task_Text_Next").Value = Task_Text_Next

            .Parameters.Add(New SqlParameter("@Dept_Id_Execute_Current", SqlDbType.NVarChar, 50))
            .Parameters("@Dept_Id_Execute_Current").Value = Dept_Id_Execute_Current

            .Parameters.Add(New SqlParameter("@Dept_Text_Execute_Current", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Execute_Current").Value = Dept_Text_Execute_Current

            .Parameters.Add(New SqlParameter("@Multi_Dept_Execute", SqlDbType.Int))
            .Parameters("@Multi_Dept_Execute").Value = Multi_Dept_Execute

            .Parameters.Add(New SqlParameter("@Dept_Id_Execute_Next", SqlDbType.NVarChar, 50))
            .Parameters("@Dept_Id_Execute_Next").Value = Dept_Id_Execute_Next

            .Parameters.Add(New SqlParameter("@Dept_Text_Execute_Next", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Execute_Next").Value = Dept_Text_Execute_Next

            .Parameters.Add(New SqlParameter("@Execute_Time", SqlDbType.NVarChar, 500))
            .Parameters("@Execute_Time").Value = Execute_Time

            .Parameters.Add(New SqlParameter("@Status_Id", SqlDbType.Int))
            .Parameters("@Status_Id").Value = Status_Id

            .Parameters.Add(New SqlParameter("@Status_Text", SqlDbType.NVarChar, 50))
            .Parameters("@Status_Text").Value = Status_Text

            .Parameters.Add(New SqlParameter("@Total_Task", SqlDbType.Int))
            .Parameters("@Total_Task").Value = Total_Task

            .Parameters.Add(New SqlParameter("@Hour_Implement_Current", SqlDbType.Decimal))
            .Parameters("@Hour_Implement_Current").Value = Hour_Implement_Current

            .Parameters.Add(New SqlParameter("@Day_Implement_Current", SqlDbType.Decimal))
            .Parameters("@Day_Implement_Current").Value = Day_Implement_Current

            .Parameters.Add(New SqlParameter("@Hour_Implement_Next", SqlDbType.Decimal))
            .Parameters("@Hour_Implement_Next").Value = Hour_Implement_Next

            .Parameters.Add(New SqlParameter("@Day_Implement_Next", SqlDbType.Decimal))
            .Parameters("@Day_Implement_Next").Value = Day_Implement_Next

            .Parameters.Add(New SqlParameter("@Total_Hour_Implement", SqlDbType.Decimal))
            .Parameters("@Total_Hour_Implement").Value = Total_Hour_Implement

            .Parameters.Add(New SqlParameter("@Total_Day_Implement", SqlDbType.Decimal))
            .Parameters("@Total_Day_Implement").Value = Total_Day_Implement

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Task_Log", SqlDbType.NVarChar, 2000))
            .Parameters("@Task_Log").Value = Task_Log

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
            .Parameters("@Description").Value = Description
            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi khởi tạo dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        'Dim sql As String = "Delete  From  Billing_S2_DictIndex_Task  Where  Id =" & CType(e.CommandArgument, Integer)
        'Try
        '    MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        '    ViewState("DATA_GRID") = Nothing
        '    ViewState("DATA_COUNT") = Nothing
        '    Dim intPageSize As Integer = pager1.PageSize
        '    Dim intCurentPage As Integer = pager1.CurrentIndex
        '    BindData(intPageSize, intCurentPage, Constants.Action.Search)
        'Catch ex As Exception
        '    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        'End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
End Class
