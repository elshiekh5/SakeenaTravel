<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/_Masters/ClearMaster.master" Inherits="DCCMSNameSpace.DynamicDefaultMasterPage" %>

<script runat="server">
/*
    protected override void OnPreInit(EventArgs e)
    {
        this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "Main.master";
        //this.SmartNavigation = true;
        this.MaintainScrollPositionOnPostBack = true;
        base.OnPreInit(e);
    }*/
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="css" Runat="Server">
<link rel="stylesheet" href="/WebSite/_Assets/plugins/flexslider/flexslider.css" >  
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/parallax-slider/css/parallax-slider.css">
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/owl-carousel/owl-carousel/owl.carousel.css">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts" Runat="Server">
<script type="text/javascript" src="/WebSite/_Assets/plugins/flexslider/jquery.flexslider-min.js"></script>
<script type="text/javascript" src="/WebSite/_Assets/plugins/parallax-slider/js/modernizr.js"></script>
<script type="text/javascript" src="/WebSite/_Assets/plugins/parallax-slider/js/jquery.cslider.js"></script>

    <script type="text/javascript" src="/WebSite/_Assets/plugins/bxslider/jquery.bxslider.js"></script>
<script type="text/javascript" src="/WebSite/_Assets/plugins/owl-carousel/owl-carousel/owl.carousel.js"></script>
    <!-- JS Page Level -->           
<script type="text/javascript" src="/WebSite/_Assets/js/app.js"></script>
<script type="text/javascript" src="/WebSite/_Assets/js/plugins/owl-carousel.js"></script>
<script type="text/javascript" src="/WebSite/_Assets/js/pages/index.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        App.init();
        App.initSliders();
        Index.initParallaxSlider();
        App.initBxSlider();
        OwlCarousel.initOwlCarousel();
    });
</script>
</asp:Content>


