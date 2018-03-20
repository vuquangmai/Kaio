Public Class ReportLKFLotteryCycleTotalOperator
    Inherits GlobalPage
#Region "Page load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "BÁO CÁO TỔNG HỢP THEO CHU KỲ"
        End If
    End Sub
#End Region
 
#Region "Submit"
    Protected Sub btnExpot_Click(sender As Object, e As EventArgs) Handles btnExpot.Click
        ExportData.ExportExcel._LKF.CycleReportTotal_1(Me.DropDownListYear.SelectedItem.Value)
    End Sub
#End Region

End Class