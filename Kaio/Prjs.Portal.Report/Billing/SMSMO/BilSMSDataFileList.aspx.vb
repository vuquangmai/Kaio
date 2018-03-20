Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class BilSMSDataFileList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BIÊN BẢN ĐỐI SOÁT DỊCH VỤ SMS MO"
            BindYear()
            BindMonth()
            BindPartner()
            BindDept()
            Me.pager1.Visible = False
            Me.DataGrid.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindYear()
        Me.DropDownListYear.Items.Clear()
        For i As Integer = 2015 To 2020
            Me.DropDownListYear.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListYear.SelectedValue = Now.AddMonths(-1).Year
    End Sub
    Private Sub BindMonth()
        Me.DropDownListMonth.Items.Clear()
        For i As Integer = 1 To 12
            Me.DropDownListMonth.Items.Add(New ListItem(i, i))
        Next
        Me.DropDownListMonth.SelectedValue = Now.AddMonths(-1).Month
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT A.Id,A.Partner_Text,A.Partner_Code " & _
        " FROM  Ccare_Management_Partner A INNER JOIN Ccare_Management_Contract B ON A.Id=B.Partner_Id " & _
        " WHERE B.Service_Id= " & Constants.ServiceInfo.Id.SMS
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
     Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_Id.Items.Clear()
        Me.DropDownListDepartment_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("ID")))
            Next
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
#Region "Submit Click"
    Protected Sub btnSearching_Click(sender As Object, e As EventArgs) Handles btnSearching.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT A.Month, A.Department_Id, A.Department_Text, A.Partner_Id, A.Partner_Code, A.Partner_Text,A.Contract_Id,A.Contract_Code,A.Contract_Number, " & _
             " Isnull(A.File_Name_1,'') File_Name_1,Isnull(A.File_Path_1,'') File_Path_1," & _
             " Isnull(A.File_Name_2,'') File_Name_2 ,Isnull(A.File_Path_2,'') File_Path_2,A.File_Url,A.Create_Time," & _
             " Row_Number() Over ( Order by A.Department_Text, A.Partner_Code ) as RowNumber " & _
             " From Billing_SMS_Data_File  A  " & _
             " Where Month=" & Me.DropDownListYear.SelectedItem.Value & IIf(Me.DropDownListMonth.SelectedItem.Value < 10, "0" & Me.DropDownListMonth.SelectedItem.Value, Me.DropDownListMonth.SelectedItem.Value)
        If Me.DropDownListDepartment_Id.SelectedItem.Value > 0 Then
            sql = sql & " ANN Department_Id=" & Me.DropDownListDepartment_Id.SelectedItem.Value
        End If
        If Me.DropDownListPartner_Id.SelectedItem.Value > 0 Then
            sql = sql & " ANN Partner_Id=" & Me.DropDownListPartner_Id.SelectedItem.Value
        End If
        If Me.txtPartner_Text.Text.Trim <> "" Then
            sql = sql & " AND Partner_Text Like N'%" & Me.txtPartner_Text.Text.Trim & "%'"
        End If
        If Me.txtContract_Code.Text.Trim <> "" Then
            sql = sql & " AND Contract_Code Like N'%" & Me.txtContract_Code.Text.Trim & "%'"
        End If
        If Me.txtContract_Number.Text.Trim <> "" Then
            sql = sql & " AND Contract_Number Like N'%" & Me.txtContract_Number.Text.Trim & "%'"
        End If

        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        Dim dt As DataTable = Nothing
        Dim dtPageCount As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
        Else
            dt = CType(ViewState("DATA_GRID"), DataTable)
            dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
        End If
        ViewState("DATA_GRID") = dt
        ViewState("DATA_COUNT") = dtPageCount
        Dim _totalCount As Integer = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Visible = True
            Me.pager1.Visible = True
            pager1.ItemCount = _totalCount
            Me.lblerror.Text = ""
            For j As Integer = 0 To DataGrid.Items.Count - 1
                Dim lbID As Label
                lbID = DataGrid.Items(j).FindControl("lblOrder")
                lbID.Text = ((intCurentPage - 1) * DataGrid.PageSize + 1 + j) & "/" & _totalCount
            Next
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub
#End Region
End Class