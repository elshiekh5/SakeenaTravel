<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs"
    Inherits="AdminSMSNumbers_Update" %>

<%@ Register src="../../_UserControls/SMS/Users/Edit.ascx" tagname="Edit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:Edit ID="Edit1" runat="server" />
    
</asp:Content>
