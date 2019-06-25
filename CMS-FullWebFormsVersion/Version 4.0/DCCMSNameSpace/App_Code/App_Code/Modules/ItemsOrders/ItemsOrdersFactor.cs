using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DCCMSNameSpace
{   
    /// <summary>
    /// The factory class of ItemsOrdersModel.
    /// </summary>
    public class ItemsOrdersFactor
    {

        #region --------------Create--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates model object by calling News data provider create method.
        /// </summary>
        /// <param name="ItemsOrdersObj">The model object.</param>
        /// <returns>The result of create operation.</returns>
        //--------------------------------------------------------------------
        public static bool Create(ItemsOrdersModel ItemsOrdersObj, List<ItemsOrdersDetailsModel> productsList)
        {
            return ItemsOrdersSqlDataPrvider.Instance.Create(ItemsOrdersObj, productsList);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------Updat--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates model object by calling sql data provider update method.
        /// </summary>
        /// <param name="ItemsOrdersObj">The model object.</param>
        /// <returns>The result of update operation.</returns>
        //--------------------------------------------------------------------
        public static bool Updat(ItemsOrdersModel ItemsOrdersObj)
        {
            return ItemsOrdersSqlDataPrvider.Instance.Updat(ItemsOrdersObj);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region --------------Delete--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes single model object .
        /// </summary>
        /// <param name="OrderID">The model id.</param>
        /// <returns>The result of delete operation.</returns>
        //--------------------------------------------------------------------
        public static bool Delete(int OrderID)
        {
            return ItemsOrdersSqlDataPrvider.Instance.Delete(OrderID);
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
        public static List<ItemsOrdersModel> GetPageByPage(int pageIndex, int pageSize, out int totalRecords)
        {
            return ItemsOrdersSqlDataPrvider.Instance.GetPageByPage(pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        #region --------------GetPageByPageForUser--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific records.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        //--------------------------------------------------------------------
        public static List<ItemsOrdersModel> GetPageByPageForUser(Guid userID, int pageIndex, int pageSize, out int totalRecords)
        {
            return ItemsOrdersSqlDataPrvider.Instance.GetPageByPageForUser(userID,pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        #region --------------Get--------------
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific records.
        /// </summary>
        /// <param name="OrderID">The model id.</param>
        /// <returns>Model object.</returns>
        //--------------------------------------------------------------------
        public static List<ItemsOrdersModel> Get(int OrderID)
        {
            return ItemsOrdersSqlDataPrvider.Instance.Get(OrderID);
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        #region --------------Get--------------
        //--------------------------------------------------------------------
        public static ItemsOrdersModel GetObject(int OrderID)
        {
            List<ItemsOrdersModel> list =ItemsOrdersSqlDataPrvider.Instance.Get(OrderID);
            if(list!=null && list.Count>0)
            {
            return list[0];
            }
            return null;
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
    }
}