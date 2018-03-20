Public Class MobileTrafficOnlineMT
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "TRA CỨU LOG GIAO DỊCH MT"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindRangeShortcode()
        BindShortcode()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.MMDDHHMI(Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate, _
                                      Me.DropDownListFromHour, _
                                      Me.DropDownListToHour, _
                                      Me.DropDownListFromMinute, _
                                      Me.DropDownListToMinute)
    End Sub
    Private Sub BindRangeShortcode()
        Dim sql As String = "SELECT distinct(Range_Of_Short_Code) Range_Of_Short_Code  FROM SMS_DictIndex_Short_Code  Order by Range_Of_Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListRangOfShortCode.Items.Clear()
        Me.RadDropDownListRangOfShortCode.Localization.AllItemsCheckedString = "--all--"
        Me.RadDropDownListRangOfShortCode.Localization.CheckAllString = "--all--"

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListRangOfShortCode.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Range_Of_Short_Code"), dt.Rows(i).Item("Range_Of_Short_Code")))
            Next
        End If
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListRangOfShortCode.Items
            ' If item.Text.Trim = "--all--" Then
            item.Checked = True
            'End If
        Next
    End Sub
    Private Sub BindShortcode()
        Dim sql As String = "SELECT *  FROM SMS_DictIndex_Short_Code Where Id>0 "
        Dim collection As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListRangOfShortCode.CheckedItems
        Dim sb As New StringBuilder()

        If collection.Count = 0 Then
            Me.lblerror.Text = "Dải số không hợp lệ !"
            Me.RadDropDownListShortCode.Items.Clear()
            Me.RadDropDownListShortCode.CheckBoxes = False
            Exit Sub
        Else
            Me.RadDropDownListShortCode.CheckBoxes = True
            If collection.Count < Me.RadDropDownListRangOfShortCode.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In collection
                    If sb.ToString = "" Then
                        sb.Append("'" + item.Text + "'")
                    Else
                        sb.Append(",'" + item.Text + "'")
                    End If
                Next
                sql = sql & " And  Range_Of_Short_Code In (" & sb.ToString() & ")"
            End If
        End If

        sql = sql & "  Order by Short_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListShortCode.Items.Clear()
        Me.RadDropDownListShortCode.Localization.AllItemsCheckedString = "--all--"
        Me.RadDropDownListShortCode.Localization.CheckAllString = "--all--"
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListShortCode.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListShortCode.Items
            item.Checked = True
        Next
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Util.ControlData.LoadControlMMDDHH(Me.DropDownListYear.SelectedItem.Value, _
                                   Me.DropDownListMonth.SelectedItem.Value, _
                                   Me.DropDownListFromDate, _
                                   Me.DropDownListToDate, _
                                   Me.DropDownListFromHour, _
                                   Me.DropDownListToHour)
    End Sub
    Protected Sub RadDropDownListRangOfShortCode_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListRangOfShortCode.SelectedIndexChanged
        BindShortcode()
    End Sub

#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListMobileOperator.Items
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
        'BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Me.txtUser_Id.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        Dim sql As String = ""
        For j As Integer = Me.DropDownListFromDate.SelectedItem.Value To Me.DropDownListToDate.SelectedItem.Value
            If sql = "" Then
                sql = BuildDataTable(j)
            Else
                sql = sql & " union " & BuildDataTable(j)
            End If
        Next
        BindData(intPageSize, intCurentPage, Constants.Action.Search, sql)

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Me.txtUser_Id.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        Dim sql As String = ""
        For j As Integer = Me.DropDownListFromDate.SelectedItem.Value To Me.DropDownListToDate.SelectedItem.Value
            If sql = "" Then
                sql = BuildDataTable(j)
            Else
                sql = sql & " union " & BuildDataTable(j)
            End If
        Next
        BindData(intPageSize, intCurentPage, Constants.Action.Search, sql)
    End Sub
