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

    Protected Sub imgLess1_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess1.Click
        Dim go As Boolean = False

        Try
            queryConn.queryData("SELECT userId from userProgress WHERE lessonId = 7")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                MsgBox(r("userId"))
            Next
        Catch ex As Exception

        End Try

        Try
            queryConn.queryData("INSERT INTO userProgress (userId, lessonId, lessonStatus) VALUES (" & userId & ", 7, 1)")
        Catch ex As Exception
        End Try
        Dim lc As New lessonClass(7, 1)
        addLesson(lc)



    End Sub



    Public Sub addLesson(ByVal obj As lessonClass)
        lessArray.Add(obj)
    End Sub

    Protected Sub imgLess2_Click(sender As Object, e As ImageClickEventArgs) Handles imgLess2.Click
        Dim lc As New lessonClass(8, 1)
        addLesson(lc)
    End Sub
End Class