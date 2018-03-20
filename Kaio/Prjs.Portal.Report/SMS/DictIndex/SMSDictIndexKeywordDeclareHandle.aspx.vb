Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class SMSDictIndexKeywordDeclareHandle
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public UtilsNumeric As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "XỬ LÝ KHAI BÁO ĐĂNG KÝ MÃ MỚI DỊCH VỤ SMS"
            BindDictIndex()
            ShowTab(CurrentUser.DeptId)
            Me.pagerQ7.Visible = False
        End If
        LoadData()
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindStatus()
        InitBindPartner()
        BindShortCode()
        BindDate()
        BindCate1(0)
        EnableTab(0)
        BindRoutingCode()
    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_IdQ1.Items.Clear()
        Me.DropDownListDepartment_IdQ1.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ1.SelectedValue = 0
        Me.DropDownListDepartment_IdQ2.Items.Clear()
        Me.DropDownListDepartment_IdQ2.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ2.SelectedValue = 0
        Me.DropDownListDepartment_IdQ3.Items.Clear()
        Me.DropDownListDepartment_IdQ3.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ3.SelectedValue = 0
        Me.DropDownListDepartment_IdQ5.Items.Clear()
        Me.DropDownListDepartment_IdQ5.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ5.SelectedValue = 0
        Me.DropDownListDepartment_IdQ6.Items.Clear()
        Me.DropDownListDepartment_IdQ6.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ7.Items.Clear()
        Me.DropDownListDepartment_IdQ7.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ6.SelectedValue = 0
        Me.DropDownListDepartment_IdQ8.Items.Clear()
        Me.DropDownListDepartment_IdQ8.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListDepartment_IdQ8.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ5.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ6.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ7.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
                Me.DropDownListDepartment_IdQ8.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindShortCode()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ1.Items.Clear()
        Me.DropDownListShortCodeQ1.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListShortCodeQ2.Items.Clear()
        Me.DropDownListShortCodeQ2.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListShortCodeQ3.Items.Clear()
        Me.DropDownListShortCodeQ3.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListShortCodeQ5.Items.Clear()
        Me.DropDownListShortCodeQ5.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListShortCodeQ6.Items.Clear()
        Me.DropDownListShortCodeQ6.Items.Add(New ListItem("--all--", "--all--"))
        Me.DropDownListShortCodeQ7.Items.Clear()
        Me.DropDownListShortCodeQ7.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ1.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Me.DropDownListShortCodeQ2.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Me.DropDownListShortCodeQ3.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Me.DropDownListShortCodeQ5.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Me.DropDownListShortCodeQ6.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Me.DropDownListShortCodeQ7.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ1(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ1.Items.Clear()
        Me.DropDownListShortCodeQ1.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ1.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ2(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ2.Items.Clear()
        Me.DropDownListShortCodeQ2.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ2.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ3(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ3.Items.Clear()
        Me.DropDownListShortCodeQ3.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ3.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ5(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ5.Items.Clear()
        Me.DropDownListShortCodeQ5.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ5.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ6(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ6.Items.Clear()
        Me.DropDownListShortCodeQ6.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ6.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindShortCodeQ7(ByVal RangOf As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If RangOf <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code='" & RangOf & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCodeQ7.Items.Clear()
        Me.DropDownListShortCodeQ7.Items.Add(New ListItem("--all--", "--all--"))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCodeQ7.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ1(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text, A.Partner_Id,   " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ1.Items.Clear()
        Me.DropDownListPartner_IdQ1.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ1.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ2(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,A.Partner_Id,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ2.Items.Clear()
        Me.DropDownListPartner_IdQ2.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ2.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ3(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text, A.Partner_Id, " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ3.Items.Clear()
        Me.DropDownListPartner_IdQ3.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ3.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ5(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,A.Partner_Id,   " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ5.Items.Clear()
        Me.DropDownListPartner_IdQ5.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ5.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ5.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ6(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,A.Partner_Id,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ6.Items.Clear()
        Me.DropDownListPartner_IdQ6.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ6.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ6.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindPartnerQ7(ByVal Department_Id As String)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,A.Partner_Id,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id In (" & Department_Id & ") AND A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ7.Items.Clear()
        Me.DropDownListPartner_IdQ7.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ7.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ7.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
  
    Private Sub InitBindPartner()
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text, A.Partner_Id, " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE  A.Service_Id= " & Constants.ServiceInfo.Id.SMS & _
             " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_IdQ1.Items.Clear()
        Me.DropDownListPartner_IdQ1.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ1.SelectedValue = 0
        Me.DropDownListPartner_IdQ2.Items.Clear()
        Me.DropDownListPartner_IdQ2.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ2.SelectedValue = 0
        Me.DropDownListPartner_IdQ3.Items.Clear()
        Me.DropDownListPartner_IdQ3.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ3.SelectedValue = 0
        Me.DropDownListPartner_IdQ5.Items.Clear()
        Me.DropDownListPartner_IdQ5.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ5.SelectedValue = 0
        Me.DropDownListPartner_IdQ6.Items.Clear()
        Me.DropDownListPartner_IdQ6.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ6.SelectedValue = 0
        Me.DropDownListPartner_IdQ7.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListPartner_IdQ7.SelectedValue = 0
        Me.DropDownListPartner_IdQ8.Items.Clear()
        Me.DropDownListPartner_IdQ8.Items.Add(New ListItem("Tự doanh", 0))
        Me.DropDownListPartner_IdQ8.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_IdQ1.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ2.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ3.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ5.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ6.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ7.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
                Me.DropDownListPartner_IdQ8.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindStatus()
        Me.DropDownListStatus_IdQ1.Items.Clear()
        Me.DropDownListStatus_IdQ2.Items.Clear()
        Me.DropDownListStatus_IdQ3.Items.Clear()
        Me.DropDownListStatus_IdQ5.Items.Clear()
        Me.DropDownListStatus_IdQ6.Items.Clear()
        Me.DropDownListStatus_IdQ7.Items.Clear()
        Me.DropDownListStatus_IdQ8.Items.Clear()

        Me.DropDownListStatus_IdQ1.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Create_New, Constants.DeclareKeyword.StatusId.Create_New))
        Me.DropDownListStatus_IdQ2.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Request_Routing, Constants.DeclareKeyword.StatusId.Request_Routing))
        Me.DropDownListStatus_IdQ3.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Routing, Constants.DeclareKeyword.StatusId.Declare_Routing))
        Me.DropDownListStatus_IdQ5.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Telcos, Constants.DeclareKeyword.StatusId.Declare_Telcos))
        Me.DropDownListStatus_IdQ6.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Report, Constants.DeclareKeyword.StatusId.Declare_Report))
        Me.DropDownListStatus_IdQ7.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Add_Partner, Constants.DeclareKeyword.StatusId.Add_Partner))

        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Create_New, Constants.DeclareKeyword.StatusId.Create_New))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Request_Routing, Constants.DeclareKeyword.StatusId.Request_Routing))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Routing, Constants.DeclareKeyword.StatusId.Declare_Routing))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Telcos, Constants.DeclareKeyword.StatusId.Declare_Telcos))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Approved, Constants.DeclareKeyword.StatusId.Telcos_Approved))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Reject, Constants.DeclareKeyword.StatusId.Telcos_Reject))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Report, Constants.DeclareKeyword.StatusId.Declare_Report))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Add_Partner, Constants.DeclareKeyword.StatusId.Add_Partner))
        Me.DropDownListStatus_IdQ8.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Closed, Constants.DeclareKeyword.StatusId.Closed))
    End Sub
    Private Sub BindDate()
        Me.RadFromDateQ1.SelectedDate = Now
        Me.RadToDateQ1.SelectedDate = Now
        Me.RadFromDateQ2.SelectedDate = Now
        Me.RadToDateQ2.SelectedDate = Now
        Me.RadFromDateQ3.SelectedDate = Now
        Me.RadToDateQ3.SelectedDate = Now
        Me.RadFromDateQ5.SelectedDate = Now
        Me.RadToDateQ5.SelectedDate = Now
        Me.RadFromDateQ6.SelectedDate = Now
        Me.RadToDateQ6.SelectedDate = Now
        Me.RadFromDateQ7.SelectedDate = Now
        Me.RadToDateQ7.SelectedDate = Now
    End Sub
    Private Sub BindCate1(ByVal intRootId As Integer)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Service_Info Where Root_Id =" & intRootId & " Order by Cate_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCate_1Q8.Items.Clear()
        Me.DropDownListCate_1Q8.Items.Add(New ListItem(("--Chọn--"), 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCate_1Q8.Items.Add(New ListItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindRoutingCode()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Routing  Order by Routing_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListRouting_CodeQ8Proc.Items.Clear()
        Me.DropDownListRouting_CodeQ8Proc.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListRouting_CodeQ8Proc.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListRouting_CodeQ8Proc.Items.Add(New ListItem(dt.Rows(i).Item("Routing_Code"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindStatusHandle(ByVal CurrentStatusId As Integer)
        Me.DropDownListStatus_IdQ8Proc.Items.Clear()
        Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListStatus_IdQ8Proc.SelectedValue = 0
        Select Case CurrentStatusId
            Case Constants.DeclareKeyword.StatusId.Create_New
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Request_Routing, Constants.DeclareKeyword.StatusId.Request_Routing))
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Telcos, Constants.DeclareKeyword.StatusId.Declare_Telcos))
            Case Constants.DeclareKeyword.StatusId.Request_Routing
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Routing, Constants.DeclareKeyword.StatusId.Declare_Routing))
            Case Constants.DeclareKeyword.StatusId.Declare_Routing
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Telcos, Constants.DeclareKeyword.StatusId.Declare_Telcos))
            Case Constants.DeclareKeyword.StatusId.Declare_Telcos
                'Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Approved, Constants.DeclareKeyword.StatusId.Telcos_Approved))
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Telcos_Reject, Constants.DeclareKeyword.StatusId.Telcos_Reject))
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Declare_Report, Constants.DeclareKeyword.StatusId.Declare_Report))
            Case Constants.DeclareKeyword.StatusId.Declare_Report
                Me.DropDownListStatus_IdQ8Proc.Items.Add(New ListItem(Constants.DeclareKeyword.StatusText.Add_Partner, Constants.DeclareKeyword.StatusId.Add_Partner))
        End Select
    End Sub
    Private Sub BindGroupHandle(ByVal CurrentStatusId As Integer)
        Dim sql As String = ""
        Select Case CurrentStatusId
            Case Constants.DeclareKeyword.StatusId.Request_Routing
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id=2"
            Case Constants.DeclareKeyword.StatusId.Declare_Routing
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id=1"
            Case Constants.DeclareKeyword.StatusId.Declare_Telcos
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id=1"
            Case Constants.DeclareKeyword.StatusId.Create_New
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id=1"
            Case Constants.DeclareKeyword.StatusId.Telcos_Reject
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id =1"
            Case Constants.DeclareKeyword.StatusId.Telcos_Approved
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id =1"
            Case Constants.DeclareKeyword.StatusId.Declare_Report
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id =3"
            Case Constants.DeclareKeyword.StatusId.Add_Partner
                sql = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id =3"
        End Select
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), Sql)
        Me.DropDownListGroup_Handle_IdQ8Proc.Items.Clear()
        Me.DropDownListGroup_Handle_IdQ8Proc.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListGroup_Handle_IdQ8Proc.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListGroup_Handle_IdQ8Proc.Items.Add(New ListItem(dt.Rows(i).Item("Group_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
#End Region
#Region "Load Data"
    Private Sub LoadData()
        If ViewState("DATA_GRID_Q1") Is Nothing Then
            Me.RadGridQ1.Visible = False
            BindQ1Data(Constants.Action.Search)
        Else
            'bindQ1Data(Constants.Action.Search)
        End If
        If ViewState("DATA_GRID_Q2") Is Nothing Then
            Me.RadGridQ2.Visible = False
            BindQ2Data(Constants.Action.Search)
        Else
            'bindQ1Data(Constants.Action.Search)
        End If
        If ViewState("DATA_GRID_Q3") Is Nothing Then
            Me.RadGridQ3.Visible = False
            BindQ3Data(Constants.Action.Search)
        Else
            'bindQ1Data(Constants.Action.Search)
        End If
       
        If ViewState("DATA_GRID_Q5") Is Nothing Then
            Me.RadGridQ5.Visible = False
            BindQ5Data(Constants.Action.Search)
        Else

        End If
        If ViewState("DATA_GRID_Q6") Is Nothing Then
            Me.RadGridQ6.Visible = False
            BindQ6Data(Constants.Action.Search)
        Else
            'bindQ1Data(Constants.Action.Search)
        End If
        
    End Sub
#End Region
#Region "Q1 Event"
#Region "Bind Grid"
    Private Sub BindQ1Data(ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ1.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ1.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id desc) as RowNumber  FROM " & vTable & " WHERE TypeOf_Ticket_Id = 1 AND Status_Id=" & Constants.DeclareKeyword.StatusId.Create_New
        sql = sql & " AND Group_Handle_Id  IN (SELECT Group_Id  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE User_Id=" & CurrentUser.UserId & ")"
        If Me.CheckBoxAllDateQ1.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ1.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ1.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ1.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ1.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ1.Text.Trim <> "" Then
            If Me.CheckBoxKeywordQ1.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ1.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ1.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ1.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ1.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q1") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID_Q1"), DataTable)
            End If
            ViewState("DATA_GRID_Q1") = dt
            Me.lblTotalQ1.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.RadGridQ1.Visible = True
                Me.RadGridQ1.DataSource = dt
                Me.RadGridQ1.DataBind()
            Else
                Me.RadGridQ1.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ1(sql, CurrentUser.UserFullName)
        End If
    End Sub
#End Region
#Region "Rad Grid Event"
    Public Sub lnkQ1_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim lnkPortal As LinkButton = CType(sender, LinkButton)
        ViewState(ViewStateInfo.Object_Id) = lnkPortal.CommandArgument
        BindDataQ8(ViewState(ViewStateInfo.Object_Id))
        EnableTab(6)
    End Sub
    'Private Sub RadGridQ1_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridQ1.NeedDataSource
    '    If Not e.IsFromDetailTable Then
    '        Dim dt As DataTable = Nothing
    '        If ViewState("DATA_GRID_Q1") Is Nothing Then
    '            Me.RadGridQ1.Visible = False
    '        Else
    '            dt = CType(ViewState("DATA_GRID_Q1"), DataTable)
    '            If dt.Rows.Count > 0 Then
    '                Me.RadGridQ1.Visible = True
    '                Me.RadGridQ1.DataSource = dt
    '            Else
    '                Me.RadGridQ1.Visible = False
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ1_Click(sender As Object, e As EventArgs) Handles btnSearchingQ1.Click
        ViewState("DATA_GRID_Q1") = Nothing
        BindQ1Data(Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q2 Event"
#Region "Bind Grid"
    Private Sub BindQ2Data(ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ2.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ2.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id) as RowNumber  FROM " & vTable & " WHERE  TypeOf_Ticket_Id = 1 AND  Status_Id=" & Constants.DeclareKeyword.StatusId.Request_Routing
        sql = sql & " AND Group_Handle_Id  IN (SELECT Group_Id  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE User_Id=" & CurrentUser.UserId & ")"
        If Me.CheckBoxAllDateQ2.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ2.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ2.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ2.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ2.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ2.Text.Trim <> "" Then
            If Me.CheckBoxKeywordQ2.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ2.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ2.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ2.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ2.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q2") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID_Q2"), DataTable)
            End If
            ViewState("DATA_GRID_Q2") = dt
            Me.lblTotalQ2.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.RadGridQ2.Visible = True
                Me.RadGridQ2.DataSource = dt
                Me.RadGridQ2.DataBind()
            Else
                Me.RadGridQ2.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ2(sql, CurrentUser.UserFullName)
        End If
    End Sub
