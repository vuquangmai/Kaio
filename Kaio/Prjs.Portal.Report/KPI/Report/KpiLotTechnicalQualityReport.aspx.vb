Imports System.Data.SqlClient
Public Class KpiLotTechnicalQualityReport
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO CHI TIẾT KPI DỊCH VỤ XỔ SỐ - CHẤT LƯỢNG KỸ THUẬT"
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
        BindErrorCodeQ4()
    End Sub
    Private Sub BindDate()
        Me.RadFromDateQ1.SelectedDate = Now
        Me.RadToDateQ1.SelectedDate = Now
        Me.RadFromDateQ2.SelectedDate = Now
        Me.RadToDateQ2.SelectedDate = Now
        Me.RadFromDateQ3.SelectedDate = Now
        Me.RadToDateQ3.SelectedDate = Now
        Me.RadFromDateQ4.SelectedDate = Now
        Me.RadToDateQ4.SelectedDate = Now
        Me.RadFromDateQ5.SelectedDate = Now
        Me.RadToDateQ5.SelectedDate = Now
    End Sub
    Private Sub BindErrorCodeQ4()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Technical_Quality_System_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ4.Items.Clear()
        Me.DropDownListErrorCodeQ4.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ4.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_MT WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListMobile_OperatorQ1.SelectedItem.Value > 0 Then
            sql = sql & " AND Mobile_Operator_Id='" & Me.DropDownListMobile_OperatorQ1.SelectedItem.Value & "'"
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
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ2.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ2.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_Handle WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListMobile_OperatorQ2.SelectedItem.Value > 0 Then
            sql = sql & " AND Mobile_Operator_Id='" & Me.DropDownListMobile_OperatorQ2.SelectedItem.Value & "'"
        End If
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
#Region "Q3"
#Region "Bind Data"
    Private Sub BindDataQ3(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ3.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ3.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_Mobile_Operator WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListMobile_OperatorQ3.SelectedItem.Value > 0 Then
            sql = sql & " AND Mobile_Operator_Id='" & Me.DropDownListMobile_OperatorQ3.SelectedItem.Value & "'"
        End If
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
#Region "Submit Click"
    Protected Sub btnSearchQ3_Click(sender As Object, e As EventArgs) Handles btnSearchQ3.Click
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExpQ3_Click(sender As Object, e As EventArgs) Handles btnExpQ3.Click
        ViewState("DATA_GRID_Q3") = Nothing
        ViewState("DATA_COUNT_Q3") = Nothing
        Dim intPageSize As Integer = PagerQ3.PageSize
        Dim intCurentPage As Integer = PagerQ3.CurrentIndex
        BindDataQ3(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#End Region
#Region "Q4"
#Region "Bind Data"
    Private Sub BindDataQ4(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ4.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ4.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_System_Error WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListErrorCodeQ4.SelectedItem.Value > 0 Then
            sql = sql & " AND Error_Id=" & Me.DropDownListErrorCodeQ4.SelectedItem.Value
        End If
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
 #Region "Submit Click"
    Protected Sub btnSearchQ4_Click(sender As Object, e As EventArgs) Handles btnSearchQ4.Click
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExpQ4_Click(sender As Object, e As EventArgs) Handles btnExpQ4.Click
        ViewState("DATA_GRID_Q4") = Nothing
        ViewState("DATA_COUNT_Q4") = Nothing
        Dim intPageSize As Integer = PagerQ4.PageSize
        Dim intCurentPage As Integer = PagerQ4.CurrentIndex
        BindDataQ4(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#End Region
#Region "Q5"
#Region "Bind Data"
    Private Sub BindDataQ5(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ5.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ5.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Technical_Quality_MT_Error WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
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
#Region "Submit Click"
    Protected Sub btnSearchQ5_Click(sender As Object, e As EventArgs) Handles btnSearchQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExpQ5_Click(sender As Object, e As EventArgs) Handles btnExpQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        ViewState("DATA_COUNT_Q5") = Nothing
        Dim intPageSize As Integer = PagerQ5.PageSize
        Dim intCurentPage As Integer = PagerQ5.CurrentIndex
        BindDataQ5(intPageSize, intCurentPage, Constants.Action.Export)
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
 