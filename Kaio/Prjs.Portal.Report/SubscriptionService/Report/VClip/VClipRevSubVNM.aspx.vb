  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class VClipRevSubVNM
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU SUBS DỊCH VỤ VCLIP - V//"
            BindDictIndex()
            InitData()

        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
    End Sub
    Private Sub BindDate()
        Me.RadFromDate.SelectedDate = Now.AddDays(-(Today.Day) + 1)
        Me.RadToDate.SelectedDate = Now
    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblMoney_VMG_Telcos.Text = 0
        Me.lblMoney_Telcos_VMG.Text = 0
        Me.lblMoney_Ccare.Text = 0
        Me.lblTotalCDR.Text = 0
        Me.pager1.Visible = False
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
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        Dim vTable As String = "VClip_S2_Charged_Users_Log_" & RadFromDate.SelectedDate.Value.Year & "_" & RadFromDate.SelectedDate.Value.Month

        sqlOrder = " order by vYear"
        sql = "SELECT  YEAR(A.ChargingDate) as vYear , Price ," & _
        " (CASE WHEN '" & Me.CheckBoxMonth.Checked & "'='False' THEN '--all--' ELSE  convert(varchar,month(A.ChargingDate)) end) as Month," & _
        " (CASE WHEN '" & Me.CheckBoxDate.Checked & "'='False' THEN '--all--' ELSE  DATENAME(day,A.ChargingDate) end ) as Day," & _
        " (CASE WHEN '" & Me.CheckBoxHour.Checked & "'='False' THEN '--all--' ELSE  DATENAME(hour, A.ChargingDate) end ) as Hour, " & _
        " (CASE WHEN '" & Me.CheckBoxShortCode.Checked & "'='False' THEN '--all--' ELSE A.Service_ID end ) as Service_ID, " & _
        " (CASE WHEN '" & Me.CheckBoxKeyword.Checked & "'='False' THEN '--all--' ELSE convert(nvarchar,Command_Code)  end ) as Command_Code,  " & _
        " (CASE WHEN '" & Me.CheckBoxChannel.Checked & "'='False' THEN '--all--' ELSE convert(nvarchar,Registration_Channel)  end ) as Registration_Channel,  " & _
        " (CASE WHEN '" & Me.CheckBoxUser_Id.Checked & "'='False' THEN '--all--' ELSE convert(nvarchar,User_ID)  end ) as User_ID,  " & _
        " count(*) Total, count(*)*Price  as vMoney,cast(round(count(*)*Price *0.6,0) as decimal(18,0)) as vVMG,cast(round(count(*)*Price *0.4,0) as decimal(18,0))  as vVNM," & _
        " row_number() over( Order by YEAR(A.ChargingDate) desc) as RowNumber  from " & vTable & " A "
       
        sqlConditional = " WHERE Reason ='Succ' AND convert(varchar(10),A.ChargingDate, 112)  >= " & FromDate & _
            " AND convert(varchar(10),A.ChargingDate, 112)  <= " & ToDate

        If Me.CheckBoxChannel.Checked And Me.DropDownListChannel.SelectedItem.Text.Trim <> "--all--" Then
            sqlConditional = sqlConditional & " AND convert(nvarchar,Registration_Channel) ='" & Me.DropDownListChannel.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxKeyword.Checked And Me.txtKeyword.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " AND A.Command_Code='" & Me.txtKeyword.Text.Trim & "'"
        End If
        If Me.CheckBoxShortCode.Checked And Me.DropDownListShortCode.SelectedItem.Value <> "--all--" Then
            sqlConditional = sqlConditional & " AND A.Service_ID='" & Me.DropDownListShortCode.SelectedItem.Value & "'"
        End If
        If Me.CheckBoxUser_Id.Checked And Me.txtUser_Id.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " AND A.User_ID='" & Me.txtUser_Id.Text.Trim & "'"
        End If

        sqlGroup = " group by YEAR(A.ChargingDate),Price "
        If Me.CheckBoxMonth.Checked Then
            sqlGroup = sqlGroup & ",convert(varchar,month(A.ChargingDate))"
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked Then
            sqlGroup = sqlGroup & ", DATENAME(day,A.ChargingDate)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked Then
            sqlGroup = sqlGroup & ",  DATENAME(hour, A.ChargingDate) "
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxKeyword.Checked Then
            sqlGroup = sqlGroup & ", A.Command_Code"
            sqlOrder = sqlOrder & ",Command_Code"
        End If
        If Me.CheckBoxChannel.Checked Then
            sqlGroup = sqlGroup & ", convert(nvarchar,Registration_Channel)"
        End If
        If Me.CheckBoxShortCode.Checked Then
            sqlGroup = sqlGroup & ", A.Service_ID"
            sqlOrder = sqlOrder & ",Service_ID"
        End If
        If Me.CheckBoxUser_Id.Checked Then
            sqlGroup = sqlGroup & ", A.User_ID"
            sqlOrder = sqlOrder & ",User_ID"
        End If
        sql = sql & sqlConditional & sqlGroup

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT COUNT(*) Total,SUM(Total) TotalRecord ,SUM(vMoney) vMoney,SUM(vVMG) vVMG,SUM(vVNM) vVNM FROM (" & sql & ") T1")
            Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = _totalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.lblTotalCDR.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("TotalRecord"), 0)
                Me.lblMoney_Ccare.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vMoney"), 0)
                Me.lblMoney_VMG_Telcos.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vVMG"), 0)
                Me.lblMoney_Telcos_VMG.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("vVNM"), 0)

                Me.pager1.Visible = True
                Me.DataGrid.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

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
        If Me.CheckBoxKeyword.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxShortCode.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
        If Me.CheckBoxPrice.Checked = True Then
            Me.DataGrid.Columns(9).Visible = True
        Else
            Me.DataGrid.Columns(9).Visible = False
        End If
    End Sub
#End Region

End Class