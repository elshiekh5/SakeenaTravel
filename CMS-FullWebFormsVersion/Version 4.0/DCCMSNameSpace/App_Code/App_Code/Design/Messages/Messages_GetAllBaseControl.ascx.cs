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
    public class Messages_GetAllBaseControl : ReadyUserControls.UserControl
    {
        

        #region --------------ModuleTypeID--------------
        //------------------------------------------
        //ModuleTypeID
        //------------------------------------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
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

        #region --------------ToItemID--------------
        private int _ToItemID;
        public int ToItemID
        {
            get { return _ToItemID; }
            set { _ToItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Type--------------
        private int _Type = 0;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        //------------------------------------------
        #endregion
        /*
    #region --------------CategoryID--------------
    private int _CategoryID;
    public int CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }
    //------------------------------------------
    #endregion
    */
        #region --------------TemplateID--------------
        private string _TemplateID = "dlMsgs";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------------------
        MessagesModuleOptions currentModule;
        public DCSiteUrls siteUrls;
        //-----------------------------------------------
        protected int totalRecords = 0;
        //-----------------------------------------------
        MoversFW.OurPager pager;
        Label lblResult;
        HtmlTableRow trPagerContainer;
        HtmlTableRow trSearch;
        TextBox txtSearch;
        ImageButton ibtnSearch;
        //-----------------------------------------------
        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //-------------------------------------------------
            currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            lblResult.Text = "";
            if (!IsPostBack)
            {
                FirstLoad();
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
            trSearch = (HtmlTableRow)this.FindControl("trSearch");
            txtSearch = (TextBox)this.FindControl("txtSearch");
            ibtnSearch = (ImageButton)this.FindControl("ibtnSearch");
            //ibtnSearch.OnClientClick += new ImageClickEventHandler(ibtnSearch_Click);
            trSearch.Visible = currentModule.HasSearech;
        }
        //-----------------------------------------------------------
        #region ---------------FirstLoad---------------
        //-----------------------------------------------
        //FirstLoad
        //-----------------------------------------------
        public void FirstLoad()
        {
            PagerManager.PrepareUserPager(pager);
            pager.Visible = false;
            LoadData();
        }
        //-----------------------------------------------
        #endregion
        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public new void LoadData()
        {
            //---------------------------------------------------------
            int categoryID = 0;
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                categoryID = Convert.ToInt32(Request.QueryString["id"]);
            //---------------------------------------------------------
            if (currentModule.CategoryLevel != 0 && categoryID == 0)
            {
                this.Visible = false;
            }
            else
            {
                //---------------------------------------------------------
                string keywords = "";
                if (trSearch.Visible)
                    keywords = txtSearch.Text;
                //---------------------------------------------------------
                pager.PageSize = currentModule.PageItemCount_UserDefault;
                List<MessagesEntity> msgList;
                //LoadListDesign();
                Languages langID = SiteSettings.GetCurrentLanguage();
                msgList = MessagesFactory.GetAvailable(ModuleTypeID, categoryID, langID, Type, ToItemID, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID, keywords);
                Control c;
                DataList dl;
                Repeater r;
                c = this.FindControl(TemplateID);
                if (c is DataList)
                {
                    dl = (DataList)c;
                    LoadDataList(dl, msgList);
                }
                else
                {
                    r = (Repeater)c;
                    LoadRepeater(r, msgList);
                }
            }
        }
        //--------------------------------------------------------
        #endregion
        public void LoadDataList(DataList dl, List<MessagesEntity> msgList)
        {
            if (msgList != null && msgList.Count > 0)
            {

                dl.DataSource = msgList;
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
            {
                /*
                dl.Visible = false;
                pager.Visible = false;
                trPagerContainer.Visible = false;
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = DynamicResource.GetText("AdminText", "ThereIsNoData");
                lblResult.Visible = true;*/
                this.Visible = false;

            }
        }
        public void LoadRepeater(Repeater r, List<MessagesEntity> msgList)
        {
            if (msgList != null && msgList.Count > 0)
            {
                r.DataSource = msgList;
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
        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.Page.IsValid)
                return;
            pager.CurrentPage = 1;
            LoadData();
        }

        /*
        private void LoadListDesign()
        {
            //templateID
            string templateID = "dlMsgs";
            if (!string.IsNullOrEmpty(TemplateID))
                templateID = TemplateID;
            //----------------------------------
            DataList dl = LoadDataList(templateID);
            //-----------------------------------------
            //Load data list design
            dlMsgs.ItemTemplate = dl.ItemTemplate;
            dlMsgs.AlternatingItemTemplate = dl.AlternatingItemTemplate;
            dlMsgs.HeaderTemplate = dl.HeaderTemplate;
            dlMsgs.FooterTemplate = dl.FooterTemplate;
            dlMsgs.ShowHeader = dl.ShowHeader;
            dlMsgs.ShowFooter = dl.ShowFooter;
            dlMsgs.Width = dl.Width;
            dlMsgs.RepeatColumns = dl.RepeatColumns;
            dlMsgs.DataBind();
            //-----------------------------------------
        
        }
        */
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
        //--------------------------------------------------------------------------------
        public string GetEducationLevelText(object educationLevel)
        {
            string el = educationLevel.ToString();
            if (el != "0")
            {
                return DynamicResource.GetText("Motakhasesen", "EducationLevel_" + el);
            }
            else
            {
                return "";
            }
        }
        //--------------------------------------------------------------------------------
    }

}