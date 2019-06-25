using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ParentChildDropDownList
    /// </summary>
    public class ParentChildTree
    {
        int categoriesDepth;
        DataTable dtSource = null;
        string parent;
        string child;
        string text;
        string navigateUrl;
        string iconUrl;
        string imgUrl;
        public void DataBind(TreeView trCategories, int depth, DataTable dtSource, string parent, string child, string text, string navigateUrl, string iconUrl, string imgUrl)
        {
            categoriesDepth = depth;
            this.dtSource = dtSource;
            this.parent = parent;
            this.child = child;
            this.text = text;
            this.navigateUrl = navigateUrl;
            this.iconUrl = iconUrl;
            this.imgUrl = imgUrl;
            BuildTree(trCategories);
        }

        public void BuildTree(TreeView trCategories)
        {

            DataSet ds = new DataSet();
            ds.Tables.Add(dtSource);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dbRow[parent]) == 0)
                    dbRow[parent] = DBNull.Value;
            }
            ds.Relations.Add("ParentChildRelashion", ds.Tables[0].Columns[child], ds.Tables[0].Columns[parent]);
            string name = "";
            string navigateUrl = "";
            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (dbRow[parent] == DBNull.Value || Convert.ToInt32(dbRow[parent]) == 0)
                {
                    name = dbRow[text].ToString();
                    navigateUrl = string.Format(navigateUrl, dbRow[child].ToString());
                    TreeNode newNode = CreateNode(dbRow, null);
                    trCategories.Nodes.Add(newNode);
                    PopulateSubTree(dbRow, newNode, 1);
                }
            }
        }


        //------------------------------------------
        private void PopulateSubTree(DataRow dbRow, TreeNode node, int ParentDepth)
        {
            if (categoriesDepth == -1 || ParentDepth < categoriesDepth)
            {
                string name = "";
                foreach (DataRow childRow in dbRow.GetChildRows("ParentChildRelashion"))
                {
                    if (childRow.GetChildRows("ParentChildRelashion").Length > 0)
                        iconUrl = "";
                    else
                        iconUrl = "";
                    name = childRow[text].ToString();
                    TreeNode childNode = CreateNode(childRow, node);
                    node.ChildNodes.Add(childNode);
                    PopulateSubTree(childRow, childNode, ++ParentDepth);
                }
            }
        }
        private void PopulateParents(TreeNode node)
        {
            node.Expanded = true;
            TreeNode parentNode;
            while (node.Parent != null)
            {
                parentNode = node.Parent;
                parentNode.Expanded = true;
                node = parentNode;
            }
        }
        //------------------------------------------
        private TreeNode CreateNode(DataRow childRow, TreeNode parentNode)
        {
            string value = childRow[child].ToString();
            string text = childRow[this.text].ToString();

            HttpContext context = HttpContext.Current;
            TreeNode node = new TreeNode();
            node.Value = value;
            node.Text = text;
            node.ImageUrl = imgUrl;
            if (context.Request.QueryString[child] != null &&
                        context.Request.QueryString[child].Length > 0 &&
                        context.Request.QueryString[child] == value)
            {
                if (parentNode != null)
                {
                    PopulateParents(parentNode);
                }
                node.Expanded = true;
            }
            else
            {
                node.Expanded = false;
            }
            //----------------------------------
            if (navigateUrl.Length > 0)
            {
                node.NavigateUrl = string.Format(navigateUrl, value);
            }
            else
            {
                node.NavigateUrl = context.Request.Path + "#";
            }
            return node;
        }
        //------------------------------------------
    }
}