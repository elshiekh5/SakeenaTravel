using System;
using System.Collections;
using System.Data;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of SMSCredit.
    /// </summary>
    public class SMSCreditFactory
    {
        public static DataTable GetAll()
        {
            return SMSCreditSqlDataPrvider.Instance.GetAllSMSCredit();
        }
        public static void Decrease()
        {
            SMSCreditSqlDataPrvider.Instance.Decrease();
        }
    }
}