<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Details.aspx.cs" Inherits="AdminItems_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

<%@ Register src="Details.ascx" tagname="Details" tagprefix="uc1" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Details ID="ucDetails" runat="server" />
</asp:Content>

