Imports System.Data.SqlClient

Public Class SMSDictIndexKeywordEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
            BindCate1(0)
            BindRouting()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI MÃ DỊCH VỤ SMS"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM MÃ DỊCH VỤ SMS"
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
        Me.DropDownListDepartment_Id.Items.Clear()
        Me.DropDownListDepartment_Id.Items.Add(New ListItem("--Chọn--", 0))
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
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
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
        sql = sql & " ORDER BY D.Partner_Code "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("--Tự doanh--", 0))
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
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCate_1.Items.Add(New ListItem(dt.Rows(i).Item("Cate_Name"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
    Private Sub BindRouting()
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Routing  Order by Routing_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListRouting_Text.Items.Clear()
        Me.DropDownListRouting_Text.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListRouting_Text.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListRouting_Text.Items.Add(New ListItem(dt.Rows(i).Item("Routing_Code"), dt.Rows(i).Item("Routing_Code")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Keyword_List Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListDepartment_Id.SelectedValue = dt.Rows(0).Item("Department_Code")
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.DropDownListRangeShortCode.SelectedValue = dt.Rows(0).Item("Range_Of_Short_Code")
            BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)
            Me.DropDownListShortCode.SelectedValue = dt.Rows(0).Item("Short_Code")
            Me.txtKeyWord.Text = dt.Rows(0).Item("Key_Word")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.DropDownListCate_1.SelectedValue = dt.Rows(0).Item("Cate1_Id")
            Me.DropDownListRouting_Text.SelectedValue = dt.Rows(0).Item("Routing_Text")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click

        If Me.DropDownListDepartment_Id.SelectedItem.Text = "--Chọn--" Then
            Me.lblerror.Text = "Phòng ban không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListRangeShortCode.SelectedItem.Text = "--Chọn--" Then
            Me.lblerror.Text = "Dải số không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListShortCode.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đầu số không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListRouting_Text.SelectedItem.Text = "--Chọn--" Then
            Me.lblerror.Text = "Định tuyến mã không hợp lệ !"
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
        Dim Department_Id As String = Me.DropDownListDepartment_Id.SelectedItem.Value
        Dim Department_Code As String = Me.DropDownListDepartment_Id.SelectedItem.Text
        Dim Routing_Code As String = Me.DropDownListRouting_Text.SelectedItem.Value
        Dim Routing_Text As String = Me.DropDownListRouting_Text.SelectedItem.Value
        Dim Partner_Id As String = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Partner_Code As String = Me.DropDownListPartner_Id.SelectedItem.Text
        Dim Range_Of_Short_Code As String = Me.DropDownListRangeShortCode.SelectedItem.Value
        Dim Short_Code As String = Me.DropDownListShortCode.SelectedItem.Value
        Dim Key_Word As String = Me.txtKeyWord.Text.Trim
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Active_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Deactive_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Cate1_Id As Integer = Me.DropDownListCate_1.SelectedItem.Value
        Dim Cate1_Text As String = Me.DropDownListCate_1.SelectedItem.Text.Trim
        Dim Cate2_Id As Integer = 0
        Dim Cate2_Text As String = ""
        Dim Cate3_Id As Integer = 0
        Dim Cate3_Text As String = ""
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  SMS_DictIndex_Keyword_List  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Short_Code=N'" & Short_Code & "' And Key_Word=N'" & Key_Word & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into SMS_DictIndex_Keyword_List(Department_Code, Department_Id,Routing_Code,Routing_Text, Partner_Code, Partner_Id, Range_Of_Short_Code, Short_Code,Key_Word,Status,Active_Time,Deactive_Time,Cate1_Id,Cate1_Text,Cate2_Id,Cate2_Text,Cate3_Id,Cate3_Text, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Department_Code & "',N'" & Department_Id & "',N'" & Routing_Code & "',N'" & Routing_Text & "',N'" & Partner_Code & "',N'" & Partner_Id & "',N'" & Range_Of_Short_Code & "',N'" & Short_Code & "',N'" & Key_Word & "',N'" & Status & "',N'" & Active_Time & "',N'" & Deactive_Time & "',N'" & Cate1_Id & "',N'" & Cate1_Text & "',N'" & Cate2_Id & "',N'" & Cate2_Text & "',N'" & Cate3_Id & "',N'" & Cate3_Text & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = " Update SMS_DictIndex_Keyword_List Set Department_Code=N'" & Department_Code & "'," & _
                    "Department_Id=N'" & Department_Id & "'," & _
                    "Routing_Code=N'" & Routing_Code & "'," & _
                    "Routing_Text=N'" & Routing_Text & "'," & _
                    "Partner_Code=N'" & Partner_Code & "'," & _
                    "Partner_Id=N'" & Partner_Id & "'," & _
                    "Range_Of_Short_Code=N'" & Range_Of_Short_Code & "'," & _
                    "Short_Code=N'" & Short_Code & "'," & _
                    "Key_Word=N'" & Key_Word & "'," & _
                    "Status=N'" & Status & "'," & _
                    "Cate1_Id=N'" & Cate1_Id & "'," & _
                    "Cate1_Text=N'" & Cate1_Text & "'," & _
                    "Cate2_Id=N'" & Cate2_Id & "'," & _
                    "Cate2_Text=N'" & Cate2_Text & "'," & _
                    "Cate3_Id=N'" & Cate3_Id & "'," & _
                    "Cate3_Text=N'" & Cate3_Text & "'," & _
                    "Update_Time=N'" & Update_Time & "'," & _
                    "Update_By_Id=N'" & Update_By_Id & "'," & _
                    "Update_By_Text=N'" & Update_By_Text & "'," & _
                    "Description=N'" & Description & "'" & _
                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From  SMS_DictIndex_Keyword_List  " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
        BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListDepartment_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListDepartment_Id.SelectedIndexChanged
        BindPartner(Me.DropDownListDepartment_Id.SelectedItem.Value)
    End Sub
#End Region

  
End Class