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
    public class Messages_GetLastControl : ReadyUserControls.UserControl
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
        
        #region --------------Count--------------
    private int _Count;
    public int Count
    {
        get { return _Count; }
        set { _Count = value; }
    }
    //------------------------------------------
    #endregion
        
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

            if (!IsPostBack)
            {
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion
        //-----------------------------------------------------------
        protected void CatchControls()
        {
        }
        //-----------------------------------------------------------
        
        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public new void LoadData()
        {
                List<MessagesEntity> msgList = MessagesFactory.GetLast(ModuleTypeID,Count,OwnerID);
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
        //--------------------------------------------------------
        #endregion
        public void LoadDataList(DataList dl, List<MessagesEntity> msgList)
        {
            if (msgList != null && msgList.Count > 0)
            {

                dl.DataSource = msgList;
                dl.DataBind();
                dl.Visible = true;
            }
            else
            {
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
            }
            else
            {
                this.Visible = false;

            }
        }

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