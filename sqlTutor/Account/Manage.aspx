<%@ Page Title="Your Profile" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Manage.aspx.vb" Inherits="sqlTutor.Manage" %>

<%@ Import Namespace="sqlTutor" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>



<asp:Content ContentPlaceHolderID="MainContent" runat="server">
     <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {                          
            amount = document.getElementById('<%= lbAmount.ClientID %>').innerHTML    
            total = document.getElementById('<%= lbTotal.ClientID %>').innerHTML  


            animateProgressBar(amount);
        
            function animateProgressBar(p)
            {
                val = p / total * 100 /*lessons completed / total lessons * 100 to display text as a percentage of the total lessons*/

                oW = $("#outer").width();/*The current with of the outer Div element of the progress bar*/
                /**alert(val) Used to verify the width of the outer div element**/
                $('#inner').animate({                 
                    'width': (val * oW) / 100

                }, 3000);


                $({ counter: 1 }).animate({ counter: val }, {

                    duration: 3000,
                    step : function()
                    {
                        $('#inner').text(Math.ceil(this.counter) + ' %');
                    }
                })
            }        
        });
   
    </script>
    <link href="../Content/profileStyle.css" rel="stylesheet" />
    
    <h4>Your Profile</h4> 
    <div class="parent">
        <div class="item"><br />
            <asp:ImageButton ID="icon" runat="server" ImageUrl="~/Images/1469158637_user.png" class="subIcon" ToolTip="Click to change picture" />
            <br />
            <asp:Label ID="lbEmail" runat="server"></asp:Label>
            <br />            
            <asp:HyperLink ID="cngPass" runat="server" NavigateUrl="~/Account/ManagePassword.aspx">Edit Password</asp:HyperLink>   
            <br />
            <div id="divQp">
                Query Points Earned<br />
                &nbsp;<asp:Label ID="lbQp" runat="server">0</asp:Label>
                /350</div>
            <br />
            <br />
</div>
       
        <div class="item">            
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Current Mission"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentDesc" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbCurrentStatus" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnContinue" runat="server" BackColor="#0066CC" BorderStyle="None" ForeColor="White" Height="53px" Text="Continue Mission" ToolTip="Continue Lesson" Width="133px" />
            <br />
            <br />
            <br />
            <br />
        </div>


        <div class="item">
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="Larger" Text="Next Mission"></asp:Label>
            <br />
            <asp:Label ID="lbNextLesson" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbNextDesc" runat="server"></asp:Label>
            <br />
            <asp:Image ID="Image2" runat="server" Height="83px" ImageUrl="~/Images/database.png" Width="95px" />
            <br />
        </div>


        <div class="item" style="vertical-align: middle; text-align: center">
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Size="Larger" Text="Current Rank"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/shield-ok-icon.png" />
            <br />
            <asp:Label ID="lbRank" runat="server" Text="Current Rank"></asp:Label>
        </div>

        <div class="item">
            <div class="tileHeader">
                <h4>Overall Progress</h4>
            </div>
            <br />
            Number of Missions Completed -&nbsp;
            <asp:Label ID="lbAmount" runat="server">0</asp:Label>
            / <asp:Label ID="lbTotal" runat="server" Text="10"></asp:Label>
             <br />
            <br />
             <br />
             <div id ="outer">
   <div id="inner"></div>
  </div>
  </div>  
            <br />
        </div>
    
    <div class="row">
        <div class="col-md-12" style="left: 0px; top: 0px; height: 81px">
            <div class="form-horizontal">
                            

                <hr />
                <dl class="dl-horizontal">
                    <dd>
                          
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>

