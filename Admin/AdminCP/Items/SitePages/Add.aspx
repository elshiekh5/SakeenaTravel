<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs"  Inherits="AdminSitePages_Create"  %>
<%@ Register src="../../../AdminCP/_UserControls/Items/Create.ascx" tagname="Create" tagprefix="uc1" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Create ID="Create1" runat="server" ModuleTypeID="1" />

</asp:Content>

