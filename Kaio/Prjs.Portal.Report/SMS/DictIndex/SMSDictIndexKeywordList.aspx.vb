Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMSDictIndexKeywordList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ MÃ DỊCH VỤ SMS"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
            BindDictIndex()
            BindData()
        End If

    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindPartner()
        BindShortCode(Me.DropDownListRangeShortCode.SelectedItem.Value)
    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_Id.Items.Clear()
        Me.DropDownListDepartment_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Code"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindShortCode(Range_Of_Short_Code As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If Range_Of_Short_Code <> "--all--" Then
            sql = sql & "  And  Range_Of_Short_Code='" & Range_Of_Short_Code & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCode.Items.Clear()
        Me.DropDownListShortCode.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindPartner()
        'Dim sql As String = "SELECT * FROM Ccare_Management_Partner Order by Partner_Text"
        'Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        'Me.DropDownListPartner_Id.Items.Clear()
        'Me.DropDownListPartner_Id.Items.Add(New ListItem("--Chọn--", 0))
        'Me.DropDownListPartner_Id.SelectedValue = 0
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("ID")))
        '    Next
        'End If
    End Sub
    
#End Region
#Region "Bind Data"
    Private Sub BindData()
        Dim sql As String = "SELECT Isnull(B.Id,0) Id,Isnull(B.Dept_Text,'Unknown') Dept_Text,Isnull(B.Dept_Code,'Unknown') Dept_Code, A.Routing_Text,count(A.Id) Total FROM  SMS_DictIndex_Keyword_List A  " & _
               " LEFT JOIN  System_Department B ON A.Department_Id  =B.Id  " & _
               " WHERE A.Id>0 "
        If Me.DropDownListDepartment_Id.SelectedItem.Text <> "--all--" Then
            sql = sql & " And A.Department_Id =N'" & Me.DropDownListDepartment_Id.SelectedItem.Value & "'"
        End If
        If Me.DropDownListRangeShortCode.SelectedItem.Text <> "--all--" Then
            sql = sql & " And A.Range_Of_Short_Code =N'" & Me.DropDownListRangeShortCode.SelectedItem.Value & "'"
        End If
        If Me.DropDownListShortCode.SelectedItem.Text <> "--all--" Then
            sql = sql & " And A.Short_Code =N'" & Me.DropDownListShortCode.SelectedItem.Value & "'"
        End If
        If Me.txtKeyWord.Text.Trim <> "" Then
            sql = sql & " And A.Key_Word =N'" & Me.txtKeyWord.Text.Trim & "'"
        End If
        sql = sql & " GROUP BY B.Id,B.Dept_Text,B.Dept_Code,A.Routing_Text " & _
                        " ORDER BY B.Dept_Text "
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
        If Not e.IsFromDetailTable Then
            Dim sql As String = "SELECT Isnull(B.Id,0) Id,Isnull(B.Dept_Text,'Unknown') Dept_Text,Isnull(B.Dept_Code,'Unknown') Dept_Code, A.Routing_Text,count(A.Id) Total FROM  SMS_DictIndex_Keyword_List A  " & _
            " LEFT JOIN  System_Department B ON A.Department_Code  =B.Dept_Code  " & _
            " WHERE A.Id>0 "
            If Me.DropDownListDepartment_Id.SelectedItem.Text <> "--all--" Then
                sql = sql & " And A.Department_Code =N'" & Me.DropDownListDepartment_Id.SelectedItem.Text & "'"
            End If
            sql = sql & " GROUP BY B.Id,B.Dept_Text,B.Dept_Code " & _
                            " ORDER BY B.Dept_Text "
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
                Dim Department_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = " SELECT (convert(varchar,A.Department_Code)+'#'+ convert(varchar,Isnull(A.Short_Code,'Unknown'))) Id ,Isnull(B.Dept_Text,'Unknown') Dept_Text,Isnull(B.Dept_Code,'Unknown') Dept_Code, " & _
               " Isnull(A.Range_Of_Short_Code,'Unknown') Range_Of_Short_Code,Isnull(A.Short_Code,'Unknown') Short_Code, count(A.Id) Total FROM  SMS_DictIndex_Keyword_List A  " & _
               " LEFT JOIN  System_Department B ON A.Department_Code  =B.Dept_Code " & _
               " WHERE B.Id  =" & Department_Id
                If Me.DropDownListDepartment_Id.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Department_Code =N'" & Me.DropDownListDepartment_Id.SelectedItem.Text & "'"
                End If
                If Me.DropDownListRangeShortCode.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Range_Of_Short_Code =N'" & Me.DropDownListRangeShortCode.SelectedItem.Value & "'"
                End If
                If Me.DropDownListShortCode.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Short_Code =N'" & Me.DropDownListShortCode.SelectedItem.Value & "'"
                End If
                If Me.txtKeyWord.Text.Trim <> "" Then
                    sql = sql & " And A.Key_Word =N'" & Me.txtKeyWord.Text.Trim & "'"
                End If
                sql = sql & " GROUP BY (convert(varchar,A.Department_Code)+'#'+ convert(varchar,Isnull(A.Short_Code,'Unknown'))) ,B.Dept_Text,B.Dept_Code,A.Range_Of_Short_Code,A.Short_Code  " & _
               " ORDER BY A.Short_Code "

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt
            Case "OrderDetails"
                Dim vId As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim splitout = Split(vId.ToString(), "#")
                Dim Department_Code As String = splitout(0)
                Dim Short_Code As String = splitout(1)
                sql = "SELECT Id,Short_Code,Key_Word,(CASE  Status WHEN '1' THEN N'Sử dụng' ELSE N'Dừng' END ) Status, Cate1_Text,  " & _
                        " Create_Time,Create_By_Text,Update_Time,Update_By_Text," & _
                        " (CASE  Partner_Id WHEN '0' THEN N'Tự doanh' ELSE Partner_Code END ) Partner_Code" & _
                        " FROM SMS_DictIndex_Keyword_List A  " & _
                        " WHERE  Department_Code=N'" & Department_Code & "' AND  Short_Code= '" & Short_Code & "'"
                If Me.DropDownListDepartment_Id.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Department_Code =N'" & Me.DropDownListDepartment_Id.SelectedItem.Text & "'"
                End If
                If Me.DropDownListRangeShortCode.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Range_Of_Short_Code =N'" & Me.DropDownListRangeShortCode.SelectedItem.Value & "'"
                End If
                If Me.DropDownListShortCode.SelectedItem.Text <> "--all--" Then
                    sql = sql & " And A.Short_Code =N'" & Me.DropDownListShortCode.SelectedItem.Value & "'"
                End If
                If Me.txtKeyWord.Text.Trim <> "" Then
                    sql = sql & " And A.Key_Word =N'" & Me.txtKeyWord.Text.Trim & "'"
                End If
                sql = sql & " ORDER BY Short_Code,Key_Word"
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
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordEdit)
    End Sub
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        BindData()
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
        BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)
    End Sub
#End Region
End Class