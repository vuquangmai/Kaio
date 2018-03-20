Imports System.Data.SqlClient
Public Class KpiLotCcareReport
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO CHI TIẾT KPI DỊCH VỤ XỔ SỐ - CHĂM SÓC KHÁCH HÀNG"
            BindDictIndex()
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
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
    End Sub
    Private Sub BindDate()
        Me.RadFromDateQ1.SelectedDate = Now
        Me.RadToDateQ1.SelectedDate = Now
        Me.RadFromDateQ2.SelectedDate = Now
        Me.RadToDateQ2.SelectedDate = Now
    End Sub

#End Region
#Region "Q1"
#Region "Bind Data"
    Private Sub BindDataQ1(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ1.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ1.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Ccare_Complain WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListStatusQ1.SelectedItem.Value <> -1 Then
            sql = sql & " AND Status_Id='" & Me.DropDownListStatusQ1.SelectedItem.Value & "'"
        End If
        If Me.txtUser_IdQ1.Text.Trim <> "" Then
            sql = sql & " AND User_Id='" & Me.txtUser_IdQ1.Text.Trim & "'"
        End If
        If Me.txtInfoQ1.Text.Trim <> "" Then
            sql = sql & " AND Info like N'%" & Me.txtUser_IdQ1.Text.Trim & "%'"
        End If
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
            Else
                Me.DataGridQ1.Visible = False
                Me.PagerQ1.Visible = False

            End If
        Else
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
#Region "Submit Click"
    Protected Sub btnSearchQ1_Click(sender As Object, e As EventArgs) Handles btnSearchQ1.Click
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
#End Region
#Region "Q2"
#Region "Ajax"
    Protected Sub RadDateQ2_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadToDateQ2.SelectedDateChanged
        BinDataQ2()
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BinDataQ2()
        Dim sql As String = "Select * From Kpi_Lot_Ccare_Serving Where Date_Text='" & Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ2.SelectedDate.Value, "") & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGridQ2.DataSource = dt
            Me.DataGridQ2.DataBind()
            Me.DataGridQ2.Visible = True
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGridQ2.Items
                thisButton = gridrow.FindControl("DeleterQ2")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGridQ2.Visible = False
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ2.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ2.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Ccare_Serving WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        sqlTotal = "SELECT count(*) Total FROM (" & sql & ") T"
        If strAction = Constants.Action.Search Then
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
        Else
            Me.DataGridQ2.Visible = False
            Me.PagerQ2.Visible = False

        End If
         Else
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
#Region "Submit Click"
    Protected Sub btnSearchQ2_Click(sender As Object, e As EventArgs) Handles btnSearchQ2.Click
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExpQ2_Click(sender As Object, e As EventArgs) Handles btnExpQ2.Click
        ViewState("DATA_GRID_Q2") = Nothing
        ViewState("DATA_COUNT_Q2") = Nothing
        Dim intPageSize As Integer = PagerQ2.PageSize
        Dim intCurentPage As Integer = PagerQ2.CurrentIndex
        BindDataQ2(intPageSize, intCurentPage, Constants.Action.Export)
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