<%@ Control Language="C#" AutoEventWireup="true"  Inherits="AppService.SingleItemUserConrol" %>
<script runat="server">
    public override void Prepare()
    {
        this.ItemID = (int)SitePages.AboutUsSlogan;
    }
</script>
<div class="spotLoght">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center animated fadeInLeft">
                    <%= this.RequiredItem.Description%>
                </div>            
                
            </div>
        </div>
    </div>  
