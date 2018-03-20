Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiScratchCardCcare
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ THẺ CÀO - CHĂM SÓC KHÁCH HÀNG"
            BindDictIndex()
            InitStatus()
            SetTitle()
        End If
        Me.txtFileUploadQ1.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
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
    End Sub
#End Region
#Region "Init Status"
    Private Sub InitStatus()
        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
    End Sub
#End Region
#Region "Load Data"
    Private Sub LoadData()
        Dim intPageSizeQ1 As Integer = PagerQ1.PageSize
        Dim intCurentPageQ1 As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSizeQ1, intCurentPageQ1, Constants.Action.Search)
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
        Me.RadTime_StartQ1.SelectedDate = Now
        Me.RadTime_EndQ1.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ1.Items.Clear()
        DropDownListToHourQ1.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ1.Items.Clear()
        DropDownListToMinuteQ1.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ1.Items.Clear()
        DropDownListToSecondQ1.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ1.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_ScratchCard_Time_Handle_Ccare_Complain WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.ScratchCard.CcareComplain(sql, CurrentUser.UserName)

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
        If Me.txtComplain_TextQ1.Text = "" Then
            Me.lblerror.Text = "Nội dung khiếu nại không hợp lệ !"
            Exit Sub
        End If
        If Me.txtHandle_TextQ1.Text = "" Then
            Me.lblerror.Text = "Nội dung xử lý khiếu nại không hợp lệ !"
            Exit Sub
        End If
        Dim Complain_Text As String = Me.txtComplain_TextQ1.Text.Trim
        Dim Handle_Text As String = Me.txtHandle_TextQ1.Text.Trim
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian nhận KN phải nhỏ hơn thời gian xử lý"
            Exit Sub
        End If
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Ccare_Complain WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCcareComplainTimeHandle(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Insert_Time_Handle_Ccare_Complain"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Complain_Text", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Complain_Text").Value = Complain_Text

            .Parameters.Add(New SqlParameter("@Handle_Text", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Handle_Text").Value = Handle_Text

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
#Region "Update Data"
    Private Sub UpdateDataQ1()
        If Me.txtComplain_TextQ1.Text = "" Then
            Me.lblerror.Text = "Nội dung khiếu nại không hợp lệ !"
            Exit Sub
        End If
        If Me.txtHandle_TextQ1.Text = "" Then
            Me.lblerror.Text = "Nội dung xử lý khiếu nại không hợp lệ !"
            Exit Sub
        End If
        Dim Complain_Text As String = Me.txtComplain_TextQ1.Text.Trim
        Dim Handle_Text As String = Me.txtHandle_TextQ1.Text.Trim
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian nhận KN phải nhỏ hơn thời gian xử lý"
            Exit Sub
        End If
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Ccare_Complain WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCcareComplainTimeHandle(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Update_Time_Handle_Ccare_Complain"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Complain_Text", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Complain_Text").Value = Complain_Text

            .Parameters.Add(New SqlParameter("@Handle_Text", SqlDbType.NVarChar, 1000))
            .Parameters.Item("@Handle_Text").Value = Handle_Text

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
        Me.txtComplain_TextQ1.Text = ""
        Me.txtHandle_TextQ1.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ1_Click(sender As Object, e As EventArgs) Handles btnExpQ1.Click
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
    Protected Sub btnImportQ1_Click(sender As Object, e As EventArgs) Handles btnImportQ1.Click
        If Me.txtFileUploadQ1.Text.Trim = "" Then
            Me.lblerror.Text = "File import không hợp lệ !"
            Exit Sub
        End If
        If Me.txtSheetQ1.Text.Trim = "" Then
            Me.lblerror.Text = "Tên sheet không hợp lệ !"
            Exit Sub
        End If
        ImportQ1(Me.txtFileUploadQ1.Text.Trim, Me.txtSheetQ1.Text.Trim)
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnDelQ1_Click(sender As Object, e As EventArgs) Handles btDelQ1.Click
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
        Dim sql As String = "DELETE FROM Kpi_ScratchCard_Time_Handle_Ccare_Complain Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_Time_Handle_Ccare_Complain Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_StartQ1.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_EndQ1.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.txtComplain_TextQ1.Text = dt.Rows(0).Item("Complain_Text")
            Me.txtHandle_TextQ1.Text = dt.Rows(0).Item("Handle_Text")
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
            sql = "Delete From Kpi_ScratchCard_Time_Handle_Ccare_Complain  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub

#End Region
#Region "Import Data"
    Private Sub ImportQ1(ByVal xlsFile As String, ByVal Sheet As String)
        Dim sql As String = ""
        Dim TotalRecord As Integer = 0
        If xlsFile.EndsWith(".xls") = True Then
            sql = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 8.0"""
        ElseIf xlsFile.EndsWith(".xlsx") = True Then
            sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 12.0 Xml;HDR=YES"""
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
            Exit Sub
        End If
        Dim connFile As New OleDbConnection(sql)
        Try
            connFile.Open()
        Catch ex As Exception
            Me.lblerror.Text = " Error connect to excel file .Code: " & ex.Message
            Exit Sub
        End Try
        Dim strSqlStmt As String = "SELECT * FROM [" & Sheet & "$]"
        Dim daFile As OleDbDataAdapter
        Dim cmdFile As New OleDbCommand
        Dim dsFile As New DataSet
        With cmdFile
            .CommandType = CommandType.Text
            .CommandText = strSqlStmt
            .Connection = connFile
        End With
        Try
            daFile = New OleDbDataAdapter(cmdFile)
            daFile.Fill(dsFile, "Data_File")
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi đọc file excel. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        connFile.Close()
        connFile = Nothing
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Ccare_Complain WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Dim conn As New SqlConnection(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim Complain_Text As String = ""
        Dim Handle_Text As String = ""
        Dim Date_Id As String = ""
        Dim Date_Text As String = ""
        Dim Time_Start_Id As String = ""
        Dim Time_Start_Text As String = ""
        Dim Time_End_Id As String = ""
        Dim Time_End_Text As String = ""

        Dim Total_Sec As Integer = 0
        Dim Total_Min As Decimal = 0
        Dim Total_Hour As Decimal = 0
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
        End If
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = "Import"

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                If dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim <> "" Then
                    Dim vDate_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim, Constants.CultureInfo.culture_En)
                    Date_Id = DateTime.Parse(vDate_Id).ToString("yyyy-MM-dd")
                    Date_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd")
                    Complain_Text = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                    Handle_Text = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim
                    Dim vTime_Start_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim, Constants.CultureInfo.culture_En)
                    Time_Start_Id = DateTime.Parse(vTime_Start_Id).ToString("yyyy-MM-dd HH:mm:ss")
                    Time_Start_Text = DateTime.Parse(vTime_Start_Id).ToString("yyyyMMddHHmmss")
                    Dim vTime_End_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim, Constants.CultureInfo.culture_En)
                    Time_End_Id = DateTime.Parse(vTime_End_Id).ToString("yyyy-MM-dd HH:mm:ss")
                    Time_End_Text = DateTime.Parse(vTime_End_Id).ToString("yyyyMMddHHmmss")

                    Total_Sec = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
                    Total_Min = FormatNumber(Total_Sec / 60, 3, TriState.False)
                    Total_Hour = FormatNumber(Total_Min / 60, 3, TriState.False)
                    Decrease_Percent_Total = CaculateCcareComplainTimeHandle(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Hour)
                    Dim cmd As New SqlCommand
                    With cmd
                        .Parameters.Clear()
                        .Connection = GlobalConnection
                        .CommandText = "KPI_ScratchCard_Insert_Time_Handle_Ccare_Complain"
                        .CommandType = CommandType.StoredProcedure

                        .Parameters.Add(New SqlParameter("@Complain_Text", SqlDbType.NVarChar, 1000))
                        .Parameters.Item("@Complain_Text").Value = Complain_Text

                        .Parameters.Add(New SqlParameter("@Handle_Text", SqlDbType.NVarChar, 1000))
                        .Parameters.Item("@Handle_Text").Value = Handle_Text

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
                End If
            Next
        End If

        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số bản ghi: " & TotalRecord
    End Sub
#End Region
#End Region
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Days & " ngày, " & t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateCcareComplainTimeHandle(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateCcareComplainTotal(ByVal Standar_Threshold_Handle As Integer, _
                                       ByVal Standar_Threshold_Handle_Over As Integer, _
                                       ByVal Decrease_Percent As Integer, _
                                       ByVal Decrease_Percent_Max As Integer, _
                                       ByVal Total_Complain As Integer) As Integer
        Dim retval As Integer = 0
        If Total_Complain <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Complain - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
End Class