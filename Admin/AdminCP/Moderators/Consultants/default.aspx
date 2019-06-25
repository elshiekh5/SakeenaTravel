<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminMessagesConsulting_Services_Consultants"  %>
 <%@ Register src="../../../AdminCP/_UserControls/UsersData/SiteUsers.ascx" tagname="SiteUsers" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <uc1:SiteUsers ID="ucSiteUsers" runat="server" />

</asp:Content>

