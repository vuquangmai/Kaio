  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class ViSportCancelUserVNM
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "HỦY DỊCH VỤ VISPORT - V//"
            InitData()
        End If
        Me.btnCancel.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")

    End Sub
#End Region
#Region "Init Data"
    Private Sub InitData()
        Me.lblTotal.Text = 0
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
        If Me.txtUser.Text.Trim = "" Then
            Me.lblerror.Text = "Thông tin khách hàng không hợp lệ !"
            Exit Sub
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Me.txtUser.Text.Trim = "" Then
            Me.lblerror.Text = "Thông tin khách hàng không hợp lệ !"
            Exit Sub
        End If
        If Me.txtUser.Text = "" Then
            Me.lblerror.Text = "Thông tin thuê bao không hợp lệ !"
            Exit Sub
        Else
            Dim sql As String = "Update Sport_Game_Hero_Registered_Users  set Status =0,DeletedTime =getdate() where User_Id='" & Me.txtUser.Text.Trim & "'"
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_3"), sql)
                Me.lblerror.Text = "Hủy dịch vụ thành công !"
                Dim intPageSize As Integer = pager1.PageSize
                Dim intCurentPage As Integer = pager1.CurrentIndex
                BindData(intPageSize, intCurentPage, Constants.Action.Search)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi hủy dịch vụ. Mã lỗi: " & ex.Message

            End Try
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "Sport_Game_Hero_Registered_Users"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim strSortField As String = ""
        sqlOrder = " Order by RegisteredTime "
        sql = "SELECT  User_ID,Request_ID,Service_ID,Command_Code,Operator,RegisteredTime,DeletedTime,Registration_Channel," & _
                 " case convert(varchar,Status) when '1' then N'Đăng ký' when '0' then N'Hủy' else N'Unknown' end Status, " & _
                 " row_number() over( Order by RegisteredTime desc) as RowNumber " & _
                 " FROM " & vTable & " A"

        sqlTotal = "SELECT  " & _
                                " COUNT(*) Total " & _
                            " FROM " & vTable & " A"
        sqlConditional = " WHERE  User_ID='" & Me.txtUser.Text.Trim & "'"
       
        sql = sql & sqlConditional
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
                Me.lblTotal.Text = Utils.FormatDecimal(dtPageCount.Rows(0).Item("Total"), 0)
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If
    End Sub

#End Region

End Class