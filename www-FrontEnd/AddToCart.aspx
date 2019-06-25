<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {

                int itemID = Convert.ToInt32(Request.QueryString["id"]);
                ItemsEntity item = null;
                ItemCategoriesEntity category = null;
                ShoppingCart.AddToCart(itemID, ref item, ref category);
                if (Request.QueryString["p"] != null)
                {
                    if (Request.QueryString["p"] == "m")
                        Response.Redirect("/default2.aspx#mbc");
                    else if (Request.QueryString["p"] == "s")
                    {
                        Response.Redirect("/WebSite/SpecialOptions/Default.aspx#spSlider");
                    }
                    else
                    {
                        LoadItemUrl(category);
                    }
                }
                else
                {
                    LoadItemUrl(category);
                }

            }
        }
    }
    public void LoadItemUrl(ItemCategoriesEntity category)
    {
        ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(16);
        string url = DCSiteUrls.Instance.BuildItemCategoriesLink(category.CategoryID, category.Title, currentModule);
        Response.Redirect(url);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
