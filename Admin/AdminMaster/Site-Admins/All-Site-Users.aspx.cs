using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

public partial class MasterAdmin_AllSiteUsers : MasterAdminMasterPage
{
    MembershipUserCollection siteUsers=null;
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = "„” Œœ„Ì «·„Êﬁ⁄";
            PagerManager.PrepareAdminPager(pager);
            pager.Visible = false;
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    private void LoadData()
    {
        pager.PageSize = 25;
        int totalRecords = 0;
        siteUsers = Membership.GetAllUsers(pager.CurrentPage-1, pager.PageSize, out totalRecords);
        if (siteUsers != null && siteUsers.Count > 0)
        {
            dgSiteUsers.DataSource = siteUsers;
            dgSiteUsers.DataKeyField = "UserName";
            dgSiteUsers.AllowPaging = false;
            pager.Visible = true;
            pager.TotalRecords = totalRecords;
            dgSiteUsers.DataBind();
            dgSiteUsers.Visible = true;
        }
        else
        {
            dgSiteUsers.Visible = false;
            pager.Visible = false;
            lblResult.ForeColor = Color.Red;
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgSiteUsers_ItemDataBound--------------
    //---------------------------------------------------------
    //dgSiteUsers_ItemDataBound
    //---------------------------------------------------------
    protected void dgSiteUsers_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
        }
    }
    //--------------------------------------------------------
    #endregion

    protected string GetPassword(string UserName)
    {
        string pass = "";
        if (siteUsers != null && siteUsers.Count > 0)
        {
            MembershipUser user = siteUsers[UserName];
            if (user != null)
            pass = user.GetPassword();
        }
        return pass;

    }

    #region --------------Pager_PageIndexChang--------------
    //---------------------------------------------------------
    //Pager_PageIndexChang
    //---------------------------------------------------------
    protected void Pager_PageIndexChang()
    {
        LoadData();
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgSiteUsers_DeleteCommand--------------
    //---------------------------------------------------------
    //dgSiteUsers_DeleteCommand
    //---------------------------------------------------------
    protected void dgSiteUsers_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        //-----------------------------------------------------------------------------------
        string username = (string)dgSiteUsers.DataKeys[e.Item.ItemIndex];
        //-----------------------------------------------------------------------------------
        if (Membership.DeleteUser(username, true))
        {
            lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            if (dgSiteUsers.Items.Count == 1)
            {
                --pager.CurrentPage;
            }
            LoadData();
        }
        else
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
        //-----------------------------------------------------------------------------------

    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgSiteUsers_EditCommand--------------
    //---------------------------------------------------------
    //dgSiteUsers_EditCommand
    //---------------------------------------------------------
    protected void dgSiteUsers_EditCommand(object source, DataGridCommandEventArgs e)
    {
        ImageButton lbtnUserActivation = (ImageButton)e.Item.FindControl("lbtnUserActivation");
        //-----------------------------------------------------------------------------------
        string username = (string)dgSiteUsers.DataKeys[e.Item.ItemIndex];
        //-----------------------------------------------------------------------------------
        MembershipUser user = Membership.GetUser(username);
        if (user != null)
        {
            if (user.IsApproved)
            {
                //-----------------------------------------------------------------------
                user.IsApproved = false;
                Membership.UpdateUser(user);
                //-----------------------------------------------------------------------
                lblResult.CssClass = "operation_error";
                lblResult.Text = " „ ≈·€«¡ «· ›⁄Ì·";
                lbtnUserActivation.ImageUrl = "/Content/images/Boolean/false.gif";
            }
            else
            {
                //-----------------------------------------------------------------------
                user.IsApproved = true;
                Membership.UpdateUser(user);
                //-----------------------------------------------------------------------
                lblResult.CssClass = "operation_done";
                lblResult.Text = " „ «· ›⁄Ì·";
                lbtnUserActivation.ImageUrl = "/Content/images/Boolean/True.gif";
                //-----------------------------------------------------------------------
            }
            
        }
        else
        {
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_error";
            lblResult.Text = "·„ Ì‰ÃÕ ⁄„·Ì… «·Õ’Ê· ⁄·Ï »Ì«‰«  Â–« «·„” Œœ„";
            //-----------------------------------------------------------------------
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetActivationImage--------------
    //---------------------------------------------------------
    //GetActivationImage
    //---------------------------------------------------------
    public string GetActivationImage(object isApproved)
    {
        bool _IsApproved = Convert.ToBoolean(isApproved);
        if (_IsApproved)
            return "/Content/images/Boolean/true.gif";
        else
            return "/Content/images/Boolean/false.gif";

    }
    //--------------------------------------------------------
    #endregion

    public string GetSubSiteFolderSize(object identifire)
    {
        string text = "";
        long folderSize = 0;
        string folderPath = DCSiteUrls.GetPath_SubSiteUploadFolder((string)identifire);
        string folderPathPhysicalPath = DCServer.MapPath(folderPath);
        if (Directory.Exists(folderPathPhysicalPath))
        {
            DirectoryInfo dir = new DirectoryInfo(folderPathPhysicalPath);
            DcDirectoryManager.GetDirectorySize(dir, ref  folderSize);
            text = DcDirectoryManager.CalculateSizeToRead(folderSize);
        }
        return text;
    }

    

}

