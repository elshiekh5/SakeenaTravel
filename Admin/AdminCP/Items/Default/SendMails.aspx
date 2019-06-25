<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendMails.aspx.cs" ValidateRequest="false" Inherits="AdminItems_SendMails"  %>
<%@ Register src="../../_UserControls/MailList/SendMail.ascx" tagname="SendMail" tagprefix="uc1" %>
<%@ Register src="../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc2" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />

    <uc1:SendMail ID="ucSendMail"  runat="server" />



</asp:Content>

