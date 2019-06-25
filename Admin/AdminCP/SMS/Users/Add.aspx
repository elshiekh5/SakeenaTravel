<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Add.aspx.cs"
    Inherits="AdminSMSNumbers_Create" %>

<%@ Register src="../../_UserControls/SMS/Users/Add.ascx" tagname="Add" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:Add ID="Add1" runat="server" />
    
</asp:Content>
