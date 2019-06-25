using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using System.Text;
public partial class Pages_Website_Items_ItemDownload : System.Web.UI.Page
{
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    
    #region --------------LoadData--------------
    //---------------------------------------------------------
    //Page_Load
    //---------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        //--------------------
        downloading();
        //--------------------
    }
    //--------------------------------------------------------
    #endregion

    public void downloading()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            int itemID = Convert.ToInt32(Request.QueryString["id"]);
            int type = Convert.ToInt32(Request.QueryString["type"]);
            ItemsEntity item = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            if (item != null)
            {
                string folder = DCSiteUrls.GetPath_ItemsFiles(item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID);
                string filePath = "";

                if (type == 1 &&  item.FileExtension.Length > 0)//file
                {
                    filePath = folder + item.File;
                    //Response.Write(item.Title.Replace(" ", "_"));
                    //Response.End();
                    Download(filePath, item.Title.Replace(" ", "_"), item.FileExtension);

                }
                else if (type == 2 && item.VideoExtension.Length > 0)//Video
                {
                    filePath = folder + item.Video;
                    //Response.Write(item.Title.Replace(" ", "_"));
                    //Response.End();
                    Download(filePath, item.Title.Replace(" ", "_"), item.VideoExtension);
                }
                else if (type == 3  && item.AudioExtension.Length > 0)//Audio
                {
                    filePath = folder + item.Audio;
                    //Response.Write(item.Title.Replace(" ", "_"));
                    //Response.End();
                    Download(filePath, item.Title.Replace(" ","_"), item.AudioExtension);
                    
                }
                //--------------------------------------------------------
              
                else
                {
                    Response.Write("<script>alert('" + Resources.User.DownLoad_FileNotFound + "');history.go(-1);</script>");
                }
                //--------------------------------------------------------
            }
            else
            {
                Response.Write("<script>alert('" + Resources.User.DownLoad_FileNotFound + "');history.go(-1);</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('" + Resources.User.DownLoad_FileNotFound + "');history.go(-1);</script>");
        }


    }
    protected void Download(string path, string title, string extension)
    {
        path = DCServer.MapPath(path);
        if (File.Exists(path))
        {
            title = title.Replace(' ', '_');
            //-----------------------------------------------------------------------------------------------------------
            Response.HeaderEncoding = Encoding.GetEncoding(1256);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-disposition", "attachment; filename=" + title + extension);
            Response.TransmitFile(path);
            //-----------------------------------------------------------------------------------------------------------
        }
        else
        {
            Response.Write("<script>alert('" + Resources.User.DownLoad_FileNotFound + "');history.go(-1);</script>");
        }
    }
}
