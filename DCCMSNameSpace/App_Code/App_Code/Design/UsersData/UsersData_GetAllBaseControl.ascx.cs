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

using System.Drawing;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        /// <summary>
        /// Summary description for ItemsGetAllBaseControl
        /// </summary>
        public class UsersData_GetAllBaseControl : ReadyUserControls.UserControl
        {
            #region --------------UserRole--------------
            private string _UserRole = "";
            public string UserRole
            {
                get { return _UserRole; }
                set { _UserRole = value; }
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

            //-------------------------------------------------------
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
            #region --------------TemplateID--------------
            private string _TemplateID = "dlUsers";
            public string TemplateID
            {
                get { return _TemplateID; }
                set { _TemplateID = value; }
            }
            //------------------------------------------
            #endregion
            //-------------------------------------------------------
            UsersDataGlobalOptions currentModule;
            public DCSiteUrls siteUrls;
            //-------------------------------------------------------
            public int totalRecords = 0;
            //-------------------------------------------------------
            MoversFW.OurPager pager;
            Label lblResult;
            HtmlTableRow trPagerContainer;
            HtmlTableRow trSearch;
            TextBox txtSearch;
            ImageButton ibtnSearch;
            //-------------------------------------------------------
            #region ---------------Page_Load---------------
            //-----------------------------------------------
            //Page_Load
            //-----------------------------------------------
            private void Page_Load(object sender, System.EventArgs e)
            {
                currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
                siteUrls = DCSiteUrls.Instance;
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                lblResult.Text = "";
                if (!IsPostBack)
                {
                    PagerManager.PrepareUserPager(pager);
                    pager.Visible = false;
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
            private void LoadData()
            {
                pager.PageSize = currentModule.PageItemCount_UserDefault;
                //--------------------------------------------------------------------
                Languages langID = SiteSettings.GetCurrentLanguage();
                //--------------------------------------------------------------------
                int categoryID = -1;
                if (currentModule.CategoryLevel != 0)
                    categoryID = Convert.ToInt32(Request.QueryString["id"]);
                //--------------------------------------------------------------------
                string keywords = "";
                if (trSearch.Visible)
                    keywords = txtSearch.Text;
                //--------------------------------------------------------------------
                List<UsersDataEntity> usersDataList = UsersDataFactory.GetAll(ModuleTypeID, categoryID, langID, "", UserRole, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID, true, keywords);

                Control c;
                DataList dl;
                Repeater r;
                c = this.FindControl(TemplateID);
                if (c is DataList)
                {
                    dl = (DataList)c;
                    LoadDataList(dl, usersDataList);
                }
                else
                {
                    r = (Repeater)c;
                    LoadRepeater(r, usersDataList);
                }
            }
            //--------------------------------------------------------
            #endregion

            public void LoadDataList(DataList dl, List<UsersDataEntity> usersDataList)
            {
                if (usersDataList != null && usersDataList.Count > 0)
                {

                    dl.DataSource = usersDataList;
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
            public void LoadRepeater(Repeater r, List<UsersDataEntity> usersDataList)
            {
                if (usersDataList != null && usersDataList.Count > 0)
                {
                    r.DataSource = usersDataList;
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

            public bool CheckUrl(object _url)
            {
                string url = _url.ToString();
                return !string.IsNullOrEmpty(url);
            }
        }
    }
}