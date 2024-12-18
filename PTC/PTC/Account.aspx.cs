using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using PTC.BusinessLogic;
using PTC.DataAccess;
using PTC.Entities;
using PTC.Utilities;

    public partial class Account : System.Web.UI.Page
    {
        private String UserID
        {
            get
            {
                if (Session["UserID"] != null)
                    return Session["UserID"].ToString();
                return string.Empty;
            }
        }

        private byte[] UserImage
        {
            get
            {
                object obj = ViewState["UserImage"];
                return obj == null ? null : ((byte[])obj);
            }
            set
            {
                ViewState["UserImage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            UsersEntity userentity = new UsersEntity();
            UsersLogicController usercontroller = new UsersLogicController();
            userentity = usercontroller.Users_SelectByUserID(UserID);
            bindcontrols(userentity);
            Bind_fvUserImage();
 


        }

        private void bindcontrols(UsersEntity userentity)
        {
            UserImage = userentity.UserImage;
            txtUserName.Text = userentity.UserName;
          
            txtDateOfBirth.Text = userentity.DateOfBirth;
            txtGender.Text = userentity.Gender;
            txtIP.Text = userentity.IP;
            txtEmail.Text = userentity.Email;
            txtPaypalEmail.Text = userentity.PaypalEmail;
            txtBalance.Text = Convert.ToString(userentity.Balance);
            txtAdsClicked.Text = userentity.AdsClicked;
            txtPasswordQuestion.Text = userentity.PasswordQuestion;
            txtPasswordAnswer.Text = userentity.PasswordAnswer;
            txtPhone.Text = userentity.Phone;
            txtAddress.Text = userentity.Address;
 
        }

        private void Bind_fvUserImage()
        {
            UsersLogicController usersLogicController = new UsersLogicController();
            fvUserImage.DataSource = usersLogicController.Users_SelectAllUserImageByUserID(UserID);
            fvUserImage.DataBind();
        }

        protected void lbtnStats_Click(object sender, EventArgs e)
        {
            AccountInfo.Visible = false;
            Stats.Visible = true;
        }

        protected void lbtnAccount_Click(object sender, EventArgs e)
        {
            Stats.Visible = false;
            AccountInfo.Visible = true;
        }


    }
