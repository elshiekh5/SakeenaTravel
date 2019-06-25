<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutTab.ascx.cs" Inherits="WebSite__SharedControls_AboutTabl" %>
<!-- Tabs Widget -->
            <div class="headline headline-md"><h2>Digital Tags</h2></div>
             <p>Pellentesque fermentum, ante ac felis.</p>                        
            <div class="tab-v2 margin-bottom-40">
                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home-1">About Us</a></li>
                        <li><a data-toggle="tab" href="#home-2"><%= (WhyUs!=null)?WhyUs.Title:"" %></a></li>
                    </ul>                
                    <div class="tab-content">
                        <div id="home-1" class="tab-pane active">
                            <p>Vivamus imperdiet condimentum diam, eget placerat felis consectetur id. Donec eget orci metus, ac ac adipiscing nunc.</p> <p>Pellentesque fermentum, ante ac felis consectetur id. Donec eget orci metusvivamus imperdiet.</p>                        
                        </div>
                        <div id="home-2" class="tab-pane magazine-sb-categories">
                            <p><%= (WhyUs!=null)?WhyUs.ShortDescription:"" %></p>
                            <div class="row">
                                <ul class="list-unstyled col-xs-6">
                                    <li><a href="#">Best Sliders</a></li>
                                    <li><a href="#">Parralax Page</a></li>
                                    <li><a href="#">Backgrounds</a></li>
                                    <li><a href="#">Parralax Slider</a></li>
                                    <li><a href="#">Responsive</a></li>
                                    <li><a href="#">800+ fa fas</a></li>
                                </ul>                        
                                <ul class="list-unstyled col-xs-6">
                                    <li><a href="#">60+ Pages</a></li>
                                    <li><a href="#">Layer Slider</a></li>
                                    <li><a href="#">Bootstrap 3</a></li>
                                    <li><a href="#">Fixed Header</a></li>
                                    <li><a href="#">Best Template</a></li>
                                    <li><a href="#">And Many More</a></li>
                                </ul>                        
                            </div>
                        </div>
                    </div>
                </div>            
            <!-- End Tabs Widget -->