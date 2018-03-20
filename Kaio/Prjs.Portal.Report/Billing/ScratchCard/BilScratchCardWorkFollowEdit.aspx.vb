Imports System.Data.SqlClient
Public Class BilScratchCardWorkFollowEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "CẬP NHẬT THÔNG TIN TIẾN ĐỘ ĐỐI SOÁT VỚI ĐỐI TÁC - DỊCH VỤ THẺ CÀO"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    Me.PanelNextAuto.Visible = False
                    Me.PanelNextManual.Visible = False
                    Me.PanelOption.Visible = False

                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                End If
            End If
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindTask(ByVal Task_Id_Current As Integer)
        Dim sql As String = "SELECT * FROM Billing_ScratchCard_DictIndex_Task Where Id<> " & Task_Id_Current & " Order by Task_Order"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListTask.Items.Clear()
        Me.DropDownListTask.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListTask.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListTask.Items.Add(New ListItem(dt.Rows(i).Item("Task_Name"), dt.Rows(i).Item("Task_Order")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM Billing_ScratchCard_Work_Follow Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblContract_Code.Text = dt.Rows(0).Item("Contract_Code")
            Me.lblPartner_Text.Text = dt.Rows(0).Item("Partner_Text")
            Me.DropDownListStatus_Id_Current.SelectedValue = dt.Rows(0).Item("Status_Id")
            Me.lblAccount_Report.Text = IIf(IsDBNull(dt.Rows(0).Item("Account_Report")) = True, "", dt.Rows(0).Item("Account_Report"))
            Me.lblTask_Order_Current.Text = IIf(IsDBNull(dt.Rows(0).Item("Task_Order_Current")) = True, "", dt.Rows(0).Item("Task_Order_Current"))
            Me.lblDept_Text_Execute_Current.Text = IIf(IsDBNull(dt.Rows(0).Item("Dept_Text_Execute_Current")) = True, "", dt.Rows(0).Item("Dept_Text_Execute_Current"))
            Me.lblContract_Code.Text = IIf(IsDBNull(dt.Rows(0).Item("Contract_Code")) = True, "", dt.Rows(0).Item("Contract_Code"))
            Me.lblMonth.Text = dt.Rows(0).Item("Month") & "/" & dt.Rows(0).Item("Year")
            Me.lblDept_Text_Biz.Text = IIf(IsDBNull(dt.Rows(0).Item("Dept_Text_Biz")) = True, "", dt.Rows(0).Item("Dept_Text_Biz"))
            Me.lblTask_Text_Curent.Text = IIf(IsDBNull(dt.Rows(0).Item("Task_Text_Curent")) = True, "", dt.Rows(0).Item("Task_Text_Curent"))
            Me.lblHour_Implement_Current.Text = dt.Rows(0).Item("Hour_Implement_Current")
            Me.txtTotal_Revenue.Text = dt.Rows(0).Item("Total_Revenue")
            Me.txtTotal_Payment_1.Text = dt.Rows(0).Item("Total_Payment_1")
            Me.txtTotal_Payment_2.Text = dt.Rows(0).Item("Total_Payment_2")
            Me.txtRatio_Payment_1.Text = dt.Rows(0).Item("Ratio_Payment_1")
            Me.txtRatio_Payment_2.Text = dt.Rows(0).Item("Ratio_Payment_2")
            Me.txtTotal_Debts.Text = dt.Rows(0).Item("Total_Debts")
            Me.txtComment_Current.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            If dt.Rows(0).Item("Status_Id") = 1 Then
                Me.btnUpdate.Visible = False
            Else
                Me.btnUpdate.Visible = True
            End If
            BindTask(dt.Rows(0).Item("Task_Id_Current"))
            ViewState("Status_Id_Current") = dt.Rows(0).Item("Status_Id")
        End If
    End Sub
#End Region
#Region "Bind Next Task Auto"
    Private Sub BindNextTaskAuto()
        Dim sql As String = "SELECT * FROM Billing_ScratchCard_DictIndex_Task Where Task_Order=" & CInt(Me.lblTask_Order_Current.Text.Trim) + 1
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblTask_Order_Next_Auto.Text = IIf(IsDBNull(dt.Rows(0).Item("Task_Order")) = True, "", dt.Rows(0).Item("Task_Order"))
            If dt.Rows(0).Item("Multi_Dept_Execute") = 0 Then
                Me.lblDept_Text_Execute_Next_Auto.Text = IIf(IsDBNull(dt.Rows(0).Item("Dept_Text_Execute")) = True, "", dt.Rows(0).Item("Dept_Text_Execute"))
            ElseIf dt.Rows(0).Item("Multi_Dept_Execute") = 1 Then
                Me.lblDept_Text_Execute_Next_Auto.Text = Me.lblDept_Text_Biz.Text.Trim
            End If
            Me.lblHour_Implement_Next_Auto.Text = IIf(IsDBNull(dt.Rows(0).Item("Hour_Implement")) = True, "", dt.Rows(0).Item("Hour_Implement"))
            Me.lblTask_Text_Next_Auto.Text = dt.Rows(0).Item("Task_Name")
            If dt.Rows(0).Item("Task_End") = 1 Then
                Me.CheckBoxEndTaskAuto.Checked = True
            Else
                Me.CheckBoxEndTaskAuto.Checked = False
            End If
            Me.PanelNextAuto.Visible = True
            Me.PanelNextManual.Visible = False
        Else
            Me.lblTask_Order_Next_Auto.Text = ""
            Me.lblDept_Text_Execute_Next_Auto.Text = ""
            Me.lblHour_Implement_Next_Auto.Text = ""
            Me.lblTask_Text_Next_Auto.Text = ""
            Me.PanelNextAuto.Visible = False
            Me.PanelNextManual.Visible = False
        End If
    End Sub
#End Region
#Region "Bind Next Task Manual"
    Private Sub BindNextTaskManual()
        Me.PanelNextAuto.Visible = False
        Me.PanelNextManual.Visible = True
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        Dim retval As String = ""
        Dim Status_Id_Current As Integer = Me.DropDownListStatus_Id_Current.SelectedItem.Value
        If Status_Id_Current = 1 Then ' Hoàn thành bước hiện tại và chuyển bước tiếp theo
            '1. Insert bảng chi tiêt
            Dim sql As String = "SELECT * FROM Billing_ScratchCard_Work_Follow Where Id=" & ViewState(ViewStateInfo.Object_Id)
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                Dim Work_Follow_Id As Integer = ViewState(ViewStateInfo.Object_Id)
                Dim Year As Integer = dt.Rows(0).Item("Year")
                Dim Month As Integer = dt.Rows(0).Item("Month")
                Dim TypeOfPartner As Integer = dt.Rows(0).Item("TypeOfPartner")
                Dim Dept_Id_Of As Integer = dt.Rows(0).Item("Dept_Id_Of")
                Dim Dept_Text_Of As String = dt.Rows(0).Item("Dept_Text_Of")
                Dim Contract_Id As Integer = dt.Rows(0).Item("Contract_Id")
                Dim Contract_Code As String = dt.Rows(0).Item("Contract_Code")
                Dim Contract_Number As String = dt.Rows(0).Item("Contract_Number")
                Dim Partner_Id As Integer = dt.Rows(0).Item("Partner_Id")
                Dim Partner_Text As String = dt.Rows(0).Item("Partner_Text")
                Dim Partner_Code As String = dt.Rows(0).Item("Partner_Code")
                Dim Account_Report As String = dt.Rows(0).Item("Account_Report")
                Dim Dept_Id_Biz As String = dt.Rows(0).Item("Dept_Id_Biz")
                Dim Dept_Text_Biz As String = dt.Rows(0).Item("Dept_Text_Biz")
                Dim Multi_Dept_Biz As Integer = dt.Rows(0).Item("Multi_Dept_Biz")

                Dim Task_Order_Current As Integer = dt.Rows(0).Item("Task_Order_Current")
                Dim Task_Id_Current As Integer = dt.Rows(0).Item("Task_Id_Current")
                Dim Task_Text_Curent As String = dt.Rows(0).Item("Task_Text_Curent")
                Dim Task_Order_Next As Integer = dt.Rows(0).Item("Task_Order_Next")
                Dim Task_Id_Next As Integer = dt.Rows(0).Item("Task_Id_Next")
                Dim Task_Text_Next As String = dt.Rows(0).Item("Task_Text_Next")
                Dim Dept_Id_Execute_Current As String = dt.Rows(0).Item("Dept_Id_Execute_Current")
                Dim Dept_Text_Execute_Current As String = dt.Rows(0).Item("Dept_Text_Execute_Current")
                Dim Multi_Dept_Execute As Integer = dt.Rows(0).Item("Multi_Dept_Execute")
                Dim Dept_Id_Execute_Next As String = dt.Rows(0).Item("Dept_Id_Execute_Next")
                Dim Dept_Text_Execute_Next As String = dt.Rows(0).Item("Dept_Text_Execute_Next")
                Dim Execute_Time As String = DateTime.Parse(dt.Rows(0).Item("Execute_Time")).ToString("yyyy-MM-dd HH:mm:ss")
                Dim Status_Id As Integer = 1 ' dt.Rows(0).Item("Status_Id")
                Dim Status_Text As String = "Hoàn thành" ' dt.Rows(0).Item("Status_Text")
                Dim Total_Task As Integer = dt.Rows(0).Item("Total_Task")
                Dim Hour_Implement_Current As Decimal = dt.Rows(0).Item("Hour_Implement_Current")
                Dim Day_Implement_Current As Decimal = dt.Rows(0).Item("Day_Implement_Current")
                Dim Hour_Implement_Next As Decimal = dt.Rows(0).Item("Hour_Implement_Next")
                Dim Day_Implement_Next As Decimal = dt.Rows(0).Item("Day_Implement_Next")
                Dim Total_Hour_Implement As Decimal = dt.Rows(0).Item("Total_Hour_Implement")
                Dim Total_Day_Implement As Decimal = dt.Rows(0).Item("Total_Day_Implement")
                Dim Total_Revenue As Decimal = dt.Rows(0).Item("Total_Revenue")
                Dim Total_Payment_1 As Decimal = dt.Rows(0).Item("Total_Payment_1")
                Dim Ratio_Payment_1 As Decimal = dt.Rows(0).Item("Ratio_Payment_1")
                Dim Total_Payment_2 As Decimal = dt.Rows(0).Item("Total_Payment_2")
                Dim Ratio_Payment_2 As Decimal = dt.Rows(0).Item("Ratio_Payment_2")
                Dim Total_Debts As Decimal = dt.Rows(0).Item("Total_Debts")
                Dim Status_Debts_Id As Integer = dt.Rows(0).Item("Status_Debts_Id")
                Dim Status_Debts_Text As String = dt.Rows(0).Item("Status_Debts_Text")
                Dim Create_Time As String = DateTime.Parse(dt.Rows(0).Item("Create_Time")).ToString("yyyy-MM-dd HH:mm:ss")
                Dim Create_By_Id As String = dt.Rows(0).Item("Create_By_Id")
                Dim Create_By_Text As String = dt.Rows(0).Item("Create_By_Text")
                Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
                Dim Update_By_Id As String = CurrentUser.UserId
                Dim Update_By_Text As String = CurrentUser.UserName
                Dim Task_Log As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                  CurrentUser.UserName & "(" & CurrentUser.UserFullName & "): Cập nhật thông tin [ " & Me.txtComment_Current.Text.Trim & " ] <br>"
                Dim Description As String = Me.txtComment_Current.Text.Trim
                InsertData(Work_Follow_Id, _
                          Year, _
                         Month, _
                         TypeOfPartner, _
                         Dept_Id_Of, _
                         Dept_Text_Of, _
                         Contract_Id, _
                         Contract_Code, _
                         Contract_Number, _
                         Partner_Id, _
                         Partner_Text, _
                         Partner_Code, _
                         Account_Report, _
                         Dept_Id_Biz, _
                         Dept_Text_Biz, _
                         Multi_Dept_Biz, _
                         Task_Order_Current, _
                         Task_Id_Current, _
                         Task_Text_Curent, _
                         Task_Order_Next, _
                         Task_Id_Next, _
                         Task_Text_Next, _
                         Dept_Id_Execute_Current, _
                         Dept_Text_Execute_Current, _
                         Multi_Dept_Execute, _
                         Dept_Id_Execute_Next, _
                         Dept_Text_Execute_Next, _
                         Execute_Time, _
                         Status_Id, _
                         Status_Text, _
                         Total_Task, _
                         Hour_Implement_Current, _
                         Day_Implement_Current, _
                         Hour_Implement_Next, _
                         Day_Implement_Next, _
                         Total_Hour_Implement, _
                         Total_Day_Implement, _
                         Total_Revenue, _
                         Total_Payment_1, _
                         Ratio_Payment_1, _
                        Total_Payment_2, _
                        Ratio_Payment_2, _
                         Total_Debts, _
                         Status_Debts_Id, _
                         Status_Debts_Text, _
                         Create_By_Id, _
                         Create_By_Text, _
                         Create_Time, _
                         Update_By_Id, _
                         Update_By_Text, _
                         Update_Time, _
                         Task_Log, _
                         Description)
            End If
            '2.Update thông tin
            UpdatNext()
        ElseIf Status_Id_Current = 0 Then ' Bổ sung thông tin hiện tại
            retval = UpdateCurrent()
        End If

        If retval = "" Then
            RedirectUrl(Constants.Url._Billing.BilScratchCardWorkFollowList)
        Else
            Me.lblerror.Text = retval
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Billing.BilScratchCardWorkFollowList)
    End Sub
#End Region
#Region "Update Data"
    Private Function UpdatNext() As String
        Dim retval As String = ""
        Dim sql As String = ""
        Dim Task_Order_Current As Integer = 0
        Dim Task_Id_Current As Integer = 0
        Dim Task_Text_Curent As String = ""
        Dim Task_Order_Next As Integer = 0
        Dim Task_Id_Next As Integer = 0
        Dim Task_Text_Next As String = ""
        Dim Dept_Id_Execute_Current As Integer = 0
        Dim Dept_Text_Execute_Current As String = ""
        Dim Dept_Id_Execute_Next As Integer = 0
        Dim Dept_Text_Execute_Next As String = ""
        Dim Hour_Implement_Current As Decimal = 0
        Dim Day_Implement_Current As Decimal = 0
        Dim Hour_Implement_Next As Decimal = 0
        Dim Day_Implement_Next As Decimal = 0
        Dim Total_Revenue As Decimal = Me.txtTotal_Revenue.Text.Trim
        Dim Total_Payment_1 As Decimal = Me.txtTotal_Payment_1.Text.Trim
        Dim Ratio_Payment_1 As Decimal = Me.txtRatio_Payment_1.Text.Trim
        Dim Total_Payment_2 As Decimal = Me.txtTotal_Payment_2.Text.Trim
        Dim Ratio_Payment_2 As Decimal = Me.txtRatio_Payment_2.Text.Trim
        Dim Total_Debts As Decimal = Me.txtTotal_Debts.Text.Trim
        Dim Status_Id As Integer = 0
        Dim Status_Text As String = ""
        Dim Status_Debts_Id As Integer = StatusDebtsId(Total_Payment_1 + Total_Payment_2, Total_Debts)
        Dim Status_Debts_Text As String = StatusDebtsText(Total_Payment_1 + Total_Payment_2, Total_Debts)
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtComment_Current.Text.Trim
        Dim Task_Log As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                  CurrentUser.UserName & "(" & CurrentUser.UserFullName & "): Cập nhật thông tin [ " & Me.txtComment_Current.Text.Trim & " ] <br>"
        If Me.DropDownListNextTask.SelectedItem.Value = 1 Then
            sql = "Select * From Billing_ScratchCard_DictIndex_Task Where Task_Order=" & CInt(Me.lblTask_Order_Next_Auto.Text.Trim)
        Else
            sql = "Select * From Billing_ScratchCard_DictIndex_Task Where Task_Order=" & CInt(Me.lblTask_Order_Next_Manual.Text.Trim)
        End If
        Dim dtTaskCurrent As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dtTaskCurrent.Rows.Count > 0 Then
            Task_Order_Current = dtTaskCurrent.Rows(0).Item("Task_Order")
            Task_Id_Current = dtTaskCurrent.Rows(0).Item("Id")
            Task_Text_Curent = dtTaskCurrent.Rows(0).Item("Task_Name")
            If dtTaskCurrent.Rows(0).Item("Multi_Dept_Execute") = 0 Then
                Dept_Id_Execute_Current = dtTaskCurrent.Rows(0).Item("Dept_Id_Execute")
                Dept_Text_Execute_Current = dtTaskCurrent.Rows(0).Item("Dept_Text_Execute")
            ElseIf dtTaskCurrent.Rows(0).Item("Multi_Dept_Execute") = 1 Then
                sql = "SELECT A.Department_Id,B.Dept_Code FROM  Ccare_Management_Contract A" & _
                        " INNER JOIN   System_Department B ON A.Department_Id =B.Id " & _
                        " WHERE Contract_Code = N'" & Me.lblContract_Code.Text.Trim & "'"
                Dim dtDeptExe As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                If dtDeptExe.Rows.Count > 0 Then
                    Dept_Id_Execute_Current = dtDeptExe.Rows(0).Item("Department_Id")
                    Dept_Text_Execute_Current = dtDeptExe.Rows(0).Item("Dept_Code")
                Else
                    retval = "Lỗi !!!!!!"
                    Return retval
                End If
            End If

            Hour_Implement_Current = dtTaskCurrent.Rows(0).Item("Hour_Implement")
            Day_Implement_Current = dtTaskCurrent.Rows(0).Item("Day_Implement")

            If Me.DropDownListNextTask.SelectedItem.Value = 1 Then
                If Me.CheckBoxEndTaskAuto.Checked = True Then
                    Status_Id = 1
                    Status_Text = "Hoàn thành"
                Else
                    Status_Id = 0
                    Status_Text = "Chưa hoàn thành"
                End If
            Else
                If Me.CheckBoxEndTaskManual.Checked = True Then
                    Status_Id = 1
                    Status_Text = "Hoàn thành"
                Else
                    Status_Id = 0
                    Status_Text = "Chưa hoàn thành"
                End If
            End If

            If Me.DropDownListNextTask.SelectedItem.Value = 1 Then
                sql = "Select * From Billing_ScratchCard_DictIndex_Task Where Task_Order=" & CInt(Me.lblTask_Order_Next_Auto.Text.Trim) + 1
            Else
                sql = "Select * From Billing_ScratchCard_DictIndex_Task Where Task_Order=" & CInt(Me.lblTask_Order_Next_Manual.Text.Trim) + 1
            End If
            Dim dtTaskNext As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dtTaskNext.Rows.Count > 0 Then
                Task_Order_Next = dtTaskNext.Rows(0).Item("Task_Order")
                Task_Id_Next = dtTaskNext.Rows(0).Item("Id")
                Task_Text_Next = dtTaskNext.Rows(0).Item("Task_Name")
                Hour_Implement_Next = dtTaskNext.Rows(0).Item("Hour_Implement")
                Day_Implement_Next = dtTaskNext.Rows(0).Item("Day_Implement")
            End If
            sql = "Update Billing_ScratchCard_Work_Follow SET " & _
             "Total_Revenue=" & Total_Revenue & "," & _
             "Total_Payment_1=" & Total_Payment_1 & "," & _
             "Ratio_Payment_1=" & Ratio_Payment_1 & "," & _
             "Total_Payment_2=" & Total_Payment_2 & "," & _
             "Ratio_Payment_2=" & Ratio_Payment_2 & "," & _
             "Total_Debts=" & Total_Debts & "," & _
             "Status_Debts_Id=" & Status_Debts_Id & "," & _
             "Status_Debts_Text=N'" & Status_Debts_Text & "'," & _
             "Task_Order_Current=N'" & Task_Order_Current & "'," & _
             "Task_Id_Current=N'" & Task_Id_Current & "'," & _
             "Task_Text_Curent=N'" & Task_Text_Curent & "'," & _
             "Dept_Id_Execute_Current=N'" & Dept_Id_Execute_Current & "'," & _
             "Dept_Text_Execute_Current=N'" & Dept_Text_Execute_Current & "'," & _
             "Hour_Implement_Current=N'" & Hour_Implement_Current & "'," & _
             "Day_Implement_Current=N'" & Day_Implement_Current & "'," & _
             "Task_Order_Next=N'" & Task_Order_Next & "'," & _
             "Task_Id_Next=N'" & Task_Id_Next & "'," & _
             "Task_Text_Next=N'" & Task_Text_Next & "'," & _
             "Hour_Implement_Next=N'" & Hour_Implement_Next & "'," & _
             "Day_Implement_Next=N'" & Day_Implement_Next & "'," & _
             "Status_Id=N'" & Status_Id & "'," & _
             "Status_Text=N'" & Status_Text & "'," & _
             "Update_Time=N'" & Update_Time & "'," & _
             "Update_By_Id=N'" & Update_By_Id & "'," & _
             "Update_By_Text=N'" & Update_By_Text & "'," & _
             "Description=N'" & Description & "'," & _
             "Task_Log=Task_Log+ N'" & Task_Log & "'" & _
             " WHERE Id=" & ViewState(ViewStateInfo.Object_Id)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            Catch ex As Exception
                retval = "Lỗi Update dữ liệu. Mã lỗi: " & ex.Message
                Return retval
            End Try
        End If
        Return retval

    End Function
    Private Function UpdateCurrent() As String
        Dim retval As String = ""
        Dim sql As String = ""
        Dim Total_Revenue As Decimal = Me.txtTotal_Revenue.Text.Trim
        Dim Total_Payment_1 As Decimal = Me.txtTotal_Payment_1.Text.Trim
        Dim Ratio_Payment_1 As Decimal = Me.txtRatio_Payment_1.Text.Trim
        Dim Total_Payment_2 As Decimal = Me.txtTotal_Payment_2.Text.Trim
        Dim Ratio_Payment_2 As Decimal = Me.txtRatio_Payment_2.Text.Trim
        Dim Total_Debts As Decimal = Me.txtTotal_Debts.Text.Trim
        Dim Status_Debts_Id As Integer = StatusDebtsId(Total_Payment_1 + Total_Payment_2, Total_Debts)
        Dim Status_Debts_Text As String = StatusDebtsText(Total_Payment_1 + Total_Payment_2, Total_Debts)
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtComment_Current.Text.Trim
        Dim Task_Log As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                  CurrentUser.UserName & "(" & CurrentUser.UserFullName & "): Cập nhật thông tin [ " & Me.txtComment_Current.Text.Trim & " ] <br>"
        sql = "Update Billing_ScratchCard_Work_Follow SET " & _
              "Total_Revenue=" & Total_Revenue & "," & _
              "Total_Payment_1=" & Total_Payment_1 & "," & _
              "Ratio_Payment_1=" & Ratio_Payment_1 & "," & _
              "Total_Payment_2=" & Total_Payment_2 & "," & _
              "Ratio_Payment_2=" & Ratio_Payment_2 & "," & _
              "Total_Debts=" & Total_Debts & "," & _
              "Status_Debts_Id=" & Status_Debts_Id & "," & _
              "Status_Debts_Text=N'" & Status_Debts_Text & "'," & _
              "Update_Time=N'" & Update_Time & "'," & _
              "Update_By_Id=N'" & Update_By_Id & "'," & _
              "Update_By_Text=N'" & Update_By_Text & "'," & _
              "Description=N'" & Description & "'," & _
              "Task_Log=Task_Log+ N'" & Task_Log & "'" & _
              " WHERE Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Catch ex As Exception
            retval = "Lỗi Update dữ liệu. Mã lỗi: " & ex.Message
        End Try
        Return retval
    End Function
#End Region
#Region "Insert Data"
    Private Function InsertData(ByVal Work_Follow_Id As Integer, _
                    ByVal Year As Integer, _
                    ByVal Month As Integer, _
                    ByVal TypeOfPartner As Integer, _
                    ByVal Dept_Id_Of As Integer, _
                    ByVal Dept_Text_Of As String, _
                    ByVal Contract_Id As Integer, _
                    ByVal Contract_Code As String, _
                    ByVal Contract_Number As String, _
                    ByVal Partner_Id As Integer, _
                    ByVal Partner_Text As String, _
                    ByVal Partner_Code As String, _
                    ByVal Account_Report As String, _
                    ByVal Dept_Id_Biz As String, _
                    ByVal Dept_Text_Biz As String, _
                    ByVal Multi_Dept_Biz As Integer, _
                    ByVal Task_Order_Current As Integer, _
                    ByVal Task_Id_Current As Integer, _
                    ByVal Task_Text_Curent As String, _
                    ByVal Task_Order_Next As Integer, _
                    ByVal Task_Id_Next As Integer, _
                    ByVal Task_Text_Next As String, _
                    ByVal Dept_Id_Execute_Current As String, _
                    ByVal Dept_Text_Execute_Current As String, _
                    ByVal Multi_Dept_Execute As Integer, _
                    ByVal Dept_Id_Execute_Next As String, _
                    ByVal Dept_Text_Execute_Next As String, _
                    ByVal Execute_Time As String, _
                    ByVal Status_Id As Integer, _
                    ByVal Status_Text As String, _
                    ByVal Total_Task As Integer, _
                    ByVal Hour_Implement_Current As Decimal, _
                    ByVal Day_Implement_Current As Decimal, _
                    ByVal Hour_Implement_Next As Decimal, _
                    ByVal Day_Implement_Next As Decimal, _
                    ByVal Total_Hour_Implement As Decimal, _
                    ByVal Total_Day_Implement As Decimal, _
                    ByVal Total_Revenue As Decimal, _
                    ByVal Total_Payment_1 As Decimal, _
                    ByVal Ratio_Payment_1 As Integer, _
                    ByVal Total_Payment_2 As Decimal, _
                    ByVal Ratio_Payment_2 As Integer, _
                    ByVal Total_Debts As Decimal, _
                    ByVal Status_Debts_Id As Integer, _
                    ByVal Status_Debts_Text As String, _
                    ByVal Create_By_Id As Integer, _
                    ByVal Create_By_Text As String, _
                    ByVal Create_Time As String, _
                    ByVal Update_By_Id As Integer, _
                    ByVal Update_By_Text As String, _
                    ByVal Update_Time As String, _
                    ByVal Task_Log As String, _
                    ByVal Description As String) As String

        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "Billing_ScratchCard_Work_Follow_Detail_Insert"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Work_Follow_Id", SqlDbType.Int))
            .Parameters("@Work_Follow_Id").Value = Work_Follow_Id

            .Parameters.Add(New SqlParameter("@Year", SqlDbType.Int))
            .Parameters("@Year").Value = Year

            .Parameters.Add(New SqlParameter("@Month", SqlDbType.Int))
            .Parameters("@Month").Value = Month

            .Parameters.Add(New SqlParameter("@TypeOfPartner", SqlDbType.Int))
            .Parameters("@TypeOfPartner").Value = TypeOfPartner

            .Parameters.Add(New SqlParameter("@Dept_Id_Of", SqlDbType.Int))
            .Parameters("@Dept_Id_Of").Value = Dept_Id_Of

            .Parameters.Add(New SqlParameter("@Dept_Text_Of", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Of").Value = Dept_Text_Of

            .Parameters.Add(New SqlParameter("@Contract_Id", SqlDbType.Int))
            .Parameters("@Contract_Id").Value = Contract_Id

            .Parameters.Add(New SqlParameter("@Contract_Code", SqlDbType.NVarChar, 500))
            .Parameters("@Contract_Code").Value = Contract_Code

            .Parameters.Add(New SqlParameter("@Contract_Number", SqlDbType.NVarChar, 500))
            .Parameters("@Contract_Number").Value = Contract_Number

            .Parameters.Add(New SqlParameter("@Partner_Id", SqlDbType.Int))
            .Parameters("@Partner_Id").Value = Partner_Id

            .Parameters.Add(New SqlParameter("@Partner_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Partner_Text").Value = Partner_Text

            .Parameters.Add(New SqlParameter("@Partner_Code", SqlDbType.NVarChar, 500))
            .Parameters("@Partner_Code").Value = Partner_Code

            .Parameters.Add(New SqlParameter("@Account_Report", SqlDbType.NVarChar, 500))
            .Parameters("@Account_Report").Value = Account_Report

            .Parameters.Add(New SqlParameter("@Dept_Id_Biz", SqlDbType.NVarChar, 50))
            .Parameters("@Dept_Id_Biz").Value = Dept_Id_Biz

            .Parameters.Add(New SqlParameter("@Dept_Text_Biz", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Biz").Value = Dept_Text_Biz

            .Parameters.Add(New SqlParameter("@Multi_Dept_Biz", SqlDbType.Int))
            .Parameters("@Multi_Dept_Biz").Value = Multi_Dept_Biz

            .Parameters.Add(New SqlParameter("@Task_Order_Current", SqlDbType.Int))
            .Parameters("@Task_Order_Current").Value = Task_Order_Current

            .Parameters.Add(New SqlParameter("@Task_Id_Current", SqlDbType.Int))
            .Parameters("@Task_Id_Current").Value = Task_Id_Current

            .Parameters.Add(New SqlParameter("@Task_Text_Curent", SqlDbType.NVarChar, 500))
            .Parameters("@Task_Text_Curent").Value = Task_Text_Curent

            .Parameters.Add(New SqlParameter("@Task_Order_Next", SqlDbType.Int))
            .Parameters("@Task_Order_Next").Value = Task_Order_Next

            .Parameters.Add(New SqlParameter("@Task_Id_Next", SqlDbType.Int))
            .Parameters("@Task_Id_Next").Value = Task_Id_Next

            .Parameters.Add(New SqlParameter("@Task_Text_Next", SqlDbType.NVarChar, 500))
            .Parameters("@Task_Text_Next").Value = Task_Text_Next

            .Parameters.Add(New SqlParameter("@Dept_Id_Execute_Current", SqlDbType.NVarChar, 50))
            .Parameters("@Dept_Id_Execute_Current").Value = Dept_Id_Execute_Current

            .Parameters.Add(New SqlParameter("@Dept_Text_Execute_Current", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Execute_Current").Value = Dept_Text_Execute_Current

            .Parameters.Add(New SqlParameter("@Multi_Dept_Execute", SqlDbType.Int))
            .Parameters("@Multi_Dept_Execute").Value = Multi_Dept_Execute

            .Parameters.Add(New SqlParameter("@Dept_Id_Execute_Next", SqlDbType.Int))
            .Parameters("@Dept_Id_Execute_Next").Value = Dept_Id_Execute_Next

            .Parameters.Add(New SqlParameter("@Dept_Text_Execute_Next", SqlDbType.NVarChar, 500))
            .Parameters("@Dept_Text_Execute_Next").Value = Dept_Text_Execute_Next

            .Parameters.Add(New SqlParameter("@Execute_Time", SqlDbType.NVarChar, 500))
            .Parameters("@Execute_Time").Value = Execute_Time

            .Parameters.Add(New SqlParameter("@Status_Id", SqlDbType.Int))
            .Parameters("@Status_Id").Value = Status_Id

            .Parameters.Add(New SqlParameter("@Status_Text", SqlDbType.NVarChar, 50))
            .Parameters("@Status_Text").Value = Status_Text

            .Parameters.Add(New SqlParameter("@Total_Task", SqlDbType.Int))
            .Parameters("@Total_Task").Value = Total_Task

            .Parameters.Add(New SqlParameter("@Hour_Implement_Current", SqlDbType.Decimal))
            .Parameters("@Hour_Implement_Current").Value = Hour_Implement_Current

            .Parameters.Add(New SqlParameter("@Day_Implement_Current", SqlDbType.Decimal))
            .Parameters("@Day_Implement_Current").Value = Day_Implement_Current

            .Parameters.Add(New SqlParameter("@Hour_Implement_Next", SqlDbType.Decimal))
            .Parameters("@Hour_Implement_Next").Value = Hour_Implement_Next

            .Parameters.Add(New SqlParameter("@Day_Implement_Next", SqlDbType.Decimal))
            .Parameters("@Day_Implement_Next").Value = Day_Implement_Next

            .Parameters.Add(New SqlParameter("@Total_Hour_Implement", SqlDbType.Decimal))
            .Parameters("@Total_Hour_Implement").Value = Total_Hour_Implement

            .Parameters.Add(New SqlParameter("@Total_Day_Implement", SqlDbType.Decimal))
            .Parameters("@Total_Day_Implement").Value = Total_Day_Implement

            .Parameters.Add(New SqlParameter("@Total_Revenue", SqlDbType.Decimal))
            .Parameters("@Total_Revenue").Value = Total_Revenue

            .Parameters.Add(New SqlParameter("@Total_Payment_1", SqlDbType.Decimal))
            .Parameters("@Total_Payment_1").Value = Total_Payment_1

            .Parameters.Add(New SqlParameter("@Ratio_Payment_1", SqlDbType.Int))
            .Parameters("@Ratio_Payment_1").Value = Ratio_Payment_1

            .Parameters.Add(New SqlParameter("@Total_Payment_2", SqlDbType.Decimal))
            .Parameters("@Total_Payment_2").Value = Total_Payment_2

            .Parameters.Add(New SqlParameter("@Ratio_Payment_2", SqlDbType.Int))
            .Parameters("@Ratio_Payment_2").Value = Ratio_Payment_2

            .Parameters.Add(New SqlParameter("@Total_Debts", SqlDbType.Decimal))
            .Parameters("@Total_Debts").Value = Total_Debts

            .Parameters.Add(New SqlParameter("@Status_Debts_Id", SqlDbType.Int))
            .Parameters("@Status_Debts_Id").Value = Status_Debts_Id

            .Parameters.Add(New SqlParameter("@Status_Debts_Text", SqlDbType.NVarChar, 100))
            .Parameters("@Status_Debts_Text").Value = Status_Debts_Text

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

            .Parameters.Add(New SqlParameter("@Task_Log", SqlDbType.NVarChar, 2000))
            .Parameters("@Task_Log").Value = Task_Log

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
            .Parameters("@Description").Value = Description
            Try
                .ExecuteNonQuery()
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi insert data. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Ajax"
    Private Sub BindNextInfo()
        If Me.DropDownListStatus_Id_Current.SelectedItem.Value = 0 Then
            Me.PanelNextAuto.Visible = False
            Me.PanelNextManual.Visible = False
            Me.PanelOption.Visible = False
        ElseIf Me.DropDownListStatus_Id_Current.SelectedItem.Value = 1 Then
            Me.PanelOption.Visible = True
            If Me.DropDownListNextTask.SelectedItem.Value = 1 Then
                BindNextTaskAuto()
                Me.lblTask.Visible = False
                Me.DropDownListTask.Visible = False
            ElseIf Me.DropDownListNextTask.SelectedItem.Value = 2 Then
                BindNextTaskManual()
                Me.lblTask.Visible = True
                Me.DropDownListTask.Visible = True
            End If
        End If
    End Sub
    Protected Sub DropDownListStatus_Id_Current_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListStatus_Id_Current.SelectedIndexChanged
        BindNextInfo()
    End Sub
    Protected Sub DropDownListNextTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListNextTask.SelectedIndexChanged
        BindNextInfo()
    End Sub
    Protected Sub txtTotal_Revenue_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_Revenue.TextChanged
        Me.txtTotal_Debts.Text = Me.txtTotal_Revenue.Text - Me.txtTotal_Payment_1.Text - Me.txtTotal_Payment_2.Text
    End Sub
    Protected Sub txtTotal_Payment_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_Payment_1.TextChanged
        Me.txtTotal_Debts.Text = Me.txtTotal_Revenue.Text - Me.txtTotal_Payment_1.Text - Me.txtTotal_Payment_2.Text
    End Sub
    Protected Sub txtTotal_Payment_2_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_Payment_2.TextChanged
        Me.txtTotal_Debts.Text = Me.txtTotal_Revenue.Text - Me.txtTotal_Payment_1.Text - Me.txtTotal_Payment_2.Text

    End Sub
    Protected Sub DropDownListTask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTask.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM Billing_SMS_DictIndex_Task Where Task_Order=" & CInt(Me.DropDownListTask.SelectedItem.Value)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.lblTask_Order_Next_Manual.Text = IIf(IsDBNull(dt.Rows(0).Item("Task_Order")) = True, "", dt.Rows(0).Item("Task_Order"))
            If dt.Rows(0).Item("Multi_Dept_Execute") = 0 Then
                Me.lblDept_Text_Execute_Next_Manual.Text = IIf(IsDBNull(dt.Rows(0).Item("Dept_Text_Execute")) = True, "", dt.Rows(0).Item("Dept_Text_Execute"))
            ElseIf dt.Rows(0).Item("Multi_Dept_Execute") = 1 Then
                Me.lblDept_Text_Execute_Next_Manual.Text = Me.lblDept_Text_Biz.Text.Trim
            End If

            Me.lblHour_Implement_Next_Manual.Text = IIf(IsDBNull(dt.Rows(0).Item("Hour_Implement")) = True, "", dt.Rows(0).Item("Hour_Implement"))
            Me.lblTask_Text_Next_Manual.Text = dt.Rows(0).Item("Task_Name")
            If dt.Rows(0).Item("Task_End") = 1 Then
                Me.CheckBoxEndTaskManual.Checked = True
            Else
                Me.CheckBoxEndTaskManual.Checked = False
            End If
            Me.PanelNextAuto.Visible = False
            Me.PanelNextManual.Visible = True
        Else
            Me.lblTask_Order_Next_Manual.Text = ""
            Me.lblDept_Text_Execute_Next_Manual.Text = ""
            Me.lblHour_Implement_Next_Manual.Text = ""
            Me.lblTask_Text_Next_Manual.Text = ""
            Me.PanelNextAuto.Visible = False
            Me.PanelNextManual.Visible = False
        End If
    End Sub
#End Region
    Private Function StatusDebtsId(Total_Payment As Decimal, Total_Debts As Decimal) As Integer
        Dim retval As Integer = 0
        If Total_Payment > 0 And Total_Debts = 0 Then ' Đã thanh toán
            retval = 2
        ElseIf Total_Payment > 0 And Total_Debts > 0 Then ' Thanh toán 1 phần
            retval = 1
        ElseIf Total_Payment = 0 And Total_Debts >= 0 Then ' Chưa thanh toán
            retval = 0
        End If
        Return retval
    End Function
    Private Function StatusDebtsText(ByVal Total_Payment As Decimal, ByVal Total_Debts As Decimal) As String
        Dim retval As String = ""
        If Total_Payment > 0 And Total_Debts = 0 Then ' Đã thanh toán
            retval = "Đã thanh toán"
        ElseIf Total_Payment > 0 And Total_Debts > 0 Then ' Thanh toán 1 phần
            retval = "Thanh toán 1 phần"
        ElseIf Total_Payment = 0 And Total_Debts >= 0 Then ' Chưa thanh toán
            retval = "Chưa thanh toán"
        End If
        Return retval
    End Function


End Class