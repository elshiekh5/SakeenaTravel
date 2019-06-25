using System;using DCCMSNameSpace;
using System.Collections;
using System.Data;
using System.Web;
using DCCMSNameSpace.net.digitalchains.cntry;
//using net.digitalchains.cntry;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of Transfere.
    /// </summary>
    public class VisitorCouter
    {
        /// <summary>
        /// vc_Create
        /// </summary>
        /// <param name="ctry"></param>
        /// <returns></returns>
        public static bool vc_Create(string ctry)
        {
            return StatisticsSqlDataPrvider.Instance.vc_Create(ctry);
        }

        public static bool vc_Delete(string ctry)
        {
            return StatisticsSqlDataPrvider.Instance.vc_Delete(ctry);
        }
        /// <summary>
        /// GetCountryVisitors
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCountryVisitors()
        {
            return StatisticsSqlDataPrvider.Instance.GetCountryVisitors();
        }

        public static void IncreaseCounter()
        {
            try
            {
                string ip = IpAddress();
                if (IsValidIP(ip))
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies["Shakaeak_svc"];
                    if (cookie == null)
                    {
                        IpCountryService ips = new IpCountryService();

                        IpEntity ipe = ips.GetIpInfo(ip, GetKey());
                        if (ipe != null)
                        {
                            vc_Create(ipe.CTRY);
                            cookie = new HttpCookie("Shakaeak_svc");
                            cookie.Expires = DateTime.Now.AddHours(1);

                            HttpContext.Current.Response.Cookies.Add(cookie);
                        }

                    }
                }
            }
            catch
            {


            }
        }

        public static void DecreaseCounter()
        {
            string ip = IpAddress();
            if (IsValidIP(ip))
            {
                //HttpCookie cookie = HttpContext.Current.Request.Cookies["Tawfik_svc"];
                //if (cookie == null)
                //{
                IpCountryService ips = new IpCountryService();

                IpEntity ipe = ips.GetIpInfo(ip, GetKey());
                if (ipe != null)
                {
                    vc_Delete(ipe.CTRY);
                    //cookie = new HttpCookie("Tawfik_svc");
                    //cookie.Expires = DateTime.Now.AddHours(1);

                    //HttpContext.Current.Response.Cookies.Add(cookie);
                }

                //}
            }
        }
        public static bool IsValidIP(string addr)
        {
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex check = new Regex(pattern);
            bool valid = false;
            if (addr == "")
                valid = false;
            else
                valid = check.IsMatch(addr, 0);
            return valid;
        }

        private static string GetKey()
        {
            return MD5Hashing.GetMd5Sum(SiteSettings.Site_IpWebServicePassword);
        }

        public static int GetVisitorsCount()
        {
            return StatisticsSqlDataPrvider.Instance.GetVisitorsCount();
        }

        /// <summary>
        /// FlagPath
        /// </summary>
        /// <param name="ctry"></param>
        /// <returns></returns>
        public static string GetCountryFlagPath(object ctry)
        {
            string filename = "/Content/images/flags/" + ctry.ToString().Trim() + ".png";
            if (File.Exists(DCServer.MapPath(filename)))
                return filename;

            else
                return null;
        }

        public static string IpAddress()
        {
            string strIp;

            strIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIp == null)
            {
                strIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIp;//"8.4.9.193";
        }
        public static void SetZero()
        {
            StatisticsSqlDataPrvider.Instance.SetZero();
        }
        //---------------------------------------------------
        public static DataTable GetTopCountryVisitors(int count)
        {
            return StatisticsSqlDataPrvider.Instance.GetTopCountryVisitors(count);
        }

    }
}