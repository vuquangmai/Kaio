  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineRevVMS8979
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU ĐẦU SỐ 8979 - VMS"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindPartner()
        BindDate()
        BindServiceId()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate)
    End Sub

    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM S2_TTND_Partners where PartnerID>0 Order by PartnerName"
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
        Dim sql As String = "SELECT * FROM S2_TTKD_Services  where Service_Type = 'VIOLET' Order by service_name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("service_name"), dt.Rows(i).Item("service_Id")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        BindDate()
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblTotalCDR.Text = 0
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPrice_Unit.Items
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

        Dim vTable As String = "S2_VMS_Total_" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)

        sql = "SELECT  substring(A.Date,1,4) as vYear ,substring(A.Date,5,2)  as vMonth," & _
            " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  substring(A.Date,7,2) end ) as vDate ," & _
            " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,B.Service_Name) end ) as vService_Name ," & _
            " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,B.Register_Syntax) end ) as vRegister_Syntax ," & _
            " (case when '" & Me.CheckBoxService_Id.Checked & "'='False' then '--all--' else convert(nvarchar,B.Cancel_Syntax) end ) as vCancel_Syntax ," & _
            " (case when '" & Me.CheckBoxPrice_Unit.Checked & "'='False' then '--all--' else convert(nvarchar,A.Price) end ) as vPrice ," & _
            " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,C.PartnerName) end ) as vPartnerName," & _
            " Sum(Cdr) vTotal,  sum(cast(Revenue_Total as decimal))  vMoneyTotal, sum(cast(Revenue_Share as decimal))  vMoneyVMG,(sum(cast(Revenue_Total as decimal))-sum(cast(Revenue_Share as decimal)))  vMoneyViolet," & _
            " row_number() over( Order by  sum(cast(Revenue_Share as decimal))  desc) as RowNumber " & _
            "  FROM " & _
            vTable & " A LEFT JOIN S2_TTKD_Services B on '121200'+ A.ServiceID COLLATE DATABASE_DEFAULT =B.Service_ID COLLATE DATABASE_DEFAULT " & _
           " LEFT JOIN S2_TTND_Partners C ON B.PartnerID =C.PartnerID "
        sqlConditional = " WHERE substring(A.Date,1,4)='" & Me.DropDownListYear.SelectedItem.Value & "'"

        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = " AND  A.Date >='" & vFromDate & "' and A.Date<='" & vToDate & "'"
        End If

        If Me.CheckBoxPartnerId.Checked And Me.RadDropDownListPartner_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and convert(nvarchar,C.PartnerName)=N'" & Me.RadDropDownListPartner_Id.SelectedItem.Text & "'"
        End If
        If Me.CheckBoxService_Id.Checked And Me.RadDropDownListService_Id.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and A.SPID+ A.ServiceID='" & Me.RadDropDownListService_Id.SelectedItem.Value & "'"
        End If

        If Me.CheckBoxPrice_Unit.Checked = True Then
            Dim CollectionPrice_Unit As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPrice_Unit.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPrice_Unit.Count = 0 Then
                Me.lblerror.Text = "Đơn giá không hợp lệ !"
                Exit Sub
            Else
                If CollectionPrice_Unit.Count < Me.RadDropDownListPrice_Unit.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPrice_Unit
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  convert(nvarchar,A.Price) In (" & sb.ToString() & ")"
                End If
            End If
        End If

        sqlGroup = " GROUP BY substring(A.Date,1,4) ,substring(A.Date,5,2)"

        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", substring(A.Date,7,2) "
            sqlOrder = sqlOrder & ",CAST(vDate  as INT)"
        End If
        If Me.CheckBoxPrice_Unit.Checked = True Then
            sqlGroup = sqlGroup & ", A.Price"
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            sqlGroup = sqlGroup & ", B.Service_Name,B.Register_Syntax,B.Cancel_Syntax"
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", C.PartnerName"
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT SUM(vTotal) vTotalCDR,SUM(vMoneyVMG) vMoneyVMG,SUM(vMoneyViolet) vMoneyViolet, SUM(vMoneyTotal)  as vMoneyTotal, COUNT(*)  TotalRecord FROM  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sqlTotal)
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
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyVMG"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyViolet"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoneyTotal"), 0)
                Me.lblTotalCDR.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vTotalCDR"), 0)

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
        If Me.CheckBoxDate.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxService_Id.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
            Me.DataGrid.Columns(6).Visible = True
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
            Me.DataGrid.Columns(6).Visible = False
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPrice_Unit.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If

    End Sub

#End Region

End Class