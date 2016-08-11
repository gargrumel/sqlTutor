<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lessons.aspx.vb" Inherits="sqlTutor.lessons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div id="lessonsHeader">
   <div id ="outer">
   <div id="inner"></div>
  </div>
  </div>   
                 
     <div id="content" > 
         
    <div class="tile"><a href="#">LEVEL 1</a><br />
       
        <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {                          
            amount = document.getElementById('<%= lbPercent.ClientID %>').innerHTML            

            animateProgressBar(amount);
        
            function animateProgressBar(p)
            {                
                /**oW = $("#outer").width();/*The current with of the outer Div element of the progress bar*/
                $('#inner').animate({                 
                    'width': (350 * p) / 100 
                }, 3000);

                val = p / 350 * 100 /*points gained / total points * 100 to display text as a percentage of the total points*/

                $({ counter: 1 }).animate({ counter: val }, {

                    duration: 3000,
                    step : function()
                    {
                        $('#inner').text(Math.ceil(this.counter) + ' % complete');
                    }
                })


            }        
        });
   
    </script>
       
         <asp:ImageButton ID="imgLess1" runat="server" Height="74px" Width="96px" ImageUrl="~/Images/database.png" />
        <br />   
        <br />      
        <asp:Label ID="lbLess1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Reward: 10QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">LEVEL 2</a><br />
            <asp:ImageButton ID="imgLess2" runat="server" Height="74px" ImageUrl="~/Images/locked-icon.png" Width="96px" Enabled="False" />
            <br />
            <br />
            <asp:Label ID="lbLess2" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label3" runat="server" Text="Reward: 20QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">LEVEL 3</a><br />
            <asp:ImageButton ID="imgLess3" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />  
            <br />            
            <asp:Label ID="lbLess3" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label4" runat="server" Text="Reward: 30QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">LEVEL 4</a><br />
            <asp:ImageButton ID="imgLess4" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />  
            <br />            
            <asp:Label ID="lbLess4" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label5" runat="server" Text="Reward: 40QP" Enabled="False"></asp:Label>
        </div>
        <div class="tile" id="bonus"><a href="#">BONUS STAGE</a>
            <asp:ImageButton ID="imgBonus" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
             <br /> 
              <br />
            <div id="bonusBar">
                <asp:Label ID="lbQptitle" runat="server" Text="QP Earned: "></asp:Label>
                <asp:Label ID="lbPercent" runat="server" ForeColor="Black">0</asp:Label>

                <br />                
                <asp:Label ID="lbBonus" runat="server" Text="Earn 100QP to unlock"></asp:Label>
                <br />
                <br />            
                <br />
            </div>



        </div>

        <div class="tile"><a href="#">LEVEL 6</a><br />
            <br />
            <asp:ImageButton ID="imgLess5" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            
            
            <br />
            <asp:Label ID="lbLess5" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label6" runat="server" Text="Reward: 45QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 7</a><br />
            <br />
            <asp:ImageButton ID="imgLess6" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />
            <br />
            <asp:Label ID="lbLess6" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label7" runat="server" Text="Reward: 50QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 8</a><br />
            <br />
            <asp:ImageButton ID="imgLess7" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />
            <br />
            <asp:Label ID="lbLess7" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label8" runat="server" Text="Reward: 75QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 9</a><br />
            <br />
            <asp:ImageButton ID="imgLess8" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />
            <br />
            <asp:Label ID="lbLess8" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label9" runat="server" Text="Reward: 80QP"></asp:Label>
        </div>
        <div class="tile"><a href="#">STAGE 10</a><br />
            <br />
            <asp:ImageButton ID="imgLess9" runat="server" ImageUrl="~/Images/locked-icon.png" height="74px" width="96px" Enabled="False" />
            <br />
            <br />
            <asp:Label ID="lbLess9" runat="server" Text="Query Master Challenge"></asp:Label>
            <br />
        <asp:Label ID="Label10" runat="server" Text="Reward: 100QP"></asp:Label>
        </div>
        </div>
</asp:Content>
