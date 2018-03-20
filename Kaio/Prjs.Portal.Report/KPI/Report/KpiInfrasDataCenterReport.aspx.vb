Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class KpiInfrasDataCenterReport
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "CHẤT LƯỢNG HẠ TẦNG PHÒNG MÁY 36 HOÀNG CẦU"
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
    End Sub
#End Region

#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindCriteriaIdQ1()
        BindCriteriaIdQ2()
        BindCriteriaIdQ3()
    End Sub
    Private Sub BindDate()
        Me.RadTime_StartQ1.SelectedDate = Now
        Me.RadTime_EndQ1.SelectedDate = Now
        Me.RadTime_StartQ2.SelectedDate = Now
        Me.RadTime_EndQ2.SelectedDate = Now
        Me.RadTime_StartQ3.SelectedDate = Now
        Me.RadTime_EndQ3.SelectedDate = Now
    End Sub
    Private Sub BindCriteriaIdQ1()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_DataCenter WHERE Criteria_Id=1"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ1.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ2()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_DataCenter WHERE Criteria_Id=2"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ2.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindCriteriaIdQ3()
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_DataCenter WHERE Criteria_Id=3"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCriteria_IdQ3.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCriteria_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
#End Region

#Region "Q1"
#Region "Bind Data"
    Private Sub BindDataQ1(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ1.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_EndQ1.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_DataCenter_Electricity_Supply WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
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
#Region "Submit Click"
    Protected Sub btnUpdateQ1_Click(sender As Object, e As EventArgs) Handles btnUpdateQ1.Click
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
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ2.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_EndQ2.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_DataCenter_Air_Conditional WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
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
                Me.lblTotalQ2.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ2.Visible = False
                Me.PagerQ2.Visible = False
                Me.lblTotalQ2.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.AirConditional(sql, CurrentUser.UserName)
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
    Protected Sub btnUpdateQ2_Click(sender As Object, e As EventArgs) Handles btnUpdateQ2.Click
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
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_StartQ3.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadTime_EndQ3.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Date_Text ) as RowNumber  FROM Kpi_Infras_DataCenter_Transmission_Power WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
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
                Me.lblTotalQ3.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGridQ3.Visible = False
                Me.PagerQ3.Visible = False
                Me.lblTotalQ3.Text = 0
            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._KPI.Infras.TransmissionPower(sql, CurrentUser.UserName)
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
    Protected Sub btnUpdateQ3_Click(sender As Object, e As EventArgs) Handles btnUpdateQ3.Click
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