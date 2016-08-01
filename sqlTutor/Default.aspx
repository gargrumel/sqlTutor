<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="sqlTutor._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div id ="graphArea" class="text-center">      
   <br />
    <br />
       <br />
       <asp:Label ID="lbWelcome" runat="server" Text="Welcome Back " Font-Size="X-Large"></asp:Label>
    &nbsp;<asp:Label ID="lbUser" runat="server" Font-Size="X-Large"></asp:Label>
    <br />
       <br />
       <asp:Label ID="lbTopic" runat="server" ForeColor="Black"></asp:Label>
       <br />
    <br />
      <div id ="outer">            
           <div id="inner" style="vertical-align: bottom">
               <br />
               <asp:Label ID="lbPercent" runat="server" ForeColor="White" Text="10% Complete"></asp:Label>
           </div>
          
                  
       
           <br />
       </div>
       <br />
          <br />
         <div id="continueButton">
             <asp:Button ID="btnContinue" runat="server" Text="Continue Lesson" CssClass="btn btn-default" />
         </div>


   </div>

</asp:Content>
