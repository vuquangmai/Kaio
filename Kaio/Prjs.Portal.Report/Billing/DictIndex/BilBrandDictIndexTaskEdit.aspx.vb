Imports System.Data.SqlClient

Public Class BilBrandDictIndexTaskEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDept()
            BindTaskOrder()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI BƯỚC ĐỐI SOÁT DỊCH VỤ BRAND"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM BƯỚC ĐỐI SOÁT DỊCH VỤ BRAND"
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
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListDept_Id_Biz.Items.Clear()
        Me.DropDownListDept_Id_Biz.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDept_Id_Biz.SelectedValue = 0
        Me.DropDownListDept_Id_Execute.Items.Clear()
        Me.DropDownListDept_Id_Execute.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDept_Id_Execute.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDept_Id_Biz.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Code"), dt.Rows(i).Item("ID")))
                Me.DropDownListDept_Id_Execute.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Code"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindTaskOrder()
        Dim sql As String = "SELECT * FROM System_Department Order by Dept_Code"
        Me.DropDownListTask_Order.Items.Clear()
        Me.DropDownListTask_Order.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListTask_Order.SelectedValue = 0
        For i As Integer = 1 To 100
            Me.DropDownListTask_Order.Items.Add(New ListItem(i, i))
        Next
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM Billing_Brand_DictIndex_Task Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListTask_Order.SelectedValue = dt.Rows(0).Item("Task_Order")
            Me.DropDownListDept_Id_Biz.SelectedValue = dt.Rows(0).Item("Dept_Id_Biz")
            Me.DropDownListDept_Id_Execute.SelectedValue = dt.Rows(0).Item("Dept_Id_Execute")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.txtTask_Name.Text = IIf(IsDBNull(dt.Rows(0).Item("Task_Name")) = True, "", dt.Rows(0).Item("Task_Name"))
            Me.txtDay_Implement.Text = IIf(IsDBNull(dt.Rows(0).Item("Day_Implement")) = True, "", dt.Rows(0).Item("Day_Implement"))
            Me.txtHour_Implement.Text = IIf(IsDBNull(dt.Rows(0).Item("Hour_Implement")) = True, "", dt.Rows(0).Item("Hour_Implement"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            If dt.Rows(0).Item("Task_End") = 1 Then
                Me.CheckBoxEndTask.Checked = True
            Else
                Me.CheckBoxEndTask.Checked = False
            End If
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.DropDownListDept_Id_Biz.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Bộ phận kinh doanh không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListDept_Id_Execute.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Bộ phận thực hiện không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListTask_Order.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Thứ tự thực hiện không hợp lệ !"
            Exit Sub
        End If
        If Me.txtTask_Name.Text = "" Then
            Me.lblerror.Text = "Nội dung thực hiện không hợp lệ !"
            Exit Sub
        End If
        If Me.txtHour_Implement.Text = "" Then
            Me.lblerror.Text = "Số giờ thực hiện không hợp lệ !"
            Exit Sub
        End If
      
        Dim Task_Order As Integer = Me.DropDownListTask_Order.SelectedItem.Value
        Dim Task_Name As String = Me.txtTask_Name.Text.Trim
        Dim Task_End As Integer = IIf(Me.CheckBoxEndTask.Checked = True, 1, 0)
        Dim Hour_Implement As Decimal = Me.txtHour_Implement.Text.Trim
        Dim Day_Implement As Decimal = Me.txtDay_Implement.Text.Trim
        Dim Dept_Id_Biz As Integer = Me.DropDownListDept_Id_Biz.SelectedItem.Value
        Dim Dept_Text_Biz As String = Me.DropDownListDept_Id_Biz.SelectedItem.Text
        Dim Dept_Id_Execute As Integer = Me.DropDownListDept_Id_Execute.SelectedItem.Value
        Dim Dept_Text_Execute As String = Me.DropDownListDept_Id_Execute.SelectedItem.Text
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  Billing_Brand_DictIndex_Task  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Task_Name=N'" & Task_Name & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into Billing_Brand_DictIndex_Task(Task_Order, Task_Name,Task_End,Hour_Implement, Day_Implement,Dept_Id_Biz,Dept_Text_Biz,Dept_Id_Execute,Dept_Text_Execute,Status, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Task_Order & "',N'" & Task_Name & "',N'" & Task_End & "',N'" & Hour_Implement & "',N'" & Day_Implement & "',N'" & Dept_Id_Biz & "',N'" & Dept_Text_Biz & "',N'" & Dept_Id_Execute & "',N'" & Dept_Text_Execute & "',N'" & Status & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Billing_Brand_DictIndex_Task Set Task_Order=N'" & Task_Order & "'," & _
     "Task_Name=N'" & Task_Name & "'," & _
     "Task_End=N'" & Task_End & "'," & _
     "Hour_Implement=N'" & Hour_Implement & "'," & _
     "Day_Implement=N'" & Day_Implement & "'," & _
     "Dept_Id_Biz=N'" & Dept_Id_Biz & "'," & _
     "Dept_Text_Biz=N'" & Dept_Text_Biz & "'," & _
     "Dept_Id_Execute=N'" & Dept_Id_Execute & "'," & _
     "Dept_Text_Execute=N'" & Dept_Text_Execute & "'," & _
     "Status=N'" & Status & "'," & _
     "Update_Time=N'" & Update_Time & "'," & _
     "Update_By_Id=N'" & Update_By_Id & "'," & _
     "Update_By_Text=N'" & Update_By_Text & "'," & _
     "Description=N'" & Description & "'" & _
     " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Billing.BilBrandDictIndexTaskList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Billing.BilBrandDictIndexTaskList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From Billing_Brand_DictIndex_Task Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Billing.BilBrandDictIndexTaskList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub txtHour_Implement_TextChanged(sender As Object, e As EventArgs) Handles txtHour_Implement.TextChanged
        Dim Day_Implement As Decimal = Me.txtHour_Implement.Text / 8
        Me.txtDay_Implement.Text = Day_Implement

    End Sub
#End Region
End Class