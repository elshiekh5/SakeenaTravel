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
    public class OurDropDownList
    {
        #region --------------Load_ddl()--------------
        //---------------------------------------------------------------------------   

        //---------------------------------------------------------------------------
        public static void LoadDropDownList<T>(List<T> list, DropDownList ddl, string testFeild, string valueFeild, bool addChoose)
        {
            LoadDropDownList<T>(list, ddl, testFeild, valueFeild, addChoose, -1);
        }
        //---------------------------------------------------------------------------
        public static void LoadDropDownList<T>(List<T> list, DropDownList ddl, string testFeild, string valueFeild, bool addChoose, int chooseID)
        {
            if (list != null && list.Count > 0)
            {
                ddl.DataSource = list;
                ddl.DataTextField = testFeild;
                ddl.DataValueField = valueFeild;
                ddl.DataBind();
                if (addChoose)
                    ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("User","Choose"), chooseID.ToString()));
                ddl.Enabled = true;
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("User","NoData"), chooseID.ToString()));
                ddl.Enabled = false;
            }
        }

        //---------------------------------------------------------------------------
        public static void LoadDropDownList(DataTable dt, DropDownList ddl, string testFeild, string valueFeild, bool addChoose, int chooseValue)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = testFeild;
                ddl.DataValueField = valueFeild;
                ddl.DataBind();
                if (addChoose)
                    ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","Choose"), chooseValue.ToString()));
                ddl.Enabled = true;
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","ThereIsNoData"), chooseValue.ToString()));
                ddl.Enabled = false;
            }
        }

        //---------------------------------------------------------------------------
        public static void LoadDropDownList(DataView dv, DropDownList ddl, string testFeild, string valueFeild, bool addChoose)
        {
            if (dv != null && dv.Count > 0)
            {
                ddl.DataSource = dv;
                ddl.DataTextField = testFeild;
                ddl.DataValueField = valueFeild;
                ddl.DataBind();
                if (addChoose)
                    ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","Choose"), "-1"));
                ddl.Enabled = true;
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","ThereIsNoData"), "-1"));
                ddl.Enabled = false;
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------Load Priority --------------
        //---------------------------------------------------------------------------
        //Load Priority
        //---------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------

        #endregion
    }

}