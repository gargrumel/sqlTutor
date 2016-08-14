<%@ Page Title="Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.vb" Inherits="sqlTutor.Register" %>

<%@ Import Namespace="sqlTutor" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" placeHolder="Email" CssClass="form-control" Width="50%"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The E-Mail field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" placeHolder="Password"  TextMode="Password" CssClass="form-control" Width="50%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" placeHolder="Confirm Password"  TextMode="Password" CssClass="form-control" Width="50%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                <br />
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="button" ID="register" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
            </div>
        </div>
    </div>
</asp:Content>
