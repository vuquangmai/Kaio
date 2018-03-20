Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class MGameReportKpi
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO KPI DỊCH VỤ M-GAME"
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
        BindPartnerd()
    End Sub
    Private Sub BindPartnerd()
        Dim sql As String = ""
        If CurrentUser.PartnerId > 0 Then
            sql = "SELECT * FROM Ccare_Management_Partner Where Id =" & CurrentUser.PartnerId & " Order by Partner_Code"
        Else
            sql = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.MGame & ") Order by Partner_Code"
        End If
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
       Me.RadDropDownListPartner_Id.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Partner_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPartner_Id.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPacket.Items
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

        Dim vTable As String = "MGame_Data_" & Me.RadDatePickerFromDate.SelectedDate.Value.Year
        Dim vFromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDatePickerFromDate.SelectedDate.Value, "")
        Dim vToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadDatePickerToDate.SelectedDate.Value, "")
        sql = "SELECT substring(Date,1,4) as Year ," & _
                " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Text,'Unknown') end ) as Partner_Text," & _
                " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else Date end ) as Date," & _
                " (case when '" & Me.CheckBoxPacket.Checked & "'='False' then '--all--' else Package_Text   end ) as Package_Text," & _
                " SUM(isnull(Active_Member,0)) Active_Member, " & _
                " SUM(isnull(Cancel_Member,0)) Cancel_Member, " & _
                " SUM(isnull(Total_Registration,0)) Total_Registration, " & _
                " SUM(isnull(WAP_Registration,0)) WAP_Registration, " & _
                " SUM(isnull(SMS_Registration,0)) SMS_Registration, " & _
                " SUM(isnull(SMS_Cancel,0)) SMS_Cancel, " & _
                " SUM(isnull(WAP_Cancel,0)) WAP_Cancel, " & _
                " SUM(isnull(Total_Cancel,0)) Total_Cancel, " & _
                " SUM(isnull(Renewal_Success,0)) Renewal_Success, " & _
                " SUM(isnull(Renewal_Error,0)) Renewal_Error, " & _
                " SUM(isnull(Total_Renewal,0)) Total_Renewal, " & _
                " SUM(isnull(Money_Renewal,0)) Money_Renewal, " & _
                " SUM(isnull(Total_Download_Game,0)) Total_Download_Game, " & _
                " SUM(isnull(Money_Download_Game,0)) Money_Download_Game, " & _
                " SUM(isnull(Money_Ccare,0)) Money_Ccare, " & _
                " SUM(isnull(Growth_User_Day,0)) Growth_User_Day, " & _
                " row_number() over( Order by substring(Date,1,4)  ) as RowNumber " & _
                "  FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1"
        If CurrentUser.PartnerId > 0 Then
            sqlConditional = sqlConditional & " And Partner_Id=" & CurrentUser.PartnerId
        End If
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And Date>='" & vFromDate & "' And Date<='" & vToDate & "'"
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Dim CollectionServiceId As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPartner_Id.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionServiceId.Count = 0 Then
                Me.lblerror.Text = "Đối tác không hợp lệ !"
                Exit Sub
            Else
                If CollectionServiceId.Count < Me.RadDropDownListPartner_Id.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionServiceId
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Partner_Id In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxPacket.Checked = True Then
            Dim CollectionPacket As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPacket.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPacket.Count = 0 Then
                Me.lblerror.Text = "Gói dịch vụ không hợp lệ !"
                Exit Sub
            Else
                If CollectionPacket.Count < Me.RadDropDownListPacket.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPacket
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Package_Id In (" & sb.ToString() & ")"
                End If
            End If
        End If


        sqlGroup = " GROUP BY substring(Date,1,4)"
        sqlOrder = " ORDER BY Year "
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", Date "
            sqlOrder = sqlOrder & ",Date"
        End If


        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", Partner_Text"
            sqlOrder = sqlOrder & ",Partner_Text"
        End If
        If Me.CheckBoxPacket.Checked = True Then
            sqlGroup = sqlGroup & ", Package_Text"
        End If
        sql = sql & sqlConditional & sqlGroup

        If strAction = Constants.Action.Search Then
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), "SELECT count(*) Total FROM (" & sql & ") T")
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
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            sql = sql & sqlOrder
            'ExportData.ExportExcel._S2.S2KpiViGame9029(sql)
        End If
    End Sub
#End Region
End Class