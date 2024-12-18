using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password))
        {
            //Get the logged user ProviderKey
            string sMemberLoginGUID = Membership.GetUser(LoginUser.UserName).ProviderUserKey.ToString();

            //Get the logged in username and ProviderKey
            MembershipUser user = Membership.GetUser(LoginUser.UserName);
            Guid usrguid = (Guid)user.ProviderUserKey;

            Session["UserName"] = user.UserName.ToString();
            Session["UserID"] = user.ProviderUserKey.ToString();

            Response.Redirect("~/Default.aspx");
        }
    }
}