Imports System.Data.SqlClient
Imports System.Reflection
Public Class DeleteObject
#Region "Url Interface"
    Public Class UrlManager
 
#Region "Delete Group Url Info"
        Public Shared Function DeleteGroupUrl(ByVal intGroupId As Integer, ByVal intUrltId As Integer) As String
            Dim cmd As New SqlCommand
            Dim retval As String = ""
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Delete_Group_Url"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupId

                .Parameters.Add(New SqlParameter("@Url_Id", SqlDbType.Int, 50))
                .Parameters("@Url_Id").Value = intUrltId
            End With
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                 Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                retval = ex.Message
            Finally
                cmd.Dispose()
            End Try
            Return retval
        End Function
#End Region
 
    End Class
#End Region
#Region "Lott Interfac"
    Public Class LottInterface
        Public Shared Function DeleteUserCompany(ByVal intUserId As Integer, ByVal intRef_Id As Integer) As String
            Dim cmd As New SqlCommand
            Dim retval As String = ""
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "Lott_Delete_User_Company"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId

                .Parameters.Add(New SqlParameter("@Ref_Id", SqlDbType.Int, 50))
                .Parameters("@Ref_Id").Value = intRef_Id
            End With
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)
                retval = ex.Message
            Finally
                cmd.Dispose()
            End Try
            Return retval
        End Function
    End Class
#End Region
End Class
