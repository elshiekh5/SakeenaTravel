using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for PlayersBuilder
    /// </summary>
    public class PlayersBuilder
    {

        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildFlashPlayer(string swfPath, int originalWidth, int originalHeight, int targetWidth, int targetHeight, string bgcolorNumber)
        {
            GetMaintainedRatio(originalWidth, originalHeight, ref targetWidth, ref targetHeight);
            return BuildFlashPlayer(swfPath, targetWidth, targetHeight, bgcolorNumber);

        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildFlashPlayerCode(string swfPath, int width, int height, string bgcolorNumber)
        {
            swfPath = SitesHandler.GetSiteDomain() + swfPath;
            return BuildFlashPlayer(swfPath, width, height, bgcolorNumber);
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildFlashPlayer(string swfPath, int width, int height, string bgcolorNumber)
        {
            string player = "";
            player = "<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\"";
            player += "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0\" ";
            player += "width=\"" + width + "\" height=\"" + height + "\" id=\"swfPlayer\" align=\"middle\">";
            player += "<param name=\"allowScriptAccess\" value=\"sameDomain\" />";
            player += "<param name=\"allowFullScreen\" value=\"false\" />";
            player += "<param name=\"movie\" value=\"" + swfPath + "\" />";
            player += "<param name=\"quality\" value=\"high\" />";
            player += "<param name=\"wmode\" value=\"transparent\" />";
            player += "<param name=\"bgcolor\" value=\"#" + bgcolorNumber + "\" />";
            player += "<embed src=\"" + swfPath + "\"";
            player += "quality=\"high\" wmode=\"transparent\" bgcolor=\"#" + bgcolorNumber + "\" width=\"" + width + "\" height=\"" + height + "\"";
            player += "name=\"~Header_ar\" align=\"middle\"";
            player += "allowScriptAccess=\"sameDomain\" allowFullScreen=\"false\"";
            player += "type=\"application/x-shockwave-flash\"";
            player += "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />";
            player += "</object>";


            return player;

        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildFlvPlayer(string videoPath, string previewImg, string width, string height, string bgcolorNumber, string frontcolorNumber)
        {
            string player = "";
            Guid id = Guid.NewGuid();

            player = "<script type='text/javascript' src='/Content/Components/FlvPlyer/swfobject.js'></script>";
            player += "<div id='player'></div>";
            player += "<span id='" + id + "'><script type='text/javascript'>";
            player += "var so = new SWFObject('/Content/Components/FlvPlyer/mediaplayer.swf','mpl','" + width + "','" + height + "','8');";
            player += "so.addParam('allowscriptaccess','always');";
            player += "so.addParam('wmode','transparent');";
            player += "so.addParam('allowfullscreen','true');";
            player += "so.addVariable('wmode','transparent');";
            player += "so.addVariable('width','" + width + "');";
            player += "so.addVariable('height','" + height + "');";
            player += "so.addVariable('file','" + videoPath + "');";
            player += "so.addVariable('image','" + previewImg + "');";
            player += "so.addVariable('backcolor','0x" + bgcolorNumber + "');";
            player += "so.addVariable('frontcolor','0x" + frontcolorNumber + "');";
            player += "so.addVariable('logo','');";
            player += "so.addVariable('link','');";
            player += "so.addVariable('linktarget','_blank');";
            player += "so.addVariable('showstop','true');";
            player += "so.write('player');";
            player += "</script></span>";

            return player;

        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildSoundPlayer(string audioPath, string width)
        {
            string player = "";
            Guid id = Guid.NewGuid();
            string bgcolorNumber = "D5D7D8"; string frontcolorNumber = "000000";
            player = "<script type='text/javascript' src='/Content/Components/FlvPlyer/swfobject.js'></script>";
            player += "<div id='player'></div>";
            player += "<span id='" + id + "'><script type='text/javascript'>";
            player += "var so = new SWFObject('/Content/Components/FlvPlyer/mediaplayer.swf','mpl','" + width + "','20','8');";
            player += "so.addParam('allowscriptaccess','always');";
            player += "so.addParam('wmode','transparent');";
            player += "so.addParam('allowfullscreen','true');";
            player += "so.addVariable('wmode','transparent');";
            player += "so.addVariable('width','" + width + "');";
            player += "so.addVariable('height','20');";
            player += "so.addVariable('file','" + audioPath + "');";
            //player += "so.addVariable('image','" + previewImg + "');";
            player += "so.addVariable('backcolor','0x" + bgcolorNumber + "');";
            player += "so.addVariable('frontcolor','0x" + frontcolorNumber + "');";
            player += "so.addVariable('logo','');";
            player += "so.addVariable('link','');";
            player += "so.addVariable('linktarget','_blank');";
            player += "so.addVariable('showstop','true');";
            player += "so.write('player');";
            player += "</script></span>";

            return player;

        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildMediaPlayer(string virtualPath, string width, string height)
        {
            Guid id = Guid.NewGuid();
            string player = "";
            player = "<object id='MediaPlayer" + id + "' classid='CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6' standby='Loading MicroSoft Windows Media Player components...' type='application/x-oleobject' width='" + width + "' height='" + height + "'><param name='url' value='" + virtualPath + "'><param name='animationatStart' value='true'><param name='transparentatStart' value='true'><param name='autoStart' value='false'><param name='showControls' value='true'><param name='ShowDisplay' value='true'></object>";
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildRealPlayerAudio(string virtualPath, string width, string height)
        {
            Guid id = Guid.NewGuid();

            string player = "";
            player = "<object classid='CLSID:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA'  width='" + width + "' height='" + height + "' id='RealPlayer" + id + "'><param name='controls' value='ControlPanel,StatusBar'><param name='autostart' value='false'><param name='SRC' value='" + virtualPath + "'><param name='console' value='_master'><param name='center' value='true'><embed type='audio/x-pn-realaudio-plugin' src='" + virtualPath + "' height='" + height + "'width='" + width + "' nojava='true' controls='ControlPanel,StatusBar' console='_master'center='true' pluginspage='http://www.real.com/'></embed></object>";
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string BuildRealPlayerVideo(string virtualPath, string width, string height)
        {
            Guid id = Guid.NewGuid();

            string player = "";
            player = "<object classid='CLSID:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA'  width='" + width + "' height='" + height + "' id='RealPlayer" + id + "'><param name='controls' value='ControlPanel,StatusBar'><param name='autostart' value='false'><param name='SRC' value='" + virtualPath + "'><param name='console' value='_master'><param name='center' value='true'><embed type='audio/x-pn-realaudio-plugin' src='" + virtualPath + "' height='" + height + "'width='" + width + "' nojava='true' controls='ControlPanel,StatusBar' console='_master'center='true' pluginspage='http://www.real.com/'></embed></object>";
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string LoadVedioPlayer(string virtualPath, string preview, string ext, string width, string height)
        {
            string player = "";
            ext = ext.ToLower();
            string PhysicalPath = DCServer.MapPath(virtualPath);
            if (File.Exists(PhysicalPath))
            {
                if (ext.Contains("wmv") || ext.Contains("avi") || ext.Contains("mpg") || ext.Contains("mpeg"))
                {
                    player = BuildMediaPlayer(virtualPath, width, height);
                }
                else if (ext.Contains("ram") || ext.Contains("rm") || ext.Contains("ra") || ext.Contains("wma"))
                {
                    player = BuildRealPlayerVideo(virtualPath, width, height);
                }
                else if (ext.Contains("flv"))
                {
                    player = BuildFlvPlayer(virtualPath, preview, width, height, "D5D7D8", "000000");
                }
                else
                {
                    player = "عفوا لا يمكن تشغيل هذا الملف";
                }
            }
            else
            {
                player = "عفوا الملف غير موجود";
            }
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string LoadAudioPlayer(string virtualPath, string ext)
        {

            string player = "";
            ext = ext.ToLower();
            string PhysicalPath = DCServer.MapPath(virtualPath);
            if (File.Exists(PhysicalPath))
            {
                if (ext.Contains("mp3"))
                {
                    player = BuildSoundPlayer(virtualPath, "100%");
                }
                else if (ext.Contains("ram") || ext.Contains("rm") || ext.Contains("ra") || ext.Contains("mp3") || ext.Contains("wma"))
                {
                    player = BuildRealPlayerAudio(virtualPath, "100%", "65");
                }
                else
                {
                    player = "عفوا لا يمكن تشغيل هذا الملف";
                }
            }
            else
            {
                player = "عفوا الملف غير موجود";
            }
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static void GetMaintainedRatio(int originalWidth, int originalHeight, ref int targetWidth, ref int targetHeight)
        {
            // See if we want to maintain the image ratio
            if (true)
            {
                if (originalWidth <= targetWidth)
                {
                    targetWidth = originalWidth;
                    targetHeight = originalHeight;
                    return;
                }
                //Check to make sure we have a height and width on the attachemnet (if not check the data)
                if (originalHeight == 0 || originalWidth == 0)
                    targetWidth = targetHeight = 0;

                double heightRatio = (double)originalHeight / originalWidth;
                double widthRatio = (double)originalWidth / originalHeight;

                int desiredHeight = targetHeight;
                int desiredWidth = targetWidth;


                targetHeight = desiredHeight;
                if (widthRatio > 0)
                    targetWidth = Convert.ToInt32(targetHeight * widthRatio);

                if (targetWidth > desiredWidth)
                {
                    targetWidth = desiredWidth;
                    targetHeight = Convert.ToInt32(targetWidth * heightRatio);
                }
            }

            // In some instances, we might not want to scale it larger
            if (targetHeight > originalHeight || targetWidth > originalWidth)
            {
                // TODO: Not perfect
                targetHeight = originalHeight;
                targetWidth = originalWidth;
                return;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string LoadYoutubePlayer(string code)
        {
            int InnerWidth = SiteDesign.GetInnreWidth();
            return LoadYoutubePlayer(code, InnerWidth, 350);
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public static string LoadYoutubePlayer(string code, int width, int height)
        {
            string player = "";
            player += "<object width=\"" + width + "\" height=\"" + height + "\" >";
            player += "<param name=\"movie\" value=\"http://www.youtube.com/v/" + code + "?fs=1\"</param>";
            player += "<param name=\"allowFullScreen\" value=\"true\"></param>";
            player += "<param name=\"wmode\" value=\"transparent\" />";
            player += "<param name=\"allowScriptAccess\" value=\"always\"></param>";
            player += "<embed src=\"http://www.youtube.com/v/" + code + "?fs=1\"";
            player += "type=\"application/x-shockwave-flash\"";
            player += "allowfullscreen=\"true\"  wmode=\"transparent\" ";
            player += "allowscriptaccess=\"always\"";
            player += "width=\"" + width + "\" height=\"" + height + "\">";
            player += "</embed>";
            player += "</object>";
            // string player = "<iframe title=\"YouTube video player\" class=\"youtube-player\" type=\"text/html\" width=\"480\" height=\"390\" src=\"http://www.youtube.com/embed/" + code + "\" frameborder=\"0\" allowFullScreen></iframe>";
            return player;
        }
        //---------------------------------------------------------------------------------------------------------------------------------
    }
}