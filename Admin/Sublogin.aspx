<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sublogin.aspx.cs" Inherits="login"  %>



<%@ Register src="~/AdminCP/_UserControls/Security/SubLogin.ascx" tagname="login" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">
    <title><%= Resources.AdminText.ControlPanel %></title>
<link id="cssLogin" runat="server" href="/Content/AdminDesign/css/adminLogin.css" rel="stylesheet" type="text/css" />
    
</head>
<body >
    <form id="form1" runat="server">
    <uc2:login ID="login2" runat="server" />  
   </form>
</body>
</html>
