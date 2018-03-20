Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class SMS9029SubscriptionUsers
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "BÁO CÁO ĐĂNG KÝ DỊCH VỤ"
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindPartner()
        BindDate()
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM VMG_MPay_Partners  WHERE Status =1 AND PartnerType=1 "
        sql = sql & " Order by PartnerName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
        Me.DropDownListPartnerId.Items.Clear()
        Me.DropDownListPartnerId.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartnerId.Items.Add(New ListItem(dt.Rows(i).Item("PartnerName"), dt.Rows(i).Item("PartnerId")))
            Next
        End If
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SELECTedDate = Now
        Me.RadToDate.SELECTedDate = Now
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
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
#Region "Pager"
    Protected Sub pager_CommAND(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommANDArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VIETTEL_MPay_Sub_Users"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SELECTedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SELECTedDate.Value, "")
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim strSortField As String = ""
        Dim vParaTime As String = "RegisterTime"
        If Me.DropDownListStatus.SELECTedItem.Value = 0 Then
            vParaTime = "CancelTime"
        End If
        sql = "SELECT  substring(A." & vParaTime & ",1,4) as vYear , " & _
        " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",5,2) end) as Month," & _
        " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",7,2) end ) as Day," & _
        " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",9,2) end ) as Hour, " & _
        " (case when '" & Me.CheckBoxUser.Checked & "'='False' then '--all--' else A.MSISDN end ) as MSISDN, " & _
        " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else A.RegisterChannel end ) as RegisterChannel, " & _
        " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else A.Detail end ) as Detail, " & _
        " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,B.PartnerName)  end ) as PartnerName,  " & _
        " count(*) Total,  row_number() over( Order by count(*)  desc) as RowNumber  FROM " & vTable & " A left join VMG_MPay_Partners B on A.PartnerId=B.PartnerId "
        sqlTotal = "SELECT  substring(A." & vParaTime & ",1,4) as vYear , " & _
        " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",5,2) end) as Month," & _
        " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",7,2) end ) as Day," & _
        " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else  substring(A." & vParaTime & ",9,2) end ) as Hour, " & _
        " (case when '" & Me.CheckBoxUser.Checked & "'='False' then '--all--' else A.MSISDN end ) as MSISDN, " & _
        " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else A.RegisterChannel end ) as RegisterChannel, " & _
        " (case when '" & Me.CheckBoxKeyword.Checked & "'='False' then '--all--' else A.Detail end ) as Detail, " & _
        " (case when '" & Me.CheckBoxPartnerId.Checked & "'='False' then '--all--' else convert(nvarchar,B.service_name)  end ) as Services,  " & _
        " count(*) Total    FROM " & vTable & " A left join VMG_MPay_Partners B on A.PartnerId=B.PartnerId "
        sqlConditional = " WHERE A.Status =" & Me.DropDownListStatus.SELECTedItem.Value
        If Me.CheckBoxAllDate.Checked = False Then
            sqlConditional = sqlConditional & " AND substring(A." & vParaTime & ",1,8)>='" & FromDate & "'"
            sqlConditional = sqlConditional & " AND substring(A." & vParaTime & ",1,8)<='" & ToDate & "'"
        End If
        If Me.CheckBoxPartnerId.Checked And Me.DropDownListPartnerId.SELECTedItem.Value > 0 Then
            sqlConditional = sqlConditional & " AND convert(nvarchar,B.PartnerId) =N'" & Me.DropDownListPartnerId.SELECTedItem.Value & "'"
        End If
        If Me.CheckBoxChannel.Checked And Me.DropDownListChannel.SELECTedItem.Text <> "--all--" Then
            sqlConditional = sqlConditional & " AND RegisterChannel =N'" & Me.DropDownListChannel.SELECTedItem.Value & "'"
        End If
        If Me.CheckBoxUser.Checked = True And Me.txtMsisdn.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " AND convert(nvarchar,A.MSISDN) =N'" & Me.txtMsisdn.Text.Trim & "'"
        End If
        If Me.CheckBoxKeyword.Checked = True And Me.txtKeyword.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " AND convert(nvarchar,A.Detail) =N'" & Me.txtKeyword.Text.Trim & "'"
        End If

        sqlGroup = " GROUP BY substring(A." & vParaTime & ",1,4)"
        sqlOrder = " ORDER BY vYear"
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ",substring(A." & vParaTime & ",5,2) "
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", substring(A." & vParaTime & ",7,2)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ",  substring(A." & vParaTime & ",9,2) "
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxPartnerId.Checked Then
            sqlGroup = sqlGroup & ", convert(nvarchar,B.PartnerName)"
        End If
        If Me.CheckBoxUser.Checked Then
            sqlGroup = sqlGroup & ",  A.MSISDN "
        End If
        If Me.CheckBoxKeyword.Checked Then
            sqlGroup = sqlGroup & ",  A.Detail "
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ",  A.RegisterChannel "
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT  count(*) TotalRecord, sum(Total) TotalUser From  (" & sql & ") T1 "
            sql = "SELECT * from (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " AND  T1.RowNumber < " & UpperBand & sqlOrder
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.lblTotal.Text = Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("TotalUser"), 0)
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If
    End Sub
#End Region
#Region "Is Column"
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
        If Me.CheckBoxUser.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPartnerId.Checked = True Then
            Me.DataGrid.Columns(8).Visible = True
        Else
            Me.DataGrid.Columns(8).Visible = False
        End If
    End Sub
#End Region
 
End Class