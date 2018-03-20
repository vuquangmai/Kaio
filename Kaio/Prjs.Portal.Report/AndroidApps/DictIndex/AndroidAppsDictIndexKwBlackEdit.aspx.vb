Imports System.Data.SqlClient

Public Class AndroidAppsDictIndexKwBlackEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN KEYWORD"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN KEYWORD"
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
        Dim sql As String = "SELECT * FROM Apps_Keyword_BlackList Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtKeyword.Text = dt.Rows(0).Item("Keyword")
            Me.DropDownListField_Id.SelectedValue = dt.Rows(0).Item("Field_Id")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.DropDownListField_Id.SelectedItem.Value = "Chọn" Then
            Me.lblerror.Text = "Trường tìm kiếm không hợp lệ!"
            Exit Sub
        End If
        If Me.txtKeyword.Text = "" Then
            Me.lblerror.Text = "Keyword không hợp lệ !"
            Exit Sub
        End If

        Dim Keyword As String = Me.txtKeyword.Text.Trim
        Dim Field_Id As String = Me.DropDownListField_Id.SelectedItem.Value
        Dim Field_Text As String = Me.DropDownListField_Id.SelectedItem.Text
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * FROM  Apps_Keyword_BlackList  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Keyword=N'" & Keyword & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into Apps_Keyword_BlackList(Keyword,Field_Id,Field_Text,Create_Time,Create_By_Id,Create_By_Text,Update_Time,Update_By_Id,Update_By_Text, Description)" & _
                    "Values (N'" & Keyword & "',N'" & Field_Id & "',N'" & Field_Text & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Apps_Keyword_BlackList Set Keyword=N'" & Keyword & "'," & _
                        "Field_Id=N'" & Field_Id & "'," & _
                        "Field_Text=N'" & Field_Text & "'," & _
                        "Update_Time=N'" & Update_Time & "'," & _
                        "Update_By_Id=N'" & Update_By_Id & "'," & _
                        "Update_By_Text=N'" & Update_By_Text & "'," & _
                        "Description=N'" & Description & "'" & _
                       " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._AndroidApps.AndroidAppsDictIndexKwBlackList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._AndroidApps.AndroidAppsDictIndexKwBlackList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From Apps_Keyword_BlackList Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._AndroidApps.AndroidAppsDictIndexKwBlackList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"

#End Region

End Class