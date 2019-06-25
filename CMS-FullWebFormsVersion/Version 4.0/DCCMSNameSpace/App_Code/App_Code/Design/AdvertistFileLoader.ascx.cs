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
        public partial class AdvertistFileLoader : ReadyUserControls.UserControl
        {
            #region --------------PlaceID--------------
            private int _PlaceID;
            public int PlaceID
            {
                get { return _PlaceID; }
                set { _PlaceID = value; }
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

            Literal ltrAd;
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!IsPostBack)
                    LoadData();
            }
            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                ltrAd = (Literal)this.FindControl("ltrAd");
            }
            //-----------------------------------------------
            #endregion
            public void LoadData()
            {

                //-------------------------------------------------
                string advText = AdvertismentsFactory.GetAdForShowFile(PlaceID, OwnerID);
                if (!string.IsNullOrEmpty(advText))
                    ltrAd.Text = advText;
                else
                    this.Visible = false;
                //-------------------------------------------------
            }

            

        }
    }
}