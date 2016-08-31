Imports Microsoft.AspNet.Identity
Public Class lesson1
    Inherits System.Web.UI.Page

    Dim queryConn As New connections 'New instance of the connections Class
    Dim r As New record 'New instance of the record Class
    Dim userId As Integer 'Variable to store the user id
    Dim lessId As Integer 'Variable to store the lesson id

    Dim seq As Integer ''Variable to store the sequence id from the current lesson
    Dim ques1 As String 'String variable for question 1
    Dim ques2 As String 'String variable for question 2
    Dim ANS1 As String  'String value for the first answer
    Dim ANS2 As String 'String value for the second answer

    'Alert messages. Needs to move to database
    Dim error1 As String = "Check your command and try again." 'String value for the error message
    Dim feedback As String = "You are correct, Great Job" 'String value for the feedback message
    Dim completeText As String = "Complete Mission" 'String value for the button when the task is completed
    Dim feedBack2 As String = "Look at the example and try again."
    Dim feedBack3 As String = "The SQL command is Case Sensitive"
    Dim help As String = "Let me help you. Click on the Show answer button"
    Dim help1 As String = "I will enter the correct answer for you"
    Dim back As String = "Back to lessons" 'String value for the button if the user visits the page, after they have completed the task
    Dim missonComplete As String = "Mission Complete"


    Dim complete As Boolean = False 'Boolean variable to hold value if lesson is already completed or not

    Dim task1 As String = "Task 1" 'String value for the first task
    Dim task2 As String = "Task 2" 'String value for the second task
    Dim bulbOn As String = "~/Images/bulb.jpg" 'Bulb image illuminated
    Dim bulbOff As String = "~/Images/bulbOff.jpg" 'Bulb image not illuminated
    Dim lesson As Integer = 8 'Variable for the lesson ID for this page

    Dim t1 As System.Threading.Thread 'Thread instance to improve performance after the testing phase***********************************************************************

    '@queryConn.queryData - Executes the SQL query and loads the results into some variables
    '@If statement - checks the value of the lesson sequence id and loads the associated task sequence 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            queryConn.queryData("SELECT Lessons.ans1, Lessons.ans2, Lessons.ques1, Lessons.ques2, userProgress.seqId, Users.userId
                                FROM (userProgress INNER JOIN
                                Users ON userProgress.userId = Users.userId), Lessons
                                WHERE (Users.email = '" & User.Identity.GetUserName & "') AND (Lessons.ID = " & lesson & ")")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId") 'User ID
                lessId = lesson 'The lesson ID
                seq = r("seqId") 'The lesson sequence ID
                ques1 = r("ques1") 'The first question
                ques2 = r("ques2") 'The second question
                ANS1 = r("ans1") 'The first answer
                ANS2 = r("ans2") 'The second answer
            Next
        Catch ex As Exception
        End Try
        lbPercent.Text = seq 'Sets the percentage label text to the seq value

        r.getComplete(userId, lessId) 'Calls a method of the record class to check if the lesson was already completed
        If r.complete = True Then
            complete = True 'Sets the complete variable to true if Method returns true otherwise, the value is false
        End If

        If seq = 16 Then
            enable() 'Calls the enable method if the sequence value is 16
        ElseIf seq = 32 Then

        ElseIf seq = 48 Then
            loadTask2() 'Calls the loadTask2 method if the sequence value is 48
        ElseIf seq = 64 Then
            loadTask2()
            enable() 'Calls the loadTask2 method and enables the runSQL textbox if the sequence value is 64
        End If

        If Not Page.IsPostBack Then 'Executes only if its not a postback event 
            lbExample.Text = ques1 'Sets the lable text only on page load, not postback
            lbAnswer.Text = ANS1 'Sets the lable text only on page load, not postback
        Else

        End If
    End Sub

    'Method to redirect to the lessons page
    Public Sub redirect()
        Response.Redirect("/Members/lessons.aspx")
    End Sub

    'Updates the complete table and enables \ updates the btnNext control text and color
    'Modifies the queryPoints table, only if the lesson has not been completed.

    Public Sub finish()
        btnNext.Text = completeText
        hfComplete.Value = 1 'Sets the hidden field value to 1
        btnNext.BackColor = Drawing.Color.Blue
        r.updateLesson(lesson, userId, 100) 'Calls the updateLesson Method in the record class and passes the lessonId, userId and sequence (100)
        lbPercent.Text = 100 'Changes the label text to 100
        If complete = False Then 'Checks the complete variable value and if the lesson is not found in the complete table..
            r.completeLesson(userId, lessId) 'Calls the completeLesson method in the record class and passes the values userId and lessId
            r.updateQp(userId, 30) 'Calls the updateQp Method in the record class and passes the userId and qp value
        End If

    End Sub


    'calls the loadLesson method
    Protected Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        loadLesson() 'Calls the loadLesson method
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
        lbResult.Visible = True 'Sets the bulb message text to visible
        If txtRunSql.Text = ANS1 Then 'If the user's entered text and the answer1 matches
            panRun.Visible = False 'Sets the visibility of the run sql panel to false
            correctClass() 'Calls the correctClass method
            lbResult.Text = feedback 'Shows the feedback message
            bOn() 'Calls the bOn method which changes the bulb image
            txtRunSql.Text = "" 'Resets the txtRunSql control text to Blank
            btnNext.Visible = True 'Enables the btnNext control
            btnNext.BackColor = Drawing.Color.Blue 'Changes the btnNext control background to blue
            panLess1.Visible = True 'Sets the visibility of the lesson 1 panel to true (Displays the result table)
            imgCorrect.Visible = True 'Displays the correct image (Check)
            lbPercent.Text = 32 'Sets the percentage complete to 16
            r.updateLesson(lesson, userId, 32) 'Calls the updateLesson method from the record class, updates the database with the lesson ID, userID and query points

        Else
            wrongClass() 'Calls the wrongClass method
            lbResult.Text = error1 'Displays the error message label
            bOn() 'calls the bOn method
            btnNext.Visible = False 'Changes the visibility of the btnNext button
            txtRunSql.Text = "" 'Clears the text of the txtRunsql text box
            addWrong() 'Calls the addWrong method
        End If
    End Sub


    '@If statement - Defines what string is used as the answer (Task 2) and updates the database with the relevant information and displays the appropriate feedback label
    'uses same logic as method above
    Public Sub execute2() 'Same logic as execute1
        lbResult.Visible = True
        If txtRunSql.Text = ANS2 Then
            correctClass()
            bOn()
            panRun.Visible = False
            btnNext.Visible = True
            btnNext.Enabled = True 'Control disabled when state is changed to visible
            btnNext.Text = completeText
            lbResult.Text = missonComplete
            btnNext.BackColor = Drawing.Color.Blue
            r.updateLesson(lesson, userId, 100)
            panLess2.Visible = True
            imgCorrect.Visible = True
            lbPercent.Text = 100
            btnWatch.Visible = True

        Else
            wrongClass()
            lbResult.Text = error1
            btnNext.Enabled = False
            bOn()
            addWrong()

        End If
    End Sub

    'calls the enable method
    '@if Statement - Updates the database, based on the current task

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If lbTask.Text = task1 Then
            r.updateLesson(lesson, userId, 16)
            lbPercent.Text = 16

        ElseIf lbTask.Text = task2 Then
            r.updateLesson(lesson, userId, 64)
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
        txtRunSql.BackColor = Drawing.Color.White
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

        ElseIf lbTask.Text = task2 Then 'If the task label is Task 2
            finish() 'Calls the finish method
        End If
        If seq <> 100 Then
            r.updateLesson(lesson, userId, 48) 'Calls the updateLesson Method in the record class 
            lbPercent.Text = 48
        End If
    End Sub

    'Sets the value and state of associated controls for task 2
    Public Sub loadTask2()
        lbExample.Text = ques2 'Sets the text of the example label to the ques2 variable value
        lbAnswer.Text = ANS2 'Sets he text of answer label to the ANS2 variable value

        lbTask.Text = task2
        btnOk.Visible = True
        panRun.Visible = False
        panLess1.Visible = False
        txtRunSql.BorderColor = Drawing.Color.LightGray
        btnNext.Visible = False
        lbResult.Visible = False
        panelAns.Visible = False
        btnShowAns.Visible = False
        bOff()
    End Sub



    Protected Sub btnShowAns_Click(sender As Object, e As EventArgs) Handles btnShowAns.Click

        panelAns.Visible = True 'makes panelAns visible
        btnRun.Visible = True 'makes btnRun visible
        lbResult.Text = "" 'resets the result text
        wrongAns.Value = 1 'sets hidden field wrongAns to 1
        btnShowAns.Visible = False 'Hides the showAns button
        bOff() 'Calls he bOff method
    End Sub

    'Tracks the amount of incorrect answers and displays a message at specific count
    'Passes the count to a Hidden Field 
    Public Sub addWrong()
        wrongAns.Value += 1 'Adds 1 to the hiiden field value
        If wrongAns.Value = 2 Then
            lbResult.Text = feedBack2 'Shows the feedback2 text if the hidden field value is 2
        ElseIf wrongAns.Value = 3 Then
            lbResult.Text = feedBack3 'Shows the feedback3 text if the hidden field value is 3
        ElseIf wrongAns.Value > 4 And lbTask.Text = task1 Then
            lbResult.Text = help1 'Shows the help message if the hidden field value is 4
            txtRunSql.Text = "" 'Clears the sql text box
            txtRunSql.Text = ANS1 'Places the answer in the txtRunSql textbox
            txtRunSql.BackColor = Drawing.Color.DeepSkyBlue 'Changes the sql textbox background color 
            wrongAns.Value = 1 'Resets the hidden field value to 1
        ElseIf wrongAns.Value > 4 And lbTask.Text = task2 Then 'If during task 2 and the hidden field value is 4
            lbResult.Text = help 'Shows the help message
            btnShowAns.Visible = True 'Makes the show answer button visible
            btnRun.Visible = False 'Makes the run sql button visible
            lbAnswer.ForeColor = Drawing.Color.DeepSkyBlue 'Changes the answer label color
        End If
    End Sub

    'Changes the visibility of the panel containing a video
    Protected Sub btnWatch_Click(sender As Object, e As EventArgs) Handles btnWatch.Click
        panelVideo.Visible = True
    End Sub

    'Changes the source image of the bulb to the bulbOff variable value
    Private Sub bOff()
        imgBulb.ImageUrl = bulbOff
    End Sub

    'Changes the source image of the bulb to the bulbOff variable value
    Public Sub bOn()
        imgBulb.ImageUrl = bulbOn
    End Sub

    'This event does not fire. intended to call the bulb off method and clear the lbResult text
    Protected Sub txtRunSql_TextChanged(sender As Object, e As EventArgs) Handles txtRunSql.TextChanged
        bOff()
        lbResult.Visible = False
    End Sub

    Public Sub correctClass()
        lbResult.Attributes.Add("class", "alert alert-success")
    End Sub

    Public Sub wrongClass()
        lbResult.Attributes.Add("class", "alert alert-warning")
    End Sub


End Class