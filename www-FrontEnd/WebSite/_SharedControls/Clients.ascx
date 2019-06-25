<%@ Control Language="C#" AutoEventWireup="true"  Inherits="DCCMSNameSpace.ReadyUserControls.Items_GetAll" %>
<script runat="server">
    public override void Prepare()
    {
        RequiredModule = SiteModulesMap.Clients;
    }
</script>
<div id="clients-flexslider" class="flexslider home clients">
            <div class="headline"><h2>Our Clients</h2></div>    
        <ul class="slides">
            <asp:Repeater ID="rList" runat="server">
    <ItemTemplate>
        <li>
                <a href="#">
                    <img src='<%# Eval("PhotoPathOriginal") %>' alt="" />
                    <img src='<%# Eval("Photo2Path") %>' class="color-img" alt="" />
                </a>
            </li>
    </ItemTemplate>
</asp:Repeater>
            
        </ul>
    </div>
