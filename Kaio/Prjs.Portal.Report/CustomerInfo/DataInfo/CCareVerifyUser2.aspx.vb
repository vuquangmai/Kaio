Public Class CCareVerifyUser2
    Inherits GlobalPage
    Public Utils As New Util.Encrypt

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            BindDictIndex()
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "SỬA ĐỔI THÔNG TIN KHÁCH HÀNG"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.CheckBoxDel.Enabled = IsDelete
            Me.btnDelete.Visible = IsDelete
            If ViewState(ViewStateInfo.Status) = Constants.Action.Insert Then
                Me.btnDelete.Visible = False
            End If
        End If
        Me.btnDelete.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
    End Sub
#End Region
#Region "Dict Index"
    Private Sub BindDictIndex()
        BindPartner()
        BindProvince()
        BindSource()
        BindFees()
        BindField()
        BindIncome()
        BindBirthday()
        BindExactlyRate()
    End Sub
    Private Sub BindPartner()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PARTNER Where STATUS_ID=1 Order by upper(PARTNER_TEXT)"
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
    Private Sub BindBrand(ByVal PARTNER_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_BRAND  Where STATUS_ID=1 And PARTNER_ID=" & PARTNER_ID & " Order by upper(BRAND_NAME)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListBRAND_NAME.Items.Clear()
        Me.DropDownListBRAND_NAME.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListBRAND_NAME.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListBRAND_NAME.Items.Add(New ListItem(dt.Rows(i).Item("BRAND_NAME"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindProvince()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_PROVINCE  Where STATUS_ID=1 Order by (PROVINCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListPROVINCE_ID.Items.Clear()
        Me.DropDownListPROVINCE_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListPROVINCE_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListPROVINCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("PROVINCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindSource()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_SOURCE  Where STATUS_ID=1 Order by upper(SOURCE_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListSOURCE_ID.Items.Clear()
        Me.DropDownListSOURCE_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListSOURCE_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListSOURCE_ID.Items.Add(New ListItem(dt.Rows(i).Item("SOURCE_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindFees()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FEES  Where STATUS_ID=1 Order by upper(FEES_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListFEES_ID.Items.Clear()
        Me.DropDownListFEES_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListFEES_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListFEES_ID.Items.Add(New ListItem(dt.Rows(i).Item("FEES_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindField()
      Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_FIELD  Where STATUS_ID=1 Order by upper(FIELD_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.CheckBoxListFIELD_ID.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.CheckBoxListFIELD_ID.Items.Add(New ListItem(dt.Rows(i).Item("FIELD_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindIncome()
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_INCOME  Where STATUS_ID=1 Order by upper(INCOME_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListINCOME_ID.Items.Clear()
        Me.DropDownListINCOME_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListINCOME_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListINCOME_ID.Items.Add(New ListItem(dt.Rows(i).Item("INCOME_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
    Private Sub BindBirthday()
        Me.DropDownListYEAR.Items.Clear()
        Me.DropDownListMONTH.Items.Clear()
        Me.DropDownListDAY.Items.Clear()
        Me.DropDownListYEAR.Items.Add(New ListItem("NA", "NA"))
        Me.DropDownListMONTH.Items.Add(New ListItem("NA", "NA"))
        Me.DropDownListDAY.Items.Add(New ListItem("NA", "NA"))

        For i As Integer = 1940 To 2012
            Me.DropDownListYEAR.Items.Add(New ListItem(i, i))
        Next
        For j As Integer = 1 To 12
            Me.DropDownListMONTH.Items.Add(New ListItem(Util.StringBuilder.ConvertDigit(j), Util.StringBuilder.ConvertDigit(j)))
        Next
        For k As Integer = 1 To 31
            Me.DropDownListDAY.Items.Add(New ListItem(Util.StringBuilder.ConvertDigit(k), Util.StringBuilder.ConvertDigit(k)))
        Next

    End Sub
    Private Sub BindExactlyRate()
        Me.DropDownListEXACTLY_RATE.Items.Clear()
        For i As Integer = 0 To 100 Step 10
            Me.DropDownListEXACTLY_RATE.Items.Add(New ListItem(i, i))
        Next
    End Sub
    Private Sub BindDistrict(ByVal PROVINCE_ID As Integer)
        Dim sql As String = "SELECT * FROM CCARE_DICTINDEX_DISTRICT  Where STATUS_ID=1 And PROVINCE_ID=" & PROVINCE_ID & " Order by upper(DISTRICT_TEXT)"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        Me.DropDownListDISTRICT_ID.Items.Clear()
        Me.DropDownListDISTRICT_ID.Items.Add(New ListItem("--Chọn--", 0))
        Me.DropDownListDISTRICT_ID.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListDISTRICT_ID.Items.Add(New ListItem(dt.Rows(i).Item("DISTRICT_TEXT"), dt.Rows(i).Item("ID")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM CCARE_CUSTOMER_VERIFY_1 Where Id=" & intId
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.txtUSER_ID.Text = IIf(IsDBNull(dt.Rows(0).Item("USER_ID")) = True, "", dt.Rows(0).Item("USER_ID"))
            Me.txtMT.Text = IIf(IsDBNull(dt.Rows(0).Item("MT")) = True, "", dt.Rows(0).Item("MT"))
            Me.txtCUSTOMER_CODE.Text = IIf(IsDBNull(dt.Rows(0).Item("ID")) = True, "", dt.Rows(0).Item("ID"))
            Me.txtCUSTOMER_NAME.Text = IIf(IsDBNull(dt.Rows(0).Item("CUSTOMER_NAME")) = True, "", dt.Rows(0).Item("CUSTOMER_NAME"))
            Me.txtADDRESS.Text = IIf(IsDBNull(dt.Rows(0).Item("ADDRESS")) = True, "", dt.Rows(0).Item("ADDRESS"))
            Me.txtEMAIL_ADDRESS.Text = IIf(IsDBNull(dt.Rows(0).Item("EMAIL_ADDRESS")) = True, "", dt.Rows(0).Item("EMAIL_ADDRESS"))
            Dim splitout = Split(dt.Rows(0).Item("BIRTH_DAY").ToString.Trim, "/")
            For i As Integer = 0 To UBound(splitout)
                Select Case i
                    Case 0
                        Me.DropDownListDAY.SelectedValue = splitout(i) 'ds.Tables(0).Rows(0).Item("DATE_OF_BIRTH").Substring(0, 2)
                    Case 1
                        Me.DropDownListMONTH.SelectedValue = splitout(i) ' ds.Tables(0).Rows(0).Item("DATE_OF_BIRTH").Substring(3, 2)
                    Case 2
                        Me.DropDownListYEAR.SelectedValue = splitout(i) 'ds.Tables(0).Rows(0).Item("DATE_OF_BIRTH").Substring(6, 4)
                End Select
            Next
            Me.DropDownListPROVINCE_ID.SelectedValue = dt.Rows(0).Item("PROVINCE_ID")
            Me.DropDownListMOBILE_OPERATOR.SelectedValue = dt.Rows(0).Item("MOBILE_OPERATOR")
            Me.DropDownListPARTNER_ID.SelectedValue = dt.Rows(0).Item("PARTNER_ID")
            BindBrand(Me.DropDownListPARTNER_ID.SelectedItem.Value)
            Me.DropDownListBRAND_NAME.SelectedValue = dt.Rows(0).Item("BRAND_ID")
            splitout = Split(dt.Rows(0).Item("FIELD_ID").ToString.Trim, ";")
            For i As Integer = 0 To UBound(splitout)
                If IsNumeric(splitout(i)) = True Then
                    Try
                        If splitout(i) > 0 Then
                            Me.CheckBoxListFIELD_ID.Items.FindByValue(splitout(i)).Selected = True
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Next
            Me.DropDownListEXACTLY_RATE.SelectedValue = dt.Rows(0).Item("EXACTLY_RATE")
            Me.txtREMARK.Text = IIf(IsDBNull(dt.Rows(0).Item("REMARK")) = True, "", dt.Rows(0).Item("REMARK"))
            Me.DropDownListSOURCE_ID.SelectedValue = dt.Rows(0).Item("SOURCE_ID")
            Me.DropDownListFEES_ID.SelectedValue = dt.Rows(0).Item("FEES_ID")
            Me.DropDownListINCOME_ID.SelectedValue = dt.Rows(0).Item("INCOME_ID")
            Me.DropDownListSEX.SelectedValue = dt.Rows(0).Item("SEX_ID")
            Me.txtKEY_WORD.Text = IIf(IsDBNull(dt.Rows(0).Item("KEY_WORD")) = True, "", dt.Rows(0).Item("KEY_WORD"))
            Me.txtGROUP_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("GROUP_TEXT")) = True, "", dt.Rows(0).Item("GROUP_TEXT"))
            Me.DropDownListSTATUS_ID.SelectedValue = dt.Rows(0).Item("STATUS_ID")
            bindData1(Me.txtUSER_ID.Text.Trim)
            bindData2(Me.txtUSER_ID.Text.Trim)
            bindData3(Me.txtUSER_ID.Text.Trim)
        End If
    End Sub
    Private Sub bindData1(User_Id As String)
        Dim sql As String = "SELECT * From  CCARE_CUSTOMER_INFO  Where  upper(USER_ID)='" & User_Id.ToUpper & "'"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid_1.DataSource = dt
            Me.DataGrid_1.DataBind()
            Me.DataGrid_1.Visible = True
        Else
            Me.DataGrid_1.Visible = False
        End If
    End Sub
    Private Sub bindData2(User_Id As String)
        Dim sql As String = "SELECT * From  CCARE_CUSTOMER_VERIFY_1  Where   Id <>" & ViewState(ViewStateInfo.Object_Id) & " And  upper(USER_ID)='" & User_Id.ToUpper & "'"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid_2.DataSource = dt
            Me.DataGrid_2.DataBind()
            Me.DataGrid_2.Visible = True
        Else
            Me.DataGrid_2.Visible = False
        End If
    End Sub
    Private Sub bindData3(User_Id As String)
        Dim sql As String = "SELECT * From  CCARE_CUSTOMER_IMPORT  Where    upper(USER_ID)='" & User_Id.ToUpper & "'"
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGrid_3.DataSource = dt
            Me.DataGrid_3.DataBind()
            Me.DataGrid_3.Visible = True
        Else
            Me.DataGrid_3.Visible = False
        End If
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        If Me.txtUSER_ID.Text.Trim = "" Then
            Me.lblerror.Text = "Số điện thoại không hợp lệ !"
            Exit Sub
        End If
        If Me.DropDownListSTATUS_ID.SelectedItem.Value = "--Chọn--" Then
            Me.lblerror.Text = "Trạng thái không hợp lệ !"
            Exit Sub
        End If
        Dim USER_ID As String = Me.txtUSER_ID.Text.Trim
        Dim STATUS_ID As Integer = Me.DropDownListSTATUS_ID.SelectedItem.Value
        Dim STATUS_TEXT As String = Me.DropDownListSTATUS_ID.SelectedItem.Text
        Dim GROUP_TEXT As String = Me.txtGROUP_TEXT.Text.Trim
        Dim MT As String = Me.txtMT.Text.Trim
        Dim BRAND_ID As Integer = 0
        Dim BRAND_NAME As String = ""
        If Me.DropDownListBRAND_NAME.SelectedItem.Text <> "--Chọn--" Then
            BRAND_ID = Me.DropDownListBRAND_NAME.SelectedItem.Value
            BRAND_NAME = Me.DropDownListBRAND_NAME.SelectedItem.Text.Trim
        End If
        Dim PROVINCE_ID As Integer = 0
        Dim PROVINCE_TEXT As String = ""
        If Me.DropDownListPROVINCE_ID.SelectedItem.Value > 0 Then
            PROVINCE_ID = Me.DropDownListPROVINCE_ID.SelectedItem.Value
            PROVINCE_TEXT = Me.DropDownListPROVINCE_ID.SelectedItem.Text.Trim
        End If
        Dim DISTRICT_ID As Integer = 0
        Dim DISTRICT_TEXT As String = ""
        If Me.DropDownListDISTRICT_ID.SelectedItem.Value > 0 Then
            DISTRICT_ID = Me.DropDownListDISTRICT_ID.SelectedItem.Value
            DISTRICT_TEXT = Me.DropDownListDISTRICT_ID.SelectedItem.Text.Trim
        End If
        Dim PARTNER_ID As Integer = 0
        Dim PARTNER_TEXT As String = ""
        If Me.DropDownListPARTNER_ID.SelectedItem.Value > 0 Then
            PARTNER_ID = Me.DropDownListPARTNER_ID.SelectedItem.Value
            PARTNER_TEXT = Me.DropDownListPARTNER_ID.SelectedItem.Text.Trim
        End If
        Dim SEX_ID As Integer = 0
        Dim SEX_TEXT As String = ""
        If Me.DropDownListSEX.SelectedItem.Value > 0 Then
            SEX_ID = Me.DropDownListSEX.SelectedItem.Value
            SEX_TEXT = Me.DropDownListSEX.SelectedItem.Text
        End If
        Dim FIELD_ID As String = 0
        Dim FIELD_TEXT As String = ""
        For i As Integer = 0 To Me.CheckBoxListFIELD_ID.Items.Count - 1
            If CheckBoxListFIELD_ID.Items(i).Selected = True Then
                If FIELD_TEXT.Trim = "" Then
                    FIELD_TEXT = Me.CheckBoxListFIELD_ID.Items(i).Text
                    FIELD_ID = Me.CheckBoxListFIELD_ID.Items(i).Value & ";"
                Else
                    FIELD_TEXT = FIELD_TEXT & ";" & Me.CheckBoxListFIELD_ID.Items(i).Text
                    FIELD_ID = FIELD_ID & Me.CheckBoxListFIELD_ID.Items(i).Value & ";"
                End If
            End If
        Next
        Dim SOURCE_ID As Integer = 0
        Dim SOURCE_TEXT As String = ""
        If Me.DropDownListSOURCE_ID.SelectedItem.Value > 0 Then
            SOURCE_ID = Me.DropDownListSOURCE_ID.SelectedItem.Value
            SOURCE_TEXT = Me.DropDownListSOURCE_ID.SelectedItem.Text.Trim
        End If
        Dim KEY_WORD As String = Me.txtKEY_WORD.Text.Trim
        Dim REMARK As String = Me.txtREMARK.Text.Trim
        Dim CUSTOMER_CODE As String = Me.txtCUSTOMER_CODE.Text.Trim
        Dim CUSTOMER_NAME As String = Me.txtCUSTOMER_NAME.Text.Trim
        Dim BIRTH_DAY As String = Me.DropDownListDAY.SelectedItem.Value & "/" & Me.DropDownListMONTH.SelectedItem.Value & "/" & Me.DropDownListYEAR.SelectedItem.Value
        Dim ADDRESS As String = Me.txtADDRESS.Text.Trim
        Dim EMAIL_ADDRESS As String = Me.txtEMAIL_ADDRESS.Text.Trim
        Dim FEES_ID As Integer = 0
        Dim FEES_TEXT As String = ""
        If Me.DropDownListFEES_ID.SelectedItem.Value > 0 Then
            FEES_ID = Me.DropDownListFEES_ID.SelectedItem.Value
            FEES_TEXT = Me.DropDownListFEES_ID.SelectedItem.Text.Trim
        End If
        Dim INCOME_ID As Integer = 0
        Dim INCOME_TEXT As String = ""
        If Me.DropDownListINCOME_ID.SelectedItem.Value > 0 Then
            INCOME_ID = Me.DropDownListINCOME_ID.SelectedItem.Value
            INCOME_TEXT = Me.DropDownListINCOME_ID.SelectedItem.Text.Trim
        End If
        Dim EXACTLY_RATE As String = Me.DropDownListEXACTLY_RATE.SelectedItem.Value
        Dim MOBILE_OPERATOR As String = Me.DropDownListMOBILE_OPERATOR.SelectedItem.Value
        Dim IS_VERIFY_1 As Integer = 0
        Dim VERIFY_BY_1_ID As Integer = 0
        Dim VERIFY_BY_1_TEXT As String = ""
        Dim VERIFY_TIME_1 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_2 As Integer = 0
        Dim VERIFY_BY_2_ID As Integer = 0
        Dim VERIFY_BY_2_TEXT As String = ""
        Dim VERIFY_TIME_2 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim IS_VERIFY_3 As Integer = 0
        Dim VERIFY_BY_3_ID As Integer = 0
        Dim VERIFY_BY_3_TEXT As String = ""
        Dim VERIFY_TIME_3 As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")

        Dim KEY_IMPORT As String = ""
        Dim FILE_IMPORT As String = ""
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim LOGER_INFO As String = "- " & DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss") & ", " & _
                                                                       CurrentUser.UserName & "(" & CurrentUser.UserFullName & ") Gọi điện xác minh thông tin khách hàng <br>"
        Dim sql As String = ""
        Dim retval As String = ""
        retval = UpdateObject.B2CManagement.UpdateVerify_1(ViewState(ViewStateInfo.Object_Id), _
                                                                                                         USER_ID, _
                                                                                                         STATUS_ID, _
                                                                                                         STATUS_TEXT, _
                                                                                                         GROUP_TEXT, _
                                                                                                         MT, _
                                                                                                         BRAND_ID, _
                                                                                                         BRAND_NAME, _
                                                                                                         PARTNER_ID, _
                                                                                                         PARTNER_TEXT, _
                                                                                                         PROVINCE_ID, _
                                                                                                         PROVINCE_TEXT, _
                                                                                                         DISTRICT_ID, _
                                                                                                         DISTRICT_TEXT, _
                                                                                                         SEX_ID, _
                                                                                                         SEX_TEXT, _
                                                                                                         FIELD_ID, _
                                                                                                         FIELD_TEXT, _
                                                                                                         SOURCE_ID, _
                                                                                                         SOURCE_TEXT, _
                                                                                                         KEY_WORD, _
                                                                                                         REMARK, _
                                                                                                         CUSTOMER_CODE, _
                                                                                                         CUSTOMER_NAME, _
                                                                                                         BIRTH_DAY, _
                                                                                                         ADDRESS, _
                                                                                                         EMAIL_ADDRESS, _
                                                                                                         FEES_ID, _
                                                                                                         FEES_TEXT, _
                                                                                                          INCOME_ID, _
                                                                                                          INCOME_TEXT, _
                                                                                                         EXACTLY_RATE, _
                                                                                                         MOBILE_OPERATOR, _
                                                                                                         UPDATE_BY_ID, _
                                                                                                         UPDATE_BY_TEXT, _
                                                                                                         UPDATE_TIME, _
                                                                                                         LOGER_INFO
                                                                                                    )
        If retval = "" Then
            Me.lblerror.Text = "Cập nhật thông tin khách hàng thành công."
            If Me.CheckBoxMove.Checked = True Then
                sql = "SELECT * From  CCARE_CUSTOMER_INFO  Where   upper(USER_ID)='" & USER_ID.ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then
                    retval = UpdateObject.B2CManagement.MoveVerify_1_To_Info(ViewState(ViewStateInfo.Object_Id))
                    If retval = "" Then
                        Me.lblerror.Text = Me.lblerror.Text & "<br>Chuyển thông tin khách hàng thành công."
                    End If
                Else
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Thông tin khách hàng này đã tồn tại trong bảng chính."
                End If
            End If
            If Me.CheckBoxDel.Checked = True Then
                sql = "Delete  From  CCARE_CUSTOMER_VERIFY_1  Where  Id =" & ViewState(ViewStateInfo.Object_Id)
                Try
                    OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu bảng gọi thành công."
                Catch ex As Exception
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu bảng gọi."
                End Try
            End If
            If Me.CheckBoxDelTheSame.Checked = True Then
                sql = "Delete  From  CCARE_CUSTOMER_IMPORT  Where  USER_ID ='" & USER_ID & "'"
                Try
                    OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Xóa dữ liệu liên quan thành công."
                Catch ex As Exception
                    Me.lblerror.Text = Me.lblerror.Text & "<br>Lỗi xóa dữ liệu liên quan."
                End Try
            End If
            'RedirectUrl(Constants.Url._CcareB2C.CCareVerifyUser1List)
        Else
            Me.lblerror.Text = "Lỗi thao tác dữ liệu. Mã lỗi: " & retval
            Exit Sub
        End If
       
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._CcareB2C.CCareVerifyUser1List)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Dim sql As String = "Delete  From  CCARE_CUSTOMER_VERIFY_1  Where  Id =" & ViewState(ViewStateInfo.Object_Id)
        Try
            OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            RedirectUrl(Constants.Url._CcareB2C.CCareVerifyUser1List)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try

    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListPARTNER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPARTNER_ID.SelectedIndexChanged
        BindBrand(Me.DropDownListPARTNER_ID.SelectedItem.Value)
    End Sub
    Protected Sub txtUSER_ID_TextChanged(sender As Object, e As EventArgs) Handles txtUSER_ID.TextChanged
        Dim vPhone As String = Me.txtUSER_ID.Text.Trim
        If vPhone.StartsWith(0) = True Then
            vPhone = "84" & vPhone.Substring(1)
        ElseIf vPhone.StartsWith(84) = False Then
            vPhone = "84" & vPhone
        End If
        Me.txtUSER_ID.Text = vPhone
        Dim MobileOperator As String = Util.FormatOperator(vPhone)
        Me.DropDownListMOBILE_OPERATOR.SelectedValue = MobileOperator
    End Sub
    Protected Sub DropDownListSTATUS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListSTATUS_ID.SelectedIndexChanged
        If Me.DropDownListSTATUS_ID.SelectedItem.Value = 4 Then
            Me.CheckBoxMove.Checked = True
        End If
    End Sub
    Protected Sub DropDownListPROVINCE_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListPROVINCE_ID.SelectedIndexChanged
        BindDistrict(Me.DropDownListPROVINCE_ID.SelectedItem.Value)
    End Sub
#End Region

   
End Class