Imports System.Data.SqlClient

Public Class BilScratchCardRatioLossEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.DropDownListYear.SelectedValue = Now.Year
            Me.DropDownListMonth.SelectedValue = Util.StringBuilder.ConvertDigit(Now.Month)
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI TỶ LỆ THẤT THOÁT DỊCH VỤ THẺ CÀO"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM TỶ LỆ THẤT THOÁT DỊCH VỤ THẺ CÀO"
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
 
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM Billing_ScratchCard_Ratio_Loss Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListMobile_Operator.SelectedValue = dt.Rows(0).Item("Mobile_Operator")
            Me.DropDownListYear.SelectedValue = dt.Rows(0).Item("Month").ToString.Substring(0, 4)
            Me.DropDownListMonth.SelectedValue = dt.Rows(0).Item("Month").ToString.Substring(4, 2)
            Me.DropDownListCycle_Number.SelectedValue = dt.Rows(0).Item("Cycle_Number")
            Me.txtRatio_Percent_Loss.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Percent_Loss")) = True, 100, dt.Rows(0).Item("Ratio_Percent_Loss"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.DropDownListMobile_Operator.SelectedItem.Value = "--Chọn--" Then
            Me.lblerror.Text = "Mạng không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_Percent_Loss.Text.Trim = "" Then
            Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
            Exit Sub
        Else
            If Not IsNumeric(Me.txtRatio_Percent_Loss.Text.Trim) Then
                Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
                Exit Sub
            ElseIf Me.txtRatio_Percent_Loss.Text.Trim > 100 Or Me.txtRatio_Percent_Loss.Text.Trim < 0 Then
                Me.lblerror.Text = "Tỷ lệ không hợp lệ !"
                Exit Sub
            End If
        End If
        Dim Month As String = Me.DropDownListYear.SelectedItem.Value & Me.DropDownListMonth.SelectedItem.Value
        Dim Mobile_Operator As String = Me.DropDownListMobile_Operator.SelectedItem.Value
        Dim Cycle_Number As Integer = Me.DropDownListCycle_Number.SelectedItem.Value
        Dim Ratio_Percent_Loss As Decimal = Me.txtRatio_Percent_Loss.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From Billing_ScratchCard_Ratio_Loss  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Month=N'" & Month & "' And Mobile_Operator='" & Mobile_Operator & "' And Cycle_Number=" & Cycle_Number
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into Billing_ScratchCard_Ratio_Loss(Month, Mobile_Operator,Cycle_Number,Ratio_Percent_Loss, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Month & "',N'" & Mobile_Operator & "',N'" & Cycle_Number & "',N'" & Ratio_Percent_Loss & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Billing_ScratchCard_Ratio_Loss Set Month=N'" & Month & "'," & _
                 "Mobile_Operator=N'" & Mobile_Operator & "'," & _
                 "Cycle_Number=N'" & Cycle_Number & "'," & _
                 "Ratio_Percent_Loss=N'" & Ratio_Percent_Loss & "'," & _
                 "Update_Time=N'" & Update_Time & "'," & _
                 "Update_By_Id=N'" & Update_By_Id & "'," & _
                 "Update_By_Text=N'" & Update_By_Text & "'," & _
                 "Description=N'" & Description & "'" & _
                 " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Billing.BilScratchCardRatioLossList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Billing.BilScratchCardRatioLossList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From Billing_ScratchCard_Ratio_Loss Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Billing.BilScratchCardRatioLossList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
 


End Class