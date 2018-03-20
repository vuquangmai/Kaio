Imports System.Data.SqlClient

Public Class KpiLotInputData
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ XỔ SỐ - CHẤT LƯỢNG NHẬP LIỆU"
            BindDictIndex()
            InitStatus()
            SetTitle()
        End If
        LoadData()
    End Sub
#End Region
#Region "Load Data"
    Private Sub LoadData()
        Dim intPageSizeQ1 As Integer = PagerQ1.PageSize
        Dim intCurentPageQ1 As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSizeQ1, intCurentPageQ1, Constants.Action.Search)

        Dim intPageSizeQ2 As Integer = PagerQ2.PageSize
        Dim intCurentPageQ2 As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSizeQ2, intCurentPageQ2, Constants.Action.Search)

        Dim intPageSizeQ3 As Integer = PagerQ3.PageSize
        Dim intCurentPageQ3 As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSizeQ3, intCurentPageQ3, Constants.Action.Search)

        Dim intPageSizeQ4 As Integer = PagerQ4.PageSize
        Dim intCurentPageQ4 As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSizeQ4, intCurentPageQ4, Constants.Action.Search)
    End Sub
#End Region
#Region "Set Title"
    Private Sub SetTitle()
        If ViewState("Status_Q1") = Constants.Action.Insert Then
            Me.lbltitle_Q1.Text = "Thêm mới dữ liệu"
        ElseIf ViewState("Status_Q1") = Constants.Action.Update Then
            Me.lbltitle_Q1.Text = "Sửa đổi dữ liệu"
        End If
        If ViewState("Status_Q2") = Constants.Action.Insert Then
            Me.lbltitle_Q2.Text = "Thêm mới dữ liệu"
        ElseIf ViewState("Status_Q2") = Constants.Action.Update Then
            Me.lbltitle_Q2.Text = "Sửa đổi dữ liệu"
        End If
        If ViewState("Status_Q3") = Constants.Action.Insert Then
            Me.lbltitle_Q3.Text = "Thêm mới dữ liệu"
        ElseIf ViewState("Status_Q3") = Constants.Action.Update Then
            Me.lbltitle_Q3.Text = "Sửa đổi dữ liệu"
        End If
        If ViewState("Status_Q4") = Constants.Action.Insert Then
            Me.lbltitle_Q4.Text = "Thêm mới dữ liệu"
        ElseIf ViewState("Status_Q4") = Constants.Action.Update Then
            Me.lbltitle_Q4.Text = "Sửa đổi dữ liệu"
        End If
    End Sub
