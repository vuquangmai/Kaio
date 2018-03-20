Imports System.Data.SqlClient
Public Class KpiLotTechnicalQuality
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ XỔ SỐ - CHẤT LƯỢNG KỸ THUẬT"
            BindDictIndex()
            InitStatus()
            SetTitle()
        End If
        LoadData()
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
        If ViewState("Status_Q5") = Constants.Action.Insert Then
            Me.lbltitle_Q5.Text = "Thêm mới dữ liệu"
        ElseIf ViewState("Status_Q5") = Constants.Action.Update Then
            Me.lbltitle_Q5.Text = "Sửa đổi dữ liệu"
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
        ViewState("Id_Q5") = 0
        ViewState("Status_Q5") = Constants.Action.Insert
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

        Dim intPageSizeQ5 As Integer = PagerQ5.PageSize
        Dim intCurentPageQ5 As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSizeQ5, intCurentPageQ5, Constants.Action.Search)
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
        BindErrorCodeQ4()
    End Sub
    Private Sub BindDate()
        Me.RadDateQ1.SelectedDate = Now
        Me.RadDateQ2.SelectedDate = Now
        Me.RadDateQ3.SelectedDate = Now
        Me.RadDateQ4.SelectedDate = Now
        Me.RadToDateQ4.SelectedDate = Now
        Me.RadDateQ5.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ1.Items.Clear()
        DropDownListToHourQ1.Items.Clear()
        DropDownListFromHourQ4.Items.Clear()
        DropDownListToHourQ4.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ1.Items.Clear()
        DropDownListToMinuteQ1.Items.Clear()
        DropDownListFromMinuteQ4.Items.Clear()
        DropDownListToMinuteQ4.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ1.Items.Clear()
        DropDownListToSecondQ1.Items.Clear()
        DropDownListFromSecondQ4.Items.Clear()
        DropDownListToSecondQ4.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindErrorCodeQ4()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Technical_Quality_System_Error"
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
    Protected Sub RadDateQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ1.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM  Kpi_Lot_Technical_Quality_MT Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ1.SelectedDate.Value, "") & "'"
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
            Else
                Me.DataGridQ1.Visible = False
                Me.PagerQ1.Visible = False
            End If
        Else
            ExportData.ExportExcel._KPI.Lott.TechnicalMTHandset(sql, CurrentUser.UserName)
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
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
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
        Dim Percentage As Integer = 0
        Dim Decrease_Percent_Total_1 As Integer = 0 'Điểm trừ thời gian xử lý
        Dim Decrease_Percent_Total_2 As Integer = 0 'Điểm trừ thực tế
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & Mobile_Operator_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Percentage = dt.Rows(0).Item("Percentage")
            Decrease_Percent_Total_1 = CaculateTechnicalQualityMT(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            Decrease_Percent_Total_2 = (Decrease_Percent_Total_1 * Percentage) / 100
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Technical_Quality_MT"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

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

            .Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Int))
            .Parameters.Item("@Percentage").Value = Percentage

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_1").Value = Decrease_Percent_Total_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_2").Value = Decrease_Percent_Total_2

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
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
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
        Dim Percentage As Integer = 0
        Dim Decrease_Percent_Total_1 As Integer = 0 'Điểm trừ thời gian xử lý
        Dim Decrease_Percent_Total_2 As Integer = 0 'Điểm trừ thực tế
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & Mobile_Operator_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Percentage = dt.Rows(0).Item("Percentage")
            Decrease_Percent_Total_1 = CaculateTechnicalQualityMT(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            Decrease_Percent_Total_2 = (Decrease_Percent_Total_1 * Percentage) / 100
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Technical_Quality_MT"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

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

            .Parameters.Add(New SqlParameter("@Percentage", SqlDbType.Int))
            .Parameters.Item("@Percentage").Value = Percentage

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_1").Value = Decrease_Percent_Total_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_2").Value = Decrease_Percent_Total_2

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
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
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
        Dim sql As String = "DELETE FROM Kpi_Lot_Technical_Quality_MT Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Technical_Quality_MT Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListMobile_OperatorQ1.Text = dt.Rows(0).Item("Mobile_Operator_Id")
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
    Protected Sub RadDateQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ2.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM  Kpi_Lot_Technical_Quality_Handle Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Lott.TechnicalTimeProc(sql, CurrentUser.UserName)
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
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotalTime_Proc_Q2.Text.Trim
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_Handle"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalQualityHandle(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Technical_Quality_Handle"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal, 3))
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
#Region "Update Data"
    Private Sub UpdateDataQ2()
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotalTime_Proc_Q2.Text.Trim
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_Handle"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalQualityHandle(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Technical_Quality_Handle"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal, 3))
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
        'If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Mạng không hợp lệ !"
        '    Exit Sub
        'End If
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
        Dim sql As String = "DELETE FROM Kpi_Lot_Technical_Quality_Handle Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Technical_Quality_Handle Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtTotalTime_Proc_Q2.Text = dt.Rows(0).Item("Total_Sec")
            SetTitle()
        End If
    End Sub
