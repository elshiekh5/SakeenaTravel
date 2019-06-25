<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="ImportFromExcelFile.aspx.cs"
    Inherits="AdminMailListUsers_ImportMailsFromExcelFile" %>

<%@ Register src="../../../_UserControls/MailList/MailListUsers/Import-Export/ImportFromExcelFile.ascx" tagname="ImportFromExcelFile" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ImportFromExcelFile ID="ImportFromExcelFile1" runat="server" />
    
</asp:Content>

