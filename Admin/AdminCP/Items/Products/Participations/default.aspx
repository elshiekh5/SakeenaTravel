<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminItemsParticipations_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>


 <%@ Register src="../../../../AdminCP/_UserControls/Items/GetVisitorsParticipations.ascx" tagname="GetVisitorsParticipations" tagprefix="uc1" %>
<%@ Register src="../../../../Content/AdminDesign/ItemsTopMenu.ascx" tagname="ItemsTopMenu" tagprefix="uc2" %>
<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:ItemsTopMenu ID="ItemsTopMenu1" runat="server" />


     <uc1:GetVisitorsParticipations ID="ucGetVisitorsParticipations" runat="server" />


</asp:Content>

