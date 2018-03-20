' ===============================================================================
' Microsoft Data Access Application Block for .NET
' http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
'
' SQLHelper.cs
'
' This file contains the implementations of the MySQLHelper and MySQLHelperParameterCache
' classes.
'
' For more information see the Data Access Application Block Implementation Overview. 
' ===============================================================================
' Release history
' VERSION	DESCRIPTION
'   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
'
' ===============================================================================
' Copyright (C) 2000-2001 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
' FITNESS FOR A PARTICULAR PURPOSE.
' ==============================================================================

Imports System.Collections
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports MySql.Data.MySqlClient
Imports System.Data.OleDb

''' <summary>
''' The MySQLHelper class is intended to encapsulate high performance, scalable best practices for 
''' common uses of SqlClient
''' </summary>
Public NotInheritable Class MySQLHelper
#Region "private utility methods & constructors"

    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new MySQLHelper()"
    Private Sub New()
    End Sub

    ''' <summary>
    ''' This method is used to attach array of MySqlParameters to a MySqlCommand.
    ''' 
    ''' This method will assign a value of DbNull to any parameter with a direction of
    ''' InputOutput and a value of null.  
    ''' 
    ''' This behavior will prevent default values from being used, but
    ''' this will be the less common case than an intended pure output parameter (derived as InputOutput)
    ''' where the user provided no input value.
    ''' </summary>
    ''' <param name="command">The command to which the parameters will be added</param>
    ''' <param name="commandParameters">An array of MySqlParameters to be added to command</param>
    Private Shared Sub AttachParameters(ByVal command As MySqlCommand, ByVal commandParameters As MySqlParameter())
        If command Is Nothing Then
            Throw New ArgumentNullException("command")
        End If
        If commandParameters IsNot Nothing Then
            For Each p As MySqlParameter In commandParameters
                If p IsNot Nothing Then
                    ' Check for derived output value with no value assigned
                    If (p.Direction = ParameterDirection.InputOutput OrElse p.Direction = ParameterDirection.Input) AndAlso (p.Value Is Nothing) Then
                        p.Value = DBNull.Value
                    End If
                    command.Parameters.Add(p)
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' This method assigns dataRow column values to an array of MySqlParameters
    ''' </summary>
    ''' <param name="commandParameters">Array of MySqlParameters to be assigned values</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values</param>
    Private Shared Sub AssignParameterValues(ByVal commandParameters As MySqlParameter(), ByVal dataRow As DataRow)
        If (commandParameters Is Nothing) OrElse (dataRow Is Nothing) Then
            ' Do nothing if we get no data
            Return
        End If

        Dim i As Integer = 0
        ' Set the parameters values
        For Each commandParameter As MySqlParameter In commandParameters
            ' Check the parameter name
            If commandParameter.ParameterName Is Nothing OrElse commandParameter.ParameterName.Length <= 1 Then
                Throw New Exception(String.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", i, commandParameter.ParameterName))
            End If
            If dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) <> -1 Then
                commandParameter.Value = dataRow(commandParameter.ParameterName.Substring(1))
            End If
            i += 1
        Next
    End Sub

    ''' <summary>
    ''' This method assigns an array of values to an array of MySqlParameters
    ''' </summary>
    ''' <param name="commandParameters">Array of MySqlParameters to be assigned values</param>
    ''' <param name="parameterValues">Array of objects holding the values to be assigned</param>
    Private Shared Sub AssignParameterValues(ByVal commandParameters As MySqlParameter(), ByVal parameterValues As Object())
        If (commandParameters Is Nothing) OrElse (parameterValues Is Nothing) Then
            ' Do nothing if we get no data
            Return
        End If

        ' We must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        ' Iterate through the MySqlParameters, assigning the values from the corresponding position in the 
        ' value array
        Dim i As Integer = 0, j As Integer = commandParameters.Length
        While i < j
            ' If the current array value derives from IDbDataParameter, then assign its Value property
            If TypeOf parameterValues(i) Is IDbDataParameter Then
                Dim paramInstance As IDbDataParameter = DirectCast(parameterValues(i), IDbDataParameter)
                If paramInstance.Value Is Nothing Then
                    commandParameters(i).Value = DBNull.Value
                Else
                    commandParameters(i).Value = paramInstance.Value
                End If
            ElseIf parameterValues(i) Is Nothing Then
                commandParameters(i).Value = DBNull.Value
            Else
                commandParameters(i).Value = parameterValues(i)
            End If
            i += 1
        End While
    End Sub

    ''' <summary>
    ''' This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    ''' to the provided command
    ''' </summary>
    ''' <param name="command">The MySqlCommand to be prepared</param>
    ''' <param name="connection">A valid MySqlConnection, on which to execute this command</param>
    ''' <param name="transaction">A valid MySqlTransaction, or 'null'</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of MySqlParameters to be associated with the command or 'null' if no parameters are required</param>
    ''' <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
    Private Shared Sub PrepareCommand(ByVal command As MySqlCommand, ByVal connection As MySqlConnection, ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal commandParameters As MySqlParameter(), _
     ByRef mustCloseConnection As Boolean)
        If command Is Nothing Then
            Throw New ArgumentNullException("command")
        End If
        If commandText Is Nothing OrElse commandText.Length = 0 Then
            Throw New ArgumentNullException("commandText")
        End If

        ' If the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            mustCloseConnection = True
            connection.Open()
        Else
            mustCloseConnection = False
        End If

        ' Associate the connection with the command
        command.Connection = connection

        ' Set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        ' If we were provided a transaction, assign it
        If transaction IsNot Nothing Then
            If transaction.Connection Is Nothing Then
                Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
            End If
            command.Transaction = transaction
        End If

        ' Set the command type
        command.CommandType = commandType

        ' Attach the command parameters if they are provided
        If commandParameters IsNot Nothing Then
            AttachParameters(command, commandParameters)
        End If
        Return
    End Sub

#End Region

#Region "ExecuteNonQuery"

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset and takes no parameters) against the database specified in 
    ''' the connection string
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteNonQuery(connectionString, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset) against the database specified in the connection string 
    ''' using the provided parameters
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Integer
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If

        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteNonQuery(connection, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored prcedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset and takes no parameters) against the provided MySqlConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteNonQuery(connection, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset) against the specified MySqlConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Integer
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, connection, DirectCast(Nothing, MySqlTransaction), commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Finally, execute the command
        Dim retval As Integer = cmd.ExecuteNonQuery()

        ' Detach the MySqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()
        If mustCloseConnection Then
            connection.Close()
        End If
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified MySqlConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal connection As MySqlConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset and takes no parameters) against the provided MySqlTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteNonQuery(transaction, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns no resultset) against the specified MySqlTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Integer
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Finally, execute the command
        Dim retval As Integer = cmd.ExecuteNonQuery()

        ' Detach the MySqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified 
    ''' MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQuery(ByVal transaction As MySqlTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Integer
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteDataset"

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteDataset(connectionString, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As DataSet
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If

        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(connection, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteDataset(connection, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As DataSet
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, connection, DirectCast(Nothing, MySqlTransaction), commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Create the DataAdapter & DataSet
        Using da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet()

            ' Fill the DataSet using default values for DataTable names, etc
            da.Fill(ds)

            ' Detach the MySqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            If mustCloseConnection Then
                connection.Close()
            End If

            ' Return the dataset
            Return ds
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal connection As MySqlConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteDataset(transaction, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As DataSet
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Create the DataAdapter & DataSet
        Using da As New MySqlDataAdapter(cmd)
            Dim ds As New DataSet()

            ' Fill the DataSet using default values for DataTable names, etc
            da.Fill(ds)

            ' Detach the MySqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            ' Return the dataset
            Return ds
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified 
    ''' MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDataset(ByVal transaction As MySqlTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As DataSet
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteReader"

    ''' <summary>
    ''' This enum is used to indicate whether the connection was provided by the caller, or created by MySQLHelper, so that
    ''' we can set the appropriate CommandBehavior when calling ExecuteReader()
    ''' </summary>
    Private Enum MySqlConnectionOwnership
        ''' <summary>Connection is owned and managed by MySQLHelper</summary>
        Internal
        ''' <summary>Connection is owned and managed by the caller</summary>
        External
    End Enum

    ''' <summary>
    ''' Create and prepare a MySqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
    ''' </summary>
    ''' <remarks>
    ''' If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
    ''' 
    ''' If the caller provided the connection, we want to leave it to them to manage.
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection, on which to execute this command</param>
    ''' <param name="transaction">A valid MySqlTransaction, or 'null'</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of MySqlParameters to be associated with the command or 'null' if no parameters are required</param>
    ''' <param name="connectionOwnership">Indicates whether the connection parameter was provided by the caller, or created by MySQLHelper</param>
    ''' <returns>MySqlDataReader containing the results of the command</returns>
    Private Shared Function ExecuteReader(ByVal connection As MySqlConnection, ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal commandParameters As MySqlParameter(), ByVal connectionOwnership As MySqlConnectionOwnership) As MySqlDataReader
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If

        Dim mustCloseConnection As Boolean = False
        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Try
            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, _
             mustCloseConnection)

            ' Create a reader
            Dim dataReader As MySqlDataReader

            ' Call ExecuteReader with the appropriate CommandBehavior
            If connectionOwnership = MySqlConnectionOwnership.External Then
                dataReader = cmd.ExecuteReader()
            Else
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            ' Detach the MySqlParameters from the command object, so they can be used again.
            ' HACK: There is a problem here, the output parameter values are fletched 
            ' when the reader is closed, so if the parameters are detached from the command
            ' then the SqlReader can´t set its values. 
            ' When this happen, the parameters can´t be used again in other command.
            Dim canClear As Boolean = True
            For Each commandParameter As MySqlParameter In cmd.Parameters
                If commandParameter.Direction <> ParameterDirection.Input Then
                    canClear = False
                End If
            Next

            If canClear Then
                cmd.Parameters.Clear()
            End If

            Return dataReader
        Catch
            If mustCloseConnection Then
                connection.Close()
            End If
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As MySqlDataReader
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteReader(connectionString, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As MySqlDataReader
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        Dim connection As MySqlConnection = Nothing
        Try
            connection = New MySqlConnection(connectionString)
            connection.Open()

            ' Call the private overload that takes an internally owned connection in place of the connection string
            Return ExecuteReader(connection, Nothing, commandType, commandText, commandParameters, MySqlConnectionOwnership.Internal)
        Catch
            ' If we fail to return the SqlDatReader, we need to close the connection ourselves
            If connection IsNot Nothing Then
                connection.Close()
            End If
            Throw
        End Try

    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(connString, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As MySqlDataReader
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String) As MySqlDataReader
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteReader(connection, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As MySqlDataReader
        ' Pass through the call to the private overload using a null transaction value and an externally owned connection
        Return ExecuteReader(connection, DirectCast(Nothing, MySqlTransaction), commandType, commandText, commandParameters, MySqlConnectionOwnership.External)
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal connection As MySqlConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As MySqlDataReader
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String) As MySqlDataReader
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteReader(transaction, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''   MySqlDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As MySqlDataReader
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If

        ' Pass through to private overload, indicating that the connection is owned by the caller
        Return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, MySqlConnectionOwnership.External)
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified
    ''' MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  MySqlDataReader dr = ExecuteReader(trans, "GetOrders", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReader(ByVal transaction As MySqlTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As MySqlDataReader
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteScalar"

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteScalar(connectionString, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Object
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(connection, commandType, commandText, commandParameters)
        End Using
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connectionString As String, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided MySqlConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteScalar(connection, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Object
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()

        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, connection, DirectCast(Nothing, MySqlTransaction), commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Execute the command & return the results
        Dim retval As Object = cmd.ExecuteScalar()

        ' Detach the MySqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        If mustCloseConnection Then
            connection.Close()
        End If

        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(conn, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal connection As MySqlConnection, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided MySqlTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of MySqlParameters
        Return ExecuteScalar(transaction, commandType, commandText, DirectCast(Nothing, MySqlParameter()))
    End Function

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter()) As Object
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If

        ' Create a command and prepare it for execution
        Dim cmd As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Execute the command & return the results
        Dim retval As Object = cmd.ExecuteScalar()

        ' Detach the MySqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()
        Return retval
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified
    ''' MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", 24, 36);
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalar(ByVal transaction As MySqlTransaction, ByVal spName As String, ByVal ParamArray parameterValues As Object()) As Object
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' PPull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "FillDataset"

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ''' the connection string. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)</param>
    Public Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String())
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If

        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames)
        End Using
    End Sub

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the database specified in the connection string 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    Public Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray commandParameters As MySqlParameter())
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If
        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters)
        End Using
    End Sub

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, 24);
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>    
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    Public Shared Sub FillDataset(ByVal connectionString As String, ByVal spName As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray parameterValues As Object())
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If
        ' Create & open a MySqlConnection, and dispose of it after we are done
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, spName, dataSet, tableNames, parameterValues)
        End Using
    End Sub

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlConnection. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>    
    Public Shared Sub FillDataset(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String())
        FillDataset(connection, commandType, commandText, dataSet, tableNames, Nothing)
    End Sub

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    Public Shared Sub FillDataset(ByVal connection As MySqlConnection, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray commandParameters As MySqlParameter())
        FillDataset(connection, Nothing, commandType, commandText, dataSet, tableNames, _
         commandParameters)
    End Sub

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  FillDataset(conn, "GetOrders", ds, new string[] {"orders"}, 24, 36);
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    Public Shared Sub FillDataset(ByVal connection As MySqlConnection, ByVal spName As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray parameterValues As Object())
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If
    End Sub

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlTransaction. 
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    Public Shared Sub FillDataset(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String())
        FillDataset(transaction, commandType, commandText, dataSet, tableNames, Nothing)
    End Sub

    ''' <summary>
    ''' Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    Public Shared Sub FillDataset(ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray commandParameters As MySqlParameter())
        FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, _
         commandParameters)
    End Sub

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified 
    ''' MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <remarks>
    ''' This method provides no access to output parameters or the stored procedure's return value parameter.
    ''' 
    ''' e.g.:  
    '''  FillDataset(trans, "GetOrders", ds, new string[]{"orders"}, 24, 36);
    ''' </remarks>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    ''' <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
    Public Shared Sub FillDataset(ByVal transaction As MySqlTransaction, ByVal spName As String, ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray parameterValues As Object())
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If we receive parameter values, we need to figure out where they go
        If (parameterValues IsNot Nothing) AndAlso (parameterValues.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of MySqlParameters
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else
            ' Otherwise we can just call the SP without params
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If
    End Sub

    ''' <summary>
    ''' Private helper method that execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction and MySqlConnection
    ''' using the provided parameters.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new MySqlParameter("@prodid", 24));
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection</param>
    ''' <param name="transaction">A valid MySqlTransaction</param>
    ''' <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
    ''' <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
    ''' by a user defined name (probably the actual table name)
    ''' </param>
    ''' <param name="commandParameters">An array of SqlParamters used to execute the command</param>
    Private Shared Sub FillDataset(ByVal connection As MySqlConnection, ByVal transaction As MySqlTransaction, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), _
     ByVal ParamArray commandParameters As MySqlParameter())
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If dataSet Is Nothing Then
            Throw New ArgumentNullException("dataSet")
        End If

        ' Create a command and prepare it for execution
        Dim command As New MySqlCommand()
        Dim mustCloseConnection As Boolean = False
        PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, _
         mustCloseConnection)

        ' Create the DataAdapter & DataSet
        Using dataAdapter As New MySqlDataAdapter(command)
            ' Add the table mappings specified by the user
            If tableNames IsNot Nothing AndAlso tableNames.Length > 0 Then
                Dim tableName As String = "Table"
                For index As Integer = 0 To tableNames.Length - 1
                    If tableNames(index) Is Nothing OrElse tableNames(index).Length = 0 Then
                        Throw New ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames")
                    End If
                    dataAdapter.TableMappings.Add(tableName, tableNames(index))
                    tableName += (index + 1).ToString()
                Next
            End If

            ' Fill the DataSet using default values for DataTable names, etc
            dataAdapter.Fill(dataSet)

            ' Detach the MySqlParameters from the command object, so they can be used again
            command.Parameters.Clear()
        End Using

        If mustCloseConnection Then
            connection.Close()
        End If
    End Sub

