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

using DCCMSNameSpace.Zecurity;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class Logout : ReadyUserControls.UserControl
        {
            //-----------------------------------------------------------
            Label lblUserName;
            LinkButton lbtnLogOut;
            //LinkButton lbtnLogOut2;
            Control liProfile;
            Control liLinkMainPage;
            Control liLinkControlPanel;
            //Control liLinkUsersSites;
            //Control liLinkUsersFiles;
            //Control liLinkUsersPhotos;
            //Control liLinkUsersVideos;
            HtmlAnchor aLinkMainPage;
            //HtmlAnchor aLinkControlPanel;
            //HtmlAnchor aLinkUsersSites;
            //HtmlAnchor aLinkUsersFiles;
            //HtmlAnchor aLinkUsersPhotos;
            //HtmlAnchor aLinkUsersVideos;
            //-----------------------------------------------------------

            #region ---------------Page_Load---------------
            //-----------------------------------------------
            //CatchConPage_Loadtrols
            //-----------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (this.Page.User != null && this.Page.User.Identity.IsAuthenticated)
                {
                    string username = this.Page.User.Identity.Name;
                    lblUserName.Text = username;
                    MembershipUser user = Membership.GetUser(this.Page.User.Identity.Name);
                    UsersDataEntity userData = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, Guid.Empty);
                    //aLinkMainPage.HRef = userData.ProfilePageID;xxxxxxxx
                    //aLinkControlPanel.HRef = "/Adminsub/default.aspx";
                    //aLinkUsersSites.HRef = "/" + username + "/SubSite/Items/UsersSites/default.aspx";
                    //aLinkUsersVideos.HRef = "/" + username + "/SubSite/Items/UsersVideos/default.aspx";
                    //aLinkUsersPhotos.HRef = "/" + username + "/SubSite/Items/UsersPhotos/default.aspx";
                    //aLinkUsersFiles.HRef = "/" + username + "/SubSite/Items/UsersFiles/default.aspx";
                    //------------------------
                    if (Roles.IsUserInRole(ZecurityManager.UserName, DCRoles.SiteOverallAdminsRoles) || Roles.IsUserInRole(ZecurityManager.UserName, DCRoles.SiteSubAdminsRoles))
                    {
                        //aLinkControlPanel.HRef = "/Admincp/default.aspx";
                        //liLinkMainPage.Visible = false;
                        //liProfile.Visible = false;
                        //liLinkUsersSites.Visible = false;
                        //liLinkUsersFiles.Visible = false;
                        //liLinkUsersPhotos.Visible = false;
                        //liLinkUsersVideos.Visible = false;
                    }
                }
            }
            //-----------------------------------------------
            #endregion

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                //-----------------------------------------------
                lblUserName = (Label)this.FindControl("lblUserName");
                //-----------------------------------------------
                lbtnLogOut = (LinkButton)this.FindControl("lbtnLogOut");
                lbtnLogOut = (LinkButton)this.FindControl("lbtnLogOut");
                //-----------------------------------------------
                liProfile = (Control)this.FindControl("liProfile");
                liLinkMainPage = (Control)this.FindControl("liLinkMainPage");
                liLinkControlPanel = (Control)this.FindControl("liLinkControlPanel");
                //liLinkUsersSites = (Control)this.FindControl("liLinkUsersSites");
                //liLinkUsersFiles = (Control)this.FindControl("liLinkUsersFiles");
                //liLinkUsersPhotos = (Control)this.FindControl("liLinkUsersPhotos");
                //liLinkUsersVideos = (Control)this.FindControl("liLinkUsersVideos");
                //-----------------------------------------------
                aLinkMainPage = (HtmlAnchor)this.FindControl("aLinkMainPage");
                //aLinkControlPanel = (HtmlAnchor)this.FindControl("aLinkControlPanel");
                //aLinkUsersSites = (HtmlAnchor)this.FindControl("aLinkUsersSites");
                //aLinkUsersFiles = (HtmlAnchor)this.FindControl("aLinkUsersFiles");
                //aLinkUsersPhotos = (HtmlAnchor)this.FindControl("aLinkUsersPhotos");
                //aLinkUsersVideos = (HtmlAnchor)this.FindControl("aLinkUsersVideos");
                //-----------------------------------------------
            }
            //-----------------------------------------------
            #endregion

            //-----------------------------------------------------------
            protected void lbtnLogOut_Click(object sender, EventArgs e)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(SiteUrls.HomePage);
            }
            //-----------------------------------------------------------
            protected void lbtnLogOutLink_Click(object sender, EventArgs e)
            {
                FormsAuthentication.SignOut();
                Response.Redirect(SiteUrls.HomePage);
            }
            //-----------------------------------------------------------
        }
    }
}