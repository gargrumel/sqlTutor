<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="introduction.aspx.vb" Inherits="sqlTutor.introduction" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">



    <script src="Scripts/jquery-1.10.2.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {      
            T1 = document.getElementById("task1")
            T2 = document.getElementById("task2")
            T3 = document.getElementById("task3")

            b1 = document.getElementById("btnTask1")
            b2 = document.getElementById("btnTask2")
            b3 = document.getElementById("btnTask3")
            complete = document.getElementById("continueButton")

            T1.style.borderColor = 'deepSkyBlue'
            
           

            $("#btnTask1").click(function () {
                T1.style.borderColor = 'white'
                T2.style.borderColor = 'deepSkyBlue'
                T3.style.borderColor = 'white'
                $('#task3')[0].scrollIntoView(true);
                
                
                
            });

            $("#btnTask2").click(function () {
                T1.style.borderColor = 'white'
                T2.style.borderColor = 'white'
                T3.style.borderColor = 'deepSkyBlue'
               
                
                
            });

            $("#btnTask3").click(function () {
                T1.style.borderColor = 'white'
                T2.style.borderColor = 'white'
                T3.style.borderColor = 'white'                             
                alert("You have sucessfully complete this lesson. Click Complete to finish")
            });

         

        });
   
    </script>

    <div id ="introWindow">
    <h1>Introduction to SQL - Reward: 10qp</h1>
       
    <br/>
          <br/>
        <p>
            Welcome to your first lesson. Here you will begin learning SQL and earning QUERY-POINTS (qp).
            <asp:Label ID="lbPercent" runat="server" Text=""></asp:Label>
        </p>
        <br/>


        <div id ="task1">
             <br/>
         What is SQL? Structured Query Language (SQL) is a standard computer language used to manipulate data within a database<br />
            
        <br />
            <input id="btnTask1" type="button" value="I Got It" class="btn default-default" />
        </div>
        <br />
        <div id ="task2">
            <br />
        What is a database? A database is like a container that stores data within tables<br />
             <input id="btnTask2" type="button" value="I Got It" class="btn default-default" hidden="hidden"  />
        <br />

        </div>
      <div>
            <br />
        <div id="task3">
               <br />
        What is a table? A table is a collection of related data entries. It consists of columns and rows.<br />
        <br />
        <table style="width: 50%; height: 50px; border-style: solid; border-width: 1px">
            <tr>
                <td><strong>Column1</strong></td>
                <td><strong>Column2</strong></td>
                <td><strong>Column3</strong></td>
                <td><strong>Column4</strong></td>
            </tr>
            <tr>
                <td>row1</td>
                <td>row1</td>
                <td>row1</td>
                <td>row1</td>
            </tr>
            <tr>
                <td>row2</td>
                <td>row2</td>
                <td>row2</td>
                <td>row2</td>
            </tr>
            <tr>
                <td>row3</td>
                <td>row3</td>
                <td>row3</td>
                <td>row3</td>
            </tr>
        </table>
             <input id="btnTask3" type="button" value="I Got It" class="btn default-default" hidden="hidden"/>

        </div>
        <br />
        <br />

      <asp:Button class ="cButton" ID ="btnComplete" runat="server" Text="Complete" BackColor="#0099FF" CssClass="btn btn-default" ForeColor="White"/>
   </div>
    </div>
</asp:Content>

