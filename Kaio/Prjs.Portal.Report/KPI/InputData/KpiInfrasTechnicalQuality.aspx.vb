Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiInfrasTechnicalQuality
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CHẤT LƯỢNG KỸ THUẬT KPI HẠ TẦNG"
            BindDictIndex()
            InitStatus()
            SetTitle()
            'CreateFolder()
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
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
        BindCriteriaIdQ1()
        BindCriteriaIdQ2()
        BindCriteriaIdQ3()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
        Me.RadTime_Start_IdQ1.SelectedDate = Now
        Me.RadTime_End_IdQ1.SelectedDate = Now
        Me.RadDate_IdQ2.SelectedDate = Now
        Me.RadTime_Start_IdQ2.SelectedDate = Now
        Me.RadTime_End_IdQ2.SelectedDate = Now
        Me.RadDate_IdQ3.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ1.Items.Clear()
        DropDownListToHourQ1.Items.Clear()
        DropDownListFromHourQ2.Items.Clear()
        DropDownListToHourQ2.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ1.Items.Clear()
        DropDownListToMinuteQ1.Items.Clear()
        DropDownListFromMinuteQ2.Items.Clear()
        DropDownListToMinuteQ2.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ1.Items.Clear()
        DropDownListToSecondQ1.Items.Clear()
        DropDownListFromSecondQ2.Items.Clear()
        DropDownListToSecondQ2.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindCriteriaIdQ1()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Technical_Quality_System_DownTime"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ1.Items.Clear()
        Me.DropDownListCriteria_IdQ1.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ2()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ2.Items.Clear()
        Me.DropDownListCriteria_IdQ2.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ3()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Performance"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ3.Items.Clear()
        Me.DropDownListCriteria_IdQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region
#Region "Q1"
#Region "Ajax"
    Protected Sub RadDate_IdQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ1.SelectedDateChanged
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Technical_Quality_System_Downtime WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
                Me.PagerQ1.Visible = True
                PagerQ1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ1.Items
                    thisButton = gridrow.FindControl("DeleterQ1")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
                Me.lblTotalQ1.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ1.Visible = False
                Me.PagerQ1.Visible = False
                Me.lblTotalQ1.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.TechnicalQualitySystemDowntime(sql, CurrentUser.UserName)
        End If
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
#Region "Insert Data"
    Private Sub InsertDataQ1()
        If Me.DropDownListCriteria_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ1.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value

        Dim Total_Sec As Decimal = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        If Total_Sec < 0 Then
            Me.lblerror.Text = "Thời gian phát hiện phải nhỏ hơn thời gian khắc phục sự cố !"
            Exit Sub
        End If
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

        Dim Standar_Threshold_Handle_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Over_Quantity As Integer = 0
        Dim Decrease_Percent_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Max_Quantity As Integer = 0
        Dim Decrease_Percent_Max_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Time As Integer = 0
        Dim Standar_Threshold_Handle_Over_Time As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Standar_Threshold_Handle_Max_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Quantity_Total As Integer = 0
        Dim Decrease_Percent_Time_Total As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Decrease_Percent_Max As Integer = 100

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_System_DownTime WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Quantity")
            Standar_Threshold_Handle_Over_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Over_Quantity")
            Decrease_Percent_Quantity = dt.Rows(0).Item("Decrease_Percent_Quantity")
            Standar_Threshold_Handle_Max_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Max_Quantity")
            Decrease_Percent_Max_Quantity = dt.Rows(0).Item("Decrease_Percent_Max_Quantity")
            Standar_Threshold_Handle_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Time")
            Standar_Threshold_Handle_Over_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Over_Time")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Standar_Threshold_Handle_Max_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Max_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Quantity_Total = CaculateQualityDownTime(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeDownTime(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Technical_Quality_System_Downtime"
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

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Quantity").Value = Standar_Threshold_Handle_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Quantity").Value = Standar_Threshold_Handle_Over_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity").Value = Decrease_Percent_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Quantity").Value = Standar_Threshold_Handle_Max_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Quantity").Value = Decrease_Percent_Max_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Time").Value = Standar_Threshold_Handle_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Time").Value = Standar_Threshold_Handle_Over_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Time").Value = Standar_Threshold_Handle_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity_Total").Value = Decrease_Percent_Quantity_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time_Total").Value = Decrease_Percent_Time_Total

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
#Region "Update Data"
    Private Sub UpdateDataQ1()
        If Me.DropDownListCriteria_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ1.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value

        Dim Total_Sec As Decimal = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        If Total_Sec < 0 Then
            Me.lblerror.Text = "Thời gian phát hiện phải nhỏ hơn thời gian khắc phục sự cố !"
            Exit Sub
        End If
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

        Dim Standar_Threshold_Handle_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Over_Quantity As Integer = 0
        Dim Decrease_Percent_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Max_Quantity As Integer = 0
        Dim Decrease_Percent_Max_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Time As Integer = 0
        Dim Standar_Threshold_Handle_Over_Time As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Standar_Threshold_Handle_Max_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Quantity_Total As Integer = 0
        Dim Decrease_Percent_Time_Total As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Decrease_Percent_Max As Integer = 100

        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_System_DownTime WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Quantity")
            Standar_Threshold_Handle_Over_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Over_Quantity")
            Decrease_Percent_Quantity = dt.Rows(0).Item("Decrease_Percent_Quantity")
            Standar_Threshold_Handle_Max_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Max_Quantity")
            Decrease_Percent_Max_Quantity = dt.Rows(0).Item("Decrease_Percent_Max_Quantity")
            Standar_Threshold_Handle_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Time")
            Standar_Threshold_Handle_Over_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Over_Time")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Standar_Threshold_Handle_Max_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Max_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Quantity_Total = CaculateQualityDownTime(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeDownTime(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Technical_Quality_System_Downtime"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

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

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Quantity").Value = Standar_Threshold_Handle_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Quantity").Value = Standar_Threshold_Handle_Over_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity").Value = Decrease_Percent_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Quantity").Value = Standar_Threshold_Handle_Max_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Quantity").Value = Decrease_Percent_Max_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Time").Value = Standar_Threshold_Handle_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Time").Value = Standar_Threshold_Handle_Over_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Time").Value = Standar_Threshold_Handle_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity_Total").Value = Decrease_Percent_Quantity_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time_Total").Value = Decrease_Percent_Time_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

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
        If ViewState("Status_Q1") = Constants.Action.Insert Then
            InsertDataQ1()
        ElseIf ViewState("Status_Q1") = Constants.Action.Update Then
            UpdateDataQ1()
        End If
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)

        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
        Me.txtError_DescQ1.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ1_Click(sender As Object, e As EventArgs) Handles btnExpQ1.Click
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub

    Protected Sub btDelQ1_Click(sender As Object, e As EventArgs) Handles btDelQ1.Click
        DelDataQ1()
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
#End Region
#Region "Del Data"
    Sub DelQ1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Infras_Technical_Quality_System_Downtime Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Technical_Quality_System_Downtime Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ1.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ1.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListCriteria_IdQ1.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtError_DescQ1.Text = dt.Rows(0).Item("Error_Desc")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Delete Data"
    Private Sub DelDataQ1()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGridQ1.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From Kpi_Infras_Technical_Quality_System_Downtime  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#End Region
