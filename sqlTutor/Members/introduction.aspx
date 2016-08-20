<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="introduction.aspx.vb" Inherits="sqlTutor.introduction" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">   

    <div id ="introWindow">
    <h4>Introduction to SQL - Reward: 10qp</h4>
       
    <br/>
          <br/>
        <p>
            Welcome to your first Mission. Here you will begin learning SQL and earning QUERY-POINTS (qp).
            <asp:Label ID="lbPercent" runat="server" Text=""></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lbTask" runat="server" Font-Size="Larger" Text="TASK 1"></asp:Label>
        </p>
        <br/>


        <div id ="task1">
             <asp:Panel ID="Panel1" runat="server">
                 <br/>
                 What is SQL? <strong>Structured Query Language</strong> (SQL) is a standard computer language used to store and manipulate data within a <strong>DATABASE.<br /> </strong>
                 <br />
                 &nbsp;</asp:Panel>
        </div>
        <br />
        <asp:Panel ID="Panel2" runat="server" Visible="False">
            What is a <strong>DATABASE</strong>? A database is like a container that stores data within a <strong>TABLE</strong>.</asp:Panel>
        <br />
        <asp:Panel ID="Panel3" runat="server" Visible="False">
            What is a <strong>TABLE</strong>? A table is a collection of related data entries. It consists of <strong>COLUMNS</strong> and <strong>ROWS</strong>.<br />
            <br />
            For example:<br />
            <table style="width: 50%; height: 50px; border-style: solid; border-width: 1px">
                <tr>
                    <td style="border: thin solid #000000"><strong>Column1</strong></td>
                    <td style="border: thin solid #000000"><strong>Column2</strong></td>
                    <td style="border: thin solid #000000"><strong>Column3</strong></td>
                    <td style="border: thin solid #000000"><strong>Column4</strong></td>
                </tr>
                <tr>
                    <td style="border: thin solid #000000">row1</td>
                    <td style="border: thin solid #000000">row1</td>
                    <td style="border: thin solid #000000">row1</td>
                    <td style="border: thin solid #000000">row1</td>
                </tr>
                <tr>
                    <td style="border: thin solid #000000">row2</td>
                    <td style="border: thin solid #000000">row2</td>
                    <td style="border: thin solid #000000">row2</td>
                    <td style="border: thin solid #000000">row2</td>
                </tr>
                <tr>
                    <td style="border: thin solid #000000">row3</td>
                    <td style="border: thin solid #000000">row3</td>
                    <td style="border: thin solid #000000">row3</td>
                    <td style="border: thin solid #000000">row3</td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Button ID="btnNext" runat="server" BackColor="#1EA3FE" CssClass="btn btn-default" ForeColor="White" height="36px" Text="Next" width="188px" />
        <div>
        <br />

      <asp:Button class ="cButton" ID ="btnComplete" runat="server" Text="Complete Lesson" BackColor="#0099FF" CssClass="btn btn-default" ForeColor="White" Visible="False"/>
   </div>
    </div>
</asp:Content>

