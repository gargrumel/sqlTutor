Imports Microsoft.AspNet.Identity

Public Class _Default
    Inherits Page
    Dim queryConn As New connections
    Dim pageName As String
    Dim progress As Integer
    Dim r As record




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        getLessons()
        getCompete()

        If lbUser.Text = "" Then
            Response.Redirect("~/loggedOut.aspx")
        ElseIf lbTopic.Text <> "" Then
            btnContinue.Text = "Continue learning"

        Else
            btnContinue.Text = "Begin learning SQL"

        End If

        showProgressBar()
    End Sub

    Public Sub showProgressBar()
        If lbPercent.Text < 2 Then
            panelProgress.Visible = False
        Else
            panelProgress.Visible = True
        End If
    End Sub

    Private Sub getLessons()
        lbUser.Text = User.Identity.GetUserName
        Try
            queryConn.queryData("SELECT Lessons.lessName,Users.email, Lessons.pageName, userProgress.seqId
                                    FROM Users, Lessons, userProgress                 
                                    WHERE (Users.email = '" & lbUser.Text & "' AND
                                    userProgress.lessonId = Lessons.ID
                                    AND Users.userId = userProgress.userId)") 'SQL Query
            For Each r As DataRow In queryConn.ds.Tables(0).Rows

                lbTopic.Text = "Currently Viewing: " & r("lessName")
                pageName = r("pageName")
                lbPercent.Text = r("seqId")
                progress = r("seqId")

            Next
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnContinue.Click

        If btnContinue.Text = "Begin learning SQL" Then
            Response.Redirect("/Members/lessons.aspx")

        ElseIf lbPercent.text = 100 Then
            Response.Redirect("/Members/lessons.aspx")
        Else
            Response.Redirect(pageName)
        End If

    End Sub

    Public Sub getCompete()
        Try
            queryConn.queryData("SELECT * FROM Complete, Users WHERE Users.email = " & User.Identity.GetUserName & " AND
                                    Users.userId = Complete.userID")
            If queryConn.count = 0 Then
                panNewUser.Visible = True
            Else
                panNewUser.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub


End Class