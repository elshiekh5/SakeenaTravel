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

namespace DCCMSNameSpace.ReadyUserControls
{
    /// <summary>
    /// Summary description for ItemsGetAllBaseControl
    /// </summary>
    public class ItemCategories_GetAllBaseControl : ReadyUserControls.UserControl
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
        
        #region --------------ParentID--------------
        public int ParentID
        {
            get
            {
                if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                    return Convert.ToInt32(Request.QueryString["id"]);
                else
                    return 0;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------TemplateID--------------
        private string _TemplateID = "dlCategories";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListDir--------------
        public string ListDir
        {
            get
            {

                Languages langID = SiteSettings.GetCurrentLanguage();
                if (langID == Languages.Ar)
                    return "rtl";
                else
                    return "ltr";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        //---------------------------------------------
        public ItemsModulesOptions currentModule;
        public DCSiteUrls siteUrls;
        int totalRecords = 0;
        //---------------------------------------------
        MoversFW.OurPager pager;
        Label lblResult;
        HtmlTableRow trPagerContainer;

        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //---------------------------------------------
            currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            if (!IsPostBack)
            {
                PagerManager.PrepareUserPager(pager);
                pager.Visible = false;
                trPagerContainer.Visible = false;
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion

        //-----------------------------------------------------------
        protected void CatchControls()
        {
            lblResult = (Label)this.FindControl("lblResult");
            trPagerContainer = (HtmlTableRow)this.FindControl("trPagerContainer");
            pager = (MoversFW.OurPager)this.FindControl("pager");
        }
        //-----------------------------------------------------------


        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public new void LoadData()
        {

            pager.PageSize = currentModule.CategoryPageItemCount_UserDefault;
            List<ItemCategoriesEntity> categoriesList = ItemCategoriesFactory.GetAll(ModuleTypeID, ParentID, true, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID);

            Control c;
            DataList dl;
            Repeater r;
            c = this.FindControl(TemplateID);
            if (c is DataList)
            {
                dl = (DataList)c;
                LoadDataList(dl, categoriesList);
            }
            else
            {
                r = (Repeater)c;
                LoadRepeater(r, categoriesList);
            }
        }

        //--------------------------------------------------------
        #endregion


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

        #region --------------LoadDataList--------------
        //---------------------------------------------------------
        //LoadDataList
        //---------------------------------------------------------
        public void LoadDataList(DataList dl, List<ItemCategoriesEntity> categoriesList)
        {
            if (categoriesList != null && categoriesList.Count > 0)
            {

                dl.DataSource = categoriesList;
                dl.DataBind();
                dl.Visible = true;
                if (totalRecords > pager.PageSize)
                {
                    pager.Visible = true;
                    trPagerContainer.Visible = true;
                    pager.TotalRecords = totalRecords;
                    PagerManager.PrepareUserPager(pager);

                }
                else
                {
                    pager.TotalRecords = totalRecords;
                    pager.Visible = false;
                    trPagerContainer.Visible = false;
                }
                lblResult.Visible = false;
            }
            else
            {/*
                dl.Visible = false;
                pager.Visible = false;
                trPagerContainer.Visible = false;
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = DynamicResource.GetText("AdminText", "ThereIsNoData");
                lblResult.Visible = true;*/
                this.Visible = false;
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------LoadRepeater--------------
        //---------------------------------------------------------
        //LoadRepeater
        //---------------------------------------------------------
        public void LoadRepeater(Repeater r, List<ItemCategoriesEntity> categoriesList)
        {
            if (categoriesList != null && categoriesList.Count > 0)
            {
                r.DataSource = categoriesList;
                r.DataBind();
                r.Visible = true;
                if (totalRecords > pager.PageSize)
                {
                    pager.Visible = true;
                    trPagerContainer.Visible = true;
                    pager.TotalRecords = totalRecords;
                    PagerManager.PrepareUserPager(pager);

                }
                else
                {
                    pager.TotalRecords = totalRecords;
                    pager.Visible = false;
                    trPagerContainer.Visible = false;
                }
                lblResult.Visible = false;
            }
            else
            {
                /*
                r.Visible = false;
                pager.Visible = false;
                trPagerContainer.Visible = false;
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = DynamicResource.GetText("AdminText", "ThereIsNoData");
                lblResult.Visible = true;*/
                this.Visible = false;
            }
        }
        //--------------------------------------------------------
        #endregion

        
    }

}