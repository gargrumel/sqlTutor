Public Class record
    Dim queryConn As New connections

    Public Sub completeLesson(ByVal user As Integer, ByVal lesson As Integer)
        Try
            queryConn.queryData("SELECT * FROM complete WHERE userId =" & user & " AND lessonId = " & lesson)
            If queryConn.count = 0 Then
                queryConn.queryData("INSERT into complete (userId, lessonId) VALUES (" & user & ", " & lesson & ")")
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
