using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{

    namespace ReadyUserControls
    {
        public partial class MailListSubsribe : ReadyUserControls.UserControl
        {
            ImageButton ibtnEmailSubscripe;
            RegularExpressionValidator rxvEmail;
            TextBox txtEMail;
            Label lblResult;
            //-----------------------------------------------------------
            protected void CatchControls()
            {
                lblResult = (Label)this.FindControl("lblResult");
                lblResult.Font.Bold = true;
                lblResult.ForeColor = Color.Blue;
                txtEMail = (TextBox)this.FindControl("txtEMail");
                rxvEmail = (RegularExpressionValidator)this.FindControl("rxvEmail");
                ibtnEmailSubscripe = (ImageButton)this.FindControl("ibtnEmailSubscripe");
            }
            //-----------------------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //-----------------------------------------------------------
                CatchControls();
                Prepare();
                //-----------------------------------------------------------
                lblResult.Text = "";
                if (!IsPostBack)
                {
                    ibtnEmailSubscripe.AlternateText = DynamicResource.GetText("MailList","SubscripeBtnText");
                    rxvEmail.Text = DynamicResource.GetText("MailList","InvalidEmail");
                    rxvEmail.ValidationExpression = DCValidation.GetEmailExpression();
                }
            }
            protected void ibtnEmailSubscripe_Click(object sender, ImageClickEventArgs e)
            {
                //-------------------------------------
                if (!Page.IsValid)
                    return;
                //-------------------------------------
                MailListUsersEntity mailListUsers;
                ExecuteCommandStatus status;
                Languages langID = SiteSettings.GetCurrentLanguage();

                mailListUsers = new MailListUsersEntity();
                mailListUsers.LangID = langID;
                //mailListUsers.Groups = groups;
                mailListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
                mailListUsers.Email = txtEMail.Text;
                status = MailListUsersFactory.Create(mailListUsers);

                if (status == ExecuteCommandStatus.Done)
                {
                    lblResult.CssClass = "operation_done";
                    lblResult.Text = DynamicResource.GetText("MailList","SubscripeDone");
                    // Clear controls;
                    txtEMail.Text = "";
                }
                else if (status == ExecuteCommandStatus.AllreadyExists)
                {
                    lblResult.CssClass = "operation_error";
                    lblResult.Text = DynamicResource.GetText("MailList","ExistsEmail");
                }
                else
                {
                    lblResult.CssClass = "operation_error";
                    lblResult.Text = DynamicResource.GetText("MailList","SubscripeFailed");
                }

            }

            protected void SendEmail(MailListUsersEntity user)
            {
                // prepare message
                string body = string.Format(DynamicResource.GetText("MailList","ActivationMailBody"), new string[3] { SitesHandler.GetSiteDomain(), Encryption.Encrypt(user.UserID.ToString()), user.Email });
                //string from =MailListEmailsFactory.MailFrom;
                MailListEmailsEntity mail = new MailListEmailsEntity();
                mail.Subject = DynamicResource.GetText("MailList","ActivationMailSubject");
                mail.Body = body;
                mail.To.Add(user.Email);
                MailListEmailsFactory.Send(mail);
            }
            //-------------------------------------------------------------------------------
    
        }
    }
}