   Imports System.Data.SqlClient

    Public Class SMSDictIndexKeywordFilterEdit
        Inherits GlobalPage
#Region "Page Load"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
                BindDept()
                ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
                If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                    If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI MÃ DỊCH VỤ SMS VIETTEL FILTER"
                        bindData(ViewState(ViewStateInfo.Object_Id))
                        ViewState(ViewStateInfo.Status) = Constants.Action.Update
                    Else
                    Me.lbltitle.Text = "THÊM MÃ DỊCH VỤ SMS VIETTEL FILTER"
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
        Private Sub BindDept()
        'Dim sql As String = "SELECT * FROM System_Department Order by Dept_Text"
        'Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        'Me.DropDownListDepartment_Id.Items.Clear()
        'Me.DropDownListDepartment_Id.Items.Add(New ListItem("--Chọn--", 0))
        'Me.DropDownListDepartment_Id.SelectedValue = 0
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '    Me.DropDownListDepartment_Id.Items.Add(New ListItem(dt.Rows(i).Item("Dept_Code"), dt.Rows(i).Item("Id")))
        '    Next
        'End If
        End Sub
        Private Sub BindShortCode(Range_Of_Short_Code As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Short_Code  not like '8%76' And  Short_Code not like '6%35' "
        If Range_Of_Short_Code <> "--Chọn--" Then
            sql = sql & "  And  Range_Of_Short_Code='" & Range_Of_Short_Code & "'"
        End If
            sql = sql & "  Order by Short_Code"
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCode.Items.Clear()
        Me.DropDownListShortCode.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListShortCode.SelectedValue = 0
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
                Next
            End If
        End Sub
#End Region
#Region "Bind Data"
        Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM service_viettel_filter Where Id=" & intId
        Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
            If dt.Rows.Count > 0 Then
            Me.DropDownListDepartment_Id.SelectedValue = dt.Rows(0).Item("thirdparty_id")
            BindShortCode("--Chọn--")
            Me.DropDownListShortCode.SelectedValue = dt.Rows(0).Item("shortcode")
            Me.txtKeyWord.Text = dt.Rows(0).Item("keyword")
            Me.DropDownListStatus.SelectedValue = dt.Rows(0).Item("status")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
            Me.txtservice_uri.Text = IIf(IsDBNull(dt.Rows(0).Item("service_uri")) = True, "", dt.Rows(0).Item("service_uri"))

            End If
        End Sub
#End Region
#Region "Submit Click"
        Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
            If Me.DropDownListDepartment_Id.SelectedItem.Text = "--Chọn--" Then
                Me.lblerror.Text = "Phòng ban không hợp lệ !"
                Exit Sub
            End If
            If Me.DropDownListShortCode.SelectedItem.Value = 0 Then
                Me.lblerror.Text = "Đầu số không hợp lệ !"
                Exit Sub
            End If
            If Me.txtKeyWord.Text = "" Then
                Me.lblerror.Text = "Mã dịch vụ không hợp lệ !"
                Exit Sub
            End If

        Dim thirdparty_id As String = Me.DropDownListDepartment_Id.SelectedItem.Value
        Dim name As String = Me.DropDownListDepartment_Id.SelectedItem.Text
        Dim service_uri As String = Me.txtservice_uri.Text.Trim
        Dim description As String = Me.txtDescription.Text.Trim
        Dim shortcode As String = Me.DropDownListShortCode.SelectedItem.Value
        Dim keyword As String = Me.txtKeyWord.Text.Trim
        Dim Status As Integer = Me.DropDownListStatus.SelectedItem.Value
        Dim create_date As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim creator As String = CurrentUser.UserName
        Dim start_date As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim end_date As String = DateTime.Parse(Now.AddYears(100)).ToString("yyyy-MM-dd HH:mm:ss")
        Dim last_updated As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim sql As String = ""

        sql = "SELECT * From  service_viettel_filter  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And shortcode=N'" & shortcode & "' And keyword=N'" & keyword & "'"
        Dim dt As DataTable = MySQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
        If dt.Rows.Count = 0 Then
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                sql = "insert into service_viettel_filter (name, service_uri,description, shortcode,keyword,create_date,creator,thirdparty_id,operator,start_date,end_date,status,last_updated) " & _
                         " values " & _
                         "('" & name & "','" & service_uri & "','" & description & "','" & shortcode & "','" & keyword & "',current_date(), '" & creator & "' , " & thirdparty_id & " ,'VIETTEL' ,current_date() , DATE_ADD(current_date(),INTERVAL 50 YEAR) , " & Status & " , current_timestamp())"
            ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
                sql = "update service_viettel_filter set " & _
                            " name='" & name & "'," & _
                            " service_uri='" & service_uri & "'," & _
                            " description='" & description & "'," & _
                            " shortcode='" & shortcode & "'," & _
                            " keyword='" & keyword & "'," & _
                            " thirdparty_id='" & thirdparty_id & "'," & _
                            " status='" & Status & "'," & _
                            " last_updated= current_timestamp() " & _
                            " Where Id='" & ViewState(ViewStateInfo.Object_Id) & "'"
            End If
            Try
                MySQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
                RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordFilterList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
        Else
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
            Exit Sub
        End If
        End Sub
        Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordFilterList)
        End Sub
        Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete From  service_viettel_filter  Where Id=" & ViewState(ViewStateInfo.Object_Id)
            Try
            MySQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString("MySQL_234_1"), sql)
            RedirectUrl(Constants.Url._SMS.SMSDictIndexKeywordFilterList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
        End Sub
#End Region
#Region "Ajax"
        Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
            BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)
        End Sub
#End Region
    End Class