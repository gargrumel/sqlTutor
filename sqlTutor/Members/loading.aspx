<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="loading.aspx.vb" Inherits="sqlTutor.loading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #loading{
    height:20px;
    width:100%;
    background-color:blue;
    color:white
}
    </style>
</head>
    <script type="text/javascript">
function Redirect()
{
  window.location = 'lessons.aspx'; // Redirect immediately to the actual page
}
</script>
    
<body onload="Redirect()">
    <form id="form1" runat="server">

    <div id ="loading">
    
        Loading. Please wait....</div>
    </form>
</body>
</html>
