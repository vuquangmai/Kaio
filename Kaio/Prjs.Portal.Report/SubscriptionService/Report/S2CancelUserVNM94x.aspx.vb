Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Net

Public Class S2CancelUserVNM94x
    Inherits GlobalPage
    Public Utils As New Util.Numeric
    Public Utils_1 As New Util.Encrypt
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "HỦY DỊCH VỤ 94x - V//"
        End If
        If Me.txtUser_Id.Text.Trim <> "" Then
            BindData()
        End If
    End Sub
#End Region

#Region "Submit Click"
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        BindData()
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        BindData()
    End Sub
#End Region
    Private Sub BindData()
        Dim vTable As String = "S2_TTND_Registered_Users"
        Dim conn As New SqlConnection(IsSqlConnection.BuildSqlConnectionString("SqlConnectionString_168_2"))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "S2_TTND_Get_RegisteredServicesByMsisdn"
            .Parameters.Add(New SqlParameter("@Msisdn", SqlDbType.NVarChar, 20))
            .Parameters("@Msisdn").Value = Me.txtUser_Id.Text.Trim
            .Parameters.Add(New SqlParameter("@Service_Type", SqlDbType.NVarChar, 20))
            .Parameters("@Service_Type").Value = 1006
            .Connection = conn
        End With
        Dim da As New SqlClient.SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds, "tmp")
        Dim dt As DataTable = ds.Tables("tmp")

        If dt.Rows.Count > 0 Then
            DataGrid.DataSource = dt
            DataGrid.DataBind()
            Me.DataGrid.Visible = True

        Else
            Me.DataGrid.Visible = False
        End If
        Me.lblerror.Text = ""
        conn.Close()
        conn.Dispose()
    End Sub
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim vUser_ID As String = CType(e.CommandArgument, Integer)
        If SendMT(vUser_ID) = 1 Then
            bindData()
            Me.lblerror.Text = "Hủy thành công !"
        Else
            Me.lblerror.Text = "Lỗi hủy dịch vụ !"
        End If
    End Sub
    Private Function SendMT(ByVal vUser_ID As String) As Integer
        Dim num As Integer = -1
        Dim receiver As New S294xTool
        receiver.PreAuthenticate = True
        receiver.Credentials = New NetworkCredential(ConfigurationManager.AppSettings.Item("Outgoing_Username"), ConfigurationManager.AppSettings.Item("Outgoing_Password"))
        Try
            num = receiver.CancelSubscriptionService(vUser_ID)
        Catch exception1 As Exception
            num = -1
        End Try
        receiver = Nothing
        Return num
    End Function
End Class