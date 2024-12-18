using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PTC.DataAccess;
using PTC.Entities;
using System.IO;

namespace PTC.BusinessLogic
{
    public class UsersLogicController
    {
        UsersDataController usersController;
        IDataReader dataReader;

        public UsersLogicController()
        {
            usersController = new UsersDataController();
        }

        public void Users_Insert(UsersEntity usersEntity, ref string Errmsg)
        {
            usersController.Users_Insert(usersEntity, ref Errmsg);
        }

        public void Users_Update(UsersEntity usersEntity, ref string Errmsg)
        {
          
            usersController.Users_Update(usersEntity, ref Errmsg);
        }

        public UsersEntity Users_SelectUsersCount()
        {
            UsersEntity usersEntity = new UsersEntity();
            dataReader = usersController.Users_SelectUsersCount();

            if (dataReader != null)
            {
                if (dataReader.Read())
                {
                    if (!(dataReader["UsersCount"] is DBNull))
                    {
                        usersEntity.UsersCount = Convert.ToInt32(dataReader["UsersCount"]);
                    }
                }
                dataReader.Close();
            }
            return usersEntity;
        }

        public UsersEntity Users_SelectByUserID(string userID, ref string Errmsg)
        {
            UsersEntity usersEntity = new UsersEntity();
            dataReader = usersController.Users_SelectByUserID(userID, ref Errmsg);

            try
            {
                if (dataReader != null)
                {
                    if (dataReader.Read())
                    {
                        Fill(dataReader, usersEntity);
                    }
                    dataReader.Close();
                }
                return usersEntity;
            }
            catch (Exception ex)
            {
                Errmsg = ex.ToString();
                return usersEntity;
            }
        }

        public UsersEntity Users_SelectByUserName(string userName)
        {
            UsersEntity usersEntity = new UsersEntity();
            dataReader = usersController.Users_SelectByUserName(userName);

            try
            {
                if (dataReader != null)
                {
                    if (dataReader.Read())
                    {
                        Fill(dataReader, usersEntity);
                    }
                    dataReader.Close();
                }
                return usersEntity;
            }
            catch (Exception ex)
            {
                return usersEntity;
            }
        }