#End Region
#Region "Init Status"
    Private Sub InitStatus()
        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
        ViewState("Id_Q2") = 0
        ViewState("Status_Q2") = Constants.Action.Insert
        ViewState("Id_Q3") = 0
        ViewState("Status_Q3") = Constants.Action.Insert
        ViewState("Id_Q4") = 0
        ViewState("Status_Q4") = Constants.Action.Insert
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
        BindProvinceQ1()
        BindProvinceQ2()
        BindProvinceQ3()
        BindErrorCodeQ3()
        BindErrorCodeQ4()
        InitTime()
    End Sub
    Private Sub BindDate()
        Me.RadDateQ1.SelectedDate = Now
        Me.RadDate_1Q2.SelectedDate = Now
        Me.RadDate_2Q2.SelectedDate = Now
        Me.RadDateQ3.SelectedDate = Now
        Me.RadDateQ4.SelectedDate = Now
        Me.RadToDateQ4.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ1.Items.Clear()
        DropDownListToHourQ1.Items.Clear()
        DropDownListToHourQ2.Items.Clear()
        DropDownListFromHourQ3.Items.Clear()
        DropDownListToHourQ3.Items.Clear()
        DropDownListFromHourQ4.Items.Clear()
        DropDownListToHourQ4.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ1.Items.Clear()
        DropDownListToMinuteQ1.Items.Clear()
        DropDownListToMinuteQ2.Items.Clear()
        DropDownListFromMinuteQ3.Items.Clear()
        DropDownListToMinuteQ3.Items.Clear()
        DropDownListFromMinuteQ4.Items.Clear()
        DropDownListToMinuteQ4.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ1.Items.Clear()
        DropDownListToSecondQ1.Items.Clear()
        DropDownListToSecondQ2.Items.Clear()
        DropDownListFromSecondQ3.Items.Clear()
        DropDownListToSecondQ3.Items.Clear()
        DropDownListFromSecondQ4.Items.Clear()
        DropDownListToSecondQ4.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindProvinceQ1()
        Dim DayOfWeek As Integer = Util.DateTimeFomat.GetDayOfWeek(Util.DateTimeFomat.Timestamp2DDMMYYYY(Me.RadDateQ1.SelectedDate.Value, "/"))
        Dim sql As String = "SELECT B.* FROM Lottery_Company_Schedule A Inner Join Lottery_Company B On A.Company_Id=B.Company_Id WHERE A.Schedule=" & DayOfWeek & " AND B.Company_Region='" & Me.DropDownListRegionQ1.SelectedItem.Value & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ1.Items.Clear()
        Me.DropDownListProvinceQ1.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ1.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub BindProvinceQ2()
        Dim DayOfWeek As Integer = Util.DateTimeFomat.GetDayOfWeek(Util.DateTimeFomat.Timestamp2DDMMYYYY(Me.RadDate_1Q2.SelectedDate.Value, "/"))
        Dim sql As String = "SELECT B.* FROM Lottery_Company_Schedule A Inner Join Lottery_Company B On A.Company_Id=B.Company_Id WHERE A.Schedule=" & DayOfWeek & " AND B.Company_Region='" & Me.DropDownListRegionQ2.SelectedItem.Value & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ2.Items.Clear()
        Me.DropDownListProvinceQ2.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ2.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub BindProvinceQ3()
        Dim DayOfWeek As Integer = Util.DateTimeFomat.GetDayOfWeek(Util.DateTimeFomat.Timestamp2DDMMYYYY(Me.RadDateQ3.SelectedDate.Value, "/"))
        Dim sql As String = "SELECT B.* FROM Lottery_Company_Schedule A Inner Join Lottery_Company B On A.Company_Id=B.Company_Id WHERE A.Schedule=" & DayOfWeek & " AND B.Company_Region='" & Me.DropDownListRegionQ3.SelectedItem.Value & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ3.Items.Clear()
        Me.DropDownListProvinceQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ3.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub InitTime()
        Select Case Me.DropDownListRegionQ1.SelectedItem.Value
            Case "BAC"
                Me.DropDownListFromHourQ1.SelectedValue = "18"
                Me.DropDownListToHourQ1.SelectedValue = "18"
                Me.DropDownListFromMinuteQ1.SelectedValue = "15"
                Me.DropDownListToMinuteQ1.SelectedValue = "15"
            Case "TRUNG"
                Me.DropDownListFromHourQ1.SelectedValue = "17"
                Me.DropDownListToHourQ1.SelectedValue = "17"
                Me.DropDownListFromMinuteQ1.SelectedValue = "15"
                Me.DropDownListToMinuteQ1.SelectedValue = "15"
            Case "NAM"
                Me.DropDownListFromHourQ1.SelectedValue = "16"
                Me.DropDownListToHourQ1.SelectedValue = "16"
                Me.DropDownListFromMinuteQ1.SelectedValue = "15"
                Me.DropDownListToMinuteQ1.SelectedValue = "15"
        End Select
    End Sub
    Private Sub BindErrorCodeQ3()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Input_Data_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ3.Items.Clear()
        Me.DropDownListErrorCodeQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ3.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindErrorCodeQ4()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Input_Software_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ4.Items.Clear()
        Me.DropDownListErrorCodeQ4.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ4.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
#End Region
#Region "Q1"
#Region "Ajax"
    Protected Sub DropDownListRegionQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ1.SelectedIndexChanged
        InitTime()
        BindProvinceQ1()
    End Sub
    Protected Sub RadDateQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ1.SelectedDateChanged
        BindProvinceQ1()
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Pager"
    Protected Sub Pager_CommandQ1(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PagerQ1.Command
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        PagerQ1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ1(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text desc ) as RowNumber  FROM Kpi_Lot_Input_Data Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ1.SelectedDate.Value, "") & "'"
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q1") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q1"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q1"), DataTable)
            End If
            ViewState("DATA_GRID_Q1") = dt
            ViewState("DATA_COUNT_Q1") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGridQ1.DataSource = dt
                Me.DataGridQ1.DataBind()
                Me.DataGridQ1.Visible = True
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ1.Items
                    thisButton = gridrow.FindControl("DeleterQ1")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next

                Me.PagerQ1.Visible = True
                PagerQ1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Else
                Me.DataGridQ1.Visible = False
                Me.PagerQ1.Visible = False
            End If
        Else
            ExportData.ExportExcel._KPI.Lott.InputDataLot(sql, CurrentUser.UserName)
        End If
    End Sub
