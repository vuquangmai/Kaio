Imports System.Data.OleDb
Imports System.Data.OracleClient

Public Class CCareImportBlackList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
    Public Utils_1 As New Util.Numeric
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CreateFolder()
            Me.lbltitle.Text = "IMPORT BLACK LIST"
        End If
        Me.txtUserFile.fpUploadDir = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        ' Me.CheckBoxDelData.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Dim gridrow As DataGridItem
        Dim thisButton As ImageButton
        For Each gridrow In Me.DataGrid.Items
            thisButton = gridrow.FindControl("deleter")
            thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
        Next
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
        If Me.txtUserFile.Text.Trim = "" Then
            Me.lblerror.Text = "File dữ liệu không hợp lệ !"
            Exit Sub
        End If
        Dim vFile As String = txtUserFile.Text.Trim
        If vFile.ToLower.EndsWith(".xls") = True Or vFile.EndsWith(".xlsx") = True Then
            ProcXLS(vFile)
        ElseIf vFile.ToLower.EndsWith(".csv") = True Then
            ProcCSV(vFile)
        ElseIf vFile.ToLower.EndsWith(".txt") = True Then
            ProcTXT(vFile)
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
        End If
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)

    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReturn.Click
        RedirectUrl(Constants.Url._CcareB2C.CCareCustomerInfoList)
    End Sub
#End Region
#Region "xls File"
    Private Sub ProcXLS(ByVal xlsFile As String)
        Dim dt As DataTable = Nothing
        Dim sql As String = ""
        If xlsFile.EndsWith(".xls") = True Then
            sql = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 8.0"""
        ElseIf xlsFile.EndsWith(".xlsx") = True Then
            sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Request.MapPath(xlsFile.Trim) & "; Extended Properties=""Excel 12.0 Xml;HDR=YES"""
        Else
            Me.lblerror.Text = "Định dạng file không hợp lệ !"
            Exit Sub
        End If
        Dim connFile As New OleDbConnection(sql)
        Try
            connFile.Open()
        Catch ex As Exception
            Me.lblerror.Text = " Error connect to excel file .Code: " & ex.Message
            Exit Sub
        End Try
        Dim strSqlStmt As String = "SELECT * FROM [" & Me.txtSheet.Text.Trim & "$]"
        Dim daFile As OleDbDataAdapter
        Dim cmdFile As New OleDbCommand
        Dim dsFile As New DataSet
        With cmdFile
            .CommandType = CommandType.Text
            .CommandText = strSqlStmt
            .Connection = connFile
        End With
        Try
            daFile = New OleDbDataAdapter(cmdFile)
            daFile.Fill(dsFile, "Data_File")
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi đọc file excel. Mã lỗi: " & ex.Message
            Exit Sub
        End Try
        connFile.Close()
        connFile = Nothing

        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim USER_ID As String = ""
        Dim MOBILE_OPERATOR As String = Util.FormatOperator(USER_ID)
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim DESCRIPTION As String = Me.txtDescription.Text.Trim
        Dim TotalImport As Integer = 0
        Dim TotalExist As Integer = 0
        If dsFile.Tables("Data_File").Rows.Count > 0 Then
            For i As Integer = 0 To dsFile.Tables("Data_File").Rows.Count - 1
                USER_ID = dsFile.Tables("Data_File").Rows(i).Item(0).ToString.Trim
                MOBILE_OPERATOR = Util.FormatOperator(USER_ID)
                sql = "SELECT * From  CCARE_DICTINDEX_BLACKLIST  Where  upper(USER_ID)='" & USER_ID.ToUpper & "'"
                If Me.B2CCheckData(sql) = False Then
                    Dim cmd As New OracleCommand
                    With cmd
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_REFUSE"
                        .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                        .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 200))
                        .Parameters("p_USER_ID").Value = USER_ID

                        .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                        .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_CREATE_BY_ID").Value = CREATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                        .Parameters("p_CREATE_BY_TEXT").Value = CREATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_CREATE_TIME").Value = CREATE_TIME

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                        .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                        .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                        .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                        .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                        .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                        .Parameters.Add(New OracleParameter("p_DESCRIPTION", OracleType.VarChar, 200))
                        .Parameters("p_DESCRIPTION").Value = DESCRIPTION

                        .Connection = conn
                        Try
                            .ExecuteNonQuery()
                            TotalImport = TotalImport + 1
                        Catch ex As Exception
                            Me.lblerror.Text = ex.Message
                            Exit Sub
                        End Try
                    End With
                Else
                    TotalExist = TotalExist + 1
                End If
            Next
        End If
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số Import: " & TotalImport & " (Tồn tại:" & TotalExist & ")"
    End Sub
