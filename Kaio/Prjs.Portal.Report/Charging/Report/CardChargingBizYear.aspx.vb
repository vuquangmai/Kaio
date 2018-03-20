Public Class CardChargingBizYear
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU THẺ CÀO TỔNG HỢP THEO NĂM - TRUNG TÂM KINH DOANH"
            BindDictIndex()
            InitData()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "Dict Index"
    Private Sub BindDictIndex()
        BindDate()
        BindCardType()
        BindPartner()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
    End Sub
    Private Sub BindCardType()
        Dim sql As String = "SELECT * FROM cardtype Order by cardName"
        Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sql)
        Me.RadDropDownListCard_Type.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListCard_Type.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("cardName"), dt.Rows(i).Item("cardID")))
            Next
        End If
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT id, upper(subcp_name) subcp_name  FROM subcp WHERE center_name is not null"
        Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sql)
        Me.RadDropDownListPartner.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListPartner.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("subcp_name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListCard_Type.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListChannel.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPartner.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListPriceUnit.Items
            item.Checked = True
        Next
        For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadDropDownListMonth.Items
            item.Checked = True
        Next
    End Sub

#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlExc As String = ""
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = " WHERE substring(time,1,4)='" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & "'"
        Dim sqlGroup As String = " GROUP BY substring(time,1,4)"
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        Dim vTable As String = "tonghopcardvmg" & Me.DropDownListYear.SelectedItem.Value

        sql = "SELECT substring(time,1,4) vYear," & _
        " if('" & Me.CheckBoxMonth.Checked & "' like 'False' ,'--all--',substring(time,5,2)) vMonth,  " & _
        " if('" & Me.CheckBoxCard_Type.Checked & "' like 'False' ,'--all--', cardName) vCardName  ," & _
        " if('" & Me.RadDropDownListStatus.SelectedItem.Value & "' like '0' ,'Thành công','Lỗi') vStatus  ," & _
        " if('" & Me.CheckBoxPriceUnit.Checked & "' like 'False' ,'--all--',cardAmount ) vCardAmount ," & _
        " if('" & Me.CheckBoxChannel.Checked & "' like 'False' ,'--all--',serviceName ) vChannel ," & _
        " if('" & Me.CheckBoxPartner.Checked & "' like 'False' ,'--all--',subcp_name ) vSubcp_name , " & _
        " SUM(Total_Card) vTotal_Card,SUM(cardamount * total_card) vTotal_Amount " & _
        " FROM " &
        vTable
        If Me.RadDropDownListStatus.SelectedItem.Value = 0 Then
            sqlConditional = sqlConditional & " AND status='0'"
        Else
            sqlConditional = sqlConditional & " AND status<> '0'"
        End If
        If Me.CheckBoxMonth.Checked = True Then
            Dim CollectionMonth As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListMonth.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionMonth.Count = 0 Then
                Me.lblerror.Text = "Tháng không hợp lệ !"
                Exit Sub
            Else
                If CollectionMonth.Count < Me.RadDropDownListMonth.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionMonth
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  substring(time,5,2)  In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxCard_Type.Checked = True Then
            Dim CollectionCardType As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListCard_Type.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionCardType.Count = 0 Then
                Me.lblerror.Text = "Loại thẻ không hợp lệ !"
                Exit Sub
            Else
                If CollectionCardType.Count < Me.RadDropDownListCard_Type.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionCardType
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  cardName In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxPartner.Checked = True Then
            Dim CollectionPartner As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPartner.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPartner.Count = 0 Then
                Me.lblerror.Text = "Đối tác không hợp lệ !"
                Exit Sub
            Else
                If CollectionPartner.Count < Me.RadDropDownListPartner.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPartner
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  subcp_name In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Dim CollectionChannel As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListChannel.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionChannel.Count = 0 Then
                Me.lblerror.Text = "Kênh thẻ không hợp lệ !"
                Exit Sub
            Else
                If CollectionChannel.Count < Me.RadDropDownListChannel.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionChannel
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Text + "'")
                        Else
                            sb.Append(",'" + item.Text + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  serviceName In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            Dim CollectionPriceUnit As IList(Of Telerik.Web.UI.RadComboBoxItem) = Me.RadDropDownListPriceUnit.CheckedItems
            Dim sb As New StringBuilder()
            If CollectionPriceUnit.Count = 0 Then
                Me.lblerror.Text = "Mệnh giá thẻ không hợp lệ !"
                Exit Sub
            Else
                If CollectionPriceUnit.Count < Me.RadDropDownListPriceUnit.Items.Count Then
                    For Each item As Telerik.Web.UI.RadComboBoxItem In CollectionPriceUnit
                        If sb.ToString = "" Then
                            sb.Append("'" + item.Value + "'")
                        Else
                            sb.Append(",'" + item.Value + "'")
                        End If
                    Next
                    sqlConditional = sqlConditional & " And  cardAmount In (" & sb.ToString() & ")"
                End If
            End If
        End If
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ", substring(time,5,2)"
            sqlOrder = sqlOrder & ",CAST(substring(time,5,2)  as SIGNED) "
        End If
        If Me.CheckBoxCard_Type.Checked Then
            sqlGroup = sqlGroup & ",cardName"
        End If
        If Me.CheckBoxPartner.Checked Then
            sqlGroup = sqlGroup & ",subcp_name"
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ",serviceName"
        End If
        If Me.CheckBoxPriceUnit.Checked Then
            sqlGroup = sqlGroup & ",cardAmount"
            sqlOrder = sqlOrder & ",CAST(cardAmount  as SIGNED) "
        End If

        sqlExc = sql & sqlConditional & sqlGroup
        sqlTotal = "SELECT count(*) Total , sum(vTotal_Card) vTotal_Card ,sum(vTotal_Amount) vTotal_Amount FROM (" & sqlExc & ") A"
        If strAction = Constants.Action.Search Then
            sqlExc = sqlExc & sqlOrder & " LIMIT " & LowerBand & ", " & UpperBand
            Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sqlExc)
            Dim dtPageCount As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MySQLConnectionStringCardChargingBiz), sqlTotal)
            Dim _TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = _TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _TotalCount
                Next
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
                Dim vTotalCard As Double = 0
                Dim vTotalAmount As Double = 0
                Me.pager1.Visible = True
                Me.lblerror.Text = ""
                IsColumnDataGrid()
                'Me.lblTotalCard.Text = Me.Util.formatNumbers(dtPageCount.Rows(0).Item("vTotal_Card"))
                'Me.lblTotalAmount.Text = Me.Util.formatNumbers(dtPageCount.Rows(0).Item("vTotal_Amount"))
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        ElseIf strAction = Constants.Action.Export Then
            sqlExc = sqlExc & sqlOrder
            ExportData.ExportExcel._Charging.ChargingBizYear(sqlExc, CurrentUser.UserName, _
                                                              Me.CheckBoxPartner.Checked, _
                                                              Me.CheckBoxMonth.Checked, _
                                                              Me.CheckBoxCard_Type.Checked, _
                                                              Me.CheckBoxChannel.Checked, _
                                                              Me.CheckBoxPriceUnit.Checked)

        End If
    End Sub
#End Region
#Region "Is Column"
    Private Sub IsColumnDataGrid()
        If Me.CheckBoxPartner.Checked = True Then
            Me.DataGrid.Columns(1).Visible = True
        Else
            Me.DataGrid.Columns(1).Visible = False
        End If
        If Me.CheckBoxMonth.Checked = True Then
            Me.DataGrid.Columns(3).Visible = True
        Else
            Me.DataGrid.Columns(3).Visible = False
        End If
        If Me.CheckBoxCard_Type.Checked = True Then
            Me.DataGrid.Columns(4).Visible = True
        Else
            Me.DataGrid.Columns(4).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxPriceUnit.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
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
End Class