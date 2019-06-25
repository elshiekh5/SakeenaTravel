<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="New.aspx.cs" Inherits="AdminMessagesConsulting_Services_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>
<%@ Register src="../../../AdminCP/_UserControls/Messages/GetNew.ascx" tagname="GetNew" tagprefix="uc1" %>

 <%@ Register src="../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />
     <uc1:GetNew ID="ucGetNew" runat="server"   />
</asp:Content>

