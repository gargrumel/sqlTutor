Imports Microsoft.AspNet.Identity
Public Class lesson1
    Inherits System.Web.UI.Page

    Dim queryConn As New connections 'New instance of the connections Class
    Dim r As New record 'New instance of the record Class
    Dim userId As Integer 'Variable to store the user id
    Dim lessId As Integer 'Variable to store the lesson id

    Dim seq As Integer ''Variable to store the sequence id from the current lesson
    Dim ANS1 As String = "SELECT * FROM Cars" 'String value for the first answer
    Dim ANS2 As String = "SELECT * FROM Employees" 'String value for the second answer
    Dim error1 As String = "Check your command and try again." 'String value for the error message
    Dim feedback As String = "You are correct, Great Job" 'String value for the feedback message
    Dim completeText As String = "Complete Mission" 'String value for the button when the task is completed
    Dim feedBack2 As String = "You may want to look at the example and try again."
    Dim help As String = "Ok, let me help you. Click on the Show answer button"
    Dim help1 As String = "Ok, I will enter the correct answer for you."
    Dim back As String = "Back to lessons" 'String value for the button if the user visits the page, after they have completed the task
    'Dim lessonCompleteText As String = "You have already completed this level" - No longer required, handled by javaScript
    Dim table1 As String = "Cars" 'String value for the first table
    Dim table2 As String = "Employees" 'String value for the second table
    Dim complete As Boolean = False

    Dim task1 As String = "Task 1" 'String value for the first task
    Dim task2 As String = "Task 2" 'String value for the second task

    Dim t1 As System.Threading.Thread 'Thread instance to improve performance after the testing phase***********************************************************************

    '@queryConn.queryData - Executes the SQL query and loads the results into some variables
    '@If statement - checks the value of the lesson sequence id and loads the associated task sequence 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId, userProgress.seqId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 8)")


            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")
                seq = r("seqId")

            Next
        Catch ex As Exception
        End Try
        lbPercent.Text = seq

        r.getComplete(userId, lessId) 'Calls a method of the record class to check if the lesson was already completed
        If r.complete = True Then
            complete = True 'Sets the complete variable to true if Method returns true otherwise, the value is false
        End If


    End Sub

    Public Sub redirect()
        Response.Redirect("/Members/lessons.aspx")
    End Sub

    'Updates the database and enables \ updates the btnNext control text and color

    Public Sub finish()
        btnNext.Text = completeText
        btnNext.BackColor = Drawing.Color.Blue
        r.updateLesson(8, userId, 100)
        lbPercent.Text = 100
        If complete = False Then
            r.completeLesson(userId, lessId)
            r.updateQp(userId, 30)
        End If

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
            panRun.Visible = False
            lbResult.Text = feedback 'Shows the feedback message
            txtRunSql.Text = "" 'Resets the txtRunSql control text to Blank
            btnNext.Visible = True 'Enables the btnNext control
            btnNext.BackColor = Drawing.Color.Blue 'Changes the btnNext control background to blue
            panLess1.Visible = True
            imgCorrect.Visible = True
            lbPercent.Text = 32
            r.updateLesson(8, userId, 32) 'Calls the updateLesson method from the record class

        Else
            lbResult.Text = error1 'Displays the error message label
            btnNext.Visible = False
            addWrong()

        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 2) and updates the database with the relevant information and displays the appropriate feedback label

    Public Sub execute2() 'Same logic as execute1
        lbResult.Visible = True
        If txtRunSql.Text = ANS2 Then
            lbResult.Text = feedback
            panRun.Visible = False
            btnNext.Visible = True
            btnNext.Enabled = True 'Control disabled when state is changed to visible
            btnNext.Text = completeText
            btnNext.BackColor = Drawing.Color.Blue
            r.updateLesson(8, userId, 100)
            panLess2.Visible = True
            imgCorrect.Visible = True
            lbPercent.Text = 100
            btnWatch.Visible = True

        Else
            lbResult.Text = error1
            btnNext.Enabled = False
            addWrong()

        End If
    End Sub

    'calls the enable method
    '@if Statement - Updates the database, based on the current task

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If lbTask.Text = task1 Then
            r.updateLesson(8, userId, 16)
            lbPercent.Text = 16

        ElseIf lbTask.Text = task2 Then
            r.updateLesson(8, userId, 64)
            lbPercent.Text = 64
        End If
        enable()
    End Sub


    'Enables controls
    Public Sub enable()
        btnOk.Visible = False
        panRun.Visible = True
        txtRunSql.BorderColor = Drawing.Color.DeepSkyBlue
        txtRunSql.Focus()
        btnRun.BackColor = Drawing.Color.Orange
    End Sub


    'Handles action based on button text

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        If btnNext.Text = completeText Then
            finish()
            redirect()

        ElseIf btnNext.Text = back Then
            redirect()
        Else
            btnNext.Visible = False
            nextLesson()
            imgCorrect.Visible = False

        End If

    End Sub

    'Loads appropriate task, based on task label value

    Private Sub nextLesson()
        If lbTask.Text = task1 Then 'If the task label text is Task 1
            loadTask2() 'Loads Task 2
            btnNext.BackColor = Drawing.Color.LightGray 'Sets the btnNext button color to light gray
            panLess1.Visible = False
        ElseIf lbTask.Text = task2 Then
            finish()
        End If
        If seq <> 100 Then
            r.updateLesson(8, userId, 48)
            lbPercent.Text = 48
        End If
    End Sub

    'Sets the value and state of associated controls for task 2
    Public Sub loadTask2()
        lbExample.Text = "Now test your understanding of the SELECT Statement. Select all the records FROM a table named Employees"
        lbTask.Text = task2
        btnOk.Visible = True
        panRun.Visible = False
        txtRunSql.BorderColor = Drawing.Color.LightGray
        lbTable.Text = table2
        btnNext.Visible = False
        lbResult.Visible = False
        panelAns.Visible = False
        btnShowAns.Visible = False
    End Sub

    Protected Sub btnShowAns_Click(sender As Object, e As EventArgs) Handles btnShowAns.Click
        panelAns.Visible = True
        btnRun.Visible = True
        lbResult.Text = ""
        wrongAns.Value = 1
        btnShowAns.Visible = False
    End Sub

    Public Sub addWrong()
        wrongAns.Value += 1
        If wrongAns.Value = 3 Then
            lbResult.Text = feedBack2
        ElseIf wrongAns.Value > 4 And lbTask.Text = task1 Then
            lbResult.Text = help1
            txtRunSql.Text = ""
            txtRunSql.Text = ANS1
            txtRunSql.BackColor = Drawing.Color.DeepSkyBlue
        ElseIf wrongAns.Value > 4 And lbTask.Text = task2 Then
            lbResult.Text = help
            btnShowAns.Visible = True
            btnRun.Visible = False
            lbAnswer.ForeColor = Drawing.Color.DeepSkyBlue
        End If
    End Sub

    Protected Sub btnWatch_Click(sender As Object, e As EventArgs) Handles btnWatch.Click
        panelVideo.Visible = True
    End Sub
End Class