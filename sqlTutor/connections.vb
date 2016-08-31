'This class handles the main connections\queries to the Access database. 

Public Class connections
    Dim data As String = My.Settings.connection 'Stored connection string
    Dim conn As New OleDb.OleDbConnection(data) 'OleDb connection using stored connection string
    Dim cmd As New OleDb.OleDbCommand 'Query string
    Public da As OleDb.OleDbDataAdapter 'Data adapter
    Public ds As DataSet ' Data set to hold data
    Public params As New List(Of OleDb.OleDbParameter)
    Public count As Integer 'To capture the amount of records for statistics


    'Inserts a new record into the Access database during registration
    Public Sub register(ByVal email As String) 'Method to insert registered user into the database. 

        cmd.Connection = conn 'assigns the OleDb connection string as the OledbCommand connection
        Try
            conn.Open() 'Opens the connection
            If conn.State = ConnectionState.Open Then 'If the connection is open
                cmd.CommandText = "INSERT INTO Users (rankId, email) VALUES(7, '" & email & "')" 'Defines SQL Query
                cmd.ExecuteNonQuery() 'Executes SQL Query
                conn.Close() 'Closes the connection
            End If
        Catch ex As Exception
            'Handles any exceptions
        End Try
        If conn.State = ConnectionState.Open Then
            conn.Close() 'Ensures that the connection is closed after method execution
        End If
    End Sub

    'Query the database, accepts a string parameter and passes into an OLEDB command, using the OleDb connection
    Public Sub queryData(Query As String) 'Method to query the database
        Try
            conn.Open() 'Opens the connection
            cmd = New OleDb.OleDbCommand(Query, conn) 'Defines the SQL command (using the OleDb connection and the Query String)
            params.ForEach(Sub(x) cmd.Parameters.Add(x)) 'Adds the parameters of the query
            params.Clear() 'Clears the parameters
            ds = New DataSet 'Instance of a new Dataset
            da = New OleDb.OleDbDataAdapter(cmd) 'Instance of a new DataAdapter
            count = da.Fill(ds) 'Retrieves the result count and passes the value to the count variable (For statistical use)
            conn.Close() 'Closes the connection
        Catch ex As Exception
            'Handles any exceptions
        End Try

        If conn.State = ConnectionState.Open Then
            conn.Close() 'Ensures that the connection is closed after method execution
        End If

    End Sub

End Class
