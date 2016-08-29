<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson3.aspx.vb" Inherits="sqlTutor.lesson3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="Scripts/jquery-1.10.2.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

           

        });
   
    </script>
  


    <div id="lesson2">
        <div id="window1">

            <div class="lessonHeader">              

                <asp:Label ID="lbTopic" runat="server" Text="SELECT Statement - Multiple tables"></asp:Label>
                 &nbsp;(With WHERE Clause)<br />
                <asp:Label ID="lbPercent" runat="server" Font-Bold="True">0</asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="% complete"></asp:Label>             

             
        </div>

             <div id="instructions">
                            <asp:UpdatePanel ID="updateCount" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbTask" runat="server" Font-Size="Larger" Text="Task 1"></asp:Label>
                                    &nbsp;- Time Remaining:
                                    <asp:Label ID="lbCounter" runat="server" Font-Size="X-Large" Text="20"></asp:Label>
                                    &nbsp;seconds
                                </ContentTemplate>
                                <Triggers>
                                   
                                </Triggers>
                            </asp:UpdatePanel>
                            <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Scenario: To SELECT records FROM multiple tables"></asp:Label>

                    &nbsp;with specific values<br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="SQL Command: "></asp:Label>

                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Text="SELECT column_name FROM table1_name, table2_name "></asp:Label>

                            <strong>WHERE </strong>
                            <br />
                            column_name = value<br />
                    <br />
                    <asp:Panel ID="panelTask" runat="server" BackColor="White" ForeColor="Black">
                        <asp:Label ID="lbTryIt" runat="server" Text="For example:"></asp:Label>
                        &nbsp;To <strong>SELECT</strong> the column named
                        <asp:Label ID="lbColumn" runat="server" Font-Bold="True" Font-Italic="True" Text="ID"></asp:Label>
                        &nbsp;FROM
                        <asp:Label ID="lbTable" runat="server" Font-Bold="True" Font-Italic="True" Text="Employees"></asp:Label>
                        &nbsp;WHERE
                        <asp:Label ID="lbCondition" runat="server" Text="FirstName equals Frank" Font-Bold="True"></asp:Label>
                        <br />
                        <br />
                        SQL Command:
                        <asp:Label ID="lbCommand" runat="server" Font-Bold="True" Font-Italic="True" Text="SELECT ID FROM Employees WHERE FirstName = 'Frank'"></asp:Label>
                        
                      
                    </asp:Panel>                   
                        <asp:Button ID="btnOk" runat="server" ForeColor="Black" Text="I Understand" CssClass="button" BorderStyle="None" />
                   
                    <asp:Panel ID="panelTry" runat="server" Visible="False" BackColor="#CCCCCC" Height="100%">
                        <asp:Label ID="Label7" runat="server" Font-Size="Larger" Text="Try It" ForeColor="Black"></asp:Label>
                        ..<br />
                        <asp:TextBox ID="txtRunSql" runat="server" BorderStyle="None" Height="34px" Width="100%"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnRun" runat="server" BackColor="#FF3300" CssClass="button" ForeColor="White" Text="Run SQL &gt;&gt;" BorderStyle="None" />
                    </asp:Panel>
                            <br />
                    <br />
                    <br />

                </div>

                <div id="runSql">
                </div>


        </div>


        <div id="window2">

        <div class="lessonHeader" id="resultWindow">
            <asp:Image ID="imgBulb" runat="server" BackColor="Black" Height="50%" ImageUrl="~/Images/bulb.jpg" Width="49px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbResult" runat="server" Font-Size="Larger" ForeColor="Black" Visible="False"></asp:Label>

        </div>                      
          
                            <br />
                            <asp:Panel ID="panLess1" runat="server" Visible="False">
                                <table style="width: 30%; height: 30%; border: 1px solid #000000">
                                    <tr>
                                        <td style="border: thin solid #000000; width: 140px;"><strong>ID</strong></td>
                                    </tr>
                                    <tr>
                                        <td style="border: thin solid #000000; width: 140px;">001</td>
                                    </tr>
                                </table>
                                <br />
                                <br />
            </asp:Panel>
            <asp:Panel ID="panLess2" runat="server" Visible="False">
                <table style="width: 30%; height: 30%; border: 1px solid #000000">
                    <tr>
                        <td style="border: thin solid #000000"><strong>MAKE</strong></td>
                    </tr>
                    <tr>
                        <td style="border: thin solid #000000">Jaguar</td>
                    </tr>
                    <tr>
                        <td style="border: thin solid #000000">Bently</td>
                    </tr>
                </table>
                <br />
                <br />
            </asp:Panel>
            <asp:Button ID="btnNext" runat="server" BackColor="#0033CC" CssClass="button" ForeColor="White" height="36px" Text="Next Task &gt;&gt;" Visible="False" width="140px" BorderStyle="None" />
&nbsp; <asp:Image ID="imgCorrect" runat="server" ImageUrl="~/Images/ok-icon.png" Visible="False" />

        </div>


    </div>   
</asp:Content>
