<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs" Inherits="Admin_ItemCategories_Create"  %>

 <%@ Register src="../../../../AdminCP/_UserControls/ItemCategories/Create.ascx" tagname="Create" tagprefix="uc1" %>
<%@ Register src="../../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc20" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc20:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
    <uc1:Create ID="ucCreate" runat="server" />
</asp:Content>

