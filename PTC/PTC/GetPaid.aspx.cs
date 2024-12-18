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


    public partial class GetPaid : System.Web.UI.Page
    {

        private String UserID
        {
            get
            {
                if (Session["UserID"] != null)
                    return Session["UserID"].ToString();
                return string.Empty;
            }
        }

        private string adsID;
        private string AdsID
        {
            get
            {
                if (Request.QueryString["adsid"] != null)
                {
                    this.adsID = Request.QueryString["adsid"];
                }
                else
                {
                    this.adsID = string.Empty;
                }

                return this.adsID;
            }
        }

        private string adsURL;
        private string AdsURL
        {
            get
            {
                if (Request.QueryString["adsurl"] != null)
                {
                    this.adsURL = Request.QueryString["adsurl"];
                }
                else
                {
                    this.adsURL = string.Empty;
                }

                return this.adsURL;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            //Adding attribute to HTML control 
            frame.Attributes.Add("src", AdsURL);
            Panel1.Visible = false;

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Panel1.Visible = true;

         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (txtCaptcha.Text != "")
            {
                if (Session["randomStr"].ToString() == txtCaptcha.Text)
                {
                    //Response.Write("successful submission by Human");

                    AdsDataController Ads = new AdsDataController();
                    Ads.GenerateAdsUpdateByAdsID(UserID, AdsID);        
                    Response.Redirect(Convert.ToString(AdsURL).Trim(),false);

                }
                else
                {
                    Response.Write("Enter correct characters as shown in image.");
                }
            }
            else
            {
                Response.Write("Please enter characters shown in image in textbox");
            }
        }


    }
