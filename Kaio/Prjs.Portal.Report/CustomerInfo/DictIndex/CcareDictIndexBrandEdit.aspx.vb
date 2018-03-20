Public Class CcareDictIndexBrandEdit
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            BindProvince()
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN BRAND NAME"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                Else
                    Me.lbltitle.Text = "THÊM THÔNG TIN BRAND NAME"
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
#Region "Dict Index"
    Private Sub BindProvince()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PARTNER Order by PARTNER_TEXT"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPARTNER_ID.Items.Clear()
        Me.DropDownListPARTNER_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPARTNER_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPARTNER_ID.Items.Add(New ListItem(dt.Rows(i).Item("PARTNER_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND Where Id=" & intId
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListPARTNER_ID.SelectedValue = dt.Rows(0).Item("PARTNER_ID")
            Me.txtBRAND_NAME.Text = dt.Rows(0).Item("BRAND_NAME")
            Me.DropDownListSTATUS_ID.SelectedValue = dt.Rows(0).Item("STATUS_ID")
            Me.txtDescription.Text = IIf(IsDBNull(dt.Rows(0).Item("DESCRIPTION")) = True, "", dt.Rows(0).Item("DESCRIPTION"))
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.DropDownListPARTNER_ID.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Đối tác không hợp lệ !"
            Exit Sub
        End If
        If Me.txtBRAND_NAME.Text = "" Then
            Me.lblerror.Text = "Quận, Huyện không hợp lệ !"
            Exit Sub
        End If
        Dim PARTNER_ID As Integer = Me.DropDownListPARTNER_ID.SelectedItem.Value
        Dim PARTNER_TEXT As String = Me.DropDownListPARTNER_ID.SelectedItem.Text
        Dim BRAND_NAME As String = Me.txtBRAND_NAME.Text.Trim
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
        ' sql = "SELECT * From  CCARE_DICTINDEX_BRAND  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And upper(BRAND_NAME)='" & BRAND_NAME.ToUpper & "'"
        'If Me.B2CCheckData(sql) = False Then
        If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
            retval = UpdateObject.B2CManagement.InsertDictIndexBrand(PARTNER_ID, PARTNER_TEXT, BRAND_NAME, STATUS_ID, STATUS_TEXT, CREATE_BY_ID, CREATE_BY_TEXT, CREATE_TIME, UPDATE_BY_ID, UPDATE_BY_TEXT, UPDATE_TIME, DESCRIPTION)
        ElseIf ViewState(ViewStateInfo.Status) = Constants.Action.Update Then
            retval = UpdateObject.B2CManagement.UpdateDictIndexBrand(ViewState(ViewStateInfo.Object_Id), PARTNER_ID, PARTNER_TEXT, BRAND_NAME, STATUS_ID, STATUS_TEXT, UPDATE_BY_ID, UPDATE_BY_TEXT, UPDATE_TIME, DESCRIPTION)
        End If
        If retval = "" Then
            RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexBrandList)
        Else
            Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & retval
            Exit Sub
        End If
        'Else
        ' Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
        'Exit Sub
        'End If
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexBrandList)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete  From  CCARE_DICTINDEX_BRAND  Where  Id =" & ViewState(ViewStateInfo.Object_Id)
        Try
            OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            RedirectUrl(Constants.Url._CcareB2C.CcareDictIndexBrandList)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region
End Class