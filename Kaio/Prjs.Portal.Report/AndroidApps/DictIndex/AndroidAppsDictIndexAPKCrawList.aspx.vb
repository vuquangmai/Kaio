Public Class AndroidAppsDictIndexAPKCrawList
    Inherits GlobalPage
    Public Utils As New Util.Encrypt
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbltitle.Text = "QUẢN LÝ APP ID"
            IsPrivilegeOnMenu()
            Me.btnAdd.Visible = IsUpdate
        End If
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
       
    End Sub
#End Region
#Region "Bind Data"
    Private Sub BindData(ByVal intPageSize As Integer, ByVal intCurentPage As Integer, ByVal strAction As String)
        Dim LowerBand As Integer = (intCurentPage - 1) * intPageSize
        Dim UpperBand = (intCurentPage * intPageSize) + 1
        Dim sqlTotal As String = ""
        Dim sql As String = "SELECT Id,App_Id,App_Text,Status_Id,Status_Text,Updated_Text,Updated_Id,Requires_Android,Current_Version,Installs_Text,Installs_Id,Offered_By,Developer, " & _
            " Reviews,Star_5,Star_4,Star_3,Star_2,Star_1,Blacked,Removed,Used,AddedToFan,Crawler_Date,Crawler_Num," & _
             " Row_Number() Over ( Order by App_Id ) as RowNumber " & _
             " FROM Apps_Crawler_Info " ' WHERE (Blacked+Removed+Used+AddedToFan)=0"
        If Me.DropDownListStatus_Id.SelectedItem.Value > -1 Then
            sql = sql & " AND Status_Id=" & Me.DropDownListStatus_Id.SelectedItem.Value
        End If
        If Me.txtApp_Id.Text.Trim <> "" Then
            sql = sql & " AND App_Id like N' %" & Me.txtApp_Id.Text.Trim & "%'"
        End If
        If Me.txtCrawler_Num.Text.Trim <> "" Then
            sql = sql & " AND Crawler_Num='" & Me.txtCrawler_Num.Text.Trim & "'"
        End If
        sqlTotal = "SELECT count(*) Total From (" & sql & ") T"
        sql = "SELECT * From (" & sql & ") T WHERE  T.RowNumber  >" & LowerBand & " and  T.RowNumber < " & UpperBand
        Dim dt As DataTable = Nothing
        Dim dtPageCount As DataTable = Nothing
        If ViewState("DATA_GRID") Is Nothing Then
            dt = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            dtPageCount = MSSQLEnv.BuildDataTable.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sqlTotal)
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
            Me.pager1.Visible = True
            pager1.ItemCount = Convert.ToInt32(dtPageCount.Rows(0).Item("Total"))
            Me.lblTotal.Text = "Tổng số: " & Util.Numeric.Number2Decimal(dtPageCount.Rows(0).Item("Total"), 0)
            
        Else
            Me.DataGrid.Visible = False
            Me.pager1.Visible = False
            Me.lblTotal.Text = "Tổng số: " & Constants.AlertInfo.ZeroRecord
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
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region
#Region "Checkbox Blacked"
    Public Sub CheckboxBlacked_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkBlacked As CheckBox = CType(sender, CheckBox)
        Dim row As DataGridItem = CType(chkBlacked.NamingContainer, DataGridItem)
        Dim Id As String = CType(row.FindControl("lblId"), Label).Text
        Dim Blacked As Integer = IIf(chkBlacked.Checked = True, 1, 0)
        'Dim lblApp_Id As Label
        'lblApp_Id = row.FindControl("lblApp_Id")
        'Dim App_Id As String = lblApp_Id.Text
        Dim sql As String = "UPDATE Apps_Crawler_Info SET Blacked=" & Blacked & " WHERE Id=" & Id
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi thao tác dữ liệu . Mã lỗi: " & ex.Message
        End Try

    End Sub
#End Region
#Region "Checkbox Removed"
    Public Sub CheckboxRemoved_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkRemoved As CheckBox = CType(sender, CheckBox)
        Dim row As DataGridItem = CType(chkRemoved.NamingContainer, DataGridItem)
        Dim Id As String = CType(row.FindControl("lblId"), Label).Text
        Dim Removed As Integer = IIf(chkRemoved.Checked = True, 1, 0)
        Dim sql As String = "UPDATE Apps_Crawler_Info SET Removed=" & Removed & " WHERE Id=" & Id
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi thao tác dữ liệu . Mã lỗi: " & ex.Message
        End Try

    End Sub
#End Region
#Region "Checkbox Used"
    Public Sub CheckboxUsed_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkUsed As CheckBox = CType(sender, CheckBox)
        Dim row As DataGridItem = CType(chkUsed.NamingContainer, DataGridItem)
        Dim Id As String = CType(row.FindControl("lblId"), Label).Text
        Dim Used As Integer = IIf(chkUsed.Checked = True, 1, 0)
        Dim sql As String = "UPDATE Apps_Crawler_Info SET Used=" & Used & " WHERE Id=" & Id
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi thao tác dữ liệu . Mã lỗi: " & ex.Message
        End Try

    End Sub
