<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Blogs.ascx.cs" Inherits="WebSite_PortfolioGrid_Controls_Items" %>
<%@ Register src="../../_SharedControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<%
    foreach (AppService.FrontItemsModel item in ItemsList)
    {
        %>
        <div class="blog margin-bottom-40">
                	<h2><a href="blog_item_option1.html"><%= item.Title%></a></h2>
                    <div class="blog-post-tags">
                        <ul class="list-unstyled list-inline blog-info">
                            <li><i class="fa fa-calendar"></i> <%= item.Date_Added%>/li>
                            <li><i class="fa fa-pencil"></i> <%= item.AuthorName%></li>
                        </ul>
                        <ul class="list-unstyled list-inline blog-tags">
                            <li>
                                <i class="fa fa-tags"></i> 
                                <a href="#">Technology</a> 
                                <a href="#">Education</a>
                                <a href="#">Internet</a>
                                <a href="#">Media</a>
                            </li>
                        </ul>                                                
                    </div>
                    <div class="blog-img">
                        <img class="img-responsive" src="<%= ThumbnailsManager.GetThumb(item.PhotoPathOriginal, 870, 315, 100)%>" alt="">
                    </div>
                    <p><%= item.ShortDescription%></p>
                    <p><a class="btn-u btn-u-small" href="<%= item.BuildLink%>"><i class="fa fa-plus-sign"></i> Read More</a></p>
                </div>
      
<%  }
%>

    
<div class="text-center">
                    <uc1:Pager ID="ucPager" runat="server" />                                         
</div>