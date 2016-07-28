Public Class record
    Dim queryConn As New connections
    Public Sub completeLesson(ByVal user As Integer, ByVal lesson As Integer)
        queryConn.queryData("INSERT into complete (userId, lessonId) VALUES (" & user & ", " & lesson & ")")
    End Sub

End Class
