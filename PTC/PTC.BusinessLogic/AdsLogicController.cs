using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTC.DataAccess;
using PTC.Entities;

namespace PTC.BusinessLogic
{
    public class AdsLogicController
    {
        public AdsLogicController()
        {

        }

        #region Insert Methods
        public void Ads_Insert(AdsEntity adsEntity)
        {
            AdsDataController adsDataController = new AdsDataController();
            adsDataController.Ads_Insert(adsEntity);
        }
        #endregion

        #region Update Methods
        public void Ads_Update(AdsEntity adsEntity)
        {
            AdsDataController adsDataController = new AdsDataController();
            adsDataController.Ads_Update(adsEntity);
        }
        #endregion

        #region Delete Methods

        public void Ads_DeleteByAdsID(string adsidID, string updatedUserID)
        {
            AdsDataController adsDataController = new AdsDataController();
            adsDataController.Ads_DeleteByAdsID(adsidID, updatedUserID);
        }
        #endregion

        #region SelectList Methods

        public AdsEntityCollections SelectList()
        {
            AdsEntityCollections adsEntityCollections = new AdsEntityCollections();

            AdsDataController adsDataController = new AdsDataController();
            IDataReader dataReader = adsDataController.Ads_SelectList();
            while (dataReader.Read())
            {
                AdsEntity adsEntity = new AdsEntity();

                this.Fill(dataReader, adsEntity);

                adsEntityCollections.Add(adsEntity);
            }
            dataReader.Close();
            return adsEntityCollections;
        }

        #region ViewAds

        public AdsEntityCollections ViewAds(string userID)
        {
            AdsEntityCollections adsEntityCollections = new AdsEntityCollections();

            AdsDataController adsDataController = new AdsDataController();
            IDataReader dataReader = adsDataController.Ads_ViewAds(userID);
            while (dataReader.Read())
            {
                AdsEntity adsEntity = new AdsEntity();

                this.FillForAds(dataReader, adsEntity);

                adsEntityCollections.Add(adsEntity);
            }
            dataReader.Close();
            return adsEntityCollections;
        }

        #endregion

        #region GenerateAds

        public void GenerateAds(string userID)
        {
            AdsDataController Ads = new AdsDataController();
            Ads.GenerateAds(userID);
        }

        #endregion

        #region UpdateUser,Ads,GeneratedAds

        public void GenerateAdsUpdateByAdsID(string userID, string adsID)
        {
            AdsDataController Ads = new AdsDataController();
            Ads.GenerateAdsUpdateByAdsID(userID,adsID);

        }

        #endregion

        public AdsEntity SelectByAdsID(string adsidID)
        {
            AdsDataController adsDataController = new AdsDataController();
            IDataReader dataReader = adsDataController.Ads_SelectByAdsID(adsidID);
            AdsEntity adsEntity = new AdsEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, adsEntity);
            }
            dataReader.Close();
            return adsEntity;
        }


        #endregion

        private void Fill(IDataReader dataReader, AdsEntity adsEntity)
        {
            if (!(dataReader["AdsID"] is DBNull))
            {
                adsEntity.AdsID = Convert.ToString(dataReader["AdsID"]);

            }
            if (!(dataReader["AdsPackageID"] is DBNull))
            {
                adsEntity.AdsPackageID = Convert.ToString(dataReader["AdsPackageID"]);

            }
            if (!(dataReader["Clicks"] is DBNull))
            {
                adsEntity.Clicks = Convert.ToString(dataReader["Clicks"]);

            }
            if (!(dataReader["AdsName"] is DBNull))
            {
                adsEntity.AdsName = Convert.ToString(dataReader["AdsName"]);

            }
            if (!(dataReader["AdsDescription"] is DBNull))
            {
                adsEntity.AdsDescription = Convert.ToString(dataReader["AdsDescription"]);

            }
            if (!(dataReader["AdsURL"] is DBNull))
            {
                adsEntity.AdsURL = Convert.ToString(dataReader["AdsURL"]);

            }
            if (!(dataReader["AdsClicksLeft"] is DBNull))
            {
                adsEntity.AdsClicksLeft = Convert.ToInt32(dataReader["AdsClicksLeft"]);

            }
            if (!(dataReader["Active"] is DBNull))
            {
                adsEntity.Active = Convert.ToBoolean(dataReader["Active"]);
            }

            if (!(dataReader["TS"] is DBNull))
            {
                adsEntity.TS = (byte[])(dataReader["TS"]);
            }

            if (!(dataReader["CreatedDate"] is DBNull))
            {
                adsEntity.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
            }
            else
            {
                adsEntity.CreatedDate = DateTime.MinValue;
            }
            if (!(dataReader["CreatedUserID"] is DBNull))
            {
                adsEntity.CreatedUserID = Convert.ToString(dataReader["CreatedUserID"]);
            }

            if (!(dataReader["UpdatedDate"] is DBNull))
            {
                adsEntity.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
            }
            else
            {
                adsEntity.UpdatedDate = DateTime.MinValue;
            }
            if (!(dataReader["UpdatedUserID"] is DBNull))
            {
                adsEntity.UpdatedUserID = Convert.ToString(dataReader["UpdatedUserID"]);
            }

        }

        private void FillForAds(IDataReader dataReader, AdsEntity adsEntity)
        {
            if (!(dataReader["AdsID"] is DBNull))
            {
                adsEntity.AdsID = Convert.ToString(dataReader["AdsID"]);

            }
            if (!(dataReader["AdsPackageID"] is DBNull))
            {
                adsEntity.AdsPackageID = Convert.ToString(dataReader["AdsPackageID"]);

            }
            if (!(dataReader["PerClick"] is DBNull))
            {
                adsEntity.PerClick = Convert.ToString(dataReader["PerClick"]);

            }
            if (!(dataReader["AdsName"] is DBNull))
            {
                adsEntity.AdsName = Convert.ToString(dataReader["AdsName"]);

            }
            if (!(dataReader["AdsDescription"] is DBNull))
            {
                adsEntity.AdsDescription = Convert.ToString(dataReader["AdsDescription"]);

            }
            if (!(dataReader["AdsURL"] is DBNull))
            {
                adsEntity.AdsURL = Convert.ToString(dataReader["AdsURL"]);

            }
           
        }

    }
}

