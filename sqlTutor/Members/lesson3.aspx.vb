﻿Imports Microsoft.AspNet.Identity
Public Class lesson3
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim r As New record
    Dim userId As Integer
    Dim lessId As Integer
    Dim seq As Integer ''Variable to store the sequence id from the current lesson
    Dim ANS1 As String = "SELECT ID FROM Employees WHERE FirstName = 'Frank'" 'String value for the first answer
    Dim ANS2 As String = "SELECT Make FROM Cars WHERE Year = '2007'" 'String value for the second answer
    Dim error1 As String = "Check your command and try again." 'String value for the error message
    Dim feedback As String = "You are correct, Great Job" 'String value for the feedback message
    Dim completeText As String = "Mark as complete" 'String value for the button when the task is completed
    Dim back As String = "Back to lessons" 'String value for the button if the user visits the page, after they have completed the task
    'Dim lessonCompleteText As String = "You have already completed this level" - No longer required, handled by javaScript
    Dim table1 As String = "Cars" 'String value for the first table
    Dim table2 As String = "Employees" 'String value for the second table

    Dim task1 As String = "Task 1" 'String value for the first task
    Dim task2 As String = "Task 2" 'String value for the second task



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId, userProgress.seqId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 10)")

            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")
                seq = r("seqId")

                MsgBox(userId & " " & lessId & " " & seq)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub redirect()
        Response.Redirect("/Members/lessons.aspx")
    End Sub


    'Disables buttons
    Public Sub disable()
        panelTry.Visible = False
    End Sub

    'Updates the database and enables \ updates the btnNext control text and color

    Public Sub finish()
        btnOk.Visible = True
        btnNext.Text = completeText
        btnNext.BackColor = Drawing.Color.Blue
        r.updateLesson(10, userId, 100)
        lbPercent.Text = 100
        r.completeLesson(userId, lessId)
        r.updateQp(userId, 100)
        redirect()
    End Sub

    'calls the loadLesson method
    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        loadLesson()

    End Sub


    'executes a specific method, based on the lbTask text
    Public Sub loadLesson()
        If lbTask.Text = task1 Then
            execute1() 'Calls the execute1 method

        ElseIf lbTask.Text = task2 Then
            execute2() 'Calls the execute2 method

        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 1) and updates the database with the relevant information and displays the appropriate feedback label
    Public Sub execute1()
        lbResult.Visible = True
        If txtRunSql.Text = ANS1 Then 'If the user's entered text and the answer matches
            lbResult.Text = feedback 'Shows the feedback message
            txtRunSql.Text = "" 'Resets the txtRunSql control text to Blank
            btnNext.Visible = True 'Makes the btnNext control visible
            btnNext.BackColor = Drawing.Color.Blue 'Changes the btnNext control background to blue
            r.updateLesson(10, userId, 32) 'Calls the updateLesson method from the record class
            disable() 'Calls the disable method
            imgCorrect.Visible = True
            lbPercent.Text = 32
            panLess1.Visible = True
        Else
            lbResult.Text = error1 'Displays the error message label
            btnOk.Visible = False
        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 2) and updates the database with the relavant information and displays the appropriate feedback label

    Public Sub execute2() 'Same logic as execute1
        lbResult.Visible = True
        If txtRunSql.Text = ANS2 Then
            lbResult.Text = feedback
            txtRunSql.Text = ""
            btnNext.Visible = True
            btnNext.BackColor = Drawing.Color.LightGray
            btnNext.Text = completeText
            btnNext.BackColor = Drawing.Color.Blue
            r.updateLesson(10, userId, 100)
            r.updateQp(userId, 100)
            disable()
            imgCorrect.Visible = True
            lbPercent.Text = 100
            panLess2.Visible = True

        Else
            lbResult.Text = error1
            btnOk.Visible = False
        End If
    End Sub

    'calls the enable method
    '@if Statement - Updates the database, based on the current task

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If lbTask.Text = task1 Then
            r.updateLesson(10, userId, 16)
            lbPercent.Text = 16
        Else
            r.updateLesson(10, userId, 64)
            lbPercent.Text = 64
        End If
        enable()

    End Sub



    'Enables controls
    Public Sub enable()
        btnOk.Visible = False
        txtRunSql.Visible = True
        txtRunSql.Enabled = True
        btnRun.Enabled = True
        txtRunSql.BorderColor = Drawing.Color.DeepSkyBlue
        txtRunSql.Focus()
        btnRun.Visible = True
        btnRun.BackColor = Drawing.Color.Orange
        panelTry.Visible = True
        panelTask.BackColor = Drawing.Color.DeepSkyBlue
    End Sub

    'Loads appropriate task, based on task label value
    'Sets the value and state of associated controls for task 2
    Public Sub loadTask2()
        lbTask.Text = task2
        lbTable.Text = "Cars"
        lbColumn.Text = "Make"
        lbCondition.Text = "Year equals '2007'"
        btnOk.Visible = True
        btnRun.Visible = False
        lbCommand.Text = ANS2
        lbCommand.Visible = False
        txtRunSql.BorderColor = Drawing.Color.LightGray
        btnNext.Visible = False
        imgCorrect.Visible = False
        lbResult.Visible = False
        panLess1.Visible = False
        lbTryIt.Text = "Test your understanding"
        panelTask.BackColor = Drawing.Color.White
    End Sub


    'Handles action based on button text
    Protected Sub btnNext_Click1(sender As Object, e As EventArgs) Handles btnNext.Click
        If btnNext.Text = completeText Then
            finish()
        Else
            loadTask2()
        End If
    End Sub


End Class