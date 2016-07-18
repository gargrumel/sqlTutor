

Public Class connections
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Watchtower\Dropbox\EAAD\sqlTutor\sqlTutor\App_Data\eLearning.accdb;Persist Security Info=True")
    Dim cmd As New OleDb.OleDbCommand
    Public da As OleDb.OleDbDataAdapter
    Public ds As DataSet
    Public params As New List(Of OleDb.OleDbParameter)
    Public count As Integer 'To capture the amount of records for statistics

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

    Public Sub queryData(Query As String) 'Method to query the database
        Try
            conn.Open() 'Opens the connection
            cmd = New OleDb.OleDbCommand(Query, conn) 'Defines the SQL command (using the Oledb connection and the Query String)
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

    Public Sub addParam(Name As String, Value As Object)
        Dim newParam As New OleDb.OleDbParameter(Name, Value)
        params.Add(newParam)
    End Sub

End Class
