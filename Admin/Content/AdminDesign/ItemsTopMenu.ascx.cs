using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class App_Design_masters_ItemsTopMenu : System.Web.UI.UserControl
{
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    public ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];
    public int inactiveCommentsCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Visible = false;
        return;
        if (!IsPostBack)
        {
            trCategories.Visible = false;
            trItems.Visible = false;
            trPhotos.Visible = false;
            trComments.Visible = false;
            if (currentModule.CategoryLevel != 0 && currentModule.DisplayCategoriesInAdminMenue)
            {
                trCategories.Visible = true;
            }
            trItems.Visible = true;
            if (currentModule.HasMultiPhotos)
            {
                trPhotos.Visible = true;
            }
            if (currentModule.HasComments)
            {
                trComments.Visible = true;
                inactiveCommentsCount = ItemsCommentsFactory.GetCount(-1, Languages.Unknowen, currentModule.ModuleTypeID, true, false, false, OwnerID);
                lblInactiveComments.Text = Resources.Modules.Module_CommentsInactive + " -" + inactiveCommentsCount;
            }
        }
        
    }

   

}
