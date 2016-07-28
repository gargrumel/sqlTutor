Imports Microsoft.AspNet.Identity

Public Class lessons
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim lessArray As New ArrayList
    Dim userId As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        queryConn.queryData("SELECT UserId FROM Users WHERE Email = '" & User.Identity.GetUserName() & "'")
        For Each r As DataRow In queryConn.ds.Tables(0).Rows
            userId = r("userId")
        Next
        loadLesson1()
        loadLesson2()
        loadLesson3()
        loadLesson4()
    End Sub

    Private Sub loadLesson1()
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = 7")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbLess1.Text = r("lessName")
                imgLess1.ToolTip = r("lessDesc")
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadLesson2()
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = 8")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbLess2.Text = r("lessName")
                imgLess2.ToolTip = r("lessDesc")
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub loadLesson3()
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = 9")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbLess3.Text = r("lessName")
                imgLess3.ToolTip = r("lessDesc")
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub loadLesson4()
        Try
            queryConn.queryData("SELECT * FROM Lessons WHERE ID = 10")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbLess4.Text = r("lessName")
                imgLess4.ToolTip = r("lessDesc")
            Next
        Catch ex As Exception
        End Try

    End Sub



    Public Sub addLesson(ByVal obj As lessonClass)
        lessArray.Add(obj)
    End Sub

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
    Public Sub startLesson(ByVal less As Integer, ByVal page As String)
        Try
            queryConn.queryData("SELECT * from userProgress WHERE userID = " & userId)
            If queryConn.count = 0 Then
                queryConn.queryData("INSERT INTO userProgress (userId, lessonId, lessonStatus) VALUES (" & userId & "," & less & ", 1)")
            Else
                queryConn.queryData("UPDATE userProgress SET lessonId = " & less & ", lessonStatus = 1 WHERE userId = " & userId)
            End If
            Dim lc As New lessonClass(less, 1)
            addLesson(lc) 'Experimental
            queryConn.count = 0
            Response.Redirect(page)
        Catch ex As Exception
        End Try

    End Sub


End Class