#End Region
#Region "Update Data"
    Private Sub UpdateDataQ1()
        If Me.DropDownListProvinceQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Tỉnh không hợp lệ !"
            Exit Sub
        End If
        Dim Region_Id As String = Me.DropDownListRegionQ1.SelectedItem.Value
        Dim Region_Text As String = Me.DropDownListRegionQ1.SelectedItem.Text
        Dim Company_Id As Integer = Me.DropDownListProvinceQ1.SelectedItem.Value
        Dim Company_Text As String = Me.DropDownListProvinceQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Data WHERE Criteria_Id=" & Company_Id
        If Me.DropDownListRegionQ1.SelectedItem.Value = "TRUNG" Then ' Miền trung không phân biệt theo tỉnh
            sql = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Data WHERE Criteria_Id=" & 3
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateInputData(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Input_Data"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Id", SqlDbType.Int))
            .Parameters.Item("@Company_Id").Value = Company_Id

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent").Value = Decrease_Percent

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max").Value = Decrease_Percent_Max

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters.Item("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters.Item("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdateQ1_Click(sender As Object, e As EventArgs) Handles btnUpdateQ1.Click
        UpdateDataQ1()
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
        SetTitle()
    End Sub
    Protected Sub btnExpQ1_Click(sender As Object, e As EventArgs) Handles btnExpQ1.Click
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Lot_Input_Data Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q1") = Nothing
            ViewState("DATA_COUNT_Q1") = Nothing
            Dim intPageSize As Integer = PagerQ1.PageSize
            Dim intCurentPage As Integer = PagerQ1.CurrentIndex
            BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
            ViewState("Id_Q1") = 0
            ViewState("Status_Q1") = Constants.Action.Insert
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try
    End Sub
#End Region
#Region "Edit Data"
    Sub EditQ1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        ViewState("Id_Q1") = CType(e.CommandArgument, Integer)
        ViewState("Status_Q1") = Constants.Action.Update
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Input_Data Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListRegionQ1.Text = dt.Rows(0).Item("Region_Id")
            BindProvinceQ1()
            Me.DropDownListProvinceQ1.SelectedValue = dt.Rows(0).Item("Company_Id")
            Me.DropDownListFromHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
#Region "Q2"
#Region "Ajax"
    Protected Sub DropDownListRegionQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ2.SelectedIndexChanged
        InitTime()
        BindProvinceQ2()
    End Sub
    Protected Sub RadDateQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_1Q2.SelectedDateChanged
        BindProvinceQ2()
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text desc ) as RowNumber  FROM Kpi_Lot_Input_LuckyNumber Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_1Q2.SelectedDate.Value, "") & "'"
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q2") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q2"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q2"), DataTable)
            End If
            ViewState("DATA_GRID_Q2") = dt
            ViewState("DATA_COUNT_Q2") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGridQ2.DataSource = dt
                Me.DataGridQ2.DataBind()
                Me.DataGridQ2.Visible = True
                Me.PagerQ2.Visible = True
                PagerQ2.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ2.Items
                    thisButton = gridrow.FindControl("DeleterQ2")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
            Else
                Me.DataGridQ2.Visible = False
                Me.PagerQ2.Visible = False
            End If
        Else
            ExportData.ExportExcel._KPI.Lott.InputDataLuckyNumber(sql, CurrentUser.UserName)

        End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub Pager_CommandQ2(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PagerQ2.Command
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        PagerQ2.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Update Data"
    Private Sub UpdateDataQ2()
     
        Dim Region_Id As String = Me.DropDownListRegionQ2.SelectedItem.Value
        Dim Region_Text As String = Me.DropDownListRegionQ2.SelectedItem.Text
        Dim Company_Id As Integer = Me.DropDownListProvinceQ2.SelectedItem.Value
        Dim Company_Text As String = Me.DropDownListProvinceQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_1Q2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_1Q2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = ""
        Dim Time_Start_Text As String = ""
        Dim Time_End_Id As String = ""
        Dim Time_End_Text As String = ""
        Dim Total_Sec As Decimal = 0 ' DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = 0 ' FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = 0 ' FormatNumber(Total_Min / 60, 3, TriState.False)

        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim sql As String = "SELECT*  FROM Kpi_Lot_DictIndex_Input_LuckyNumber "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")

            Time_Start_Id = DateTime.Parse(Me.RadDate_1Q2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Standar_Threshold_Handle & ":00:00"
            Time_Start_Text = DateTime.Parse(Me.RadDate_1Q2.SelectedDate.Value).ToString("yyyyMMdd") & Standar_Threshold_Handle & "0000"
            Time_End_Id = DateTime.Parse(Me.RadDate_2Q2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
            Time_End_Text = DateTime.Parse(Me.RadDate_2Q2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value

            Total_Sec = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
            Total_Min = FormatNumber(Total_Sec / 60, 3, TriState.False)
            Total_Hour = FormatNumber(Total_Min / 60, 3, TriState.False)

            Decrease_Percent_Total = CaculateInputLuckyNumber(Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Hour)
        End If
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
      
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Input_LuckyNumber"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Id", SqlDbType.Int))
            .Parameters.Item("@Company_Id").Value = Company_Id

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent").Value = Decrease_Percent

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max").Value = Decrease_Percent_Max

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters.Item("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters.Item("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdateQ2_Click(sender As Object, e As EventArgs) Handles btnUpdateQ2.Click
        If Me.DropDownListProvinceQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Tỉnh không hợp lệ !"
            Exit Sub
        End If
        UpdateDataQ2()
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
        ViewState("Id_Q2") = 0
        ViewState("Status_Q2") = Constants.Action.Insert
        SetTitle()
    End Sub
    Protected Sub btnExpQ2_Click(sender As Object, e As EventArgs) Handles btnExpQ2.Click
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Lot_Input_LuckyNumber Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q2") = Nothing
            ViewState("DATA_COUNT_Q2") = Nothing
            Dim intPageSize As Integer = PagerQ2.PageSize
            Dim intCurentPage As Integer = PagerQ2.CurrentIndex
            BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
            ViewState("Id_Q2") = 0
            ViewState("Status_Q2") = Constants.Action.Insert
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try
    End Sub
#End Region
#Region "Edit Data"
    Sub EditQ2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        ViewState("Id_Q2") = CType(e.CommandArgument, Integer)
        ViewState("Status_Q2") = Constants.Action.Update
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Input_LuckyNumber Where Id=" & ViewState("Id_Q2")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_1Q2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadDate_1Q2.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListRegionQ2.Text = dt.Rows(0).Item("Region_Id")
            BindProvinceQ2()
            Me.DropDownListProvinceQ2.SelectedValue = dt.Rows(0).Item("Company_Id")
            Me.DropDownListToHourQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
#Region "Q3"
#Region "Ajax"
    Protected Sub DropDownListRegionQ3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ3.SelectedIndexChanged
        InitTime()
        BindProvinceQ3()
    End Sub
    Protected Sub RadDateQ3_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ3.SelectedDateChanged
        BindProvinceQ3()
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ3(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""

        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text desc ) as RowNumber  FROM Kpi_Lot_Input_Data_Error Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "") & "'"
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q3") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q3"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q3"), DataTable)
            End If
            ViewState("DATA_GRID_Q3") = dt
            ViewState("DATA_COUNT_Q3") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGridQ3.DataSource = dt
                Me.DataGridQ3.DataBind()
                Me.DataGridQ3.Visible = True
                Me.PagerQ3.Visible = True
                PagerQ3.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ3.Items
                    thisButton = gridrow.FindControl("DeleterQ3")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
            Else
                Me.DataGridQ3.Visible = False
                Me.PagerQ3.Visible = False
            End If
        Else
            ExportData.ExportExcel._KPI.Lott.InputDataErr(sql, CurrentUser.UserName)
        End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub Pager_CommandQ3(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PagerQ3.Command
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        PagerQ3.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Insert Data"
    Private Sub InsertDataQ3()
        Dim Region_Id As String = Me.DropDownListRegionQ3.SelectedItem.Value
        Dim Region_Text As String = Me.DropDownListRegionQ3.SelectedItem.Text
        Dim Company_Id As Integer = Me.DropDownListProvinceQ3.SelectedItem.Value
        Dim Company_Text As String = Me.DropDownListProvinceQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Total_Time As Integer = 0
        Dim Decrease_Percent_Error As Integer = 0
        Dim Decrease_Percent_Max_Error As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ3.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ3.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ3.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Data_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputDataError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Input_Data_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Id", SqlDbType.Int))
            .Parameters.Item("@Company_Id").Value = Company_Id

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Time").Value = Decrease_Percent_Total_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Error").Value = Decrease_Percent_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Error").Value = Decrease_Percent_Max_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Error_Id", SqlDbType.Int))
            .Parameters.Item("@Error_Id").Value = Error_Id

            .Parameters.Add(New SqlParameter("@Error_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Error_Text").Value = Error_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters.Item("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters.Item("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Update Data"
    Private Sub UpdateDataQ3()
        Dim Region_Id As String = Me.DropDownListRegionQ3.SelectedItem.Value
        Dim Region_Text As String = Me.DropDownListRegionQ3.SelectedItem.Text
        Dim Company_Id As Integer = Me.DropDownListProvinceQ3.SelectedItem.Value
        Dim Company_Text As String = Me.DropDownListProvinceQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Total_Time As Integer = 0
        Dim Decrease_Percent_Error As Integer = 0
        Dim Decrease_Percent_Max_Error As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ3.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ3.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ3.Text.Trim
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Data_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputDataError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Input_Data_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q3")

            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Id", SqlDbType.Int))
            .Parameters.Item("@Company_Id").Value = Company_Id

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Time").Value = Decrease_Percent_Total_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Error").Value = Decrease_Percent_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Error").Value = Decrease_Percent_Max_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Error_Id", SqlDbType.Int))
            .Parameters.Item("@Error_Id").Value = Error_Id

            .Parameters.Add(New SqlParameter("@Error_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Error_Text").Value = Error_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdateQ3_Click(sender As Object, e As EventArgs) Handles btnUpdateQ3.Click
        If Me.DropDownListProvinceQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Tỉnh không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListErrorCodeQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi hợp lệ !"
            Exit Sub
        End If
        If ViewState("Status_Q3") = Constants.Action.Insert Then
            InsertDataQ3()
        ElseIf ViewState("Status_Q3") = Constants.Action.Update Then
            UpdateDataQ3()
        End If
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)
        ViewState("Id_Q3") = 0
        ViewState("Status_Q3") = Constants.Action.Insert
        SetTitle()
    End Sub
    Protected Sub btnExpQ3_Click(sender As Object, e As EventArgs) Handles btnExpQ3.Click
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ3(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "DELETE FROM Kpi_Lot_Input_Data_Error Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q3") = Nothing
            ViewState("DATA_COUNT_Q3") = Nothing
            Dim intPageSize As Integer = PagerQ3.PageSize
            Dim intCurentPage As Integer = PagerQ3.CurrentIndex
            BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)
            ViewState("Id_Q3") = 0
            ViewState("Status_Q3") = Constants.Action.Insert
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try
    End Sub
