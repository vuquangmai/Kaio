Imports System.Data.SqlClient
Imports Telerik.Web.UI
'Imports Telerik.Charting

Public Class ChartTrafficSummery
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU SMS THEO NGÀY"
            BindDictIndex()
            InitData()
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindPartner()
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)
        BindDate()
        BindRouting()
        BindRangeShortcode()
        BindShortcode()
        BindCate1()
        BindCate2(Me.RadDropDownListCate1_Id.SelectedItem.Value)
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDDHH(Me.DropDownListYear.SelectedItem.Value, _
                                      Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate, _
                                      Me.DropDownListFromHour, _
                                      Me.DropDownListToHour)
    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Where Id In (1,3,4,5,6,8,12,14) Order by Dept_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListDepartment_Id.Items.Clear()
        Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Dept_Code") & " [" & dt.Rows(i).Item("Dept_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.SMS & ") Order by Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Partner_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindPartner(ByVal Department_Id As Integer)
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.SMS
        If Department_Id > 0 Then
            sql = sql & " And Department_Id=" & Department_Id & ") "
        Else
            sql = sql & ") "
        End If
        sql = sql & " Order by Partner_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

        Me.RadDropDownListPartner_Id.Items.Clear()
        Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Partner_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindRouting()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Routing  Order by Routing_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListThirdParty.Items.Clear()
        Me.RadDropDownListThirdParty.Localization.AllItemsCheckedString = "--all--"
        Me.RadDropDownListThirdParty.Localization.CheckAllString = "--all--"

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListThirdParty.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Routing_Code"), dt.Rows(i).Item("ID")))
            Next
        End If
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListRangOfShortCode.Items
            item.Checked = True
        Next
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
    Private Sub BindContract(ByVal Partner_Id As Integer)
        Dim sql As String = "SELECT *  FROM Ccare_Management_Contract Where Service_Id= " & Constants.ServiceInfo.Id.SMS
        If Partner_Id > 0 Then
            sql = sql & " And Partner_Id='" & Partner_Id & "'"
        End If
        sql = sql & "  Order by Contract_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListContract_Code.Items.Clear()
        Me.RadDropDownListContract_Code.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListContract_Code.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Contract_Code") & " [" & dt.Rows(i).Item("Partner_Text") & "]", dt.Rows(i).Item("Contract_Code")))
            Next
        End If
    End Sub
    Private Sub BindCate1()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Service_Info Where Cate_Level=1 Order by Cate_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)

        Me.RadDropDownListCate1_Id.Items.Clear()
        Me.RadDropDownListCate1_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        Me.RadDropDownListCate1_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListCate1_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindCate2(ByVal Cate1_Id As Integer)
        Dim sql As String = "SELECT *  FROM SMS_DictIndex_Service_Info Where Cate_Level=2"
        If Cate1_Id > 0 Then
            sql = sql & " And  Root_Id='" & Cate1_Id & "'"
        End If
        sql = sql & "  Order by Cate_Name "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListCate2_Id.Items.Clear()
        Me.RadDropDownListCate2_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        Me.RadDropDownListCate2_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListCate2_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
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
    Protected Sub RadDropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListDepartment_Id.SelectedIndexChanged
        BindPartner(RadDropDownListDepartment_Id.SelectedItem.Value)
    End Sub

    Protected Sub RadDropDownListPartner_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListPartner_Id.SelectedIndexChanged
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)

    End Sub

    Protected Sub RadDropDownListCate1_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListCate1_Id.SelectedIndexChanged
        BindCate2(Me.RadDropDownListCate1_Id.SelectedItem.Value)

    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListMobileOperator.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDayOfWeek.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListThirdParty.Items
            item.Checked = True
        Next
        Me.RadChart1.Visible = False
        Me.RadChart2.Visible = False
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intPageSize As Integer = 1
        Dim intCurentPage As Integer = 1
        BindData(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = 1
        Dim intCurentPage As Integer = 1
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

        Dim vTable As String = "SMS_HQ_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromHour.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToHour.SelectedItem.Value)
        sql = "SELECT substring(date,7,2) Y, " & _
                              " SUM(MO) MO, SUM(MT) MT, SUM(CDR) CDR, SUM(MO_Error) MO_Error, SUM(MT_Error) MT_Error, SUM(CDR_Error) CDR_Error, SUM(MO_Refund) MO_Refund, " & _
                              " SUM(cast(Money_Total as decimal)) Money_Total, SUM(cast(Money_Share as decimal))  Money_Share, SUM(cast(Money_Operator as decimal))  Money_Operator," & _
                              " SUM(cast(Money_Total_Refund as decimal)) Money_Total_Refund, SUM(cast(Money_Share_Refund as decimal)) Money_Share_Refund, SUM(cast(Money_Operator_Refund as decimal)) Money_Operator_Refund," & _
                              " SUM(cast(Money_Total_Error as decimal)) Money_Total_Error, SUM(cast(Money_Share_Error as decimal)) Money_Share_Error, SUM(cast(Money_Operator_Error as decimal)) Money_Operator_Error " & _
                              " FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1 "
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And Date>='" & vFromDate & "' And Date<='" & vToDate & "'"
        End If
        If Me.RadDropDownListStatus.SelectedItem.Value = 1 Then
            sqlConditional = sqlConditional & " And Status_Id=0"
        ElseIf Me.RadDropDownListStatus.SelectedItem.Value = 2 Then
            sqlConditional = sqlConditional & " And Status_Id =-1"
        ElseIf Me.RadDropDownListStatus.SelectedItem.Value = 3 Then
            sqlConditional = sqlConditional & " And Status_Id >0"
        End If
        If Me.CheckBoxDepartment.Checked = True And Me.RadDropDownListDepartment_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Department_Id =" & Me.RadDropDownListDepartment_Id.SelectedItem.Value
        End If
        If Me.CheckBoxPartnerId.Checked = True And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Partner_Id =" & Me.RadDropDownListPartner_Id.SelectedItem.Value
        End If
        If Me.CheckBoxContractCode.Checked = True And Me.RadDropDownListContract_Code.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Contract_Code =N'" & Me.RadDropDownListContract_Code.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxThirdParty.Checked = True Then
            Dim CollectionThirdParty As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListThirdParty.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionThirdParty.Count = 0 Then
                Me.lblerror.Text = "Định tuyến không hợp lệ !"
                Exit Sub
            Else
                If CollectionThirdParty.Count < Me.RadDropDownListThirdParty.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionThirdParty
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  ThirdParty_Text In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxMobileOperator.Checked = True Then
            Dim CollectionMobileOperator As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListMobileOperator.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionMobileOperator.Count = 0 Then
                Me.lblerror.Text = "Mạng không hợp lệ !"
                Exit Sub
            Else
                If CollectionMobileOperator.Count < Me.RadDropDownListMobileOperator.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionMobileOperator
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Mobile_Operator In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxRangOfShortCode.Checked = True Then
            Dim CollectionRange As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListRangOfShortCode.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionRange.Count = 0 Then
                Me.lblerror.Text = "Dải số không hợp lệ !"
                Exit Sub
            Else
                If CollectionRange.Count < Me.RadDropDownListRangOfShortCode.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionRange
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Range_Short_Code In (" & sb.ToString() & ")"
                End If
            End If
        End If


        If Me.CheckBoxShortCode.Checked = True Then
            Dim CollectionShortCode As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListShortCode.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionShortCode.Count = 0 Then
                Me.lblerror.Text = "Đầu số không hợp lệ !"
                Exit Sub
            Else
                If CollectionShortCode.Count < Me.RadDropDownListShortCode.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionShortCode
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Short_Code In (" & sb.ToString() & ")"
                End If
            End If
        End If

        If Me.CheckBoxKeyword.Checked = True And Me.txtKeyword.Text.Trim <> "" Then
            If Me.CheckBoxAbsolute.Checked = True Then
                sqlConditional = sqlConditional & " And Key_Word='" & Me.txtKeyword.Text.Trim & "'"
            Else
                sqlConditional = sqlConditional & " And Key_Word like '" & Me.txtKeyword.Text.Trim & "%'"
            End If
        End If
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
        If Me.CheckBoxCate1_Id.Checked = True And Me.RadDropDownListCate1_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Cate1_Id =N'" & Me.RadDropDownListCate1_Id.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxCate2_Id.Checked = True And Me.RadDropDownListCate2_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Cate2_Id =N'" & Me.RadDropDownListCate2_Id.SelectedItem.Value & "'"
        End If
        sqlGroup = " GROUP BY substring(Date,7,2) "
        sqlOrder = " ORDER BY substring(Date,7,2) "
        sql = sql & sqlConditional & sqlGroup & sqlOrder
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringHQReport), sql)
            If dt.Rows.Count > 0 Then
                RadChart2.PlotArea.YAxis.Appearance.MinorGridLines.Visible = True

                'Data binding RadChart.
                RadChart2.DataSource = dt
                RadChart2.DataBind()
                Me.RadChart2.Visible = True
                RadChart1.DataSource = dt
                RadChart1.DataBind()
                Me.RadChart1.Visible = True
            Else
                Me.RadChart2.Visible = False
                Me.RadChart1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        ElseIf strAction = Constants.Action.Export Then
            'ExportData.ExportExcel._SMS.MobileTrafficSummery(sql, CurrentUser.UserName, Me.CheckBoxError.Checked, _
            '                                                 Me.CheckBoxRefund.Checked, _
            '                                                 Me.CheckBoxDepartment.Checked, _
            '                                                 Me.CheckBoxPartnerId.Checked, _
            '                                                 Me.CheckBoxContractCode.Checked, _
            '                                                 Me.CheckBoxThirdParty.Checked, _
            '                                                 Me.CheckBoxMobileOperator.Checked, _
            '                                                 Me.CheckBoxRangOfShortCode.Checked, _
            '                                                 Me.CheckBoxShortCode.Checked, _
            '                                                 Me.CheckBoxKeyword.Checked, _
            '                                                 Me.CheckBoxDayOfWeek.Checked, _
            '                                                 Me.CheckBoxDate.Checked, _
            '                                                 Me.CheckBoxHour.Checked, _
            '                                                 Me.CheckBoxCate1_Id.Checked, _
            '                                                 Me.CheckBoxCate2_Id.Checked)

        End If
    End Sub
    Sub ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Charting.ChartItemDataBoundEventArgs)
        'e.SeriesItem.ActiveRegion.Tooltip = "Tooltip"
        'e.SeriesItem.ActiveRegion.Tooltip += e.ChartSeries.Name & "(" & (DirectCast(e.DataItem, DataRowView))("Y").ToString() & "): " & Util.formatNumbers(e.SeriesItem.YValue)
    End Sub
    Protected Sub RadChart2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Charting.ChartItemDataBoundEventArgs) Handles RadChart2.ItemDataBound
        'If e.SeriesItem.YValue > 30 Then
        '    e.SeriesItem.ActiveRegion.Tooltip = "Attention! Temperature too high! " & Chr(10)
        'ElseIf e.SeriesItem.YValue < 10 Then
        '    e.SeriesItem.ActiveRegion.Tooltip = "Attention! Temperature too low! " & Chr(10)
        'End If
        e.SeriesItem.ActiveRegion.Tooltip += e.ChartSeries.Name & "(" & (DirectCast(e.DataItem, DataRowView))("Y").ToString() & "): " & (e.SeriesItem.YValue)
    End Sub
    Protected Sub RadChart1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Charting.ChartItemDataBoundEventArgs) Handles RadChart1.ItemDataBound
        e.SeriesItem.ActiveRegion.Tooltip += e.ChartSeries.Name & "(" & (DirectCast(e.DataItem, DataRowView))("Y").ToString() & "): " & (e.SeriesItem.YValue)
    End Sub
#End Region
End Class