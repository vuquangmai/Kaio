﻿Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiInfrasAlert
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CẢNH BÁO, MONITOR"
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
        BindCriteriaIdQ1()
    End Sub
    Private Sub BindDate()
        Me.RadDate_IdQ1.SelectedDate = Now
    End Sub
     
    Private Sub BindCriteriaIdQ1()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Alert"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ1.Items.Clear()
        Me.DropDownListCriteria_IdQ1.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_Monitor_Alert WHERE Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "") & "'"
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
            ExportData.ExportExcel._KPI.Infras.MonitorAlert(sql, CurrentUser.UserName)
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
            Me.lblerror.Text = "Hệ thống cảnh báo, monitor không hợp lệ !"
            Exit Sub
        End If
     
        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
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

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ1.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Alert WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Quantity = dt.Rows(0).Item("Decrease_Percent")
        End If

        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Insert_Monitor_Alert"
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

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
            Me.lblerror.Text = "Hệ thống cảnh báo, monitor không hợp lệ !"
            Exit Sub
        End If

        Dim Criteria_Id As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Value
        Dim Criteria_Text As String = Me.DropDownListCriteria_IdQ1.SelectedItem.Text
        Dim Date_Id As String = DateTime.Parse(Me.RadDate_IdQ1.SelectedDate.Value).ToString("yyyy-MM-dd")
        Dim Date_Text As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDate_IdQ1.SelectedDate.Value, "")
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

        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescriptionQ1.Text.Trim
        Dim sql As String = "SELECT *  FROM Kpi_Infras_DictIndex_Alert WHERE Criteria_Id=" & Criteria_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Standar_Threshold_Handle_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle")
            Standar_Threshold_Handle_Over_Quantity = dt.Rows(0).Item("Standar_Threshold_Handle_Over")
            Decrease_Percent_Quantity = dt.Rows(0).Item("Decrease_Percent")
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "KPI_Infras_Update_Monitor_Alert"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters.Item("@Id").Value = ViewState("Id_Q1")

            .Parameters.Add(New SqlParameter("@Date_Id", SqlDbType.DateTime))
            .Parameters.Item("@Date_Id").Value = Date_Id

            .Parameters.Add(New SqlParameter("@Date_Text", SqlDbType.NVarChar, 50))
            .Parameters.Item("@Date_Text").Value = Date_Text

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
        Dim sql As String = "Delete from Kpi_Infras_Monitor_Alert Where Id=" & CType(e.CommandArgument, Integer)
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
        Dim sql As String = "SELECT *  FROM Kpi_Infras_Monitor_Alert Where Id=" & ViewState("Id_Q1")
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.RadDate_IdQ1.SelectedDate = dt.Rows(0).Item("Date_Id")
            Me.DropDownListCriteria_IdQ1.SelectedValue = dt.Rows(0).Item("Criteria_Id")
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
            sql = "Delete From Kpi_Infras_Monitor_Alert  WHERE Id IN (" & vId & ")"
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
   
End Class