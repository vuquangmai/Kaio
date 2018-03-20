  Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class S2OnlineUserInfoVMS8979
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt

#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "THÔNG TIN KHÁCH HÀNG"
            BindDictIndex()
            Me.pager1.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDate()
    End Sub
    Private Sub BindDate()
        Me.DropDownListYear.SelectedValue = Now.Year
        Me.DropDownListMonth.SelectedValue = Now.Month
        Util.ControlData.LoadControlMMDD(Me.DropDownListMonth.SelectedItem.Value, _
                                      Me.DropDownListFromDate, _
                                      Me.DropDownListToDate)
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        BindDate()
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
        If Me.txtUser_Id.Text = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        bindDataUser()
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If Me.txtUser_Id.Text = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        bindDataUser()
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindDataUser()
        Dim sql As String = " SELECT A.Msisdn,A.ShortCode,status=case A.Status when 0 then N'Hủy' else N'Đăng ký' end, A.RegisteredTime,A.CancelTime," & _
        " B.Service_Name,B.Register_Syntax,B.Cancel_Syntax,convert(nvarchar,C.PartnerName) PartnerName" & _
        " FROM S2_TTKD_RegisteredUsers A LEFT JOIN  S2_TTKD_Services B on A.Service_ID=B.Service_ID " & _
        " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID " & _
        " Where  A.Msisdn='" & Me.txtUser_Id.Text.Trim & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
        If dt.Rows.Count > 0 Then
            DataGridUser.DataSource = dt
            DataGridUser.DataBind()
            Me.DataGridUser.Visible = True
        Else
            Me.DataGridUser.Visible = False
        End If

    End Sub
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim sqlConditional As String = ""
        Dim sqlGroup As String = ""
        Dim sqlOrder As String = ""
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1

        Dim vTable As String = "S2TTKD_VioletMT_Log" & Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value)
        Dim vFromDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListFromDate.SelectedItem.Value)
        Dim vToDate As String = Util.StringBuilder.ConvertDigit(Me.DropDownListYear.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListMonth.SelectedItem.Value) & Util.StringBuilder.ConvertDigit(Me.DropDownListToDate.SelectedItem.Value)
        sql = " SELECT A.Msisdn,A.Message,A.SenderName ,A.Requesttime,A.DeliveryStatus, B.service_name,convert(nvarchar,C.PartnerName) PartnerName " & _
                " FROM " & vTable & " A LEFT JOIN S2_TTKD_Services B on A.Service_ID=B.Service_ID " & _
                " LEFT JOIN S2_TTND_Partners C on B.PartnerID =C.PartnerID " & _
                " WHERE  A.Msisdn='" & Me.txtUser_Id.Text.Trim & "'"

        sql = sql & " AND CONVERT(varchar,A.RequestTime,112) >='" & vFromDate & "'  AND CONVERT(varchar,A.RequestTime,112)<='" & vToDate & "'"
        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("db177.vmgmedia.vn_1"), sql)
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                DataGrid.Visible = True
                Me.pager1.Visible = True
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If

    End Sub

#End Region

End Class