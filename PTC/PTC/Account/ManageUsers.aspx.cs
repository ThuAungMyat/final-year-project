using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using PTC.BusinessLogic;
using PTC.DataAccess;
using PTC.Entities;
using PTC.Utilities;

public partial class Account_ManageUsers : System.Web.UI.Page
{
    private MembershipUserCollection allUsers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            allUsers = Membership.GetAllUsers();
            BindUsers(true);
            lblTotalUsers.Text = allUsers.Count.ToString();
            lblOnlineUsers.Text = Membership.GetNumberOfUsersOnline().ToString();
            lblCurrentUser.Text = Membership.GetUser().ToString();
            string[] alphabet = "A;B;C;D;E;F;G;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z;All".Split(';');
            rptAlphabet.DataSource = alphabet;
            rptAlphabet.DataBind();
        }
    }

    private void BindUsers(bool reloadAllUsers)
    {
        if (reloadAllUsers)
        {
            allUsers = Membership.GetAllUsers();
        }

        MembershipUserCollection users = null;

        string searchText = "";
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SearchText"]))
            searchText = gvUsers.Attributes["SearchText"];

        bool searchByEmail = false;
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SearchByEmail"]))
            searchByEmail = bool.Parse(gvUsers.Attributes["SearchByEmail"]);

        if (searchText.Length > 0)
        {
            if (searchByEmail)
                users = Membership.FindUsersByEmail(searchText);
            else
                users = Membership.FindUsersByName(searchText);
        }
        else
        {
            users = allUsers;
        }

        gvUsers.DataSource = users;
        gvUsers.DataBind();
    }

    protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string userName = gvUsers.DataKeys[e.RowIndex].Value.ToString();
        ProfileManager.DeleteProfile(userName);
        Membership.DeleteUser(userName);
        BindUsers(true);
        lblTotalUsers.Text = allUsers.Count.ToString();
    }

    protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (gvUsers.PageIndex + 1) + " Of " + gvUsers.PageCount;
        }
    }

    protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindUsers(true);
        gvUsers.PageIndex = e.NewPageIndex;
        gvUsers.DataBind();
    }

    protected void rptAlphabet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        gvUsers.Attributes.Add("SearchByEmail", false.ToString());
        if (e.CommandArgument.ToString().Length == 1)
        {
            gvUsers.Attributes.Add("SearchText", e.CommandArgument.ToString() + "%");
            BindUsers(false);
        }
        else
        {
            gvUsers.Attributes.Add("SearchText", "");
            BindUsers(false);
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bool searchByEmail = (ddlSearchTypes.SelectedValue == "E-mail");
        gvUsers.Attributes.Add("SearchText", "%" + txtSearchText.Text + "%");
        gvUsers.Attributes.Add("SearchByEmail", searchByEmail.ToString());
        BindUsers(false);
    }

}