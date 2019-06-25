using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;


public partial class Mobile_Forms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str= "worked";

    }
    //---------------------------------------------------------------
    [WebMethod]
    public static string SaveData(object formObject)
    {
        return "worked";
    }
    //---------------------------------------------------------------
    [WebMethod]
    public static string SaveData()
    {
        
        return "worked";
    }
    //---------------------------------------------------------------
    [WebMethod]
    public static string SaveData(string name)
    {
        
        return "worked";
    }
    //---------------------------------------------------------------


    //---------------------------------------------------------------
    [WebMethod]
    public static string SaveForm2Data(string name, string emial, string mobile, string question)
    {
        MessagesEntity msg = new MessagesEntity();
        msg.ModuleTypeID = 507;
        msg.Name = name;
        msg.EMail = emial;
        msg.Mobile = mobile;
        msg.Details = question;
        msg.LangID = Languages.En;
        MessagesModuleOptions currentMessageModule = MessagesModuleOptions.GetType(507);
        bool createMessageFolder = (currentMessageModule.HasFileExtension || currentMessageModule.HasPhotoExtension || currentMessageModule.HasPhoto2Extension || currentMessageModule.HasVideoExtension || currentMessageModule.HasAudioExtension);
        bool status = MessagesFactory.Create(msg, createMessageFolder);
        return "worked";
    }
    //---------------------------------------------------------------
    [WebMethod]
    public static string SaveForm3Data(string name, string emial, string mobile, string mailbox, string city, string address, string needs, string knowen)
    {

        MessagesEntity msg = new MessagesEntity();
        msg.ModuleTypeID = 504;

        msg.Name = "0," + name.Replace(' ',',');

        //msg.Name = name;
        msg.EMail = emial;
        msg.Mobile = mobile;
        msg.MailBox = mailbox;
        msg.UserCityName = city;
        msg.Address = address;
        msg.LangID = Languages.En;
        try
        {
            msg.EducationLevel = Convert.ToInt32(needs);
        }
        catch { }
        try
        {
            msg.SocialStatus = Convert.ToInt32(knowen);
        }
        catch { }
        MessagesModuleOptions currentMessageModule = MessagesModuleOptions.GetType(504);
        bool createMessageFolder = (currentMessageModule.HasFileExtension || currentMessageModule.HasPhotoExtension || currentMessageModule.HasPhoto2Extension || currentMessageModule.HasVideoExtension || currentMessageModule.HasAudioExtension);

        bool status = MessagesFactory.Create(msg, createMessageFolder);
        return "worked";
    }
    //---------------------------------------------------------------
}
