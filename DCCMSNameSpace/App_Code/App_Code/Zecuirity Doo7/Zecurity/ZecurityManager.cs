using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Web.Caching;
using System.Configuration;
using System.Web.Security;



namespace DCCMSNameSpace
{
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for ZecurityManager
        /// </summary>
        public class ZecurityManager
        {
            public static string UserName
            {
                get { return HttpContext.Current.User.Identity.Name.ToLower(); }
            }


            #region [ Document operations ]
            private static XmlDocument GetSecurityConfig()
            {
                XmlDocument xmlDoc;
                if (HttpContext.Current.Cache["SecurityConfig"] != null)
                    xmlDoc = (XmlDocument)HttpContext.Current.Cache["SecurityConfig"];
                else
                {
                    string path = DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath();
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);

                    CacheDependency dep = new CacheDependency(path);
                    HttpContext.Current.Cache.Insert("SecurityConfig", xmlDoc, dep);
                }
                return xmlDoc;
            }
            #endregion

            #region [ Groups operations ]
            public static bool AddGroup(Zecurity.Group group)
            {
                bool res = false;
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group[@Name='" + group.Name + "']");
                if (nodeList.Count == 0)
                {
                    //Group Attributes
                    XmlElement xmlNewGroup = xmlDoc.CreateElement("Group");
                    AddAttribute("ID", group.ID.ToString(), xmlNewGroup);
                    AddAttribute("Name", group.Name, xmlNewGroup);

                    //Adding Permissions
                    if (group.Permissions.Count > 0)
                    {
                        XmlElement xmlPermissions = xmlDoc.CreateElement("Permissions");
                        foreach (Zecurity.Permission permission in group.Permissions)
                        {
                            XmlElement xmlPermission = xmlDoc.CreateElement("Permission");
                            AddAttribute("ID", permission.ID.ToString(), xmlPermission);
                            AddAttribute("Path", permission.Path, xmlPermission);
                            AddAttribute("Add", permission.Add.ToString(), xmlPermission);
                            AddAttribute("Edit", permission.Edit.ToString(), xmlPermission);
                            AddAttribute("Delete", permission.Delete.ToString(), xmlPermission);
                            AddAttribute("Trusted", permission.Trusted.ToString(), xmlPermission);
                            AddAttribute("Name", permission.Name, xmlPermission);

                            xmlPermissions.AppendChild(xmlPermission);
                        }

                        xmlNewGroup.AppendChild(xmlPermissions);
                    }

                    //Preparing for Users
                    XmlElement xmlUsers = xmlDoc.CreateElement("Users");
                    xmlNewGroup.AppendChild(xmlUsers);

                    XmlNode commonParent = xmlDoc.SelectSingleNode("/Security/Groups");
                    commonParent.AppendChild(xmlNewGroup);

                    xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
                    res = true;
                }

                return res;
            }

            public static List<Zecurity.Group> GetAllGroups()
            {
                List<Zecurity.Group> res = new List<Zecurity.Group>();
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList groups = xmlDoc.SelectNodes("/Security/Groups/Group");
                foreach (XmlNode group in groups)
                {
                    res.Add(PopulateGroupFromXmlNode(group));
                }

                return res;
            }

            private static Zecurity.Group PopulateGroupFromXmlNode(XmlNode group)
            {
                Zecurity.Group res = new Zecurity.Group();
                res.ID = new Guid(group.Attributes["ID"].Value);
                res.Name = group.Attributes["Name"].Value;
                XmlNodeList permissions = group.SelectNodes("Permissions/Permission");
                if (permissions.Count > 0)
                {
                    res.Permissions = new List<Zecurity.Permission>();
                    foreach (XmlNode permission in permissions)
                    {
                        res.Permissions.Add(PopulatePermissionFromXmlNode(permission));
                    }
                }

                XmlNodeList users = group.SelectNodes("Users/User");
                if (users.Count > 0)
                {
                    res.Users = new List<Zecurity.User>();
                    foreach (XmlNode user in users)
                    {
                        res.Users.Add(PopulateUserFromXmlNode(user));
                    }
                }
                return res;
            }

