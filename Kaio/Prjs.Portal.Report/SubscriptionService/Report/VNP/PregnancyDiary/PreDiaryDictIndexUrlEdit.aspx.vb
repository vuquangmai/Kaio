Imports System.Data.SqlClient

Public Class PreDiaryDictIndexUrlEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindPartner()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN URL TRUYỀN THÔNG - DỊCH VỤ NHẬT KÝ MANG THAI"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN URL TRUYỀN THÔNG - DỊCH VỤ NHẬT KÝ MANG THAI"
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
        Dim sql As String = "SELECT * FROM Ccare_Management_Partner A INNER JOIN Ccare_Management_Contract B " & _
                                      " ON A.Id=B.Partner_Id WHERE B.Service_Id=" & Constants.ServiceInfo.Id.PregnancyDiary & " Order by Confidence_Text"
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
        Dim sql As String = "SELECT * FROM Pregnancy_Diary_DictIndex_Url_Service Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtUrl_Code.Text = dt.Rows(0).Item("Url_Code")
            Me.DropDownListPartner_Id.SelectedValue = dt.Rows(0).Item("Partner_Id")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("Status")
            Me.txtUrl.Text = IIf(IsDBNull(dt.Rows(0).Item("Url")) = True, "", dt.Rows(0).Item("Url"))
            Me.txtRatio_Share_Diary.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share_Diary")) = True, "", dt.Rows(0).Item("Ratio_Share_Diary"))
            Me.txtRatio_Share_Week.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share_Week")) = True, "", dt.Rows(0).Item("Ratio_Share_Week"))
            Me.txtRatio_Share_Clip.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share_Clip")) = True, "", dt.Rows(0).Item("Ratio_Share_Clip"))
            Me.txtRatio_Share_Audio.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share_Audio")) = True, "", dt.Rows(0).Item("Ratio_Share_Audio"))
            Me.txtRatio_Share_Advise.Text = IIf(IsDBNull(dt.Rows(0).Item("Ratio_Share_Advise")) = True, "", dt.Rows(0).Item("Ratio_Share_Advise"))
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
        If Me.txtRatio_Share_Diary.Text = "" Or Not IsNumeric(Me.txtRatio_Share_Diary.Text.Trim) Then
            Me.lblerror.Text = "Tỷ lê gói ngày không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_Share_Week.Text.Trim = "" Or Not IsNumeric(Me.txtRatio_Share_Week.Text.Trim) Then
            Me.lblerror.Text = "Tỷ lê gói tuần không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_Share_Clip.Text = "" Or Not IsNumeric(Me.txtRatio_Share_Clip.Text.Trim) Then
            Me.lblerror.Text = "Tỷ lê gói Clip không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_Share_Audio.Text = "" Or Not IsNumeric(Me.txtRatio_Share_Audio.Text.Trim) Then
            Me.lblerror.Text = "Tỷ lê gói Audio không hợp lệ !"
            Exit Sub
        End If
        If Me.txtRatio_Share_Advise.Text = "" Or Not IsNumeric(Me.txtRatio_Share_Advise.Text.Trim) Then
            Me.lblerror.Text = "Tỷ lê gói tư vấn không hợp lệ !"
            Exit Sub
        End If
        Dim Partner_Id As Integer = Me.DropDownListPartner_Id.SelectedItem.Value
        Dim Url_Code As String = Me.txtUrl_Code.Text.Trim
        Dim Ratio_Share_Diary As String = Me.txtRatio_Share_Diary.Text.Trim
        Dim Ratio_Share_Week As String = Me.txtRatio_Share_Week.Text.Trim
        Dim Ratio_Share_Clip As String = Me.txtRatio_Share_Clip.Text.Trim
        Dim Ratio_Share_Audio As String = Me.txtRatio_Share_Audio.Text.Trim
        Dim Ratio_Share_Advise As String = Me.txtRatio_Share_Advise.Text.Trim
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
        sql = "SELECT * From  Pregnancy_Diary_DictIndex_Url_Service  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Url=N'" & Url & "'"
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "Insert Into Pregnancy_Diary_DictIndex_Url_Service(Partner_Id, Url_Code,Ratio_Share_Diary,Ratio_Share_Week,Ratio_Share_Clip,Ratio_Share_Audio,Ratio_Share_Advise, Status,Url, Create_Time, Create_By_Id, Create_By_Text, Update_Time, Update_By_Id,Update_By_Text,Description)" & _
                    "Values (N'" & Partner_Id & "',N'" & Url_Code & "',N'" & Ratio_Share_Diary & "',N'" & Ratio_Share_Week & "',N'" & Ratio_Share_Clip & "',N'" & Ratio_Share_Audio & "',N'" & Ratio_Share_Advise & "',N'" & Status & "',N'" & Url & "',N'" & Create_Time & "',N'" & Create_By_Id & "',N'" & Create_By_Text & "',N'" & Update_Time & "',N'" & Update_By_Id & "',N'" & Update_By_Text & "',N'" & Description & "')"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "Update Pregnancy_Diary_DictIndex_Url_Service Set Partner_Id=N'" & Partner_Id & "'," & _
                     "Url_Code=N'" & Url_Code & "'," & _
                     "Ratio_Share_Diary=N'" & Ratio_Share_Diary & "'," & _
                     "Ratio_Share_Week=N'" & Ratio_Share_Week & "'," & _
                     "Ratio_Share_Clip=N'" & Ratio_Share_Clip & "'," & _
                     "Ratio_Share_Audio=N'" & Ratio_Share_Audio & "'," & _
                     "Ratio_Share_Advise=N'" & Ratio_Share_Advise & "'," & _
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
                RedirectUrl(Constants.Url._PregnancyDiary.PreDiaryDictIndexUrlList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._PregnancyDiary.PreDiaryDictIndexUrlList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From Pregnancy_Diary_DictIndex_Url_Service Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            sql = "Delete From Ccare_Management_Contract_Pregnancy_Diary Where Url_Id=" & ViewState(ViewStateInfo.Object_Id)
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Vishare.VishareDictIndexUrlList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region
#Region "Ajax"
    Protected Sub txtUrl_Code_TextChanged(sender As Object, e As EventArgs) Handles txtUrl_Code.TextChanged
        Me.txtUrl.Text = "http://ads.vishare.vn/?p=" & Me.txtUrl_Code.Text.Trim
    End Sub
#End Region
End Class