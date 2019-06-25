using DCCMSNameSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AppService
{
    public class SingleItemUserConrol : CustomUserControl
    {
        public int ItemID { get; set; }
        public FrontItemsModel RequiredItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Prepare();
            LoadItem();
        }
        //-----------------------------------------------------------
        public void LoadItem()
        {
            //------------------------------------------------------------------------
            Languages langID = SiteSettings.GetCurrentLanguage();
            RequiredItem = FrontItemsController.GetItemObject(ItemID, langID);
            if (RequiredItem != null && RequiredItem.IsAvailable)
            {
                this.Visible = true;
            }
            else
            {

                this.Visible = false;
            }
            //----------------------------------------------
        }
    }


}