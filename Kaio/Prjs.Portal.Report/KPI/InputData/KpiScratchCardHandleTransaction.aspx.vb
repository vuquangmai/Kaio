Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiScratchCardHandleTransaction
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CHẤT LƯỢNG XỬ LÝ GIAO DỊCH"
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
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_ScratchCard_Transaction_Quality_Handle WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.ScratchCard.HandleTransaction(sql, CurrentUser.UserName)
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
        If Me.txtTotal_Trans_1.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch nhỏ hơn 1s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Trans_2.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch từ 1s đến 2s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Trans_3.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch lớn hơn 2s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Pending.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch pendind không hợp lệ !"
            Exit Sub
        End If

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Total_Trans_1 As Integer = Me.txtTotal_Trans_1.Text.Trim
        Dim Total_Trans_2 As Integer = Me.txtTotal_Trans_2.Text.Trim
        Dim Total_Trans_3 As Integer = Me.txtTotal_Trans_3.Text.Trim
        Dim Total_Trans As Integer = Total_Trans_1 + Total_Trans_2 + Total_Trans_3
        Dim Total_Pending As Integer = Me.txtTotal_Pending.Text.Trim
        Dim Rate_Pending As Decimal = 0
        If Total_Trans > 0 Then
            Rate_Pending = UtilsNumeric.FormatDecimal(Total_Pending / Total_Trans, 2)
        End If
        Dim Percentage_1 As Integer = 0
        Dim Percentage_2 As Integer = 0
        Dim Percentage_3 As Integer = 0
        Dim KPI_Handle_Transaction As Integer = 0

        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Decimal = 0
        Dim Standar_Threshold_Handle_Max As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Decimal = 0

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Time "
        Dim dtTime As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTime.Rows.Count > 0 Then
            For j As Integer = 0 To dtTime.Rows.Count - 1
                Select Case dtTime.Rows(j).Item("Criteria_Id")
                    Case 1
                        Percentage_1 = dtTime.Rows(j).Item("Percentage")
                    Case 2
                        Percentage_2 = dtTime.Rows(j).Item("Percentage")
                    Case 3
                        Percentage_3 = dtTime.Rows(j).Item("Percentage")
                End Select
            Next
        End If
        If Total_Trans > 0 Then
            KPI_Handle_Transaction = (Total_Trans_1 * Percentage_1 + Total_Trans_2 * Percentage_2 + Total_Trans_3 * Percentage_3) / Total_Trans
        End If
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Pending "
        Dim dtPending As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtPending.Rows.Count > 0 Then
            Standar_Threshold_Handle = dtPending.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dtPending.Rows(0).Item("Standar_Threshold_Handle_Over")
            Standar_Threshold_Handle_Max = dtPending.Rows(0).Item("Standar_Threshold_Handle_Max")
            Decrease_Percent = dtPending.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dtPending.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateHandleTransaction(Standar_Threshold_Handle, _
                                                               Standar_Threshold_Handle_Over, _
                                                               Standar_Threshold_Handle_Max, _
                                                               Decrease_Percent, _
                                                               Decrease_Percent_Max, _
                                                               Rate_Pending)

        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Insert_Transaction_Quality_Handle"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Trans_1", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_1").Value = Total_Trans_1

            .Parameters.Add(New SqlParameter("@Total_Trans_2", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_2").Value = Total_Trans_2

            .Parameters.Add(New SqlParameter("@Total_Trans_3", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_3").Value = Total_Trans_3

            .Parameters.Add(New SqlParameter("@Total_Trans", SqlDbType.Int))
            .Parameters.Item("@Total_Trans").Value = Total_Trans

            .Parameters.Add(New SqlParameter("@Total_Pending", SqlDbType.Int))
            .Parameters.Item("@Total_Pending").Value = Total_Pending

            .Parameters.Add(New SqlParameter("@Rate_Pending", SqlDbType.Decimal))
            .Parameters.Item("@Rate_Pending").Value = Rate_Pending

            .Parameters.Add(New SqlParameter("@KPI_Handle_Transaction", SqlDbType.Int))
            .Parameters.Item("@KPI_Handle_Transaction").Value = KPI_Handle_Transaction

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max").Value = Standar_Threshold_Handle_Max

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
       If Me.txtTotal_Trans_1.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch nhỏ hơn 1s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Trans_2.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch từ 1s đến 2s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Trans_3.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch lớn hơn 2s không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_Pending.Text.Trim = "" Then
            Me.lblerror.Text = "Số giao dịch pendind không hợp lệ !"
            Exit Sub
        End If

        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
        Dim Total_Trans_1 As Integer = Me.txtTotal_Trans_1.Text.Trim
        Dim Total_Trans_2 As Integer = Me.txtTotal_Trans_2.Text.Trim
        Dim Total_Trans_3 As Integer = Me.txtTotal_Trans_3.Text.Trim
        Dim Total_Trans As Integer = Total_Trans_1 + Total_Trans_2 + Total_Trans_3
        Dim Total_Pending As Integer = Me.txtTotal_Pending.Text.Trim
        Dim Rate_Pending As Decimal = 0
        If Total_Trans > 0 Then
            Rate_Pending = UtilsNumeric.FormatDecimal(Total_Pending / Total_Trans, 2)
        End If
        Dim Percentage_1 As Integer = 0
        Dim Percentage_2 As Integer = 0
        Dim Percentage_3 As Integer = 0
        Dim KPI_Handle_Transaction As Integer = 0

        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Decimal = 0
        Dim Standar_Threshold_Handle_Max As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Decimal = 0

        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = ""
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Time "
        Dim dtTime As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTime.Rows.Count > 0 Then
            For j As Integer = 0 To dtTime.Rows.Count - 1
                Select Case dtTime.Rows(j).Item("Criteria_Id")
                    Case 1
                        Percentage_1 = dtTime.Rows(j).Item("Percentage")
                    Case 2
                        Percentage_2 = dtTime.Rows(j).Item("Percentage")
                    Case 3
                        Percentage_3 = dtTime.Rows(j).Item("Percentage")
                End Select
            Next
        End If
        If Total_Trans > 0 Then
            KPI_Handle_Transaction = (Total_Trans_1 * Percentage_1 + Total_Trans_2 * Percentage_2 + Total_Trans_3 * Percentage_3) / Total_Trans
        End If
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Pending "
        Dim dtPending As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtPending.Rows.Count > 0 Then
            Standar_Threshold_Handle = dtPending.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dtPending.Rows(0).Item("Standar_Threshold_Handle_Over")
            Standar_Threshold_Handle_Max = dtPending.Rows(0).Item("Standar_Threshold_Handle_Max")
            Decrease_Percent = dtPending.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dtPending.Rows(0).Item("Decrease_Percent_Max")
            Decrease_Percent_Total = CaculateHandleTransaction(Standar_Threshold_Handle, _
                                                               Standar_Threshold_Handle_Over, _
                                                               Standar_Threshold_Handle_Max, _
                                                               Decrease_Percent, _
                                                               Decrease_Percent_Max, _
                                                               Rate_Pending)

        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_ScratchCard_Update_Transaction_Quality_Handle"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

            .Parameters.Add(New SqlParameter("@Total_Trans_1", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_1").Value = Total_Trans_1

            .Parameters.Add(New SqlParameter("@Total_Trans_2", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_2").Value = Total_Trans_2

            .Parameters.Add(New SqlParameter("@Total_Trans_3", SqlDbType.Int))
            .Parameters.Item("@Total_Trans_3").Value = Total_Trans_3

            .Parameters.Add(New SqlParameter("@Total_Trans", SqlDbType.Int))
            .Parameters.Item("@Total_Trans").Value = Total_Trans

            .Parameters.Add(New SqlParameter("@Total_Pending", SqlDbType.Int))
            .Parameters.Item("@Total_Pending").Value = Total_Pending

            .Parameters.Add(New SqlParameter("@Rate_Pending", SqlDbType.Decimal))
            .Parameters.Item("@Rate_Pending").Value = Rate_Pending

            .Parameters.Add(New SqlParameter("@KPI_Handle_Transaction", SqlDbType.Int))
            .Parameters.Item("@KPI_Handle_Transaction").Value = KPI_Handle_Transaction

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Decimal))
            .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

            .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max", SqlDbType.Int))
            .Parameters.Item("@Standar_Threshold_Handle_Max").Value = Standar_Threshold_Handle_Max

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
        Me.txtTotal_Trans_3.Text = ""
        Me.txtTotal_Pending.Text = ""
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
        Dim sql As String = "Delete from Kpi_ScratchCard_Transaction_Quality_Handle Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_ScratchCard_Transaction_Quality_Handle Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.txtTotal_Trans_1.Text = dt.Rows(0).Item("Total_Trans_1")
            Me.txtTotal_Trans_2.Text = dt.Rows(0).Item("Total_Trans_2")
            Me.txtTotal_Trans_3.Text = dt.Rows(0).Item("Total_Trans_3")
            Me.txtTotal_Pending.Text = dt.Rows(0).Item("Total_Pending")
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
            sql = "Delete From Kpi_ScratchCard_Transaction_Quality_Handle  WHERE Id IN (" & vId & ")"
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
     
        Dim conn As New SqlConnection(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim Date_Id As String = ""
        Dim Date_Text As String = ""
        Dim Total_Trans_1 As Integer = 0
        Dim Total_Trans_2 As Integer = 0
        Dim Total_Trans_3 As Integer = 0
        Dim Total_Trans As Integer = 0
        Dim Total_Pending As Integer = 0
        Dim Rate_Pending As Decimal = 0
        If Total_Trans > 0 Then
            Rate_Pending = UtilsNumeric.FormatDecimal(Total_Pending / Total_Trans, 2)
        End If
        Dim Percentage_1 As Integer = 0
        Dim Percentage_2 As Integer = 0
        Dim Percentage_3 As Integer = 0
        Dim KPI_Handle_Transaction As Integer = 0

        Dim Standar_Threshold_Handle As Integer = 0
        Dim Standar_Threshold_Handle_Over As Decimal = 0
        Dim Standar_Threshold_Handle_Max As Integer = 0
        Dim Decrease_Percent As Integer = 0
        Dim Decrease_Percent_Max As Integer = 0
        Dim Decrease_Percent_Total As Decimal = 0

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = "Import"
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Time "
        Dim dtTime As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTime.Rows.Count > 0 Then
            For j As Integer = 0 To dtTime.Rows.Count - 1
                Select Case dtTime.Rows(j).Item("Criteria_Id")
                    Case 1
                        Percentage_1 = dtTime.Rows(j).Item("Percentage")
                    Case 2
                        Percentage_2 = dtTime.Rows(j).Item("Percentage")
                    Case 3
                        Percentage_3 = dtTime.Rows(j).Item("Percentage")
                End Select
            Next
        End If
       
        sql = "SELECT *  FROM Kpi_ScratchCard_DictIndex_Transaction_Pending "
        Dim dtPending As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtPending.Rows.Count > 0 Then
            Standar_Threshold_Handle = dtPending.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over = dtPending.Rows(0).Item("Standar_Threshold_Handle_Over")
            Standar_Threshold_Handle_Max = dtPending.Rows(0).Item("Standar_Threshold_Handle_Max")
            Decrease_Percent = dtPending.Rows(0).Item("Decrease_Percent")
            Decrease_Percent_Max = dtPending.Rows(0).Item("Decrease_Percent_Max")

        End If

        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1

                Dim vDate_Id As DateTime = Util.DateTimeFomat.ConvertDateTimeAMPMTo24Hour(dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim, Constants.CultureInfo.culture_En)
                Date_Id = DateTime.Parse(vDate_Id).ToString("yyyy-MM-dd")
                Date_Text = DateTime.Parse(vDate_Id).ToString("yyyyMMdd")
                Total_Trans_1 = dsFile.Tables("Data_File").Rows(i).Item(1).ToString.Trim
                Total_Trans_2 = dsFile.Tables("Data_File").Rows(i).Item(2).ToString.Trim
                Total_Trans_3 = dsFile.Tables("Data_File").Rows(i).Item(3).ToString.Trim
                Total_Pending = dsFile.Tables("Data_File").Rows(i).Item(4).ToString.Trim
                Total_Trans = Total_Trans_1 + Total_Trans_2 + Total_Trans_3
                If Total_Trans > 0 Then
                    KPI_Handle_Transaction = (Total_Trans_1 * Percentage_1 + Total_Trans_2 * Percentage_2 + Total_Trans_3 * Percentage_3) / Total_Trans
                End If
                Decrease_Percent_Total = CaculateHandleTransaction(Standar_Threshold_Handle, _
                                                           Standar_Threshold_Handle_Over, _
                                                           Standar_Threshold_Handle_Max, _
                                                           Decrease_Percent, _
                                                           Decrease_Percent_Max, _
                                                           Rate_Pending)
                
                Dim cmd As New SqlCommand
                With cmd
                    .Parameters.Clear()
                    .Connection = GlobalConnection
                    .CommandText = "KPI_ScratchCard_Insert_Transaction_Quality_Handle"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
                    .Parameters.Item("@Date_Id").Value = Date_Id

                    .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
                    .Parameters.Item("@Date_Text").Value = Date_Text

                    .Parameters.Add(New SqlParameter("@Total_Trans_1", SqlDbType.Int))
                    .Parameters.Item("@Total_Trans_1").Value = Total_Trans_1

                    .Parameters.Add(New SqlParameter("@Total_Trans_2", SqlDbType.Int))
                    .Parameters.Item("@Total_Trans_2").Value = Total_Trans_2

                    .Parameters.Add(New SqlParameter("@Total_Trans_3", SqlDbType.Int))
                    .Parameters.Item("@Total_Trans_3").Value = Total_Trans_3

                    .Parameters.Add(New SqlParameter("@Total_Trans", SqlDbType.Int))
                    .Parameters.Item("@Total_Trans").Value = Total_Trans

                    .Parameters.Add(New SqlParameter("@Total_Pending", SqlDbType.Int))
                    .Parameters.Item("@Total_Pending").Value = Total_Pending

                    .Parameters.Add(New SqlParameter("@Rate_Pending", SqlDbType.Decimal))
                    .Parameters.Item("@Rate_Pending").Value = Rate_Pending

                    .Parameters.Add(New SqlParameter("@KPI_Handle_Transaction", SqlDbType.Int))
                    .Parameters.Item("@KPI_Handle_Transaction").Value = KPI_Handle_Transaction

                    .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle", SqlDbType.Int))
                    .Parameters.Item("@Standar_Threshold_Handle").Value = Standar_Threshold_Handle

                    .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Over", SqlDbType.Decimal))
                    .Parameters.Item("@Standar_Threshold_Handle_Over").Value = Standar_Threshold_Handle_Over

                    .Parameters.Add(New SqlParameter("@Standar_Threshold_Handle_Max", SqlDbType.Int))
                    .Parameters.Item("@Standar_Threshold_Handle_Max").Value = Standar_Threshold_Handle_Max

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
    Private Function CaculateHandleTransaction(ByVal Standar_Threshold_Handle As Integer, _
                                          ByVal Standar_Threshold_Handle_Over As Decimal, _
                                          ByVal Standar_Threshold_Handle_Max As Integer, _
                                          ByVal Decrease_Percent As Integer, _
                                          ByVal Decrease_Percent_Max As Integer, _
                                          ByVal Rate_Pending As Decimal) As Decimal
        Dim retval As Decimal = 0
        If Rate_Pending <= Standar_Threshold_Handle Then
            retval = 0
        Else
            If Rate_Pending >= Standar_Threshold_Handle_Max Then ' Nếu thời gian xử lý vượt quá ngưỡng tối đa thì điểm trừ bằng số điểm tối đa
                retval = Decrease_Percent_Max
            Else
                Dim k As Integer = Math.Truncate((Rate_Pending - Standar_Threshold_Handle) / Standar_Threshold_Handle_Over)
                retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
            End If
        End If

        Return retval
    End Function
End Class