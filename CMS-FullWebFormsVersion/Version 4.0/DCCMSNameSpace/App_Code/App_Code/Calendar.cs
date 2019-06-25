using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace DCCMSNameSpace
{
    public enum CalendarType
    {
        Unknowen,
        Gregorian,
        Islamic
    }

    public enum CalendarLang
    {
        Unknowen,
        en,
        ar
    }
    public enum CalendarAninmation
    {
        Unknowen,
        show,
        fadeIn,
        slideDown,
        blind,
        bounce,
        clip,
        drop,
        fold,
        slide
    }
    public enum CalendarAlignment
    {
        Unknowen,
        top,
        bottom,
        topLeft,
        topRight,
        bottomLeft,
        bottomRight
    }
    public enum CalendarFirstDay
    {
        Unknowen = -1,
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }

    //------------
    /*string CalendarYearRange
    string MinDate
    string MaxDate
    string DateFormat
    string AltFieldID
    string AltDateFormat
    //string Theme*/
    public enum CalendarEnable
    {

        Unknowen,
        enable,
        disable

    }
}