<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentBlogEntries.ascx.cs" Inherits="Footer_RecentBlogEntries" %>

<div class="posts">
    <div class="headline">
        <h2>Recent Blog Entries</h2>
    </div>
    <asp:Repeater ID="rList" runat="server">
        <ItemTemplate>
            <dl class="dl-horizontal">
                <dt><a href="#">
                    <img src="<%# ThumbnailsManager.GetThumb(Eval("PhotoPathOriginal").ToString() , 150,160,100) %>" alt="<%# Eval("Title") %>"></a></dt>
                <dd>
                    <p><a href="#"><%# Eval("Title") %></a></p>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
