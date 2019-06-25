<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs"
    Inherits="AdminUsersData_Update"  %>
 <%@ Register src="../../../AdminCP/_UserControls/UsersData/EditData.ascx" tagname="EditData" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <uc1:EditData ID="ucEditData" runat="server" />
</asp:Content>

