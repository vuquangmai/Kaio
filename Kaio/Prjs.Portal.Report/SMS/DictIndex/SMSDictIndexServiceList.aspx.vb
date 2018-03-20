   Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
    Public Class SMSDictIndexServiceList
        Inherits GlobalPage
        Public Utils As New Util.Encrypt
        Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ THÔNG TIN DỊCH VỤ"
                IsPrivilegeOnMenu()
                Me.btnAdd.Visible = IsUpdate
                BindData()
            End If

        End Sub
#End Region
 

#Region "Bind Data"
        Private Sub BindData()
        Dim sql As String = "SELECT A.Id,A.Cate_Name, Count(B.Id) Total, row_number() over( Order by A.Cate_Name ) as RowNumber From  " & _
                    " (SELECT *  FROM SMS_DictIndex_Service_Info Where Cate_Level=1) A" & _
                    " Left Join " & _
                    " (SELECT *  FROM SMS_DictIndex_Service_Info Where Cate_Level=2) B " & _
                    " On A.Id=B.Root_Id " & _
                    " Group By A.Id,A.Cate_Name " & _
                    " Order By A.Cate_Name"
        
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            RadGrid.DataSource = dt
            RadGrid.DataBind()
            Me.RadGrid.Visible = True
            Me.lblerror.Text = ""
        Else
            Me.RadGrid.Visible = False
            Me.lblerror.Text = "Không có dữ liệu !"
        End If
    End Sub
#End Region
#Region "RadGrid Event"
    Private Sub RadGrid_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        'If Not e.IsFromDetailTable Then
        '    Dim sql As String = "SELECT Isnull(B.Id,0) Id,Isnull(B.Dept_Text,'Unknown') Dept_Text,Isnull(B.Dept_Code,'Unknown') Dept_Code, count(A.Id) Total FROM  SMS_DictIndex_Keyword_List A  " & _
        '        " LEFT JOIN  System_Department B ON A.Department_Code  =B.Dept_Code  " & _
        '        " WHERE A.Id>0 "
        '    If Me.DropDownListDepartment_Id.SelectedItem.Text <> "--all--" Then
        '        sql = sql & " And A.Department_Code =N'" & Me.DropDownListDepartment_Id.SelectedItem.Value & "'"
        '    End If
        '    sql = sql & " GROUP BY B.Id,B.Dept_Text,B.Dept_Code " & _
        '                    " ORDER BY B.Dept_Text "
        '    Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        '    If dt.Rows.Count > 0 Then
        '        RadGrid.DataSource = dt
        '        Me.RadGrid.Visible = True
        '        Me.lblerror.Text = ""
        '    Else
        '        Me.RadGrid.Visible = False
        '        Me.lblerror.Text = "Không có dữ liệu !"
        '    End If
        'End If
    End Sub
    Private Sub RadGrid_DetailTableDataBind(ByVal source As Object, ByVal e As GridDetailTableDataBindEventArgs) Handles RadGrid.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Dim sql As String = ""
        Select Case e.DetailTableView.Name
            Case "Orders"
                Dim Root_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = " SELECT A.Id,A.Cate_Name, Count(B.Id) Total  From  " & _
                        " (SELECT *  FROM SMS_DictIndex_Service_Info Where Cate_Level=2 And Root_Id=" & Root_Id & ") A " & _
                        " Inner Join " & _
                        " (SELECT *  FROM SMS_DictIndex_Service_Info Where Cate_Level=3) B " & _
                        " On A.Id=B.Root_Id " & _
                        " Group By A.Id,A.Cate_Name " & _
                        " Order By A.Cate_Name "
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
            Case "OrderDetails"
                Dim Root_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = " SELECT *  " & _
                         " FROM SMS_DictIndex_Service_Info " & _
                         " WHERE  Root_Id=" & Root_Id
                sql = sql & " ORDER BY Cate_Name "
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
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
        Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexServiceEdit)
        End Sub
        Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
            BindData()
        End Sub
#End Region
 
    End Class