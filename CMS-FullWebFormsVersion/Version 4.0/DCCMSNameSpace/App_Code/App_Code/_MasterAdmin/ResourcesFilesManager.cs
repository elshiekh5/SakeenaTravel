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
using System.Resources;
namespace DCCMSNameSpace
{

    public class ResourcesFilesManager
    {
        public static string ModuleResourceFileArabic = "Modules.resx";
        public static string ModuleResourceFileEnglish = "Modules.en.resx";
        #region -----------------Context-----------------
        //-----------------------------------------------------------------
        private HttpContext _Context;
        public HttpContext Context
        {
            get
            {
                if (_Context == null)
                {
                    _Context = HttpContext.Current;
                }
                return _Context;
            }
        }
        #endregion

        #region -----------------ResourceFile-----------------
        //-----------------------------------------------------------------
        private  string _ResourceFile;
        public  string ResourceFile
        {
            get
            {
                return _ResourceFile;
            }
            set { _ResourceFile = value; }
        }
        #endregion

        #region -----------------PhysicalFile-----------------
        private string _PhysicalFile;
        public string PhysicalFile
        {
            get
            {
                if (_PhysicalFile==null)
                _PhysicalFile = DCServer.MapPath("/App_GlobalResources/_MasterAdmin/" + _ResourceFile);

                return _PhysicalFile;
            }
        }
        #endregion

        //-----------------------------------------------------
        public ResourcesFilesManager()
        {
           _ResourceFile= "Modules.resx";
           LoadResourceFile();
        }
        //-----------------------------------------------------

        public ResourcesFilesManager(string filePath)
        {
            _ResourceFile = filePath;

            LoadResourceFile();
        }

        private XmlDocument XmlDoc;
        
        //-----------------------------------------------------------------
        #region -----------------LoadResourceFile-----------------
        //-----------------------------------------------------------------
        public void LoadResourceFile()
        {
            XmlDoc = new XmlDocument();
            XmlDoc.PreserveWhitespace = true;
            XmlDoc.Load(PhysicalFile);
         }
        #endregion

        #region -----------------AddAttribute-----------------
        //-----------------------------------------------------------------
        private void AddAttribute(XmlElement element, string name, object value)
        {
            XmlAttribute att = element.SetAttributeNode(name, "");
            att.InnerText = value.ToString();
            element.Attributes.Append(att);
        }
        #endregion


        //-----------------------------------------------------------------
        public bool SaveNode(string name, string _value)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/root/data[@name='" + name + "']");
            if (nodeList.Count == 0)
            {                //create node and add value
                XmlNode node = XmlDoc.CreateNode(XmlNodeType.Element, "data", null);
                AddAttribute((XmlElement)node, "name", name);
                XmlAttribute e = XmlDoc.CreateAttribute("xml", "space", "http://www.w3.org/XML/1998/namespace");
                e.Value = "preserve";
                node.Attributes.Append(e);
               // AddAttribute((XmlElement)node, "xml:space", "preserve");
                //node.InnerText = "this is new node";
                //create title node
                XmlNode nodeValue = XmlDoc.CreateElement("value");
                //add value for it
                nodeValue.InnerText = _value;
                //------------------------------
                //add to parent node
                node.AppendChild(nodeValue);
                //add to elements collection
                XmlDoc.DocumentElement.AppendChild(node);
                //save back
                XmlDoc.Save(PhysicalFile);
                //------------------------------

                return true;
            }
            else
            {
                XmlNode oldNode = (XmlNode)nodeList[0];
                XmlNode nodeValue = oldNode.SelectNodes("value")[0];
                nodeValue.InnerText = _value;
                XmlDoc.Save(PhysicalFile);
                return true;
            }
            return false;
        }
        //------------------------------------------------------------------
        public string GetNodeValue(string name)
        {
            XmlNodeList nodeList = XmlDoc.SelectNodes("/root/data[@name='" + name + "']");
            if (nodeList.Count == 0)
            {

                return "";
            }
            else
            {
                XmlElement node = (XmlElement)nodeList[0];
                return node.InnerText.Trim();
            }
            
        }
        //------------------------------------------------------------------
        public bool DeleteNode(string name)
        {
            bool res = false;
            XmlNodeList nodeList = XmlDoc.SelectNodes("/root/data[@name='" + name + "']");
            foreach (XmlNode node in nodeList)
            {
                XmlNode parentnode = node.ParentNode;
                parentnode.RemoveChild(node);
            }
            XmlDoc.Save(PhysicalFile);
            res = true;

            return res;
        }

        //-----------------------------------------------------------------
        public static void SaveResourcesData(string moduleTitle,string arabicModuleTitle,string englishModuleTitle)
        {
            ResourcesFilesManager rfmArabic = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileArabic);
            ResourcesFilesManager rfmEnglish = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileEnglish);
            string arText = "";
            string enText = "";
            if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
            {
                arText = rfmArabic.GetNodeValue(moduleTitle);
                enText = rfmEnglish.GetNodeValue(moduleTitle);
                //----------------------------------------------------------
                //Clear text
                arText = GetClearText(arText);
                enText = GetClearText(enText);
                //----------------------------------------------------------
                if (arText.Trim() != arabicModuleTitle.Trim())
                {
                    rfmArabic.SaveNode(moduleTitle, arabicModuleTitle);
                }
                if (enText.Trim() != englishModuleTitle.Trim())
                {
                    rfmEnglish.SaveNode(moduleTitle, englishModuleTitle);
                }
            }
            else
            {
                rfmArabic.SaveNode(moduleTitle, arabicModuleTitle);
                rfmEnglish.SaveNode(moduleTitle, englishModuleTitle);
            }
        }
        //-----------------------------------------------------------------
        public static string GetClearText(string str)
        {

            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            return str;
        }
        //-----------------------------------------------------------------

    }

    
}