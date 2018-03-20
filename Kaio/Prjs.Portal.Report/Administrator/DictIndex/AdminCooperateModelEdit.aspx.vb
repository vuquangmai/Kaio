Public Class AdminCooperateModelEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN MÔ HÌNH HỢP TÁC"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN MÔ HÌNH HỢP TÁC"
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
        Dim sql As String = "SELECT * FROM System_Cooperation_Model Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtModel_Text.Text = dt.Rows(0).Item("Model_Text")
            Me.txtModel_Code.Text = IIf(IsDBNull(dt.Rows(0).Item("Model_Code")) = True, "", dt.Rows(0).Item("Model_Code"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtModel_Text.Text = "" Then
            Me.lblerror.Text = "Tên dịch vụ không hợp lệ !"
            Exit Sub
        End If
        If Me.txtModel_Text.Text.Trim = "" Then
            Me.lblerror.Text = "Mã dịch vụ không hợp lệ !"
            Exit Sub
        End If
        Dim Model_Text As String = Me.txtModel_Text.Text.Trim
        Dim Model_Code As String = Me.txtModel_Code.Text.Trim
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = "SELECT * From  System_Cooperation_Model  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Model_Text=N'" & Model_Text & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into System_Cooperation_Model(Model_Text, Model_Code,  Description)" & _
                    "Values (N'" & Model_Text & "',N'" & Model_Code & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update System_Cooperation_Model Set Model_Text=N'" & Model_Text & "'," & _
                "Model_Code=N'" & Model_Code & "'," & _
                "Description=N'" & Description & "'" & _
                " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Admin.AdminCooperateModelList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminCooperateModelList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim str As String = ""
        Dim sql As String = "Delete From System_Cooperation_Model Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminCooperateModelList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
End Class