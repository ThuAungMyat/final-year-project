using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using PTC.BusinessLogic;
using PTC.DataAccess;
using PTC.Entities;
using PTC.Utilities;
using System.Web.Security;

public partial class Account_Register : System.Web.UI.Page
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
        string ip = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
        lblIP.Text = "IP Address: " + ip;
       
        
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            BindRoles();
        }
    }

    //public static string GetClientIpAddress(HttpRequestBase request)
    //{
    //    try
    //    {
    //        var userHostAddress = request.UserHostAddress;

    //        // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
    //        // Could use TryParse instead, but I wanted to catch all exceptions
    //        IPAddress.Parse(userHostAddress);

    //        var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

    //        if (string.IsNullOrEmpty(xForwardedFor))
    //            return userHostAddress;

    //        // Get a list of public ip addresses in the X_FORWARDED_FOR variable
    //        var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

    //        // If we found any, return the last one, otherwise return the user host address
    //        return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
    //    }
    //    catch (Exception)
    //    {
    //        // Always return all zeroes for any failure (my calling code expects it)
    //        return "0.0.0.0";
    //    }
      
    //}

    //private static bool IsPrivateIpAddress(string ipAddress)
    //{
    //    // http://en.wikipedia.org/wiki/Private_network
    //    // Private IP Addresses are: 
    //    //  24-bit block: 10.0.0.0 through 10.255.255.255
    //    //  20-bit block: 172.16.0.0 through 172.31.255.255
    //    //  16-bit block: 192.168.0.0 through 192.168.255.255
    //    //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

    //    var ip = IPAddress.Parse(ipAddress);
    //    var octets = ip.GetAddressBytes();

    //    var is24BitBlock = octets[0] == 10;
    //    if (is24BitBlock) return true; // Return to prevent further processing

    //    var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
    //    if (is20BitBlock) return true; // Return to prevent further processing

    //    var is16BitBlock = octets[0] == 192 && octets[1] == 168;
    //    if (is16BitBlock) return true; // Return to prevent further processing

    //    var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
    //    return isLinkLocalAddress;
    //}

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

                List<string> newRoles = new List<string>();
                foreach (ListItem item in chklRoles.Items)
                {
                    if (item.Selected)
                        newRoles.Add(item.Text);
                }

                if (newRoles.Count > 0)
                {
                    Roles.AddUserToRoles(txtUserName.Text, newRoles.ToArray());
                }

                CreateAccountResults.Text = "The user account was successfully created!";
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

    private void BindRoles()
    {
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();
        foreach (string role in Roles.GetRolesForUser(txtUserName.Text))
            chklRoles.Items.FindByText(role).Selected = true;
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
        if (rdoMale.Checked)
        {
            usersEntity.Gender = "Male";
        }
        else
        {
            usersEntity.Gender = "Female";
        }
        usersEntity.Email = txtEmail.Text;
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
