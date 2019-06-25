using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DCRoles
    /// </summary>
    public class DCRoles
    {
        public static string SiteMasterAdmin = "MasterAdmin";
        public static string SiteOverallAdminsRoles = "overalladmins";
        public static string SiteSubAdminsRoles = "administrators";
        public static string SiteUsersRoles = "SiteUsers";
        public static string ConsultantsRoles = "Consultants";
        public static string SubAdminsRole = "SubAdmins";

        //--------------------------------------------------
        public static bool CheckIsAdmin()
        {
            return (Roles.IsUserInRole(DCRoles.SiteMasterAdmin) || Roles.IsUserInRole(DCRoles.SiteOverallAdminsRoles) || Roles.IsUserInRole(DCRoles.SiteSubAdminsRoles));
        }
        //--------------------------------------------------
        public static bool CheckIsSubAdmin()
        {
            return (Roles.IsUserInRole(DCRoles.SubAdminsRole));
        }
        //--------------------------------------------------
    }

}
