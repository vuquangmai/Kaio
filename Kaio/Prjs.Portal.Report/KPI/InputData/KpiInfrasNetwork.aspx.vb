Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiInfrasNetwork
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
        Dim intPageSizeQ4 As Integer = PagerQ4.PageSize
        Dim intCurentPageQ4 As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSizeQ4, intCurentPageQ4, Constants.Action.Search)
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
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindHour()
        BindMinute()
        BindSecond()
        BindCriteriaIdQ1()
        BindCriteriaIdQ2()
        BindCriteriaIdQ4()
        BindCriteriaIdQ5()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
        Me.RadDate_IdQ2.SelectedDate = Now
        Me.RadDate_IdQ3.SelectedDate = Now
        Me.RadTime_Start_IdQ3.SelectedDate = Now
        Me.RadTime_End_IdQ3.SelectedDate = Now
        Me.RadDate_IdQ4.SelectedDate = Now
        Me.RadTime_Start_IdQ4.SelectedDate = Now
        Me.RadTime_End_IdQ4.SelectedDate = Now
        Me.RadDate_IdQ5.SelectedDate = Now
        Me.RadTime_Start_IdQ5.SelectedDate = Now
        Me.RadTime_End_IdQ5.SelectedDate = Now
    End Sub
    Private Sub BindHour()
        DropDownListFromHourQ3.Items.Clear()
        DropDownListToHourQ3.Items.Clear()
        DropDownListFromHourQ4.Items.Clear()
        DropDownListToHourQ4.Items.Clear()
        DropDownListFromHourQ5.Items.Clear()
        DropDownListToHourQ5.Items.Clear()
        For i As Integer = 0 To 23
            Me.DropDownListFromHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromHourQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToHourQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindMinute()
        DropDownListFromMinuteQ3.Items.Clear()
        DropDownListToMinuteQ3.Items.Clear()
        DropDownListFromMinuteQ4.Items.Clear()
        DropDownListToMinuteQ4.Items.Clear()
        DropDownListFromMinuteQ5.Items.Clear()
        DropDownListToMinuteQ5.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromMinuteQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToMinuteQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindSecond()
        DropDownListFromSecondQ3.Items.Clear()
        DropDownListToSecondQ3.Items.Clear()
        DropDownListFromSecondQ4.Items.Clear()
        DropDownListToSecondQ4.Items.Clear()
        DropDownListFromSecondQ5.Items.Clear()
        DropDownListToSecondQ5.Items.Clear()
        For i As Integer = 0 To 59
            Me.DropDownListFromSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ3.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ4.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListFromSecondQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
            Me.DropDownListToSecondQ5.Items.Add(New ListItem(IIf(i < 10, "0" & i, i), IIf(i < 10, "0" & i, i)))
        Next
    End Sub
    Private Sub BindCriteriaIdQ1()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Internet_Bandwidth"
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
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_LeaseLine_Bandwidth"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ2.Items.Clear()
        Me.DropDownListCriteria_IdQ2.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ4()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Stability_Of_Internet"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ4.Items.Clear()
        Me.DropDownListCriteria_IdQ4.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ4.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ5()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Stability_Of_LeaseLine"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ5.Items.Clear()
        Me.DropDownListCriteria_IdQ5.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ5.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Internet_Bandwidth WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Infras.InternetBandwidth(sql, CurrentUser.UserName)
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
            Me.lblerror.Text = "Đường truyền không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_PercentQ1.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
            Exit Sub
        End If
        If Not IsNumeric(Me.txtRatio_PercentQ1.Text.Trim) = True Then
            Me.lblerror.Text = "Tỷ lệ phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Ratio_Percent As Integer = Me.txtRatio_PercentQ1.Text.Trim
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Internet_Bandwidth WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Quantity_Total = CaculateQuantityInternetBandwidth(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeInternetBandwidth(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Ratio_Percent)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Internet_Bandwidth"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Ratio_Percent", SqlDbType.Int))
            .Parameters.Item("@Ratio_Percent").Value = Ratio_Percent

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
            Me.lblerror.Text = "Đường truyền không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_PercentQ1.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
            Exit Sub
        End If
        If Not IsNumeric(Me.txtRatio_PercentQ1.Text.Trim) = True Then
            Me.lblerror.Text = "Tỷ lệ phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Ratio_Percent As Integer = Me.txtRatio_PercentQ1.Text.Trim
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
        Dim Description As String = Me.txtDescriptionQ1.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Internet_Bandwidth WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Quantity_Total = CaculateQuantityInternetBandwidth(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeInternetBandwidth(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Ratio_Percent)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Internet_Bandwidth"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Ratio_Percent", SqlDbType.Int))
            .Parameters.Item("@Ratio_Percent").Value = Ratio_Percent

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
        Me.txtDescriptionQ1.Text = ""
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
        Dim sql As String = "Delete from Kpi_Infras_Internet_Bandwidth Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Internet_Bandwidth Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListCriteria_IdQ1.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtRatio_PercentQ1.Text = dt.Rows(0).Item("Ratio_Percent")
            Me.txtDescriptionQ1.Text = dt.Rows(0).Item("Description")
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
            sql = "Delete From Kpi_Infras_Internet_Bandwidth  WHERE Id IN (" & vId & ")"
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_LeaseLine_Bandwidth WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Infras.LeaselineBandwidth(sql, CurrentUser.UserName)
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
            Me.lblerror.Text = "Đường truyền không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_PercentQ2.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
            Exit Sub
        End If
        If Not IsNumeric(Me.txtRatio_PercentQ2.Text.Trim) = True Then
            Me.lblerror.Text = "Tỷ lệ phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Ratio_Percent As Integer = Me.txtRatio_PercentQ2.Text.Trim
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_LeaseLine_Bandwidth WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Quantity_Total = CaculateQuantityInternetBandwidth(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeInternetBandwidth(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Ratio_Percent)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_LeaseLine_Bandwidth"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Ratio_Percent", SqlDbType.Int))
            .Parameters.Item("@Ratio_Percent").Value = Ratio_Percent

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
            Me.lblerror.Text = "Đường truyền không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_PercentQ2.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
            Exit Sub
        End If
        If Not IsNumeric(Me.txtRatio_PercentQ2.Text.Trim) = True Then
            Me.lblerror.Text = "Tỷ lệ phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ2.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ2.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ2.SelectedDate.Value, "")
        Dim Ratio_Percent As Integer = Me.txtRatio_PercentQ2.Text.Trim
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
        Dim Description As String = Me.txtDescriptionQ2.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_LeaseLine_Bandwidth WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Quantity_Total = CaculateQuantityInternetBandwidth(Standar_Threshold_Handle_Quantity, Standar_Threshold_Handle_Over_Quantity, Decrease_Percent_Quantity, Decrease_Percent_Max, 1) ' Luôn =0, cuối tháng tổng hợp b/c mới tính điểm KPI này
            Decrease_Percent_Time_Total = CaculateTimeInternetBandwidth(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Ratio_Percent)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_LeaseLine_Bandwidth"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q2")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Ratio_Percent", SqlDbType.Int))
            .Parameters.Item("@Ratio_Percent").Value = Ratio_Percent

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
        Me.txtDescriptionQ2.Text = ""
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
        Dim sql As String = "Delete from Kpi_Infras_LeaseLine_Bandwidth Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_LeaseLine_Bandwidth Where Id=" & ViewState("Id_Q2")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ2.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListCriteria_IdQ2.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtRatio_PercentQ2.Text = dt.Rows(0).Item("Ratio_Percent")
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
            sql = "Delete From Kpi_Infras_LeaseLine_Bandwidth  WHERE Id IN (" & vId & ")"
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Services_Of_MobileOperator WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Infras.ServicesOfMobileOperator(sql, CurrentUser.UserName)
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
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ3.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Services_Of_MobileOperator WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateServicesOfMobileOperator(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Services_Of_MobileOperator"
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
    Private Sub UpdateDataQ3()
        If Me.DropDownListCriteria_IdQ3.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ3.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ3.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ3.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ3.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ3.SelectedItem.Value & Me.DropDownListFromMinuteQ3.SelectedItem.Value & Me.DropDownListFromSecondQ3.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ3.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ3.SelectedItem.Value & ":" & Me.DropDownListToSecondQ3.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ3.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ3.SelectedItem.Value & Me.DropDownListToMinuteQ3.SelectedItem.Value & Me.DropDownListToSecondQ3.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Services_Of_MobileOperator WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateServicesOfMobileOperator(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Services_Of_MobileOperator"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
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
        Me.txtError_DescQ3.Text = ""
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
        Dim sql As String = "DELETE FROM Kpi_Infras_Services_Of_MobileOperator Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Services_Of_MobileOperator Where Id=" & ViewState("Id_Q3")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ3.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ3.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ3.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ3.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListCriteria_IdQ3.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtError_DescQ3.Text = dt.Rows(0).Item("Error_Desc")
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
            sql = "Delete From Kpi_Infras_Services_Of_MobileOperator  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
        End If
    End Sub
#End Region
#End Region
#Region "Q4"
#Region "Ajax"
    Protected Sub RadDate_IdQ4_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDate_IdQ4.SelectedDateChanged
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Stability_Of_Internet WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ4.SelectedDate.Value, "") & "'"
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
                Me.lblTotalQ4.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ4.Visible = False
                Me.PagerQ4.Visible = False
                Me.lblTotalQ4.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.StabilityOfInternet(sql, CurrentUser.UserName)
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
        If Me.DropDownListCriteria_IdQ4.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ4.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ4.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ4.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ4.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ4.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ4.SelectedItem.Value & Me.DropDownListFromMinuteQ4.SelectedItem.Value & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ4.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ4.SelectedItem.Value & Me.DropDownListToMinuteQ4.SelectedItem.Value & Me.DropDownListToSecondQ4.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Stability_Of_Internet WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateStabilityOfInternet(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Stability_Of_Internet"
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
    Private Sub UpdateDataQ4()
        If Me.DropDownListCriteria_IdQ4.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ4.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ4.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ4.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ4.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ4.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ4.SelectedItem.Value & Me.DropDownListFromMinuteQ4.SelectedItem.Value & Me.DropDownListFromSecondQ4.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ4.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ4.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ4.SelectedItem.Value & ":" & Me.DropDownListToSecondQ4.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ4.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ4.SelectedItem.Value & Me.DropDownListToMinuteQ4.SelectedItem.Value & Me.DropDownListToSecondQ4.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Stability_Of_Internet WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateStabilityOfInternet(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Stability_Of_Internet"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
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
    Protected Sub btnUpdateQ4_Click(sender As Object, e As EventArgs) Handles btnUpdateQ4.Click
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
        Me.txtError_DescQ4.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ4_Click(sender As Object, e As EventArgs) Handles btnExpQ4.Click
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub

    Protected Sub btDelQ4_Click(sender As Object, e As EventArgs) Handles btDelQ4.Click
        DelDataQ4()
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
#End Region
#Region "Del Data"
    Sub DelQ4(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "DELETE FROM Kpi_Infras_Stability_Of_Internet Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Stability_Of_Internet Where Id=" & ViewState("Id_Q4")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ4.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ4.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ4.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ4.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListCriteria_IdQ4.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtError_DescQ4.Text = dt.Rows(0).Item("Error_Desc")
            SetTitle()
        End If
    End Sub
#End Region
#Region "Delete Data"
    Private Sub DelDataQ4()
        Dim vId As String = "0"
        Dim sql As String = ""
        Dim dgItem As DataGridItem
        Dim ckObj As System.Web.UI.HtmlControls.HtmlInputCheckBox
        For Each dgItem In Me.DataGridQ4.Items
            If TypeOf dgItem.Cells(0).Controls(1) Is System.Web.UI.HtmlControls.HtmlInputCheckBox Then
                ckObj = CType(dgItem.Cells(0).Controls(1), System.Web.UI.HtmlControls.HtmlInputCheckBox)
                If ckObj.Checked Then
                    vId = vId & "," & ckObj.Value
                End If
            End If
        Next
        If vId <> "0" Then
            sql = "Delete From Kpi_Infras_Stability_Of_Internet  WHERE Id IN (" & vId & ")"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            End Try
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Stability_Of_Leaseline WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Infras.StabilityOfLeaseline(sql, CurrentUser.UserName)
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
        If Me.DropDownListCriteria_IdQ5.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ5.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ5.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ5.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ5.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ5.SelectedItem.Value & Me.DropDownListFromMinuteQ5.SelectedItem.Value & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ5.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListToSecondQ5.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ5.SelectedItem.Value & Me.DropDownListToMinuteQ5.SelectedItem.Value & Me.DropDownListToSecondQ5.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Stability_Of_LeaseLine WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateStabilityLeaseline(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Stability_Of_Leaseline"
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
    Private Sub UpdateDataQ5()
        If Me.DropDownListCriteria_IdQ5.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ5.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ5.SelectedItem.Text
        Dim Error_Desc As String = Me.txtError_DescQ5.Text.Trim

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ5.SelectedDate.Value, "")
        Dim Time_Start_Id As String = DateTime.Parse(Me.RadTime_Start_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListFromHourQ5.SelectedItem.Value & ":" & Me.DropDownListFromMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_Start_Text As String = DateTime.Parse(Me.RadTime_Start_IdQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListFromHourQ5.SelectedItem.Value & Me.DropDownListFromMinuteQ5.SelectedItem.Value & Me.DropDownListFromSecondQ5.SelectedItem.Value
        Dim Time_End_Id As String = DateTime.Parse(Me.RadTime_End_IdQ5.SelectedDate.Value).ToString("yyyy-MM-dd") & " " & Me.DropDownListToHourQ5.SelectedItem.Value & ":" & Me.DropDownListToMinuteQ5.SelectedItem.Value & ":" & Me.DropDownListToSecondQ5.SelectedItem.Value
        Dim Time_End_Text As String = DateTime.Parse(Me.RadTime_End_IdQ5.SelectedDate.Value).ToString("yyyyMMdd") & Me.DropDownListToHourQ5.SelectedItem.Value & Me.DropDownListToMinuteQ5.SelectedItem.Value & Me.DropDownListToSecondQ5.SelectedItem.Value

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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Stability_Of_LeaseLine WHERE Criteria_Id=" & Criteria_Id
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
            Decrease_Percent_Time_Total = CaculateStabilityLeaseline(Standar_Threshold_Handle_Time, Standar_Threshold_Handle_Over_Time, Standar_Threshold_Handle_Max_Time, Decrease_Percent_Max_Time, Decrease_Percent_Time, Total_Min)
            Decrease_Percent_Total = Decrease_Percent_Quantity_Total + Decrease_Percent_Time_Total
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Stability_Of_Leaseline"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
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
        Me.txtError_DescQ5.Text = ""
        SetTitle()
    End Sub
    Protected Sub btnExpQ5_Click(sender As Object, e As EventArgs) Handles btnExpQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub

    Protected Sub btDelQ5_Click(sender As Object, e As EventArgs) Handles btDelQ5.Click
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
        Dim sql As String = "DELETE FROM Kpi_Infras_Stability_Of_Leaseline Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Stability_Of_Leaseline Where Id=" & ViewState("Id_Q5")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ5.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.RadTime_Start_IdQ5.SelectedDate = dt.Rows(0).Item("Time_Start_Id")
            Me.RadTime_End_IdQ5.SelectedDate = dt.Rows(0).Item("Time_End_Id")
            Me.DropDownListFromHourQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("HH")
            Me.DropDownListFromMinuteQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("mm")
            Me.DropDownListFromSecondQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_Start_Id")).ToString("ss")
            Me.DropDownListToHourQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("HH")
            Me.DropDownListToMinuteQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("mm")
            Me.DropDownListToSecondQ5.Text = DateTime.Parse(dt.Rows(0).Item("Time_End_Id")).ToString("ss")
            Me.DropDownListCriteria_IdQ5.SelectedValue = dt.Rows(0).Item("Criteria_Id")
            Me.txtError_DescQ5.Text = dt.Rows(0).Item("Error_Desc")
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
            sql = "DELETE FROM Kpi_Infras_Stability_Of_Leaseline  WHERE Id IN (" & vId & ")"
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
    Private Function CaculateQuantityInternetBandwidth(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateTimeInternetBandwidth(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateServicesOfMobileOperator(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateStabilityOfInternet(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateStabilityLeaseline(ByVal Standar_Threshold_Handle As Integer, _
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