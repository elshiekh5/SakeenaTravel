<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendMailToOne.aspx.cs" Inherits="SendMailToAll"  %>
<%@ Register src="../_UserControls/MailList/SendMail.ascx" tagname="SendMail" tagprefix="uc1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			
			
    <uc1:SendMail ID="SendMail1" runat="server" FormMailTo="One" />
			
			
</asp:Content>

