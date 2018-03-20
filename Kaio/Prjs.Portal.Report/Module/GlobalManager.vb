Module GlobalManager
#Region "Global"
#Region "Manager Connection"
    Public GlobalConnection As SqlClient.SqlConnection
#End Region
#Region "Manager Connection String"
    Public Const MSSQLConnectionStringGlobal As String = "SqlConnectionString"
    Public Const MSSQLConnectionStringHQReport As String = "SqlConnectionStringHQReport"

    Public Const OracleConnectionStringCcare As String = "SqlConnectionStringCcare"

    Public Const MySQLConnectionStringCardCharging As String = "SqlConnectionStringCardCharging"
    Public Const MySQLConnectionStringCardChargingBiz As String = "SqlConnectionStringCardChargingBiz"

#End Region
#Region "Manager Action Database"
    Public Function OpenGlobalConnection() As String
        Dim retval As String = ""
        GlobalConnection = New SqlClient.SqlConnection(IsSqlConnection.BuildSqlConnectionString(MSSQLConnectionStringGlobal))
        If GlobalConnection.State = ConnectionState.Closed Then
            Try
                GlobalConnection.Open()
            Catch ex As Exception
                LogService.WriteLog(Constants.LogLevel._Error, ex.Message)
                retval = ex.Message
            End Try
        End If
        Return retval
    End Function

#End Region
#Region "Channel Control"
    'Public Administrator As Boolean = False
    'Public AndroidApps As Boolean = False
    'Public SMS As Boolean = False
    'Public S2 As Boolean = False
    'Public Vinabox As Boolean = False
    'Public GamePortal As Boolean = False

    'Public Vishare As Boolean = False
    'Public CustomerInfo As Boolean = False
#End Region
#End Region
End Module
