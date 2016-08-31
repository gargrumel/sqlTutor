<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="articles.aspx.vb" Inherits="sqlTutor.articles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        document.getElementById('articles').style.backgroundColor = "blue";
    </script>
     <asp:UpdatePanel ID="updatePanel" runat="server">
                <ContentTemplate>
    <div id="articles">


        <div id="listBox">
        <asp:ListBox ID="listLessons" runat="server" Height="100%" Width="100%" DataSourceID="listData" DataTextField="lessName" DataValueField="lessInfo" AutoPostBack="True"></asp:ListBox>
            <asp:SqlDataSource ID="listData" runat="server" ConnectionString="<%$ ConnectionStrings:sqlTutor.My.MySettings.connection %>" ProviderName="<%$ ConnectionStrings:sqlTutor.My.MySettings.connection.ProviderName %>" SelectCommand="SELECT [lessName], [lessInfo] FROM [Lessons]"></asp:SqlDataSource>
        </div>
        
        <div id="listDisplay">
       
           
                    <asp:TextBox ID="txtDisplay" runat="server" ReadOnly="True" TextMode="MultiLine" AutoPostBack="True" BorderStyle="None"></asp:TextBox>
              
       
        </div>






    </div>

                      </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="listLessons" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>

    </asp:Content>
