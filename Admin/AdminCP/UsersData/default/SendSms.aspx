<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendSms.aspx.cs" Inherits="AdminUserData_SendSms"  %>
<%@ Register src="../../_UserControls/SMS/Send/SendSms.ascx" tagname="SendSms" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SendSms ID="ucSendSms" runat="server" />
</asp:Content>

