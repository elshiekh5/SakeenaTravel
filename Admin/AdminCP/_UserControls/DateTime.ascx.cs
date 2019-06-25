using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class UserControls_DateTime : System.Web.UI.UserControl
{
    int day;
    int month;
    int year;
    int hours;
    int minutes;

    private DateTime _Date=DateTime.MinValue;
    private DateConditions _DateCondition = DateConditions.Unlimitid;
    public DateConditions DateCondition
    {
        get
        {
            return _DateCondition;
        }
        set 
        {
            _DateCondition = value;
        }
    }
    public DateTime Date 
    {
        get
        {
            if (day == 0)
            {
                if (IsValid)
                {
                    _Date = new DateTime(year, month, day,hours,minutes,0);
                    return _Date;
                }
                else
                {
                    return _Date;
                }
            }
            else
                _Date = new DateTime(year, month, day, hours, minutes, 0);
                    return _Date;
        }
        set 
        {
            _Date = value;
            ddlDay.SelectedValue=_Date.Day.ToString();
            ddlMonth.SelectedValue=_Date.Month.ToString();
            txtYear.Text=_Date.Year.ToString();
            DdlHours.SelectedValue = _Date.Hour.ToString();
            DdlMinutes.SelectedValue = _Date.Minute.ToString();

        }
    }

    private string _DateString = "";
    public string DateString
    {
        get
        {
            if (day == 0)
            {
                if (IsValid)
                {
                    _DateString = day + "-" + month + "-" + year + "-" + hours + "-" + minutes;
                    return _DateString;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                _DateString = day + "-" + month + "-" + year + "-" + hours + "-" + minutes;
            }
            return _DateString;
        }
        
    }
    private bool _IsValid = false;
    public bool IsValid
    {
        get
        {
            try
            {
                if (!Page.IsValid)
                    throw new Exception(); 
                day = Convert.ToInt32(ddlDay.SelectedValue);
                month = Convert.ToInt32(ddlMonth.SelectedValue);
                year = Convert.ToInt32(txtYear.Text);
                hours = Convert.ToInt32(DdlHours.SelectedValue);
                minutes = Convert.ToInt32(DdlMinutes.SelectedValue);

                switch (DateCondition)
                {
                    //case DateConditions.Unlimitid:
                    //    break;
                    case DateConditions.EqualNow:
                        if (DateTime.Compare(Date, DateTime.Now) != 0)
                            throw new Exception();
                        break;
                    case DateConditions.GreaterThanNow:
                        if (DateTime.Compare(Date, DateTime.Now) <= 0)
                            throw new Exception();
                        break;
                    case DateConditions.LessThanNow:
                        if (DateTime.Compare(Date, DateTime.Now) >= 0)
                            throw new Exception();
                        break;
                    default:
                        break;
                }
               
                //----------------
                if ((month == 2 || month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                    throw new Exception();
                //----------------
                if (month == 2 && day > 29)
                    throw new Exception();
                //----------------
                if (month == 2 && (year % 4 > 0) && day > 28)
                    throw new Exception();
                //----------------
                lblResult.Text = "";
                return true;

            }
            catch (Exception ex)
            {

                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.InvalidDate;
                return false;
            }
        }
        set { _IsValid=value; }
    }
    private string _ValidationGroup = "";
    public string ValidationGroup
    {
        get { return _ValidationGroup; }
        set { _ValidationGroup = value; }
    }

     private bool _Enabled = true;
     public bool Enabled
     {
         get
         {
             return _Enabled;
         }
         set
         {
             _Enabled = value;
         }
     }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ValidationGroup--------------------
            ddlDay.ValidationGroup = ValidationGroup;
            ddlMonth.ValidationGroup = ValidationGroup;
            txtYear.ValidationGroup = ValidationGroup;
            DdlHours.ValidationGroup = ValidationGroup;
            DdlMinutes.ValidationGroup = ValidationGroup;
            rfvDay.ValidationGroup = ValidationGroup;
            rfvMonth.ValidationGroup = ValidationGroup;
            rfvYear.ValidationGroup = ValidationGroup;
            RFVHours.ValidationGroup = ValidationGroup;
            RFVMinutes.ValidationGroup = ValidationGroup;

            //Enabled------------------
            ddlDay.Enabled = Enabled;
            ddlMonth.Enabled = Enabled;
            txtYear.Enabled = Enabled;
            DdlHours.Enabled = Enabled;
            DdlMinutes.Enabled = Enabled;
            rfvDay.Enabled = Enabled;
            rfvMonth.Enabled = Enabled;
            rfvYear.Enabled = Enabled;
            RFVHours.Enabled = Enabled;
            RFVMinutes.Enabled = Enabled;

        }
    }
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    public void ClearControls()
    {
        txtYear.Text = "";
        ddlDay.SelectedIndex = -1;
        ddlMonth.SelectedIndex = -1;
        DdlHours.SelectedIndex = -1;
        DdlMinutes.SelectedIndex = -1;
    }
    //--------------------------------------------------------
    #endregion
}

