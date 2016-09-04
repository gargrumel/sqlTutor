<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="videos.aspx.vb" Inherits="sqlTutor.videos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        document.getElementById('videos').style.backgroundColor = "blue";
    </script>
    <h4>Videos</h4>
       
        <br/>
    <div id ="vidBody">

<div class="videoTile">
    <div class="divHeader">
        <asp:Label Text="SELECT ALL Statement" runat="server" />

    </div>
    <video controls="controls" class="player">
        <source src="/videos/selectMp4.mp4" type="video/mp4" />
        <source src="file.webm" type="video/webm" />
        <source src="file.ogv" type="video/ogg" />
    </video>

</div>

<div class="videoTile">
     <div class="divHeader">
          <asp:Label Text="SELECT ALL Statement (WHERE CLAUSE)" runat="server" />
    </div>
      <iframe src="https://www.youtube.com/embed/JeZCabShIFk"frameborder="0" allowfullscreen></iframe>
</div>

<div class="videoTile">
     <div class="divHeader">

    </div>
       <source src="file.mp4" type="video/mp4" />
        <source src="file.webm" type="video/webm" />
        <source src="file.ogv" type="video/ogg" />

</div>

</div>
 
  
</asp:Content>
