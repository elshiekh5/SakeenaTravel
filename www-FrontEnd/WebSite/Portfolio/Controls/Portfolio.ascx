<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Portfolio.ascx.cs" Inherits="WebSite_Portfolio_Controls_Items" %>
<%@ Register src="../../_SharedControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>
  <% 
     
 %>
<div class="gallery-page">
<div class="row margin-bottom-20">
<%
    foreach (AppService.FrontItemsModel item in ItemsList)
    {
        %>

    <div class="col-md-3 col-sm-6">
                        <a class="thumbnail fancybox-button zoomer" data-rel="fancybox-button" title="<%= item.Title%>" href="<%= item.PhotoPathOriginal%>">
                            <span class="overlay-zoom">
                                <img alt="" src="<%= ThumbnailsManager.GetThumb(item.PhotoPathOriginal, 270,270,100) %>" class="img-responsive">
                                <span class="zoom-icon"></span>
                            </span>
                        &nbsp;</a>
    </div>
        
      
<%  }
%>
    
 </div>
    
    <div class="text-right">
        <uc1:pager ID="ucPager" runat="server" />
    </div>

</div>