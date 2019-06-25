using System;
using DCCMSNameSpace;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Controls_Website_SiteStatistics_SiteStatistics : System.Web.UI.UserControl
{
    //----------------------------------------------------------
    List<ItemsModulesOptions> ItemsModulesList = null;
    List<UsersDataGlobalOptions> UsersDataModulesList = null;
    List<MessagesModuleOptions> MessagesList = null;
    //----------------------------------------------------------
    List<SiteStatisticsEntity> StatsItemsModulesList = null;
    List<SiteStatisticsEntity> StatsUsersDataModulesList = null;
    List<SiteStatisticsEntity> StatsMessagesList = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //----------------------------------------------------------
            ItemsModulesList = new List<ItemsModulesOptions>();
            UsersDataModulesList = new List<UsersDataGlobalOptions>();
            MessagesList = new List<MessagesModuleOptions>();
            //----------------------------------------------------------
            StatsItemsModulesList = new List<SiteStatisticsEntity>();
            StatsUsersDataModulesList = new List<SiteStatisticsEntity>();
            StatsMessagesList = new List<SiteStatisticsEntity>();
            //----------------------------------------------------------
            LoadData();
            //----------------------------------------------------------
        }
    }
    protected void LoadData()
    {
        List<SiteStatisticsEntity> statsList = SiteStatisticsFactory.GetAll(-1, SitesHandler.GetOwnerIDAsGuid());
        if (statsList != null && statsList.Count > 0)
        {
            foreach (SiteStatisticsEntity stats in statsList)
            {
                if (stats.ModuleTypeID < 500)
                {
                    StatsItemsModulesList.Add(stats);
                }
                else if (stats.ModuleTypeID < 600)
                {
                    StatsMessagesList.Add(stats);
                }
                else if (stats.ModuleTypeID < 700)
                {
                    StatsUsersDataModulesList.Add(stats);
                }

            }
        }
    }
}