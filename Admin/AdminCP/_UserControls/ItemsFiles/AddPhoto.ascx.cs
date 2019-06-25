using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
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


public partial class UserControls_Items_AddPhoto : System.Web.UI.UserControl
{
    public ItemFileTypes FileType
    {
        get
        {
            if (ViewState["FileType"] != null)
                return (ItemFileTypes)ViewState["FileType"];
            else
                return ItemFileTypes.Photo;
        }
        set { ViewState["FileType"] = value; }
    }
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    public ItemsModulesOptions currentModule;
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
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
            //if (currentModule.ModuleTypeID != 101)
            { TrTitle.Visible = false; }
        }
    }
    //-----------------------------------------------
    #endregion
    #region --------------Load_ddlItems()--------------
    //---------------------------------------------------------
    //Load_ddlItems
    //---------------------------------------------------------
    protected void Load_ddlItems()
    {
        List<ItemsEntity> ItemsList = ItemsFactory.GetAllForAdmin(ModuleTypeID, OwnerID);
        if (ItemsList != null && ItemsList.Count > 0)
        {
            ddlItems.DataSource = ItemsList;
            ddlItems.DataTextField = "Title";
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
            ddlItems.Enabled = true;
        }
        else
        {
            ddlItems.Items.Clear();
            ddlItems.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlItems.Enabled = false;
        }
    }
    //--------------------------------------------------------
    #endregion
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        Load_ddlItems();
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
        {

            int itemID = Convert.ToInt32(Request.QueryString["id"]);
            ddlItems.SelectedValue = itemID.ToString();
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
       
            if (!Page.IsValid)
            {
                return;
            }
            int itemID = Convert.ToInt32(ddlItems.SelectedValue);

            ItemsEntity item = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            ItemsFilesEntity itemFile = new ItemsFilesEntity();
            itemFile.ItemID = itemID;
            itemFile.Title = txtTitle.Text;
            itemFile.ModuleTypeID = ModuleTypeID;
            //-----------------------------------------------------------------
            itemFile.CategoryID = item.CategoryID;
            itemFile.ModuleTypeID = item.ModuleTypeID;
            itemFile.OwnerName = item.OwnerName;
            itemFile.OwnerID = OwnerID;
            //-----------------------------------------------------------------
            if (fuPhoto.HasFile)
            {
                if (FileType == ItemFileTypes.Photo)
                {
                    if (!MoversFW.Photos.CheckIsImage(fuPhoto.PostedFile))
                    {
                        lblResult.CssClass = "lblResult_Faild";
                        lblResult.Text = Resources.AdminText.InvalidPhotoFile;
                        return;
                    }
                }
            }
            itemFile.FileExtension = Path.GetExtension(fuPhoto.FileName);
            //-----------------------------------------------------------------
            itemFile.FileType = FileType;
            bool status = ItemsFilesFactory.Create(itemFile);
            if (status)
            {
                //Photo-----------------------------
                if (fuPhoto.HasFile)
                {
                    string photosPath = DCSiteUrls.GetPath_ItemsFiles(itemFile.OwnerName, itemFile.ModuleTypeID, itemFile.CategoryID, itemFile.ItemID);
                    if ( FileType == ItemFileTypes.Photo)
                    {
                        //-----------------------------------
                        //Photos.SavePhotos(fuPhoto, ItemsFiles, photosPath);
                        //------------------------------------------------
                        //Save new original photo
                        fuPhoto.PostedFile.SaveAs(DCServer.MapPath(photosPath) + itemFile.GetPhotoName(PhotoTypes.Original));
                        //Create new thumbnails
                        MoversFW.Thumbs.CreateThumb(photosPath, itemFile.GetPhotoName(PhotoTypes.Thumb), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
                        MoversFW.Thumbs.CreateThumb(photosPath, itemFile.GetPhotoName(PhotoTypes.Big), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
                        //------------------------------------------------
                    }
                    else
                    {
                        fuPhoto.SaveAs(DCServer.MapPath(photosPath + itemFile.Photo));
                    }
                }
                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
                LoadList();
                //ClearControls();
           
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
        
            int itemID = Convert.ToInt32(ddlItems.SelectedValue);
            if (itemID > 0)
            {
                List<ItemsFilesEntity> photosList = ItemsFilesFactory.GetAll(itemID, FileType);
                OurLists.LoadDataList<ItemsFilesEntity>(photosList, dlPhotos, "FileID");
            }
            else
            {
                dlPhotos.Visible = false;
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
    //--------------------------------------------------------
    protected void dlPhotos_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            Button lbtnDelete = (Button)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
                lbtnDelete.Visible = false;
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
    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        int itemID = Convert.ToInt32(ddlItems.SelectedValue);
        LoadList();
    }
}
