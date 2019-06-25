<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Export.aspx.cs" Inherits="AdminUsersData_ExportData"  %>
 <%@ Register src="../../_UserControls/UsersData/Export.ascx" tagname="Export" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <uc1:Export ID="ucExport" runat="server" />
     
</asp:Content>

