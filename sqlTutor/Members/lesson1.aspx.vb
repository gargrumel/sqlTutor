Imports Microsoft.AspNet.Identity
Public Class lesson1
    Inherits System.Web.UI.Page

    Dim queryConn As New connections
    Dim userId As Integer
    Dim lessId As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 8)")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        queryConn.queryData("INSERT into complete (userId, lessonId) VALUES (" & userId & ", " & lessId & ")")
        Response.Redirect("/Members/lessons.aspx")
    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSelect.TextChanged

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Dim ans As String = "SELECT * FROM Cars"
        If txtSelect.Text = ans Then
            lbAns.Text = "You are correct.."
            lbAns.Visible = True
            dataPanel.Visible = True
            imgCorrect.Visible = True
        Else
            lbAns.Visible = True
            lbAns.Text = "I'm sorry, please try again.."
        End If
        txtSelect.Text = ""
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGotIt.Click
        txtSelect.Visible = True
        btnExecute.Visible = True
        lbTry.Visible = True
        lbDisplay.Visible = True
        lbTableName.Visible = True

    End Sub
End Class