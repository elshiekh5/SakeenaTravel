using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;
using System.IO;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SMS
    /// </summary>
    public class SMS
    {

        public SMS()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static bool isArabic(string val)
        {
            string str = "œÃÕŒÂ⁄€›ﬁÀ’÷ÿﬂ„‰ «·»Ì”‘Ÿ“Ê…Ï·«—ƒ¡∆≈·≈√·√¬·¬";

            for (int i = 0; i < val.Length; i++)
            {
                if (str.IndexOf(val.Substring(i, 1)) != -1)
                {
                    return true;
                }
            }

            return false;
        }
        public static string GetBalance()
        {
            return GetABHttpRequest();


        }
        public static int SendToURL(string url, string un, string pass, string nums, string sndr, string msg)
        {
            try
            {
                url = Encryption.Decrypt(url);
                WebRequest req = WebRequest.Create(url);
                string s1 = "mobile=" + un + "&password=" + pass + "&numbers=" + nums + "&sender=" + sndr + "&msg=" + ConvertToUnicode(msg) + "&applicationType=24";
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                byte[] byteArray = Encoding.UTF8.GetBytes(s1);
                req.ContentLength = byteArray.Length;
                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse resp = req.GetResponse();

                Stream s = resp.GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.ASCII);
                string doc = sr.ReadToEnd();

                return Convert.ToInt32(doc);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int SendMessage(string username, string password, string msg, string sender, string numbers)
        {

            return SendToURL(SmsSettings.URL, SmsSettings.UserName, SmsSettings.Password, numbers, sender, msg);
        }

        public static int SendMessage()
        {

            return SendToURL(SmsSettings.URL, SmsSettings.UserName, SmsSettings.Password, SmsSettings.Numbers, SmsSettings.Sender, SmsSettings.Message);
        }

        public static bool SendMessage(string msg, string numbers)
        {
            bool temp = false;

            int x = SendToURL(SmsSettings.URL, SmsSettings.UserName, SmsSettings.Password, numbers, SmsSettings.Sender, msg);
            if (x == 49)
            {
                temp = true;
            }
            return temp;
        }

        private static int sendEnglishMessage(string message)
        {
            //int t = SendMessage("<Your Username>", "<Your Password>", ConvertToUnicode(message), txtSender.Text, txtNumbers.Text);
            int t = SendMessage("<Your Username>", "<Your Password>", ConvertToUnicode(message), "", "");
            return (int)t;
            //ShowResult(t);
        }

        private static int sendArabicMessage(string message)
        {
            //int t = SendMessage("<Your Username>", "<Your Password>", ConvertToUnicode(message), txtSender.Text, txtNumbers.Text);
            int t = SendMessage("<Your Username>", "<Your Password>", ConvertToUnicode(message), "", "");
            return (int)t;
            //ShowResult(t);
        }

        public static string ShowResult(int val)
        {
            switch (val)
            {
                case 49: return "Message sent successfully";
                case 50: return "Your balance is zero";
                case 51: return "There is no enough credit";
                case 0: return "Error: Sending Message";
                default: return val.ToString();
            }
        }

        private static string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;

            for (int i = 0; i < val.Length; i++)
            {
                msg2 += convertToUnicode(System.Convert.ToChar(val.Substring(i, 1)));
            }

            return msg2;
        }

        private static string convertToUnicode(char ch)
        {
            System.Text.UnicodeEncoding class1 = new System.Text.UnicodeEncoding();
            byte[] msg = class1.GetBytes(System.Convert.ToString(ch));

            return fourDigits(msg[1] + msg[0].ToString("X"));
        }

        private static string fourDigits(string val)
        {
            string result = string.Empty;

            switch (val.Length)
            {
                case 1: result = "000" + val; break;
                case 2: result = "00" + val; break;
                case 3: result = "0" + val; break;
                case 4: result = val; break;
            }

            return result;
        }

        public static int DCSendSMS(string message)
        {
            if (isArabic(message))
            {
                return sendArabicMessage(message);
            }
            else
            {
                return sendEnglishMessage(message);
            }
        }

        //Diver

        public static string GetABHttpRequest()
        {

            Stream aStream = null;
            try
            {
                int timeOut = 10000;
                //get timeOut from config if exists

                //Send POST request AB asp web page
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.mobily.ws/api/balance.php?mobile=" + SmsSettings.UserName + "&password=" + SmsSettings.Password);

                req.Method = "Get";
                req.ContentType = "text/html";

                req.Credentials = CredentialCache.DefaultCredentials;


                // Create The Response Object And Fill It By Sending The Request;
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                aStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(aStream);

                StringBuilder sbOutput = new StringBuilder();

                char[] buffer = new char[1024];

                int r;
                while ((r = sr.Read(buffer, 0, buffer.Length)) > 0)
                    sbOutput.Append(buffer, 0, r);

                return sbOutput.ToString();
            }
            catch (WebException ex)
            {
                //TODO: handle exception
            }
            catch (Exception ex)
            {
                //TODO: handle exception
            }
            finally
            {
                aStream.Close();
            }

            return string.Empty;
        }


        //Diver
    }
}