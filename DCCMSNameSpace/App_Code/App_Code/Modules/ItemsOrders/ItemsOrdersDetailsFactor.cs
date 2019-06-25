using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DCCMSNameSpace
{   
    /// <summary>
    /// The factory class of ItemsOrdersDetailsModel.
    /// </summary>
    public class ItemsOrdersDetailsFactor
    {

        #region --------------Create--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates model object by calling News data provider create method.
        /// </summary>
        /// <param name="ItemsOrdersDetailsObj">The model object.</param>
        /// <returns>The result of create operation.</returns>
        //--------------------------------------------------------------------
        public static bool Create(ItemsOrdersDetailsModel ItemsOrdersDetailsObj)
        {
            return ItemsOrdersDetailsSqlDataPrvider.Instance.Create(ItemsOrdersDetailsObj);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------Updat--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates model object by calling sql data provider update method.
        /// </summary>
        /// <param name="ItemsOrdersDetailsObj">The model object.</param>
        /// <returns>The result of update operation.</returns>
        //--------------------------------------------------------------------
        public static bool Updat(ItemsOrdersDetailsModel ItemsOrdersDetailsObj)
        {
            return ItemsOrdersDetailsSqlDataPrvider.Instance.Updat(ItemsOrdersDetailsObj);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------Delete--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes single model object .
        /// </summary>
        /// <param name="ItemID">The model id.</param>
        /// <returns>The result of delete operation.</returns>
        //--------------------------------------------------------------------
        public static bool Delete(int ItemID)
        {
            return ItemsOrdersDetailsSqlDataPrvider.Instance.Delete(ItemID);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------GetPageByPage--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific records.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        //--------------------------------------------------------------------
        public static List<ItemsOrdersDetailsModel> GetPageByPage(int OrderID,int pageIndex, int pageSize, out int totalRecords)
        {
            return ItemsOrdersDetailsSqlDataPrvider.Instance.GetPageByPage(OrderID,pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------Get--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific records.
        /// </summary>
        /// <param name="ItemID">The model id.</param>
        /// <returns>Model object.</returns>
        //--------------------------------------------------------------------
        public static List<ItemsOrdersDetailsModel> Get(int orderID)
        {
            return ItemsOrdersDetailsSqlDataPrvider.Instance.Get(orderID);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
    }
}