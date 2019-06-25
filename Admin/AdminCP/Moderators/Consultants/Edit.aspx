<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs" Inherits="AdminMessagesConsulting_Services_EditConsultant"  %>
 <%@ Register src="../../../AdminCP/_UserControls/UsersData/EditData.ascx" tagname="EditData" tagprefix="uc1" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <uc1:EditData ID="ucEditData" runat="server"  />

</asp:Content>

