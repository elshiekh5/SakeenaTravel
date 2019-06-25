<%@ Control Language="C#" AutoEventWireup="true" %>
<script runat="server">
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }
    
    int index = 0;
    int rowsCountOpened = 0;
    int rowsCountClosed = 0;
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
		
<div class="gallery-page">
        <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
                <% if(index%3 == 0)
                {
                    ++rowsCountOpened; 
                %>
                   <div class="row margin-bottom-20">
                <% } %>
                    <div class="col-md-4 col-sm-6">
                        <a class="thumbnail fancybox-button zoomer" data-rel="fancybox-button" title="" href="/Content/UpFiles/_Site/ItemCategories/<%#Eval("CategoryID")%>/Items/<%#Eval("ItemID")%>/Files/ItemFiles_<%#Eval("FileID")%>-Big.jpg">
                            <span class="overlay-zoom">
                                <img alt="" src="<%# ThumbnailsManager.GetThumb(Eval("PhotoOiginalPath").ToString() , 270,170,100) %>" class="img-responsive">
                                <span class="zoom-icon"></span>
                            </span>
                        </a>
                    </div>


               
                <% if(index%3 == 2)
                { 
                     ++rowsCountClosed;
                %>
                </div>
                <% } %>

                 <% ++index; %>
                <%--<li>
                    <a href="" class="fancybox-button zoomer" data-rel="fancybox-button">
                        <em class="overflow-hidden thumbcontainer">
                            <img src="" alt="" /></em>
                        <span>
                            <i></i>
                        </span>
                    </a>
                </li>--%>
            </ItemTemplate>
        </asp:Repeater>
            <% if (rowsCountOpened > rowsCountClosed){ %>
            </div>
           <% } %>
        <!--/thumbnails-->

        			
</div>