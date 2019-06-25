<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Show.aspx.cs" Inherits="AdminMailListUsers_Create"  %>

 <%@ Register src="../../_UserControls/MailList/MailListArchive/Show.ascx" tagname="Show" tagprefix="uc1" %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			
     <uc1:Show ID="Show1" runat="server" />
			
</asp:Content>

