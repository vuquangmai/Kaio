Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiBrTechnicalQuality
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CHẤT LƯỢNG KỸ THUẬT"
            BindDictIndex()
            InitStatus()
            SetTitle()
            CreateFolder()
        End If
        Me.txtFileUploadQ1.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
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
        Dim intPageSizeQ5 As Integer = PagerQ5.PageSize
        Dim intCurentPageQ5 As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSizeQ5, intCurentPageQ5, Constants.Action.Search)
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
        ViewState("Id_Q5") = 0
        ViewState("Status_Q5") = Constants.Action.Insert
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
        BindRoutingQ1(Me.DropDownListTypeOf_IdQ1.SelectedItem.Value)
        BindErrorCodeQ3()
        BindErrorCodeQ5()

    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
        Me.RadDate_IdQ2.SelectedDate = Now
        Me.RadDate_IdQ3.SelectedDate = Now
        Me.RadTime_StartQ3.SelectedDate = Now
        Me.RadTime_EndQ3.SelectedDate = Now
        Me.RadDate_IdQ5.SelectedDate = Now
        Me.RadTime_StartQ5.SelectedDate = Now
        Me.RadTime_EndQ5.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ2.Items.Clear()
        DropDownListToHourQ2.Items.Clear()
        DropDownListFromHourQ3.Items.Clear()
        DropDownListToHourQ3.Items.Clear()
        DropDownListFromHourQ5.Items.Clear()
        DropDownListToHourQ5.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ2.Items.Clear()
        DropDownListToMinuteQ2.Items.Clear()
        DropDownListFromMinuteQ3.Items.Clear()
        DropDownListToMinuteQ3.Items.Clear()
        DropDownListFromMinuteQ5.Items.Clear()
        DropDownListToMinuteQ5.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ2.Items.Clear()
        DropDownListToSecondQ2.Items.Clear()
        DropDownListFromSecondQ3.Items.Clear()
        DropDownListToSecondQ3.Items.Clear()
        DropDownListFromSecondQ5.Items.Clear()
        DropDownListToSecondQ5.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ2.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindErrorCodeQ3()
        Dim sql As String = "SELECT * FROM Kpi_Br_DictIndex_Technical_Quality_System_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ3.Items.Clear()
        Me.DropDownListErrorCodeQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ3.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindErrorCodeQ5()
        Dim sql As String = "SELECT * FROM Kpi_Br_DictIndex_Input_Software_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ5.Items.Clear()
        Me.DropDownListErrorCodeQ5.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ5.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindRoutingQ1(ByVal TypeOf_Id As Integer)
        Dim sql As String = "SELECT * FROM Kpi_Br_DictIndex_Routing Where Status_Id=1 Order by Routing_Text"
        If TypeOf_Id > 0 Then
            sql = "SELECT * FROM Kpi_Br_DictIndex_Routing Where Status_Id=1 AND TypeOf_Id=" & TypeOf_Id & " Order by Routing_Text"
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListMobile_OperatorQ1.Items.Clear()
        Me.DropDownListMobile_OperatorQ1.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListMobile_OperatorQ1.Items.Add(New ListItem(dt.Rows(i).Item("Routing_Text"), dt.Rows(i).Item("Routing_Id")))
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Technical_Quality_MT_Telcos WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Brand.TechnicalQualityMTTelcos(sql, CurrentUser.UserName)
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
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại tin không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Sec_Q1.Text.Trim = "" Then
            Me.lblerror.Text = "Thời gian gửi tin không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRate_Delay_Q1.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ xử lý chậm không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotal_Sec_Q1.Text.Trim 'DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = 0
            If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 1 Then ' Quảng cáo
                Decrease_Percent_Total = CaculateQualityMTAdvTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
            ElseIf Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 2 Then 'CSKH
                Decrease_Percent_Total = CaculateQualityMTCcareTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            End If
        End If
        Dim Rate_Delay As Integer = Me.txtRate_Delay_Q1.Text.Trim 'DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Insert_Technical_Quality_MT_Telcos"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
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

            .Parameters.Add(New SqlParameter("@Rate_Delay", SqlDbType.Int))
            .Parameters.Item("@Rate_Delay").Value = Rate_Delay

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
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại tin không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Sec_Q1.Text.Trim = "" Then
            Me.lblerror.Text = "Thời gian gửi tin không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRate_Delay_Q1.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ xử lý chậm không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Total_Sec As Decimal = Me.txtTotal_Sec_Q1.Text.Trim 'DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = 0
            If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 1 Then ' Quảng cáo
                Decrease_Percent_Total = CaculateQualityMTAdvTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
            ElseIf Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 2 Then 'CSKH
                Decrease_Percent_Total = CaculateQualityMTCcareTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            End If
        End If
        Dim Rate_Delay As Integer = Me.txtRate_Delay_Q1.Text.Trim 'DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))

        Dim cmd As New SqlCommand
        With cmd


            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Update_Technical_Quality_MT_Telcos"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
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

            .Parameters.Add(New SqlParameter("@Rate_Delay", SqlDbType.Int))
            .Parameters.Item("@Rate_Delay").Value = Rate_Delay

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
        Me.txtTotal_Sec_Q1.Text = ""
        Me.txtRate_Delay_Q1.Text = ""
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
        Dim sql As String = "Delete from Kpi_Br_Technical_Quality_MT_Telcos Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Technical_Quality_MT_Telcos Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListMobile_OperatorQ1.Text = dt.Rows(0).Item("Mobile_Operator_Id")
            Me.DropDownListTypeOf_IdQ1.Text = dt.Rows(0).Item("TypeOf_Id")
            Me.txtTotal_Sec_Q1.Text = dt.Rows(0).Item("Total_Sec")
            Me.txtRate_Delay_Q1.Text = dt.Rows(0).Item("Rate_Delay")

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
            sql = "Delete From Kpi_Br_Technical_Quality_MT_Telcos  WHERE Id IN (" & vId & ")"
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
        'Load DictIndex Info
        sql = "SELECT *  FROM Kpi_Br_DictIndex_Routing "
        Dim dsMobileOperatorInfo As DataSet = MSSQLEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        sql = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT "
        Dim dsQualityMT As DataSet = MSSQLEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

        Dim conn As New SqlConnection(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = ""
        Dim TypeOf_Id As String = 0
        Dim TypeOf_Text As String = ""

        Dim Date_Id As String = ""
        Dim Date_Text As String = ""
        Dim Total_Sec As Decimal = 0
        Dim Total_Min As Decimal = 0
        Dim Total_Hour As Decimal = 0
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
        Dim Description As String = "Import"

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                Mobile_Operator_Text = dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim
                Dim FiltertMobileOperator As String = " Routing_Text='" & Mobile_Operator_Text & "'"
                Dim sourceMobileOperator As DataRow() = dsMobileOperatorInfo.Tables(0).Select(FiltertMobileOperator)
                If sourceMobileOperator.Length > 0 Then
                    Mobile_Operator_Id = sourceMobileOperator(0).Item("Routing_Id")
                End If
                TypeOf_Text = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                TypeOf_Text = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                If TypeOf_Text.ToUpper = "QUẢNG CÁO" Then
                    TypeOf_Id = 1
                ElseIf TypeOf_Text.ToUpper = "CHĂM SÓC KHÁCH HÀNG" Then
                    TypeOf_Id = 2
                End If

                If Mobile_Operator_Id > 0 And TypeOf_Id > 0 Then

                    Dim vDate_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim, Constants.CultureInfo.culture_En)
                    Date_Id = DateTime.Parse(vDate_Id).ToString("yyyy-MM-dd")
                    Date_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd")
                    Total_Sec = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim
                    Total_Min = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
                    Total_Hour = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

                    Dim FiltertQualityMT As String = " Criteria_Id=" & TypeOf_Id
                    Dim sourceQualityMT As DataRow() = dsQualityMT.Tables(0).Select(FiltertQualityMT)
                    If sourceQualityMT.Length > 0 Then
                        Standar_Threshold_Handle = sourceQualityMT(0).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over = sourceQualityMT(0).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent = sourceQualityMT(0).Item("Decrease_Percent")
                        Decrease_Percent_Max = sourceQualityMT(0).Item("Decrease_Percent_Max")

                        If TypeOf_Id = 1 Then ' Quảng cáo
                            Decrease_Percent_Total = CaculateQualityMTAdvTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
                        ElseIf TypeOf_Id = 2 Then 'CSKH
                            Decrease_Percent_Total = CaculateQualityMTCcareTelcos(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
                        End If
                        Dim Rate_Delay As Integer = dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim.Replace("%", "") * 100

                        Dim cmd As New SqlCommand
                        With cmd
                            .Parameters.Clear()
                            .Connection = GlobalConnection
                            .CommandText = "KPI_Br_Insert_Technical_Quality_MT_Telcos"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
                            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

                            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
                            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

                            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
                            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

                            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
                            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

                            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
                            .Parameters.Item("@Date_Id").Value = Date_Id

                            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
                            .Parameters.Item("@Date_Text").Value = Date_Text

                            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Decimal))
                            .Parameters.Item("@Total_Sec").Value = Total_Sec

                            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
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

                            .Parameters.Add(New SqlParameter("@Rate_Delay", SqlDbType.Int))
                            .Parameters.Item("@Rate_Delay").Value = Rate_Delay

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
                                TotalRecord = TotalRecord + 1
                            Catch ex As Exception
                                Me.lblerror.Text = ex.Message
                                Exit Sub
                            End Try
                        End With
                    End If
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
#Region "Q2"
#Region "Ajax"
    Protected Sub RadDate_IdQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ2.SelectedDateChanged
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub DropDownListUser_IdQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListUser_IdQ2.SelectedIndexChanged
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = Util.FormatOperator(Me.DropDownListUser_IdQ2.SelectedItem.Value)
        Select Case Mobile_Operator_Text
            Case "VMS"
                Mobile_Operator_Id = 1
            Case "VNP"
                Mobile_Operator_Id = 2
            Case "VIETTEL"
                Mobile_Operator_Id = 3
            Case "VNM"
                Mobile_Operator_Id = 4
            Case "GTEL"
                Mobile_Operator_Id = 5
        End Select
        Me.DropDownListMobile_OperatorQ2.SelectedValue = Mobile_Operator_Id
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Technical_Quality_MT_Handset WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Brand.TechnicalQualityMTHandset(sql, CurrentUser.UserName)
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
        If Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại tin không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListUser_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = Util.FormatOperator(Me.DropDownListUser_IdQ2.SelectedItem.Value)
        Select Case Mobile_Operator_Text
            Case "MOBI"
                Mobile_Operator_Id = 1
            Case "VINA"
                Mobile_Operator_Id = 2
            Case "VIETTEL"
                Mobile_Operator_Id = 3
            Case "VNM"
                Mobile_Operator_Id = 4
            Case "GTEL"
                Mobile_Operator_Id = 5
        End Select
        Dim User_Id As String = Me.DropDownListUser_IdQ2.SelectedItem.Value.Trim
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ2.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ2.SelectedItem.Value & Me.DropDownListFromMinuteQ2.SelectedItem.Value & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            If Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 3 Then ' Quảng cáo
                Decrease_Percent_Total = CaculateQualityMTAdvHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
            ElseIf Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 4 Then 'CSKH
                Decrease_Percent_Total = CaculateQualityMTCcareHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            End If
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Insert_Technical_Quality_MT_Handset"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 100))
            .Parameters.Item("@User_Id").Value = User_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

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

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal))
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
        If Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại tin không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListUser_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = Util.FormatOperator(Me.DropDownListUser_IdQ2.SelectedItem.Value)
        Select Case Mobile_Operator_Text
            Case "MOBI"
                Mobile_Operator_Id = 1
            Case "VINA"
                Mobile_Operator_Id = 2
            Case "VIETTEL"
                Mobile_Operator_Id = 3
            Case "VNM"
                Mobile_Operator_Id = 4
            Case "GTEL"
                Mobile_Operator_Id = 5
        End Select
        Dim User_Id As String = Me.DropDownListUser_IdQ2.SelectedItem.Value.Trim
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ2.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ2.SelectedItem.Value & Me.DropDownListFromMinuteQ2.SelectedItem.Value & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            If Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 3 Then ' Quảng cáo
                Decrease_Percent_Total = CaculateQualityMTAdvHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
            ElseIf Me.DropDownListTypeOf_IdQ2.SelectedItem.Value = 4 Then 'CSKH
                Decrease_Percent_Total = CaculateQualityMTCcareHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
            End If
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Update_Technical_Quality_MT_Handset"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 100))
            .Parameters.Item("@User_Id").Value = User_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

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

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal))
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
    Protected Sub btnImportQ2_Click(sender As Object, e As EventArgs) Handles btnImportQ2.Click
        If Me.txtFileUploadQ2.Text.Trim = "" Then
            Me.lblerror.Text = "File import không hợp lệ !"
            Exit Sub
        End If
        If Me.txtSheetQ2.Text.Trim = "" Then
            Me.lblerror.Text = "Tên sheet không hợp lệ !"
            Exit Sub
        End If
        ImportQ2(Me.txtFileUploadQ2.Text.Trim, Me.txtSheetQ2.Text.Trim)
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
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
        Dim sql As String = "Delete from Kpi_Br_Technical_Quality_MT_Handset Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Technical_Quality_MT_Handset Where Id=" & ViewState("Id_Q2")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListTypeOf_IdQ2.SelectedValue = dt.Rows(0).Item("TypeOf_Id")
            Me.DropDownListMobile_OperatorQ2.SelectedValue = dt.Rows(0).Item("Mobile_Operator_Id")
            Me.DropDownListUser_IdQ2.SelectedValue = dt.Rows(0).Item("User_Id")
            Me.DropDownListFromHourQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ2.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
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
            sql = "Delete From Kpi_Br_Technical_Quality_MT_Handset  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#Region "Import Data"
    Private Sub ImportQ2(ByVal xlsFile As String, ByVal Sheet As String)
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
        'Load DictIndex Info
        sql = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_MT "
        Dim dsOperatorInfo As DataSet = MSSQLEnv.BuildDataSet.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Dim conn As New SqlConnection(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = ""
        Dim User_Id As String = ""
        Dim TypeOf_Id As String = 0 'Me.DropDownListTypeOf_IdQ2.SelectedItem.Value
        Dim TypeOf_Text As String = "" ' Me.DropDownListTypeOf_IdQ2.SelectedItem.Text
        Dim Date_Id As String = "" ' DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = "" ' Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = "" ' DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ2.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_Start_Text As String = "" 'DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ2.SelectedItem.Value & Me.DropDownListFromMinuteQ2.SelectedItem.Value & Me.DropDownListFromSecondQ2.SelectedItem.Value
        Dim Time_End_Id As String = "" ' DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ2.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ2.SelectedItem.Value & ":" & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Time_End_Text As String = "" ' DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ2.SelectedItem.Value & Me.DropDownListToMinuteQ2.SelectedItem.Value & Me.DropDownListToSecondQ2.SelectedItem.Value
        Dim Total_Sec As Integer = 0
        Dim Total_Min As Decimal = 0
        Dim Total_Hour As Decimal = 0
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
        Dim Description As String = "Import"

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                User_Id = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim
                TypeOf_Text = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                If TypeOf_Text.ToUpper = "QUẢNG CÁO" Then
                    TypeOf_Id = 3
                ElseIf TypeOf_Text.ToUpper = "CHĂM SÓC KHÁCH HÀNG" Then
                    TypeOf_Id = 4
                End If
                Mobile_Operator_Id = 0
                Mobile_Operator_Text = dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim
                Select Case Mobile_Operator_Text.ToUpper
                    Case "MOBI"
                        Mobile_Operator_Id = 1
                    Case "VINA"
                        Mobile_Operator_Id = 2
                    Case "VIETTEL"
                        Mobile_Operator_Id = 3
                    Case "VNM"
                        Mobile_Operator_Id = 4
                    Case "GTEL"
                        Mobile_Operator_Id = 5
                End Select

                If Mobile_Operator_Id > 0 And User_Id <> "" And TypeOf_Id > 0 Then
                    Dim vDate_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim, Constants.CultureInfo.culture_En)
                    Date_Id = DateTime.Parse(vDate_Id).ToString("yyyy-MM-dd")
                    Date_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd")

                    Dim vTime_Start_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim, Constants.CultureInfo.culture_En)
                    Time_Start_Id = DateTime.Parse(vDate_Id).ToString("MM/dd/yyyy") & " " & DateTime.Parse(vTime_Start_Id).ToString("HH:mm:ss")
                    Time_Start_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd") & DateTime.Parse(vTime_Start_Id).ToString("HHmmss")


                    Dim vTime_End_Id As String = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(5).ToString.Trim, Constants.CultureInfo.culture_En)
                    Time_End_Id = DateTime.Parse(vDate_Id).ToString("MM/dd/yyyy") & " " & DateTime.Parse(vTime_End_Id).ToString("HH:mm:ss")
                    Time_End_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd") & DateTime.Parse(vTime_End_Id).ToString("HHmmss")

                    Total_Sec = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
                    Total_Min = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
                    Total_Hour = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)

                    Dim FiltertInfo As String = " Criteria_Id=" & TypeOf_Id
                    Dim sourceMobileOperator As DataRow() = dsOperatorInfo.Tables(0).Select(FiltertInfo)
                    If sourceMobileOperator.Length > 0 Then
                        Standar_Threshold_Handle = sourceMobileOperator(0).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over = sourceMobileOperator(0).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent = sourceMobileOperator(0).Item("Decrease_Percent")
                        Decrease_Percent_Max = sourceMobileOperator(0).Item("Decrease_Percent_Max")
                        If TypeOf_Id = 3 Then ' Quảng cáo
                            Decrease_Percent_Total = CaculateQualityMTAdvHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Min)
                        ElseIf TypeOf_Id = 4 Then 'CSKH
                            Decrease_Percent_Total = CaculateQualityMTCcareHandset(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Sec)
                        End If
                        Dim cmd As New SqlCommand
                        With cmd
                            .Parameters.Clear()
                            .Connection = GlobalConnection
                            .CommandText = "KPI_Br_Insert_Technical_Quality_MT_Handset"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int, 50))
                            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

                            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
                            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

                            .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 100))
                            .Parameters.Item("@User_Id").Value = User_Id

                            .Parameters.Add(New SqlParameter("@TypeOf_Id", SqlDbType.Int, 50))
                            .Parameters.Item("@TypeOf_Id").Value = TypeOf_Id

                            .Parameters.Add(New SqlParameter("@TypeOf_Text", SqlDbType.NVarChar, 50))
                            .Parameters.Item("@TypeOf_Text").Value = TypeOf_Text

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

                            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal))
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
                                TotalRecord = TotalRecord + 1
                            Catch ex As Exception
                                Me.lblerror.Text = ex.Message
                                Exit Sub
                            End Try
                        End With
                    End If
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Technical_Quality_System_Error WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Brand.TechnicalQualitySystemError(sql, CurrentUser.UserName)
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
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value
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
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian phát hiện lỗi phải nhỏ hơn thời gian khắc phục lỗi"
            Exit Sub
        End If
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_System_Error WHERE Criteria_Id=" & Error_Id
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
            .CommandText = "KPI_Br_Insert_Technical_Quality_System_Error"
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
    Private Sub UpdateDataQ3()
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_StartQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value
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
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian phát hiện lỗi phải nhỏ hơn thời gian khắc phục lỗi"
            Exit Sub
        End If
        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ3.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ3.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ3.Text.Trim
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Technical_Quality_System_Error WHERE Criteria_Id=" & Error_Id
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
            .CommandText = "KPI_Br_Update_Technical_Quality_System_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q3")

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
            sql = "Delete From Kpi_Br_Technical_Quality_System_Error  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdateQ3_Click(sender As Object, e As EventArgs) Handles btnUpdateQ3.Click
        If Me.DropDownListErrorCodeQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi không hợp lệ !"
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
        Dim sql As String = "DELETE FROM Kpi_Br_Technical_Quality_System_Error Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Technical_Quality_System_Error Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListErrorCodeQ3.Text = dt.Rows(0).Item("Error_Id")
            Me.RadTime_StartQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtError_DescQ3.Text = dt.Rows(0).Item("Error_Desc")
            Me.DropDownListFromHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            SetTitle()
        End If
    End Sub
