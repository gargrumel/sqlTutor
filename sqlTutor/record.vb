Public Class record
    'This class holds the methods to update the Lesson and User records. 
    Dim queryConn As New connections
    Public complete As Boolean 'Boolean value to validate id the lesson was completed.


    'Accepts two parameters and updates the 'Complete' table
    '@user The userId, @lesson The lessonId
    Public Sub completeLesson(ByVal user As Integer, ByVal lesson As Integer)
        Try
            queryConn.queryData("SELECT * FROM complete WHERE userId =" & user & " AND lessonId = " & lesson)
            If queryConn.count = 0 Then 'Only if the query does not return any results
                queryConn.queryData("INSERT into complete (userId, lessonId) VALUES (" & user & ", " & lesson & ")") 'Insert a new record with the supplied parameters
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Method to UPDATE the userProgress table
    Public Sub updateLesson(ByVal less As Integer, ByVal user As String, ByVal progress As Integer)
        Try
            queryConn.queryData("SELECT * from userProgress WHERE userID = " & user) 'Queries the userProgress table using the userId as a parameter
            If queryConn.count = 0 Then 'If no results are found
                'Inserts a new record with the supplied parameters
                queryConn.queryData("INSERT INTO userProgress (userId, lessonId, lessonStatus, seqId) VALUES (" & user & "," & less & ", 1, " & progress & ")")
            Else
                'If not, updates the user record with the supplied parameters
                queryConn.queryData("UPDATE userProgress SET lessonId = " & less & ", lessonStatus = 1, seqId = " & progress & " WHERE userId = " & user)
            End If

        Catch ex As Exception
        End Try
    End Sub

    'Updates the queryPoints table based on the userId
    Public Sub updateQp(ByVal id As Integer, ByVal qp As Integer)
        Try
            queryConn.queryData("UPDATE queryPoints SET queryPoints = " & qp & " WHERE userId = " & id)

        Catch ex As Exception

        End Try

    End Sub


    'Method to add queryPoints to the queryPoints table. Inserts a record into the queryPoints table based on the userId

    Public Sub addQp(ByVal id As Integer, ByVal qp As Integer)
        Try
            queryConn.queryData("INSERT INTO queryPoints (userId, queryPoints) VALUES (" & id & "," & qp & ")")
        Catch ex As Exception

        End Try
    End Sub

    'Accepts two parameters userId and lessonId
    'Queries the complete table and sets true or false to the complete variable
    Public Sub getComplete(ByVal id As Integer, ByVal lessid As Integer)
        Try
            queryConn.queryData("SELECT * FROM complete WHERE userId = " & id & "AND lessonId = " & lessid)
            If queryConn.count = 0 Then
                complete = False
            Else
                complete = True
            End If
        Catch ex As Exception
        End Try

    End Sub

End Class