        public UsersEntityCollections UsersInRoles_SelectUsersInRole(string roleName)
        {
            UsersEntityCollections usersEntityCollections = new UsersEntityCollections();
            dataReader = usersController.UsersInRoles_SelectUsersInRole(roleName);

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    UsersEntity usersEntity = new UsersEntity();
                    if (!(dataReader["UserName"] is DBNull))
                    {
                        usersEntity.UserName = dataReader["UserName"].ToString();
                    }
                    usersEntityCollections.Add(usersEntity);
                }
                dataReader.Close();
            }
            return usersEntityCollections;
        }

        public UsersEntityCollections Users_SelectAllUserImageByUserID(string userID)
        {
            UsersEntityCollections usersEntityCollections = new UsersEntityCollections();
            dataReader = usersController.Users_SelectAllUserImageByUserID(userID);

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    UsersEntity usersEntity = new UsersEntity();
                    Fill(dataReader, usersEntity);
                    usersEntityCollections.Add(usersEntity);
                }
                dataReader.Close();
            }
            return usersEntityCollections;
        }

        public UsersEntity UserLogin(string userName, string password, ref string Errmsg)
        {
            IDataReader dataReader = usersController.UserLogin(userName, password, ref Errmsg);

            UsersEntity usersEntity = new UsersEntity();

            try
            {
                if (dataReader != null)
                {
                    if (dataReader.Read())
                    {
                        Fill(dataReader, usersEntity);
                    }
                    dataReader.Close();
                }
                return usersEntity;
            }
            catch (Exception ex)
            {
                Errmsg = ex.ToString();
                return usersEntity;
            }
        }

        #region Delete Methods

        public void Users_DeleteByUserID(string userID, string updatedUserID)
        {
            UsersDataController userDataController = new UsersDataController();
            userDataController.Users_DeleteByUserID(userID, updatedUserID);
        }
        #endregion

        #region SelectList Methods
        public UsersEntityCollections Users_SelectList()
        {
            UsersEntityCollections usersEntityCollections = new UsersEntityCollections();

            UsersDataController userDataController = new UsersDataController();
            IDataReader dataReader = userDataController.Users_SelectList();
            while (dataReader.Read())
            {
                UsersEntity usersEntity = new UsersEntity();

                this.Fill(dataReader, usersEntity);

                usersEntityCollections.Add(usersEntity);
            }
            dataReader.Close();
            return usersEntityCollections;
        }

        public UsersEntity Users_SelectByUserID(string userID)
        {
            UsersDataController userDataController = new UsersDataController();
            IDataReader dataReader = userDataController.Users_SelectByUserID(userID);
            UsersEntity usersEntity = new UsersEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, usersEntity);
            }
            dataReader.Close();
            return usersEntity;
        }
        #endregion

        public UsersEntityCollections Users_SelectAllUserByUserName(string userName)
        {
            UsersEntityCollections usersEntityCollections = new UsersEntityCollections();
            dataReader = usersController.Users_SelectAllUserByUserName(userName);

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    UsersEntity usersEntity = new UsersEntity();

                    Fill(dataReader, usersEntity);

                    usersEntityCollections.Add(usersEntity);
                }
                dataReader.Close();
            }
            return usersEntityCollections;
        }

        public UsersEntityCollections Users_SelectAllUserByEmail(string email)
        {
            UsersEntityCollections usersEntityCollections = new UsersEntityCollections();
            dataReader = usersController.Users_SelectAllUserByEmail(email);

            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    UsersEntity usersEntity = new UsersEntity();

                    Fill(dataReader, usersEntity);

                    usersEntityCollections.Add(usersEntity);
                }
                dataReader.Close();
            }
            return usersEntityCollections;
        }

        public Stream Users_SelectUserImageByUserName(string userName)
        {
            Stream stream = null;
            UsersDataController userDataController = new UsersDataController();
            stream = userDataController.Users_SelectUserImageByUserName(userName);
            return stream;
        }

        public Stream Users_SelectUserImageByUserID(string userID)
        {
            Stream stream = null;
            UsersDataController userDataController = new UsersDataController();
            stream = userDataController.Users_SelectUserImageByUserID(userID);
            return stream;
        }

        private void Fill(IDataReader dataReader, UsersEntity usersEntity)
        {
            if (!(dataReader["UserID"] is DBNull))
            {
                usersEntity.UserID = dataReader["UserID"].ToString();
            }
            if (!(dataReader["UserName"] is DBNull))
            {
                usersEntity.UserName = dataReader["UserName"].ToString();
            }
            if (!(dataReader["Password"] is DBNull))
            {
                usersEntity.Password = dataReader["Password"].ToString();
            }
            if (!(dataReader["DateOfBirth"] is DBNull))
            {
                usersEntity.DateOfBirth = dataReader["DateOfBirth"].ToString();
            }
            if (!(dataReader["Gender"] is DBNull))
            {
                usersEntity.Gender = dataReader["Gender"].ToString();
            }
            if (!(dataReader["IP"] is DBNull))
            {
                usersEntity.IP = dataReader["IP"].ToString();
            }
            if (!(dataReader["Email"] is DBNull))
            {
                usersEntity.Email = dataReader["Email"].ToString();
            }
            if (!(dataReader["PaypalEmail"] is DBNull))
            {
                usersEntity.PaypalEmail= dataReader["PaypalEmail"].ToString();
            }
            if (!(dataReader["Balance"] is DBNull))
            {
                usersEntity.Balance = Convert.ToDecimal(dataReader["Balance"]);
            }
            if (!(dataReader["AdsClicked"] is DBNull))
            {
                usersEntity.AdsClicked = dataReader["AdsClicked"].ToString();
            }
            if (!(dataReader["PasswordQuestion"] is DBNull))
            {
                usersEntity.PasswordQuestion = dataReader["PasswordQuestion"].ToString();
            }
            if (!(dataReader["PasswordAnswer"] is DBNull))
            {
                usersEntity.PasswordAnswer = dataReader["PasswordAnswer"].ToString();
            }
            if (!(dataReader["Phone"] is DBNull))
            {
                usersEntity.Phone = dataReader["Phone"].ToString();
            }
            if (!(dataReader["Address"] is DBNull))
            {
                usersEntity.Address = dataReader["Address"].ToString();
            }
            if (!(dataReader["UserImage"] is DBNull))
            {
                usersEntity.UserImage = (Byte[])(dataReader["UserImage"]);
            }
            if (!(dataReader["IsApproved"] is DBNull))
            {
                usersEntity.IsApproved = Convert.ToBoolean(dataReader["IsApproved"]);

            }
            if (!(dataReader["Active"] is DBNull))
            {
                usersEntity.Active = Convert.ToBoolean(dataReader["Active"]);
            }

            if (!(dataReader["TS"] is DBNull))
            {
                usersEntity.TS = (byte[])(dataReader["TS"]);
            }

            if (!(dataReader["CreatedDate"] is DBNull))
            {
                usersEntity.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
            }
            else
            {
                usersEntity.CreatedDate = DateTime.MinValue;
            }
            if (!(dataReader["CreatedUserID"] is DBNull))
            {
                usersEntity.CreatedUserID = Convert.ToString(dataReader["CreatedUserID"]);
            }

            if (!(dataReader["UpdatedDate"] is DBNull))
            {
                usersEntity.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
            }
            else
            {
                usersEntity.UpdatedDate = DateTime.MinValue;
            }
            if (!(dataReader["UpdatedUserID"] is DBNull))
            {
                usersEntity.UpdatedUserID = Convert.ToString(dataReader["UpdatedUserID"]);
            }
        }
    }
}
