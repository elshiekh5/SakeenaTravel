<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="InActive.aspx.cs" ValidateRequest="false" Inherits="AdminNews_InActiveComments"  %>
<%@ Register src="../../../../AdminCP/_UserControls/ItemsComments/Comments.ascx" tagname="Comments" tagprefix="uc2" %>
 <%@ Register src="../../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />

    <uc2:Comments ID="ucComments" runat="server" IsAvilableCondition="true" IsActive="false" NotSeenCondition="false" PageFile="InActive.aspx" />

</asp:Content>

