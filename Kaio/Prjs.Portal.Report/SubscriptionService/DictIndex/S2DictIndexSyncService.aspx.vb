Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class S2DictIndexSyncService
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CreateFolder()
            Me.lbltitle.Text = "GẮN DỊCH VỤ TƯƠNG ỨNG VỚI ĐỐI TÁC - DỊCH VỤ S2"
        End If
        Me.UploadFile.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"

    End Sub
#Region "Import"
    Private Sub ProcFile()
        Dim sql As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Request.MapPath(Me.UploadFile.Text.Trim) & "; Extended Properties=""Excel 8.0"""
        Dim connFile As New OleDbConnection(sql)
        Try
            connFile.Open()
        Catch ex As Exception
            Me.lblerror.Text = " Error connect to excel file .Code: " & ex.Message
            Exit Sub
        End Try
        Dim strSqlStmt As String = "SELECT * FROM [" & Me.txtSheet.Text.Trim & "$]"
        Dim dafile As OleDbDataAdapter
        Dim cmdfile As New OleDbCommand
        Dim dsfile As New DataSet
        With cmdfile
            .CommandType = CommandType.Text
            .CommandText = strSqlStmt
            .Connection = connFile
        End With
        Try
            dafile = New OleDbDataAdapter(cmdfile)
            dafile.Fill(dsfile, "DATAFILE")
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi đọc file excel. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        connFile.Close()
        connFile = Nothing
      
        If dsfile.Tables("DATAFILE").Rows.Count > 0 Then
            For i As Integer = 0 To dsfile.Tables("DATAFILE").Rows.Count - 1
                Dim Partner_Text As String = dsfile.Tables("DATAFILE").Rows(i).Item(7).ToString.Trim
                sql = "SELECT * FROM Ccare_Management_Partner WHERE partner_Text=N'" & Partner_Text & "'"
                Dim dt As DataTable = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                If dt.Rows.Count > 0 Then
                    Dim Partner_Id As Integer = dt.Rows(0).Item("Id")
                    Dim Service_text As String = dsfile.Tables("DATAFILE").Rows(i).Item(3).ToString.Trim
                    Dim Ratio_Share As String = dsfile.Tables("DATAFILE").Rows(i).Item(10).ToString.Trim
                    sql = "UPDATE S2_DictIndex_Service SET Flag_Update=1,Partner_Id=" & Partner_Id & "," & _
                    "Partner_Text=N'" & Partner_Text & "'," & _
                    "Ratio_Share=N'" & Ratio_Share & "'" & _
                    "WHERE Service_text=N'" & Service_text & "'"
                    Try
                        MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
                    Catch ex As Exception
                        Me.lblerror.Text = "Lỗi xử lý dữ liệu. Mã lỗi: " & ex.Message
                        Exit Sub
                    End Try
                End If
                dt.Clear()
            Next
        End If
        Me.lblerror.Text = "Xử lý dữ liệu thành công !"
    End Sub
#End Region
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ProcFile()
    End Sub
End Class