#End Region

#Region "UpdateDataset"

    ''' <summary>
    ''' Executes the respective command for each inserted, updated, or deleted row in the DataSet.
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  UpdateDataset(conn, insertCommand, deleteCommand, updateCommand, dataSet, "Order");
    ''' </remarks>
    ''' <param name="insertCommand">A valid transact-SQL statement or stored procedure to insert new records into the data source</param>
    ''' <param name="deleteCommand">A valid transact-SQL statement or stored procedure to delete records from the data source</param>
    ''' <param name="updateCommand">A valid transact-SQL statement or stored procedure used to update records in the data source</param>
    ''' <param name="dataSet">The DataSet used to update the data source</param>
    ''' <param name="tableName">The DataTable used to update the data source.</param>
    Public Shared Sub UpdateDataset(ByVal insertCommand As MySqlCommand, ByVal deleteCommand As MySqlCommand, ByVal updateCommand As MySqlCommand, ByVal dataSet As DataSet, ByVal tableName As String)
        If insertCommand Is Nothing Then
            Throw New ArgumentNullException("insertCommand")
        End If
        If deleteCommand Is Nothing Then
            Throw New ArgumentNullException("deleteCommand")
        End If
        If updateCommand Is Nothing Then
            Throw New ArgumentNullException("updateCommand")
        End If
        If tableName Is Nothing OrElse tableName.Length = 0 Then
            Throw New ArgumentNullException("tableName")
        End If

        ' Create a MySqlDataAdapter, and dispose of it after we are done
        Using dataAdapter As New MySqlDataAdapter()
            ' Set the data adapter commands
            dataAdapter.UpdateCommand = updateCommand
            dataAdapter.InsertCommand = insertCommand
            dataAdapter.DeleteCommand = deleteCommand

            ' Update the dataset changes in the data source
            dataAdapter.Update(dataSet, tableName)

            ' Commit all the changes made to the DataSet
            dataSet.AcceptChanges()
        End Using
    End Sub

