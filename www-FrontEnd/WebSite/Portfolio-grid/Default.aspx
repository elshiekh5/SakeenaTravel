<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebSite/_Masters/ClearMaster.master"  CodeFile="Default.aspx.cs" Inherits="WebSite_PortfolioGrid_Default" %>
<%@ Register src="../_SharedControls/Intro.ascx" tagname="Intro" tagprefix="uc3" %>
<%@ Register src="Controls/Portfolio-grid.ascx" tagname="ItemsGallery" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="css" Runat="Server">
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/fancybox/source/jquery.fancybox.css">
    <%--<link rel="stylesheet" href="/WebSite/_Assets/css/effects.css" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container content">
           <uc2:ItemsGallery ID="ucPortfolioFull" runat="server" />
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
        <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="/WebSite/_Assets/js/grid.js"></script>
        <script type="text/javascript">
            var isAbsolute = false;
            var isFixed = true;

            $(document).ready(function () {
                $("#device").gridalicious({
                    width: 270,
                    gutter: 30,
                    animate: true,
                    animationOptions: {
                        speed: 150,
                        duration: 500,
                        complete: onComplete
                    },
                });
                // function not used.
                function onComplete(data) {
                }
            });
        </script>
</asp:Content>

