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
    Dim completeText As String = "Mark as complete" 'String value for the button when the task is completed
    Dim back As String = "Back to lessons" 'String value for the button if the user visits the page, after they have completed the task
    'Dim lessonCompleteText As String = "You have already completed this level" - No longer required, handled by javaScript
    Dim table1 As String = "Cars" 'String value for the first table
    Dim table2 As String = "Employees" 'String value for the second table


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
        If seq = 16 Then
            lbTask.Text = task1
            enable()
        ElseIf seq = 64 Then
            lbTask.Text = task2
            loadTask2()
            enable()
        ElseIf seq = 32 Then
            nextLesson()
        ElseIf seq = 80 Then
            btnOk.Enabled = False
            btnNext.Enabled = True
            btnNext.Text = completeText
            btnNext.BackColor = Drawing.Color.Blue
        ElseIf seq = 100 Then 'Disables buttons if task is already completed, based on seq value
            lbPercent.Text = seq
            btnNext.Enabled = True
            btnNext.Text = back
            btnOk.Enabled = False
            btnNext.BackColor = Drawing.Color.Blue
        End If
    End Sub

    Public Sub redirect()
        Response.Redirect("/Members/lessons.aspx")
    End Sub


    'Disables buttons
    Public Sub disable()
        btnRun.Enabled = False
        txtRunSql.Enabled = False
    End Sub

    'Updates the database and enables \ updates the btnNext control text and color

    Public Sub finish()
        btnNext.Enabled = True
        btnNext.Text = completeText
        btnNext.BackColor = Drawing.Color.Blue
        r.updateLesson(8, userId, 100)
        r.completeLesson(userId, lessId)
    End Sub


    'calls the loadLesson method
    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        loadLesson()
    End Sub


    'executes a specific method, based on the lbTask text
    Public Sub loadLesson()
        If lbTask.Text = task1 Then
            execute1()

        ElseIf lbTask.Text = task2 Then
            execute2()

        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 1) and updates the database with the relevant information and displays the appropriate feedback label
    Public Sub execute1()
        lbResult.Visible = True
        If txtRunSql.Text = ANS1 Then
            lbResult.Text = feedback
            txtRunSql.Text = ""
            btnNext.Enabled = True
            btnNext.BackColor = Drawing.Color.Blue
            r.updateLesson(8, userId, 32)
            disable()
        Else
            lbResult.Text = error1
            btnNext.Enabled = False
        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 2) and updates the database with the relavant information and displays the appropriate feedback label

    Public Sub execute2()
        lbResult.Visible = True
        If txtRunSql.Text = ANS2 Then
            lbResult.Text = feedback
            txtRunSql.Text = ""
            btnNext.Enabled = True
            btnNext.BackColor = Drawing.Color.LightGray
            btnNext.Text = completeText
            btnNext.BackColor = Drawing.Color.Blue
            r.updateLesson(8, userId, 80)
            disable()
        Else
            lbResult.Text = error1
            btnNext.Enabled = False
        End If
    End Sub

    'calls the enable method
    '@if Statement - Updates the database, based on the current task

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        enable()

        If lbTask.Text = task1 Then
            r.updateLesson(8, userId, 16)
        Else
            r.updateLesson(8, userId, 64)
        End If
    End Sub


    'Enables controls
    Public Sub enable()
        btnOk.Enabled = False
        txtRunSql.Enabled = True
        txtRunSql.BorderColor = Drawing.Color.DeepSkyBlue
        txtRunSql.Focus()
        btnRun.Enabled = True
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
            nextLesson()

        End If

    End Sub

    'Loads appropriate task, based on task label value

    Private Sub nextLesson()
        If lbTask.Text = task1 Then
            loadTask2()
            btnNext.BackColor = Drawing.Color.LightGray
        ElseIf lbTask.text = task2 Then
            finish()
        End If
        If seq <> 100 Then
            r.updateLesson(8, userId, 48)
        End If
    End Sub

    'Sets the value and state of associated controls for task 2
    Public Sub loadTask2()
        lbTask.Text = task2
        btnOk.Enabled = True
        btnRun.Enabled = False
        txtRunSql.BorderColor = Drawing.Color.LightGray
        lbTable.Text = table2
        btnNext.Enabled = False
        lbResult.Visible = False
    End Sub
End Class