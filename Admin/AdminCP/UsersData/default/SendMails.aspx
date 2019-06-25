<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendMails.aspx.cs" Inherits="AdminUserData_SendMails"  %>
 <%@ Register src="../../_UserControls/MailList/SendMail.ascx" tagname="SendMail" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc1:SendMail ID="ucSendMail" runat="server" />
</asp:Content>

