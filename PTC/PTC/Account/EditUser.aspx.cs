using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_EditUser : System.Web.UI.Page
{
    string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // retrieve the username from the querystring
        userName = this.Request.QueryString["UserName"];

        //lblRolesFeedbackOK.Visible = false;
        //lblProfileFeedbackOK.Visible = false;
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!this.IsPostBack)
        {

            // show the user's details
            MembershipUser user = Membership.GetUser(userName);
            lblUserName.Text = user.UserName;
            lnkEmail.Text = user.Email;
            lnkEmail.NavigateUrl = "mailto:" + user.Email;
            lblRegistered.Text = user.CreationDate.ToString("f");
            lblLastLogin.Text = user.LastLoginDate.ToString("f");
            lblLastActivity.Text = user.LastActivityDate.ToString("f");
            chkOnlineNow.Checked = user.IsOnline;
            chkApproved.Checked = user.IsApproved;
            chkLockedOut.Checked = user.IsLockedOut;
            chkLockedOut.Enabled = user.IsLockedOut;

            BindRoles();

        }
    }

    private void BindRoles()
    {
        // fill the CheckBoxList with all the available roles, and then select
        // those that the user belongs to
        chklRoles.DataSource = Roles.GetAllRoles();
        chklRoles.DataBind();
        foreach (string role in Roles.GetRolesForUser(userName))
            chklRoles.Items.FindByText(role).Selected = true;
    }

    protected void chkApproved_CheckedChanged(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(userName);
        user.IsApproved = chkApproved.Checked;
        Membership.UpdateUser(user);
    }

    protected void chkLockedOut_CheckedChanged(object sender, EventArgs e)
    {
        if (!chkLockedOut.Checked)
        {
            MembershipUser user = Membership.GetUser(userName);
            user.UnlockUser();
            chkLockedOut.Enabled = false;
        }
    }

    protected void chklRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        // first remove the user from all roles...
        string[] currRoles = Roles.GetRolesForUser(userName);
        if (currRoles.Length > 0)
            Roles.RemoveUserFromRoles(userName, currRoles);
        // and then add the user to the selected roles
        List<string> newRoles = new List<string>();
        foreach (ListItem item in chklRoles.Items)
        {
            if (item.Selected)
                newRoles.Add(item.Text);
        }

        if (newRoles.Count > 0)
        {
            Roles.AddUserToRoles(userName, newRoles.ToArray());
        }
    }
}