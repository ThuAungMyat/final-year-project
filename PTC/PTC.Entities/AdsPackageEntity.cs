using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Text;

namespace PTC.Entities
{
    public class AdsPackageEntity
    {
        public AdsPackageEntity()
        {
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
            get { return this.clicks; }
            set { this.clicks = value; }
        }

        private Decimal price;
        public Decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        private Decimal perClick;
        public Decimal PerClick
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

    }

    public class AdsPackageEntityCollections : Collection<AdsPackageEntity> { }
}
