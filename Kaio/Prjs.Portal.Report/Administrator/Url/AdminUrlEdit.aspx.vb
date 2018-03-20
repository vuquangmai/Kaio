Public Class AdminUrlEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindChannel()
            ' bindTypeOfMenu()
            BindParent(Me.DropDownListChannel_Id.SelectedItem.Value, Me.DropDownListTypeOfMenu.SelectedItem.Value)
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI MENU CHỨC NĂNG"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM MENU CHỨC NĂNG"
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
    Private Sub BindChannel()
        Dim sql As String = "SELECT * FROM System_Channel WHERE Channel_Status= 1 Order by Channel_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListChannel_Id.Items.Clear()
        Me.DropDownListChannel_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListChannel_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListChannel_Id.Items.Add(New ListItem(dt.Rows(i).Item("Channel_Text"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindParent(ByVal Channel_Id As Integer, ByVal Url_Level As Integer)
        Dim sql As String = "SELECT * FROM System_Url Where Url_Level=" & Url_Level - 1 & " And Is_Locked=0 And Channel_Id=" & Channel_Id & " Order by Url_Text"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListParent_Id.Items.Clear()
        Me.DropDownListParent_Id.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListParent_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListParent_Id.Items.Add(New ListItem(dt.Rows(i).Item("Url_Text") & "[" & dt.Rows(i).Item("ID") & "]", dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    'Private Sub BindTypeOfMenu()
    '    If Me.DropDownListTypeOfMenu.SelectedItem.Value = 2 Then
    '        Me.lblParent_Id.Visible = True
    '        Me.DropDownListParent_Id.Visible = True
    '    ElseIf Me.DropDownListTypeOfMenu.SelectedItem.Value = 1 Then
    '        Me.lblParent_Id.Visible = False
    '        Me.DropDownListParent_Id.Visible = False
    '        Me.DropDownListParent_Id.SelectedValue = 0
    '    End If
    'End Sub
    Protected Sub DropDownListTypeOfMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListTypeOfMenu.SelectedIndexChanged
        ' BindTypeOfMenu()
        BindParent(Me.DropDownListChannel_Id.SelectedItem.Value, Me.DropDownListTypeOfMenu.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListChannel_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListChannel_Id.SelectedIndexChanged
        BindParent(Me.DropDownListChannel_Id.SelectedItem.Value, Me.DropDownListTypeOfMenu.SelectedItem.Value)
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM System_Url Where Id=" & intId
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.txtUrl_Text.Text = dt.Rows(0).Item("Url_Text")
            Me.txtUrl_Id.Text = IIf(IsDBNull(dt.Rows(0).Item("Url_Id")) = True, "", dt.Rows(0).Item("Url_Id"))
            Me.txtUrl_Alias.Text = IIf(IsDBNull(dt.Rows(0).Item("Url_Alias")) = True, "", dt.Rows(0).Item("Url_Alias"))
            Me.DropDownListChannel_Id.SelectedValue = dt.Rows(0).Item("Channel_Id")
            'If dt.Rows(0).Item("Url_Level") = 2 Then
            '    Me.DropDownListTypeOfMenu.SelectedValue = 1
            'ElseIf dt.Rows(0).Item("Url_Level") = 3 Then
            '    Me.DropDownListTypeOfMenu.SelectedValue = 2
            '    Me.DropDownListParent_Id.SelectedValue = dt.Rows(0).Item("Parent_Id")
            'End If
            Me.DropDownListTypeOfMenu.SelectedValue = dt.Rows(0).Item("Url_Level")
            BindParent(Me.DropDownListChannel_Id.SelectedItem.Value, Me.DropDownListTypeOfMenu.SelectedItem.Value)
            Me.DropDownListParent_Id.SelectedValue = dt.Rows(0).Item("Parent_Id")
            ' bindTypeOfMenu()
            Me.DropDownListUrl_Order.SelectedValue = dt.Rows(0).Item("Url_Order")
            Me.DropDownListIs_Locked.SelectedValue = dt.Rows(0).Item("Is_Locked")
            If dt.Rows(0).Item("Url_Display") = 0 Then
                Me.CheckBoxUrl_Display.Checked = False
            Else
                Me.CheckBoxUrl_Display.Checked = True
            End If
            If dt.Rows(0).Item("Url_Privilege") = 0 Then
                Me.CheckBoxUrl_Privilege.Checked = False
            Else
                Me.CheckBoxUrl_Privilege.Checked = True
            End If
            If dt.Rows(0).Item("Url_Private") = 0 Then
                Me.CheckBoxUrl_Private.Checked = False
            Else
                Me.CheckBoxUrl_Private.Checked = True
            End If
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("Description")) = True, "", dt.Rows(0).Item("Description"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtUrl_Text.Text = "" Then
            Me.lblerror.Text = "Tên Menu không hợp lệ !"
            Exit Sub
        End If
        'If Me.DropDownListTypeOfMenu.SelectedItem.Value = 2 Then
        '    If Me.txtUrl_Id.Text = "" Then
        '        Me.lblerror.Text = "Url của Menu không hợp lệ !"
        '        Exit Sub
        '    End If
        'End If
        'If Me.DropDownListTypeOfMenu.SelectedItem.Value = 0 Then
        '    Me.lblerror.Text = "Loại Menu không hợp lệ !"
        'End If
        'If Me.DropDownListTypeOfMenu.SelectedItem.Value = 2 Then
        '    If Me.DropDownListParent_Id.SelectedValue = 0 Then
        '        Me.lblerror.Text = "Phải chọn Menu cha !"
        '        Exit Sub
        '    End If
        'End If

        If Me.DropDownListChannel_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Phải chọn kênh !"
            Exit Sub
        End If
        Dim Url_Text As String = Me.txtUrl_Text.Text.Trim
        Dim Url_Id As String = Me.txtUrl_Id.Text.Trim
        Dim Url_Alias As String = Me.txtUrl_Alias.Text.Trim
        Dim Parent_Id As Integer = 0
        Dim Url_Level As Integer = 0
        'Edit 20160815
        'If Me.DropDownListTypeOfMenu.SelectedItem.Value = 2 Then
        '    Parent_Id = Me.DropDownListParent_Id.SelectedItem.Value
        '    Url_Level = 3
        'Else
        '    Parent_Id = Me.DropDownListChannel_Id.SelectedItem.Value
        '    Url_Level = 2
        'End If
        Parent_Id = Me.DropDownListParent_Id.SelectedItem.Value
        Url_Level = Me.DropDownListTypeOfMenu.SelectedItem.Value
        'Edit 20160815

        Dim Channel_Id As Integer = Me.DropDownListChannel_Id.SelectedItem.Value
        Dim Url_Order As Integer = Me.DropDownListUrl_Order.SelectedItem.Value
        Dim Url_Display As Integer = IIf(Me.CheckBoxUrl_Display.Checked = True, 1, 0)
        Dim Url_Privilege As Integer = IIf(Me.CheckBoxUrl_Privilege.Checked = True, 1, 0)
        Dim Url_Private As Integer = IIf(Me.CheckBoxUrl_Private.Checked = True, 1, 0)
        Dim Is_Locked As Integer = Me.DropDownListIs_Locked.SelectedItem.Value
        Dim Description As String = Me.txtDescription.Text.Trim
        Dim sql As String
        If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
            sql = "Insert Into System_Url(Url_Text, Url_Id, Url_Alias,Parent_Id, Channel_Id, Url_Order, Url_Display, Url_Private, Url_Privilege, Url_Level, Is_Locked, Description)" & _
                "Values (N'" & Url_Text & "',N'" & Url_Id & "',N'" & Url_Alias & "',N'" & Parent_Id & "',N'" & Channel_Id & "',N'" & Url_Order & "',N'" & Url_Display & "',N'" & Url_Private & "',N'" & Url_Privilege & "',N'" & Url_Level & "',N'" & Is_Locked & "',N'" & Description & "')"
        ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
            sql = "Update System_Url Set Url_Text=N'" & Url_Text & "'," & _
            "Url_Id=N'" & Url_Id & "'," & _
            "Url_Alias=N'" & Url_Alias & "'," & _
            "Parent_Id=N'" & Parent_Id & "'," & _
            "Channel_Id=N'" & Channel_Id & "'," & _
            "Url_Order=N'" & Url_Order & "'," & _
            "Url_Display=N'" & Url_Display & "'," & _
            "Url_Private=N'" & Url_Private & "'," & _
            "Url_Privilege=N'" & Url_Privilege & "'," & _
            "Url_Level=N'" & Url_Level & "'," & _
            "Is_Locked=N'" & Is_Locked & "'," & _
            "Description=N'" & Description & "'" & _
            " Where Id=" & ViewState(ViewStateInfo.Object_Id)
        End If
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            RedirectUrl(Constants.Url._Admin.AdminUrlList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._Admin.AdminUrlList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Select * From  System_Url  where  Parent_Id =" & ViewState(ViewStateInfo.Object_Id)
        If IsCheckData(sql) = False Then
            Dim str As String = ""
            sql = "Delete From System_Url Where Id=" & ViewState(ViewStateInfo.Object_Id)
            Try
                MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                RedirectUrl(Constants.Url._Admin.AdminUrlList)
            Catch ex As Exception
                Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
            End Try
            Me.lblerror.Text = Constants.AlertInfo.ExistRecordDelete
            Exit Sub
        End If
    End Sub
#End Region
End Class