using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

namespace DCCMSNameSpace
{
    public class General
    {
        public static string GetBoleanPhoto(object _value)
        {
            bool b_value = Convert.ToBoolean(_value);
            if (b_value)
                return "/Content/AdminDesign/Ar/css/images/Boolean/True.gif";
            else
                return "/Content/AdminDesign/Ar/css/images/Boolean/False.gif";
        }
        public static string SubstringByChars(object OriginalWord)
        {
            return SubstringByChars(OriginalWord.ToString());
        }
        public static string SubstringByChars(string OriginalWord)
        {
            return SubstringByChars(OriginalWord, 217);
        }
        public static string SubstringByWords(string OriginalWord, int length)
        {
            OriginalWord = OriginalWord.Replace("  ", " ");
            char[] arr = { ' ' };
            string[] summ = OriginalWord.Split(arr);
            string _Summ = "";
            for (int x = 0; x <= summ.Length - 1; x++)
            {
                if (x > length) break;
                _Summ += summ[x] + " ";
            }
            return _Summ;
        }
        public static string RemoveHTML(object htmlStrings)
        {
            string toBeCleared = htmlStrings.ToString();
            toBeCleared = Regex.Replace(toBeCleared, "<(.|\n)*?>", "");
            return Regex.Replace(toBeCleared, "&nbsp;", " ");
        }
        public static string RemoveHTML(string toBeCleared)
        {
            toBeCleared = Regex.Replace(toBeCleared, "<(.|\n)*?>", "");
            return Regex.Replace(toBeCleared, "&nbsp;", " ");
        }
        public static string SubstringByChars(string OriginalWord, int length)
        {
            char[] summ = OriginalWord.ToCharArray();
            string _Summ = "";
            for (int x = 0; x <= OriginalWord.Length - 1; x++)
            {
                if (x > length) break;
                _Summ += summ[x].ToString();
            }
            if (_Summ.Length > length)
            {
                _Summ = _Summ;
            }

            return _Summ;
        }

        public static string Clearstr(string str)
        {
            string String = str.Trim().Replace("'", "").Replace("[", "").Replace("%", "");//.Replace("_", "[_]");
            return String;
        }

        #region SubString

        public static string SubStringByWords(string statement, int length, bool setPoints)
        {
            statement = statement.Replace("  ", " ");
            char[] spliter = { ' ' };
            string[] words = statement.Split(spliter);
            string newStatement = "";
            if (words.Length < length)
                length = words.Length;
            for (int i = 0; i <= length - 1; i++)
            {
                newStatement += words[i] + " ";
            }
            if (statement.Length >= newStatement.Length)
            {
                if (setPoints)
                    newStatement = newStatement + "...";
            }
            return newStatement;
        }
        #region Substring
        //-----------------------------------------------
        public static string SubString(object OriginalWord, int length)
        {
            return SubString(OriginalWord.ToString(), length, false);
        }
        public static string SubString(object OriginalWord, int length, bool endOfWord)
        {
            return SubString(OriginalWord.ToString(), length, endOfWord);
        }
        public static string SubString(string OriginalWord, int length, bool endByWord)
        {
            return SubString(OriginalWord, length, 7, endByWord);
        }
        public static string SubString(string OriginalWord, int length, int oneWordCharacters, bool endByWord)
        {
            length = length * oneWordCharacters;
            string newString;
            if (OriginalWord.Length <= length)
            {
                newString = OriginalWord;
            }
            else
            {
                newString = OriginalWord.Remove(length);
                if (endByWord)
                {
                    int lastIndex = newString.LastIndexOf(' ');
                    if (lastIndex > 0)
                        newString = newString.Remove(lastIndex);
                }
                newString += "...";
            }
            return newString;
        }
        #endregion
        /*
        public static string SubStringByWordsRelly(string statement, int length)
        {
            statement = statement.Replace("  ", " ");
            char[] spliter = { ' ' };
            string[] words = statement.Split(spliter);
            string newStatement = "";
            if (words.Length < length)
                length = words.Length;
            for (int i = 0; i <= length - 1; i++)
            {
                newStatement += words[i] + " ";
            }
            if (statement.Length >= newStatement.Length)
            {
                newStatement = newStatement + "...";
            }
            return newStatement;
        }*/
        #endregion





        public static DateTime ConvertDateToHijri(DateTime dateConv)
        {
            return ConvertDateCalendar(dateConv, "Hijri", "ar-sa");
        }

