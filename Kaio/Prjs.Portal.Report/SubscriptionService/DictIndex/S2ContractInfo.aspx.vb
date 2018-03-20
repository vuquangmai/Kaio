Imports Telerik.Web.UI
Imports Telerik.Web.UI.Calendar.View
Public Class S2ContractInfo
    Inherits System.Web.UI.Page
#Region "Page Load"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDictIndex()
            ViewState(ViewStateInfo.Object_Id) = Request.QueryString("objid")
            ViewState("Year") = Request.QueryString("year")
            ViewState("Month") = Request.QueryString("month")

            If Not ViewState(ViewStateInfo.Object_Id) Is Nothing Then
                Me.lbltitle.Text = "THÔNG TIN HỢP ĐỒNG, TIẾN ĐỘ ĐỐI SOÁT THANH TOÁN - DỊCH VỤ S2"
                bindData(ViewState(ViewStateInfo.Object_Id))
                BindAppendix(Me.txtContract_Code.Text.Trim)
                BindRatio(Me.txtContract_Code.Text.Trim)
            End If
        End If
    End Sub
#End Region
#Region "BindData"
    Private Sub bindData(ByVal ContractText As String)
        Dim sql As String = "SELECT * FROM Ccare_Management_Contract Where Contract_Code=N'" & ContractText & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListDepartment_Id.SelectedValue = dt.Rows(0).Item("Department_Id")
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.DropDownListService_Id.SelectedValue = dt.Rows(0).Item("Service_Id")
            Me.DropDownListCooperation_Id.SelectedValue = dt.Rows(0).Item("Cooperation_Id")
            Me.txtContract_Code.Text = dt.Rows(0).Item("Contract_Code")
            Me.txtContract_Number.Text = dt.Rows(0).Item("Contract_Number")
            Me.txtContract_Text.Text = dt.Rows(0).Item("Contract_Text")
            Me.RadContract_Sign_Date.SelectedDate = dt.Rows(0).Item("Contract_Sign_Date")
            Me.RadAcceptance_Test_Date.SelectedDate = dt.Rows(0).Item("Acceptance_Test_Date")
            Me.RadLaunching_Date.SelectedDate = dt.Rows(0).Item("Launching_Date")
            Me.ContractFile.Text = dt.Rows(0).Item("Contract_File")
            Me.DropDownListCycle_Contract.SelectedValue = dt.Rows(0).Item("Cycle_Contract_Id")
            Me.txtRatio_1.Text = dt.Rows(0).Item("Ratio_1")
            Me.txtRatio_2.Text = dt.Rows(0).Item("Ratio_2")
            Me.DropDownListCcare_Cost.SelectedValue = dt.Rows(0).Item("Ccare_Cost")
            Me.txtMin_Revenue.Text = dt.Rows(0).Item("Ccare_Cost")
            'BindRatio(Me.txtContract_Code.Text.Trim)
            BindStaffInternal(Me.DropDownListDepartment_Id.SelectedItem.Value)
            Me.txtSurrogate_A.Text = dt.Rows(0).Item("Surrogate_A")
            Me.txtSurrogate_B.Text = dt.Rows(0).Item("Surrogate_B")
            Me.DropDownListBusiness_Name_A.SelectedValue = dt.Rows(0).Item("Business_Name_A")
            Me.txtBusiness_Competence_A.Text = dt.Rows(0).Item("Business_Competence_A")
            Me.txtBusiness_Mobile_A.Text = dt.Rows(0).Item("Business_Mobile_A")
            Me.txtBusiness_Email_A.Text = dt.Rows(0).Item("Business_Email_A")
            Me.txtBusiness_Name_B.Text = dt.Rows(0).Item("Business_Name_B")
            Me.txtBusiness_Competence_B.Text = dt.Rows(0).Item("Business_Competence_B")
            Me.txtBusiness_Mobile_B.Text = dt.Rows(0).Item("Business_Mobile_B")
            Me.txtBusiness_Email_B.Text = dt.Rows(0).Item("Business_Email_B")

            Me.DropDownListTechnical_Name_A.SelectedValue = dt.Rows(0).Item("Technical_Name_A")
            Me.txtTechnical_Competence_A.Text = dt.Rows(0).Item("Technical_Competence_A")
            Me.txtTechnical_Mobile_A.Text = dt.Rows(0).Item("Technical_Mobile_A")
            Me.txtTechnical_Email_A.Text = dt.Rows(0).Item("Technical_Email_A")
            Me.txtTechnical_Name_B.Text = dt.Rows(0).Item("Technical_Name_B")
            Me.txtTechnical_Competence_B.Text = dt.Rows(0).Item("Technical_Competence_B")
            Me.txtTechnical_Mobile_B.Text = dt.Rows(0).Item("Technical_Mobile_B")
            Me.txtTechnical_Email_B.Text = dt.Rows(0).Item("Technical_Email_B")

            Me.DropDownListData_Name_A.SelectedValue = dt.Rows(0).Item("Data_Name_A")
            Me.txtData_Competence_A.Text = dt.Rows(0).Item("Data_Competence_A")
            Me.txtData_Mobile_A.Text = dt.Rows(0).Item("Data_Mobile_A")
            Me.txtData_Email_A.Text = dt.Rows(0).Item("Data_Email_A")
            Me.txtData_Name_B.Text = dt.Rows(0).Item("Data_Name_B")
            Me.txtData_Competence_B.Text = dt.Rows(0).Item("Data_Competence_B")
            Me.txtData_Mobile_B.Text = dt.Rows(0).Item("Data_Mobile_B")
            Me.txtData_Email_B.Text = dt.Rows(0).Item("Data_Email_B")

            Me.DropDownListPayment_Name_A.SelectedValue = dt.Rows(0).Item("Payment_Name_A")
            Me.txtPayment_Competence_A.Text = dt.Rows(0).Item("Payment_Competence_A")
            Me.txtPayment_Mobile_A.Text = dt.Rows(0).Item("Payment_Mobile_A")
            Me.txtPayment_Email_A.Text = dt.Rows(0).Item("Payment_Email_A")
            Me.txtPayment_Name_B.Text = dt.Rows(0).Item("Payment_Name_B")
            Me.txtPayment_Competence_B.Text = dt.Rows(0).Item("Payment_Competence_B")
            Me.txtPayment_Mobile_B.Text = dt.Rows(0).Item("Payment_Mobile_B")
            Me.txtPayment_Email_B.Text = dt.Rows(0).Item("Payment_Email_B")

            Me.DropDownListCcare_Name_A.SelectedValue = dt.Rows(0).Item("Ccare_Name_A")
            Me.txtCcare_Competence_A.Text = dt.Rows(0).Item("Ccare_Competence_A")
            Me.txtCcare_Mobile_A.Text = dt.Rows(0).Item("Ccare_Mobile_A")
            Me.txtCcare_Email_A.Text = dt.Rows(0).Item("Ccare_Email_A")
            Me.txtCcare_Name_B.Text = dt.Rows(0).Item("Ccare_Name_B")
            Me.txtCcare_Competence_B.Text = dt.Rows(0).Item("Ccare_Competence_B")
            Me.txtCcare_Mobile_B.Text = dt.Rows(0).Item("Ccare_Mobile_B")
            Me.txtCcare_Email_B.Text = dt.Rows(0).Item("Ccare_Email_B")

            BindAppendix(Me.txtContract_Code.Text.Trim)
            Me.DropDownListContract_Status.SelectedValue = dt.Rows(0).Item("Contract_Status")
            Me.txtDescription.Text = dt.Rows(0).Item("Description")
            Me.txtContract_Code.ReadOnly = True
        End If
    End Sub
