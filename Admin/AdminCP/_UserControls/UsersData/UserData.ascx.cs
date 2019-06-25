using System;using DCCMSNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class Admin_UserData_View : System.Web.UI.UserControl
{
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    UsersDataGlobalOptions currentModule;

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
        if (!IsPostBack)
        {
            HandleOptionalControls(); 
            LoadData();
           
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        //HasName
        trName.Visible = currentModule.HasName;
        //-----------------------------------
        //HasTel
        trTel.Visible = currentModule.HasTel;
        //-----------------------------------
        //HasMobile
        trMobile.Visible = currentModule.HasMobile;
        //-----------------------------------
    }
    //-----------------------------------------------
    #endregion
    
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("UserId"))
        {
            Guid userid = new Guid(Request.QueryString["UserId"]);
            MembershipUser user = Membership.GetUser(userid);
            UsersDataEntity usersDataObject = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, OwnerID);
            if (usersDataObject != null)
            {
                lblName.Text = usersDataObject.Name;
                lblTel.Text = usersDataObject.Tel;
                lblMobile.Text = usersDataObject.Mobile;
                
              
               
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }

    }
    //-----------------------------------------------
    #endregion
}

