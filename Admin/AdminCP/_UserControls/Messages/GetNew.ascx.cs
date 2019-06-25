using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;


public partial class Messages_GetNew : System.Web.UI.UserControl
{
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

    #region --------------ToItemID--------------
    private int _ToItemID=-1;
    public int ToItemID
    {
        get { return _ToItemID; }
        set { _ToItemID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------ToUserId--------------
    private object _ToUserId = null;
    public object ToUserId
    {
        get { return _ToUserId; }
        set { _ToUserId = value; }
    }
    //------------------------------------------
    #endregion

    MessagesModuleOptions currentModule;
    
    #region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
		if(!IsPostBack)
		{
           
			PagerManager.PrepareAdminPager(pager);
			pager.Visible = false;
            HandelControls();
            SetTexts();
			LoadData();
            //-----------------------------------------------------
            if (currentModule.HasTitle)
            {
                dgMessages.Columns[1].Visible = true;
                dgMessages.Columns[3].Visible = false;
            }
            else
            {
                dgMessages.Columns[1].Visible = false;
                dgMessages.Columns[3].Visible = true;
            }
            dgMessages.Columns[7].Visible = currentModule.HasComments;
            dgMessages.Columns[8].Visible = currentModule.HasComments;


            //-----------------------------------------------------
        }
	}
	//-----------------------------------------------
	#endregion
    //-----------------------------------------------

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        #region ------------------Type Handling---------------------
        //Type Handling
        if (currentModule.HasType)
            Load_ddlType();
        else
            trType.Visible = false;
        #endregion
        trExport.Visible = currentModule.HasExportData;

            
    }
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        //-----------------------------------------------
        dgMessages.Columns[1].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Title");
        dgMessages.Columns[3].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Email");
        dgMessages.Columns[3].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Name");
        dgMessages.Columns[4].HeaderText = Resources.AdminText.AdminGrid_ReviewStatus;
        dgMessages.Columns[5].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Reply");
        dgMessages.Columns[6].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "IsAvailable_Status");
        dgMessages.Columns[7].HeaderText = Resources.AdminText.AdminGrid_InActiveComments;
        dgMessages.Columns[8].HeaderText = Resources.AdminText.AdminGrid_ActiveComments;
        dgMessages.Columns[9].HeaderText = Resources.AdminText.AdminGrid_DateAdded;
        //-----------------------------------------------
        lblType.Text = DynamicResource.GetMessageModuleText(currentModule, "Type");
        //-----------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region --------------Load_ddlType()--------------
    //---------------------------------------------------------
    //Load_ddlType
    //---------------------------------------------------------
    protected void Load_ddlType()
    {

        ddlType.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
        string text = "";
        string id = "";
        for (int i = 1; i <= currentModule.TypesCount; i++)
        {
            id = i.ToString();
            text = DynamicResource.GetMessageModuleText(currentModule, "Type_" + i);
            ddlType.Items.Add(new ListItem(text, id));
        }
    }
    //--------------------------------------------------------
    #endregion

	#region --------------LoadData--------------
	//---------------------------------------------------------
	//LoadData
	//---------------------------------------------------------
	private void LoadData()
	{
		pager.PageSize = SiteSettings.Site_AdminPageSize;
		int totalRecords = 0;
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        int typeID = 0;
        if (currentModule.HasType)
            typeID = Convert.ToInt32(ddlType.SelectedValue);
        //--------------------------------------------------------------------
        List<MessagesEntity> messagesList = MessagesFactory.GetAll(ModuleTypeID, -1, langID, typeID, ToItemID,ToUserId, false, false, true, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID);
		if(messagesList!=null&&messagesList.Count >0)
		{
			dgMessages.DataSource= messagesList;
			dgMessages.DataKeyField="MessageID";
			dgMessages.AllowPaging=false;
			pager.Visible = true;
			pager.TotalRecords = totalRecords;
            //------------------------------------
            dgMessages.Columns[1].Visible = currentModule.HasTitle;
            dgMessages.Columns[2].Visible = currentModule.HasEMail ;
            dgMessages.Columns[3].Visible = currentModule.HasName && !currentModule.HasTitle;
            dgMessages.Columns[5].Visible = currentModule.HasReply;
            dgMessages.Columns[6].Visible = currentModule.HasIsAvailable;
            //------------------------------------
            dgMessages.DataBind();
			dgMessages.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            //Check Edit permission
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Edit))
                dgMessages.Columns[dgMessages.Columns.Count - 2].Visible = false;
            //Check Delete permission
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
                dgMessages.Columns[dgMessages.Columns.Count - 1].Visible = false;
            //-------------------------------------------------------------------------------
		}
		else
		{
			dgMessages.Visible=false;
			pager.Visible = false;
			lblResult.CssClass = "operation_error";
			lblResult.Text = Resources.AdminText.ThereIsNoData;
		}
	}
	//--------------------------------------------------------
	#endregion

	#region --------------dgMessages_ItemDataBound--------------
	//---------------------------------------------------------
	//dgMessages_ItemDataBound
	//---------------------------------------------------------
	protected void dgMessages_ItemDataBound(object source, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
			lbtnDelete.Attributes.Add("onclick", "return confirm('"+Resources.AdminText.DeleteActivation+"')");
			lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
        }
	}
	//--------------------------------------------------------
	#endregion

	#region --------------Pager_PageIndexChang--------------
	//---------------------------------------------------------
	//Pager_PageIndexChang
	//---------------------------------------------------------
	protected void Pager_PageIndexChang()
	{
		LoadData();
	}
	//--------------------------------------------------------
	#endregion

	#region --------------dgMessages_DeleteCommand--------------
	//---------------------------------------------------------
	//dgMessages_DeleteCommand
	//---------------------------------------------------------
	protected void dgMessages_DeleteCommand(object source, DataGridCommandEventArgs e)
	{

       
        //-------------------------------------------------------------------------------

        int messageID = Convert.ToInt32(dgMessages.DataKeys[e.Item.ItemIndex]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
		if(MessagesFactory.Delete(messageID))
		{
            //------------------------------------------------
            //RegisterInMailList
            if ((currentModule.MailListAutomaticRegistration || (msg.HasEmailService)) && !string.IsNullOrEmpty(msg.EMail))
                MessagesFactory.UnRegisterInMailList(msg);
            //------------------------------------------------
            //RegisterInSms
            if ((currentModule.SmsAutomaticRegistration || (msg.HasSmsService)) && !string.IsNullOrEmpty(msg.Mobile))
                MessagesFactory.UnRegisterInSms(msg);
            //------------------------------------------------
			lblResult.CssClass = "operation_done";
			lblResult.Text = Resources.AdminText.DeletingOprationDone;
			//if one item in datagrid
			if (dgMessages.Items.Count == 1)
			{
				--pager.CurrentPage;
			}
			LoadData();
		}
		else
		{
			lblResult.CssClass = "operation_error";
			lblResult.Text =Resources.AdminText.DeletingOprationFaild;
		}
	}
	//--------------------------------------------------------
	#endregion

    //--------------------------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        int typeID = 0;
        if (currentModule.HasType)
            typeID = Convert.ToInt32(ddlType.SelectedValue);
        //--------------------------------------------------------------------
        Response.Redirect("/AdminCP/Messages/" + currentModule.Identifire + "/Export.aspx?lang=" + (int)langID + "&typeID=" + typeID);
        //--------------------------------------------------------------------

    }
}

