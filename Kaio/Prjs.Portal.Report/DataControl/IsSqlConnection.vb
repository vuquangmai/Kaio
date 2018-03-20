Imports System.Web.Configuration
Public Class IsSqlConnection
    Public Shared Function BuildSqlConnectionString(ByVal sql As String) As String
        Return WebConfigurationManager.ConnectionStrings(sql).ConnectionString
    End Function

End Class