        public static DateTime ConvertDateCalendar(DateTime dateConv, string calendar, string dateLangCulture)
        {
            DateTimeFormatInfo dTFormat;
            dateLangCulture = dateLangCulture.ToLower();
            if (calendar == "Hijri" && dateLangCulture.StartsWith("en-"))
            {
                dateLangCulture = "ar-sa";
            }
            dTFormat = new System.Globalization.CultureInfo(dateLangCulture, false).DateTimeFormat;
            switch (calendar)
            {
                case "Hijri":
                    dTFormat.Calendar = new System.Globalization.HijriCalendar();
                    break;

                case "Gregorian":
                    dTFormat.Calendar = new System.Globalization.GregorianCalendar();
                    break;
            }

            string day, month, year;
            dTFormat.ShortDatePattern = "dd";
            day = dateConv.Date.ToString("d", dTFormat);
            dTFormat.ShortDatePattern = "MM";
            month = dateConv.Date.ToString("d", dTFormat);
            dTFormat.ShortDatePattern = "yyyy";
            year = dateConv.Date.ToString("d", dTFormat);
            DateTime hijriDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            return hijriDate;
        }

        public static DateTime ConvertDateToHijri(DateTime dateConv, out string day, out string month, out string year)
        {
            string culture = "ar-sa";
            return ConvertDateCalendar(dateConv, "Hijri", culture, out  day, out  month, out  year);
        }
        public static DateTime ConvertDateToHijri(DateTime dateConv, out string day, out string month, out string year, string culture)
        {
            return ConvertDateCalendar(dateConv, "Hijri", culture, out  day, out  month, out  year);
        }
        public static string ConvertDateToHijri2(object date)
        {
            DateTime dateConv = Convert.ToDateTime(date);
            return ConvertDateToHijri2(dateConv, Languages.Ar);
        }
        public static string ConvertDateToHijri2(object date, Languages langID)
        {
            DateTime dateConv = Convert.ToDateTime(date);
            return ConvertDateToHijri2(dateConv, langID);
        }
        public static string ConvertDateToHijri2(DateTime dateConv)
        {

            return ConvertDateToHijri2(dateConv, Languages.Ar);
        }
        public static string ConvertDateToHijri2(DateTime dateConv, Languages langID)
        {
            string day, month, year;
            string culture = "ar-sa";
            if (langID == Languages.En)
                culture = "en-us";
            ConvertDateToHijri(dateConv, out day, out month, out year, culture);
            string s = day + "/" + month + "/" + year;
            return s;
        }

        public static DateTime ConvertDateCalendar(DateTime dateConv, string calendar, string dateLangCulture, out string day, out string month, out string year)
        {
            DateTimeFormatInfo dTFormat;
            dateLangCulture = dateLangCulture.ToLower();
            if (calendar == "Hijri" && dateLangCulture.StartsWith("en-"))
            {
                dateLangCulture = "ar-sa";
            }
            dTFormat = new System.Globalization.CultureInfo(dateLangCulture, false).DateTimeFormat;
            switch (calendar)
            {
                case "Hijri":
                    dTFormat.Calendar = new System.Globalization.HijriCalendar();
                    break;

                case "Gregorian":
                    dTFormat.Calendar = new System.Globalization.GregorianCalendar();
                    break;

            }


            // string day, month, year;
            dTFormat.ShortDatePattern = "dd";
            day = dateConv.Date.ToString("d", dTFormat);
            dTFormat.ShortDatePattern = "MM";
            month = dateConv.Date.ToString("d", dTFormat);
            dTFormat.ShortDatePattern = "yyyy";
            year = dateConv.Date.ToString("d", dTFormat);

            DateTime hijriDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

            dTFormat.ShortDatePattern = "MMMM";
            month = dateConv.Date.ToString("d", dTFormat);

            return hijriDate;
        }

        public static string ConvertDateToHijriToString(object dateConv)
        {
            string day, month, year;
            DateTime date = Convert.ToDateTime(dateConv);
            date = ConvertDateCalendar(date, "Hijri", "ar-sa", out  day, out  month, out  year);
            return day + "/" + month + "/" + year;
        }

        public static string GetGoogleMapKey()
        {
            //Key of http://www.dl.com.sa
            //return "ABQIAAAAmiAvVcuvADoeiezuhDP9LBQd6IXdq9Rz6Sa6pixZS2OgXk17KxQjBPwb_aTECYBrman5rJ0Ima90sg";
            //Key of http://Hr.dl.com.sa
            return "AIzaSyBl2VWGCFX-9danTalEWEojnWFhBGy9B2A";
        }

        public static Dimensions GetDimensions(string imageFilePhysicalPath)
        {
            try
            {
                Bitmap image = (Bitmap)Bitmap.FromFile(imageFilePhysicalPath, true);
                Dimensions dim = new Dimensions();
                dim.Height = image.Height.ToString();
                dim.Width = image.Width.ToString();
                FileInfo info = new FileInfo(imageFilePhysicalPath);
                dim.Size = info.Length.ToString();
                image.Dispose();
                return dim;
            }
            catch
            {
                return new Dimensions();
            }
        }

    }
}