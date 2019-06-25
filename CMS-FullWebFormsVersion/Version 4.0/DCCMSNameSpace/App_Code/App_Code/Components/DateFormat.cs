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
using System.Net.Mail;
using System.Threading;
using System.Text;
using System.Globalization;
using System.Web.Hosting;
using System.Xml;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DateFormat
    /// </summary>
    public class DateFormat
    {


        #region DateFormat
        public DateFormat()
        {
        }
        #endregion

        #region ArabicCal
        public static string ArabicCal()
        {
            return Hijri();
        }
        #endregion

        #region GetConfigSettings()
        private static int GetConfigSettings()
        {
            string path = DCServer.MapPath("/ConfigrationFiles/hijri.xml");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNode node = xDoc.SelectSingleNode("hijriDate/offset");

            int i = 0;
            int.TryParse(node.InnerText, out i);

            return i;
        }
        #endregion

        #region ArabicCalEn()
        public static string ArabicCalEn()
        {
            return HijriEn();
        }
        #endregion

        #region ArabicCalCustom
        public static string ArabicCalCustom(object date_Added, bool addEnglish)
        {
            return ArabicCalCustom((DateTime)date_Added, addEnglish);
        }
        public static string ArabicCalCustom(DateTime date_Added, bool addEnglish)
        {

            string hijridate = HijriCustom(date_Added);
            string gorgydate = date_Added.ToLongDateString().Replace(",", "");
            string fulldate = hijridate;
            if (addEnglish)
                fulldate = hijridate + " الموافق " + gorgydate + " م ";
            return fulldate;
        }
        #endregion

        #region EnglishCal
        public static string EnglishCal()
        {
            return GergEng();
        }
        #endregion

        #region EnglishCalCustom
        public static string EnglishCalCustom(DateTime date_Added)
        {
            return GergEngCustom(date_Added);
        }
        #endregion

        #region FrenshCal
        public static string FrenshCal()
        {
            return GergFrn();
        }
        #endregion

        #region  GergEng()
        public static string GergEng()
        {
            CultureInfo enCul = new CultureInfo(Culture.EnglishUSA);
            string greg = DateTime.UtcNow.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            return System.DateTime.UtcNow.ToString() + AIDate[2] + SwtichMonthOfYearEn(AIDate[1]) + AIDate[0] + "A.H";
        }
        #endregion

        #region GergEngCustom
        public static string GergEngCustom(DateTime date_Added)
        {
            CultureInfo enCul = new CultureInfo(Culture.EnglishUSA);
            string greg = date_Added.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            return date_Added.DayOfWeek.ToString() + " " + AIDate[2] + " " + SwtichMonthOfYearEn(AIDate[1]) + " " + AIDate[0];
        }
        #endregion

        #region GergFrn
        public static string GergFrn()
        {
            CultureInfo enCul = new CultureInfo(Culture.EnglishUSA);
            string greg = DateTime.UtcNow.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            return SwtichDaysOfWeakFr(System.DateTime.UtcNow.DayOfWeek.ToString()) + " " + AIDate[2] + " " + SwtichMonthOfYearFr(AIDate[1]) + " " + AIDate[0] + " A.H";
        }
        #endregion

        #region HijriNow()

        public static string HijriNow()
        {

            DateTime dt = System.DateTime.Now;


            // dt = dt.AddDays(i);

            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = dt.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " محرم ";
                        break;
                    case "02":
                        month = " صفر ";
                        break;
                    case "03":
                        month = " ربيع الأول ";
                        break;
                    case "04":
                        month = " ربيع الثانى ";
                        break;
                    case "05":
                        month = " جمادى الأولى ";
                        break;
                    case "06":
                        month = " جمادى الثانية ";
                        break;
                    case "07":
                        month = " رجب ";
                        break;
                    case "08":
                        month = " شعبان ";
                        break;
                    case "09":
                        month = " رمضان ";
                        break;
                    case "10":
                        month = " شوال ";
                        break;
                    case "11":
                        month = " ذو القعدة ";
                        break;
                    case "12":
                        month = " ذو الحجة ";
                        break;
                }
                int day = Convert.ToInt16(AIDate[2].ToString());
                if (day == 0)
                    day = 1;
                return day + month + AIDate[0] + "هـ";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion

        #region ToHijri
        public static string ToHijri(DateTime dt)
        {
            int i = GetConfigSettings();


            dt = dt.AddDays(i);

            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = dt.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " محرم ";
                        break;
                    case "02":
                        month = " صفر ";
                        break;
                    case "03":
                        month = " ربيع الأول ";
                        break;
                    case "04":
                        month = " ربيع الثانى ";
                        break;
                    case "05":
                        month = " جمادى الأولى ";
                        break;
                    case "06":
                        month = " جمادى الثانية ";
                        break;
                    case "07":
                        month = " رجب ";
                        break;
                    case "08":
                        month = " شعبان ";
                        break;
                    case "09":
                        month = " رمضان ";
                        break;
                    case "10":
                        month = " شوال ";
                        break;
                    case "11":
                        month = " ذو القعدة ";
                        break;
                    case "12":
                        month = " ذو الحجة ";
                        break;
                }
                int day = Convert.ToInt16(AIDate[2].ToString()) + 1;
                if (day == 0)
                    day = 1;
                return day + month + AIDate[0] + "هـ";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion

        #region Hijri()

        public static string Hijri()
        {
            int i = GetConfigSettings();
            DateTime dt = DateTime.Now.AddDays(i);


            //dt = dt.AddDays(i);

            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = dt.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " محرم ";
                        break;
                    case "02":
                        month = " صفر ";
                        break;
                    case "03":
                        month = " ربيع الأول ";
                        break;
                    case "04":
                        month = " ربيع الثانى ";
                        break;
                    case "05":
                        month = " جمادى الأولى ";
                        break;
                    case "06":
                        month = " جمادى الثانية ";
                        break;
                    case "07":
                        month = " رجب ";
                        break;
                    case "08":
                        month = " شعبان ";
                        break;
                    case "09":
                        month = " رمضان ";
                        break;
                    case "10":
                        month = " شوال ";
                        break;
                    case "11":
                        month = " ذو القعدة ";
                        break;
                    case "12":
                        month = " ذو الحجة ";
                        break;
                }
                int day = Convert.ToInt16(AIDate[2].ToString());
                if (day == 0)
                    day = 1;
                return day + month + AIDate[0] + "هـ";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion


        #region HijriEn
        public static string HijriEn()
        {
            int i = GetConfigSettings();

            DateTime dt = DateTime.Now;
            dt = dt.AddDays(i);

            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = dt.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " Moharam ";
                        break;
                    case "02":
                        month = " Safar ";
                        break;
                    case "03":
                        month = " Rabi Awal ";
                        break;
                    case "04":
                        month = " Rabi Alsani ";
                        break;
                    case "05":
                        month = " Gomada Awal  ";
                        break;
                    case "06":
                        month = " Gomada Alsani ";
                        break;
                    case "07":
                        month = " Ragab ";
                        break;
                    case "08":
                        month = " shaban ";
                        break;
                    case "09":
                        month = " Ramadan ";
                        break;
                    case "10":
                        month = " shawal ";
                        break;
                    case "11":
                        month = " Zo Alqeda ";
                        break;
                    case "12":
                        month = " Zo Alheja ";
                        break;
                }
                int day = Convert.ToInt16(AIDate[2].ToString()) + 1;
                if (day == 0)
                    day = 1;
                return System.DateTime.UtcNow.DayOfWeek.ToString() + "&nbsp;" + day + month + AIDate[0] + " A.H";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion

        #region ToHijriEn
        public static string ToHijriEn(DateTime dt)
        {
            int i = GetConfigSettings();

            dt = dt.AddDays(i);

            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = dt.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " Moharam ";
                        break;
                    case "02":
                        month = " Safar ";
                        break;
                    case "03":
                        month = " Rabi Awal ";
                        break;
                    case "04":
                        month = " Rabi Alsani ";
                        break;
                    case "05":
                        month = " Gomada Awal  ";
                        break;
                    case "06":
                        month = " Gomada Alsani ";
                        break;
                    case "07":
                        month = " Ragab ";
                        break;
                    case "08":
                        month = " shaban ";
                        break;
                    case "09":
                        month = " Ramadan ";
                        break;
                    case "10":
                        month = " shawal ";
                        break;
                    case "11":
                        month = " Zo Alqeda ";
                        break;
                    case "12":
                        month = " Zo Alheja ";
                        break;
                }
                int day = Convert.ToInt16(AIDate[2].ToString()) + 1;
                if (day == 0)
                    day = 1;
                return day + month + AIDate[0] + " A.H";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion

        #region HijriArMonth
        public static string HijriArMonth(string month)
        {
            switch (month)
            {
                case "01":
                    month = " محرم ";
                    break;
                case "02":
                    month = " صفر ";
                    break;
                case "03":
                    month = " ربيع الأول ";
                    break;
                case "04":
                    month = " ربيع الثانى ";
                    break;
                case "05":
                    month = " جمادى الأولى ";
                    break;
                case "06":
                    month = " جمادى الثانية ";
                    break;
                case "07":
                    month = " رجب ";
                    break;
                case "08":
                    month = " شعبان ";
                    break;
                case "09":
                    month = " رمضان ";
                    break;
                case "10":
                    month = " شوال ";
                    break;
                case "11":
                    month = " ذو القعدة ";
                    break;
                case "12":
                    month = " ذو الحجة ";
                    break;
            }
            return month;
        }
        #endregion

        #region HijriEnMonth
        public static string HijriEnMonth(string month)
        {
            switch (month)
            {
                case "01":
                    month = " Moharam ";
                    break;
                case "02":
                    month = " Safar ";
                    break;
                case "03":
                    month = " Rabi Awal ";
                    break;
                case "04":
                    month = " Rabi Alsani ";
                    break;
                case "05":
                    month = " Gomada Awal  ";
                    break;
                case "06":
                    month = " Gomada Alsani ";
                    break;
                case "07":
                    month = " Ragab ";
                    break;
                case "08":
                    month = " shaban ";
                    break;
                case "09":
                    month = " Ramadan ";
                    break;
                case "10":
                    month = " shawal ";
                    break;
                case "11":
                    month = " Zo Alqeda ";
                    break;
                case "12":
                    month = " Zo Alheja ";
                    break;
            }
            return month;
        }
        #endregion

        #region HijriCustom
        public static string HijriCustom(DateTime date_Added)
        {

            int i = GetConfigSettings();
            DateTime DayDate = date_Added;
            date_Added = date_Added.AddDays(i);
            CultureInfo arCul = new CultureInfo("ar-SA");
            string greg = DateTime.Now.AddDays(i).ToString("yyyy/MM/dd", arCul.DateTimeFormat);
            string hijri = greg, month = "";
            char[] arr = { '/' };
            string[] AIDate = hijri.Split(arr);
            try
            {
                switch (AIDate[1])
                {
                    case "01":
                        month = " محرم ";
                        break;
                    case "02":
                        month = " صفر ";
                        break;
                    case "03":
                        month = " ربيع الأول ";
                        break;
                    case "04":
                        month = " ربيع الثانى ";
                        break;
                    case "05":
                        month = " جمادى الأولى ";
                        break;
                    case "06":
                        month = " جمادى الثانية ";
                        break;
                    case "07":
                        month = " رجب ";
                        break;
                    case "08":
                        month = " شعبان ";
                        break;
                    case "09":
                        month = " رمضان ";
                        break;
                    case "10":
                        month = " شوال ";
                        break;
                    case "11":
                        month = " ذو القعدة ";
                        break;
                    case "12":
                        month = " ذو الحجة ";
                        break;
                }
                return SwtichDaysOfWeakAr(DayDate.DayOfWeek.ToString()) + "&nbsp;" + AIDate[2] + month + AIDate[0] + " هـ";
            }
            catch { return "<font color=red>لم يحدد"; }
        }
        #endregion


        #region SwtichDaysOfWeakAr
        public static string SwtichDaysOfWeakAr(string day)
        {
            string back = "";

            switch (day)
            {
                case "Saturday":
                    back = "السبت";
                    break;
                case "Sunday":
                    back = "الأحد";
                    break;
                case "Monday":
                    back = "الأثنين";
                    break;
                case "Tuesday":
                    back = "الثلاثاء";
                    break;
                case "Wednesday":
                    back = "الأربعاء";
                    break;
                case "Thursday":
                    back = "الخميس";
                    break;
                case "Friday":
                    back = "الجمعة";
                    break;
            }
            return back;
        }
        #endregion

        #region SwtichDaysOfWeakFr
        public static string SwtichDaysOfWeakFr(string day)
        {
            string back = "";

            switch (day)
            {
                case "Saturday":
                    back = "Samedi";
                    break;
                case "Sunday":
                    back = "Dimanche";
                    break;
                case "Monday":
                    back = "Lundi";
                    break;
                case "Tuesday":
                    back = "Mardi";
                    break;
                case "Wednesday":
                    back = "Mercredi";
                    break;
                case "Thursday":
                    back = "Jeudi";
                    break;
                case "Friday":
                    back = "Vendredi";
                    break;
            }

            return back;
        }
        #endregion

        #region SwtichMonthOfYearFr
        public static string SwtichMonthOfYearFr(string day)
        {
            string back = "";

            switch (day)
            {
                case "01":
                    back = "Janvier";
                    break;
                case "02":
                    back = "Février";
                    break;
                case "03":
                    back = "Lundi";
                    break;
                case "04":
                    back = "Avril";
                    break;
                case "05":
                    back = "Mai";
                    break;
                case "06":
                    back = "Juin";
                    break;
                case "07":
                    back = "Juillet";
                    break;
                case "08":
                    back = "Août";
                    break;
                case "09":
                    back = "Septembre";
                    break;
                case "10":
                    back = "Octobre";
                    break;
                case "11":
                    back = "Novembre";
                    break;
                case "12":
                    back = "Décembre";
                    break;
            }

            return back;
        }
        #endregion

        #region SwtichMonthOfYearEn
        public static string SwtichMonthOfYearEn(string day)
        {
            string back = "";

            switch (day)
            {
                case "01":
                    back = "January";
                    break;
                case "02":
                    back = "February";
                    break;
                case "03":
                    back = "March";
                    break;
                case "04":
                    back = "April";
                    break;
                case "05":
                    back = "May";
                    break;
                case "06":
                    back = "June";
                    break;
                case "07":
                    back = "July";
                    break;
                case "08":
                    back = "August";
                    break;
                case "09":
                    back = "Septembre";
                    break;
                case "10":
                    back = "October";
                    break;
                case "11":
                    back = "November";
                    break;
                case "12":
                    back = "December";
                    break;
            }

            return back;
        }
        #endregion

        #region SwtichMonthOfYearAr
        public static string SwtichMonthOfYearAr(string day)
        {
            string back = "";

            switch (day)
            {
                case "1":
                    back = "يناير";
                    break;
                case "2":
                    back = "فبراير";
                    break;
                case "3":
                    back = "مارس";
                    break;
                case "4":
                    back = "أبريل";
                    break;
                case "5":
                    back = "مايو";
                    break;
                case "6":
                    back = "يونيو";
                    break;
                case "7":
                    back = "يوليو";
                    break;
                case "8":
                    back = "أغسطس";
                    break;
                case "9":
                    back = "سبتمبر";
                    break;
                case "10":
                    back = "أكتوبر";
                    break;
                case "11":
                    back = "نوفمبر";
                    break;
                case "12":
                    back = "ديسمبر";
                    break;
            }
            return back;
        }
        #endregion
    }
}
