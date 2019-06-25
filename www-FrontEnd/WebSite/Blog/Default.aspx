<%@ Page Language="C#" Title="" MasterPageFile="~/WebSite/_Masters/Inner-WithSideBar.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebSite_Blog_Default" %>
<%@ Register src="Controls/Blogs.ascx" tagname="Blog" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="css" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc2:Blog ID="Blog1" runat="server"  ModuleTypeID="15"  />   
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

