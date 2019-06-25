<%@ Page Language="C#" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int itemID = Convert.ToInt32(Request.QueryString["id"]);
                ShoppingCart.RemoveFromCart(itemID);
                Response.Redirect("/WebSite/Orders/CartItems.aspx");
            }
        }
    }
</script>
