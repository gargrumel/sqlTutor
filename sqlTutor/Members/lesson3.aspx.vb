﻿Imports Microsoft.AspNet.Identity
Public Class lesson3
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim r As New record
    Dim userId As Integer
    Dim lessId As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            queryConn.queryData("SELECT Users.userId, userProgress.lessonId
                                From Users, userProgress
                                Where (Users.email = '" & User.Identity.GetUserName & "') AND (userProgress.lessonId = 10)")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                userId = r("userId")
                lessId = r("lessonId")
            Next
        Catch ex As Exception
        End Try
    End Sub





End Class