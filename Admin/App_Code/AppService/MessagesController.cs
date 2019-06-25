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
            MessagesModuleOptions currentMessageModule = MessagesModuleOptions.GetType(moduleTypeID);
            //Preparing admin notification email
            string mailBody = "<table style='width:auto; direction:" + Resources.Lang.Dir + "'>";
            MessagesEntity msg = new MessagesEntity();

            //-------------------------------------
            msg.ModuleTypeID = moduleTypeID;
            //--------------------------------------------------------------------------
            msg.Name = model.Name;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentMessageModule, "Name"), msg.Name);
            msg.EMail = model.Email;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentMessageModule, "Email"), msg.EMail);
            msg.Details = model.Message;
            mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentMessageModule, "Details"), model.Message);
            //-------------------------------------
            msg.LangID = SiteSettings.GetCurrentLanguage();
            bool createMessageFolder = (currentMessageModule.HasFileExtension || currentMessageModule.HasPhotoExtension || currentMessageModule.HasPhoto2Extension || currentMessageModule.HasVideoExtension || currentMessageModule.HasAudioExtension);
            bool status = MessagesFactory.Create(msg, createMessageFolder);
            if (status)
            {
                //-------------------------------------------------------------------------
                //RegisterInMailList
                if ((currentMessageModule.MailListAutomaticRegistration || (msg.HasEmailService)) && !string.IsNullOrEmpty(msg.EMail))
                    MessagesFactory.RegisterInMailList(msg);
                //------------------------------------------------------------------------
                //RegisterInSms
                if ((currentMessageModule.SmsAutomaticRegistration || (msg.HasSmsService)) && !string.IsNullOrEmpty(msg.Mobile))
                    MessagesFactory.RegisterInSms(msg);
                //------------------------------------------------------------------------
                //------------------------------------------------------------------------
                if (SiteSettings.Admininstration_HasAdminEmail)
                {
                    string subject = DynamicResource.GetMessageModuleText(currentMessageModule, "NewMessageRecieved");
                    SendMailToSiteAdmin(subject, mailBody);
                }
                //------------------------------------------------------------------------
                resultMessage = DynamicResource.GetMessageModuleText(currentMessageModule, "SendinogOperationDone");
            }
            else
            {
                resultMessage = DynamicResource.GetMessageModuleText(currentMessageModule, "SendinogOperationFaild");
            
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