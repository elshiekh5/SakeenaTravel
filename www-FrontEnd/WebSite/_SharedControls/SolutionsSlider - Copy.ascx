<%@ Control Language="C#" AutoEventWireup="true"  %>
<script runat="server">
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ItemsFilesEntity> photosList = ItemsFilesFactory.GetAll(itemsObject.ItemID, ItemFileTypes.Photo);
        if (photosList != null && photosList.Count > 0)
        {
            rList.DataSource = photosList;
            rList.DataBind();
            rList.Visible = true;
            this.Visible = true;
            //-----------------------------------------
        }
        else
        {
            rList.Visible = false;
            this.Visible = false;
        }
    }
</script>
        <ul id="itemPhotosSlider" class="bxslider recent-work">
            <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
            <li>
                <a href="#">
                <em class="overflow-hidden"><img src="<%# ItemsFilesFactory.GetPhotoThumbnail(Eval("FileID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>" alt="" /></em>
                </a>
            </li>
            </ItemTemplate>
        </asp:Repeater>
