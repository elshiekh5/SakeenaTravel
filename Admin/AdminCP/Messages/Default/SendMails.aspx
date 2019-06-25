<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendMails.aspx.cs" Inherits="AdminMessages_SendMails"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
 <%@ Register src="../../_UserControls/MailList/SendMail.ascx" tagname="SendMail" tagprefix="uc1" %>
  <%@ Register src="../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />
     <uc1:SendMail ID="ucSendMail" runat="server" />
</asp:Content>

