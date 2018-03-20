Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class MSSQLEnv
    Public Class BuildDataTable
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String) As DataTable
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, sqlExc)
            Return ds.Tables(0)
        End Function
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String, ByVal ParamArray commandParameters As SqlParameter()) As DataTable
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, sqlExc)
            Return ds.Tables(0)
        End Function
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As DataTable
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.Text, sqlExc)
            Return ds.Tables(0)
        End Function
    End Class
    Public Class BuildDataSet
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String) As DataSet
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, sqlExc)
            Return ds
        End Function
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String, ByVal ParamArray commandParameters As SqlParameter()) As DataSet
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, sqlExc)
            Return ds
        End Function
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As DataSet
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlCon, CommandType.Text, sqlExc)
            Return ds
        End Function
    End Class
    Public Class ExecuteNonQuery
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As Integer
            Return SqlHelper.ExecuteNonQuery(sqlCon, CommandType.Text, sqlExc)
        End Function
    End Class
    Public Class BuildDataReader
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As SqlDataReader
            Return SqlHelper.ExecuteReader(sqlCon, CommandType.Text, sqlExc)
        End Function
    End Class
    
End Class