#End Region
#Region "Edit Data"
    Sub EditQ3(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        ViewState("Id_Q3") = CType(e.CommandArgument, Integer)
        ViewState("Status_Q3") = Constants.Action.Update
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Input_Data_Error Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListRegionQ3.Text = dt.Rows(0).Item("Region_Id")
            BindProvinceQ3()
            Me.DropDownListProvinceQ3.SelectedValue = dt.Rows(0).Item("Company_Id")
            Me.DropDownListFromHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListErrorCodeQ3.SelectedValue = dt.Rows(0).Item("Error_Id")
            Me.txtError_DescQ3.Text = dt.Rows(0).Item("Error_Desc")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
#Region "Q4"
#Region "Ajax"
    Protected Sub RadDateQ4_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ4.SelectedDateChanged
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ4(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text desc ) as RowNumber  FROM Kpi_Lot_Input_Software_Error Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ4.SelectedDate.Value, "") & "'"
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q4") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q4"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q4"), DataTable)
            End If
            ViewState("DATA_GRID_Q4") = dt
            ViewState("DATA_COUNT_Q4") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGridQ4.DataSource = dt
                Me.DataGridQ4.DataBind()
                Me.DataGridQ4.Visible = True
                Me.PagerQ4.Visible = True
                PagerQ4.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ4.Items
                    thisButton = gridrow.FindControl("DeleterQ4")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
            Else
                Me.DataGridQ4.Visible = False
                Me.PagerQ4.Visible = False

            End If
        Else
            ExportData.ExportExcel._KPI.Lott.InputSoftwareErr(sql, CurrentUser.UserName)
        End If
    End Sub
