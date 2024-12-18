using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using PTC.Entities;

namespace PTC.DataAccess
{
    public class AdsDataController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public AdsDataController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PTC2"].ConnectionString);
        }

        #region Insert Methods
        public void Ads_Insert(AdsEntity adsEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("Ads_Insert", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("AdsID", SqlDbType.Char, 36).Value = adsEntity.AdsID;
                    command.Parameters.Add("AdsPackageID", SqlDbType.NVarChar).Value = adsEntity.AdsPackageID;
                    command.Parameters.Add("AdsName", SqlDbType.NVarChar).Value = adsEntity.AdsName;
                    command.Parameters.Add("AdsDescription", SqlDbType.NVarChar).Value = adsEntity.AdsDescription;
                    command.Parameters.Add("AdsURL", SqlDbType.NVarChar).Value = adsEntity.AdsURL;
                    command.Parameters.Add("AdsClicksLeft", SqlDbType.NVarChar).Value = adsEntity.AdsClicksLeft;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = adsEntity.Active;
                    command.Parameters.Add("CreatedUserID", SqlDbType.NVarChar).Value = adsEntity.CreatedUserID;

                    command.ExecuteNonQuery();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        #endregion

        #region Update Methods
        public void Ads_Update(AdsEntity adsEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("Ads_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("AdsID", SqlDbType.Char, 36).Value = adsEntity.AdsID;
                    command.Parameters.Add("AdsPackageID", SqlDbType.NVarChar).Value = adsEntity.AdsPackageID;
                    command.Parameters.Add("AdsName", SqlDbType.NVarChar).Value = adsEntity.AdsName;
                    command.Parameters.Add("AdsDescription", SqlDbType.NVarChar).Value = adsEntity.AdsDescription;
                    command.Parameters.Add("AdsURL", SqlDbType.NVarChar).Value = adsEntity.AdsURL;
                    command.Parameters.Add("AdsClicksLeft", SqlDbType.NVarChar).Value = adsEntity.AdsClicksLeft;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = adsEntity.Active;
                    command.Parameters.Add("TS", SqlDbType.Binary).Value = adsEntity.TS;
                    command.Parameters.Add("UpdatedUserID", SqlDbType.NVarChar).Value = adsEntity.UpdatedUserID;


                    command.ExecuteNonQuery();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        #endregion

        #region Delete Methods
        public void Ads_DeleteByAdsID(string adsID, string updatedUserID)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("Ads_DeleteByAdsID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("AdsID", SqlDbType.Char, 36).Value = adsID;
                command.Parameters.Add("UpdatedUserID", SqlDbType.NVarChar).Value = updatedUserID;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region SelectList Methods

        public IDataReader Ads_SelectList()
        {
            command = new SqlCommand("Ads_SelectList", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region ViewAds

        public IDataReader Ads_ViewAds(string userID)
        {
            command = new SqlCommand("Ads_ViewAds", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("UserID", SqlDbType.Char, 36).Value = userID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region GenerateAds

        public void GenerateAds(string userID)
        {
            command = new SqlCommand("Generate_Ads", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("UserID", SqlDbType.Char, 36).Value = userID;
         
            connection.Open();
            command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion

        #region UpdateUser,Ads,GeneratedAds

        public void GenerateAdsUpdateByAdsID(string userID, string adsID)
        {
            command = new SqlCommand("GeneratedAds_UpdateByAdsID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@GeneratedUserID", SqlDbType.Char, 36).Value = userID;
            command.Parameters.Add("@AdsID", SqlDbType.Char, 36).Value = adsID;

            connection.Open();
            command.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        #endregion

        #region SelectByID Methods
        public IDataReader Ads_SelectByAdsID(string adsID)
        {
            command = new SqlCommand("Ads_SelectByAdsID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("AdsID", SqlDbType.Char).Value = adsID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

    }
}
