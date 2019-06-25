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
   
    internal class SiteUsersDataModulesManager
    {
        
        private XmlDocument XmlDoc;
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------

        #region -----------------LoadAllModules-----------------
        //-----------------------------------------------------------------
        public void LoadAllModules(List<UsersDataGlobalOptions> SiteUsersDataModulesList)
        {
            XmlDoc = SiteConfigurationManager.LoadSiteUsersDataModulesConfig();
            XmlNodeList modulesXml = XmlDoc.SelectNodes("/SiteUsersDataModules/Module");
            foreach (XmlNode usersDataModule in modulesXml)
            {
               SiteUsersDataModulesList.Add(PopulateModuleFromXmlNode(usersDataModule));
            }
         }
        #endregion

        
        //-----------------------------------------------------------------
        #region -----------------PopulateModuleFromXmlNode-----------------
        //-----------------------------------------------------------------
        private UsersDataGlobalOptions PopulateModuleFromXmlNode(XmlNode node)
        {
            UsersDataGlobalOptions usersDataModule = new UsersDataGlobalOptions();
            /****************************************************/
            //find all the public properties of list Type using reflection
            PropertyInfo[] piT = typeof(UsersDataGlobalOptions).GetProperties();
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(UsersDataGlobalOptions);
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
                            myPropInfo.SetValue(usersDataModule, Enum.Parse(myPropInfo.PropertyType, attr.Value), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        else
                        {
                            myPropInfo.SetValue(usersDataModule, Convert.ChangeType(attr.Value, myPropInfo.PropertyType), null);
                        }
                    }
                }
                catch (Exception ex)
                {
                   // throw new Exception(attr.Name);
                }
            }
            return usersDataModule;
        }
        #endregion
        //-----------------------------------------------------------------
        #region -----------------PopulateXmlNodeFromModule-----------------
        //-----------------------------------------------------------------
        //PopulateXmlNodeFromModule
        //-----------------------------------------------------------------
        private XmlElement PopulateXmlNodeFromModule(UsersDataGlobalOptions usersDataModule, XmlElement node)
        {
            UsersDataGlobalOptions defaultModule = new UsersDataGlobalOptions();
            /****************************************************/

            Type myType = typeof(UsersDataGlobalOptions);
            PropertyInfo[] piT = myType.GetProperties();
            object moduleValue;
            object defaultValue;
            foreach (PropertyInfo myPropInfo in piT)
            {
                if (myPropInfo.CanWrite)
                {
                    moduleValue = myPropInfo.GetValue(usersDataModule, null);
                    defaultValue = myPropInfo.GetValue(defaultModule, null);
                    if (moduleValue.ToString() != defaultValue.ToString())
                        AddAttribute(node, myPropInfo.Name, moduleValue);
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
        public bool SaveModule(UsersDataGlobalOptions usersDataModule)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteUsersDataModules/Module[@ModuleTypeID='" + usersDataModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                return AddModule(usersDataModule);
            }
            else
                return UpdateModule(usersDataModule);
        }
        public  bool AddModule(UsersDataGlobalOptions usersDataModule)
        {
            bool res = false;
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteUsersDataModules/Module[@ModuleTypeID='" + usersDataModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                 XmlElement xmlNewModule = XmlDoc.CreateElement("Module");
                 xmlNewModule = PopulateXmlNodeFromModule(usersDataModule, xmlNewModule);
                 XmlNode commonParent = XmlDoc.SelectSingleNode("/SiteUsersDataModules");
                 commonParent.AppendChild(xmlNewModule);
                 //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteUsersDataModules.config");
                 SiteConfigurationManager.UpdateSiteUsersDataModules(XmlDoc);
                 //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool UpdateModule(UsersDataGlobalOptions usersDataModule)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteUsersDataModules/Module[@ModuleTypeID='" + usersDataModule.ModuleTypeID + "']");
            if (nodesList.Count == 1)
            {

                XmlElement oldModuleNode = (XmlElement)nodesList[0];
                oldModuleNode.Attributes.RemoveAll();
                PopulateXmlNodeFromModule(usersDataModule, oldModuleNode);
                //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteUsersDataModules.config");
                SiteConfigurationManager.UpdateSiteUsersDataModules(XmlDoc);
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool DeleteModule(int moduleID)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteUsersDataModules/Module[@ModuleTypeID='" + moduleID + "']");
            foreach (XmlNode module in nodesList)
            {
                XmlNode parentnode = module.ParentNode;
                parentnode.RemoveChild(module);
            }
            //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs + "SiteUsersDataModules.config");
            SiteConfigurationManager.UpdateSiteUsersDataModules(XmlDoc);
            res = true;
            return res;
        }
        //------------------------------------------------------------------


    }
}