Imports System.Data.SqlClient

Public Class AdminStaffInternalEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN NHÂN VIÊN"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN NHÂN VIÊN"
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
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDept()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDept_Id.Items.Clear()
        Me.DropDownListDept_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDept_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDept_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindCompetence(ByVal Department_Id As Integer)
        Dim sql As String = "SELECT * FROM System_Competence Where Department_Id=" & Department_Id & " Order by Competence_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCompetence.Items.Clear()
        Me.DropDownListCompetence.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListCompetence.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCompetence.Items.Add(New ListItem(dt.Rows(i).Item("Competence_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM System_Staff_Internal Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtStaff_Text.Text = dt.Rows(0).Item("Staff_Text")
            Me.txtStaff_Code.Text = dt.Rows(0).Item("Staff_Code")
            Me.DropDownListDept_Id.SelectedValue = dt.Rows(0).Item("Department_Id")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            BindCompetence(Me.DropDownListDept_Id.SelectedItem.Value)
            Me.DropDownListCompetence.SelectedValue = dt.Rows(0).Item("Competence_Id")

            Me.txtEmail.Text = IIf(IsDBNull(dt.Rows(0).Item("Email")) = True, "", dt.Rows(0).Item("Email"))
            Me.txtMobile.Text = IIf(IsDBNull(dt.Rows(0).Item("Mobile")) = True, "", dt.Rows(0).Item("Mobile"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtStaff_Text.Text = "" Then
            Me.lblerror.Text = "Tên nhân viên không hợp lệ !"
            Exit Sub
        End If
        If Me.txtStaff_Code.Text = "" Then
            Me.lblerror.Text = "Mã nhân viên không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListDept_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Phòng ban không hợp lệ !"
            Exit Sub
        End If
        Dim Staff_Text As String = Me.txtStaff_Text.Text.Trim
        Dim Staff_Code As String = Me.txtStaff_Code.Text.Trim
        Dim Department_Id As Integer = Me.DropDownListDept_Id.SelectedItem.Value
        Dim Competence_Id As Integer = Me.DropDownListCompetence.SelectedItem.Value
        Dim Email As String = Me.txtEmail.Text.Trim
        Dim Mobile As String = Me.txtMobile.Text.Trim
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  System_Staff_Internal  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Staff_Code=N'" & Staff_Code & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into System_Staff_Internal(Staff_Text, Staff_Code, Department_Id,Competence_Id, Email, Mobile, Status, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Staff_Text & "',N'" & Staff_Code & "',N'" & Department_Id & "',N'" & Competence_Id & "',N'" & Email & "',N'" & Mobile & "',N'" & Status & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update System_Staff_Internal Set Staff_Text=N'" & Staff_Text & "'," & _
     "Staff_Code=N'" & Staff_Code & "'," & _
     "Department_Id=N'" & Department_Id & "'," & _
     "Competence_Id=N'" & Competence_Id & "'," & _
     "Email=N'" & Email & "'," & _
     "Mobile=N'" & Mobile & "'," & _
     "Status=N'" & Status & "'," & _
     "Update_Time=N'" & Update_Time & "'," & _
     "Update_By_Id=N'" & Update_By_Id & "'," & _
     "Update_By_Text=N'" & Update_By_Text & "'," & _
     "Description=N'" & Description & "'" & _
     " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Admin.AdminStaffInternalList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminStaffInternalList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Update System_Staff_Internal Set Is_Delete=1 " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminStaffInternalList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListDept_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDept_Id.SelectedIndexChanged
        BindCompetence(Me.DropDownListDept_Id.SelectedItem.Value)
    End Sub
#End Region
End Class