Public Class KpiInfrasDictIndexInternetBandwidthEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "KPI HẠ TẦNG - CẬP NHẬT BĂNG THÔNG INTERNET"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "KPI HẠ TẦNG - THÊM BĂNG THÔNG INTERNET"
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
        Dim sql As String = "SELECT * FROM Kpi_Infras_DictIndex_Internet_Bandwidth Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtCriteria_Text.Text = dt.Rows(0).Item("Criteria_Text")
            Me.txtStandar_Threshold_Handle_Quantity.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Quantity")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Quantity"))
            Me.txtStandar_Threshold_Handle_Over_Quantity.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Over_Quantity")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Over_Quantity"))
            Me.txtDecrease_Percent_Quantity.Text = IIf(IsDBNull(dt.Rows(0).Item("Decrease_Percent_Quantity")) = True, "", dt.Rows(0).Item("Decrease_Percent_Quantity"))
            Me.txtStandar_Threshold_Handle_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Time")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Time"))
            Me.txtStandar_Threshold_Handle_Over_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Over_Time")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Over_Time"))
            Me.txtDecrease_Percent_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Decrease_Percent_Time")) = True, "", dt.Rows(0).Item("Decrease_Percent_Time"))
            Me.txtStandar_Threshold_Handle_Max_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Standar_Threshold_Handle_Max_Time")) = True, "", dt.Rows(0).Item("Standar_Threshold_Handle_Max_Time"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            Me.txtDecrease_Percent_Max_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Decrease_Percent_Max_Time")) = True, "", dt.Rows(0).Item("Decrease_Percent_Max_Time"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtCriteria_Text.Text = "" Then
            Me.lblerror.Text = "Tiêu chí không hợp lệ !"
            Exit Sub
        End If
        If Me.txtStandar_Threshold_Handle_Quantity.Text = "" Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Quantity.Text.Trim) Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtStandar_Threshold_Handle_Over_Quantity.Text = "" Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Over_Quantity.Text.Trim) Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent_Quantity.Text = "" Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent_Quantity.Text.Trim) Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If

        If Me.txtStandar_Threshold_Handle_Time.Text = "" Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Time.Text.Trim) Then
            Me.lblerror.Text = "Ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtStandar_Threshold_Handle_Over_Time.Text = "" Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Over_Time.Text.Trim) Then
            Me.lblerror.Text = "Bước nhảy quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent_Time.Text = "" Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent_Time.Text.Trim) Then
            Me.lblerror.Text = "Điểm trừ quá ngưỡng xử lý chuẩn phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtStandar_Threshold_Handle_Max_Time.Text = "" Then
            Me.lblerror.Text = "Ngưỡng xử lý tối đa không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtStandar_Threshold_Handle_Max_Time.Text.Trim) Then
            Me.lblerror.Text = "Ngưỡng xử lý tối đa phải là kiểu số !"
            Exit Sub
        End If
        If Me.txtDecrease_Percent_Max_Time.Text = "" Then
            Me.lblerror.Text = "Điểm trừ ở ngưỡng xử lý tối đa không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtDecrease_Percent_Max_Time.Text.Trim) Then
            Me.lblerror.Text = "Điểm trừ ở ngưỡng xử lý tối đa phải là kiểu số !"
            Exit Sub
        End If
        Dim Criteria_Text As String = Me.txtCriteria_Text.Text.Trim
        Dim Standar_Threshold_Handle_Quantity As Integer = Me.txtStandar_Threshold_Handle_Quantity.Text.Trim
        Dim Standar_Threshold_Handle_Over_Quantity As Integer = Me.txtStandar_Threshold_Handle_Over_Quantity.Text.Trim
        Dim Decrease_Percent_Quantity As Integer = Me.txtDecrease_Percent_Quantity.Text.Trim
        Dim Standar_Threshold_Handle_Time As Integer = Me.txtStandar_Threshold_Handle_Time.Text.Trim
        Dim Standar_Threshold_Handle_Over_Time As Integer = Me.txtStandar_Threshold_Handle_Over_Time.Text.Trim
        Dim Decrease_Percent_Time As Integer = Me.txtDecrease_Percent_Time.Text.Trim
        Dim Standar_Threshold_Handle_Max_Time As Integer = Me.txtStandar_Threshold_Handle_Max_Time.Text.Trim
        Dim Decrease_Percent_Max_Time As Integer = Me.txtDecrease_Percent_Max_Time.Text.Trim
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  Kpi_Infras_DictIndex_Internet_Bandwidth  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Criteria_Text=N'" & Criteria_Text & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                'Insert
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "UPDATE Kpi_Infras_DictIndex_Internet_Bandwidth SET " & _
                         " Standar_Threshold_Handle_Quantity=N'" & Standar_Threshold_Handle_Quantity & "'," & _
                         "Standar_Threshold_Handle_Over_Quantity=N'" & Standar_Threshold_Handle_Over_Quantity & "'," & _
                         "Decrease_Percent_Quantity=N'" & Decrease_Percent_Quantity & "'," & _
                         "Standar_Threshold_Handle_Time=N'" & Standar_Threshold_Handle_Time & "'," & _
                         "Standar_Threshold_Handle_Over_Time=N'" & Standar_Threshold_Handle_Over_Time & "'," & _
                         "Decrease_Percent_Time=N'" & Decrease_Percent_Time & "'," & _
                         "Standar_Threshold_Handle_Max_Time=N'" & Standar_Threshold_Handle_Max_Time & "'," & _
                         "Decrease_Percent_Max_Time=N'" & Decrease_Percent_Max_Time & "'," & _
                         "Update_Time=N'" & Update_Time & "'," & _
                         "Update_By_Id=N'" & Update_By_Id & "'," & _
                         "Update_By_Text=N'" & Update_By_Text & "'," & _
                         "Description=N'" & Description & "'" & _
                         " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._KPI.Infras.KpiInfrasDictIndexTechnicalQualitySysDownTimeList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
     
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._KPI.Infras.KpiInfrasDictIndexInternetBandwidthList)
    End Sub

#End Region
End Class