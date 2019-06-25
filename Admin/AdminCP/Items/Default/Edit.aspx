<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminItems_Update"  %>

 <%@ Register src="../../../AdminCP/_UserControls/Items/Update.ascx" tagname="Update" tagprefix="uc1" %>
<%@ Register src="../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc2" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
     <uc1:Update ID="ucUpdate1" runat="server"  />

</asp:Content>

