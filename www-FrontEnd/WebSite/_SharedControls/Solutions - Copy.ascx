<%@ Control Language="C#" AutoEventWireup="true"  Inherits="DCCMSNameSpace.ReadyUserControls.Items_GetAll" %>
<div id="w">
    <ul class="portfolio recent-work clearfix">
        <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
        <li data-id="id-2" class="print">
            <a href="<%# Eval("BuildLink") %>">
                <em class="overflow-hidden"><img src="<%# Eval("PhotoPathOriginal") %>" alt="" /></em>
                <span>
                    <strong><%# Eval("Title") %></strong>
                    <i><%# Eval("ShortDescription") %></i>
                </span>
            </a>
        </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>


