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

    public partial class ViewAds : System.Web.UI.Page
    {
        public const string InvalidPage = "InvalidPage";

        private String UserID
        {
            get
            {
                if (Session["UserID"] != null)
                    return Session["UserID"].ToString();
                return string.Empty;
            }
        }

        private String AdsID
        {
            get
            {
                object obj = ViewState["AdsID"];
                return obj == null ? string.Empty : obj.ToString();
            }
            set
            {
                ViewState["AdsID"] = value;
            }
        }

        private bool IsGenerated
        {
            get
            {

                if (Session["IsGenerated"] == null)
                {

                    Session["IsGenerated"] = false;
                }

                return (bool)Session["IsGenerated"];
            }

            set
            {

                Session["IsGenerated"] = value;
            }
        }
        
        private String AdsPackageID
        {
            get
            {
                object obj = ViewState["AdsPackageID"];
                return obj == null ? string.Empty : obj.ToString();
            }
            set
            {
                ViewState["AdsPackageID"] = value;
            }
        }

        private byte[] TS
        {
            get
            {
                object obj = ViewState["TS"];
                return obj == null ? null : ((byte[])obj);
            }
            set
            {
                ViewState["TS"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (this.IsGenerated == false)
            {
                AdsLogicController AdsController = new AdsLogicController();
                AdsController.GenerateAds(Convert.ToString(Session["UserID"]));
                this.IsGenerated = true;
            }

            Bind_gvAds();


        }

        private void Bind_gvAds()
        {
            AdsLogicController adsLogicController = new AdsLogicController();
            gvAds.DataSource = adsLogicController.ViewAds(Convert.ToString(Session["UserID"]));
            gvAds.DataBind();
        }

        protected void gvAds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Bind_gvAds();
            gvAds.PageIndex = e.NewPageIndex;
            gvAds.DataBind();
        }

        public string GetWindowName()
        {
            if (Session["WindowName"] != null)
            {
                string WindowName = Session["WindowName"].ToString();
                return WindowName;
            }
            else
            {
                return InvalidPage;
            }
        }
    }
