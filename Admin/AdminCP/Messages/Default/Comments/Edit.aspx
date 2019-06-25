<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminNews_CommentsEdit"  %>



 <%@ Register src="../../../../AdminCP/_UserControls/ItemsComments/Edit.ascx" tagname="Edit" tagprefix="uc1" %>



 <%@ Register src="../../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />



     <uc1:Edit ID="ucEdit" runat="server" />



</asp:Content>

