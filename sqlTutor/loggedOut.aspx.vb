Imports Microsoft.AspNet.Identity

Public Class loggedOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.GetUserName <> "" Then
            Response.Redirect("/Default.aspx")
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Response.Redirect("/Account/login.aspx")
    End Sub

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Response.Redirect("/Account/register.aspx")
    End Sub
End Class