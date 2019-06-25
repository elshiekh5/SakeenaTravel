<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs" ValidateRequest="false" Inherits="AdminItemsAuthors_Create"  %>
<%@ Register src="../../../AdminCP/_UserControls/Items/Create.ascx" tagname="Create" tagprefix="uc1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Create ID="ucCreate" runat="server" />

</asp:Content>