#End Region
#End Region
#Region "Q5"
#Region "Ajax"
    Protected Sub RadDate_IdQ5_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ5.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Input_Software_Error WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "") & "'"
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
                Me.lblTotalQ5.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ5.Visible = False
                Me.PagerQ5.Visible = False
                Me.lblTotalQ5.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Brand.InputDataSoftwareError(sql, CurrentUser.UserName)
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
        If Me.DropDownListErrorCodeQ5.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi không hợp lệ !"
            Exit Sub
        End If
        If Me.txtProgram_CodeQ5.Text.Trim = "" Then
            Me.lblerror.Text = "Mã chương trình không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = ""
        Dim Program_Code As String = Me.txtProgram_CodeQ5.Text.Trim
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ5.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ5.SelectedItem.Value & Me.DropDownListFromMinuteQ5.SelectedItem.Value & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ5.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListToSecondQ5.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ5.SelectedItem.Value & Me.DropDownListToMinuteQ5.SelectedItem.Value & Me.DropDownListToSecondQ5.SelectedItem.Value
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
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian phát hiện lỗi phải nhỏ hơn thời gian khắc phục lỗi"
            Exit Sub
        End If
        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ5.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ5.SelectedItem.Text
        Dim Error_Desc As String = ""
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Input_Software_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputSoftwareError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "Kpi_Br_Insert_Input_Software_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Program_Code", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Program_Code").Value = Program_Code

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
    Private Sub UpdateDataQ5()
        If Me.DropDownListErrorCodeQ5.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại lỗi không hợp lệ !"
            Exit Sub
        End If
        If Me.txtProgram_CodeQ5.Text.Trim = "" Then
            Me.lblerror.Text = "Mã chương trình không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator_Id As String = 0
        Dim Mobile_Operator_Text As String = ""
        Dim Program_Code As String = Me.txtProgram_CodeQ5.Text.Trim
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ5.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ5.SelectedItem.Value & Me.DropDownListFromMinuteQ5.SelectedItem.Value & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ5.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListToSecondQ5.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ5.SelectedItem.Value & Me.DropDownListToMinuteQ5.SelectedItem.Value & Me.DropDownListToSecondQ5.SelectedItem.Value
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
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian phát hiện lỗi phải nhỏ hơn thời gian khắc phục lỗi"
            Exit Sub
        End If
        Dim Error_Id As Integer = Me.DropDownListErrorCodeQ5.SelectedItem.Value
        Dim Error_Text As String = Me.DropDownListErrorCodeQ5.SelectedItem.Text
        Dim Error_Desc As String = ""
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Input_Software_Error WHERE Criteria_Id=" & Error_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Time = dt.Rows(0).Item("Decrease_Percent_Time")
            Decrease_Percent_Max_Time = dt.Rows(0).Item("Decrease_Percent_Max_Time")
            Decrease_Percent_Error = dt.Rows(0).Item("Decrease_Percent_Error")
            Decrease_Percent_Max_Error = dt.Rows(0).Item("Decrease_Percent_Max_Error")
            Decrease_Percent_Total_Time = CaculateInputSoftwareError(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent_Time, Decrease_Percent_Max_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Total_Time + Decrease_Percent_Error
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "Kpi_Br_Update_Input_Software_Error"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q5")

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.Int))
            .Parameters.Item("@Mobile_Operator_Id").Value = Mobile_Operator_Id

            .Parameters.Add(New SqlParameter("@Mobile_Operator_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Mobile_Operator_Text").Value = Mobile_Operator_Text

            .Parameters.Add(New SqlParameter("@Program_Code", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Program_Code").Value = Program_Code

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
        Me.txtProgram_CodeQ5.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExxpQ5_Click(sender As Object, e As EventArgs) Handles btnExxpQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
    Protected Sub btnDelQ5_Click(sender As Object, e As EventArgs) Handles btnDelQ5.Click
        DelDataQ5()
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Del Data"
    Sub DelQ5(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete from Kpi_Br_Input_Software_Error Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Input_Software_Error Where Id=" & ViewState("Id_Q5")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ5.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_StartQ5.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_EndQ5.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListErrorCodeQ5.Text = dt.Rows(0).Item("Error_Id")
            Me.txtProgram_CodeQ5.Text = dt.Rows(0).Item("Program_Code")
            Me.DropDownListFromHourQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Delete Data"
    Private Sub DelDataQ5()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGridQ5.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From Kpi_Br_Input_Software_Error  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub

#End Region
#End Region
#Region "Ajax"
    Protected Sub DropDownListTypeOf_IdQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTypeOf_IdQ1.SelectedIndexChanged
        BindRoutingQ1(Me.DropDownListTypeOf_IdQ1.SelectedItem.Value)
    End Sub
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
    Private Function CaculateQualityMTAdvTelcos(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateQualityMTCcareTelcos(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateQualityMTAdvHandset(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateQualityMTCcareHandset(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateInputSoftwareError(ByVal Standar_Threshold_Handle As Integer, _
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

End Class