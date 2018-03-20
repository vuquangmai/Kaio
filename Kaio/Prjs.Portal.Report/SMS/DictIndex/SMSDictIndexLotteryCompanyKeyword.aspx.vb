Imports System.Data.SqlClient

Public Class SMSDictIndexLotteryCompanyKeyword
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindDictIndex()
            ViewState(ViewStateInfo.Object_Id) = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objid")))
            ViewState("Company_Text") = Util.Encrypt.DecryptText(Util.DefaultObject.IsNothing(Request.QueryString("objtext")))
            Me.lblCompanyText.Text = ViewState("Company_Text").ToString.ToUpper
            If IsNumeric(ViewState(ViewStateInfo.Object_Id)) Then
                If ViewState(ViewStateInfo.Object_Id) > 0 Then
                    bindData(ViewState(ViewStateInfo.Object_Id))
                End If
            End If
            IsPrivilegeOnMenu()
            Me.btnUpdate.Visible = IsUpdate
            Me.btnDelete.Visible = IsDelete
            Me.lbltitle.Text = "QUẢN LÝ MÃ THEO CÔNG TY XỔ SỐ"
        End If
        BindConfig()
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGridConfig.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindDictIndex()
        BindShortCode(Me.DropDownListRangeShortCode.SelectedItem.Value)
    End Sub
    Private Sub BindShortCode(Range_Of_Short_Code As String)
        Dim sql As String = "SELECT * FROM SMS_DictIndex_Short_Code  Where Id>0 "
        If Range_Of_Short_Code <> "--all--" Then
            sql = sql & "  And  Range_Of_Short_Code='" & Range_Of_Short_Code & "'"
        End If
        sql = sql & "  Order by Short_Code"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListShortCode.Items.Clear()
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListShortCode.Items.Add(New ListItem(dt.Rows(i).Item("Short_Code"), dt.Rows(i).Item("Short_Code")))
            Next
        End If
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(Company_Id As Integer)
        Dim sql As String = "Select * From SMS_DictIndex_Lottery_Company_Keyword Where Company_Id='" & Company_Id & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGridConfig.DataSource = dt
            Me.DataGridConfig.DataBind()
            Me.DataGridConfig.Visible = True
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGridConfig.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGridConfig.Visible = False
        End If
    End Sub
#End Region
 
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateConfig()
        BindConfig()
    End Sub
    Private Sub UpdateConfig()
        If Me.txtKeyword.Text = "" Then
            Me.lblerror.Text = "Mã dịch vụ không hợp lệ !"
            Exit Sub
        End If
        Dim cmd As New SqlCommand
        With cmd
            .Parameters.Clear()
            .Connection = GlobalConnection
            .CommandText = "SMS_Update_Lottery_Company_Keyword"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(New SqlParameter("@Company_Id", SqlDbType.Int))
            .Parameters.Item("@Company_Id").Value = ViewState(ViewStateInfo.Object_Id)

            .Parameters.Add(New SqlParameter("@Company_Text", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Company_Text").Value = ViewState("Company_Text")

            .Parameters.Add(New SqlParameter("@Short_Code", SqlDbType.NVarChar, 100))
            .Parameters.Item("@Short_Code").Value = Me.DropDownListShortCode.SelectedItem.Text.Trim

            .Parameters.Add(New SqlParameter("@Key_Word", SqlDbType.NVarChar, 4000))
            .Parameters.Item("@Key_Word").Value = Me.txtKeyword.Text.Trim
            Try
                .ExecuteNonQuery()
                Me.lblerror.Text = "Thêm dữ liệu thành công !"
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
            End Try
        End With
    End Sub
    Private Sub BindConfig()
        Dim sql As String = "SELECT Id,Company_Id,Company_Text,Short_Code,CASE WHEN len(Key_Word)>50 THEN substring(Key_Word,1,50)+'...' ELSE Key_Word END AS Key_Word " & _
            " FROM SMS_DictIndex_Lottery_Company_Keyword " & _
            " Where Company_Id='" & ViewState(ViewStateInfo.Object_Id) & "'"
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DataGridConfig.DataSource = dt
            Me.DataGridConfig.DataBind()
            Me.DataGridConfig.Visible = True
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGridConfig.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGridConfig.Visible = False
        End If
    End Sub
    Sub DelConfig(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete From SMS_DictIndex_Lottery_Company_Keyword Where Id=" & CType(e.CommandArgument, Integer)
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            BindConfig()
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi xóa dữ liệu. Mã lỗi: " & ex.Message
        End Try
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGridConfig.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
    Sub EditConfig(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Select *  From SMS_DictIndex_Lottery_Company_Keyword Where Id=" & CType(e.CommandArgument, Integer)
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        If dt.Rows.Count > 0 Then
            Me.DropDownListShortCode.SelectedValue = dt.Rows(0).Item("Short_Code")
            Me.txtKeyword.Text = dt.Rows(0).Item("Key_Word")
        End If
    End Sub

    Protected Sub DropDownListRangeShortCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRangeShortCode.SelectedIndexChanged
        BindShortCode(DropDownListRangeShortCode.SelectedItem.Value)

    End Sub
End Class