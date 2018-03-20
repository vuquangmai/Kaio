Imports System.Data.SqlClient
Imports System.Reflection

Public Class ObjDataReader
#Region "User Interface"
    Public Class UserManager
#Region "Select User Info"
        Public Shared Function UserInfo(ByVal vUserName As String, ByVal vPassword As String) As SqlDataReader
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_User_Info"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@User_Name", SqlDbType.NVarChar, 50))
                .Parameters("@User_Name").Value = vUserName

                .Parameters.Add(New SqlParameter("@Pass_Word", SqlDbType.NVarChar, 250))
                .Parameters("@Pass_Word").Value = vPassword
            End With

            Dim dr As SqlDataReader = Nothing
            Try
                dr = cmd.ExecuteReader
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
            Finally
                cmd.Dispose()
            End Try
            Return dr
        End Function

#End Region
#Region "Select User Rights"
        Public Shared Function UserRights(ByVal intUserId As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Select_User_Rights"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@ID", SqlDbType.Int))
                .Parameters("@ID").Value = intUserId

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
