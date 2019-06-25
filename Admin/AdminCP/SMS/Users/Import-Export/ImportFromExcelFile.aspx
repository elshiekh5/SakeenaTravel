<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true"
    CodeFile="ImportFromExcelFile.aspx.cs" Inherits="Admin_SMSN_ImportFromExcelFile"  %>

<%@ Register src="../../../_UserControls/SMS/Users/Import-Export/ImportFromExcelFile.ascx" tagname="ImportFromExcelFile" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:ImportFromExcelFile ID="ImportFromExcelFile1" runat="server" />
    
</asp:Content>
