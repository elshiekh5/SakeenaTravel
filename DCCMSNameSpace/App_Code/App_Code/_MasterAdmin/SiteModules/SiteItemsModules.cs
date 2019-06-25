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

    internal class SiteItemsModulesManager
    {
        private XmlDocument XmlDoc;
        //-----------------------------------------------------------------
        #region -----------------LoadAllModules-----------------
        //-----------------------------------------------------------------
        public void LoadAllModules(List<ItemsModulesOptions> SiteItemsModulesList)
        {
            XmlDoc = SiteConfigurationManager.LoadSiteItemsModulesConfig();
            XmlNodeList modulesXml = XmlDoc.SelectNodes("/SiteItemsModules/Module");
            foreach (XmlNode itemsModule in modulesXml)
            {
                SiteItemsModulesList.Add(PopulateModuleFromXmlNode(itemsModule));
            }
        }
        #endregion
        //-----------------------------------------------------------------
        #region -----------------PopulateModuleFromXmlNode-----------------
        //-----------------------------------------------------------------
        private ItemsModulesOptions PopulateModuleFromXmlNode(XmlNode node)
        {
            ItemsModulesOptions itemsModule = new ItemsModulesOptions();
            /****************************************************/
            //find all the public properties of list Type using reflection
            PropertyInfo[] piT = typeof(ItemsModulesOptions).GetProperties();
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(ItemsModulesOptions);
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
                            myPropInfo.SetValue(itemsModule, Enum.Parse(myPropInfo.PropertyType, attr.Value), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        else
                        {
                            myPropInfo.SetValue(itemsModule, Convert.ChangeType(attr.Value, myPropInfo.PropertyType), null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(attr.Name);
                }
            }
            return itemsModule;
        }
        #endregion
        //-----------------------------------------------------------------
        #region -----------------PopulateXmlNodeFromModule-----------------
        //-----------------------------------------------------------------
        //PopulateXmlNodeFromModule
        //-----------------------------------------------------------------
        private XmlElement PopulateXmlNodeFromModule(ItemsModulesOptions itemsModule, XmlElement node)
        {
            ItemsModulesOptions defaultModule = new ItemsModulesOptions();
            /****************************************************/

            Type myType = typeof(ItemsModulesOptions);
            PropertyInfo[] piT = myType.GetProperties();
            object moduleValue;
            object defaultValue;
            foreach (PropertyInfo myPropInfo in piT)
            {
                if (myPropInfo.CanWrite)
                {
                    moduleValue = myPropInfo.GetValue(itemsModule, null);
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
        public bool SaveModule(ItemsModulesOptions itemsModule)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteItemsModules/Module[@ModuleTypeID='" + itemsModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                return AddModule(itemsModule);
            }
            else
                return UpdateModule(itemsModule);
        }
        public  bool AddModule(ItemsModulesOptions itemsModule)
        {
            bool res = false;
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteItemsModules/Module[@ModuleTypeID='" + itemsModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                 XmlElement xmlNewModule = XmlDoc.CreateElement("Module");
                 xmlNewModule = PopulateXmlNodeFromModule(itemsModule, xmlNewModule);
                 XmlNode commonParent = XmlDoc.SelectSingleNode("/SiteItemsModules");
                 commonParent.AppendChild(xmlNewModule);
                 //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteItemsModules.config");
                 SiteConfigurationManager.UpdateSiteItemsModules(XmlDoc);
                 //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool UpdateModule(ItemsModulesOptions itemsModule)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteItemsModules/Module[@ModuleTypeID='" + itemsModule.ModuleTypeID + "']");
            if (nodesList.Count == 1)
            {

                XmlElement oldModuleNode = (XmlElement)nodesList[0];
                oldModuleNode.Attributes.RemoveAll();
                PopulateXmlNodeFromModule(itemsModule, oldModuleNode);
                //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteItemsModules.config");
                SiteConfigurationManager.UpdateSiteItemsModules(XmlDoc);
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool DeleteModule(int moduleID)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteItemsModules/Module[@ModuleTypeID='" + moduleID + "']");
            if (nodesList.Count > 0)
            {
                foreach (XmlNode module in nodesList)
                {
                    XmlNode parentnode = module.ParentNode;
                    parentnode.RemoveChild(module);
                }
                //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs + "SiteItemsModules.config");
                SiteConfigurationManager.UpdateSiteItemsModules(XmlDoc);
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
    }

}