<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="loggedOut.aspx.vb" Inherits="sqlTutor.loggedOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="logOut" class="text-center" style="background-repeat: no-repeat">


            
        <asp:Panel ID="logoutContent" runat="server" CssClass="img-responsive" Wrap="False" Width="100%" Height="100%">
             <br />
             <br />
             <br />

                <div class="text-center">
                    <asp:Label ID="Label1" runat="server" Text="Have fun while you Learn" Font-Size="XX-Large" ></asp:Label>
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="89px" ImageUrl="~/Images/database.png" Width="107px" />
                <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Log in to start learning SQL" Font-Size="Larger"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="btnLogin" class="button" runat="server" Text="LOG IN" BorderWidth="1px" Height="70px" ToolTip="Login" Width="140px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" class="button" runat="server" Text="REGISTER" height="69px" ToolTip="Register" width="142px" BorderStyle="None" />
                <br />
                <br />
                <br />
                    &nbsp;&nbsp;<br /><br /><br /><br /><br /><br /><br /><br /></div>




        </asp:Panel>


    </div>

</asp:Content>