#Region "Q2"
#Region "Ajax"
    Protected Sub RadDate_IdQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ2.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Technical_Quality_Server_Error WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "") & "'"
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
                Me.lblTotalQ2.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ2.Visible = False
                Me.PagerQ2.Visible = False
                Me.lblTotalQ2.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.TechnicalQualityServerError(sql, CurrentUser.UserName)
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
#Region "Insert Data"
    Private Sub InsertDataQ2()
        If Me.DropDownListCriteria_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ2.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ2.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ2.SelectedItem.Value & Me.DropDownListFromMinuteQ2.SelectedItem.Value & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value

        Dim Total_Sec As Decimal = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        If Total_Sec < 0 Then
            Me.lblerror.Text = "Thời gian phát hiện phải nhỏ hơn thời gian khắc phục sự cố !"
            Exit Sub
        End If
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

        Dim Standar_Threshold_Handle_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Over_Quantity As Integer = 0
        Dim Decrease_Percent_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Max_Quantity As Integer = 0
        Dim Decrease_Percent_Max_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Time As Integer = 0
        Dim Standar_Threshold_Handle_Over_Time As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Standar_Threshold_Handle_Max_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Quantity_Total As Integer = 0
        Dim Decrease_Percent_Time_Total As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Decrease_Percent_Max As Integer = 100

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Error WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = 0
            Standar_Threshold_Handle_Over_Quantity = 0
            Decrease_Percent_Quantity = 0
            Standar_Threshold_Handle_Max_Quantity = 0
            Decrease_Percent_Max_Quantity = 0
            Standar_Threshold_Handle_Time = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent")
            Standar_Threshold_Handle_Max_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Max")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Quantity_Total = 0
            Decrease_Percent_Time_Total = CaculateServerError(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Technical_Quality_Server_Error"
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

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Quantity").Value = Standar_Threshold_Handle_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Quantity").Value = Standar_Threshold_Handle_Over_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity").Value = Decrease_Percent_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Quantity").Value = Standar_Threshold_Handle_Max_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Quantity").Value = Decrease_Percent_Max_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Time").Value = Standar_Threshold_Handle_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Time").Value = Standar_Threshold_Handle_Over_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Time").Value = Standar_Threshold_Handle_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity_Total").Value = Decrease_Percent_Quantity_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time_Total").Value = Decrease_Percent_Time_Total

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
#Region "Update Data"
    Private Sub UpdateDataQ2()
        If Me.DropDownListCriteria_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ2.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ2.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ2.SelectedItem.Value & Me.DropDownListFromMinuteQ2.SelectedItem.Value & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value

        Dim Total_Sec As Decimal = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        If Total_Sec < 0 Then
            Me.lblerror.Text = "Thời gian phát hiện phải nhỏ hơn thời gian khắc phục sự cố !"
            Exit Sub
        End If
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

        Dim Standar_Threshold_Handle_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Over_Quantity As Integer = 0
        Dim Decrease_Percent_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Max_Quantity As Integer = 0
        Dim Decrease_Percent_Max_Quantity As Integer = 0
        Dim Standar_Threshold_Handle_Time As Integer = 0
        Dim Standar_Threshold_Handle_Over_Time As Integer = 0
        Dim Decrease_Percent_Time As Integer = 0
        Dim Standar_Threshold_Handle_Max_Time As Integer = 0
        Dim Decrease_Percent_Max_Time As Integer = 0
        Dim Decrease_Percent_Quantity_Total As Integer = 0
        Dim Decrease_Percent_Time_Total As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Decrease_Percent_Max As Integer = 100

        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
          Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Error WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = 0
            Standar_Threshold_Handle_Over_Quantity = 0
            Decrease_Percent_Quantity = 0
            Standar_Threshold_Handle_Max_Quantity = 0
            Decrease_Percent_Max_Quantity = 0
            Standar_Threshold_Handle_Time = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent")
            Standar_Threshold_Handle_Max_Time = dt.Rows(0).Item("Standar_Threshold_Handle_Max")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Quantity_Total = 0
            Decrease_Percent_Time_Total = CaculateServerError(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Technical_Quality_Server_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

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

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal, 3))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Quantity").Value = Standar_Threshold_Handle_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Quantity").Value = Standar_Threshold_Handle_Over_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity").Value = Decrease_Percent_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Quantity").Value = Standar_Threshold_Handle_Max_Quantity

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Quantity", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Quantity").Value = Decrease_Percent_Max_Quantity

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Time").Value = Standar_Threshold_Handle_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Time").Value = Standar_Threshold_Handle_Over_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time").Value = Decrease_Percent_Time

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max_Time").Value = Standar_Threshold_Handle_Max_Time

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Time", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Time").Value = Decrease_Percent_Max_Time

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

            .Parameters.Add(New SqlParameter("@Error_Desc", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Error_Desc").Value = Error_Desc

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Quantity_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Quantity_Total").Value = Decrease_Percent_Quantity_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Time_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Time_Total").Value = Decrease_Percent_Time_Total

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

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
        If ViewState("Status_Q2") = Constants.Action.Insert Then
            InsertDataQ2()
        ElseIf ViewState("Status_Q2") = Constants.Action.Update Then
            UpdateDataQ2()
        End If
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)

        ViewState("Id_Q2") = 0
        ViewState("Status_Q2") = Constants.Action.Insert
        Me.txtError_DescQ2.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ2_Click(sender As Object, e As EventArgs) Handles btnExpQ2.Click
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub

    Protected Sub btDelQ2_Click(sender As Object, e As EventArgs) Handles btDelQ2.Click
        DelDataQ2()
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
#End Region
#Region "Del Data"
    Sub DelQ2(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Infras_Technical_Quality_Server_Error Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Technical_Quality_Server_Error Where Id=" & ViewState("Id_Q2")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ2.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ2.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListCriteria_IdQ2.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtError_DescQ2.Text = dt.Rows(0).Item("Error_Desc")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Delete Data"
    Private Sub DelDataQ2()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGridQ2.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From Kpi_Infras_Technical_Quality_Server_Error  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#End Region
#Region "Q3"
#Region "Ajax"
    Protected Sub RadDate_IdQ3_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ3.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Technical_Quality_Server_Performance WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "") & "'"
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
                Me.lblTotalQ3.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ3.Visible = False
                Me.PagerQ3.Visible = False
                Me.lblTotalQ3.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.TechnicalQualityServerPerformance(sql, CurrentUser.UserName)
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
        If Me.DropDownListCriteria_IdQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Tiêu chí không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ3.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Performance WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Point_Level")
            Decrease_Percent_Total = 100 - Standar_Threshold_Handle
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Technical_Quality_Server_Performance"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

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
#Region "Update Data"
    Private Sub UpdateDataQ3()
        If Me.DropDownListCriteria_IdQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Tiêu chí không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ3.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Performance WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Point_Level")
            Decrease_Percent_Total = 100 - Standar_Threshold_Handle
        End If
    
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Technical_Quality_Server_Performance"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q3")

           .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Criteria_Id", SqlDbType.Int))
            .Parameters.Item("@Criteria_Id").Value = Criteria_Id

            .Parameters.Add(New SqlParameter("@Criteria_Text", SqlDbType.NVarChar, 500))
            .Parameters.Item("@Criteria_Text").Value = Criteria_Text

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total").Value = Decrease_Percent_Total

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
        Me.txtDescriptionQ3.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ3_Click(sender As Object, e As EventArgs) Handles btnExpQ3.Click
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub

    Protected Sub btDelQ3_Click(sender As Object, e As EventArgs) Handles btDelQ3.Click
        DelDataQ3()
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
#End Region
#Region "Del Data"
    Sub DelQ3(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Infras_Technical_Quality_Server_Performance Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Technical_Quality_Server_Performance Where Id=" & ViewState("Id_Q3")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListCriteria_IdQ3.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtDescriptionQ3.Text = dt.Rows(0).Item("Description")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Delete Data"
    Private Sub DelDataQ3()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGridQ3.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From Kpi_Infras_Technical_Quality_Server_Performance  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#End Region
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Function ConvertTimeSS2DD(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return IIf(t.Days > 0, t.Days & " ngày, " & t.Hours & ":" & t.Minutes & ":" & t.Seconds, t.Hours & ":" & t.Minutes & ":" & t.Seconds)
    End Function
    Function ConvertTimeSS2HH(ByVal TotalSecond As Integer) As String
        Dim hours As Integer = TotalSecond / 3600
        Dim minutes As Integer = (TotalSecond Mod 3600) / 60
        Dim seconds As Integer = (TotalSecond Mod 3600) Mod 60
        Return hours & ":" & minutes & ":" & seconds
    End Function
    Private Function CaculateQualityDownTime(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTimeDownTime(ByVal Standar_Threshold_Handle As Integer, _
                                              ByVal Standar_Threshold_Handle_Over As Integer, _
                                              ByVal Standar_Threshold_Handle_Max As Integer, _
                                              ByVal Decrease_Percent_Max_Time As Integer, _
                                              ByVal Decrease_Percent As Integer, _
                                              ByVal Total_Min As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Min <= Standar_Threshold_Handle Then
            retval = 0
        Else
            If Total_Min >= Standar_Threshold_Handle_Max Then ' Nếu thời gian xử lý vượt quá ngưỡng tối đa thì điểm trừ bằng số điểm tối đa
                retval = Decrease_Percent_Max_Time
            Else
                Dim k As Integer = Math.Truncate((Total_Min - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
                retval = IIf(k * Decrease_Percent > Decrease_Percent_Max_Time, Decrease_Percent_Max_Time, k * Decrease_Percent)
            End If
        End If

        Return retval
    End Function
    Private Function CaculateServerError(ByVal Standar_Threshold_Handle As Integer, _
                                             ByVal Standar_Threshold_Handle_Over As Integer, _
                                             ByVal Standar_Threshold_Handle_Max As Integer, _
                                             ByVal Decrease_Percent_Max_Time As Integer, _
                                             ByVal Decrease_Percent As Integer, _
                                             ByVal Total_Min As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Min <= Standar_Threshold_Handle Then
            retval = 0
        Else
            If Total_Min >= Standar_Threshold_Handle_Max Then ' Nếu thời gian xử lý vượt quá ngưỡng tối đa thì điểm trừ bằng số điểm tối đa
                retval = Decrease_Percent_Max_Time
            Else
                Dim k As Integer = Math.Truncate((Total_Min - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
                retval = IIf(k * Decrease_Percent > Decrease_Percent_Max_Time, Decrease_Percent_Max_Time, k * Decrease_Percent)
            End If
        End If

        Return retval
    End Function
End Class