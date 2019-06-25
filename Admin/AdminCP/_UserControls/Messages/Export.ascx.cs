using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;

using System.Collections.Specialized;

public partial class App_Controls_Messages_Admin_Export : System.Web.UI.UserControl
{
    //---------------------------------------
    MessagesModuleOptions currentModule;
    //---------------------------------------
    List<MessagesEntity> messagesList;
    //---------------------------------------

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

    #region --------------Page_Load--------------
    //---------------------------------------------------------
    //Page_Load
    //---------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    public void LoadData()
    {
        HandelControls();
        SetTexts();
        if ((!SiteSettings.Languages_HasMultiLanguages && !currentModule.HasType)||Request.QueryString.Count>0)
        {
            btnExport.Visible = false;
            Export();
        }

    }
    //--------------------------------------------------------
    #endregion

    #region --------------Load_ddlType--------------
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

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    private void HandelControls()
    {
        //----------------------------------------------------------------------
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
        //---------------------------------------------------------------------
        dgMessages.Columns[0].Visible = currentModule.HasName;
        dgMessages.Columns[1].Visible = currentModule.HasEMail;
        dgMessages.Columns[2].Visible = currentModule.HasCountryID;
        dgMessages.Columns[3].Visible = currentModule.HasCityID;
        dgMessages.Columns[4].Visible = currentModule.HasUserCityName;
        dgMessages.Columns[5].Visible = currentModule.HasCompany;
        dgMessages.Columns[6].Visible = currentModule.HasJobID;
        dgMessages.Columns[7].Visible = currentModule.HasJobText;
        dgMessages.Columns[8].Visible = currentModule.HasEmpNo;
        dgMessages.Columns[9].Visible = currentModule.HasJobTel;
        dgMessages.Columns[10].Visible = currentModule.HasActivitiesID;
        dgMessages.Columns[11].Visible = currentModule.HasUrl;
        dgMessages.Columns[12].Visible = currentModule.HasTel;
        dgMessages.Columns[13].Visible = currentModule.HasMobile;
        dgMessages.Columns[14].Visible = currentModule.HasFax;
        dgMessages.Columns[15].Visible = currentModule.HasMailBox;
        dgMessages.Columns[16].Visible = currentModule.HasZipCode;
        dgMessages.Columns[17].Visible = currentModule.HasAddress;
        dgMessages.Columns[18].Visible = currentModule.HasAgeRang;
        dgMessages.Columns[19].Visible = currentModule.HasGender;
        dgMessages.Columns[20].Visible = currentModule.HasBirthDate;
        dgMessages.Columns[21].Visible = currentModule.HasSocialStatus;
        dgMessages.Columns[22].Visible = currentModule.HasEducationLevel;
        dgMessages.Columns[23].Visible = currentModule.HasType;
        dgMessages.Columns[24].Visible = currentModule.HasHasSmsService;
        dgMessages.Columns[25].Visible = currentModule.HasHasEmailService;
        //dgMessages.Columns[26].Visible = currentModule.HasDate_Added;
        //dgMessages.Columns[27].Visible = currentModule.HasIsSeen;
        dgMessages.Columns[28].Visible = currentModule.HasReply;
        dgMessages.Columns[29].Visible = currentModule.HasIsAvailable;
    }
    //-----------------------------------------------
    #endregion
    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        //----------------------------------------------------------------------
        /*
        currentModule.HasNationalityID;
        currentModule.CategoryLevel;
        currentModule.HasRedirectToMember;
        currentModule.HasAddress;
        currentModule.HasTitle;
        currentModule.HasDetails;
        currentModule.HasToItemID;
        currentModule.HasReply;
        currentModule.HasCityID;
        currentModule.HasUserCityName;
        */
        /*
        //----------------------------------------------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        trPhotoPreview.Visible = currentModule.HasPhotoExtension;
        rfvPhoto.Visible = false;
        //----------------------------------------------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.HasFileExtension;
        trFilePreview.Visible = currentModule.HasFileExtension;
        //rfvFile.Visible = currentModule.HasFileExtension && currentModule.RequiredFile;
        //----------------------------------------------------------------------
        //Height	
        trHeight.Visible = currentModule.HasHeight;
        rfvHeight.Visible = currentModule.HasHeight && currentModule.RequiredHeight;
        //----------------------------------------------------------------------
        //Width
        trWidth.Visible = currentModule.HasWidth;
        rfvWidth.Visible = currentModule.HasWidth && currentModule.RequiredWidth;
        //----------------------------------------------------------------------
        //ItemDate
        trItemDate.Visible = currentModule.HasItemDate;
        //rfvItemDate.Visible = currentModule.HasItemDate && currentModule.RequiredItemDate;
        //----------------------------------------------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.HasVideoExtension;
        trVideoPreview.Visible = currentModule.HasVideoExtension;
        //rfvVideo.Visible = currentModule.HasVideoExtension && currentModule.RequiredVideo;
        //----------------------------------------------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.HasAudioExtension;
        trAudioPreview.Visible = currentModule.HasAudioExtension;
        //rfvAudio.Visible = currentModule.HasAudioExtension && currentModule.RequiredAudio;
        //----------------------------------------------------------------------
        //trPhoto2Preview
        trPhoto2Extension.Visible = currentModule.HasPhoto2Extension;
        trPhoto2Preview.Visible = currentModule.HasPhoto2Extension;
        //rfvPhoto2.Visible = currentModule.HasPhoto2Extension && currentModule.RequiredPhoto2;
        //----------------------------------------------------------------------
        //trHasIsMain
        trHasIsMain.Visible = currentModule.HasIsMain;
        //----------------------------------------------------------------------
        //HasPriority
        if (currentModule.HasPriority)
        {
            trPriority.Visible = true;
            LoadPriorities();
        }
        else
        {
            trPriority.Visible = false;
        }
        //----------------------------------------------------------------------
        //trYouTubeCode
        trYoutubeCode.Visible = currentModule.HasYoutubeCode;
        //----------------------------------------------------------------------
        trShortDescription.Visible = (currentModule.HasShortDescription || currentModule.HasMetaDescription);
        //-----------------------------------
        //Previews
        ibtnDeletePhoto.Visible = !currentModule.RequiredPhotoExtension;
        ibtnDeleteFile.Visible = !currentModule.RequiredFile;
        btnDeletePhoto2.Visible = !currentModule.RequiredPhoto2;
        ibtnDeleteVideo.Visible = !currentModule.RequiredVideo;
        ibtnDeleteAudio.Visible = !currentModule.RequiredAudio;
        //----------------------------------------------------------------------
        lblAdminNote.Text = currentModule.AdminNote;
        //----------------------------------------------------------------------
        //trGoogleLatitude
        trGoogleLatitude.Visible = currentModule.HasGoogleLatitude;
        rfvGoogleLatitude.Visible = currentModule.HasGoogleLatitude && currentModule.RequiredGoogleLatitude;
        //----------------------------------------------------------------------
        //trGoogleLongitude
        trGoogleLongitude.Visible = currentModule.HasGoogleLongitude;
        rfvGoogleLongitude.Visible = currentModule.HasGoogleLongitude && currentModule.RequiredGoogleLongitude;
        //----------------------------------------------------------------------
        //trPrice
        trPrice.Visible = currentModule.HasPrice;
        rfvPrice.Visible = currentModule.HasPrice && currentModule.RequiredPrice;
        //----------------------------------------------------------------------
        //trOnlyForRegisered
        trOnlyForRegisered.Visible = currentModule.HasOnlyForRegisered;
        //----------------------------------------------------------------------
        //Files publishing
        cbPublishPhoto.Visible = currentModule.HasPublishPhoto;
        cbPublishPhoto2.Visible = currentModule.HasPublishPhoto2;
        cbPublishFile.Visible = currentModule.HasPublishFile;
        cbPublishAudio.Visible = currentModule.HasPublishAudio;
        cbPublishVideo.Visible = currentModule.HasPublishVideo;
        cbPublishYoutbe.Visible = currentModule.HasPublishYoutbe;
        //----------------------------------------------------------------------
        trMetaKeyWords.Visible = currentModule.HasMetaKeyWords;
        //----------------------------------------------------------------------
        //-------------------------------------------
        //Attatchments
        trAttatch1.Visible = currentModule.HasAttachmentsInReplay;
        trAttatch2.Visible = currentModule.HasAttachmentsInReplay;
        trAttatch3.Visible = currentModule.HasAttachmentsInReplay;
        //-------------------------------------------
        */
    }
    //-----------------------------------------------
    #endregion



    
    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        lblType.Text = DynamicResource.GetMessageModuleText(currentModule, "Type");
        //-------------------------------------------------------------------------------------------
        //Set Gerid Headers
        //-------------------------------------------------------------------------------------------
        dgMessages.Columns[0].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Name");
        dgMessages.Columns[1].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "EMail");
        dgMessages.Columns[2].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "CountryID");
        dgMessages.Columns[3].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "CityID");
        dgMessages.Columns[4].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "UserCityName");
        dgMessages.Columns[5].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Company");
        dgMessages.Columns[6].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "JobID");
        dgMessages.Columns[7].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "JobText");
        dgMessages.Columns[8].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "EmpNo");
        dgMessages.Columns[9].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "JobTel");
        dgMessages.Columns[10].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "ActivitiesID");
        dgMessages.Columns[11].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Url");
        dgMessages.Columns[12].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Tel");
        dgMessages.Columns[13].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Mobile");
        dgMessages.Columns[14].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Fax");
        dgMessages.Columns[15].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "MailBox");
        dgMessages.Columns[16].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "ZipCode");
        dgMessages.Columns[17].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Address");
        dgMessages.Columns[18].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "AgeRang");
        dgMessages.Columns[19].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Gender");
        dgMessages.Columns[20].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "BirthDate");
        dgMessages.Columns[21].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "SocialStatus");
        dgMessages.Columns[22].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel");
        dgMessages.Columns[23].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Type");
        dgMessages.Columns[24].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "HasSmsService");
        dgMessages.Columns[25].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "HasEmailService");
        dgMessages.Columns[26].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "Date_Added");
        dgMessages.Columns[27].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "IsSeen");
        dgMessages.Columns[28].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "IsReplied");
        dgMessages.Columns[29].HeaderText = DynamicResource.GetMessageModuleText(currentModule, "IsAvailable");
        //-------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------Export---------------
    //-----------------------------------------------
    //Export
    //-----------------------------------------------
    private void Export()
    {
        LoadList();
        if (messagesList != null && messagesList.Count > 0)
        {
            dgMessages.DataSource = messagesList;
            dgMessages.DataKeyField = "MessageID";
            dgMessages.DataBind();
            dgMessages.Visible = true;
            //-----------------------------------
            Response.Clear();
            //Response.HeaderEncoding = Encoding.GetEncoding("Windows-1256");
            Response.AddHeader("content-disposition", "attachment;filename="+currentModule.Identifire+".xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            // Response.Charset = "utf-8";
            Response.Charset = "utf-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            dgMessages.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            dgMessages.Visible = false;
            //-----------------------------------
        }
        else
        {
            dgMessages.Visible = false;
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
        
    }
    #endregion

    #region --------------LoadList--------------
    //---------------------------------------------------------
    //LoadList
    //---------------------------------------------------------
    public void LoadList()
    {
        StringDictionary tempDictionary = new StringDictionary();
        List<MessagesEntity> arabicList = null;
        List<MessagesEntity> englishList = null;
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
        {
            langID = (Languages)Convert.ToInt32(Request.QueryString["lang"]);
        }
        else
        {
            if (SiteSettings.Languages_HasMultiLanguages)
                langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        }
        //--------------------------------------------------------------------
        int typeID = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["type"]))
        {
            typeID = Convert.ToInt32(Request.QueryString["type"]);
        }
        else
        {
            if (currentModule.HasType)
                typeID = Convert.ToInt32(ddlType.SelectedValue);
        }
        //--------------------------------------------------------------------
        if (SiteSettings.Languages_HasMultiLanguages && langID == Languages.Unknowen)
        {
            messagesList = MessagesFactory.ExportData(ModuleTypeID, -1, Languages.Ar, typeID, -1, false, false, false, OwnerID);
            foreach (MessagesEntity msg in messagesList)
            {
                tempDictionary.Add(msg.MessageID.ToString(), null);
            }
            //------------------------------------------
            englishList = MessagesFactory.ExportData(ModuleTypeID, -1, Languages.En, typeID, -1, false, false, false, OwnerID);
            foreach (MessagesEntity msg in englishList)
            {
                if (!tempDictionary.ContainsKey(msg.MessageID.ToString()))
                    messagesList.Add(msg);
            }
        }
        //-------------------------------------------------------------------
        else
        {
            messagesList = MessagesFactory.ExportData(ModuleTypeID, -1, langID, typeID, -1, false, false, false, OwnerID);
            foreach (MessagesEntity msg in messagesList)
            {
                tempDictionary.Add(msg.MessageID.ToString(), null);
            }
        }
        
        //-------------------------------------------------------------------
    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetTypeText--------------
    //---------------------------------------------------------
    //GetTypeText
    //---------------------------------------------------------
    protected string GetTypeText(object type)
    {
        string text = "";
        if (type != null && type.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "Type_" + type);
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;
         
    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetJobIDText--------------
    //---------------------------------------------------------
    //GetJobIDText
    //---------------------------------------------------------
    protected string GetJobIDText(object job)
    {
        string text = "";
        if (job != null && job.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "Job_" + job);
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetActivitiesIDText--------------
    //---------------------------------------------------------
    //GetActivitiesIDText
    //---------------------------------------------------------
    protected string GetActivitiesIDText(object ActivitiesID)
    {
        string text = "";
        if (ActivitiesID != null && ActivitiesID.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "ActivitiesID_" + ActivitiesID);
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetAgeText--------------
    //---------------------------------------------------------
    //GetAgeText
    //---------------------------------------------------------
    protected string GetAgeText(object age)
    {
        string text = "";
        if (age != null && age.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "AgeRang_" + age.ToString());
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetGenderText--------------
    //---------------------------------------------------------
    //GetGenderText
    //---------------------------------------------------------
    protected string GetGenderText(object _value)
    {
        string text = "";
        if (_value != null && _value.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "Gender_" + _value.ToString());
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetSocialStatusText--------------
    //---------------------------------------------------------
    //GetSocialStatusText
    //---------------------------------------------------------
    protected string GetSocialStatusText(object _value)
    {
        string text = "";
        if (_value != null && _value.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "SocialStatus_" + _value.ToString());
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetEducationLevelText--------------
    //---------------------------------------------------------
    //GetEducationLevelText
    //---------------------------------------------------------
    protected string GetEducationLevelText(object _value)
    {
        string text = "";
        if (_value != null && _value.ToString().Length > 0)
            text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_" + _value.ToString());
        if (string.IsNullOrEmpty(text))
            text = Resources.Messages.Unspecified;
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetBooleanText--------------
    //---------------------------------------------------------
    //GetBooleanText
    //---------------------------------------------------------
    public string GetBooleanText(object _value)
    {
        bool x = Convert.ToBoolean(_value);
        if (x) return Resources.Messages.True;
        else return Resources.Messages.False;
    }
    //--------------------------------------------------------
    #endregion

    #region --------------btnExport_Click--------------
    //---------------------------------------------------------
    //btnExport_Click
    //---------------------------------------------------------
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export();
    }
    //--------------------------------------------------------
    #endregion

    public string GetName(object _name)
    {
        string name="";
        if (_name != null)
        {
            name = (string)_name;

            if (currentModule.HasNameSeparated)
            {
                string sparatedNmae = "";
                //------------------------------------------------------------
                string[] names = name.Split(new Char[] { ',' });
                foreach (string str in names)
                {
                    if (names.Length > 0)
                        sparatedNmae += " ";
                    sparatedNmae += str;
                }
                //------------------------------------------------------------
                name = sparatedNmae;
            }
        }
        return name;
    }
}
