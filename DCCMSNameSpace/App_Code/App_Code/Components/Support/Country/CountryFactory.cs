using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of Country.
    /// </summary>
    [Serializable()]
    public class CountryFactory
    {

        /// <summary>
        /// Creates Country object by calling Country data provider create method.
        /// <example>[Example]bool result=CountryFactory.Create(country);.</example>
        /// </summary>
        /// <param name="country">The Country object.</param>
        /// <returns>The result of create operation.</returns>
        public static bool Create(CountryEntity country)
        {
            return CountrySqlDataPrvider.Instance.Create(country);
        }
        //------------------------------------------
        /// <summary>
        /// Updates Country object by calling Country data provider update method.
        /// <example>[Example]bool result=CountryFactory.Update(country);.</example>
        /// </summary>
        /// <param name="country">The Country object.</param>
        /// <returns>The result of update operation.</returns>
        public static bool Update(CountryEntity country)
        {
            return CountrySqlDataPrvider.Instance.Update(country);
        }
        //------------------------------------------
        /// <summary>
        /// Deletes single Country object .
        /// <example>[Example]bool result=CountryFactory.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The country id.</param>
        /// <returns>The result of delete operation.</returns>
        public static bool Delete(int id)
        {
            return CountrySqlDataPrvider.Instance.Delete(id);
        }
        //------------------------------------------
        /// <summary>
        /// Gets All Country.
        /// <example>[Example]DataTable dtCountry=CountryFactory.GetAll();.</example>
        /// </summary>
        /// <returns>All Country.</returns>
        public static DataTable GetAll()
        {
            return CountrySqlDataPrvider.Instance.GetAllCountry();
        }
        public static DataTable GetAllByContID(int COntID)
        {
            return CountrySqlDataPrvider.Instance.GetAllCountryByContID(COntID);
        }
        public static DataTable GetRestCountriesForStatistics()
        {
            return CountrySqlDataPrvider.Instance.GetRestCountriesForStatistics();
        }
        public static DataTable GetTopCountriesForStatistics()
        {
            return CountrySqlDataPrvider.Instance.GetTopCountriesForStatistics();
        }
        public static List<CountryEntity> GetAllinList()
        {
            return CountrySqlDataPrvider.Instance.GetAllinList();
        }
        //------------------------------------------
        /// <summary>
        /// Gets single Country object .
        /// <example>[Example]CountryEntity country=CountryFactory.GetCountryObject(id);.</example>
        /// </summary>
        /// <param name="id">The country id.</param>
        /// <returns>Country object.</returns>
        public static CountryEntity GetCountryObject(int id)
        {
            return CountrySqlDataPrvider.Instance.GetCountryObject(id);
        }
        //------------------------------------------

    }
}
