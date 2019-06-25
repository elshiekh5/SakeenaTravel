<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs" Inherits="Admin_Consulting_ServicesCategories_Create"  %>

 <%@ Register src="../../../../AdminCP/_UserControls/ItemCategories/Create.ascx" tagname="Create" tagprefix="uc1" %>
 <%@ Register src="../../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />
    <uc1:Create ID="ucCreate" runat="server" TypeID="MessagesCategories" />
</asp:Content>

