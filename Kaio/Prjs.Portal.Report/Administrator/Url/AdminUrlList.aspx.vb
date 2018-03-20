 Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class AdminUrlList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ MENU CHỨC NĂNG HỆ THỐNG"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
        End If
        ReloadData()
    End Sub
#End Region
#Region "Reload Data"
    Private Sub ReloadData()
        If ViewState("DATA_GRID") Is Nothing Then
            'Not Load database
        Else
            Dim dt As DataTable = Nothing
            If ViewState("DATA_GRID") Is Nothing Then
                Me.RadGrid.Visible = False
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                If dt.Rows.Count > 0 Then
                    Me.RadGrid.Visible = True
                    Me.RadGrid.DataSource = dt
                Else
                    Me.RadGrid.Visible = False
                End If
            End If
        End If
    End Sub
#End Region
#Region "RadGrid Event"
    Private Sub RadGrid_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        If Not e.IsFromDetailTable Then
            Dim sql As String = "SELECT * FROM System_Channel  WHERE Channel_Status=1 Order by Id"
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
                Dim Channel_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT  Id, Url_Text, Url_Id, Parent_Id, Channel_Id, Url_Order, Description, " & _
               " Url_Display= case Url_Display when 1 then N'Yes' else 'No' end," & _
               " Url_Private=case Url_Private when 1 then N'Yes' else 'No' end," & _
               " Is_Locked=case Is_Locked when 1 then N'Locked' else 'Active' end," & _
               " Url_Privilege=case Url_Privilege when 1 then N'Yes' else 'No' end " & _
               " From System_Url  " & _
               " Where Url_Level=2 and  Channel_Id=" & Channel_Id & " Order by Url_Order "
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
            Case "OrderDetails"
                Dim Parent_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT  Id, Url_Text, Url_Id, Parent_Id, Channel_Id, Url_Order, Description, " & _
             " Url_Display= case Url_Display when 1 then N'Yes' else 'No' end," & _
             " Url_Private=case Url_Private when 1 then N'Yes' else 'No' end," & _
             " Is_Locked=case Is_Locked when 1 then N'Locked' else 'Active' end," & _
             " Url_Privilege=case Url_Privilege when 1 then N'Yes' else 'No' end " & _
             " From System_Url  " & _
             " Where Url_Level=3 and  Parent_Id=" & Parent_Id & " Order by Url_Order "
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt 'GetDataTable("SELECT * FROM [Order Details] WHERE OrderID = " & OrderID)
            Case "OrderDetails_4"
                Dim Parent_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT  Id, Url_Text, Url_Id, Parent_Id, Channel_Id, Url_Order, Description, " & _
             " Url_Display= case Url_Display when 1 then N'Yes' else 'No' end," & _
             " Url_Private=case Url_Private when 1 then N'Yes' else 'No' end," & _
             " Is_Locked=case Is_Locked when 1 then N'Locked' else 'Active' end," & _
             " Url_Privilege=case Url_Privilege when 1 then N'Yes' else 'No' end " & _
             " From System_Url  " & _
             " Where Url_Level=4 and  Parent_Id=" & Parent_Id & " Order by Url_Order "
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
#Region "Submit Click"
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        RedirectUrl(Constants.Url._Admin.AdminUrlEdit)
    End Sub
#End Region
End Class