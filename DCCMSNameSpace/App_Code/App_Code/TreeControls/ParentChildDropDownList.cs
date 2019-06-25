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
    public class ParentChildDropDownList
    {
        int categoriesDepth;
        DataTable dtSource = null;
        string parent;
        string child;
        string text;
        //--------------------------------------------------------------------------------
        public void DataBind(DropDownList ddlControl, int parentID, int depth, DataTable dtSource, string parent, string child, string text)
        {
            categoriesDepth = depth;
            this.dtSource = dtSource;
            this.parent = parent;
            this.child = child;
            this.text = text;
            BuildList(ddlControl, parentID);
        }
        //--------------------------------------------------------------------------------
        public void DataBind(DropDownList ddlControl, int depth, DataTable dtSource, string parent, string child, string text)
        {
            categoriesDepth = depth;
            this.dtSource = dtSource;
            this.parent = parent;
            this.child = child;
            this.text = text;
            BuildList(ddlControl);
        }
        //-------------------------------------------------------------------------------
        public void BuildList(DropDownList ddlControl)
        {
            BuildList(ddlControl, 0);
        }
        public void BuildList(DropDownList ddlControl, int parentID)
        {
            int noneParentID = 0;
            //-----------------------------------------------
            if (parentID > 0) noneParentID = parentID;
            //-----------------------------------------------
            string name = "";
            DataSet ds = new DataSet();
            ds.Tables.Add(dtSource);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(dbRow[parent]) == noneParentID)
                    dbRow[parent] = DBNull.Value;
            }
            ds.Relations.Add("ParentChildRelashion", ds.Tables[0].Columns[child], ds.Tables[0].Columns[parent]);

            foreach (DataRow dbRow in ds.Tables[0].Rows)
            {
                if (dbRow[parent] == DBNull.Value || Convert.ToInt32(dbRow[parent]) == 0)
                {
                    name = dbRow[text].ToString();
                    ddlControl.Items.Add(new ListItem(name, dbRow[child].ToString()));
                    PopulateItem(ddlControl, dbRow, 1);
                }
            }
        }
        //--------------------------------------------------------------------------------
        private void PopulateItem(DropDownList ddlControl, DataRow dbRow, int ParentDepth)
        {
            if (categoriesDepth == -1 || ParentDepth < categoriesDepth)
            {
                string name;
                foreach (DataRow childRow in dbRow.GetChildRows("ParentChildRelashion"))
                {
                    name = GetDepth(ParentDepth) + childRow[text];
                    ddlControl.Items.Add(new ListItem(name, childRow[child].ToString()));
                    PopulateItem(ddlControl, childRow, ParentDepth + 1);
                }

            }
        }
        //--------------------------------------------------------------------------------
        private string GetDepth(int ParentDepth)
        {
            string space = "";
            for (int i = 0; i < ParentDepth; i++)
            {
                space += "/__";
            }
            return space + "";
        }
        //--------------------------------------------------------------------------------
    }
}