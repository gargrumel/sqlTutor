﻿<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="sqlTutor._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
  
    <script type="text/javascript">       
          
        $(document).ready(function () {
                       
            amount = document.getElementById('<%= lbPercent.ClientID %>').innerHTML             

            animateProgressBar(amount);          
                
            function animateProgressBar(p) {
                oW = $("#outer").width();              
                $('#inner').animate({
                    'width': (oW * p) / 100
                }, 3000);

                $({ counter: 1 }).animate({ counter: p }, {

                    duration: 3000,
                    step: function () {
                        $('#inner').text(Math.ceil(this.counter) + ' %');
                    }
                })

            }        
        });
   
    </script>
    

<div id="window">
  <div id ="welcomeArea">            
   <br />
   <br />
   <asp:Label ID="lbWelcome" runat="server" Text="Welcome: " Font-Size="X-Large"></asp:Label>
   <asp:Label ID="lbUser" runat="server" Font-Size="X-Large"></asp:Label>
   <br />
   <br />
   <asp:Label ID="lbTopic" runat="server" ForeColor="Black" Font-Size="Larger"></asp:Label>
               &nbsp;<asp:Label ID="lbPercent" runat="server" ForeColor="Black" Font-Size="Larger" ToolTip="Percent complete">0</asp:Label> 

      &nbsp;<asp:Label ID="lbcompleted" runat="server" Font-Size="Larger" Text="% completed" Visible="False"></asp:Label>

      <br />
      
      <asp:Panel ID="panNewUser" runat="server" Font-Size="Large" Visible="False">
          Begin your mission to becoming a SQL Master. Complete each mission to earn Query Points.<br /> </asp:Panel>
   </div>

                 <br />

                 <asp:Button CssClass="button" ID="btnContinue" runat="server" Text="" BackColor="#0033CC" ForeColor="White" BorderStyle="None" Height="55px" Width="149px" />
     
                 <br />
                 <br />
    <asp:Panel ID="panelProgress" runat="server" Height="100%">          
    <div id ="outer" class="text-center">                  
                   
    <div id= "inner" style="vertical-align: bottom" width="0px">
   </div>
        </div>
    <br />
           <div id="continueButton">
   
    </div>
   
    </asp:Panel>
       &nbsp;
             </div> 
      <asp:Label ID="lbComplete" runat="server" Text="" Visible="false"></asp:Label>           
     
          <asp:Label ID="lbValue" runat="server"></asp:Label>
         <br />
         
 
    

    </asp:Content>