#End Region
#Region "Bind Data"
    Private Function BuildDataTable(ByVal j As Integer) As String
        Dim sql As String = ""
        Dim sqlConditional As String = ""
        Dim vTable As String = "mt" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vStartTime As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromHour.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromMinute.SelectedItem.Value)
        Dim vEndTime As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToHour.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToMinute.SelectedItem.Value)
        sqlConditional = " WHERE date_format(loggingTime,'%Y%m%d%H%i') >=" & vStartTime & " and date_format(loggingTime,'%Y%m%d%H%i')<= " & vEndTime
        If DropDownListStatus.SelectedItem.Value > -1 Then
            If Me.DropDownListStatus.SelectedItem.Value = 0 Then
                sqlConditional = sqlConditional & " AND status=" & Me.DropDownListStatus.SelectedItem.Value
            Else
                sqlConditional = sqlConditional & " AND status<>0"
            End If
        End If

        Dim CollectionMobileOperator As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListMobileOperator.CheckedItems
        Dim sb As New StringBuilder()
        If CollectionMobileOperator.Count = 0 Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Return ""
        Else
            If CollectionMobileOperator.Count < Me.RadDropDownListMobileOperator.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionMobileOperator
                    If sb.ToString = "" Then
                        sb.Append("'" + item.Text + "'")
                    Else
                        sb.Append(",'" + item.Text + "'")
                    End If
                Next
                sqlConditional = sqlConditional & " AND  operator In (" & sb.ToString() & ")"
            End If
        End If

        Dim CollectionShortCode As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListShortCode.CheckedItems
        sb = New StringBuilder()
        If CollectionShortCode.Count = 0 Then
            Me.lblerror.Text = "Đầu số không hợp lệ !"
            Return ""
        Else
            If CollectionShortCode.Count < Me.RadDropDownListShortCode.Items.Count Then
                For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionShortCode
                    If sb.ToString = "" Then
                        sb.Append("'" + item.Text + "'")
                    Else
                        sb.Append(",'" + item.Text + "'")
                    End If
                Next
                sqlConditional = sqlConditional & " AND  sender In (" & sb.ToString() & ")"
            End If
        End If

        If Me.txtKeyWord.Text.Trim <> "" Then
            If Me.CheckBoxAbsolute.Checked = True Then
                sqlConditional = sqlConditional & " AND keyword='" & Me.txtKeyWord.Text.Trim & "'"
            Else
                sqlConditional = sqlConditional & " AND keyword like '" & Me.txtKeyWord.Text.Trim & "%'"
            End If
        End If
        If Me.txtUser_Id.Text.Trim <> "" Then
            Dim User_id As String = Me.txtUser_Id.Text.Trim
            If User_id.StartsWith(0) = True Then
                User_id = "84" & User_id.Substring(1)
            ElseIf User_id.StartsWith(84) = False Then
                User_id = "84" & User_id
            End If
            sqlConditional = sqlConditional & " AND receiver='" & User_id & "'"
        End If
        sql = "SELECT id, sender, receiver, msgdata, udhdata, keyword, thirdparty, receive_time, send_time, deliver_time, operator, account, service_uri, gateway, node, ip, content_type, (CASE message_type WHEN '1' THEN 'Charging' WHEN '2' THEN 'ReFund'  WHEN '0' THEN 'No Charge' ELSE 'Unknown' END) message_type, number_message, if(status like '0' ,'success',concat('<font color=red>',error_message,'</font>')) status, error_no, error_message, request_id, autotimestamp, priority, dlrmask, notes, money, process_result, DATE_FORMAT(loggingTime,'%Y-%m-%d %H:%i:%s') loggingTime " & _
            " FROM " & vTable & Util.StringBuilder.ConvertDigit(j)
        Return "(" & sql & sqlConditional & ")"

    End Function
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String, ByVal sqlExc As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = "SELECT COUNT(*) Total FROM (" & sqlExc & ") T"
        Dim sql As String = sqlExc & " LIMIT " & LowerBand & ", " & UpperBand
        If strAction = Constants.Action.Search Then
            Dim dtPageCount As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_EMS_Slave"), sqlTotal)
            Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_EMS_Slave"), sql)
            Dim TotalCount As Integer = dtPageCount.Rows(0).Item("Total")
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                DataGrid.Visible = True
                pager1.Visible = True
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & TotalCount
                Next
            Else
                DataGrid.Visible = False
                pager1.Visible = False
            End If
        Else

        End If
    End Sub
#End Region
End Class