#End Region
#Region "Bind Appendix"
    Private Sub BindAppendix(Contract_Code As String)
        Dim dt As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
            Dim sql As String = "SELECT * FROM Ccare_Management_Contract_Appendix Where Contract_Code=N'" & Contract_Code & "' Order by Appendix_Date"
            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Else
            dt = CType(ViewState("DATA_GRID"), DataTable)
        End If
        If dt.Rows.Count > 0 Then
            DataGrid.DataSource = dt
            DataGrid.DataBind()
            DataGrid.Visible = True
        Else
            DataGrid.Visible = False
        End If
    End Sub
#End Region
#Region "Bind Ratio"
    Private Sub BindRatio(Contract_Code As String)
        Dim dt As DataTable = Nothing
        If ViewState("DATA_GRID_2") Is Nothing Then
            Dim sql As String = "SELECT * FROM Ccare_Management_Contract_Ratio Where Contract_Code=N'" & Contract_Code & "' Order by Min_Val"
            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Else
            dt = CType(ViewState("DATA_GRID_2"), DataTable)
        End If
        If dt.Rows.Count > 0 Then
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
            DataGrid2.Visible = True
        Else
            DataGrid2.Visible = False
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindDept()
        BindPartner()
        BindService()
        BindCooperationModel()
        BindDate()

    End Sub
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_Id.Items.Clear()
        Me.DropDownListDepartment_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDepartment_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Order by Partner_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindService()
        Dim sql As String = "SELECT * FROM System_Service_Info Order by Service_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListService_Id.Items.Clear()
        Me.DropDownListService_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListService_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListService_Id.Items.Add(New ListItem(dt.Rows(i).Item("Service_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindCooperationModel()
        Dim sql As String = "SELECT * FROM System_Cooperation_Model Order by Model_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCooperation_Id.Items.Clear()
        Me.DropDownListCooperation_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListCooperation_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCooperation_Id.Items.Add(New ListItem(dt.Rows(i).Item("Model_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindDate()
        Me.RadContract_Sign_Date.SelectedDate = Now
        Me.RadLaunching_Date.SelectedDate = Now
        Me.RadAcceptance_Test_Date.SelectedDate = Now
    End Sub
    Private Sub BindStaffInternal(Department_Id As Integer)
        Me.DropDownListBusiness_Name_A.Items.Clear()
        Me.DropDownListBusiness_Name_A.Items.Add(New ListItem("--Unknown--", 0))
        Me.DropDownListBusiness_Name_A.SelectedValue = 0
        Me.DropDownListTechnical_Name_A.Items.Clear()
        Me.DropDownListTechnical_Name_A.Items.Add(New ListItem("--Unknown--", 0))
        Me.DropDownListTechnical_Name_A.SelectedValue = 0
        Me.DropDownListData_Name_A.Items.Clear()
        Me.DropDownListData_Name_A.Items.Add(New ListItem("--Unknown--", 0))
        Me.DropDownListData_Name_A.SelectedValue = 0
        Me.DropDownListPayment_Name_A.Items.Clear()
        Me.DropDownListPayment_Name_A.Items.Add(New ListItem("--Unknown--", 0))
        Me.DropDownListPayment_Name_A.SelectedValue = 0
        Me.DropDownListCcare_Name_A.Items.Clear()
        Me.DropDownListCcare_Name_A.Items.Add(New ListItem("--Unknown--", 0))
        Me.DropDownListCcare_Name_A.SelectedValue = 0
        If Department_Id > 0 Then
            Dim sql As String = "SELECT * FROM System_Staff_Internal  Where Is_Delete=0 And Department_Id=" & Department_Id & " Order by Staff_Text"
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.DropDownListBusiness_Name_A.Items.Add(New ListItem(dt.Rows(i).Item("Staff_Text"), dt.Rows(i).Item("Staff_Text")))
                    Me.DropDownListTechnical_Name_A.Items.Add(New ListItem(dt.Rows(i).Item("Staff_Text"), dt.Rows(i).Item("Staff_Text")))
                    Me.DropDownListData_Name_A.Items.Add(New ListItem(dt.Rows(i).Item("Staff_Text"), dt.Rows(i).Item("Staff_Text")))
                    Me.DropDownListPayment_Name_A.Items.Add(New ListItem(dt.Rows(i).Item("Staff_Text"), dt.Rows(i).Item("Staff_Text")))
                    Me.DropDownListCcare_Name_A.Items.Add(New ListItem(dt.Rows(i).Item("Staff_Text"), dt.Rows(i).Item("Staff_Text")))
                Next
            End If
        End If
    End Sub
#End Region
#Region "RadGrid Event"
    Private Sub RadGrid_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid.NeedDataSource
        If Not e.IsFromDetailTable Then
            Dim sql As String = "SELECT * FROM Billing_Brand_Work_Follow Where Year=" & ViewState("Year") & " And month= " & ViewState("Month") & " And Contract_Code=N'" & ViewState(ViewStateInfo.Object_Id) & "'"

            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                RadGrid.DataSource = dt
                Me.RadGrid.Visible = True
                Me.lblerror.Text = ""
            Else
                Me.RadGrid.Visible = False
                Me.lblerror.Text = "Không có dữ liệu tiến độ đối soát, thanht toán !"
            End If
        End If
    End Sub
    Private Sub RadGrid_DetailTableDataBind(ByVal source As Object, ByVal e As GridDetailTableDataBindEventArgs) Handles RadGrid.DetailTableDataBind
        Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
        Dim sql As String = ""
        Select Case e.DetailTableView.Name
            Case "Orders"
                Dim Work_Follow_Id As String = dataItem.GetDataKeyValue("ID").ToString()
                sql = "SELECT *  FROM Billing_Brand_Work_Follow_Detail  " & _
               " Where Work_Follow_Id=" & Work_Follow_Id & _
               " ORDER BY Task_Order_Current "

                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                e.DetailTableView.DataSource = dt

            Case "OrderDetails"
                Dim vId As String = dataItem.GetDataKeyValue("ID").ToString()
                Dim splitout = Split(vId.ToString(), "M")
                Dim Department_Id As Integer = splitout(0)
                Dim Service_Id As Integer = splitout(1)
                sql = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Contract_Text,A.Cycle_Contract_Text,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE A.Department_Id=" & Department_Id & " AND A.Service_Id= " & Service_Id
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
End Class