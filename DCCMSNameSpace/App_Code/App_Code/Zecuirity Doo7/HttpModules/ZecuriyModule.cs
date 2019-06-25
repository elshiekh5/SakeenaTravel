using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;


namespace DCCMSNameSpace
{
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for SecuriyModule
        /// </summary>
        public class ZecurityModule : IHttpModule
        {
            #region IHttpModule Members

            public void Dispose()
            {
            }

            public void Init(HttpApplication context)
            {
                context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            }

            void context_PreRequestHandlerExecute(object sender, EventArgs e)
            {
                Page page = HttpContext.Current.CurrentHandler as Page;
                if (page != null)
                {
                    page.PreInit += new EventHandler(page_PreInit);
                }
            }

            void page_PreInit(object sender, EventArgs e)
            {
                //-----------------------------------------------
                Page page = sender as Page;
                if (page == null) return;
                //-----------------------------------------------
                HttpContext context = HttpContext.Current;
                string currentPath = context.Request.Path;
                if (context.Items.Contains("RealPath"))
                {
                    currentPath = (string)context.Items["RealPath"];
                }
                //-----------------------------------------------
                CheckPath(currentPath, page, context);
                //-----------------------------------------------
            }

            public void CheckPath(string currentPath, Page page, HttpContext context)
            {
                string currentFolder = currentPath.Remove(currentPath.LastIndexOf("/") + 1).ToLower();
                if (isSafePath(currentPath)) return;
                if (HttpContext.Current.User.IsInRole(DCRoles.SiteOverallAdminsRoles)) return;
                List<Zecurity.Permission> permissions = Zecurity.ZecurityManager.GetAllUserPermissions(new Guid(Membership.GetUser(context.User.Identity.Name).ProviderUserKey.ToString()));
                if (permissions.Count == 0) RaiseErrorFlag();
                Zecurity.Permission folderPermission = permissions.Find(delegate(Zecurity.Permission p) { return currentFolder.ToLower().StartsWith(p.Path.ToLower()); });
                if (folderPermission == null) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("add.aspx"))
                    if (!folderPermission.Add) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("edit.aspx"))
                    if (!folderPermission.Edit) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("delete.aspx"))
                    if (!folderPermission.Delete) RaiseErrorFlag();
            }
            private void RaiseErrorFlag()
            {
                HttpContext.Current.Response.Redirect(SiteSettings.ZecurityErrorPagePath);
            }

            private bool isSafePath(string requestpath)
            {
                string loweredRequestPath = requestpath.ToLower();
                string unSafePathesString = SiteSettings.ZecurityUnSafePathes.ToLower();
                string lowerdAdminDefaultPage = SiteSettings.ZecurityAdminDefaultPage.ToLower();
                string lowerdErrorPagePath = SiteSettings.ZecurityErrorPagePath.ToLower();
                char[] splitter = { ',' };
                string[] unSafePathesArray = unSafePathesString.Split(splitter);
                foreach (string path in unSafePathesArray)
                {
                    if (loweredRequestPath.Contains(path) && loweredRequestPath != lowerdAdminDefaultPage && loweredRequestPath != lowerdErrorPagePath)
                        return false;
                }
                return true;


            }

            #endregion

            public void CheckPermessionForPage()
            {
                string currentPath = HttpContext.Current.Request.Path;
                string currentFolder = currentPath.Remove(currentPath.LastIndexOf("/") + 1).ToLower();
                if (isSafePath(currentPath)) return;
                //if (HttpContext.Current.User.IsInRole(DCRoles.SiteOverallAdminsRoles)) return;
                if (Roles.IsUserInRole(DCRoles.SiteOverallAdminsRoles)) return;
                List<Zecurity.Permission> permissions = Zecurity.ZecurityManager.GetAllUserPermissions(new Guid(Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString()));
                if (permissions.Count == 0) RaiseErrorFlag();
                Zecurity.Permission folderPermission = permissions.Find(delegate(Zecurity.Permission p) { return currentFolder.ToLower().StartsWith(p.Path.ToLower()); });
                if (folderPermission == null) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("add.aspx"))
                    if (!folderPermission.Add) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("edit.aspx"))
                    if (!folderPermission.Edit) RaiseErrorFlag();
                if (currentPath.ToLower().EndsWith("delete.aspx"))
                    if (!folderPermission.Delete) RaiseErrorFlag();
            }
        }

    }
}