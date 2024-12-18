using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        string UserName = Session["UserName"].ToString();

        if (!this.IsPostBack)
        {
            string str = string.Empty;
            string[] strRoleNames = Roles.GetRolesForUser(UserName);

            foreach (string strRole in strRoleNames)
            {
                if (strRole == "Administrator")
                {
                    PanelAdmin.Visible = true;
                    return;
                }
            }

            foreach (string strRole in strRoleNames)
            {
                if (strRole == "Member")
                {
                    PanelAdmin.Visible = false;
                    return;
                }
            }
        }
    }
}