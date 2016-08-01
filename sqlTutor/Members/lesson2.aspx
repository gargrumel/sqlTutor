<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="lesson2.aspx.vb" Inherits="sqlTutor.lesson2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>&nbsp;</h1>
    <h1>Create Table Statement</h1>
    <p>To create a Table, type CREATE</p>
    <p>&nbsp;</p>
    <p>
          <asp:TextBox ID="txtAns" runat="server" Height="154px" TextMode="MultiLine" Width="461px"></asp:TextBox>
      </p>
    <p>
          <asp:Button ID="btnExecute" runat="server" Text="Execute SQL &gt;&gt;" class ="cButton" />
        &nbsp;</p>
    <p>&nbsp;</p>
    <p>
  <asp:Button ID="btnComplete" runat="server" Height="68px" Text="Complete Lesson" Width="173px" />    
    </p>
</asp:Content>
