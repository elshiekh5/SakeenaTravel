<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="Admin_Consulting_ServicesCategories_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<%@ Register src="../../../../AdminCP/_UserControls/ItemCategories/GetAll.ascx" tagname="GetAll" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc1:GetAll ID="ucGetAll" runat="server"  />
</asp:Content>

