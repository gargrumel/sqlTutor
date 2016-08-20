Imports Microsoft.AspNet.Identity

Public Class _Default
    Inherits Page
    Dim queryConn As New connections 'Declare an instance of the connections Class
    Dim pageName As String 'Declare a variable to hold the page required page name from the database
    Dim progress As Integer 'Variable to hold the sequence ID of the current lesson, retrieved from the database
    Dim r As record 'Declare an instance of the record Class
    Dim start As String = "Start Mission" 'String for btnContinue text
    Dim con As String = "Continue Mission" 'String for btnContinue text





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        getLessons() 'Calls the getLessons Method
        getComplete() 'Calls the getComplete Method
        'If the user is anonymous, redirect to the loggedOut page
        'If a level is in progress, the btnContinue text will be set to the con variable text else the start variable text
        If lbUser.Text = "" Then
            Response.Redirect("~/loggedOut.aspx")
        ElseIf lbTopic.Text <> "" Then
            btnContinue.Text = con
        Else
            btnContinue.Text = start
        End If
        showProgressBar() 'calls the showProgressBar Method
    End Sub

    'If the progress percentage is less than 2, the panel the progress bar is contained in will be hidden, else, visible
    Public Sub showProgressBar()
        If lbPercent.Text < 2 Then
            panelProgress.Visible = False
        Else
            panelProgress.Visible = True
        End If
    End Sub


    'Query to retrieve the logged on user's current lessons and the page name value for navigation and percentage complete
    'The pageName variable is used to hold the page name so the user can navigate to the lesson page when they click the continue button
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


    'Navigates to the relevant page, depending on the button text
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnContinue.Click

        If btnContinue.Text = start Then
            Response.Redirect("/Members/lessons.aspx")

        ElseIf lbPercent.Text = 100 Then
            Response.Redirect("/Members/lessons.aspx")
        Else
            Response.Redirect(pageName)
        End If

    End Sub

    'Query to retrieve the completed lessons for the logged on user and hides the progress bar and percentage completed if no result is returned
    'Displays a second panel with welcome information
    Public Sub getComplete()
        Try
            queryConn.queryData("SELECT * FROM Complete, Users WHERE Users.email = " & User.Identity.GetUserName & " AND
                                    Users.userId = Complete.userID")
            If queryConn.count = 0 Then
                panNewUser.Visible = True
                lbcompleted.Visible = False
                lbPercent.Visible = False
            Else
                panNewUser.Visible = False
                lbcompleted.Visible = True
                lbPercent.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub


End Class