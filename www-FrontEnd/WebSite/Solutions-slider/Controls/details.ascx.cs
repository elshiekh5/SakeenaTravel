using AppService;
using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite_Solutions_slider_details : System.Web.UI.UserControl
{
    public ItemsModulesOptions currentModule { get; set; }
    public FrontItemsModel itemsObject { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        if (currentModule.HasTitle)
        {
            lblTitle.InnerText = itemsObject.Title;
        }
        if (currentModule.HasDate_Added)
        {
            lblDate.InnerHtml += itemsObject.ItemDate.ToLongDateString();
        }
        if (currentModule.HasAuthorName && !string.IsNullOrEmpty(itemsObject.AuthorName))
        {
            lblAuthor.InnerHtml += itemsObject.AuthorName;
        }
        if (currentModule.HasComments)
        {
            lblComments.InnerHtml += "24 " + Resources.Comments.UserCommentsCount;

        }
        if (currentModule.HasPhotoExtension && !string.IsNullOrEmpty(itemsObject.PhotoExtension))
        {
            imgPhoto.Src = ThumbnailsManager.GetThumb(itemsObject.PhotoPathOriginal.ToString(), 870, 315, 100);
        }
        if (currentModule.HasDetails && !string.IsNullOrEmpty(itemsObject.Description))
        {
            ltrDetails.Text = itemsObject.Description;

        }
    }
}