#End Region
 
#End Region
#Region "Q3"
#Region "Ajax"
    Protected Sub RadDateQ3_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ3.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_Mobile_Operator Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Lott.TechnicalMTTelcos(sql, CurrentUser.UserName)
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
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ3.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotalTime_Proc_Q3.Text.Trim
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_Mobile_Operator"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalQualityMobileOperator(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Technical_Quality_Mobile_Operator"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal, 3))
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
#Region "Update Data"
    Private Sub UpdateDataQ3()
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ3.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ3.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ3.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotalTime_Proc_Q3.Text.Trim
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_Mobile_Operator"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalQualityMobileOperator(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Technical_Quality_Mobile_Operator"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q3")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal, 3))
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
        If Me.DropDownListMobile_OperatorQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
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
        Dim sql As String = "DELETE FROM Kpi_Lot_Technical_Quality_Mobile_Operator Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Technical_Quality_Mobile_Operator Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListMobile_OperatorQ3.Text = dt.Rows(0).Item("Mobile_Operator_Id")
            Me.RadDateQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtTotalTime_Proc_Q3.Text = dt.Rows(0).Item("Total_Sec")
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

        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_System_Error Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ4.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Lott.TechnicalSysErr(sql, CurrentUser.UserName)
        End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub Pager_CommandQ4(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PagerQ4.Command
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        PagerQ4.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_System_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateTechnicalSystemError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Technical_Quality_System_Error"
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
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ4.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ4.SelectedItem.Value & Me.DropDownListToMinuteQ4.SelectedItem.Value & Me.DropDownListToSecondQ4.SelectedItem.Value
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_System_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateTechnicalSystemError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Technical_Quality_System_Error"
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
        Dim sql As String = "DELETE FROM Kpi_Lot_Technical_Quality_System_Error Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Technical_Quality_System_Error Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListErrorCodeQ4.Text = dt.Rows(0).Item("Error_Id")
            Me.RadDateQ4.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtError_DescQ4.Text = dt.Rows(0).Item("Error_Desc")
            Me.DropDownListFromHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            SetTitle()
        End If
    End Sub
#End Region

#End Region
#Region "Q5"
#Region "Ajax"
    Protected Sub RadDateQ5_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ5.SelectedDateChanged
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ5(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""

        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_MT_Error Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ5.SelectedDate.Value, "") & "'"
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q5") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q5"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q5"), DataTable)
            End If
            ViewState("DATA_GRID_Q5") = dt
            ViewState("DATA_COUNT_Q5") = dtPageCount
            If dt.Rows.Count > 0 Then
                Me.DataGridQ5.DataSource = dt
                Me.DataGridQ5.DataBind()
                Me.DataGridQ5.Visible = True
                Me.PagerQ5.Visible = True
                PagerQ5.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
                Dim gridrow As DataGridItem
                Dim thisButton As ImageButton
                For Each gridrow In Me.DataGridQ5.Items
                    thisButton = gridrow.FindControl("DeleterQ5")
                    thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
                Next
            Else
                Me.DataGridQ5.Visible = False
                Me.PagerQ5.Visible = False
            End If
        Else
            ExportData.ExportExcel._KPI.Lott.TechnicalMTErr(sql, CurrentUser.UserName)
        End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub Pager_CommandQ5(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles PagerQ5.Command
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        PagerQ5.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Insert Data"
    Private Sub InsertDataQ5()
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " 00:00:00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyyMMdd") & "000000"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & " 00:00:00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyyMMdd") & "000000"
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Decimal = 0
        Dim Standar_Threshold_Handle_Over As Decimal = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Percent_Error As Decimal = Me.txtPercent_ErrorQ5.Text.Trim
        Dim Decrease_Percent_Total As Integer = 0
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtError_DescQ5.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_MT_Error WHERE Criteria_Id=" & 1
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalMTError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Percent_Error)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Technical_Quality_MT_Error"
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

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent").Value = Decrease_Percent

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max").Value = Decrease_Percent_Max

            .Parameters.Add(New SqlParameter("@Percent_Error", SqlDbType.Decimal))
            .Parameters.Item("@Percent_Error").Value = Percent_Error

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
    Private Sub UpdateDataQ5()
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " 00:00:00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyyMMdd") & "000000"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & " 00:00:00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDateQ5.SelectedDate.Value).ToString("yyyyMMdd") & "000000"
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Standar_Threshold_Handle As Decimal = 0
        Dim Standar_Threshold_Handle_Over As Decimal = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Percent_Error As Decimal = Me.txtPercent_ErrorQ5.Text.Trim
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtError_DescQ5.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Technical_Quality_MT_Error WHERE Criteria_Id=" & 1
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateTechnicalMTError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Percent_Error)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Technical_Quality_MT_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q5")

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

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Decrease_Percent", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent").Value = Decrease_Percent

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max").Value = Decrease_Percent_Max

            .Parameters.Add(New SqlParameter("@Percent_Error", SqlDbType.Decimal))
            .Parameters.Item("@Percent_Error").Value = Percent_Error

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
    Protected Sub btnUpdateQ5_Click(sender As Object, e As EventArgs) Handles btnUpdateQ5.Click
        If ViewState("Status_Q5") = Constants.Action.Insert Then
            InsertDataQ5()
        ElseIf ViewState("Status_Q5") = Constants.Action.Update Then
            UpdateDataQ5()
        End If
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
        ViewState("Id_Q5") = 0
        ViewState("Status_Q5") = Constants.Action.Insert
        SetTitle()
    End Sub
    Protected Sub btnExpQ5_Click(sender As Object, e As EventArgs) Handles btnExpQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ5(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "DELETE FROM Kpi_Lot_Technical_Quality_MT_Error Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q5") = Nothing
            ViewState("DATA_COUNT_Q5") = Nothing
            Dim intPageSize As Integer = PagerQ5.PageSize
            Dim intCurentPage As Integer = PagerQ5.CurrentIndex
            BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
            ViewState("Id_Q5") = 0
            ViewState("Status_Q5") = Constants.Action.Insert
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try
    End Sub
#End Region
#Region "Edit Data"
    Sub EditQ5(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        ViewState("Id_Q5") = CType(e.CommandArgument, Integer)
        ViewState("Status_Q5") = Constants.Action.Update
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Technical_Quality_MT_Error Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ5.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtPercent_ErrorQ5.Text = dt.Rows(0).Item("Percent_Error")
            Me.txtError_DescQ5.Text = dt.Rows(0).Item("Description")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateTechnicalQualityMT(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTechnicalQualityHandle(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTechnicalQualityMobileOperator(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTechnicalSystemError(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTechnicalMTError(ByVal Standar_Threshold_Handle As Decimal, _
                                            ByVal Standar_Threshold_Handle_Over As Decimal, _
                                            ByVal Decrease_Percent As Integer, _
                                            ByVal Decrease_Percent_Max As Integer, _
                                            ByVal Percent_Error As Decimal) As Integer
        Dim retval As Integer = 0
        If Percent_Error <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Percent_Error - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
End Class
 