<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs" Inherits="AdminMailListUsers_Create"  %>

 <%@ Register src="../../_UserControls/MailList/MailListUsers/Add.ascx" tagname="Add" tagprefix="uc1" %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			
     <uc1:Add ID="Add1" runat="server" />
			
</asp:Content>

