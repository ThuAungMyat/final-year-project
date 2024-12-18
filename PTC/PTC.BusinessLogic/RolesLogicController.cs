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
    public class RolesLogicController
    {
        public RolesLogicController()
        {

        }

        #region Insert Methods
        public void Roles_Insert(RolesEntity rolesEntity)
        {
            RolesDataController rolesDataController = new RolesDataController();
            rolesDataController.Roles_Insert(rolesEntity);
        }
        #endregion

        #region Update Methods
        public void Roles_Update(RolesEntity rolesEntity)
        {
            RolesDataController rolesDataController = new RolesDataController();
            rolesDataController.Roles_Update(rolesEntity);
        }
        #endregion

        #region Delete Methods

        public void Roles_DeleteByRolesID(string rolesID, string updatedUserID)
        {
            RolesDataController rolesDataController = new RolesDataController();
            rolesDataController.Roles_DeleteByRolesID(rolesID, updatedUserID);
        }
        #endregion

        #region SelectList Methods
        public RolesEntityCollections SelectList()
        {
            RolesEntityCollections rolesEntityCollections = new RolesEntityCollections();

            RolesDataController rolesDataController = new RolesDataController();
            IDataReader dataReader = rolesDataController.Roles_SelectList();
            while (dataReader.Read())
            {
                RolesEntity rolesEntity = new RolesEntity();

                this.Fill(dataReader, rolesEntity);

                rolesEntityCollections.Add(rolesEntity);
            }
            dataReader.Close();
            return rolesEntityCollections;
        }

        public RolesEntityCollections UsersInRoles_SelectRolesForUser(string userprofileID)
        {
            RolesEntityCollections rolesEntityCollections = new RolesEntityCollections();

            RolesDataController rolesDataController = new RolesDataController();
            IDataReader dataReader = rolesDataController.UsersInRoles_SelectRolesForUser(userprofileID);
            while (dataReader.Read())
            {
                RolesEntity rolesEntity = new RolesEntity();

                if (!(dataReader["RoleName"] is DBNull))
                {
                    rolesEntity.RoleName = Convert.ToString(dataReader["RoleName"]);
                }

                rolesEntityCollections.Add(rolesEntity);
            }
            dataReader.Close();
            return rolesEntityCollections;
        }

        public RolesEntity SelectByRolesID(string rolesID)
        {
            RolesDataController rolesDataController = new RolesDataController();
            IDataReader dataReader = rolesDataController.Roles_SelectByRolesID(rolesID);
            RolesEntity rolesEntity = new RolesEntity();

            if (dataReader.Read())
            {
                this.Fill(dataReader, rolesEntity);
            }
            dataReader.Close();
            return rolesEntity;
        }
        #endregion

        private void Fill(IDataReader dataReader, RolesEntity rolesEntity)
        {
            if (!(dataReader["RoleID"] is DBNull))
            {
                rolesEntity.RoleID = Convert.ToString(dataReader["RoleID"]);

            }
            if (!(dataReader["RoleName"] is DBNull))
            {
                rolesEntity.RoleName = Convert.ToString(dataReader["RoleName"]);

            }
            if (!(dataReader["Active"] is DBNull))
            {
                rolesEntity.Active = Convert.ToBoolean(dataReader["Active"]);
            }

            if (!(dataReader["TS"] is DBNull))
            {
                rolesEntity.TS = (byte[])(dataReader["TS"]);
            }

            if (!(dataReader["CreatedDate"] is DBNull))
            {
                rolesEntity.CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"]);
            }
            else
            {
                rolesEntity.CreatedDate = DateTime.MinValue;
            }
            if (!(dataReader["CreatedUserID"] is DBNull))
            {
                rolesEntity.CreatedUserID = Convert.ToString(dataReader["CreatedUserID"]);
            }

            if (!(dataReader["UpdatedDate"] is DBNull))
            {
                rolesEntity.UpdatedDate = Convert.ToDateTime(dataReader["UpdatedDate"]);
            }
            else
            {
                rolesEntity.UpdatedDate = DateTime.MinValue;
            }
            if (!(dataReader["UpdatedUserID"] is DBNull))
            {
                rolesEntity.UpdatedUserID = Convert.ToString(dataReader["UpdatedUserID"]);
            }

        }

    }
}

