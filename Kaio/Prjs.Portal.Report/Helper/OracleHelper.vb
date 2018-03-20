'If you have any further queries . please contact rajesh158@hotmail.com

Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Xml
Imports System.Collections
Imports System.Data.OracleClient


Public NotInheritable Class OracleHelper
#Region "private utility methods & constructors"

    Private Sub New()
    End Sub



    ''' <summary>
    ''' This method is used to attach array of OracleParameters to a OracleCommand.
    ''' 
    ''' This method will assign a value of DbNull to any parameter with a direction of
    ''' InputOutput and a value of null.  
    ''' 
    ''' This behavior will prevent default values from being used, but
    ''' this will be the less common case than an intended pure output parameter (derived as InputOutput)
    ''' where the user provided no input value.
    ''' </summary>
    ''' <param name="command">The command to which the parameters will be added</param>
    ''' <param name="commandParameters">an array of OracleParameters tho be added to command</param>
    Private Shared Sub AttachParameters(ByVal command As OracleCommand, ByVal commandParameters As OracleParameter())
        For Each p As OracleParameter In commandParameters
            'check for derived output value with no value assigned
            If (p.Direction = ParameterDirection.InputOutput) AndAlso (p.Value Is Nothing) Then
                p.Value = DBNull.Value
            End If
            command.Parameters.Add(p)
        Next
    End Sub

    ''' <summary>
    ''' This method assigns an array of values to an array of OracleParameters.
    ''' </summary>
    ''' <param name="commandParameters">array of OracleParameters to be assigned values</param>
    ''' <param name="parameterValues">array of objects holding the values to be assigned</param>
    Private Shared Sub AssignParameterValues(ByVal commandParameters As OracleParameter(), ByVal parameterValues As Object())
        If (commandParameters Is Nothing) OrElse (parameterValues Is Nothing) Then
            'do nothing if we get no data
            Return
        End If

        ' we must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        'iterate through the OracleParameters, assigning the values from the corresponding position in the 
        'value array
        Dim i As Integer = 0, j As Integer = commandParameters.Length
        While i < j
            commandParameters(i).Value = parameterValues(i)
            i += 1
        End While
    End Sub

    ''' <summary>
    ''' This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    ''' to the provided command.
    ''' </summary>
    ''' <param name="command">the OracleCommand to be prepared</param>
    ''' <param name="connection">a valid OracleConnection, on which to execute this command</param>
    ''' <param name="transaction">a valid OracleTransaction, or 'null'</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of OracleParameters to be associated with the command or 'null' if no parameters are required</param>
    Private Shared Sub PrepareCommand(ByVal command As OracleCommand, ByVal connection As OracleConnection, ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal commandParameters As OracleParameter())
        'if the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If

        'associate the connection with the command
        command.Connection = connection

        'set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        'if we were provided a transaction, assign it.
        'command.Transaction = transaction;
        If transaction IsNot Nothing Then
        End If

        'set the command type
        command.CommandType = commandType

        'attach the command parameters if they are provided
        If commandParameters IsNot Nothing Then
            AttachParameters(command, commandParameters)
        End If

        Return
    End Sub


#End Region

