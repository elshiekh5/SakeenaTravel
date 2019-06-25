<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminMessagesConsulting_Services_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
 <%@ Register src="../../../AdminCP/_UserControls/Messages/GetAll.ascx" tagname="GetAll" tagprefix="uc1" %>
 <%@ Register src="../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />
     <uc1:GetAll ID="ucGetAll" runat="server" />
</asp:Content>

