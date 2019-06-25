using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
namespace DCCMSNameSpace
{
    public class AdvertismentsFactory
    {
        #region --------------Save--------------
        public static bool Save(AdvertismentsEntity advertisment, SPOperation operation)
        {
            return AdvertismentsSqlDataPrvider.Instance.Save(advertisment, operation);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Advertisments object .
        /// <example>[Example]bool status=AdvertismentsFactory.Delete(advertiseID);.</example>
        /// </summary>
        /// <param name="advertiseID">The advertisment id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int advertiseID)
        {
            bool status = AdvertismentsSqlDataPrvider.Instance.Delete(advertiseID);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<AdvertismentsEntity> GetAll(Languages langID, int placeID, Guid OwnerID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords)
        {
            return AdvertismentsSqlDataPrvider.Instance.GetAll(langID, placeID,  OwnerID, isAvailableCondition, pageIndex, pageSize, out  totalRecords);
        }
        #endregion
        #region --------------GetSeparatedAdForShow--------------
        public static string GetSeparatedAdForShow(int placeID, Guid OwnerID)
        {
            string adText = "";
            AdvPlacesEntity adPlace = AdvPlacesFactory.GetObject(placeID);
            List<AdvertismentsEntity> advertismentList = AdvertismentsSqlDataPrvider.Instance.GetSeparatedAdForShow(placeID, OwnerID, adPlace.EnableSeparatedCount);
            foreach (AdvertismentsEntity advertisment in advertismentList)
            {

                if (advertisment != null)
                    adText += GetAdvertiseFile(advertisment);
                else
                {
                    if (adPlace != null)
                    {
                        adText += AdvertismentsFactory.GetAdvertiseFile(adPlace.DefaultFileType, adPlace.DefaultFilePath, -1, adPlace.Width, adPlace.Height, "", false);
                    }
                }
            }
            return adText;
        }
        //------------------------------------------
        #endregion
        #region --------------GetObject--------------
        public static AdvertismentsEntity GetObject(int advertiseID)
        {
            AdvertismentsEntity advertisment = AdvertismentsSqlDataPrvider.Instance.GetObject(advertiseID);
            //return the object
            return advertisment;
        }
        //------------------------------------------
        #endregion

        #region --------------UpdateActivity--------------

        public static bool UpdateActivity(int advertiseID, int placeID, int isActive)
        {
            bool status = AdvertismentsSqlDataPrvider.Instance.UpdateActivity(advertiseID, placeID, isActive);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------IncreaseApperanceCount--------------
        public static bool IncreaseApperanceCount(int advertiseID)
        {
            bool status = AdvertismentsSqlDataPrvider.Instance.IncreaseApperanceCount(advertiseID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------IncreaseClicksCount--------------
        public static bool IncreaseClicksCount(int advertiseID)
        {
            bool status = AdvertismentsSqlDataPrvider.Instance.IncreaseClicksCount(advertiseID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAdForShow--------------
        public static AdvertismentsEntity GetAdForShow(int placeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            AdvertismentsEntity advertisment = AdvertismentsSqlDataPrvider.Instance.GetAdForShow(placeID, OwnerID, langID);
            //return the object
            return advertisment;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAdForShowFile--------------
        public static string GetAdForShowFile(int placeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            AdvertismentsEntity advertisment = AdvertismentsSqlDataPrvider.Instance.GetAdForShow(placeID, OwnerID, langID);
            string adText = "";
            if (advertisment != null)
                adText = GetAdvertiseFile(advertisment);
            else
            {
                AdvPlacesEntity adPlace = AdvPlacesFactory.GetObject(placeID);
                if (adPlace != null)
                {
                    adText = AdvertismentsFactory.GetAdvertiseFile(adPlace.DefaultFileType, adPlace.DefaultFilePath, -1, adPlace.Width, adPlace.Height, "", false);
                }
            }
            return adText;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAdvertiseFile--------------
        public static string GetAdvertiseFile(object adID)
        {
            return GetAdvertiseFile(Convert.ToInt32(adID));
        }
        public static string GetAdvertiseFile(int adID)
        {
            AdvertismentsEntity adv = AdvertismentsFactory.GetObject(adID);
            return GetAdvertiseFile(adv);

        }
        //------------------------------------------
        public static string GetAdvertiseFileForAdmin(object adID)
        {
            return GetAdvertiseFileForAdmin(Convert.ToInt32(adID));
        }
        public static string GetAdvertiseFileForAdmin(int adID)
        {
            AdvertismentsEntity adv = AdvertismentsFactory.GetObject(adID);
            return GetAdvertiseFileForAdmin(adv);

        }
        //------------------------------------------
        public static string GetAdvertiseFile(AdvertismentsEntity adv)
        {
            if (adv != null)
            {
                bool hasLink = !string.IsNullOrEmpty(adv.Url);
                return GetAdvertiseFile(adv.FileType, adv.GetFileVirtualPath(), adv.AdvertiseID, adv.Width, adv.Height, adv.Title, hasLink);
            }
            else
                return null;
        }
        //------------------------------------------------------------------------
        public static string GetAdvertiseFileForAdmin(AdvertismentsEntity adv)
        {
            if (adv != null)
            {
                bool hasLink = !string.IsNullOrEmpty(adv.Url);
                int width = adv.Width;
                if (width > 450) width = 450;
                int ViewHeight = adv.Height;
                if (adv.IsSmall) ViewHeight = Convert.ToInt16(adv.Height / 2);
                return GetAdvertiseFile(adv.FileType, adv.GetFileVirtualPath(), adv.AdvertiseID, width, ViewHeight, adv.Title, hasLink);
            }
            else
                return null;
        }
        //------------------------------------------------------------------------
        public static string GetAdvertiseFile(AdsTypes adtype, string fileVirtualPath, int adID, int width, int height, string title, bool hasLink)
        {
            string target = "/Website/Advs/ViewAd.aspx?id=" + adID.ToString();
            string adObject = "";
            switch (adtype)
            {
                case AdsTypes.Photo:
                    if (adID > 0 && hasLink)
                        adObject += "<a href='" + target + "' target='_blank' >";

                    adObject += "<img title='" + title + "' src='" + fileVirtualPath + "' width='" + width.ToString() + "' alt='" + title + "' height='" + height.ToString() + "' border=0>";

                    if (adID > 0 && hasLink)
                        adObject += "</a>";

                    break;
                case AdsTypes.Flash:
                    adObject = PlayersBuilder.BuildFlashPlayer(fileVirtualPath, width, height, "ffffff");
                    break;
            }

            return adObject;
        }
        //------------------------------------------------------------------------

        #endregion
    }
}

