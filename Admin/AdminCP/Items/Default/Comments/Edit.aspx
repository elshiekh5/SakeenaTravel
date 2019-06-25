<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminItems_CommentsEdit"  %>



 <%@ Register src="../../../../AdminCP/_UserControls/ItemsComments/Edit.ascx" tagname="Edit" tagprefix="uc1" %>

<%@ Register src="../../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc20" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc20:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />

     <uc1:Edit ID="ucEdit" runat="server" />



</asp:Content>

