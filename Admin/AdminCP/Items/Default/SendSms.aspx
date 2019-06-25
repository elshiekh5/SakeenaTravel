<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendSms.aspx.cs" ValidateRequest="false" Inherits="AdminItems_SendSms"  %>
<%@ Register src="../../_UserControls/SMS/Send/SendSms.ascx" tagname="SendSms" tagprefix="uc1" %>
<%@ Register src="../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc2" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
    <uc1:SendSms ID="ucSendSms" runat="server" />
</asp:Content>

