Imports System.Threading

Public Class IsLiveConnection
    Public Class MSSQLDatabaseGlobal
        Public Function IsConnection() As Boolean
            Dim rst As Boolean = False
            If GlobalManager.GlobalConnection.State = ConnectionState.Closed Or GlobalManager.GlobalConnection.State = ConnectionState.Broken Then
                rst = False
            Else
                rst = True
            End If
            LogService.WriteLog(Constants.LogLevel._Info, "The State Of Global Connection Is :" & GlobalManager.GlobalConnection.State.ToString)
            Return rst
            'Dim cmd As New SqlClient.SqlCommand
            'Dim rst As Boolean = False
            'With cmd
            '    .CommandType = CommandType.Text
            '    .CommandText = "select getdate()"
            '    .Connection = GlobalManager.GlobalConnection
            '    LogService.WriteLog(Constants.LogLevel._Info, .CommandText)
            '    Try
            '        .ExecuteNonQuery()
            '        rst = True
            '    Catch ex As Exception
            '        LogService.WriteLog(Constants.LogLevel._Error, "Error Connecting to Database . Code: " & ex.Message)
            '    Finally
            '    End Try
            'End With
            'Return rst
        End Function
        Public Sub IsCallBack()
            While True
                Try
                    Dim IntRetry As Integer = 0
                    If Not IsConnection() Then
                        While IntRetry < 3
                            LogService.WriteLog(Constants.LogLevel._Info, "The Connection Is Closed, The System Will Initiates a New Connection Right now")
                            If GlobalManager.OpenGlobalConnection().Trim = "" Then
                                IntRetry = 3
                            Else
                                IntRetry = IntRetry + 1
                                LogService.WriteLog(Constants.LogLevel._Error, "The System Can not Initialize a New Connection:#" & IntRetry)
                            End If
                        End While
                    End If
                    IntRetry = 0
                Catch ex As Exception
                    LogService.WriteLog(Constants.LogLevel._Error, "Error  Initialize a New Connection to Database Global. Code: " & ex.Message)
                End Try

                Dim vTime As Integer = 0
                If IsNumeric(ConfigurationManager.AppSettings("SystemCallBack")) = True Then
                    vTime = ConfigurationManager.AppSettings("SystemCallBack")
                Else
                    vTime = "30" ' 30 minutes defalut
                End If
                If vTime > 30 Then
                    vTime = 30
                End If
                Thread.Sleep(vTime * 60 * 1000)
                LogService.WriteLog(Constants.LogLevel._Info, "System will sleeping in " & vTime & " minutes ")
            End While
        End Sub
    End Class
End Class
