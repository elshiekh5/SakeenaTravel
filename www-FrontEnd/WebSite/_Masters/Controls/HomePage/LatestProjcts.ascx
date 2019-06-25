<%@ Control Language="C#" ClassName="LatestProjcts" %>
<script runat="server">
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }
    
    int index = 0;
    int rowsCountOpened = 0;
    int rowsCountClosed = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<ItemsEntity> itemsList = ItemsFactory.GetLast(25, 3, SitesHandler.GetOwnerIDAsGuid());
        if (itemsList != null && itemsList.Count > 0)
        {
            rList.DataSource = itemsList;
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
    public string GetActive() {
        if (index++ == 0)
            return "active";
        else
            return "";
    }
</script>
 <div class="headline"><h2>Latest Projects</h2></div>
        <div id="myCarousel" class="carousel slide carousel-v1 c-latestProject-Box">
            <div class="carousel-inner">
                <asp:Repeater ID="rList" runat="server">
                    <itemtemplate>
                        <div class="item <%# GetActive() %>">
                            <img src="<%# ThumbnailsManager.GetThumb(Eval(" photopathoriginal").ToString() , 973,615,100) %>" alt="" />
                            <div class="carousel-caption">
                                <p><%# Eval("Title") %></p>
                            </div>
                        </div>
                    </itemtemplate>
                </asp:Repeater>
            </div>

            <div class="carousel-arrow">
                <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                    <i class="fa fa-angle-left"></i>
                </a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next">
                    <i class="fa fa-angle-right"></i>
                </a>
            </div>
        </div>