Imports System.Data.SqlClient
Public Class ReportLKFLotteryCycle
    Inherits GlobalPage
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO DOANH THU THEO KỲ PHÁT HÀNH VÉ"
            BindCompanyId(Me.DropDownListRegion_Id.SelectedItem.Value)
        End If
    End Sub
#End Region
#Region "DictIndex"
    Private Sub BindCompanyId(ByVal Region_Id As Integer)
        Dim sql As String = "Select * From SMS_DictIndex_Lottery_Company Where Id not In (" & Constants.Company.CompanyId._MienBacKhac & "," & Constants.Company.CompanyId._MienNam & "," & Constants.Company.CompanyId._MienTrung & "," & Constants.Company.CompanyId._MienBac & "," & Constants.Company.CompanyId._ThuDo & ")"
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
        'If Me.DropDownListCompany_Id.SelectedItem.Value < 0 Then
        '    Me.lblerror.Text = "Công ty xổ số không hợp lệ !"
        '    Exit Sub
        'End If
        ExportData.ExportExcel._LKF.CycleReportAll(Me.DropDownListYear.SelectedItem.Value, Me.DropDownListRegion_Id.SelectedItem.Value, Me.DropDownListCompany_Id.SelectedItem.Value)
        'Dim CompanyText As String = IsDataTable(Me.DropDownListCompany_Id.SelectedItem.Value) ' Util.RemoveAccented(Me.DropDownListCompany_Id.SelectedItem.Text.ToString.Replace(" ", ""))
        'ExportData.ExportExcel._LKF.CycleReport(Me.DropDownListYear.SelectedItem.Value, Me.DropDownListCompany_Id.SelectedItem.Value, CompanyText)
        'Dim FilePath As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/" & CompanyText
        'Dim FileCreate As String = CreateFilexls.SMS.LKF.CycleReport(Me.DropDownListYear.SelectedItem.Value, Me.DropDownListCompany_Id.SelectedItem.Value, FilePath)
        'Me.lblerror.Text = FileCreate
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
                Dim splitout = Split(dt.Rows(0).Item("Date_Result_Id").ToString.Trim, ";")
                For k As Integer = 0 To Me.CheckBoxListDateResult.Items.Count - 1
                    Me.CheckBoxListDateResult.Items.Item(k).Selected = False
                Next
                For i As Integer = 0 To UBound(splitout)
                    If IsNumeric(splitout(i)) = True Then
                        Me.CheckBoxListDateResult.Items.FindByValue(splitout(i)).Selected = True
                    End If
                Next
            End If
            sql = "Select * from SMS_LKF_Month_Cycle Where Year=" & Me.DropDownListYear.SelectedItem.Value & " And Company_Id=" & Me.DropDownListCompany_Id.SelectedItem.Value
            Dim dt1 As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            If dt1.Rows.Count > 0 Then
                Me.lblTotalCycle.Text = dt1.Rows(0).Item("Total")
                Me.lblTotalCycleMonth.Text = "Tháng 1: " & dt1.Rows(0).Item("T1") & _
                    "; Tháng 2: " & dt1.Rows(0).Item("T2") & _
                    "; Tháng 3: " & dt1.Rows(0).Item("T3") & _
                    "; Tháng 4: " & dt1.Rows(0).Item("T4") & _
                    "; Tháng 5: " & dt1.Rows(0).Item("T5") & _
                    "; Tháng 6: " & dt1.Rows(0).Item("T6") & _
                    "; Tháng 7: " & dt1.Rows(0).Item("T7") & _
                    "; Tháng 8: " & dt1.Rows(0).Item("T8") & _
                    "; Tháng 9: " & dt1.Rows(0).Item("T9") & _
                    "; Tháng 10: " & dt1.Rows(0).Item("T10") & _
                    "; Tháng 11: " & dt1.Rows(0).Item("T11") & _
                    "; Tháng 12: " & dt1.Rows(0).Item("T12")
            End If
        End If
    End Sub
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region
End Class