#End Region
#Region "Rad Grid Event"
    Public Sub lnkQ2_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim lnkPortal As LinkButton = CType(sender, LinkButton)
        ViewState(ViewStateInfo.Object_Id) = lnkPortal.CommandArgument
        BindDataQ8(ViewState(ViewStateInfo.Object_Id))
        EnableTab(6)
    End Sub
    'Private Sub RadGridQ2_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridQ2.NeedDataSource
    '    If Not e.IsFromDetailTable Then
    '        Dim dt As DataTable = Nothing
    '        If ViewState("DATA_GRID_Q2") Is Nothing Then
    '            Me.RadGridQ2.Visible = False
    '        Else
    '            dt = CType(ViewState("DATA_GRID_Q2"), DataTable)
    '            If dt.Rows.Count > 0 Then
    '                Me.RadGridQ2.Visible = True
    '                Me.RadGridQ2.DataSource = dt
    '            Else
    '                Me.RadGridQ2.Visible = False
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ2_Click(sender As Object, e As EventArgs) Handles btnSearchingQ2.Click
        ViewState("DATA_GRID_Q2") = Nothing
        BindQ2Data(Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q3 Event"
#Region "Bind Grid"
    Private Sub BindQ3Data(ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ3.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ3.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id) as RowNumber  FROM " & vTable & " WHERE  TypeOf_Ticket_Id = 1 AND  Status_Id=" & Constants.DeclareKeyword.StatusId.Declare_Routing
        sql = sql & " AND Group_Handle_Id  IN (SELECT Group_Id  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE User_Id=" & CurrentUser.UserId & ")"
        If Me.CheckBoxAllDateQ3.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ3.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ3.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ3.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ3.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ3.Text.Trim <> "" Then
            If Me.CheckBoxKeywordQ3.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ3.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ3.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ3.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ3.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q3") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID_Q3"), DataTable)
            End If
            ViewState("DATA_GRID_Q3") = dt
            Me.lblTotalQ3.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.RadGridQ3.Visible = True
                Me.RadGridQ3.DataSource = dt
                Me.RadGridQ3.DataBind()
            Else
                Me.RadGridQ3.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ3(sql, CurrentUser.UserFullName)
        End If
    End Sub
