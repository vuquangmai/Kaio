Imports System.Data.SqlClient

Public Class SMSDictIndexLotteryCompanyEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN CÔNG TY XỔ SỐ"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    ViewState(ViewStateInfo.Status) = Constants.Action.Insert
                    Me.lbltitle.Text = "THÊM THÔNG TIN CÔNG TY XỔ SỐ"
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Me.btnDelete.Visible = False
                Me.btnResetPassWord.Visible = False
            End If
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT Id, Region_Id, Region_Text, Company_Text, Date_Result_Id, Date_Result_Text, Create_By_Id, Create_By_Text, Create_Time, Update_By_Id,Update_By_Text,Update_Time,Description" & _
            " FROM SMS_DictIndex_Lottery_Company Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtCompany_Id.Text = dt.Rows(0).Item("Company_Text")
            Me.DropDownListRegion_Id.SelectedValue = dt.Rows(0).Item("Region_Id")
            Dim splitout = Split(dt.Rows(0).Item("Date_Result_Id").ToString.Trim, ";")
            For i As Integer = 0 To UBound(splitout)
                If IsNumeric(splitout(i)) = True Then
                    Me.CheckBoxListDateResult.Items.FindByValue(splitout(i)).Selected = True
                End If
            Next
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtCompany_Id.Text = "" Then
            Me.lblerror.Text = "Tên Công ty xổ số không hợp lệ !"
            Exit Sub
        End If

        If Me.DropDownListRegion_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Miền không hợp lệ !"
            Exit Sub
        End If
        Dim Region_Id As Integer = Me.DropDownListRegion_Id.SelectedItem.Value
        Dim Region_Text As String = Me.DropDownListRegion_Id.SelectedItem.Text
        Dim Company_Text As String = Me.txtCompany_Id.Text.Trim
        Dim Date_Result_Id As String = ""
        Dim Date_Result_Text As String = ""
        For i As Integer = 0 To Me.CheckBoxListDateResult.Items.Count - 1
            If CheckBoxListDateResult.Items(i).Selected = True Then
                If Date_Result_Text.Trim = "" Then
                    Date_Result_Text = Me.CheckBoxListDateResult.Items(i).Text
                    Date_Result_Id = Me.CheckBoxListDateResult.Items(i).Value & ";"
                Else
                    Date_Result_Text = Date_Result_Text & ";" & Me.CheckBoxListDateResult.Items(i).Text
                    Date_Result_Id = Date_Result_Id & Me.CheckBoxListDateResult.Items(i).Value & ";"
                End If
            End If
        Next
        Dim Create_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Create_By_Id As String = CurrentUser.UserId
        Dim Create_By_Text As String = CurrentUser.UserName
        Dim Update_Time As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim Update_By_Id As String = CurrentUser.UserId
        Dim Update_By_Text As String = CurrentUser.UserName
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String = ""
        sql = "SELECT * From  SMS_DictIndex_Lottery_Company  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And Company_Text=N'" & Company_Text & "'"
        Dim vId As Integer = 0
        If Me.IsCheckData(sql) = False Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                vId = InsertData(Region_Id, Region_Text, Company_Text, Date_Result_Id, Date_Result_Text, Create_By_Id, Create_By_Text, Create_Time, Update_By_Id, Update_By_Text, Update_Time, Description)
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                vId = UpdateData(ViewState(ViewStateInfo.Object_Id), Region_Id, Region_Text, Company_Text, Date_Result_Id, Date_Result_Text, Update_By_Id, Update_By_Text, Update_Time, Description)
            End If
            If vId > 0 Then
                RedirectUrl(Constants.Url._SMS.SMSDictIndexLotteryCompanyList)
            Else
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute
            End If
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexLotteryCompanyList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From SMS_DictIndex_Lottery_Company " & _
                                    " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._SMS.SMSDictIndexLotteryCompanyList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub


#End Region
#Region "Insert User"
    Private Function InsertData(ByVal Region_Id As Integer, _
                     ByVal Region_Text As String, _
                     ByVal Company_Text As String, _
                     ByVal Date_Result_Id As String, _
                     ByVal Date_Result_Text As String, _
                     ByVal Create_By_Id As Integer, _
                     ByVal Create_By_Text As String, _
                     ByVal Create_Time As String, _
                     ByVal Update_By_Id As Integer, _
                     ByVal Update_By_Text As String, _
                     ByVal Update_Time As String, _
                     ByVal Description As String) As String
        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "SMS_Insert_Lottery_Company"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters("@Id").Direction = ParameterDirection.Output

            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.Int))
            .Parameters("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 250))
            .Parameters("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Result_Id", SqlDbType.NVarChar, 250))
            .Parameters("@Date_Result_Id").Value = Date_Result_Id

            .Parameters.Add(New SqlParameter("@Date_Result_Text", SqlDbType.NVarChar, 250))
            .Parameters("@Date_Result_Text").Value = Date_Result_Text

            .Parameters.Add(New SqlParameter("@Create_By_Id", SqlDbType.Int))
            .Parameters("@Create_By_Id").Value = Create_By_Id

            .Parameters.Add(New SqlParameter("@Create_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Create_By_Text").Value = Create_By_Text

            .Parameters.Add(New SqlParameter("@Create_Time", SqlDbType.DateTime))
            .Parameters("@Create_Time").Value = Create_Time

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
            .Parameters("@Description").Value = Description

            Try
                .ExecuteNonQuery()
                retval = .Parameters("@Id").Value
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
#Region "Update Users"
    Private Function UpdateData(ByVal Id As Integer, _
                   ByVal Region_Id As Integer, _
                   ByVal Region_Text As String, _
                   ByVal Company_Text As String, _
                   ByVal Date_Result_Id As String, _
                   ByVal Date_Result_Text As String, _
                   ByVal Update_By_Id As Integer, _
                   ByVal Update_By_Text As String, _
                   ByVal Update_Time As String, _
                   ByVal Description As String) As String
        Dim retval As Integer = 0
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "SMS_Update_Lottery_Company"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 50))
            .Parameters("@Id").Value = Id

            .Parameters.Add(New SqlParameter("@Region_Id", SqlDbType.Int))
            .Parameters("@Region_Id").Value = Region_Id

            .Parameters.Add(New SqlParameter("@Region_Text", SqlDbType.NVarChar, 50))
            .Parameters("@Region_Text").Value = Region_Text

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 250))
            .Parameters("@Company_Text").Value = Company_Text

            .Parameters.Add(New SqlParameter("@Date_Result_Id", SqlDbType.NVarChar, 250))
            .Parameters("@Date_Result_Id").Value = Date_Result_Id

            .Parameters.Add(New SqlParameter("@Date_Result_Text", SqlDbType.NVarChar, 250))
            .Parameters("@Date_Result_Text").Value = Date_Result_Text

            .Parameters.Add(New SqlParameter("@Update_By_Id", SqlDbType.Int))
            .Parameters("@Update_By_Id").Value = Update_By_Id

            .Parameters.Add(New SqlParameter("@Update_By_Text", SqlDbType.NVarChar, 500))
            .Parameters("@Update_By_Text").Value = Update_By_Text

            .Parameters.Add(New SqlParameter("@Update_Time", SqlDbType.DateTime))
            .Parameters("@Update_Time").Value = Update_Time

            .Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 2000))
            .Parameters("@Description").Value = Description

            Try
                .ExecuteNonQuery()
                retval = .Parameters("@Id").Value
            Catch ex As Exception
                Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & ex.Message
                retval = 0
            End Try
        End With
        Return retval
    End Function
#End Region
 
End Class