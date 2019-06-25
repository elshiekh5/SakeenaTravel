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
        public partial class VisitorsTotalCount : ReadyUserControls.UserControl
        {
            int counter = 0;
            //Detrmine number of top visitors to show
            private int _ViewedVisitors = 0;

            Label lblCount;
            public int ViewedVisitors
            {
                get { return _ViewedVisitors; }
                set { _ViewedVisitors = value; }
            }
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
                lblCount = (Label)this.FindControl("lblCount");
            }
            //-----------------------------------------------
            #endregion
            private void LoadData()
            {
                DataTable dt = VisitorCouter.GetCountryVisitors();
                foreach (DataRow dr in dt.Rows)
                {
                    counter += int.Parse(dr["vc_count"].ToString());
                }
                //lblCount.ForeColor = Color.Maroon;
                lblCount.Text = counter.ToString();
            }

            


        }
    }
}