Imports Microsoft.AspNet.Identity
Public Class introduction
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim r As New record
    Dim userId As Integer
    Dim lessId As Integer
    Dim qp As Integer


    Private Sub introduction_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 7)")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")

            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        r.completeLesson(userId, lessId)
        r.updateLesson(7, userId, 100)
        r.addQp(userId, 10)
        Response.Redirect("/Members/lessons.aspx")
    End Sub


End Class