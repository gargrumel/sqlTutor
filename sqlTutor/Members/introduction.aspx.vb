﻿Public Class introduction
    Inherits System.Web.UI.Page
    Dim queryConn As New connections

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Response.Redirect("/Members/lessons.aspx")
    End Sub
End Class