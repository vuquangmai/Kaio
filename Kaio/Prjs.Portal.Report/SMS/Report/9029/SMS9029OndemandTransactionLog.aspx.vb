Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class SMS9029OndemandTransactionLog
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "BÁO CÁO LOG GIAO DỊCH SMS MO 9029 "
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
        BindService()
        BindPartner()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                                          Me.DropDownListFromDate, _
                                                          Me.DropDownListToDate)
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM VMG_MPay_Partners  WHERE Status =1 And PartnerType=1 "
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
    Private Sub BindService()
        Dim sql As String = "SELECT * FROM VMG_MPay_Services  WHERE Status =1 "
        sql = sql & " Order by ServiceName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
        Me.DropDownListServiceId.Items.Clear()
        Me.DropDownListServiceId.Items.Add(New ListItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListServiceId.Items.Add(New ListItem(dt.Rows(i).Item("ServiceName"), dt.Rows(i).Item("ServiceId")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                                            Me.DropDownListFromDate, _
                                                            Me.DropDownListToDate)
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Export)
    End Sub
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VMG_MPay_TransactionLog_" & Me.DropDownListYear.SelectedItem.Value & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)
        Dim vTable1 As String = ""
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlCriteria As String = ""
        Dim sqlOrder As String = ""
        sql = "SELECT  A.*, B.ServiceName,C.PartnerName,row_number() over( Order by LoggingTime desc) as RowNumber   " & _
               " FROM  " & _
                 vTable & " A " & _
               " INNER JOIN VMG_MPay_Services B on convert(varchar,A.ServiceId)=convert(varchar,B.ServiceId)" & _
               " INNER JOIN VMG_MPay_Partners C on convert(varchar,B.PartnerId)=convert(varchar,C.PartnerId)" & _
               " WHERE 1=1"
        If Me.DropDownListStatus.SelectedItem.Value > -1 Then
            sql = sql & " AND  A.synstatus = " & Me.DropDownListStatus.SelectedItem.Value
        End If
        If Me.CheckBoxAllDate.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), LoggingTime, 112) >='" & vFromDate & "' AND CONVERT(VARCHAR(10), LoggingTime, 112) <='" & vToDate & "'"
        End If
        If Me.DropDownListServiceId.SelectedItem.Value > 0 Then
            sql = sql & " AND A.ServiceId='" & Me.DropDownListServiceId.SelectedItem.Value & "'"
        End If
        If Me.DropDownListOperator.SelectedItem.Text <> "--all--" Then
            sql = sql & " AND A.Operator='" & Me.DropDownListOperator.SelectedItem.Value & "'"
        End If
        If Me.DropDownListPartnerId.SelectedItem.Value > 0 Then
            sql = sql & " AND B.PartnerId='" & Me.DropDownListPartnerId.SelectedItem.Value & "'"
        End If
        If Me.txtPhoneNumber.Text.Trim <> "" Then
            sql = sql & " AND A.Isdn='" & Me.txtPhoneNumber.Text.Trim & "'"
        End If
        If Me.txtKeyword.Text.Trim <> "" Then
            sql = sql & " AND A.ContentCode='" & Me.txtKeyword.Text.Trim & "'"
        End If

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT   count(*) TotalRecord FROM  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " AND  T1.RowNumber < " & UpperBand
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            'ExportS2._9029MO(dt, Session(Constants.UserInfoSession.USER_FULL_NAME), Me.DropDownListYear.SELECTedItem.Text, Me.DropDownListMonth.SELECTedItem.Text)
        End If

    End Sub
#End Region
End Class