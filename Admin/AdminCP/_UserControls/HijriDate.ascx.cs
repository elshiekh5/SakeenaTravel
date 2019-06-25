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


public partial class UserControls_HijriDate : System.Web.UI.UserControl
{
    int day;
    int month;
    int year;

    private DateTime _Date=DateTime.MinValue;
    public DateTime Date 
    {
        get
        {
            if (day == 0)
            {
                if (IsValid)
                {
                    _Date = new DateTime(year, month, day);
                    return _Date;
                }
                else
                {
                    return _Date;
                }
            }
            else
                _Date = new DateTime(year, month, day);
                    return _Date;
        }
        set 
        {
            _Date = value;
            ddlDay.SelectedValue=_Date.Day.ToString();
            ddlMonth.SelectedValue=_Date.Month.ToString();
            ddlyear.SelectedValue=_Date.Year.ToString();

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
                year = Convert.ToInt32(ddlyear.SelectedValue);

               
               
               
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
            ddlyear.ValidationGroup = ValidationGroup;
            rfvDay.ValidationGroup = ValidationGroup;
            rfvMonth.ValidationGroup = ValidationGroup;
            rfvYear.ValidationGroup = ValidationGroup;

            //Enabled------------------
            ddlDay.Enabled = Enabled;
            ddlMonth.Enabled = Enabled;
            ddlyear.Enabled = Enabled;
            rfvDay.Enabled = Enabled;
            rfvMonth.Enabled = Enabled;
            rfvYear.Enabled = Enabled;
            //-------------------------
            LoadYears();

        }
    }
    //---------------------------------------------
    protected void LoadYears()
    {
        int currentYear = (DateTime.Now.Year)-585;
        int frist = currentYear-80;
        ListItem item;
        for (int i = currentYear ; i>=frist; i--)
        {
            item =new ListItem(i.ToString(),i.ToString());

            ddlyear.Items.Add(item);
        }
    }
    //----------------------------------------------
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    public void ClearControls()
    {
        ddlyear.SelectedIndex = -1;
        ddlDay.SelectedIndex = -1;
        ddlMonth.SelectedIndex = -1;
    }
    //--------------------------------------------------------
    #endregion
}

