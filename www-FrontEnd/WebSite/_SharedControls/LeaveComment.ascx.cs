using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite__SharedControls_LeaveComment : System.Web.UI.UserControl
{
   
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------ModuleBaseTypes--------------
    private ModuleBaseTypes _BaseModuleType = ModuleBaseTypes.Items;
    public ModuleBaseTypes BaseModuleType
    {
        get { return _BaseModuleType; }
        set { _BaseModuleType = value; }
    }
    //------------------------------------------
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            if (!MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.Comments.SorryCannotComment;
                divControls.Visible = false;
                lblResult.Visible = true;
            }
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
     {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            if (!Page.IsValid) return;
            //-----------------------------------------------------------------
            ItemsCommentsEntity comment = new ItemsCommentsEntity();
            comment.SenderName = txtName.Text;
            comment.ItemID = Convert.ToInt32(Request.QueryString["id"]);
            comment.LangID = SiteSettings.GetCurrentLanguage();
            comment.SenderEmail = txtEmail.Text;
            //if (trCountryID.Visible)
            //{
            //    comment.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
            //    SystemCountriesEntity country = SystemCountriesFactory.GetObject(comment.CountryID);
            //    comment.CtryShort = country.country_code;
            //}
            //comment.CommentTitle = txtCommentTitle.Text;
            comment.CommentText = txtCommentText.Text;
            //---------------------------------------
            //ModulesItemsEntity item = ModulesItemsFactory.GetObjectForUser(comment.ItemID, false);
            //comment.IsActive = !item.ModeratedComments;
            comment.SendingDate = DateTime.UtcNow;
            //---------------------------------------

            //---------------------------------------
            comment.ModuleTypeID = ModuleTypeID;
            comment.BaseModuleType = BaseModuleType;
            ExecuteCommandStatus status = ItemsCommentsFactory.Create(comment);

            if (status == ExecuteCommandStatus.Done)
            {
                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.Comments.CommentSent;
                //ClearControls();
                divControls.Visible = false;
                lblResult.Visible = true;
            }
            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.Comments.CommentError;
                divControls.Visible = true;
                lblResult.Visible = true;
            }
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.Comments.SorryCannotComment;
            divControls.Visible = true;
            lblResult.Visible = true;
        }
    }

   
}