using System;


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
    public class Items_GetAllBaseControl : ReadyUserControls.UserControl
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

        #region --------------TemplateID--------------
        private string _TemplateID = "dlItems";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
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

        #region --------------ListDir--------------
        private string _ListDir = "ltr";
        public string ListDir
        {
            get { return _ListDir; }
            set { _ListDir = value; }
        }
        //------------------------------------------
        #endregion

        public ItemsModulesOptions currentModule;
        public DCSiteUrls siteUrls;
        public int totalRecords = 0;


        MoversFW.OurPager pager;
        Label lblResult;
        HtmlTableRow trPagerContainer;
        HtmlTableRow trSearch;
        TextBox txtSearch;
        ImageButton ibtnSearch;
        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //-------------------------------------------------
            currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            lblResult.Text = "";
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
            trSearch = (HtmlTableRow)this.FindControl("trSearch");
            txtSearch = (TextBox)this.FindControl("txtSearch");
            ibtnSearch = (ImageButton)this.FindControl("ibtnSearch");
            //ibtnSearch.OnClientClick += new ImageClickEventHandler(ibtnSearch_Click);
            trSearch.Visible = currentModule.HasSearech;
        }
        //-----------------------------------------------------------

        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public void LoadData()
        {
            //---------------------------------------------------------
            int categoryID = 0;
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                categoryID = Convert.ToInt32(Request.QueryString["id"]);
            //---------------------------------------------------------
            string keywords = "";
            if (trSearch.Visible)
                keywords = txtSearch.Text;
            //---------------------------------------------------------
            pager.PageSize = currentModule.PageItemCount_UserDefault;
            List<ItemsEntity> itemsList = ItemsFactory.GetAll(ModuleTypeID, categoryID, true, pager.CurrentPage, pager.PageSize, out totalRecords, keywords, OwnerID);
           
            Control c;
            DataList dl;
            Repeater r;
            c = this.FindControl(TemplateID);
            if (c is DataList)
            {
                dl = (DataList)c;
                LoadDataList(dl, itemsList);
            }
            else
            {
                r = (Repeater)c;
                LoadRepeater(r, itemsList);
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
        public void LoadDataList(DataList dl, List<ItemsEntity> itemsList)
        {
            if (itemsList != null && itemsList.Count > 0)
            {
                dl.DataSource = itemsList;
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
               /* dl.Visible = false;
                pager.Visible = false;
                trPagerContainer.Visible = false;
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = DynamicResource.GetText("AdminText", "ThereIsNoData");
                lblResult.Visible = true;*/
                this.Visible = false;
            }
        }
        public void LoadRepeater(Repeater r, List<ItemsEntity> itemsList)
        {
            if (itemsList != null && itemsList.Count > 0)
            {
                r.DataSource = itemsList;
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
        public string GetAuther(object Auther)
        {
            if (Auther.ToString().Length > 0)
                return "<br/><font style='color:black;font-weight:normal;'><b> "+DynamicResource.GetText(currentModule,"AuthorName")+" : </b></font><b>" + Auther.ToString() + "</b>";
            else
                return "";
        }
        public bool CheckUrl(object _url)
        {
            string url = _url.ToString();
            return !string.IsNullOrEmpty(url);
        }
        public bool CheckFile(object VideoExtension)
        {
            if (!string.IsNullOrEmpty((string)VideoExtension))
                return true;
            else
                return false;
        }
        public bool CheckYouTube(object VideoExtension, object YouTubeCode)
        {
            if (string.IsNullOrEmpty((string)VideoExtension) && !string.IsNullOrEmpty((string)YouTubeCode))
                return true;
            else
                return false;
        }
        public bool CheckSwf(object Extension, object RequiredExtension)
        {
            string exten = (string)Extension;
            string rExten = (string)RequiredExtension;
            if (exten.ToLower() == rExten.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetPureExtension(object Extension)
        {
            if (!string.IsNullOrEmpty(Extension.ToString()))
                return Extension.ToString().Remove(0, 1);
            else
                return "---";
        }

        

    }
}