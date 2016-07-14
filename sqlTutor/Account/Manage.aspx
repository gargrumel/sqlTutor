<%@ Page Title="Manage Account" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="sqlTutor.Manage" %>

<%@ Import Namespace="sqlTutor" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/profileStyle.css" rel="stylesheet" />
    <h2><%: Title %>.</h2>
     <h4>Your Profile</h4> 

    <div class="parent">
        <div class="item">Personal Information</div>
        <div class="item">Current Lesson</div>
        <div class="item">Next Lesson</div>
        <div class="item">Current Achievement</div>
        <div class="item">Some graph here</div>
        <div class="item">Another Graph here</div>
             
        </div>                   
                 
  

    <div class="row">
        <div class="col-md-12" style="left: 0px; top: 0px; height: 81px">
            <div class="form-horizontal">
                            

                <hr />
                <dl class="dl-horizontal">
                    <dd>
                        <% If TwoFactorEnabled Then %>
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% Else %>
                       	<%--
                       	Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% End If %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>

