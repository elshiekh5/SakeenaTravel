<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="AddPhoto.aspx.cs" ValidateRequest="false" Inherits="AdminItems_Create"  %>

 <%@ Register src="../../../AdminCP/_UserControls/ItemsFiles/AddPhoto.ascx" tagname="AddPhoto" tagprefix="uc1" %>

<%@ Register src="../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc2" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />
     <uc1:AddPhoto ID="ucAddPhoto" runat="server" FileType="Photo"  />
</asp:Content>

