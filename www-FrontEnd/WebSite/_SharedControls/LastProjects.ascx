<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LastProjects.ascx.cs" Inherits="WebSite__SharedControls_LastProjects" %>
<!-- Photo Stream -->
<div class="headline headline-md">
    <h2>Photo Stream</h2>
</div>
<ul class="list-unstyled blog-photos margin-bottom-30">
    <asp:Repeater ID="rList" runat="server">
        <ItemTemplate>
            <li><a class="fancybox-button" href="<%# Eval("PhotoPathOriginal")%>" data-rel="fancybox-button" title="Project #1">
                <img class="hover-effect" alt="<%# Eval("Title") %>" src="<%# ThumbnailsManager.GetThumb(Eval("PhotoPathOriginal").ToString() , 150,150,100) %>"></a></li>
        </ItemTemplate>

    </asp:Repeater>
</ul>
<!-- End Photo Stream -->
