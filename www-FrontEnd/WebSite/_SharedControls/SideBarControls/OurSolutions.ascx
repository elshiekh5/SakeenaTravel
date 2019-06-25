<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OurSolutions.ascx.cs" Inherits="WebSite__SharedControls_SideBarControls_OurSolutions" %>
<!-- Blog Tags -->
<div class="headline headline-md">
    <h2>Solutions</h2>
</div>
<ul class="list-unstyled blog-tags margin-bottom-30">
    <asp:Repeater ID="rList" runat="server">
        <ItemTemplate>
            <li><a href="<%# Eval("BuildLink") %>"><i class="fa fa-tags"></i><%# Eval("Title") %></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<!-- End Blog Tags -->






