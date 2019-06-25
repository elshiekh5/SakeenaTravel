<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="ImportFromTextFile.aspx.cs"
    Inherits="AdminMailListUsers_ImportMailsFromTextFile" %>

<%@ Register src="../../../_UserControls/MailList/MailListUsers/Import-Export/ImportFromTextFile.ascx" tagname="ImportFromTextFile" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ImportFromTextFile ID="ImportFromTextFile1" runat="server" />
    
</asp:Content>

