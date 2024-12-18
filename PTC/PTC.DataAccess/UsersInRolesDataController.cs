using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using PTC.Entities;

namespace PTC.DataAccess
{
    public class UsersInRolesDataController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public UsersInRolesDataController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PTC"].ConnectionString);
        }

        #region Insert Methods
        public void UsersInRoles_Insert(string userName,string roleName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("UsersInRoles_Insert", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("UserName", SqlDbType.NVarChar).Value = userName;
                    command.Parameters.Add("RoleName", SqlDbType.NVarChar).Value = roleName;

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
        public void UsersInRoles_Update(UsersInRolesEntity usersinrolesEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("UsersInRoles_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("UserProfileID", SqlDbType.Char, 36).Value = usersinrolesEntity.UserID;
                    command.Parameters.Add("RoleID", SqlDbType.NVarChar).Value = usersinrolesEntity.RoleID;

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
        public void UsersInRoles_DeleteByUserProfileID(string userprofileID, string updatedUserID)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("UsersInRoles_DeleteByUserProfileID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("UserProfileID", SqlDbType.Char, 36).Value = userprofileID;
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

        public IDataReader UsersInRoles_DeleteByUsersFromRoles(string userName, string roleName)
        {
            command = new SqlCommand("UsersInRoles_DeleteUsersFromRoles", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserName", SqlDbType.Char).Value = userName;
            command.Parameters.Add("RoleName", SqlDbType.Char).Value = roleName;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

        #region SelectList Methods
        public IDataReader UsersInRoles_SelectList()
        {
            command = new SqlCommand("UsersInRoles_SelectList", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region SelectByID Methods
        public IDataReader UsersInRoles_SelectByUserProfileID(string userprofileID)
        {
            command = new SqlCommand("UsersInRoles_SelectByUserProfileID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserProfileID", SqlDbType.Char).Value = userprofileID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    
        public IDataReader UsersInRoles_IsUserInRole(string userName,string roleName)
        {
            command = new SqlCommand("UsersInRoles_IsUserInRole", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserName", SqlDbType.Char).Value = userName;
            command.Parameters.Add("RoleName", SqlDbType.Char).Value = roleName;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #endregion

    }
}

