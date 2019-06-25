<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebSite/_Masters/ClearMaster.master" CodeFile="Default.aspx.cs" Inherits="WebSite_Services_Default" %>
<%@ Register Src="../_SharedControls/Intro.ascx" TagName="Intro" TagPrefix="uc3" %>
<%@ Register Src="../_SharedControls/Clients.ascx" TagName="Clients" TagPrefix="uc5" %>
<%@ Register Src="controls/Services.ascx" TagName="ServicesFull" TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="Server">
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/flexslider/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--=== Content Part ===-->
    <div class="container content">
        <div class="row margin-bottom-20">
            <div class="col-md-12">
                <p>
                    <uc3:Intro ID="Intro3" runat="server" RequiredPageType="ServicesIntro" />
                </p>
            </div>
        </div>
        <uc6:ServicesFull ID="Services1" runat="server" />

        <!-- Our Clients -->
        <uc5:Clients ID="Clients2" runat="server" RequiredModule="Clients" />
        <!--/flexslider-->
        <!-- //End Our Clients -->
    </div>
    <!--/container-->
    <!--=== End Content Part ===-->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scripts" runat="Server">
    <!-- JS Implementing Plugins -->
    <script type="text/javascript" src="/WebSite/_Assets/plugins/flexslider/jquery.flexslider-min.js"></script>
    <!-- JS Page Level -->
    <script type="text/javascript" src="/WebSite/_Assets/js/app.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            App.initSliders();
        });
    </script>
</asp:Content>

