Imports System.Data.SqlClient
Public Class KpiLotCcare
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ XỔ SỐ - CHĂM SÓC KHÁCH HÀNG"
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
    End Sub
#End Region
#Region "Init Status"
    Private Sub InitStatus()
        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
        ViewState("Id_Q2") = 0
        ViewState("Status_Q2") = Constants.Action.Insert
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
        Me.RadToDateQ1.SelectedDate = Now
        Me.RadDateQ2.SelectedDate = Now
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
    Protected Sub RadDateQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ1.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Lot_Ccare_Complain WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Lott.CcareComplain(sql, CurrentUser.UserName)
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
#End Region
#Region "Insert Data"
    Private Sub InsertDataQ1()
        Dim User_Id As String = Me.txtUser_IdQ1.Text.Trim
        Dim Info As String = Me.txtInfoQ1.Text.Trim
        Dim Status_Id As String = Me.DropDownListStatusQ1.SelectedItem.Value
        Dim Status_Text As String = Me.DropDownListStatusQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadToDateQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadToDateQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc"
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Ccare_Complain WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCcareComplain(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Hour)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Ccare_Complain"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@User_Id").Value = User_Id

            .Parameters.Add(New SqlParameter("@Info", SqlDbType.NVarChar, 2000))
            .Parameters.Item("@Info").Value = Info

            .Parameters.Add(New SqlParameter("@Status_Id", SqlDbType.Int))
            .Parameters.Item("@Status_Id").Value = Status_Id

            .Parameters.Add(New SqlParameter("@Status_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Status_Text").Value = Status_Text

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
        Dim User_Id As String = Me.txtUser_IdQ1.Text.Trim
        Dim Info As String = Me.txtInfoQ1.Text.Trim
        Dim Status_Id As String = Me.DropDownListStatusQ1.SelectedItem.Value
        Dim Status_Text As String = Me.DropDownListStatusQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ1.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ1.SelectedItem.Value & Me.DropDownListFromMinuteQ1.SelectedItem.Value & Me.DropDownListFromSecondQ1.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ1.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ1.SelectedItem.Value & ":" & Me.DropDownListToSecondQ1.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ1.SelectedItem.Value & Me.DropDownListToMinuteQ1.SelectedItem.Value & Me.DropDownListToSecondQ1.SelectedItem.Value
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc"
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Ccare_Complain WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCcareComplain(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Hour)
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Ccare_Complain"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 50))
            .Parameters.Item("@User_Id").Value = User_Id

            .Parameters.Add(New SqlParameter("@Info", SqlDbType.NVarChar, 2000))
            .Parameters.Item("@Info").Value = Info

            .Parameters.Add(New SqlParameter("@Status_Id", SqlDbType.Int))
            .Parameters.Item("@Status_Id").Value = Status_Id

            .Parameters.Add(New SqlParameter("@Status_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Status_Text").Value = Status_Text

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

        If Me.txtUser_IdQ1.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại khách hàng không hợp lệ !"
            Exit Sub
        End If
        If Me.txtInfoQ1.Text.Trim = "" Then
            Me.lblerror.Text = "Nội dung khiếu nại không hợp lệ !"
            Exit Sub
        End If
        If ViewState("Status_Q1") = Constants.Action.Insert Then
            InsertDataQ1()
        ElseIf ViewState("Status_Q1") = Constants.Action.Update Then
            UpdateDataQ1()
        End If
        ViewState("Id_Q1") = 0
        ViewState("Status_Q1") = Constants.Action.Insert
        SetTitle()
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Search)
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
        Dim sql As String = "DELETE FROM Kpi_Lot_Ccare_Complain Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Ccare_Complain Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadToDateQ1.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListStatusQ1.SelectedValue = dt.Rows(0).Item("Status_Id")
            Me.DropDownListFromHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ1.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.txtInfoQ1.Text = dt.Rows(0).Item("Info")
            Me.txtUser_IdQ1.Text = dt.Rows(0).Item("User_Id")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Q2"
#Region "Ajax"
    Protected Sub RadDateQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDateQ2.SelectedDateChanged
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSizeQ2 As Integer = PagerQ2.PageSize
        Dim intCurentPageQ2 As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSizeQ2, intCurentPageQ2, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM   Kpi_Lot_Ccare_Serving Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "") & "'"
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
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Lott.CcareServe(sql, CurrentUser.UserName)
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
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "")

        Dim Total_Serve As Integer = Me.txtTotalSevingQ2.Text.Trim
        Dim Standar_Threshold_Handle_Serve As Integer = 0
        Dim Standar_Threshold_Handle_Over_Serve As Integer = 0
        Dim Decrease_Percent_Serve As Integer = 0
        Dim Decrease_Percent_Max_Serve As Integer = 0
        Dim Decrease_Percent_Total_Serve As Integer = 0

        Dim Total_Wait As Integer = Me.txtTotalWaitQ2.Text.Trim
        Dim Standar_Threshold_Handle_Wait As Integer = 0
        Dim Standar_Threshold_Handle_Over_Wait As Integer = 0
        Dim Decrease_Percent_Wait As Integer = 0
        Dim Decrease_Percent_Max_Wait As Integer = 0
        Dim Decrease_Percent_Total_Wait As Integer = 0

        Dim Total_Satisfied As Integer = Me.txtTotalSatisfiedQ2.Text.Trim
        Dim Standar_Threshold_Handle_Satisfied As Integer = 0
        Dim Standar_Threshold_Handle_Over_Satisfied As Integer = 0
        Dim Decrease_Percent_Satisfied As Integer = 0
        Dim Decrease_Percent_Max_Satisfied As Integer = 0
        Dim Decrease_Percent_Total_Satisfied As Integer = 0

        Dim Decrease_Percent_Total As Integer = 0

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Ccare_Serving"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim Criteria_Id As Integer = dt.Rows(j).Item("Criteria_Id")
                Select Case Criteria_Id
                    Case 1 'Tỷ lệ phục vụ KH
                        Standar_Threshold_Handle_Serve = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Serve = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Serve = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Serve = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Serve = CaculateCcareServing(Standar_Threshold_Handle_Serve, Standar_Threshold_Handle_Over_Serve, Decrease_Percent_Serve, Decrease_Percent_Max_Serve, Total_Serve)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Serve
                    Case 2 'Thời gian KH chờ được phục vụ
                        Standar_Threshold_Handle_Wait = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Wait = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Wait = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Wait = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Wait = CaculateCcareWait(Standar_Threshold_Handle_Wait, Standar_Threshold_Handle_Over_Wait, Decrease_Percent_Wait, Decrease_Percent_Max_Wait, Total_Wait)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Wait
                    Case 3 'Chăm sóc khách hàng
                        Standar_Threshold_Handle_Satisfied = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Satisfied = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Satisfied = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Satisfied = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Satisfied = CaculateCcareSatisfied(Standar_Threshold_Handle_Satisfied, Standar_Threshold_Handle_Over_Satisfied, Decrease_Percent_Satisfied, Decrease_Percent_Max_Satisfied, Total_Satisfied)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Satisfied
                End Select
            Next

        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Insert_Ccare_Serving"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Serve", SqlDbType.Int))
            .Parameters.Item("@Total_Serve").Value = Total_Serve

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Serve", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Serve").Value = Standar_Threshold_Handle_Serve

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Serve", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Serve").Value = Standar_Threshold_Handle_Over_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Serve").Value = Decrease_Percent_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Serve").Value = Decrease_Percent_Max_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Serve").Value = Decrease_Percent_Total_Serve

            .Parameters.Add(New SqlParameter("@Total_Wait", SqlDbType.Int))
            .Parameters.Item("@Total_Wait").Value = Total_Wait

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Wait", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Wait").Value = Standar_Threshold_Handle_Wait

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Wait", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Wait").Value = Standar_Threshold_Handle_Over_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Wait").Value = Decrease_Percent_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Wait").Value = Decrease_Percent_Max_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Wait").Value = Decrease_Percent_Total_Wait

            .Parameters.Add(New SqlParameter("@Total_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Total_Satisfied").Value = Total_Satisfied

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Satisfied").Value = Standar_Threshold_Handle_Satisfied

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Satisfied").Value = Standar_Threshold_Handle_Over_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Satisfied").Value = Decrease_Percent_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Satisfied").Value = Decrease_Percent_Max_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Satisfied").Value = Decrease_Percent_Total_Satisfied

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
        Dim Date_Id As String = DateTime.Parse(Me.RadDateQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDateQ2.SelectedDate.Value, "")

        Dim Total_Serve As Integer = Me.txtTotalSevingQ2.Text.Trim
        Dim Standar_Threshold_Handle_Serve As Integer = 0
        Dim Standar_Threshold_Handle_Over_Serve As Integer = 0
        Dim Decrease_Percent_Serve As Integer = 0
        Dim Decrease_Percent_Max_Serve As Integer = 0
        Dim Decrease_Percent_Total_Serve As Integer = 0

        Dim Total_Wait As Integer = Me.txtTotalWaitQ2.Text.Trim
        Dim Standar_Threshold_Handle_Wait As Integer = 0
        Dim Standar_Threshold_Handle_Over_Wait As Integer = 0
        Dim Decrease_Percent_Wait As Integer = 0
        Dim Decrease_Percent_Max_Wait As Integer = 0
        Dim Decrease_Percent_Total_Wait As Integer = 0

        Dim Total_Satisfied As Integer = Me.txtTotalSatisfiedQ2.Text.Trim
        Dim Standar_Threshold_Handle_Satisfied As Integer = 0
        Dim Standar_Threshold_Handle_Over_Satisfied As Integer = 0
        Dim Decrease_Percent_Satisfied As Integer = 0
        Dim Decrease_Percent_Max_Satisfied As Integer = 0
        Dim Decrease_Percent_Total_Satisfied As Integer = 0

        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_Lot_DictIndex_Ccare_Serving"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim Criteria_Id As Integer = dt.Rows(j).Item("Criteria_Id")
                Select Case Criteria_Id
                    Case 1 'Tỷ lệ phục vụ KH
                        Standar_Threshold_Handle_Serve = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Serve = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Serve = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Serve = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Serve = CaculateCcareServing(Standar_Threshold_Handle_Serve, Standar_Threshold_Handle_Over_Serve, Decrease_Percent_Serve, Decrease_Percent_Max_Serve, Total_Serve)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Serve
                    Case 2 'Thời gian KH chờ được phục vụ
                        Standar_Threshold_Handle_Wait = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Wait = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Wait = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Wait = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Wait = CaculateCcareWait(Standar_Threshold_Handle_Wait, Standar_Threshold_Handle_Over_Wait, Decrease_Percent_Wait, Decrease_Percent_Max_Wait, Total_Wait)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Wait
                    Case 3 'Chăm sóc khách hàng
                        Standar_Threshold_Handle_Satisfied = dt.Rows(j).Item("Standar_Threshold_Handle")
                        Standar_Threshold_Handle_Over_Satisfied = dt.Rows(j).Item("Standar_Threshold_Handle_Over")
                        Decrease_Percent_Satisfied = dt.Rows(j).Item("Decrease_Percent")
                        Decrease_Percent_Max_Satisfied = dt.Rows(j).Item("Decrease_Percent_Max")
                        Decrease_Percent_Total_Satisfied = CaculateCcareSatisfied(Standar_Threshold_Handle_Satisfied, Standar_Threshold_Handle_Over_Satisfied, Decrease_Percent_Satisfied, Decrease_Percent_Max_Satisfied, Total_Satisfied)
                        Decrease_Percent_Total = Decrease_Percent_Total + Decrease_Percent_Total_Satisfied
                End Select
            Next

        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Lot_Update_Ccare_Serving"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Serve", SqlDbType.Int))
            .Parameters.Item("@Total_Serve").Value = Total_Serve

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Serve", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Serve").Value = Standar_Threshold_Handle_Serve

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Serve", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Serve").Value = Standar_Threshold_Handle_Over_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Serve").Value = Decrease_Percent_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Serve").Value = Decrease_Percent_Max_Serve

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Serve", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Serve").Value = Decrease_Percent_Total_Serve

            .Parameters.Add(New SqlParameter("@Total_Wait", SqlDbType.Int))
            .Parameters.Item("@Total_Wait").Value = Total_Wait

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Wait", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Wait").Value = Standar_Threshold_Handle_Wait

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Wait", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Wait").Value = Standar_Threshold_Handle_Over_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Wait").Value = Decrease_Percent_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Wait").Value = Decrease_Percent_Max_Wait

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Wait", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Wait").Value = Decrease_Percent_Total_Wait

            .Parameters.Add(New SqlParameter("@Total_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Total_Satisfied").Value = Total_Satisfied

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Satisfied").Value = Standar_Threshold_Handle_Satisfied

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_Satisfied").Value = Standar_Threshold_Handle_Over_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Satisfied").Value = Decrease_Percent_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_Satisfied").Value = Decrease_Percent_Max_Satisfied

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_Satisfied", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_Satisfied").Value = Decrease_Percent_Total_Satisfied

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
        Dim intPageSizeQ2 As Integer = PagerQ2.PageSize
        Dim intCurentPageQ2 As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSizeQ2, intCurentPageQ2, Constants.Action.Search)

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
        Dim sql As String = "DELETE FROM Kpi_Lot_Ccare_Serving Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q2") = Nothing
            ViewState("DATA_COUNT_Q2") = Nothing
            Dim intPageSizeQ2 As Integer = PagerQ2.PageSize
            Dim intCurentPageQ2 As Integer = PagerQ2.CurrentIndex
            BindDataQ2(intPageSizeQ2, intCurentPageQ2, Constants.Action.Search)
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
        Dim sql As String = "SELECT *  FROM Kpi_Lot_Ccare_Serving Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDateQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtTotalSevingQ2.Text = dt.Rows(0).Item("Total_Serve")
            Me.txtTotalWaitQ2.Text = dt.Rows(0).Item("Total_Wait")
            Me.txtTotalSatisfiedQ2.Text = dt.Rows(0).Item("Total_Satisfied")
            SetTitle()
        End If
    End Sub
#End Region

#End Region
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Days & " ngày, " & t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateCcareComplain(ByVal Standar_Threshold_Handle As Integer, _
                                       ByVal Standar_Threshold_Handle_Over As Integer, _
                                       ByVal Decrease_Percent As Integer, _
                                       ByVal Decrease_Percent_Max As Integer, _
                                       ByVal Total_Hour As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Hour <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Hour - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateCcareServing(ByVal Standar_Threshold_Handle As Integer, _
                                      ByVal Standar_Threshold_Handle_Over As Integer, _
                                      ByVal Decrease_Percent As Integer, _
                                      ByVal Decrease_Percent_Max As Integer, _
                                      ByVal Total As Integer) As Integer
        Dim retval As Integer = 0
        If Total >= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Standar_Threshold_Handle - Total) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateCcareWait(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateCcareSatisfied(ByVal Standar_Threshold_Handle As Integer, _
                                     ByVal Standar_Threshold_Handle_Over As Integer, _
                                     ByVal Decrease_Percent As Integer, _
                                     ByVal Decrease_Percent_Max As Integer, _
                                     ByVal Total As Integer) As Integer
        Dim retval As Integer = 0
        If Total >= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Standar_Threshold_Handle - Total) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function

End Class