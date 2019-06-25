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

    internal class SiteMessagesModulesManager
    {
       
        private XmlDocument XmlDoc;
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------
        
        //-----------------------------------------------------------------

        #region -----------------LoadAllModules-----------------
        //-----------------------------------------------------------------
        public void LoadAllModules(List<MessagesModuleOptions> SiteMessagesModulesList)
        {
            XmlDoc = SiteConfigurationManager.LoadSiteMessagesModulesConfig();
            XmlNodeList modulesXml = XmlDoc.SelectNodes("/SiteMessagesModules/Module");
            foreach (XmlNode messagesModule in modulesXml)
            {
                SiteMessagesModulesList.Add(PopulateModuleFromXmlNode(messagesModule));
            }
         }
        #endregion

       
        //-----------------------------------------------------------------
        #region -----------------PopulateModuleFromXmlNode-----------------
        //-----------------------------------------------------------------
        private MessagesModuleOptions PopulateModuleFromXmlNode(XmlNode node)
        {
            MessagesModuleOptions messagesModule = new MessagesModuleOptions();
            /****************************************************/
            //find all the public properties of list Type using reflection
            PropertyInfo[] piT = typeof(MessagesModuleOptions).GetProperties();
            // Get the Type object corresponding to MyClass.
            Type myType=typeof(MessagesModuleOptions);
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
                            myPropInfo.SetValue(messagesModule, Enum.Parse(myPropInfo.PropertyType, attr.Value), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        else
                        {
                            myPropInfo.SetValue(messagesModule, Convert.ChangeType(attr.Value, myPropInfo.PropertyType), null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(attr.Name);
                }
            }
            return messagesModule;
        }
        #endregion
        //-----------------------------------------------------------------
        #region -----------------PopulateXmlNodeFromModule-----------------
        //-----------------------------------------------------------------
        //PopulateXmlNodeFromModule
        //-----------------------------------------------------------------
        private XmlElement PopulateXmlNodeFromModule(MessagesModuleOptions messagesModule, XmlElement node)
        {
            MessagesModuleOptions defaultModule = new MessagesModuleOptions();
            /****************************************************/

            Type myType = typeof(MessagesModuleOptions);
            PropertyInfo[] piT = myType.GetProperties();
            object moduleValue;
            object defaultValue;
            foreach (PropertyInfo myPropInfo in piT)
            {
                if (myPropInfo.CanWrite)
                {
                    moduleValue = myPropInfo.GetValue(messagesModule, null);
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
        public bool SaveModule(MessagesModuleOptions messagesModule)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteMessagesModules/Module[@ModuleTypeID='" + messagesModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                return AddModule(messagesModule);
            }
            else
                return UpdateModule(messagesModule);
        }
        public  bool AddModule(MessagesModuleOptions messagesModule)
        {
            bool res = false;
            XmlNodeList nodeList = XmlDoc.SelectNodes("/SiteMessagesModules/Module[@ModuleTypeID='" + messagesModule.ModuleTypeID + "']");
            if (nodeList.Count == 0)
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                 XmlElement xmlNewModule = XmlDoc.CreateElement("Module");
                 xmlNewModule = PopulateXmlNodeFromModule(messagesModule, xmlNewModule);
                 XmlNode commonParent = XmlDoc.SelectSingleNode("/SiteMessagesModules");
                 commonParent.AppendChild(xmlNewModule);
                 //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteMessagesModules.config");
                 SiteConfigurationManager.UpdateSiteMessagesModules(XmlDoc);

                 //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool UpdateModule(MessagesModuleOptions messagesModule)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteMessagesModules/Module[@ModuleTypeID='" + messagesModule.ModuleTypeID + "']");
            if (nodesList.Count == 1)
            {

                XmlElement oldModuleNode = (XmlElement)nodesList[0];
                oldModuleNode.Attributes.RemoveAll();
                PopulateXmlNodeFromModule(messagesModule, oldModuleNode);
                //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs+"SiteMessagesModules.config");
                SiteConfigurationManager.UpdateSiteMessagesModules(XmlDoc);
                res = true;
            }
            return res;
        }
        //------------------------------------------------------------------
        public bool DeleteModule(int moduleID)
        {
            bool res = false;
            XmlNodeList nodesList = XmlDoc.SelectNodes("/SiteMessagesModules/Module[@ModuleTypeID='" + moduleID + "']");
            foreach (XmlNode module in nodesList)
            {
                XmlNode parentnode = module.ParentNode;
                parentnode.RemoveChild(module);
            }
            //XmlDoc.Save(DCServer.MapPath("~") + SiteDesign.ModulesOptionsConfigs + "SiteMessagesModules.config");
            SiteConfigurationManager.UpdateSiteMessagesModules(XmlDoc);
            res = true;
            return res;
        }
        //------------------------------------------------------------------
    }
}