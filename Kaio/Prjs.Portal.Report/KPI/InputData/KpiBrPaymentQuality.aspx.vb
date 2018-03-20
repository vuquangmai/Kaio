Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiBrPaymentQuality
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CHẤT LƯỢNG, THỜI GIAN THANH TOÁN"
            BindDictIndex()
            InitStatus()
            SetTitle()
        End If
        LoadData()
    End Sub
#End Region
#Region "Load Data"
    Private Sub LoadData()
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
        ViewState("Id_Q2") = 0
        ViewState("Status_Q2") = Constants.Action.Insert
        ViewState("Id_Q3") = 0
        ViewState("Status_Q3") = Constants.Action.Insert
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindPartner()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ2.SelectedDate = Now
        Me.RadDate_IdQ3.SelectedDate = Now
        Me.RadTime_Start_IdQ2.SelectedDate = Now
        Me.RadTime_End_IdQ2.SelectedDate = Now
        Me.RadTime_Start_IdQ3.SelectedDate = Now
        Me.RadTime_End_IdQ3.SelectedDate = Now
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Kpi_Br_DictIndex_Partner WHERE Status_Id=1 ORDER BY Partner_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownPartner_IdQ2.Items.Clear()
        Me.DropDownPartner_IdQ2.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownPartner_IdQ3.Items.Clear()
        Me.DropDownPartner_IdQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownPartner_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownPartner_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Payment_Quality_1 WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Brand.PaymentQuanlity1(sql, CurrentUser.UserName)
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
        If Me.DropDownPartner_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đối tác không hợp lệ !"
            Exit Sub
        End If
        Dim TypeOf_Id As String = 1
        Dim TypeOf_Text As String = "Thời gian QCS hoàn thành hồ sơ thanh toán, gửi kế toán"
        Dim Partner_Id As Integer = Me.DropDownPartner_IdQ2.SelectedItem.Value
        Dim Partner_Text As String = Me.DropDownPartner_IdQ2.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyyMMdd")
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyyMMdd")
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Ngày nhận bản đối soát từ ĐSTC phải trước trước ngày gửi kế toán !"
            Exit Sub
        End If

        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Total_Date As Integer = DateDiff(DateInterval.Day, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Quanlity_Payment WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
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
        Decrease_Percent_Total = CaculateTimeChecking(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Date)
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ2.Text.Trim

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Insert_Kpi_Br_Payment_Quality_1"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Partner_Text").Value = Partner_Text

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

            .Parameters.Add(New SqlParameter("@Total_Date", SqlDbType.Decimal))
            .Parameters.Item("@Total_Date").Value = Total_Date

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
        If Me.DropDownPartner_IdQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đối tác không hợp lệ !"
            Exit Sub
        End If
        Dim TypeOf_Id As String = 1
        Dim TypeOf_Text As String = "Thời gian QCS hoàn thành hồ sơ thanh toán, gửi kế toán"
        Dim Partner_Id As Integer = Me.DropDownPartner_IdQ2.SelectedItem.Value
        Dim Partner_Text As String = Me.DropDownPartner_IdQ2.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ2.SelectedDate.Value).ToString("yyyyMMdd")
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ2.SelectedDate.Value).ToString("yyyyMMdd")
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Ngày nhận bản đối soát từ ĐSTC phải trước trước ngày gửi kế toán !"
            Exit Sub
        End If

        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Total_Date As Integer = DateDiff(DateInterval.Day, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Quanlity_Payment WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
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
        Decrease_Percent_Total = CaculateTimeChecking(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Date)
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ2.Text.Trim
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Update_Kpi_Br_Payment_Quality_1"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Partner_Text").Value = Partner_Text

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

            .Parameters.Add(New SqlParameter("@Total_Date", SqlDbType.Decimal))
            .Parameters.Item("@Total_Date").Value = Total_Date

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
        Dim sql As String = "Delete from Kpi_Br_Payment_Quality_1 Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Payment_Quality_1 Where Id=" & ViewState("Id_Q2")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ2.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ2.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownPartner_IdQ2.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.txtDescriptionQ2.Text = dt.Rows(0).Item("Description")
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
            sql = "Delete From Kpi_Br_Payment_Quality_1  WHERE Id IN (" & vId & ")"
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Br_Payment_Quality_2 WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Brand.PaymentQuanlity2(sql, CurrentUser.UserName)
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
        If Me.DropDownPartner_IdQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đối tác không hợp lệ !"
            Exit Sub
        End If
        Dim TypeOf_Id As String = 2
        Dim TypeOf_Text As String = "Thời gian Kế toán xuất hóa đơn"
        Dim Partner_Id As Integer = Me.DropDownPartner_IdQ3.SelectedItem.Value
        Dim Partner_Text As String = Me.DropDownPartner_IdQ3.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyyMMdd")
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyyMMdd")
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian nhận y/c thanh toán từ QCS phải trước ngày kế toán xuất hóa đơn !"
            Exit Sub
        End If

        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Total_Date As Integer = DateDiff(DateInterval.Day, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Quanlity_Payment WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
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
        Decrease_Percent_Total = CaculateTimeChecking(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Date)
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ3.Text.Trim

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Insert_Kpi_Br_Payment_Quality_2"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Partner_Text").Value = Partner_Text

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

            .Parameters.Add(New SqlParameter("@Total_Date", SqlDbType.Decimal))
            .Parameters.Item("@Total_Date").Value = Total_Date

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
        If Me.DropDownPartner_IdQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đối tác không hợp lệ !"
            Exit Sub
        End If
        Dim TypeOf_Id As String = 2
        Dim TypeOf_Text As String = "Thời gian Kế toán xuất hóa đơn"
        Dim Partner_Id As Integer = Me.DropDownPartner_IdQ3.SelectedItem.Value
        Dim Partner_Text As String = Me.DropDownPartner_IdQ3.SelectedItem.Text

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyyMMdd")
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyyMMdd")
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Thời gian nhận y/c thanh toán từ QCS phải trước ngày kế toán xuất hóa đơn !"
            Exit Sub
        End If

        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = UtilsNumeric.FormatDecimal(Total_Sec / 60, 3)
        Dim Total_Hour As Decimal = UtilsNumeric.FormatDecimal(Total_Min / 60, 3)
        Dim Total_Date As Integer = DateDiff(DateInterval.Day, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim sql As String = "SELECT *  FROM Kpi_Br_DictIndex_Quanlity_Payment WHERE Criteria_Id=" & TypeOf_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
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
        Decrease_Percent_Total = CaculateTimeChecking(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Date)
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ3.Text.Trim
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Br_Update_Kpi_Br_Payment_Quality_2"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q3")

            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int, 50))
            .Parameters.Item("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Partner_Text").Value = Partner_Text

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

            .Parameters.Add(New SqlParameter("@Total_Date", SqlDbType.Decimal))
            .Parameters.Item("@Total_Date").Value = Total_Date

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
        Dim sql As String = "Delete from Kpi_Br_Payment_Quality_2 Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Br_Payment_Quality_2 Where Id=" & ViewState("Id_Q3")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ3.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ3.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownPartner_IdQ3.SelectedValue = dt.Rows(0).Item("Partner_Id")
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
            sql = "Delete From Kpi_Br_Payment_Quality_2  WHERE Id IN (" & vId & ")"
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
    Private Function CaculateQualityChecking(ByVal Standar_Threshold_Handle As Integer, _
                                       ByVal Standar_Threshold_Handle_Over As Integer, _
                                       ByVal Decrease_Percent As Integer, _
                                       ByVal Decrease_Percent_Max As Integer, _
                                       ByVal Total_Error As Integer) As Integer
        Dim retval As Integer = 0
        If Total_Error <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Error - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateTimeChecking(ByVal Standar_Threshold_Handle As Integer, _
                                    ByVal Standar_Threshold_Handle_Over As Integer, _
                                    ByVal Decrease_Percent As Integer, _
                                    ByVal Decrease_Percent_Max As Integer, _
                                    ByVal Total_Date As Integer) As Integer
        Dim retval As Integer = 0
        If Total_Date <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Date - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If
        Return retval
    End Function

End Class