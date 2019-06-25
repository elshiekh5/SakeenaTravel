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

namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class Page_YouTube : ReadyUserControls.UserControl
        {
            #region --------------RequiredPage--------------
            private SitePages _RequiredPage;
            public SitePages RequiredPage
            {
                get { return _RequiredPage; }
                set { _RequiredPage = value; }
            }
            //------------------------------------------
            #endregion
            
            #region --------------PageID--------------
            public int PageID
            {
                get { return (int)RequiredPage; }
            }
            //------------------------------------------
            #endregion

            #region --------------Width--------------
            private int _Width;
            public int Width
            {
                get { return _Width; }
                set { _Width = value; }
            }
            //------------------------------------------
            #endregion

            #region --------------Height--------------
            private int _Height;
            public int Height
            {
                get { return _Height; }
                set { _Height = value; }
            }
            //------------------------------------------
            #endregion

            Literal ltrYouTubeCode;

            protected void Page_Load(object sender, EventArgs e)
            {
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

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                ltrYouTubeCode = (Literal)this.FindControl("ltrYouTubeCode");
            }
            //-----------------------------------------------
            #endregion

            protected void LoadData()
            {
                int itemID = PageID;
                Languages lang = SiteSettings.GetCurrentLanguage();
                ItemsEntity itemsObject = ItemsFactory.GetObject(itemID, lang, UsersTypes.User, SitesHandler.GetOwnerIDAsGuid());
                if (itemsObject!=null && !string.IsNullOrEmpty(itemsObject.YoutubeCode))
                {
                    ltrYouTubeCode.Text = PlayersBuilder.LoadYoutubePlayer(itemsObject.YoutubeCode, Width, Height);
                    //------------------------------------------------------
                }
                else
                {
                    this.Visible = false;
                }
            }


        }
    }
}