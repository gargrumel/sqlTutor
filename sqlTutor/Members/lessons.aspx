<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lessons.aspx.vb" Inherits="sqlTutor.lessons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">    
    <div class="tile"><a href="#">STAGE 1</a><br />
        <br />
        <br />
        <asp:Label ID="lbLess1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:ImageButton ID="imgLess1" runat="server" Height="24px" ImageUrl="~/Images/checked_checkbox.png" Width="45px" />
        </div>
        <div class="tile"><a href="#">STAGE 2</a><br />
            <asp:ImageButton ID="imgLess2" runat="server" Height="24px" ImageUrl="~/Images/locked-icon.png" Width="45px" />
            <br />
            <br />
            <asp:Label ID="lbLess2" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 3="#">STAGE 3</a><br />
            <asp:ImageButton ID="imgLess3" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" />
            <br />  
            <br />            
            <asp:Label ID="lbLess3" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 4</a><br />
            <asp:ImageButton ID="imgLess4" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" />
            <br />  
            <br />            
            <asp:Label ID="lbLess4" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="tile"><a href="#">BONUS STAGE</a></div>
        <div class="tile"><a href="#">STAGE 6</a></div>
        <div class="tile"><a href="#">STAGE 7</a></div>
        <div class="tile"><a href="#">STAGE 8</a></div>
        <div class="tile"><a href="#">STAGE 9</a></div>
        <div class="tile"><a href="#">STAGE 10</a></div>
        </div>
</asp:Content>
