using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.Reflection;
namespace DCCMSNameSpace
{

    public class SitePagesManager
    {
        
        private XmlDocument XmlDoc;
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------
        #region -----------------LoadAllPages-----------------
        //-----------------------------------------------------------------
        public void LoadAllPages(List<SitePageOptions> SitePagesList)
        {
            XmlDoc = SiteConfigurationManager.LoadSitePagesConfig();
            XmlNodeList modulesXml = XmlDoc.SelectNodes("/Pages/Page");
            foreach (XmlNode page in modulesXml)
            {
                SitePagesList.Add(PopulatePageFromXmlNode(page));
            }
         }
        #endregion
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------
        #region -----------------PopulatePageFromXmlNode-----------------
        //-----------------------------------------------------------------
        private SitePageOptions PopulatePageFromXmlNode(XmlNode node)
        {
            SitePageOptions Page = new SitePageOptions();
            /****************************************************/
            //find all the public properties of list Type using reflection
            PropertyInfo[] piT = typeof(SitePageOptions).GetProperties();
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(SitePageOptions);
            PropertyInfo myPropInfo;
            string exceptions = "";
            foreach (XmlAttribute attr in node.Attributes)
            {
                try
                {
                    myPropInfo = myType.GetProperty(attr.Name);
                    if (myPropInfo.CanWrite)
                    {
                        if (myPropInfo.PropertyType.BaseType == typeof(System.Enum))
                        {
                            //int intVal = Convert.ToInt32(attr.Value);
                            myPropInfo.SetValue(Page, Enum.Parse(myPropInfo.PropertyType, attr.Value), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        else
                        {
                            myPropInfo.SetValue(Page, Convert.ChangeType(attr.Value, myPropInfo.PropertyType), null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(attr.Name);
                }
            }
            return Page;
        }
        #endregion
        //-----------------------------------------------------------------
        #region -----------------PopulateXmlNodeFromPage-----------------
        //-----------------------------------------------------------------
        //PopulateXmlNodeFromPage
        //-----------------------------------------------------------------
        private XmlElement PopulateXmlNodeFromPage(SitePageOptions page, XmlElement node)
        {
            SitePageOptions defaultPage = new SitePageOptions();
            /****************************************************/

            Type myType = typeof(SitePageOptions);
            PropertyInfo[] piT = myType.GetProperties();
            object propValue;
            object defaultValue;
            foreach (PropertyInfo myPropInfo in piT)
            {
                if (myPropInfo.CanWrite)
                {
                    propValue = myPropInfo.GetValue(page, null);
                    defaultValue = myPropInfo.GetValue(defaultPage, null);
                    if (propValue.ToString() != defaultValue.ToString())
                        AddAttribute(node, myPropInfo.Name, propValue);
                }
            }
            return node;
           
        }
        //-----------------------------------------------------------------
        #endregion
        //-----------------------------------------------------------------
        //-----------------------------------------------------------------
        #region -----------------AddAttribute-----------------
        //-----------------------------------------------------------------
        private static void AddAttribute(XmlElement element,string name, object value)
        {
            XmlAttribute att = element.SetAttributeNode(name, "");
            att.InnerText = value.ToString();
            element.Attributes.Append(att);
        }
        #endregion
        //-----------------------------------------------------------------
        public bool SavePage(SitePageOptions page)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/Pages/Page[@PageID='" + page.PageID + "']");
            if (nodeList.Count == 0)
            {
                return AddPage(page);
            }
            else
                return UpdatePage(page);
        }
        public  bool AddPage(SitePageOptions page)
        {
            bool res = false;
            XmlNodeList nodeList = XmlDoc.SelectNodes("/Pages/Page[@PageID='" + page.PageID + "']");
            if (nodeList.Count == 0)
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                 XmlElement xmlNewPage = XmlDoc.CreateElement("Page");
                 xmlNewPage = PopulateXmlNodeFromPage(page, xmlNewPage);
                 XmlNode commonParent = XmlDoc.SelectSingleNode("/Pages");
                 commonParent.AppendChild(xmlNewPage);
                 //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SitePages.config");
                 SiteConfigurationManager.UpdateSitePages(XmlDoc);
                 //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool UpdatePage(SitePageOptions page)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/Pages/Page[@PageID='" + page.PageID + "']");
            if (nodesList.Count == 1)
            {

                XmlElement oldPageNode = (XmlElement)nodesList[0];
                oldPageNode.Attributes.RemoveAll();
                PopulateXmlNodeFromPage(page, oldPageNode);
                //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SitePages.config");
                SiteConfigurationManager.UpdateSitePages(XmlDoc);
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool DeletePage(int pageID)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/Pages/Page[@PageID='" + pageID + "']");
            foreach (XmlNode page in nodesList)
            {
                XmlNode parentnode = page.ParentNode;
                parentnode.RemoveChild(page);
            }
            //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SitePages.config");
            SiteConfigurationManager.UpdateSitePages(XmlDoc);
            res = true;

            return res;
        }
    }
}