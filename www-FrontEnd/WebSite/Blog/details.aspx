<%@ Page Language="C#"  MasterPageFile="~/WebSite/_Masters/Inner-WithSideBar.master" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="WebSite_Blog_details" %>

<%@ Register Src="../_SharedControls/Intro.ascx" TagName="Intro" TagPrefix="uc3" %>
<%@ Register Src="Controls/details.ascx" TagName="ItemDetails" TagPrefix="uc2" %>

<%@ Register Src="../_SharedControls/LeaveComment.ascx" TagName="LeaveComment" TagPrefix="uc4" %>

<script runat="server">
    
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="Server">
    <link rel="stylesheet" href="/WebSite/_Assets/css/pages/blog.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <uc2:ItemDetails ID="ucItemDetails" runat="server" />
                <!-- Leave a Comment -->
                <a id="iframe" href="/WebSite/LeaveComment.aspx">Leave your comment</a>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

