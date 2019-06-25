<%@ Control Language="C#" ClassName="Header" %>
<script runat="server"></script>
<!--=== Header ===-->
<div class="header">
    <!-- Topbar -->
    <div class="topbar">
        <div class="container">
            <!-- Topbar Navigation -->
            <ul class="loginbar pull-left">
                <li>
                    <i class="fa fa-globe"></i>
                    012 113 680 95 
                </li>
                <li class="topbar-devider"></li>
               <li>
                    <i class="fa fa-globe"></i>
                    elshiekh5@gmail.com 
                </li>
            </ul>
            <!-- End Topbar Navigation -->
            <!-- Topbar Navigation -->
            <ul class="loginbar pull-right">
                <li>
                    <i class="fa fa-globe"></i>
                    <a>Languages</a>
                    <ul class="lenguages">
                        <li class="active">
                            <a href="/ChangeLang.aspx?id=<%=Resources.Lang.OtherLangID %>">English <i class="fa fa-check"></i></a>
                        </li>
                        <li><a href="#">عربي</a></li>
                        <li><a href="#">Russian</a></li>
                        <li><a href="#">German</a></li>
                    </ul>
                </li>
                <li class="topbar-devider"></li>
                <li><a href="page_faq.html">Help</a></li>
                <li class="topbar-devider"></li>
                <li><a href="page_login.html">Login</a></li>
            </ul>
            <!-- End Topbar Navigation -->
        </div>
    </div>
    <!-- End Topbar -->
    <!-- Navbar -->
    <div class="navbar navbar-default" role="navigation">
        <div class="container">
            <div class="top2">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="fa fa-bars"></span>
                </button>
                <a class="navbar-brand" href="index.html">
                    <img id="logo-header" src="/WebSite/_Assets/img/logo.png" alt="Logo">
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="cborder pull-right">	
            <div class="collapse navbar-collapse navbar-responsive-collapse">
                <ul class="nav navbar-nav">
                    <!-- Home -->
                    <li class="active">
                        <a href="/">Home</a>
                    </li>
                    <li>
                        <a href="/About_Us/all.aspx">About Us</a>

                    </li>
                    <li>
                        <a href="/Services/all.aspx">
                            Services
                        </a>

                    </li>
                    <li>
                        <a href="/Solutions/all.aspx">
                            Solutions
                        </a>
                    </li>
                    <li>
                        <a href="/Portfolio/all.aspx">Portfolio</a>
                    </li>
                    <li>
                        <a href="/Blog/all.aspx">Blog</a>
                    </li>
                    <li>
                        <a href="/Contact_Us/send.aspx">Contact Us</a>
                    </li>
                   
                </ul>
            </div><!--/navbar-collapse-->
                </div>
                </div>
        </div>
    </div>
    <!-- End Navbar -->
</div>
<!--=== End Header ===-->   