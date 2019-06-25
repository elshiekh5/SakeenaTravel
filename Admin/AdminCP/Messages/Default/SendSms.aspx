<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="SendSms.aspx.cs" Inherits="AdminMessages_SendSms"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<%@ Register src="../../_UserControls/SMS/Send/SendSms.ascx" tagname="SendSms" tagprefix="uc1" %>
 <%@ Register src="../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />
     <uc1:SendSms ID="ucSendSms" runat="server" />
</asp:Content>

