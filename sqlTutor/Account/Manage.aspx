﻿<%@ Page Title="Your Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="sqlTutor.Manage" %>

<%@ Import Namespace="sqlTutor" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/profileStyle.css" rel="stylesheet" />
    
    <h4>Your Profile</h4> 
    <div class="parent">
        <div class="item"><br />
            <asp:ImageButton ID="icon" runat="server" ImageUrl="~/Images/1469158637_user.png" class="subIcon" ToolTip="Click to change picture" />
            <br />
            <br />
            <asp:Label ID="lbEmail" runat="server"></asp:Label>
            <br />            
            <asp:HyperLink ID="cngPass" runat="server" NavigateUrl="~/Account/ManagePassword.aspx">Edit Password</asp:HyperLink>   
</div>
       
        <div class="item">            
            <br />
            Current Lesson<br />
            <asp:Label ID="lbCurrentName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentDesc" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentStatus" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnContinue" runat="server" BackColor="#34B3A0" BorderStyle="None" ForeColor="White" Height="53px" Text="Continue Lesson" ToolTip="Continue Lesson" />
            <br />
            <br />
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            </asp:UpdateProgress>
            <br />
            <br />
            &nbsp;<br />
            <br />
            <br />
            <br />
        </div>


        <div class="item">
            <br />
            Next Lesson<br />
            <asp:Label ID="lbNextLesson" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbNextDesc" runat="server"></asp:Label>
            <br />
        </div>


        <div class="item" style="vertical-align: middle; text-align: center">
            Current Achievement<br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/shield-ok-icon.png" />
            <br />
            <asp:Label ID="lbRank" runat="server" Text="Current Achievement"></asp:Label>
        </div>

        <div class="item">Some graph here</div>


        <div class="item">
            <br />
            Number of Lessons Completed<br />
            <br />
            <asp:Label ID="lbAmount" runat="server"></asp:Label>
            <br />
        </div>
             
        </div>                   
                 
  

    <div class="row">
        <div class="col-md-12" style="left: 0px; top: 0px; height: 81px">
            <div class="form-horizontal">
                            

                <hr />
                <dl class="dl-horizontal">
                    <dd>
                          
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>

