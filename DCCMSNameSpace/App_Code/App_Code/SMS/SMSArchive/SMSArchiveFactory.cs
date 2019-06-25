using System;
using System.Collections;
using System.Data;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of SMSArchive.
    /// </summary>
    public class SMSArchiveFactory
    {

        /// <summary>
        /// Creates SMSArchive object by calling SMSArchive data provider create method.
        /// <example>[Example]bool result=SMSArchiveFactory.Create(sMSArchive);.</example>
        /// </summary>
        /// <param name="sMSArchive">The SMSArchive object.</param>
        /// <returns>The result of create operation.</returns>
        public static bool Create(SMSArchiveEntity sMSArchive)
        {
            return SMSArchiveSqlDataPrvider.Instance.Create(sMSArchive);
        }
        public static bool Create(string msg, string to, string snder, Languages langID)
        {
            SMSArchiveEntity smsen = new SMSArchiveEntity();
            smsen.LangID = langID;
            smsen.Message = msg;
            smsen.RecieverMobile = to;
            smsen.Sender = snder;
            return SMSArchiveSqlDataPrvider.Instance.Create(smsen);
        }
        //------------------------------------------
        /// <summary>
        /// Deletes single SMSArchive object .
        /// <example>[Example]bool result=SMSArchiveFactory.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The sMSArchive id.</param>
        /// <returns>The result of delete operation.</returns>
        public static bool Delete(int id)
        {
            return SMSArchiveSqlDataPrvider.Instance.Delete(id);
        }
        public static bool DeleteAll()
        {
            return SMSArchiveSqlDataPrvider.Instance.DeleteAll();
        }
        //------------------------------------------
        /// <summary>
        /// Gets All SMSArchive.
        /// <example>[Example]DataTable dtSMSArchive=SMSArchiveFactory.GetAll();.</example>
        /// </summary>
        /// <returns>All SMSArchive.</returns>
        public static DataTable GetAll()
        {
            return SMSArchiveSqlDataPrvider.Instance.GetAllSMSArchive();
        }
        //------------------------------------------
        /// <summary>
        /// Gets single SMSArchive object .
        /// <example>[Example]SMSArchiveEntity sMSArchive=SMSArchiveFactory.GetSMSArchiveObject(id);.</example>
        /// </summary>
        /// <param name="id">The sMSArchive id.</param>
        /// <returns>SMSArchive object.</returns>
        public static SMSArchiveEntity GetSMSArchiveObject(int id)
        {
            return SMSArchiveSqlDataPrvider.Instance.GetSMSArchiveObject(id);
        }
        //------------------------------------------
    }
}