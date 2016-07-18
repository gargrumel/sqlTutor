﻿<%@ Page Title="Your Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="sqlTutor.Manage" %>

<%@ Import Namespace="sqlTutor" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/profileStyle.css" rel="stylesheet" />
    
    <h4>Your Profile</h4> 
    <div class="parent">
        <div class="item"><br />
            <asp:ImageButton ID="icon" runat="server" ImageUrl="~/Images/Gender Neutral User-64.png" class="iconItem" />
            <br />
            <div class="iconItem">Info1<br /></div>
            <div class="iconItem">Info2<br /></div>
        </div>
        <div class="item">Current Lesson<br />
            <asp:Label ID="lbCurrentName" runat="server" Text="Lesson Name"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentDesc" runat="server" Text="lesson Description"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentStatus" runat="server" Text="Lesson Status" Font-Bold="True"></asp:Label>
            <br />
        </div>
        <div class="item">Next Lesson<br />
            <asp:Label ID="lbNextLesson" runat="server" Text="Lesson Name"></asp:Label>
            <br />
            <asp:Label ID="lbNextDesc" runat="server" Text="Lesson Description"></asp:Label>
            <br />
        </div>
        <div class="item">Current Achievement<br />
            <br />
            <asp:Label ID="lbRank" runat="server" Text="Current Achievement"></asp:Label>
        </div>
        <div class="item">Some graph here</div>
        <div class="item">Another Graphs here</div>
             
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