#End Region
#Region "Rad Grid Event"
    Public Sub lnkQ3_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim lnkPortal As LinkButton = CType(sender, LinkButton)
        ViewState(ViewStateInfo.Object_Id) = lnkPortal.CommandArgument
        BindDataQ8(ViewState(ViewStateInfo.Object_Id))
        EnableTab(6)
    End Sub
    'Private Sub RadGridQ3_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridQ3.NeedDataSource
    '    If Not e.IsFromDetailTable Then
    '        Dim dt As DataTable = Nothing
    '        If ViewState("DATA_GRID_Q3") Is Nothing Then
    '            Me.RadGridQ3.Visible = False
    '        Else
    '            dt = CType(ViewState("DATA_GRID_Q3"), DataTable)
    '            If dt.Rows.Count > 0 Then
    '                Me.RadGridQ3.Visible = True
    '                Me.RadGridQ3.DataSource = dt
    '            Else
    '                Me.RadGridQ3.Visible = False
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ3_Click(sender As Object, e As EventArgs) Handles btnSearchingQ3.Click
        ViewState("DATA_GRID_Q3") = Nothing
        BindQ3Data(Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q5 Event"
#Region "Bind Grid"
    Private Sub BindQ5Data(ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ5.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ5.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id) as RowNumber  FROM " & vTable & " WHERE  TypeOf_Ticket_Id = 1 AND  Status_Id=" & Constants.DeclareKeyword.StatusId.Declare_Telcos
        sql = sql & " AND Group_Handle_Id  IN (SELECT Group_Id  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE User_Id=" & CurrentUser.UserId & ")"
        If Me.CheckBoxAllDateQ5.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ5.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ5.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ5.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ5.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ5.Text.Trim <> "" Then
            If Me.CheckBoxKeyWordQ5.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ5.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ5.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ5.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ5.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q5") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID_Q5"), DataTable)
            End If
            ViewState("DATA_GRID_Q5") = dt
            Me.lblTotalQ5.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.RadGridQ5.Visible = True
                Me.RadGridQ5.DataSource = dt
                Me.RadGridQ5.DataBind()
            Else
                Me.RadGridQ5.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ5(sql, CurrentUser.UserFullName)
        End If
    End Sub
