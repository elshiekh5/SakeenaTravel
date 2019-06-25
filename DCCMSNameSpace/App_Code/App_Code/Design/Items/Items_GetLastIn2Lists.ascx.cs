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

using System.Collections.Generic;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public class Items_GetLastIn2Lists : ReadyUserControls.UserControl
        {
            //--------------------------------------------------
            Repeater rList1;
            Repeater rList2;
            //--------------------------------------------------
            #region --------------RequiredModule--------------
            private SiteModulesMap _RequiredModule = SiteModulesMap.UnSpecified;
            public SiteModulesMap RequiredModule
            {
                get { return _RequiredModule; }
                set { _RequiredModule = value; }
            }
            //------------------------------------------
            #endregion

            #region --------------ModuleTypeID--------------
            public int ModuleTypeID
            {
                get { return (int)RequiredModule; }
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

            #region --------------List1Count--------------
            private int _List1Count = 1;
            public int List1Count
            {
                get { return _List1Count; }
                set { _List1Count = value; }
            }
            //------------------------------------------
            #endregion

            #region --------------ItemsCount--------------
            private int _ItemsCount=1;
            public int ItemsCount
            {
                get { return _ItemsCount; }
                set { _ItemsCount = value; }
            }
            //------------------------------------------
            #endregion

            //--------------------------------------------------
            public ItemsModulesOptions currentModule;
            public DCSiteUrls siteUrls;
            //--------------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //---------------------------------------------------
                currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
                siteUrls = DCSiteUrls.Instance;
                //---------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!IsPostBack)
                { LoadData(); }
            }
            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                rList1 = (Repeater)this.FindControl("rList1");
                rList2 = (Repeater)this.FindControl("rList2");
            }
            //-----------------------------------------------
            #endregion

            #region ---------------LoadData---------------
            //-----------------------------------------------
            //LoadData
            //-----------------------------------------------
            protected void LoadData()
            {
                List<ItemsEntity> itemsList = ItemsFactory.GetLast(ModuleTypeID, ItemsCount, OwnerID);
                List<ItemsEntity> itemsListOne = new List<ItemsEntity>();
                List<ItemsEntity> itemsListTwo = new List<ItemsEntity>();
                if (itemsList != null && itemsList.Count > 0)
                {
                    //---------------------------------------
                    //items List One 
                    //---------------------------------------
                    int availbleList1Count = List1Count;
                    if (availbleList1Count > itemsList.Count)
                        availbleList1Count = itemsList.Count;
                    //---------------------------------------
                    for (int i = 0; i < availbleList1Count; i++)
                    {
                        itemsListOne.Add(itemsList[i]);
                        
                    }
                    //---------------------------------------
                    //rList1
                    //---------------------------------------
                    if (itemsListOne.Count > 0)
                    {
                        rList1.DataSource = itemsListOne;
                        rList1.DataBind();
                        rList1.Visible = true;
                    }
                    else
                    {
                        rList1.Visible = false;
                    }
                    //---------------------------------------
                    //Items List Two
                    //---------------------------------------
                    for (int i = availbleList1Count; i < itemsList.Count; i++)
                    {
                        itemsListTwo.Add(itemsList[0]);
                    }
                    
                    //---------------------------------------
                    //rList2
                    //---------------------------------------
                    if (itemsListTwo.Count > 0)
                    {
                        rList2.DataSource = itemsListTwo;
                        rList2.DataBind();
                        rList2.Visible = true;
                    }
                    else
                    {
                        rList2.Visible = false;
                    }
                    //---------------------------------------
                }
                else
                {
                    this.Visible = false;
                }
            }
            //-----------------------------------------------
            #endregion

            

        }
    }
}