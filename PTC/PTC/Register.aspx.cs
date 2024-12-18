using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
    UsersLogicController usersLogicController;
    UsersEntity usersEntity = new UsersEntity();
    string Errmsg = string.Empty;


    String UserID
    {
        get
        {
            if (Request.QueryString["UserID"] != null)
                return Request.QueryString["UserID"];
            return string.Empty;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //string ip = HttpContext.Current.Request.UserHostAddress;
        string ip = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
        //lblIP.Text = "IP Address: " + ip;
        ViewState["IP"] = ip;
        txtIP.Text = ip;

        if (Session["UserID"] != null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {

        }
    }

    #region Controls Methods

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus createStatus;
        MembershipUser newUser;
        newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, txtSecurityQuestion.Text, txtSecurityAnswer.Text, true, out createStatus);

        switch (createStatus)
        {
            case MembershipCreateStatus.Success:

                newUser = Membership.GetUser(txtUserName.Text);
                Guid newUserId = (Guid)newUser.ProviderUserKey;

                usersEntity.UserID = newUserId.ToString();
                BindUserInfo(usersEntity);
                UsersLogicController userLogicController = new UsersLogicController();
                userLogicController.Users_Insert(usersEntity, ref Errmsg);


                Roles.AddUserToRole(txtUserName.Text, "Member");

                //CreateAccountResults.Text = "The user account was successfully created!";
                break;

            case MembershipCreateStatus.DuplicateUserName:
                CreateAccountResults.Text = "There already exists a user with this username.";
                break;

            case MembershipCreateStatus.DuplicateEmail:
                CreateAccountResults.Text = "There already exists a user with this email address.";
                break;

            case MembershipCreateStatus.InvalidEmail:
                CreateAccountResults.Text = "There email address you provided in invalid.";
                break;

            case MembershipCreateStatus.InvalidAnswer:
                CreateAccountResults.Text = "There security answer was invalid.";
                break;

            case MembershipCreateStatus.InvalidPassword:
                CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
                break;

            default:
                CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                break;
        }
        ClearControls();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    private void ClearControls()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtDateOfBirth.Text = "";
        txtEmail.Text = "";
        txtSecurityQuestion.Text = "";
        txtSecurityAnswer.Text = "";
        txtPhoneNo.Text = "";
        txtEmail.Text = "";
    }

    #endregion

    #region Helper Method

    protected void BindUserInfo(UsersEntity usersEntity)
    {
        usersEntity.UserName = txtUserName.Text;
        usersEntity.Password = txtPassword.Text;
        usersEntity.DateOfBirth = txtDateOfBirth.Text;
        usersEntity.IP = txtPaypalEmail.Text;
        if (rdoMale.Checked)
        {
            usersEntity.Gender = "Male";
        }
        else
        {
            usersEntity.Gender = "Female";
        }
        usersEntity.Email = txtEmail.Text;
        usersEntity.PaypalEmail = txtPaypalEmail.Text;
        usersEntity.PasswordQuestion = txtSecurityQuestion.Text;
        usersEntity.PasswordAnswer = txtSecurityAnswer.Text;
        usersEntity.Phone = txtPhoneNo.Text;
        usersEntity.Address = txtAddress.Text;
        usersEntity.IsApproved = true;
        usersEntity.Active = true;

        if (UploadUserImage.HasFile)
        {
            Bitmap bm = new Bitmap(UploadUserImage.PostedFile.InputStream);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, bm.RawFormat);
            usersEntity.UserImage = ms.ToArray();
        }
    }


    #endregion
}