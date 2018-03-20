Public Class CCareCustomerInfo
    Inherits GlobalPage

#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    Me.lbltitle.Text = "THÔNG TIN KHÁCH HÀNG"
                    bindData(ViewState(ViewStateInfo.Object_Id))
                    ViewState(ViewStateInfo.Status) = Constants.Action.Update
                End If
            Else
                Me.lblerror.Text = "Thông tin không tồn tại !"
            End If
        End If
    End Sub
#End Region
 
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        Dim sql As String = "SELECT * FROM CCARE_CUSTOMER_IMPORT Where Id=" & intId
        Dim dt As DataTable = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
        If dt.Rows.Count > 0 Then
            Me.lblUSER_ID.Text = IIf(IsDBNull(dt.Rows(0).Item("USER_ID")) = True, "", dt.Rows(0).Item("USER_ID"))
            Me.lblMT.Text = IIf(IsDBNull(dt.Rows(0).Item("MT")) = True, "", dt.Rows(0).Item("MT"))
            Me.lblID.Text = IIf(IsDBNull(dt.Rows(0).Item("ID")) = True, "", dt.Rows(0).Item("ID"))
            Me.lblCUSTOMER_NAME.Text = IIf(IsDBNull(dt.Rows(0).Item("CUSTOMER_NAME")) = True, "", dt.Rows(0).Item("CUSTOMER_NAME"))
            Me.lblADDRESS.Text = IIf(IsDBNull(dt.Rows(0).Item("ADDRESS")) = True, "", dt.Rows(0).Item("ADDRESS"))
            Me.lblEMAIL_ADDRESS.Text = IIf(IsDBNull(dt.Rows(0).Item("EMAIL_ADDRESS")) = True, "", dt.Rows(0).Item("EMAIL_ADDRESS"))
            Me.lblBIRTH_DAY.Text = IIf(IsDBNull(dt.Rows(0).Item("BIRTH_DAY")) = True, "", dt.Rows(0).Item("BIRTH_DAY"))
            Me.lblPROVINCE_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("PROVINCE_TEXT")) = True, "", dt.Rows(0).Item("PROVINCE_TEXT"))
            Me.lblMOBILE_OPERATOR.Text = IIf(IsDBNull(dt.Rows(0).Item("MOBILE_OPERATOR")) = True, "", dt.Rows(0).Item("MOBILE_OPERATOR"))
            Me.lblPARTNER_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("PARTNER_TEXT")) = True, "", dt.Rows(0).Item("PARTNER_TEXT"))
            Me.lblBRAND_NAME.Text = IIf(IsDBNull(dt.Rows(0).Item("BRAND_NAME")) = True, "", dt.Rows(0).Item("BRAND_NAME"))
            Me.lblSEX_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("SEX_TEXT")) = True, "", dt.Rows(0).Item("SEX_TEXT"))
            Me.lblFIELD_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("FIELD_TEXT")) = True, "", dt.Rows(0).Item("FIELD_TEXT"))
            Me.lblSOURCE_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("SOURCE_TEXT")) = True, "", dt.Rows(0).Item("SOURCE_TEXT"))
            Me.lblEXACTLY_RATE.Text = IIf(IsDBNull(dt.Rows(0).Item("EXACTLY_RATE")) = True, "", dt.Rows(0).Item("EXACTLY_RATE"))
            Me.lblGROUP_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("GROUP_TEXT")) = True, "", dt.Rows(0).Item("GROUP_TEXT"))
            Me.lblREMARK.Text = IIf(IsDBNull(dt.Rows(0).Item("REMARK")) = True, "", dt.Rows(0).Item("REMARK"))
            Me.lblFEES_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("FEES_TEXT")) = True, "", dt.Rows(0).Item("FEES_TEXT"))
            Me.lblINCOME_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("INCOME_TEXT")) = True, "", dt.Rows(0).Item("INCOME_TEXT"))
            Me.lblKEY_WORD.Text = IIf(IsDBNull(dt.Rows(0).Item("KEY_WORD")) = True, "", dt.Rows(0).Item("KEY_WORD"))
            Me.lblSTATUS_TEXT.Text = IIf(IsDBNull(dt.Rows(0).Item("STATUS_TEXT")) = True, "", dt.Rows(0).Item("STATUS_TEXT"))
            bindData1(Me.lblUSER_ID.Text.Trim)
            bindData2(Me.lblUSER_ID.Text.Trim)
            bindData3(Me.lblUSER_ID.Text.Trim)
        End If
    End Sub
#End Region
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
        Dim sql As String = "SELECT * From  CCARE_CUSTOMER_VERIFY_1  Where  upper(USER_ID)='" & User_Id.ToUpper & "'"
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
End Class