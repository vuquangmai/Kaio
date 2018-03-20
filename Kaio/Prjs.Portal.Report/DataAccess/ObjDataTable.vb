Imports System.Data.SqlClient
Imports System.Reflection

Public Class ObjDataTable
#Region "Check Exist Objects"
    Public Class CheckExist
        Public Shared Function IsExistObject(ByVal sql As String) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Connection = GlobalConnection
                .CommandText = sql
            End With
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try
            Return dt
        End Function
    End Class

#End Region
#Region "Url Interface"
    Public Class UrlManager
#Region "Check Access Rights"
        Public Shared Function UrlAccessRights(ByVal intGroupId As Integer, ByVal intUserId As Integer, ByVal intChannelId As Integer, ByVal Url As String) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_Url_Access_Rights"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId

                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId

                .Parameters.Add(New SqlParameter("@Channel_Id", SqlDbType.Int, 50))
                .Parameters("@Channel_Id").Value = intChannelId

                .Parameters.Add(New SqlParameter("@Url_Id", SqlDbType.NVarChar, 250))
                .Parameters("@Url_Id").Value = Url
            End With

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
#Region "Check Privilege on Menu"
        Public Shared Function CheckPrivilege(ByVal intGroupId As Integer, ByVal Url As String) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_Privilege_On_Menu_By_Group_Id"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId

                .Parameters.Add(New SqlParameter("@Url_Id", SqlDbType.NVarChar, 500))
                .Parameters("@Url_Id").Value = Url
            End With

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
#Region "Select Url by GroupId"
        Public Shared Function UrlByGroupId(ByVal intGroupId As Integer, ByVal intUserId As Integer, ByVal intChannel As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_Url_By_Group_Id"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId

                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId

                .Parameters.Add(New SqlParameter("@Channel_Id", SqlDbType.Int, 50))
                .Parameters("@Channel_Id").Value = intChannel
            End With

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
               Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
#Region "Select Url Active by Group User"
        Public Shared Function UrlActiveByGroup(ByVal intGroupId As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_Url_Active_By_Group"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId
            End With
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
            Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
#Region "Select Url DeActive by Group User"
        Public Shared Function UrlDeActiveByGroup(ByVal intGroupId As Integer, ByVal intGroupRootId As Integer, ByVal intIsGroupAdmin As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_Url_DeActive_By_Group"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId
                .Parameters.Add(New SqlParameter("@ROOT_ID", SqlDbType.Int, 50))
                .Parameters("@ROOT_ID").Value = intGroupRootId
                .Parameters.Add(New SqlParameter("@IS_ADMIN", SqlDbType.Int, 50))
                .Parameters("@IS_ADMIN").Value = intIsGroupAdmin
            End With
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
               Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
    End Class
#End Region
#Region "Group User Interface"
    Public Class GroupUserManager
#Region "Select Group Privilege"
        Public Shared Function GroupPrivilege(ByVal intGroupId As String, ByVal intGroupRootId As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Connection = GlobalConnection
                .CommandText = "System_Select_Privilege_By_Group"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId

                .Parameters.Add(New SqlParameter("@Root_Id", SqlDbType.Int, 50))
                .Parameters("@Root_Id").Value = intGroupRootId
            End With

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
    End Class
#End Region
#Region "Lott Interface"
    Public Class LottInterface
#Region "Select Company Active by Group User"
        Public Shared Function CompanyActiveByUser(ByVal intUserId As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "Lott_Select_Company_Active_By_User"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId
            End With
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
#Region "Select Url DeActive by User"
        Public Shared Function CompanyDeActiveByUser(ByVal intUserId As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "Lott_Select_Company_DeActive_By_User"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId
            End With
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Try
                da.Fill(dt)
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                dt = Nothing
            Finally
                cmd.Dispose()
                da.Dispose()
            End Try

            Return dt
        End Function
#End Region
    End Class

#End Region

End Class
