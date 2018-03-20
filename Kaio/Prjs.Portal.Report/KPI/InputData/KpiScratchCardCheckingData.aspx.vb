Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiScratchCardCheckingData
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "KPI DỊCH VỤ THẺ CÀO - ĐỐI SOÁT, THANH TOÁN"
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
        Me.txtTotal_DayQ1.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ1.SelectedDate.Value, Me.RadTime_EndQ1.SelectedDate.Value, True)
        Me.txtTotal_Day_1Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ2.SelectedDate.Value, Me.RadTime_EndQ2.SelectedDate.Value, True)
        Me.txtTotal_Day_2Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_EndQ2.SelectedDate.Value, Me.RadTime_PaymentQ2.SelectedDate.Value, True)
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
        Me.RadTime_StartQ1.SelectedDate = Now
        Me.RadTime_EndQ1.SelectedDate = Now
        Me.RadDate_IdQ2.SelectedDate = Now
        Me.RadTime_StartQ2.SelectedDate = Now
        Me.RadTime_EndQ2.SelectedDate = Now
        Me.RadTime_PaymentQ2.SelectedDate = Now
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
    Protected Sub RadTime_StartQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTime_StartQ1.SelectedDateChanged
        Dim TotalDate As Integer = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ1.SelectedDate.Value, Me.RadTime_EndQ1.SelectedDate.Value, True)
        Me.txtTotal_DayQ1.Text = TotalDate
    End Sub
    Protected Sub RadTime_EndQ1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTime_EndQ1.SelectedDateChanged
        Dim TotalDate As Integer = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ1.SelectedDate.Value, Me.RadTime_EndQ1.SelectedDate.Value, True)
        Me.txtTotal_DayQ1.Text = TotalDate
    End Sub
    Protected Sub DropDownListMobile_OperatorQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMobile_OperatorQ1.SelectedIndexChanged
        Select Case DropDownListMobile_OperatorQ1.SelectedItem.Value
            Case 1
                Me.DropDownListTypeOf_IdQ1.SelectedValue = 1
            Case Else
                Me.DropDownListTypeOf_IdQ1.SelectedValue = 2
        End Select
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ1(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_ScratchCard_CheckingData WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.ScratchCard.CheckingData(sql, CurrentUser.UserName)
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
        If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Chu kỳ đối soát không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
    
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
      
        Dim Total_Day As Integer = Me.txtTotal_DayQ1.Text.Trim
        Dim Total_Hour As Decimal = Total_Day * 60
        Dim Total_Min As Decimal = Total_Hour * 60
        Dim Total_Sec As Integer = Total_Min * 60

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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Checking_Data WHERE Criteria_Id=" & Mobile_Operator_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCheckingData(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Day)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Insert_Checking_Data"
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

            .Parameters.Add(New SqlParameter("@Total_Day", SqlDbType.Int))
            .Parameters.Item("@Total_Day").Value = Total_Day

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
        If Me.DropDownListTypeOf_IdQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Loại khách hàng không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
       
        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ1.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ1.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ1.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ1.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
        Dim Total_Day As Integer = Me.txtTotal_DayQ1.Text.Trim
        Dim Total_Hour As Decimal = Total_Day * 60
        Dim Total_Min As Decimal = Total_Hour * 60
        Dim Total_Sec As Integer = Total_Min * 60

        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Checking_Data WHERE Criteria_Id=" & Mobile_Operator_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent = dt.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dt.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateCheckingData(Standar_Threshold_Handle, Standar_Threshold_Handle_Over, Decrease_Percent, Decrease_Percent_Max, Total_Day)
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Update_Checking_Data"
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

            .Parameters.Add(New SqlParameter("@Total_Day", SqlDbType.Int))
            .Parameters.Item("@Total_Day").Value = Total_Day

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
        SetTitle()
    End Sub
    Protected Sub btnExpQ1_Click(sender As Object, e As EventArgs) Handles btnExpQ1.Click
        ViewState("DATA_GRID_Q1") = Nothing
        ViewState("DATA_COUNT_Q1") = Nothing
        Dim intPageSize As Integer = PagerQ1.PageSize
        Dim intCurentPage As Integer = PagerQ1.CurrentIndex
        BindDataQ1(intPageSize, intCurentPage, Constants.Action.Export)
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
        Dim sql As String = "DELETE FROM Kpi_ScratchCard_CheckingData Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_CheckingData Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_StartQ1.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_EndQ1.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListMobile_OperatorQ1.Text = dt.Rows(0).Item("Mobile_Operator_Id")
            Me.DropDownListTypeOf_IdQ1.Text = dt.Rows(0).Item("TypeOf_Id")
            Me.txtTotal_DayQ1.Text = dt.Rows(0).Item("Total_Day")
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
            sql = "Delete From Kpi_ScratchCard_CheckingData  WHERE Id IN (" & vId & ")"
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
    Protected Sub RadTime_StartQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTime_StartQ2.SelectedDateChanged
        Me.txtTotal_Day_1Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ2.SelectedDate.Value, Me.RadTime_EndQ2.SelectedDate.Value, True)
    End Sub
    Protected Sub RadTime_EndQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTime_EndQ2.SelectedDateChanged
        Me.txtTotal_Day_1Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_StartQ2.SelectedDate.Value, Me.RadTime_EndQ2.SelectedDate.Value, True)
        Me.txtTotal_Day_2Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_EndQ2.SelectedDate.Value, Me.RadTime_PaymentQ2.SelectedDate.Value, True)
    End Sub
    Protected Sub RadTime_PaymentQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadTime_PaymentQ2.SelectedDateChanged
        Me.txtTotal_Day_2Q2.Text = Util.DateTimeFomat.BusinessDateDiff(Me.RadTime_EndQ2.SelectedDate.Value, Me.RadTime_PaymentQ2.SelectedDate.Value, True)
    End Sub
    Protected Sub DropDownListMobile_OperatorQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMobile_OperatorQ2.SelectedIndexChanged
        Select Case DropDownListMobile_OperatorQ2.SelectedItem.Value
            Case 1
                Me.DropDownListTypeOf_IdQ2.SelectedValue = 1
            Case Else
                Me.DropDownListTypeOf_IdQ2.SelectedValue = 2
        End Select
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_ScratchCard_Payment WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.ScratchCard.OutBill(sql, CurrentUser.UserName)
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
            Me.lblerror.Text = "Chu kỳ đối soát không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If

        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_Payment_Id As String = DateTime.Parse(Me.RadTime_PaymentQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Payment_Text As String = DateTime.Parse(Me.RadTime_PaymentQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
        If Time_End_Text > Time_Payment_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Total_Day_1 As Integer = Me.txtTotal_Day_1Q2.Text.Trim
        Dim Total_Day_2 As Integer = Me.txtTotal_Day_2Q2.Text.Trim

        Dim Standar_Threshold_Handle_1 As Integer = 0
        Dim Standar_Threshold_Handle_Over_1 As Integer = 0
        Dim Decrease_Percent_1 As Integer = 0
        Dim Decrease_Percent_Max_1 As Integer = 0
        Dim Decrease_Percent_Total_1 As Integer = 0
        Dim Standar_Threshold_Handle_2 As Integer = 0
        Dim Standar_Threshold_Handle_Over_2 As Integer = 0
        Dim Decrease_Percent_2 As Integer = 0
        Dim Decrease_Percent_Max_2 As Integer = 0
        Dim Decrease_Percent_Total_2 As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Out_Bill WHERE Criteria_Id=" & 1
        Dim dt_1 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt_1.Rows.Count > 0 Then ' Xuất hóa đơn
            Standar_Threshold_Handle_1 = dt_1.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_1 = dt_1.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_1 = dt_1.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max_1 = dt_1.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total_1 = CaculateOutBill(Standar_Threshold_Handle_1, Standar_Threshold_Handle_Over_1, Decrease_Percent_1, Decrease_Percent_Max_1, Total_Day_1)
        End If
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Payment WHERE Criteria_Id=" & Mobile_Operator_Id

        Dim dt_2 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt_2.Rows.Count > 0 Then 'Thanh toán
            Standar_Threshold_Handle_2 = dt_2.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_2 = dt_2.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_2 = dt_2.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max_2 = dt_2.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total_2 = CaculatePayment(Standar_Threshold_Handle_2, Standar_Threshold_Handle_Over_2, Decrease_Percent_2, Decrease_Percent_Max_2, Total_Day_2)
        End If
        Decrease_Percent_Total = Decrease_Percent_Total_1 + Decrease_Percent_Total_2
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Insert_Payment"
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

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Time_Payment_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Payment_Id").Value = Time_Payment_Id

            .Parameters.Add(New SqlParameter("@Time_Payment_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Payment_Text").Value = Time_Payment_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Total_Day_1", SqlDbType.Int))
            .Parameters.Item("@Total_Day_1").Value = Total_Day_1

            .Parameters.Add(New SqlParameter("@Total_Day_2", SqlDbType.Int))
            .Parameters.Item("@Total_Day_2").Value = Total_Day_2

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_1", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_1").Value = Standar_Threshold_Handle_1

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_1", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_1").Value = Standar_Threshold_Handle_Over_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_1").Value = Decrease_Percent_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_1").Value = Decrease_Percent_Max_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_1").Value = Decrease_Percent_Total_1

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_2", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_2").Value = Standar_Threshold_Handle_2

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_2", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_2").Value = Standar_Threshold_Handle_Over_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_2").Value = Decrease_Percent_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_2").Value = Decrease_Percent_Max_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_2").Value = Decrease_Percent_Total_2

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
            Me.lblerror.Text = "Chu kỳ đối soát không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If

        Dim Mobile_Operator_Id As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Value
        Dim Mobile_Operator_Text As String = Me.DropDownListMobile_OperatorQ2.SelectedItem.Text
        Dim TypeOf_Id As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Value
        Dim TypeOf_Text As String = Me.DropDownListTypeOf_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ2.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_StartQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_EndQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_EndQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        Dim Time_Payment_Id As String = DateTime.Parse(Me.RadTime_PaymentQ2.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & "00" & ":" & "00" & ":" & "00"
        Dim Time_Payment_Text As String = DateTime.Parse(Me.RadTime_PaymentQ2.SelectedDate.Value).ToString("yyyyMMdd") & "00" & "00" & "00"
        If Time_Start_Text > Time_End_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
        If Time_End_Text > Time_Payment_Text Then
            Me.lblerror.Text = "Khoảng thời gian không hợp lệ !"
            Exit Sub
        End If
        Dim Total_Sec As Integer = DateDiff(DateInterval.Second, CDate(Time_Start_Id), CDate(Time_End_Id))
        Dim Total_Min As Decimal = FormatNumber(Total_Sec / 60, 3, TriState.False)
        Dim Total_Hour As Decimal = FormatNumber(Total_Min / 60, 3, TriState.False)
        Dim Total_Day_1 As Integer = Me.txtTotal_Day_1Q2.Text.Trim
        Dim Total_Day_2 As Integer = Me.txtTotal_Day_2Q2.Text.Trim

        Dim Standar_Threshold_Handle_1 As Integer = 0
        Dim Standar_Threshold_Handle_Over_1 As Integer = 0
        Dim Decrease_Percent_1 As Integer = 0
        Dim Decrease_Percent_Max_1 As Integer = 0
        Dim Decrease_Percent_Total_1 As Integer = 0
        Dim Standar_Threshold_Handle_2 As Integer = 0
        Dim Standar_Threshold_Handle_Over_2 As Integer = 0
        Dim Decrease_Percent_2 As Integer = 0
        Dim Decrease_Percent_Max_2 As Integer = 0
        Dim Decrease_Percent_Total_2 As Integer = 0
        Dim Decrease_Percent_Total As Integer = 0

        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Out_Bill WHERE Criteria_Id=" & 1
        Dim dt_1 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt_1.Rows.Count > 0 Then
            Standar_Threshold_Handle_1 = dt_1.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_1 = dt_1.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_1 = dt_1.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max_1 = dt_1.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total_1 = CaculateOutBill(Standar_Threshold_Handle_1, Standar_Threshold_Handle_Over_1, Decrease_Percent_1, Decrease_Percent_Max_1, Total_Day_1)
        End If
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Payment WHERE Criteria_Id=" & Mobile_Operator_Id

        Dim dt_2 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt_2.Rows.Count > 0 Then
            Standar_Threshold_Handle_2 = dt_2.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_2 = dt_2.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_2 = dt_2.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max_2 = dt_2.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total_2 = CaculatePayment(Standar_Threshold_Handle_2, Standar_Threshold_Handle_Over_2, Decrease_Percent_2, Decrease_Percent_Max_2, Total_Day_2)
        End If
        Decrease_Percent_Total = Decrease_Percent_Total_1 + Decrease_Percent_Total_2

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Update_Payment"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")
            .Parameters.Add(New SqlParameter("@Mobile_Operator_Id", SqlDbType.NVarChar, 50))
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

            .Parameters.Add(New SqlParameter("@Time_Start_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Start_Id").Value = Time_Start_Id

            .Parameters.Add(New SqlParameter("@Time_Start_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Start_Text").Value = Time_Start_Text

            .Parameters.Add(New SqlParameter("@Time_End_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_End_Id").Value = Time_End_Id

            .Parameters.Add(New SqlParameter("@Time_End_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_End_Text").Value = Time_End_Text

            .Parameters.Add(New SqlParameter("@Time_Payment_Id", SqlDbType.DateTime))
            .Parameters.Item("@Time_Payment_Id").Value = Time_Payment_Id

            .Parameters.Add(New SqlParameter("@Time_Payment_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Time_Payment_Text").Value = Time_Payment_Text

            .Parameters.Add(New SqlParameter("@Total_Sec", SqlDbType.Int))
            .Parameters.Item("@Total_Sec").Value = Total_Sec

            .Parameters.Add(New SqlParameter("@Total_Min", SqlDbType.Decimal))
            .Parameters.Item("@Total_Min").Value = Total_Min

            .Parameters.Add(New SqlParameter("@Total_Hour", SqlDbType.Decimal))
            .Parameters.Item("@Total_Hour").Value = Total_Hour

            .Parameters.Add(New SqlParameter("@Total_Day_1", SqlDbType.Int))
            .Parameters.Item("@Total_Day_1").Value = Total_Day_1

            .Parameters.Add(New SqlParameter("@Total_Day_2", SqlDbType.Int))
            .Parameters.Item("@Total_Day_2").Value = Total_Day_2

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_1", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_1").Value = Standar_Threshold_Handle_1

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_1", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_1").Value = Standar_Threshold_Handle_Over_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_1").Value = Decrease_Percent_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_1").Value = Decrease_Percent_Max_1

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_1", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_1").Value = Decrease_Percent_Total_1

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_2", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_2").Value = Standar_Threshold_Handle_2

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over_2", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Over_2").Value = Standar_Threshold_Handle_Over_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_2").Value = Decrease_Percent_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Max_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Max_2").Value = Decrease_Percent_Max_2

            .Parameters.Add(New SqlParameter("@Decrease_Percent_Total_2", SqlDbType.Int))
            .Parameters.Item("@Decrease_Percent_Total_2").Value = Decrease_Percent_Total_2

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

    Protected Sub btnDelQ2_Click(sender As Object, e As EventArgs) Handles btDelQ2.Click
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
        Dim sql As String = "DELETE FROM Kpi_ScratchCard_Payment Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_Payment Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_StartQ2.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_EndQ2.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListMobile_OperatorQ2.Text = dt.Rows(0).Item("Mobile_Operator_Id")
            Me.DropDownListTypeOf_IdQ2.Text = dt.Rows(0).Item("TypeOf_Id")
            Me.txtTotal_Day_1Q2.Text = dt.Rows(0).Item("Total_Day_1")
            Me.txtTotal_Day_2Q2.Text = dt.Rows(0).Item("Total_Day_2")
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
            sql = "Delete From Kpi_ScratchCard_Payment  WHERE Id IN (" & vId & ")"
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
        Return t.Days & " ngày, " & t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateCheckingData(ByVal Standar_Threshold_Handle As Integer, _
                                       ByVal Standar_Threshold_Handle_Over As Integer, _
                                       ByVal Decrease_Percent As Integer, _
                                       ByVal Decrease_Percent_Max As Integer, _
                                       ByVal Total_Date As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Date <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Date - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateOutBill(ByVal Standar_Threshold_Handle As Integer, _
                                     ByVal Standar_Threshold_Handle_Over As Integer, _
                                     ByVal Decrease_Percent As Integer, _
                                     ByVal Decrease_Percent_Max As Integer, _
                                     ByVal Total_Date As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Date <= Standar_Threshold_Handle Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate((Total_Date - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculatePayment(ByVal Standar_Threshold_Handle As Integer, _
                                    ByVal Standar_Threshold_Handle_Over As Integer, _
                                    ByVal Decrease_Percent As Integer, _
                                    ByVal Decrease_Percent_Max As Integer, _
                                    ByVal Total_Date As Decimal) As Integer
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