#End Region
#Region "csv File"
    Private Sub ProcCSV(ByVal csvFile As String)
        Dim FileNumber As Integer = FreeFile()
        ' Open file
        FileOpen(FileNumber, Request.MapPath(csvFile.Trim), OpenMode.Input)
        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
         Dim USER_ID As String = ""
        Dim MOBILE_OPERATOR As String = Util.FormatOperator(USER_ID)
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim DESCRIPTION As String = Me.txtDescription.Text.Trim
        Dim TotalImport As Integer = 0
        Dim TotalExist As Integer = 0
        ' Loop until end of file
        Do Until EOF(FileNumber)
            ' Read a line from file
            Dim vText As String = LineInput(FileNumber)
            ' Split line at commas
            'Dim Values() As String = Split(Text, ",")
            ' Values(0) now contains first column value,
            ' Values(1) contains second column, etc.
            USER_ID = vText.ToString.Trim
            MOBILE_OPERATOR = Util.FormatOperator(USER_ID)
            Dim sql As String = "SELECT * From  CCARE_DICTINDEX_BLACKLIST  Where   upper(USER_ID)='" & USER_ID.ToUpper & "'"
            If Me.B2CCheckData(Sql) = False Then
                Dim cmd As New OracleCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_REFUSE"
                    .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                    .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 200))
                    .Parameters("p_USER_ID").Value = USER_ID

                    .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                    .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_CREATE_BY_ID").Value = CREATE_BY_ID

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_CREATE_BY_TEXT").Value = CREATE_BY_TEXT

                    .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_CREATE_TIME").Value = CREATE_TIME

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                    .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                    .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                    .Parameters.Add(New OracleParameter("p_DESCRIPTION", OracleType.VarChar, 200))
                    .Parameters("p_DESCRIPTION").Value = DESCRIPTION

                    .Connection = conn
                    Try
                        .ExecuteNonQuery()
                        TotalImport = TotalImport + 1
                    Catch ex As Exception
                        Me.lblerror.Text = ex.Message
                        Exit Sub
                    End Try
                End With
            Else
                Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
                TotalExist = TotalExist + 1
            End If
        Loop
        ' Close file
        FileClose(FileNumber)
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        FileClose(FileNumber)
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số Import: " & TotalImport & " (Tồn tại:" & TotalExist & ")"
    End Sub
