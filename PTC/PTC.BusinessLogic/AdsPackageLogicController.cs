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
    public class AdsPackageLogicController
    {
        public AdsPackageLogicController()
        {

        }

        #region Insert Methods
        public void AdsPackage_Insert(AdsPackageEntity adspackageEntity)
        {
            AdsPackageDataController adspackageDataController = new AdsPackageDataController();
            adspackageDataController.AdsPackage_Insert(adspackageEntity);
        }
        #endregion

        #region Update Methods
        public void AdsPackage_Update(AdsPackageEntity adspackageEntity)
        {
            AdsPackageDataController adspackageDataController = new AdsPackageDataController();
            adspackageDataController.AdsPackage_Update(adspackageEntity);
        }
        #endregion

        #region Delete Methods

        public void AdsPackage_DeleteByAdsPackageID(string adspackageidID, string updatedUserID)
        {
            AdsPackageDataController adspackageDataController = new AdsPackageDataController();
            adspackageDataController.AdsPackage_DeleteByAdsPackageID(adspackageidID, updatedUserID);
        }
        #endregion

        #region SelectList Methods
        public AdsPackageEntityCollections SelectList()
        {
            AdsPackageEntityCollections adspackageEntityCollections = new AdsPackageEntityCollections();

            AdsPackageDataController adspackageDataController = new AdsPackageDataController();
            IDataReader dataReader = adspackageDataController.AdsPackage_SelectList();
            while (dataReader.Read())
            {
                AdsPackageEntity adspackageEntity = new AdsPackageEntity();

                this.Fill(dataReader, adspackageEntity);

                adspackageEntityCollections.Add(adspackageEntity);
            }
            dataReader.Close();
            return adspackageEntityCollections;
        }

        public AdsPackageEntity SelectByAdsPackageID(string adspackageidID)
        {
            AdsPackageDataController adspackageDataController = new AdsPackageDataController();
            IDataReader dataReader = adspackageDataController.AdsPackage_SelectByAdsPackageID(adspackageidID);
            AdsPackageEntity adspackageEntity = new AdsPackageEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, adspackageEntity);
            }
            dataReader.Close();
            return adspackageEntity;
        }
        #endregion

        private void Fill(IDataReader dataReader, AdsPackageEntity adspackageEntity)
        {
            if (!(dataReader["AdsPackageID"] is DBNull))
            {
                adspackageEntity.AdsPackageID = Convert.ToString(dataReader["AdsPackageID"]);

            }
            if (!(dataReader["Clicks"] is DBNull))
            {
                adspackageEntity.Clicks = Convert.ToString(dataReader["Clicks"]);

            }
            if (!(dataReader["Price"] is DBNull))
            {
                adspackageEntity.Price = Convert.ToDecimal(dataReader["Price"]);

            }
            if (!(dataReader["PerClick"] is DBNull))
            {
                adspackageEntity.PerClick = Convert.ToDecimal(dataReader["PerClick"]);

            }
            if (!(dataReader["Active"] is DBNull))
            {
                adspackageEntity.Active = Convert.ToBoolean(dataReader["Active"]);
            }

            if (!(dataReader["TS"] is DBNull))
            {
                adspackageEntity.TS = (byte[])(dataReader["TS"]);
            }

            if (!(dataReader["CreatedDate"] is DBNull))
            {
                adspackageEntity.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
            }
            else
            {
                adspackageEntity.CreatedDate = DateTime.MinValue;
            }
            if (!(dataReader["CreatedUserID"] is DBNull))
            {
                adspackageEntity.CreatedUserID = Convert.ToString(dataReader["CreatedUserID"]);
            }

            if (!(dataReader["UpdatedDate"] is DBNull))
            {
                adspackageEntity.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
            }
            else
            {
                adspackageEntity.UpdatedDate = DateTime.MinValue;
            }
            if (!(dataReader["UpdatedUserID"] is DBNull))
            {
                adspackageEntity.UpdatedUserID = Convert.ToString(dataReader["UpdatedUserID"]);
            }

        }

    }
}

