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
    public class RolesDataController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public RolesDataController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PTC"].ConnectionString);
        }

        #region Insert Methods
        public void Roles_Insert(RolesEntity rolesEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("Roles_Insert", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("RoleID", SqlDbType.Char, 36).Value = rolesEntity.RoleID;
                    command.Parameters.Add("RoleName", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("LoweredRoleName", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("Description", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = rolesEntity.Active;
                    command.Parameters.Add("CreatedUserID", SqlDbType.NVarChar).Value = rolesEntity.CreatedUserID;

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
        public void Roles_Update(RolesEntity rolesEntity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("Roles_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("RoleID", SqlDbType.Char, 36).Value = rolesEntity.RoleID;
                    command.Parameters.Add("RoleName", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("LoweredRoleName", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("Description", SqlDbType.NVarChar).Value = rolesEntity.RoleName;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = rolesEntity.Active;
                    command.Parameters.Add("TS", SqlDbType.Binary).Value = rolesEntity.TS;
                    command.Parameters.Add("UpdatedUserID", SqlDbType.NVarChar).Value = rolesEntity.UpdatedUserID;


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
        public void Roles_DeleteByRolesID(string roleID, string updatedUserID)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("Roles_DeleteByRoleID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("RoleID", SqlDbType.Char, 36).Value = roleID;
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
        public IDataReader Roles_SelectList()
        {
            command = new SqlCommand("Roles_SelectList", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region SelectByID Methods
        public IDataReader Roles_SelectByRolesID(string rolesID)
        {
            command = new SqlCommand("Roles_SelectByRoleID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("RoleID", SqlDbType.Char).Value = rolesID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader UsersInRoles_SelectRolesForUser(string userID)
        {
            command = new SqlCommand("UsersInRoles_SelectRolesForUser", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserID", SqlDbType.Char).Value = userID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    
        #endregion

    }
}

