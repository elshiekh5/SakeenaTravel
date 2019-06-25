<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminItemsAuthors_Update"  %>

 <%@ Register src="../../../AdminCP/_UserControls/Items/Update.ascx" tagname="Update" tagprefix="uc1" %>

 
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <uc1:Update ID="ucUpdate1" runat="server"  />

</asp:Content>

