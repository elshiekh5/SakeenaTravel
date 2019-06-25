<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemsGallery.ascx.cs" Inherits="WebSite__SharedControls_ItemsGallery" %>
<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>
<div class="gallery-page">
                <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
                <% if(index%4 == 0)
                {
                    ++rowsCountOpened; 
                %>
                   <div class="row margin-bottom-20">
                <% } %>
                    <div class="col-md-3 col-sm-6">
                        <a class="thumbnail fancybox-button zoomer" data-rel="fancybox-button" title="<%# Eval("Title")%>" href="<%# Eval("PhotoPathOriginal")%>">
                            <span class="overlay-zoom">
                                <img alt="" src="<%# ThumbnailsManager.GetThumb(Eval("PhotoPathOriginal").ToString() , 270,270,100) %>" class="img-responsive">
                                <span class="zoom-icon"></span>
                            </span>
                        </a>
                    </div>


               
                <% if(index%4 == 3)
                { 
                     ++rowsCountClosed;
                %>
                </div>
                <% } %>

                 <% ++index; %>
                <%--<li>
                    <a href="" class="fancybox-button zoomer" data-rel="fancybox-button">
                        <em class="overflow-hidden thumbcontainer">
                            <img src="" alt="" /></em>
                        <span>
                            <i></i>
                        </span>
                    </a>
                </li>--%>
            </ItemTemplate>
        </asp:Repeater>
            <% if (rowsCountOpened > rowsCountClosed){ %>
            </div>
           <% } %>
        <!--/thumbnails-->
                
                <div class="text-right">
                   <uc1:Pager ID="ucPager" runat="server" />
                </div>
</div>










