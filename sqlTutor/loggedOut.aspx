<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="loggedOut.aspx.vb" Inherits="sqlTutor.loggedOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="logOut" class="text-center">


            
        <asp:Panel ID="logoutContent" runat="server"  >
             <br />
             <br />
             <br />

                <div class="text-center">
                    <asp:Label ID="Label1" runat="server" Text="Want to take your application to the next level" Font-Size="Larger"></asp:Label>
                    <br/>
                <h1>Learn SQL Now</h1>
                <br />
                    <asp:Image ID="Image1" runat="server" Height="89px" ImageUrl="~/Images/database.png" Width="107px" />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="#00CCFF" ForeColor="White" BorderWidth="1px" Height="60px" ToolTip="Login" Width="101px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" Text="Register" BackColor="#FF3300" CssClass="btn default-default" ForeColor="White" height="60px" ToolTip="Register" width="101px" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>




        </asp:Panel>


    </div>

</asp:Content>
