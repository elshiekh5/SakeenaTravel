using System;using DCCMSNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;


public partial class UserControls_Items_AddFile : System.Web.UI.UserControl
{
    public ItemFileTypes FileType
    {
        get
        {
            if (ViewState["FileType"] != null)
                return (ItemFileTypes)ViewState["FileType"];
            else
                return ItemFileTypes.Video;
        }
        set { ViewState["FileType"] = value; }
    }
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            #region ---------------lblFileText---------------
            switch (FileType)
            {
                case ItemFileTypes.Photo:
                    lblFileText.Text = Resources.ItemsFiles.ItemFileType_Photo;
                    break;
                case ItemFileTypes.File:
                    lblFileText.Text = Resources.ItemsFiles.ItemFileType_File;
                    break;
                case ItemFileTypes.Audio:
                    lblFileText.Text = Resources.ItemsFiles.ItemFileType_Audio;
                    break;
                case ItemFileTypes.Video:
                    lblFileText.Text = Resources.ItemsFiles.ItemFileType_Video;
                    break;
                default:
                    lblFileText.Text = Resources.ItemsFiles.ItemFileType_File;
                    break;
            }
            //----------------------------------------
            #endregion

            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {

            int itemID = Convert.ToInt32(Request.QueryString["ID"]);
            ItemsEntity item = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            lblItemTitle.Text = item.Title;
            LoadList();
        }
    }
    #endregion
    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            if (!Page.IsValid)
            {
                return;
            }
            int itemID = Convert.ToInt32(Request.QueryString["ID"]);
            ItemsEntity item = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            ItemsFilesEntity ItemsFiles = new ItemsFilesEntity();
            ItemsFiles.ItemID = itemID;
            //-------------
            ItemsFiles.FileExtension = Path.GetExtension(fuPhoto.FileName);
            //-----------------------------------------------------------------
            ItemsFiles.FileType = FileType;
            //-----------------------------------------------------------------
            ItemsFiles.CategoryID = item.CategoryID;
            ItemsFiles.ModuleTypeID = item.ModuleTypeID;
            ItemsFiles.OwnerName = item.OwnerName;
            ItemsFiles.OwnerID = OwnerID;
            //-----------------------------------------------------------------
            bool status = ItemsFilesFactory.Create(ItemsFiles);
            if (status)
            {
                //Photo-----------------------------
                if (fuPhoto.HasFile)
                {
                    string filesPath = DCSiteUrls.GetPath_ItemsFiles(ItemsFiles.OwnerName, ItemsFiles.ModuleTypeID, ItemsFiles.CategoryID, ItemsFiles.ItemID);

                        fuPhoto.SaveAs(DCServer.MapPath(filesPath + ItemsFiles.Photo));
                }
                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
                LoadList();
                //ClearControls();
            }
            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.SavingDataFaild;
            }
        }
    }
    //-----------------------------------------------
    #endregion

    

    #region --------------LoadList--------------
    //---------------------------------------------------------
    //LoadList
    //---------------------------------------------------------
    protected void LoadList()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            int itemID = Convert.ToInt32(Request.QueryString["ID"]);

            List<ItemsFilesEntity> photosList = ItemsFilesFactory.GetAll(itemID,FileType);
            OurLists.LoadDataList<ItemsFilesEntity>(photosList, dlPhotos, "FileID");
        }
        else
        {
                Response.Redirect("/Admin/");
        }
    }
    //--------------------------------------------------------
    #endregion
    protected void dlPhotos_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        int id = Convert.ToInt32(dlPhotos.DataKeys[e.Item.ItemIndex]);
        bool result = ItemsFilesFactory.Delete(id);
        if (result)
        {
            LoadList();
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
    }
    protected void dlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
        }
    }
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
       
    }
    //--------------------------------------------------------
    #endregion
}
