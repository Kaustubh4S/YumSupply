using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Stocks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory();
            LoadProduct();
        }
    }

    private void LoadBrand()
    {
        try
        {
            string strcmd = "Select BrandID, BrandName from Brands order by BrandName";
            DataTable dt = SQLHelper.FillData(strcmd);
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataSource = dt;
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("~Select Brand~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadCategory()
    {
        try
        {
            string strcmd = "SELECT Category.CategoryID, Category.CategoryName FROM Category INNER JOIN Product ON Category.CategoryID = Product.CategoryID WHERE Product.BrandID = @0 ORDER BY Category.CategoryName";
            DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadProduct()
    {
        try
        {
            string strcmd = "SELECT ProductID, ProductName FROM Product WHERE BrandID = @0 or CategoryID=@1 ORDER BY ProductName";
            DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue);
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductID";
            ddlProduct.DataSource = dt;
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProduct();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProduct();
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}