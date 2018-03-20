Imports System.Data.SqlClient

Public Class ChargingDictIndexUrlEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindPartner()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN TÀI KHOẢN THẺ CÀO"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN TÀI KHOẢN THẺ CÀO"
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
        Dim sql As String = "SELECT * FROM ScratchCard_DictIndex_Url_Service Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtUrl_Code.Text = dt.Rows(0).Item("Url_Code")
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.txtUrl.Text = IIf(IsDBNull(dt.Rows(0).Item("Url")) = True, "", dt.Rows(0).Item("Url"))
            Me.txtRatio_After_Viettel.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VIETTEL")) = True, 0, dt.Rows(0).Item("Ratio_After_VIETTEL"))
            Me.txtRatio_After_VMS.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMS")) = True, 0, dt.Rows(0).Item("Ratio_After_VMS"))
            Me.txtRatio_After_VNP.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VNP")) = True, 0, dt.Rows(0).Item("Ratio_After_VNP"))
            Me.txtRatio_After_VNM.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VNM")) = True, 0, dt.Rows(0).Item("Ratio_After_VNM"))
            Me.txtRatio_After_Gtel.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_GTEL")) = True, 0, dt.Rows(0).Item("Ratio_After_GTEL"))
            Me.txtRatio_After_VMG_Viettel.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMG_VIETTEL")) = True, 0, dt.Rows(0).Item("Ratio_After_VMG_VIETTEL"))
            Me.txtRatio_After_VMG_VMS.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMG_VMS")) = True, 0, dt.Rows(0).Item("Ratio_After_VMG_VMS"))
            Me.txtRatio_After_VMG_VNP.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMG_VNP")) = True, 0, dt.Rows(0).Item("Ratio_After_VMG_VNP"))
            Me.txtRatio_After_VMG_VNM.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMG_VNM")) = True, 0, dt.Rows(0).Item("Ratio_After_VMG_VNM"))
            Me.txtRatio_After_VMG_Gtel.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_After_VMG_GTEL")) = True, 0, dt.Rows(0).Item("Ratio_After_VMG_GTEL"))
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
        If Me.txtUrl_Code.Text = "" Then
            Me.lblerror.Text = "Mã Url không hợp lệ !"
            Exit Sub
        End If
        If Me.txtUrl.Text = "" Then
            Me.lblerror.Text = "Url không hợp lệ !"
            Exit Sub
        End If

        Dim Partner_Id As Integer = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Url_Code As String = Me.txtUrl_Code.Text.Trim
        Dim Ratio_After_VIETTEL As String = Me.txtRatio_After_Viettel.Text.Trim
        Dim Ratio_After_VMS As String = Me.txtRatio_After_VMS.Text.Trim
        Dim Ratio_After_VNP As String = Me.txtRatio_After_VNP.Text.Trim
        Dim Ratio_After_VNM As String = Me.txtRatio_After_VNM.Text.Trim
        Dim Ratio_After_GTEL As String = Me.txtRatio_After_Gtel.Text.Trim

        Dim Ratio_After_VMG_VIETTEL As String = Me.txtRatio_After_VMG_Viettel.Text.Trim
        Dim Ratio_After_VMG_VMS As String = Me.txtRatio_After_VMG_VMS.Text.Trim
        Dim Ratio_After_VMG_VNP As String = Me.txtRatio_After_VMG_VNP.Text.Trim
        Dim Ratio_After_VMG_VNM As String = Me.txtRatio_After_VMG_VNM.Text.Trim
        Dim Ratio_After_VMG_GTEL As String = Me.txtRatio_After_VMG_Gtel.Text.Trim

        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim Url As String = Me.txtUrl.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  ScratchCard_DictIndex_Url_Service  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Url=N'" & Url & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into ScratchCard_DictIndex_Url_Service(Partner_Id, Url_Code,Ratio_After_VIETTEL,Ratio_After_VMS,Ratio_After_VNP,Ratio_After_VNM,Ratio_After_GTEL," & _
                    " Ratio_After_VMG_VIETTEL,Ratio_After_VMG_VMS,Ratio_After_VMG_VNP,Ratio_After_VMG_VNM,Ratio_After_VMG_GTEL," & _
                    "Status,Url, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Partner_Id & "',N'" & Url_Code & "',N'" & Ratio_After_VIETTEL & "',N'" & Ratio_After_VMS & "',N'" & Ratio_After_VNP & "',N'" & Ratio_After_VNM & "',N'" & Ratio_After_GTEL & "'," & _
                    "N'" & Ratio_After_VMG_VIETTEL & "',N'" & Ratio_After_VMG_VMS & "',N'" & Ratio_After_VMG_VNP & "',N'" & Ratio_After_VMG_VNM & "',N'" & Ratio_After_VMG_GTEL & "'," & _
                    "N'" & Status & "',N'" & Url & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update ScratchCard_DictIndex_Url_Service Set Partner_Id=N'" & Partner_Id & "'," & _
     "Url_Code=N'" & Url_Code & "'," & _
     "Ratio_After_VIETTEL=N'" & Ratio_After_VIETTEL & "'," & _
     "Ratio_After_VMS=N'" & Ratio_After_VMS & "'," & _
     "Ratio_After_VNP=N'" & Ratio_After_VNP & "'," & _
     "Ratio_After_VNM=N'" & Ratio_After_VNM & "'," & _
     "Ratio_After_GTEL=N'" & Ratio_After_GTEL & "'," & _
     "Ratio_After_VMG_VIETTEL=N'" & Ratio_After_VMG_VIETTEL & "'," & _
     "Ratio_After_VMG_VMS=N'" & Ratio_After_VMG_VMS & "'," & _
     "Ratio_After_VMG_VNP=N'" & Ratio_After_VMG_VNP & "'," & _
     "Ratio_After_VMG_VNM=N'" & Ratio_After_VMG_VNM & "'," & _
     "Ratio_After_VMG_GTEL=N'" & Ratio_After_VMG_GTEL & "'," & _
     "Status=N'" & Status & "'," & _
     "Url=N'" & Url & "'," & _
     "Update_Time=N'" & Update_Time & "'," & _
     "Update_By_Id=N'" & Update_By_Id & "'," & _
     "Update_By_Text=N'" & Update_By_Text & "'," & _
     "Description=N'" & Description & "'" & _
     " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Charging.ChargingDictIndexUrlList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Charging.ChargingDictIndexUrlList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From ScratchCard_DictIndex_Url_Service Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            sql = "Delete From Ccare_Management_Contract_ScratchCard Where Url_Id=" & ViewState(ViewStateInfo.Object_Id)
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Charging.ChargingDictIndexUrlList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
 
End Class