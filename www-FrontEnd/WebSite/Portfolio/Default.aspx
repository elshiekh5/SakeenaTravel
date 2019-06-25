<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebSite/_Masters/ClearMaster.master"  CodeFile="Default.aspx.cs" Inherits="WebSite_Portfolio_Default" %>
<%@ Register src="../_SharedControls/Intro.ascx" tagname="Intro" tagprefix="uc3" %>
<%@ Register src="Controls/Portfolio.ascx" tagname="ItemsGallery" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="css" Runat="Server">
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/fancybox/source/jquery.fancybox.css">
    <%--<link rel="stylesheet" href="/WebSite/_Assets/css/effects.css" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container content">
           <uc2:ItemsGallery ID="ucPortfolioFull" runat="server" ModuleTypeID="24" />
    </div>
<!--/container-->
<!--=== End Content Part ===-->
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="scripts" Runat="Server">
    <!-- JS Implementing Plugins -->
    <script type="text/javascript" src="/WebSite/_Assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
    <!-- JS Page Level -->
    <script type="text/javascript" src="/WebSite/_Assets/js/app.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            App.initFancybox();
        });
    </script>
        <!-- Le javascript
        ================================================== -->
</asp:Content>

