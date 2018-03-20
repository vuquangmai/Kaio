    Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class KpiBrDictIndexPercentageList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "TỶ TRỌNG KPI DỊCH VỤ SMS BRANDNAME"
            IsPrivilegeOnMenu()
        End If
    End Sub
#End Region

#Region "RadGrid Event"
    Private Sub RadGrid_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        If Not e.IsFromDetailTable Then
            Dim sql As String = "SELECT * FROM Kpi_Br_Percentage  Where  Root_Id=0  "
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                RadGrid.DataSource = dt
                Me.RadGrid.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.RadGrid.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        End If
    End Sub
    Private Sub RadGrid_DetailTableDataBind(ByVal source As Object, ByVal e As GridDetailTableDataBindEventArgs) Handles RadGrid.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Dim sql As String = ""
        Select Case e.DetailTableView.Name
            Case "Orders"
                Dim Root_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT  * FROM Kpi_Br_Percentage  " & _
               " Where Root_Id=" & Root_Id
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
            Case "OrderDetails"
                Dim Root_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT  * FROM Kpi_Br_Percentage  " & _
               " Where Root_Id=" & Root_Id
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt 'GetDataTable("SELECT * FROM [Order Details] WHERE OrderID = " & OrderID)
        End Select
    End Sub
    Protected Sub RadGrid_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles RadGrid.PreRender
        'If Not Page.IsPostBack Then
        '    RadGrid.MasterTableView.Items(0).Expanded = True
        '    RadGrid.MasterTableView.Items(0).ChildItem.NestedTableViews(0).Items(0).Expanded = True
        'End If
    End Sub
#End Region

End Class