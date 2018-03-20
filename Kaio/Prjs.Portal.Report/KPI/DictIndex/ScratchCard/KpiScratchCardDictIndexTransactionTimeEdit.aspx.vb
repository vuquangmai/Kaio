Public Class KpiScratchCardDictIndexTransactionTimeEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "KPI DỊCH VỤ THẺ CÀO - CẬP NHẬT TỪ ĐIỂN THỜI GIAN XỬ LÝ GIAO DỊCH"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "KPI DỊCH VỤ BRAND NAME - THÊM TỪ ĐIỂN THỜI GIAN XỬ LÝ GIAO DỊCH"
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
        Dim sql As String = "SELECT * FROM Kpi_ScratchCard_DictIndex_Transaction_Time Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtCriteria_Text.Text = dt.Rows(0).Item("Criteria_Text")
            Me.txtPercentage.Text = IIf(IsDBNull(dt.Rows(0).Item("Percentage")) = True, "", dt.Rows(0).Item("Percentage"))
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            Me.DropDownListStatus_Id.SelectedValue = dt.Rows(0).Item("Status_Id")
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        'If Me.DropDownListPartner_Id.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Đối tác không hợp lệ !"
        '    Exit Sub
        'End If
        If Me.txtCriteria_Text.Text = "" Then
            Me.lblerror.Text = "Tiêu chí không hợp lệ !"
            Exit Sub
        End If

        If Me.DropDownListStatus_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Trạng thái không hợp lệ !"
            Exit Sub
        End If
        If Me.txtPercentage.Text = "" Then
            Me.lblerror.Text = "Tỷ trọng không hợp lệ !"
            Exit Sub
        ElseIf Not IsNumeric(Me.txtPercentage.Text.Trim) Then
            Me.lblerror.Text = "Tỷ trọng phải là kiểu số !"
            Exit Sub
        End If

        Dim Criteria_Text As String = Me.txtCriteria_Text.Text.ToUpper
        Dim Percentage As Integer = Me.txtPercentage.Text.Trim
        Dim Status_Id As Integer = Me.DropDownListStatus_Id.SelectedItem.Value
        Dim Status_Text As String = Me.DropDownListStatus_Id.SelectedItem.Text
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  Kpi_ScratchCard_DictIndex_Transaction_Time  Where  Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Criteria_Text=N'" & Criteria_Text & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                ''Insert
                'sql = "INSERT INTO Kpi_ScratchCard_DictIndex_Transaction_Time (TypeOf_Kpi_Id,Routing_Text,TypeOf_Id,TypeOf_Text,Percentage,Status_Id,Status_Text,Create_Time,Create_By_Id,Create_By_Text,Update_Time,Update_By_Id,Update_By_Text,Description) " & _
                '    " VALUES('" & TypeOf_Kpi_Id & "',N'" & Routing_Text & "',N'" & TypeOf_Id & "',N'" & TypeOf_Text & "',N'" & Percentage & "',N'" & Status_Id & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Kpi_ScratchCard_DictIndex_Transaction_Time Set " & _
                         "Criteria_Text=N'" & Criteria_Text & "'," & _
                         "Percentage=N'" & Percentage & "'," & _
                         "Status_Id=N'" & Status_Id & "'," & _
                         "Status_Text=N'" & Status_Text & "'," & _
                         "Update_Time=N'" & Update_Time & "'," & _
                         "Update_By_Id=N'" & Update_By_Id & "'," & _
                         "Update_By_Text=N'" & Update_By_Text & "'," & _
                         "Description=N'" & Description & "'" & _
                         " Where Id=" & ViewState(ViewStateInfo.Object_Id)
            End If
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._KPI.ScratchCard.KpiScratchCardDictIndexTransactionTimeList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._KPI.ScratchCard.KpiScratchCardDictIndexTransactionTimeList)
    End Sub

#End Region
End Class