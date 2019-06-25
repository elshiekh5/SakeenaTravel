using System;
using System.Threading;
using System.Collections.Generic;
using System.Net.Mail;

using System.Text;



namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for EmailJob.
    /// </summary>
    public class EmailJob
    {
        private int Interval;
        private Timer emailTimet = null;
        public EmailJob()
        {
            Interval = SiteSettings.MailList_SendingIntervalBySeconds * 1000;
        }
        //-----------------------------------
        public void Start()
        {
            //Create a new timer to iterate over each job
            emailTimet = new Timer(new TimerCallback(call_back), null, 0, Interval);
        }
        //-----------------------
        private void call_back(object state)
        {
            emailTimet.Change(Timeout.Infinite, Timeout.Infinite);
            //
            TrySendingEmails();
            //
            emailTimet.Change(Interval, Interval);
        }

        //-----------------------
        public void Stop()
        {
            emailTimet.Dispose();
            emailTimet = null;
        }
        //-----------------------
        /// <summary>
        /// this method gets all the emails from db that is ready to be sent and locks them for sending then try to send if fails increases the tries and id success deletes the row 
        /// </summary>
        private void TrySendingEmails()
        {
            List<MailListEmailsEntity> mailsList = MailListEmailsFactory.GetAll();
            foreach (MailListEmailsEntity mail in mailsList)
            {
                int id = mail.MailID;
                int mailMaxNoOfTries = Convert.ToInt32(SiteSettings.MailList_MailMaxNoOfTries);
                if (mail.Trials < mailMaxNoOfTries)
                {
                    if (MailListEmailsFactory.ActualSend(mail)) MailListEmailsFactory.Delete(id);
                    else MailListEmailsFactory.IncreaseTrials(id);
                }
                else
                {
                    MailListEmailsFactory.Delete(id);
                }
            }
        }

    }

}