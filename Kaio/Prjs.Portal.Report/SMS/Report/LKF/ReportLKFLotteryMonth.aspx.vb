Imports System.Data.SqlClient

Public Class ReportLKFLotteryMonth
    Inherits GlobalPage
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU THEO THÁNG"
            BindCompanyId(Me.DropDownListRegion_Id.SelectedItem.Value)
        End If

    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindCompanyId(ByVal Region_Id As Integer)
        Dim sql As String = "Select * From SMS_DictIndex_Lottery_Company Where Id >0 "
        If Region_Id > 0 Then
            sql = sql & " And Region_Id=" & Region_Id
        End If
        sql = sql & " Order by Company_Text "
        Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
        Me.DropDownListCompany_Id.Items.Clear()
        Me.DropDownListCompany_Id.Items.Add(New ListItem("--all--", 0))
        Me.DropDownListCompany_Id.SelectedValue = 0
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.DropDownListCompany_Id.Items.Add(New ListItem(dt.Rows(i).Item("Company_Text"), dt.Rows(i).Item("Id")))
            Next
        End If
    End Sub
#End Region
#Region "Ajax"
    Protected Sub DropDownListRegion_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListRegion_Id.SelectedIndexChanged
        BindCompanyId(Me.DropDownListRegion_Id.SelectedItem.Value)
    End Sub
    Protected Sub DropDownListCompany_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListCompany_Id.SelectedIndexChanged
        bindData(Me.DropDownListCompany_Id.SelectedItem.Value)
    End Sub
#End Region
#Region "Submit"
    Protected Sub btnExpot_Click(sender As Object, e As EventArgs) Handles btnExpot.Click
        If Me.DropDownListRegion_Id.SelectedItem.Value = 0 Then
            Me.lblerror.Text = "Vùng/Miền không hợp lệ !"
            Exit Sub
        End If
        ExportData.ExportExcel._LKF.MonthReportAll(Me.DropDownListYear.SelectedItem.Value, Me.DropDownListRegion_Id.SelectedItem.Value, Me.DropDownListCompany_Id.SelectedItem.Value)
      
    End Sub
#End Region
#Region "Bind Data"
    Private Sub bindData(ByVal intId As Integer)
        If intId > 0 Then
            Dim sql As String = "SELECT Id, Region_Id, Region_Text, Company_Text, Date_Result_Id, Date_Result_Text, Create_By_Id, Create_By_Text, Create_Time, Update_By_Id,Update_By_Text,Update_Time,Description" & _
           " FROM SMS_DictIndex_Lottery_Company Where Id=" & intId
            Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt.Rows.Count > 0 Then
                Me.DropDownListRegion_Id.SelectedValue = dt.Rows(0).Item("Region_Id")
            End If
            
        End If
    End Sub
#End Region
End Class