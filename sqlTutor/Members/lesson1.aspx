<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson1.aspx.vb" Inherits="sqlTutor.lesson1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div id ="mainLessonContent">
      <link href="../Content/Site.css" rel="stylesheet" />
      <div id ="lContent1"> 
                 
          <asp:Label ID="Label1" runat="server" Text="SELECT Statement" Font-Size="Large"></asp:Label>
          <br />
          <br />
          <asp:Label ID="Label2" runat="server" Text="Secnario: Display all records in a Table"></asp:Label>
          <br />
          <br />
          <asp:Label ID="Label3" runat="server" Text="SQL Command: "></asp:Label>
&nbsp;<em><asp:Label ID="Label4" runat="server" Text="SELECT * FROM table_name" Font-Size="Larger"></asp:Label>
          </em>
          <br />
          <br />
          For example, to display All records in a table named <em>Fruits<br />
          <br />
          SQL Command:
          <asp:Label ID="Label5" runat="server" Text="SELECT * FROM Fruits" Font-Size="Larger"></asp:Label>
          <br />
          <br />
          <asp:Button ID="btnGotIt" runat="server" Text="Got It &gt;&gt;" Height="44px" Width="118px" />
          <br />
          <br />
          <asp:Label ID="lbTry" runat="server" Font-Size="Large" Text="Try It..." Visible="False"></asp:Label>
          <br />
          <br />
          <asp:Label ID="lbDisplay" runat="server" Text="Display All records in a table named " Visible="False" Font-Size="Larger"></asp:Label>
          <asp:Label ID="lbTableName" runat="server" Font-Size="Larger" Text="Cars" Visible="False"></asp:Label>
          <br />
          <br />
          <asp:TextBox ID="txtSelect" runat="server" Height="28px" style="margin-bottom: 0" Width="100%" Visible="False"></asp:TextBox>
          <br />
          <br />
          <asp:Button ID="btnExecute" runat="server" Text="Execute SQL &gt;&gt;" Visible="False" BorderStyle="None" Height="40px" />
          <br />
          <br />
          <br />
  <asp:Button ID="btnComplete" runat="server" Height="68px" Text="Complete Lesson" Width="173px" BorderStyle="None" />    
          </em></div>
      <div id ="lContent2">
          <asp:Label ID="lbAns" runat="server" Font-Size="XX-Large" Visible="False"></asp:Label>
          &nbsp;<asp:Image ID="imgCorrect" runat="server" BackColor="White" Height="35px" ImageUrl="~/Images/checked_checkbox.png" Visible="False" Width="37px" />
          <br />
          <br />
          <asp:Panel ID="dataPanel" runat="server" Visible="False">
              <table id="tbDisplay" style="width: 100%; border: 1px solid #FFFFFF" border="1">
                  <tr>
                      <td style="height: 21px"><strong>Make</strong></td>
                      <td style="height: 21px"><strong>Model</strong></td>
                      <td style="height: 21px"><strong>Year</strong></td>
                  </tr>
                  <tr>
                      <td>Ford</td>
                      <td>Mustang</td>
                      <td>2007</td>
                  </tr>
                  <tr>
                      <td>Mazda</td>
                      <td>RX - 7</td>
                      <td>2106</td>
                  </tr>
              </table>
          </asp:Panel>
          <ajaxToolkit:DropShadowExtender ID="dataPanel_DropShadowExtender" runat="server" BehaviorID="dataPanel_DropShadowExtender" TargetControlID="dataPanel">
          </ajaxToolkit:DropShadowExtender>
          <br />
          <br />
          <br />
          <br />
      </div>

  </div>
  </asp:Content>
