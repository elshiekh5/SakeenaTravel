<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendMailToGroups.aspx.cs"
    Inherits="SendMailToAll" %>

<%@ Register src="../_UserControls/MailList/SendMailToGroups.ascx" tagname="SendMailToGroups" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <uc1:SendMailToGroups ID="SendMailToGroups1" runat="server" />
   
</asp:Content>
