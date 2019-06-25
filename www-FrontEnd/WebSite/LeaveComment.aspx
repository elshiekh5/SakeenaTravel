<%@ Page Title=""  Language="C#" MasterPageFile="~/WebSite/_Masters/Blank.master" AutoEventWireup="true" CodeFile="LeaveComment.aspx.cs" Inherits="WebSite_LeaveComment" %>

<%@ Register src="_SharedControls/LeaveComment.ascx" tagname="LeaveComment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:LeaveComment ID="LeaveComment1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

