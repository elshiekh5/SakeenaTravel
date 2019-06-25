using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
namespace DCCMSNameSpace
{
    public class AdvPlacesFactory
    {
        /*
        #region --------------Create--------------
        /// <summary>
        /// Creates AdvPlaces object by calling AdvPlaces data provider create method.
        /// <example>[Example]bool status=AdvPlacesFactory.Create(advPlaces);.</example>
        /// </summary>
        /// <param name="advPlaces">The AdvPlaces object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(AdvPlacesEntity advPlaces)
        {
            return AdvPlacesSqlDataPrvider.Instance.Create(advPlaces);
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates AdvPlaces object by calling AdvPlaces data provider update method.
        /// <example>[Example]bool status=AdvPlacesFactory.Update(advPlaces);.</example>
        /// </summary>
        /// <param name="advPlaces">The AdvPlaces object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Update(AdvPlacesEntity advPlaces)
        {
            bool status =AdvPlacesSqlDataPrvider.Instance.Update(advPlaces);
            if (status)
            {
                string cacheKey = GetChacheKey(advPlaces.PlaceID);
                OurCache.Remove(cacheKey);
            }
            return status;
        }
        //------------------------------------------
        #endregion
        */
        #region --------------Save--------------
        public static ExecuteCommandStatus Save(AdvPlacesEntity advPlaces, SPOperation operation)
        {
            return AdvPlacesSqlDataPrvider.Instance.Save(advPlaces, operation);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single AdvPlaces object .
        /// <example>[Example]bool status=AdvPlacesFactory.Delete(placeID);.</example>
        /// </summary>
        /// <param name="placeID">The advPlaces id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int placeID)
        {
            bool status = AdvPlacesSqlDataPrvider.Instance.Delete(placeID);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<AdvPlacesEntity> GetAll(AdvPlaceTypes PlaceType)
        {
            int totalRecords = 0;
            return AdvPlacesSqlDataPrvider.Instance.GetAll(PlaceType ,- 1, -1, out totalRecords);
        }
        public static List<AdvPlacesEntity> GetAll(AdvPlaceTypes PlaceType, int pageIndex, int pageSize, out int totalRecords)
        {

            return AdvPlacesSqlDataPrvider.Instance.GetAll(PlaceType,pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount()
        {

            return AdvPlacesSqlDataPrvider.Instance.GetCountAdvPlaces();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static AdvPlacesEntity GetObject(int placeID)
        {

            AdvPlacesEntity advPlaces = AdvPlacesSqlDataPrvider.Instance.GetObject(placeID);

            //return the object
            return advPlaces;
        }
        //------------------------------------------
        #endregion
    }
}

