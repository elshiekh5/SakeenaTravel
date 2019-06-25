<%@ Control Language="C#" AutoEventWireup="true"  Inherits="AppService.SingleItemUserConrol" %>
<script runat="server">
    public override void Prepare()
    {
        this.ItemID = (int)SitePages.Welcome;
    }
</script>
<div class="col-md-6 md-margin-bottom-40">
    <%= this.RequiredItem.Description%>
</div>

<div class="col-md-6 md-margin-bottom-40">
    <div class="responsive-video">
        <iframe src="http://player.vimeo.com/video/<%= RequiredItem.YoutubeCode %>" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
    </div>
</div>


