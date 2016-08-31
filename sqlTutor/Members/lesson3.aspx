<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson3.aspx.vb" Inherits="sqlTutor.lesson3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">

        function missionComplete() {
            complete = document.getElementById('<%= hfComplete.ClientID %>').value            
            if (complete > 0) {
                alert("Mission Completed")            }
        }

    </script>
    <asp:Panel ID="Panel1" runat="server">
        
    <div id="bulbHeader">
        <asp:Image ID="imgBulb" runat="server" BackColor="Black" ImageUrl="~/Images/bulbOff.jpg" Width="49px" />
        <asp:Label ID="lbResult" runat="server" class="alert alert-warning" Font-Size="Larger" Visible="False"></asp:Label>
    </div>
         <div id="lessonBody">
        <div class="docItem">
            <div class="lessonHeader">
                <asp:Label ID="Label2" runat="server" Text="LEVEL 2: SELECT ALL STATEMENT - Reward: 20qp" Font-Size="Larger" Font-Bold="True"></asp:Label>
                 <br />
                   &nbsp;<asp:Label ID="lbPercent" runat="server" Font-Bold="True" ForeColor="Black">0</asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="% complete"></asp:Label>                
            </div>

            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                   <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <asp:Panel ID="Panel3" runat="server">
                            <asp:Label ID="lbTask" runat="server" Font-Size="Larger" Text="Task 1"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbOutcome" runat="server" Text="Learning Outcome: " Font-Size="Larger"></asp:Label>
                            <br />

                            <asp:Panel ID="panelInstructions" runat="server" BackColor="#354551" ForeColor="White">
                                <asp:Label ID="lbScenario" runat="server" Text="To SELECT all the records FROM a table"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="lbExample" runat="server" Text="For example, to SELECT all the records FROM a table named Cars " style="font-weight: 700"></asp:Label>
                                <br />
                            </asp:Panel>
                            <br />
                            <br />
                            <asp:Panel ID="panelAns" runat="server" BackColor="#D4D5D6">
                                &nbsp;<asp:Label ID="lbCommand" runat="server" Text="SQL command:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbAnswer" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                            </asp:Panel>
                            &nbsp;<br />&nbsp;&nbsp;<br />&nbsp;<asp:Button CssClass="button" ID="btnOk" runat="server" Text="I Understand" BorderStyle="None" />
                            &nbsp;<br /> 
                        </asp:Panel>
                <br />
                <br />
                        <asp:HiddenField ID="wrongAns" runat="server" Value="0" />
                        <asp:HiddenField ID="hfComplete" runat="server" Value="0" />
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRun" />
                </Triggers>
               </asp:UpdatePanel>
            </asp:Panel>


        </div>
        <div class="docItem">
            <div class="lessonHeader" id="queryWindow">
            </div>


             <br />
            <asp:UpdatePanel ID="updatePane2" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <asp:Panel ID="panRun" runat="server" Visible="False">

                            <asp:TextBox ID="txtRunSql" runat="server" BorderColor="LightGray" BorderStyle="Solid" BorderWidth="2px" height="36px" Width="100%"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnRun" runat="server" CssClass="button" Text="Run SQL &gt;&gt;" />
                            &nbsp;
                            <a name="middle"></a>
                            <asp:Button ID="btnShowAns" runat="server" height="36px" Text="Show answer" Visible="False" width="140px" CssClass="button" />
                        </asp:Panel>
                          <br /> 
                         <asp:Panel ID="panelVideo" runat="server" Visible="False">
                             <video controls="controls">
                                 <source src="/Videos/selectMp4.mp4" type="video/mp4" />
                                 
                             </video>
                        </asp:Panel>
                         <br /> 
                         <br /> 
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRun" />
                </Triggers>
            </asp:UpdatePanel>           
        </div>


        <div class="docItem">
            <div class="lessonHeader" id="resultWindow">               
                <asp:Label ID="Label3" runat="server" Text="Query Results"></asp:Label>
                </div>
             <asp:UpdatePanel ID="updatePanel3" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <div id="message">
                            <asp:Panel ID="panLess1" runat="server" Visible="False">
                                <table style="width: 100%; height: 100%">
                                    <tr>
                                        <td style="border: thin solid #000000"><b>Make</b></td>
                                        <td style="border: thin solid #000000"><b>Model</b></td>
                                        <td style="border: thin solid #000000"><b>Year</b></td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">Jaguar</td>
                                        <td style="border: thin solid #000000">XJ</td>
                                        <td style="border: thin solid #000000">2013</td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">Bently</td>
                                        <td style="border: thin solid #000000">Bentayga</td>
                                        <td style="border: thin solid #000000">2016</td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">Lotus</td>
                                        <td style="border: thin solid #000000">Exos</td>
                                        <td style="border: thin solid #000000">2012</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="panLess2" runat="server" Visible="False">
                                <table style="width: 100%; height: 100%">
                                    <tr>
                                        <td style="border: thin solid #000000"><b>ID</b></td>
                                        <td style="border: thin solid #000000"><b>FirstName</b></td>
                                        <td style="border: thin solid #000000"><b>LastName</b></td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">001</td>
                                        <td style="border: thin solid #000000">Frank</td>
                                        <td style="border: thin solid #000000">Markson</td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">002</td>
                                        <td style="border: thin solid #000000">Jeffery</td>
                                        <td style="border: thin solid #000000">Smith</td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000">003</td>
                                        <td style="border: thin solid #000000">Christene</td>
                                        <td style="border: thin solid #000000">McKelly</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            </div>
                        <br />
                        <asp:Button ID="btnNext" runat="server" OnClientClick="missionComplete();" ForeColor="White" Text="Next Task &gt;&gt;" CssClass="button" Visible="False" />
                        &nbsp;<asp:Image ID="imgCorrect" runat="server" ImageUrl="~/Images/ok-icon.png" Visible="False" />
                        <br />
                        <br />
                        <asp:Button ID="btnWatch" runat="server" CssClass="button" Text="Watch a video" Visible="False" />
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRun" />
                </Triggers>
            </asp:UpdatePanel>                
        </div>


    </div>

    </asp:Panel>

   
</asp:Content>