            private static Zecurity.User PopulateUserFromXmlNode(XmlNode users)
            {
                Zecurity.User res = new Zecurity.User();
                res.ID = new Guid(users.Attributes["ID"].Value);
                return res;
            }

            private static Zecurity.Permission PopulatePermissionFromXmlNode(XmlNode permission)
            {
                Zecurity.Permission res = new Zecurity.Permission();

                res.ID = new Guid(permission.Attributes["ID"].Value);
                res.Path = permission.Attributes["Path"].Value;
                res.Add = Convert.ToBoolean(permission.Attributes["Add"].Value);
                res.Edit = Convert.ToBoolean(permission.Attributes["Edit"].Value);
                res.Delete = Convert.ToBoolean(permission.Attributes["Delete"].Value);
                res.Name = permission.Attributes["Name"].Value;
                //res.Trusted = Convert.ToBoolean(permission.Attributes["Trusted"].Value);

                return res;
            }

            private static void AddAttribute(string name, string value, XmlElement element)
            {
                XmlAttribute att = element.SetAttributeNode(name, "");
                att.InnerText = value;
                element.Attributes.Append(att);
            }

            public static bool DeleteGroup(Guid id)
            {
                bool res = false;
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group[@ID='" + id.ToString() + "']");
                if (nodeList.Count != 1)
                    return false;

                XmlNode parentNode = nodeList[0].ParentNode;

                try
                {
                    parentNode.RemoveChild(nodeList[0]);
                    res = true;
                }
                catch { }

                xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());

