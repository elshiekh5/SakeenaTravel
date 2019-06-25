<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true"
    CodeFile="MailTest.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1 {
            width: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td class="style1">Smtp</td>
    <td><asp:TextBox ID="txtSmtp" runat="server" Width="215px" Text="74.53.184.13"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="style1">port</td>
    <td><asp:TextBox ID="txtport" runat="server" Width="215px" Text="25"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="style1">User</td>
    <td><asp:TextBox ID="txtUser" runat="server" Width="215px" Text="career@ramesses.co"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="style1">pass</td>
    <td><asp:TextBox ID="txtpass" runat="server" Width="215px" Text="test123321"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="style1">From</td>
    <td><asp:TextBox ID="txtFrom" runat="server" Width="215px" Text="career@ramesses.co"></asp:TextBox></td>
    </tr>
      <tr>
    <td class="style1">To</td>
    <td><asp:TextBox ID="txtTo" runat="server" Width="215px" Text="elshiekh5@gmail.com"></asp:TextBox></td>
          
    </tr>
      <tr>
    <td class="style1">Subject</td>
    <td><asp:TextBox ID="txtSubject" runat="server" Width="215px" Text="Test"></asp:TextBox></td>
    </tr>
      <tr>
    <td class="style1">Body</td>
    <td><asp:TextBox ID="txtBody" runat="server" Width="215px" Text="testing message"></asp:TextBox></td>
    </tr>
      <tr>
    <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Send" 
            onclick="Button1_Click" /></td>
    </tr>
        
    </table>
    </div>
    </form>
</body>
</html>


