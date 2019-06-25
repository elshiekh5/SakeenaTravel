using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for OurDropDownList
    /// </summary>
    public class OurLists
    {
        #region --------------LoadDataList()--------------
        //---------------------------------------------------------
        //LoadDataList
        //---------------------------------------------------------
        public static void LoadDataList<T>(List<T> list, DataList dl, string dataKeyField)
        {
            if (list != null && list.Count > 0)
            {
                dl.DataSource = list;
                dl.DataKeyField = dataKeyField;
                dl.DataBind();
                dl.Visible = true;
            }
            else
            {
                dl.Visible = false;

            }
        }
        public static void LoadDataList<T>(List<T> list, DataList dl, string dataKeyField, Label lblNoData)
        {
            if (list != null && list.Count > 0)
            {
                dl.DataSource = list;
                dl.DataKeyField = dataKeyField;
                dl.DataBind();
                dl.Visible = true;
                lblNoData.Visible = false;
            }
            else
            {
                dl.Visible = false;
                lblNoData.Visible = true;

            }
        }
        #endregion

        #region --------------Load Priority --------------
        //---------------------------------------------------------
        //Load Priority
        //---------------------------------------------------------
        public static void LoadPriorities(DropDownList ddl, int itemCount, bool AddIndex)
        {
            ddl.Items.Clear();
            if (AddIndex)
                ++itemCount;
            if (itemCount > 0)
            {

                for (int i = 1; i <= itemCount; i++)
                {
                    ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                ddl.SelectedIndex = ddl.Items.Count - 1;
                ddl.Enabled = true;
            }
            else
            {
                ddl.Items.Add(new ListItem("1", "1"));
                ddl.Enabled = true;


            }
        }
        //--------------------------------------------------------
        #endregion

    }
}
