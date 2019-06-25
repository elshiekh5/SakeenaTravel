<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="Admin_ItemCategories_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<%@ Register src="../../../../AdminCP/_UserControls/ItemCategories/GetAll.ascx" tagname="GetAll" tagprefix="uc1" %>
<%@ Register src="../../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc20" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc20:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
     <uc1:GetAll ID="ucGetAll" runat="server" />
</asp:Content>

