   Imports System.Data.SqlClient

    Public Class BilBrandInitDataEdit
        Inherits GlobalPage
#Region "Page Load"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN ĐỐI SOÁT ĐỐI TÁC - DỊCH VỤ SMS BRAND"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM Billing_Brand_Work_Follow Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblContract_Code.Text = dt.Rows(0).Item("Contract_Code")
            Me.lblContract_Number.Text = dt.Rows(0).Item("Contract_Number")
            Me.lblPartner_Text.Text = dt.Rows(0).Item("Partner_Text")
            Me.lblPartner_Code.Text = dt.Rows(0).Item("Partner_Code")
            Me.lblMonth.Text = dt.Rows(0).Item("Month") & "/" & dt.Rows(0).Item("Year")
            Me.DropDownListHave_Revenue.SelectedValue = dt.Rows(0).Item("Have_Revenue")
            Me.txtTotal_Revenue.Text = dt.Rows(0).Item("Total_Revenue")
            Me.txtTotal_Payment.Text = dt.Rows(0).Item("Total_Payment")
            Me.txtTotal_Debts.Text = dt.Rows(0).Item("Total_Debts")
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim Have_Revenue As String = Me.DropDownListHave_Revenue.SelectedItem.Value
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        If ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
            sql = "Select * From Billing_Brand_DictIndex_Task Where Task_End=1"
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Dim Task_Id_Current As Integer = 0
            Dim Task_Order_Current As Integer = 0
            Dim Task_Text_Curent As String = ""
            Dim Task_Order_Next As Integer = 0
            Dim Task_Id_Next As Integer = 0
            Dim Task_Text_Next As String = ""
            Dim Status_Text As String = "Hoàn thành"
            Dim Status_Debts_Id As Integer = 2
            Dim Status_Debts_Text As String = "Đã thanh toán"
            If dt.Rows.Count > 0 Then
                Task_Id_Current = dt.Rows(0).Item("Id")
                Task_Order_Current = dt.Rows(0).Item("Task_Order")
                Task_Text_Curent = dt.Rows(0).Item("Task_Name")
            End If
            Dim Total_Revenue As Decimal = Me.txtTotal_Revenue.Text.Trim
            Dim Total_Payment As Decimal = Me.txtTotal_Payment.Text.Trim
            Dim Total_Debts As Decimal = Me.txtTotal_Debts.Text.Trim
            sql = "Update Billing_Brand_Work_Follow Set Have_Revenue=N'" & Have_Revenue & "'," & _
                     "Total_Revenue=" & Total_Revenue & "," & _
                     "Total_Payment=" & Total_Payment & "," & _
                     "Total_Debts=" & Total_Debts & "," & _
                     "Task_Id_Current=N'" & Task_Id_Current & "'," & _
                     "Task_Order_Current=N'" & Task_Order_Current & "'," & _
                     "Task_Text_Curent=N'" & Task_Text_Curent & "'," & _
                     "Task_Order_Next=N'" & Task_Order_Next & "'," & _
                     "Task_Id_Next=N'" & Task_Id_Next & "'," & _
                     "Task_Text_Next=N'" & Task_Text_Next & "'," & _
                     "Status_Text=N'" & Status_Text & "'," & _
                     "Status_Debts_Id=N'" & Status_Debts_Id & "'," & _
                     "Status_Debts_Text=N'" & Status_Debts_Text & "'," & _
                     "Update_Time=N'" & Update_Time & "'," & _
                     "Update_By_Id=N'" & Update_By_Id & "'," & _
                     "Update_By_Text=N'" & Update_By_Text & "'," & _
                     "Description=N'" & Description & "'" & _
                     " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        End If
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Billing.BilBrandInitDataList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
        End Try
       
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Billing.BilBrandInitDataList)
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "DELETE   FROM Billing_Brand_Work_Follow Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            sql = "DELETE   FROM Billing_Brand_Work_Follow_Detail Where Work_Follow_Id=" & ViewState(ViewStateInfo.Object_Id)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi xóa dữ liệu chi tiết !"
            End Try
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu !"
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub txtTotal_Revenue_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_Revenue.TextChanged
        Me.txtTotal_Debts.Text = Me.txtTotal_Revenue.Text - Me.txtTotal_Payment.Text
    End Sub
    Protected Sub txtTotal_Payment_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_Payment.TextChanged
        Me.txtTotal_Debts.Text = Me.txtTotal_Revenue.Text - Me.txtTotal_Payment.Text

    End Sub
#End Region

    
End Class