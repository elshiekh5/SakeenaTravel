<%@ Control Language="C#" AutoEventWireup="true" Inherits="DCCMSNameSpace.ReadyUserControls.Items_GetAll" %>
<script runat="server">
    public override void Prepare()
    {
        RequiredModule = SiteModulesMap.Portfolio;
    }
</script>

<%@ Register Src="Intro.ascx" TagName="Intro" TagPrefix="uc1" %>
<div class="row-fluid">
    <p>
        <uc1:intro id="Intro1" runat="server" requiredpagetype="PortfolioIntro" />
    </p>
    <br />
</div>
<div class="row-fluid gallery">
                <ul id="device">
                    <asp:Repeater ID="rList" runat="server">
                        <ItemTemplate>
                            <li class="item">
                                <a class="thumbnail fancybox-button zoomer" data-rel="fancybox-button" title="Project #<%# Eval("ItemID") %>" href='<%# Eval("PhotoPathOriginal") %>'>
                                    <div class="overlay-zoom">
                                        <img src='<%# Eval("Photo2Path") %>' alt="" />

                                        <div class="zoom-icon"></div>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
<div class="pagination pagination-right">
    <ul>
        <li><a href="#">Prev</a></li>
        <li><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li class="active"><a>3</a></li>
        <li><a href="#">4</a></li>
        <li><a href="#">5</a></li>
        <li><a href="#">Next</a></li>
    </ul>
</div>
</div>            

        
            <!--/row-fluid-->
