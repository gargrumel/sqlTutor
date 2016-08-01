Imports Microsoft.AspNet.Identity
Public Class lesson1
    Inherits System.Web.UI.Page

    Dim queryConn As New connections
    Dim r As New record
    Dim userId As Integer
    Dim lessId As Integer
    Dim ANS1 As String = "SELECT * FROM Cars"
    Dim ANS2 As String = "SELECT * FROM Employees"
    Dim error1 As String = "Check your command and try again."
    Dim feedback As String = "You are correct, Great Job"
    Dim completeText As String = "Mark as complete"
    Dim table1 As String = "Cars"
    Dim table2 As String = "Employees"
    Dim table3 As String = "Shoes"

    Dim task1 As String = "Task 1"
    Dim task2 As String = "Task 2"
    Dim task3 As String = "Task 3"

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


    Public Sub enable()
        btnOk.Enabled = False
        txtRunSql.Enabled = True
        txtRunSql.BorderColor = Drawing.Color.DeepSkyBlue
        txtRunSql.Focus()
        btnRun.Enabled = True
        btnRun.BackColor = Drawing.Color.Orange
    End Sub

    Public Sub execute1()
        lbResult.Visible = True
        If txtRunSql.Text = ANS1 Then
            lbResult.Text = feedback
            txtRunSql.Text = ""
            btnNext.Enabled = True
            btnNext.BackColor = Drawing.Color.Blue
        Else
            lbResult.Text = error1
            btnNext.Enabled = False
        End If
    End Sub

    Public Sub execute2()
        lbResult.Visible = True
        If txtRunSql.Text = ANS2 Then
            lbResult.Text = feedback
            txtRunSql.Text = ""
            btnNext.Enabled = True
            btnNext.BackColor = Drawing.Color.LightGray
            btnNext.Text = completeText
            btnNext.BackColor = Drawing.Color.Blue
        Else
            lbResult.Text = error1
            btnNext.Enabled = False
        End If
    End Sub


    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If lbTask.Text = task1 Then
            execute1()
        ElseIf lbTask.Text = task2 Then
            execute2()
        End If
    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        enable()
    End Sub

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If lbTask.Text = task1 Then
            loadTask1()
            btnNext.BackColor = Drawing.Color.LightGray

        ElseIf btnNext.Text = completeText Then
            r.completeLesson(userId, lessId)
            Response.Redirect("/Members/lessons.aspx")
        End If

    End Sub

    Public Sub loadTask1()
        lbTask.Text = task2
        btnOk.Enabled = True

        btnRun.Enabled = False
        txtRunSql.BorderColor = Drawing.Color.LightGray
        lbTable.Text = table2
        btnNext.Enabled = False
        lbResult.Visible = False

    End Sub
End Class