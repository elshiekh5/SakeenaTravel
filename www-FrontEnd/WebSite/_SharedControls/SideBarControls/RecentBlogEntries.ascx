<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentBlogEntries.ascx.cs" Inherits="WebSite__SharedControls_SideBarControls_RecentBlogEntries" %>
<!-- Posts -->
<div class="posts margin-bottom-40">
    <div class="headline headline-md">
        <h2>Recent Posts</h2>
    </div>
    <asp:Repeater ID="rList" runat="server">
        <ItemTemplate>
            <dl class="dl-horizontal">
                <dt><a href="#">
                    <img src="<%# ThumbnailsManager.GetThumb(Eval("PhotoPathOriginal").ToString() , 150,160,100) %>" alt="<%# Eval("Title") %>" /></a></dt>
                <dd>
                    <p><a href="#"><%# Eval("Title") %></a></p>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
<!--/posts-->
<!-- End Posts -->