#End Region
#Region "Checkbox AddedToFan"
    Public Sub CheckboxAddedToFan_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkAddedToFan As CheckBox = CType(sender, CheckBox)
        Dim row As DataGridItem = CType(chkAddedToFan.NamingContainer, DataGridItem)
        Dim Id As String = CType(row.FindControl("lblId"), Label).Text
        Dim AddedToFan As Integer = IIf(chkAddedToFan.Checked = True, 1, 0)
        Dim sql As String = "UPDATE Apps_Crawler_Info SET AddedToFan=" & AddedToFan & " WHERE Id=" & Id
        Try
            MSSQLEnv.ExecuteNonQuery.sqlText(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal), sql)
            ViewState("DATA_GRID") = Nothing
            ViewState("DATA_COUNT") = Nothing
            Dim intPageSize As Integer = pager1.PageSize
            Dim intCurentPage As Integer = pager1.CurrentIndex
            BindData(intPageSize, intCurentPage, Constants.Action.Search)
        Catch ex As Exception
            Me.lblerror.Text = "Lỗi thao tác dữ liệu . Mã lỗi: " & ex.Message
        End Try

    End Sub
#End Region
#Region "Delete Data"
    Sub CheckBlacked()
        For Each dgItem In Me.DataGrid.Items
            Dim chkRow As CheckBox = TryCast(dgItem.Cells(9).FindControl("CheckboxBlacked"), CheckBox)
            If chkRow.Checked Then
                Dim App_Id As String = TryCast(dgItem.Cells(0).FindControl("lblApp_Id"), Label).Text
                Dim App_Id1 As String = TryCast(dgItem.Cells(1).FindControl("lblApp_Id"), Label).Text
                Dim App_Id2 As String = TryCast(dgItem.Cells(2).FindControl("lblApp_Id"), Label).Text
                Dim name As String = dgItem.Cells(1).Text
                Dim lblInstalls_Id As String = TryCast(dgItem.Cells(0).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id1 As String = TryCast(dgItem.Cells(1).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id2 As String = TryCast(dgItem.Cells(2).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id3 As String = TryCast(dgItem.Cells(3).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id4 As String = TryCast(dgItem.Cells(4).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id5 As String = TryCast(dgItem.Cells(5).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id6 As String = TryCast(dgItem.Cells(6).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id7 As String = TryCast(dgItem.Cells(7).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id8 As String = TryCast(dgItem.Cells(8).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id9 As String = TryCast(dgItem.Cells(9).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id10 As String = TryCast(dgItem.Cells(10).FindControl("lblInstalls_Id"), Label).Text
                Dim lblInstalls_Id11 As String = TryCast(dgItem.Cells(11).FindControl("lblInstalls_Id"), Label).Text
            End If

           
        Next
        
    End Sub

    Public Sub chkStatus_OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim chkStatus As CheckBox = CType(sender, CheckBox)
        Dim row As DataGridItem = CType(chkStatus.NamingContainer, DataGridItem)
        Dim strADCN As String = CType(row.FindControl("lblApp_Text"), Label).Text

        Dim cid As String = row.Cells(1).Text
        Dim cid1 As String = row.Cells(2).Text
        Dim cid2 As String = row.Cells(3).Text
        Dim cid3 As String = row.Cells(4).Text
        Dim status As Boolean = chkStatus.Checked
        Dim lblApp_Id As Label
        lblApp_Id = row.FindControl("lblApp_Id")
        Dim App_Id As String = lblApp_Id.Text

        'Dim constr As String = "Server=.\SQLEXPRESS;Database=TestDB;uid=waqas;pwd=sql;"
        'Dim query As String = "UPDATE Categories SET Approved = @Approved WHERE CategoryID = @CategoryID"

        'Dim con As SqlConnection = New SqlConnection(constr)
        'Dim com As SqlCommand = New SqlCommand(query, con)


        'com.Parameters.Add("@Approved", SqlDbType.Bit).Value = status
        'com.Parameters.Add("@CategoryID", SqlDbType.Int).Value = cid


        'con.Open()
        'com.ExecuteNonQuery()
        'con.Close()

        'LoadData()
    End Sub

    '----------------------------------------------------------------
    ' Converted from C# to VB .NET using CSharpToVBConverter(1.2).
    ' Developed by: Kamal Patel (http://www.KamalPatel.net) 
    '----------------------------------------------------------------
    Sub Blacked()
        For i As Int16 = 0 To Me.DataGrid.Items.Count - 1
            With DataGrid
                Dim lblApp_Id As Label
                lblApp_Id = .Items(i).FindControl("lblApp_Id")
                Dim App_Id As String = lblApp_Id.Text

                Dim lblApp_Text As Label
                lblApp_Text = .Items(i).FindControl("lblApp_Text")
                Dim App_Text As String = lblApp_Text.Text


                Dim lbl_USER_ID As Label
                lbl_USER_ID = .Items(i).FindControl("lbl_USER_ID")
                Dim UserId As String = lbl_USER_ID.Text

                Dim chkStatus As CheckBox
                chkStatus = .Items(i).FindControl("chkStatus")
                If chkStatus.Checked = True Then

                Else

                End If
            End With
        Next
    End Sub
#End Region
#Region "Submit Click"
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Response.Redirect(Constants.Url._AndroidApps.AndroidAppsDictIndexList)
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ViewState("DATA_GRID") = Nothing
        ViewState("DATA_COUNT") = Nothing
        Dim intPageSize As Integer = pager1.PageSize
        Dim intCurentPage As Integer = pager1.CurrentIndex
        BindData(intPageSize, intCurentPage, Constants.Action.Search)
    End Sub
#End Region

    
End Class