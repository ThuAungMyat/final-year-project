using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_ManageAllRoles : System.Web.UI.Page
{
    string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            Bind_gvRoles();
        }
    }

    protected void butSave_Click(object sender, EventArgs e)
    {
        if (!Roles.RoleExists(txtRoleName.Text.Trim()))
        {
            Roles.CreateRole(txtRoleName.Text.Trim());
            txtRoleName.Text = "";
            Bind_gvRoles();
        }
    }

    protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Bind_gvRoles();
        gvRoles.PageIndex = e.NewPageIndex;
        gvRoles.DataBind();
    }

    protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("ManageRole"))
        {
            GridViewRow val = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int RowIndex = val.RowIndex;
            Label value = (Label)gvRoles.Rows[RowIndex].FindControl("lblRoleName");
            Session["RoleName"] = value.Text;
            Response.Redirect("ManageSingleRole.aspx");
        }
    }

    protected void gvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblRoleName = gvRoles.Rows[e.RowIndex].FindControl("lblRoleName") as Label;

        Roles.DeleteRole(lblRoleName.Text, false);

        Bind_gvRoles();
    }

    protected void butCancel_Click(object sender, EventArgs e)
    {
        txtRoleName.Text = "";
    }

    private void Bind_gvRoles()
    {
        String[] list = Roles.GetAllRoles();
        gvRoles.DataSource = list;
        gvRoles.DataBind();
    }
    
}