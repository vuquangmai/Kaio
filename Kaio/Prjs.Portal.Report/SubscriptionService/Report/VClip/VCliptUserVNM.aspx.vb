  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class VCliptUserVNM
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO ĐĂNG KÝ, HỦY DỊCH VỤ VCLIP - V//"
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
        Me.lblTotalActive.Text = 0
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
        Dim vTable As String = "VClip_S2_Registered_Users"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim vFromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim vToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim strSortField As String = ""
        sqlOrder = " Order by vYear "
        sql = "SELECT   YEAR(#@) as vYear ," & _
                           " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  convert(varchar,month(#@))  end) as Month," & _
                            " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,#@)  end ) as Day," & _
                            " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else   DATENAME(hour, #@) end ) as Hour," & _
                            " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else Service_ID end ) as ShortCode," & _
                            " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else User_id end ) as User_id," & _
                            " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else Registration_Channel end ) as Registration_Channel," & _
                            " count(*) Total, " & _
                            " row_number() over( Order by count(*) desc) as RowNumber " & _
                            " FROM " & vTable & " A"

        sqlTotal = "SELECT   YEAR(#@) as vYear ," & _
                           " (case when '" & Me.CheckBoxMonth.Checked & "'='False' then '--all--' else  convert(varchar,month(#@))  end) as Month," & _
                            " (case when '" & Me.CheckBoxDate.Checked & "'='False' then '--all--' else  DATENAME(day,#@)  end ) as Day," & _
                            " (case when '" & Me.CheckBoxHour.Checked & "'='False' then '--all--' else   DATENAME(hour, #@) end ) as Hour," & _
                            " (case when '" & Me.CheckBoxShortCode.Checked & "'='False' then '--all--' else Service_ID end ) as ShortCode," & _
                            " (case when '" & Me.CheckBoxUser_Id.Checked & "'='False' then '--all--' else User_id end ) as User_id," & _
                            " (case when '" & Me.CheckBoxChannel.Checked & "'='False' then '--all--' else Registration_Channel end ) as Registration_Channel," & _
                            " count(*) Total " & _
                            " FROM " & vTable & " A"
        sqlConditional = " WHERE  Status=" & Me.DropDownListStatus.SelectedItem.Value
        If Me.CheckBoxAllDate.Checked = False Then
            If Me.DropDownListStatus.SelectedItem.Value = 1 Then
                sqlConditional = sqlConditional & " AND CONVERT(varchar, RegisteredTime,112) >=" & vFromDate & " AND CONVERT(varchar, RegisteredTime,112)<=" & vToDate
            Else
                sqlConditional = sqlConditional & " AND  DeletedTime is not null AND CONVERT(varchar, DeletedTime,112) >=" & vFromDate & " AND CONVERT(varchar, DeletedTime,112) <=" & vToDate
            End If
        End If
        If Me.CheckBoxShortCode.Checked = True And Me.DropDownListShortCode.SelectedItem.Value > 0 Then
            sqlConditional = sqlConditional & " and A.Short_Code='" & Me.DropDownListShortCode.SelectedItem.Text & "'"
        End If

        If Me.CheckBoxUser_Id.Checked = True And Me.txtUser_Id.Text.Trim <> "" Then
            sqlConditional = sqlConditional & " and A.User_id='" & Me.txtUser_Id.Text.Trim & "'"
        End If
        If Me.CheckBoxChannel.Checked = True And Me.DropDownListChannel.SelectedItem.Text.Trim.ToLower <> "--all--" Then
            sqlConditional = sqlConditional & " and A.Registration_Channel='" & Me.DropDownListChannel.SelectedItem.Text.Trim & "'"
        End If

        sqlGroup = " GROUP BY YEAR(#@)"
        If Me.CheckBoxMonth.Checked = True Then
            sqlGroup = sqlGroup & ", convert(varchar,month(#@))"
            sqlOrder = sqlOrder & ",CAST(month as INT)"
        End If
        If Me.CheckBoxDate.Checked = True Then
            sqlGroup = sqlGroup & ", DATENAME(day,#@)"
            sqlOrder = sqlOrder & ",CAST(day as INT)"
        End If
        If Me.CheckBoxHour.Checked = True Then
            sqlGroup = sqlGroup & ", DATENAME(hour, #@)"
            sqlOrder = sqlOrder & ",CAST(hour as INT)"
        End If
        If Me.CheckBoxShortCode.Checked = True Then
            sqlGroup = sqlGroup & ", Service_ID"
            sqlOrder = sqlOrder & ",shortcode"
        End If
        If Me.CheckBoxUser_Id.Checked = True Then
            sqlGroup = sqlGroup & ", User_id"
            sqlOrder = sqlOrder & ",User_id"
        End If
        If Me.CheckBoxChannel.Checked = True Then
            sqlGroup = sqlGroup & ", A.Registration_Channel"
        End If

        If Me.DropDownListStatus.SelectedItem.Value = 1 Then
            sql = sql.Replace("#@", "RegisteredTime")
            sqlTotal = sqlTotal.Replace("#@", "RegisteredTime")
            sqlConditional = sqlConditional.Replace("#@", "RegisteredTime")
            sqlGroup = sqlGroup.Replace("#@", "RegisteredTime")
        Else
            sql = sql.Replace("#@", "DeletedTime")
            sqlTotal = sqlTotal.Replace("#@", "DeletedTime")
            sqlConditional = sqlConditional.Replace("#@", "DeletedTime")
            sqlGroup = sqlGroup.Replace("#@", "DeletedTime")
        End If
        sql = sql & sqlConditional & sqlGroup
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT * FROM (" & sql & ") T1 WHERE  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand & sqlOrder)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT count(*) Total FROM   (" & sql & ") T1")
            pager1.ItemCount = dtPageCount.Rows(0).Item("Total")
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & dtPageCount.Rows(0).Item("Total")
                Next
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True

                Dim dtTotal As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), "SELECT COUNT(*) Total FROM Sport_Game_Hero_Registered_Users WHERE Status = 1")
                Me.lblTotalActive.Text = dtTotal.Rows(0).Item("Total")
                IsColumnDataGrid()
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

        If Me.CheckBoxShortCode.Checked = True Then
            Me.DataGrid.Columns(5).Visible = True
        Else
            Me.DataGrid.Columns(5).Visible = False
        End If
        If Me.CheckBoxUser_Id.Checked = True Then
            Me.DataGrid.Columns(6).Visible = True
        Else
            Me.DataGrid.Columns(6).Visible = False
        End If
        If Me.CheckBoxChannel.Checked = True Then
            Me.DataGrid.Columns(7).Visible = True
        Else
            Me.DataGrid.Columns(7).Visible = False
        End If
    End Sub
#End Region

End Class