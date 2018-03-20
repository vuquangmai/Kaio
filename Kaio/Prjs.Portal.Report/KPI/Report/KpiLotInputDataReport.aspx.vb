Imports System.Data.SqlClient

Public Class KpiLotInputDataReport
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO CHI TIẾT KPI DỊCH VỤ XỔ SỐ - CHẤT LƯỢNG NHẬP LIỆU"
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
    End Sub
#End Region
 
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindProvinceQ1(Me.DropDownListRegionQ1.SelectedItem.Value)
        BindProvinceQ2(Me.DropDownListRegionQ2.SelectedItem.Value)
        BindProvinceQ3(Me.DropDownListRegionQ3.SelectedItem.Value)
        BindErrorCodeQ3()
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
    End Sub

    Private Sub BindProvinceQ1(ByVal Region_Id As String)
        Dim sql As String = "SELECT * FROM Lottery_Company WHERE Company_Id>0 "
        If Region_Id <> "--all--" Then
            sql = sql & " AND Company_Region='" & Region_Id & "'"
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ1.Items.Clear()
        Me.DropDownListProvinceQ1.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ1.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub BindProvinceQ2(ByVal Region_Id As String)
        Dim sql As String = "SELECT * FROM Lottery_Company WHERE Company_Id>0 "
        If Region_Id <> "--all--" Then
            sql = sql & " AND Company_Region='" & Region_Id & "'"
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ2.Items.Clear()
        Me.DropDownListProvinceQ2.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ2.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub BindProvinceQ3(ByVal Region_Id As String)
        Dim sql As String = "SELECT * FROM Lottery_Company WHERE Company_Id>0 "
        If Region_Id <> "--all--" Then
            sql = sql & " AND Company_Region='" & Region_Id & "'"
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListProvinceQ3.Items.Clear()
        Me.DropDownListProvinceQ3.Items.Add(New ListItem("--Chọn--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListProvinceQ3.Items.Add(New ListItem(dt.Rows(i).Item("Company_Name"), dt.Rows(i).Item("Company_Id")))
            Next
        End If
    End Sub
    Private Sub BindErrorCodeQ3()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Input_Data_Error"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListErrorCodeQ3.Items.Clear()
        Me.DropDownListErrorCodeQ3.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListErrorCodeQ3.Items.Add(New ListItem(dt.Rows(i).Item("Criteria_Text"), dt.Rows(i).Item("Criteria_Id")))
            Next
        End If
    End Sub
    Private Sub BindErrorCodeQ4()
        Dim sql As String = "SELECT * FROM Kpi_Lot_DictIndex_Input_Software_Error"
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
#Region "Ajax"
    Protected Sub DropDownListRegionQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ1.SelectedIndexChanged
        BindProvinceQ1(DropDownListRegionQ1.SelectedItem.Value)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ1(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ1.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ1.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Input_Data WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If DropDownListRegionQ1.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Region_Id='" & Me.DropDownListRegionQ1.SelectedItem.Value & "'"
        End If
        If Me.DropDownListProvinceQ1.SelectedItem.Value > 0 Then
            sql = sql & " AND Company_Id=" & Me.DropDownListProvinceQ1.SelectedItem.Value
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
            ExportData.ExportExcel._KPI.Lott.InputDataLot(sql, CurrentUser.UserName)
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
    Protected Sub DropDownListRegionQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ2.SelectedIndexChanged
        BindProvinceQ2(DropDownListRegionQ2.SelectedItem.Value)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ2(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ2.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ2.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Input_LuckyNumber WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If DropDownListRegionQ2.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Region_Id='" & Me.DropDownListRegionQ2.SelectedItem.Value & "'"
        End If
        If Me.DropDownListProvinceQ2.SelectedItem.Value > 0 Then
            sql = sql & " AND Company_Id=" & Me.DropDownListProvinceQ2.SelectedItem.Value
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
            ExportData.ExportExcel._KPI.Lott.InputDataLuckyNumber(sql, CurrentUser.UserName)

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
#Region "Ajax"
    Protected Sub DropDownListRegionQ3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegionQ3.SelectedIndexChanged
        BindProvinceQ3(Me.DropDownListRegionQ3.SelectedItem.Value)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindDataQ3(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ3.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ3.SelectedDate.Value, "")
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Input_Data_Error WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If DropDownListRegionQ3.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Region_Id='" & Me.DropDownListRegionQ3.SelectedItem.Value & "'"
        End If
        If Me.DropDownListProvinceQ3.SelectedItem.Value > 0 Then
            sql = sql & " AND Company_Id=" & Me.DropDownListProvinceQ3.SelectedItem.Value
        End If
        If Me.DropDownListErrorCodeQ3.SelectedItem.Value > 0 Then
            sql = sql & " AND Error_Id=" & Me.DropDownListErrorCodeQ3.SelectedItem.Value
        End If
        If Me.txtError_DescQ3.Text.Trim <> "" Then
            sql = sql & " AND Error_Desc like N'%" & Me.txtError_DescQ3.Text.Trim & "%'"
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
            ExportData.ExportExcel._KPI.Lott.InputDataErr(sql, CurrentUser.UserName)
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
    Protected Sub btnUpdateQ3_Click(sender As Object, e As EventArgs) Handles btnSearchQ3.Click
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
        Dim sql As String = "SELECT *,Row_Number() Over ( Order by Id ) as RowNumber  FROM Kpi_Lot_Input_Software_Error WHERE Date_Text>='" & FromDate & "' AND Date_Text<='" & ToDate & "'"
        If Me.DropDownListErrorCodeQ4.SelectedItem.Value > 0 Then
            sql = sql & " AND Error_Id=" & Me.DropDownListErrorCodeQ4.SelectedItem.Value
        End If
        If Me.txtError_DescQ4.Text.Trim <> "" Then
            sql = sql & " AND Error_Desc like N'%" & Me.txtError_DescQ4.Text.Trim & "%'"
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
            ExportData.ExportExcel._KPI.Lott.InputSoftwareErr(sql, CurrentUser.UserName)
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
    Protected Sub btnUpdateQ4_Click(sender As Object, e As EventArgs) Handles btnSearchQ4.Click
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
    Function ConvertTimeSS(ByVal TotalSecond As Integer) As String
        Dim t As TimeSpan = TimeSpan.FromSeconds(TotalSecond)
        Return t.Hours & ":" & t.Minutes & ":" & t.Seconds
    End Function
    Private Function CaculateInputData(ByVal Standar_Threshold_Handle As Integer, _
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
    Private Function CaculateInputLuckyNumber(ByVal Standar_Threshold_Handle_Over As Integer, _
                                     ByVal Decrease_Percent As Integer, _
                                     ByVal Decrease_Percent_Max As Integer, _
                                     ByVal Total_Hour As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Hour <= 0 Then
            retval = 0
        Else
            Dim k As Integer = Math.Truncate(Total_Hour / Standar_Threshold_Handle_Over)
            retval = IIf(k * Decrease_Percent > Decrease_Percent_Max, Decrease_Percent_Max, k * Decrease_Percent)
        End If

        Return retval
    End Function
    Private Function CaculateInputDataError(ByVal Standar_Threshold_Handle As Integer, _
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
End Class