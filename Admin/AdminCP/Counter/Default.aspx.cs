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

public partial class Admin_counter_Default : AdminMasterPage
{
    int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Page.Title = Resources.VisitorsCounter.VisitorsCounterModuleTitle;
            LoadData();
        }
    }
    private void LoadData()
    {
        DataTable dt = VisitorCouter.GetCountryVisitors();
        if (dt.Rows.Count > 0)
        {
            dgCountryVisitors.AllowPaging = false;
            dgCountryVisitors.AutoGenerateColumns = false;
            dgCountryVisitors.GridLines = GridLines.None;
            dgCountryVisitors.Width = Unit.Percentage(100);
            dgCountryVisitors.PageSize = 5;
            dgCountryVisitors.PagerStyle.Visible = false;
            dgCountryVisitors.DataSource = dt;
            dgCountryVisitors.DataBind();
        }

        //lblCount.ForeColor = Color.Maroon;
        lblCount.Text = string.Format(Resources.VisitorsCounter.VisitorsCountText, counter);
        //if (Resources.Globals.lang.ToLower() == "ar")
        //{
           
        //}
        //else if (Resources.Globals.lang.ToLower() == "fr")
        //{
        //    lblCount.Text += "Total des visiteurs: " + counter.ToString();
        //}
        //else
        //{
        //    lblCount.Text += "Total visitors: " + counter.ToString();
        //}
    }
    protected void dgCountryVisitors_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.ItemIndex > 4)
            {
                e.Item.Visible = false;
                return;
            }
            DataRowView drv = (DataRowView)e.Item.DataItem;
            counter += int.Parse(drv["vc_count"].ToString());
        }
    }
    protected void btnSetZero_Click(object sender, EventArgs e)
    {
        VisitorCouter.SetZero();
        LoadData();
    }
}

