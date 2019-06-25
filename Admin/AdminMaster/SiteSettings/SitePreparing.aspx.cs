using System;using DCCMSNameSpace;
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

using System.Data.SqlClient;

public partial class AdminSiteSettings_Comments : MasterAdminMasterPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = "Õ–› «·»Ì«‰«  Ê«· ÂÌ∆… ·„Êﬁ⁄ ÃœÌœ";
        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------DeleteOldSiteFiles--------------
    public void DeleteOldSiteFiles()
    {
        /*
        //ItemCategories
        string SourcePath=DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesDirectory (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
        //SiteDeparments
        SourcePath = DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsDirectory (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
        //Items
        SourcePath = DCServer.MapPath(DCSiteUrls.GetPath_ItemsDirectory (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
        //UserData
        SourcePath = DCServer.MapPath(DCSiteUrls.GetPath_UserDataDirectory (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
        //Messages
        SourcePath = DCServer.MapPath(DCSiteUrls.GetPath_MessagesDirectory (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
        //Advertisments
        SourcePath = DCServer.MapPath(DCSiteUrls.GetPath_UAdvertisments (SitesHandler.GetOwnerIdentifire()));
        Delete(SourcePath);
        //------------------------------------------
         */ 
    }
    
    #endregion

    #region --------------GetSqlConnection--------------
    public SqlConnection GetSqlConnection()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ToString());
    }
    //------------------------------------------
    #endregion

    #region --------------DeleleOldSiteData--------------
    public void DeleleOldSiteData()
    {
        using (SqlConnection myConnection = GetSqlConnection())
        {
            SqlCommand myCommand = new SqlCommand("SiteManager_PrepareSite", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            // Set the parameters
            myCommand.Parameters.Add("@DefaultLangID", SqlDbType.Int, 4).Value = SiteSettings.Languages_DefaultLanguageID;
            // Execute the command
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
    }
    //------------------------------------------
    #endregion

    #region --------------Delete--------------
    //------------------------------------------------------------------------------------------
    public static void Delete(string SourcePath)
    {
        DirectoryInfo SourceDirectory = new DirectoryInfo(SourcePath.Trim());
        Delete(SourceDirectory);
    }
    //------------------------------------------
    public static void Delete(DirectoryInfo SourceDirectory)
    {
        DirectoryInfo[] SourceSubDirectories;
        FileInfo[] SourceFiles;
        SourceFiles = SourceDirectory.GetFiles();
        SourceSubDirectories = SourceDirectory.GetDirectories();
        //for (int i = 0; i < Form1.newModulesNames.Length; i++)
        //{
        //Recursively Copy Every SubDirectory and it's Contents (according to folder filter)
        foreach (DirectoryInfo SourceSubDirectory in SourceSubDirectories)
        {
            Delete(SourceSubDirectory);
        }
        foreach (FileInfo SourceFile in SourceFiles)
        {
            SourceFile.Delete();
        }
    }
    //------------------------------------------------------------------------------------------
    #endregion

    #region --------------DeleleAllOldSiteUsers--------------
    public void DeleleAllOldSiteUsers()
    {
        MembershipUserCollection siteUsers = Membership.GetAllUsers();
        string username;
        foreach (MembershipUser user in siteUsers)
        {
            username =user.UserName.ToLower();
            if (!(username == "dcadmin" || username == "admin" || username == "dcmaster"))
            {
                Membership.DeleteUser(username, true);
            }
        }
    }
    //------------------------------------------
    #endregion

    protected void btnDeleteAllData_Click(object sender, EventArgs e)
    {
        DeleleOldSiteData();
        DeleleAllOldSiteUsers();
        DeleteOldSiteFiles();

    }
    protected void btnDeleteAllDataWithoutUsers_Click(object sender, EventArgs e)
    {
        DeleleOldSiteData();
        DeleteOldSiteFiles();
    }
    protected void btnDeleteAllOldUsers_Click(object sender, EventArgs e)
    {
        DeleleAllOldSiteUsers();
    }
    protected void btnAddTestingData_Click(object sender, EventArgs e)
    {
        TestingDataFactor testfactor = new TestingDataFactor();
        testfactor.InsertTestingDataForAllSiteModules();
    }
}