#End Region
#Region "Rad Grid Event"
    Public Sub lnkQ5_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim lnkPortal As LinkButton = CType(sender, LinkButton)
        ViewState(ViewStateInfo.Object_Id) = lnkPortal.CommandArgument
        BindDataQ8(ViewState(ViewStateInfo.Object_Id))
        EnableTab(6)
    End Sub
    Private Sub RadGridQ5_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridQ5.PageIndexChanged
        Dim dt As DataTable = Nothing
        If ViewState("DATA_GRID_Q5") Is Nothing Then
            Me.RadGridQ5.Visible = False
        Else
            dt = CType(ViewState("DATA_GRID_Q5"), DataTable)
            If dt.Rows.Count > 0 Then
                Me.RadGridQ5.Visible = True
                Me.RadGridQ5.DataSource = dt
            Else
                Me.RadGridQ5.Visible = False
            End If
        End If
    End Sub
    Private Sub RadGridQ5_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridQ5.NeedDataSource
        If Not e.IsFromDetailTable Then
            Dim dt As DataTable = Nothing
            If ViewState("DATA_GRID_Q5") Is Nothing Then
                Me.RadGridQ5.Visible = False
            Else
                dt = CType(ViewState("DATA_GRID_Q5"), DataTable)
                If dt.Rows.Count > 0 Then
                    Me.RadGridQ5.Visible = True
                    Me.RadGridQ5.DataSource = dt
                Else
                    Me.RadGridQ5.Visible = False
                End If
            End If
        End If
    End Sub
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ5_Click(sender As Object, e As EventArgs) Handles btnSearchingQ5.Click
        ViewState("DATA_GRID_Q5") = Nothing
        BindQ5Data(Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q6 Event"
#Region "Bind Grid"
    Private Sub BindQ6Data(ByVal strAction As String)
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ6.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ6.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id) as RowNumber  FROM " & vTable & " WHERE  TypeOf_Ticket_Id = 1 AND  Status_Id=" & Constants.DeclareKeyword.StatusId.Declare_Report
        sql = sql & " AND Group_Handle_Id  IN (SELECT Group_Id  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE User_Id=" & CurrentUser.UserId & ")"
        If Me.CheckBoxAllDateQ6.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ6.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ6.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ6.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ6.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ6.Text.Trim <> "" Then
            If Me.CheckBoxKeywordQ6.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ6.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ6.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ6.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ6.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q6") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Else
                dt = CType(ViewState("DATA_GRID_Q6"), DataTable)
            End If
            ViewState("DATA_GRID_Q6") = dt
            Me.lblTotalQ6.Text = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                Me.RadGridQ6.Visible = True
                Me.RadGridQ6.DataSource = dt
                Me.RadGridQ6.DataBind()
            Else
                Me.RadGridQ6.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ6(sql, CurrentUser.UserFullName)
        End If
    End Sub
