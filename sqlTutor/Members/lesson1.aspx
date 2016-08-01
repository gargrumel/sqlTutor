<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson1.aspx.vb" Inherits="sqlTutor.lesson1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
      
    </script>

    <asp:Panel ID="Panel1" runat="server">
         <div id="lessonBody">
        <div class="docItem">
            <div class="lessonHeader">
               
                <asp:Label ID="lbTopic" runat="server" Text="SELECT ALL STATEMENT"></asp:Label>
                 <br />
                
            </div>

            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                   <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <asp:Label ID="lbTask" runat="server" Text="Task 1" Font-Size="Larger"></asp:Label>
                          <br />
                        <br />
                <asp:Label ID="lbOutcome" runat="server" Text="Learning Outcome: "></asp:Label>
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
                <asp:Label ID="lbAnswer" runat="server" Text="SELECT * FROM "></asp:Label>
                          &nbsp;<asp:Label ID="lbTable" runat="server" Text="Cars"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnOk" runat="server" Text="NEXT >>" />
                <br />
                <br />
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
                        <asp:TextBox ID="txtRunSql" runat="server" BorderColor="LightGray" BorderStyle="Solid" BorderWidth="2px" Enabled="False" Width="100%" CssClass="form-control"></asp:TextBox>
                          <br /> 
                         <br /> 
            <asp:Button ID="btnRun" runat="server" Text="Run SQL >>" Enabled="False" /> 
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
                        <asp:Label ID="lbResult" runat="server" Visible="False" ForeColor="Black"></asp:Label>  
                        <br />
                        <br />
                        <asp:Button ID="btnNext" runat="server" Enabled="False" ForeColor="White" Text="Next Task &gt;&gt;" />
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
