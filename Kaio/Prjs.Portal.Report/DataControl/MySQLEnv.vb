Public Class MySQLEnv
    Public Class BuildDataTable
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As DataTable
            Dim ds As DataSet = MySQLHelper.ExecuteDataset(sqlCon, CommandType.Text, sqlExc)
            Return ds.Tables(0)
        End Function
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String) As DataTable
            Dim ds As DataSet = MySQLHelper.ExecuteDataset(sqlCon, CommandType.StoredProcedure, sqlExc)
            Return ds.Tables(0)
        End Function
    End Class
    Public Class BuildDataSet
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As DataSet
            Dim ds As DataSet = MySQLHelper.ExecuteDataset(sqlCon, CommandType.Text, sqlExc)
            Return ds
        End Function
        Public Shared Function sqlStoredProc(ByVal sqlCon As String, ByVal sqlExc As String) As Integer
            Return MySQLHelper.ExecuteNonQuery(sqlCon, CommandType.StoredProcedure, sqlExc)
        End Function
    End Class
    Public Class ExecuteNonQuery
        Public Shared Function sqlText(ByVal sqlCon As String, ByVal sqlExc As String) As Integer
            Return MySQLHelper.ExecuteNonQuery(sqlCon, CommandType.Text, sqlExc)

        End Function
    End Class
End Class

