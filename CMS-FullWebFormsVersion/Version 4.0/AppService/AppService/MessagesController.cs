using DCCMSNameSpace;
using System;
using System.Data.Entity;
using System.Linq;


namespace AppService
{
    
    public class MessagesController
    {

        static string rowTemplate = "<tr><td><b>{0}</b></td>:<td>{1}</td></tr>";
        public static bool ContactUS(ContactUsModel model, out string resultMessage)
        {
            int moduleTypeID = 501;
            MessagesModuleOptions currentModule = MessagesModuleOptions.GetType(moduleTypeID);
            //Preparing admin notification email
            string mailBody = "<table style='width:auto; direction:" + Resources.Lang.Dir + "'>";
            MessagesEntity msg = new MessagesEntity();

            //-------------------------------------
            msg.ModuleTypeID = moduleTypeID;
            //--------------------------------------------------------------------------
            msg.Name = model.Name;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Name"), msg.Name);
            msg.EMail = model.Email;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Email"), msg.EMail);
            msg.Details = model.Message;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Details"), model.Message);
            //-------------------------------------
            msg.LangID = SiteSettings.GetCurrentLanguage();
            bool status = MessagesFactory.Create(msg);
            if (status)
            {
                //-------------------------------------------------------------------------
                //RegisterInMailList
                if ((currentModule.MailListAutomaticRegistration || (msg.HasEmailService)) && !string.IsNullOrEmpty(msg.EMail))
                    MessagesFactory.RegisterInMailList(msg);
                //------------------------------------------------------------------------
                //RegisterInSms
                if ((currentModule.SmsAutomaticRegistration || (msg.HasSmsService)) && !string.IsNullOrEmpty(msg.Mobile))
                    MessagesFactory.RegisterInSms(msg);
                //------------------------------------------------------------------------
                //------------------------------------------------------------------------
                if (SiteSettings.Admininstration_HasAdminEmail)
                {
                    string subject = DynamicResource.GetMessageModuleText(currentModule, "NewMessageRecieved");
                    SendMailToSiteAdmin(subject, mailBody);
                }
                //------------------------------------------------------------------------
                resultMessage = DynamicResource.GetMessageModuleText(currentModule, "SendinogOperationDone");
            }
            else
            {
                resultMessage = DynamicResource.GetMessageModuleText(currentModule, "SendinogOperationFaild");
            
            }
            return status;
        }

        //------------------------------------------------------------------------------------
       public static  void SendMailToSiteAdmin(string subject, string mailBody)
        {
            MailListEmailsEntity mail = new MailListEmailsEntity();
            //------------------------------------------------------------------------
            string to = SiteSettings.Admininstration_AdminEmail;
            mail.To.Add(to);
            //------------------------------------------------------------------------
            if (SiteSettings.Admininstration_HasAdminBccEmail)
            {
                string AdminbccMail = SiteSettings.Admininstration_AdminBccEmail;
                mail.Bcc.Add(AdminbccMail);
            }
            //------------------------------------------------------------------------
            mail.Subject = subject;
            //-------------------------------------
            mail.Body = mailBody;
            //------------------------------------------------------------------------
            mail.IsBodyHtml = true;

            MailListEmailsFactory.Send(mail);

        }
        //------------------------------------------------------------------------------------
    }

    
}