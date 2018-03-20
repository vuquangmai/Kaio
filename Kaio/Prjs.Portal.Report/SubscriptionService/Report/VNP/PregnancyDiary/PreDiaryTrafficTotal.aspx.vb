  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class PreDiaryTrafficTotal
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU DỊCH VỤ NHẬT KÝ MANG THAI"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindPartner()
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)
        BindDate()
        BindUrl()
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
        Dim sql As String = "SELECT * FROM System_Department Where Id In (4) Order by Dept_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListDepartment_Id.Items.Clear()
        Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.RadDropDownListDepartment_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Dept_Code") & " [" & dt.Rows(i).Item("Dept_Text") & "]", dt.Rows(i).Item("ID")))
                Next
            End If

        End If
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.PregnancyDiary & ") Order by Partner_Code"
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
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Where Id In (SELECT Partner_Id FROM  Ccare_Management_Contract WHERE Service_Id=" & Constants.ServiceInfo.Id.PregnancyDiary
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
    Private Sub BindContract(ByVal Partner_Id As Integer)
        Dim sql As String = "SELECT *  FROM Ccare_Management_Contract Where Service_Id= " & Constants.ServiceInfo.Id.PregnancyDiary
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
    Private Sub BindUrl()
        Dim sql As String = "SELECT * FROM Pregnancy_Diary_DictIndex_Url_Service  Order by Url"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.RadDropDownListUrl_Id.Items.Clear()
        Me.RadDropDownListUrl_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        Me.RadDropDownListUrl_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListUrl_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("Url"), dt.Rows(i).Item("Url_Text")))
            Next
        End If
    End Sub

#End Region
#Region "Ajax"


    Protected Sub RadDropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListDepartment_Id.SelectedIndexChanged
        BindPartner(RadDropDownListDepartment_Id.SelectedItem.Value)
    End Sub

    Protected Sub RadDropDownListPartner_Id_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadDropDownListPartner_Id.SelectedIndexChanged
        BindContract(Me.RadDropDownListPartner_Id.SelectedItem.Value)

    End Sub

