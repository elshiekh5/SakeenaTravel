<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminMailListGroups_GetAll"  %>
 <%@ Register src="../../_UserControls/MailList/MailListGroups/GetAll.ascx" tagname="GetAll" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
			
     <uc1:GetAll ID="GetAll1" runat="server" />
			
</asp:Content>

