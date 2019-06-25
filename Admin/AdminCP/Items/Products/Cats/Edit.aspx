<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="Admin_ItemCategories_Update"  %>
<%@ Register src="../../../../AdminCP/_UserControls/ItemCategories/Update.ascx" tagname="Update" tagprefix="uc1" %>
<%@ Register src="../../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc20" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc20:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
     <uc1:Update ID="ucUpdate" runat="server" />
</asp:Content>

