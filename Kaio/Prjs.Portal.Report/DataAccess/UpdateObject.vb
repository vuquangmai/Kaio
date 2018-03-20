Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Data.OracleClient
Public Class UpdateObject
#Region "Url Interface"
    Public Class UrlManager
#Region "Insert Url Group User "
        Public Shared Function InsertUrlGroup(ByVal intGroupid As Integer, ByVal intItemId As Integer) As String
            Dim retval As String = ""
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "System_Insert_Group_Url"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Group_Id", SqlDbType.Int, 50))
                .Parameters("@Group_Id").Value = intGroupid

                .Parameters.Add(New SqlParameter("@Url_Id", SqlDbType.Int, 50))
                .Parameters("@Url_Id").Value = intItemId
            End With

            Try
                cmd.ExecuteNonQuery()
                retval = ""
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)

                retval = ex.Message
            End Try

            Return retval
        End Function
#End Region
 
    End Class
#End Region
#Region "B2C Interface"
    Public Class B2CManagement
        Public Shared Function InsertDictIndexSource(ByVal SOURCE_TEXT As String, _
                                           ByVal STATUS_ID As Integer, _
                                           ByVal STATUS_TEXT As String, _
                                           ByVal CREATE_BY_ID As Integer, _
                                           ByVal CREATE_BY_TEXT As String, _
                                           ByVal CREATE_TIME As DateTime, _
                                          ByVal UPDATE_BY_ID As Integer, _
                                           ByVal UPDATE_BY_TEXT As String, _
                                           ByVal UPDATE_TIME As DateTime, _
                                           ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_SOURCE"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexSource(ByVal ID As Integer, _
                                         ByVal SOURCE_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_SOURCE"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexPartner(ByVal PARTNER_TEXT As String, _
                                        ByVal PARTNER_FULL_NAME As String, _
                                        ByVal STATUS_ID As Integer, _
                                        ByVal STATUS_TEXT As String, _
                                        ByVal CREATE_BY_ID As Integer, _
                                        ByVal CREATE_BY_TEXT As String, _
                                        ByVal CREATE_TIME As DateTime, _
                                       ByVal UPDATE_BY_ID As Integer, _
                                        ByVal UPDATE_BY_TEXT As String, _
                                        ByVal UPDATE_TIME As DateTime, _
                                        ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_PARTNER"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_PARTNER_FULL_NAME", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_FULL_NAME").Value = PARTNER_FULL_NAME

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexPartner(ByVal ID As Integer, _
                                         ByVal PARTNER_TEXT As String, _
                                         ByVal PARTNER_FULL_NAME As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_PARTNER"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_PARTNER_FULL_NAME", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_FULL_NAME").Value = PARTNER_FULL_NAME

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexField(ByVal FIELD_TEXT As String, _
                                        ByVal STATUS_ID As Integer, _
                                        ByVal STATUS_TEXT As String, _
                                        ByVal CREATE_BY_ID As Integer, _
                                        ByVal CREATE_BY_TEXT As String, _
                                        ByVal CREATE_TIME As DateTime, _
                                       ByVal UPDATE_BY_ID As Integer, _
                                        ByVal UPDATE_BY_TEXT As String, _
                                        ByVal UPDATE_TIME As DateTime, _
                                        ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_FIELD"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexField(ByVal ID As Integer, _
                                         ByVal FIELD_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_FIELD"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexFees(ByVal FEES_TEXT As String, _
                                    ByVal STATUS_ID As Integer, _
                                    ByVal STATUS_TEXT As String, _
                                    ByVal CREATE_BY_ID As Integer, _
                                    ByVal CREATE_BY_TEXT As String, _
                                    ByVal CREATE_TIME As DateTime, _
                                   ByVal UPDATE_BY_ID As Integer, _
                                    ByVal UPDATE_BY_TEXT As String, _
                                    ByVal UPDATE_TIME As DateTime, _
                                    ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_FEES"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexFees(ByVal ID As Integer, _
                                         ByVal FEES_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_FEES"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexInCome(ByVal INCOME_TEXT As String, _
                                        ByVal STATUS_ID As Integer, _
                                        ByVal STATUS_TEXT As String, _
                                        ByVal CREATE_BY_ID As Integer, _
                                        ByVal CREATE_BY_TEXT As String, _
                                        ByVal CREATE_TIME As DateTime, _
                                       ByVal UPDATE_BY_ID As Integer, _
                                        ByVal UPDATE_BY_TEXT As String, _
                                        ByVal UPDATE_TIME As DateTime, _
                                        ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_INCOME"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexInCome(ByVal ID As Integer, _
                                         ByVal INCOME_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_INCOME"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexProvince(ByVal REGION_ID As Integer, _
                                      ByVal REGION_TEXT As String, _
                                      ByVal PROVINCE_TEXT As String, _
                                      ByVal STATUS_ID As Integer, _
                                      ByVal STATUS_TEXT As String, _
                                      ByVal CREATE_BY_ID As Integer, _
                                      ByVal CREATE_BY_TEXT As String, _
                                      ByVal CREATE_TIME As DateTime, _
                                      ByVal UPDATE_BY_ID As Integer, _
                                      ByVal UPDATE_BY_TEXT As String, _
                                      ByVal UPDATE_TIME As DateTime, _
                                      ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_PROC"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_REGION_ID", OracleType.Number, 18))
                .Parameters("p_REGION_ID").Value = REGION_ID

                .Parameters.Add(New OracleParameter("p_REGION_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_REGION_TEXT").Value = REGION_TEXT

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexProvince(ByVal ID As Integer, _
                                         ByVal REGION_ID As Integer, _
                                         ByVal REGION_TEXT As String, _
                                         ByVal PROVINCE_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_PROC"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_REGION_ID", OracleType.Number, 18))
                .Parameters("p_REGION_ID").Value = REGION_ID

                .Parameters.Add(New OracleParameter("p_REGION_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_REGION_TEXT").Value = REGION_TEXT

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexDistrict(ByVal PROVINCE_ID As Integer, _
                                    ByVal PROVINCE_TEXT As String, _
                                    ByVal DISTRICT_TEXT As String, _
                                    ByVal STATUS_ID As Integer, _
                                    ByVal STATUS_TEXT As String, _
                                    ByVal CREATE_BY_ID As Integer, _
                                    ByVal CREATE_BY_TEXT As String, _
                                    ByVal CREATE_TIME As DateTime, _
                                    ByVal UPDATE_BY_ID As Integer, _
                                    ByVal UPDATE_BY_TEXT As String, _
                                    ByVal UPDATE_TIME As DateTime, _
                                    ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_DIST"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexDistrict(ByVal ID As Integer, _
                                         ByVal PROVINCE_ID As Integer, _
                                         ByVal PROVINCE_TEXT As String, _
                                         ByVal DISTRICT_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_DIST"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexBrand(ByVal PARTNER_ID As Integer, _
                                 ByVal PARTNER_TEXT As String, _
                                 ByVal BRAND_NAME As String, _
                                 ByVal STATUS_ID As Integer, _
                                 ByVal STATUS_TEXT As String, _
                                 ByVal CREATE_BY_ID As Integer, _
                                 ByVal CREATE_BY_TEXT As String, _
                                 ByVal CREATE_TIME As DateTime, _
                                 ByVal UPDATE_BY_ID As Integer, _
                                 ByVal UPDATE_BY_TEXT As String, _
                                 ByVal UPDATE_TIME As DateTime, _
                                 ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_BRAND"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexBrand(ByVal ID As Integer, _
                                         ByVal PARTNER_ID As Integer, _
                                         ByVal PARTNER_TEXT As String, _
                                         ByVal BRAND_NAME As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_BRAND"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexBlackList(ByVal USER_ID As String, _
                                          ByVal MOBILE_OPERATOR As String, _
                                          ByVal CREATE_BY_ID As Integer, _
                                          ByVal CREATE_BY_TEXT As String, _
                                          ByVal CREATE_TIME As DateTime, _
                                          ByVal UPDATE_BY_ID As Integer, _
                                          ByVal UPDATE_BY_TEXT As String, _
                                          ByVal UPDATE_TIME As DateTime, _
                                          ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexBlackList(ByVal ID As Integer, _
                                         ByVal USER_ID As String, _
                                          ByVal MOBILE_OPERATOR As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_REFUSE"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 200))
                .Parameters("p_USER_ID").Value = USER_ID

                .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function InsertDictIndexCareer(ByVal CAREER_TEXT As String, _
                                      ByVal STATUS_ID As Integer, _
                                      ByVal STATUS_TEXT As String, _
                                      ByVal CREATE_BY_ID As Integer, _
                                      ByVal CREATE_BY_TEXT As String, _
                                      ByVal CREATE_TIME As DateTime, _
                                     ByVal UPDATE_BY_ID As Integer, _
                                      ByVal UPDATE_BY_TEXT As String, _
                                      ByVal UPDATE_TIME As DateTime, _
                                      ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.INSERT_CCARE_DICTINDEX_CAREER"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_CAREER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_CAREER_TEXT").Value = CAREER_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateDictIndexCareer(ByVal ID As Integer, _
                                         ByVal CAREER_TEXT As String, _
                                         ByVal STATUS_ID As Integer, _
                                         ByVal STATUS_TEXT As String, _
                                         ByVal UPDATE_BY_ID As Integer, _
                                         ByVal UPDATE_BY_TEXT As String, _
                                         ByVal UPDATE_TIME As DateTime, _
                                         ByVal DESCRIPTION As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_DICTINDEX.UPDATE_CCARE_DICTINDEX_CAREER"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Value = ID

                .Parameters.Add(New OracleParameter("p_CAREER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_CAREER_TEXT").Value = CAREER_TEXT

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

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
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function

        Public Shared Function InsertCustomerInfo(ByVal USER_ID As String, _
                                                                        ByVal STATUS_ID As Integer, _
                                                                        ByVal STATUS_TEXT As String, _
                                                                        ByVal GROUP_TEXT As String, _
                                                                        ByVal MT As String, _
                                                                        ByVal BRAND_ID As Integer, _
                                                                        ByVal BRAND_NAME As String, _
                                                                        ByVal PARTNER_ID As Integer, _
                                                                        ByVal PARTNER_TEXT As String, _
                                                                        ByVal PROVINCE_ID As Integer, _
                                                                        ByVal PROVINCE_TEXT As String, _
                                                                        ByVal DISTRICT_ID As Integer, _
                                                                        ByVal DISTRICT_TEXT As String, _
                                                                        ByVal SEX_ID As Integer, _
                                                                        ByVal SEX_TEXT As String, _
                                                                        ByVal FIELD_ID As String, _
                                                                        ByVal FIELD_TEXT As String, _
                                                                        ByVal SOURCE_ID As Integer, _
                                                                        ByVal SOURCE_TEXT As String, _
                                                                        ByVal KEY_WORD As String, _
                                                                        ByVal REMARK As String, _
                                                                        ByVal CUSTOMER_CODE As String, _
                                                                        ByVal CUSTOMER_NAME As String, _
                                                                        ByVal BIRTH_DAY As String, _
                                                                        ByVal ADDRESS As String, _
                                                                        ByVal EMAIL_ADDRESS As String, _
                                                                        ByVal FEES_ID As Integer, _
                                                                        ByVal FEES_TEXT As String, _
                                                                        ByVal INCOME_ID As Integer, _
                                                                        ByVal INCOME_TEXT As String, _
                                                                        ByVal EXACTLY_RATE As String, _
                                                                        ByVal MOBILE_OPERATOR As String, _
                                                                        ByVal IS_VERIFY_1 As Integer, _
                                                                        ByVal VERIFY_BY_1_ID As Integer, _
                                                                        ByVal VERIFY_BY_1_TEXT As String, _
                                                                        ByVal VERIFY_TIME_1 As String, _
                                                                        ByVal IS_VERIFY_2 As Integer, _
                                                                        ByVal VERIFY_BY_2_ID As Integer, _
                                                                        ByVal VERIFY_BY_2_TEXT As String, _
                                                                        ByVal VERIFY_TIME_2 As String, _
                                                                        ByVal IS_VERIFY_3 As Integer, _
                                                                        ByVal VERIFY_BY_3_ID As Integer, _
                                                                        ByVal VERIFY_BY_3_TEXT As String, _
                                                                        ByVal VERIFY_TIME_3 As String, _
                                                                        ByVal KEY_IMPORT As String, _
                                                                        ByVal FILE_IMPORT As String, _
                                                                        ByVal CREATE_BY_ID As Integer, _
                                                                        ByVal CREATE_BY_TEXT As String, _
                                                                        ByVal CREATE_TIME As String, _
                                                                        ByVal UPDATE_BY_ID As Integer, _
                                                                        ByVal UPDATE_BY_TEXT As String, _
                                                                        ByVal UPDATE_TIME As String, _
                                                                        ByVal LOGER_INFO As String
                                                                        ) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_CUSTOMER.INSERT_CCARE_CUSTOMER_INFO"
                .Parameters.Add(New OracleParameter("p_ID", OracleType.Int32, 50)).Direction = ParameterDirection.Output

                .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                .Parameters("p_USER_ID").Value = USER_ID

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

                .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_GROUP_TEXT").Value = GROUP_TEXT

                .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                .Parameters("p_MT").Value = MT

                .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                .Parameters("p_BRAND_ID").Value = BRAND_ID

                .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                .Parameters("p_DISTRICT_ID").Value = DISTRICT_ID

                .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                .Parameters("p_SEX_ID").Value = SEX_ID

                .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_SEX_TEXT").Value = SEX_TEXT

                .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 1000))
                .Parameters("p_FIELD_ID").Value = FIELD_ID

                .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 1000))
                .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                .Parameters("p_SOURCE_ID").Value = SOURCE_ID

                .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                .Parameters("p_KEY_WORD").Value = KEY_WORD

                .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                .Parameters("p_REMARK").Value = REMARK

                .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_CODE").Value = CUSTOMER_CODE

                .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_NAME").Value = CUSTOMER_NAME

                .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                .Parameters("p_BIRTH_DAY").Value = BIRTH_DAY

                .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_ADDRESS").Value = ADDRESS

                .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_EMAIL_ADDRESS").Value = EMAIL_ADDRESS

                .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                .Parameters("p_FEES_ID").Value = FEES_ID

                .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                .Parameters("p_INCOME_ID").Value = INCOME_ID

                .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                .Parameters("p_EXACTLY_RATE").Value = EXACTLY_RATE

                .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                .Parameters.Add(New OracleParameter("p_IS_VERIFY_1", OracleType.Number, 18))
                .Parameters("p_IS_VERIFY_1").Value = IS_VERIFY_1

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_ID", OracleType.Number, 18))
                .Parameters("p_VERIFY_BY_1_ID").Value = VERIFY_BY_1_ID

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_1_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_VERIFY_BY_1_TEXT").Value = VERIFY_BY_1_TEXT

                .Parameters.Add(New OracleParameter("p_VERIFY_TIME_1", OracleType.DateTime, 200))
                .Parameters("p_VERIFY_TIME_1").Value = VERIFY_TIME_1

                .Parameters.Add(New OracleParameter("p_IS_VERIFY_2", OracleType.Number, 18))
                .Parameters("p_IS_VERIFY_2").Value = IS_VERIFY_2

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_ID", OracleType.Number, 18))
                .Parameters("p_VERIFY_BY_2_ID").Value = VERIFY_BY_2_ID

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_2_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_VERIFY_BY_2_TEXT").Value = VERIFY_BY_2_TEXT

                .Parameters.Add(New OracleParameter("p_VERIFY_TIME_2", OracleType.DateTime, 200))
                .Parameters("p_VERIFY_TIME_2").Value = VERIFY_TIME_2

                .Parameters.Add(New OracleParameter("p_IS_VERIFY_3", OracleType.Number, 18))
                .Parameters("p_IS_VERIFY_3").Value = IS_VERIFY_3

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_ID", OracleType.Number, 18))
                .Parameters("p_VERIFY_BY_3_ID").Value = VERIFY_BY_3_ID

                .Parameters.Add(New OracleParameter("p_VERIFY_BY_3_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_VERIFY_BY_3_TEXT").Value = VERIFY_BY_3_TEXT

                .Parameters.Add(New OracleParameter("p_VERIFY_TIME_3", OracleType.DateTime, 200))
                .Parameters("p_VERIFY_TIME_3").Value = VERIFY_TIME_3

                .Parameters.Add(New OracleParameter("p_KEY_IMPORT", OracleType.VarChar, 200))
                .Parameters("p_KEY_IMPORT").Value = KEY_IMPORT

                .Parameters.Add(New OracleParameter("p_FILE_IMPORT", OracleType.VarChar, 200))
                .Parameters("p_FILE_IMPORT").Value = FILE_IMPORT

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

                .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                .Parameters("p_LOGER_INFO").Value = LOGER_INFO

                .Connection = conn
                Try
                    .ExecuteNonQuery()
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateCustomerInfo(ByVal ID As String, _
                                                                        ByVal USER_ID As String, _
                                                                        ByVal STATUS_ID As String, _
                                                                        ByVal STATUS_TEXT As String, _
                                                                        ByVal GROUP_TEXT As String, _
                                                                        ByVal MT As String, _
                                                                        ByVal BRAND_ID As String, _
                                                                        ByVal BRAND_NAME As String, _
                                                                        ByVal PARTNER_ID As String, _
                                                                        ByVal PARTNER_TEXT As String, _
                                                                        ByVal PROVINCE_ID As String, _
                                                                        ByVal PROVINCE_TEXT As String, _
                                                                        ByVal DISTRICT_ID As Integer, _
                                                                        ByVal DISTRICT_TEXT As String, _
                                                                        ByVal SEX_ID As String, _
                                                                        ByVal SEX_TEXT As String, _
                                                                        ByVal FIELD_ID As String, _
                                                                        ByVal FIELD_TEXT As String, _
                                                                        ByVal SOURCE_ID As String, _
                                                                        ByVal SOURCE_TEXT As String, _
                                                                        ByVal KEY_WORD As String, _
                                                                        ByVal REMARK As String, _
                                                                        ByVal CUSTOMER_CODE As String, _
                                                                        ByVal CUSTOMER_NAME As String, _
                                                                        ByVal BIRTH_DAY As String, _
                                                                        ByVal ADDRESS As String, _
                                                                        ByVal EMAIL_ADDRESS As String, _
                                                                        ByVal FEES_ID As String, _
                                                                        ByVal FEES_TEXT As String, _
                                                                        ByVal INCOME_ID As String, _
                                                                        ByVal INCOME_TEXT As String, _
                                                                        ByVal EXACTLY_RATE As String, _
                                                                        ByVal MOBILE_OPERATOR As String, _
                                                                        ByVal UPDATE_BY_ID As String, _
                                                                        ByVal UPDATE_BY_TEXT As String, _
                                                                        ByVal UPDATE_TIME As String, _
                                                                        ByVal LOGER_INFO As String
                                                                        ) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_CUSTOMER.UPDATE_CCARE_CUSTOMER_INFO"
                .Connection = conn

                .Parameters.Add(New OracleParameter("p_ID", OracleType.Number, 18))
                .Parameters("p_ID").Value = ID

                .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                .Parameters("p_USER_ID").Value = USER_ID

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

                .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_GROUP_TEXT").Value = GROUP_TEXT

                .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                .Parameters("p_MT").Value = MT

                .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                .Parameters("p_BRAND_ID").Value = BRAND_ID

                .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                .Parameters("p_DISTRICT_ID").Value = DISTRICT_ID

                .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                .Parameters("p_SEX_ID").Value = SEX_ID

                .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_SEX_TEXT").Value = SEX_TEXT

                .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 200))
                .Parameters("p_FIELD_ID").Value = FIELD_ID

                .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                .Parameters("p_SOURCE_ID").Value = SOURCE_ID

                .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                .Parameters("p_KEY_WORD").Value = KEY_WORD

                .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                .Parameters("p_REMARK").Value = REMARK

                .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_CODE").Value = CUSTOMER_CODE

                .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_NAME").Value = CUSTOMER_NAME

                .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                .Parameters("p_BIRTH_DAY").Value = BIRTH_DAY

                .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_ADDRESS").Value = ADDRESS

                .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_EMAIL_ADDRESS").Value = EMAIL_ADDRESS

                .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                .Parameters("p_FEES_ID").Value = FEES_ID

                .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                .Parameters("p_INCOME_ID").Value = INCOME_ID

                .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                .Parameters("p_EXACTLY_RATE").Value = EXACTLY_RATE

                .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                .Parameters("p_LOGER_INFO").Value = LOGER_INFO


                Try
                    .ExecuteNonQuery()
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function UpdateVerify_1(ByVal ID As String, _
                                                                      ByVal USER_ID As String, _
                                                                      ByVal STATUS_ID As String, _
                                                                      ByVal STATUS_TEXT As String, _
                                                                      ByVal GROUP_TEXT As String, _
                                                                      ByVal MT As String, _
                                                                      ByVal BRAND_ID As String, _
                                                                      ByVal BRAND_NAME As String, _
                                                                      ByVal PARTNER_ID As String, _
                                                                      ByVal PARTNER_TEXT As String, _
                                                                      ByVal PROVINCE_ID As String, _
                                                                      ByVal PROVINCE_TEXT As String, _
                                                                      ByVal DISTRICT_ID As String, _
                                                                      ByVal DISTRICT_TEXT As String, _
                                                                      ByVal SEX_ID As String, _
                                                                      ByVal SEX_TEXT As String, _
                                                                      ByVal FIELD_ID As String, _
                                                                      ByVal FIELD_TEXT As String, _
                                                                      ByVal SOURCE_ID As String, _
                                                                      ByVal SOURCE_TEXT As String, _
                                                                      ByVal KEY_WORD As String, _
                                                                      ByVal REMARK As String, _
                                                                      ByVal CUSTOMER_CODE As String, _
                                                                      ByVal CUSTOMER_NAME As String, _
                                                                      ByVal BIRTH_DAY As String, _
                                                                      ByVal ADDRESS As String, _
                                                                      ByVal EMAIL_ADDRESS As String, _
                                                                      ByVal FEES_ID As String, _
                                                                      ByVal FEES_TEXT As String, _
                                                                      ByVal INCOME_ID As String, _
                                                                      ByVal INCOME_TEXT As String, _
                                                                      ByVal EXACTLY_RATE As String, _
                                                                      ByVal MOBILE_OPERATOR As String, _
                                                                      ByVal UPDATE_BY_ID As String, _
                                                                      ByVal UPDATE_BY_TEXT As String, _
                                                                      ByVal UPDATE_TIME As String, _
                                                                      ByVal LOGER_INFO As String
                                                                      ) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_CUSTOMER.UPDATE_CCARE_CUSTOMER_VERIFY_1"
                .Connection = conn

                .Parameters.Add(New OracleParameter("p_ID", OracleType.Number, 18))
                .Parameters("p_ID").Value = ID

                .Parameters.Add(New OracleParameter("p_USER_ID", OracleType.NVarChar, 20))
                .Parameters("p_USER_ID").Value = USER_ID

                .Parameters.Add(New OracleParameter("p_STATUS_ID", OracleType.Number, 18))
                .Parameters("p_STATUS_ID").Value = STATUS_ID

                .Parameters.Add(New OracleParameter("p_STATUS_TEXT", OracleType.NVarChar, 20))
                .Parameters("p_STATUS_TEXT").Value = STATUS_TEXT

                .Parameters.Add(New OracleParameter("p_GROUP_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_GROUP_TEXT").Value = GROUP_TEXT

                .Parameters.Add(New OracleParameter("p_MT", OracleType.NVarChar, 1000))
                .Parameters("p_MT").Value = MT

                .Parameters.Add(New OracleParameter("p_BRAND_ID", OracleType.Number, 18))
                .Parameters("p_BRAND_ID").Value = BRAND_ID

                .Parameters.Add(New OracleParameter("p_BRAND_NAME", OracleType.NVarChar, 200))
                .Parameters("p_BRAND_NAME").Value = BRAND_NAME

                .Parameters.Add(New OracleParameter("p_PARTNER_ID", OracleType.Number, 18))
                .Parameters("p_PARTNER_ID").Value = PARTNER_ID

                .Parameters.Add(New OracleParameter("p_PARTNER_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PARTNER_TEXT").Value = PARTNER_TEXT

                .Parameters.Add(New OracleParameter("p_PROVINCE_ID", OracleType.Number, 18))
                .Parameters("p_PROVINCE_ID").Value = PROVINCE_ID

                .Parameters.Add(New OracleParameter("p_PROVINCE_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_PROVINCE_TEXT").Value = PROVINCE_TEXT

                .Parameters.Add(New OracleParameter("p_DISTRICT_ID", OracleType.Number, 18))
                .Parameters("p_DISTRICT_ID").Value = DISTRICT_ID

                .Parameters.Add(New OracleParameter("p_DISTRICT_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_DISTRICT_TEXT").Value = DISTRICT_TEXT

                .Parameters.Add(New OracleParameter("p_SEX_ID", OracleType.Number, 18))
                .Parameters("p_SEX_ID").Value = SEX_ID

                .Parameters.Add(New OracleParameter("p_SEX_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_SEX_TEXT").Value = SEX_TEXT

                .Parameters.Add(New OracleParameter("p_FIELD_ID", OracleType.NVarChar, 1000))
                .Parameters("p_FIELD_ID").Value = FIELD_ID

                .Parameters.Add(New OracleParameter("p_FIELD_TEXT", OracleType.NVarChar, 1000))
                .Parameters("p_FIELD_TEXT").Value = FIELD_TEXT

                .Parameters.Add(New OracleParameter("p_SOURCE_ID", OracleType.Number, 18))
                .Parameters("p_SOURCE_ID").Value = SOURCE_ID

                .Parameters.Add(New OracleParameter("p_SOURCE_TEXT", OracleType.NVarChar, 500))
                .Parameters("p_SOURCE_TEXT").Value = SOURCE_TEXT

                .Parameters.Add(New OracleParameter("p_KEY_WORD", OracleType.NVarChar, 200))
                .Parameters("p_KEY_WORD").Value = KEY_WORD

                .Parameters.Add(New OracleParameter("p_REMARK", OracleType.NVarChar, 1000))
                .Parameters("p_REMARK").Value = REMARK

                .Parameters.Add(New OracleParameter("p_CUSTOMER_CODE", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_CODE").Value = CUSTOMER_CODE

                .Parameters.Add(New OracleParameter("p_CUSTOMER_NAME", OracleType.NVarChar, 200))
                .Parameters("p_CUSTOMER_NAME").Value = CUSTOMER_NAME

                .Parameters.Add(New OracleParameter("p_BIRTH_DAY", OracleType.NVarChar, 200))
                .Parameters("p_BIRTH_DAY").Value = BIRTH_DAY

                .Parameters.Add(New OracleParameter("p_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_ADDRESS").Value = ADDRESS

                .Parameters.Add(New OracleParameter("p_EMAIL_ADDRESS", OracleType.NVarChar, 200))
                .Parameters("p_EMAIL_ADDRESS").Value = EMAIL_ADDRESS

                .Parameters.Add(New OracleParameter("p_FEES_ID", OracleType.Number, 18))
                .Parameters("p_FEES_ID").Value = FEES_ID

                .Parameters.Add(New OracleParameter("p_FEES_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_FEES_TEXT").Value = FEES_TEXT

                .Parameters.Add(New OracleParameter("p_INCOME_ID", OracleType.Number, 18))
                .Parameters("p_INCOME_ID").Value = INCOME_ID

                .Parameters.Add(New OracleParameter("p_INCOME_TEXT", OracleType.NVarChar, 200))
                .Parameters("p_INCOME_TEXT").Value = INCOME_TEXT

                .Parameters.Add(New OracleParameter("p_EXACTLY_RATE", OracleType.NVarChar, 200))
                .Parameters("p_EXACTLY_RATE").Value = EXACTLY_RATE

                .Parameters.Add(New OracleParameter("p_MOBILE_OPERATOR", OracleType.NVarChar, 200))
                .Parameters("p_MOBILE_OPERATOR").Value = MOBILE_OPERATOR

                .Parameters.Add(New OracleParameter("p_UPDATE_BY_ID", OracleType.Number, 18))
                .Parameters("p_UPDATE_BY_ID").Value = UPDATE_BY_ID

                .Parameters.Add(New OracleParameter("p_UPDATE_BY_TEXT", OracleType.VarChar, 200))
                .Parameters("p_UPDATE_BY_TEXT").Value = UPDATE_BY_TEXT

                .Parameters.Add(New OracleParameter("p_UPDATE_TIME", OracleType.DateTime, 200))
                .Parameters("p_UPDATE_TIME").Value = UPDATE_TIME

                .Parameters.Add(New OracleParameter("p_LOGER_INFO", OracleType.VarChar, 2000))
                .Parameters("p_LOGER_INFO").Value = LOGER_INFO


                Try
                    .ExecuteNonQuery()
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function MoveVerify_1_To_Info(ByVal ID As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_CUSTOMER.MOVE_CUSTOMER_VERIFY_1_TO_INFO"
                .Connection = conn

                .Parameters.Add(New OracleParameter("p_ID", OracleType.Number, 18))
                .Parameters("p_ID").Value = ID


                Try
                    .ExecuteNonQuery()
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
        Public Shared Function MoveImport_To_Info(ByVal ID As String) As String
            Dim str As String = ""
            Dim conn As New OracleConnection(IsSqlConnection.BuildSqlConnectionString(OracleConnectionStringCcare))
            If conn.State = ConnectionState.Closed Then
                Try
                    conn.Open()
                Catch ex As Exception
                    str = ex.Message
                    LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                    Return str
                End Try
            End If
            Dim cmd As New OracleCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "CCARE_CUSTOMER.MOVE_CUSTOMER_IMPORT_TO_INFO"
                .Connection = conn

                .Parameters.Add(New OracleParameter("p_ID", OracleType.Number, 18))
                .Parameters("p_ID").Value = ID


                Try
                    .ExecuteNonQuery()
                Catch ex As Exception
                    str = ex.Message
                End Try
            End With

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
                conn.Dispose()
            End If
            Return str
        End Function
    End Class
#End Region
#Region "Lott Interface"
    Public Class LottInterface
        Public Shared Function InsertCompanyUser(ByVal intUserId As Integer, ByVal intItemId As Integer) As String
            Dim retval As String = ""
            Dim cmd As New SqlCommand
            With cmd
                .Parameters.Clear()
                .Connection = GlobalConnection
                .CommandText = "Lott_Insert_User_Company"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.Int, 50))
                .Parameters("@User_Id").Value = intUserId

                .Parameters.Add(New SqlParameter("@Ref_Id", SqlDbType.Int, 50))
                .Parameters("@Ref_Id").Value = intItemId
            End With

            Try
                cmd.ExecuteNonQuery()
                retval = ""
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)

                retval = ex.Message
            End Try

            Return retval
        End Function
#Region "Update User TeleSales"
        Public Shared Function UpdateUserReportFunction(ByVal vUserId As Integer, ByVal vChannel_Lott_Report As Integer) As String
            Dim retval As String = ""
            Dim cmd As New SqlCommand
            With cmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Lott_Update_User_Report_Function"
                .Parameters.Add(New SqlParameter("@User_Id", SqlDbType.NVarChar, 50))
                .Parameters("@User_Id").Value = vUserId

                .Parameters.Add(New SqlParameter("@Channel_Lott_Report", SqlDbType.NVarChar, 250))
                .Parameters("@Channel_Lott_Report").Value = vChannel_Lott_Report
                .Connection = GlobalConnection
            End With

            Try
                cmd.ExecuteNonQuery()
                retval = ""
            Catch ex As Exception
                Dim strLog As String = Util.ExceptionLogInfo(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, New System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name, ex.Message)
                LogService.WriteLog(Constants.LogLevel._Error, strLog)

                retval = ex.Message
            End Try

            Return retval

        End Function
#End Region
    End Class
#End Region

End Class
