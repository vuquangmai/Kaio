Imports System.IO

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Context.Response.Clear()
        Dim file As FileInfo = New FileInfo("C:\HP\netPrjs\HQ\Prjs.Portal.Report\Test\HD SMS PLUS 9029_VMG_New_TienTien.docx")
        Context.Response.ContentType = "Application/msword"
        Context.Response.AppendHeader("Content-Disposition", "inline; filename=" + file.Name)
        Context.Response.AppendHeader("Content-Length", file.Length.ToString())
        Context.Response.WriteFile(file.FullName)
        Context.Response.End()
    End Sub

End Class