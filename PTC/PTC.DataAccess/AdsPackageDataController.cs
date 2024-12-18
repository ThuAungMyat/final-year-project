using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using PTC.Entities;

namespace PTC.DataAccess
{
    public class AdsPackageDataController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public AdsPackageDataController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PTC2"].ConnectionString);
        }

        #region Insert Methods
        public void AdsPackage_Insert(AdsPackageEntity adspackageEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("AdsPackage_Insert", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("AdsPackageID", SqlDbType.Char, 36).Value = adspackageEntity.AdsPackageID;
                    command.Parameters.Add("Clicks", SqlDbType.NVarChar).Value = adspackageEntity.Clicks;
                    command.Parameters.Add("Price", SqlDbType.Decimal).Value = adspackageEntity.Price;
                    command.Parameters.Add("PerClick", SqlDbType.Decimal).Value = adspackageEntity.PerClick;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = adspackageEntity.Active;
                    command.Parameters.Add("CreatedUserID", SqlDbType.NVarChar).Value = adspackageEntity.CreatedUserID;

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
        public void AdsPackage_Update(AdsPackageEntity adspackageEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("AdsPackage_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("AdsPackageID", SqlDbType.Char, 36).Value = adspackageEntity.AdsPackageID;
                    command.Parameters.Add("Clicks", SqlDbType.NVarChar).Value = adspackageEntity.Clicks;
                    command.Parameters.Add("Price", SqlDbType.NVarChar).Value = adspackageEntity.Price;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = adspackageEntity.Active;
                    command.Parameters.Add("TS", SqlDbType.Binary).Value = adspackageEntity.TS;
                    command.Parameters.Add("UpdatedUserID", SqlDbType.NVarChar).Value = adspackageEntity.UpdatedUserID;


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
        public void AdsPackage_DeleteByAdsPackageID(string adspackageID, string updatedUserID)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("AdsPackage_DeleteByAdsPackageID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("AdsPackageID", SqlDbType.Char, 36).Value = adspackageID;
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
        public IDataReader AdsPackage_SelectList()
        {
            command = new SqlCommand("AdsPackage_SelectList", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region SelectByID Methods
        public IDataReader AdsPackage_SelectByAdsPackageID(string adspackageID)
        {
            command = new SqlCommand("AdsPackage_SelectByAdsPackageID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("AdsPackageID", SqlDbType.Char).Value = adspackageID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

    }
}

