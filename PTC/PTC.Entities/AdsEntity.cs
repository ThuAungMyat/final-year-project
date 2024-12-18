using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Text;

namespace PTC.Entities
{
    public class AdsEntity
    {
        public AdsEntity()
        {
        }

        private String adsID;
        public String AdsID
        {
            get { return this.adsID; }
            set { this.adsID = value; }
        }

        private String adsPackageID;
        public String AdsPackageID
        {
            get { return this.adsPackageID; }
            set { this.adsPackageID = value; }
        }

        private String clicks;
        public String Clicks
        {
            get { return clicks; }
            set { clicks = value; }
        }

        private String adsName;
        public String AdsName
        {
            get { return this.adsName; }
            set { this.adsName = value; }
        }

        private String adsDescription;
        public String AdsDescription
        {
            get { return this.adsDescription; }
            set { this.adsDescription = value; }
        }

        private String adsURL;
        public String AdsURL
        {
            get { return this.adsURL; }
            set { this.adsURL = value; }
        }

        private String perClick;
        public String PerClick
        {
            get { return perClick; }
            set { perClick = value; }
        }

        private bool active;
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        private byte[] tS;
        public byte[] TS
        {
            get { return this.tS; }
            set { this.tS = value; }
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return this.createdDate; }
            set { this.createdDate = value; }
        }

        private String createdUserID;
        public String CreatedUserID
        {
            get
            {
                if (string.IsNullOrEmpty(this.createdUserID))
                {
                    if (HttpContext.Current.Session["UserID"] == null)
                    {
                        this.createdUserID = string.Empty;
                    }
                    else
                    {
                        this.createdUserID = HttpContext.Current.Session["UserID"].ToString();
                    }
                }

                return this.createdUserID;
            }

            set { this.createdUserID = value; }
        }

        private DateTime updatedDate;
        public DateTime UpdatedDate
        {
            get { return this.updatedDate; }
            set { this.updatedDate = value; }
        }

        private String updatedUserID;
        public String UpdatedUserID
        {
            get
            {
                if (string.IsNullOrEmpty(this.updatedUserID))
                {
                    if (HttpContext.Current.Session["UserID"] == null)
                    {
                        this.updatedUserID = string.Empty;
                    }
                    else
                    {
                        this.updatedUserID = HttpContext.Current.Session["UserID"].ToString();
                    }
                }

                return this.updatedUserID;
            }

            set { this.updatedUserID = value; }
        }

        private double adsClicksLeft;
        public double AdsClicksLeft
        {
            get { return this.adsClicksLeft; }
            set { this.adsClicksLeft = value; }
        }

    }

    public class AdsEntityCollections : Collection<AdsEntity> { }
}
