Imports Microsoft.AspNet.Identity

Public Class videos
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.GetUserName = "" Then
            Response.Redirect("/LoggedOut.aspx")
        End If
    End Sub

End Class