#End Region
#Region "Insert Data"
    Private Sub InsertDataQ4()
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ4.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ4.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ4.SelectedItem.Value & Me.DropDownListFromMinuteQ4.SelectedItem.Value & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadToDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ4.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadToDateQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ4.SelectedItem.Value & Me.DropDownListToMinuteQ4.SelectedItem.Value & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Total_Time As Integer = 0
        Dim Decrease_Percent_Error As Integer = 0
        Dim Decrease_Percent_Max_Error As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ4.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ4.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ4.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Software_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputSoftwareError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Sec)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Input_Software_Error"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Time").Value = Decrease_Percent_Total_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Error").Value = Decrease_Percent_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Error").Value = Decrease_Percent_Max_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Error_Id", SqlDbType.Int))
            .Parameters.Item("@Error_Id").Value = Error_Id

            .Parameters.Add(New SqlParameter("@Error_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Error_Text").Value = Error_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters.Item("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters.Item("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Update Data"
    Private Sub UpdateDataQ4()
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ4.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ4.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ4.SelectedItem.Value & Me.DropDownListFromMinuteQ4.SelectedItem.Value & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadToDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ4.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadToDateQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ4.SelectedItem.Value & Me.DropDownListToMinuteQ4.SelectedItem.Value & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Total_Time As Integer = 0
        Dim Decrease_Percent_Error As Integer = 0
        Dim Decrease_Percent_Max_Error As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ4.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ4.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ4.Text.Trim
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
          Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Input_Software_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputSoftwareError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Sec)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Input_Software_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q4")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Time").Value = Decrease_Percent_Total_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Error").Value = Decrease_Percent_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Error", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Error").Value = Decrease_Percent_Max_Error

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

            .Parameters.Add(New SqlParameter("@Error_Id", SqlDbType.Int))
            .Parameters.Item("@Error_Id").Value = Error_Id

            .Parameters.Add(New SqlParameter("@Error_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Error_Text").Value = Error_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters.Item("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters.Item("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Description").Value = Description
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Cập nhật liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdateQ4_Click(sender As Object, e As EventArgs) Handles btnUpdateQ4.Click
        If Me.DropDownListErrorCodeQ4.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi không hợp lệ !"
            Exit Sub
        End If
        If ViewState("Status_Q4") = Constants.Action.Insert Then
            InsertDataQ4()
        ElseIf ViewState("Status_Q4") = Constants.Action.Update Then
            UpdateDataQ4()
        End If
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)
        ViewState("Id_Q4") = 0
        ViewState("Status_Q4") = Constants.Action.Insert
        SetTitle()
    End Sub
    Protected Sub btnExpQ4_Click(sender As Object, e As EventArgs) Handles btnExpQ4.Click
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ4(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "DELETE FROM Kpi_Lot_Input_Software_Error Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q4") = Nothing
            ViewState("DATA_COUNT_Q4") = Nothing
            Dim intPageSize As Integer = PagerQ4.PageSize
            Dim intCurentPage As Integer = PagerQ4.CurrentIndex
            BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)
            ViewState("Id_Q4") = 0
            ViewState("Status_Q4") = Constants.Action.Insert
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try

    End Sub