#End Region
#Region "txt File"
    Private Sub ProcTXT(ByVal txtFile As String)
        Dim FileNumber As Integer = FreeFile()
        ' Open file
        FileOpen(FileNumber, Request.MapPath(txtFile.Trim), OpenMode.Input)

        Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
        If conn.State = ConnectionState.Closed Then
            Try
                conn.Open()
            Catch ex As Exception
                Me.lblerror.Text = ex.Message
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
            End Try
        End If
        Dim USER_ID As String = ""
        Dim MOBILE_OPERATOR As String = Util.FormatOperator(USER_ID)
        Dim CREATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim CREATE_BY_ID As String = CurrentUser.UserId
        Dim CREATE_BY_TEXT As String = CurrentUser.UserName
        Dim UPDATE_TIME As String = DateTime.Parse(Now).ToString("yyyy-MM-dd HH:mm:ss")
        Dim UPDATE_BY_ID As String = CurrentUser.UserId
        Dim UPDATE_BY_TEXT As String = CurrentUser.UserName
        Dim DESCRIPTION As String = Me.txtDescription.Text.Trim
        Dim TotalImport As Integer = 0
        Dim TotalExist As Integer = 0
        Do Until EOF(FileNumber)
            ' Read a line from file
            Dim vText As String = LineInput(FileNumber)
            ' Split line at commas
            'Dim Values() As String = Split(Text, ",")
            ' Values(0) now contains first column value,
            ' Values(1) contains second column, etc.
            USER_ID = vText.ToString.Trim
            MOBILE_OPERATOR = Util.FormatOperator(USER_ID)
            Dim sql As String = "SELECT * From  CCARE_DICTINDEX_BLACKLIST  Where    upper(USER_ID)='" & USER_ID.ToUpper & "'"
            If Me.B2CCheckData(sql) = False Then
                Dim cmd As New OracleCommand
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_REFUSE"
                    .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                    .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 200))
                    .Parameters("p_USER_ID").Value = USER_ID

                    .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                    .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_CREATE_BY_ID").Value = CREATE_BY_ID

                    .Parameters.Add(New OracleParameter("p_CREATE_BY_TEXT", OracleType.NVarChar, 200))
                    .Parameters("p_CREATE_BY_TEXT").Value = CREATE_BY_TEXT

                    .Parameters.Add(New OracleParameter("p_CREATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_CREATE_TIME").Value = CREATE_TIME

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                    .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                    .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                    .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                    .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                    .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                    .Parameters.Add(New OracleParameter("p_DESCRIPTION", OracleType.VarChar, 200))
                    .Parameters("p_DESCRIPTION").Value = DESCRIPTION

                    .Connection = conn
                    Try
                        .ExecuteNonQuery()
                        TotalImport = TotalImport + 1
                    Catch ex As Exception
                        Me.lblerror.Text = ex.Message
                        Exit Sub
                    End Try
                End With
            Else
                Me.lblerror.Text = Constants.AlertInfo.ExistRecordAdd
                TotalExist = TotalExist + 1
            End If
        Loop
        ' Close file
        FileClose(FileNumber)
        FileSystem.Kill(Request.MapPath(txtFile.Trim))
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
        Me.lblerror.Text = "Import dữ liệu thành công !. Tổng số Import: " & TotalImport & " (Tồn tại:" & TotalExist & ")"
    End Sub
#End Region
 
#Region "Create Folder"
    Private Sub CreateFolder()
        Dim strFolder As String = ConfigurationManager.AppSettings("UpLoadDirectory") & CType(CurrentUser.UserName, String) & "/" & DateTime.Now.Year.ToString() & "/" & Util.StringBuilder.ConvertDigit(DateTime.Now.Month.ToString()) & "/"
        Util.CreateUserFolder(Server.MapPath("../../" & strFolder))
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT Id,USER_ID,MOBILE_OPERATOR, Create_By_Id,Create_By_Text,Create_Time,Update_By_Id,Update_By_Text,Update_Time,Description, RowNum as RowNumber " & _
                                     " FROM CCARE_DICTINDEX_BLACKLIST "
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        Dim dt As DataTable = Nothing
        Dim dtPageCount As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
            dt = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            dtPageCount = OracleEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sqlTotal)
        Else
            dt = CType(ViewState("DATA_GRID"), DataTable)
            dtPageCount = CType(ViewState("DATA_COUNT"), DataTable)
        End If
        ViewState("DATA_GRID") = dt
        ViewState("DATA_COUNT") = dtPageCount
        If dt.Rows.Count > 0 Then
            Me.DataGrid.DataSource = dt
            Me.DataGrid.DataBind()
            Me.DataGrid.Columns(6).Visible = IsUpdate
            Me.DataGrid.Columns(7).Visible = IsDelete
            Me.DataGrid.PagerStyle.Visible = False
            Me.DataGrid.Visible = True
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            pager1.Visible = True
            Dim gridrow As DataGridItem
            Dim thisButton As ImageButton
            For Each gridrow In Me.DataGrid.Items
                thisButton = gridrow.FindControl("deleter")
                thisButton.Attributes.Add("onclick", "if(confirm('" & Constants.AlertInfo.ConfirmDelete & "')){}else{return false}")
            Next
        Else
            Me.DataGrid.Visible = False
            pager1.Visible = False
            Me.lblerror.Text = Constants.AlertInfo.ZeroRecord
        End If
    End Sub

#End Region
#Region "Pager"
    Protected Sub pager_Command(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles pager1.Command
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim currnetPageIndx As Int32 = CType(e.CommandArgument, Int32)
        pager1.CurrentIndex = currnetPageIndx
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        bindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Delete Data"
     Sub DelData(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim sql As String = "Delete  From  CCARE_DICTINDEX_BLACKLIST  Where  Id =" & CType(e.CommandArgument, Integer)
        Try
            OracleEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = Constants.AlertInfo.ErrorExcute & Constants.AlertInfo.ErrorCode & ex.Message
        End Try
    End Sub
#End Region

End Class