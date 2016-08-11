<%@ Page Title="Log in" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="sqlTutor.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
    
    </script>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Log in to SQL Tutor</h4>
                    <hr />
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <div class="col-md-10" style="text-align: left">
                            <div class="text-center">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeHolder="Email" Width="50%" >lennon@gmail.com</asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10" style="text-align: left">
                            <div class="text-center">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeHolder="Password" Width="50%" >Test123?</asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            <br />
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe" ID="Label1">Remember me?</asp:Label>
                            <br />
                            <asp:Button runat="server" class="button" OnClick="LogIn" Text="LOG IN" ID="btnLogin" Width="189px" Height="52px" BorderStyle="None" />
                        </div>
                    </div>
                </div>
                <p class="text-left">
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" NavigateUrl="~/Account/Register.aspx">Dont have an account yet? Register as a new user</asp:HyperLink>
                </p>
                <p class="text-left">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Forgot.aspx">Forgot Password?</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <asp:Image ID="Image1" runat="server" Height="100%" ImageUrl="~/Images/database_2.jpg" Width="100%" />
            <br />
            <p>
                Learn one of the most powerful programming languages in the World!!
            </p>
        </div>
    </div>
</asp:Content>
