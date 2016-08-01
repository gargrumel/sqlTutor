Imports Microsoft.AspNet.Identity

Public Class _Default
    Inherits Page
    Dim queryConn As New connections
    Dim pageName As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        getLessons()
    End Sub

    Private Sub getLessons()
        Try
            queryConn.queryData("SELECT Lessons.lessName,Users.email, Lessons.pageName
                                    FROM Users, Lessons, userProgress                 
                                    WHERE (Users.email = '" & User.Identity.GetUserName & "' AND
                                    userProgress.lessonId = Lessons.ID
                                    AND Users.userId = userProgress.userId)") 'SQL Query

            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbUser.Text = r("email")
                lbTopic.Text = "Currently Viewing: " & r("lessName")
                pageName = r("pageName")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Response.Redirect(pageName)
    End Sub
End Class