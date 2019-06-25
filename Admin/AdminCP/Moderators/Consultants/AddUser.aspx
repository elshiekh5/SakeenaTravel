<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="AddUser.aspx.cs" Inherits="AdminMessagesConsulting_Services_AddConsultant"  %>
<%@ Register src="../../../AdminCP/_UserControls/UsersData/AddUser.ascx" tagname="AddUser" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc1:AddUser ID="ucAddUser" runat="server"   />
</asp:Content>

