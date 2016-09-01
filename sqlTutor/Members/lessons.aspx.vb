Imports Microsoft.AspNet.Identity

Public Class lessons
    Inherits System.Web.UI.Page
    Dim queryConn As New connections 'Connections class
    Dim userId As Integer 'Variable to hold user ID
    Dim imgUrl2 As String = "~/Images/lock-64.png" 'Locked image
    Dim imgUrl As String = "~/Images/unlock-64.png" 'Unlocked image
    Dim imgUrl3 As String = "~/Images/star.png" 'Star image
    Dim bonusUnlocked As String = "Congratulations, Bonus Mission Unlocked.."

    'Loads all the lessons 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If the user is anonymous
        If User.Identity.GetUserName = "" Then
            Response.Redirect("/loggedOut.aspx") 'Redirects anonymous users to the loggedOut page
        Else
            queryConn.queryData("SELECT UserId FROM Users WHERE Email = '" & User.Identity.GetUserName() & "'")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId") 'Sets the user id to the userId variable
            Next
            loadLesson1() 'calls the loadLesson method
            'Calls the populate method to load each lesson, reuses the code
            populate(7, lbLess2, imgLess2)
            populate(8, lbLess3, imgLess3)
            populate(9, lbLess4, imgLess4)
            populate(10, lbLess5, imgLess5)
            populate(11, lbLess6, imgLess6)
            populate(12, lbLess7, imgLess7)
            populate(13, lbLess8, imgLess8)

        End If

        getQp() 'Calls the getQp Method
    End Sub

    'Accepts an integer (lesson ID), label (Lesson Label) and image (Lesson Image) as parameters
    'Queries the Lessons table with the lesson ID and passes the lesson information to the label and image
    'Queries the complete table and unlocks (Enables controls) the next lesson if the previous lesson ID is found
    Public Sub populate(ByVal l As Integer, ByVal lb As Label, ByVal img As Image)
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = " & l + 1)
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lb.Text = r("lessName")
                img.ToolTip = r("lessDesc")
                img.ImageUrl = imgUrl2
            Next
            queryConn.queryData("SELECT * FROM complete WHERE lessonId = " & l & " AND userId = " & userId)

            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                If queryConn.count > 0 Then
                    img.ImageUrl = imgUrl
                    img.Enabled = True
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    'Queries the database and retrieves the lesson information with ID 7 (First Lesson)
    Private Sub loadLesson1()
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = " & 7)
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbLess1.Text = r("lessName") 'Sets the lbLess1 text to the lesson name retrieved from the database
                imgLess1.ToolTip = r("lessDesc") 'Sets the image tool tip to the lesson description
            Next
        Catch ex As Exception

        End Try

    End Sub

    'Starts the specified lesson ID when the image button is clicked, calls the startLesson method
    Protected Sub imgLess1_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess1.Click
        startLesson(7, "/Members/introduction.aspx")
    End Sub


    Protected Sub imgLess2_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess2.Click
        startLesson(8, "/Members/lesson1.aspx")
    End Sub

    Protected Sub imgLess3_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess3.Click
        startLesson(9, "/Members/lesson2.aspx")
    End Sub


    Protected Sub imgLess4_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess4.Click
        startLesson(10, "/Members/lesson3.aspx")
    End Sub

    Protected Sub imgLess5_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess5.Click
        startLesson(11, "/Members/lesson4.aspx")
    End Sub

    Protected Sub imgLess6_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess6.Click
        startLesson(12, "/Members/lesson5.aspx")
    End Sub

    Protected Sub imgLess7_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess7.Click
        startLesson(13, "/Members/lesson6.aspx")
    End Sub


    Protected Sub imgLess8_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess8.Click
        startLesson(14, "/Members/lesson7.aspx")
    End Sub


    'Accepts an integer and string as parameters
    'Queries the userProgress table. If no record is found, a new record is inserted with the userId variable value
    'If the user already exists, the record is updated to reflect the current lesson only. The user is then redirected to the page parameter value.

    Public Sub startLesson(ByVal less As Integer, ByVal page As String)
        Try
            queryConn.queryData("SELECT * from userProgress WHERE userID = " & userId)
            If queryConn.count = 0 Then
                queryConn.queryData("INSERT INTO userProgress (userId, lessonId) VALUES (" & userId & ", " & less & ")")
            Else
                queryConn.queryData("UPDATE userProgress SET lessonId = " & less & ", seqId = 0 WHERE userId = " & userId)
            End If
            queryConn.count = 0
            Response.Redirect(page)
        Catch ex As Exception
        End Try

    End Sub
    'Queries the database and returns the queryPoints value and passes to the lbPercent label
    Private Sub getQp()
        Try
            queryConn.queryData("SELECT queryPoints FROM queryPoints WHERE userId = " & userId)
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbPercent.Text = r("queryPoints")
            Next
        Catch ex As Exception
        End Try
        'If the queryPoints value is more than 99, the bonus stage image is enabled and changed
        If lbPercent.Text > 99 Then
            lbBonus.Text = bonusUnlocked
            imgBonus.Enabled = True
            imgBonus.ImageUrl = imgUrl3
        End If

    End Sub

    'Redirects to the bonus stage page
    Protected Sub imgBonus_Click(sender As Object, e As ImageClickEventArgs) Handles imgBonus.Click
        Response.Redirect("/Members/bonus.aspx")
    End Sub
End Class