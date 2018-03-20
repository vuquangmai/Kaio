Imports System.Data.SqlClient

Public Class S2DictIndexVNMServiceEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindPartner()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN DỊCH VỤ S2 VIETNAMOBILE"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN DỊCH VỤ S2 VIETNAMOBILE"
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
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner Order by Confidence_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListPartner_Id.Items.Clear()
        Me.DropDownListPartner_Id.Items.Add(New ListItem("Tự doanh", 0))
        Me.DropDownListPartner_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPartner_Id.Items.Add(New ListItem(dt.Rows(i).Item("Partner_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM S2_DictIndex_Service Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.txtRatio_Share.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share")) = True, 0, dt.Rows(0).Item("Ratio_Share"))
            Me.txtAccess_Number.Text = dt.Rows(0).Item("Access_Number")
            Me.txtService_Id.Text = IIf(IsDBNull(dt.Rows(0).Item("Service_Id")) = True, "", dt.Rows(0).Item("Service_Id"))
            Me.txtService_Text.Text = IIf(IsDBNull(dt.Rows(0).Item("Service_Text")) = True, "", dt.Rows(0).Item("Service_Text"))
            Me.txtPricing.Text = IIf(IsDBNull(dt.Rows(0).Item("Pricing")) = True, 0, dt.Rows(0).Item("Pricing"))
            Me.DropDownListPeriod_Id.SelectedValue = dt.Rows(0).Item("Period_Id")
            Me.txtSubscription_Command_Word.Text = IIf(IsDBNull(dt.Rows(0).Item("Subscription_Command_Word")) = True, "", dt.Rows(0).Item("Subscription_Command_Word"))
            Me.txtUnsubscription_Command_Word.Text = IIf(IsDBNull(dt.Rows(0).Item("Unsubscription_Command_Word")) = True, "", dt.Rows(0).Item("Unsubscription_Command_Word"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        'If Me.DropDownListPartner_Id.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Đối tác không hợp lệ !"
        '    Exit Sub
        'End If
        If Me.txtAccess_Number.Text = "" Then
            Me.lblerror.Text = "Đầu số không hợp lệ !"
            Exit Sub
        End If
        If Me.txtService_Id.Text = "" Then
            Me.lblerror.Text = "Mã dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtService_Text.Text = "" Then
            Me.lblerror.Text = "Tên dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtPricing.Text = "" Then
            Me.lblerror.Text = "Giá dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtSubscription_Command_Word.Text = "" Then
            Me.lblerror.Text = "Cú pháp đăng ký dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtUnsubscription_Command_Word.Text = "" Then
            Me.lblerror.Text = "Cú pháp hủy dịch vụ không hợp lệ !"
            Exit Sub
        End If
        Dim Mobile_Operator As String = "VNM"
        Dim Partner_Id As Integer = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Partner_Text As String = Me.DropDownListPartner_Id.SelectedItem.Text
        Dim Ratio_Share As Integer = IIf(Me.txtRatio_Share.Text.Trim = "", 0, Me.txtRatio_Share.Text.Trim)
        Dim Access_Number As String = Me.txtAccess_Number.Text.Trim
        Dim Service_Id As String = Me.txtService_Id.Text.Trim
        Dim Service_Text As String = Me.txtService_Text.Text.Trim
        Dim Pricing As String = Me.txtPricing.Text.Trim
        Dim Period_Id As Integer = Me.DropDownListPeriod_Id.SelectedItem.Value
        Dim Period_Text As String = Me.DropDownListPeriod_Id.SelectedItem.Text
        Dim Subscription_Command_Word As String = Me.txtSubscription_Command_Word.Text.Trim
        Dim Unsubscription_Command_Word As String = Me.txtUnsubscription_Command_Word.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  S2_DictIndex_Service  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Service_Id=N'" & Service_Id & "' And Mobile_Operator=N'" & Mobile_Operator & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into S2_DictIndex_Service(Mobile_Operator, Partner_Id,Partner_Text,Ratio_Share,Access_Number, Service_Id,Service_Text,Pricing,Period_Id,Period_Text,Subscription_Command_Word,Unsubscription_Command_Word,Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Mobile_Operator & "',N'" & Partner_Id & "',N'" & Partner_Text & "',N'" & Ratio_Share & "',N'" & Access_Number & "',N'" & Service_Id & "',N'" & Service_Text & "',N'" & Pricing & "',N'" & Period_Id & "',N'" & Period_Text & "',N'" & Subscription_Command_Word & "',N'" & Unsubscription_Command_Word & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update S2_DictIndex_Service Set Mobile_Operator=N'" & Mobile_Operator & "'," & _
     "Partner_Id=N'" & Partner_Id & "'," & _
     "Partner_Text=N'" & Partner_Text & "'," & _
     "Ratio_Share=N'" & Ratio_Share & "'," & _
     "Access_Number=N'" & Access_Number & "'," & _
     "Service_Id=N'" & Service_Id & "'," & _
     "Service_Text=N'" & Service_Text & "'," & _
     "Pricing=N'" & Pricing & "'," & _
     "Period_Id=N'" & Period_Id & "'," & _
     "Subscription_Command_Word=N'" & Subscription_Command_Word & "'," & _
     "Unsubscription_Command_Word=N'" & Unsubscription_Command_Word & "'," & _
     "Update_Time=N'" & Update_Time & "'," & _
     "Update_By_Id=N'" & Update_By_Id & "'," & _
     "Update_By_Text=N'" & Update_By_Text & "'," & _
     "Description=N'" & Description & "'" & _
     " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._S2.S2DictIndexVNMServiceList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._S2.S2DictIndexVNMServiceList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From S2_DictIndex_Service Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._S2.S2DictIndexVNMServiceList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region
End Class