#End Region

#Region "CreateCommand"

    ''' <summary>
    ''' Simplify the creation of a Sql command object by allowing
    ''' a stored procedure and optional parameters to be provided
    ''' </summary>
    ''' <remarks>
    ''' e.g.:  
    '''  MySqlCommand command = CreateCommand(conn, "AddCustomer", "CustomerID", "CustomerName");
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="sourceColumns">An array of string to be assigned as the source columns of the stored procedure parameters</param>
    ''' <returns>A valid MySqlCommand object</returns>
    Public Shared Function CreateCommand(ByVal connection As MySqlConnection, ByVal spName As String, ByVal ParamArray sourceColumns As String()) As MySqlCommand
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' Create a MySqlCommand
        Dim cmd As New MySqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure

        ' If we receive parameter values, we need to figure out where they go
        If (sourceColumns IsNot Nothing) AndAlso (sourceColumns.Length > 0) Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided source columns to these parameters based on parameter order
            For index As Integer = 0 To sourceColumns.Length - 1
                commandParameters(index).SourceColumn = sourceColumns(index)
            Next

            ' Attach the discovered parameters to the MySqlCommand object
            AttachParameters(cmd, commandParameters)
        End If

        Return cmd
    End Function

#End Region

#Region "ExecuteNonQueryTypedParams"

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the database specified in 
    ''' the connection string using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQueryTypedParams(ByVal connectionString As [String], ByVal spName As [String], ByVal dataRow As DataRow) As Integer
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified MySqlConnection 
    ''' using the dataRow column values as the stored procedure's parameters values.  
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQueryTypedParams(ByVal connection As MySqlConnection, ByVal spName As [String], ByVal dataRow As DataRow) As Integer
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified
    ''' MySqlTransaction using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="transaction">A valid MySqlTransaction object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An int representing the number of rows affected by the command</returns>
    Public Shared Function ExecuteNonQueryTypedParams(ByVal transaction As MySqlTransaction, ByVal spName As [String], ByVal dataRow As DataRow) As Integer
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' Sf the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteDatasetTypedParams"

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDatasetTypedParams(ByVal connectionString As String, ByVal spName As [String], ByVal dataRow As DataRow) As DataSet
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        'If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the dataRow column values as the store procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDatasetTypedParams(ByVal connection As MySqlConnection, ByVal spName As [String], ByVal dataRow As DataRow) As DataSet
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlTransaction 
    ''' using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on row values.
    ''' </summary>
    ''' <param name="transaction">A valid MySqlTransaction object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A dataset containing the resultset generated by the command</returns>
    Public Shared Function ExecuteDatasetTypedParams(ByVal transaction As MySqlTransaction, ByVal spName As [String], ByVal dataRow As DataRow) As DataSet
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteReaderTypedParams"

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
    ''' the connection string using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReaderTypedParams(ByVal connectionString As [String], ByVal spName As [String], ByVal dataRow As DataRow) As MySqlDataReader
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function


    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
    ''' using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReaderTypedParams(ByVal connection As MySqlConnection, ByVal spName As [String], ByVal dataRow As DataRow) As MySqlDataReader
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlTransaction 
    ''' using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="transaction">A valid MySqlTransaction object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>A MySqlDataReader containing the resultset generated by the command</returns>
    Public Shared Function ExecuteReaderTypedParams(ByVal transaction As MySqlTransaction, ByVal spName As [String], ByVal dataRow As DataRow) As MySqlDataReader
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

#Region "ExecuteScalarTypedParams"

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the database specified in 
    ''' the connection string using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalarTypedParams(ByVal connectionString As [String], ByVal spName As [String], ByVal dataRow As DataRow) As Object
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlConnection 
    ''' using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalarTypedParams(ByVal connection As MySqlConnection, ByVal spName As [String], ByVal dataRow As DataRow) As Object
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    ''' <summary>
    ''' Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlTransaction
    ''' using the dataRow column values as the stored procedure's parameters values.
    ''' This method will query the database to discover the parameters for the 
    ''' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ''' </summary>
    ''' <param name="transaction">A valid MySqlTransaction object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="dataRow">The dataRow used to hold the stored procedure's parameter values.</param>
    ''' <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
    Public Shared Function ExecuteScalarTypedParams(ByVal transaction As MySqlTransaction, ByVal spName As [String], ByVal dataRow As DataRow) As Object
        If transaction Is Nothing Then
            Throw New ArgumentNullException("transaction")
        End If
        If transaction IsNot Nothing AndAlso transaction.Connection Is Nothing Then
            Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        ' If the row has values, the store procedure parameters must be initialized
        If dataRow IsNot Nothing AndAlso dataRow.ItemArray.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters As MySqlParameter() = MySQLHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            Return MySQLHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            Return MySQLHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function

#End Region

End Class

''' <summary>
''' MySQLHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
''' ability to discover parameters for stored procedures at run-time.
''' </summary>
Public NotInheritable Class MySQLHelperParameterCache
#Region "private methods, variables, and constructors"

    'Since this class provides only static methods, make the default constructor private to prevent 
    'instances from being created with "new MySQLHelperParameterCache()"
    Private Sub New()
    End Sub

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable())

    ''' <summary>
    ''' Resolve at run time the appropriate set of MySqlParameters for a stored procedure
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
    ''' <returns>The parameter array discovered.</returns>
    Private Shared Function DiscoverSpParameterSet(ByVal connection As MySqlConnection, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As MySqlParameter()
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        Dim cmd As New MySqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure

        connection.Open()
        MySqlCommandBuilder.DeriveParameters(cmd)
        connection.Close()

        If Not includeReturnValueParameter Then
            cmd.Parameters.RemoveAt(0)
        End If

        Dim discoveredParameters As MySqlParameter() = New MySqlParameter(cmd.Parameters.Count - 1) {}

        cmd.Parameters.CopyTo(discoveredParameters, 0)

        ' Init the parameters with a DBNull value
        For Each discoveredParameter As MySqlParameter In discoveredParameters
            discoveredParameter.Value = DBNull.Value
        Next
        Return discoveredParameters
    End Function

    ''' <summary>
    ''' Deep copy of cached MySqlParameter array
    ''' </summary>
    ''' <param name="originalParameters"></param>
    ''' <returns></returns>
    Private Shared Function CloneParameters(ByVal originalParameters As MySqlParameter()) As MySqlParameter()
        Dim clonedParameters As MySqlParameter() = New MySqlParameter(originalParameters.Length - 1) {}

        Dim i As Integer = 0, j As Integer = originalParameters.Length
        While i < j
            clonedParameters(i) = DirectCast(DirectCast(originalParameters(i), ICloneable).Clone(), MySqlParameter)
            i += 1
        End While

        Return clonedParameters
    End Function

#End Region

#Region "caching functions"

    ''' <summary>
    ''' Add parameter array to the cache
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <param name="commandParameters">An array of SqlParamters to be cached</param>
    Public Shared Sub CacheParameterSet(ByVal connectionString As String, ByVal commandText As String, ByVal ParamArray commandParameters As MySqlParameter())
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If commandText Is Nothing OrElse commandText.Length = 0 Then
            Throw New ArgumentNullException("commandText")
        End If

        Dim hashKey As String = connectionString & ":" & commandText

        paramCache(hashKey) = commandParameters
    End Sub

    ''' <summary>
    ''' Retrieve a parameter array from the cache
    ''' </summary>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="commandText">The stored procedure name or T-SQL command</param>
    ''' <returns>An array of SqlParamters</returns>
    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As MySqlParameter()
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If commandText Is Nothing OrElse commandText.Length = 0 Then
            Throw New ArgumentNullException("commandText")
        End If

        Dim hashKey As String = connectionString & ":" & commandText

        Dim cachedParameters As MySqlParameter() = TryCast(paramCache(hashKey), MySqlParameter())
        If cachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(cachedParameters)
        End If
    End Function

#End Region

#Region "Parameter Discovery Functions"

    ''' <summary>
    ''' Retrieves the set of MySqlParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <returns>An array of MySqlParameters</returns>
    Public Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As MySqlParameter()
        Return GetSpParameterSet(connectionString, spName, False)
    End Function

    ''' <summary>
    ''' Retrieves the set of MySqlParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connectionString">A valid connection string for a MySqlConnection</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
    ''' <returns>An array of MySqlParameters</returns>
    Public Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As MySqlParameter()
        If connectionString Is Nothing OrElse connectionString.Length = 0 Then
            Throw New ArgumentNullException("connectionString")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        Using connection As New MySqlConnection(connectionString)
            Return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter)
        End Using
    End Function

    ''' <summary>
    ''' Retrieves the set of MySqlParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <returns>An array of MySqlParameters</returns>
    Friend Shared Function GetSpParameterSet(ByVal connection As MySqlConnection, ByVal spName As String) As MySqlParameter()
        Return GetSpParameterSet(connection, spName, False)
    End Function

    ''' <summary>
    ''' Retrieves the set of MySqlParameters appropriate for the stored procedure
    ''' </summary>
    ''' <remarks>
    ''' This method will query the database for this information, and then store it in a cache for future requests.
    ''' </remarks>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
    ''' <returns>An array of MySqlParameters</returns>
    Friend Shared Function GetSpParameterSet(ByVal connection As MySqlConnection, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As MySqlParameter()
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        Using clonedConnection As MySqlConnection = DirectCast(DirectCast(connection, ICloneable).Clone(), MySqlConnection)
            Return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter)
        End Using
    End Function

    ''' <summary>
    ''' Retrieves the set of MySqlParameters appropriate for the stored procedure
    ''' </summary>
    ''' <param name="connection">A valid MySqlConnection object</param>
    ''' <param name="spName">The name of the stored procedure</param>
    ''' <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
    ''' <returns>An array of MySqlParameters</returns>
    Private Shared Function GetSpParameterSetInternal(ByVal connection As MySqlConnection, ByVal spName As String, ByVal includeReturnValueParameter As Boolean) As MySqlParameter()
        If connection Is Nothing Then
            Throw New ArgumentNullException("connection")
        End If
        If spName Is Nothing OrElse spName.Length = 0 Then
            Throw New ArgumentNullException("spName")
        End If

        Dim hashKey As String = Convert.ToString(connection.ConnectionString) & ":" & spName & (If(includeReturnValueParameter, ":include ReturnValue Parameter", ""))

        Dim cachedParameters As MySqlParameter()

        'dungbeo
        cachedParameters = TryCast(paramCache(hashKey), MySqlParameter())
        If cachedParameters Is Nothing Then
            Dim spParameters As MySqlParameter() = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter)
            paramCache(hashKey) = spParameters
            cachedParameters = spParameters
        End If

        Return CloneParameters(cachedParameters)
    End Function

#End Region
End Class

