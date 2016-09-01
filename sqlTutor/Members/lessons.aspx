<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lessons.aspx.vb" Inherits="sqlTutor.lessons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">

        document.getElementById('lessons').style.backgroundColor = "blue";
   
    </script>      
  

              <div id="lessonPageHeader"> 
        <h4>SQL Missions</h4>              
                <asp:Label ID="lbQptitle" runat="server" Text="QP Earned: "></asp:Label>
                &nbsp;
                <asp:Label ID="lbPercent" runat="server" ForeColor="black">0</asp:Label>
    </div>
          
     <div id="content" >          
    <div class="tile">
        
        <br />
        LEVEL 1<br />
        <br />   
             
         <asp:ImageButton ID="imgLess1" runat="server" Height="74px" Width="96px" ImageUrl="~/Images/database.png" BackColor="#1A7B72" />
        <br />   
        <br />      
        <asp:Label ID="lbLess1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Reward: 10QP"></asp:Label>
        <br />
        </div>
        <div class="tile">
           
            <br />
            LEVEL 2<br />
            <br />
            <asp:ImageButton ID="imgLess2" runat="server" Height="74px" Width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />
            <br />
            <asp:Label ID="lbLess2" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label3" runat="server" Text="Reward: 20QP"></asp:Label>
        </div>
        <div class="tile">
          
            <br />
            LEVEL 3<br />
            <br />
            <asp:ImageButton ID="imgLess3" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />  
            <br />            
            <asp:Label ID="lbLess3" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label4" runat="server" Text="Reward: 30QP"></asp:Label>
        </div>
        <div class="tile">
            
            <br />
            LEVEL 4<br />
            <br />
            <asp:ImageButton ID="imgLess4" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />  
            <br />            
            <asp:Label ID="lbLess4" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label5" runat="server" Text="Reward: 40QP" Enabled="False"></asp:Label>
        </div>
        <div class="tile" id="bonus">
            
            <br />
            BONUS STAGE
            <br />
             <br />
            <asp:ImageButton ID="imgBonus" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" ImageUrl="~/Images/Lock-64.png" />
             
              <br />
            <div id="bonusBar">

                <br />                
                <asp:Label ID="lbBonus" runat="server" Text="Earn 100QP to unlock"></asp:Label>
                <br />
                <br />            
                <br />
            </div>



        </div>

        <div class="tile">
            
            <br />
            LEVEL 6<br />
            <br />
            <asp:ImageButton ID="imgLess5" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            
            
            <br />
            
            
            <br />
            <asp:Label ID="lbLess5" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label6" runat="server" Text="Reward: 45QP"></asp:Label>
        </div>
        <div class="tile">
            
            <br />
            STAGE 7<br />
            <br />
            <asp:ImageButton ID="imgLess6" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />
            <br />
            <asp:Label ID="lbLess6" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label7" runat="server" Text="Reward: 50QP"></asp:Label>
        </div>
        <div class="tile">
            
            <br />
            STAGE 8<br />
            <br />
            <asp:ImageButton ID="imgLess7" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />
            <br />
            <asp:Label ID="lbLess7" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label8" runat="server" Text="Reward: 75QP"></asp:Label>
        </div>
        <div class="tile">
            
            <br />
            STAGE 9<br />
            <br />
            <asp:ImageButton ID="imgLess8" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" />
            <br />
            <br />
            <asp:Label ID="lbLess8" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label9" runat="server" Text="Reward: 80QP"></asp:Label>
        </div>
        <div class="tile">
            
            <br />
            STAGE 10<br />
            <br />
            <asp:ImageButton ID="imgLess9" runat="server" height="74px" width="96px" Enabled="False" BackColor="#1A7B72" ImageUrl="~/Images/Lock-64.png" />
            <br />
            <br />
            <asp:Label ID="lbLess9" runat="server" Text="Query Master Challenge"></asp:Label>
            <br />
        <asp:Label ID="Label10" runat="server" Text="Reward: 100QP"></asp:Label>
        </div>
        </div>

</asp:Content>
