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

public partial class AdsPackage : System.Web.UI.Page
{
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
            Bind_gvAdsPackage();
        }
    }
    #endregion

    #region Controls Methods

    protected void butSave_Click(object sender, EventArgs e)
    {
        try
        {
            AdsPackageEntity adspackageEntity = new AdsPackageEntity();
            AdsPackageLogicController adspackageLogicController = new AdsPackageLogicController();
            BindAdsPackageEntity(adspackageEntity);

            if (butSave.Text == "Save")
            {
                adspackageLogicController.AdsPackage_Insert(adspackageEntity);
                lblMessage.Text = "Save Successfully.";
            }
            if (butSave.Text == "Update")
            {
                adspackageEntity.AdsPackageID = AdsPackageID;
                adspackageEntity.TS = TS;
                adspackageLogicController.AdsPackage_Update(adspackageEntity);
                lblMessage.Text = "Update Successfully.";
                butSave.Text = "Save";
            }

            ClearControls();
            gvAdsPackage.SelectedIndex = -1;
            Bind_gvAdsPackage();
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
        gvAdsPackage.SelectedIndex = -1;
        Bind_gvAdsPackage();
        butSave.Text = "Save";
        lblMessage.Text = string.Empty;
    }

    protected void gvAdsPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Bind_gvAdsPackage();
        gvAdsPackage.PageIndex = e.NewPageIndex;
        gvAdsPackage.DataBind();
    }

    protected void gvAdsPackage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AdsPackageID = e.CommandArgument.ToString();
        AdsPackageEntity adspackageEntity = new AdsPackageEntity();
        AdsPackageLogicController adspackageLogicController = new AdsPackageLogicController();

        if (e.CommandName == "DataSelect")
        {
            adspackageEntity = adspackageLogicController.SelectByAdsPackageID(AdsPackageID);
            TS = adspackageEntity.TS;
            txtClicks.Text = adspackageEntity.Clicks;
            txtPrice.Text = Convert.ToString(adspackageEntity.Price);
            txtPerClick.Text = Convert.ToString(adspackageEntity.PerClick);
            butSave.Text = "Update";
        }
        else if (e.CommandName == "DataDelete")
        {
            adspackageLogicController.AdsPackage_DeleteByAdsPackageID(AdsPackageID, adspackageEntity.UpdatedUserID);
            lblMessage.Text = "Delete Successfully.";
            ClearControls();
            butSave.Text = "Save";
            Bind_gvAdsPackage();
        }
    }
    #endregion

    #region Helper Methods

    private void Bind_gvAdsPackage()
    {
        AdsPackageLogicController adspackageLogicController = new AdsPackageLogicController();
        gvAdsPackage.DataSource = adspackageLogicController.SelectList();
        gvAdsPackage.DataBind();
    }

    protected void BindAdsPackageEntity(AdsPackageEntity adspackageEntity)
    {
       
        adspackageEntity.Clicks = txtClicks.Text;
        adspackageEntity.Price = Convert.ToDecimal(txtPrice.Text);
        adspackageEntity.PerClick = Convert.ToDecimal(txtPerClick.Text);
        adspackageEntity.Active = true;

    }

    private void ClearControls()
    {
        txtClicks.Text = string.Empty;
        txtPrice.Text = string.Empty;
        txtPerClick.Text = string.Empty;
    }
    #endregion

    protected void txtPrice_TextChanged(object sender, EventArgs e)
    {
        decimal price = Convert.ToDecimal(txtPrice.Text);
        int clicks = Convert.ToInt32(txtClicks.Text);
        txtPerClick.Text = Convert.ToString(price / clicks);

        if(clicks>price)
        {
            lblMessage.Text = "";
        }
    }
}

