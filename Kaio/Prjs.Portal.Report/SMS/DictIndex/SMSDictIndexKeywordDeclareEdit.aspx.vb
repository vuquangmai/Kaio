Imports System.Data.SqlClient

Public Class SMSDictIndexKeywordDeclareEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
            BindCate1(0)
            BindGroupHandle()
            CreateFolder()
            ShowObjectEdit()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI KHAI BÁO ĐĂNG KÝ MÃ DỊCH VỤ SMS"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "KHAI BÁO ĐĂNG KÝ MÃ DỊCH VỤ SMS"
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Me.btnDelete.Visible = False
            End If
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Me.txtUserFile.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Me.txtUserFile_Edit.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Where Id=" & CurrentUser.DeptId & " Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDepartment_Id.Items.Clear()
        'Me.DropDownListDepartment_Id.Items.Add(New ListItem("--Chọn--", 0))
        'Me.DropDownListDepartment_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Code"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    
    Private Sub BindPartner(ByVal Department_Id As Integer)
        Dim sql As String = "SELECT A.Id,A.Contract_Code,A.Contract_Number,A.Cycle_Contract_Text, A.Contract_Text,A.Partner_Id,  " & _
             " B.Service_Text ,B.Service_Code,C.Model_Text,C.Model_Code,D.Partner_Text,D.Partner_Code " & _
             " FROM Ccare_Management_Contract A  INNER JOIN System_Service_Info B ON A.Service_Id=B.Id " & _
             " INNER JOIN System_Cooperation_Model C ON A.Cooperation_Id=C.Id " & _
             " INNER JOIN Ccare_Management_Partner D ON A.Partner_Id=D.Id " & _
             " WHERE  A.Service_Id= " & Constants.ServiceInfo.Id.SMS
        If Department_Id > 0 Then
            sql = sql & " AND A.Department_Id =" & Department_Id
        End If
        sql = "SELECT  Partner_Id, Partner_Code FROM (" & sql & ") T GROUP BY Partner_Id, Partner_Code "
        sql = sql & " ORDER BY Partner_Code "

        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("Tự doanh", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Code"), dt.Rows(i).Item("Partner_Id")))
            Next
        End If
    End Sub
    Private Sub BindCate1(ByVal intRootId As Integer)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Service_Info Where Root_Id =" & intRootId & " Order by Cate_Name"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCate_1.Items.Clear()
        Me.DropDownListCate_1.Items.Add(New ListItem(("--Chọn--"), 0))
        Me.DropDownListCate1_Edit.Items.Clear()
        Me.DropDownListCate1_Edit.Items.Add(New ListItem(("--Chọn--"), 0))
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCate_1.Items.Add(New ListItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
                Me.DropDownListCate1_Edit.Items.Add(New ListItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindGroupHandle()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Keyword_Declare_Group_Handle Where Id=1"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListGroup_Handle_Id.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListGroup_Handle_Id.Items.Add(New ListItem(dt.Rows(i).Item("Group_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Keyword_Declare Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListTypeOf_Ticket_Id.SelectedValue = dt.Rows(0).Item("TypeOf_Ticket_Id")
            Me.DropDownListTypeOf_MT_Id.SelectedValue = dt.Rows(0).Item("TypeOf_MT_Id")
            Me.DropDownListDepartment_Id.SelectedValue = dt.Rows(0).Item("Department_Id")
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.txtKeyWord.Text = dt.Rows(0).Item("Key_Word")
            Me.txtRouting_Url.Text = dt.Rows(0).Item("Routing_Url")
            Me.txtMT.Text = dt.Rows(0).Item("MT")
            Me.txtTotal_MT.Text = dt.Rows(0).Item("Total_MT")
            Me.txtService_Text.Text = dt.Rows(0).Item("Service_Text")
            Me.txtService_Description.Text = dt.Rows(0).Item("Service_Description")
            Me.txtUserFile.Text = dt.Rows(0).Item("Url_File")
            Me.DropDownListStatus_Id.SelectedValue = dt.Rows(0).Item("Status_Id")
            Me.DropDownListCate_1.SelectedValue = dt.Rows(0).Item("Cate1_Id")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            BindShortCode(dt.Rows(0).Item("Short_Code"))
            BuildRangOfShortCode(dt.Rows(0).Item("Range_Of_Short_Code"))
            ShowObjectEdit()
            Me.txtRouting_Url_Edit.Text = dt.Rows(0).Item("Routing_Url_Edit")
            Me.txtMT_Edit.Text = dt.Rows(0).Item("MT_Edit")
            Me.txtTotal_MT_Edit.Text = dt.Rows(0).Item("Total_MT_Edit")
            Me.txtService_Text_Edit.Text = dt.Rows(0).Item("Service_Text_Edit")
            Me.txtService_Description_Edit.Text = dt.Rows(0).Item("Service_Description_Edit")
            Me.DropDownListCate1_Edit.SelectedValue = dt.Rows(0).Item("Cate1_Id_Edit")
            Me.txtUserFile_Edit.Text = dt.Rows(0).Item("Url_File_Edit")

        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.DropDownListTypeOf_Ticket_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Thể loại không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListTypeOf_MT_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Định dạng MT không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListDepartment_Id.SelectedItem.Text = "--Chọn--" Then
            Me.lblerror.Text = "Phòng ban không hợp lệ !"
            Exit Sub
        End If
        If Me.txtKeyWord.Text = "" Then
            Me.lblerror.Text = "Mã dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListCate_1.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Dich vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTotal_MT.Text = "" Then
            Me.lblerror.Text = "Số lượng MT không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtTotal_MT.Text) Then
            Me.lblerror.Text = "Số lượng MT không hợp lệ !"
            Exit Sub
        End If
        If Me.txtService_Text.Text.Trim = "" Then
            Me.lblerror.Text = "Tên dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtMT.Text.Trim = "" Then
            Me.lblerror.Text = "Nội dung MT không hợp lệ !"
            Exit Sub
        End If
        If Me.txtService_Description.Text.Trim = "" Then
            Me.lblerror.Text = "Mô tả dịch vụ không hợp lệ !"
            Exit Sub
        End If
        Dim TypeOf_Ticket_Id As Integer = Me.DropDownListTypeOf_Ticket_Id.SelectedItem.Value
        Dim TypeOf_Ticket_Text As String = Me.DropDownListTypeOf_Ticket_Id.SelectedItem.Text
        Dim TypeOf_MT_Id As Integer = Me.DropDownListTypeOf_MT_Id.SelectedItem.Value
        Dim TypeOf_MT_Text As String = Me.DropDownListTypeOf_MT_Id.SelectedItem.Text
        Dim Department_Id As String = Me.DropDownListDepartment_Id.SelectedItem.Value
        Dim Department_Code As String = Me.DropDownListDepartment_Id.SelectedItem.Text
        Dim Partner_Id As String = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Partner_Code As String = Me.DropDownListPartner_Id.SelectedItem.Text
        Dim Range_Of_Short_Code As String = BuildRangOfShortCode()
        If Range_Of_Short_Code = "" Then
            Me.lblerror.Text = "Dải số không hợp lệ !"
            Exit Sub
        End If
        Dim Short_Code As String = BuildShortCode()
        If Short_Code = "" Then
            Me.lblerror.Text = "Dải số không hợp lệ !"
            Exit Sub
        End If
        Dim Key_Word As String = Me.txtKeyWord.Text.Trim
        Dim Routing_Id As Integer = 0
        Dim Routing_Code As String = ""
        Dim Routing_Url As String = Me.txtRouting_Url.Text.Trim
        Dim Routing_Url_Edit As String = Me.txtRouting_Url_Edit.Text.Trim
        Dim MT As String = Me.txtMT.Text.Trim
        Dim MT_Edit As String = Me.txtMT_Edit.Text.Trim 'Edit
        Dim Total_MT As Integer = Me.txtTotal_MT.Text.Trim
        Dim Total_MT_Edit As Integer = IIf(Me.txtTotal_MT_Edit.Text.Trim = "", 0, Me.txtTotal_MT_Edit.Text.Trim)
        Dim Service_Text As String = Me.txtService_Text.Text.Trim
        Dim Service_Text_Edit As String = Me.txtService_Text_Edit.Text.Trim
        Dim Service_Description As String = Me.txtService_Description.Text.Trim
        Dim Service_Description_Edit As String = Me.txtService_Description_Edit.Text.Trim
        Dim Cate1_Id As Integer = Me.DropDownListCate_1.SelectedItem.Value
        Dim Cate1_Id_Edit As Integer = Me.DropDownListCate1_Edit.SelectedItem.Value
        Dim Cate1_Text As String = Me.DropDownListCate_1.SelectedItem.Text.Trim
        Dim Cate1_Text_Edit As String = Me.DropDownListCate1_Edit.SelectedItem.Text.Trim
        Dim Url_File As String = txtUserFile.Text.Trim
        Dim Url_File_Edit As String = txtUserFile_Edit.Text.Trim
        Dim Group_Handle_Id As Integer = Me.DropDownListGroup_Handle_Id.SelectedItem.Value
        Dim Group_Handle_Text As String = Me.DropDownListGroup_Handle_Id.SelectedItem.Text
        Dim Status_Id As Integer = Me.DropDownListStatus_Id.SelectedItem.Value
        Dim Status_Text As String = Me.DropDownListStatus_Id.SelectedItem.Text
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim Proc_Trace As String = "<li>" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "</li>" & _
                CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") đã tạo mới ticket với ghi chú: <br>" & _
                Me.txtDescription.Text.Trim
        Dim sql As String = ""
        Dim TicketId As Integer = 0
        ' sql = "SELECT * From  SMS_DictIndex_Keyword_Declare  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Short_Code=N'" & Short_Code & "' And Key_Word=N'" & Key_Word & "' And TypeOf_Ticket_Id =" & TypeOf_Ticket_Id
        Dim strCheck As String = CheckExist(Key_Word, Short_Code, TypeOf_Ticket_Id)
        If strCheck = "" Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Proc_Trace = "<li>" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "</li>" & _
                CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") đã tạo mới ticket với ghi chú: <br>" & _
                Me.txtDescription.Text.Trim
                'sql = "Insert Into SMS_DictIndex_Keyword_Declare(TypeOf_Ticket_Id,TypeOf_Ticket_Text,Department_Id, Department_Code,Partner_Id,Partner_Code,  Range_Of_Short_Code, Short_Code, Key_Word,Routing_Id,Routing_Code,Routing_Url,Routing_Url_Edit,MT,MT_Edit,Total_MT,Total_MT_Edit,Service_Text,Service_Text_Edit,Service_Description,Service_Description_Edit,Cate1_Id,Cate1_Id_Edit,Cate1_Text,Cate1_Text_Edit,Url_File,Url_File_Edit,Group_Handle_Id,Group_Handle_Text,Status_Id,Status_Text, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description,Proc_Trace)" & _
                '    "Values (N'" & TypeOf_Ticket_Id & "',N'" & TypeOf_Ticket_Text & "',N'" & Department_Id & "',N'" & Department_Code & "',N'" & Partner_Id & "',N'" & Partner_Code & "',N'" & Range_Of_Short_Code & "',N'" & Short_Code & "',N'" & Key_Word & "',N'" & Routing_Id & "',N'" & Routing_Code & "',N'" & Routing_Url & "',N'" & Routing_Url_Edit & "',N'" & MT & "',N'" & MT_Edit & "',N'" & Total_MT & "',N'" & Total_MT_Edit & "',N'" & Service_Text & "',N'" & Service_Text_Edit & "',N'" & Service_Description & "',N'" & Service_Description_Edit & "',N'" & Cate1_Id & "',N'" & Cate1_Id_Edit & "',N'" & Cate1_Text & "',N'" & Cate1_Text_Edit & "',N'" & Url_File & "',N'" & Url_File_Edit & "',N'" & Group_Handle_Id & "',N'" & Group_Handle_Text & "',N'" & Status_Id & "',N'" & Status_Text & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "',N'" & Proc_Trace & "')"
                Dim cmd As New SqlClient.SqlCommand
                With cmd
                    .Parameters.Clear()
                    .Connection = GlobalConnection
                    .CommandText = "SMS_DictIndex_Keyword_Declare_Insert"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
                    .Parameters("@Id").Direction = ParameterDirection.Output

                    .Parameters.Add(New SqlParameter("@TypeOf_Ticket_Id", SqlDbType.Int))
                    .Parameters("@TypeOf_Ticket_Id").Value = TypeOf_Ticket_Id

                    .Parameters.Add(New SqlParameter("@TypeOf_Ticket_Text", SqlDbType.NVarChar, 50))
                    .Parameters("@TypeOf_Ticket_Text").Value = TypeOf_Ticket_Text

                    .Parameters.Add(New SqlParameter("@TypeOf_MT_Id", SqlDbType.Int))
                    .Parameters("@TypeOf_MT_Id").Value = TypeOf_MT_Id

                    .Parameters.Add(New SqlParameter("@TypeOf_MT_Text", SqlDbType.NVarChar, 50))
                    .Parameters("@TypeOf_MT_Text").Value = TypeOf_MT_Text

                    .Parameters.Add(New SqlParameter("@Department_Id", SqlDbType.Int))
                    .Parameters("@Department_Id").Value = Department_Id

                    .Parameters.Add(New SqlParameter("@Department_Code", SqlDbType.NVarChar, 100))
                    .Parameters("@Department_Code").Value = Department_Code

                    .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int))
                    .Parameters("@Partner_Id").Value = Partner_Id

                    .Parameters.Add(New SqlParameter("@Partner_Code", SqlDbType.NVarChar, 100))
                    .Parameters("@Partner_Code").Value = Partner_Code

                    .Parameters.Add(New SqlParameter("@Range_Of_Short_Code", SqlDbType.NVarChar, 50))
                    .Parameters("@Range_Of_Short_Code").Value = Range_Of_Short_Code

                    .Parameters.Add(New SqlParameter("@Short_Code", SqlDbType.NVarChar, 2000))
                    .Parameters("@Short_Code").Value = Short_Code

                    .Parameters.Add(New SqlParameter("@Key_Word", SqlDbType.NVarChar, 50))
                    .Parameters("@Key_Word").Value = Key_Word

                    .Parameters.Add(New SqlParameter("@Routing_Id", SqlDbType.Int))
                    .Parameters("@Routing_Id").Value = Routing_Id

                    .Parameters.Add(New SqlParameter("@Routing_Code", SqlDbType.NVarChar, 100))
                    .Parameters("@Routing_Code").Value = Routing_Code

                    .Parameters.Add(New SqlParameter("@Routing_Url", SqlDbType.NVarChar, 1000))
                    .Parameters("@Routing_Url").Value = Routing_Url

                    .Parameters.Add(New SqlParameter("@Routing_Url_Edit", SqlDbType.NVarChar, 1000))
                    .Parameters("@Routing_Url_Edit").Value = Routing_Url_Edit

                    .Parameters.Add(New SqlParameter("@MT", SqlDbType.NVarChar, 500))
                    .Parameters("@MT").Value = MT

                    .Parameters.Add(New SqlParameter("@MT_Edit", SqlDbType.NVarChar, 500))
                    .Parameters("@MT_Edit").Value = MT_Edit

                    .Parameters.Add(New SqlParameter("@Total_MT", SqlDbType.Int, 50))
                    .Parameters("@Total_MT").Value = Total_MT

                    .Parameters.Add(New SqlParameter("@Total_MT_Edit", SqlDbType.Int, 50))
                    .Parameters("@Total_MT_Edit").Value = Total_MT_Edit

                    .Parameters.Add(New SqlParameter("@Service_Text", SqlDbType.NVarChar, 1000))
                    .Parameters("@Service_Text").Value = Service_Text

                    .Parameters.Add(New SqlParameter("@Service_Text_Edit", SqlDbType.NVarChar, 1000))
                    .Parameters("@Service_Text_Edit").Value = Service_Text_Edit

                    .Parameters.Add(New SqlParameter("@Service_Description", SqlDbType.NVarChar, 1000))
                    .Parameters("@Service_Description").Value = Service_Description

                    .Parameters.Add(New SqlParameter("@Service_Description_Edit", SqlDbType.NVarChar, 1000))
                    .Parameters("@Service_Description_Edit").Value = Service_Description_Edit

                    .Parameters.Add(New SqlParameter("@Cate1_Id", SqlDbType.Int, 50))
                    .Parameters("@Cate1_Id").Value = Cate1_Id

                    .Parameters.Add(New SqlParameter("@Cate1_Id_Edit", SqlDbType.Int, 50))
                    .Parameters("@Cate1_Id_Edit").Value = Cate1_Id_Edit

                    .Parameters.Add(New SqlParameter("@Cate1_Text", SqlDbType.NVarChar, 500))
                    .Parameters("@Cate1_Text").Value = Cate1_Text

                    .Parameters.Add(New SqlParameter("@Cate1_Text_Edit", SqlDbType.NVarChar, 500))
                    .Parameters("@Cate1_Text_Edit").Value = Cate1_Text_Edit

                    .Parameters.Add(New SqlParameter("@Url_File", SqlDbType.NVarChar, 500))
                    .Parameters("@Url_File").Value = Url_File

                    .Parameters.Add(New SqlParameter("@Url_File_Edit", SqlDbType.NVarChar, 500))
                    .Parameters("@Url_File_Edit").Value = Url_File_Edit

                    .Parameters.Add(New SqlParameter("@Group_Handle_Id", SqlDbType.Int, 50))
                    .Parameters("@Group_Handle_Id").Value = Group_Handle_Id

                    .Parameters.Add(New SqlParameter("@Group_Handle_Text", SqlDbType.NVarChar, 50))
                    .Parameters("@Group_Handle_Text").Value = Group_Handle_Text

                    .Parameters.Add(New SqlParameter("@Status_Id", SqlDbType.Int, 50))
                    .Parameters("@Status_Id").Value = Status_Id

                    .Parameters.Add(New SqlParameter("@Status_Text", SqlDbType.NVarChar, 50))
                    .Parameters("@Status_Text").Value = Status_Text

                    .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
                    .Parameters("@Create_By_Id").Value = Create_By_Id

                    .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 500))
                    .Parameters("@Create_By_Text").Value = Create_By_Text

                    .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
                    .Parameters("@Create_Time").Value = Create_Time

                    .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
                    .Parameters("@Update_By_Id").Value = Update_By_Id

                    .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 500))
                    .Parameters("@Update_By_Text").Value = Update_By_Text

                    .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
                    .Parameters("@Update_Time").Value = Update_Time

                    .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
                    .Parameters("@Description").Value = Description

                    .Parameters.Add(New SqlParameter("@Proc_Trace", SqlDbType.NVarChar, 2000))
                    .Parameters("@Proc_Trace").Value = Proc_Trace

                    Try
                        .ExecuteNonQuery()
                        TicketId = .Parameters("@Id").Value
                    Catch ex As Exception
                        Me.lblerror.Text = "Lỗi thêm nhóm account. Mã lỗi: " & ex.Message
                        Exit Sub
                    End Try
                End With
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                TicketId = ViewState(ViewStateInfo.Object_Id)
                Proc_Trace = "<li>" & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & "</li>" & _
              CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") đã cập nhật thông tin khai báo ticket với ghi chú: <br>" & _
              Me.txtDescription.Text.Trim
                sql = " Update SMS_DictIndex_Keyword_Declare Set Partner_Id=N'" & Partner_Id & "'," & _
                    "TypeOf_MT_Id=N'" & TypeOf_MT_Id & "'," & _
                    "TypeOf_MT_Text=N'" & TypeOf_MT_Text & "'," & _
                    "Partner_Code=N'" & Partner_Code & "'," & _
                    "Range_Of_Short_Code=N'" & Range_Of_Short_Code & "'," & _
                    "Short_Code=N'" & Short_Code & "'," & _
                    "Key_Word=N'" & Key_Word & "'," & _
                    "Routing_Url=N'" & Routing_Url & "'," & _
                    "Routing_Url_Edit=N'" & Routing_Url_Edit & "'," & _
                    "MT=N'" & MT & "'," & _
                    "MT_Edit=N'" & MT_Edit & "'," & _
                    "Total_MT=N'" & Total_MT & "'," & _
                    "Total_MT_Edit=N'" & Total_MT_Edit & "'," & _
                    "Service_Text=N'" & Service_Text & "'," & _
                    "Service_Text_Edit=N'" & Service_Text_Edit & "'," & _
                    "Service_Description=N'" & Service_Description & "'," & _
                    "Service_Description_Edit=N'" & Service_Description_Edit & "'," & _
                    "Cate1_Id=N'" & Cate1_Id & "'," & _
                    "Cate1_Id_Edit=N'" & Cate1_Id_Edit & "'," & _
                    "Cate1_Text=N'" & Cate1_Text & "'," & _
                    "Cate1_Text_Edit=N'" & Cate1_Text_Edit & "'," & _
                    "Url_File=N'" & Url_File & "'," & _
                    "Url_File_Edit=N'" & Url_File_Edit & "'," & _
                    "Group_Handle_Id=N'" & Group_Handle_Id & "'," & _
                    "Group_Handle_Text=N'" & Group_Handle_Text & "'," & _
                    "Status_Id=N'" & Status_Id & "'," & _
                    "Status_Text=N'" & Status_Text & "'," & _
                    "Update_Time=N'" & Update_Time & "'," & _
                    "Update_By_Id=N'" & Update_By_Id & "'," & _
                    "Update_By_Text=N'" & Update_By_Text & "'," & _
                    "Description=N'" & Description & "'," & _
                    "Proc_Trace=Proc_Trace+N'" & Proc_Trace & "'" & _
                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
                Try
                    MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordDeclareList)
                Catch ex As Exception
                    Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
                End Try
            End If
            Dim EmailTo As String = GetEmailList(Group_Handle_Id)
            If EmailTo <> "" Then
                SentEmail(EmailTo, CurrentUser.UserEmail, TicketId, Me.DropDownListTypeOf_Ticket_Id.SelectedItem.Text, Key_Word, Short_Code, Service_Text, Department_Code, Status_Text, Create_By_Text, Create_Time, Group_Handle_Text, Description)
            End If
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd & ". Đầu số: " & strCheck
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From  SMS_DictIndex_Keyword_Declare  " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordDeclareList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_Id.SelectedIndexChanged
        BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
    End Sub
    Protected Sub CheckBox99x_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox99x.CheckedChanged
        If Me.CheckBox99x.Checked = True Then
            Me.CheckBox996.Checked = True
            Me.CheckBox997.Checked = True
            Me.CheckBox998.Checked = True
        Else
            Me.CheckBox996.Checked = False
            Me.CheckBox997.Checked = False
            Me.CheckBox998.Checked = False
        End If
    End Sub
    Protected Sub CheckBox8x79_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8x79.CheckedChanged
        If Me.CheckBox8x79.Checked = True Then
            Me.CheckBox8079.Checked = True
            Me.CheckBox8179.Checked = True
            Me.CheckBox8279.Checked = True
            Me.CheckBox8379.Checked = True
            Me.CheckBox8479.Checked = True
            Me.CheckBox8579.Checked = True
            Me.CheckBox8679.Checked = True
            Me.CheckBox8779.Checked = True
            Me.CheckBox8879.Checked = True
        Else
            Me.CheckBox8079.Checked = False
            Me.CheckBox8179.Checked = False
            Me.CheckBox8279.Checked = False
            Me.CheckBox8379.Checked = False
            Me.CheckBox8479.Checked = False
            Me.CheckBox8579.Checked = False
            Me.CheckBox8679.Checked = False
            Me.CheckBox8779.Checked = False
            Me.CheckBox8879.Checked = False
        End If
    End Sub
    Protected Sub CheckBox8x80_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6x66.CheckedChanged
        If Me.CheckBox6x66.Checked = True Then
            Me.CheckBox6066.Checked = True
            Me.CheckBox6166.Checked = True
            Me.CheckBox6266.Checked = True
            Me.CheckBox6366.Checked = True
            Me.CheckBox6466.Checked = True
            Me.CheckBox6566.Checked = True
            Me.CheckBox6666.Checked = True
            Me.CheckBox6766.Checked = True
        Else
            Me.CheckBox6066.Checked = False
            Me.CheckBox6166.Checked = False
            Me.CheckBox6266.Checked = False
            Me.CheckBox6366.Checked = False
            Me.CheckBox6466.Checked = False
            Me.CheckBox6566.Checked = False
            Me.CheckBox6666.Checked = False
            Me.CheckBox6766.Checked = False

        End If
    End Sub
    Protected Sub CheckBox8x99_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8x99.CheckedChanged
        If Me.CheckBox8x99.Checked = True Then
            Me.CheckBox8099.Checked = True
            Me.CheckBox8199.Checked = True
            Me.CheckBox8299.Checked = True
            Me.CheckBox8399.Checked = True
            Me.CheckBox8499.Checked = True
            Me.CheckBox8599.Checked = True
            Me.CheckBox8699.Checked = True
            Me.CheckBox8799.Checked = True
        Else
            Me.CheckBox8099.Checked = False
            Me.CheckBox8199.Checked = False
            Me.CheckBox8299.Checked = False
            Me.CheckBox8399.Checked = False
            Me.CheckBox8499.Checked = False
            Me.CheckBox8599.Checked = False
            Me.CheckBox8699.Checked = False
            Me.CheckBox8799.Checked = False
        End If
    End Sub
    Protected Sub DropDownListTypeOf_Ticket_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTypeOf_Ticket_Id.SelectedIndexChanged
        ShowObjectEdit()
    End Sub
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region
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
        If Me.CheckBox8879.Checked = True Then
            str = str & "," & CheckBox8879.Text.Trim
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
        If Me.CheckBox99x.Checked = True Or Me.CheckBox996.Checked = True Or Me.CheckBox997.Checked = True Or Me.CheckBox998.Checked = True Then
            str = str & "," & CheckBox99x.Text.Trim
        End If
        If Me.CheckBox8x79.Checked = True Or Me.CheckBox8079.Checked = True Or Me.CheckBox8179.Checked = True Or Me.CheckBox8279.Checked = True Or Me.CheckBox8379.Checked = True Or Me.CheckBox8479.Checked = True Or Me.CheckBox8579.Checked = True Or Me.CheckBox8679.Checked = True Or Me.CheckBox8779.Checked = True Or Me.CheckBox8879.Checked = True Then
            str = str & "," & CheckBox8x79.Text.Trim
        End If
        If Me.CheckBox6x66.Checked = True Or Me.CheckBox6066.Checked = True Or Me.CheckBox6166.Checked = True Or Me.CheckBox6266.Checked = True Or Me.CheckBox6366.Checked = True Or Me.CheckBox6466.Checked = True Or Me.CheckBox6566.Checked = True Or Me.CheckBox6666.Checked = True Or Me.CheckBox6766.Checked = True Then
            str = str & "," & CheckBox6x66.Text.Trim
        End If
        If Me.CheckBox8x99.Checked = True Or Me.CheckBox8099.Checked = True Or Me.CheckBox8199.Checked = True Or Me.CheckBox8299.Checked = True Or Me.CheckBox8399.Checked = True Or Me.CheckBox8499.Checked = True Or Me.CheckBox8599.Checked = True Or Me.CheckBox8699.Checked = True Or Me.CheckBox8799.Checked = True Then
            str = str & "," & CheckBox8x99.Text.Trim
        End If
        Return str

    End Function
    Private Sub BindShortCode(ByVal str As String)
        If str.IndexOf("996") > 0 Then
            Me.CheckBox996.Checked = True
        End If
        If str.IndexOf("997") > 0 Then
            Me.CheckBox997.Checked = True
        End If
        If str.IndexOf("998") > 0 Then
            Me.CheckBox998.Checked = True
        End If
        If str.IndexOf("6066") > 0 Then
            Me.CheckBox6066.Checked = True
        End If
        If str.IndexOf("6166") > 0 Then
            Me.CheckBox6166.Checked = True
        End If
        If str.IndexOf("6266") > 0 Then
            Me.CheckBox6266.Checked = True
        End If
        If str.IndexOf("6366") > 0 Then
            Me.CheckBox6366.Checked = True
        End If
        If str.IndexOf("6466") > 0 Then
            Me.CheckBox6466.Checked = True
        End If
        If str.IndexOf("6566") > 0 Then
            Me.CheckBox6566.Checked = True
        End If
        If str.IndexOf("6666") > 0 Then
            Me.CheckBox6666.Checked = True
        End If
        If str.IndexOf("6766") > 0 Then
            Me.CheckBox6766.Checked = True
        End If
        If str.IndexOf("8079") > 0 Then
            Me.CheckBox8079.Checked = True
        End If
        If str.IndexOf("8179") > 0 Then
            Me.CheckBox8179.Checked = True
        End If
        If str.IndexOf("8279") > 0 Then
            Me.CheckBox8279.Checked = True
        End If
        If str.IndexOf("8379") > 0 Then
            Me.CheckBox8379.Checked = True
        End If
        If str.IndexOf("8479") > 0 Then
            Me.CheckBox8479.Checked = True
        End If
        If str.IndexOf("8579") > 0 Then
            Me.CheckBox8579.Checked = True
        End If
        If str.IndexOf("8679") > 0 Then
            Me.CheckBox8679.Checked = True
        End If
        If str.IndexOf("8779") > 0 Then
            Me.CheckBox8779.Checked = True
        End If
        If str.IndexOf("8879") > 0 Then
            Me.CheckBox8879.Checked = True
        End If
        If str.IndexOf("8099") > 0 Then
            Me.CheckBox8099.Checked = True
        End If
        If str.IndexOf("8199") > 0 Then
            Me.CheckBox8199.Checked = True
        End If
        If str.IndexOf("8299") > 0 Then
            Me.CheckBox8299.Checked = True
        End If
        If str.IndexOf("8399") > 0 Then
            Me.CheckBox8399.Checked = True
        End If
        If str.IndexOf("8499") > 0 Then
            Me.CheckBox8499.Checked = True
        End If
        If str.IndexOf("8599") > 0 Then
            Me.CheckBox8599.Checked = True
        End If
        If str.IndexOf("8699") > 0 Then
            Me.CheckBox8699.Checked = True
        End If
        If str.IndexOf("8799") > 0 Then
            Me.CheckBox8799.Checked = True
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
#Region "Check Exist"
    Private Function CheckExist(ByVal Keyword As String, ByVal CurrentShort_Code As String, ByVal TypeOf_Ticket_Id As Integer) As String
        Dim retval As String = ""
        Dim sql As String = ""
        sql = "SELECT * From  SMS_DictIndex_Keyword_Declare  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Key_Word=N'" & Keyword & "' And TypeOf_Ticket_Id =" & TypeOf_Ticket_Id
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count = 0 Then
            retval = ""
        Else
            For j As Integer = 0 To dt.Rows.Count - 1
                Dim Short_Code As String = dt.Rows(j).Item("Short_Code")
                Dim splitout = Split(Short_Code.ToString(), ",")
                For i As Integer = 0 To UBound(splitout)
                    If CurrentShort_Code.IndexOf(splitout(i)) > 0 Then
                        If retval = "" Then
                            retval = "'" & splitout(i) & "'"
                        Else
                            retval = retval & ",'" & splitout(i) & "'"
                        End If
                    End If
                Next
            Next
        End If
        Return retval
    End Function