#Region "ExecuteNonQuery"

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteNonQuery(connectionString, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Integer
        'create & open a OracleConnection, and dispose of it after we are done.
        Using cn As New OracleConnection(connectionString)
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteNonQuery(cn, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns no resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored prcedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset and takes no parameters) against the provided OracleConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteNonQuery(connection, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset) against the specified OracleConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Integer
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, connection, DirectCast(Nothing, OracleTransaction), commandType, commandText, commandParameters)

        'finally, execute the command.
        Dim retval As Integer = cmd.ExecuteNonQuery()

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns no resultset) against the specified OracleConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As OracleConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset and takes no parameters) against the provided OracleTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteNonQuery(transaction, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns no resultset) against the specified OracleTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Integer
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

        'finally, execute the command.
        Dim retval As Integer = cmd.ExecuteNonQuery()

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns no resultset) against the specified 
    ''' OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As OracleTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function


#End Region

#Region "ExecuteDataSet"

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteDataset(connectionString, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As DataSet
        'create & open a OracleConnection, and dispose of it after we are done.
        Using cn As New OracleConnection(connectionString)
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(cn, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteDataset(connection, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As DataSet
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, connection, DirectCast(Nothing, OracleTransaction), commandType, commandText, commandParameters)

        'create the DataAdapter & DataSet
        Dim da As New OracleDataAdapter(cmd)
        Dim ds As New DataSet()

        'fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds)

        ' detach the OracleParameters from the command object, so they can be used again.			
        cmd.Parameters.Clear()

        'return the dataset
        Return ds
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As OracleConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteDataset(transaction, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As DataSet
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

        'create the DataAdapter & DataSet
        Dim da As New OracleDataAdapter(cmd)
        Dim ds As New DataSet()

        'fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds)

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()

        'return the dataset
        Return ds
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified 
    ''' OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As OracleTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteReader"

    ''' <summary>
    ''' this enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
    ''' we can set the appropriate CommandBehavior when calling ExecuteReader()
    ''' </summary>
    Private Enum OracleConnectionOwnership
        ''' <summary>Connection is owned and managed by SqlHelper</summary>
        Internal
        ''' <summary>Connection is owned and managed by the caller</summary>
        External
    End Enum

    ''' <summary>
    ''' Create and prepare a OracleCommand, and call ExecuteReader with the appropriate CommandBehavior.
    ''' </summary>
    ''' <remarks>
    ''' If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
    ''' 
    ''' If the caller provided the connection, we want to leave it to them to manage.
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection, on which to execute this command</param>
    ''' <param name="transaction">a valid OracleTransaction, or 'null'</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of OracleParameters to be associated with the command or 'null' if no parameters are required</param>
    ''' <param name="connectionOwnership">indicates whether the connection parameter was provided by the caller, or created by SqlHelper</param>
    ''' <returns>OracleDataReader containing the results of the command</returns>
    Private Shared Function ExecuteReader(ByVal connection As OracleConnection, ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal commandParameters As OracleParameter(), ByVal connectionOwnership As OracleConnectionOwnership) As OracleDataReader
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters)

        'create a reader
        Dim dr As OracleDataReader

        ' call ExecuteReader with the appropriate CommandBehavior
        If connectionOwnership = OracleConnectionOwnership.External Then
            dr = cmd.ExecuteReader()
        Else
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        End If

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()

        Return dr
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As OracleDataReader
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteReader(connectionString, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As OracleDataReader
        'create & open a OracleConnection
        Dim cn As New OracleConnection(connectionString)
        cn.Open()

        Try
            'call the private overload that takes an internally owned connection in place of the connection string
            Return ExecuteReader(cn, Nothing, commandType, commandText, commandParameters, OracleConnectionOwnership.Internal)
        Catch
            'if we fail to return the SqlDatReader, we need to close the connection ourselves
            cn.Close()
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(connString, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As OracleDataReader
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String) As OracleDataReader
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteReader(connection, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As OracleDataReader
        'pass through the call to the private overload using a null transaction value and an externally owned connection
        Return ExecuteReader(connection, DirectCast(Nothing, OracleTransaction), commandType, commandText, commandParameters, OracleConnectionOwnership.External)
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As OracleConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As OracleDataReader
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String) As OracleDataReader
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteReader(transaction, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''   OracleDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As OracleDataReader
        'pass through to private overload, indicating that the connection is owned by the caller
        Return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, OracleConnectionOwnership.External)
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified
    ''' OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  OracleDataReader dr = ExecuteReader(trans, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a OracleDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As OracleTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As OracleDataReader
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteScalar"

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Object
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteScalar(connectionString, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Object
        'create & open a OracleConnection, and dispose of it after we are done.
        Using cn As New OracleConnection(connectionString)
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(cn, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a 1x1 resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset and takes no parameters) against the provided OracleConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String) As Object
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteScalar(connection, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset) against the specified OracleConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Object
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, connection, DirectCast(Nothing, OracleTransaction), commandType, commandText, commandParameters)

        'execute the command & return the results
        Dim retval As Object = cmd.ExecuteScalar()

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()
        Return retval

    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a 1x1 resultset) against the specified OracleConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As OracleConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset and takes no parameters) against the provided OracleTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String) As Object
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteScalar(transaction, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a 1x1 resultset) against the specified OracleTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As Object
        'create a command and prepare it for execution
        Dim cmd As New OracleCommand()
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

        'execute the command & return the results
        Dim retval As Object = cmd.ExecuteScalar()

        ' detach the OracleParameters from the command object, so they can be used again.
        cmd.Parameters.Clear()
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a 1x1 resultset) against the specified
    ''' OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As OracleTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteXmlReader"

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command using "FOR XML AUTO"</param>
    ''' <returns>an XmlReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String) As XmlReader
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteXmlReader(connection, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(conn, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command using "FOR XML AUTO"</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an XmlReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal connection As OracleConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As XmlReader
        'create a command and prepare it for execution
        ''Dim cmd As New OracleCommand()
        ''PrepareCommand(cmd, connection, DirectCast(Nothing, OracleTransaction), commandType, commandText, commandParameters)

        ' ''create the DataAdapter & DataSet
        ''Dim retval As XmlReader = cmd.ExecuteXmlReader()

        ' '' detach the OracleParameters from the command object, so they can be used again.
        ''cmd.Parameters.Clear()
        ''Return retval

    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified OracleConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(conn, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">a valid OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure using "FOR XML AUTO"</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>an XmlReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal connection As OracleConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As XmlReader
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset and takes no parameters) against the provided OracleTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command using "FOR XML AUTO"</param>
    ''' <returns>an XmlReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String) As XmlReader
        'pass through the call providing null for the set of OracleParameters
        Return ExecuteXmlReader(transaction, commandType, commandText, DirectCast(Nothing, OracleParameter()))
    End Function

    ''' <summary>
    ''' Execute a OracleCommand (that returns a resultset) against the specified OracleTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(trans, CommandType.StoredProcedure, "GetOrders", new OracleParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command using "FOR XML AUTO"</param>
    ''' <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    ''' <returns>an XmlReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal transaction As OracleTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter()) As XmlReader
        ''create a command and prepare it for execution
        'Dim cmd As New OracleCommand()
        'PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters)

        ''create the DataAdapter & DataSet
        'Dim retval As XmlReader = cmd.ExecuteXmlReader()

        '' detach the OracleParameters from the command object, so they can be used again.
        'cmd.Parameters.Clear()
        'Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a OracleCommand (that returns a resultset) against the specified 
    ''' OracleTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  XmlReader r = ExecuteXmlReader(trans, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">a valid OracleTransaction</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>a dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteXmlReader(ByVal transaction As OracleTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As XmlReader
        'if we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As OracleParameter() = OracleDataAccessParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of OracleParameters
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            'otherwise we can just call the SP without params
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function


#End Region
End Class
Public NotInheritable Class OracleDataAccessParameterCache
#Region "private methods, variables, and constructors"

    'Since this class provides only static methods, make the default constructor private to prevent 
    'instances from being created with "new OracleDataAccessParameterCache()".
    Private Sub New()
    End Sub

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable())

    ''' <summary>
    ''' resolve at run time the appropriate set of OracleParameters for a stored procedure
    ''' </summary>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
    ''' <returns></returns>
    Private Shared Function DiscoverSpParameterSet(ByVal connectionString As String, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As OracleParameter()
        Using cn As New OracleConnection(connectionString)
            Using cmd As New OracleCommand(spName, cn)
                cn.Open()
                cmd.CommandType = CommandType.StoredProcedure


                'OracleCommandBuilder.DeriveParameters(cmd);

                If Not includeReturnValueParameter Then
                    cmd.Parameters.RemoveAt(0)
                End If

                Dim discoveredParameters As OracleParameter() = New OracleParameter(cmd.Parameters.Count - 1) {}



                cmd.Parameters.CopyTo(discoveredParameters, 0)

                Return discoveredParameters
            End Using
        End Using
    End Function

    'deep copy of cached OracleParameter array
    Private Shared Function CloneParameters(ByVal originalParameters As OracleParameter()) As OracleParameter()
        Dim clonedParameters As OracleParameter() = New OracleParameter(originalParameters.Length - 1) {}

        Dim i As Integer = 0, j As Integer = originalParameters.Length
        While i < j
            clonedParameters(i) = DirectCast(DirectCast(originalParameters(i), ICloneable).Clone(), OracleParameter)
            i += 1
        End While

        Return clonedParameters
    End Function

#End Region

#Region "caching functions"

    ''' <summary>
    ''' add parameter array to the cache
    ''' </summary>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <param name="commandParameters">an array of SqlParamters to be cached</param>
    Public Shared Sub CacheParameterSet(ByVal connectionString As String, ByVal commandText As String, ByVal ParamArray commandParameters As OracleParameter())
        Dim hashKey As String = connectionString & ":" & commandText

        paramCache(hashKey) = commandParameters
    End Sub

    ''' <summary>
    ''' retrieve a parameter array from the cache
    ''' </summary>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="commandText">the stored procedure name or PL/SQL command</param>
    ''' <returns>an array of SqlParamters</returns>
    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As OracleParameter()
        Dim hashKey As String = connectionString & ":" & commandText

        Dim cachedParameters As OracleParameter() = DirectCast(paramCache(hashKey), OracleParameter())

        If cachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(cachedParameters)
        End If
    End Function

#End Region

#Region "Parameter Discovery Functions"

    ''' <summary>
    ''' Retrieves the set of OracleParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <returns>an array of OracleParameters</returns>
    Public Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As OracleParameter()
        Return GetSpParameterSet(connectionString, spName, False)
    End Function

    ''' <summary>
    ''' Retrieves the set of OracleParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connectionString">a valid connection string for a OracleConnection</param>
    ''' <param name="spName">the name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
    ''' <returns>an array of OracleParameters</returns>
    Public Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As OracleParameter()
        Dim hashKey As String = connectionString & ":" & spName & (If(includeReturnValueParameter, ":include ReturnValue Parameter", ""))

        Dim cachedParameters As OracleParameter()

        cachedParameters = DirectCast(paramCache(hashKey), OracleParameter())

        If cachedParameters Is Nothing Then
            cachedParameters = DirectCast(InlineAssignHelper(paramCache(hashKey), DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter)), OracleParameter())
        End If

        Return CloneParameters(cachedParameters)
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

#End Region

End Class
