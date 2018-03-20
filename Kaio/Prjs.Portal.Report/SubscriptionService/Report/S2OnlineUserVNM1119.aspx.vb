  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineUserVNM1119
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO ĐĂNG KÝ, HỦY DỊCH VỤ 1119 - V//"
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindPartner()
        BindDate()
        BindServiceId()
        InitData()
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM S2_TTND_Partners WHERE PartnerID>0 Order by PartnerName "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerID")))
            Next
        End If
    End Sub
    Private Sub BindServiceId()
        Dim sql As String = "SELECT * FROM S2_Vnm_Services Order by ServiceName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), Sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("ServiceName"), dt.Rows(i).Item("ServiceId")))
            Next
        End If
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListChannel.Items
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
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim vTable As String = "S2_Vnm_Users"
        Dim vFromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim vToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        sql = "SELECT  YEAR(A.SubscriptionTime) as vYear , " & _
              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  convert(varchar,month(A.SubscriptionTime)) end) as vMonth," & _
              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,A.SubscriptionTime) end ) as vDate," & _
              " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  DATENAME(hour, A.SubscriptionTime) end ) as vHour, " & _
              " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else A.User_id end ) as User_Id, " & _
              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,B.service_name)  end ) as vService_Name,  " & _
              " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,C.PartnerName) end ) as vPartnerName," & _
              " COUNT(*) Total,  row_number() over( Order by YEAR(A.SubscriptionTime) desc) as RowNumber " & _
              " FROM " & vTable & " A LEFT JOIN S2_TTKD_Services B on A.Service_ID=B.Id " & _
              " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID "

        sqlTotal = "SELECT  YEAR(A.SubscriptionTime) as vYear , " & _
              " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  convert(varchar,month(A.SubscriptionTime)) end) as vMonth," & _
              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,A.SubscriptionTime) end ) as vDate," & _
              " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  DATENAME(hour, A.SubscriptionTime) end ) as vHour, " & _
              " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else A.User_id end ) as User_Id, " & _
              " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,B.service_name)  end ) as vService_Name,  " & _
              " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,C.PartnerName) end ) as vPartnerName," & _
              " COUNT(*) Total " & _
              " FROM " & vTable & " A LEFT JOIN S2_GPC_TTND_Services B on A.Service_ID=B.Service_ID " & _
              " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID "

        sqlConditional = " WHERE A.Status=" & Me.DropDownListStatus.SelectedItem.Value
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " AND CONVERT(varchar, A.SubscriptionTime,112) >='" & vFromDate & "' AND CONVERT(varchar ,A.SubscriptionTime,112)<='" & vToDate & "'"
        End If
        If Me.CheckBoxService_Id.Checked And Me.RadDropDownListService_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " AND CONVERT(nvarchar,B.Service_ID) ='" & Me.RadDropDownListService_Id.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxUser_Id.Checked = True And Me.txtUser_Id.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and CONVERT(nvarchar,A.User_id) =N'" & Me.txtUser_Id.Text.Trim & "'"
        End If
        If Me.CheckBoxPartnerId.Checked And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and CONVERT(nvarchar,C.PartnerID)=N'" & Me.RadDropDownListPartner_Id.SelectedItem.Value & "'"
        End If
        sqlGroup = " GROUP BY YEAR(A.SubscriptionTime)"
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", C.PartnerName"
        End If
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ",CONVERT(varchar,month(A.SubscriptionTime)) "
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", DATENAME(day,A.SubscriptionTime)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ",  DATENAME(hour, A.SubscriptionTime) "
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxService_Id.Checked Then
            sqlGroup = sqlGroup & ", CONVERT(nvarchar,B.service_name) "
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ", CONVERT(nvarchar,A.Registration_Channel) "
        End If
        If Me.CheckBoxUser_Id.Checked Then
            sqlGroup = sqlGroup & ",  A.User_id "
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT  COUNT(*) TotalRecord, SUM(Total) TotalUser From  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " AND  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            Dim TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            pager1.ItemCount = TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & TotalCount
                Next
                IsColumnDataGrid()
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
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxMonth.Checked = True Then
            Me.DataGrid.Columns(2).Visible = True
        Else
            Me.DataGrid.Columns(2).Visible = False
        End If
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxHour.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxUser_Id.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If
    End Sub
#End Region
End Class