#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblMoney_VMG_Partner.Text = 0
        Me.lblMoney_Partner_VMG.Text = 0
        Me.lblTotal_Registration.Text = 0
        Me.lblWAP_Registration.Text = 0
        Me.lblSMS_Registration.Text = 0
        Me.lblWeb_Registration.Text = 0
        Me.lblApp_Registration.Text = 0
        Me.lblTotal_Cancel.Text = 0
        Me.lblWAP_Cancel.Text = 0
        Me.lblSMS_Cancel.Text = 0
        Me.lblAPP_Cancel.Text = 0
        Me.lblWEB_Cancel.Text = 0
        Me.lblTotal_Renewal_Success.Text = 0
        Me.lblTotal_Renewal_Fail.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPriceUnit.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDayOfWeek.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropPackage_Text.Items
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

        Dim vTable As String = "Pregnancy_Diary_Data_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)
        Dim strSortField As String = ""
        If Me.DropDownListFieldList.SelectedItem.Value > 0 Then
            strSortField = SortFiedln(Me.DropDownListFieldList.SelectedItem.Value & "#" & Me.DropDownListSort.SelectedItem.Value)
        End If
        sql = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                              " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Code,'Unknown') end ) as Partner_Code," & _
                              " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                              " (case when '" & Me.CheckBoxPackage_Text.Checked & "'='False' then '--all--' else isnull(Package_Text,'Unknown') end ) as Package_Text," & _
                              " (case when '" & Me.CheckBoxPriceUnit.Checked & "'='False' then '--all--' else convert(varchar,Price_Unit) end ) as Price_Unit," & _
                              " (case when '" & Me.CheckBoxUrl_Id.Checked & "'='False' then '--all--' else convert(varchar,Url_Text) end ) as Url_Text," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " SUM(WAP_Registration) WAP_Registration, SUM(SMS_Registration) SMS_Registration,SUM(APP_Registration) APP_Registration, SUM(WEB_Registration) WEB_Registration, SUM(Total_Registration) Total_Registration, SUM(Registration_Charge) Registration_Charge," & _
                              " SUM(cast(Money_Registration_Ccare as decimal)) Money_Registration_Ccare, SUM(cast(Money_Registration_Telcos_VMG as decimal))  Money_Registration_Telcos_VMG , SUM(cast(Money_Registration_VMG_Telcos as decimal))  Money_Registration_VMG_Telcos," & _
                              " SUM(WAP_Cancel) WAP_Cancel, SUM(SMS_Cancel) SMS_Cancel,SUM(WEB_Cancel) WEB_Cancel, SUM(APP_Cancel) APP_Cancel, SUM(SYS_Cancel) SYS_Cancel, SUM(Total_Cancel) Total_Cancel," & _
                              " SUM(Total_Renewal_Success) Total_Renewal_Success, SUM(Total_Renewal_Fail) Total_Renewal_Fail," & _
                              " SUM(cast(Money_Renewal_Ccare as decimal))  Money_Renewal_Ccare,SUM(cast(Money_Renewal_Telcos_VMG as decimal))  Money_Renewal_Telcos_VMG,SUM(cast(Money_Renewal_VMG_Telcos as decimal))  Money_Renewal_VMG_Telcos,SUM(cast(Money_Renewal_VMG_Partner as decimal))  Money_Renewal_VMG_Partner,SUM(cast(Money_Renewal_Partner_VMG as decimal))  Money_Renewal_Partner_VMG," & _
                              " SUM(cast(Money_Download_1K as decimal)) Money_Download_1K, SUM(cast(Money_Download_2K as decimal))  Money_Download_2K, SUM(cast(Money_Download_3K as decimal))  Money_Download_3K, SUM(cast(Money_Download_5K as decimal))  Money_Download_5K, SUM(cast(Money_Download_10K as decimal))  Money_Download_10K," & _
                              " SUM(cast(Money_Download_Ccare as decimal)) Money_Download_Ccare, SUM(cast(Money_Download_Telcos_VMG as decimal)) Money_Download_Telcos_VMG,SUM(cast(Money_Download_VMG_Telcos as decimal)) Money_Download_VMG_Telcos," & _
                              " SUM(Total_Click) Total_Click, SUM(Total_Identify_User) Total_Identify_User, SUM(Total_Click_Identify_IP) Total_Click_Identify_IP, SUM(Total_Identify_User_Identify_IP) Total_Identify_User_Identify_IP, " & _
                              " SUM(cast(Total_Money_Ccare as decimal)) Total_Money_Ccare, SUM(cast(Total_Money_Telcos_VMG as decimal)) Total_Money_Telcos_VMG, SUM(cast(Total_Money_VMG_Telcos as decimal)) Total_Money_VMG_Telcos, SUM(cast(Total_Money_VMG_Partner as decimal)) Total_Money_VMG_Partner, SUM(cast(Total_Money_Partner_VMG as decimal)) Total_Money_Partner_VMG," & _
                              " SUM(cast(Active_Accumulated as decimal)) Active_Accumulated, SUM(cast(Cancel_Accumulated as decimal)) Cancel_Accumulated," & _
                              " row_number() over( Order by substring(date,1,4) " & IIf(strSortField.ToString.Trim = "", "", "," & strSortField) & " ) as RowNumber " & _
                              " FROM " & vTable
        sqlTotal = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                               " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Code,'Unknown') end ) as Partner_Code," & _
                              " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                              " (case when '" & Me.CheckBoxPackage_Text.Checked & "'='False' then '--all--' else isnull(Package_Text,'Unknown') end ) as Package_Text," & _
                              " (case when '" & Me.CheckBoxPriceUnit.Checked & "'='False' then '--all--' else convert(varchar,Price_Unit) end ) as Price_Unit," & _
                              " (case when '" & Me.CheckBoxUrl_Id.Checked & "'='False' then '--all--' else convert(varchar,Url_Text) end ) as Url_Text," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " SUM(WAP_Registration) WAP_Registration, SUM(SMS_Registration) SMS_Registration,SUM(APP_Registration) APP_Registration, SUM(WEB_Registration) WEB_Registration, SUM(Total_Registration) Total_Registration, SUM(Registration_Charge) Registration_Charge," & _
                              " SUM(cast(Money_Registration_Ccare as decimal)) Money_Registration_Ccare, SUM(cast(Money_Registration_Telcos_VMG as decimal))  Money_Registration_Telcos_VMG , SUM(cast(Money_Registration_VMG_Telcos as decimal))  Money_Registration_VMG_Telcos," & _
                              " SUM(WAP_Cancel) WAP_Cancel, SUM(SMS_Cancel) SMS_Cancel,SUM(WEB_Cancel) WEB_Cancel, SUM(APP_Cancel) APP_Cancel, SUM(SYS_Cancel) SYS_Cancel, SUM(Total_Cancel) Total_Cancel," & _
                              " SUM(Total_Renewal_Success) Total_Renewal_Success, SUM(Total_Renewal_Fail) Total_Renewal_Fail," & _
                              " SUM(cast(Money_Renewal_Ccare as decimal))  Money_Renewal_Ccare,SUM(cast(Money_Renewal_Telcos_VMG as decimal))  Money_Renewal_Telcos_VMG,SUM(cast(Money_Renewal_VMG_Telcos as decimal))  Money_Renewal_VMG_Telcos,SUM(cast(Money_Renewal_VMG_Partner as decimal))  Money_Renewal_VMG_Partner,SUM(cast(Money_Renewal_Partner_VMG as decimal))  Money_Renewal_Partner_VMG," & _
                              " SUM(cast(Money_Download_1K as decimal)) Money_Download_1K, SUM(cast(Money_Download_2K as decimal))  Money_Download_2K, SUM(cast(Money_Download_3K as decimal))  Money_Download_3K, SUM(cast(Money_Download_5K as decimal))  Money_Download_5K, SUM(cast(Money_Download_10K as decimal))  Money_Download_10K," & _
                              " SUM(cast(Money_Download_Ccare as decimal)) Money_Download_Ccare, SUM(cast(Money_Download_Telcos_VMG as decimal)) Money_Download_Telcos_VMG,SUM(cast(Money_Download_VMG_Telcos as decimal)) Money_Download_VMG_Telcos," & _
                              " SUM(Total_Click) Total_Click, SUM(Total_Identify_User) Total_Identify_User, SUM(Total_Click_Identify_IP) Total_Click_Identify_IP, SUM(Total_Identify_User_Identify_IP) Total_Identify_User_Identify_IP, " & _
                              " SUM(cast(Total_Money_Ccare as decimal)) Total_Money_Ccare, SUM(cast(Total_Money_Telcos_VMG as decimal)) Total_Money_Telcos_VMG, SUM(cast(Total_Money_VMG_Telcos as decimal)) Total_Money_VMG_Telcos, SUM(cast(Total_Money_VMG_Partner as decimal)) Total_Money_VMG_Partner, SUM(cast(Total_Money_Partner_VMG as decimal)) Total_Money_Partner_VMG," & _
                              " SUM(cast(Active_Accumulated as decimal)) Active_Accumulated, SUM(cast(Cancel_Accumulated as decimal)) Cancel_Accumulated " & _
                            " FROM " & vTable
        sqlConditional = sqlConditional & " WHERE 1=1 "
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " And Date>='" & vFromDate & "' And Date<='" & vToDate & "'"
        End If

        If Me.CheckBoxPartnerId.Checked = True And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Partner_Id =" & Me.RadDropDownListPartner_Id.SelectedItem.Value
        End If
        If Me.CheckBoxContractCode.Checked = True And Me.RadDropDownListContract_Code.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Contract_Code =N'" & Me.RadDropDownListContract_Code.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxPackage_Text.Checked = True Then
            Dim CollectionPackageId As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropPackage_Text.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPackageId.Count = 0 Then
                Me.lblerror.Text = "Loại giao dịch không hợp lệ !"
                Exit Sub
            Else
                If CollectionPackageId.Count < Me.RadDropPackage_Text.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPackageId
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
        If Me.CheckBoxPriceUnit.Checked = True Then
            Dim CollectionPriceUnit As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPriceUnit.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPriceUnit.Count = 0 Then
                Me.lblerror.Text = "Đơn giá không hợp lệ !"
                Exit Sub
            Else
                If CollectionPriceUnit.Count < Me.RadDropDownListPriceUnit.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPriceUnit
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  Price_Unit In (" & sb.ToString() & ")"
                End If
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
        If Me.CheckBoxUrl_Id.Checked = True And Me.RadDropDownListUrl_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " And Url_Text =N'" & Me.RadDropDownListUrl_Id.SelectedItem.Value & "'"
        End If

        sqlGroup = " GROUP BY substring(Date,1,4),substring(Date,5,2) "
        sqlOrder = " ORDER BY Year "

        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,7,2)"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",CAST(day as INT)"
            End If
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", Partner_Code"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Partner_Code"
            End If
        End If
        If Me.CheckBoxContractCode.Checked = True Then
            sqlGroup = sqlGroup & ", Contract_Code"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Contract_Code"
            End If
        End If
        If Me.CheckBoxPackage_Text.Checked = True Then
            sqlGroup = sqlGroup & ", Package_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Package_Text"
            End If
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            sqlGroup = sqlGroup & ", Price_Unit"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Price_Unit"
            End If
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            sqlGroup = sqlGroup & ", DayOfWeek_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",DayOfWeek_Text"
            End If
        End If
        If Me.CheckBoxUrl_Id.Checked = True Then
            sqlGroup = sqlGroup & ", Url_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Url_Text"
            End If
        End If

        If Me.DropDownListFieldFilter.SelectedItem.Value > 0 Then
            If Me.DropDownListFieldFilter.SelectedItem.Value = 1 Then
                sqlCriteria = " HAVING SUM(cast(Money_Ccare as decimal)) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 2 Then
                sqlCriteria = " HAVING SUM(Total_Registration) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 3 Then
                sqlCriteria = " HAVING SUM(Total_Cancel) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 4 Then
                sqlCriteria = " HAVING SUM(Total_Renewal_Success) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            End If
        End If
        sql = sql & sqlConditional & sqlGroup & sqlCriteria
        sqlTotal = sqlTotal & sqlConditional & sqlGroup & sqlCriteria

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(WAP_Registration) WAP_Registration, SUM(SMS_Registration) SMS_Registration,SUM(APP_Registration) APP_Registration, SUM(WEB_Registration) WEB_Registration, SUM(Total_Registration) Total_Registration, SUM(Registration_Charge) Registration_Charge," & _
                                 " SUM(cast(Money_Registration_Ccare as decimal)) Money_Registration_Ccare, SUM(cast(Money_Registration_Telcos_VMG as decimal))  Money_Registration_Telcos_VMG , SUM(cast(Money_Registration_VMG_Telcos as decimal))  Money_Registration_VMG_Telcos," & _
                                 " SUM(WAP_Cancel) WAP_Cancel, SUM(SMS_Cancel) SMS_Cancel,SUM(WEB_Cancel) WEB_Cancel, SUM(APP_Cancel) APP_Cancel, SUM(SYS_Cancel) SYS_Cancel, SUM(Total_Cancel) Total_Cancel," & _
                                 " SUM(Total_Renewal_Success) Total_Renewal_Success, SUM(Total_Renewal_Fail) Total_Renewal_Fail," & _
                                 " SUM(cast(Money_Renewal_Ccare as decimal))  Money_Renewal_Ccare,SUM(cast(Money_Renewal_Telcos_VMG as decimal))  Money_Renewal_Telcos_VMG,SUM(cast(Money_Renewal_VMG_Telcos as decimal))  Money_Renewal_VMG_Telcos,SUM(cast(Money_Renewal_VMG_Partner as decimal))  Money_Renewal_VMG_Partner,SUM(cast(Money_Renewal_Partner_VMG as decimal))  Money_Renewal_Partner_VMG," & _
                                 " SUM(cast(Money_Download_1K as decimal)) Money_Download_1K, SUM(cast(Money_Download_2K as decimal))  Money_Download_2K, SUM(cast(Money_Download_3K as decimal))  Money_Download_3K, SUM(cast(Money_Download_5K as decimal))  Money_Download_5K, SUM(cast(Money_Download_10K as decimal))  Money_Download_10K," & _
                                 " SUM(cast(Money_Download_Ccare as decimal)) Money_Download_Ccare, SUM(cast(Money_Download_Telcos_VMG as decimal)) Money_Download_Telcos_VMG,SUM(cast(Money_Download_VMG_Telcos as decimal)) Money_Download_VMG_Telcos," & _
                                 " SUM(Total_Click) Total_Click, SUM(Total_Identify_User) Total_Identify_User, SUM(Total_Click_Identify_IP) Total_Click_Identify_IP, SUM(Total_Identify_User_Identify_IP) Total_Identify_User_Identify_IP, " & _
                                 " SUM(cast(Total_Money_Ccare as decimal)) Total_Money_Ccare, SUM(cast(Total_Money_Telcos_VMG as decimal)) Total_Money_Telcos_VMG, SUM(cast(Total_Money_VMG_Telcos as decimal)) Total_Money_VMG_Telcos, SUM(cast(Total_Money_VMG_Partner as decimal)) Total_Money_VMG_Partner, SUM(cast(Total_Money_Partner_VMG as decimal)) Total_Money_Partner_VMG," & _
                                 " SUM(cast(Active_Accumulated as decimal)) Active_Accumulated, SUM(cast(Cancel_Accumulated as decimal)) Cancel_Accumulated," & _
                                 " COUNT(*) Total FROM (" & sqlTotal & ") T"
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
                IsColumnDataGrid()
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Money_VMG_Telcos"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Money_Telcos_VMG"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Money_Ccare"), 0)
                Me.lblMoney_VMG_Partner.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Money_VMG_Partner"), 0)
                Me.lblMoney_Partner_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Money_Partner_VMG"), 0)
                Me.lblTotal_Registration.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Registration"), 0)
                Me.lblWAP_Registration.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("WAP_Registration"), 0)
                Me.lblSMS_Registration.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("SMS_Registration"), 0)
                Me.lblApp_Registration.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("APP_Registration"), 0)
                Me.lblWeb_Registration.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("WEB_Registration"), 0)
                Me.lblTotal_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Cancel"), 0)
                Me.lblWAP_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("WAP_Cancel"), 0)
                Me.lblSMS_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("SMS_Cancel"), 0)
                Me.lblWEB_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("WEB_Cancel"), 0)
                Me.lblAPP_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("APP_Cancel"), 0)
                Me.lblSYS_Cancel.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("SYS_Cancel"), 0)
                Me.lblTotal_Renewal_Success.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Renewal_Success"), 0)
                Me.lblTotal_Renewal_Fail.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total_Renewal_Fail"), 0)
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._PregnancyDiary.PregnancyDiaryTrafficTotal(sql, CurrentUser.UserName, _
                                                             Me.CheckBoxDate.Checked, _
                                                             Me.CheckBoxDayOfWeek.Checked, _
                                                             Me.CheckBoxPackage_Text.Checked, _
                                                             Me.CheckBoxPriceUnit.Checked, _
                                                             Me.CheckBoxRegister.Checked, _
                                                             Me.CheckBoxCancel.Checked, _
                                                             Me.CheckBoxRenewal.Checked, _
                                                             Me.CheckBoxPartnerId.Checked, _
                                                             Me.CheckBoxContractCode.Checked, _
                                                             Me.CheckBoxUrl_Id.Checked)

        End If
    End Sub
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxRegister.Checked = True Then
            Me.DataGrid.Columns(9).Visible = True
            Me.DataGrid.Columns(10).Visible = True
            Me.DataGrid.Columns(11).Visible = True
            Me.DataGrid.Columns(12).Visible = True
            Me.DataGrid.Columns(13).Visible = True
            Me.DataGrid.Columns(14).Visible = True
        Else
            Me.DataGrid.Columns(9).Visible = False
            Me.DataGrid.Columns(10).Visible = False
            Me.DataGrid.Columns(11).Visible = False
            Me.DataGrid.Columns(12).Visible = False
            Me.DataGrid.Columns(13).Visible = False
            Me.DataGrid.Columns(14).Visible = False
        End If
        If Me.CheckBoxCancel.Checked = True Then
            Me.DataGrid.Columns(15).Visible = True
            Me.DataGrid.Columns(16).Visible = True
            Me.DataGrid.Columns(17).Visible = True
            Me.DataGrid.Columns(18).Visible = True
            Me.DataGrid.Columns(19).Visible = True
            Me.DataGrid.Columns(20).Visible = True
        Else
            Me.DataGrid.Columns(15).Visible = False
            Me.DataGrid.Columns(16).Visible = False
            Me.DataGrid.Columns(17).Visible = False
            Me.DataGrid.Columns(18).Visible = False
            Me.DataGrid.Columns(19).Visible = False
            Me.DataGrid.Columns(20).Visible = False
        End If
        If Me.CheckBoxRenewal.Checked = True Then
            Me.DataGrid.Columns(21).Visible = True
            Me.DataGrid.Columns(22).Visible = True
            Me.DataGrid.Columns(23).Visible = True
        Else
            Me.DataGrid.Columns(21).Visible = False
            Me.DataGrid.Columns(22).Visible = False
            Me.DataGrid.Columns(23).Visible = False
        End If
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(1).Visible = True
        Else
            Me.DataGrid.Columns(1).Visible = False
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            Me.DataGrid.Columns(2).Visible = True
        Else
            Me.DataGrid.Columns(2).Visible = False
        End If
        If Me.CheckBoxPackage_Text.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(25).Visible = True
        Else
            Me.DataGrid.Columns(25).Visible = False
        End If
        If Me.CheckBoxContractCode.Checked = True Then
            Me.DataGrid.Columns(26).Visible = True
        Else
            Me.DataGrid.Columns(26).Visible = False
        End If
        If Me.CheckBoxUrl_Id.Checked = True Then
            Me.DataGrid.Columns(27).Visible = True
        Else
            Me.DataGrid.Columns(27).Visible = False
        End If
    End Sub
    Private Function SortFiedln(ByVal strIn As String) As String
        Dim result As String = ""
        Select Case strIn

            Case "2#1"
                result = "SUM(Total_Registration) desc"
            Case "2#2"
                result = "SUM(Total_Registration) asc"
            Case "3#1"
                result = "SUM(Total_Cancel) desc"
            Case "3#2"
                result = "SUM(Total_Cancel) asc"
            Case "4#1"
                result = "SUM(Total_Renewal) desc"
            Case "4#2"
                result = "SUM(Total_Renewal) asc"
            Case "1#1"
                result = "SUM(cast(Total_Money_Ccare as decimal)) desc"
            Case "1#2"
                result = "SUM(cast(Total_Money_Ccare as decimal)) asc"
        End Select
        Return result
    End Function
#End Region
End Class