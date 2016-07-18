<%@ Page Title="SQL Documentation" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="docs.aspx.vb" Inherits="sqlTutor.docs" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
      <div class="docBody" style="height: 552px">
    <div class="docItem">Menu<br />
        <br />
          <asp:ListBox ID="menuList" runat="server" AutoPostBack="True" DataSourceID="menuDataSource" DataTextField="lessName" DataValueField="lesInfo" Height="229px" Width="180px"></asp:ListBox>
        <asp:SqlDataSource ID="menuDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [lessName], [lessDesc], [lesInfo] FROM [Lessons]"></asp:SqlDataSource>
          </div>
    <div class="docItem">Display<br />
        <br />
        <asp:Label ID="lbDoc" runat="server" Text="Topic Description"></asp:Label>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtInfo" runat="server" BorderStyle="None" Height="60%" ReadOnly="True" TextMode="MultiLine" Width="80%"></asp:TextBox>
          </div> 
        </div>
</asp:Content>

