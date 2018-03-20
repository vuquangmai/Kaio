Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class MobileTrafficSummery
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU SMS THEO NGÀY"
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
        Me.lblTotalMO.Text = 0
        Me.lblTotalMT.Text = 0
        Me.lblTotalCDR.Text = 0
        Me.lblMoney_Total.Text = 0
        Me.lblMoney_Share.Text = 0
        Me.lblMoney_Operator.Text = 0
        Me.lblTotalMOErr.Text = 0
        Me.lblTotalMTErr.Text = 0
        Me.lblTotalCDRErr.Text = 0
        Me.lblMoney_Total_Error.Text = 0
        Me.lblMoney_Share_Error.Text = 0
        Me.lblMoney_Operator_Error.Text = 0
        Me.lblMoney_Total_Refund.Text = 0
        Me.lblMoney_Share_Refund.Text = 0
        Me.lblMoney_Operator_Refund.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListMobileOperator.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListDayOfWeek.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListThirdParty.Items
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

        Dim vTable As String = "SMS_HQ_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromHour.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToHour.SelectedItem.Value)
        Dim strSortField As String = ""
        If Me.DropDownListFieldList.SelectedItem.Value > 0 Then
            strSortField = SortFiedln(Me.DropDownListFieldList.SelectedItem.Value & "#" & Me.DropDownListSort.SelectedItem.Value)
        End If
        sql = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                              " (case when '" & Me.CheckBoxDepartment.Checked & "'='False' then '--all--' else isnull(Department_Text,'Unknown') end ) as Department_Text," & _
                              " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Text,'Unknown') end ) as Partner_Text," & _
                              " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                              " (case when '" & Me.CheckBoxThirdParty.Checked & "'='False' then '--all--' else isnull(ThirdParty_Text,'Unknown') end ) as ThirdParty_Text," & _
                              " (case when '" & Me.CheckBoxMobileOperator.Checked & "'='False' then '--all--' else isnull(Mobile_Operator,'Unknown') end ) as Mobile_Operator," & _
                              " (case when '" & Me.CheckBoxRangOfShortCode.Checked & "'='False' then '--all--' else isnull(Range_Short_Code,'Unknown') end ) as Range_Short_Code," & _
                              " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else isnull(Short_Code,'Unknown') end ) as Short_Code," & _
                              " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else isnull(Key_Word,'Unknown') end ) as Key_Word," & _
                              " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                              " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                              " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else substring(Date,9,2) end ) as Hour," & _
                              " (case when '" & Me.CheckBoxCate1_Id.Checked & "'='False' then '--all--' else Cate1_Text end ) as Cate1_Text," & _
                              " (case when '" & Me.CheckBoxCate2_Id.Checked & "'='False' then '--all--' else Cate2_Text end ) as Cate2_Text," & _
                              " SUM(MO) MO, SUM(MT) MT, SUM(CDR) CDR, SUM(MO_Error) MO_Error, SUM(MT_Error) MT_Error, SUM(CDR_Error) CDR_Error, SUM(MO_Refund) MO_Refund, " & _
                              " SUM(cast(Money_Total as decimal)) Money_Total, SUM(cast(Money_Share as decimal))  Money_Share, SUM(cast(Money_Operator as decimal))  Money_Operator," & _
                              " SUM(cast(Money_Total_Refund as decimal)) Money_Total_Refund, SUM(cast(Money_Share_Refund as decimal)) Money_Share_Refund, SUM(cast(Money_Operator_Refund as decimal)) Money_Operator_Refund," & _
                              " SUM(cast(Money_Total_Error as decimal)) Money_Total_Error, SUM(cast(Money_Share_Error as decimal)) Money_Share_Error, SUM(cast(Money_Operator_Error as decimal)) Money_Operator_Error," & _
                              " row_number() over( Order by substring(date,1,4) " & IIf(strSortField.ToString.Trim = "", "", "," & strSortField) & " ) as RowNumber " & _
                              " FROM " & vTable
        sqlTotal = "SELECT substring(Date,1,4) as Year,substring(Date,5,2) as Month," & _
                            " (case when '" & Me.CheckBoxDepartment.Checked & "'='False' then '--all--' else isnull(Department_Text,'Unknown') end ) as Department_Text," & _
                            " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else isnull(Partner_Text,'Unknown') end ) as Partner_Text," & _
                            " (case when '" & Me.CheckBoxContractCode.Checked & "'='False' then '--all--' else isnull(Contract_Code,'Unknown') end ) as Contract_Code," & _
                            " (case when '" & Me.CheckBoxThirdParty.Checked & "'='False' then '--all--' else isnull(ThirdParty_Text,'Unknown') end ) as ThirdParty_Text," & _
                            " (case when '" & Me.CheckBoxMobileOperator.Checked & "'='False' then '--all--' else isnull(Mobile_Operator,'Unknown') end ) as Mobile_Operator," & _
                            " (case when '" & Me.CheckBoxRangOfShortCode.Checked & "'='False' then '--all--' else isnull(Range_Short_Code,'Unknown') end ) as Range_Short_Code," & _
                            " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else isnull(Short_Code,'Unknown') end ) as Short_Code," & _
                            " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else isnull(Key_Word,'Unknown') end ) as Key_Word," & _
                            " (case when '" & Me.CheckBoxDayOfWeek.Checked & "'='False' then '--all--' else isnull(DayOfWeek_Text,'Unknown') end ) as DayOfWeek_Text," & _
                            " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else substring(Date,7,2) end ) as Day," & _
                            " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else substring(Date,9,2) end ) as Hour," & _
                            " (case when '" & Me.CheckBoxCate1_Id.Checked & "'='False' then '--all--' else Cate1_Text end ) as Cate1_Text," & _
                            " (case when '" & Me.CheckBoxCate2_Id.Checked & "'='False' then '--all--' else Cate2_Text end ) as Cate2_Text," & _
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

        sqlGroup = " GROUP BY substring(Date,1,4),substring(Date,5,2) "
        sqlOrder = " ORDER BY Year "

        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,7,2)"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",CAST(day as INT)"
            End If
        End If
        If Me.CheckBoxHour.Checked = True Then
            sqlGroup = sqlGroup & ", substring(Date,9,2)"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",CAST(hour as INT)"
            End If
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            sqlGroup = sqlGroup & ", Key_Word"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Key_Word"
            End If
        End If
        If Me.CheckBoxDepartment.Checked = True Then
            sqlGroup = sqlGroup & ", Department_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Department_Text"
            End If
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            sqlGroup = sqlGroup & ", Partner_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Partner_Text"
            End If
        End If
        If Me.CheckBoxContractCode.Checked = True Then
            sqlGroup = sqlGroup & ", Contract_Code"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Contract_Code"
            End If
        End If
        If Me.CheckBoxThirdParty.Checked = True Then
            sqlGroup = sqlGroup & ", ThirdParty_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",ThirdParty_Text"
            End If
        End If
        If Me.CheckBoxMobileOperator.Checked = True Then
            sqlGroup = sqlGroup & ", Mobile_Operator"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Mobile_Operator"
            End If
        End If
        If Me.CheckBoxRangOfShortCode.Checked = True Then
            sqlGroup = sqlGroup & ", Range_Short_Code"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Range_Short_Code"
            End If
        End If
        If Me.CheckBoxShortCode.Checked = True Then
            sqlGroup = sqlGroup & ", Short_Code"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Short_Code"
            End If
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            sqlGroup = sqlGroup & ", DayOfWeek_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",DayOfWeek_Text"
            End If
        End If
        If Me.CheckBoxCate1_Id.Checked = True Then
            sqlGroup = sqlGroup & ", Cate1_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Cate1_Text"
            End If
        End If
        If Me.CheckBoxCate2_Id.Checked = True Then
            sqlGroup = sqlGroup & ", Cate2_Text"
            If Me.DropDownListFieldList.SelectedItem.Value = 0 Then
                sqlOrder = sqlOrder & ",Cate2_Text"
            End If
        End If


        If Me.DropDownListFieldFilter.SelectedItem.Value > 0 Then
            If Me.DropDownListFieldFilter.SelectedItem.Value = 1 Then
                sqlCriteria = " HAVING SUM(cast(Money_Total as decimal)) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 2 Then
                sqlCriteria = " HAVING SUM(MO) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 3 Then
                sqlCriteria = " HAVING SUM(MT) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            ElseIf Me.DropDownListFieldFilter.SelectedItem.Value = 4 Then
                sqlCriteria = " HAVING SUM(CDR) " & Me.DropDownListFilter.SelectedItem.Text & Me.txtFilter.Text.Trim
            End If
        End If
        sql = sql & sqlConditional & sqlGroup & sqlCriteria
        sqlTotal = sqlTotal & sqlConditional & sqlGroup & sqlCriteria
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(MO) MO, SUM(MT) MT, SUM(CDR) CDR, SUM(MO_Error) MO_Error, SUM(MT_Error) MT_Error, SUM(CDR_Error) CDR_Error, SUM(MO_Refund) MO_Refund, " & _
                            "SUM(cast(Money_Total as decimal)) Money_Total, SUM(cast(Money_Share as decimal))  Money_Share, SUM(cast(Money_Operator as decimal))  Money_Operator," & _
                            "SUM(cast(Money_Total_Refund as decimal)) Money_Total_Refund, SUM(cast(Money_Share_Refund as decimal)) Money_Share_Refund, SUM(cast(Money_Operator_Refund as decimal)) Money_Operator_Refund," & _
                            "SUM(cast(Money_Total_Error as decimal)) Money_Total_Error, SUM(cast(Money_Share_Error as decimal)) Money_Share_Error, SUM(cast(Money_Operator_Error as decimal)) Money_Operator_Error," & _
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
                IsColumnDataGrid()
                Me.lblTotalMO.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MO"), 0)
                Me.lblTotalMT.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MT"), 0)
                Me.lblTotalCDR.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("CDR"), 0)
                Me.lblMoney_Total.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Total"), 0)
                Me.lblMoney_Share.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Share"), 0)
                Me.lblMoney_Operator.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Operator"), 0)
                Me.lblTotalMOErr.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MO_Error"), 0)
                Me.lblTotalMTErr.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("MT_Error"), 0)
                Me.lblTotalCDRErr.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("CDR_Error"), 0)
                Me.lblMoney_Total_Error.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Total_Error"), 0)
                Me.lblMoney_Share_Error.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Share_Error"), 0)
                Me.lblMoney_Operator_Error.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Operator_Error"), 0)
                Me.lblMoney_Total_Refund.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Total_Refund"), 0)
                Me.lblMoney_Share_Refund.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Share_Refund"), 0)
                Me.lblMoney_Operator_Refund.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Money_Operator_Refund"), 0)
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"

            End If
        ElseIf strAction = Constants.Action.Export Then
            ExportData.ExportExcel._SMS.MobileTrafficSummery(sql, CurrentUser.UserName, Me.CheckBoxError.Checked, _
                                                             Me.CheckBoxRefund.Checked, _
                                                             Me.CheckBoxDepartment.Checked, _
                                                             Me.CheckBoxPartnerId.Checked, _
                                                             Me.CheckBoxContractCode.Checked, _
                                                             Me.CheckBoxThirdParty.Checked, _
                                                             Me.CheckBoxMobileOperator.Checked, _
                                                             Me.CheckBoxRangOfShortCode.Checked, _
                                                             Me.CheckBoxShortCode.Checked, _
                                                             Me.CheckBoxKeyword.Checked, _
                                                             Me.CheckBoxDayOfWeek.Checked, _
                                                             Me.CheckBoxDate.Checked, _
                                                             Me.CheckBoxHour.Checked, _
                                                             Me.CheckBoxCate1_Id.Checked, _
                                                             Me.CheckBoxCate2_Id.Checked)

        End If
    End Sub
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxError.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
            Me.DataGrid.Columns(8).Visible = True
            Me.DataGrid.Columns(9).Visible = True
            Me.DataGrid.Columns(10).Visible = True
            Me.DataGrid.Columns(11).Visible = True
            Me.DataGrid.Columns(12).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
            Me.DataGrid.Columns(8).Visible = False
            Me.DataGrid.Columns(9).Visible = False
            Me.DataGrid.Columns(10).Visible = False
            Me.DataGrid.Columns(11).Visible = False
            Me.DataGrid.Columns(12).Visible = False
        End If
        If Me.CheckBoxRefund.Checked = True Then
            Me.DataGrid.Columns(13).Visible = True
            Me.DataGrid.Columns(14).Visible = True
            Me.DataGrid.Columns(15).Visible = True
            Me.DataGrid.Columns(16).Visible = True
        Else
            Me.DataGrid.Columns(13).Visible = False
            Me.DataGrid.Columns(14).Visible = False
            Me.DataGrid.Columns(15).Visible = False
            Me.DataGrid.Columns(16).Visible = False
        End If

        If Me.CheckBoxMobileOperator.Checked = True Then
            Me.DataGrid.Columns(17).Visible = True
        Else
            Me.DataGrid.Columns(17).Visible = False
        End If
        If Me.CheckBoxRangOfShortCode.Checked = True Then
            Me.DataGrid.Columns(18).Visible = True
        Else
            Me.DataGrid.Columns(18).Visible = False
        End If
        If Me.CheckBoxShortCode.Checked = True Then
            Me.DataGrid.Columns(19).Visible = True
        Else
            Me.DataGrid.Columns(19).Visible = False
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(20).Visible = True
        Else
            Me.DataGrid.Columns(20).Visible = False
        End If
        If Me.CheckBoxDayOfWeek.Checked = True Then
            Me.DataGrid.Columns(21).Visible = True
        Else
            Me.DataGrid.Columns(21).Visible = False
        End If
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(22).Visible = True
        Else
            Me.DataGrid.Columns(22).Visible = False
        End If
        If Me.CheckBoxHour.Checked = True Then
            Me.DataGrid.Columns(23).Visible = True
        Else
            Me.DataGrid.Columns(23).Visible = False
        End If
        If Me.CheckBoxDepartment.Checked = True Then
            Me.DataGrid.Columns(24).Visible = True
        Else
            Me.DataGrid.Columns(24).Visible = False
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
        If Me.CheckBoxCate1_Id.Checked = True Then
            Me.DataGrid.Columns(27).Visible = True
        Else
            Me.DataGrid.Columns(27).Visible = False
        End If
        If Me.CheckBoxCate2_Id.Checked = True Then
            Me.DataGrid.Columns(28).Visible = True
        Else
            Me.DataGrid.Columns(28).Visible = False
        End If
        If Me.CheckBoxThirdParty.Checked = True Then
            Me.DataGrid.Columns(29).Visible = True
        Else
            Me.DataGrid.Columns(29).Visible = False
        End If
    End Sub
    Private Function SortFiedln(ByVal strIn As String) As String
        Dim result As String = ""
        Select Case strIn

            Case "2#1"
                result = "SUM(MO) desc"
            Case "2#2"
                result = "SUM(MO) asc"
            Case "3#1"
                result = "SUM(MT) desc"
            Case "3#2"
                result = "SUM(MT) asc"
            Case "4#1"
                result = "SUM(CDR) desc"
            Case "4#2"
                result = "SUM(CDR) asc"
            Case "1#1"
                result = "SUM(cast(Money_Total as decimal)) desc"
            Case "1#2"
                result = "SUM(cast(Money_Total as decimal)) asc"
        End Select
        Return result
    End Function

#End Region
End Class