using System;


using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

namespace DCCMSNameSpace.ReadyUserControls
{
    /// <summary>
    /// Summary description for ItemsGetAllBaseControl
    /// </summary>
    public class ItemsOrders_CategoryItems : ReadyUserControls.UserControl
    {
        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryID--------------
        private int _CategoryID = -1;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------CategoryName--------------
        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
        //------------------------------------------
        #endregion

        public ItemsModulesOptions currentModule;
        public DCSiteUrls siteUrls;
        public int totalRecords = 0;
        List<ItemsOrdersDetailsModel> CartList = null;


        Label lblResult;
        Repeater dlItems;
        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //-------------------------------------------------
            currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            lblResult.Text = "";
            //---------------------------------------------------------
            //Load Cart 
            //---------------------------------------------------------
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<ItemsOrdersDetailsModel>();
            }
            CartList = (List<ItemsOrdersDetailsModel>)Session["Cart"];
            //---------------------------------------------------------
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion

        //-----------------------------------------------------------
        protected void CatchControls()
        {
            lblResult = (Label)this.FindControl("lblResult");
            dlItems = (Repeater)this.FindControl("dlItems");
        }
        //-----------------------------------------------------------

        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public void LoadData()
        {
            List<ItemsEntity> itemsList = ItemsFactory.GetAll(ModuleTypeID, CategoryID, true, OwnerID);
            int quant = 0;
            foreach (ItemsEntity item in itemsList)
            {
                quant =CheckQuant(item.ItemID);
                item.MailBox=quant.ToString();
                item.ZipCode = (Convert.ToInt32(item.Price) * quant).ToString() ;
            }
            if (itemsList != null && itemsList.Count > 0)
            {
                dlItems.DataSource = itemsList;
                dlItems.DataBind();
                dlItems.Visible = true;
                //lblResult.Visible = false;
            }
            else
            {
                this.Visible = false;
            }
        }
        //--------------------------------------------------------
        #endregion
        public List<ItemsOrdersDetailsModel> GetSelectedList()
        {
            int ItemID; int Quantity;
            TextBox txtQuant;
            HtmlInputHidden hdnID;
            HtmlInputHidden hdnPrice;
            Label lblTitle;
            ItemsOrdersDetailsModel productRequest;
            List<ItemsOrdersDetailsModel> productsList = new List<ItemsOrdersDetailsModel>();


            foreach (RepeaterItem r in dlItems.Items)
            {
                try
                {
                    txtQuant = (TextBox)r.FindControl("txtQuant");
                    hdnID = (HtmlInputHidden)r.FindControl("hdnID");
                    hdnPrice = (HtmlInputHidden)r.FindControl("hdnPrice");
                    lblTitle = (Label)r.FindControl("lblTitle");
                    ItemID = Convert.ToInt32(hdnID.Value);
                        Quantity = 0;
                        if (!string.IsNullOrEmpty(txtQuant.Text))
                        {
                            try
                            {
                                Quantity = Convert.ToInt32(txtQuant.Text);
                            }
                            catch{ Quantity = 0;}
                        }
                    if (Quantity > 0)
                    {
                        productRequest = new ItemsOrdersDetailsModel();
                        productRequest.Price = hdnPrice.Value;
                        productRequest.ItemID = ItemID;
                        productRequest.Quantity = Quantity;
                        productRequest.Title = lblTitle.Text;
                        productsList.Add(productRequest);
                    }
                }
                catch { }
            }
            return productsList;

            /*
           bool result= ItemsOrdersFactor.Create(order, productsList);
           if (result)
           {
               lblResult.Text = Resources.Messages.SendinogOperationDone;
               dlItems.Visible = false;
               ibtnSend.Visible = false;
               SendMailToSiteAdmin(userData, productsList);

           }
           else
           {
               lblResult.Text = Resources.Messages.SendinogOperationFaild;
       
           }*/
        }
        public string GetText(object data)
        {
            string str = null;
            if (data != null)
                str = data.ToString();
            if (!string.IsNullOrEmpty(str))
                return str;
            else
                return "---";
        }
        public string BindQuant(object quant)
        {
            if (quant != null)
            {
                string quantString = quant.ToString();
                if (!string.IsNullOrEmpty(quantString) && quantString!="0")
                {
                    return quantString;
                }
            }
            return "";
        }
        private int CheckQuant(object id)
        {
            int itemID = (int)id;
            if (CartList != null)
            {
                foreach (ItemsOrdersDetailsModel p in CartList)
                {
                    if (p.ItemID == itemID)
                    {
                        return p.Quantity;
                    }
                }
            }
            return 0;
        }
    }
}