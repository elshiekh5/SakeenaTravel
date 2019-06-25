<%@ Control Language="C#" AutoEventWireup="true" %>
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

<div class="headline">
    <h3>Samples</h3>
    <a class="ch-viewall" href="#"></a></div>
<div class="row-fluid  gallery margin-bottom-40 ">
    <ul id="list" class="bxslider recent-work">
        <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
               <%-- <li>
                    <a href="<%# ItemsFilesEntity.GetPhotoPath(PhotoTypes.Big,Eval("FileID"),Eval("FileExtension"),Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>" class="fancybox-button zoomer" data-rel="fancybox-button">
                        <em class="overflow-hidden thumbcontainer">
                            <img src="<%# ItemsFilesFactory.GetPhotoThumbnail(Eval("FileID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>" alt="" /></em>
                        <span>
                            <i></i>
                        </span>
                    </a>
                </li>--%>
                 <li>
                    <a href="/Content/UpFiles/_Site/ItemCategories/<%#Eval("CategoryID")%>/Items/<%#Eval("ItemID")%>/Files/ItemFiles_<%#Eval("FileID")%>-Big.jpg" class="fancybox-button zoomer" data-rel="fancybox-button">
                        <em class="overflow-hidden thumbcontainer">
                            <img src="<%# ItemsFilesFactory.GetPhotoThumbnail(Eval("FileID"),Eval("PhotoExtension"),SiteSettings.Photos_HListWidth,SiteSettings.Photos_HListHeight,Eval("OwnerName"),Eval("ModuleTypeID"),Eval("CategoryID"),Eval("ItemID"))%>" alt="" /></em>
                        <span>
                            <i></i>
                        </span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>


    </ul>
</div>
<!--/row-->
<!-- //End Recent Works -->
