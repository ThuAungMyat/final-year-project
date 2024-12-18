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

public partial class Ads : System.Web.UI.Page
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

    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            ClearControls();
            Bind_gvAds();
            ddlAdsPackage_DataBind();
        }
    }
    #endregion

    #region Controls Methods

    protected void butSave_Click(object sender, EventArgs e)
    {
        try
        {
            AdsEntity adsEntity = new AdsEntity();
            AdsLogicController adsLogicController = new AdsLogicController();
            BindAdsEntity(adsEntity);

            if (butSave.Text == "Save")
            {
                adsLogicController.Ads_Insert(adsEntity);
                lblMessage.Text = "Save Successfully.";
            }
            if (butSave.Text == "Update")
            {
                adsEntity.AdsID = AdsID;
                adsEntity.TS = TS;
                adsLogicController.Ads_Update(adsEntity);
                lblMessage.Text = "Update Successfully.";
                butSave.Text = "Save";
            }

            ClearControls();
            gvAds.SelectedIndex = -1;
            Bind_gvAds();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return;
        }
    }

    protected void butCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        gvAds.SelectedIndex = -1;
        Bind_gvAds();
        butSave.Text = "Save";
        lblMessage.Text = string.Empty;
    }

    protected void gvAds_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Bind_gvAds();
        gvAds.PageIndex = e.NewPageIndex;
        gvAds.DataBind();
    }

    protected void gvAds_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdsID = e.CommandArgument.ToString();
        AdsEntity adsEntity = new AdsEntity();
        AdsLogicController adsLogicController = new AdsLogicController();

        if (e.CommandName == "DataSelect")
        {
            adsEntity = adsLogicController.SelectByAdsID(AdsID);
            TS = adsEntity.TS;
            ddlAdsPackage.SelectedValue = adsEntity.AdsPackageID;
            txtAdsName.Text = adsEntity.AdsName;
            txtAdsDescription.Text = adsEntity.AdsDescription;
            txtAdsURL.Text = adsEntity.AdsURL;
            txtAdsClicksLeft.Text = Convert.ToString(adsEntity.AdsClicksLeft);
            butSave.Text = "Update";
        }
        else if (e.CommandName == "DataDelete")
        {
            adsLogicController.Ads_DeleteByAdsID(AdsID, adsEntity.UpdatedUserID);
            lblMessage.Text = "Delete Successfully.";
            ClearControls();
            butSave.Text = "Save";
            Bind_gvAds();
        }
    }
    #endregion

    #region Helper Methods

    private void Bind_gvAds()
    {
        AdsLogicController adsLogicController = new AdsLogicController();
        gvAds.DataSource = adsLogicController.SelectList();
        gvAds.DataBind();
    }

    private void ddlAdsPackage_DataBind()
    {
        AdsPackageLogicController Ads = new AdsPackageLogicController();
        ddlAdsPackage.DataValueField = "AdsPackageID";
        ddlAdsPackage.DataTextField = "Clicks";
        ddlAdsPackage.DataSource = Ads.SelectList();
        ddlAdsPackage.DataBind();
    
    }

    protected void BindAdsEntity(AdsEntity adsEntity)
    {
        adsEntity.AdsPackageID = ddlAdsPackage.SelectedValue;
        adsEntity.AdsName = txtAdsName.Text;
        adsEntity.AdsDescription = txtAdsDescription.Text;
        adsEntity.AdsURL = Convert.ToString(txtAdsURL.Text).Trim();
        adsEntity.AdsClicksLeft = Convert.ToInt32(txtAdsClicksLeft.Text);
        adsEntity.Active = true;
    }

    private void ClearControls()
    {
        ddlAdsPackage.SelectedIndex = -1;
        txtAdsName.Text = string.Empty;
        txtAdsDescription.Text = string.Empty;
        //txtAdsURL.Text = string.Empty;
        txtAdsClicksLeft.Text = string.Empty;
    }
    #endregion

    protected void ddlAdsPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAdsClicksLeft.Text = Convert.ToString(ddlAdsPackage.SelectedItem);
    }

}

