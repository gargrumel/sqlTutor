<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson1.aspx.vb" Inherits="sqlTutor.lesson1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <script src="Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript">


        $(document).ready(function () {      
            go = document.getElementById("#btnOk")
            amount = document.getElementById('<%= lbPercent.ClientID %>').innerHTML
            
        
        });

        function checkWrong() {
            
            wa = document.getElementById('<%= wrongAns.ClientID %>').innerHTML;
            alert(wa)
            if (wa.value < 3) {
                alert("Please double check your SQL command")
            } else if (wa.value > 4) {
                alert("The correct command is: SELECT * FROM Employees")
                wa.value = 2
            }
        }
   
    </script>

    <asp:Panel ID="Panel1" runat="server">
         <div id="lessonBody">
        <div class="docItem">
            <div class="lessonHeader">
                <asp:Label ID="Label2" runat="server" Text="SELECT ALL STATEMENT - Reward: 20qp" Font-Size="Larger" Font-Bold="true"></asp:Label>
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
                            <asp:Label ID="lbOutcome" runat="server" Text="Learning Outcome: "></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbScenario" runat="server" Text="To SELECT all the records FROM a table"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbExample" runat="server" Text="For example, to SELECT all the records FROM a table named Cars "></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbCommand" runat="server" Text="SQL command:"></asp:Label>
                            <br />
                            <br />
                            <asp:Panel ID="panelAns" runat="server" BackColor="#0099FF">
                                <asp:Label ID="lbAnswer" runat="server" Font-Bold="True" Font-Italic="True" Text="SELECT * FROM "></asp:Label>
                                <asp:Label ID="lbTable" runat="server" Font-Bold="True" Font-Italic="True" Text="Cars"></asp:Label>
                            </asp:Panel>
                            &nbsp;<br />&nbsp;&nbsp;<br />&nbsp;<asp:Button ID="btnOk" runat="server" CssClass="btn btn-default" Text="I Understand" />
                            &nbsp;<br />
                        </asp:Panel>
                <br />
                <br />
                        <asp:HiddenField ID="wrongAns" runat="server" />
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnOk" />
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
                            <asp:Button ID="btnRun" onclientclick="javascript:return checkWrong();" runat="server" CssClass="btn btn-default" Text="Run SQL &gt;&gt;" />
                            &nbsp;
                            <asp:Button ID="btnShowAns" runat="server" height="36px" Text="Show answer" Visible="False" width="140px" />
                        </asp:Panel>
                          <br /> 
                         <br /> 
                         <br /> 
                    </fieldset>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnOk" />
                </Triggers>
            </asp:UpdatePanel>           
        </div>


        <div class="docItem">
            <div class="lessonHeader" id="resultWindow">               
            </div>
             <asp:UpdatePanel ID="updatePanel3" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <div id="message">
                        <br />
                        <asp:Label ID="lbResult" runat="server" Visible="False" ForeColor="#FF3300" Font-Size="Larger"></asp:Label>  
                            <br />
                            <br />
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
                                        <td style="border: thin solid #000000">ID</td>
                                        <td style="border: thin solid #000000">FirstName</td>
                                        <td style="border: thin solid #000000">LastName</td>
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
                        <asp:Button ID="btnNext" runat="server" ForeColor="White" Text="Next Task &gt;&gt;" CssClass="btn btn-default" Visible="False" />
                        &nbsp;<asp:Image ID="imgCorrect" runat="server" ImageUrl="~/Images/ok-icon.png" Visible="False" />
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