#End Region
#Region "Rad Grid Event"
    Public Sub lnkQ6_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim lnkPortal As LinkButton = CType(sender, LinkButton)
        ViewState(ViewStateInfo.Object_Id) = lnkPortal.CommandArgument
        BindDataQ8(ViewState(ViewStateInfo.Object_Id))
        EnableTab(6)
    End Sub
    'Private Sub RadGridQ6_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridQ6.NeedDataSource
    '    If Not e.IsFromDetailTable Then
    '        Dim dt As DataTable = Nothing
    '        If ViewState("DATA_GRID_Q6") Is Nothing Then
    '            Me.RadGridQ6.Visible = False
    '        Else
    '            dt = CType(ViewState("DATA_GRID_Q6"), DataTable)
    '            If dt.Rows.Count > 0 Then
    '                Me.RadGridQ6.Visible = True
    '                Me.RadGridQ6.DataSource = dt
    '            Else
    '                Me.RadGridQ6.Visible = False
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ6_Click(sender As Object, e As EventArgs) Handles btnSearchingQ6.Click
        ViewState("DATA_GRID_Q6") = Nothing
        BindQ6Data(Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q7 Event"
#Region "Bind Grid"
    'Private Sub BindQ7Data(ByVal strAction As String)
    '    Dim sql As String = ""
    '    Dim sqlTotal As String = ""
    '    Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
    '    Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ7.SelectedDate.Value, "")
    '    Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ7.SelectedDate.Value, "")
    '    sql = "SELECT *,row_number() over( Order by Id) as RowNumber  FROM " & vTable & " WHERE TypeOf_Ticket_Id = 1 AND Status_Id=" & Constants.DeclareKeyword.StatusId.Add_Partner

    '    If Me.CheckBoxAllDateQ7.Checked = False Then
    '        sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
    '    End If
    '    If Me.DropDownListRangeShortCodeQ7.SelectedItem.Value <> "--all--" Then
    '        sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ7.SelectedItem.Value & "%'"
    '    End If
    '    If Me.DropDownListShortCodeQ7.SelectedItem.Value <> "--all--" Then
    '        sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ7.SelectedItem.Value & "%'"
    '    End If
    '    If Me.txtKeyWordQ7.Text.Trim <> "" Then
    '        If Me.CheckBoxKeywordQ7.Checked = True Then
    '            sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ7.Text.Trim & "%'"
    '        Else
    '            sql = sql & " AND Key_Word='" & Me.txtKeyWordQ7.Text.Trim & "'"
    '        End If
    '    End If
    '    If Me.DropDownListStatus_IdQ7.SelectedItem.Value > 0 Then
    '        sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ7.SelectedItem.Value & "'"
    '    End If

    '    If strAction = Constants.Action.Search Then

    '        Dim dt As DataTable = Nothing
    '        Dim dtPageCount As DataTable = Nothing
    '        If ViewState("DATA_GRID_Q7") Is Nothing Then
    '            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
    '        Else
    '            dt = CType(ViewState("DATA_GRID_Q7"), DataTable)
    '        End If
    '        ViewState("DATA_GRID_Q7") = dt
    '        Me.lblTotalQ7.Text = dt.Rows.Count
    '        If dt.Rows.Count > 0 Then
    '            Me.RadGridQ7.Visible = True
    '            Me.RadGridQ7.DataSource = dt
    '            Me.RadGridQ7.DataBind()
    '        Else
    '            Me.RadGridQ7.Visible = False
    '        End If
    '    ElseIf strAction = Constants.Action.Export Then
    '        'Export.Excel.SurveyInfo.ReportLogQ7(sql, CurrentUser.UserFullName)
    '    End If
    'End Sub
    Private Sub BindDataQ7(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sql As String = ""
        Dim sqlTotal As String = ""
        Dim vTable As String = "SMS_DictIndex_Keyword_Declare"
        Dim FromDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadFromDateQ7.SelectedDate.Value, "")
        Dim ToDate As String = Util.DateTimeFomat.Timestamp2YYYYMMDD(Me.RadToDateQ7.SelectedDate.Value, "")
        sql = "SELECT *,row_number() over( Order by Id desc) as RowNumber  FROM " & vTable & " WHERE TypeOf_Ticket_Id = 1 AND Status_Id=" & Constants.DeclareKeyword.StatusId.Add_Partner

        If Me.CheckBoxAllDateQ7.Checked = False Then
            sql = sql & " AND CONVERT(VARCHAR(10), Create_Time, 112) >='" & FromDate & "' and CONVERT(VARCHAR(10), Create_Time, 112) <='" & ToDate & "'"
        End If
        If Me.DropDownListRangeShortCodeQ7.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Range_Of_Short_Code like '%," & Me.DropDownListRangeShortCodeQ7.SelectedItem.Value & "%'"
        End If
        If Me.DropDownListShortCodeQ7.SelectedItem.Value <> "--all--" Then
            sql = sql & " AND Short_Code like '%," & Me.DropDownListShortCodeQ7.SelectedItem.Value & "%'"
        End If
        If Me.txtKeyWordQ7.Text.Trim <> "" Then
            If Me.CheckBoxKeywordQ7.Checked = True Then
                sql = sql & " AND Key_Word like '%" & Me.txtKeyWordQ7.Text.Trim & "%'"
            Else
                sql = sql & " AND Key_Word='" & Me.txtKeyWordQ7.Text.Trim & "'"
            End If
        End If
        If Me.DropDownListStatus_IdQ7.SelectedItem.Value > 0 Then
            sql = sql & " AND Status_Id =  '" & Me.DropDownListStatus_IdQ7.SelectedItem.Value & "'"
        End If

        If strAction = Constants.Action.Search Then
            sqlTotal = "SELECT COUNT(*) Total FROM (" & sql & ") T"
            sql = "SELECT * FROM (" & sql & ") T where  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
            Dim dt As DataTable = Nothing
            Dim dtPageCount As DataTable = Nothing
            If ViewState("DATA_GRID_Q7") Is Nothing Then
                dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
            Else
                dt = CType(ViewState("DATA_GRID_Q7"), DataTable)
                dtPageCount = CType(ViewState("DATA_COUNT_Q7"), DataTable)
            End If
            ViewState("DATA_GRID_Q7") = dt
            ViewState("DATA_COUNT_Q7") = dtPageCount
            pagerQ7.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Me.lblTotalQ7.Text = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            If dt.Rows.Count > 0 Then
                Me.DataGridQ7.Visible = True
                Me.DataGridQ7.DataSource = dt
                Me.DataGridQ7.DataBind()
                Me.pagerQ7.Visible = True
            Else
                Me.DataGridQ7.Visible = False
                Me.pagerQ7.Visible = False
            End If
        ElseIf strAction = Constants.Action.Export Then
            'Export.Excel.SurveyInfo.ReportLogQ7(sql, CurrentUser.UserFullName)
        End If

    End Sub
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pagerQ7.Command
        ViewState("DATA_GRID_Q7") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pagerQ7.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pagerQ7.PageSize
        Dim intCurentPage As Integer = pagerQ7.CurrentIndex
        BindDataQ7(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Rad Grid Event"
     
#End Region
#Region "Submmit"
    Protected Sub btnSearchingQ7_Click(sender As Object, e As EventArgs) Handles btnSearchingQ7.Click
        ViewState("DATA_GRID_Q7") = Nothing
        Dim intPageSize As Integer = pagerQ7.PageSize
        Dim intCurentPage As Integer = pagerQ7.CurrentIndex
        BindDataQ7(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#End Region
#Region "Q8 Event"
    Private Sub BindDataQ8(ByVal intId As Integer)
        If IsLockedTicket(intId) <> "" Then
            Me.lblerror.Text = "Lỗi thao tác dữ liệu !"
            Exit Sub
        End If
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Keyword_Declare Where (Is_Handle=0 Or Is_Handle=" & CurrentUser.UserId & ") AND  Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListTypeOf_Ticket_IdQ8.SelectedValue = dt.Rows(0).Item("TypeOf_Ticket_Id")
            Me.DropDownListTypeOf_MT_IdQ8.SelectedValue = dt.Rows(0).Item("TypeOf_MT_Id")
            Me.DropDownListDepartment_IdQ8.SelectedValue = dt.Rows(0).Item("Department_Id")
            Me.DropDownListPartner_IdQ8.SelectedValue = dt.Rows(0).Item("Partner_Id")
            BindShortCode(dt.Rows(0).Item("Short_Code"))
            BuildRangOfShortCode(dt.Rows(0).Item("Range_Of_Short_Code"))
            Me.txtKeyWordQ8.Text = dt.Rows(0).Item("Key_Word")
            Me.txtRouting_UrlQ8.Text = dt.Rows(0).Item("Routing_Url")
            Me.txtService_TextQ8.Text = dt.Rows(0).Item("Service_Text")
            Me.txtService_DescriptionQ8.Text = dt.Rows(0).Item("Service_Description")
            Me.txtTotal_MTQ8.Text = dt.Rows(0).Item("Total_MT")
            Me.txtMTQ8.Text = dt.Rows(0).Item("MT")
            Me.lblUserFileQ8.Text = " <a href=" & dt.Rows(0).Item("Url_File") & " target=""_blank""   title =""Download"" >" & dt.Rows(0).Item("Url_File") & "</a>"
            Me.DropDownListStatus_IdQ8.SelectedValue = dt.Rows(0).Item("Status_Id")
            Me.DropDownListCate_1Q8.SelectedValue = dt.Rows(0).Item("Cate1_Id")
            Me.DropDownListRouting_CodeQ8Proc.SelectedValue = dt.Rows(0).Item("Routing_Id")
            Me.txtDescriptionQ8.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            BindStatusHandle(dt.Rows(0).Item("Status_Id"))
        Else
            Me.lblerror.Text = "Ticket này có người khác đang xử lý !"
        End If
    End Sub
    Protected Sub btnUpdateQ8_Click(sender As Object, e As EventArgs) Handles btnUpdateQ8.Click
        If Me.DropDownListStatus_IdQ8Proc.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Trạng thái không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListGroup_Handle_IdQ8Proc.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Nhóm xử lý không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListStatus_IdQ8Proc.SelectedItem.Value = Constants.DeclareKeyword.StatusId.Declare_Routing Then
            If Me.DropDownListRouting_CodeQ8Proc.SelectedItem.Value = 0 Then
                Me.lblerror.Text = "Định tuyến không hợp lệ !"
                Exit Sub
            End If
        End If
        Dim Routing_Id As String = Me.DropDownListRouting_CodeQ8Proc.SelectedItem.Value
        Dim Routing_Code As String = IIf(Me.DropDownListRouting_CodeQ8Proc.SelectedItem.Value = 0, "", Me.DropDownListRouting_CodeQ8Proc.Text.Trim)
        Dim Status_Id As Integer = Me.DropDownListStatus_IdQ8Proc.SelectedItem.Value
        Dim Status_Text As String = Me.DropDownListStatus_IdQ8Proc.SelectedItem.Text
        Dim Group_Handle_Id As Integer = DropDownListGroup_Handle_IdQ8Proc.SelectedItem.Value
        Dim Group_Handle_Text As String = DropDownListGroup_Handle_IdQ8Proc.SelectedItem.ToString
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Is_Handle As Integer = 0
        Dim Proc_Trace As String = "<li>" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "</li>" & _
                CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") đã " & Me.DropDownListStatus_IdQ8Proc.SelectedItem.Text & ", chuyển đến nhóm xử lý: " & Me.DropDownListGroup_Handle_IdQ8Proc.SelectedItem.Text.Trim & " với ghi chú: <br>" & _
                Me.txtDescriptionQ8Proc.Text.Trim
        Dim sql As String = ""
        sql = " Update SMS_DictIndex_Keyword_Declare Set " & _
                  "Routing_Id=N'" & Routing_Id & "'," & _
                  "Routing_Code=N'" & Routing_Code & "'," & _
                  "Status_Id=N'" & Status_Id & "'," & _
                  "Status_Text=N'" & Status_Text & "'," & _
                  "Group_Handle_Id=N'" & Group_Handle_Id & "'," & _
                  "Group_Handle_Text=N'" & Group_Handle_Text & "'," & _
                  "Update_Time=N'" & Update_Time & "'," & _
                  "Update_By_Id=N'" & Update_By_Id & "'," & _
                  "Update_By_Text=N'" & Update_By_Text & "'," & _
                  "Is_Handle=N'" & Is_Handle & "'," & _
                  "Proc_Trace=Proc_Trace+N'" & Proc_Trace & "'" & _
                  " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID_Q1") = Nothing
            BindQ1Data(Constants.Action.Search)
            ViewState("DATA_GRID_Q2") = Nothing
            BindQ2Data(Constants.Action.Search)
            ViewState("DATA_GRID_Q3") = Nothing
            BindQ3Data(Constants.Action.Search)
            ViewState("DATA_GRID_Q5") = Nothing
            BindQ5Data(Constants.Action.Search)
            ViewState("DATA_GRID_Q6") = Nothing
            BindQ6Data(Constants.Action.Search)
            ViewState("DATA_GRID_Q7") = Nothing
            Dim intPageSize As Integer = pagerQ7.PageSize
            Dim intCurentPage As Integer = pagerQ7.CurrentIndex
            BindDataQ7(intPageSize, intCurentPage, Constants.Action.Search)
            EnableTab(0)

            sql = "SELECT*  FROM SMS_DictIndex_Keyword_Declare A INNER JOIN dbo.System_Users B ON A.Create_By_Id=B.Id WHERE a.Id=" & ViewState(ViewStateInfo.Object_Id)
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Dim Create_By_Text As String = ""
            Dim Create_Time As String = ""
            Dim Description As String = ""
            Dim Email_Create As String = ""
            If dt.Rows.Count > 0 Then
                Create_By_Text = dt.Rows(0).Item("Create_By_Text")
                Create_Time = DateTime.Parse(dt.Rows(0).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss")
                Description = dt.Rows(0).Item("Create_By_Text")
                Email_Create = dt.Rows(0).Item("Email")
            End If
            Dim EmailTo As String = GetEmailList(Group_Handle_Id)
            Dim TicketId As Integer = ViewState(ViewStateInfo.Object_Id)
            Dim Key_Word As String = Me.txtKeyWordQ8.Text.Trim
            Dim Short_Code As String = BuildShortCode()
            Dim Service_Text As String = Me.txtService_TextQ8.Text.Trim
            Dim Department_Code As String = Me.DropDownListDepartment_IdQ8.SelectedItem.Text
            Dim Email_Current As String = CurrentUser.UserEmail
            If EmailTo <> "" Then
                SentEmail(EmailTo, Email_Create & "," & Email_Current, TicketId, Me.DropDownListTypeOf_Ticket_IdQ8.SelectedItem.Text, Key_Word, Short_Code, Service_Text, Department_Code, Status_Text, Create_By_Text, Create_Time, Group_Handle_Text, Description)
            End If

        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
    Protected Sub btnCancelQ8_Click(sender As Object, e As EventArgs) Handles btnCancelQ8.Click
        Dim sql As String = "UPDATE SMS_DictIndex_Keyword_Declare SET Is_Handle=0 WHERE Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        ViewState("DATA_GRID_Q1") = Nothing
        BindQ1Data(Constants.Action.Search)
        ViewState("DATA_GRID_Q2") = Nothing
        BindQ2Data(Constants.Action.Search)
        ViewState("DATA_GRID_Q3") = Nothing
        BindQ3Data(Constants.Action.Search)
        ViewState("DATA_GRID_Q5") = Nothing
        BindQ5Data(Constants.Action.Search)
        ViewState("DATA_GRID_Q6") = Nothing
        BindQ6Data(Constants.Action.Search)
        ViewState("DATA_GRID_Q7") = Nothing
        Dim intPageSize As Integer = pagerQ7.PageSize
        Dim intCurentPage As Integer = pagerQ7.CurrentIndex
        BindDataQ7(intPageSize, intCurentPage, Constants.Action.Search)
        EnableTab(0)
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListRangeShortCodeQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ1.SelectedIndexChanged
        BindShortCodeQ1(DropDownListRangeShortCodeQ1.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListRangeShortCodeQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ2.SelectedIndexChanged
        BindShortCodeQ2(DropDownListRangeShortCodeQ2.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListRangeShortCodeQ3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ3.SelectedIndexChanged
        BindShortCodeQ3(DropDownListRangeShortCodeQ3.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListRangeShortCodeQ5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ5.SelectedIndexChanged
        BindShortCodeQ5(DropDownListRangeShortCodeQ5.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListRangeShortCodeQ6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ6.SelectedIndexChanged
        BindShortCodeQ6(DropDownListRangeShortCodeQ6.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListRangeShortCodeQ7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCodeQ7.SelectedIndexChanged
        BindShortCodeQ7(DropDownListRangeShortCodeQ7.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListDepartment_IdQ1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ1.SelectedIndexChanged
        If DropDownListDepartment_IdQ1.SelectedItem.Value > 0 Then
            BindPartnerQ1(Me.DropDownListDepartment_IdQ1.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListDepartment_IdQ2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ2.SelectedIndexChanged
        If DropDownListDepartment_IdQ2.SelectedItem.Value > 0 Then
            BindPartnerQ2(Me.DropDownListDepartment_IdQ2.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListDepartment_IdQ3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ3.SelectedIndexChanged
        If DropDownListDepartment_IdQ3.SelectedItem.Value > 0 Then
            BindPartnerQ3(Me.DropDownListDepartment_IdQ3.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListDepartment_IdQ5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ5.SelectedIndexChanged
        If DropDownListDepartment_IdQ5.SelectedItem.Value > 0 Then
            BindPartnerQ5(Me.DropDownListDepartment_IdQ5.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListDepartment_IdQ6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ6.SelectedIndexChanged
        If DropDownListDepartment_IdQ6.SelectedItem.Value > 0 Then
            BindPartnerQ6(Me.DropDownListDepartment_IdQ6.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListDepartment_IdQ7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_IdQ7.SelectedIndexChanged
        If DropDownListDepartment_IdQ7.SelectedItem.Value > 0 Then
            BindPartnerQ7(Me.DropDownListDepartment_IdQ7.SelectedItem.Value)
        End If
    End Sub
    Protected Sub DropDownListStatus_IdQ8Proc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListStatus_IdQ8Proc.SelectedIndexChanged
        BindGroupHandle(DropDownListStatus_IdQ8Proc.SelectedItem.Value)
    End Sub
#Region "Build Rang Of ShortCode"
    Private Function BuildShortCode() As String
        Dim str As String = ""

        If Me.CheckBox996.Checked = True Then
            str = str & "," & CheckBox996.Text.Trim
        End If
        If Me.CheckBox997.Checked = True Then
            str = str & "," & CheckBox997.Text.Trim
        End If
        If Me.CheckBox998.Checked = True Then
            str = str & "," & CheckBox998.Text.Trim
        End If

        If Me.CheckBox8079.Checked = True Then
            str = str & "," & CheckBox8079.Text.Trim
        End If
        If Me.CheckBox8179.Checked = True Then
            str = str & "," & CheckBox8179.Text.Trim
        End If
        If Me.CheckBox8279.Checked = True Then
            str = str & "," & CheckBox8279.Text.Trim
        End If
        If Me.CheckBox8379.Checked = True Then
            str = str & "," & CheckBox8379.Text.Trim
        End If
        If Me.CheckBox8479.Checked = True Then
            str = str & "," & CheckBox8479.Text.Trim
        End If
        If Me.CheckBox8579.Checked = True Then
            str = str & "," & CheckBox8579.Text.Trim
        End If
        If Me.CheckBox8679.Checked = True Then
            str = str & "," & CheckBox8679.Text.Trim
        End If
        If Me.CheckBox8779.Checked = True Then
            str = str & "," & CheckBox8779.Text.Trim
        End If

        If Me.CheckBox6066.Checked = True Then
            str = str & "," & CheckBox6066.Text.Trim
        End If
        If Me.CheckBox6166.Checked = True Then
            str = str & "," & CheckBox6166.Text.Trim
        End If
        If Me.CheckBox6266.Checked = True Then
            str = str & "," & CheckBox6266.Text.Trim
        End If
        If Me.CheckBox6366.Checked = True Then
            str = str & "," & CheckBox6366.Text.Trim
        End If
        If Me.CheckBox6466.Checked = True Then
            str = str & "," & CheckBox6466.Text.Trim
        End If
        If Me.CheckBox6566.Checked = True Then
            str = str & "," & CheckBox6566.Text.Trim
        End If
        If Me.CheckBox6666.Checked = True Then
            str = str & "," & CheckBox6666.Text.Trim
        End If
        If Me.CheckBox6766.Checked = True Then
            str = str & "," & CheckBox6766.Text.Trim
        End If
        If Me.CheckBox8099.Checked = True Then
            str = str & "," & CheckBox8099.Text.Trim
        End If
        If Me.CheckBox8199.Checked = True Then
            str = str & "," & CheckBox8199.Text.Trim
        End If
        If Me.CheckBox8299.Checked = True Then
            str = str & "," & CheckBox8299.Text.Trim
        End If
        If Me.CheckBox8399.Checked = True Then
            str = str & "," & CheckBox8399.Text.Trim
        End If
        If Me.CheckBox8499.Checked = True Then
            str = str & "," & CheckBox8499.Text.Trim
        End If
        If Me.CheckBox8599.Checked = True Then
            str = str & "," & CheckBox8599.Text.Trim
        End If
        If Me.CheckBox8699.Checked = True Then
            str = str & "," & CheckBox8699.Text.Trim
        End If
        If Me.CheckBox8799.Checked = True Then
            str = str & "," & CheckBox8799.Text.Trim
        End If
        Return str
    End Function
    Private Function BuildRangOfShortCode() As String
        Dim str As String = ""
        If Me.CheckBox99x.Checked = True Then
            str = str & "," & CheckBox99x.Text.Trim
        End If
        If Me.CheckBox8x79.Checked = True Then
            str = str & "," & CheckBox8x79.Text.Trim
        End If
        If Me.CheckBox6x66.Checked = True Then
            str = str & "," & CheckBox6x66.Text.Trim
        End If
        If Me.CheckBox8x99.Checked = True Then
            str = str & "," & CheckBox8x99.Text.Trim
        End If
        Return str

    End Function
    Private Sub BindShortCode(ByVal str As String)
        If str.IndexOf("996") > 0 Then
            Me.CheckBox996.Checked = True
            Me.CheckBox996.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("997") > 0 Then
            Me.CheckBox997.Checked = True
            Me.CheckBox997.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("998") > 0 Then
            Me.CheckBox998.Checked = True
            Me.CheckBox998.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6066") > 0 Then
            Me.CheckBox6066.Checked = True
            Me.CheckBox6066.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6166") > 0 Then
            Me.CheckBox6166.Checked = True
            Me.CheckBox6166.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6266") > 0 Then
            Me.CheckBox6266.Checked = True
            Me.CheckBox6266.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6366") > 0 Then
            Me.CheckBox6366.Checked = True
            Me.CheckBox6366.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6466") > 0 Then
            Me.CheckBox6466.Checked = True
            Me.CheckBox6466.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6566") > 0 Then
            Me.CheckBox6566.Checked = True
            Me.CheckBox6566.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6666") > 0 Then
            Me.CheckBox6666.Checked = True
            Me.CheckBox6666.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("6766") > 0 Then
            Me.CheckBox6766.Checked = True
            Me.CheckBox6766.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8079") > 0 Then
            Me.CheckBox8079.Checked = True
        End If
        If str.IndexOf("8179") > 0 Then
            Me.CheckBox8179.Checked = True
            Me.CheckBox8179.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8279") > 0 Then
            Me.CheckBox8279.Checked = True
            Me.CheckBox8279.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8379") > 0 Then
            Me.CheckBox8379.Checked = True
            Me.CheckBox8379.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8479") > 0 Then
            Me.CheckBox8479.Checked = True
            Me.CheckBox8479.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8579") > 0 Then
            Me.CheckBox8579.Checked = True
            Me.CheckBox8579.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8679") > 0 Then
            Me.CheckBox8679.Checked = True
            Me.CheckBox8679.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8779") > 0 Then
            Me.CheckBox8779.Checked = True
            Me.CheckBox8779.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8879") > 0 Then
            Me.CheckBox8879.Checked = True
            Me.CheckBox8879.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8099") > 0 Then
            Me.CheckBox8099.Checked = True
            Me.CheckBox8099.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8199") > 0 Then
            Me.CheckBox8199.Checked = True
            Me.CheckBox8199.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8299") > 0 Then
            Me.CheckBox8299.Checked = True
            Me.CheckBox8299.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8399") > 0 Then
            Me.CheckBox8399.Checked = True
            Me.CheckBox8399.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8499") > 0 Then
            Me.CheckBox8499.Checked = True
            Me.CheckBox8499.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8599") > 0 Then
            Me.CheckBox8599.Checked = True
            Me.CheckBox8599.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8699") > 0 Then
            Me.CheckBox8699.Checked = True
            Me.CheckBox8699.ForeColor = Drawing.Color.Blue
        End If
        If str.IndexOf("8799") > 0 Then
            Me.CheckBox8799.Checked = True
            Me.CheckBox8799.ForeColor = Drawing.Color.Blue
        End If
    End Sub
    Private Sub BuildRangOfShortCode(ByVal str As String)
        If str.IndexOf("99x") > 0 Then
            Me.CheckBox99x.Checked = True
        End If
        If str.IndexOf("8x79") > 0 Then
            Me.CheckBox8x79.Checked = True
        End If
        If str.IndexOf("6x66") > 0 Then
            Me.CheckBox6x66.Checked = True
        End If
        If str.IndexOf("8x99") > 0 Then
            Me.CheckBox8x99.Checked = True
        End If
    End Sub
#End Region
#End Region
#Region "Enable Tab"
    Private Sub EnableTab(ByVal TabNumber As Integer)
        Me.RadTabStrip1.Tabs(TabNumber).Enabled = True
        Me.RadTabStrip1.Tabs(TabNumber).Selected = True
        Select Case TabNumber
            Case 0
                Me.RadPageViewQ1.Selected = True
            Case 6
                Me.RadPageViewQ8.Selected = True
        End Select
    End Sub
#End Region
#Region "Lock Ticket"
    Private Function IsLockedTicket(ByVal TicketId As Integer) As String
        Dim retval As String = ""
        Dim sql As String = "UPDATE SMS_DictIndex_Keyword_Declare SET Is_Handle=" & CurrentUser.UserId & " WHERE Id=" & TicketId
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Catch ex As Exception
            retval = ex.Message
        End Try
        Return retval
    End Function
#End Region
#Region "Send Email"
    Private Function SentEmail(ByVal strTo As String, _
                               ByVal strCC As String, _
                               ByVal TicketId As String, _
                               ByVal Subject As String, _
                               ByVal KeyWord As String, _
                               ByVal ShortCode As String, _
                               ByVal Service_Text As String, _
                               ByVal Thirdparty_Text As String, _
                               ByVal Status_Text As String, _
                               ByVal Create_By_Text As String, _
                               ByVal Create_Time As String, _
                               ByVal Group_Handle_Text As String, _
                               ByVal Description As String) As String
        Dim vUrl As String = "http://" & Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & "/index.aspx" ' Request.ServerVariables("URL")
        Dim vContent As String = "Thông tin đăng ký khai báo mã dịch vụ SMS MO <br>" & _
        "<li>Mã ticket: " & TicketId & "</li>" & _
        "<li>Mã dịch vụ: " & KeyWord & "</li>" & _
        "<li>Đầu số: " & ShortCode & "</li>" & _
        "<li>Dịch vụ: " & Service_Text & "</li>" & _
        "<li>Bộ phận khai báo: " & Thirdparty_Text & "</li>" & _
        "<li>Trạng thái: " & Status_Text & "</li>" & _
        "<li>Người khởi tạo: " & Create_By_Text & "</li>" & _
        "<li>Thời gian khởi tạo: " & Create_Time & "</li>" & _
        "<li>Chuyển đến nhóm xử lý: " & Group_Handle_Text & "</li>" & _
        "<li>Ghi chú: " & Description & "</li>" & _
        "<br>" & _
         "<br>" & _
         " <i>Đây là email tự động, vui lòng không gửi thư vào địa chỉ này. Mọi vướng mắc liên quan đến hệ thống hãy liên hệ:</i>" & _
         " <li>Phòng Đối Soát Tính Cước - Kaio</li>" & _
         " <li>Điện thoại: 84-4-33578820. Ext 732 </li>" & _
         " <li>E-mail: support@vmgmedia.vn</li>" & _
         "<br>" & _
        "------------------------------------------------------------------"
        Subject = "[" & TicketId & "]" & Subject & "[" & KeyWord & "]" & "[" & ShortCode & "]"
        Util.DoStuff()
        If EmailData.AlertSMSDeclare(Subject, strTo, strCC, vContent) = False Then
            LogService.WriteLog(Constants.LogLevel._Debug, "Lỗi gửi e-mail")
            Return "Lỗi gửi e-mail"
        Else
            Return ""
        End If

    End Function
#End Region
#Region "Get List Email"
    Private Function GetEmailList(ByVal GroupHandleId As Integer) As String
        Dim retval As String = ""
        Dim sql As String = "SELECT *  FROM SMS_DictIndex_Keyword_Declare_User_Handle WHERE Group_Id=" & GroupHandleId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            For j As Integer = 0 To dt.Rows.Count - 1
                If retval = "" Then
                    retval = dt.Rows(j).Item("Email")
                Else
                    retval = retval & "," & dt.Rows(j).Item("Email")
                End If
            Next
        End If
        Return retval
    End Function
#End Region
#Region "Show and Hide Tab"
    Private Sub ShowTab(ByVal Dept_Id As Integer)
        Select Case Dept_Id
            '-	Định tuyến mã
            '-	Xử lý ticket
            Case 9 ' Phòng Hệ thống
                Me.RadTabStrip1.Tabs(1).Enabled = True
                Me.RadTabStrip1.Tabs(1).Selected = True
                Me.RadPageViewQ2.Selected = True

                Me.RadTabStrip1.Tabs(0).Visible = False
                Me.RadPageViewQ1.Visible = False
                Me.RadTabStrip1.Tabs(2).Visible = False
                Me.RadPageViewQ3.Visible = False
                Me.RadTabStrip1.Tabs(3).Visible = False
                Me.RadPageViewQ5.Visible = False
                Me.RadTabStrip1.Tabs(4).Visible = False
                Me.RadPageViewQ6.Visible = False
                Me.RadTabStrip1.Tabs(5).Visible = False
                Me.RadPageViewQ7.Visible = False
            Case 6 'DVKH
                ' -	Ticket chờ xử lý
                '-	Khai báo Telcos
                '-	Khai báo Filter, report
                '-	Ticket đã xử lý
                '-	Xử lý ticket
                Me.RadTabStrip1.Tabs(0).Enabled = True
                Me.RadTabStrip1.Tabs(0).Selected = True
                Me.RadPageViewQ1.Selected = True

                Me.RadTabStrip1.Tabs(1).Visible = False
                Me.RadPageViewQ2.Visible = False
                Me.RadTabStrip1.Tabs(4).Visible = False
                Me.RadPageViewQ6.Visible = False
            Case 7 'DSTC
                '-	Gán doanh thu
                '-	Ticket đã xử lý
                '-	Xử lý ticket
                Me.RadTabStrip1.Tabs(4).Enabled = True
                Me.RadTabStrip1.Tabs(4).Selected = True
                Me.RadPageViewQ6.Selected = True

                Me.RadTabStrip1.Tabs(0).Visible = False
                Me.RadPageViewQ1.Visible = False
                Me.RadTabStrip1.Tabs(1).Visible = False
                Me.RadPageViewQ2.Visible = False
                Me.RadTabStrip1.Tabs(2).Visible = False
                Me.RadPageViewQ3.Visible = False
                Me.RadTabStrip1.Tabs(3).Visible = False
                Me.RadPageViewQ5.Visible = False
                Me.RadTabStrip1.Tabs(5).Visible = False
                Me.RadPageViewQ7.Visible = False
        End Select
    End Sub
#End Region

  
End Class