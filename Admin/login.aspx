<%@ Page Language="C#" %>
<%@ Register src="~/AdminCP/_UserControls/Security/login.ascx" tagname="login" tagprefix="uc2" %>
<!DOCTYPE html>

<script runat="server">
protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
      new ScriptResourceDefinition
      {
          Path = "~/scripts/jquery-1.7.2.min.js",
          DebugPath = "~/scripts/jquery-1.7.2.min.js",
          CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
          CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
      });

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= Resources.AdminText.ControlPanel %></title>
<link id="cssLogin" href="<%$ Resources:AdminText,AdminLoginCss %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js"></script>
</head>
<body >
    
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc2:login ID="login2" runat="server" />  
   </form>
</body>
</html>