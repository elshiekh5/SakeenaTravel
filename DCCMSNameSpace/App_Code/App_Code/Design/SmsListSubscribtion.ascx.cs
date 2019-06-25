using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class SmsListSubscribtion : ReadyUserControls.UserControl
        {
            //-----------------------------------------------
            TextBox txtMobileNo;
            Label lblResult;
            ImageButton ibtnSmsSubscripe;
            //-----------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                lblResult.Text = "";
                if (!IsPostBack)
                {
                }
            }

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                txtMobileNo = (TextBox)this.FindControl("txtMobileNo");
                lblResult = (Label)this.FindControl("lblResult");
                ibtnSmsSubscripe = (ImageButton)this.FindControl("ibtnSmsSubscripe");
            }
            //-----------------------------------------------
            #endregion

            protected void ibtnSmsSubscripe_Click(object sender, ImageClickEventArgs e)
            {
                //-------------------------------------
                if (!Page.IsValid)
                    return;
                //-------------------------------------
                if (txtMobileNo.Text.Trim() == "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "alert('" + DynamicResource.GetText("SMS","EnterNo") + "')", true);
                    return;
                }
                SMSNumbersEntity newNumber = new SMSNumbersEntity();
                newNumber.Numbers = txtMobileNo.Text;
                //newNumber.IsActive = true;
                ExecuteCommandStatus status = SMSNumbersFactory.Create(newNumber);
                if (status == ExecuteCommandStatus.Done)
                {
                    lblResult.CssClass = "operation_done";
                    lblResult.Text = DynamicResource.GetText("SMS","Done");
                    try
                    {
                        if ((SmsWebService.WebMethods.SendMessage(ConfigurationManager.AppSettings["SMSKey"], DynamicResource.GetText("SMS","Welcome"), txtMobileNo.Text)) != SmsWebService.SMSSendStatus.Sent)
                        {
                            //resultMsg += DynamicResource.GetText("SMS","Error");
                        }
                    }
                    catch { }
                    txtMobileNo.Text = "";

                }
                else if (status == ExecuteCommandStatus.AllreadyExists)
                {
                    lblResult.CssClass = "operation_error";
                    lblResult.Text = DynamicResource.GetText("SMS","ExistBefor");
                }
                else
                {
                    lblResult.CssClass = "operation_error";
                    lblResult.Text = DynamicResource.GetText("SMS","ExistBefor");
                }
            }
            protected void SubScribeToSmS()
            {

            }
        }
    }
}