Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Net

Public Class S2CancelUserVNM1119
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "HỦY DỊCH VỤ 1119 - V//"
            BindServiceId()
        End If
        If Me.txtUser_Id.Text.Trim <> "" Then
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindServiceId()
        Dim sql As String = "SELECT * FROM S2_Vnm_Services Order by ServiceName"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Clear()
        Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem("--all--", 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.RadDropDownListService_Id.Items.Add(New Telerik.Web.UI.RadComboBoxItem(dt.Rows(i).Item("ServiceName"), dt.Rows(i).Item("ServiceId")))
            Next
        End If
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
#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Me.txtUser_Id.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Me.txtUser_Id.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "S2_Vnm_Users "
        Dim LowerBand As Integer = ((intCurentPage - 1) * intPageSize)
        Dim UpperBand As Integer = ((intCurentPage * intPageSize) + 1)

        Dim sql As String = ""
        Dim sqlCount As String = ""
        sql = "select t1.Id, t1.UserId, t3.Description as ServiceType, t2.ServiceName, t1.ChargeOccasion, t1.PeriodLength, t1.Rental, t1.RequestId, t1.ShortCode, t1.CommandCode,  t1.SubscriptionTime, t1.SubscriptionChannel, t1.UnsubscriptionTime, t1.UnsubscriptionChannel" & _
            ",(case when convert(nvarchar,t1.Status)='1' then N'True' else N'False' end) as IsStatus,(case when convert(nvarchar,t1.Status)='1' then N'Đăng ký' else N'Hủy' end) as Status, row_number() over( Order by t1.SubscriptionTime desc) as RowNumber  " & _
            "  from S2_Vnm_Users t1 " & _
            " inner join S2_Vnm_Services t2 on t1.ServiceId = t2.ServiceId " & _
            " inner join S2_Vnm_ServiceTypes t3 on t1.ServiceType = t3.ServiceType" & _
            "  where   convert(nvarchar,t1.UserId) =N'" & Me.txtUser_Id.Text.Trim & "'"
        If Me.RadDropDownListService_Id.SelectedItem.Value > 0 Then
            sql = sql & " and convert(nvarchar,t2.ServiceId) =N'" & Me.RadDropDownListService_Id.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            sqlCount = "select  count(*) Total  From  (" & sql & ") T1 "
            sql = "select * from (" & sql & ") T1 where  T1.RowNumber  >" & LowerBand & " and  T1.RowNumber < " & UpperBand
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sqlCount)
            Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = _totalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                Me.pager1.Visible = True
            Else
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If

    End Sub
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim vId As String = CType(e.CommandArgument, String)
        If CancelService(vId) = "" Then
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            bindData(intPageSize, intCurentPage, Constants.Action.Search)
            Me.lblerror.Text = "Hủy thành công !"
        Else
            Me.lblerror.Text = "Lỗi hủy dịch vụ !"
        End If
    End Sub

    Private Function CancelService(ByVal vId As String) As String
        Dim retval As String = ""
        Dim sql As String = "Update S2_Vnm_Users " & _
        "  SET  [Status] = 0, UnsubscriptionTime = Getdate(), UnsubscriptionChannel = 'Report Tool'" & _
        " WHERE ID = " & vId
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        Catch ex As Exception
            retval = ex.Message
        End Try
        Return retval
    End Function
End Class