using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using MoversFW;
using FredCK.FCKeditorV2;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for AdminDefaultPage
    /// </summary>
    public abstract class AdminAddEditPage : AdminMasterPage
    {
        protected PagesTypes pageType = PagesTypes.AdminAdd;
        protected Label lblResult;
        protected Button btnSave;
        protected object dcObj;
        protected ExecuteCommandStatus status;

        #region ---------------FirstLoad---------------
        //-----------------------------------------------
        //FirstLoad
        //-----------------------------------------------
        protected void FirstLoad(Label lblResult, Button btnSave)
        {
            this.lblResult = lblResult;
            this.btnSave = btnSave;
            //-------------------------
            lblResult.Text = "";
            //Get page type
            if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
            {
                pageType = PagesTypes.AdminEdit;
            }

            if (!IsPostBack)
            {
                HandelControls();
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion


        #region ---------------LoadData---------------
        //-----------------------------------------------
        //LoadData
        //-----------------------------------------------
        protected virtual void LoadData()
        {
            if (pageType == PagesTypes.AdminEdit)
            {

                if (!LoadControls())
                    Response.Redirect("default.aspx");
            }

        }
        //-----------------------------------------------
        #endregion
        protected virtual void HandelControls() { }
        protected virtual bool LoadControls() { return false; }
        protected virtual object LoadObject() { return null; }
        protected abstract object SaveData();
        protected virtual void SaveFiles(object obj) { }

        #region ---------------btnSave_Click---------------
        //-----------------------------------------------
        //btnSave_Click
        //-----------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (pageType == PagesTypes.AdminEdit && !MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                Response.Redirect("default.aspx");

            if (!Page.IsValid)
            {
                return;
            }

            dcObj = SaveData();
            if (dcObj == null)
                return;

            if (status == ExecuteCommandStatus.Done)
            {
                SaveFiles(dcObj);
                if (pageType == PagesTypes.AdminEdit)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    lblResult.CssClass = "operation_done";
                    lblResult.Text = DynamicResource.GetText("AdminText","SavingDataSuccessfuly");
                    ClearControls();
                }

            }
            else if (status == ExecuteCommandStatus.AllreadyExists)
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText","DuplicateItem");
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText","SavingDataFaild");
            }

        }

        #endregion
        #region --------------ClearControls()--------------
        //---------------------------------------------------------
        //ClearControls()
        //---------------------------------------------------------
        protected virtual void ClearControls()
        {
            foreach (Control c in this.Controls)
            {
                ClearControl(c);
            }
        }
        //---------------------------------------------------------
        protected void ClearControl(Control c)
        {
            Type controlType = c.GetType();
            string s = controlType.FullName;
            if (c is TextBox)
            {
                TextBox txt = (TextBox)c;
                txt.Text = "";
            }
            else if (c is DropDownList)
            {
                DropDownList ddl = (DropDownList)c;
                ddl.SelectedIndex = -1;
            }
            else if (c is CheckBox)
            {
                CheckBox cb = (CheckBox)c;
                cb.Checked = false;
            }
            else if (c is FCKeditor)
            {
                FCKeditor editor = (FCKeditor)c;
                editor.Value = "";
            }

            if (c.HasControls())
            {
                foreach (Control child2 in c.Controls)
                {
                    ClearControl(child2);
                }
            }
        }
        //--------------------------------------------------------
        #endregion
    }
    public abstract class AdminAddEditUserControl : System.Web.UI.UserControl
    {
        protected PagesTypes pageType = PagesTypes.AdminAdd;
        protected Label lblResult;
        protected Button btnSave;
        protected object dcObj;
        protected ExecuteCommandStatus status;

        #region ---------------FirstLoad---------------
        //-----------------------------------------------
        //FirstLoad
        //-----------------------------------------------
        protected void FirstLoad(Label lblResult, Button btnSave)
        {
            this.lblResult = lblResult;
            this.btnSave = btnSave;
            //-------------------------
            lblResult.Text = "";
            //Get page type
            if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
            {
                pageType = PagesTypes.AdminEdit;
            }

            if (!IsPostBack)
            {
                HandelControls();
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion


        #region ---------------LoadData---------------
        //-----------------------------------------------
        //LoadData
        //-----------------------------------------------
        protected virtual void LoadData()
        {
            if (pageType == PagesTypes.AdminEdit)
            {

                if (!LoadControls())
                    Response.Redirect("default.aspx");
            }

        }
        //-----------------------------------------------
        #endregion
        protected virtual void HandelControls() { }
        protected virtual bool LoadControls() { return false; }
        protected virtual object LoadObject() { return null; }
        protected abstract object SaveData();
        protected virtual void SaveFiles(object obj) { }

        #region ---------------btnSave_Click---------------
        //-----------------------------------------------
        //btnSave_Click
        //-----------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (pageType == PagesTypes.AdminEdit && !MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                Response.Redirect("default.aspx");

            if (!Page.IsValid)
            {
                return;
            }

            dcObj = SaveData();
            if (dcObj == null)
                return;

            if (status == ExecuteCommandStatus.Done)
            {
                SaveFiles(dcObj);
                if (pageType == PagesTypes.AdminEdit)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    lblResult.CssClass = "operation_done";
                    lblResult.Text = DynamicResource.GetText("AdminText", "SavingDataSuccessfuly");
                    ClearControls();
                }

            }
            else if (status == ExecuteCommandStatus.AllreadyExists)
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText", "DuplicateItem");
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText", "SavingDataFaild");
            }

        }

        #endregion
        #region --------------ClearControls()--------------
        //---------------------------------------------------------
        //ClearControls()
        //---------------------------------------------------------
        protected virtual void ClearControls()
        {
            foreach (Control c in this.Controls)
            {
                ClearControl(c);
            }
        }
        //---------------------------------------------------------
        protected void ClearControl(Control c)
        {
            Type controlType = c.GetType();
            string s = controlType.FullName;
            if (c is TextBox)
            {
                TextBox txt = (TextBox)c;
                txt.Text = "";
            }
            else if (c is DropDownList)
            {
                DropDownList ddl = (DropDownList)c;
                ddl.SelectedIndex = -1;
            }
            else if (c is CheckBox)
            {
                CheckBox cb = (CheckBox)c;
                cb.Checked = false;
            }
            else if (c is FCKeditor)
            {
                FCKeditor editor = (FCKeditor)c;
                editor.Value = "";
            }

            if (c.HasControls())
            {
                foreach (Control child2 in c.Controls)
                {
                    ClearControl(child2);
                }
            }
        }
        //--------------------------------------------------------
        #endregion
    }
    public abstract class MasterAdminAddEditPage : AdminAddEditPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Page.MasterPageFile = "~/AdminMaster/MasterAdmin.master";
        }
    }
}