Imports Microsoft.AspNet.Identity
Public Class lesson1
    Inherits System.Web.UI.Page

    Dim queryConn As New connections
    Dim userId As Integer
    Dim lessId As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            queryConn.queryData("SELECT Users.userId, Lessons.ID FROM Users, Lessons WHERE User.email = " & User.Identity.GetUserName & " AND Lessons.ID = 7")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("ID")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        queryConn.queryData("INSERT into complete (userId, lessonId) VALUES (" & userId & ", " & lessId & ")")
        Response.Redirect("/Members/lessons.aspx")
    End Sub
End Class