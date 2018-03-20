Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMS9029SubscriptionUserInfo
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblTitle.Text = "THÔNG TIN ĐĂNG KÝ, HỦY DỊCH VỤ"
            IsPrivilegeOnMenu()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim vTable As String = "VIETTEL_MPay_Sub_Users"
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT A.UserID,A.Msisdn,A.RequestID,A.RegisterChannel,A.CancelChannel,A.Detail,A.PartnerId," & _
            " (convert(varchar(4),substring(A.RegisterTime ,1,8))+'-'+ " & _
            " convert(varchar(4),substring(A.RegisterTime,5,2))+'-'+ " & _
            " convert(varchar(4),substring(A.RegisterTime,7,2))+' '+ " & _
            " convert(varchar(4),substring(A.RegisterTime,9,2))+':'+ " & _
            " convert(varchar(4),substring(A.RegisterTime,11,2))+':'+" & _
            " convert(varchar(4),substring(A.RegisterTime,13,2))) RegisterTime," & _
            " (convert(varchar(4),substring(A.CancelTime ,1,8))+'-'+ " & _
            " convert(varchar(4),substring(A.CancelTime,5,2))+'-'+ " & _
            " convert(varchar(4),substring(A.CancelTime,7,2))+' '+ " & _
            " convert(varchar(4),substring(A.CancelTime,9,2))+':'+ " & _
            " convert(varchar(4),substring(A.CancelTime,11,2))+':'+" & _
            " convert(varchar(4),substring(A.CancelTime,13,2))) CancelTime, " & _
            " (case A.Status when 1 then N'Đăng ký' else N'Hủy' end) StatusText, B.PartnerName,row_number() over( Order by UserID desc) as RowNumber   " & _
              " FROM  " & _
                vTable & " A left join VMG_MPay_Partners B on A.PartnerId=B.PartnerId "

        If Me.txtUser_Id.Text.Trim <> "" Then
            Dim vPhone As String = Me.txtUser_Id.Text.Trim
            If vPhone.StartsWith(0) = True Then
                vPhone = vPhone.Substring(1)
            ElseIf vPhone.StartsWith(84) = True Then
                vPhone = vPhone.Substring(2)
            End If
            sql = sql & " WHERE A.Msisdn='" & vPhone & "'"
        End If
        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT   COUNT(*) TotalRecord FROM  (" & sql & ") T1 "
            sql = "SELECT * FROM (" & sql & ") T1 where  T1.RowNumber  >" & LowerBand & " AND  T1.RowNumber < " & UpperBand
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sql)
            Dim dtPageCount As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"), sqlTotal)
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("TotalRecord"))
            If dt.Rows.Count > 0 Then
                GridData.DataSource = dt
                GridData.DataBind()
                Me.GridData.Visible = True
                Me.pager1.Visible = True
            Else
                Me.GridData.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If
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
End Class