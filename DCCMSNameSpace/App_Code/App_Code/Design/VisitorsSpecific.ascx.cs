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
        public partial class VisitorsSpecificCounts : ReadyUserControls.UserControl
        {
            Repeater dlCountries;
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!Page.IsPostBack)
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
                dlCountries = (Repeater)this.FindControl("dlCountries");
            }
            //-----------------------------------------------
            #endregion

            private void LoadData()
            {
                DataTable dtCountries = VisitorCouter.GetTopCountryVisitors(4);
                dlCountries.DataSource = dtCountries;
                dlCountries.DataBind();
                /*  while (dt.Rows.Count > 4)
              {
                  dt.Rows.RemoveAt(4);
	         
              }*/
            }


        }
    }
}