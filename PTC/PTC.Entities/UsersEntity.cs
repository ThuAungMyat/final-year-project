using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Linq;
using System.Text;

namespace PTC.Entities
{
    public class UsersEntity
    {
        public UsersEntity()
        {
        }

        private String userID;
        public String UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        private String userName;
        public String UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        private String password;
        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        private string dateOfBirth;
        public string DateOfBirth
        {
            get { return this.dateOfBirth; }
            set { this.dateOfBirth = value; }
        }

        private String gender;
        public String Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        private String iP;
        public String IP
        {
            get { return iP; }
            set { iP = value; }
        }

        private String email;
        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        private String paypalEmail;
        public String PaypalEmail
        {
            get { return paypalEmail; }
            set { paypalEmail = value; }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private String adsClicked;
        public String AdsClicked
        {
            get { return adsClicked; }
            set { adsClicked = value; }
        }

        private String passwordQuestion;
        public String PasswordQuestion
        {
            get { return this.passwordQuestion; }
            set { this.passwordQuestion = value; }
        }

        private String passwordAnswer;
        public String PasswordAnswer
        {
            get { return this.passwordAnswer; }
            set { this.passwordAnswer = value; }
        }

        private String phone;
        public String Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        private String address;
        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        private byte[] userImage;
        public byte[] UserImage
        {
            get { return this.userImage; }
            set { this.userImage = value; }
        }

        private int usersCount;
        public int UsersCount
        {
            get { return this.usersCount; }
            set { this.usersCount = value; }
        }

        private bool isApproved;
        public bool IsApproved
        {
            get { return this.isApproved; }
            set { this.isApproved = value; }
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

    public class UsersEntityCollections : Collection<UsersEntity> { }
}
