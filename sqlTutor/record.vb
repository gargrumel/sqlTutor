Public Class record
    'This class holds the methods to update the Lesson and User records. 
    Dim queryConn As New connections


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

    'Method to add queryPoints to the queryPoints table

    Public Sub addQp(ByVal id As Integer, ByVal qp As Integer)
        Try

        Catch ex As Exception

        End Try

        Try
            queryConn.queryData("SELECT * queryPoints WHERE userID = " & id)
            If queryConn.count = 0 Then
                queryConn.queryData("INSERT INTO queryPoints (userId, queryPoints) VALUES (" & id & "," & qp & ")")
            Else
                queryConn.queryData("UPDATE queryPoints SET userId = " & id & ", queryPoints = " & qp)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub minusQp(ByVal id As Integer, ByVal qp As Integer)


    End Sub






End Class
