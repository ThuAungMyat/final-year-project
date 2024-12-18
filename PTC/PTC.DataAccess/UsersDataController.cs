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
using System.IO;

namespace PTC.DataAccess
{
    public class UsersDataController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public UsersDataController()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PTC2"].ConnectionString);
        }

        public void Users_Insert(UsersEntity usersEntity, ref string Errmsg)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand("Users_Insert", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("UserID", SqlDbType.Char).Value = usersEntity.UserID;
                    command.Parameters.Add("UserName", SqlDbType.VarChar).Value = usersEntity.UserName;
                    command.Parameters.Add("Password", SqlDbType.VarChar).Value = usersEntity.Password;
                    command.Parameters.Add("DateOfBirth", SqlDbType.DateTime).Value = usersEntity.DateOfBirth;
                    command.Parameters.Add("IP", SqlDbType.VarChar).Value = usersEntity.IP;
                    command.Parameters.Add("Gender", SqlDbType.VarChar).Value = usersEntity.Gender;
                    command.Parameters.Add("Email", SqlDbType.VarChar).Value = usersEntity.Email;
                    command.Parameters.Add("PaypalEmail", SqlDbType.VarChar).Value = usersEntity.PaypalEmail;
                    command.Parameters.Add("PasswordQuestion", SqlDbType.VarChar).Value = usersEntity.PasswordQuestion;
                    command.Parameters.Add("PasswordAnswer", SqlDbType.VarChar).Value = usersEntity.PasswordAnswer;
                    command.Parameters.Add("Phone", SqlDbType.VarChar).Value = usersEntity.Phone;
                    command.Parameters.Add("Address", SqlDbType.VarChar).Value = usersEntity.Address;
                    command.Parameters.Add("UserImage", SqlDbType.Binary).Value = usersEntity.UserImage;
                    command.Parameters.Add("IsApproved", SqlDbType.Bit).Value = usersEntity.IsApproved;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = usersEntity.Active;
                    command.Parameters.Add("CreatedUserID", SqlDbType.NVarChar).Value = usersEntity.CreatedUserID;

                    command.ExecuteNonQuery();
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Errmsg = ex.Message;
                    return;
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

        public void Users_Update(UsersEntity usersEntity, ref string Errmsg)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    connection.Open();
                   
                    command = new SqlCommand("Users_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("UserID", SqlDbType.Char).Value = usersEntity.UserID;
                    command.Parameters.Add("UserName", SqlDbType.VarChar).Value = usersEntity.UserName;
                    command.Parameters.Add("Password", SqlDbType.VarChar).Value = usersEntity.Password;
                    command.Parameters.Add("DateOfBirth", SqlDbType.DateTime).Value = usersEntity.DateOfBirth;
                    command.Parameters.Add("Gender", SqlDbType.VarChar).Value = usersEntity.Gender;
                    command.Parameters.Add("Email", SqlDbType.VarChar).Value = usersEntity.Email;
                    command.Parameters.Add("PasswordQuestion", SqlDbType.VarChar).Value = usersEntity.PasswordQuestion;
                    command.Parameters.Add("PasswordAnswer", SqlDbType.VarChar).Value = usersEntity.PasswordAnswer;
                    command.Parameters.Add("Phone", SqlDbType.VarChar).Value = usersEntity.Phone;
                    command.Parameters.Add("Address", SqlDbType.VarChar).Value = usersEntity.Address;
                    command.Parameters.Add("UserImage", SqlDbType.Binary).Value = usersEntity.UserImage;
                    command.Parameters.Add("IsApproved", SqlDbType.Bit).Value = usersEntity.IsApproved;
                    command.Parameters.Add("Active", SqlDbType.Bit).Value = usersEntity.Active;
                    command.Parameters.Add("TS", SqlDbType.Binary).Value = usersEntity.TS;
                    command.Parameters.Add("UpdatedUserID", SqlDbType.NVarChar).Value = usersEntity.UpdatedUserID;

                    command.ExecuteNonQuery();
                    scope.Complete();
                    //}
                }
                catch (Exception ex)
                {
                    Errmsg = ex.Message;
                    return;
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

        public IDataReader Users_SelectByUserID(string userID, ref string Errmsg)
        {
            connection.Open();
            command = new SqlCommand("Users_SelectByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID;

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Users_SelectByUserName(string userName)
        {
            command = new SqlCommand("Users_SelectByUserName", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserName", SqlDbType.Char).Value = userName;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader UsersInRoles_SelectUsersInRole(string roleName)
        {
            command = new SqlCommand("UsersInRoles_SelectUsersInRole", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("RoleName", SqlDbType.NVarChar).Value = roleName;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Users_SelectUsersCount()
        {
            connection.Open();
            command = new SqlCommand("Users_SelectUsersCount", connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }

        public IDataReader UserLogin(string userName, string password, ref string Errmsg)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("Users_LoginCheck", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                SqlParameter paraErr = command.Parameters.Add("@Err", SqlDbType.VarChar, 100);
                paraErr.Direction = ParameterDirection.Output;

                SqlParameter paraReturnValue = command.Parameters.Add("ReturnValue", SqlDbType.Int);
                paraReturnValue.Direction = ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();
                if (int.Parse(paraReturnValue.Value.ToString()) != 0)
                {
                    command = new SqlCommand("Users_Login", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    return reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    Errmsg = paraErr.Value.ToString();
                    return reader;
                }
            }
            catch (Exception ex)
            {
                Errmsg = ex.ToString();
                return reader;
            }
        }

        #region Delete Methods
        public void Users_DeleteByUserID(string userID, string updatedUserID)
        {
            try
            {
                connection.Open();
                command = new SqlCommand("Users_DeleteByUserID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("UserID", SqlDbType.Char, 36).Value = userID;
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
        public IDataReader Users_SelectList()
        {
            command = new SqlCommand("Users_SelectList", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region SelectByID Methods
        public IDataReader Users_SelectByUserID(string userID)
        {
            command = new SqlCommand("Users_SelectByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserID", SqlDbType.Char).Value = userID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Users_SelectAllUserImageByUserID(string userID)
        {
            command = new SqlCommand("Users_SelectByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserID", SqlDbType.Char).Value = userID;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Users_SelectAllUserByUserName(string userName)
        {
            command = new SqlCommand("Users_SelectAllUserByUserName", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserName", SqlDbType.NVarChar).Value = userName;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader Users_SelectAllUserByEmail(string email)
        {
            command = new SqlCommand("Users_SelectAllUserByEmail", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("Email", SqlDbType.NVarChar).Value = email;

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public Stream Users_SelectUserImageByUserName(string userName)
        {
            command = new SqlCommand("Users_SelectUserImageByUserName", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserName", SqlDbType.Char).Value = userName;

            connection.Open();

            object result = command.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }
        }

        public Stream Users_SelectUserImageByUserID(string userID)
        {
            command = new SqlCommand("Users_SelectUserImageByUserID", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("UserID", SqlDbType.Char).Value = userID;

            connection.Open();

            object result = command.ExecuteScalar();
            try
            {
                return new MemoryStream((byte[])result);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
