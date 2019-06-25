using System;
using System.Collections.Generic;

using System.Web;
using System.Text.RegularExpressions;
namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DCValidation
    /// </summary>
    public class DCValidation
    {
        static string NumberPattern = @"^\d*\.?\d*$|^-\d*\.?\d*$";
        static string PositiveNumber = @"^\d*\.?\d*$";
        static string NegativeNumber = @"^-\d*\.?\d*$";
        static string NegativeNumberWithPoint2 = @"^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$";
        static string PositiveNumberWithPoint2 = @"^-?[0-9]{0,2}(\.[0-9]{1,2})?$|^-?(100)(\.[0]{1,2})?$";
        static string IntegerNumber = @"^\d*$|^-\d*$";
        static string PositiveIntegerNumber = @"^\d*$";
        static string NegativeIntegerNumber = @"^-\d*$";
        static string EmailPattern = @"^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$";
        static string UrlPattern=@"(http|ftp|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,4}(/\S*)?$";

        #region ------------------------IsNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(NumberPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsPositiveNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsPositiveNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsPositiveNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(PositiveNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsNegativeNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsNegativeNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsNegativeNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(NegativeNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsNegativeNumberWithPoint2------------------------
        //-------------------------------------------------------------------------------------------
        //IsNegativeNumberWithPoint2
        //-------------------------------------------------------------------------------------------
        public static bool IsNegativeNumberWithPoint2(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(NegativeNumberWithPoint2, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion
        
        #region ------------------------IsPositiveNumberWithPoint2------------------------
        //-------------------------------------------------------------------------------------------
        //IsPositiveNumberWithPoint2
        //-------------------------------------------------------------------------------------------
        public static bool IsPositiveNumberWithPoint2(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(PositiveNumberWithPoint2, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsIntegerNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsIntegerNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsIntegerNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(IntegerNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion
        
        #region ------------------------IsPositiveIntegerNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsPositiveIntegerNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsPositiveIntegerNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(PositiveIntegerNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion
        
        #region ------------------------IsNegativeIntegerNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsNegativeIntegerNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsNegativeIntegerNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(NegativeIntegerNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsMobileNumber------------------------
        //-------------------------------------------------------------------------------------------
        //IsMobileNumber
        //-------------------------------------------------------------------------------------------
        public static bool IsMobileNumber(string numger)
        {
            if (string.IsNullOrEmpty(numger)) return false;
            Regex _regex = new Regex(PositiveIntegerNumber, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(numger);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsEmail------------------------
        //-------------------------------------------------------------------------------------------
        //IsEmail
        //-------------------------------------------------------------------------------------------
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            Regex _regex = new Regex(EmailPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(email);
        }
        //-------------------------------------------------------------------------------------------
        #endregion

        #region ------------------------IsUrl------------------------
        //-------------------------------------------------------------------------------------------
        //IsUrl
        //-------------------------------------------------------------------------------------------
        public static bool IsUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return false;
            Regex _regex = new Regex(UrlPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return _regex.IsMatch(url);
        }
        //-------------------------------------------------------------------------------------------
        #endregion


        //----------------------------------------------------------------
        public static string GetEmailExpression()
        {
            /* old pattern
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return strRegex;*/
            return EmailPattern;
        }
        /*old
        public static bool IsEmail(string Email)
        {
            string strRegex = GetEmailExpression();
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }*/
        public static string GetUrlExpression()
        {/* old pattern
            string strRegex = "^(https?://)"
             + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@ 
             + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184 
             + "|" // allows either IP or domain 
             + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www. 
             + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain 
             + "[a-z]{2,6})" // first level domain- .com or .museum 
             + "(:[0-9]{1,4})?" // port number- :80 
             + "((/?)|" // a slash isn't required if there is no file name 
             + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            return strRegex;*/
            return UrlPattern;
        }
        /*
        public static bool IsUrl(string Url)
        {
            string strRegex = GetUrlExpression();

            Regex re = new Regex(strRegex);

            if (re.IsMatch(Url))
                return (true);
            else
                return (false);
        }

        public static bool IsIntegerNumber(string number)
        {
            string strRegex = "\\d*";

            Regex re = new Regex(strRegex);

            if (re.IsMatch(number))
                return (true);
            else
                return (false);
        }*/
    }
}