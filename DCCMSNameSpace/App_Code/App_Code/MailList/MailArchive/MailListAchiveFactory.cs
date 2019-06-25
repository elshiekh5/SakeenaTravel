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



namespace DCCMSNameSpace
{
    public class MailListAchiveFactory
    {
        #region --------------Save--------------
        public static bool Save(MailListEmailsEntity mail)
        {
            if (mail.From == null)
            {
                string fromAddress = "";
                string fromName = "";

                fromAddress = SiteSettings.MailList_MailFrom;
                fromName = SiteSettings.MailList_MailFromName;
                mail.From = new MailAddress(fromAddress, fromName, Encoding.GetEncoding(1256));
            }
            return MailListAchiveSqlDataPrvider.Instance.Save(mail);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        public static bool Delete(int id)
        {
            bool status = MailListAchiveSqlDataPrvider.Instance.Delete(id);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<MailListEmailsEntity> GetAll()
        {
            int totalRecords = 0;
            return GetAll(-1, -1, out  totalRecords);
        }
        public static List<MailListEmailsEntity> GetAll(int pageIndex, int pageSize, out int totalRecords)
        {

            return MailListAchiveSqlDataPrvider.Instance.GetAll(pageIndex, pageSize, out  totalRecords);
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount()
        {

            return MailListAchiveSqlDataPrvider.Instance.GetCountMailListAchive();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static MailListEmailsEntity GetObject(int id)
        {
            MailListEmailsEntity mail = MailListAchiveSqlDataPrvider.Instance.GetObject(id);
            //return the object
            return mail;
        }
        //------------------------------------------
        #endregion
    }

}