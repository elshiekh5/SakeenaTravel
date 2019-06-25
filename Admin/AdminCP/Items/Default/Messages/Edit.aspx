<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminMessagesConsultingServices_Update"  %>
 <%@ Register src="../../../../AdminCP/_UserControls/Messages/Update.ascx" tagname="Update" tagprefix="uc1" %>

 <%@ Register src="../../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />

     <uc1:Update ID="ucUpdate" runat="server"  />

</asp:Content>

