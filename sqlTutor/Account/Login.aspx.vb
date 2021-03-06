﻿Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin

Partial Public Class Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Email.Focus()
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs) Handles btnLogin.Click, btnLogin.Click
        btnLogin.Enabled = False


        If IsValid Then
            ' Validate the user password
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

            ' This doen't count login failures towards account lockout
            ' To enable password failures to trigger lockout, change to shouldLockout := True
            Dim result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout:=False)

            Select Case result
                Case SignInStatus.Success
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
                    Exit Select
                Case SignInStatus.LockedOut
                    Response.Redirect("/Account/Lockout")
                    Exit Select
                Case SignInStatus.RequiresVerification
                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                    Request.QueryString("ReturnUrl"),
                                                    RememberMe.Checked),
                                      True)
                    Exit Select


                Case Else
                    FailureText.Text = "Invalid login attempt"
                    ErrorMessage.Visible = True
                    Email.Text = ""
                    Password.Text = ""
                    btnLogin.Enabled = True

                    Exit Select
            End Select
        End If

    End Sub



    Protected Sub Email_TextChanged(sender As Object, e As EventArgs) Handles Email.TextChanged
        Dim watermark As String = "E-Mail" 'Expiremtal
        If Email.Text = "" Then
            btnLogin.Enabled = False
        End If
    End Sub

End Class
