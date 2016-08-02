<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="sqlTutor._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {      
                       
            amount = document.getElementById('<%= lbPercent.ClientID %>').innerHTML  
           

            animateProgressBar(amount);
           

            function animateProgressBar(p)
            {                
                outerWidth = $("#outer").width();
                $('#inner').animate({                 
                    'width': (outerWidth * p) / 100
                }, 3000);
            }        
        });
   
    </script>
    

<div id="window">
  <div id ="welcomeArea">

            
   <br />
    <br />
       <br />
       <asp:Label ID="lbWelcome" runat="server" Text="Welcome Back " Font-Size="X-Large"></asp:Label>
    &nbsp;<asp:Label ID="lbUser" runat="server" Font-Size="X-Large"></asp:Label>
    <br />
       <br />
       <asp:Label ID="lbTopic" runat="server" ForeColor="Black"></asp:Label>
       &nbsp;
               <asp:Label ID="lbPercent" runat="server" ForeColor="Black" Font-Size="Larger" ToolTip="Percent complete">0</asp:Label>
      <asp:Label ID="lbComplete" runat="server" Text="% Complete"></asp:Label>
           
       <br />
    <br />

      <div id ="outer" width="500px" class="text-center">            
           <div id= "inner" style="vertical-align: bottom" ;width="0px">
               <br />
           </div>
          
                  
       
           <br />
       </div>
       <br />
          <asp:Label ID="lbValue" runat="server"></asp:Label>
          <br />       
          <br />
         <div id="continueButton">
             <asp:Button ID="btnContinue" runat="server" Text="" CssClass="btn btn-default" />
   
    </div>

  </div>

   
    </div>



 



</asp:Content>
