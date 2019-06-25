using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Policy;


namespace DCCMSNameSpace
{
    namespace Utilities
    {
        /// <summary>
        /// Summary description for Shared
        /// </summary>
        public class Shared
        {
            public static SqlConnection GetSqlConnection()
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
            }

            public static void SetLanguage(Languages lang)
            {
                string cookie_name = GetApplicationID() + "_lang";
                if (HttpContext.Current.Request.Cookies[cookie_name] != null)
                {
                    HttpContext.Current.Response.Cookies[cookie_name].Value = lang.ToString();
                }
                else
                {
                    HttpCookie cookie = new HttpCookie(cookie_name);
                    cookie.Value = lang.ToString();
                    cookie.Expires = DateTime.Now.AddYears(1);
                    HttpContext.Current.Response.SetCookie(cookie);
                }

                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
            }

            public static String GetApplicationID()
            {
                string applicationIdString = string.Empty;
                if (HttpRuntime.Cache["applicationIdString"] == null)
                {
                    using (SqlConnection conn = GetSqlConnection())
                    {
                        conn.Open();
                        const String selectQuery = "SELECT ApplicationId FROM aspnet_Applications WHERE ApplicationName=@p1";
                        using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                        {
                            SqlParameter p1 = cmd.Parameters.Add("@p1", System.Data.SqlDbType.NVarChar);
                            p1.Value = Membership.ApplicationName;
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                                applicationIdString = dr[0].ToString();
                        }
                        if (conn != null)
                            conn.Close();
                    }
                    HttpRuntime.Cache.Insert("applicationIdString", applicationIdString);
                }
                else
                {
                    applicationIdString = (string)HttpRuntime.Cache["applicationIdString"];
                }
                return applicationIdString;
            }

            public static Languages GetCurrentLanguage()
            {
                try
                {
                    Languages res = (Languages)
                    Enum.Parse(typeof(Languages),
                        System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName,
                        true);
                    return res;
                }
                catch { return Languages.Ar; }
            }

        }
    }
}