﻿Public Class record
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


    Public Sub updateLesson(ByVal less As Integer, ByVal user As String, ByVal progress As Integer)
        Try
            queryConn.queryData("SELECT * from userProgress WHERE userID = " & user)
            If queryConn.count = 0 Then
                queryConn.queryData("INSERT INTO userProgress (userId, lessonId, lessonStatus, seqId) VALUES (" & user & "," & less & ", 1, " & progress & ")")
            Else
                queryConn.queryData("UPDATE userProgress SET lessonId = " & less & ", lessonStatus = 1, seqId = " & progress & " WHERE userId = " & user)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub addQp(ByVal id As Integer, ByVal qp As Integer)
        Try
            queryConn.queryData("SELECT * from queryPoints WHERE userID = " & id)
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
