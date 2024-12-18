using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;

public partial class Account_ManageSingleRole : System.Web.UI.Page
{
    string strRoleName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        strRoleName = Session["RoleName"].ToString();
        lblRoleName.Text = strRoleName;
        Bind_gvRolesUserList();
    }

    private void Bind_gvRolesUserList()
    {
        string selectedRoleName = strRoleName;
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);
        gvRolesUserList.DataSource = usersBelongingToRole;
        gvRolesUserList.DataBind();
    }

    protected void gvRolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string selectedRoleName = strRoleName;

        Label UserNameLabel = gvRolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

        Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

        ActionStatus.Text = string.Format("User <b>{0}</b> was removed from role <b>{1}</b>.", UserNameLabel.Text, selectedRoleName);

        Bind_gvRolesUserList();
    }

    protected void btnAddUserToRole_Click(object sender, EventArgs e)
    {
        string selectedRoleName = strRoleName;
        string UserNameAddToRole = txtUserName.Text;

        if (UserNameAddToRole.Trim().Length == 0)
        {
            ActionStatus.Text = "You must enter a <b>UserName</b> in the textbox.";
            return;
        }

        MembershipUser userInfo = Membership.GetUser(UserNameAddToRole);
        if (userInfo == null)
        {
            ActionStatus.Text = string.Format("The user <b>{0}</b> does not exist in the system.", UserNameAddToRole);
            return;
        }

        if (Roles.IsUserInRole(UserNameAddToRole, selectedRoleName))
        {
            ActionStatus.Text = string.Format("User <b>{0}</b> already is a member of role <b>{1}</b>.", UserNameAddToRole, selectedRoleName);
            return;
        }

        Roles.AddUserToRole(UserNameAddToRole, selectedRoleName);

        txtUserName.Text = string.Empty;
        Bind_gvRolesUserList();

        ActionStatus.Text = string.Format("User <b>{0}</b> was added to role <b>{1}</b>.", UserNameAddToRole, selectedRoleName);
    }

    protected void gvRolesUserList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btn = e.Row.Cells[1].Controls[0] as ImageButton;
            btn.OnClientClick = "if (confirm('Are you sure you want to delete this user from Role?') == false) return false;";
        }
    }
}