Public Class KpiInfrasDictIndexTechnicalQualityServerErrEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "KPI HẠ TẦNG - CẬP NHẬT THỜI GIAN KHẮC PHỤC SỰ CỐ MÁY CHỦ"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "KPI HẠ TẦNG - THÊM THỜI GIAN KHẮC PHỤC SỰ CỐ MÁY CHỦ"
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Technical_Quality_Server_Error Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtCriteria_Text.Text = dt.Rows(0).Item("Criteria_Text")
            Me.txtStandar_Threshold_Handle.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle"))
            Me.txtStandar_Threshold_Handle_Over.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Over")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Over"))
            Me.txtDecrease_Percent.Text = IIf(IsDBNull(dt.Rows(0).Item("Decrease_Percent")) = True, "", dt.Rows(0).Item("Decrease_Percent"))
            Me.txtStandar_Threshold_Handle_Max.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Max")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Max"))
            Me.txtDecrease_Percent_Max.Text = IIf(IsDBNull(dt.Rows(0).Item("Decrease_Percent_Max")) = True, "", dt.Rows(0).Item("Decrease_Percent_Max"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            Me.lblTypeOf_Unit.Text = IIf(IsDBNull(dt.Rows(0).Item("TypeOf_Unit")) = True, "", dt.Rows(0).Item("TypeOf_Unit"))
            Me.lblTypeOf_Unit0.Text = IIf(IsDBNull(dt.Rows(0).Item("TypeOf_Unit")) = True, "", dt.Rows(0).Item("TypeOf_Unit"))
            Me.lblTypeOf_Unit3.Text = IIf(IsDBNull(dt.Rows(0).Item("TypeOf_Unit")) = True, "", dt.Rows(0).Item("TypeOf_Unit"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtCriteria_Text.Text = "" Then
            Me.lblerror.Text = "Tiêu chí không hợp lệ !"
            Exit Sub
        End If
        If Me.txtStandar_Threshold_Handle.Text = "" Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle.Text.Trim) Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        
        If Me.txtStandar_Threshold_Handle_Over.Text = "" Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Over.Text.Trim) Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent.Text = "" Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent.Text.Trim) Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent_Max.Text = "" Then
            Me.lblerror.Text = "Ngưỡng xử lý tối đa không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent.Text.Trim) Then
            Me.lblerror.Text = "Ngưỡng xử lý tối đa phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent_Max.Text = "" Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý tối đa không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent.Text.Trim) Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý tối đa phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Text As String = Me.txtCriteria_Text.Text.Trim
        Dim Standar_Threshold_Handle As Integer = Me.txtStandar_Threshold_Handle.Text.Trim
        Dim Standar_Threshold_Handle_Over As Integer = Me.txtStandar_Threshold_Handle_Over.Text.Trim
        Dim Decrease_Percent As Integer = Me.txtDecrease_Percent.Text.Trim
        Dim Standar_Threshold_Handle_Max As Integer = Me.txtStandar_Threshold_Handle_Max.Text.Trim
        Dim Decrease_Percent_Max As Integer = Me.txtDecrease_Percent_Max.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  Kpi_Infras_DictIndex_Technical_Quality_Server_Error  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Criteria_Text=N'" & Criteria_Text & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                'Insert
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Kpi_Infras_DictIndex_Technical_Quality_Server_Error Set Standar_Threshold_Handle=N'" & Standar_Threshold_Handle & "'," & _
                         "Standar_Threshold_Handle_Over=N'" & Standar_Threshold_Handle_Over & "'," & _
                         "Decrease_Percent=N'" & Decrease_Percent & "'," & _
                         "Standar_Threshold_Handle_Max=N'" & Standar_Threshold_Handle_Max & "'," & _
                         "Decrease_Percent_Max=N'" & Decrease_Percent_Max & "'," & _
                         "Update_Time=N'" & Update_Time & "'," & _
                         "Update_By_Id=N'" & Update_By_Id & "'," & _
                         "Update_By_Text=N'" & Update_By_Text & "'," & _
                         "Description=N'" & Description & "'" & _
                         " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._KPI.Infras.KpiInfrasDictIndexTechnicalQualityServerErrList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._KPI.Infras.KpiInfrasDictIndexTechnicalQualityServerErrList)
    End Sub

#End Region
End Class