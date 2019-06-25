using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DCCMSNameSpace
{
    public class Photos
    {
        public static bool CheckIsImage(HttpPostedFile postedFile)
        {
            if (postedFile.ContentLength > 0)
                return (postedFile.ContentType.IndexOf("image") > -1);
            else
                return false;


        }
        static int thumbWidth = 120;
        static int thumbHeight = 120;
        static int thumbMicroWidth = 30;
        static int thumbMicroHeight = 30;
        static int thumbMiniWidth = 90;
        static int thumbMiniHeight = 90;
        static int thumbBigWidth = 400;
        static int thumbBigHeight = 400;
        public static string ThumbExetnsion = ".jpg";
        //--------------------------------------------------------


        public static string GetPhotoName(string photoExtension, PhotoTypes photos, string photoIdentifre, int id)
        {
            if (photoExtension.Length > 0)
            {
                switch (photos)
                {
                    case PhotoTypes.Original:
                        return photoIdentifre + id + photoExtension;
                    case PhotoTypes.Thumb:
                        return photoIdentifre + id + "-thumb" + Photos.ThumbExetnsion;
                    case PhotoTypes.Big:
                        return photoIdentifre + id + "-Big" + Photos.ThumbExetnsion;
                    default:
                        return "";
                }
            }
            else
            {
                return "";
            }
        }


    }
}