#End Region
#Region "Show/Hide Object Edit"
    Private Sub ShowObjectEdit()
        If Me.DropDownListTypeOf_Ticket_Id.SelectedItem.Value = 2 Then
            Me.txtRouting_Url_Edit.Visible = True
            Me.lblRouting_Url_Edit.Visible = True
            Me.lblMT_Edit.Visible = True
            Me.txtMT_Edit.Visible = True
            Me.lblTotal_MT_Edit.Visible = True
            Me.txtTotal_MT_Edit.Visible = True
            Me.lblService_Text_Edit.Visible = True
            Me.txtService_Text_Edit.Visible = True
            Me.lblService_Description_Edit.Visible = True
            Me.txtService_Description_Edit.Visible = True
            Me.lblUserFile_Edit.Visible = True
            Me.txtUserFile_Edit.Visible = True
            Me.lblCate_Edit.Visible = True
            Me.DropDownListCate1_Edit.Visible = True
        Else
            Me.txtRouting_Url_Edit.Visible = False
            Me.lblRouting_Url_Edit.Visible = False
            Me.lblMT_Edit.Visible = False
            Me.txtMT_Edit.Visible = False
            Me.lblTotal_MT_Edit.Visible = False
            Me.txtTotal_MT_Edit.Visible = False
            Me.lblService_Text_Edit.Visible = False
            Me.txtService_Text_Edit.Visible = False
            Me.lblService_Description_Edit.Visible = False
            Me.txtService_Description_Edit.Visible = False
            Me.lblUserFile_Edit.Visible = False
            Me.txtUserFile_Edit.Visible = False
            Me.lblCate_Edit.Visible = False
            Me.DropDownListCate1_Edit.Visible = False
        End If
    End Sub

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

End Class