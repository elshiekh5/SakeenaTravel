<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="ImportFromTextFile.aspx.cs"
    Inherits="AdminSmsUsers_ImportSmsFromTextFile" %>

<%@ Register src="../../../_UserControls/SMS/Users/Import-Export/ImportFromTextFile.ascx" tagname="ImportFromTextFile" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ImportFromTextFile ID="ImportFromTextFile1" runat="server" />
    
</asp:Content>

