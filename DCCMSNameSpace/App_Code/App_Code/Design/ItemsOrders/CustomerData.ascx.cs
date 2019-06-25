using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace DCCMSNameSpace.ReadyUserControls
{
    public class ItemsOrders_CustomerData : ReadyUserControls.UserControl
    {

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion
        Label lblName;
        Label lblEmail;
        Label lblTel;
        Label lblMobile;
        Label lblAddress;
        Label lblComment;

        TextBox txtName;
        TextBox txtEMail;
        TextBox txtTel;
        TextBox txtMobile;
        TextBox txtAddress;
        TextBox txtComment;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            if (!IsPostBack)
            {
                SetTexts();
                LoadData();
            }
        }
        //-----------------------------------------------------------
        protected void CatchControls()
        {
            lblName = (Label)this.FindControl("lblName");
            lblEmail = (Label)this.FindControl("lblEmail");
            lblTel = (Label)this.FindControl("lblTel");
            lblMobile = (Label)this.FindControl("lblMobile");
            lblAddress = (Label)this.FindControl("lblAddress");
            lblComment = (Label)this.FindControl("lblComment");

            txtName = (TextBox)this.FindControl("txtName");
            txtEMail = (TextBox)this.FindControl("txtEMail");
            txtTel = (TextBox)this.FindControl("txtTel");
            txtMobile = (TextBox)this.FindControl("txtMobile");
            txtAddress = (TextBox)this.FindControl("txtAddress");
            txtComment = (TextBox)this.FindControl("txtComment");
        }
        //-----------------------------------------------------------
        
        #region ---------------SetTexts---------------
        //-----------------------------------------------
        //SetTexts
        //-----------------------------------------------
        private void SetTexts()
        {
            //---------------------------------------------------------------------------------
            lblName.Text = DynamicResource.GetText("ItemsOrders", "CustomerName"); 
            lblEmail.Text = DynamicResource.GetText("ItemsOrders", "CustomerEmail"); 
            lblTel.Text = DynamicResource.GetText("ItemsOrders", "CustomerPhone"); 
            lblMobile.Text = DynamicResource.GetText("ItemsOrders", "CustomerMobile"); 
            lblAddress.Text = DynamicResource.GetText("ItemsOrders", "CustomerAddress"); 
            lblComment.Text = DynamicResource.GetText("ItemsOrders", "Comment"); 
            //---------------------------------------------------------------------------------
        }
        //-----------------------------------------------
        #endregion
        public void LoadData()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                MembershipUser user = Membership.GetUser(this.Page.User.Identity.Name);
                UsersDataEntity userData = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, OwnerID);
                if (userData != null)
                {
                    txtName.Text = userData.Name;
                    txtEMail.Text = userData.Email;
                    txtTel.Text = userData.Tel;
                    txtMobile.Text = userData.Mobile;
                    //txtAddress.Text = userData.Address;
                }
            }

        }
        public ItemsOrdersModel GerOrderData()
        {
            /*if (this.User.Identity.IsAuthenticated)
            {
                //MembershipUser user = Membership.GetUser(this.Page.User.Identity.Name);
                //UsersDataEntity userData = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, OwnerID);
                //ItemsOrdersModel order = new ItemsOrdersModel();
                //order.UserId = (Guid)user.ProviderUserKey;
            }*/

            ItemsOrdersModel order = new ItemsOrdersModel();
            order.UserId = Guid.Empty;
            order.CustomerName = txtName.Text;
            order.CustomerEmail = txtEMail.Text;
            order.CustomerPhone = txtTel.Text;
            order.CustomerMobile = txtMobile.Text;
            order.CustomerAddress = txtAddress.Text;
            order.Comment = txtComment.Text;
            return order;

        }
    }
}