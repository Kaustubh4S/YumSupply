using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadBrand();
    }


    private void LoadBrand()
    {
        string strcmd = "Select BrandID, BrandName from Brands order by BrandName";
        DataTable dt = SQLHelper.FillData(strcmd);
        ddlBrand.DataTextField = "BrandName";
        ddlBrand.DataValueField = "BrandID";
        ddlBrand.DataSource = dt;
        ddlBrand.DataBind();
        ddlBrand.Items.Insert(0, new ListItem("~Select Brand~", "-1"));
    }

    protected void ddlBrands_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}