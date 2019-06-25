using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
public partial class AdminCP_ItemsOrders_OrderData : System.Web.UI.UserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = Resources.Cities.CitiesModuleTitle;
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            int orderID = Convert.ToInt32(Request.QueryString["id"]);
            ItemsOrdersModel order = ItemsOrdersFactor.GetObject(orderID);
            if (orderID != null)
            {

                lblCustomerName.Text = order.CustomerName;
                lblCustomerEmail.Text = order.CustomerEmail;
                lblCustomerPhone.Text = order.CustomerPhone;
                lblCustomerMobile.Text = order.CustomerMobile;
                lblCustomerAddress.Text = order.CustomerAddress;
                lblDateAdded.Text = order.DateAdded.ToString();
                ddlOrderStatus.SelectedValue = order.Status.ToString();
                txtComment.Text = order.Comment;
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
    //-----------------------------------------------
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            if (!Page.IsValid)
            {
                return;
            }
            int orderID = Convert.ToInt32(Request.QueryString["id"]);
            ItemsOrdersModel order = ItemsOrdersFactor.GetObject(orderID);
            order.Status = Convert.ToInt32(ddlOrderStatus.SelectedValue);
            order.Comment = txtComment.Text;
            bool status = ItemsOrdersFactor.Updat(order);
            if (status)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.SavingDataFaild;
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
}