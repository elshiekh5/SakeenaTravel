using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class SystemCountriesFactory
    {
        #region --------------Create--------------
        /// <summary>
        /// Creates SystemCountries object by calling SystemCountries data provider create method.
        /// <example>[Example]bool status=SystemCountriesFactory.Create(systemCountriesObject);.</example>
        /// </summary>
        /// <param name="systemCountriesObject">The SystemCountries object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(SystemCountriesEntity systemCountriesObject)
        {
            return SystemCountriesSqlDataPrvider.Instance.Create(systemCountriesObject);
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates SystemCountries object by calling SystemCountries data provider update method.
        /// <example>[Example]bool status=SystemCountriesFactory.Update(systemCountriesObject);.</example>
        /// </summary>
        /// <param name="systemCountriesObject">The SystemCountries object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Update(SystemCountriesEntity systemCountriesObject)
        {
            bool status = SystemCountriesSqlDataPrvider.Instance.Update(systemCountriesObject);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single SystemCountries object .
        /// <example>[Example]bool status=SystemCountriesFactory.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The systemCountriesObject id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int id)
        {
            bool status = SystemCountriesSqlDataPrvider.Instance.Delete(id);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<SystemCountriesEntity> GetAll()
        {

            return SystemCountriesSqlDataPrvider.Instance.GetAllSystemCountries();
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllWithPager--------------
        public static List<SystemCountriesEntity> GetAllWithPager(int pageIndex, int pageSize, out int totalRecords)
        {

            return SystemCountriesSqlDataPrvider.Instance.GetAllSystemCountriesWithPager(pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static SystemCountriesEntity GetObject(int id)
        {
            SystemCountriesEntity systemCountriesObject = SystemCountriesSqlDataPrvider.Instance.GetObject(id);
            //return the object
            return systemCountriesObject;
        }
        //------------------------------------------
        #endregion

        public static string GetCountryFlag(object countryID)
        {
            string directoryPath = "/Content/images/flags/";
            SystemCountriesEntity cntry = GetObject((int)countryID);
            if (cntry != null)
                return directoryPath + cntry.country_code + ".png";
            else
                return "/Content/images/flags/spacer.gif";
        }
    }
}