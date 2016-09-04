Imports Microsoft.AspNet.Identity
Public Class introduction
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim r As New record
    Dim userId As Integer
    Dim lessId As Integer
    Dim qp As Integer
    Dim task1 As String = "TASK 1"
    Dim task2 As String = "TASK 2"
    Dim task3 As String = "TASK 3"
    Dim complete As Boolean = False 'Variable used with the query to check if the lesson was already completed.
    Dim seq As Integer

    'SQL query to retrieve records from the userProgress table and the associated sequence.
    'Sets the results to three variables: userId, lessId, seq (The sequence of the lesson).

    Private Sub introduction_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId, seqId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 7)")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")
                seq = r("seqId")
            Next
        Catch ex As Exception
        End Try

        r.getComplete(userId, lessId) 'Calls a method of the record class to check if the lesson was already completed
        If r.complete = True Then
            complete = True 'Sets the complete variable to true if Method returns true otherwise, the value is false
            showAll() 'if the lesson was already completed, calls the showAll method, which shows all the tasks and the complete button 
        End If
        If seq = 50 Then ' Allows the user to continue the lesson at a specific point, based on the sequence ID
            runTask2()
        ElseIf seq = 75 Then
            runTask3()
        End If
    End Sub

    '
    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        'Calls the completeLesson method from the record Class which records the lesson as complete (Inserts userId and lessId)
        r.completeLesson(userId, lessId)
        'Records the userProgress table to show the current lesson the user is doing.
        r.updateLesson(7, userId, 100)
        redirect() 'Calls the redirect method
    End Sub

    Protected Sub btnTask1_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If lbTask.Text = task1 Then
            r.addQp(userId, 2)
            runTask2()
        ElseIf lbTask.Text = task2 Then
            runTask3()
        End If


    End Sub

    'Makes the required panel visible for task 1
    Public Sub runTask1()
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
    End Sub

    'Makes the required panel for task 2 visible and updates the queryPoints table, once the lesson has not already been completed
    Public Sub runTask2()
        r.updateLesson(lessId, userId, 50) 'Sets the sequence id for the lesson so the user can return to this point
        lbTask.Text = task2
        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
        If complete = False Then
            r.updateQp(userId, 4)
        End If
    End Sub

    'Makes the required panel for task 3 visible and updates the queryPoints table, once the lesson has not already been completed
    Public Sub runTask3()
        r.updateLesson(lessId, userId, 75) 'Sets the sequence id for the lesson so the user can return to this point
        lbTask.Text = task3
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = True
        btnNext.Visible = False
        btnComplete.Visible = True
        If complete = False Then
            r.updateQp(userId, 10)
        End If
    End Sub

    'Shows all the panels and hides the next button
    Public Sub showAll()
        lbTask.Text = task3
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        btnNext.Visible = False
        btnComplete.Visible = True
    End Sub
    'Redirects the user to the lessons page
    Public Sub redirect()
        Response.Redirect("/Members/lessons.aspx")
    End Sub


End Class