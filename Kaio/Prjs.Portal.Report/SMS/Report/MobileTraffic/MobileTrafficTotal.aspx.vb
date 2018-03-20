Public Class MobileTrafficTotal
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public IsTotal As Integer = 0
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO SỐ LIỆU ĐỐI SOÁT VỚI TELCOS -  DỊCH VỤ SMS MO"
            BindDictIndex()
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindYear()
        BindMonth()
        BindRangeShortcode()
        BindShortcode()
    End Sub
#End Region
    Private Sub BindYear()
        Me.DropDownListYear.Items.Clear()
        For i As Integer = 2015 To 2020
            Me.DropDownListYear.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListYear.SelectedValue = Now.AddMonths(-1).Year
    End Sub
    Private Sub BindMonth()
        Me.DropDownListMonth.Items.Clear()
        For i As Integer = 1 To 12
            Me.DropDownListMonth.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListMonth.SelectedValue = Now.AddMonths(-1).Month
    End Sub
    Private Sub BindRangeShortcode()
        Dim sql As String = "SELECT distinct(Range_Of_Short_Code) Range_Of_Short_Code  FROM SMS_DictIndex_Short_Code  Order by Range_Of_Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListRangOfShortCode.Items.Clear()
        Me.DropDownListRangOfShortCode.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListRangOfShortCode.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListRangOfShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Range_Of_Short_Code"), dt.Rows(i).Item("Range_Of_Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortcode()
        Dim sql As String = "SELECT *  FROM SMS_DictIndex_Short_Code Where Id>0 "
        Me.DropDownListShortCode.Items.Clear()
        Me.DropDownListShortCode.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListShortCode.SelectedValue = 0
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim sql As String = " SELECT  * FROM SMS_Gateway_Total " & _
               "  WHERE  MonthData =" & Me.DropDownListYear.SelectedItem.Value & IIf(Me.DropDownListMonth.SelectedItem.Value < 10, "0" & Me.DropDownListMonth.SelectedItem.Value, Me.DropDownListMonth.SelectedItem.Value)
      
        If Me.DropDownListOperator.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Mobile_Operator='" & Me.DropDownListOperator.SelectedItem.Value & "'"
        End If
        If Me.DropDownListRangOfShortCode.SelectedItem.Text <> "--all--" Then
            sql = sql & " AND Short_Code  like '" & Me.DropDownListRangOfShortCode.SelectedItem.Value.Replace("x", "%") & "'"
        End If
        If Me.DropDownListShortCode.SelectedItem.Value > 0 Then
            sql = sql & " AND Short_Code='" & Me.DropDownListShortCode.SelectedItem.Value & "'"
        End If
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
            End If
            ViewState("DATA_GRID") = dt
          
            If dt.Rows.Count > 0 Then
                Me.DataGrid.DataSource = dt
                Me.DataGrid.DataBind()
                Me.DataGrid.PagerStyle.Visible = False
                Me.DataGrid.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
            End If
        Else
            ExportData.ExportExcel._SMS.MobileTrafficTotal(sql, CurrentUser.UserFullName)

        End If
    End Sub
    
#End Region
#Region "Submit button"
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        Dim intPageSize As Integer = 1
        Dim intCurentPage As Integer = 1
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        ViewState("DATA_GRID") = Nothing
        Dim intPageSize As Integer = 1
        Dim intCurentPage As Integer = 1
        bindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
 

End Class