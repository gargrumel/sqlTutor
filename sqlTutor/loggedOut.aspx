<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="loggedOut.aspx.vb" Inherits="sqlTutor.loggedOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <img src="Images/greenBg.jpg" id="landing" style="width:100%; height:100%;position:absolute;top:0;left:0;z-index:-5000;" />

    <div id="logOut" class="text-center" style="background-repeat: no-repeat">
            
        <asp:Panel ID="logoutContent" runat="server" CssClass="img-responsive" Wrap="False" Width="100%" Height="100%">
             <br />
             <br />
             <br />

                <div class="text-center">
                    <asp:Label ID="Label1" runat="server" Text="Have fun while you Learn" Font-Size="XX-Large" ForeColor="White" ></asp:Label>
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="89px" ImageUrl="~/Images/database.png" Width="107px" />
                <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Log in to start your SQL Mission" Font-Size="X-Large" ForeColor="White"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="btnLogin" class="button" runat="server" Text="LOG IN" Height="70px" ToolTip="Login" Width="140px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" class="button" runat="server" Text="REGISTER" height="69px" ToolTip="Register" width="142px" BorderStyle="None" />
                <br />
                <br />
                <br />
                    &nbsp;&nbsp;<br /><br /><br /><br /><br /><br /><br /><br /></div>




        </asp:Panel>


    </div>

</asp:Content>
