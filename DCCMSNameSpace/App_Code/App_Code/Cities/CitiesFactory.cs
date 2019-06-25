using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
namespace DCCMSNameSpace
{
    public class CitiesFactory
    {


        #region --------------Create--------------
        /// <summary>
        /// Creates Cities object by calling Cities data provider create method.
        /// <example>[Example]bool status=CitiesFactory.Create(cities);.</example>
        /// </summary>
        /// <param name="cities">The Cities object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(CitiesEntity cities)
        {
            return CitiesSqlDataPrvider.Instance.Create(cities);
        }
        public static bool Create2(CitiesEntity cities)
        {
            return CitiesSqlDataPrvider.Instance.Create2(cities);
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates Cities object by calling Cities data provider update method.
        /// <example>[Example]bool status=CitiesFactory.Update(cities);.</example>
        /// </summary>
        /// <param name="cities">The Cities object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Update(CitiesEntity cities)
        {
            bool status = CitiesSqlDataPrvider.Instance.Update(cities);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Cities object .
        /// <example>[Example]bool status=CitiesFactory.Delete(cityID);.</example>
        /// </summary>
        /// <param name="cityID">The cities id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int cityID)
        {
            bool status = CitiesSqlDataPrvider.Instance.Delete(cityID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllWithPager--------------
        public static List<CitiesEntity> GetAll(int countryID)
        {
            int totalRecords = 0;
            return CitiesSqlDataPrvider.Instance.GetAll(countryID, -1, -1, out totalRecords);
        }
        public static List<CitiesEntity> GetAllWithPager(int countryID, int pageIndex, int pageSize, out int totalRecords)
        {
            return CitiesSqlDataPrvider.Instance.GetAll(countryID, pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------
        #endregion

        public static List<CitiesEntity> GoogleSearch(double NorthEast_Latitude, double NorthEast_Longitude, double SouthWest_Latitude, double SouthWest_Longitude)
        {
            return CitiesSqlDataPrvider.Instance.GoogleSearch(NorthEast_Latitude, NorthEast_Longitude, SouthWest_Latitude, SouthWest_Longitude);
        }
        #region --------------GetObject--------------
        public static CitiesEntity GetObject(int cityID)
        {
            CitiesEntity cities = CitiesSqlDataPrvider.Instance.GetObject(cityID);
            //return the object
            return cities;
        }
        //------------------------------------------
        #endregion
    }
}
