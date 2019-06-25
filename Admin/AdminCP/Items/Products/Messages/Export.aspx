<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Export.aspx.cs" Inherits="AdminMessages_Export"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

<%@ Register src="../../../../AdminCP/_UserControls/Messages/Export.ascx" tagname="Export" tagprefix="uc1" %>

 <%@ Register src="../../../../Content/AdminDesign/MessagesTopMenu.ascx" tagname="MessagesTopMenu" tagprefix="uc20" %>
 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <uc20:MessagesTopMenu ID="MessagesTopMenu1" runat="server" />

    <uc1:Export ID="ucExport" runat="server" />

</asp:Content>

