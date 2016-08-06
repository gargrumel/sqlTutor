Imports System
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin

Partial Public Class Manage
    Inherits System.Web.UI.Page
    Dim queryConn As New connections
    Dim nextLess As Integer = 0
    Dim navPage As String = ""
    Dim newUser As Boolean = False


    Private Sub getLessons()
        Try
            queryConn.queryData("SELECT Lessons.lessName,Lessons.lessDesc,Status.lessStatus, Lessons.ID, Users.email
                                    FROM Users, Lessons, userProgress , Status                  
                                    WHERE (Users.email = '" & User.Identity.GetUserName & "' AND
                                    UserProgress.lessonId = Lessons.ID
                                    AND userProgress.lessonStatus = Status.ID )") 'SQL Query

            If queryConn.count = 0 Then 'If no result is found.
                newUser = True
                btnContinue.Text = "Start Learning SQL"
                lbNextLesson.Text = "You have not started any lessons yet"
            Else
                For Each r As DataRow In queryConn.ds.Tables(0).Rows

                    lbCurrentName.Text = r("lessName") 'Sets the results of the query as the values for the respective controls
                    lbCurrentDesc.Text = r("lessDesc")
                    lbCurrentStatus.Text = r("lessStatus")

                    lbEmail.Text = "Email: " & r("email")
                    nextLess = r("ID") + 1 'Retrieves the ID from the current lesson, adds 1 and sets the value to the nextLess variable

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try






    End Sub

    Private Sub getNextLesson()
        Try
            queryConn.queryData("SELECT lessName, lessDesc, pageName FROM Lessons WHERE ID = " & nextLess)
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbNextLesson.Text = r("lessName")
                lbNextDesc.Text = r("lessDesc")
                nextLess = 0
                page = r("pageName")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getCount()
        Try
            queryConn.queryData("SELECT * FROM complete, Users WHERE Users.email = '" & User.Identity.GetUserName & "' AND Users.userId = complete.userId")
            For Each r As DataRow In queryConn.ds.Tables(0).Rows
                lbAmount.Text = queryConn.count
            Next
        Catch ex As Exception

        End Try
    End Sub



    Protected Property SuccessMessage() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Private Function HasPassword(manager As ApplicationUserManager) As Boolean
        Dim appUser = manager.FindById(User.Identity.GetUserId())
        Return (appUser IsNot Nothing AndAlso appUser.PasswordHash IsNot Nothing)
    End Function

    Protected Property HasPhoneNumber() As Boolean
        Get
            Return m_HasPhoneNumber
        End Get
        Private Set(value As Boolean)
            m_HasPhoneNumber = value
        End Set
    End Property
    Private m_HasPhoneNumber As Boolean

    Protected Property TwoFactorEnabled() As Boolean
        Get
            Return m_TwoFactorEnabled
        End Get
        Private Set(value As Boolean)
            m_TwoFactorEnabled = value
        End Set
    End Property
    Private m_TwoFactorEnabled As Boolean

    Protected Property TwoFactorBrowserRemembered() As String
        Get
            Return m_TwoFactorBrowserRemembered
        End Get
        Private Set(value As String)
            m_TwoFactorBrowserRemembered = value
        End Set
    End Property
    Private m_TwoFactorBrowserRemembered As String

    Public Property LoginsCount As Integer

    Protected Sub Page_Load() Handles Me.Load
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()

        HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()))

        ' Enable this after setting up two-factor authentientication
        'PhoneNumber.Text = If(manager.GetPhoneNumber(User.Identity.GetUserId()), String.Empty)

        TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId())

        lbEmail.Text = User.Identity.GetUserName
        LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count

        Dim authenticationManager = HttpContext.Current.GetOwinContext().Authentication
        getCount()
        getLessons()
        getNextLesson()


    End Sub

    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub

    ' Remove phonenumber from user
    Protected Sub RemovePhone_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
        Dim result = manager.SetPhoneNumber(User.Identity.GetUserId(), Nothing)
        If Not result.Succeeded Then
            Return
        End If
        Dim userInfo = manager.FindById(User.Identity.GetUserId())
        If userInfo IsNot Nothing Then
            signInManager.SignIn(userInfo, isPersistent:=False, rememberBrowser:=False)
            Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess")
        End If
    End Sub

    ' DisableTwoFactorAuthentication
    Protected Sub TwoFactorDisable_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        manager.SetTwoFactorEnabled(User.Identity.GetUserId(), False)

        Response.Redirect("/Account/Manage")
    End Sub

    'EnableTwoFactorAuthentication 
    Protected Sub TwoFactorEnable_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        manager.SetTwoFactorEnabled(User.Identity.GetUserId(), True)

        Response.Redirect("/Account/Manage")
    End Sub

    Protected Sub icon_Click(sender As Object, e As ImageClickEventArgs) Handles icon.Click

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If newUser = True Then
            Response.Redirect("/Members/lessons.aspx")
        End If
    End Sub
End Class