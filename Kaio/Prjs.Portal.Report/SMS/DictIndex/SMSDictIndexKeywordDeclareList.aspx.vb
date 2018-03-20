Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMSDictIndexKeywordDeclareList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ KHAI BÁO MÃ DỊCH VỤ SMS"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
            BindDictIndex()
        End If
        If ViewState("DATA_GRID") Is Nothing Then
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindStatus()
        BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
        BindShortCode(Me.DropDownListRangeShortCode.SelectedItem.Value)
        Me.RadFromDate.SelectedDate = Now
        Me.RadToDate.SelectedDate = Now
        Me.pager1.Visible = False
    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Where Id=" & CurrentUser.DeptId & " Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_Id.Items.Clear()
        'Me.DropDownListDepartment_Id.Items.Add(New ListItem("--all--", 0))
        'Me.DropDownListDepartment_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
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
    Private Sub BindPartner(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text, A.Partner_Id, " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindStatus()
        Me.DropDownListStatus_Id.Items.Clear()
        Me.DropDownListStatus_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListStatus_Id.SelectedValue = 0
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Create_New, Constants.DeclareKeyword.StatusId.Create_New))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Request_Routing, Constants.DeclareKeyword.StatusId.Request_Routing))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Routing, Constants.DeclareKeyword.StatusId.Declare_Routing))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Telcos, Constants.DeclareKeyword.StatusId.Declare_Telcos))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Approved, Constants.DeclareKeyword.StatusId.Telcos_Approved))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Reject, Constants.DeclareKeyword.StatusId.Telcos_Reject))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Report, Constants.DeclareKeyword.StatusId.Declare_Report))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Add_Partner, Constants.DeclareKeyword.StatusId.Add_Partner))
        Me.DropDownListStatus_Id.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Closed, Constants.DeclareKeyword.StatusId.Closed))
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDate.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDate.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id desc ) as RowNumber  FROM " & vTable & " WHERE Department_Id=" & CurrentUser.DeptId
        If Me.CheckBoxAllDate.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCode.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCode.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCode.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCode.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWord.Text.Trim <> "" Then
            If Me.CheckBoxKeyword.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWord.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWord.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_Id.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_Id.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            sqlTotal = "SELECT count(*) Total   FROM (" & sql & ") T"
            If ViewState("DATA_GRID") Is Nothing Then
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
                sql = "SELECT * FROM (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " AND  T.RowNumber < " & UpperBand
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
            End If
            ViewState("DATA_GRID") = dt
            ViewState("DATA_COUNT") = dtPageCount
            Dim _TotalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.ItemCount = _TotalCount
            If dt.Rows.Count > 0 Then
                DataGrid.DataSource = dt
                DataGrid.DataBind()
                For j As Integer = 0 To DataGrid.Items.Count - 1
                    Dim lbID As Label
                    lbID = DataGrid.Items(j).FindControl("lblOrder")
                    lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _TotalCount
                Next
                Me.DataGrid.Visible = True
                Me.pager1.Visible = True
                Me.lblTotal.Text = _TotalCount
                Me.lblerror.Text = ""
            Else
                Me.DataGrid.Visible = False
                Me.pager1.Visible = False
                Me.lblerror.Text = "Không có dữ liệu !"
            End If
        ElseIf strAction = Constants.Action.Export Then

        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordDeclareEdit)
    End Sub
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
        BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_Id.SelectedIndexChanged
        If DropDownListDepartment_Id.SelectedItem.Value > 0 Then
            BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
        End If
    End Sub
#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Delete Data"
    Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete From  SMS_DictIndex_Keyword_Declare  Where Id=" & (CType(e.CommandArgument, Integer))
        Try
            MySQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Visible"
    Public Function SetVisibleEdit(ByVal Status_Id As Integer, ByVal Is_Handle As Integer) As String
        Dim str As String = "False"
        If Is_Handle > 0 And Is_Handle <> CurrentUser.UserId Then
            Return "False"
        End If
        If Status_Id = Constants.DeclareKeyword.StatusId.Create_New Or Status_Id = Constants.DeclareKeyword.StatusId.Telcos_Reject Then
            Return "True"
        Else
            Return "False"
        End If
        Return str
    End Function
    Public Function SetVisibleDelete(ByVal Status_Id As Integer, ByVal Is_Handle As Integer) As String
        Dim str As String = "False"
        If Is_Handle > 0 And Is_Handle <> CurrentUser.UserId Then
            Return "False"
        End If
        If Status_Id = Constants.DeclareKeyword.StatusId.Create_New Or Status_Id = Constants.DeclareKeyword.StatusId.Telcos_Reject Then
            Return "True"
        Else
            Return "False"
        End If
        Return str
    End Function
#End Region
End Class