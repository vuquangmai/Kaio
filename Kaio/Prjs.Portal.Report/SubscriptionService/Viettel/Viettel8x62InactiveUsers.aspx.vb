  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class Viettel8x62InactiveUsers
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO HỦY DỊCH VỤ 8x62"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        Me.RadDatePickerFromDate.SelectedDate = Now
        Me.RadDatePickerToDate.SelectedDate = Now
        BindService()
    End Sub
    Private Sub BindService()
        Dim sql As String = "SELECT * FROM p8x62_Subscription_Services  Order by Service_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_177"), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        If dt.Rows.Count > 0 Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Service_Name"), dt.Rows(i).Item("ID")))
                Next
            End If

        End If
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListService_Id.Items
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
        Dim sqlConditional As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "p8x62_Inactive_Users"
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerFromDate.SelectedDate.Value.Day)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Year) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Month) & Util.StringBuilder.ConvertDigit(Me.RadDatePickerToDate.SelectedDate.Value.Day)
        sql = "SELECT A.User_ID,A.Request_ID,A.Short_Code,A.Command_Code,A.RegisteredTime,A.Registration_Channel,A.CancelTime,B.Service_Name, " & _
                              " row_number() over( Order by A.CancelTime ) as RowNumber " & _
                              " From " & vTable & " A " & _
                              " Inner Join p8x62_Subscription_Services B " & _
                              " On A.Service_ID=B.Id"

        sqlConditional = sqlConditional & " WHERE 1=1"
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And convert(varchar,CancelTime,112)>='" & vFromDate & "' And convert(varchar,CancelTime,112)<='" & vToDate & "'"
        End If
        Dim CollectionServiceId As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListService_Id.CheckedItems
        Dim sb As New StringBuilder()
        If CollectionServiceId.Count = 0 Then
            Me.lblerror.Text = "Dịch vụ không hợp lệ !"
            Exit Sub
        Else
            If CollectionServiceId.Count < Me.RadDropDownListService_Id.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionServiceId
                    If sb.ToString = "" Then
                        sb.Append("'" + item.Value + "'")
                    Else
                        sb.Append(",'" + item.Value + "'")
                    End If
                Next
                sqlConditional = sqlConditional & " And  A.Service_ID In (" & sb.ToString() & ")"
            End If
        End If

        sql = sql & sqlConditional
        If strAction = Constants.Action.Search Then
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_177"), "SELECT count(*) Total FROM (" & sql & ") T")
            sql = "SELECT * FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_177"), sql)

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
#End Region

End Class