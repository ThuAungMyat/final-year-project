using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTC.BusinessLogic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private String UserName
    {
        get
        {
            if (Session["UserName"] != null)
                return Session["UserName"].ToString();
            return string.Empty;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "PTC";
        if (!IsPostBack)
        {
            lblDateTime.Text = String.Format("{0:D}\n", DateTime.Now).ToString();

            if (Session["UserName"] != null)
            {
                Bind_dlMember();
                Bind_dlAccount();
                lbtnLogin.Text = "Sign Out";
                lbtnLogin.PostBackUrl = ("~/Logout.aspx");
            }
        }
    }

    private void Bind_dlMember()
    {
        UsersLogicController usersLogicController = new UsersLogicController();
        dlMember.DataSource = usersLogicController.Users_SelectAllUserByUserName(UserName);
        dlMember.DataBind();
    }

    private void Bind_dlAccount()
    {
        UsersLogicController usersLogicController = new UsersLogicController();
        dlAccount.DataSource = usersLogicController.Users_SelectAllUserByUserName(UserName);
        dlAccount.DataBind();
    }
}