#End Region
#Region "Edit Data"
    Sub EditQ4(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        ViewState("Id_Q4") = CType(e.CommandArgument, Integer)
        ViewState("Status_Q4") = Constants.Action.Update
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Input_Software_Error Where Id=" & ViewState("Id_Q4")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ4.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadToDateQ4.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListErrorCodeQ4.SelectedValue = dt.Rows(0).Item("Error_Id")
            Me.txtError_DescQ4.Text = dt.Rows(0).Item("Error_Desc")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
#Region "Caculate"
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateInputData(ByVal Standar_Threshold_Handle As Integer, _
                                       ByVal Standar_Threshold_Handle_Over As Integer, _
                                       ByVal Decrease_Percent As Integer, _
                                       ByVal Decrease_Percent_Max As Integer, _
                                       ByVal Total_Min As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Min <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Min - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateInputLuckyNumber(ByVal Standar_Threshold_Handle_Over As Integer, _
                                     ByVal Decrease_Percent As Integer, _
                                     ByVal Decrease_Percent_Max As Integer, _
                                     ByVal Total_Hour As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Hour <= 0 Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate(Total_Hour / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateInputDataError(ByVal Standar_Threshold_Handle As Integer, _
                                           ByVal Standar_Threshold_Handle_Over As Integer, _
                                           ByVal Decrease_Percent As Integer, _
                                           ByVal Decrease_Percent_Max As Integer, _
                                           ByVal Total_Min As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Min <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Min - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateInputSoftwareError(ByVal Standar_Threshold_Handle As Integer, _
                                           ByVal Standar_Threshold_Handle_Over As Integer, _
                                           ByVal Decrease_Percent As Integer, _
                                           ByVal Decrease_Percent_Max As Integer, _
                                           ByVal Total_Sec As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Sec <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Sec - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
#End Region
  
End Class