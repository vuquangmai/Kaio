﻿Public Class CcareDictIndexFeesEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN MỨC CƯỚC SỬ DỤNG"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN MỨC CƯỚC SỬ DỤNG"
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
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FEES Where Id=" & intId
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.txtFEES_TEXT.Text = dt.Rows(0).Item("FEES_TEXT")
            Me.DropDownListSTATUS_ID.SelectedValue = dt.Rows(0).Item("STATUS_ID")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("DESCRIPTION")) = True, "", dt.Rows(0).Item("DESCRIPTION"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtFEES_TEXT.Text = "" Then
            Me.lblerror.Text = "Nguồn dữ liệu không hợp lệ !"
            Exit Sub
        End If
        Dim FEES_TEXT As String = Me.txtFEES_TEXT.Text.Trim
        Dim STATUS_ID As Integer = Me.DropDownListSTATUS_ID.SelectedItem.Value
        Dim STATUS_TEXT As String = Me.DropDownListSTATUS_ID.SelectedItem.Text
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim DESCRIPTION As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        Dim retval As String = ""
        sql = "SELECT * From  CCARE_DICTINDEX_FEES  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And upper(FEES_TEXT)='" & FEES_TEXT.ToUpper & "'"
        If Me.B2CCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                retval = UpdateObject.B2CManagement.InsertDictIndexFees(FEES_TEXT, STATUS_ID, STATUS_TEXT, CREATE_BY_ID, CREATE_BY_TEXT, CREATE_TIME, UPDATE_BY_ID, UPDATE_BY_TEXT, UPDATE_TIME, DESCRIPTION)
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                retval = UpdateObject.B2CManagement.UpdateDictIndexFees(ViewState(ViewStateInfo.Object_Id), FEES_TEXT, STATUS_ID, STATUS_TEXT, UPDATE_BY_ID, UPDATE_BY_TEXT, UPDATE_TIME, DESCRIPTION)
            End If
            If retval = "" Then
                RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexFeesList)
            Else
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & retval
                Exit Sub
            End If
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexFeesList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete  From  CCARE_DICTINDEX_FEES  Where  Id =" & ViewState(ViewStateInfo.Object_Id)
        Try
            OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexFeesList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region
End Class