                return res;
            }

            public static Zecurity.Group GetGroupByID(Guid id)
            {
                Zecurity.Group res = null;
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group[@ID='" + id.ToString() + "']");
                if (nodeList.Count == 1)
                    res = PopulateGroupFromXmlNode(nodeList[0]);

                return res;
            }

            public static bool UpdateGroup(Zecurity.Group group)
            {
                bool res = false;
                try
                {
                    XmlDocument xmlDoc = GetSecurityConfig();
                    XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group[@ID='" + group.ID.ToString() + "']");
                    if (nodeList.Count == 1)
                    {
                        XmlNode xmlGroup = nodeList[0];
                        xmlGroup.Attributes["Name"].Value = group.Name;

                        XmlNode oldPermissions = xmlGroup.SelectNodes("Permissions")[0];
                        XmlNode newPermissions = xmlDoc.CreateNode(XmlNodeType.Element, "Permissions", "");
                        if (group.Permissions != null)
                        {
                            if (group.Permissions.Count > 0)
                            {
                                foreach (Zecurity.Permission permission in group.Permissions)
                                {
                                    XmlNode xmlPermission = xmlDoc.CreateNode(XmlNodeType.Element, "Permission", "");
                                    AddAttribute("ID", permission.ID.ToString(), xmlPermission);
                                    AddAttribute("Path", permission.Path, xmlPermission);
                                    AddAttribute("Add", permission.Add.ToString(), xmlPermission);
                                    AddAttribute("Edit", permission.Edit.ToString(), xmlPermission);
                                    AddAttribute("Delete", permission.Delete.ToString(), xmlPermission);
                                    AddAttribute("Trusted", permission.Trusted.ToString(), xmlPermission);
                                    AddAttribute("Name", permission.Name, xmlPermission);
                                    newPermissions.AppendChild(xmlPermission);
                                }
                            }
                        }

                        xmlGroup.ReplaceChild(newPermissions, oldPermissions);
                        xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
                        res = true;
                    }
                }
                catch { }

                return res;
            }

            private static void AddAttribute(string name, string value, XmlNode node)
            {
                XmlAttribute att = node.OwnerDocument.CreateAttribute(name);
                att.InnerText = value;
                node.Attributes.Append(att);
            }

            public static bool AddUserToGroup(Guid usrid, Guid groupid)
            {
                bool res = false;
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group[@ID='" + groupid.ToString() + "']");
                if (nodeList.Count == 1)
                {
                    XmlNode group = nodeList[0];
                    XmlNode users = group.SelectNodes("Users")[0];

                    XmlNode user = xmlDoc.CreateNode(XmlNodeType.Element, "User", "");
                    XmlAttribute att_usrid = xmlDoc.CreateAttribute("ID");
                    att_usrid.InnerText = usrid.ToString();
                    user.Attributes.Append(att_usrid);

                    users.AppendChild(user);

                    xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());

                    res = true;
                }

                return res;
            }

            public static void RemoveUserFromAllgroups(Guid id)
            {
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group/Users/User[@ID='" + id.ToString() + "']");

                foreach (XmlNode user in nodeList)
                {
                    XmlNode parentnode = user.ParentNode;
                    parentnode.RemoveChild(user);
                }

                xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
            }

            public static List<Zecurity.Group> GetGroupsByUser(Guid guid)
            {
                List<Zecurity.Group> res = new List<Zecurity.Group>();
                List<Zecurity.Group> groups = GetAllGroups();

                foreach (Zecurity.Group group in groups)
                {
                    if (group.Users == null)
                        continue;

                    if (group.Users.Exists(delegate(Zecurity.User p) { return p.ID.ToString() == guid.ToString(); }))
                        res.Add(group);
                }

                return res;
            }

            public static void UpdateUserGroups(Guid usrId, List<Guid> groupIds)
            {
                RemoveUserFromAllgroups(usrId);
                if (groupIds.Count == 0)
                    return;

                foreach (Guid groupid in groupIds)
                    AddUserToGroup(usrId, groupid);
            }

            public static List<Zecurity.Permission> GetAllUserPermissions(Guid guid)
            {
                List<Zecurity.Permission> res = new List<Zecurity.Permission>();

                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Groups/Group/Users/User[@ID='" + guid.ToString() + "']");
                foreach (XmlNode user in nodeList)
                {
                    XmlNode parentnode = user.ParentNode.ParentNode;
                    XmlNodeList permissions = parentnode.SelectNodes("Permissions/Permission");
                    foreach (XmlNode permission in permissions)
                    {
                        res.Add(PopulatePermissionFromXmlNode(permission));
                    }
                }
                return res;
            }
            #endregion

            #region [ Permissions operations ]

            public static bool UserCanExecuteCommand(CommandName commandName)
            {
                bool res = false;
                if (HttpContext.Current.User == null) return false;
                string userName = HttpContext.Current.User.Identity.Name;

                //---------------------------------------------------------------------------------
                if (HttpContext.Current.User.IsInRole(DCRoles.SiteOverallAdminsRoles)) return true;
                if (HttpContext.Current.User.IsInRole(DCRoles.SiteMasterAdmin)) return true;
                if (HttpContext.Current.User.IsInRole(DCRoles.SubAdminsRole)) return true;

                //---------------------------------------------------------------------------------
                HttpContext context = HttpContext.Current;
                string currentPath = context.Request.Path;
                if (context.Items.Contains("RealPath"))
                {
                    currentPath = (string)context.Items["RealPath"];
                }
                //------------------------------------------------------------------
                string currentfolder = currentPath.Remove(currentPath.LastIndexOf("/") + 1).ToLower();
                List<Zecurity.Permission> permissions = GetAllUserPermissions(new Guid(Membership.GetUser(userName).ProviderUserKey.ToString()));
                Zecurity.Permission folderPermission =
                    permissions.Find(delegate(Zecurity.Permission p) { return currentfolder.ToLower().StartsWith(p.Path.ToLower()); });
                if (folderPermission == null) return false;

                switch (commandName)
                {
                    case CommandName.Add:
                        if (folderPermission.Add) res = true;
                        break;
                    case CommandName.Edit:
                        if (folderPermission.Edit) res = true;
                        break;
                    case CommandName.Delete:
                        if (folderPermission.Delete) res = true;
                        break;
                    case CommandName.Trusted:
                        if (folderPermission.Trusted) res = true;
                        break;
                    default:
                        res = false;
                        break;
                }


                return res;
            }


            public static bool IsTrustedOrOverAllAdmin(CommandName cmd)
            {
                bool x = false;
                if ((UserCanExecuteCommand(cmd) && UserCanExecuteCommand(CommandName.Trusted)) || (Roles.IsUserInRole(UserName, DCRoles.SiteOverallAdminsRoles)))
                {
                    x = true;
                }
                return x;
            }
            #endregion

            #region [ Modules operations ]
            public static bool AddModule(Zecurity.Module module)
            {
                bool res = false;
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Security/Modules/Module[@ID='" + module.ID + "']");
                if (nodeList.Count == 0)
                {
                    //Module Attributes
                    XmlElement xmlNewModule = xmlDoc.CreateElement("Module");
                    AddAttribute("ID", module.ID.ToString(), xmlNewModule);
                    AddAttribute("Name", module.Name, xmlNewModule);
                    AddAttribute("Path", module.Path, xmlNewModule);
                    XmlNode commonParent = xmlDoc.SelectSingleNode("/Security/Modules");
                    commonParent.AppendChild(xmlNewModule);

                    xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
                    res = true;
                }

                return res;
            }
            public static List<Zecurity.Module> GetAllModules()
            {
                List<Zecurity.Module> res = new List<Zecurity.Module>();
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNodeList modules = xmlDoc.SelectNodes("/Security/Modules/Module");
                foreach (XmlNode module in modules)
                {
                    res.Add(PopulateModuleFromXmlNode(module));
                }


                return res;
            }

            private static Zecurity.Module PopulateModuleFromXmlNode(XmlNode module)
            {
                Zecurity.Module res = new Zecurity.Module();
                res.ID = module.Attributes["ID"].Value;
                res.Name = module.Attributes["Name"].Value;
                res.Path = module.Attributes["Path"].Value;
                return res;
            }
            #endregion

            public static void HideGridColumn(System.Web.UI.WebControls.DataGrid dg, CommandName cmd, int colNo)
            {
                if (!UserCanExecuteCommand(cmd))
                {
                    dg.Columns[colNo].Visible = false;

                }
            }
            public static void ClearDocument()
            {
                DeleteAllModules();
                DeleteAllGroups();
            }

            public static void DeleteAllGroups()
            {
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNode commonParent = xmlDoc.SelectSingleNode("/Security/Groups");
                commonParent.RemoveAll();
                xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
            }
            public static void DeleteAllModules()
            {
                XmlDocument xmlDoc = GetSecurityConfig();
                XmlNode commonParent = xmlDoc.SelectSingleNode("/Security/Modules");
                commonParent.RemoveAll();
                xmlDoc.Save(DCServer.MapPath("~") + DCSiteUrls.GetPath_ZecurityConfigurationPath());
            }


            public static bool CheckFolderPermission(string currentFolder)
            {
                // end by ame 
                // if (isSafePath(currentPath)) return;
                //---------------------------------------------------------------------------------
                if (HttpContext.Current.User.IsInRole(DCRoles.SiteOverallAdminsRoles)) return true;
                if (HttpContext.Current.User.IsInRole(DCRoles.SiteMasterAdmin)) return true;
                if (HttpContext.Current.User.IsInRole(DCRoles.SubAdminsRole)) return true;
                //---------------------------------------------------------------------------------
                List<Zecurity.Permission> permissions = ZecurityManager.GetAllUserPermissions(new Guid(Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString()));
                if (permissions.Count == 0) return false;

                Permission folderPermission = permissions.Find(delegate(Zecurity.Permission p) { return currentFolder.ToLower().StartsWith(p.Path.ToLower()); });
                ////by ame 
                //if (folderPermission == null) folderPermission = permissions.Find(delegate(Zecurity.Permission p) { return FormsFolder.ToLower() == p.Path.ToLower(); });
                //end ame
                if (folderPermission == null) return false;
                else
                    return true;
                //---------------------------------------------------------------------------------
            }

        }

        public enum CommandName
        {
            Add, Edit, Delete, Trusted
        }


    }
}