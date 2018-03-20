  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class ChelseaReport
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DỰ ĐOÁN CHELSEA"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        Me.RadDatePickerFromDate.SelectedDate = Now.AddDays(-7)
        Me.RadDatePickerToDate.SelectedDate = Now

    End Sub
 
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_Ccare.Text = 0
        Me.lblRegister_User_Date.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblMO_Charge_Date.Text = 0
        Me.lblMO_Predicts_Date.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDayOfWeek.Items
            item.Checked = True
        Next
    End Sub

#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "VNM_Predicts_Chelsea"
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Day)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Day)
        sql = "SELECT substring(Date,1,4) as Year, " & _
                              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else substring(Date,5,2) end ) as Month," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " SUM(cast(Total_User as decimal)) Total_User, SUM(cast(Total_Active_User as decimal))  Total_Active_User, SUM(cast(Total_Cancel_User as decimal))  Total_Cancel_User," & _
                              " SUM(cast(Register_User_Date as decimal)) Register_User_Date, SUM(cast(Cancel_User_Date as decimal)) Cancel_User_Date,SUM(cast(Active_User_Date as decimal)) Active_User_Date,SUM(cast(MO_Predicts_Date as decimal)) MO_Predicts_Date,SUM(cast(MO_Charge_Date as decimal)) MO_Charge_Date,SUM(cast(Money_Ccare as decimal)) Money_Ccare," & _
                              " row_number() over( Order by substring(date,1,4) ) as RowNumber " & _
                              " FROM " & vTable
        sqlTotal = "SELECT substring(Date,1,4) as Year ," & _
                              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else substring(Date,5,2) end ) as Month," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " SUM(cast(Total_User as decimal)) Total_User, SUM(cast(Total_Active_User as decimal))  Total_Active_User, SUM(cast(Total_Cancel_User as decimal))  Total_Cancel_User," & _
                              " SUM(cast(Register_User_Date as decimal)) Register_User_Date, SUM(cast(Cancel_User_Date as decimal)) Cancel_User_Date,SUM(cast(Active_User_Date as decimal)) Active_User_Date,SUM(cast(MO_Predicts_Date as decimal)) MO_Predicts_Date,SUM(cast(MO_Charge_Date as decimal)) MO_Charge_Date,SUM(cast(Money_Ccare as decimal)) Money_Ccare " & _
                             " FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1 "

        sqlConditional = sqlConditional & " And Date>='" & vFromDate & "' And Date<='" & vToDate & "'"

        If Me.CheckBoxDayOfWeek.Checked = True Then
            Dim CollectionDayOfWeek As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListDayOfWeek.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionDayOfWeek.Count = 0 Then
                Me.lblerror.Text = "Thứ của tuần không hợp lệ !"
                Exit Sub
            Else
                If CollectionDayOfWeek.Count < Me.RadDropDownListDayOfWeek.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionDayOfWeek
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  DayOfWeek_Id In (" & sb.ToString() & ")"
                End If
            End If
        End If

        sqlGroup = " GROUP BY substring(Date,1,4) "
        sqlOrder = " ORDER BY Year "

        If Me.CheckBoxMonth.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,5,2)"
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,7,2)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If

        If Me.CheckBoxDayOfWeek.Checked = True Then
            sqlGroup = sqlGroup & ", DayOfWeek_Text"
            sqlOrder = sqlOrder & ",DayOfWeek_Text"
        End If

        sql = sql & sqlConditional & sqlGroup & sqlCriteria
        sqlTotal = sqlTotal & sqlConditional & sqlGroup & sqlCriteria
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(Money_Ccare) Money_Ccare, SUM(Register_User_Date) Register_User_Date, SUM(Cancel_User_Date) Cancel_User_Date," & _
                            "SUM(Active_User_Date) Active_User_Date, SUM(MO_Predicts_Date) MO_Predicts_Date, SUM(MO_Charge_Date) MO_Charge_Date," & _
                            "COUNT(*) Total FROM (" & sqlTotal & ") T"
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sqlTotal)
            sql = "SELECT * FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
            Dim TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & TotalCount
                Next
                'IsColumnDataGrid()
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Ccare"), 0)
                Me.lblRegister_User_Date.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Register_User_Date"), 0)
                Me.lblCancel_User_Date.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Cancel_User_Date"), 0)
                Me.lblActive_User_Date.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Active_User_Date"), 0)
                Me.lblMO_Predicts_Date.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MO_Predicts_Date"), 0)
                Me.lblMO_Charge_Date.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MO_Charge_Date"), 0)

                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            'ExportData.ExportExcel._S2.S2TrafficTotal(sql, CurrentUser.UserName, _
            '                                                 Me.CheckBoxDate.Checked, _
            '                                                 Me.CheckBoxDayOfWeek.Checked, _
            '                                                 Me.CheckBoxMobile_Operator.Checked, _
            '                                                 Me.CheckBoxAccess_Number.Checked, _
            '                                                 Me.CheckBoxPrice_Unit.Checked, _
            '                                                 Me.CheckBoxService_Id.Checked, _
            '                                                 Me.CheckBoxPartnerId.Checked, _
            '                                                 Me.CheckBoxContractCode.Checked)

        End If
    End Sub
    'Private Sub IsColumnDataGrid()
    '    If Me.CheckBoxMonth.Checked = True Then
    '        Me.DataGrid.Columns(1).Visible = True
    '    Else
    '        Me.DataGrid.Columns(1).Visible = False
    '    End If
    '    If Me.CheckBoxDayOfWeek.Checked = True Then
    '        Me.DataGrid.Columns(2).Visible = True
    '    Else
    '        Me.DataGrid.Columns(2).Visible = False
    '    End If
    '    If Me.CheckBoxMobile_Operator.Checked = True Then
    '        Me.DataGrid.Columns(3).Visible = True
    '    Else
    '        Me.DataGrid.Columns(3).Visible = False
    '    End If
    '    If Me.CheckBoxAccess_Number.Checked = True Then
    '        Me.DataGrid.Columns(4).Visible = True
    '    Else
    '        Me.DataGrid.Columns(4).Visible = False
    '    End If
    '    If Me.CheckBoxPrice_Unit.Checked = True Then
    '        Me.DataGrid.Columns(5).Visible = True
    '    Else
    '        Me.DataGrid.Columns(5).Visible = False
    '    End If
    '    If Me.CheckBoxService_Id.Checked = True Then
    '        Me.DataGrid.Columns(6).Visible = True
    '    Else
    '        Me.DataGrid.Columns(6).Visible = False
    '    End If
    '    If Me.CheckBoxPartnerId.Checked = True Then
    '        Me.DataGrid.Columns(12).Visible = True
    '    Else
    '        Me.DataGrid.Columns(12).Visible = False
    '    End If
    '    If Me.CheckBoxContractCode.Checked = True Then
    '        Me.DataGrid.Columns(13).Visible = True
    '    Else
    '        Me.DataGrid.Columns(13).Visible = False
    '    End If

    'End Sub

#End Region

End Class