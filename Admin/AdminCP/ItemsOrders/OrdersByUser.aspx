<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="OrdersByUser.aspx.cs" Inherits="AdminItems_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

<%@ Register src="OrdersByUser.ascx" tagname="OrdersByUser" tagprefix="uc1" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OrdersByUser ID="ucOrdersByUser" runat="server" />
</asp:Content>

