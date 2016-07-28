Public Class lesson2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Response.Redirect("/Members/lessons.aspx")
    End Sub
End Class