<%@ Page Title="" Language="C#" MasterPageFile="~/WebSite/_Masters/ClearMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebSite_Items_About_Us_Default" %>

<%@ Register Src="controls/Welcome.ascx" TagName="Welcome" TagPrefix="uc1" %>

<%@ Register Src="controls/Slogan.ascx" TagName="Slogan" TagPrefix="uc2" %>

<%@ Register Src="../_SharedControls/Intro.ascx" TagName="Intro" TagPrefix="uc3" %>

<%@ Register Src="controls/TeamWork.ascx" TagName="TeamWork" TagPrefix="uc4" %>

<%@ Register Src="../_SharedControls/Clients.ascx" TagName="Clients" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="Server">
    <link rel="stylesheet" href="/WebSite/_Assets/plugins/flexslider/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container content">		
    	<div class="row margin-bottom-40">
        	
           <uc1:Welcome ID="Welcome1" runat="server" />
        	
        </div><!--/row-->
    </div>
        <uc2:Slogan ID="Slogan1" runat="server" />
    <div class="container content">		

    	<!-- Meer Our Team -->
    	<div class="headline"><h2>Meet Our Team</h2></div>

        <p>
                <uc3:Intro ID="Intro1" runat="server" RequiredPageType="TeamWorkIntro" />
            </p>

        <div class="row team">
            <uc4:TeamWork ID="TeamWork1" RequiredModule="TeamWork" runat="server" />
        </div>
        <!--/team-->
    	<!-- End Meer Our Team -->

        <!-- Our Clients -->
         <uc5:Clients ID="Clients1" runat="server" RequiredModule="Clients" /><!--/flexslider-->
        <!-- //End Our Clients -->
    </div>






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

