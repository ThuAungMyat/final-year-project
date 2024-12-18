using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTC.DataAccess;
using PTC.Entities;

namespace PTC.BusinessLogic
{
    public class UsersInRolesLogicController
    {
        public UsersInRolesLogicController()
        {

        }

        #region Insert Methods
        public void UsersInRoles_Insert(string userName,string roleName)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            usersinrolesDataController.UsersInRoles_Insert(userName,roleName);
        }
        #endregion

        #region Update Methods
        public void UsersInRoles_Update(UsersInRolesEntity usersinrolesEntity)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            usersinrolesDataController.UsersInRoles_Update(usersinrolesEntity);
        }
        #endregion

        #region Delete Methods

        public void UsersInRoles_DeleteByUserProfileID(string userprofileidID, string updatedUserID)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            usersinrolesDataController.UsersInRoles_DeleteByUserProfileID(userprofileidID, updatedUserID);
        }
        #endregion

        #region SelectList Methods
        public UsersInRolesEntityCollections SelectList()
        {
            UsersInRolesEntityCollections usersinrolesEntityCollections = new UsersInRolesEntityCollections();

            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            IDataReader dataReader = usersinrolesDataController.UsersInRoles_SelectList();
            while (dataReader.Read())
            {
                UsersInRolesEntity usersinrolesEntity = new UsersInRolesEntity();

                this.Fill(dataReader, usersinrolesEntity);

                usersinrolesEntityCollections.Add(usersinrolesEntity);
            }
            dataReader.Close();
            return usersinrolesEntityCollections;
        }


        public UsersInRolesEntity SelectByUserProfileID(string userprofileidID)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            IDataReader dataReader = usersinrolesDataController.UsersInRoles_SelectByUserProfileID(userprofileidID);
            UsersInRolesEntity usersinrolesEntity = new UsersInRolesEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, usersinrolesEntity);
            }
            dataReader.Close();
            return usersinrolesEntity;
        }

        public void UsersInRoles_DeleteByUsersFromRoles(string userName, string roleName)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            usersinrolesDataController.UsersInRoles_DeleteByUsersFromRoles(userName, roleName);
        }

        public UsersInRolesEntity UsersInRoles_IsUserInRole(string userName, string roleName)
        {
            UsersInRolesDataController usersinrolesDataController = new UsersInRolesDataController();
            IDataReader dataReader = usersinrolesDataController.UsersInRoles_IsUserInRole(userName,roleName);
            UsersInRolesEntity usersinrolesEntity = new UsersInRolesEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, usersinrolesEntity);
            }
            dataReader.Close();
            return usersinrolesEntity;
        }
        #endregion

        private void Fill(IDataReader dataReader, UsersInRolesEntity usersinrolesEntity)
        {
            if (!(dataReader["UserID"] is DBNull))
            {
                usersinrolesEntity.UserID = Convert.ToString(dataReader["UserID"]);

            }
            if (!(dataReader["RoleID"] is DBNull))
            {
                usersinrolesEntity.RoleID = Convert.ToString(dataReader["RoleID"]);

            }
        }

    }
}

